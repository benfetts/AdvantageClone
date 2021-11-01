Namespace Reporting.Database.Classes

    <Serializable>
    Public Class JobDetailItemData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ResourceType
            JobNumber
            JobComponentNumber
            OfficeCode
            OfficeDescription
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            CampaignID
            CampaignCode
            CampaignName
            BillingBudget
            IncomeBudget
            SalesClassCode
            SalesClassDescription
            UserCode
            JobCreateDate
            JobDescription
            JobDateOpened
            RushChargesApproved
            ApprovedEstimateRequired
            Comment
            ClientReference
            BillingCoopCode
            SalesClassFormatCode
            ComplexityCode
            ComplexityDescription
            PromotionCode
            BillingComment
            LabelFromUDFTable1
            LabelFromUDFTable2
            LabelFromUDFTable3
            LabelFromUDFTable4
            LabelFromUDFTable5
            JobOpen
            JobComponent
            BillHold
            AccountExecutiveCode
            AccountExecutive
            ManagerCode
            Manager
            ComponentDateOpened
            DueDate
            StartDate
            Status
            GutPercentComplete
            AdSize
            DepartmentTeamCode
            DepartmentTeam
            MarkupPercent
            CreativeInstructions
            JobProcessControl
            ComponentDescription
            ComponentComments
            ComponentBudget
            EstimateNumber
            EstimateComponentNumber
            ClientApproved
            ClientApprovalDate
            ClientApprovedBy
            InternallyApproved
            InternalApprovalDate
            InternallyApprovedBy
            BillingUser
            AdvanceBillFlag
            DeliveryInstructions
            JobTypeCode
            JobTypeDescription
            Taxable
            TaxCode
            TaxCodeDescription
            NonBillable
            AlertGroup
            AdNumber
            AccountNumber
            AccountNumberDescription
            IncomeRecognitionMethod
            MarketCode
            MarketDescription
            ServiceFeeJob
            ServiceFeeTypeCode
            ServiceFeeTypeDescription
            Archived
            TrafficScheduleRequired
            ClientPO
            CompLabelFromUDFTable1
            CompLabelFromUDFTable2
            CompLabelFromUDFTable3
            CompLabelFromUDFTable4
            CompLabelFromUDFTable5
            JobTemplateCode
            FiscalPeriodCode
            FiscalPeriodDescription
            JobQuantity
            BlackplateVersionCode
            BlackplateVersionDesc
            BlackplateVersion2Code
            BlackplateVersion2Desc
            ClientContactCode
            ClientContactID
            BABatchID
            ClientContact
            SelectedBABatchID
            BillingCommandCenterID
            AlertAssignmentTemplate
            FunctionType
            FunctionConsolidationCode
            FunctionConsolidation
            FunctionHeading
            FunctionCode
            FunctionDescription
            ItemID
            ItemSequenceNumber
            ItemDate
            PostPeriodCode
            ItemCode
            ItemDescription
            ItemComment
            ItemExtra
            ItemDetailComment
            Hours
            Quantity
            NetAmount
            CostAmount
            ExtMarkupAmount
            NonResaleTaxAmount
            ResaleTaxAmount
            Total
            BillableLessResale
            BillableTotal
            FeeTime
            FeeTimeHours
            FeeTimeAmount
            NonBillableHours
            NonBillableQuantity
            NonBillableAmount
            BilledHours
            BilledQuantity
            BilledAmount
            BilledWithResale
            AccountsReceivablePostPeriodCode
            AccountsReceivableInvoiceNumber
            AccountsReceivableInvoiceType
            UnbilledHours
            UnbilledQuantity
            UnbilledAmount
            UnbilledAmountLessResale
            AdvanceBillFlagDetail
            IsNonBillable
            GlexActBill
            EstimateSuppliedByCode
            EstimateSuppliedBy
            EstimateHours
            EstimateHoursAmount
            EstimateQuantity
            EstimateTotalAmount
            EstimateContTotalAmount
            EstimateNonResaleTaxAmount
            EstimateResaleTaxAmount
            EstimateMarkupAmount
            EstimateCostAmount
            IsEstimateNonBillable
            EstimateFeeTime
            EstimateNetAmount
            PurchaseOrderNumber
            OpenPurchaseOrderAmount
            OpenPurchaseOrderGrossAmount
            IsNewBusiness
            Agency
            BillingApprovalHours
            BillingApprovalCostAmount
            BillingApprovalExtNetAmount
            BillingApprovalTotalAmount
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            EmployeeDefaultDepartmentCode
            EmployeeDefaultDepartmentDescription
            EmployeeTimeDepartmentCode
            EmployeeTimeDepartmentDescription
            CompletedDate
            JobProcessControlDate
            DateEntered
            DefaultRoleCode
            DefaultRole
            EmployeeOfficeCode
            EmployeeOfficeDescription
            EmployeeTitle
            IsEmployeeFreelance
            IsActiveFreelance
            EmployeeRateFrom
            ProductCategoryCode
            ProductCategoryDescription
            DirectHoursGoalPercent
            ClientType1Code
            ClientType1Description
            ClientType2Code
            ClientType2Description
            ClientType3Code
            ClientType3Description
            CurrentHours
            CurrentHoursAmount
            CurrentIncomeOnlyCharges
            CurrentVendorCharges
            CurrentTotal
            PriorHours
            PriorHoursAmount
            PriorIncomeOnlyCharges
            PriorVendorCharges
            PriorTotal
            PriorYearHours
            PriorYearHoursAmount
            PriorYearIncomeOnlyCharges
            PriorYearVendorCharges
            PriorYearTotal
            TotalToDateHours
            TotalToDateHoursAmount
            TotalToDateIncomeOnlyCharges
            TotalToDateVendorCharges
            TotalToDate
            EstimateIncomeOnlyCharges
            BilledIncomeOnlyCharges
        End Enum

#End Region

#Region " Variables "

        Private _IncludeBilledRange As Boolean = False
        Private _BilledStartPostPeriodCode As String = String.Empty
        Private _BilledEndPostPeriodCode As String = String.Empty
        Private _CurrentStartDate As Date = Date.MinValue
        Private _CurrentEndDate As Date = Date.MinValue
        Private _CurrentPostPeriodCode As String = String.Empty
        Private _PriorEndDate As Date = Date.MinValue
        Private _PriorPostPeriodCode As String = String.Empty

        Private _BilledHours As Nullable(Of Decimal) = Nothing
        Private _BilledQuantity As Nullable(Of Decimal) = Nothing
        Private _BilledAmount As Nullable(Of Decimal) = Nothing
        Private _BilledWithResale As Nullable(Of Decimal) = Nothing
        Private _CurrentHours As Nullable(Of Decimal) = Nothing
        Private _CurrentHoursAmount As Nullable(Of Decimal) = Nothing
        Private _CurrentIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _CurrentVendorCharges As Nullable(Of Decimal) = Nothing
        Private _CurrentTotal As Nullable(Of Decimal) = Nothing
        Private _PriorHours As Nullable(Of Decimal) = Nothing
        Private _PriorHoursAmount As Nullable(Of Decimal) = Nothing
        Private _PriorIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _PriorVendorCharges As Nullable(Of Decimal) = Nothing
        Private _PriorTotal As Nullable(Of Decimal) = Nothing
        Private _TotalToDateHours As Nullable(Of Decimal) = Nothing
        Private _TotalToDateHoursAmount As Nullable(Of Decimal) = Nothing
        Private _TotalToDateIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _TotalToDateVendorCharges As Nullable(Of Decimal) = Nothing
        Private _TotalToDate As Nullable(Of Decimal) = Nothing
        Private _PriorYearHours As Nullable(Of Decimal) = Nothing
        Private _PriorYearHoursAmount As Nullable(Of Decimal) = Nothing
        Private _PriorYearIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _PriorYearVendorCharges As Nullable(Of Decimal) = Nothing
        Private _PriorYearTotal As Nullable(Of Decimal) = Nothing
        Private _EstimateIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _BilledIncomeOnlyCharges As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <Required>
        Public Property ID() As Long
        <Required>
        Public Property ResourceType() As String
        Public Property JobNumber() As Nullable(Of Integer)
        Public Property JobComponentNumber() As Nullable(Of Short)
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeDescription() As String
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientDescription() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionDescription() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductDescription As String
        Public Property CampaignID As Nullable(Of Integer)
        <MaxLength(6)>
        Public Property CampaignCode As String
        <MaxLength(40)>
        Public Property CampaignName As String
        Public Property BillingBudget As Nullable(Of Decimal)
        Public Property IncomeBudget As Nullable(Of Decimal)
        <MaxLength(6)>
        Public Property SalesClassCode As String
        <MaxLength(30)>
        Public Property SalesClassDescription As String
        <MaxLength(100)>
        Public Property UserCode As String
        Public Property JobCreateDate As Nullable(Of Date)
        <MaxLength(60)>
        Public Property JobDescription As String
        Public Property JobDateOpened As Nullable(Of Date)
        <MaxLength(3)>
        Public Property RushChargesApproved As String
        <MaxLength(3)>
        Public Property ApprovedEstimateRequired As String
        Public Property Comment As String
        <MaxLength(30)>
        Public Property ClientReference As String
        <MaxLength(6)>
        Public Property BillingCoopCode As String
        <MaxLength(8)>
        Public Property SalesClassFormatCode As String
        <MaxLength(8)>
        Public Property ComplexityCode As String
        <MaxLength(30)>
        Public Property ComplexityDescription As String
        <MaxLength(8)>
        Public Property PromotionCode As String
        <MaxLength(254)>
        Public Property BillingComment As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable1 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable2 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable3 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable4 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable5 As String
        <MaxLength(3)>
        Public Property JobOpen As String
        <MaxLength(20)>
        Public Property JobComponent As String
        <MaxLength(3)>
        Public Property BillHold As String
        <MaxLength(6)>
        Public Property AccountExecutiveCode As String
        <MaxLength(100)>
        Public Property AccountExecutive As String
        <MaxLength(6)>
        Public Property ManagerCode As String
        <MaxLength(100)>
        Public Property Manager As String
        Public Property ComponentDateOpened As Nullable(Of Date)
        Public Property DueDate As Nullable(Of Date)
        Public Property StartDate As Nullable(Of Date)
        <MaxLength(30)>
        Public Property Status As String
        Public Property GutPercentComplete As Nullable(Of Decimal)
        <MaxLength(60)>
        Public Property AdSize As String
        <MaxLength(4)>
        Public Property DepartmentTeamCode As String
        <MaxLength(30)>
        Public Property DepartmentTeam As String
        Public Property MarkupPercent As Nullable(Of Decimal)
        Public Property CreativeInstructions As String
        <MaxLength(40)>
        Public Property JobProcessControl As String
        <MaxLength(60)>
        Public Property ComponentDescription As String
        Public Property ComponentComments As String
        Public Property ComponentBudget As Nullable(Of Decimal)
        Public Property EstimateNumber As Nullable(Of Integer)
        Public Property EstimateComponentNumber As Nullable(Of Short)
        <MaxLength(3)>
        Public Property ClientApproved As String
        Public Property ClientApprovalDate As Nullable(Of Date)
        <MaxLength(40)>
        Public Property ClientApprovedBy As String
        <MaxLength(3)>
        Public Property InternallyApproved As String
        Public Property InternalApprovalDate As Nullable(Of Date)
        <MaxLength(40)>
        Public Property InternallyApprovedBy As String
        <MaxLength(100)>
        Public Property BillingUser As String
        <MaxLength(40)>
        Public Property AdvanceBillFlag As String
        Public Property DeliveryInstructions As String
        <MaxLength(10)>
        Public Property JobTypeCode As String
        <MaxLength(30)>
        Public Property JobTypeDescription As String
        <MaxLength(3)>
        Public Property Taxable As String
        <MaxLength(4)>
        Public Property TaxCode As String
        <MaxLength(30)>
        Public Property TaxCodeDescription As String
        Public Property NonBillable As Nullable(Of Short)
        <MaxLength(50)>
        Public Property AlertGroup As String
        <MaxLength(30)>
        Public Property AdNumber As String
        <MaxLength(30)>
        Public Property AccountNumber As String
        <MaxLength(40)>
        Public Property AccountNumberDescription As String
        <MaxLength(30)>
        Public Property IncomeRecognitionMethod As String
        <MaxLength(10)>
        Public Property MarketCode As String
        <MaxLength(40)>
        Public Property MarketDescription As String
        <MaxLength(3)>
        Public Property ServiceFeeJob As String
        <MaxLength(6)>
        Public Property ServiceFeeTypeCode As String
        <MaxLength(30)>
        Public Property ServiceFeeTypeDescription As String
        <MaxLength(3)>
        Public Property Archived As String
        <MaxLength(3)>
        Public Property TrafficScheduleRequired As String
        <MaxLength(40)>
        Public Property ClientPO As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable1 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable2 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable3 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable4 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable5 As String
        <MaxLength(6)>
        Public Property JobTemplateCode As String
        <MaxLength(6)>
        Public Property FiscalPeriodCode As String
        <MaxLength(30)>
        Public Property FiscalPeriodDescription As String
        Public Property JobQuantity As Nullable(Of Integer)
        <MaxLength(6)>
        Public Property BlackplateVersionCode As String
        <MaxLength(60)>
        Public Property BlackplateVersionDesc As String
        <MaxLength(6)>
        Public Property BlackplateVersion2Code As String
        <MaxLength(60)>
        Public Property BlackplateVersion2Desc As String
        <MaxLength(6)>
        Public Property ClientContactCode As String
        Public Property ClientContactID As Nullable(Of Integer)
        Public Property BABatchID As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property ClientContact As String
        Public Property SelectedBABatchID As Nullable(Of Integer)
        Public Property BillingCommandCenterID As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property AlertAssignmentTemplate As String
        <MaxLength(1)>
        Public Property FunctionType As String
        <MaxLength(6)>
        Public Property FunctionConsolidationCode As String
        <MaxLength(30)>
        Public Property FunctionConsolidation As String
        <MaxLength(60)>
        Public Property FunctionHeading As String
        <MaxLength(6)>
        Public Property FunctionCode As String
        <MaxLength(30)>
        Public Property FunctionDescription As String
        Public Property ItemID As Nullable(Of Integer)
        Public Property ItemSequenceNumber As Nullable(Of Integer)
        Public Property ItemDate As Nullable(Of Date)
        <MaxLength(8)>
        Public Property PostPeriodCode As String
        <MaxLength(6)>
        Public Property ItemCode As String
        <MaxLength(100)>
        Public Property ItemDescription As String
        Public Property ItemComment As String
        <MaxLength(20)>
        Public Property ItemExtra As String
        Public Property ItemDetailComment As String
        Public Property Hours As Nullable(Of Decimal)
        Public Property Quantity As Nullable(Of Decimal)
        Public Property NetAmount As Nullable(Of Decimal)
        Public Property CostAmount As Nullable(Of Decimal)
        Public Property ExtMarkupAmount As Nullable(Of Decimal)
        Public Property NonResaleTaxAmount As Nullable(Of Decimal)
        Public Property ResaleTaxAmount As Nullable(Of Decimal)
        Public Property Total As Nullable(Of Decimal)
        Public Property BillableLessResale As Nullable(Of Decimal)
        Public Property BillableTotal As Nullable(Of Decimal)
        Public Property FeeTime As Nullable(Of Integer)
        Public Property FeeTimeHours As Nullable(Of Decimal)
        Public Property FeeTimeAmount As Nullable(Of Decimal)
        Public Property NonBillableHours As Nullable(Of Decimal)
        Public Property NonBillableQuantity As Nullable(Of Decimal)
        Public Property NonBillableAmount As Nullable(Of Decimal)
        Public Property BilledHours As Nullable(Of Decimal)
            Get

                If _IncludeBilledRange Then

                    If (Me.ResourceType = "E" OrElse Me.ResourceType = "I" OrElse Me.ResourceType = "V") AndAlso
                            Me.AccountsReceivablePostPeriodCode >= _BilledStartPostPeriodCode AndAlso Me.AccountsReceivablePostPeriodCode <= _BilledEndPostPeriodCode Then

                        BilledHours = _BilledHours

                    Else

                        BilledHours = 0

                    End If

                Else

                    BilledHours = _BilledHours

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _BilledHours = value
            End Set
        End Property
        Public Property BilledQuantity As Nullable(Of Decimal)
            Get

                If _IncludeBilledRange Then

                    If (Me.ResourceType = "E" OrElse Me.ResourceType = "I" OrElse Me.ResourceType = "V") AndAlso
                            Me.AccountsReceivablePostPeriodCode >= _BilledStartPostPeriodCode AndAlso Me.AccountsReceivablePostPeriodCode <= _BilledEndPostPeriodCode Then

                        BilledQuantity = _BilledQuantity

                    Else

                        BilledQuantity = 0

                    End If

                Else

                    BilledQuantity = _BilledQuantity

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _BilledQuantity = value
            End Set
        End Property
        Public Property BilledAmount As Nullable(Of Decimal)
            Get

                If _IncludeBilledRange Then

                    If (Me.ResourceType = "AB" OrElse Me.ResourceType = "E" OrElse Me.ResourceType = "I" OrElse Me.ResourceType = "V") AndAlso
                            Me.AccountsReceivablePostPeriodCode >= _BilledStartPostPeriodCode AndAlso Me.AccountsReceivablePostPeriodCode <= _BilledEndPostPeriodCode Then

                        BilledAmount = _BilledAmount

                    Else

                        BilledAmount = 0

                    End If

                Else

                    BilledAmount = _BilledAmount

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _BilledAmount = value
            End Set
        End Property
        Public Property BilledWithResale As Nullable(Of Decimal)
            Get

                If _IncludeBilledRange Then

                    If (Me.ResourceType = "AB" OrElse Me.ResourceType = "E" OrElse Me.ResourceType = "I" OrElse Me.ResourceType = "V") AndAlso
                            Me.AccountsReceivablePostPeriodCode >= _BilledStartPostPeriodCode AndAlso Me.AccountsReceivablePostPeriodCode <= _BilledEndPostPeriodCode Then

                        BilledWithResale = _BilledWithResale

                    Else

                        BilledWithResale = 0

                    End If

                Else

                    BilledWithResale = _BilledWithResale

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _BilledWithResale = value
            End Set
        End Property
        <MaxLength(6)>
        Public Property AccountsReceivablePostPeriodCode As String
        Public Property AccountsReceivableInvoiceNumber As Nullable(Of Integer)
        <MaxLength(3)>
        Public Property AccountsReceivableInvoiceType As String
        Public Property UnbilledHours As Nullable(Of Decimal)
        Public Property UnbilledQuantity As Nullable(Of Decimal)
        Public Property UnbilledAmount As Nullable(Of Decimal)
        Public Property UnbilledAmountLessResale As Nullable(Of Decimal)
        Public Property AdvanceBillFlagDetail As Nullable(Of Integer)
        Public Property IsNonBillable As Nullable(Of Integer)
        Public Property GlexActBill As Nullable(Of Integer)
        Public Property EstimateSuppliedByCode As String
        Public Property EstimateSuppliedBy As String
        Public Property EstimateHours As Nullable(Of Decimal)
        Public Property EstimateHoursAmount As Nullable(Of Decimal)
        Public Property EstimateQuantity As Nullable(Of Decimal)
        Public Property EstimateTotalAmount As Nullable(Of Decimal)
        Public Property EstimateContTotalAmount As Nullable(Of Decimal)
        Public Property EstimateNonResaleTaxAmount As Nullable(Of Decimal)
        Public Property EstimateResaleTaxAmount As Nullable(Of Decimal)
        Public Property EstimateMarkupAmount As Nullable(Of Decimal)
        Public Property EstimateCostAmount As Nullable(Of Decimal)
        Public Property IsEstimateNonBillable As Nullable(Of Integer)
        Public Property EstimateFeeTime As Nullable(Of Integer)
        Public Property EstimateNetAmount As Nullable(Of Decimal)
        Public Property PurchaseOrderNumber As Nullable(Of Integer)
        Public Property OpenPurchaseOrderAmount As Nullable(Of Decimal)
        Public Property OpenPurchaseOrderGrossAmount As Nullable(Of Decimal)
        Public Property IsNewBusiness As Nullable(Of Short)
        Public Property Agency As Nullable(Of Integer)
        Public Property BillingApprovalHours As Nullable(Of Integer)
        Public Property BillingApprovalCostAmount As Nullable(Of Integer)
        Public Property BillingApprovalExtNetAmount As Nullable(Of Integer)
        Public Property BillingApprovalTotalAmount As Nullable(Of Integer)
        <MaxLength(50)>
        Public Property ProductUDF1 As String
        <MaxLength(50)>
        Public Property ProductUDF2 As String
        <MaxLength(50)>
        Public Property ProductUDF3 As String
        <MaxLength(50)>
        Public Property ProductUDF4 As String
        <MaxLength(4)>
        Public Property EmployeeDefaultDepartmentCode As String
        <MaxLength(30)>
        Public Property EmployeeDefaultDepartmentDescription As String
        <MaxLength(4)>
        Public Property EmployeeTimeDepartmentCode As String
        <MaxLength(30)>
        Public Property EmployeeTimeDepartmentDescription As String
        Public Property CompletedDate As Nullable(Of Date)
        Public Property JobProcessControlDate As Nullable(Of Date)
        Public Property DateEntered As Nullable(Of Date)
        <MaxLength(6)>
        Public Property DefaultRoleCode As String
        <MaxLength(40)>
        Public Property DefaultRole As String
        <MaxLength(4)>
        Public Property EmployeeOfficeCode As String
        <MaxLength(30)>
        Public Property EmployeeOfficeDescription As String
        <MaxLength(50)>
        Public Property EmployeeTitle As String
        <MaxLength(3)>
        Public Property IsEmployeeFreelance As String
        <MaxLength(3)>
        Public Property IsActiveFreelance As String
        <MaxLength(254)>
        Public Property EmployeeRateFrom As String
        <MaxLength(10)>
        Public Property ProductCategoryCode As String
        <MaxLength(60)>
        Public Property ProductCategoryDescription As String
        Public Property DirectHoursGoalPercent
        Public Property ClientType1Code As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property ClientType1Description As String
        Public Property ClientType2Code As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property ClientType2Description As String
        Public Property ClientType3Code As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property ClientType3Description As String
        Public Property CurrentHours As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" AndAlso (Me.ItemDate >= _CurrentStartDate AndAlso Me.ItemDate <= _CurrentEndDate) Then

                    CurrentHours = Me.Hours

                Else

                    CurrentHours = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _CurrentHours = value
            End Set
        End Property
        Public Property CurrentHoursAmount As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" AndAlso (Me.ItemDate >= _CurrentStartDate AndAlso Me.ItemDate <= _CurrentEndDate) Then

                    CurrentHoursAmount = Me.Total

                Else

                    CurrentHoursAmount = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _CurrentHoursAmount = value
            End Set
        End Property
        Public Property CurrentIncomeOnlyCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "I" AndAlso (Me.ItemDate >= _CurrentStartDate AndAlso Me.ItemDate <= _CurrentEndDate) Then

                    CurrentIncomeOnlyCharges = Me.Total

                Else

                    CurrentIncomeOnlyCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _CurrentIncomeOnlyCharges = value
            End Set
        End Property
        Public Property CurrentVendorCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "V" AndAlso (Me.PostPeriodCode = _CurrentPostPeriodCode) Then

                    CurrentVendorCharges = Me.Total

                Else

                    CurrentVendorCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _CurrentVendorCharges = value
            End Set
        End Property
        Public Property CurrentTotal As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" AndAlso (Me.ItemDate >= _CurrentStartDate AndAlso Me.ItemDate <= _CurrentEndDate) Then

                    CurrentTotal = Me.Total

                ElseIf Me.ResourceType = "I" AndAlso (Me.ItemDate >= _CurrentStartDate AndAlso Me.ItemDate <= _CurrentEndDate) Then

                    CurrentTotal = Me.Total

                ElseIf Me.ResourceType = "V" AndAlso (Me.PostPeriodCode = _CurrentPostPeriodCode) Then

                    CurrentTotal = Me.Total

                Else

                    CurrentTotal = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _CurrentTotal = value
            End Set
        End Property
        Public Property PriorHours As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" AndAlso Me.ItemDate < _CurrentStartDate Then

                    PriorHours = Me.Hours

                Else

                    PriorHours = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorHours = value
            End Set
        End Property
        Public Property PriorHoursAmount As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" AndAlso Me.ItemDate < _CurrentStartDate Then

                    PriorHoursAmount = Me.Total

                Else

                    PriorHoursAmount = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorHoursAmount = value
            End Set
        End Property
        Public Property PriorIncomeOnlyCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "I" AndAlso Me.ItemDate < _CurrentStartDate Then

                    PriorIncomeOnlyCharges = Me.Total

                Else

                    PriorIncomeOnlyCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorIncomeOnlyCharges = value
            End Set
        End Property
        Public Property PriorVendorCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "V" AndAlso Me.PostPeriodCode < _CurrentPostPeriodCode Then

                    PriorIncomeOnlyCharges = Me.Total

                Else

                    PriorIncomeOnlyCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorIncomeOnlyCharges = value
            End Set
        End Property
        Public Property PriorTotal As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" AndAlso Me.ItemDate < _CurrentStartDate Then

                    PriorTotal = Me.Total

                ElseIf Me.ResourceType = "I" AndAlso Me.ItemDate < _CurrentStartDate Then

                    PriorTotal = Me.Total

                ElseIf Me.ResourceType = "V" AndAlso Me.PostPeriodCode < _CurrentPostPeriodCode Then

                    PriorTotal = Me.Total

                Else

                    PriorTotal = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorTotal = value
            End Set
        End Property
        Public Property TotalToDateHours As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" Then

                    TotalToDateHours = Me.Hours

                Else

                    TotalToDateHours = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _TotalToDateHours = value
            End Set
        End Property
        Public Property TotalToDateHoursAmount As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" Then

                    TotalToDateHoursAmount = Me.Total

                Else

                    TotalToDateHoursAmount = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _TotalToDateHoursAmount = value
            End Set
        End Property
        Public Property TotalToDateIncomeOnlyCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "I" Then

                    TotalToDateIncomeOnlyCharges = Me.Total

                Else

                    TotalToDateIncomeOnlyCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _TotalToDateIncomeOnlyCharges = value
            End Set
        End Property
        Public Property TotalToDateVendorCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "V" Then

                    TotalToDateIncomeOnlyCharges = Me.Total

                Else

                    TotalToDateIncomeOnlyCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _TotalToDateIncomeOnlyCharges = value
            End Set
        End Property
        Public Property TotalToDate As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" Then

                    TotalToDate = Me.Total

                ElseIf Me.ResourceType = "I" Then

                    TotalToDate = Me.Total

                ElseIf Me.ResourceType = "V" Then

                    TotalToDate = Me.Total

                Else

                    TotalToDate = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _TotalToDate = value
            End Set
        End Property
        Public Property PriorYearHours As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" AndAlso Me.ItemDate < _PriorEndDate Then

                    PriorYearHours = Me.Hours

                Else

                    PriorYearHours = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorYearHours = value
            End Set
        End Property
        Public Property PriorYearHoursAmount As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" AndAlso Me.ItemDate < _PriorEndDate Then

                    PriorYearHoursAmount = Me.Total

                Else

                    PriorYearHoursAmount = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorYearHoursAmount = value
            End Set
        End Property
        Public Property PriorYearIncomeOnlyCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "I" AndAlso Me.ItemDate < _PriorEndDate Then

                    PriorYearIncomeOnlyCharges = Me.Total

                Else

                    PriorYearIncomeOnlyCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorYearIncomeOnlyCharges = value
            End Set
        End Property
        Public Property PriorYearVendorCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "V" AndAlso Me.PostPeriodCode < _PriorPostPeriodCode Then

                    PriorYearVendorCharges = Me.Total

                Else

                    PriorYearVendorCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorYearVendorCharges = value
            End Set
        End Property
        Public Property PriorYearTotal As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "E" AndAlso Me.ItemDate < _PriorEndDate Then

                    PriorYearTotal = Me.Total

                ElseIf Me.ResourceType = "I" AndAlso Me.ItemDate < _PriorEndDate Then

                    PriorYearTotal = Me.Total

                ElseIf Me.ResourceType = "V" AndAlso Me.PostPeriodCode < _PriorPostPeriodCode Then

                    PriorYearTotal = Me.Total

                Else

                    PriorYearTotal = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _PriorYearTotal = value
            End Set
        End Property
        Public Property EstimateIncomeOnlyCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "EI" OrElse Me.ResourceType = "ES" Then

                    EstimateIncomeOnlyCharges = Me.EstimateTotalAmount

                Else

                    EstimateIncomeOnlyCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateIncomeOnlyCharges = value
            End Set
        End Property
        Public Property BilledIncomeOnlyCharges As Nullable(Of Decimal)
            Get

                If Me.ResourceType = "I" Then

                    BilledIncomeOnlyCharges = Me.BilledAmount

                Else

                    BilledIncomeOnlyCharges = 0

                End If

            End Get
            Set(value As Nullable(Of Decimal))
                _BilledIncomeOnlyCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceBilledTotal() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property FlatIncomeRecognized() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceBilledAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceBillingRetained() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Sub New(JobDetailItemDataCore As JobDetailItemDataCore, IncludeBilledRange As Boolean, BilledStartPostPeriodCode As String,
                       BilledEndPostPeriodCode As String, CurrentStartDate As Date, CurrentEndDate As Date, CurrentPostPeriodCode As String,
                       PriorEndDate As Date, PriorPostPeriodCode As String)

            Me.ID = JobDetailItemDataCore.ID
            Me.ResourceType = JobDetailItemDataCore.ResourceType
            Me.JobNumber = JobDetailItemDataCore.JobNumber
            Me.JobComponentNumber = JobDetailItemDataCore.JobComponentNumber
            Me.OfficeCode = JobDetailItemDataCore.OfficeCode
            Me.OfficeDescription = JobDetailItemDataCore.OfficeDescription
            Me.ClientCode = JobDetailItemDataCore.ClientCode
            Me.ClientDescription = JobDetailItemDataCore.ClientDescription
            Me.DivisionCode = JobDetailItemDataCore.DivisionCode
            Me.DivisionDescription = JobDetailItemDataCore.DivisionDescription
            Me.ProductCode = JobDetailItemDataCore.ProductCode
            Me.ProductDescription = JobDetailItemDataCore.ProductDescription
            Me.CampaignID = JobDetailItemDataCore.CampaignID
            Me.CampaignCode = JobDetailItemDataCore.CampaignCode
            Me.CampaignName = JobDetailItemDataCore.CampaignName
            Me.BillingBudget = JobDetailItemDataCore.BillingBudget
            Me.IncomeBudget = JobDetailItemDataCore.IncomeBudget
            Me.SalesClassCode = JobDetailItemDataCore.SalesClassCode
            Me.SalesClassDescription = JobDetailItemDataCore.SalesClassDescription
            Me.UserCode = JobDetailItemDataCore.UserCode
            Me.JobCreateDate = JobDetailItemDataCore.JobCreateDate
            Me.JobDescription = JobDetailItemDataCore.JobDescription
            Me.JobDateOpened = JobDetailItemDataCore.JobDateOpened
            Me.RushChargesApproved = JobDetailItemDataCore.RushChargesApproved
            Me.ApprovedEstimateRequired = JobDetailItemDataCore.ApprovedEstimateRequired
            Me.Comment = JobDetailItemDataCore.Comment
            Me.ClientReference = JobDetailItemDataCore.ClientReference
            Me.BillingCoopCode = JobDetailItemDataCore.BillingCoopCode
            Me.SalesClassFormatCode = JobDetailItemDataCore.SalesClassFormatCode
            Me.ComplexityCode = JobDetailItemDataCore.ComplexityCode
            Me.ComplexityDescription = JobDetailItemDataCore.ComplexityDescription
            Me.PromotionCode = JobDetailItemDataCore.PromotionCode
            Me.BillingComment = JobDetailItemDataCore.BillingComment
            Me.LabelFromUDFTable1 = JobDetailItemDataCore.LabelFromUDFTable1
            Me.LabelFromUDFTable2 = JobDetailItemDataCore.LabelFromUDFTable2
            Me.LabelFromUDFTable3 = JobDetailItemDataCore.LabelFromUDFTable3
            Me.LabelFromUDFTable4 = JobDetailItemDataCore.LabelFromUDFTable4
            Me.LabelFromUDFTable5 = JobDetailItemDataCore.LabelFromUDFTable5
            Me.JobOpen = JobDetailItemDataCore.JobOpen
            Me.JobComponent = JobDetailItemDataCore.JobComponent
            Me.BillHold = JobDetailItemDataCore.BillHold
            Me.AccountExecutiveCode = JobDetailItemDataCore.AccountExecutiveCode
            Me.AccountExecutive = JobDetailItemDataCore.AccountExecutive
            Me.ManagerCode = JobDetailItemDataCore.ManagerCode
            Me.Manager = JobDetailItemDataCore.Manager
            Me.ComponentDateOpened = JobDetailItemDataCore.ComponentDateOpened
            Me.DueDate = JobDetailItemDataCore.DueDate
            Me.StartDate = JobDetailItemDataCore.StartDate
            Me.Status = JobDetailItemDataCore.Status
            Me.GutPercentComplete = JobDetailItemDataCore.GutPercentComplete
            Me.AdSize = JobDetailItemDataCore.AdSize
            Me.DepartmentTeamCode = JobDetailItemDataCore.DepartmentTeamCode
            Me.DepartmentTeam = JobDetailItemDataCore.DepartmentTeam
            Me.MarkupPercent = JobDetailItemDataCore.MarkupPercent
            Me.CreativeInstructions = JobDetailItemDataCore.CreativeInstructions
            Me.JobProcessControl = JobDetailItemDataCore.JobProcessControl
            Me.ComponentDescription = JobDetailItemDataCore.ComponentDescription
            Me.ComponentComments = JobDetailItemDataCore.ComponentComments
            Me.ComponentBudget = JobDetailItemDataCore.ComponentBudget
            Me.EstimateNumber = JobDetailItemDataCore.EstimateNumber
            Me.EstimateComponentNumber = JobDetailItemDataCore.EstimateComponentNumber
            Me.ClientApproved = JobDetailItemDataCore.ClientApproved
            Me.ClientApprovalDate = JobDetailItemDataCore.ClientApprovalDate
            Me.ClientApprovedBy = JobDetailItemDataCore.ClientApprovedBy
            Me.InternallyApproved = JobDetailItemDataCore.InternallyApproved
            Me.InternalApprovalDate = JobDetailItemDataCore.InternalApprovalDate
            Me.InternallyApprovedBy = JobDetailItemDataCore.InternallyApprovedBy
            Me.BillingUser = JobDetailItemDataCore.BillingUser
            Me.AdvanceBillFlag = JobDetailItemDataCore.AdvanceBillFlag
            Me.DeliveryInstructions = JobDetailItemDataCore.DeliveryInstructions
            Me.JobTypeCode = JobDetailItemDataCore.JobTypeCode
            Me.JobTypeDescription = JobDetailItemDataCore.JobTypeDescription
            Me.Taxable = JobDetailItemDataCore.Taxable
            Me.TaxCode = JobDetailItemDataCore.TaxCode
            Me.TaxCodeDescription = JobDetailItemDataCore.TaxCodeDescription
            Me.NonBillable = JobDetailItemDataCore.NonBillable
            Me.AlertGroup = JobDetailItemDataCore.AlertGroup
            Me.AdNumber = JobDetailItemDataCore.AdNumber
            Me.AccountNumber = JobDetailItemDataCore.AccountNumber
            Me.AccountNumberDescription = JobDetailItemDataCore.AccountNumberDescription
            Me.IncomeRecognitionMethod = JobDetailItemDataCore.IncomeRecognitionMethod
            Me.MarketCode = JobDetailItemDataCore.MarketCode
            Me.MarketDescription = JobDetailItemDataCore.MarketDescription
            Me.ServiceFeeJob = JobDetailItemDataCore.ServiceFeeJob
            Me.ServiceFeeTypeCode = JobDetailItemDataCore.ServiceFeeTypeCode
            Me.ServiceFeeTypeDescription = JobDetailItemDataCore.ServiceFeeTypeDescription
            Me.Archived = JobDetailItemDataCore.Archived
            Me.TrafficScheduleRequired = JobDetailItemDataCore.TrafficScheduleRequired
            Me.ClientPO = JobDetailItemDataCore.ClientPO
            Me.CompLabelFromUDFTable1 = JobDetailItemDataCore.CompLabelFromUDFTable1
            Me.CompLabelFromUDFTable2 = JobDetailItemDataCore.CompLabelFromUDFTable2
            Me.CompLabelFromUDFTable3 = JobDetailItemDataCore.CompLabelFromUDFTable3
            Me.CompLabelFromUDFTable4 = JobDetailItemDataCore.CompLabelFromUDFTable4
            Me.CompLabelFromUDFTable5 = JobDetailItemDataCore.CompLabelFromUDFTable5
            Me.JobTemplateCode = JobDetailItemDataCore.JobTemplateCode
            Me.FiscalPeriodCode = JobDetailItemDataCore.FiscalPeriodCode
            Me.FiscalPeriodDescription = JobDetailItemDataCore.FiscalPeriodDescription
            Me.JobQuantity = JobDetailItemDataCore.JobQuantity
            Me.BlackplateVersionCode = JobDetailItemDataCore.BlackplateVersionCode
            Me.BlackplateVersionDesc = JobDetailItemDataCore.BlackplateVersionDesc
            Me.BlackplateVersion2Code = JobDetailItemDataCore.BlackplateVersion2Code
            Me.BlackplateVersion2Desc = JobDetailItemDataCore.BlackplateVersion2Desc
            Me.ClientContactCode = JobDetailItemDataCore.ClientContactCode
            Me.ClientContactID = JobDetailItemDataCore.ClientContactID
            Me.BABatchID = JobDetailItemDataCore.BABatchID
            Me.ClientContact = JobDetailItemDataCore.ClientContact
            Me.SelectedBABatchID = JobDetailItemDataCore.SelectedBABatchID
            Me.BillingCommandCenterID = JobDetailItemDataCore.BillingCommandCenterID
            Me.AlertAssignmentTemplate = JobDetailItemDataCore.AlertAssignmentTemplate
            Me.FunctionType = JobDetailItemDataCore.FunctionType
            Me.FunctionConsolidationCode = JobDetailItemDataCore.FunctionConsolidationCode
            Me.FunctionConsolidation = JobDetailItemDataCore.FunctionConsolidation
            Me.FunctionHeading = JobDetailItemDataCore.FunctionHeading
            Me.FunctionCode = JobDetailItemDataCore.FunctionCode
            Me.FunctionDescription = JobDetailItemDataCore.FunctionDescription
            Me.ItemID = JobDetailItemDataCore.ItemID
            Me.ItemSequenceNumber = JobDetailItemDataCore.ItemSequenceNumber
            Me.ItemDate = JobDetailItemDataCore.ItemDate
            Me.PostPeriodCode = JobDetailItemDataCore.PostPeriodCode
            Me.ItemCode = JobDetailItemDataCore.ItemCode
            Me.ItemDescription = JobDetailItemDataCore.ItemDescription
            Me.ItemComment = JobDetailItemDataCore.ItemComment
            Me.ItemExtra = JobDetailItemDataCore.ItemExtra
            Me.ItemDetailComment = JobDetailItemDataCore.ItemDetailComment
            Me.Hours = JobDetailItemDataCore.Hours
            Me.Quantity = JobDetailItemDataCore.Quantity
            Me.NetAmount = JobDetailItemDataCore.NetAmount
            Me.CostAmount = JobDetailItemDataCore.CostAmount
            Me.ExtMarkupAmount = JobDetailItemDataCore.ExtMarkupAmount
            Me.NonResaleTaxAmount = JobDetailItemDataCore.NonResaleTaxAmount
            Me.ResaleTaxAmount = JobDetailItemDataCore.ResaleTaxAmount
            Me.Total = JobDetailItemDataCore.Total
            Me.BillableLessResale = JobDetailItemDataCore.BillableLessResale
            Me.BillableTotal = JobDetailItemDataCore.BillableTotal
            Me.FeeTime = JobDetailItemDataCore.FeeTime
            Me.FeeTimeHours = JobDetailItemDataCore.FeeTimeHours
            Me.FeeTimeAmount = JobDetailItemDataCore.FeeTimeAmount
            Me.NonBillableHours = JobDetailItemDataCore.NonBillableHours
            Me.NonBillableQuantity = JobDetailItemDataCore.NonBillableQuantity
            Me.NonBillableAmount = JobDetailItemDataCore.NonBillableAmount
            Me.BilledHours = JobDetailItemDataCore.BilledHours
            Me.BilledQuantity = JobDetailItemDataCore.BilledQuantity
            Me.BilledAmount = JobDetailItemDataCore.BilledAmount
            Me.BilledWithResale = JobDetailItemDataCore.BilledWithResale
            Me.AccountsReceivablePostPeriodCode = JobDetailItemDataCore.AccountsReceivablePostPeriodCode
            Me.AccountsReceivableInvoiceNumber = JobDetailItemDataCore.AccountsReceivableInvoiceNumber
            Me.AccountsReceivableInvoiceType = JobDetailItemDataCore.AccountsReceivableInvoiceType
            Me.UnbilledHours = JobDetailItemDataCore.UnbilledHours
            Me.UnbilledQuantity = JobDetailItemDataCore.UnbilledQuantity
            Me.UnbilledAmount = JobDetailItemDataCore.UnbilledAmount
            Me.UnbilledAmountLessResale = JobDetailItemDataCore.UnbilledAmountLessResale
            Me.AdvanceBillFlagDetail = JobDetailItemDataCore.AdvanceBillFlagDetail
            Me.IsNonBillable = JobDetailItemDataCore.IsNonBillable
            Me.GlexActBill = JobDetailItemDataCore.GlexActBill
            Me.EstimateSuppliedByCode = JobDetailItemDataCore.EstimateSuppliedByCode
            Me.EstimateSuppliedBy = JobDetailItemDataCore.EstimateSuppliedBy
            Me.EstimateHours = JobDetailItemDataCore.EstimateSuppliedBy
            Me.EstimateHoursAmount = JobDetailItemDataCore.EstimateHoursAmount
            Me.EstimateQuantity = JobDetailItemDataCore.EstimateQuantity
            Me.EstimateTotalAmount = JobDetailItemDataCore.EstimateTotalAmount
            Me.EstimateContTotalAmount = JobDetailItemDataCore.EstimateContTotalAmount
            Me.EstimateNonResaleTaxAmount = JobDetailItemDataCore.EstimateNonResaleTaxAmount
            Me.EstimateResaleTaxAmount = JobDetailItemDataCore.EstimateResaleTaxAmount
            Me.EstimateMarkupAmount = JobDetailItemDataCore.EstimateMarkupAmount
            Me.EstimateCostAmount = JobDetailItemDataCore.EstimateCostAmount
            Me.IsEstimateNonBillable = JobDetailItemDataCore.IsEstimateNonBillable
            Me.EstimateFeeTime = JobDetailItemDataCore.EstimateFeeTime
            Me.EstimateNetAmount = JobDetailItemDataCore.EstimateNetAmount
            Me.PurchaseOrderNumber = JobDetailItemDataCore.PurchaseOrderNumber
            Me.OpenPurchaseOrderAmount = JobDetailItemDataCore.OpenPurchaseOrderAmount
            Me.OpenPurchaseOrderGrossAmount = JobDetailItemDataCore.OpenPurchaseOrderGrossAmount
            Me.IsNewBusiness = JobDetailItemDataCore.IsNewBusiness
            Me.Agency = JobDetailItemDataCore.Agency
            Me.BillingApprovalHours = JobDetailItemDataCore.BillingApprovalHours
            Me.BillingApprovalCostAmount = JobDetailItemDataCore.BillingApprovalCostAmount
            Me.BillingApprovalExtNetAmount = JobDetailItemDataCore.BillingApprovalExtNetAmount
            Me.BillingApprovalTotalAmount = JobDetailItemDataCore.BillingApprovalTotalAmount
            Me.ProductUDF1 = JobDetailItemDataCore.ProductUDF1
            Me.ProductUDF2 = JobDetailItemDataCore.ProductUDF2
            Me.ProductUDF3 = JobDetailItemDataCore.ProductUDF3
            Me.ProductUDF4 = JobDetailItemDataCore.ProductUDF4
            Me.EmployeeDefaultDepartmentCode = JobDetailItemDataCore.EmployeeDefaultDepartmentCode
            Me.EmployeeDefaultDepartmentDescription = JobDetailItemDataCore.EmployeeDefaultDepartmentDescription
            Me.EmployeeTimeDepartmentCode = JobDetailItemDataCore.EmployeeTimeDepartmentCode
            Me.EmployeeTimeDepartmentDescription = JobDetailItemDataCore.EmployeeTimeDepartmentDescription
            Me.CompletedDate = JobDetailItemDataCore.CompletedDate
            Me.JobProcessControlDate = JobDetailItemDataCore.JobProcessControlDate
            Me.DateEntered = JobDetailItemDataCore.DateEntered
            Me.DefaultRoleCode = JobDetailItemDataCore.DefaultRoleCode
            Me.DefaultRole = JobDetailItemDataCore.DefaultRole
            Me.EmployeeOfficeCode = JobDetailItemDataCore.EmployeeOfficeCode
            Me.EmployeeOfficeDescription = JobDetailItemDataCore.EmployeeOfficeDescription
            Me.EmployeeTitle = JobDetailItemDataCore.EmployeeTitle
            Me.IsEmployeeFreelance = JobDetailItemDataCore.IsEmployeeFreelance
            Me.IsActiveFreelance = JobDetailItemDataCore.IsActiveFreelance
            Me.EmployeeRateFrom = JobDetailItemDataCore.EmployeeRateFrom
            Me.ProductCategoryCode = JobDetailItemDataCore.ProductCategoryCode
            Me.ProductCategoryDescription = JobDetailItemDataCore.ProductCategoryDescription
            Me.DirectHoursGoalPercent = JobDetailItemDataCore.DirectHoursGoalPercent
            Me.ClientType1Code = JobDetailItemDataCore.ClientType1Code
            Me.ClientType1Description = JobDetailItemDataCore.ClientType1Description
            Me.ClientType2Code = JobDetailItemDataCore.ClientType2Code
            Me.ClientType2Description = JobDetailItemDataCore.ClientType2Description
            Me.ClientType3Code = JobDetailItemDataCore.ClientType3Code
            Me.ClientType3Description = JobDetailItemDataCore.ClientType3Description
            Me.AdvanceBilledTotal = JobDetailItemDataCore.AdvanceBilledTotal
            Me.FlatIncomeRecognized = JobDetailItemDataCore.FlatIncomeRecognized
            Me.AdvanceBilledAmount = JobDetailItemDataCore.AdvanceBilledAmount
            Me.AdvanceBillingRetained = JobDetailItemDataCore.AdvanceBillingRetained

            _IncludeBilledRange = IncludeBilledRange
            _BilledStartPostPeriodCode = BilledStartPostPeriodCode
            _BilledEndPostPeriodCode = BilledEndPostPeriodCode
            _CurrentStartDate = CurrentStartDate
            _CurrentEndDate = CurrentEndDate
            _CurrentPostPeriodCode = CurrentPostPeriodCode
            _PriorEndDate = PriorEndDate
            _PriorPostPeriodCode = PriorPostPeriodCode

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
