Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableMagazineDistributionDetail
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
            InsertionDate
            ForeignGrossAmount
            GrossAmount
            ForeignNetAmount
            NetAmount
            ForeignBleedGrossAmount
            BleedGrossAmount
            ForeignBleedNetAmount
            BleedNetAmount
            ForeignPositionGrossAmount
            PositionGrossAmount
            ForeignPositionNetAmount
            PositionNetAmount
            ForeignPremiumGrossAmount
            PremiumGrossAmount
            ForeignPremiumNetAmount
            PremiumNetAmount
            ForeignColorGrossAmount
            ColorGrossAmount
            ForeignColorNetAmount
            ColorNetAmount
            ForeignDiscountLineNet
            DiscountLN
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

        Private _AccountPayableMagazine As AdvantageFramework.Database.Entities.AccountPayableMagazine = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _IsDeleted As Boolean = False
        Private _Status As String = Nothing
        Private _Comments As String = Nothing
        Private _GLACodeDescription As String = Nothing
        Private _OrderNetAmount As Decimal = Nothing
        Private _NewApprovalStatus As Nullable(Of Short) = Nothing
        Private _NewApprovalComments As String = Nothing
        Private _PlanEstID As String = Nothing
        Private _InsertionDate As Nullable(Of Date) = Nothing
        Private _OrderNetBalance As Decimal = Nothing
        Private _PreviouslyPosted As Decimal = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderLineNumber As Nullable(Of Short) = Nothing
        Private _ForeignGrossAmount As Decimal = Nothing
        Private _ForeignNetAmount As Decimal = Nothing
        Private _ForeignBleedGrossAmount As Decimal = Nothing
        Private _ForeignBleedNetAmount As Decimal = Nothing
        Private _ForeignPositionGrossAmount As Decimal = Nothing
        Private _ForeignPositionNetAmount As Decimal = Nothing
        Private _ForeignPremiumGrossAmount As Decimal = Nothing
        Private _ForeignPremiumNetAmount As Decimal = Nothing
        Private _ForeignColorGrossAmount As Decimal = Nothing
        Private _ForeignColorNetAmount As Decimal = Nothing
        Private _ForeignDiscountLineNet As Decimal = Nothing
        Private _ForeignNetCharges As Decimal = Nothing
        Private _ForeignVendorTax As Decimal = Nothing
        Private _ForeignDisbursedAmount As Decimal = Nothing
        Private _CurrencyRate As Decimal = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.AccountPayableMagazine)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableMagazine As AdvantageFramework.Database.Entities.AccountPayableMagazine
            Get
                AccountPayableMagazine = _AccountPayableMagazine
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
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Line")>
        Public Property OrderLineNumber() As Nullable(Of Short)
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OrderLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InsertionDate() As Nullable(Of Date)
            Get
                InsertionDate = _InsertionDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InsertionDate = value
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
                GrossAmount = _AccountPayableMagazine.GrossAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.GrossAmount = value
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
                NetAmount = _AccountPayableMagazine.NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.NetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignBleedGrossAmount() As Decimal
            Get
                ForeignBleedGrossAmount = _ForeignBleedGrossAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignBleedGrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Gross Bleed")>
        Public Property BleedGrossAmount() As Nullable(Of Decimal)
            Get
                BleedGrossAmount = _AccountPayableMagazine.BleedGrossAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.BleedGrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignBleedNetAmount() As Decimal
            Get
                ForeignBleedNetAmount = _ForeignBleedNetAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignBleedNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Net Bleed")>
        Public Property BleedNetAmount() As Nullable(Of Decimal)
            Get
                BleedNetAmount = _AccountPayableMagazine.BleedNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.BleedNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignPositionGrossAmount() As Decimal
            Get
                ForeignPositionGrossAmount = _ForeignPositionGrossAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignPositionGrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Gross Position")>
        Public Property PositionGrossAmount() As Nullable(Of Decimal)
            Get
                PositionGrossAmount = _AccountPayableMagazine.PositionGrossAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.PositionGrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignPositionNetAmount() As Decimal
            Get
                ForeignPositionNetAmount = _ForeignPositionNetAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignPositionNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Net Position")>
        Public Property PositionNetAmount() As Nullable(Of Decimal)
            Get
                PositionNetAmount = _AccountPayableMagazine.PositionNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.PositionNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignPremiumGrossAmount() As Decimal
            Get
                ForeignPremiumGrossAmount = _ForeignPremiumGrossAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignPremiumGrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Gross Premium")>
        Public Property PremiumGrossAmount() As Nullable(Of Decimal)
            Get
                PremiumGrossAmount = _AccountPayableMagazine.PremiumGrossAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.PremiumGrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignPremiumNetAmount() As Decimal
            Get
                ForeignPremiumNetAmount = _ForeignPremiumNetAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignPremiumNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Net Premium")>
        Public Property PremiumNetAmount() As Nullable(Of Decimal)
            Get
                PremiumNetAmount = _AccountPayableMagazine.PremiumNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.PremiumNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignColorGrossAmount() As Decimal
            Get
                ForeignColorGrossAmount = _ForeignColorGrossAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignColorGrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Gross Color")>
        Public Property ColorGrossAmount() As Nullable(Of Decimal)
            Get
                ColorGrossAmount = _AccountPayableMagazine.ColorGrossAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.ColorGrossAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignColorNetAmount() As Decimal
            Get
                ForeignColorNetAmount = _ForeignColorNetAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignColorNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Net Color")>
        Public Property ColorNetAmount() As Nullable(Of Decimal)
            Get
                ColorNetAmount = _AccountPayableMagazine.ColorNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.ColorNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignDiscountLineNet() As Decimal
            Get
                ForeignDiscountLineNet = _ForeignDiscountLineNet
            End Get
            Set(ByVal value As Decimal)
                _ForeignDiscountLineNet = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Discount Line Net")>
        Public Property DiscountLN() As Nullable(Of Decimal)
            Get
                DiscountLN = _AccountPayableMagazine.DiscountLN
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.DiscountLN = value
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
                NetCharges = _AccountPayableMagazine.NetCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.NetCharges = value
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
                VendorTax = _AccountPayableMagazine.VendorTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.VendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property ForeignDisbursedAmount() As Decimal
            Get
                ForeignDisbursedAmount = Me.ForeignNetAmount + Me.ForeignBleedNetAmount + Me.ForeignPositionNetAmount + Me.ForeignPremiumNetAmount +
                                            Me.ForeignColorNetAmount - Me.ForeignDiscountLineNet + Me.ForeignNetCharges + Me.ForeignVendorTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DisbursedAmount() As Nullable(Of Decimal)
            Get
                DisbursedAmount = _AccountPayableMagazine.DisbursedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableMagazine.DisbursedAmount = value
            End Set
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
                SalesTaxCode = _AccountPayableMagazine.SalesTaxCode
            End Get
            Set(ByVal value As String)
                _AccountPayableMagazine.SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountPayableMagazine.OfficeCode
            End Get
            Set(ByVal value As String)
                _AccountPayableMagazine.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _AccountPayableMagazine.GLACode
            End Get
            Set(ByVal value As String)
                _AccountPayableMagazine.GLACode = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property GLACodeDescription() As String
            Get
                GLACodeDescription = _GLACodeDescription
            End Get
            Set(ByVal value As String)
                _GLACodeDescription = value
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

            Me.AccountPayableMagazine.NetPlus = Me.NetAmount.GetValueOrDefault(0) + Me.BleedNetAmount.GetValueOrDefault(0) + Me.PositionNetAmount.GetValueOrDefault(0) +
                                                                                      Me.PremiumNetAmount.GetValueOrDefault(0) + Me.ColorNetAmount.GetValueOrDefault(0)

            Me.AccountPayableMagazine.GrossPlus = Me.GrossAmount.GetValueOrDefault(0) + Me.BleedGrossAmount.GetValueOrDefault(0) + Me.PositionGrossAmount.GetValueOrDefault(0) +
                                                                                        Me.PremiumGrossAmount.GetValueOrDefault(0) + Me.ColorGrossAmount.GetValueOrDefault(0)

            If Me.AccountPayableMagazine.NetGross.GetValueOrDefault(0) = 1 Then

                Me.AccountPayableMagazine.CommissionAmount = FormatNumber(Me.AccountPayableMagazine.GrossPlus.GetValueOrDefault(0) * Me.AccountPayableMagazine.CommissionPercent.GetValueOrDefault(0) / 100, 2)

            Else

                Me.AccountPayableMagazine.CommissionAmount = FormatNumber(Me.AccountPayableMagazine.NetPlus.GetValueOrDefault(0) * Me.AccountPayableMagazine.MarkupPercent.GetValueOrDefault(0) / 100, 2)

            End If

            Me.AccountPayableMagazine.RebateAmount = FormatNumber(-1 * Me.AccountPayableMagazine.GrossPlus.GetValueOrDefault(0) * Me.AccountPayableMagazine.RebatePercent.GetValueOrDefault(0) / 100, 2)

            If ReCalculateTax Then

                CalculateTax(Me)

            End If

            Me.ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignNetAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignBleedGrossAmount = FormatNumber(Me.BleedGrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignBleedNetAmount = FormatNumber(Me.BleedNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignPositionGrossAmount = FormatNumber(Me.PositionGrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignPositionNetAmount = FormatNumber(Me.PositionNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignPremiumGrossAmount = FormatNumber(Me.PremiumGrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignPremiumNetAmount = FormatNumber(Me.PremiumNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignColorGrossAmount = FormatNumber(Me.ColorGrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignColorNetAmount = FormatNumber(Me.ColorNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignDiscountLineNet = FormatNumber(Me.DiscountLN.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

            Me.DisbursedAmount = FormatNumber(Me.AccountPayableMagazine.NetPlus.GetValueOrDefault(0) -
                                                Me.DiscountLN.GetValueOrDefault(0) +
                                                Me.NetCharges.GetValueOrDefault(0) +
                                                Me.VendorTax.GetValueOrDefault(0), 2)

            Me.AccountPayableMagazine.LineTotal = FormatNumber(Me.DisbursedAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableMagazine.RebateAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableMagazine.CommissionAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableMagazine.StateTax.GetValueOrDefault(0) +
                                                                Me.AccountPayableMagazine.CountyTax.GetValueOrDefault(0) +
                                                                Me.AccountPayableMagazine.CityTax.GetValueOrDefault(0), 2)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

        End Sub
        Private Shared Sub CalculateTax(ByRef AccountPayableMagazineDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail)

            Dim TotalTax As Decimal = Nothing
            Dim TaxableAmount As Decimal = 0

            TotalTax = AccountPayableMagazineDistributionDetail.AccountPayableMagazine.StateTaxPercent.GetValueOrDefault(0) +
                       AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CityTaxPercent.GetValueOrDefault(0) +
                       AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CountyTaxPercent.GetValueOrDefault(0)

            If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.IsResaleTax.GetValueOrDefault(0) = 1 Then

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableMagazineDistributionDetail.AccountPayableMagazine.NetPlus.GetValueOrDefault(0)

                End If

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableMagazineDistributionDetail.AccountPayableMagazine.DiscountLN.GetValueOrDefault(0)

                End If

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableMagazineDistributionDetail.AccountPayableMagazine.NetCharges.GetValueOrDefault(0)

                End If

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableMagazineDistributionDetail.AccountPayableMagazine.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableMagazineDistributionDetail.AccountPayableMagazine.StateTax = FormatNumber(AccountPayableMagazineDistributionDetail.AccountPayableMagazine.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CountyTax = FormatNumber(AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CityTax = FormatNumber(AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

                AccountPayableMagazineDistributionDetail.VendorTax = 0

            Else

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableMagazineDistributionDetail.AccountPayableMagazine.NetPlus.GetValueOrDefault(0)

                End If

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableMagazineDistributionDetail.AccountPayableMagazine.DiscountLN.GetValueOrDefault(0)

                End If

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableMagazineDistributionDetail.AccountPayableMagazine.NetCharges.GetValueOrDefault(0)

                End If

                AccountPayableMagazineDistributionDetail.AccountPayableMagazine.VendorTax = FormatNumber(TaxableAmount * TotalTax / 100, 2)

                TaxableAmount = 0

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableMagazineDistributionDetail.AccountPayableMagazine.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableMagazineDistributionDetail.AccountPayableMagazine.StateTax = FormatNumber(AccountPayableMagazineDistributionDetail.AccountPayableMagazine.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CountyTax = FormatNumber(AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CityTax = FormatNumber(AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

            End If

        End Sub
        Private Sub SetForeignCurrencyAmounts()

            _ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignNetAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignBleedGrossAmount = FormatNumber(Me.BleedGrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignBleedNetAmount = FormatNumber(Me.BleedNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignPositionGrossAmount = FormatNumber(Me.PositionGrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignPositionNetAmount = FormatNumber(Me.PositionNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignPremiumGrossAmount = FormatNumber(Me.PremiumGrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignPremiumNetAmount = FormatNumber(Me.PremiumNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignColorGrossAmount = FormatNumber(Me.ColorGrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignColorNetAmount = FormatNumber(Me.ColorNetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignDiscountLineNet = FormatNumber(Me.DiscountLN.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

        End Sub
        Public Shared Sub SetBaseValues(ByRef AccountPayableMagazineDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail,
                                        ByVal MagazineDetail As AdvantageFramework.Database.Views.MagazineDetail,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        CurrencyRate As Decimal)

            Dim Magazine As AdvantageFramework.Database.Views.Magazine = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim AccountPayableMagazineList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableMagazine) = Nothing
            Dim SumOfNetAmount As Decimal = 0
            Dim SumOfGrossAmount As Decimal = 0
            Dim SumOfDiscount As Decimal = 0
            Dim SumOfNetCharges As Decimal = 0
            Dim SumOfColor As Decimal = 0
            Dim SumOfBleed As Decimal = 0
            Dim SumOfPosition As Decimal = 0
            Dim SumOfPremium As Decimal = 0
            Dim SumOfCommission As Decimal = 0

            AccountPayableMagazineDistributionDetail.CurrencyRate = CurrencyRate

            AccountPayableMagazineList = AdvantageFramework.Database.Procedures.AccountPayableMagazine.LoadActiveByOrderNumberAndLineNumber(DbContext, MagazineDetail.OrderNumber, MagazineDetail.LineNumber).ToList

            AccountPayableMagazineDistributionDetail.OrderNumber = MagazineDetail.OrderNumber
            AccountPayableMagazineDistributionDetail.OrderLineNumber = MagazineDetail.LineNumber

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.RevisionNumber = MagazineDetail.RevisionNumber
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.SequenceNumber = MagazineDetail.SequenceNumber

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.SalesTaxCode = If(String.IsNullOrWhiteSpace(MagazineDetail.SalesTaxCode), Nothing, MagazineDetail.SalesTaxCode)
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CityTaxPercent = MagazineDetail.CityTaxPercent
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CountyTaxPercent = MagazineDetail.CountyTaxPercent
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.StateTaxPercent = MagazineDetail.StateTaxPercent

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyC = MagazineDetail.TaxApplyC
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyLN = MagazineDetail.TaxApplyLN
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyLND = MagazineDetail.TaxApplyLND
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyNC = MagazineDetail.TaxApplyNC
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyNCD = MagazineDetail.TaxApplyNCD
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.TaxApplyR = MagazineDetail.TaxApplyR
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.IsResaleTax = MagazineDetail.HasResaleTax

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CityTax = MagazineDetail.CityTax
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CountyTax = MagazineDetail.CountyTax
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.StateTax = MagazineDetail.StateTax
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.VendorTax = MagazineDetail.VendorTax

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CommissionPercent = MagazineDetail.CommissionPercent
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CommissionAmount = MagazineDetail.CommissionAmount
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.MarkupPercent = MagazineDetail.MarkupPercent
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.RebatePercent = MagazineDetail.RebatePercent
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.RebateAmount = MagazineDetail.RebateAmount

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.LineTotal = MagazineDetail.LineTotal
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.NetPlus = MagazineDetail.ExtendedNetAmount
            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.GrossPlus = MagazineDetail.ExtendedGrossAmount

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.NetGross = MagazineDetail.NetGross.GetValueOrDefault(0)
            AccountPayableMagazineDistributionDetail.InsertionDate = MagazineDetail.InsertDate

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.DiscountNC = 0

            Magazine = AdvantageFramework.Database.Procedures.MagazineView.LoadByOrderNumber(DbContext, MagazineDetail.OrderNumber)

            If Magazine IsNot Nothing Then

                AccountPayableMagazineDistributionDetail.ClientCode = Magazine.ClientCode
                AccountPayableMagazineDistributionDetail.DivisionCode = Magazine.DivisionCode
                AccountPayableMagazineDistributionDetail.ProductCode = Magazine.ProductCode
                AccountPayableMagazineDistributionDetail.OfficeCode = Magazine.OfficeCode

                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Magazine.OfficeCode)

                If Office IsNot Nothing Then

                    AccountPayableMagazineDistributionDetail.GLACode = Office.MediaWorkInProgressGLACode

                End If

            End If

            AccountPayableMagazineDistributionDetail.OrderNetAmount = MagazineDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                                                      MagazineDetail.DiscountAmount.GetValueOrDefault(0) +
                                                                      MagazineDetail.NetCharge.GetValueOrDefault(0) +
                                                                      MagazineDetail.VendorTax.GetValueOrDefault(0)

            AccountPayableMagazineDistributionDetail.PreviouslyPosted = AccountPayableMagazineList.Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0)) +
                                                                        AccountPayableMagazineList.Sum(Function(Entity) Entity.BleedNetAmount.GetValueOrDefault(0)) +
                                                                        AccountPayableMagazineList.Sum(Function(Entity) Entity.PositionNetAmount.GetValueOrDefault(0)) +
                                                                        AccountPayableMagazineList.Sum(Function(Entity) Entity.PremiumNetAmount.GetValueOrDefault(0)) +
                                                                        AccountPayableMagazineList.Sum(Function(Entity) Entity.ColorNetAmount.GetValueOrDefault(0)) +
                                                                        AccountPayableMagazineList.Sum(Function(Entity) Entity.DiscountLN.GetValueOrDefault(0)) +
                                                                        AccountPayableMagazineList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0)) +
                                                                        AccountPayableMagazineList.Sum(Function(Entity) Entity.VendorTax.GetValueOrDefault(0))

            SumOfNetAmount = AccountPayableMagazineList.Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0))
            SumOfGrossAmount = AccountPayableMagazineList.Sum(Function(Entity) Entity.GrossAmount.GetValueOrDefault(0))
            SumOfDiscount = AccountPayableMagazineList.Sum(Function(Entity) Math.Abs(Entity.DiscountLN.GetValueOrDefault(0)))
            SumOfNetCharges = AccountPayableMagazineList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0))
            SumOfCommission = AccountPayableMagazineList.Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0))

            If SumOfCommission > AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CommissionAmount.GetValueOrDefault(0) Then

                AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CommissionAmount = 0

            Else

                AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CommissionAmount = FormatNumber(MagazineDetail.CommissionAmount.GetValueOrDefault(0) - SumOfCommission, 2)

            End If

            If SumOfNetAmount > MagazineDetail.FlatNet.GetValueOrDefault(0) Then

                AccountPayableMagazineDistributionDetail.NetAmount = 0

            Else

                AccountPayableMagazineDistributionDetail.NetAmount = Format(MagazineDetail.FlatNet.GetValueOrDefault(0) - SumOfNetAmount, "#0.00")

            End If

            If SumOfGrossAmount > MagazineDetail.FlatGross.GetValueOrDefault(0) Then

                AccountPayableMagazineDistributionDetail.GrossAmount = 0

            Else

                AccountPayableMagazineDistributionDetail.GrossAmount = Format(MagazineDetail.FlatGross.GetValueOrDefault(0) - SumOfGrossAmount, "#0.00")

            End If

            If SumOfDiscount > Math.Abs(MagazineDetail.DiscountAmount.GetValueOrDefault(0)) Then

                AccountPayableMagazineDistributionDetail.DiscountLN = 0

            Else

                AccountPayableMagazineDistributionDetail.DiscountLN = Math.Abs(MagazineDetail.DiscountAmount.GetValueOrDefault(0)) - SumOfDiscount

            End If

            If SumOfNetCharges > MagazineDetail.NetCharge.GetValueOrDefault(0) Then

                AccountPayableMagazineDistributionDetail.NetCharges = 0

            Else

                AccountPayableMagazineDistributionDetail.NetCharges = MagazineDetail.NetCharge.GetValueOrDefault(0) - SumOfNetCharges

            End If

            If MagazineDetail.NetGross = 1 Then

                SumOfColor = AccountPayableMagazineList.Sum(Function(Entity) Entity.ColorGrossAmount)
                SumOfBleed = AccountPayableMagazineList.Sum(Function(Entity) Entity.BleedGrossAmount)
                SumOfPosition = AccountPayableMagazineList.Sum(Function(Entity) Entity.PositionGrossAmount)
                SumOfPremium = AccountPayableMagazineList.Sum(Function(Entity) Entity.PremiumGrossAmount)

                If SumOfColor > MagazineDetail.ColorAmount.GetValueOrDefault(0) Then

                    AccountPayableMagazineDistributionDetail.ColorGrossAmount = 0

                Else

                    AccountPayableMagazineDistributionDetail.ColorGrossAmount = MagazineDetail.ColorAmount.GetValueOrDefault(0) - SumOfColor

                End If

                AccountPayableMagazineDistributionDetail.ColorNetAmount = AdvantageFramework.AccountPayable.GrossToNet(AccountPayableMagazineDistributionDetail.ColorGrossAmount, MagazineDetail.CommissionPercent.GetValueOrDefault(0))

                If SumOfBleed > MagazineDetail.BleedAmount.GetValueOrDefault(0) Then

                    AccountPayableMagazineDistributionDetail.BleedGrossAmount = 0

                Else

                    AccountPayableMagazineDistributionDetail.BleedGrossAmount = MagazineDetail.BleedAmount.GetValueOrDefault(0) - SumOfBleed

                End If

                AccountPayableMagazineDistributionDetail.BleedNetAmount = AdvantageFramework.AccountPayable.GrossToNet(AccountPayableMagazineDistributionDetail.BleedGrossAmount, MagazineDetail.CommissionPercent.GetValueOrDefault(0))

                If SumOfPosition > MagazineDetail.PositionAmount.GetValueOrDefault(0) Then

                    AccountPayableMagazineDistributionDetail.PositionGrossAmount = 0

                Else

                    AccountPayableMagazineDistributionDetail.PositionGrossAmount = MagazineDetail.PositionAmount.GetValueOrDefault(0) - SumOfPosition

                End If

                AccountPayableMagazineDistributionDetail.PositionNetAmount = AdvantageFramework.AccountPayable.GrossToNet(AccountPayableMagazineDistributionDetail.PositionGrossAmount, MagazineDetail.CommissionPercent.GetValueOrDefault(0))

                If SumOfPremium > MagazineDetail.PremiumAmount.GetValueOrDefault(0) Then

                    AccountPayableMagazineDistributionDetail.PremiumGrossAmount = 0

                Else

                    AccountPayableMagazineDistributionDetail.PremiumGrossAmount = MagazineDetail.PremiumAmount.GetValueOrDefault(0) - SumOfPremium

                End If

                AccountPayableMagazineDistributionDetail.PremiumNetAmount = AdvantageFramework.AccountPayable.GrossToNet(AccountPayableMagazineDistributionDetail.PremiumGrossAmount, MagazineDetail.CommissionPercent.GetValueOrDefault(0))

            Else

                SumOfColor = AccountPayableMagazineList.Sum(Function(Entity) Entity.ColorNetAmount)
                SumOfBleed = AccountPayableMagazineList.Sum(Function(Entity) Entity.BleedNetAmount)
                SumOfPosition = AccountPayableMagazineList.Sum(Function(Entity) Entity.PositionNetAmount)
                SumOfPremium = AccountPayableMagazineList.Sum(Function(Entity) Entity.PremiumNetAmount)

                If SumOfColor > MagazineDetail.ColorAmount.GetValueOrDefault(0) Then

                    AccountPayableMagazineDistributionDetail.ColorNetAmount = 0

                Else

                    AccountPayableMagazineDistributionDetail.ColorNetAmount = MagazineDetail.ColorAmount.GetValueOrDefault(0) - SumOfColor

                End If

                AccountPayableMagazineDistributionDetail.ColorGrossAmount = AdvantageFramework.AccountPayable.NetToGross(AccountPayableMagazineDistributionDetail.ColorNetAmount, MagazineDetail.CommissionPercent.GetValueOrDefault(0))

                If SumOfBleed > MagazineDetail.BleedAmount.GetValueOrDefault(0) Then

                    AccountPayableMagazineDistributionDetail.BleedNetAmount = 0

                Else

                    AccountPayableMagazineDistributionDetail.BleedNetAmount = MagazineDetail.BleedAmount.GetValueOrDefault(0) - SumOfBleed

                End If

                AccountPayableMagazineDistributionDetail.BleedGrossAmount = AdvantageFramework.AccountPayable.NetToGross(AccountPayableMagazineDistributionDetail.BleedNetAmount, MagazineDetail.CommissionPercent.GetValueOrDefault(0))

                If SumOfPosition > MagazineDetail.PositionAmount.GetValueOrDefault(0) Then

                    AccountPayableMagazineDistributionDetail.PositionNetAmount = 0

                Else

                    AccountPayableMagazineDistributionDetail.PositionNetAmount = MagazineDetail.PositionAmount.GetValueOrDefault(0) - SumOfPosition

                End If

                AccountPayableMagazineDistributionDetail.PositionGrossAmount = AdvantageFramework.AccountPayable.NetToGross(AccountPayableMagazineDistributionDetail.PositionNetAmount, MagazineDetail.CommissionPercent.GetValueOrDefault(0))

                If SumOfPremium > MagazineDetail.PremiumAmount.GetValueOrDefault(0) Then

                    AccountPayableMagazineDistributionDetail.PremiumNetAmount = 0

                Else

                    AccountPayableMagazineDistributionDetail.PremiumNetAmount = MagazineDetail.PremiumAmount.GetValueOrDefault(0) - SumOfPremium

                End If

                AccountPayableMagazineDistributionDetail.PremiumGrossAmount = AdvantageFramework.AccountPayable.NetToGross(AccountPayableMagazineDistributionDetail.PremiumNetAmount, MagazineDetail.CommissionPercent.GetValueOrDefault(0))

            End If

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.NetPlus = AccountPayableMagazineDistributionDetail.NetAmount.GetValueOrDefault(0) +
                                                                                      AccountPayableMagazineDistributionDetail.BleedNetAmount.GetValueOrDefault(0) +
                                                                                      AccountPayableMagazineDistributionDetail.PositionNetAmount.GetValueOrDefault(0) +
                                                                                      AccountPayableMagazineDistributionDetail.PremiumNetAmount.GetValueOrDefault(0) +
                                                                                      AccountPayableMagazineDistributionDetail.ColorNetAmount.GetValueOrDefault(0)

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.GrossPlus = AccountPayableMagazineDistributionDetail.GrossAmount.GetValueOrDefault(0) +
                                                                                        AccountPayableMagazineDistributionDetail.BleedGrossAmount.GetValueOrDefault(0) +
                                                                                        AccountPayableMagazineDistributionDetail.PositionGrossAmount.GetValueOrDefault(0) +
                                                                                        AccountPayableMagazineDistributionDetail.PremiumGrossAmount.GetValueOrDefault(0) +
                                                                                        AccountPayableMagazineDistributionDetail.ColorGrossAmount.GetValueOrDefault(0)

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.RebateAmount = FormatNumber(-1 * AccountPayableMagazineDistributionDetail.AccountPayableMagazine.GrossPlus.GetValueOrDefault(0) *
                                                                                                       AccountPayableMagazineDistributionDetail.AccountPayableMagazine.RebatePercent.GetValueOrDefault(0) / 100, 2)

            CalculateTax(AccountPayableMagazineDistributionDetail)

            AccountPayableMagazineDistributionDetail.DisbursedAmount = FormatNumber(AccountPayableMagazineDistributionDetail.AccountPayableMagazine.NetPlus.GetValueOrDefault(0) -
                                                                              AccountPayableMagazineDistributionDetail.DiscountLN.GetValueOrDefault(0) +
                                                                              AccountPayableMagazineDistributionDetail.NetCharges.GetValueOrDefault(0) +
                                                                              AccountPayableMagazineDistributionDetail.VendorTax.GetValueOrDefault(0), 2)

            AccountPayableMagazineDistributionDetail.AccountPayableMagazine.LineTotal = FormatNumber(AccountPayableMagazineDistributionDetail.DisbursedAmount.GetValueOrDefault(0) +
                                                                                               AccountPayableMagazineDistributionDetail.AccountPayableMagazine.RebateAmount.GetValueOrDefault(0) +
                                                                                               AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CommissionAmount.GetValueOrDefault(0) +
                                                                                               AccountPayableMagazineDistributionDetail.AccountPayableMagazine.StateTax.GetValueOrDefault(0) +
                                                                                               AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CountyTax.GetValueOrDefault(0) +
                                                                                               AccountPayableMagazineDistributionDetail.AccountPayableMagazine.CityTax.GetValueOrDefault(0), 2)

            AccountPayableMagazineDistributionDetail.OrderNetBalance = AccountPayableMagazineDistributionDetail.OrderNetAmount - (AccountPayableMagazineDistributionDetail.DisbursedAmount + AccountPayableMagazineDistributionDetail.PreviouslyPosted)

            AccountPayableMagazineDistributionDetail.SetForeignCurrencyAmounts()

        End Sub
        Public Sub New()

            _AccountPayableMagazine = New AdvantageFramework.Database.Entities.AccountPayableMagazine

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

            Dim MagazineDetail As AdvantageFramework.Database.Views.MagazineDetail = Nothing

            _AccountPayableMagazine = New AdvantageFramework.Database.Entities.AccountPayableMagazine

            MagazineDetail = AdvantageFramework.Database.Procedures.MagazineDetailView.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayableMedia.OrderNumber, ImportAccountPayableMedia.OrderLineNumber)

            If MagazineDetail IsNot Nothing Then

                SetBaseValues(Me, MagazineDetail, DbContext, 1)

                Me.DiscountLN = 0 'should not bring this in, there is not a place in import file for discount, to bring it in will cause OOB

            End If

            Me.NetAmount = ImportAccountPayableMedia.MediaNetAmount.GetValueOrDefault(0)
            Me.VendorTax = ImportAccountPayableMedia.MediaVendorTax.GetValueOrDefault(0)
            Me.NetCharges = ImportAccountPayableMedia.MediaNetCharge.GetValueOrDefault(0)

            AdvantageFramework.AccountPayable.CalculateGrossAndCommission(Me.NetAmount, Me.DiscountLN, Me.AccountPayableMagazine.MarkupPercent, Me.GrossAmount, Me.AccountPayableMagazine.CommissionAmount)

            ReCalculate(False)

            Me.DisbursedAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) -
                                              Me.DiscountLN.GetValueOrDefault(0) +
                                              Me.NetCharges.GetValueOrDefault(0) +
                                              Me.VendorTax.GetValueOrDefault(0), 2)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableMagazine As AdvantageFramework.Database.Entities.AccountPayableMagazine,
                       LoadingActive As Boolean)

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim Magazine As AdvantageFramework.Database.Views.Magazine = Nothing
            Dim AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval = Nothing
            Dim MediaApprovalStatus As Generic.KeyValuePair(Of Long, String) = Nothing
            Dim MagazineDetail As AdvantageFramework.Database.Views.MagazineDetail = Nothing

            _AccountPayableMagazine = AccountPayableMagazine

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableMagazine.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            _CurrencyRate = If(AccountPayable.CurrencyRate.HasValue AndAlso AccountPayable.CurrencyRate = 0, 1, AccountPayable.CurrencyRate.GetValueOrDefault(1))

            _AccountPayableMagazine.DiscountLN = If(LoadingActive, Math.Abs(_AccountPayableMagazine.DiscountLN.GetValueOrDefault(0)), _AccountPayableMagazine.DiscountLN.GetValueOrDefault(0))

            _PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableMagazine.LoadActiveByOrderNumberAndLineNumber(DbContext, AccountPayableMagazine.OrderNumber, AccountPayableMagazine.OrderLineNumber) _
                .Where(Function(Entity) Entity.AccountPayableID <> AccountPayableMagazine.AccountPayableID) _
                .Sum(Function(Entity) Entity.NetAmount + Entity.BleedNetAmount + Entity.PositionNetAmount + Entity.PremiumNetAmount + Entity.ColorNetAmount + Entity.DiscountLN + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

            If AccountPayableMagazine.GeneralLedgerAccount IsNot Nothing Then

                _GLACodeDescription = AccountPayableMagazine.GeneralLedgerAccount.Description

            End If

            _OrderNumber = AccountPayableMagazine.OrderNumber
            _OrderLineNumber = AccountPayableMagazine.OrderLineNumber

            Magazine = AdvantageFramework.Database.Procedures.MagazineView.LoadByOrderNumber(DbContext, AccountPayableMagazine.OrderNumber)

            If Magazine IsNot Nothing Then

                _ClientCode = Magazine.ClientCode
                _DivisionCode = Magazine.DivisionCode
                _ProductCode = Magazine.ProductCode

                MagazineDetail = AdvantageFramework.Database.Procedures.MagazineDetailView.LoadActiveByOrderNumberLineNumber(DbContext, AccountPayableMagazine.OrderNumber, AccountPayableMagazine.OrderLineNumber)

                If MagazineDetail IsNot Nothing Then

                    _InsertionDate = MagazineDetail.InsertDate

                    _OrderNetAmount = MagazineDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                      MagazineDetail.DiscountAmount.GetValueOrDefault(0) +
                                      MagazineDetail.NetCharge.GetValueOrDefault(0) +
                                      MagazineDetail.VendorTax.GetValueOrDefault(0)

                End If

            End If

            _OrderNetBalance = _OrderNetAmount - (AccountPayableMagazine.DisbursedAmount.GetValueOrDefault(0) + _PreviouslyPosted)

            Try

                AccountPayableMediaApproval = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.LoadByAccountPayableID(DbContext, AccountPayableMagazine.AccountPayableID)
                                               Where Entity.OrderNumber = AccountPayableMagazine.OrderNumber AndAlso
                                                     Entity.LineNumber = AccountPayableMagazine.OrderLineNumber AndAlso
                                                     Entity.Source = "M" AndAlso
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
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MagazineDetail As AdvantageFramework.Database.Views.MagazineDetail,
					   CurrencyRate as Decimal)

            _AccountPayableMagazine = New AdvantageFramework.Database.Entities.AccountPayableMagazine

            SetBaseValues(Me, MagazineDetail, DbContext, CurrencyRate)

        End Sub
        Public Overrides Function ToString() As String

            ToString = _AccountPayableMagazine.AccountPayableID

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

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.DisbursedAmount.ToString

                        If Me.NetAmount.GetValueOrDefault(0) = 0 AndAlso Me.BleedNetAmount.GetValueOrDefault(0) = 0 AndAlso Me.PositionNetAmount.GetValueOrDefault(0) = 0 AndAlso _
                                Me.PremiumNetAmount.GetValueOrDefault(0) = 0 AndAlso Me.ColorNetAmount.GetValueOrDefault(0) = 0 AndAlso Me.NetCharges.GetValueOrDefault(0) = 0 AndAlso _
                                Me.VendorTax.GetValueOrDefault(0) = 0 Then

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.DisbursedAmount.ToString, True)

                        Else

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.DisbursedAmount.ToString, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.OrderNumber.ToString

                    PropertyValue = Value

                    If IsNumeric(PropertyValue) AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Order is required and cannot be zero."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.OrderLineNumber.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Line is required and cannot be zero."

                    End If

                    'Case AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail.Properties.DisbursedAmount.ToString

                    '    PropertyValue = Value

                    '    If PropertyValue Is Nothing OrElse PropertyValue = 0 AndAlso Me.NetAmount.GetValueOrDefault(0) = 0 AndAlso Me.BleedNetAmount.GetValueOrDefault(0) = 0 AndAlso _
                    '            Me.PositionNetAmount.GetValueOrDefault(0) = 0 AndAlso Me.PremiumNetAmount.GetValueOrDefault(0) = 0 AndAlso Me.ColorNetAmount.GetValueOrDefault(0) = 0 AndAlso _
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

