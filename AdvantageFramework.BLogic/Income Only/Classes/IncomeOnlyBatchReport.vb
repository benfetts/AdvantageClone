Namespace IncomeOnly.Classes

    <Serializable()>
    Public Class IncomeOnlyBatchReport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SequenceNumber
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentID
            JobComponentDescription
            FunctionCode
            FunctionDescription
            TaxCode
            InvoiceDate
            Quantity
            Rate
            Amount
            CommissionPercent
            MarkupAmount
            Taxes
            CityTaxAmount
            CountyTaxAmount
            StateTaxAmount
            TotalAmount
            Description
            ReferenceNumber
            Comment
            BillingUser
            TaxStatePercent
            TaxCityPercent
            TaxCountyPercent
            TaxCommission
            TaxCommissionOnly
            TaxResale
            IsServiceFee
            IsBilled
            NonBillable
            SalesClassCode
            DepartmentTeamCode
            IsModified
            IsDeleted
            Status
            JobServiceFeeID
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentID As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _TaxCode As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _CommissionPercent As Nullable(Of Decimal) = Nothing
        Private _MarkupAmount As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Decimal = Nothing
        Private _Description As String = Nothing
        Private _ReferenceNumber As String = Nothing
        Private _Comment As String = Nothing
        Private _BillingUser As String = Nothing
        Private _TaxStatePercent As Nullable(Of Decimal) = Nothing
        Private _TaxCityPercent As Nullable(Of Decimal) = Nothing
        Private _TaxCountyPercent As Nullable(Of Decimal) = Nothing
        Private _TaxCommission As Nullable(Of Short) = Nothing
        Private _TaxCommissionOnly As Nullable(Of Short) = Nothing
        Private _TaxResale As Nullable(Of Short) = Nothing
        Private _IsServiceFee As Boolean = Nothing
        Private _IsBilled As Boolean = Nothing
        Private _NonBillable As Boolean = Nothing
        Private _SalesClassCode As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _IsModified As Boolean = False
        Private _ModifyDate As Nullable(Of Date) = Nothing
        Private _CityTaxAmount As Nullable(Of Decimal) = Nothing
        Private _CountyTaxAmount As Nullable(Of Decimal) = Nothing
        Private _StateTaxAmount As Nullable(Of Decimal) = Nothing
        Private _IsDeleted As Boolean = False
        Private _Status As String = Nothing
        Private _JobServiceFeeID As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobComponentID() As Nullable(Of Integer)
            Get
                JobComponentID = _JobComponentID
            End Get
            Set(value As Nullable(Of Integer))
                _JobComponentID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.EntityAttribute()>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CommissionPercent() As Nullable(Of Decimal)
            Get
                CommissionPercent = _CommissionPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _CommissionPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarkupAmount() As Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _MarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(value As String)
                _TaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Taxes() As Decimal
            Get
                Taxes = _CityTaxAmount.GetValueOrDefault(0) + _CountyTaxAmount.GetValueOrDefault(0) + _StateTaxAmount.GetValueOrDefault(0)
            End Get
            Set(value As Decimal)

            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TotalAmount() As Decimal
            Get
                TotalAmount = Math.Round(_Amount.GetValueOrDefault(0) + _MarkupAmount.GetValueOrDefault(0) + Me.Taxes, 2, MidpointRounding.AwayFromZero)
            End Get
            Set(value As Decimal)

            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ReferenceNumber() As String
            Get
                ReferenceNumber = _ReferenceNumber
            End Get
            Set(value As String)
                _ReferenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(value As String)
                _BillingUser = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsServiceFee As Boolean
            Get
                IsServiceFee = _IsServiceFee
            End Get
            Set(value As Boolean)
                _IsServiceFee = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsBilled() As Boolean
            Get
                IsBilled = _IsBilled
            End Get
            Set(value As Boolean)
                _IsBilled = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NonBillable() As Boolean
            Get
                NonBillable = _NonBillable
            End Get
            Set(value As Boolean)
                _NonBillable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CityTaxAmount As Nullable(Of Decimal)
            Get
                CityTaxAmount = _CityTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CityTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CountyTaxAmount As Nullable(Of Decimal)
            Get
                CountyTaxAmount = _CountyTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CountyTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StateTaxAmount As Nullable(Of Decimal)
            Get
                StateTaxAmount = _StateTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _StateTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TaxStatePercent() As Nullable(Of Decimal)
            Get
                TaxStatePercent = _TaxStatePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxStatePercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TaxCityPercent() As Nullable(Of Decimal)
            Get
                TaxCityPercent = _TaxCityPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxCityPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TaxCountyPercent() As Nullable(Of Decimal)
            Get
                TaxCountyPercent = _TaxCountyPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _TaxCountyPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TaxCommission() As Nullable(Of Short)
            Get
                TaxCommission = _TaxCommission
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommission = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TaxCommissionOnly() As Nullable(Of Short)
            Get
                TaxCommissionOnly = _TaxCommissionOnly
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionOnly = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TaxResale() As Nullable(Of Short)
            Get
                TaxResale = _TaxResale
            End Get
            Set(value As Nullable(Of Short))
                _TaxResale = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsModified() As Boolean
            Get
                IsModified = _IsModified
            End Get
            Set(value As Boolean)
                _IsModified = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsDeleted As Boolean
            Get
                IsDeleted = _IsDeleted
            End Get
            Set(value As Boolean)
                _IsDeleted = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ModifyDate As Nullable(Of Date)
            Get
                ModifyDate = _ModifyDate
            End Get
            Set(value As Nullable(Of Date))
                _ModifyDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Status As String
            Get
                Status = _Status
            End Get
            Set(value As String)
                _Status = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobServiceFeeID As Nullable(Of Integer)
            Get
                JobServiceFeeID = _JobServiceFeeID
            End Get
            Set(value As Nullable(Of Integer))
                _JobServiceFeeID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace

