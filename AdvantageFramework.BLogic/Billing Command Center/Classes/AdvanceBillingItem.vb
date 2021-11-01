Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class AdvanceBillingItem
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FunctionCode
            FunctionDescription
            FunctionType
            QuantityHours
            Rate
            NetAmount
            MarkupPercent
            ExtendedMarkupAmount
            Amount
            SalesTaxCode
            IsResaleTax
            ExtendedNonResaleTax
            TotalAdvance
            ResaleTax
            LineTotal
            IsDeleted
            PriorBilled
            PriorIncomeRec
            AmountToRecognize
            CreateDate
        End Enum

#End Region

#Region " Variables "

        Private _AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionType As String = Nothing
        Private _IsDeleted As Boolean = False
        Private _IncomeRecognize As AdvantageFramework.Database.Entities.IncomeRecognize = Nothing
        Private _PriorIncomeRec As Decimal = Nothing
        Private _BillingIncomeIsInitialBilling As Boolean = False
        Private _PriorBilled As Decimal = Nothing
        Private _FunctionIsRequired As Boolean = False
        Private _WasPreviouslyBilled As Boolean = False
        Private _MultipleUnbilledRecordsExist As Boolean = False
        Private _IsNonBillable As Boolean = False

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling
            Get
                AdvanceBilling = _AdvanceBilling
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property IncomeRecognize As AdvantageFramework.Database.Entities.IncomeRecognize
            Get
                IncomeRecognize = _IncomeRecognize
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Qty/Hours")>
        Public Property QuantityHours() As Nullable(Of Decimal)
            Get
                QuantityHours = _AdvanceBilling.QuantityHours
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilling.QuantityHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _AdvanceBilling.Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilling.Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _AdvanceBilling.NetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilling.NetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup %")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
            Get
                MarkupPercent = _AdvanceBilling.MarkupPercent.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilling.MarkupPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Markup Amount")>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
            Get
                ExtendedMarkupAmount = _AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilling.ExtendedMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _AdvanceBilling.NetAmount.GetValueOrDefault(0) + _AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Tax Code", PropertyType:=BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property SalesTaxCode() As String
            Get
                SalesTaxCode = _AdvanceBilling.SalesTaxCode
            End Get
            Set(value As String)
                _AdvanceBilling.SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsResaleTax As Nullable(Of Short)
            Get
                IsResaleTax = _AdvanceBilling.IsResaleTax
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AdvanceBilling.IsResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Non Resale Tax")>
        Public Property ExtendedNonResaleTax As Nullable(Of Decimal)
            Get
                ExtendedNonResaleTax = _AdvanceBilling.ExtendedNonResaleTax.GetValueOrDefault(0)
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AdvanceBilling.ExtendedNonResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property TotalAdvance As Nullable(Of Decimal)
            Get
                TotalAdvance = _AdvanceBilling.NetAmount.GetValueOrDefault(0) + _AdvanceBilling.ExtendedNonResaleTax.GetValueOrDefault(0) + _AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property ResaleTax As Nullable(Of Decimal)
            Get
                If _AdvanceBilling.ExtendedStateResale IsNot Nothing AndAlso _AdvanceBilling.ExtendedCountyResale IsNot Nothing AndAlso _AdvanceBilling.ExtendedCityResale IsNot Nothing Then

                    ResaleTax = _AdvanceBilling.ExtendedStateResale.GetValueOrDefault(0) + _AdvanceBilling.ExtendedCountyResale.GetValueOrDefault(0) + _AdvanceBilling.ExtendedCityResale.GetValueOrDefault(0)

                Else

                    ResaleTax = 0

                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total Advance with Tax", IsReadOnlyColumn:=True)>
        Public Property LineTotal As Nullable(Of Decimal)
            Get
                LineTotal = _AdvanceBilling.LineTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilling.LineTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Prior Advance", IsReadOnlyColumn:=True)>
        Public Property PriorBilled As Decimal
            Get
                PriorBilled = _PriorBilled
            End Get
            Set(value As Decimal)
                _PriorBilled = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property PriorIncomeRec As Decimal
            Get
                PriorIncomeRec = _PriorIncomeRec
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AmountToRecognize As Nullable(Of Decimal)
            Get
                AmountToRecognize = _IncomeRecognize.Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _IncomeRecognize.Amount = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property BillingIncomeIsInitialBilling() As Boolean
            Get
                BillingIncomeIsInitialBilling = _BillingIncomeIsInitialBilling
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property WasPreviouslyBilled() As Boolean
            Get
                WasPreviouslyBilled = _WasPreviouslyBilled
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MultipleUnbilledRecordsExist() As Boolean
            Get
                MultipleUnbilledRecordsExist = _MultipleUnbilledRecordsExist
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property IsNonBillable() As Boolean
            Get
                IsNonBillable = _IsNonBillable
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property CreateDate() As Nullable(Of Date)
            Get
                CreateDate = _AdvanceBilling.CreateDate
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _AdvanceBilling = New AdvantageFramework.Database.Entities.AdvanceBilling
            _IncomeRecognize = New AdvantageFramework.Database.Entities.IncomeRecognize

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext,
                       ByVal FunctionCode As String, ByVal FunctionCore As AdvantageFramework.Database.Core.Function,
                       ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            Dim AdvanceBillings As IEnumerable(Of AdvantageFramework.Database.Entities.AdvanceBilling) = Nothing
            Dim IncomeRecognizes As IEnumerable(Of AdvantageFramework.Database.Entities.IncomeRecognize) = Nothing

            _FunctionCode = FunctionCode

            If FunctionCore IsNot Nothing Then

                _FunctionDescription = FunctionCore.Description
                _FunctionType = FunctionCore.Type

            End If

            _MultipleUnbilledRecordsExist = (From AB In AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext)
                                             Where AB.JobNumber = JobNumber AndAlso
                                                   AB.JobComponentNumber = JobComponentNumber AndAlso
                                                   AB.FunctionCode = FunctionCode AndAlso
                                                   AB.ARInvoiceNumber Is Nothing AndAlso
                                                   AB.AdvanceBillFlag <> 4 AndAlso
                                                   AB.AdvanceBillFlag <> 5 AndAlso
                                                   AB.AdvanceBillFlag <> 6
                                             Select AB).Count > 1

            AdvanceBillings = (From AB In AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext)
                               Where AB.JobNumber = JobNumber AndAlso
                                     AB.JobComponentNumber = JobComponentNumber AndAlso
                                     AB.FunctionCode = FunctionCode AndAlso
                                     AB.ARInvoiceNumber IsNot Nothing
                               Select AB).ToList

            _PriorBilled = AdvanceBillings.Where(Function(AB) AB.AdvanceBillFlag <> 5).Sum(Function(AB) AB.ExtendedMarkupAmount.GetValueOrDefault(0) + AB.NetAmount.GetValueOrDefault(0) + AB.ExtendedNonResaleTax.GetValueOrDefault(0))

            IncomeRecognizes = (From IR In AdvantageFramework.Database.Procedures.IncomeRecognize.Load(DbContext)
                                Where IR.JobNumber = JobNumber AndAlso
                                      IR.JobComponentNumber = JobComponentNumber AndAlso
                                      IR.FunctionCode = FunctionCode AndAlso
                                      IR.ARInvoiceNumber IsNot Nothing
                                Select IR).ToList

            _PriorIncomeRec = IncomeRecognizes.Sum(Function(IR) IR.Amount.GetValueOrDefault(0))

            _WasPreviouslyBilled = AdvanceBillings.Where(Function(AB) AB.ARInvoiceNumber IsNot Nothing AndAlso (AB.ARInvoiceIsVoided Is Nothing OrElse AB.ARInvoiceIsVoided = 0)).Count > 0 OrElse
                                    IncomeRecognizes.Where(Function(IR) IR.ARInvoiceNumber IsNot Nothing AndAlso (IR.IsVoided Is Nothing OrElse IR.IsVoided = 0)).Count > 0

            _AdvanceBilling = (From Entity In AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext)
                               Where Entity.JobNumber = JobNumber AndAlso
                                     Entity.JobComponentNumber = JobComponentNumber AndAlso
                                     Entity.FunctionCode = FunctionCode AndAlso
                                     Entity.ARInvoiceNumber Is Nothing AndAlso
                                     (Entity.AdvanceBillFlag = 1 OrElse Entity.AdvanceBillFlag = 2)
                               Select Entity).OrderByDescending(Function(AB) AB.ID).ThenByDescending(Function(AB) AB.SequenceNumber).FirstOrDefault

            If _AdvanceBilling Is Nothing Then

                _AdvanceBilling = New AdvantageFramework.Database.Entities.AdvanceBilling

                InitializeAdvanceBilling(DbContext.UserCode, JobNumber, JobComponentNumber)

                If AdvanceBillings.Where(Function(AB) AB.FunctionCode = _FunctionCode).Any Then

                    SetBillingRate(DbContext)

                End If

            End If

            _IncomeRecognize = AdvantageFramework.Database.Procedures.IncomeRecognize.LoadActiveByJobJobComponentFunction(DbContext, JobNumber, JobComponentNumber, FunctionCode)

            If _IncomeRecognize Is Nothing Then

                _IncomeRecognize = New AdvantageFramework.Database.Entities.IncomeRecognize

                InitializeIncomeRecognize(DbContext.UserCode, JobNumber, JobComponentNumber)

            ElseIf _IncomeRecognize IsNot Nothing AndAlso Me.FunctionCode IsNot Nothing Then

                SetNonBillableFlag(DbContext)

            End If

        End Sub
        Public Sub New(ByVal AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling, ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim [Function] As AdvantageFramework.Database.Core.Function = Nothing

            _AdvanceBilling = AdvanceBilling

            _FunctionCode = _AdvanceBilling.FunctionCode

            _PriorBilled = AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext) _
                .Where(Function(AB) AB.JobNumber = _AdvanceBilling.JobNumber AndAlso
                                    AB.JobComponentNumber = _AdvanceBilling.JobComponentNumber AndAlso
                                    AB.FunctionCode = _AdvanceBilling.FunctionCode AndAlso
                                    AB.ARInvoiceNumber IsNot Nothing AndAlso
                                    AB.AdvanceBillFlag <> 5).ToList.Sum(Function(AB) AB.ExtendedMarkupAmount.GetValueOrDefault(0) + AB.NetAmount.GetValueOrDefault(0) + AB.ExtendedNonResaleTax.GetValueOrDefault(0))

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, _AdvanceBilling.JobNumber, _AdvanceBilling.JobComponentNumber)

            If JobComponent IsNot Nothing AndAlso JobComponent.ProductionAdvancedBillingIncome.GetValueOrDefault(1) = AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.InitialBilling Then

                _BillingIncomeIsInitialBilling = True

            End If

            [Function] = (From Fnc In AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext)
                          Where Fnc.Code = _AdvanceBilling.FunctionCode
                          Select Fnc).SingleOrDefault

            If [Function] IsNot Nothing Then

                _FunctionDescription = [Function].Description
                _FunctionType = [Function].Type

            End If

            _IncomeRecognize = AdvantageFramework.Database.Procedures.IncomeRecognize.LoadActiveByJobJobComponentFunction(DbContext, _AdvanceBilling.JobNumber, _AdvanceBilling.JobComponentNumber, _AdvanceBilling.FunctionCode)

            If _IncomeRecognize Is Nothing Then

                _IncomeRecognize = New AdvantageFramework.Database.Entities.IncomeRecognize

                InitializeIncomeRecognize(DbContext.UserCode, _AdvanceBilling.JobNumber, _AdvanceBilling.JobComponentNumber)

            End If

            _PriorIncomeRec = (From IR In AdvantageFramework.Database.Procedures.IncomeRecognize.Load(DbContext)
                               Where IR.JobNumber = _AdvanceBilling.JobNumber AndAlso
                                     IR.JobComponentNumber = _AdvanceBilling.JobComponentNumber AndAlso
                                     IR.FunctionCode = _AdvanceBilling.FunctionCode AndAlso
                                     IR.ARInvoiceNumber IsNot Nothing
                               Select IR).ToList.Sum(Function(IR) IR.Amount.GetValueOrDefault(0))

            SetNonBillableFlag(DbContext)

        End Sub
        Public Sub ClearAdvanceBillingEntity()

            Me.QuantityHours = Nothing
            Me.Rate = Nothing
            Me.NetAmount = Nothing
            Me.MarkupPercent = Nothing
            Me.SalesTaxCode = Nothing
            Me.ExtendedMarkupAmount = Nothing
            Me.ExtendedNonResaleTax = Nothing
            Me.LineTotal = Nothing
            Me.AdvanceBilling.ExtendedCityResale = Nothing
            Me.AdvanceBilling.ExtendedCountyResale = Nothing
            Me.AdvanceBilling.ExtendedStateResale = Nothing

        End Sub
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function
        Public Sub InitializeAdvanceBilling(ByVal UserCode As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            _AdvanceBilling.DatabaseAction = AdvantageFramework.Database.Action.Inserting
            _AdvanceBilling.CreateDate = Now.ToShortDateString
            _AdvanceBilling.UserCode = UserCode
            _AdvanceBilling.BillDate = Now.ToShortDateString
            _AdvanceBilling.AdvanceBillFlag = 2
            _AdvanceBilling.UseContingency = 0
            _AdvanceBilling.JobNumber = JobNumber
            _AdvanceBilling.JobComponentNumber = JobComponentNumber

        End Sub
        Public Sub InitializeIncomeRecognize(ByVal UserCode As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            _IncomeRecognize.DatabaseAction = AdvantageFramework.Database.Action.Inserting
            _IncomeRecognize.CreateDate = Now.ToShortDateString
            _IncomeRecognize.UserCode = UserCode
            _IncomeRecognize.BillDate = Now.ToShortDateString
            _IncomeRecognize.AdvanceBillFlag = 6
            _IncomeRecognize.JobNumber = JobNumber
            _IncomeRecognize.JobComponentNumber = JobComponentNumber

        End Sub
        Public Overrides Function LoadErrorText(ByVal PropertyName As String) As String

            'objects
            Dim ErrorText As String = ""

            Try

                ErrorText = _ErrorHashtable(PropertyName)

            Catch ex As Exception
                ErrorText = ""
            Finally
                LoadErrorText = ErrorText
            End Try

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            _AdvanceBilling.FunctionCode = _FunctionCode
            _AdvanceBilling.FunctionType = _FunctionType

            _IncomeRecognize.FunctionCode = _FunctionCode

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            If Me.QuantityHours IsNot Nothing OrElse Me.Rate IsNot Nothing OrElse
                    Me.NetAmount.GetValueOrDefault(0) <> 0 OrElse Me.MarkupPercent.GetValueOrDefault(0) <> 0 OrElse Me.ExtendedMarkupAmount.GetValueOrDefault(0) <> 0 OrElse
                    Me.SalesTaxCode IsNot Nothing OrElse Me.ExtendedNonResaleTax.GetValueOrDefault(0) <> 0 Then

                SetRequired(AdvanceBillingItem.Properties.FunctionCode.ToString, True)

                _FunctionIsRequired = True

            Else

                SetRequired(AdvanceBillingItem.Properties.FunctionCode.ToString, False)

                _FunctionIsRequired = False

            End If

        End Sub
        Public Sub RefreshErrorHashtable()

            Dim ErrorString As String = Nothing

            Me.ErrorHashtable.Clear()

            For Each Key In _AdvanceBilling.ErrorHashtable.Keys

                If _AdvanceBilling.ErrorHashtable.Item(Key) <> "" AndAlso Me.ErrorHashtable.ContainsKey(Key) = False Then

                    Me.ErrorHashtable.Add(Key, _AdvanceBilling.ErrorHashtable.Item(Key))

                End If

            Next

            For Each Key In _IncomeRecognize.ErrorHashtable.Keys

                If _IncomeRecognize.ErrorHashtable.Item(Key) <> "" AndAlso Me.ErrorHashtable.ContainsKey(Key) = False Then

                    Me.ErrorHashtable.Add(Key, _IncomeRecognize.ErrorHashtable.Item(Key))

                End If

            Next

            For Each Key In Me.ErrorHashtable.Keys

                ErrorString = If(ErrorString Is Nothing, Me.ErrorHashtable.Item(Key).ToString, ErrorString + vbNewLine + Me.ErrorHashtable.Item(Key).ToString)

            Next

            _EntityError = ErrorString

        End Sub
        Private Sub ClearAdvanceBillingSalesTax()

            _AdvanceBilling.SalesTaxCode = Nothing
            _AdvanceBilling.IsResaleTax = Nothing
            _AdvanceBilling.TaxCommission = Nothing
            _AdvanceBilling.TaxCommissionOnly = Nothing
            _AdvanceBilling.CityTaxPercent = Nothing
            _AdvanceBilling.CountyTaxPercent = Nothing
            _AdvanceBilling.StateTaxPercent = Nothing

        End Sub
        Private Sub SetNonBillableFlag(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, _AdvanceBilling.JobNumber)

            If Job IsNot Nothing Then

                BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, FunctionCode, Job.ClientCode,
                                                                                Job.DivisionCode, Job.ProductCode, _AdvanceBilling.JobNumber,
                                                                                _AdvanceBilling.JobComponentNumber, Job.SalesClassCode, Nothing, Nothing)

                If BillingRate IsNot Nothing Then

                    _IsNonBillable = CBool(BillingRate.NOBILL_FLAG.GetValueOrDefault(0))

                Else

                    _IsNonBillable = False

                End If

            End If

        End Sub
        Public Sub SetBillingRate(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, _AdvanceBilling.JobNumber)

            If Job IsNot Nothing Then

                BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, FunctionCode, Job.ClientCode,
                                                                                Job.DivisionCode, Job.ProductCode, _AdvanceBilling.JobNumber,
                                                                                _AdvanceBilling.JobComponentNumber, Job.SalesClassCode, Nothing, Nothing)

                If BillingRate IsNot Nothing Then

                    _AdvanceBilling.Rate = BillingRate.BILLING_RATE
                    _IsNonBillable = CBool(BillingRate.NOBILL_FLAG.GetValueOrDefault(0))
                    _AdvanceBilling.MarkupPercent = BillingRate.COMM

                    _AdvanceBilling.SalesTaxCode = BillingRate.TAX_CODE
                    _AdvanceBilling.TaxCommission = BillingRate.TAX_COMM.GetValueOrDefault(0)
                    _AdvanceBilling.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

                    SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, _AdvanceBilling.SalesTaxCode)

                    If SalesTax IsNot Nothing Then

                        _AdvanceBilling.IsResaleTax = SalesTax.Resale.GetValueOrDefault(0)
                        _AdvanceBilling.CityTaxPercent = SalesTax.CityPercent.GetValueOrDefault(0)
                        _AdvanceBilling.CountyTaxPercent = SalesTax.CountyPercent.GetValueOrDefault(0)
                        _AdvanceBilling.StateTaxPercent = SalesTax.StatePercent.GetValueOrDefault(0)

                    Else

                        _AdvanceBilling.SalesTaxCode = Nothing
                        _AdvanceBilling.IsResaleTax = Nothing
                        _AdvanceBilling.CityTaxPercent = Nothing
                        _AdvanceBilling.CountyTaxPercent = Nothing
                        _AdvanceBilling.StateTaxPercent = Nothing

                    End If

                    If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) Then

                        If Me.FunctionType <> "V" OrElse Me.IsResaleTax.GetValueOrDefault(0) = 1 Then

                            ClearAdvanceBillingSalesTax()

                        End If

                    End If

                Else

                    _IsNonBillable = False

                    ClearAdvanceBillingSalesTax()

                End If

            End If

        End Sub
        Public Sub SetAdvanceBillingFunctionCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionCode As String)

            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            _FunctionCode = FunctionCode

            _AdvanceBilling.FunctionCode = FunctionCode

            [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCode)

            If [Function] IsNot Nothing Then

                _AdvanceBilling.FunctionType = [Function].Type
                Me.FunctionDescription = [Function].Description
                Me.FunctionType = [Function].Type

            End If

        End Sub
        Private Sub CalculateTaxValues(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling)

            Dim StateTax As Decimal = 0
            Dim CountyTax As Decimal = 0
            Dim CityTax As Decimal = 0
            Dim TaxableAmount As Decimal = 0

            If AdvanceBilling.IsResaleTax.GetValueOrDefault(0) = 1 OrElse AdvanceBilling.FunctionType = "I" OrElse AdvanceBilling.FunctionType = "E" Then

                If AdvanceBilling.TaxCommissionOnly.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0)

                ElseIf AdvanceBilling.TaxCommission.GetValueOrDefault(0) = 1 Then

                    TaxableAmount = AdvanceBilling.NetAmount.GetValueOrDefault(0) + AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0)

                Else

                    TaxableAmount = AdvanceBilling.NetAmount.GetValueOrDefault(0)

                End If

                If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) = False Then

                    StateTax = FormatNumber(AdvanceBilling.StateTaxPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)
                    CountyTax = FormatNumber(AdvanceBilling.CountyTaxPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)
                    CityTax = FormatNumber(AdvanceBilling.CityTaxPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)

                End If

                AdvanceBilling.ExtendedStateResale = StateTax
                AdvanceBilling.ExtendedCountyResale = CountyTax
                AdvanceBilling.ExtendedCityResale = CityTax

                AdvanceBilling.ExtendedNonResaleTax = 0

            Else 'vendor tax

                If AdvanceBilling.TaxCommissionOnly.GetValueOrDefault(0) = 1 Then

                    If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) = False Then

                        StateTax = FormatNumber(AdvanceBilling.StateTaxPercent.GetValueOrDefault(0) * AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, 2)
                        CountyTax = FormatNumber(AdvanceBilling.CountyTaxPercent.GetValueOrDefault(0) * AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, 2)
                        CityTax = FormatNumber(AdvanceBilling.CityTaxPercent.GetValueOrDefault(0) * AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, 2)

                    End If

                    AdvanceBilling.ExtendedNonResaleTax = 0

                ElseIf AdvanceBilling.TaxCommission.GetValueOrDefault(0) = 1 Then

                    If AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext) = False Then

                        StateTax = FormatNumber(AdvanceBilling.StateTaxPercent.GetValueOrDefault(0) * AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, 2)
                        CountyTax = FormatNumber(AdvanceBilling.CountyTaxPercent.GetValueOrDefault(0) * AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, 2)
                        CityTax = FormatNumber(AdvanceBilling.CityTaxPercent.GetValueOrDefault(0) * AdvanceBilling.ExtendedMarkupAmount.GetValueOrDefault(0) / 100, 2)

                    End If

                    AdvanceBilling.ExtendedNonResaleTax = FormatNumber((AdvanceBilling.StateTaxPercent.GetValueOrDefault(0) + AdvanceBilling.CountyTaxPercent.GetValueOrDefault(0) +
                                                                        AdvanceBilling.CityTaxPercent.GetValueOrDefault(0)) * AdvanceBilling.NetAmount.GetValueOrDefault(0) / 100, 2)

                Else

                    AdvanceBilling.ExtendedNonResaleTax = FormatNumber((AdvanceBilling.StateTaxPercent.GetValueOrDefault(0) + AdvanceBilling.CountyTaxPercent.GetValueOrDefault(0) +
                                                                        AdvanceBilling.CityTaxPercent.GetValueOrDefault(0)) * AdvanceBilling.NetAmount.GetValueOrDefault(0) / 100, 2)

                End If

                AdvanceBilling.IsResaleTax = 0
                AdvanceBilling.ExtendedStateResale = StateTax
                AdvanceBilling.ExtendedCountyResale = CountyTax
                AdvanceBilling.ExtendedCityResale = CityTax

            End If

        End Sub
        Public Sub CalculateAdvanceBilling(ByVal Session As AdvantageFramework.Security.Session,
                                           ByVal CalculateTax As Boolean,
                                           Optional ByVal BypassMarkupCalculation As Boolean = False)

            If Not BypassMarkupCalculation Then

                Me.ExtendedMarkupAmount = FormatNumber(Me.NetAmount.GetValueOrDefault(0) * Me.MarkupPercent.GetValueOrDefault(0) / 100, 2)

            ElseIf Me.NetAmount.GetValueOrDefault(0) <> 0 Then

                Me.MarkupPercent = FormatNumber(Me.ExtendedMarkupAmount.GetValueOrDefault(0) * 100 / Me.NetAmount.GetValueOrDefault(0), 3)

            End If

            If CalculateTax Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    CalculateTaxValues(DbContext, Me.AdvanceBilling)

                End Using

            End If

            Me.LineTotal = Me.NetAmount.GetValueOrDefault(0) + Me.ExtendedMarkupAmount.GetValueOrDefault(0) + Me.AdvanceBilling.ExtendedCityResale.GetValueOrDefault(0) +
                Me.AdvanceBilling.ExtendedStateResale.GetValueOrDefault(0) + Me.AdvanceBilling.ExtendedCountyResale.GetValueOrDefault(0) + Me.AdvanceBilling.ExtendedNonResaleTax.GetValueOrDefault(0)

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            'Dim EstimateRevisionDetail As AdvantageFramework.Database.Entities.EstimateRevisionDetail = Nothing

            Select Case PropertyName

                Case AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.FunctionCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso _AdvanceBilling IsNot Nothing AndAlso _FunctionIsRequired Then

                        _AdvanceBilling.DbContext = Me.DbContext
                        _AdvanceBilling.DbContext = Me.DbContext

                        ErrorText = _AdvanceBilling.ValidateCustomProperties(AdvantageFramework.Database.Entities.AdvanceBilling.Properties.FunctionCode.ToString, IsValid, PropertyValue)

                    End If

                    If IsValid AndAlso _IncomeRecognize IsNot Nothing Then

                        _IncomeRecognize.DbContext = Me.DbContext
                        _IncomeRecognize.DbContext = Me.DbContext

                        ErrorText += _IncomeRecognize.ValidateCustomProperties(AdvantageFramework.Database.Entities.IncomeRecognize.Properties.FunctionCode.ToString, IsValid, PropertyValue)

                    End If

                'Case AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.AmountToRecognize.ToString

                '    PropertyValue = Value

                '    Try

                '        EstimateRevisionDetail = (From EA In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).EstimateApprovals
                '                                  Join ERD In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).EstimateRevisionDetails
                '                                  On EA.EstimateNumber Equals ERD.EstimateNumber And
                '                                     EA.EstimateComponentNumber Equals ERD.EstimateComponentNumber And
                '                                     EA.EstimateQuoteNumber Equals ERD.EstimateQuoteNumber And
                '                                     EA.EstimateRevisionNumber Equals ERD.EstimateRevisionNumber
                '                                  Where EA.JobNumber = Me.IncomeRecognize.JobNumber AndAlso
                '                                        EA.JobComponentNumber = Me.IncomeRecognize.JobComponentNumber AndAlso
                '                                        EA.EstimateApprovalType = 2 AndAlso
                '                                        ERD.FunctionCode = Me.FunctionCode
                '                                  Select ERD).SingleOrDefault

                '    Catch ex As Exception
                '        EstimateRevisionDetail = Nothing
                '    End Try

                '    If EstimateRevisionDetail IsNot Nothing Then

                '        If (PropertyValue + Me.PriorIncomeRec) > (EstimateRevisionDetail.ExtendedAmount.GetValueOrDefault(0) + EstimateRevisionDetail.MarkupAmount.GetValueOrDefault(0) + EstimateRevisionDetail.NonResaleTaxAmount.GetValueOrDefault(0)) Then

                '            IsValid = False

                '            ErrorText = "Amount plus prior income rec cannot exceed estimate amount for function."

                '        End If

                '    End If

                Case AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.CreateDate.ToString

                    If _MultipleUnbilledRecordsExist Then

                        IsValid = True

                        ErrorText = "Multiple unbilled advance bill records exists. The last one entered is being displayed."

                    End If

                    If _IsNonBillable Then

                        IsValid = True

                        ErrorText = "Function is non billable."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        
#End Region

    End Class

End Namespace