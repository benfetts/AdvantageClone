Namespace IncomeOnly.Classes

    <Serializable()>
    Public Class IncomeOnlyHistory
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SequenceNumber
            JobNumber
            JobComponentNumber
            FunctionCode
            InvoiceDate
            Quantity
            Rate
            Amount
            ExtendedMarkupAmount
            ExtendedCityResale
            ExtendedCountyResale
            ExtendedStateResale
            LineTotal
            TaxCode
            NonBillable
            ModifiedDate
            ModifiedBy
            IsModified
            DeletedDate
            DeletedBy
            DeleteFlag
            TransferFromJob
            TransferFromJobComponent
            TransferFromFunction
            TransferAdjustedUser
            TransferAdjustedDate
            ARInvoiceNumber
            ARType
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _FunctionCode As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _ExtendedMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _ExtendedCityResale As Nullable(Of Decimal) = Nothing
        Private _ExtendedCountyResale As Nullable(Of Decimal) = Nothing
        Private _ExtendedStateResale As Nullable(Of Decimal) = Nothing
        Private _LineTotal As Nullable(Of Decimal) = Nothing
        Private _TaxCode As String = Nothing
        Private _NonBillable As Boolean = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _ModifiedBy As String = Nothing
        Private _IsModified As Boolean = Nothing
        Private _DeletedDate As Nullable(Of Date) = Nothing
        Private _DeletedBy As String = Nothing
        Private _DeleteFlag As Boolean = Nothing
        Private _TransferFromJob As Nullable(Of Integer) = Nothing
        Private _TransferFromJobComponent As Nullable(Of Short) = Nothing
        Private _TransferFromFunction As String = Nothing
        Private _TransferAdjustedUser As String = Nothing
        Private _TransferAdjustedDate As Nullable(Of Date) = Nothing
        Private _ARInvoiceNumber As Nullable(Of Integer) = Nothing
        Private _ARType As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Job Comp")>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Function")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Markup Amount")>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
            Get
                ExtendedMarkupAmount = _ExtendedMarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="City Tax Amount")>
        Public Property ExtendedCityResale() As Nullable(Of Decimal)
            Get
                ExtendedCityResale = _ExtendedCityResale
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedCityResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="County Tax Amount")>
        Public Property ExtendedCountyResale() As Nullable(Of Decimal)
            Get
                ExtendedCountyResale = _ExtendedCountyResale
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedCountyResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="State Tax Amount")>
        Public Property ExtendedStateResale() As Nullable(Of Decimal)
            Get
                ExtendedStateResale = _ExtendedStateResale
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedStateResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total")>
        Public Property LineTotal() As Nullable(Of Decimal)
            Get
                LineTotal = _LineTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _LineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(value As String)
                _TaxCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property NonBillable() As Boolean
            Get
                NonBillable = _NonBillable
            End Get
            Set(value As Boolean)
                _NonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Created/Modified Date")>
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="Created/Modified By")>
        Public Property ModifiedBy() As String
            Get
                ModifiedBy = _ModifiedBy
            End Get
            Set(value As String)
                _ModifiedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsModified() As Boolean
            Get
                IsModified = _IsModified
            End Get
            Set(value As Boolean)
                _IsModified = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property DeletedDate() As Nullable(Of Date)
            Get
                DeletedDate = _DeletedDate
            End Get
            Set(value As Nullable(Of Date))
                _DeletedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property DeletedBy() As String
            Get
                DeletedBy = _DeletedBy
            End Get
            Set(value As String)
                _DeletedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox, CustomColumnCaption:="Is Deleted")>
        Public Property DeleteFlag() As Boolean
            Get
                DeleteFlag = _DeleteFlag
            End Get
            Set(value As Boolean)
                _DeleteFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property TransferFromJob() As Nullable(Of Integer)
            Get
                TransferFromJob = _TransferFromJob
            End Get
            Set(value As Nullable(Of Integer))
                _TransferFromJob = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property TransferFromJobComponent() As Nullable(Of Short)
            Get
                TransferFromJobComponent = _TransferFromJobComponent
            End Get
            Set(value As Nullable(Of Short))
                _TransferFromJobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property TransferFromFunction() As String
            Get
                TransferFromFunction = _TransferFromFunction
            End Get
            Set(value As String)
                _TransferFromFunction = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property TransferAdjustedUser() As String
            Get
                TransferAdjustedUser = _TransferAdjustedUser
            End Get
            Set(value As String)
                _TransferAdjustedUser = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property TransferAdjustedDate() As Nullable(Of Date)
            Get
                TransferAdjustedDate = _TransferAdjustedDate
            End Get
            Set(value As Nullable(Of Date))
                _TransferAdjustedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ARInvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", CustomColumnCaption:="")>
        Public Property ARType() As String
            Get
                ARType = _ARType
            End Get
            Set(value As String)
                _ARType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly)

            _ID = IncomeOnly.ID
            _SequenceNumber = IncomeOnly.SequenceNumber
            _JobNumber = IncomeOnly.JobNumber
            _JobComponentNumber = IncomeOnly.JobComponentNumber
            _FunctionCode = IncomeOnly.FunctionCode
            _InvoiceDate = IncomeOnly.InvoiceDate
            _Quantity = IncomeOnly.Quantity
            _Rate = IncomeOnly.Rate
            _Amount = IncomeOnly.Amount
            _ExtendedMarkupAmount = IncomeOnly.ExtendedMarkupAmount
            _ExtendedCityResale = IncomeOnly.ExtendedCityResale
            _ExtendedCountyResale = IncomeOnly.ExtendedCountyResale
            _ExtendedStateResale = IncomeOnly.ExtendedStateResale
            _LineTotal = IncomeOnly.LineTotal
            _TaxCode = IncomeOnly.TaxCode
            _NonBillable = CBool(IncomeOnly.NonBillable.GetValueOrDefault(0))
            _ModifiedDate = IncomeOnly.ModifiedDate
            _ModifiedBy = IncomeOnly.ModifiedBy
            _IsModified = CBool(IncomeOnly.IsModified.GetValueOrDefault(0))
            _DeletedDate = IncomeOnly.DeletedDate
            _DeletedBy = IncomeOnly.DeletedBy
            _DeleteFlag = CBool(IncomeOnly.DeleteFlag.GetValueOrDefault(0))
            _TransferFromJob = IncomeOnly.TransferFromJob
            _TransferFromJobComponent = IncomeOnly.TransferFromJobComponent
            _TransferFromFunction = IncomeOnly.TransferFromFunction
            _TransferAdjustedUser = IncomeOnly.TransferAdjustedUser
            _TransferAdjustedDate = IncomeOnly.TransferAdjustedDate
            _ARInvoiceNumber = IncomeOnly.ARInvoiceNumber
            _ARType = IncomeOnly.ARType

        End Sub

#End Region

    End Class

End Namespace
