Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableProductionDistributionDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableID
            AccountPayableSequenceNumber
            LineNumber
            PONumber
            PODetailLineNumber
            POComplete
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobDescription
            IsOpen
            JobComponentNumber
            JobCompDescription
            IsAdvanceBilling
            BillingUserCode
            FunctionCode
            FunctionDescription
            Quantity
            ForeignRate
            Rate
            ForeignExtendedAmount
            ExtendedAmount
            SalesTaxCode
            IsResaleTax
            ForeignExtendedNonResaleTax
            ExtendedNonResaleTax
            ResaleTax
            TaxCommissions
            TaxCommissionsOnly
            CommissionPercent
            ExtendedMarkupAmount
            LineTotal
            ForeignDisbursed
            Disbursed
            POAmount
            POBalance
            IsNonBillable
            OfficeCode
            GLACode
            GLADescription
            Comment
            AccountReceivableInvoiceNumber
            BillingCommandCenterID
            CurrencyRate
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _POAmount As Nullable(Of Decimal) = Nothing
        Private _POBalance As Nullable(Of Decimal) = Nothing
        Private _Comment As String = Nothing
        Private _IsDeleted As Boolean = False
        Private _IsOpen As Nullable(Of Integer) = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Integer) = Nothing
        Private _JobCompDescription As String = Nothing
        Private _GLADescription As String = Nothing
        Private _ForeignRate As Nullable(Of Decimal) = Nothing
        Private _ForeignExtendedAmount As Decimal = Nothing
        Private _ForeignExtendedNonResaleTax As Decimal = Nothing
        Private _CurrencyRate As Decimal = 1
        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.AccountPayableProduction)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction
            Get
                AccountPayableProduction = _AccountPayableProduction
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableProduction.AccountPayableID
            End Get
            Set(ByVal value As Integer)
                _AccountPayableProduction.AccountPayableID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableSequenceNumber() As Short
            Get
                AccountPayableSequenceNumber = _AccountPayableProduction.AccountPayableSequenceNumber
            End Get
            Set(ByVal value As Short)
                _AccountPayableProduction.AccountPayableSequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineNumber() As Short
            Get
                LineNumber = _AccountPayableProduction.LineNumber
            End Get
            Set(ByVal value As Short)
                _AccountPayableProduction.LineNumber = value
            End Set
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="P.O. Number")>
        Public Property PONumber() As Nullable(Of Integer)
            Get
                PONumber = _AccountPayableProduction.PONumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AccountPayableProduction.PONumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="P.O. Line")>
        Public Property PODetailLineNumber() As Nullable(Of Short)
            Get
                PODetailLineNumber = _AccountPayableProduction.PODetailLineNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableProduction.PODetailLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="P.O. Complete", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property POComplete As Nullable(Of Short)
            Get
                POComplete = _AccountPayableProduction.IsPOComplete
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableProduction.IsPOComplete = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property JobDescription As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsOpen As Nullable(Of Integer)
            Get
                IsOpen = _IsOpen
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _IsOpen = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Job Comp", PropertyType:=BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobComponentNumber As Nullable(Of Integer)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property JobCompDescription As String
            Get
                JobCompDescription = _JobCompDescription
            End Get
            Set(ByVal value As String)
                _JobCompDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsAdvanceBilling() As Nullable(Of Short)
            Get
                IsAdvanceBilling = _AccountPayableProduction.IsAdvanceBilling
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableProduction.IsAdvanceBilling = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BillingUserCode() As String
            Get
                BillingUserCode = _AccountPayableProduction.BillingUserCode
            End Get
            Set(ByVal value As String)
                _AccountPayableProduction.BillingUserCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Function", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode As String
            Get
                FunctionCode = _AccountPayableProduction.FunctionCode
            End Get
            Set(ByVal value As String)
                _AccountPayableProduction.FunctionCode = If(value Is Nothing, "", value)
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property FunctionDescription As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity As Nullable(Of Decimal)
            Get
                Quantity = _AccountPayableProduction.Quantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableProduction.Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        Public Property ForeignRate As Nullable(Of Decimal)
            Get
                ForeignRate = _ForeignRate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ForeignRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property Rate As Nullable(Of Decimal)
            Get
                Rate = _AccountPayableProduction.Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableProduction.Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignExtendedAmount() As Decimal
            Get
                ForeignExtendedAmount = _ForeignExtendedAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignExtendedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ExtendedAmount As Nullable(Of Decimal)
            Get
                ExtendedAmount = _AccountPayableProduction.ExtendedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableProduction.ExtendedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Tax Code", PropertyType:=BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property SalesTaxCode As String
            Get
                SalesTaxCode = _AccountPayableProduction.SalesTaxCode
            End Get
            Set(ByVal value As String)
                _AccountPayableProduction.SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsResaleTax As Nullable(Of Short)
            Get
                IsResaleTax = _AccountPayableProduction.IsResaleTax
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableProduction.IsResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Foreign Vendor Tax")>
        Public Property ForeignExtendedNonResaleTax As Decimal
            Get
                ForeignExtendedNonResaleTax = _ForeignExtendedNonResaleTax
            End Get
            Set(value As Decimal)
                _ForeignExtendedNonResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Vendor Tax")>
        Public Property ExtendedNonResaleTax As Nullable(Of Decimal)
            Get
                ExtendedNonResaleTax = _AccountPayableProduction.ExtendedNonResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableProduction.ExtendedNonResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property ResaleTax As Decimal
            Get
                ResaleTax = AccountPayableProduction.ExtendedStateResale.GetValueOrDefault(0) + AccountPayableProduction.ExtendedCountyResale.GetValueOrDefault(0) + AccountPayableProduction.ExtendedCityResale.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxCommissions As Nullable(Of Short)
            Get
                TaxCommissions = _AccountPayableProduction.TaxCommissions
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableProduction.TaxCommissions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxCommissionsOnly As Nullable(Of Short)
            Get
                TaxCommissionsOnly = _AccountPayableProduction.TaxCommissionsOnly
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableProduction.TaxCommissionsOnly = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3", CustomColumnCaption:="Markup %")>
        Public Property CommissionPercent As Nullable(Of Decimal)
            Get
                CommissionPercent = _AccountPayableProduction.CommissionPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableProduction.CommissionPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Markup Amount")>
        Public Property ExtendedMarkupAmount As Nullable(Of Decimal)
            Get
                ExtendedMarkupAmount = _AccountPayableProduction.ExtendedMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AccountPayableProduction.ExtendedMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Total")>
        Public ReadOnly Property LineTotal As Nullable(Of Decimal)
            Get
                LineTotal = Me.ExtendedAmount.GetValueOrDefault(0) + Me.ExtendedMarkupAmount.GetValueOrDefault(0) + Me.ExtendedNonResaleTax.GetValueOrDefault(0) + Me.ResaleTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Foreign Disbursed", IsReadOnlyColumn:=True)>
        Public ReadOnly Property ForeignDisbursed As Decimal
            Get
                ForeignDisbursed = Me.ForeignExtendedAmount + Me.ForeignExtendedNonResaleTax
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Disbursed", IsReadOnlyColumn:=True)>
        Public ReadOnly Property Disbursed As Nullable(Of Decimal)
            Get
                Disbursed = _AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0) + _AccountPayableProduction.ExtendedNonResaleTax.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="P.O. Amount", IsReadOnlyColumn:=True)>
        Public Property POAmount() As Nullable(Of Decimal)
            Get
                POAmount = _POAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _POAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="P.O. Balance", IsReadOnlyColumn:=True)>
        Public Property POBalance() As Nullable(Of Decimal)
            Get
                POBalance = _POBalance
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _POBalance = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Non Bill", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsNonBillable As Nullable(Of Short)
            Get
                IsNonBillable = _AccountPayableProduction.IsNonBillable
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableProduction.IsNonBillable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Office", PropertyType:=BaseClasses.PropertyTypes.OfficeCode, IsReadOnlyColumn:=True)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountPayableProduction.OfficeCode
            End Get
            Set(ByVal value As String)
                _AccountPayableProduction.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACode As String
            Get
                GLACode = _AccountPayableProduction.GLACode
            End Get
            Set(ByVal value As String)
                _AccountPayableProduction.GLACode = If(value Is Nothing, "", value)
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Description", DefaultColumnType:=BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription)>
        Public Property GLADescription() As String
            Get
                GLADescription = _GLADescription
            End Get
            Set(ByVal value As String)
                _GLADescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property AccountReceivableInvoiceNumber() As Nullable(Of Integer)
            Get
                AccountReceivableInvoiceNumber = AccountPayableProduction.AccountReceivableInvoiceNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property BillingCommandCenterID() As Nullable(Of Integer)
            Get
                BillingCommandCenterID = AccountPayableProduction.BillingCommandCenterID
            End Get
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
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

        Public Sub New()

            _AccountPayableProduction = New AdvantageFramework.Database.Entities.AccountPayableProduction
            SetZeroValues()

        End Sub
        Public Function CalculatePOBalance(FieldName As String, AccountPayableID As Integer) As String

            'objects
            Dim AmountToSet As Decimal = 0
            Dim ExtendedAmount As Decimal = 0
            Dim POBalance As Decimal = 0
            Dim Message As String = Nothing

            If Me.PONumber.HasValue AndAlso Me.PODetailLineNumber.HasValue AndAlso
                (FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Quantity.ToString OrElse
                 FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Rate.ToString OrElse
                 FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ExtendedAmount.ToString OrElse
                 FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ForeignRate.ToString OrElse
                 FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.ForeignExtendedAmount.ToString) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ExtendedAmount = Me.ExtendedAmount.GetValueOrDefault(0)

                    POBalance = DbContext.Database.SqlQuery(Of Decimal)(String.Format("exec advsp_ap_production_calc_po_balance_excluding_ap_id {0}, {1}, {2}", Me.PONumber, Me.PODetailLineNumber, AccountPayableID)).FirstOrDefault

                    Me.POBalance = POBalance - ExtendedAmount

                    If AdvantageFramework.Database.Procedures.Agency.APPOMessage(DbContext) Then

                        If Me.POBalance.HasValue AndAlso ExtendedAmount > POBalance Then

                            Message = AdvantageFramework.Database.Procedures.Agency.APPOMessageText(DbContext)

                        End If

                    ElseIf AdvantageFramework.Database.Procedures.Agency.APPOReject(DbContext) Then

                        If Me.POBalance.HasValue AndAlso ExtendedAmount > POBalance Then

                            Message = AdvantageFramework.Database.Procedures.Agency.APPORejectText(DbContext)

                            AmountToSet = Me.POBalance

                            Me.ExtendedAmount = Me.POBalance

                        End If

                    End If

                End Using

            End If

            CalculatePOBalance = Message

        End Function
        Public Shared Sub CalculateQuantityRateAndAmount(ByVal FieldChanged As AdvantageFramework.BillingSystem.QtyRateAmount,
                                                         ByRef AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail,
                                                         ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            If AccountPayableProductionDistributionDetail.Quantity IsNot Nothing AndAlso AccountPayableProductionDistributionDetail.Rate IsNot Nothing AndAlso String.IsNullOrWhiteSpace(AccountPayableProductionDistributionDetail.FunctionCode) = False Then

                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, AccountPayableProductionDistributionDetail.FunctionCode)

                If [Function] IsNot Nothing AndAlso [Function].CPMFlag.GetValueOrDefault(0) = 1 Then

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(AccountPayableProductionDistributionDetail.Quantity, AccountPayableProductionDistributionDetail.Rate, AccountPayableProductionDistributionDetail.ExtendedAmount, FieldChanged, 2, 3, 2, True)

                Else

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(AccountPayableProductionDistributionDetail.Quantity, AccountPayableProductionDistributionDetail.Rate, AccountPayableProductionDistributionDetail.ExtendedAmount, FieldChanged, 2, 3)

                End If

            ElseIf FieldChanged = BillingSystem.QtyRateAmount.Quantity OrElse FieldChanged = BillingSystem.QtyRateAmount.Rate Then

                AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(AccountPayableProductionDistributionDetail.Quantity, AccountPayableProductionDistributionDetail.Rate, AccountPayableProductionDistributionDetail.ExtendedAmount, FieldChanged, 2, 3)

            ElseIf FieldChanged = BillingSystem.QtyRateAmount.Amount Then

                AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(AccountPayableProductionDistributionDetail.Quantity, AccountPayableProductionDistributionDetail.Rate, AccountPayableProductionDistributionDetail.ExtendedAmount, FieldChanged, 2, 3)

            End If

        End Sub
        Public Shared Sub ProcessBillingRate(ByVal BillingRate As AdvantageFramework.Database.Classes.BillingRate, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByRef AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail,
                                             ByVal BypassRateQuantityCalculation As Boolean)

            'objects
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing

            If Not BypassRateQuantityCalculation Then

                If AccountPayableProductionDistributionDetail.Rate IsNot Nothing Then

                    If BillingRate.BILLING_RATE.GetValueOrDefault(0) <> 0 Then

                        AccountPayableProductionDistributionDetail.Rate = BillingRate.BILLING_RATE

                    End If

                Else

                    AccountPayableProductionDistributionDetail.Rate = If(BillingRate.BILLING_RATE = 0, Nothing, BillingRate.BILLING_RATE)

                End If

                CalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Rate, AccountPayableProductionDistributionDetail, DbContext)

            End If

            If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) AndAlso AdvantageFramework.Database.Procedures.SalesTax.IsResaleTax(DbContext, BillingRate.TAX_CODE) Then

                AccountPayableProductionDistributionDetail.ClearSalesTax()

            Else

                AccountPayableProductionDistributionDetail.SalesTaxCode = BillingRate.TAX_CODE

                SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, AccountPayableProductionDistributionDetail.SalesTaxCode)

                If SalesTax IsNot Nothing Then

                    AccountPayableProductionDistributionDetail.IsResaleTax = SalesTax.Resale.GetValueOrDefault(0)

                    AccountPayableProductionDistributionDetail.AccountPayableProduction.StateTaxPercent = SalesTax.StatePercent.GetValueOrDefault(0)
                    AccountPayableProductionDistributionDetail.AccountPayableProduction.CityTaxPercent = SalesTax.CityPercent.GetValueOrDefault(0)
                    AccountPayableProductionDistributionDetail.AccountPayableProduction.CountyTaxPercent = SalesTax.CountyPercent.GetValueOrDefault(0)

                Else

                    AccountPayableProductionDistributionDetail.ClearSalesTax()

                End If

            End If

            AccountPayableProductionDistributionDetail.IsNonBillable = BillingRate.NOBILL_FLAG
            AccountPayableProductionDistributionDetail.CommissionPercent = BillingRate.COMM
            AccountPayableProductionDistributionDetail.TaxCommissions = BillingRate.TAX_COMM
            AccountPayableProductionDistributionDetail.TaxCommissionsOnly = BillingRate.TAX_COMM_ONLY

            If BillingRate.NOBILL_FLAG = 1 Then

                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, AccountPayableProductionDistributionDetail.FunctionCode)

                If [Function] IsNot Nothing Then

                    If [Function].NonBillableClientGLACode Is Nothing Then

                        AccountPayableProductionDistributionDetail.OfficeCode = Nothing
                        AccountPayableProductionDistributionDetail.GLACode = Nothing
                        AccountPayableProductionDistributionDetail.GLADescription = Nothing

                    Else

                        If String.IsNullOrWhiteSpace(AccountPayableProductionDistributionDetail.OfficeCode) = False Then

                            GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, AccountPayableProductionDistributionDetail.OfficeCode)

                            If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                GeneralLedgerAccount = AdvantageFramework.GeneralLedger.SubstituteOfficeSegment(DbContext, [Function].NonBillableClientGLACode, GeneralLedgerOfficeCrossReference.Code)

                                If GeneralLedgerAccount IsNot Nothing Then

                                    AccountPayableProductionDistributionDetail.GLACode = GeneralLedgerAccount.Code

                                End If

                            Else

                                AccountPayableProductionDistributionDetail.GLACode = [Function].NonBillableClientGLACode

                            End If

                        Else

                            AccountPayableProductionDistributionDetail.OfficeCode = Nothing
                            AccountPayableProductionDistributionDetail.GLACode = [Function].NonBillableClientGLACode
                            AccountPayableProductionDistributionDetail.GLADescription = Nothing

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, AccountPayableProductionDistributionDetail.GLACode)

                        End If

                        If GeneralLedgerAccount IsNot Nothing Then

                            AccountPayableProductionDistributionDetail.GLADescription = GeneralLedgerAccount.Description

                            If GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode)

                            Else

                                Office = AdvantageFramework.Database.Procedures.Office.Load(DbContext).FirstOrDefault

                            End If

                            If Office IsNot Nothing Then

                                AccountPayableProductionDistributionDetail.OfficeCode = Office.Code

                            End If

                        End If

                    End If

                End If

            End If

            If AccountPayableProductionDistributionDetail.IsNonBillable.GetValueOrDefault(0) = 0 AndAlso AccountPayableProductionDistributionDetail.JobNumber IsNot Nothing Then

                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, AccountPayableProductionDistributionDetail.JobNumber)

                If Job IsNot Nothing AndAlso Job.Office IsNot Nothing Then

                    AccountPayableProductionDistributionDetail.OfficeCode = Job.Office.Code
                    AccountPayableProductionDistributionDetail.GLACode = Job.Office.ProductionWorkInProgressGLACode
                    AccountPayableProductionDistributionDetail.GLADescription = AdvantageFramework.AccountPayable.GetGeneralLedgerAccountDescription(DbContext, AccountPayableProductionDistributionDetail.GLACode)

                End If

            End If

        End Sub
        Public Shared Sub SetValuesFromPODetail(ByRef AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail,
                                                ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail,
                                                ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                CurrencyRate As Decimal)

            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing

            AccountPayableProductionDistributionDetail.CurrencyRate = CurrencyRate

            AccountPayableProductionDistributionDetail.PONumber = PurchaseOrderDetail.PurchaseOrderNumber
            AccountPayableProductionDistributionDetail.PODetailLineNumber = PurchaseOrderDetail.LineNumber
            AccountPayableProductionDistributionDetail.POComplete = 1
            AccountPayableProductionDistributionDetail.ClientCode = PurchaseOrderDetail.Job.ClientCode
            AccountPayableProductionDistributionDetail.DivisionCode = PurchaseOrderDetail.Job.DivisionCode
            AccountPayableProductionDistributionDetail.ProductCode = PurchaseOrderDetail.Job.ProductCode
            AccountPayableProductionDistributionDetail.JobNumber = PurchaseOrderDetail.JobNumber
            AccountPayableProductionDistributionDetail.JobDescription = PurchaseOrderDetail.Job.Description
            AccountPayableProductionDistributionDetail.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber
            AccountPayableProductionDistributionDetail.JobCompDescription = PurchaseOrderDetail.JobComponent.Description
            AccountPayableProductionDistributionDetail.IsAdvanceBilling = If(PurchaseOrderDetail.JobComponent.IsAdvanceBilling.GetValueOrDefault(0) = 0, 0, 2)

            If PurchaseOrderDetail.FunctionCode IsNot Nothing Then

                AccountPayableProductionDistributionDetail.FunctionCode = PurchaseOrderDetail.FunctionCode.Trim

                If PurchaseOrderDetail.Function IsNot Nothing Then

                    AccountPayableProductionDistributionDetail.FunctionDescription = PurchaseOrderDetail.Function.Description

                End If

            End If

            AccountPayableProductionDistributionDetail.Rate = PurchaseOrderDetail.Rate
            AccountPayableProductionDistributionDetail.Quantity = PurchaseOrderDetail.Quantity

            If PurchaseOrderDetail.Job IsNot Nothing AndAlso PurchaseOrderDetail.Job.OfficeCode IsNot Nothing Then

                AccountPayableProductionDistributionDetail.OfficeCode = PurchaseOrderDetail.Job.OfficeCode

            End If

            AccountPayableProductionDistributionDetail.ExtendedMarkupAmount = PurchaseOrderDetail.ExtendedMarkupAmount

            BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, PurchaseOrderDetail.FunctionCode, PurchaseOrderDetail.Job.ClientCode, PurchaseOrderDetail.Job.DivisionCode, PurchaseOrderDetail.Job.ProductCode, PurchaseOrderDetail.JobNumber, PurchaseOrderDetail.JobComponentNumber, PurchaseOrderDetail.Job.SalesClassCode, Nothing, Nothing)

            If BillingRate IsNot Nothing Then

                AccountPayableProductionDistributionDetail.TaxCommissions = BillingRate.TAX_COMM
                AccountPayableProductionDistributionDetail.TaxCommissionsOnly = BillingRate.TAX_COMM_ONLY
                AccountPayableProductionDistributionDetail.CommissionPercent = BillingRate.COMM
                AccountPayableProductionDistributionDetail.IsNonBillable = BillingRate.NOBILL_FLAG
                AccountPayableProductionDistributionDetail.SalesTaxCode = BillingRate.TAX_CODE

            End If

            ProcessBillingRate(BillingRate, DbContext, AccountPayableProductionDistributionDetail, True)

            AccountPayableProductionDistributionDetail.POAmount = PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0)

            AccountPayableProductionDistributionDetail.POBalance = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculatePOBalance(DbContext, PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0), PurchaseOrderDetail.PurchaseOrderNumber, PurchaseOrderDetail.LineNumber)

            AccountPayableProductionDistributionDetail.ExtendedAmount = AccountPayableProductionDistributionDetail.POBalance

            AccountPayableProductionDistributionDetail.Comment = PurchaseOrderDetail.LineDescription

            AccountPayableProductionDistributionDetail.SetForeignCurrencyAmounts()

        End Sub
        Public Shared Function CalculatePOBalance(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal POAmount As Decimal, ByVal PONumber As Integer, ByVal PODetailLineNumber As Short) As Decimal

            Dim SumOfAmountApplied As Decimal = 0
            Dim Balance As Decimal = 0

            Try

                SumOfAmountApplied = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext)
                                      Where Entity.PONumber = PONumber AndAlso
                                            Entity.PODetailLineNumber = PODetailLineNumber AndAlso
                                            Entity.ExtendedAmount.HasValue AndAlso
                                            (Entity.ModifyDelete Is Nothing OrElse
                                             Entity.ModifyDelete = 0)
                                      Select Entity).ToList.Sum(Function(APP) APP.ExtendedAmount)

            Catch ex As Exception
                SumOfAmountApplied = 0
            End Try

            Balance = POAmount - SumOfAmountApplied

            CalculatePOBalance = Balance

        End Function
        Public Shared Sub CalculateTax(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction)

            Dim StateTax As Decimal = 0
            Dim CountyTax As Decimal = 0
            Dim CityTax As Decimal = 0
            Dim TaxableAmount As Decimal = 0

            If AccountPayableProduction.IsResaleTax.GetValueOrDefault(0) = 1 Then

                If AccountPayableProduction.TaxCommissionsOnly.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0)

                ElseIf AccountPayableProduction.TaxCommissions.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0) + AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0)

                Else

                    TaxableAmount = AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0)

                End If

                StateTax = Format(AccountPayableProduction.StateTaxPercent.GetValueOrDefault(0) * TaxableAmount / 100, "#0.00")
                CountyTax = Format(AccountPayableProduction.CountyTaxPercent.GetValueOrDefault(0) * TaxableAmount / 100, "#0.00")
                CityTax = Format(AccountPayableProduction.CityTaxPercent.GetValueOrDefault(0) * TaxableAmount / 100, "#0.00")

                AccountPayableProduction.IsResaleTax = 1
                AccountPayableProduction.ExtendedStateResale = StateTax
                AccountPayableProduction.ExtendedCountyResale = CountyTax
                AccountPayableProduction.ExtendedCityResale = CityTax

                AccountPayableProduction.ExtendedNonResaleTax = 0

            Else 'vendor tax

                If AccountPayableProduction.TaxCommissionsOnly.GetValueOrDefault(0) = 1 Then

                    If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) = False Then

                        StateTax = Format(AccountPayableProduction.StateTaxPercent.GetValueOrDefault(0) * AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, "#0.00")
                        CountyTax = Format(AccountPayableProduction.CountyTaxPercent.GetValueOrDefault(0) * AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, "#0.00")
                        CityTax = Format(AccountPayableProduction.CityTaxPercent.GetValueOrDefault(0) * AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, "#0.00")

                    End If

                    AccountPayableProduction.ExtendedNonResaleTax = 0

                ElseIf AccountPayableProduction.TaxCommissions.GetValueOrDefault(0) = 1 Then

                    If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) = False Then

                        StateTax = Format(AccountPayableProduction.StateTaxPercent.GetValueOrDefault(0) * AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, "#0.00")
                        CountyTax = Format(AccountPayableProduction.CountyTaxPercent.GetValueOrDefault(0) * AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, "#0.00")
                        CityTax = Format(AccountPayableProduction.CityTaxPercent.GetValueOrDefault(0) * AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, "#0.00")

                    End If

                    AccountPayableProduction.ExtendedNonResaleTax = Format((AccountPayableProduction.StateTaxPercent.GetValueOrDefault(0) + AccountPayableProduction.CountyTaxPercent.GetValueOrDefault(0) +
                                                                            AccountPayableProduction.CityTaxPercent.GetValueOrDefault(0)) * AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0) / 100, "#0.00")

                Else

                    AccountPayableProduction.ExtendedNonResaleTax = Format((AccountPayableProduction.StateTaxPercent.GetValueOrDefault(0) + AccountPayableProduction.CountyTaxPercent.GetValueOrDefault(0) +
                                                                            AccountPayableProduction.CityTaxPercent.GetValueOrDefault(0)) * AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0) / 100, "#0.00")

                End If

                AccountPayableProduction.IsResaleTax = 0
                AccountPayableProduction.ExtendedStateResale = StateTax
                AccountPayableProduction.ExtendedCountyResale = CountyTax
                AccountPayableProduction.ExtendedCityResale = CityTax

            End If

        End Sub
        Public Shared Sub CalculateTaxForTransfer(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesTaxCode As String,
                                                  ByRef AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction,
                                                  ByVal HasVendorTax As Boolean, ByVal TotalVendorTaxPercent As Decimal)
            'objects
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim TaxableAmount As Decimal = 0

            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, SalesTaxCode)

            If SalesTax IsNot Nothing Then

                AccountPayableProduction.IsResaleTax = SalesTax.Resale.GetValueOrDefault(0)
                AccountPayableProduction.CityTaxPercent = SalesTax.CityPercent
                AccountPayableProduction.CountyTaxPercent = SalesTax.CountyPercent
                AccountPayableProduction.StateTaxPercent = SalesTax.StatePercent

            Else

                AccountPayableProduction.IsResaleTax = 0
                AccountPayableProduction.StateTaxPercent = 0
                AccountPayableProduction.CountyTaxPercent = 0
                AccountPayableProduction.CityTaxPercent = 0

                AccountPayableProduction.ExtendedStateResale = 0
                AccountPayableProduction.ExtendedCountyResale = 0
                AccountPayableProduction.ExtendedCityResale = 0

            End If

            If HasVendorTax AndAlso TotalVendorTaxPercent > 0 Then

                AccountPayableProduction.ExtendedNonResaleTax = FormatNumber(TotalVendorTaxPercent * AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0) / 100, 2)

            End If

            If AccountPayableProduction.IsResaleTax.GetValueOrDefault(0) = 1 Then

                If AccountPayableProduction.TaxCommissionsOnly.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0)

                ElseIf AccountPayableProduction.TaxCommissions.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) + AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0)

                Else

                    TaxableAmount = AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0)

                End If

            Else

                If AccountPayableProduction.TaxCommissionsOnly.GetValueOrDefault(0) = 1 OrElse AccountPayableProduction.TaxCommissions.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0)

                End If

            End If

            AccountPayableProduction.ExtendedStateResale = FormatNumber(AccountPayableProduction.StateTaxPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)
            AccountPayableProduction.ExtendedCountyResale = FormatNumber(AccountPayableProduction.CountyTaxPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)
            AccountPayableProduction.ExtendedCityResale = FormatNumber(AccountPayableProduction.CityTaxPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)

        End Sub
        Private Sub SetZeroValues()

            _AccountPayableProduction.StateTaxPercent = 0
            _AccountPayableProduction.CountyTaxPercent = 0
            _AccountPayableProduction.CityTaxPercent = 0
            _AccountPayableProduction.TaxCommissions = 0
            _AccountPayableProduction.TaxCommissionsOnly = 0
            _AccountPayableProduction.ExtendedStateResale = 0
            _AccountPayableProduction.ExtendedCountyResale = 0
            _AccountPayableProduction.ExtendedCityResale = 0
            _AccountPayableProduction.ExtendedNonResaleTax = 0
            _AccountPayableProduction.ExtendedAmountForeign = 0
            _AccountPayableProduction.NonResidentTaxForeign = 0
            _AccountPayableProduction.RateForeign = 0
            _AccountPayableProduction.AmountExchange = 0

        End Sub
        Private Sub SetValues(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Job As AdvantageFramework.Database.Entities.Job,
                              ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent, ByVal GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim AccountPayableProductionComment As AdvantageFramework.Database.Entities.AccountPayableProductionComment = Nothing

            _ClientCode = Job.ClientCode
            _DivisionCode = Job.DivisionCode
            _ProductCode = Job.ProductCode
            _IsOpen = Job.IsOpen.GetValueOrDefault(1)

            _JobNumber = Job.Number
            _JobDescription = Job.Description
            _JobComponentNumber = JobComponent.Number
            _JobCompDescription = JobComponent.Description

            _GLADescription = GeneralLedgerAccount.Description

            If AccountPayableProduction.PONumber IsNot Nothing AndAlso AccountPayableProduction.PODetailLineNumber IsNot Nothing Then

                PurchaseOrderDetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, AccountPayableProduction.PONumber, AccountPayableProduction.PODetailLineNumber)

            End If

            If PurchaseOrderDetail IsNot Nothing Then

                _POAmount = PurchaseOrderDetail.ExtendedAmount
                _POBalance = CalculatePOBalance(DbContext, PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0), AccountPayableProduction.PONumber, AccountPayableProduction.PODetailLineNumber)

            Else

                _POAmount = Nothing
                _POBalance = Nothing

            End If

            AccountPayableProductionComment = AdvantageFramework.Database.Procedures.AccountPayableProductionComment.LoadByAccountPayableIDLineNumber(DbContext, AccountPayableProduction.AccountPayableID, AccountPayableProduction.LineNumber)

            If AccountPayableProductionComment IsNot Nothing Then

                _Comment = AccountPayableProductionComment.Comment

            End If

        End Sub
        Public Sub New(Session As AdvantageFramework.Security.Session)

            _Session = Session

            _AccountPayableProduction = New AdvantageFramework.Database.Entities.AccountPayableProduction
            SetZeroValues()

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem,
                       Session As AdvantageFramework.Security.Session)

            Me.New(Session)

            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            _AccountPayableProduction = New AdvantageFramework.Database.Entities.AccountPayableProduction
            SetZeroValues()

            _AccountPayableProduction.ExpenseReportDetailID = AccountPayableExpenseReportItem.ExpenseReportDetailID

            _Comment = AccountPayableExpenseReportItem.APComment

            _JobNumber = AccountPayableExpenseReportItem.JobNumber
            _JobComponentNumber = AccountPayableExpenseReportItem.JobComponentNumber

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobComponentNumber)

            Me.IsAdvanceBilling = If(JobComponent.IsAdvanceBilling.GetValueOrDefault(0) = 0, 0, 2)

            Me.ClientCode = JobComponent.Job.ClientCode
            Me.DivisionCode = JobComponent.Job.DivisionCode
            Me.ProductCode = JobComponent.Job.ProductCode

            If AccountPayableExpenseReportItem.FunctionCode IsNot Nothing Then

                Me.FunctionCode = AccountPayableExpenseReportItem.FunctionCode

            End If

            Me.ExtendedAmount = AccountPayableExpenseReportItem.Amount

            Me.Quantity = AccountPayableExpenseReportItem.Quantity

            If AccountPayableExpenseReportItem.Rate IsNot Nothing Then

                Me.Rate = FormatNumber(AccountPayableExpenseReportItem.Rate, 3)

            End If

            Me.GLACode = AccountPayableExpenseReportItem.GLACode
            Me.OfficeCode = AccountPayableExpenseReportItem.OfficeCode

            Me.IsNonBillable = AccountPayableExpenseReportItem.IsNonbillable
            Me.CommissionPercent = AccountPayableExpenseReportItem.CommissionPercent
            Me.TaxCommissions = AccountPayableExpenseReportItem.TaxCommissions
            Me.TaxCommissionsOnly = AccountPayableExpenseReportItem.TaxCommissionsOnly
            Me.SalesTaxCode = AccountPayableExpenseReportItem.SalesTaxCode

            Me.ExtendedMarkupAmount = FormatNumber(Me.CommissionPercent * Me.ExtendedAmount / 100, 2)

            If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) Then 'AndAlso AdvantageFramework.Database.Procedures.SalesTax.IsResaleTax(DbContext, BillingRate.TAX_CODE) Then

                Me.SalesTaxCode = Nothing

            End If

            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Me.SalesTaxCode)

            If SalesTax IsNot Nothing Then

                Me.IsResaleTax = SalesTax.Resale.GetValueOrDefault(0)
                Me.AccountPayableProduction.StateTaxPercent = SalesTax.StatePercent.GetValueOrDefault(0)
                Me.AccountPayableProduction.CityTaxPercent = SalesTax.CityPercent.GetValueOrDefault(0)
                Me.AccountPayableProduction.CountyTaxPercent = SalesTax.CountyPercent.GetValueOrDefault(0)

                CalculateTax(DbContext, Me.AccountPayableProduction)

                If SalesTax.Resale.GetValueOrDefault(0) = 0 Then

                    Me.ExtendedNonResaleTax = 0

                End If

            Else

                Me.IsResaleTax = 0

                Me.AccountPayableProduction.StateTaxPercent = 0
                Me.AccountPayableProduction.CountyTaxPercent = 0
                Me.AccountPayableProduction.CityTaxPercent = 0

                Me.AccountPayableProduction.ExtendedNonResaleTax = 0
                Me.AccountPayableProduction.ExtendedStateResale = 0
                Me.AccountPayableProduction.ExtendedCountyResale = 0
                Me.AccountPayableProduction.ExtendedCityResale = 0

                ExtendedNonResaleTax = 0

            End If

            'defaults
            _AccountPayableProduction.ExtendedAmountForeign = 0
            _AccountPayableProduction.RateForeign = 0
            _AccountPayableProduction.NonResidentTaxForeign = 0
            _AccountPayableProduction.AmountExchange = 0

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob,
                       Session As AdvantageFramework.Security.Session)

            Me.New(Session)

            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            _AccountPayableProduction = New AdvantageFramework.Database.Entities.AccountPayableProduction
            SetZeroValues()

            _Comment = ImportAccountPayableJob.JobComment

            If ImportAccountPayableJob.PONumber IsNot Nothing Then

                Me.PONumber = ImportAccountPayableJob.PONumber
                Me.PODetailLineNumber = ImportAccountPayableJob.POLine
                Me.POComplete = 1

            End If

            Me.ClientCode = ImportAccountPayableJob.ClientCode
            Me.DivisionCode = ImportAccountPayableJob.DivisionCode
            Me.ProductCode = ImportAccountPayableJob.ProductCode
            Me.OfficeCode = ImportAccountPayableJob.OfficeCodeDetail

            _JobNumber = ImportAccountPayableJob.JobNumber
            _JobComponentNumber = ImportAccountPayableJob.JobComponentNumber
            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobComponentNumber)
            Me.IsAdvanceBilling = If(JobComponent.IsAdvanceBilling.GetValueOrDefault(0) = 0, 0, 2)

            Me.FunctionCode = ImportAccountPayableJob.FunctionCode
            Me.ExtendedAmount = ImportAccountPayableJob.JobNetAmount
            Me.Quantity = ImportAccountPayableJob.JobQuantity

            Me.IsNonBillable = ImportAccountPayableJob.IsNonBillable.GetValueOrDefault(0)
            Me.CommissionPercent = ImportAccountPayableJob.CommissionPercent.GetValueOrDefault(0)
            Me.TaxCommissions = ImportAccountPayableJob.TaxCommission.GetValueOrDefault(0)
            Me.TaxCommissionsOnly = ImportAccountPayableJob.TaxCommissionOnly.GetValueOrDefault(0)
            Me.SalesTaxCode = ImportAccountPayableJob.SalesTaxCode
            Me.Rate = ImportAccountPayableJob.Rate
            Me.GLACode = ImportAccountPayableJob.GLACode

            CalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Amount, Me, DbContext)

            Me.ExtendedMarkupAmount = FormatNumber(Me.CommissionPercent.GetValueOrDefault(0) * Me.ExtendedAmount.GetValueOrDefault(0) / 100, 2)

            If Not String.IsNullOrEmpty(Me.SalesTaxCode) Then

                If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) AndAlso AdvantageFramework.Database.Procedures.SalesTax.IsResaleTax(DbContext, Me.SalesTaxCode) Then

                    Me.SalesTaxCode = Nothing

                End If

            End If

            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Me.SalesTaxCode)

            If SalesTax IsNot Nothing Then

                Me.IsResaleTax = SalesTax.Resale.GetValueOrDefault(0)
                Me.AccountPayableProduction.StateTaxPercent = SalesTax.StatePercent.GetValueOrDefault(0)
                Me.AccountPayableProduction.CityTaxPercent = SalesTax.CityPercent.GetValueOrDefault(0)
                Me.AccountPayableProduction.CountyTaxPercent = SalesTax.CountyPercent.GetValueOrDefault(0)

                CalculateTax(DbContext, Me.AccountPayableProduction)

            Else

                Me.IsResaleTax = 0

                Me.AccountPayableProduction.StateTaxPercent = 0
                Me.AccountPayableProduction.CountyTaxPercent = 0
                Me.AccountPayableProduction.CityTaxPercent = 0

                Me.AccountPayableProduction.ExtendedNonResaleTax = 0
                Me.AccountPayableProduction.ExtendedStateResale = 0
                Me.AccountPayableProduction.ExtendedCountyResale = 0
                Me.AccountPayableProduction.ExtendedCityResale = 0

            End If

            Me.ExtendedNonResaleTax = ImportAccountPayableJob.JobVendorTax.GetValueOrDefault(0)

            'defaults
            _AccountPayableProduction.ExtendedAmountForeign = 0
            _AccountPayableProduction.RateForeign = 0
            _AccountPayableProduction.NonResidentTaxForeign = 0
            _AccountPayableProduction.AmountExchange = 0

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction,
                       Session As AdvantageFramework.Security.Session)

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing

            _Session = Session

            _AccountPayableProduction = AccountPayableProduction

            If AccountPayableProduction.Function IsNot Nothing Then

                Me.FunctionDescription = AccountPayableProduction.Function.Description

            End If

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableProduction.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            _CurrencyRate = If(AccountPayable.CurrencyRate.HasValue AndAlso AccountPayable.CurrencyRate = 0, 1, AccountPayable.CurrencyRate.GetValueOrDefault(1))

            SetForeignCurrencyAmounts()

            SetValues(DbContext, AccountPayableProduction.Job, AccountPayableProduction.JobComponent, AccountPayableProduction.GeneralLedgerAccount)

        End Sub
        Private Sub SetForeignCurrencyAmounts()

            _ForeignRate = AccountPayableProduction.Rate.GetValueOrDefault(0) / _CurrencyRate
            _ForeignExtendedAmount = AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0) / _CurrencyRate
            _ForeignExtendedNonResaleTax = AccountPayableProduction.ExtendedNonResaleTax.GetValueOrDefault(0) / _CurrencyRate
            '_ForeignExtendedMarkupAmount = AccountPayableProduction.ExtendedMarkupAmount.GetValueOrDefault(0) / _CurrencyRate

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail,
                       CurrencyRate As Decimal, Session As AdvantageFramework.Security.Session)

            Me.New(Session)

            _AccountPayableProduction = New AdvantageFramework.Database.Entities.AccountPayableProduction
            SetZeroValues()

            SetValuesFromPODetail(Me, PurchaseOrderDetail, DbContext, CurrencyRate)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.IsOpen.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If PropertyValue = 0 Then

                            IsValid = True

                            ErrorText = "The job/component has been flagged closed.  You cannot modify this line."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.IsAdvanceBilling.ToString

                    PropertyValue = Value

                    If PropertyValue = 1 Then

                        IsValid = True

                        ErrorText = "Item has been selected to be Included in an Advance Billing. Changes or deletion not allowed."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.AccountReceivableInvoiceNumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        IsValid = True

                        ErrorText = "Item has been billed."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.GLACode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.IsNonBillable.GetValueOrDefault(0) = 1 Then

                        If (From Entity In AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, Me.OfficeCode, _Session)
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid GL Account."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.BillingCommandCenterID.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        IsValid = True

                        ErrorText = "The job/component has been selected for review in BCC.  You cannot modify this line."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

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

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.PODetailLineNumber.ToString

                        If Me.PONumber IsNot Nothing Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Disbursed.ToString

                        If Me.Quantity.GetValueOrDefault(0) = 0 AndAlso Me.ExtendedAmount.GetValueOrDefault(0) = 0 AndAlso Me.ExtendedNonResaleTax.GetValueOrDefault(0) = 0 AndAlso
                                Me.ResaleTax = 0 Then

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Disbursed.ToString, True)

                        Else

                            SetRequired(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.Properties.Disbursed.ToString, False)

                        End If

                End Select

            Next

        End Sub
        Public Sub ClearSalesTax()

            Me.SalesTaxCode = Nothing

            Me.IsResaleTax = 0

            Me.AccountPayableProduction.ExtendedStateResale = 0
            Me.AccountPayableProduction.ExtendedCountyResale = 0
            Me.AccountPayableProduction.ExtendedCityResale = 0

            Me.AccountPayableProduction.CityTaxPercent = 0
            Me.AccountPayableProduction.CountyTaxPercent = 0
            Me.AccountPayableProduction.StateTaxPercent = 0

        End Sub
        Public Sub SetValuesFromAccountPayableProduction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction)

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            _AccountPayableProduction = AccountPayableProduction

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, AccountPayableProduction.JobNumber)
            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, AccountPayableProduction.JobNumber, AccountPayableProduction.JobComponentNumber)
            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, AccountPayableProduction.GLACode)

            SetValues(DbContext, Job, JobComponent, GeneralLedgerAccount)

        End Sub

#End Region

    End Class

End Namespace

