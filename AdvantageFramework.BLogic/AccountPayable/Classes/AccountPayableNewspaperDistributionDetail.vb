Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableNewspaperDistributionDetail
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
            CostType
            PrintLines
            ForeignRate
            Rate
            ForeignGrossAmount
            GrossAmount
            ForeignNetAmount
            NetAmount
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
            CostTypeFromOrderDetail
            CurrencyRate
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableNewspaper As AdvantageFramework.Database.Entities.AccountPayableNewspaper = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _IsDeleted As Boolean = False
        Private _Status As String = Nothing
        Private _Comments As String = Nothing
        Private _OrderNetAmount As Decimal = Nothing
        Private _NewApprovalStatus As Nullable(Of Short) = Nothing
        Private _NewApprovalComments As String = Nothing
        Private _GLADescription As String = Nothing
        Private _CostType As String = Nothing
        Private _PlanEstID As String = Nothing
        Private _InsertionDate As Nullable(Of Date) = Nothing
        Private _OrderNetBalance As Decimal = Nothing
        Private _PreviouslyPosted As Decimal = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderLineNumber As Nullable(Of Short) = Nothing
        Private _UseCPM As Boolean = False
        Private _CostTypeFromOrderDetail As String = Nothing
        Private _ForeignRate As Nullable(Of Decimal) = Nothing
        Private _ForeignGrossAmount As Decimal = Nothing
        Private _ForeignNetAmount As Decimal = Nothing
        Private _ForeignDiscountLineNet As Decimal = Nothing
        Private _ForeignNetCharges As Decimal = Nothing
        Private _ForeignVendorTax As Decimal = Nothing
        Private _ForeignDisbursedAmount As Decimal = Nothing
        Private _CurrencyRate As Decimal = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.AccountPayableNewspaper)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableNewspaper As AdvantageFramework.Database.Entities.AccountPayableNewspaper
            Get
                AccountPayableNewspaper = _AccountPayableNewspaper
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Circulation/Qty")>
        Public Property PrintLines() As Nullable(Of Decimal)
            Get
                PrintLines = _AccountPayableNewspaper.PrintLines
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableNewspaper.PrintLines = value
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
                Rate = _AccountPayableNewspaper.Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableNewspaper.Rate = value
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
                GrossAmount = _AccountPayableNewspaper.GrossAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableNewspaper.GrossAmount = value
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
                NetAmount = _AccountPayableNewspaper.NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableNewspaper.NetAmount = value
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
                DiscountLN = _AccountPayableNewspaper.DiscountLN
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableNewspaper.DiscountLN = value
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
                NetCharges = _AccountPayableNewspaper.NetCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableNewspaper.NetCharges = value
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
                VendorTax = _AccountPayableNewspaper.VendorTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableNewspaper.VendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property ForeignDisbursedAmount() As Nullable(Of Decimal)
            Get
                ForeignDisbursedAmount = Me.ForeignNetAmount - Me.ForeignDiscountLineNet + Me.ForeignNetCharges + Me.ForeignVendorTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DisbursedAmount() As Nullable(Of Decimal)
            Get
                DisbursedAmount = _AccountPayableNewspaper.DisbursedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableNewspaper.DisbursedAmount = value
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
                SalesTaxCode = _AccountPayableNewspaper.SalesTaxCode
            End Get
            Set(ByVal value As String)
                _AccountPayableNewspaper.SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountPayableNewspaper.OfficeCode
            End Get
            Set(ByVal value As String)
                _AccountPayableNewspaper.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _AccountPayableNewspaper.GLACode
            End Get
            Set(ByVal value As String)
                _AccountPayableNewspaper.GLACode = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property UseCPM() As Boolean
            Get
                UseCPM = _UseCPM
            End Get
            Set(value As Boolean)
                _UseCPM = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CostTypeFromOrderDetail() As String
            Get
                CostTypeFromOrderDetail = _CostTypeFromOrderDetail
            End Get
            Set(value As String)
                _CostTypeFromOrderDetail = value
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

            Me.AccountPayableNewspaper.NetPlus = Me.NetAmount.GetValueOrDefault(0)
            Me.AccountPayableNewspaper.GrossPlus = Me.GrossAmount.GetValueOrDefault(0)

            If Me.AccountPayableNewspaper.NetGross.GetValueOrDefault(0) = 1 Then

                Me.AccountPayableNewspaper.CommissionAmount = FormatNumber(Me.AccountPayableNewspaper.GrossPlus.GetValueOrDefault(0) * Me.AccountPayableNewspaper.CommissionPercent.GetValueOrDefault(0) / 100, 2)

            Else

                Me.AccountPayableNewspaper.CommissionAmount = FormatNumber(Me.AccountPayableNewspaper.NetPlus.GetValueOrDefault(0) * Me.AccountPayableNewspaper.MarkupPercent.GetValueOrDefault(0) / 100, 2)

            End If

            Me.AccountPayableNewspaper.RebateAmount = FormatNumber(-1 * Me.AccountPayableNewspaper.GrossPlus.GetValueOrDefault(0) * Me.AccountPayableNewspaper.RebatePercent.GetValueOrDefault(0) / 100, 2)

            If ReCalculateTax Then

                CalculateTax(Me)

            End If

            Me.ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignNetAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignDiscountLineNet = FormatNumber(Me.DiscountLN.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            Me.ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

            Me.DisbursedAmount = FormatNumber(Me.AccountPayableNewspaper.NetPlus.GetValueOrDefault(0) -
                                                                                     Me.DiscountLN.GetValueOrDefault(0) +
                                                                                     Me.NetCharges.GetValueOrDefault(0) +
                                                                                     Me.VendorTax.GetValueOrDefault(0), 2)

            Me.AccountPayableNewspaper.LineTotal = FormatNumber(Me.DisbursedAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableNewspaper.RebateAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableNewspaper.CommissionAmount.GetValueOrDefault(0) +
                                                                Me.AccountPayableNewspaper.StateTax.GetValueOrDefault(0) +
                                                                Me.AccountPayableNewspaper.CountyTax.GetValueOrDefault(0) +
                                                                Me.AccountPayableNewspaper.CityTax.GetValueOrDefault(0), 2)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

        End Sub
        Private Shared Sub CalculateTax(ByRef AccountPayableNewspaperDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail)

            Dim TotalTax As Decimal = Nothing
            Dim TaxableAmount As Decimal = 0

            TotalTax = AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.StateTaxPercent.GetValueOrDefault(0) + _
                       AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CityTaxPercent.GetValueOrDefault(0) + _
                       AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CountyTaxPercent.GetValueOrDefault(0)

            If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.IsResaleTax.GetValueOrDefault(0) = 1 Then

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.NetPlus.GetValueOrDefault(0)

                End If

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.DiscountLN.GetValueOrDefault(0)

                End If

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.NetCharges.GetValueOrDefault(0)

                End If

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.StateTax = FormatNumber(AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CountyTax = FormatNumber(AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CityTax = FormatNumber(AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

                AccountPayableNewspaperDistributionDetail.VendorTax = 0

            Else

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyLN.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.NetPlus.GetValueOrDefault(0)

                End If

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyLND.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount - AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.DiscountLN.GetValueOrDefault(0)

                End If

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyNC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.NetCharges.GetValueOrDefault(0)

                End If

                AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.VendorTax = FormatNumber(TaxableAmount * TotalTax / 100, 2)

                TaxableAmount = 0

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyC.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CommissionAmount.GetValueOrDefault(0)

                End If

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyR.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = TaxableAmount + AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.RebateAmount.GetValueOrDefault(0)

                End If

                AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.StateTax = FormatNumber(AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.StateTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CountyTax = FormatNumber(AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CountyTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)
                AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CityTax = FormatNumber(AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CityTaxPercent.GetValueOrDefault(0) / 100 * TaxableAmount, 2)

            End If

        End Sub
        Private Shared Sub SetCostType(ByRef AccountPayableNewspaperDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail,
                                       ByVal Ordernumber As Integer, LineNumber As Short, ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim NewspaperOrderDetail As AdvantageFramework.Database.Entities.NewspaperOrderDetail = Nothing

            NewspaperOrderDetail = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.LoadActiveRevisionByOrderNumberAndLineNumber(DbContext, Ordernumber, LineNumber)

            If NewspaperOrderDetail IsNot Nothing Then

                AccountPayableNewspaperDistributionDetail.CostTypeFromOrderDetail = NewspaperOrderDetail.CostType

                If NewspaperOrderDetail.CostType = "CPM" AndAlso NewspaperOrderDetail.RateType = "CPM" Then

                    AccountPayableNewspaperDistributionDetail.UseCPM = True

                Else

                    AccountPayableNewspaperDistributionDetail.UseCPM = False

                End If

                If NewspaperOrderDetail.CostType = "CPM" AndAlso NewspaperOrderDetail.RateType = "CPM" Then

                    AccountPayableNewspaperDistributionDetail.CostType = "CPM"

                ElseIf NewspaperOrderDetail.CostType = "CPM" AndAlso NewspaperOrderDetail.RateType = "STD" Then

                    AccountPayableNewspaperDistributionDetail.CostType = "Standard"

                Else

                    AccountPayableNewspaperDistributionDetail.CostType = "Standard"

                End If

                If AccountPayableNewspaperDistributionDetail.CostTypeFromOrderDetail = "CPI" OrElse AccountPayableNewspaperDistributionDetail.CostTypeFromOrderDetail = "NA" Then

                    AccountPayableNewspaperDistributionDetail.PrintLines = Nothing
                    AccountPayableNewspaperDistributionDetail.Rate = Nothing
                    AccountPayableNewspaperDistributionDetail.ForeignRate = Nothing

                End If

            End If

        End Sub
        Private Sub SetForeignCurrencyAmounts()

            If Me.Rate.HasValue Then

                _ForeignRate = FormatNumber(Me.Rate.GetValueOrDefault(0) / Me.CurrencyRate, 4)

            Else

                _ForeignRate = Nothing

            End If

            _ForeignGrossAmount = FormatNumber(Me.GrossAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignNetAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignDiscountLineNet = FormatNumber(Me.DiscountLN.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignNetCharges = FormatNumber(Me.NetCharges.GetValueOrDefault(0) / Me.CurrencyRate, 2)
            _ForeignVendorTax = FormatNumber(Me.VendorTax.GetValueOrDefault(0) / Me.CurrencyRate, 2)

        End Sub
        Public Shared Sub SetBaseValues(ByRef AccountPayableNewspaperDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail,
                                        ByVal NewspaperDetail As AdvantageFramework.Database.Views.NewspaperDetail,
                                        ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        CurrencyRate As Decimal)

            Dim NewspaperHeader As AdvantageFramework.Database.Views.NewspaperHeader = Nothing
            Dim NewspaperOrderDetail As AdvantageFramework.Database.Entities.NewspaperOrderDetail = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim AccountPayableNewspaperList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableNewspaper) = Nothing
            Dim SumOfNetAmount As Decimal = Nothing
            Dim SumOfGrossAmount As Decimal = Nothing
            Dim SumOfDiscount As Decimal = Nothing
            Dim SumOfNetCharges As Decimal = Nothing
            Dim SumOfPrintLines As Decimal = 0
            Dim SumOfCommission As Decimal = 0

            AccountPayableNewspaperDistributionDetail.CurrencyRate = CurrencyRate

            AccountPayableNewspaperList = AdvantageFramework.Database.Procedures.AccountPayableNewspaper.LoadActiveByOrderNumberAndLineNumber(DbContext, NewspaperDetail.OrderNumber, NewspaperDetail.LineNumber).ToList

            AccountPayableNewspaperDistributionDetail.OrderNumber = NewspaperDetail.OrderNumber
            AccountPayableNewspaperDistributionDetail.OrderLineNumber = NewspaperDetail.LineNumber

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.RevisionNumber = NewspaperDetail.RevisionNumber
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.SequenceNumber = NewspaperDetail.SequenceNumber

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.SalesTaxCode = If(String.IsNullOrWhiteSpace(NewspaperDetail.SalesTaxCode), Nothing, NewspaperDetail.SalesTaxCode)
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CityTaxPercent = NewspaperDetail.CityTaxPercent
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CountyTaxPercent = NewspaperDetail.CountyTaxPercent
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.StateTaxPercent = NewspaperDetail.StateTaxPercent

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyC = NewspaperDetail.TaxApplyC
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyLN = NewspaperDetail.TaxApplyLN
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyLND = NewspaperDetail.TaxApplyLND
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyNC = NewspaperDetail.TaxApplyNC
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyNCD = NewspaperDetail.TaxApplyNCD
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.TaxApplyR = NewspaperDetail.TaxApplyR
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.IsResaleTax = NewspaperDetail.IsResaleTax

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CityTax = NewspaperDetail.CityTax
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CountyTax = NewspaperDetail.CountyTax
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.StateTax = NewspaperDetail.StateTax
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.VendorTax = NewspaperDetail.VendorTax

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CommissionPercent = NewspaperDetail.CommissionPercent.GetValueOrDefault(0)
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CommissionAmount = NewspaperDetail.CommissionAmount.GetValueOrDefault(0)
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.MarkupPercent = NewspaperDetail.MarkupPercent.GetValueOrDefault(0)
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.RebatePercent = NewspaperDetail.RebatePercent.GetValueOrDefault(0)
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.RebateAmount = NewspaperDetail.RebateAmount.GetValueOrDefault(0)
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.Rate = NewspaperDetail.NetRate.GetValueOrDefault(0)
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.NetGross = NewspaperDetail.NetGross.GetValueOrDefault(0)

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.NetCharges = NewspaperDetail.NetCharge.GetValueOrDefault(0)
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.LineTotal = NewspaperDetail.LineTotal.GetValueOrDefault(0)

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.ColorGrossAmount = 0
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.ColorNetAmount = 0
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.DiscountNC = 0

            AccountPayableNewspaperDistributionDetail.InsertionDate = NewspaperDetail.InsertDate

            NewspaperOrderDetail = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.LoadActiveRevisionByOrderNumberAndLineNumber(DbContext, NewspaperDetail.OrderNumber, NewspaperDetail.LineNumber)

            If NewspaperOrderDetail IsNot Nothing Then

                AccountPayableNewspaperDistributionDetail.PrintLines = NewspaperOrderDetail.PrintLines.GetValueOrDefault(0)

            End If

            NewspaperHeader = AdvantageFramework.Database.Procedures.NewspaperHeaderView.LoadByOrderNumber(DbContext, NewspaperDetail.OrderNumber)

            If NewspaperHeader IsNot Nothing Then

                AccountPayableNewspaperDistributionDetail.ClientCode = NewspaperHeader.ClientCode
                AccountPayableNewspaperDistributionDetail.DivisionCode = NewspaperHeader.DivisionCode
                AccountPayableNewspaperDistributionDetail.ProductCode = NewspaperHeader.ProductCode
                AccountPayableNewspaperDistributionDetail.OfficeCode = NewspaperHeader.OfficeCode

                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, NewspaperHeader.OfficeCode)

                If Office IsNot Nothing Then

                    AccountPayableNewspaperDistributionDetail.GLACode = Office.MediaWorkInProgressGLACode

                End If

            End If

            AccountPayableNewspaperDistributionDetail.OrderNetAmount = NewspaperDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                                                       NewspaperDetail.DiscountAmount.GetValueOrDefault(0) +
                                                                       NewspaperDetail.NetCharge.GetValueOrDefault(0) +
                                                                       NewspaperDetail.VendorTax.GetValueOrDefault(0)

            AccountPayableNewspaperDistributionDetail.PreviouslyPosted = AccountPayableNewspaperList.Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0)) +
                                                                         AccountPayableNewspaperList.Sum(Function(Entity) Entity.DiscountLN.GetValueOrDefault(0)) +
                                                                         AccountPayableNewspaperList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0)) +
                                                                         AccountPayableNewspaperList.Sum(Function(Entity) Entity.VendorTax.GetValueOrDefault(0))

            SumOfNetAmount = AccountPayableNewspaperList.Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0))
            SumOfGrossAmount = AccountPayableNewspaperList.Sum(Function(Entity) Entity.GrossAmount.GetValueOrDefault(0))
            SumOfPrintLines = AccountPayableNewspaperList.Sum(Function(Entity) Entity.PrintLines.GetValueOrDefault(0))
            SumOfDiscount = AccountPayableNewspaperList.Sum(Function(Entity) Math.Abs(Entity.DiscountLN.GetValueOrDefault(0)))
            SumOfNetCharges = AccountPayableNewspaperList.Sum(Function(Entity) Entity.NetCharges.GetValueOrDefault(0))
            SumOfCommission = AccountPayableNewspaperList.Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0))

            If SumOfCommission > AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CommissionAmount.GetValueOrDefault(0) Then

                AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CommissionAmount = 0

            Else

                AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CommissionAmount = FormatNumber(NewspaperDetail.CommissionAmount.GetValueOrDefault(0) - SumOfCommission, 2)

            End If

            If SumOfNetAmount > NewspaperDetail.ExtendedNetAmount.GetValueOrDefault(0) Then

                AccountPayableNewspaperDistributionDetail.NetAmount = 0

            Else

                AccountPayableNewspaperDistributionDetail.NetAmount = Format(NewspaperDetail.ExtendedNetAmount.GetValueOrDefault(0) - SumOfNetAmount, "#0.00")

            End If

            If SumOfGrossAmount > NewspaperDetail.ExtendedGrossAmount.GetValueOrDefault(0) Then

                AccountPayableNewspaperDistributionDetail.GrossAmount = 0

            Else

                AccountPayableNewspaperDistributionDetail.GrossAmount = Format(NewspaperDetail.ExtendedGrossAmount.GetValueOrDefault(0) - SumOfGrossAmount, "#0.00")

            End If

            If SumOfDiscount > Math.Abs(NewspaperDetail.DiscountAmount.GetValueOrDefault(0)) Then

                AccountPayableNewspaperDistributionDetail.DiscountLN = 0

            Else

                AccountPayableNewspaperDistributionDetail.DiscountLN = Format(Math.Abs(NewspaperDetail.DiscountAmount.GetValueOrDefault(0)) - SumOfDiscount, "#0.00")

            End If

            If SumOfNetCharges > NewspaperDetail.NetCharge.GetValueOrDefault(0) Then

                AccountPayableNewspaperDistributionDetail.NetCharges = 0

            Else

                AccountPayableNewspaperDistributionDetail.NetCharges = Format(NewspaperDetail.NetCharge.GetValueOrDefault(0) - SumOfNetCharges, "#0.00")

            End If

            If SumOfPrintLines > AccountPayableNewspaperDistributionDetail.PrintLines.GetValueOrDefault(0) Then

                AccountPayableNewspaperDistributionDetail.PrintLines = 0

            Else

                AccountPayableNewspaperDistributionDetail.PrintLines = FormatNumber(AccountPayableNewspaperDistributionDetail.PrintLines.GetValueOrDefault(0) - SumOfPrintLines, 2)

            End If

            SetCostType(AccountPayableNewspaperDistributionDetail, NewspaperDetail.OrderNumber, NewspaperDetail.LineNumber, DbContext)

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.NetPlus = AccountPayableNewspaperDistributionDetail.NetAmount.GetValueOrDefault(0)
            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.GrossPlus = AccountPayableNewspaperDistributionDetail.GrossAmount.GetValueOrDefault(0)

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.RebateAmount = FormatNumber(-1 * AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.GrossPlus.GetValueOrDefault(0) *
                                                                                                          AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.RebatePercent.GetValueOrDefault(0) / 100, 2)

            CalculateTax(AccountPayableNewspaperDistributionDetail)

            AccountPayableNewspaperDistributionDetail.DisbursedAmount = FormatNumber(AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.NetPlus.GetValueOrDefault(0) -
                                                                                     AccountPayableNewspaperDistributionDetail.DiscountLN.GetValueOrDefault(0) +
                                                                                     AccountPayableNewspaperDistributionDetail.NetCharges.GetValueOrDefault(0) +
                                                                                     AccountPayableNewspaperDistributionDetail.VendorTax.GetValueOrDefault(0), 2)

            AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.LineTotal = FormatNumber(AccountPayableNewspaperDistributionDetail.DisbursedAmount.GetValueOrDefault(0) +
                                                                                                       AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.RebateAmount.GetValueOrDefault(0) +
                                                                                                       AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CommissionAmount.GetValueOrDefault(0) +
                                                                                                       AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.StateTax.GetValueOrDefault(0) +
                                                                                                       AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CountyTax.GetValueOrDefault(0) +
                                                                                                       AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.CityTax.GetValueOrDefault(0), 2)

            AccountPayableNewspaperDistributionDetail.OrderNetBalance = AccountPayableNewspaperDistributionDetail.OrderNetAmount - (AccountPayableNewspaperDistributionDetail.DisbursedAmount + AccountPayableNewspaperDistributionDetail.PreviouslyPosted)

            AccountPayableNewspaperDistributionDetail.SetForeignCurrencyAmounts()

        End Sub
        Public Sub New()

            _AccountPayableNewspaper = New AdvantageFramework.Database.Entities.AccountPayableNewspaper

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

            Dim NewspaperDetail As AdvantageFramework.Database.Views.NewspaperDetail = Nothing

            _AccountPayableNewspaper = New AdvantageFramework.Database.Entities.AccountPayableNewspaper

            NewspaperDetail = AdvantageFramework.Database.Procedures.NewspaperDetailView.LoadActiveByOrderNumberLineNumber(DbContext, ImportAccountPayableMedia.OrderNumber, ImportAccountPayableMedia.OrderLineNumber)

            If NewspaperDetail IsNot Nothing Then

                SetBaseValues(Me, NewspaperDetail, DbContext, 1)

                Me.DiscountLN = 0 'should not bring this in, there is not a place in import file for discount, to bring it in will cause OOB

            End If

            Me.NetAmount = ImportAccountPayableMedia.MediaNetAmount.GetValueOrDefault(0)
            Me.VendorTax = ImportAccountPayableMedia.MediaVendorTax.GetValueOrDefault(0)
            Me.NetCharges = ImportAccountPayableMedia.MediaNetCharge.GetValueOrDefault(0)

            AdvantageFramework.AccountPayable.CalculateGrossAndCommission(Me.NetAmount, Me.DiscountLN, Me.AccountPayableNewspaper.MarkupPercent, Me.GrossAmount, Me.AccountPayableNewspaper.CommissionAmount)

            ReCalculate(False)

            Me.DisbursedAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) -
                                              Me.DiscountLN.GetValueOrDefault(0) +
                                              Me.NetCharges.GetValueOrDefault(0) +
                                              Me.VendorTax.GetValueOrDefault(0), 2)

            Me.OrderNetBalance = Me.OrderNetAmount - (Me.DisbursedAmount + Me.PreviouslyPosted)

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableNewspaper As AdvantageFramework.Database.Entities.AccountPayableNewspaper,
                       LoadingActive As Boolean)

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim NewspaperHeader As AdvantageFramework.Database.Views.NewspaperHeader = Nothing
            Dim AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval = Nothing
            Dim MediaApprovalStatus As Generic.KeyValuePair(Of Long, String) = Nothing
            Dim NewspaperDetail As AdvantageFramework.Database.Views.NewspaperDetail = Nothing

            _AccountPayableNewspaper = AccountPayableNewspaper

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableNewspaper.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            _CurrencyRate = If(AccountPayable.CurrencyRate.HasValue AndAlso AccountPayable.CurrencyRate = 0, 1, AccountPayable.CurrencyRate.GetValueOrDefault(1))

            _AccountPayableNewspaper.DiscountLN = If(LoadingActive, Math.Abs(_AccountPayableNewspaper.DiscountLN.GetValueOrDefault(0)), _AccountPayableNewspaper.DiscountLN.GetValueOrDefault(0))

            _OrderNumber = AccountPayableNewspaper.OrderNumber
            _OrderLineNumber = AccountPayableNewspaper.OrderLineNumber

            _PreviouslyPosted = AdvantageFramework.Database.Procedures.AccountPayableNewspaper.LoadActiveByOrderNumberAndLineNumber(DbContext, AccountPayableNewspaper.OrderNumber, AccountPayableNewspaper.OrderLineNumber) _
                .Where(Function(Entity) Entity.AccountPayableID <> AccountPayableNewspaper.AccountPayableID) _
                .Sum(Function(Entity) Entity.NetAmount + Entity.DiscountLN + Entity.NetCharges + Entity.VendorTax).GetValueOrDefault(0)

            If AccountPayableNewspaper.GeneralLedgerAccount3 IsNot Nothing Then

                _GLADescription = AccountPayableNewspaper.GeneralLedgerAccount3.Description

            End If

            NewspaperHeader = AdvantageFramework.Database.Procedures.NewspaperHeaderView.LoadByOrderNumber(DbContext, AccountPayableNewspaper.OrderNumber)

            If NewspaperHeader IsNot Nothing Then

                _ClientCode = NewspaperHeader.ClientCode
                _DivisionCode = NewspaperHeader.DivisionCode
                _ProductCode = NewspaperHeader.ProductCode

                Try

                    NewspaperDetail = (From Entity In AdvantageFramework.Database.Procedures.NewspaperDetailView.Load(DbContext)
                                       Where Entity.OrderNumber = AccountPayableNewspaper.OrderNumber AndAlso
                                             Entity.LineNumber = AccountPayableNewspaper.OrderLineNumber
                                       Select Entity).OrderByDescending(Function(E) E.RevisionNumber).ThenByDescending(Function(E) E.SequenceNumber).FirstOrDefault

                Catch ex As Exception
                    NewspaperDetail = Nothing
                End Try

                If NewspaperDetail IsNot Nothing Then

                    _InsertionDate = NewspaperDetail.InsertDate

                    _OrderNetAmount = NewspaperDetail.ExtendedNetAmount.GetValueOrDefault(0) +
                                      NewspaperDetail.DiscountAmount.GetValueOrDefault(0) +
                                      NewspaperDetail.NetCharge.GetValueOrDefault(0) +
                                      NewspaperDetail.VendorTax.GetValueOrDefault(0)

                End If

            End If

            _OrderNetBalance = _OrderNetAmount - (_AccountPayableNewspaper.DisbursedAmount.GetValueOrDefault(0) + _PreviouslyPosted)

            SetCostType(Me, AccountPayableNewspaper.OrderNumber, AccountPayableNewspaper.OrderLineNumber, DbContext)

            Try

                AccountPayableMediaApproval = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.LoadByAccountPayableID(DbContext, AccountPayableNewspaper.AccountPayableID)
                                               Where Entity.OrderNumber = AccountPayableNewspaper.OrderNumber AndAlso
                                                     Entity.LineNumber = AccountPayableNewspaper.OrderLineNumber AndAlso
                                                     Entity.Source = "N" AndAlso
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
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal NewspaperDetail As AdvantageFramework.Database.Views.NewspaperDetail,
                       CurrencyRate As Decimal)

            _AccountPayableNewspaper = New AdvantageFramework.Database.Entities.AccountPayableNewspaper

            SetBaseValues(Me, NewspaperDetail, DbContext, CurrencyRate)

        End Sub
        Public Overrides Function ToString() As String

            ToString = _AccountPayableNewspaper.AccountPayableID

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

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.DisbursedAmount.ToString

                        If Me.PrintLines.GetValueOrDefault(0) = 0 AndAlso Me.NetAmount.GetValueOrDefault(0) = 0 AndAlso Me.NetCharges.GetValueOrDefault(0) = 0 AndAlso Me.VendorTax.GetValueOrDefault(0) = 0 Then

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.DisbursedAmount.ToString, True)

                        Else

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.DisbursedAmount.ToString, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.OrderNumber.ToString

                    PropertyValue = Value

                    If IsNumeric(PropertyValue) AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Order is required and cannot be zero."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.OrderLineNumber.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Line is required and cannot be zero."

                    End If

                    'Case AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail.Properties.DisbursedAmount.ToString

                    '    PropertyValue = Value

                    '    If (PropertyValue Is Nothing OrElse PropertyValue = 0) AndAlso Me.NetAmount.GetValueOrDefault(0) = 0 AndAlso Me.NetCharges.GetValueOrDefault(0) = 0 AndAlso _
                    '            Me.VendorTax.GetValueOrDefault(0) = 0 And Me.PrintLines.GetValueOrDefault(0) = 0 Then

                    '        IsValid = False

                    '        ErrorText = "Invalid disbursement.  All data cannot be zero."

                    '    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

