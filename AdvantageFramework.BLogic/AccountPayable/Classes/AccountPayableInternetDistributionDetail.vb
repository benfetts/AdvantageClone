Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableInternetDistributionDetail
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
            InternetOrderNumber
            InternetDetailLineNumber
            StartDate
            EndDate
            CostType
            Impressions
            ForeignRate
            Rate
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

        Private _AccountPayableInternet As AdvantageFramework.Database.Entities.AccountPayableInternet = Nothing
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
        Private _CostType As String = Nothing
        Private _GrossAmount As Nullable(Of Decimal) = Nothing
        Private _PlanEstID As String = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _OrderNetBalance As Decimal = Nothing
        Private _PreviouslyPosted As Decimal = Nothing
        Private _InternetOrderNumber As Nullable(Of Integer) = Nothing
        Private _InternetDetailLineNumber As Nullable(Of Short) = Nothing
        Private _ForeignRate As Nullable(Of Decimal) = Nothing
        Private _ForeignGrossAmount As Decimal = Nothing
        Private _ForeignNetAmount As Decimal = Nothing
        Private _ForeignDiscountAmount As Decimal = Nothing
        Private _ForeignNetCharges As Decimal = Nothing
        Private _ForeignVendorTax As Decimal = Nothing
        Private _CurrencyRate As Decimal = 1

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.AccountPayableInternet)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableInternet As AdvantageFramework.Database.Entities.AccountPayableInternet
            Get
                AccountPayableInternet = _AccountPayableInternet
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
        Public Property InternetOrderNumber() As Nullable(Of Integer)
            Get
                InternetOrderNumber = _InternetOrderNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _InternetOrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Line")>
        Public Property InternetDetailLineNumber() As Nullable(Of Short)
            Get
                InternetDetailLineNumber = _InternetDetailLineNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetDetailLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _EndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CostType() As String
            Get
                CostType = _CostType
            End Get
            Set(ByVal value As String)
                _CostType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", CustomColumnCaption:="Quantity", UseMaxValue:=True, MaxValue:=2147483647, UseMinValue:=True, MinValue:=-2147483647)>
        Public Property Impressions() As Nullable(Of Integer)
            Get
                Impressions = _AccountPayableInternet.Impressions
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AccountPayableInternet.Impressions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property ForeignRate() As Nullable(Of Decimal)
            Get
                ForeignRate = _ForeignRate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ForeignRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _AccountPayableInternet.Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableInternet.Rate = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _AccountPayableInternet.NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableInternet.NetAmount = value
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
                DiscountAmount = _AccountPayableInternet.DiscountAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableInternet.DiscountAmount = value
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
                NetCharges = _AccountPayableInternet.NetCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableInternet.NetCharges = value
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
                VendorTax = _AccountPayableInternet.VendorTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableInternet.VendorTax = value
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
                SalesTaxCode = _AccountPayableInternet.SalesTaxCode
            End Get
            Set(ByVal value As String)
                _AccountPayableInternet.SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountPayableInternet.OfficeCode
            End Get
            Set(ByVal value As String)
                _AccountPayableInternet.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _AccountPayableInternet.GLACode
            End Get
            Set(ByVal value As String)
                _AccountPayableInternet.GLACode = value
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

        Public Sub ReCalculate(ByVal ReCalculateTax As Boolean)

            Me.AccountPayableInternet.RebateAmount = FormatNumber(-1 * Me.GrossAmount.GetValueOrDefault(0) * Me.AccountPayableInternet.RebatePercent.GetValueOrDefault(0) / 100, 2)

            If ReCalculateTax Then

                CalculateTax(Me)

            End If

            Me.ForeignNetAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignDiscountAmount = FormatNumber(Me.DiscountAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

            Me.AccountPayableInternet.LineTotal = FormatNumber(Me.DisbursedAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableInternet.RebateAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableInternet.CommissionAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableInternet.StateTax.GetValueOrDefault(0) +
                                                                Me.AccountPayableInternet.CountyTax.GetValueOrDefault(0) +
                                                                Me.AccountPayableInternet.CityTax.GetValueOrDefault(0), 2)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

        End Sub
        Private Shared Sub CalculateTax(ByRef AccountPayableInternetDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail)

            Dim TotalTax As Decimal = Nothing
            Dim TaxableAmount As Decimal = 0

            TotalTax = AccountPayableInternetDistributionDetail.AccountPayableInternet.StateTaxPercent.GetValueOrDefault(0) +
                       AccountPayableInternetDistributionDetail.AccountPayableInternet.CityTaxPercent.GetValueOrDefault(0) +
                       AccountPayableInternetDistributionDetail.AccountPayableInternet.CountyTaxPercent.GetValueOrDefault(0)

            If AccountPayableInternetDistributionDetail.AccountPayableInternet.IsResaleTax.GetValueOrDefault(0) = 1 Then

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableInternetDistributionDetail.AccountPayableInternet.NetAmount.GetValueOrDefault(0)

                End If

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableInternetDistributionDetail.AccountPayableInternet.DiscountAmount.GetValueOrDefault(0)

                End If

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableInternetDistributionDetail.AccountPayableInternet.NetCharges.GetValueOrDefault(0)

                End If

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableInternetDistributionDetail.AccountPayableInternet.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableInternetDistributionDetail.AccountPayableInternet.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableInternetDistributionDetail.AccountPayableInternet.StateTax = FormatNumber(AccountPayableInternetDistributionDetail.AccountPayableInternet.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableInternetDistributionDetail.AccountPayableInternet.CountyTax = FormatNumber(AccountPayableInternetDistributionDetail.AccountPayableInternet.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableInternetDistributionDetail.AccountPayableInternet.CityTax = FormatNumber(AccountPayableInternetDistributionDetail.AccountPayableInternet.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

                AccountPayableInternetDistributionDetail.VendorTax = 0

            Else

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableInternetDistributionDetail.AccountPayableInternet.NetAmount.GetValueOrDefault(0)

                End If

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableInternetDistributionDetail.AccountPayableInternet.DiscountAmount.GetValueOrDefault(0)

                End If

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableInternetDistributionDetail.AccountPayableInternet.NetCharges.GetValueOrDefault(0)

                End If

                AccountPayableInternetDistributionDetail.VendorTax = FormatNumber(TaxableAmount * TotalTax / 100, 2)

                TaxableAmount = 0

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableInternetDistributionDetail.AccountPayableInternet.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableInternetDistributionDetail.AccountPayableInternet.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableInternetDistributionDetail.AccountPayableInternet.StateTax = FormatNumber(AccountPayableInternetDistributionDetail.AccountPayableInternet.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableInternetDistributionDetail.AccountPayableInternet.CountyTax = FormatNumber(AccountPayableInternetDistributionDetail.AccountPayableInternet.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableInternetDistributionDetail.AccountPayableInternet.CityTax = FormatNumber(AccountPayableInternetDistributionDetail.AccountPayableInternet.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

            End If

        End Sub
        Private Sub SetForeignCurrencyAmounts()

            _ForeignRate = FormatNumber(Me.Rate.GetValueOrDefault(0) / Me.CurrencyRate, 4)
            _ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignNetAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignDiscountAmount = FormatNumber(Me.DiscountAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

        End Sub
        Public Shared Sub SetBaseValues(ByRef AccountPayableInternetDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail,
                                        ByVal InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim AccountPayableInternetList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableInternet) = Nothing
            Dim SumOfImpressions As Integer = 0
            Dim SumOfNetAmount As Decimal = 0
            Dim SumOfDiscount As Decimal = 0
            Dim SumOfNetCharges As Decimal = 0
            Dim SumOfCommission As Decimal = 0

            AccountPayableInternetList = AdvantageFramework.Database.Procedures.AccountPayableInternet.LoadActiveByOrderNumberAndLineNumber(DbContext, InternetOrderDetail.InternetOrderOrderNumber, InternetOrderDetail.LineNumber).ToList

            AccountPayableInternetDistributionDetail.InternetOrderNumber = InternetOrderDetail.InternetOrderOrderNumber
            AccountPayableInternetDistributionDetail.InternetDetailLineNumber = InternetOrderDetail.LineNumber

            AccountPayableInternetDistributionDetail.AccountPayableInternet.InternetDetailRevisionNumber = InternetOrderDetail.RevisionNumber
            AccountPayableInternetDistributionDetail.AccountPayableInternet.InternetDetailSequenceNumber = InternetOrderDetail.SequenceNumber

            AccountPayableInternetDistributionDetail.AccountPayableInternet.SalesTaxCode = If(String.IsNullOrWhiteSpace(InternetOrderDetail.SalesTaxCode), Nothing, InternetOrderDetail.SalesTaxCode)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.CityTaxPercent = InternetOrderDetail.CityTaxPercent.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.CountyTaxPercent = InternetOrderDetail.CountyTaxPercent.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.StateTaxPercent = InternetOrderDetail.StateTaxPercent.GetValueOrDefault(0)

            AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyC = InternetOrderDetail.TaxApplyC.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyLN = InternetOrderDetail.TaxApplyLN.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyLND = InternetOrderDetail.TaxApplyLND.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyNC = InternetOrderDetail.TaxApplyNC.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.TaxApplyR = InternetOrderDetail.TaxApplyR.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.IsResaleTax = InternetOrderDetail.IsResaleTax.GetValueOrDefault(0)

            AccountPayableInternetDistributionDetail.AccountPayableInternet.CityTax = InternetOrderDetail.CityTaxAmount.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.CountyTax = InternetOrderDetail.CountyTaxAmount.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.StateTax = InternetOrderDetail.StateTaxAmount.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.VendorTax = InternetOrderDetail.NonResalesAmount.GetValueOrDefault(0)

            AccountPayableInternetDistributionDetail.AccountPayableInternet.CommissionPercent = InternetOrderDetail.CommissionPercent.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.CommissionAmount = InternetOrderDetail.CommissionAmount.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.MarkupPercent = InternetOrderDetail.MarkupPercent.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.RebatePercent = InternetOrderDetail.RebatePercent.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.RebateAmount = InternetOrderDetail.RebateAmount.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.Rate = InternetOrderDetail.CostRate.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.AccountPayableInternet.LineTotal = InternetOrderDetail.LineTotal.GetValueOrDefault(0)
            AccountPayableInternetDistributionDetail.CostType = InternetOrderDetail.CostType
            AccountPayableInternetDistributionDetail.StartDate = InternetOrderDetail.StartDate
            AccountPayableInternetDistributionDetail.EndDate = InternetOrderDetail.EndDate

            InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, InternetOrderDetail.InternetOrderOrderNumber)

            If InternetOrder IsNot Nothing Then

                AccountPayableInternetDistributionDetail.AccountPayableInternet.NetGross = InternetOrder.NetGross.GetValueOrDefault(0)

                AccountPayableInternetDistributionDetail.ClientCode = InternetOrder.ClientCode
                AccountPayableInternetDistributionDetail.DivisionCode = InternetOrder.DivisionCode
                AccountPayableInternetDistributionDetail.ProductCode = InternetOrder.ProductCode
                AccountPayableInternetDistributionDetail.OfficeCode = InternetOrder.OfficeCode

                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, InternetOrder.OfficeCode)

                If Office IsNot Nothing Then

                    AccountPayableInternetDistributionDetail.GLACode = Office.MediaWorkInProgressGLACode

                End If

            End If

            AccountPayableInternetDistributionDetail.OrderNetAmount = InternetOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                                                      InternetOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                                                      InternetOrderDetail.NetCharge.GetValueOrDefault(0) +
                                                                      InternetOrderDetail.NonResalesAmount.GetValueOrDefault(0)

            AccountPayableInternetDistributionDetail.PreviouslyPosted = AccountPayableInternetList.Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0)) +
                                                                        AccountPayableInternetList.Sum(Function(Entity) Entity.DiscountAmount.GetValueOrDefault(0)) +
                                                                        AccountPayableInternetList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0)) +
                                                                        AccountPayableInternetList.Sum(Function(Entity) Entity.VendorTax.GetValueOrDefault(0))

            SumOfImpressions = AccountPayableInternetList.Sum(Function(Entity) Entity.Impressions.GetValueOrDefault(0))
            SumOfNetAmount = AccountPayableInternetList.Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0))
            SumOfDiscount = AccountPayableInternetList.Sum(Function(Entity) Math.Abs(Entity.DiscountAmount.GetValueOrDefault(0)))
            SumOfNetCharges = AccountPayableInternetList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0))
            SumOfCommission = AccountPayableInternetList.Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0))

            If SumOfCommission > AccountPayableInternetDistributionDetail.AccountPayableInternet.CommissionAmount.GetValueOrDefault(0) Then

                AccountPayableInternetDistributionDetail.AccountPayableInternet.CommissionAmount = 0

            Else

                AccountPayableInternetDistributionDetail.AccountPayableInternet.CommissionAmount = FormatNumber(InternetOrderDetail.CommissionAmount.GetValueOrDefault(0) - SumOfCommission, 2)

            End If

            If SumOfImpressions > InternetOrderDetail.GuaranteedImpressions.GetValueOrDefault(0) Then

                AccountPayableInternetDistributionDetail.Impressions = 0

            Else

                AccountPayableInternetDistributionDetail.Impressions = InternetOrderDetail.GuaranteedImpressions.GetValueOrDefault(0) - SumOfImpressions

            End If

            If SumOfNetAmount > InternetOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) Then

                AccountPayableInternetDistributionDetail.NetAmount = 0

            Else

                AccountPayableInternetDistributionDetail.NetAmount = InternetOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) - SumOfNetAmount

            End If

            AccountPayableInternetDistributionDetail.GrossAmount = AccountPayableInternetDistributionDetail.NetAmount.GetValueOrDefault(0) + AccountPayableInternetDistributionDetail.AccountPayableInternet.CommissionAmount.GetValueOrDefault(0)

            If SumOfDiscount > Math.Abs(InternetOrderDetail.DiscountAmount.GetValueOrDefault(0)) Then

                AccountPayableInternetDistributionDetail.DiscountAmount = 0

            Else

                AccountPayableInternetDistributionDetail.DiscountAmount = Math.Abs(InternetOrderDetail.DiscountAmount.GetValueOrDefault(0)) - SumOfDiscount

            End If

            If SumOfNetCharges > InternetOrderDetail.NetCharge.GetValueOrDefault(0) Then

                AccountPayableInternetDistributionDetail.NetCharges = 0

            Else

                AccountPayableInternetDistributionDetail.NetCharges = InternetOrderDetail.NetCharge.GetValueOrDefault(0) - SumOfNetCharges

            End If

            If AccountPayableInternetDistributionDetail.CostType = "NA" Then

                AccountPayableInternetDistributionDetail.Impressions = Nothing
                AccountPayableInternetDistributionDetail.Rate = Nothing

            End If

            AccountPayableInternetDistributionDetail.AccountPayableInternet.RebateAmount = FormatNumber(-1 * AccountPayableInternetDistributionDetail.GrossAmount.GetValueOrDefault(0) *
                                                                                                        AccountPayableInternetDistributionDetail.AccountPayableInternet.RebatePercent.GetValueOrDefault(0) / 100, 2)

            CalculateTax(AccountPayableInternetDistributionDetail)

            AccountPayableInternetDistributionDetail.AccountPayableInternet.LineTotal = FormatNumber(AccountPayableInternetDistributionDetail.DisbursedAmount.GetValueOrDefault(0) +
                                                                                                     AccountPayableInternetDistributionDetail.AccountPayableInternet.RebateAmount.GetValueOrDefault(0) +
                                                                                                     AccountPayableInternetDistributionDetail.AccountPayableInternet.CommissionAmount.GetValueOrDefault(0) +
                                                                                                     AccountPayableInternetDistributionDetail.AccountPayableInternet.StateTax.GetValueOrDefault(0) +
                                                                                                     AccountPayableInternetDistributionDetail.AccountPayableInternet.CountyTax.GetValueOrDefault(0) +
                                                                                                     AccountPayableInternetDistributionDetail.AccountPayableInternet.CityTax.GetValueOrDefault(0), 2)

            AccountPayableInternetDistributionDetail.OrderNetBalance = AccountPayableInternetDistributionDetail.OrderNetAmount - (AccountPayableInternetDistributionDetail.DisbursedAmount + AccountPayableInternetDistributionDetail.PreviouslyPosted)

            AccountPayableInternetDistributionDetail.SetForeignCurrencyAmounts()

        End Sub
        Public Sub New()

            _AccountPayableInternet = New AdvantageFramework.Database.Entities.AccountPayableInternet

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing

            _AccountPayableInternet = New AdvantageFramework.Database.Entities.AccountPayableInternet

            Me.Impressions = ImportAccountPayableMedia.MediaQuantity

            InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayableMedia.OrderNumber, ImportAccountPayableMedia.OrderLineNumber)

            If InternetOrderDetail IsNot Nothing Then

                SetBaseValues(Me, InternetOrderDetail, DbContext)

                Me.DiscountAmount = 0 'should not bring this in, there is not a place in import file for discount, to bring it in will cause OOB

            End If

            Me.NetAmount = ImportAccountPayableMedia.MediaNetAmount.GetValueOrDefault(0)
            Me.VendorTax = ImportAccountPayableMedia.MediaVendorTax.GetValueOrDefault(0)
            Me.NetCharges = ImportAccountPayableMedia.MediaNetCharge.GetValueOrDefault(0)

            AdvantageFramework.AccountPayable.CalculateGrossAndCommission(Me.NetAmount, Me.DiscountAmount, Me.AccountPayableInternet.MarkupPercent, Me.GrossAmount, Me.AccountPayableInternet.CommissionAmount)

            ReCalculate(False)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableInternet As AdvantageFramework.Database.Entities.AccountPayableInternet,
                       LoadingActive As Boolean)

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval = Nothing
            Dim MediaApprovalStatus As Generic.KeyValuePair(Of Long, String) = Nothing
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing

            _AccountPayableInternet = AccountPayableInternet

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableInternet.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            _CurrencyRate = If(AccountPayable.CurrencyRate.HasValue AndAlso AccountPayable.CurrencyRate = 0, 1, AccountPayable.CurrencyRate.GetValueOrDefault(1))

            _AccountPayableInternet.DiscountAmount = If(LoadingActive, Math.Abs(_AccountPayableInternet.DiscountAmount.GetValueOrDefault(0)), _AccountPayableInternet.DiscountAmount.GetValueOrDefault(0))

            _InternetOrderNumber = AccountPayableInternet.InternetOrderNumber
            _InternetDetailLineNumber = AccountPayableInternet.InternetDetailLineNumber

            _GrossAmount = _AccountPayableInternet.NetAmount.GetValueOrDefault(0) + _AccountPayableInternet.CommissionAmount.GetValueOrDefault(0)

            _PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableInternet.LoadActiveByOrderNumberAndLineNumber(DbContext, AccountPayableInternet.InternetOrderNumber, AccountPayableInternet.InternetDetailLineNumber) _
                                .Where(Function(Entity) Entity.AccountPayableID <> AccountPayableInternet.AccountPayableID) _
                                .Sum(Function(Entity) Entity.NetAmount + Entity.DiscountAmount + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

            If AccountPayableInternet.GeneralLedgerAccount IsNot Nothing Then

                _GLADescription = AccountPayableInternet.GeneralLedgerAccount.Description

            End If

            InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, AccountPayableInternet.InternetOrderNumber)

            If InternetOrder IsNot Nothing Then

                _ClientCode = InternetOrder.ClientCode
                _DivisionCode = InternetOrder.DivisionCode
                _ProductCode = InternetOrder.ProductCode

                _StartDate = InternetOrder.StartDate
                _EndDate = InternetOrder.EndDate

                InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, AccountPayableInternet.InternetOrderNumber, AccountPayableInternet.InternetDetailLineNumber)

                If InternetOrderDetail IsNot Nothing Then

                    _OrderNetAmount = InternetOrderDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                      InternetOrderDetail.DiscountAmount.GetValueOrDefault(0) +
                                      InternetOrderDetail.NetCharge.GetValueOrDefault(0) +
                                      InternetOrderDetail.NonResalesAmount.GetValueOrDefault(0)

                    _CostType = InternetOrderDetail.CostType

                    If _CostType = "NA" Then

                        _AccountPayableInternet.Impressions = Nothing
                        _AccountPayableInternet.Rate = Nothing

                    End If

                End If

            End If

            _OrderNetBalance = _OrderNetAmount - (Me.DisbursedAmount + _PreviouslyPosted)

            Try

                AccountPayableMediaApproval = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.LoadByAccountPayableID(DbContext, AccountPayableInternet.AccountPayableID)
                                               Where Entity.OrderNumber = AccountPayableInternet.InternetOrderNumber AndAlso
                                                     Entity.LineNumber = AccountPayableInternet.InternetDetailLineNumber AndAlso
                                                     Entity.Source = "I" AndAlso
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
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail,
                       CurrencyRate As Decimal)

            _AccountPayableInternet = New AdvantageFramework.Database.Entities.AccountPayableInternet
            _CurrencyRate = CurrencyRate

            SetBaseValues(Me, InternetOrderDetail, DbContext)

        End Sub
        Public Overrides Function ToString() As String

            ToString = _AccountPayableInternet.AccountPayableID

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

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.DisbursedAmount.ToString

                        If Me.Impressions.GetValueOrDefault(0) = 0 AndAlso Me.NetAmount.GetValueOrDefault(0) = 0 AndAlso Me.NetCharges.GetValueOrDefault(0) = 0 AndAlso Me.VendorTax.GetValueOrDefault(0) = 0 Then

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.DisbursedAmount.ToString, True)

                        Else

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.DisbursedAmount.ToString, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.InternetOrderNumber.ToString

                    PropertyValue = Value

                    If IsNumeric(PropertyValue) AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Order is required and cannot be zero."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.InternetDetailLineNumber.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Line is required and cannot be zero."

                    End If

                    'Case AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail.Properties.DisbursedAmount.ToString

                    '    PropertyValue = Value

                    '    If (PropertyValue Is Nothing OrElse PropertyValue = 0) AndAlso Me.Impressions.GetValueOrDefault(0) = 0 AndAlso Me.NetAmount.GetValueOrDefault(0) = 0 AndAlso _
                    '            Me.NetCharges.GetValueOrDefault(0) = 0 AndAlso Me.VendorTax.GetValueOrDefault(0) = 0 Then

                    '        IsValid = False

                    '        ErrorText = "Invalid disbursement.  All data cannot be zero."

                    '    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

