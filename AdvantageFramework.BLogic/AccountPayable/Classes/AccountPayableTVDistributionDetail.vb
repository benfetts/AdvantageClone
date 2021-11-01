Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableTVDistributionDetail
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

        Private _AccountPayableTV As AdvantageFramework.Database.Entities.AccountPayableTV = Nothing
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
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.AccountPayableTV)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableTV As AdvantageFramework.Database.Entities.AccountPayableTV
            Get
                AccountPayableTV = _AccountPayableTV
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
                OrderLineNumber = _AccountPayableTV.OrderLineNumber
            End Get
            Set(value As Nullable(Of Short))
                _AccountPayableTV.OrderLineNumber = value
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
                TotalSpots = _AccountPayableTV.TotalSpots
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AccountPayableTV.TotalSpots = value
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
                ExtendedNetAmount = _AccountPayableTV.ExtendedNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableTV.ExtendedNetAmount = value
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
                DiscountAmount = _AccountPayableTV.DiscountAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableTV.DiscountAmount = value
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
                NetCharges = _AccountPayableTV.NetCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableTV.NetCharges = value
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
                VendorTax = _AccountPayableTV.VendorTax.GetValueOrDefault(0)
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableTV.VendorTax = value
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
                SalesTaxCode = _AccountPayableTV.SalesTaxCode
            End Get
            Set(ByVal value As String)
                _AccountPayableTV.SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountPayableTV.OfficeCode
            End Get
            Set(ByVal value As String)
                _AccountPayableTV.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _AccountPayableTV.GLACode
            End Get
            Set(ByVal value As String)
                _AccountPayableTV.GLACode = value
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
                RewriteFlag = _AccountPayableTV.RewriteFlag
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableTV.RewriteFlag = value
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

        Private Shared Sub CalculateTax(ByRef AccountPayableTVDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail)

            Dim TotalTax As Decimal = Nothing
            Dim TaxableAmount As Decimal = 0

            TotalTax = AccountPayableTVDistributionDetail.AccountPayableTV.StateTaxPercent.GetValueOrDefault(0) + _
                       AccountPayableTVDistributionDetail.AccountPayableTV.CityTaxPercent.GetValueOrDefault(0) + _
                       AccountPayableTVDistributionDetail.AccountPayableTV.CountyTaxPercent.GetValueOrDefault(0)

            If AccountPayableTVDistributionDetail.AccountPayableTV.IsResaleTax.GetValueOrDefault(0) = 1 Then

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableTVDistributionDetail.AccountPayableTV.ExtendedNetAmount.GetValueOrDefault(0)

                End If

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableTVDistributionDetail.AccountPayableTV.DiscountAmount.GetValueOrDefault(0)

                End If

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableTVDistributionDetail.AccountPayableTV.NetCharges.GetValueOrDefault(0)

                End If

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableTVDistributionDetail.AccountPayableTV.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableTVDistributionDetail.AccountPayableTV.StateTax = FormatNumber(AccountPayableTVDistributionDetail.AccountPayableTV.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableTVDistributionDetail.AccountPayableTV.CountyTax = FormatNumber(AccountPayableTVDistributionDetail.AccountPayableTV.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableTVDistributionDetail.AccountPayableTV.CityTax = FormatNumber(AccountPayableTVDistributionDetail.AccountPayableTV.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

                AccountPayableTVDistributionDetail.VendorTax = 0

            Else

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableTVDistributionDetail.AccountPayableTV.ExtendedNetAmount.GetValueOrDefault(0)

                End If

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableTVDistributionDetail.AccountPayableTV.DiscountAmount.GetValueOrDefault(0)

                End If

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableTVDistributionDetail.AccountPayableTV.NetCharges.GetValueOrDefault(0)

                End If

                AccountPayableTVDistributionDetail.AccountPayableTV.VendorTax = FormatNumber(TaxableAmount * TotalTax / 100, 2)

                TaxableAmount = 0

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableTVDistributionDetail.AccountPayableTV.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableTVDistributionDetail.AccountPayableTV.StateTax = FormatNumber(AccountPayableTVDistributionDetail.AccountPayableTV.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableTVDistributionDetail.AccountPayableTV.CountyTax = FormatNumber(AccountPayableTVDistributionDetail.AccountPayableTV.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableTVDistributionDetail.AccountPayableTV.CityTax = FormatNumber(AccountPayableTVDistributionDetail.AccountPayableTV.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

            End If

        End Sub
        Public Sub ReCalculate(ByVal ReCalculateTax As Boolean)

            Me.AccountPayableTV.RebateAmount = FormatNumber(-1 * Me.GrossAmount.GetValueOrDefault(0) * Me.AccountPayableTV.RebatePercent.GetValueOrDefault(0) / 100, 2)

            If ReCalculateTax Then

                CalculateTax(Me)

            End If

            Me.ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignExtendedNetAmount = FormatNumber(Me.ExtendedNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignDiscountAmount = FormatNumber(Me.DiscountAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

            Me.AccountPayableTV.LineTotal = FormatNumber(Me.DisbursedAmount +
                                                            Me.AccountPayableTV.RebateAmount.GetValueOrDefault(0) +
                                                            Me.AccountPayableTV.CommissionAmount.GetValueOrDefault(0) +
                                                            Me.AccountPayableTV.StateTax.GetValueOrDefault(0) +
                                                            Me.AccountPayableTV.CountyTax.GetValueOrDefault(0) +
                                                            Me.AccountPayableTV.CityTax.GetValueOrDefault(0), 2)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

        End Sub
        Private Shared Sub SetByMonthDetailLegacy(ByRef AccountPayableTVDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail,
                                                  ByVal BroadcastMonth As String, ByVal BroadcastYear As Short, ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim TVOrderDetailLegacyList As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetailLegacy) = Nothing
            Dim OrderNumber As Integer

            OrderNumber = AccountPayableTVDistributionDetail.OrderNumber

            TVOrderDetailLegacyList = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetailLegacy.Load(DbContext)
                                       Where Entity.OrderNumber = OrderNumber AndAlso
                                             Entity.BroadcastYear = BroadcastYear
                                       Select Entity).ToList

            AccountPayableTVDistributionDetail.AccountPayableTV.RebateAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.RebateAmount).GetValueOrDefault(0)

            Select Case BroadcastMonth

                Case "JAN"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JanLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JanCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JanDiscount).GetValueOrDefault(0)

                Case "FEB"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.FebLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.FebCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.FebDiscount).GetValueOrDefault(0)

                Case "MAR"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.MarLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.MarCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.MarDiscount).GetValueOrDefault(0)

                Case "APR"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.AprLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.AprCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.AprDiscount).GetValueOrDefault(0)

                Case "MAY"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.MayLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.MayCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.MayDiscount).GetValueOrDefault(0)

                Case "JUN"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JunLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JunCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JunDiscount).GetValueOrDefault(0)

                Case "JUL"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JulLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JulCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JulDiscount).GetValueOrDefault(0)

                Case "AUG"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.AugLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.AugCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.AugDiscount).GetValueOrDefault(0)

                Case "SEP"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.SepLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.SepCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.SepDiscount).GetValueOrDefault(0)

                Case "OCT"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.OctLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.OctCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.OctDiscount).GetValueOrDefault(0)

                Case "NOV"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.NovLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.NovCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.NovDiscount).GetValueOrDefault(0)

                Case "DEC"

                    AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.DecLineNet).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.DecCommissionAmount).GetValueOrDefault(0)
                    AccountPayableTVDistributionDetail.DiscountAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.DecDiscount).GetValueOrDefault(0)

            End Select

            AccountPayableTVDistributionDetail.OrderNetAmount = AccountPayableTVDistributionDetail.ExtendedNetAmount

        End Sub
        Public Shared Function GetLegacyOrderNetAmount(ByVal OrderNumber As Integer, ByVal BroadcastMonth As String, ByVal BroadcastYear As Short, ByVal DbContext As AdvantageFramework.Database.DbContext) As Decimal

            Dim TVOrderDetailLegacyList As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetailLegacy) = Nothing
            Dim OrderNetAmount As Decimal = 0

            TVOrderDetailLegacyList = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetailLegacy.Load(DbContext)
                                       Where Entity.OrderNumber = OrderNumber AndAlso
                                             Entity.BroadcastYear = BroadcastYear
                                       Select Entity).ToList

            Select Case BroadcastMonth

                Case "JAN"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JanLineNet).GetValueOrDefault(0)

                Case "FEB"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.FebLineNet).GetValueOrDefault(0)

                Case "MAR"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.MarLineNet).GetValueOrDefault(0)

                Case "APR"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.AprLineNet).GetValueOrDefault(0)

                Case "MAY"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.MayLineNet).GetValueOrDefault(0)

                Case "JUN"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JunLineNet).GetValueOrDefault(0)

                Case "JUL"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.JulLineNet).GetValueOrDefault(0)

                Case "AUG"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.AugLineNet).GetValueOrDefault(0)

                Case "SEP"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.SepLineNet).GetValueOrDefault(0)

                Case "OCT"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.OctLineNet).GetValueOrDefault(0)

                Case "NOV"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.NovLineNet).GetValueOrDefault(0)

                Case "DEC"

                    OrderNetAmount = TVOrderDetailLegacyList.Sum(Function(Entity) Entity.DecLineNet).GetValueOrDefault(0)

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
        Public Shared Sub SetBaseValues(ByRef AccountPayableTVDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail,
                                        ByVal TVOrderLegacy As AdvantageFramework.Database.Entities.TVOrderLegacy,
                                        ByVal BroadcastYear As Short, ByVal BroadcastMonth As String,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        CurrencyRate As Decimal)

            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim AccountPayableTVList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableTV) = Nothing
            Dim SumOfNetAmount As Decimal = 0
            Dim SumOfDiscount As Decimal = 0
            Dim SumOfNetCharges As Decimal = 0
            Dim SumOfCommission As Decimal = 0
			
            AccountPayableTVDistributionDetail.CurrencyRate = CurrencyRate

            AccountPayableTVList = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableTV.Load(DbContext)
                                    Where Entity.OrderNumber = TVOrderLegacy.OrderNumber AndAlso
                                          Entity.BroadcastMonth = BroadcastMonth AndAlso
                                          Entity.BroadcastYear = BroadcastYear AndAlso
                                          (Entity.ModifyDelete Is Nothing OrElse Entity.ModifyDelete = 0)
                                    Select Entity).ToList

            AccountPayableTVDistributionDetail.RewriteFlag = 0

            AccountPayableTVDistributionDetail.AccountPayableTV.SequenceNumber = 0

            AccountPayableTVDistributionDetail.OrderNumber = TVOrderLegacy.OrderNumber

            AccountPayableTVDistributionDetail.AccountPayableTV.BroadcastMonth = BroadcastMonth
            AccountPayableTVDistributionDetail.AccountPayableTV.BroadcastYear = BroadcastYear
            AccountPayableTVDistributionDetail.AccountPayableTV.RevisionNumber = TVOrderLegacy.RevisionNumber

            AccountPayableTVDistributionDetail.AccountPayableTV.CityTax = 0
            AccountPayableTVDistributionDetail.AccountPayableTV.CountyTax = 0
            AccountPayableTVDistributionDetail.AccountPayableTV.StateTax = 0

            AccountPayableTVDistributionDetail.AccountPayableTV.OrderLineNumber = Nothing

            AccountPayableTVDistributionDetail.AccountPayableTV.SalesTaxCode = If(String.IsNullOrWhiteSpace(TVOrderLegacy.SalesTaxCode), Nothing, TVOrderLegacy.SalesTaxCode)
            AccountPayableTVDistributionDetail.AccountPayableTV.CityTaxPercent = TVOrderLegacy.CityTaxPercent
            AccountPayableTVDistributionDetail.AccountPayableTV.CountyTaxPercent = TVOrderLegacy.CountyTaxPercent
            AccountPayableTVDistributionDetail.AccountPayableTV.StateTaxPercent = TVOrderLegacy.StateTaxPercent

            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyC = TVOrderLegacy.TaxApplyC
            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyLN = TVOrderLegacy.TaxApplyLN
            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyLND = TVOrderLegacy.TaxApplyLND
            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyNC = TVOrderLegacy.TaxApplyNC
            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyR = TVOrderLegacy.TaxApplyR
            AccountPayableTVDistributionDetail.AccountPayableTV.IsResaleTax = TVOrderLegacy.IsResaleTax

            SetByMonthDetailLegacy(AccountPayableTVDistributionDetail, BroadcastMonth, BroadcastYear, DbContext)

            AccountPayableTVDistributionDetail.AccountPayableTV.CommissionPercent = TVOrderLegacy.CommissionPercent.GetValueOrDefault(0)
            AccountPayableTVDistributionDetail.AccountPayableTV.MarkupPercent = TVOrderLegacy.MarkupPercent.GetValueOrDefault(0)
            AccountPayableTVDistributionDetail.AccountPayableTV.RebatePercent = TVOrderLegacy.RebatePercent.GetValueOrDefault(0)

            AccountPayableTVDistributionDetail.OrderDate = Nothing
            AccountPayableTVDistributionDetail.TotalSpots = Nothing

            AccountPayableTVDistributionDetail.AccountPayableTV.NetGross = TVOrderLegacy.NetGross.GetValueOrDefault(0)

            AccountPayableTVDistributionDetail.ClientCode = TVOrderLegacy.ClientCode
            AccountPayableTVDistributionDetail.DivisionCode = TVOrderLegacy.DivisionCode
            AccountPayableTVDistributionDetail.ProductCode = TVOrderLegacy.ProductCode
            AccountPayableTVDistributionDetail.OfficeCode = TVOrderLegacy.OfficeCode

            Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, TVOrderLegacy.OfficeCode)

            If Office IsNot Nothing Then

                AccountPayableTVDistributionDetail.GLACode = Office.MediaWorkInProgressGLACode

            End If

            AccountPayableTVDistributionDetail.PreviouslyPosted = AccountPayableTVList.Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0)) +
                                                                  AccountPayableTVList.Sum(Function(Entity) Entity.DiscountAmount.GetValueOrDefault(0)) +
                                                                  AccountPayableTVList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0)) +
                                                                  AccountPayableTVList.Sum(Function(Entity) Entity.VendorTax.GetValueOrDefault(0))

            SumOfNetAmount = AccountPayableTVList.Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0))
            SumOfDiscount = AccountPayableTVList.Sum(Function(Entity) Entity.DiscountAmount.GetValueOrDefault(0))
            SumOfNetCharges = AccountPayableTVList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0))
            SumOfCommission = AccountPayableTVList.Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0))
            
            If SumOfCommission > AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0) Then

                AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = 0

            Else

                AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = FormatNumber(AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0) - SumOfCommission, 2)

            End If

            If SumOfNetAmount > AccountPayableTVDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) Then

                AccountPayableTVDistributionDetail.ExtendedNetAmount = 0

            Else

                AccountPayableTVDistributionDetail.ExtendedNetAmount = AccountPayableTVDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) - SumOfNetAmount

            End If

            If SumOfDiscount > Math.Abs(AccountPayableTVDistributionDetail.DiscountAmount.GetValueOrDefault(0)) Then

                AccountPayableTVDistributionDetail.DiscountAmount = 0

            Else

                AccountPayableTVDistributionDetail.DiscountAmount = Math.Abs(AccountPayableTVDistributionDetail.DiscountAmount.GetValueOrDefault(0)) - SumOfDiscount

            End If

            If SumOfNetCharges > AccountPayableTVDistributionDetail.NetCharges.GetValueOrDefault(0) Then

                AccountPayableTVDistributionDetail.NetCharges = 0

            Else

                AccountPayableTVDistributionDetail.NetCharges = AccountPayableTVDistributionDetail.NetCharges.GetValueOrDefault(0) - SumOfNetCharges

            End If

            AccountPayableTVDistributionDetail.GrossAmount = AccountPayableTVDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) + AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0)

            AccountPayableTVDistributionDetail.AccountPayableTV.RebateAmount = FormatNumber(-1 * AccountPayableTVDistributionDetail.GrossAmount.GetValueOrDefault(0) *
                                                                                            AccountPayableTVDistributionDetail.AccountPayableTV.RebatePercent.GetValueOrDefault(0) / 100, 2)

            CalculateTax(AccountPayableTVDistributionDetail)

            AccountPayableTVDistributionDetail.AccountPayableTV.LineTotal = FormatNumber(AccountPayableTVDistributionDetail.DisbursedAmount +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.RebateAmount.GetValueOrDefault(0) +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0) +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.StateTax.GetValueOrDefault(0) +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.CountyTax.GetValueOrDefault(0) +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.CityTax.GetValueOrDefault(0), 2)

            AccountPayableTVDistributionDetail.OrderNetBalance = AccountPayableTVDistributionDetail.OrderNetAmount - (AccountPayableTVDistributionDetail.DisbursedAmount + AccountPayableTVDistributionDetail.PreviouslyPosted)

            AccountPayableTVDistributionDetail.SetForeignCurrencyAmounts()

        End Sub
        Public Shared Sub SetBaseValues(ByRef AccountPayableTVDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail,
                                        ByVal TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
										CurrencyRate As Decimal)

            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim AccountPayableTVList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableTV) = Nothing
            Dim SumOfNetAmount As Decimal = 0
            Dim SumOfDiscount As Decimal = 0
            Dim SumOfNetCharges As Decimal = 0
            Dim SumOfSpots As Integer = 0
            Dim SumOfCommission As Decimal = 0
			
            AccountPayableTVDistributionDetail.CurrencyRate = CurrencyRate

            AccountPayableTVList = AdvantageFramework.Database.Procedures.AccountPayableTV.LoadActiveByOrderNumberAndLineNumber(DbContext, TVOrderDetail.TVOrderNumber, TVOrderDetail.LineNumber).ToList

            AccountPayableTVDistributionDetail.RewriteFlag = 1

            AccountPayableTVDistributionDetail.OrderNumber = TVOrderDetail.TVOrderNumber

            AccountPayableTVDistributionDetail.AccountPayableTV.OrderLineNumber = TVOrderDetail.LineNumber
            AccountPayableTVDistributionDetail.AccountPayableTV.RevisionNumber = TVOrderDetail.RevisionNumber
            AccountPayableTVDistributionDetail.AccountPayableTV.SequenceNumber = TVOrderDetail.SequenceNumber

            AccountPayableTVDistributionDetail.AccountPayableTV.SalesTaxCode = If(String.IsNullOrWhiteSpace(TVOrderDetail.SalesTaxCode), Nothing, TVOrderDetail.SalesTaxCode)
            AccountPayableTVDistributionDetail.AccountPayableTV.CityTaxPercent = If(TVOrderDetail.CityTaxPercent IsNot Nothing, Format(TVOrderDetail.CityTaxPercent, "#0.000"), Nothing)
            AccountPayableTVDistributionDetail.AccountPayableTV.CountyTaxPercent = If(TVOrderDetail.CountyTaxPercent IsNot Nothing, Format(TVOrderDetail.CountyTaxPercent, "#0.000"), Nothing)
            AccountPayableTVDistributionDetail.AccountPayableTV.StateTaxPercent = If(TVOrderDetail.StateTaxPercent IsNot Nothing, Format(TVOrderDetail.StateTaxPercent, "#0.000"), Nothing)

            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyC = TVOrderDetail.TaxApplyC
            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyLN = TVOrderDetail.TaxApplyLN
            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyLND = TVOrderDetail.TaxApplyND
            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyNC = TVOrderDetail.TaxApplyNC
            AccountPayableTVDistributionDetail.AccountPayableTV.TaxApplyR = TVOrderDetail.TaxApplyR
            AccountPayableTVDistributionDetail.AccountPayableTV.IsResaleTax = TVOrderDetail.IsResaleTax

            If TVOrderDetail.BillTypeFlag = 1 Then 'commission only

                AccountPayableTVDistributionDetail.IsCommissionOnly = True
                AccountPayableTVDistributionDetail.AccountPayableTV.CityTax = 0
                AccountPayableTVDistributionDetail.AccountPayableTV.CountyTax = 0
                AccountPayableTVDistributionDetail.AccountPayableTV.StateTax = 0

                AccountPayableTVDistributionDetail.AccountPayableTV.ExtendedNetAmount = 0
                AccountPayableTVDistributionDetail.AccountPayableTV.CommissionPercent = 0
                AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = 0
                AccountPayableTVDistributionDetail.AccountPayableTV.MarkupPercent = 0
                AccountPayableTVDistributionDetail.AccountPayableTV.RebatePercent = 0
                AccountPayableTVDistributionDetail.AccountPayableTV.RebateAmount = 0
                AccountPayableTVDistributionDetail.AccountPayableTV.LineTotal = 0
                AccountPayableTVDistributionDetail.AccountPayableTV.NetCharges = 0

                AccountPayableTVDistributionDetail.OrderNetAmount = 0

            Else

                AccountPayableTVDistributionDetail.IsCommissionOnly = False
                AccountPayableTVDistributionDetail.AccountPayableTV.CityTax = TVOrderDetail.CityTaxAmount
                AccountPayableTVDistributionDetail.AccountPayableTV.CountyTax = TVOrderDetail.CountyTaxAmount
                AccountPayableTVDistributionDetail.AccountPayableTV.StateTax = TVOrderDetail.StateTaxAmount

                AccountPayableTVDistributionDetail.AccountPayableTV.ExtendedNetAmount = TVOrderDetail.ExtendedNetAmount
                AccountPayableTVDistributionDetail.AccountPayableTV.CommissionPercent = TVOrderDetail.CommissionPercent
                AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = TVOrderDetail.CommissionAmount
                AccountPayableTVDistributionDetail.AccountPayableTV.MarkupPercent = TVOrderDetail.MarkupPercent
                AccountPayableTVDistributionDetail.AccountPayableTV.RebatePercent = TVOrderDetail.RebatePercent
                AccountPayableTVDistributionDetail.AccountPayableTV.RebateAmount = TVOrderDetail.RebateAmount
                AccountPayableTVDistributionDetail.AccountPayableTV.LineTotal = TVOrderDetail.LineTotal
                AccountPayableTVDistributionDetail.AccountPayableTV.NetCharges = TVOrderDetail.NetCharges.GetValueOrDefault(0)

                AccountPayableTVDistributionDetail.OrderNetAmount = TVOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                                                    TVOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                                                    TVOrderDetail.NetCharges.GetValueOrDefault(0) +
                                                                    TVOrderDetail.NonResaleAmount.GetValueOrDefault(0)

            End If

            AccountPayableTVDistributionDetail.BroadcastYear = TVOrderDetail.YearNumber
            AccountPayableTVDistributionDetail.BroadcastMonth = MonthName(TVOrderDetail.MonthNumber, True).ToUpper
            AccountPayableTVDistributionDetail.OrderDate = TVOrderDetail.StartDate
            AccountPayableTVDistributionDetail.TotalSpots = TVOrderDetail.TotalSpots

            TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, TVOrderDetail.TVOrderNumber)

            If TVOrder IsNot Nothing Then

                AccountPayableTVDistributionDetail.AccountPayableTV.NetGross = TVOrder.NetGross.GetValueOrDefault(0)

                AccountPayableTVDistributionDetail.ClientCode = TVOrder.ClientCode
                AccountPayableTVDistributionDetail.DivisionCode = TVOrder.DivisionCode
                AccountPayableTVDistributionDetail.ProductCode = TVOrder.ProductCode
                AccountPayableTVDistributionDetail.OfficeCode = TVOrder.OfficeCode

                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, TVOrder.OfficeCode)

                If Office IsNot Nothing Then

                    AccountPayableTVDistributionDetail.GLACode = Office.MediaWorkInProgressGLACode

                End If

            End If

            AccountPayableTVDistributionDetail.PreviouslyPosted = AccountPayableTVList.Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0)) +
                                                                  AccountPayableTVList.Sum(Function(Entity) Entity.DiscountAmount.GetValueOrDefault(0)) +
                                                                  AccountPayableTVList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0)) +
                                                                  AccountPayableTVList.Sum(Function(Entity) Entity.VendorTax.GetValueOrDefault(0))

            SumOfNetAmount = AccountPayableTVList.Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0))
            SumOfDiscount = AccountPayableTVList.Sum(Function(Entity) Math.Abs(Entity.DiscountAmount.GetValueOrDefault(0)))
            SumOfNetCharges = AccountPayableTVList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0))
            SumOfSpots = AccountPayableTVList.Sum(Function(Entity) Entity.TotalSpots.GetValueOrDefault(0))
            SumOfCommission = AccountPayableTVList.Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0))

            If SumOfCommission > AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0) OrElse TVOrderDetail.BillTypeFlag = 1 Then

                AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = 0

            Else

                AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount = FormatNumber(AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0) - SumOfCommission, 2)

            End If

            If SumOfNetAmount > TVOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) OrElse TVOrderDetail.BillTypeFlag = 1 Then

                AccountPayableTVDistributionDetail.ExtendedNetAmount = 0

            Else

                AccountPayableTVDistributionDetail.ExtendedNetAmount = TVOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) - SumOfNetAmount

            End If

            If SumOfDiscount > Math.Abs(TVOrderDetail.DiscountAmount.GetValueOrDefault(0)) OrElse TVOrderDetail.BillTypeFlag = 1 Then

                AccountPayableTVDistributionDetail.DiscountAmount = 0

            Else

                AccountPayableTVDistributionDetail.DiscountAmount = Math.Abs(TVOrderDetail.DiscountAmount.GetValueOrDefault(0)) - SumOfDiscount

            End If

            If SumOfNetCharges > TVOrderDetail.NetCharges.GetValueOrDefault(0) OrElse TVOrderDetail.BillTypeFlag = 1 Then

                AccountPayableTVDistributionDetail.NetCharges = 0

            Else

                AccountPayableTVDistributionDetail.NetCharges = TVOrderDetail.NetCharges.GetValueOrDefault(0) - SumOfNetCharges

            End If

            If SumOfSpots > TVOrderDetail.TotalSpots.GetValueOrDefault(0) Then

                AccountPayableTVDistributionDetail.TotalSpots = 0

            Else

                AccountPayableTVDistributionDetail.TotalSpots = TVOrderDetail.TotalSpots.GetValueOrDefault(0) - SumOfSpots

            End If

            AccountPayableTVDistributionDetail.GrossAmount = AccountPayableTVDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) + AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0)

            AccountPayableTVDistributionDetail.AccountPayableTV.RebateAmount = FormatNumber(-1 * AccountPayableTVDistributionDetail.GrossAmount.GetValueOrDefault(0) *
                                                                                            AccountPayableTVDistributionDetail.AccountPayableTV.RebatePercent.GetValueOrDefault(0) / 100, 2)

            CalculateTax(AccountPayableTVDistributionDetail)

            AccountPayableTVDistributionDetail.AccountPayableTV.LineTotal = FormatNumber(AccountPayableTVDistributionDetail.DisbursedAmount +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.RebateAmount.GetValueOrDefault(0) +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.CommissionAmount.GetValueOrDefault(0) +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.StateTax.GetValueOrDefault(0) +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.CountyTax.GetValueOrDefault(0) +
                                                                                         AccountPayableTVDistributionDetail.AccountPayableTV.CityTax.GetValueOrDefault(0), 2)

            AccountPayableTVDistributionDetail.OrderNetBalance = AccountPayableTVDistributionDetail.OrderNetAmount - (AccountPayableTVDistributionDetail.DisbursedAmount + AccountPayableTVDistributionDetail.PreviouslyPosted)

            AccountPayableTVDistributionDetail.SetForeignCurrencyAmounts()

        End Sub
        Public Sub New()

            _AccountPayableTV = New AdvantageFramework.Database.Entities.AccountPayableTV

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
            Dim TVOrderLegacy As AdvantageFramework.Database.Entities.TVOrderLegacy = Nothing

            _AccountPayableTV = New AdvantageFramework.Database.Entities.AccountPayableTV

            If ImportAccountPayableMedia.OrderLineNumber IsNot Nothing Then

                TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayableMedia.OrderNumber, ImportAccountPayableMedia.OrderLineNumber)

            End If

            If TVOrderDetail Is Nothing Then

                TVOrderLegacy = AdvantageFramework.Database.Procedures.TVOrderLegacy.LoadByOrderNumber(DbContext, ImportAccountPayableMedia.OrderNumber)

                If TVOrderLegacy IsNot Nothing Then

                    SetBaseValues(Me, TVOrderLegacy, ImportAccountPayableMedia.Year, ImportAccountPayableMedia.Month, DbContext, 1)

                End If

            Else

                SetBaseValues(Me, TVOrderDetail, DbContext, 1)

            End If

            Me.DiscountAmount = 0 'should not bring this in, there is not a place in import file for discount, to bring it in will cause OOB

            Me.TotalSpots = ImportAccountPayableMedia.MediaQuantity
            Me.ExtendedNetAmount = ImportAccountPayableMedia.MediaNetAmount.GetValueOrDefault(0)
            Me.VendorTax = ImportAccountPayableMedia.MediaVendorTax.GetValueOrDefault(0)
            Me.NetCharges = ImportAccountPayableMedia.MediaNetCharge.GetValueOrDefault(0)

            AdvantageFramework.AccountPayable.CalculateGrossAndCommission(Me.ExtendedNetAmount, Me.DiscountAmount, Me.AccountPayableTV.MarkupPercent, Me.GrossAmount, Me.AccountPayableTV.CommissionAmount)

            ReCalculate(False)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

            Me.AccountPayableTV.Length = ImportAccountPayableMedia.Length
            Me.AccountPayableTV.DaypartID = ImportAccountPayableMedia.DaypartID

            Me.AccountPayableTV.DaysOfWeek = ImportAccountPayableMedia.DaysOfWeek
            Me.AccountPayableTV.StartTime = ImportAccountPayableMedia.StartTime
            Me.AccountPayableTV.EndTime = ImportAccountPayableMedia.EndTime
            Me.AccountPayableTV.RateDetail = ImportAccountPayableMedia.RateDetail
            Me.AccountPayableTV.LineStartDate = ImportAccountPayableMedia.LineStartDate
            Me.AccountPayableTV.LineEndDate = ImportAccountPayableMedia.LineEndDate
            Me.AccountPayableTV.PlanCode = ImportAccountPayableMedia.PlanCode
            Me.AccountPayableTV.PackageCode = ImportAccountPayableMedia.PackageCode
            Me.AccountPayableTV.Comment = ImportAccountPayableMedia.Comment
            Me.AccountPayableTV.GrossRate = ImportAccountPayableMedia.MediaGrossRate
            Me.AccountPayableTV.NetRate = ImportAccountPayableMedia.MediaNetRate

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableTV As AdvantageFramework.Database.Entities.AccountPayableTV,
                       LoadingActive As Boolean)

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
            Dim TVOrderLegacy As AdvantageFramework.Database.Entities.TVOrderLegacy = Nothing
            Dim AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval = Nothing
            Dim MediaApprovalStatus As Generic.KeyValuePair(Of Long, String) = Nothing

            _AccountPayableTV = AccountPayableTV

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableTV.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            _CurrencyRate = If(AccountPayable.CurrencyRate.HasValue AndAlso AccountPayable.CurrencyRate = 0, 1, AccountPayable.CurrencyRate.GetValueOrDefault(1))

            _AccountPayableTV.DiscountAmount = If(LoadingActive, Math.Abs(_AccountPayableTV.DiscountAmount.GetValueOrDefault(0)), _AccountPayableTV.DiscountAmount.GetValueOrDefault(0))

            _OrderNumber = AccountPayableTV.OrderNumber

            If _AccountPayableTV.GeneralLedgerAccount IsNot Nothing Then

                _GLADescription = _AccountPayableTV.GeneralLedgerAccount.Description

            End If

            If _AccountPayableTV.RewriteFlag.GetValueOrDefault(0) = 0 Then

                TVOrderLegacy = AdvantageFramework.Database.Procedures.TVOrderLegacy.LoadByOrderNumber(DbContext, _AccountPayableTV.OrderNumber)

                If TVOrderLegacy IsNot Nothing Then

                    _ClientCode = TVOrderLegacy.ClientCode
                    _DivisionCode = TVOrderLegacy.DivisionCode
                    _ProductCode = TVOrderLegacy.ProductCode

                    _AccountPayableTV.NetGross = TVOrderLegacy.NetGross.GetValueOrDefault(0)
                    _AccountPayableTV.CommissionPercent = TVOrderLegacy.CommissionPercent
                    _AccountPayableTV.RebatePercent = TVOrderLegacy.RebatePercent
                    _AccountPayableTV.MarkupPercent = TVOrderLegacy.MarkupPercent

                    _PreviouslyPosted = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableTV.Load(DbContext)
                                         Where Entity.OrderNumber = TVOrderLegacy.OrderNumber AndAlso
                                               Entity.BroadcastMonth = AccountPayableTV.BroadcastMonth AndAlso
                                               Entity.BroadcastYear = AccountPayableTV.BroadcastYear AndAlso
                                               (Entity.ModifyDelete Is Nothing OrElse Entity.ModifyDelete = 0)
                                         Select Entity).Where(Function(TV) TV.AccountPayableID <> AccountPayableTV.AccountPayableID) _
                                                       .Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                End If

                _BroadcastMonth = AccountPayableTV.BroadcastMonth
                _BroadcastYear = AccountPayableTV.BroadcastYear

                If String.IsNullOrWhiteSpace(AccountPayableTV.BroadcastMonth) AndAlso AccountPayableTV.BroadcastYear.HasValue Then

                    _OrderNetAmount = GetLegacyOrderNetAmount(_AccountPayableTV.OrderNumber, _BroadcastMonth, _BroadcastYear, DbContext)

                End If

            Else

                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, _AccountPayableTV.OrderNumber)

                If TVOrder IsNot Nothing Then

                    _ClientCode = TVOrder.ClientCode
                    _DivisionCode = TVOrder.DivisionCode
                    _ProductCode = TVOrder.ProductCode

                End If

                TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, _AccountPayableTV.OrderNumber, _AccountPayableTV.OrderLineNumber)

                If TVOrderDetail IsNot Nothing Then

                    Me.IsCommissionOnly = (TVOrderDetail.BillTypeFlag = 1)

                    _BroadcastMonth = MonthName(TVOrderDetail.MonthNumber, True).ToUpper
                    _BroadcastYear = TVOrderDetail.YearNumber
                    _OrderDate = If(TVOrderDetail.StartDate IsNot Nothing, TVOrderDetail.StartDate.Value.ToShortDateString, Nothing)

                    _OrderNetAmount = TVOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                      TVOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                      TVOrderDetail.NetCharges.GetValueOrDefault(0) +
                                      TVOrderDetail.NonResaleAmount.GetValueOrDefault(0)

                    _PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableTV.LoadActiveByOrderNumberAndLineNumber(DbContext, TVOrderDetail.TVOrderNumber, TVOrderDetail.LineNumber) _
                                            .Where(Function(TV) TV.AccountPayableID <> AccountPayableTV.AccountPayableID) _
                                            .Sum(Function(Entity) Entity.ExtendedNetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

                End If

            End If

            _GrossAmount = _AccountPayableTV.ExtendedNetAmount.GetValueOrDefault(0) + _AccountPayableTV.CommissionAmount.GetValueOrDefault(0)

            _OrderNetBalance = _OrderNetAmount - (Me.DisbursedAmount + _PreviouslyPosted)

            Try

                AccountPayableMediaApproval = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.LoadByAccountPayableID(DbContext, _AccountPayableTV.AccountPayableID)
                                               Where Entity.OrderNumber = _AccountPayableTV.OrderNumber AndAlso
                                                     Entity.LineNumber = _AccountPayableTV.OrderLineNumber AndAlso
                                                     Entity.Source = "T" AndAlso
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

            ToString = _AccountPayableTV.AccountPayableID

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

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderLineNumber.ToString

                        If Me.RewriteFlag = 1 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.BroadcastMonth.ToString

                        If Me.RewriteFlag = 0 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.BroadcastYear.ToString

                        If Me.RewriteFlag = 0 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.DisbursedAmount.ToString

                        If Me.TotalSpots.GetValueOrDefault(0) = 0 AndAlso Me.ExtendedNetAmount.GetValueOrDefault(0) = 0 AndAlso Me.VendorTax.GetValueOrDefault(0) = 0 AndAlso _
                                Me.NetCharges.GetValueOrDefault(0) = 0 Then

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.DisbursedAmount.ToString, True)

                        Else

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.DisbursedAmount.ToString, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderNumber.ToString

                    PropertyValue = Value

                    If IsNumeric(PropertyValue) AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Order is required and cannot be zero."

                    End If

                    'Case AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.DisbursedAmount.ToString

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

