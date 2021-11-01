Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableOutOfHomeDistributionDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsDeleted
            ClientCode
            DivisionCode
            ProductCode
            PlanEstID
            OutdoorOrderNumber
            OutdoorDetailLineNumber
            PostDate
            ForeignGrossAmount
            GrossAmount
            ForeignNetAmount
            NetAmount
            ForeignDiscountAmount
            DiscountAmount
            ForeignNetCharges
            NetCharges
            ForeignVendorTax
            VendorTax
            ForeignDisbursedAmount
            DisbursedAmount
            PreviouslyPosted
            OrderNetAmount
            OrderNetBalance
            SalesTaxCode
            OfficeCode
            GLACode
            Status
            Comments
            NewApprovalStatus
            NewApprovalComments
            CurrencyRate
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableOutOfHome As AdvantageFramework.Database.Entities.AccountPayableOutOfHome = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _IsDeleted As Boolean = False
        Private _Status As String = Nothing
        Private _Comments As String = Nothing
        Private _NewApprovalStatus As Nullable(Of Short) = Nothing
        Private _NewApprovalComments As String = Nothing
        Private _GLADescription As String = Nothing
        Private _OrderNetAmount As Decimal = Nothing
        Private _GrossAmount As Nullable(Of Decimal) = Nothing
        Private _PlanEstID As String = Nothing
        Private _PostDate As Nullable(Of Date) = Nothing
        Private _OrderNetBalance As Decimal = Nothing
        Private _PreviouslyPosted As Decimal = Nothing
        Private _OutdoorOrderNumber As Nullable(Of Integer) = Nothing
        Private _OutdoorDetailLineNumber As Nullable(Of Short) = Nothing
        Private _ForeignGrossAmount As Decimal = Nothing
        Private _ForeignNetAmount As Decimal = Nothing
        Private _ForeignDiscountAmount As Decimal = Nothing
        Private _ForeignNetCharges As Decimal = Nothing
        Private _ForeignVendorTax As Decimal = Nothing
        Private _ForeignDisbursedAmount As Decimal = Nothing
        Private _CurrencyRate As Decimal = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.AccountPayableOutOfHome)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableOutOfHome As AdvantageFramework.Database.Entities.AccountPayableOutOfHome
            Get
                AccountPayableOutOfHome = _AccountPayableOutOfHome
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsDeleted() As Boolean
            Get
                IsDeleted = _IsDeleted
            End Get
            Set(ByVal value As Boolean)
                _IsDeleted = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property PlanEstID() As String
            Get
                PlanEstID = _PlanEstID
            End Get
            Set(ByVal value As String)
                _PlanEstID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Order")>
        Public Property OutdoorOrderNumber() As Nullable(Of Integer)
            Get
                OutdoorOrderNumber = _OutdoorOrderNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _OutdoorOrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Line")>
        Public Property OutdoorDetailLineNumber() As Nullable(Of Short)
            Get
                OutdoorDetailLineNumber = _OutdoorDetailLineNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorDetailLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostDate() As Nullable(Of Date)
            Get
                PostDate = _PostDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _PostDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignGrossAmount() As Decimal
            Get
                ForeignGrossAmount = _ForeignGrossAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignGrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property GrossAmount() As Nullable(Of Decimal)
            Get
                GrossAmount = _GrossAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignNetAmount() As Decimal
            Get
                ForeignNetAmount = _ForeignNetAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _AccountPayableOutOfHome.NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableOutOfHome.NetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignDiscountAmount() As Decimal
            Get
                ForeignDiscountAmount = _ForeignDiscountAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignDiscountAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                DiscountAmount = _AccountPayableOutOfHome.DiscountAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableOutOfHome.DiscountAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignNetCharges() As Decimal
            Get
                ForeignNetCharges = _ForeignNetCharges
            End Get
            Set(ByVal value As Decimal)
                _ForeignNetCharges = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NetCharges() As Nullable(Of Decimal)
            Get
                NetCharges = _AccountPayableOutOfHome.NetCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableOutOfHome.NetCharges = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property ForeignVendorTax() As Decimal
            Get
                ForeignVendorTax = _ForeignVendorTax
            End Get
            Set(ByVal value As Decimal)
                _ForeignVendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VendorTax() As Nullable(Of Decimal)
            Get
                VendorTax = _AccountPayableOutOfHome.VendorTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableOutOfHome.VendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property ForeignDisbursedAmount() As Nullable(Of Decimal)
            Get
                ForeignDisbursedAmount = Me.ForeignNetAmount - Me.ForeignDiscountAmount + Me.ForeignNetCharges + Me.ForeignVendorTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property DisbursedAmount() As Nullable(Of Decimal)
            Get
                DisbursedAmount = Me.NetAmount.GetValueOrDefault(0) - Me.DiscountAmount.GetValueOrDefault(0) + Me.NetCharges.GetValueOrDefault(0) + Me.VendorTax.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PreviouslyPosted() As Decimal
            Get
                PreviouslyPosted = _PreviouslyPosted
            End Get
            Set(ByVal value As Decimal)
                _PreviouslyPosted = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderNetAmount() As Decimal
            Get
                OrderNetAmount = _OrderNetAmount
            End Get
            Set(ByVal value As Decimal)
                _OrderNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderNetBalance() As Decimal
            Get
                OrderNetBalance = _OrderNetBalance
            End Get
            Set(ByVal value As Decimal)
                _OrderNetBalance = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Tax Code", PropertyType:=BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property SalesTaxCode() As String
            Get
                SalesTaxCode = _AccountPayableOutOfHome.SalesTaxCode
            End Get
            Set(ByVal value As String)
                _AccountPayableOutOfHome.SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountPayableOutOfHome.OfficeCode
            End Get
            Set(ByVal value As String)
                _AccountPayableOutOfHome.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _AccountPayableOutOfHome.GLACode
            End Get
            Set(ByVal value As String)
                _AccountPayableOutOfHome.GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Approval Status")>
        Public Property Status As String
            Get
                Status = _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Approval Comments")>
        Public Property Comments As String
            Get
                Comments = _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewApprovalStatus() As Nullable(Of Short)
            Get
                NewApprovalStatus = _NewApprovalStatus
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewApprovalStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewApprovalComments() As String
            Get
                NewApprovalComments = _NewApprovalComments
            End Get
            Set(ByVal value As String)
                _NewApprovalComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property GLADescription() As String
            Get
                GLADescription = _GLADescription
            End Get
            Set(ByVal value As String)
                _GLADescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CurrencyRate As Decimal
            Get
                CurrencyRate = _CurrencyRate
            End Get
            Set(value As Decimal)
                _CurrencyRate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Shared Sub CalculateTax(ByRef AccountPayableOutOfHomeDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail)

            Dim TotalTax As Decimal = Nothing
            Dim TaxableAmount As Decimal = 0

            TotalTax = AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.StateTaxPercent.GetValueOrDefault(0) + _
                       AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CityTaxPercent.GetValueOrDefault(0) + _
                       AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CountyTaxPercent.GetValueOrDefault(0)

            If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.IsResaleTax.GetValueOrDefault(0) = 1 Then

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.NetAmount.GetValueOrDefault(0)

                End If

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.DiscountAmount.GetValueOrDefault(0)

                End If

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.NetCharges.GetValueOrDefault(0)

                End If

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.StateTax = FormatNumber(AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CountyTax = FormatNumber(AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CityTax = FormatNumber(AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

                AccountPayableOutOfHomeDistributionDetail.VendorTax = 0

            Else

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.NetAmount.GetValueOrDefault(0)

                End If

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.DiscountAmount.GetValueOrDefault(0)

                End If

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.NetCharges.GetValueOrDefault(0)

                End If

                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.VendorTax = FormatNumber(TaxableAmount * TotalTax / 100, 2)

                TaxableAmount = 0

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.StateTax = FormatNumber(AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CountyTax = FormatNumber(AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CityTax = FormatNumber(AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

            End If

        End Sub
        Public Sub ReCalculate(ByVal ReCalculateTax As Boolean)

            Me.AccountPayableOutOfHome.RebateAmount = FormatNumber(-1 * Me.GrossAmount.GetValueOrDefault(0) * Me.AccountPayableOutOfHome.RebatePercent.GetValueOrDefault(0) / 100, 2)

            If ReCalculateTax Then

                CalculateTax(Me)

            End If

            Me.ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignNetAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignDiscountAmount = FormatNumber(Me.DiscountAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

            Me.AccountPayableOutOfHome.LineTotal = FormatNumber(Me.DisbursedAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableOutOfHome.RebateAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableOutOfHome.CommissionAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableOutOfHome.StateTax.GetValueOrDefault(0) +
                                                                Me.AccountPayableOutOfHome.CountyTax.GetValueOrDefault(0) +
                                                                Me.AccountPayableOutOfHome.CityTax.GetValueOrDefault(0), 2)

        End Sub
        Private Sub SetForeignCurrencyAmounts()

            _ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignNetAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignDiscountAmount = FormatNumber(Me.DiscountAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

        End Sub
        Public Shared Sub SetBaseValues(ByRef AccountPayableOutOfHomeDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail,
                                        ByVal OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
										CurrencyRate As Decimal)
										
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim AccountPayableOutOfHomeList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableOutOfHome) = Nothing
            Dim SumOfNetAmount As Decimal = 0
            Dim SumOfDiscount As Decimal = 0
            Dim SumOfNetCharges As Decimal = 0
            Dim SumOfCommission As Decimal = 0
			
            AccountPayableOutOfHomeDistributionDetail.CurrencyRate = CurrencyRate

            AccountPayableOutOfHomeList = AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.LoadActiveByOrderNumberAndLineNumber(DbContext, OutOfHomeOrderDetail.OutofHomeOrderNumber, OutOfHomeOrderDetail.LineNumber).ToList

            AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber = OutOfHomeOrderDetail.OutofHomeOrderNumber
            AccountPayableOutOfHomeDistributionDetail.OutdoorDetailLineNumber = OutOfHomeOrderDetail.LineNumber

            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.OutdoorDetailRevisionNumber = OutOfHomeOrderDetail.RevisionNumber
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.OutdoorDetailSequenceNumber = OutOfHomeOrderDetail.SequenceNumber

            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.SalesTaxCode = If(String.IsNullOrWhiteSpace(OutOfHomeOrderDetail.SalesTaxCode), Nothing, OutOfHomeOrderDetail.SalesTaxCode)
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CityTaxPercent = OutOfHomeOrderDetail.CityTaxPercent
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CountyTaxPercent = OutOfHomeOrderDetail.CountyTaxPercent
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.StateTaxPercent = OutOfHomeOrderDetail.StateTaxPercent

            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyC = OutOfHomeOrderDetail.TaxApplyC
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyLN = OutOfHomeOrderDetail.TaxApplyLN
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyLND = OutOfHomeOrderDetail.TaxApplyND
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyNC = OutOfHomeOrderDetail.TaxApplyNC
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.TaxApplyR = OutOfHomeOrderDetail.TaxApplyR
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.IsResaleTax = OutOfHomeOrderDetail.IsResaleTax

            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CityTax = OutOfHomeOrderDetail.CityTax
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CountyTax = OutOfHomeOrderDetail.CountyTax
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.StateTax = OutOfHomeOrderDetail.StateTax
            AccountPayableOutOfHomeDistributionDetail.VendorTax = OutOfHomeOrderDetail.VendorTax.GetValueOrDefault(0)

            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.NetAmount = OutOfHomeOrderDetail.ExtendedNetAmount

            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CommissionPercent = OutOfHomeOrderDetail.CommissionPercent
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CommissionAmount = OutOfHomeOrderDetail.CommissionAmount
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.MarkupPercent = OutOfHomeOrderDetail.MarkupPercent
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.RebatePercent = OutOfHomeOrderDetail.RebatePercent
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.RebateAmount = OutOfHomeOrderDetail.RebateAmount

            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.LineTotal = OutOfHomeOrderDetail.LineTotal
            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.NetCharges = OutOfHomeOrderDetail.NetCharge

            AccountPayableOutOfHomeDistributionDetail.PostDate = OutOfHomeOrderDetail.PostDate

            OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, OutOfHomeOrderDetail.OutofHomeOrderNumber)

            If OutOfHomeOrder IsNot Nothing Then

                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.NetGross = OutOfHomeOrder.NetGross.GetValueOrDefault(0)

                AccountPayableOutOfHomeDistributionDetail.ClientCode = OutOfHomeOrder.ClientCode
                AccountPayableOutOfHomeDistributionDetail.DivisionCode = OutOfHomeOrder.DivisionCode
                AccountPayableOutOfHomeDistributionDetail.ProductCode = OutOfHomeOrder.ProductCode
                AccountPayableOutOfHomeDistributionDetail.OfficeCode = OutOfHomeOrder.OfficeCode

                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, OutOfHomeOrder.OfficeCode)

                If Office IsNot Nothing Then

                    AccountPayableOutOfHomeDistributionDetail.GLACode = Office.MediaWorkInProgressGLACode

                End If

            End If

            AccountPayableOutOfHomeDistributionDetail.OrderNetAmount = OutOfHomeOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                                                       OutOfHomeOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                                                       OutOfHomeOrderDetail.NetCharge.GetValueOrDefault(0) +
                                                                       OutOfHomeOrderDetail.VendorTax.GetValueOrDefault(0)

            AccountPayableOutOfHomeDistributionDetail.PreviouslyPosted = AccountPayableOutOfHomeList.Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0)) +
                                                                         AccountPayableOutOfHomeList.Sum(Function(Entity) Entity.DiscountAmount.GetValueOrDefault(0)) +
                                                                         AccountPayableOutOfHomeList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0)) +
                                                                         AccountPayableOutOfHomeList.Sum(Function(Entity) Entity.VendorTax.GetValueOrDefault(0))

            SumOfNetAmount = AccountPayableOutOfHomeList.Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0))
            SumOfDiscount = AccountPayableOutOfHomeList.Sum(Function(Entity) Math.Abs(Entity.DiscountAmount.GetValueOrDefault(0)))
            SumOfNetCharges = AccountPayableOutOfHomeList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0))
            SumOfCommission = AccountPayableOutOfHomeList.Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0))
            
            If SumOfCommission > AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CommissionAmount.GetValueOrDefault(0) Then

                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CommissionAmount = 0

            Else

                AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CommissionAmount = FormatNumber(OutOfHomeOrderDetail.CommissionAmount.GetValueOrDefault(0) - SumOfCommission, 2)

            End If

            If SumOfNetAmount > OutOfHomeOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) Then

                AccountPayableOutOfHomeDistributionDetail.NetAmount = 0

            Else

                AccountPayableOutOfHomeDistributionDetail.NetAmount = OutOfHomeOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) - SumOfNetAmount

            End If

            AccountPayableOutOfHomeDistributionDetail.GrossAmount = AccountPayableOutOfHomeDistributionDetail.NetAmount.GetValueOrDefault(0) + AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CommissionAmount.GetValueOrDefault(0)

            If SumOfDiscount > Math.Abs(OutOfHomeOrderDetail.DiscountAmount.GetValueOrDefault(0)) Then

                AccountPayableOutOfHomeDistributionDetail.DiscountAmount = 0

            Else

                AccountPayableOutOfHomeDistributionDetail.DiscountAmount = Math.Abs(OutOfHomeOrderDetail.DiscountAmount.GetValueOrDefault(0)) - SumOfDiscount

            End If

            If SumOfNetCharges > OutOfHomeOrderDetail.NetCharge.GetValueOrDefault(0) Then

                AccountPayableOutOfHomeDistributionDetail.NetCharges = 0

            Else

                AccountPayableOutOfHomeDistributionDetail.NetCharges = OutOfHomeOrderDetail.NetCharge.GetValueOrDefault(0) - SumOfNetCharges

            End If

            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.RebateAmount = FormatNumber(-1 * AccountPayableOutOfHomeDistributionDetail.GrossAmount.GetValueOrDefault(0) *
                                                                                                          AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.RebatePercent.GetValueOrDefault(0) / 100, 2)

            CalculateTax(AccountPayableOutOfHomeDistributionDetail)

            AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.LineTotal = FormatNumber(AccountPayableOutOfHomeDistributionDetail.DisbursedAmount.GetValueOrDefault(0) +
                                                                                                       AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.RebateAmount.GetValueOrDefault(0) +
                                                                                                       AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CommissionAmount.GetValueOrDefault(0) +
                                                                                                       AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.StateTax.GetValueOrDefault(0) +
                                                                                                       AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CountyTax.GetValueOrDefault(0) +
                                                                                                       AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.CityTax.GetValueOrDefault(0), 2)

            AccountPayableOutOfHomeDistributionDetail.SetForeignCurrencyAmounts()

        End Sub
        Public Sub New()

            _AccountPayableOutOfHome = New AdvantageFramework.Database.Entities.AccountPayableOutOfHome

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

            Dim OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail = Nothing

            _AccountPayableOutOfHome = New AdvantageFramework.Database.Entities.AccountPayableOutOfHome

            OutOfHomeOrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayableMedia.OrderNumber, ImportAccountPayableMedia.OrderLineNumber)

            If OutOfHomeOrderDetail IsNot Nothing Then

                SetBaseValues(Me, OutOfHomeOrderDetail, DbContext, 1)

                Me.DiscountAmount = 0 'should not bring this in, there is not a place in import file for discount, to bring it in will cause OOB

            End If

            Me.NetAmount = ImportAccountPayableMedia.MediaNetAmount.GetValueOrDefault(0)
            Me.VendorTax = ImportAccountPayableMedia.MediaVendorTax.GetValueOrDefault(0)
            Me.NetCharges = ImportAccountPayableMedia.MediaNetCharge.GetValueOrDefault(0)

            AdvantageFramework.AccountPayable.CalculateGrossAndCommission(Me.NetAmount, Me.DiscountAmount, Me.AccountPayableOutOfHome.MarkupPercent, Me.GrossAmount, Me.AccountPayableOutOfHome.CommissionAmount)

            ReCalculate(False)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableOutOfHome As AdvantageFramework.Database.Entities.AccountPayableOutOfHome,
                       LoadingActive As Boolean)

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval = Nothing
            Dim MediaApprovalStatus As Generic.KeyValuePair(Of Long, String) = Nothing
            Dim OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail = Nothing

            _AccountPayableOutOfHome = AccountPayableOutOfHome

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableOutOfHome.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            _CurrencyRate = If(AccountPayable.CurrencyRate.HasValue AndAlso AccountPayable.CurrencyRate = 0, 1, AccountPayable.CurrencyRate.GetValueOrDefault(1))

            _AccountPayableOutOfHome.DiscountAmount = If(LoadingActive, Math.Abs(_AccountPayableOutOfHome.DiscountAmount.GetValueOrDefault(0)), _AccountPayableOutOfHome.DiscountAmount.GetValueOrDefault(0))

            _OutdoorOrderNumber = AccountPayableOutOfHome.OutdoorOrderNumber
            _OutdoorDetailLineNumber = AccountPayableOutOfHome.OutdoorDetailLineNumber

            _GrossAmount = _AccountPayableOutOfHome.NetAmount.GetValueOrDefault(0) + _AccountPayableOutOfHome.CommissionAmount.GetValueOrDefault(0)

            _PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.LoadActiveByOrderNumberAndLineNumber(DbContext, _AccountPayableOutOfHome.OutdoorOrderNumber, _AccountPayableOutOfHome.OutdoorDetailLineNumber) _
                .Where(Function(Entity) Entity.AccountPayableID <> _AccountPayableOutOfHome.AccountPayableID) _
                .Sum(Function(Entity) Entity.NetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

            If AccountPayableOutOfHome.GeneralLedgerAccount IsNot Nothing Then

                _GLADescription = AccountPayableOutOfHome.GeneralLedgerAccount.Description

            End If

            OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, AccountPayableOutOfHome.OutdoorOrderNumber)

            If OutOfHomeOrder IsNot Nothing Then

                _ClientCode = OutOfHomeOrder.ClientCode
                _DivisionCode = OutOfHomeOrder.DivisionCode
                _ProductCode = OutOfHomeOrder.ProductCode

                OutOfHomeOrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, _AccountPayableOutOfHome.OutdoorOrderNumber, _AccountPayableOutOfHome.OutdoorDetailLineNumber)

                If OutOfHomeOrderDetail IsNot Nothing Then

                    _PostDate = OutOfHomeOrderDetail.PostDate

                    _OrderNetAmount = OutOfHomeOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                      OutOfHomeOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                      OutOfHomeOrderDetail.NetCharge.GetValueOrDefault(0) +
                                      OutOfHomeOrderDetail.VendorTax.GetValueOrDefault(0)

                End If

            End If

            _OrderNetBalance = _OrderNetAmount - (Me.DisbursedAmount + _PreviouslyPosted)

            Try

                AccountPayableMediaApproval = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.LoadByAccountPayableID(DbContext, AccountPayableOutOfHome.AccountPayableID)
                                               Where Entity.OrderNumber = AccountPayableOutOfHome.OutdoorOrderNumber AndAlso
                                                     Entity.LineNumber = AccountPayableOutOfHome.OutdoorDetailLineNumber AndAlso
                                                     Entity.Source = "O" AndAlso
                                                     Entity.IsActiveRevision = 1
                                               Select Entity).SingleOrDefault

            Catch ex As Exception
                AccountPayableMediaApproval = Nothing
            End Try

            If AccountPayableMediaApproval IsNot Nothing Then

                _Status = ""

                If AccountPayableMediaApproval.Status Is Nothing Then

                    _Status = "None"

                Else

                    Try

                        MediaApprovalStatus = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.MediaApprovalStatus))
                                               Where KeyValuePair.Key = AccountPayableMediaApproval.Status
                                               Select KeyValuePair).SingleOrDefault

                        _Status = MediaApprovalStatus.Value

                    Catch ex As Exception
                        MediaApprovalStatus = Nothing
                    End Try

                End If

                _Comments = AccountPayableMediaApproval.Comments

            End If

            SetForeignCurrencyAmounts()

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail,
		               CurrencyRate as Decimal)

            _AccountPayableOutOfHome = New AdvantageFramework.Database.Entities.AccountPayableOutOfHome

            SetBaseValues(Me, OutOfHomeOrderDetail, DbContext, CurrencyRate)

        End Sub
        Public Overrides Function ToString() As String

            ToString = _AccountPayableOutOfHome.AccountPayableID

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.DisbursedAmount.ToString

                        If Me.NetAmount.GetValueOrDefault(0) = 0 AndAlso Me.VendorTax.GetValueOrDefault(0) = 0 AndAlso Me.NetCharges.GetValueOrDefault(0) = 0 Then

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.DisbursedAmount.ToString, True)

                        Else

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.DisbursedAmount.ToString, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.OutdoorOrderNumber.ToString

                    PropertyValue = Value

                    If IsNumeric(PropertyValue) AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Order is required and cannot be zero."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.OutdoorDetailLineNumber.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Line is required and cannot be zero."

                    End If

                    'Case AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail.Properties.DisbursedAmount.ToString

                    '    PropertyValue = Value

                    '    If PropertyValue Is Nothing OrElse PropertyValue = 0 AndAlso Me.NetAmount.GetValueOrDefault(0) = 0 AndAlso Me.NetCharges.GetValueOrDefault(0) = 0 AndAlso _
                    '            Me.VendorTax.GetValueOrDefault(0) = 0 Then

                    '        IsValid = False

                    '        ErrorText = "Invalid disbursement.  All data cannot be zero."

                    '    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

