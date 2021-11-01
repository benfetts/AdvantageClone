Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableRadioDistributionDetail
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
            OrderNumber
            OrderLineNumber
            BroadcastMonth
            BroadcastYear
            OrderDate
            TotalSpots
            ForeignGrossAmount
            GrossAmount
            ForeignExtendedNetAmount
            ExtendedNetAmount
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
            GLADescription
            RewriteFlag
            CurrencyRate
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableRadio As AdvantageFramework.Database.Entities.AccountPayableRadio = Nothing
        Private _BroadcastMonth As String = Nothing
        Private _BroadcastYear As Nullable(Of Short) = Nothing
        Private _OrderDate As Nullable(Of Date) = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _IsDeleted As Boolean = False
        Private _GrossAmount As Nullable(Of Decimal) = Nothing
        Private _GLADescription As String = Nothing
        Private _OrderNetAmount As Decimal = Nothing
        Private _Status As String = Nothing
        Private _Comments As String = Nothing
        Private _NewApprovalStatus As Nullable(Of Short) = Nothing
        Private _NewApprovalComments As String = Nothing
        Private _PlanEstID As String = Nothing
        Private _PostDate As Nullable(Of Date) = Nothing
        Private _OrderNetBalance As Decimal = Nothing
        Private _PreviouslyPosted As Decimal = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _ForeignGrossAmount As Decimal = Nothing
        Private _ForeignExtendedNetAmount As Decimal = Nothing
        Private _ForeignDiscountAmount As Decimal = Nothing
        Private _ForeignNetCharges As Decimal = Nothing
        Private _ForeignVendorTax As Decimal = Nothing
        Private _ForeignDisbursedAmount As Decimal = Nothing
        Private _CurrencyRate As Decimal = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.AccountPayableRadio)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableRadio As AdvantageFramework.Database.Entities.AccountPayableRadio
            Get
                AccountPayableRadio = _AccountPayableRadio
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Month")>
        Public Property BroadcastMonth() As String
            Get
                BroadcastMonth = _BroadcastMonth
            End Get
            Set(value As String)
                _BroadcastMonth = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Year")>
        Public Property BroadcastYear() As Nullable(Of Short)
            Get
                BroadcastYear = _BroadcastYear
            End Get
            Set(value As Nullable(Of Short))
                _BroadcastYear = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Order")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Line")>
        Public Property OrderLineNumber() As Nullable(Of Short)
            Get
                OrderLineNumber = _AccountPayableRadio.OrderLineNumber
            End Get
            Set(value As Nullable(Of Short))
                _AccountPayableRadio.OrderLineNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderDate() As Nullable(Of Date)
            Get
                OrderDate = _OrderDate
            End Get
            Set(value As Nullable(Of Date))
                _OrderDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", UseMaxValue:=True, MaxValue:=2147483647, UseMinValue:=True, MinValue:=-2147483647)>
        Public Property TotalSpots() As Nullable(Of Integer)
            Get
                TotalSpots = _AccountPayableRadio.TotalSpots
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AccountPayableRadio.TotalSpots = value
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
        Public Property ForeignExtendedNetAmount() As Decimal
            Get
                ForeignExtendedNetAmount = _ForeignExtendedNetAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignExtendedNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Net Amount")>
        Public Property ExtendedNetAmount() As Nullable(Of Decimal)
            Get
                ExtendedNetAmount = _AccountPayableRadio.ExtendedNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableRadio.ExtendedNetAmount = value
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
                DiscountAmount = _AccountPayableRadio.DiscountAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableRadio.DiscountAmount = value
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
                NetCharges = _AccountPayableRadio.NetCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableRadio.NetCharges = value
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
                VendorTax = _AccountPayableRadio.VendorTax.GetValueOrDefault(0)
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableRadio.VendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property ForeignDisbursedAmount() As Nullable(Of Decimal)
            Get
                ForeignDisbursedAmount = Me.ForeignExtendedNetAmount - Me.ForeignDiscountAmount + Me.ForeignNetCharges + Me.ForeignVendorTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property DisbursedAmount() As Nullable(Of Decimal)
            Get
                DisbursedAmount = Me.ExtendedNetAmount.GetValueOrDefault(0) - Me.DiscountAmount.GetValueOrDefault(0) + Me.NetCharges.GetValueOrDefault(0) + Me.VendorTax.GetValueOrDefault(0)
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
                SalesTaxCode = _AccountPayableRadio.SalesTaxCode
            End Get
            Set(ByVal value As String)
                _AccountPayableRadio.SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountPayableRadio.OfficeCode
            End Get
            Set(ByVal value As String)
                _AccountPayableRadio.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _AccountPayableRadio.GLACode
            End Get
            Set(ByVal value As String)
                _AccountPayableRadio.GLACode = value
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
        Public Property RewriteFlag() As Nullable(Of Short)
            Get
                RewriteFlag = _AccountPayableRadio.RewriteFlag
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableRadio.RewriteFlag = value
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
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsCommissionOnly() As Boolean

#End Region

#Region " Methods "

        Private Shared Sub CalculateTax(ByRef AccountPayableRadioDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail)

            Dim TotalTax As Decimal = Nothing
            Dim TaxableAmount As Decimal = 0

            TotalTax = AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTaxPercent.GetValueOrDefault(0) + _
                       AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTaxPercent.GetValueOrDefault(0) + _
                       AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTaxPercent.GetValueOrDefault(0)

            If AccountPayableRadioDistributionDetail.AccountPayableRadio.IsResaleTax.GetValueOrDefault(0) = 1 Then

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableRadioDistributionDetail.AccountPayableRadio.ExtendedNetAmount.GetValueOrDefault(0)

                End If

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableRadioDistributionDetail.AccountPayableRadio.DiscountAmount.GetValueOrDefault(0)

                End If

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableRadioDistributionDetail.AccountPayableRadio.NetCharges.GetValueOrDefault(0)

                End If

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableRadioDistributionDetail.AccountPayableRadio.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTax = FormatNumber(AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTax = FormatNumber(AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTax = FormatNumber(AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

                AccountPayableRadioDistributionDetail.VendorTax = 0

            Else

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableRadioDistributionDetail.AccountPayableRadio.ExtendedNetAmount.GetValueOrDefault(0)

                End If

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableRadioDistributionDetail.AccountPayableRadio.DiscountAmount.GetValueOrDefault(0)

                End If

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableRadioDistributionDetail.AccountPayableRadio.NetCharges.GetValueOrDefault(0)

                End If

                AccountPayableRadioDistributionDetail.AccountPayableRadio.VendorTax = FormatNumber(TaxableAmount * TotalTax / 100, 2)

                TaxableAmount = 0

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableRadioDistributionDetail.AccountPayableRadio.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTax = FormatNumber(AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTax = FormatNumber(AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTax = FormatNumber(AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

            End If

        End Sub
        Public Sub ReCalculate(ByVal ReCalculateTax As Boolean)

            Me.AccountPayableRadio.RebateAmount = FormatNumber(-1 * Me.GrossAmount.GetValueOrDefault(0) * Me.AccountPayableRadio.RebatePercent.GetValueOrDefault(0) / 100, 2)

            If ReCalculateTax Then

                CalculateTax(Me)

            End If

            Me.ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignExtendedNetAmount = FormatNumber(Me.ExtendedNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignDiscountAmount = FormatNumber(Me.DiscountAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

            Me.AccountPayableRadio.LineTotal = FormatNumber(Me.DisbursedAmount +
                                                            Me.AccountPayableRadio.RebateAmount.GetValueOrDefault(0) +
                                                            Me.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0) +
                                                            Me.AccountPayableRadio.StateTax.GetValueOrDefault(0) +
                                                            Me.AccountPayableRadio.CountyTax.GetValueOrDefault(0) +
                                                            Me.AccountPayableRadio.CityTax.GetValueOrDefault(0), 2)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

        End Sub
        Private Shared Sub SetByMonthDetailLegacy(ByRef AccountPayableRadioDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail,
                                                  ByVal BroadcastMonth As String, ByVal BroadcastYear As Short, ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim RadioOrderDetailLegacyList As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetailLegacy) = Nothing
            Dim OrderNumber As Integer

            OrderNumber = AccountPayableRadioDistributionDetail.OrderNumber

            RadioOrderDetailLegacyList = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetailLegacy.Load(DbContext)
                                          Where Entity.RadioOrderNumberLegacy = OrderNumber AndAlso
                                                Entity.BroadcastYear = BroadcastYear
                                          Select Entity).ToList

            AccountPayableRadioDistributionDetail.AccountPayableRadio.RebateAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.RebateAmount).GetValueOrDefault(0)

            Select Case BroadcastMonth

                Case "JAN"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JanLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JanCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JanDiscount).GetValueOrDefault(0)

                Case "FEB"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.FebLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.FebCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.FebDiscount).GetValueOrDefault(0)

                Case "MAR"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.MarLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.MarCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.MarDiscount).GetValueOrDefault(0)

                Case "APR"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.AprLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.AprCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.AprDiscount).GetValueOrDefault(0)

                Case "MAY"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.MayLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.MayCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.MayDiscount).GetValueOrDefault(0)

                Case "JUN"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JunLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JunCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JunDiscount).GetValueOrDefault(0)

                Case "JUL"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JulLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JulCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JulDiscount).GetValueOrDefault(0)

                Case "AUG"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.AugLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.AugCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.AugDiscount).GetValueOrDefault(0)

                Case "SEP"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.SepLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.SepCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.SepDiscount).GetValueOrDefault(0)

                Case "OCT"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.OctLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.OctCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.OctDiscount).GetValueOrDefault(0)

                Case "NOV"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.NovLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.NovCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.NovDiscount).GetValueOrDefault(0)

                Case "DEC"

                    AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.DecLineNet).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.DecCommissionAmount).GetValueOrDefault(0)
                    AccountPayableRadioDistributionDetail.DiscountAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.DecDiscount).GetValueOrDefault(0)

            End Select

        End Sub
        Public Shared Function GetLegacyOrderNetAmount(ByVal OrderNumber As Integer, ByVal BroadcastMonth As String, ByVal BroadcastYear As Short, ByVal DbContext As AdvantageFramework.Database.DbContext) As Decimal

            Dim RadioOrderDetailLegacyList As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetailLegacy) = Nothing
            Dim OrderNetAmount As Decimal = 0

            RadioOrderDetailLegacyList = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetailLegacy.Load(DbContext)
                                          Where Entity.RadioOrderNumberLegacy = OrderNumber AndAlso
                                                Entity.BroadcastYear = BroadcastYear
                                          Select Entity).ToList

            Select Case BroadcastMonth

                Case "JAN"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JanLineNet).GetValueOrDefault(0)

                Case "FEB"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.FebLineNet).GetValueOrDefault(0)

                Case "MAR"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.MarLineNet).GetValueOrDefault(0)

                Case "APR"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.AprLineNet).GetValueOrDefault(0)

                Case "MAY"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.MayLineNet).GetValueOrDefault(0)

                Case "JUN"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JunLineNet).GetValueOrDefault(0)

                Case "JUL"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.JulLineNet).GetValueOrDefault(0)

                Case "AUG"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.AugLineNet).GetValueOrDefault(0)

                Case "SEP"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.SepLineNet).GetValueOrDefault(0)

                Case "OCT"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.OctLineNet).GetValueOrDefault(0)

                Case "NOV"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.NovLineNet).GetValueOrDefault(0)

                Case "DEC"

                    OrderNetAmount = RadioOrderDetailLegacyList.Sum(Function(Entity) Entity.DecLineNet).GetValueOrDefault(0)

            End Select

            GetLegacyOrderNetAmount = OrderNetAmount

        End Function
        Private Sub SetForeignCurrencyAmounts()

            _ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignExtendedNetAmount = FormatNumber(Me.ExtendedNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignDiscountAmount = FormatNumber(Me.DiscountAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

        End Sub
        Public Shared Sub SetBaseValues(ByRef AccountPayableRadioDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail,
                                        ByVal RadioOrderLegacy As AdvantageFramework.Database.Entities.RadioOrderLegacy,
                                        ByVal BroadcastYear As Short, ByVal BroadcastMonth As String,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        CurrencyRate As Decimal)

            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim AccountPayableRadioList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableRadio) = Nothing
            Dim SumOfNetAmount As Decimal = 0
            Dim SumOfDiscount As Decimal = 0
            Dim SumOfNetCharges As Decimal = 0
            Dim SumOfCommission As Decimal = 0
			
            AccountPayableRadioDistributionDetail.CurrencyRate = CurrencyRate

            AccountPayableRadioList = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRadio.Load(DbContext)
                                       Where Entity.OrderNumber = RadioOrderLegacy.OrderNumber AndAlso
                                             Entity.BroadcastMonth = BroadcastMonth AndAlso
                                             Entity.BroadcastYear = BroadcastYear AndAlso
                                             (Entity.ModifyDelete Is Nothing OrElse Entity.ModifyDelete = 0)
                                       Select Entity).ToList

            AccountPayableRadioDistributionDetail.RewriteFlag = 0

            AccountPayableRadioDistributionDetail.AccountPayableRadio.SequenceNumber = 0

            AccountPayableRadioDistributionDetail.OrderNumber = RadioOrderLegacy.OrderNumber

            AccountPayableRadioDistributionDetail.AccountPayableRadio.BroadcastMonth = BroadcastMonth
            AccountPayableRadioDistributionDetail.AccountPayableRadio.BroadcastYear = BroadcastYear
            AccountPayableRadioDistributionDetail.AccountPayableRadio.RevisionNumber = RadioOrderLegacy.RevisionNumber

            AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTax = 0
            AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTax = 0
            AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTax = 0

            AccountPayableRadioDistributionDetail.AccountPayableRadio.OrderLineNumber = Nothing

            AccountPayableRadioDistributionDetail.AccountPayableRadio.SalesTaxCode = If(String.IsNullOrWhiteSpace(RadioOrderLegacy.SalesTaxCode), Nothing, RadioOrderLegacy.SalesTaxCode)
            AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTaxPercent = RadioOrderLegacy.CityTaxPercent
            AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTaxPercent = RadioOrderLegacy.CountyTaxPercent
            AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTaxPercent = RadioOrderLegacy.StateTaxPercent

            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyC = RadioOrderLegacy.TaxApplyC
            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyLN = RadioOrderLegacy.TaxApplyLN
            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyLND = RadioOrderLegacy.TaxApplyLND
            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyNC = RadioOrderLegacy.TaxApplyNC
            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyR = RadioOrderLegacy.TaxApplyR
            AccountPayableRadioDistributionDetail.AccountPayableRadio.IsResaleTax = RadioOrderLegacy.IsResaleTax

            SetByMonthDetailLegacy(AccountPayableRadioDistributionDetail, BroadcastMonth, BroadcastYear, DbContext)

            AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionPercent = RadioOrderLegacy.CommissionPercent.GetValueOrDefault(0)
            AccountPayableRadioDistributionDetail.AccountPayableRadio.MarkupPercent = RadioOrderLegacy.MarkupPercent.GetValueOrDefault(0)
            AccountPayableRadioDistributionDetail.AccountPayableRadio.RebatePercent = RadioOrderLegacy.RebatePercent.GetValueOrDefault(0)

            AccountPayableRadioDistributionDetail.OrderDate = Nothing
            AccountPayableRadioDistributionDetail.TotalSpots = Nothing

            AccountPayableRadioDistributionDetail.AccountPayableRadio.NetGross = RadioOrderLegacy.NetGross.GetValueOrDefault(0)

            AccountPayableRadioDistributionDetail.ClientCode = RadioOrderLegacy.ClientCode
            AccountPayableRadioDistributionDetail.DivisionCode = RadioOrderLegacy.DivisionCode
            AccountPayableRadioDistributionDetail.ProductCode = RadioOrderLegacy.ProductCode
            AccountPayableRadioDistributionDetail.OfficeCode = RadioOrderLegacy.OfficeCode

            Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, RadioOrderLegacy.OfficeCode)

            If Office IsNot Nothing Then

                AccountPayableRadioDistributionDetail.GLACode = Office.MediaWorkInProgressGLACode

            End If

            AccountPayableRadioDistributionDetail.PreviouslyPosted = AccountPayableRadioList.Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0)) +
                                                                     AccountPayableRadioList.Sum(Function(Entity) Entity.DiscountAmount.GetValueOrDefault(0)) +
                                                                     AccountPayableRadioList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0)) +
                                                                     AccountPayableRadioList.Sum(Function(Entity) Entity.VendorTax.GetValueOrDefault(0))

            SumOfNetAmount = AccountPayableRadioList.Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0))
            SumOfDiscount = AccountPayableRadioList.Sum(Function(Entity) Entity.DiscountAmount.GetValueOrDefault(0))
            SumOfNetCharges = AccountPayableRadioList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0))
            SumOfCommission = AccountPayableRadioList.Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0))
            
            If SumOfCommission > AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0) Then

                AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = 0

            Else

                AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = FormatNumber(AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0) - SumOfCommission, 2)

            End If

            If SumOfNetAmount > AccountPayableRadioDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) Then

                AccountPayableRadioDistributionDetail.ExtendedNetAmount = 0

            Else

                AccountPayableRadioDistributionDetail.ExtendedNetAmount = AccountPayableRadioDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) - SumOfNetAmount

            End If

            If SumOfDiscount > Math.Abs(AccountPayableRadioDistributionDetail.DiscountAmount.GetValueOrDefault(0)) Then

                AccountPayableRadioDistributionDetail.DiscountAmount = 0

            Else

                AccountPayableRadioDistributionDetail.DiscountAmount = Math.Abs(AccountPayableRadioDistributionDetail.DiscountAmount.GetValueOrDefault(0)) - SumOfDiscount

            End If

            If SumOfNetCharges > AccountPayableRadioDistributionDetail.NetCharges.GetValueOrDefault(0) Then

                AccountPayableRadioDistributionDetail.NetCharges = 0

            Else

                AccountPayableRadioDistributionDetail.NetCharges = AccountPayableRadioDistributionDetail.NetCharges.GetValueOrDefault(0) - SumOfNetCharges

            End If

            AccountPayableRadioDistributionDetail.GrossAmount = AccountPayableRadioDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) + AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0)

            AccountPayableRadioDistributionDetail.AccountPayableRadio.RebateAmount = FormatNumber(-1 * AccountPayableRadioDistributionDetail.GrossAmount.GetValueOrDefault(0) *
                                                                                                  AccountPayableRadioDistributionDetail.AccountPayableRadio.RebatePercent.GetValueOrDefault(0) / 100, 2)

            CalculateTax(AccountPayableRadioDistributionDetail)

            AccountPayableRadioDistributionDetail.AccountPayableRadio.LineTotal = FormatNumber(AccountPayableRadioDistributionDetail.DisbursedAmount +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.RebateAmount.GetValueOrDefault(0) +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0) +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTax.GetValueOrDefault(0) +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTax.GetValueOrDefault(0) +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTax.GetValueOrDefault(0), 2)

            AccountPayableRadioDistributionDetail.OrderNetBalance = AccountPayableRadioDistributionDetail.OrderNetAmount - (AccountPayableRadioDistributionDetail.DisbursedAmount + AccountPayableRadioDistributionDetail.PreviouslyPosted)

            AccountPayableRadioDistributionDetail.SetForeignCurrencyAmounts()

        End Sub
        Public Shared Sub SetBaseValues(ByRef AccountPayableRadioDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail,
                                        ByVal RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
										CurrencyRate As Decimal)

            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim AccountPayableRadioList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableRadio) = Nothing
            Dim SumOfNetAmount As Decimal = 0
            Dim SumOfDiscount As Decimal = 0
            Dim SumOfNetCharges As Decimal = 0
            Dim SumOfSpots As Integer = 0
            Dim SumOfCommission As Decimal = 0
			
            AccountPayableRadioDistributionDetail.CurrencyRate = CurrencyRate

            AccountPayableRadioList = AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadActiveByOrderNumberAndLineNumber(DbContext, RadioOrderDetail.RadioOrderNumber, RadioOrderDetail.LineNumber).ToList

            AccountPayableRadioDistributionDetail.RewriteFlag = 1

            AccountPayableRadioDistributionDetail.OrderNumber = RadioOrderDetail.RadioOrderNumber

            AccountPayableRadioDistributionDetail.AccountPayableRadio.OrderLineNumber = RadioOrderDetail.LineNumber
            AccountPayableRadioDistributionDetail.AccountPayableRadio.RevisionNumber = RadioOrderDetail.RevisionNumber
            AccountPayableRadioDistributionDetail.AccountPayableRadio.SequenceNumber = RadioOrderDetail.SequenceNumber

            AccountPayableRadioDistributionDetail.AccountPayableRadio.SalesTaxCode = If(String.IsNullOrWhiteSpace(RadioOrderDetail.SalesTaxCode), Nothing, RadioOrderDetail.SalesTaxCode)
            AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTaxPercent = If(RadioOrderDetail.CityTaxPercent IsNot Nothing, Format(RadioOrderDetail.CityTaxPercent, "#0.000"), Nothing)
            AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTaxPercent = If(RadioOrderDetail.CountyTaxPercent IsNot Nothing, Format(RadioOrderDetail.CountyTaxPercent, "#0.000"), Nothing)
            AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTaxPercent = If(RadioOrderDetail.StateTaxPercent IsNot Nothing, Format(RadioOrderDetail.StateTaxPercent, "#0.000"), Nothing)

            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyC = RadioOrderDetail.TaxApplyC
            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyLN = RadioOrderDetail.TaxApplyLN
            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyLND = RadioOrderDetail.TaxApplyND
            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyNC = RadioOrderDetail.TaxApplyNC
            AccountPayableRadioDistributionDetail.AccountPayableRadio.TaxApplyR = RadioOrderDetail.TaxApplyR
            AccountPayableRadioDistributionDetail.AccountPayableRadio.IsResaleTax = RadioOrderDetail.IsResaleTax

            If RadioOrderDetail.BillTypeFlag = 1 Then 'commission only

                AccountPayableRadioDistributionDetail.IsCommissionOnly = True
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTax = 0
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTax = 0
                AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTax = 0

                AccountPayableRadioDistributionDetail.AccountPayableRadio.ExtendedNetAmount = 0
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionPercent = 0
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = 0
                AccountPayableRadioDistributionDetail.AccountPayableRadio.MarkupPercent = 0
                AccountPayableRadioDistributionDetail.AccountPayableRadio.RebatePercent = 0
                AccountPayableRadioDistributionDetail.AccountPayableRadio.RebateAmount = 0
                AccountPayableRadioDistributionDetail.AccountPayableRadio.LineTotal = 0
                AccountPayableRadioDistributionDetail.AccountPayableRadio.NetCharges = 0

                AccountPayableRadioDistributionDetail.OrderNetAmount = 0

            Else

                AccountPayableRadioDistributionDetail.IsCommissionOnly = False
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTax = RadioOrderDetail.CityTaxAmount
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTax = RadioOrderDetail.CountyTaxAmount
                AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTax = RadioOrderDetail.StateTaxAmount

                AccountPayableRadioDistributionDetail.AccountPayableRadio.ExtendedNetAmount = RadioOrderDetail.ExtendedNetAmount
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionPercent = RadioOrderDetail.CommissionPercent
                AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = RadioOrderDetail.CommissionAmount
                AccountPayableRadioDistributionDetail.AccountPayableRadio.MarkupPercent = RadioOrderDetail.MarkupPercent
                AccountPayableRadioDistributionDetail.AccountPayableRadio.RebatePercent = RadioOrderDetail.RebatePercent
                AccountPayableRadioDistributionDetail.AccountPayableRadio.RebateAmount = RadioOrderDetail.RebateAmount
                AccountPayableRadioDistributionDetail.AccountPayableRadio.LineTotal = RadioOrderDetail.LineTotal
                AccountPayableRadioDistributionDetail.AccountPayableRadio.NetCharges = RadioOrderDetail.NetCharge.GetValueOrDefault(0)

                AccountPayableRadioDistributionDetail.OrderNetAmount = RadioOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                                                       RadioOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                                                       RadioOrderDetail.NetCharge.GetValueOrDefault(0) +
                                                                       RadioOrderDetail.NonResaleAmount.GetValueOrDefault(0)

            End If

            AccountPayableRadioDistributionDetail.BroadcastYear = RadioOrderDetail.YearNumber
            AccountPayableRadioDistributionDetail.BroadcastMonth = MonthName(RadioOrderDetail.MonthNumber, True).ToUpper
            AccountPayableRadioDistributionDetail.OrderDate = RadioOrderDetail.StartDate
            AccountPayableRadioDistributionDetail.TotalSpots = RadioOrderDetail.TotalSpots

            RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, RadioOrderDetail.RadioOrderNumber)

            If RadioOrder IsNot Nothing Then

                AccountPayableRadioDistributionDetail.AccountPayableRadio.NetGross = RadioOrder.NetGross.GetValueOrDefault(0)

                AccountPayableRadioDistributionDetail.ClientCode = RadioOrder.ClientCode
                AccountPayableRadioDistributionDetail.DivisionCode = RadioOrder.DivisionCode
                AccountPayableRadioDistributionDetail.ProductCode = RadioOrder.ProductCode
                AccountPayableRadioDistributionDetail.OfficeCode = RadioOrder.OfficeCode

                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, RadioOrder.OfficeCode)

                If Office IsNot Nothing Then

                    AccountPayableRadioDistributionDetail.GLACode = Office.MediaWorkInProgressGLACode

                End If

            End If

            AccountPayableRadioDistributionDetail.PreviouslyPosted = AccountPayableRadioList.Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0)) +
                                                                     AccountPayableRadioList.Sum(Function(Entity) Entity.DiscountAmount.GetValueOrDefault(0)) +
                                                                     AccountPayableRadioList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0)) +
                                                                     AccountPayableRadioList.Sum(Function(Entity) Entity.VendorTax.GetValueOrDefault(0))

            SumOfNetAmount = AccountPayableRadioList.Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0))
            SumOfDiscount = AccountPayableRadioList.Sum(Function(Entity) Math.Abs(Entity.DiscountAmount.GetValueOrDefault(0)))
            SumOfNetCharges = AccountPayableRadioList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0))
            SumOfSpots = AccountPayableRadioList.Sum(Function(Entity) Entity.TotalSpots.GetValueOrDefault(0))
            SumOfCommission = AccountPayableRadioList.Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0))

            If SumOfCommission > AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0) OrElse RadioOrderDetail.BillTypeFlag = 1 Then

                AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = 0

            Else

                AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount = FormatNumber(AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0) - SumOfCommission, 2)

            End If

            If SumOfNetAmount > RadioOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) OrElse RadioOrderDetail.BillTypeFlag = 1 Then

                AccountPayableRadioDistributionDetail.ExtendedNetAmount = 0

            Else

                AccountPayableRadioDistributionDetail.ExtendedNetAmount = RadioOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) - SumOfNetAmount

            End If

            If SumOfDiscount > Math.Abs(RadioOrderDetail.DiscountAmount.GetValueOrDefault(0)) OrElse RadioOrderDetail.BillTypeFlag = 1 Then

                AccountPayableRadioDistributionDetail.DiscountAmount = 0

            Else

                AccountPayableRadioDistributionDetail.DiscountAmount = Math.Abs(RadioOrderDetail.DiscountAmount.GetValueOrDefault(0)) - SumOfDiscount

            End If

            If SumOfNetCharges > RadioOrderDetail.NetCharge.GetValueOrDefault(0) OrElse RadioOrderDetail.BillTypeFlag = 1 Then

                AccountPayableRadioDistributionDetail.NetCharges = 0

            Else

                AccountPayableRadioDistributionDetail.NetCharges = RadioOrderDetail.NetCharge.GetValueOrDefault(0) - SumOfNetCharges

            End If

            If SumOfSpots > RadioOrderDetail.TotalSpots.GetValueOrDefault(0) Then

                AccountPayableRadioDistributionDetail.TotalSpots = 0

            Else

                AccountPayableRadioDistributionDetail.TotalSpots = RadioOrderDetail.TotalSpots.GetValueOrDefault(0) - SumOfSpots

            End If

            AccountPayableRadioDistributionDetail.GrossAmount = AccountPayableRadioDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) + AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0)

            AccountPayableRadioDistributionDetail.AccountPayableRadio.RebateAmount = FormatNumber(-1 * AccountPayableRadioDistributionDetail.GrossAmount.GetValueOrDefault(0) *
                                                                                                  AccountPayableRadioDistributionDetail.AccountPayableRadio.RebatePercent.GetValueOrDefault(0) / 100, 2)

            CalculateTax(AccountPayableRadioDistributionDetail)

            AccountPayableRadioDistributionDetail.AccountPayableRadio.LineTotal = FormatNumber(AccountPayableRadioDistributionDetail.DisbursedAmount +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.RebateAmount.GetValueOrDefault(0) +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.CommissionAmount.GetValueOrDefault(0) +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.StateTax.GetValueOrDefault(0) +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.CountyTax.GetValueOrDefault(0) +
                                                                                               AccountPayableRadioDistributionDetail.AccountPayableRadio.CityTax.GetValueOrDefault(0), 2)

            AccountPayableRadioDistributionDetail.OrderNetBalance = AccountPayableRadioDistributionDetail.OrderNetAmount - (AccountPayableRadioDistributionDetail.DisbursedAmount + AccountPayableRadioDistributionDetail.PreviouslyPosted)

            AccountPayableRadioDistributionDetail.SetForeignCurrencyAmounts()

        End Sub
        Public Sub New()

            _AccountPayableRadio = New AdvantageFramework.Database.Entities.AccountPayableRadio

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

            Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
            Dim RadioOrderLegacy As AdvantageFramework.Database.Entities.RadioOrderLegacy = Nothing
            Dim ImportAccountPayableBroadcastDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayableBroadcastDetail) = Nothing

            _AccountPayableRadio = New AdvantageFramework.Database.Entities.AccountPayableRadio

            If ImportAccountPayableMedia.OrderLineNumber IsNot Nothing Then

                RadioOrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayableMedia.OrderNumber, ImportAccountPayableMedia.OrderLineNumber)

            End If

            If RadioOrderDetail Is Nothing Then

                RadioOrderLegacy = AdvantageFramework.Database.Procedures.RadioOrderLegacy.LoadByOrderNumber(DbContext, ImportAccountPayableMedia.OrderNumber)

                If RadioOrderLegacy IsNot Nothing Then

                    SetBaseValues(Me, RadioOrderLegacy, ImportAccountPayableMedia.Year, ImportAccountPayableMedia.Month, DbContext, 1)

                End If

            Else

                SetBaseValues(Me, RadioOrderDetail, DbContext, 1)

            End If

            Me.DiscountAmount = 0 'should not bring this in, there is not a place in import file for discount, to bring it in will cause OOB

            Me.TotalSpots = ImportAccountPayableMedia.MediaQuantity
            Me.ExtendedNetAmount = ImportAccountPayableMedia.MediaNetAmount.GetValueOrDefault(0)
            Me.VendorTax = ImportAccountPayableMedia.MediaVendorTax.GetValueOrDefault(0)
            Me.NetCharges = ImportAccountPayableMedia.MediaNetCharge.GetValueOrDefault(0)

            AdvantageFramework.AccountPayable.CalculateGrossAndCommission(Me.ExtendedNetAmount, Me.DiscountAmount, Me.AccountPayableRadio.MarkupPercent, Me.GrossAmount, Me.AccountPayableRadio.CommissionAmount)

            ReCalculate(False)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

            Me.AccountPayableRadio.Length = ImportAccountPayableMedia.Length
            Me.AccountPayableRadio.DaypartID = ImportAccountPayableMedia.DaypartID

            Me.AccountPayableRadio.DaysOfWeek = ImportAccountPayableMedia.DaysOfWeek
            Me.AccountPayableRadio.StartTime = ImportAccountPayableMedia.StartTime
            Me.AccountPayableRadio.EndTime = ImportAccountPayableMedia.EndTime
            Me.AccountPayableRadio.RateDetail = ImportAccountPayableMedia.RateDetail
            Me.AccountPayableRadio.LineStartDate = ImportAccountPayableMedia.LineStartDate
            Me.AccountPayableRadio.LineEndDate = ImportAccountPayableMedia.LineEndDate
            Me.AccountPayableRadio.PlanCode = ImportAccountPayableMedia.PlanCode
            Me.AccountPayableRadio.PackageCode = ImportAccountPayableMedia.PackageCode
            Me.AccountPayableRadio.Comment = ImportAccountPayableMedia.Comment
            Me.AccountPayableRadio.GrossRate = ImportAccountPayableMedia.MediaGrossRate
            Me.AccountPayableRadio.NetRate = ImportAccountPayableMedia.MediaNetRate

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRadio As AdvantageFramework.Database.Entities.AccountPayableRadio,
                       LoadingActive As Boolean)

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
            Dim RadioOrderLegacy As AdvantageFramework.Database.Entities.RadioOrderLegacy = Nothing
            Dim AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval = Nothing
            Dim MediaApprovalStatus As Generic.KeyValuePair(Of Long, String) = Nothing

            _AccountPayableRadio = AccountPayableRadio

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableRadio.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            _CurrencyRate = If(AccountPayable.CurrencyRate.HasValue AndAlso AccountPayable.CurrencyRate = 0, 1, AccountPayable.CurrencyRate.GetValueOrDefault(1))

            _AccountPayableRadio.DiscountAmount = If(LoadingActive, Math.Abs(_AccountPayableRadio.DiscountAmount.GetValueOrDefault(0)), _AccountPayableRadio.DiscountAmount.GetValueOrDefault(0))

            _OrderNumber = AccountPayableRadio.OrderNumber

            If _AccountPayableRadio.GeneralLedgerAccount IsNot Nothing Then

                _GLADescription = _AccountPayableRadio.GeneralLedgerAccount.Description

            End If

            If _AccountPayableRadio.RewriteFlag.GetValueOrDefault(0) = 0 Then

                RadioOrderLegacy = AdvantageFramework.Database.Procedures.RadioOrderLegacy.LoadByOrderNumber(DbContext, _AccountPayableRadio.OrderNumber)

                If RadioOrderLegacy IsNot Nothing Then

                    _ClientCode = RadioOrderLegacy.ClientCode
                    _DivisionCode = RadioOrderLegacy.DivisionCode
                    _ProductCode = RadioOrderLegacy.ProductCode

                    _AccountPayableRadio.NetGross = RadioOrderLegacy.NetGross.GetValueOrDefault(0)
                    _AccountPayableRadio.CommissionPercent = RadioOrderLegacy.CommissionPercent
                    _AccountPayableRadio.RebatePercent = RadioOrderLegacy.RebatePercent
                    _AccountPayableRadio.MarkupPercent = RadioOrderLegacy.MarkupPercent

                    _PreviouslyPosted = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRadio.Load(DbContext)
                                         Where Entity.OrderNumber = RadioOrderLegacy.OrderNumber AndAlso
                                               Entity.BroadcastMonth = BroadcastMonth AndAlso
                                               Entity.BroadcastYear = BroadcastYear AndAlso
                                               (Entity.ModifyDelete Is Nothing OrElse Entity.ModifyDelete = 0)
                                         Select Entity).Where(Function(Radio) Radio.AccountPayableID <> AccountPayableRadio.AccountPayableID) _
                                                       .Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                End If

                _BroadcastMonth = AccountPayableRadio.BroadcastMonth
                _BroadcastYear = AccountPayableRadio.BroadcastYear

                _OrderNetAmount = GetLegacyOrderNetAmount(_AccountPayableRadio.OrderNumber, _BroadcastMonth, _BroadcastYear, DbContext)

            Else

                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, _AccountPayableRadio.OrderNumber)

                If RadioOrder IsNot Nothing Then

                    _ClientCode = RadioOrder.ClientCode
                    _DivisionCode = RadioOrder.DivisionCode
                    _ProductCode = RadioOrder.ProductCode

                End If

                RadioOrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, _AccountPayableRadio.OrderNumber, _AccountPayableRadio.OrderLineNumber)

                If RadioOrderDetail IsNot Nothing Then

                    Me.IsCommissionOnly = (RadioOrderDetail.BillTypeFlag = 1)

                    _BroadcastMonth = MonthName(RadioOrderDetail.MonthNumber, True).ToUpper
                    _BroadcastYear = RadioOrderDetail.YearNumber
                    _OrderDate = If(RadioOrderDetail.StartDate IsNot Nothing, RadioOrderDetail.StartDate.Value.ToShortDateString, Nothing)

                    _OrderNetAmount = RadioOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                      RadioOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                      RadioOrderDetail.NetCharge.GetValueOrDefault(0) +
                                      RadioOrderDetail.NonResaleAmount.GetValueOrDefault(0)

                    _PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadActiveByOrderNumberAndLineNumber(DbContext, RadioOrderDetail.RadioOrderNumber, RadioOrderDetail.LineNumber) _
                                            .Where(Function(Radio) Radio.AccountPayableID <> AccountPayableRadio.AccountPayableID) _
                                            .Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                End If

            End If

            _GrossAmount = _AccountPayableRadio.ExtendedNetAmount.GetValueOrDefault(0) + _AccountPayableRadio.CommissionAmount.GetValueOrDefault(0)

            _OrderNetBalance = _OrderNetAmount - (Me.DisbursedAmount + _PreviouslyPosted)

            Try

                AccountPayableMediaApproval = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.LoadByAccountPayableID(DbContext, _AccountPayableRadio.AccountPayableID)
                                               Where Entity.OrderNumber = _AccountPayableRadio.OrderNumber AndAlso
                                                     Entity.LineNumber = _AccountPayableRadio.OrderLineNumber AndAlso
                                                     Entity.Source = "R" AndAlso
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
        Public Overrides Function ToString() As String

            ToString = _AccountPayableRadio.AccountPayableID

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

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderLineNumber.ToString

                        If Me.RewriteFlag = 1 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.BroadcastMonth.ToString

                        If Me.RewriteFlag = 0 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.BroadcastYear.ToString

                        If Me.RewriteFlag = 0 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.DisbursedAmount.ToString

                        If Me.TotalSpots.GetValueOrDefault(0) = 0 AndAlso Me.ExtendedNetAmount.GetValueOrDefault(0) = 0 AndAlso Me.VendorTax.GetValueOrDefault(0) = 0 AndAlso _
                                Me.NetCharges.GetValueOrDefault(0) = 0 Then

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.DisbursedAmount.ToString, True)

                        Else

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.DisbursedAmount.ToString, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderNumber.ToString

                    PropertyValue = Value

                    If IsNumeric(PropertyValue) AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Order is required and cannot be zero."

                    End If

                    'Case AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.DisbursedAmount.ToString

                    '    PropertyValue = Value

                    '    If (PropertyValue Is Nothing OrElse PropertyValue = 0) AndAlso Me.NetAmount.GetValueOrDefault(0) = 0 AndAlso Me.NetCharges.GetValueOrDefault(0) = 0 AndAlso _
                    '            Me.VendorTax.GetValueOrDefault(0) = 0 And Me.TotalSpots.GetValueOrDefault(0) = 0 Then

                    '        IsValid = False

                    '        ErrorText = "Invalid disbursement.  All data cannot be zero."

                    '    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

