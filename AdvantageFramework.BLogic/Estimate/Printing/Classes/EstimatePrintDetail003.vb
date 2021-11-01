Namespace Estimate.Printing.Classes

    <Serializable()>
    Public Class EstimatePrintDetail003

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            'ProductUDF1
            'ProductUDF2
            'ProductUDF3
            'ProductUDF4
            EstimateNumber
            EstimateDescription
            EstimateComment
            EstimateCommentHtml
            EstimateComponentNumber
            EstimateComponentDescription
            EstimateComponentComment
            EstimateComponentCommentHtml
            EstimateContactID
            EstimateContactCode
            EstimateContactName
            EstimateContactAddress1
            EstimateContactAddress2
            EstimateContactCity
            EstimateContactState
            EstimateContactZip
            EstimateContactCountry
            EstimateContactPhone
            EstimateContactFax
            EstimateContactEmail
            EstimateContactTitle
            QuoteNumber
            QuoteDescription
            QuoteComment
            QuoteCommentHtml
            'RevisionNumber
            RevisionComment
            RevisionCommentHtml
            DefaultComment
            DefaultCommentHtml
            'ApprovalType
            'ApprovalTypeDescription
            'ClientApprovalName
            'ClientApprovalDate
            'InternalApprovalName
            'InternalApprovalDate
            JobNumber
            JobDescription
            JobClientReference
            EstimateCampaignID
            EstimateCampaignCode
            EstimateCampaignName
            SalesClassCode
            SalesClassDescription
            'JobCreateDate
            'JobDateOpened
            JobComponentNumber
            JobComponentDescription
            AccountExecutiveCode
            AccountExecutiveName
            'JobClientPO
            'ComponentDateOpened
            JobDueDate
            'JobStartDate
            'JobProcessingControl
            FunctionType
            FunctionHeadingID
            FunctionHeadingDescription
            FunctionHeadingSequence
            FunctionCode
            FunctionDescription
            FunctionOrder
            'SequenceNumber
            DetailComments
            DetailCommentsHtml
            'SuppliedByCode
            'SuppliedByName
            SuppliedByNotes
            SuppliedByNotesHtml
            'EstimateQuantity
            'EstimateRate
            'EstimateExtAmount
            'EstimateNetAmount
            'EstimateCostAmount
            'EstimateTaxAmount
            'EstimateMarkupAmount
            'EstimateTotalAmount
            'EstimateContingencyAmount
            'EstimateMarkupContingency
            EstimateFunctionType
            EmployeeTitleID
            EstimatePhaseID
            EstimatePhaseDescription
            JobQuantity
            CPU
            CPM
            EstimateComponentQuote
            'EstimateComponent
            InOut
            FunctionOption
            GroupOption
            SortOption
            TaxSeparate
            CommissionSeparate
            ContingencySeparate
            IncludeContingency
            PrintNonBillable
            AdNumber
            LabelFromUDFTable1
            LabelFromUDFTable2
            LabelFromUDFTable3
            LabelFromUDFTable4
            LabelFromUDFTable5
            CompLabelFromUDFTable1
            CompLabelFromUDFTable2
            CompLabelFromUDFTable3
            CompLabelFromUDFTable4
            CompLabelFromUDFTable5
            OriginalAmount
            OriginalMarkupAmount
            OriginalContingency
            OriginalMarkupContingency
            OriginalTax
            OriginalJobQuantity
            OriginalCPU
            OriginalCPM
            OriginalLineTotal
            OriginalLineContingencyTotal
            RevisedAmount
            RevisedMarkupAmount
            RevisedContingency
            RevisedMarkupContingency
            RevisedTax
            RevisedJobQuantity
            RevisedCPU
            RevisedCPM
            RevisedLineTotal
            RevisedLineContingencyTotal
            FinalActual
            OneRevision
            MaxRevision
            ActualMarkup
            ActualTax
            ActualTotal
            NonBillableMarkup
            NonBillableTax
            NonBillableTotal
            GroupingID
            OriginalApprovalType
            RevisedApprovalType
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        'Private _ProductUDF1 As String = Nothing
        'Private _ProductUDF2 As String = Nothing
        'Private _ProductUDF3 As String = Nothing
        'Private _ProductUDF4 As String = Nothing
        Private _EstimateNumber As Integer = Nothing
        Private _EstimateDescription As String = Nothing
        Private _EstimateComment As String = Nothing
        Private _EstimateCommentHtml As String = Nothing
        Private _EstimateComponentNumber As Short = Nothing
        Private _EstimateComponentDescription As String = Nothing
        Private _EstimateComponentComment As String = Nothing
        Private _EstimateComponentCommentHtml As String = Nothing
        Private _EstimateContactID As Nullable(Of Integer) = Nothing
        Private _EstimateContactCode As String = Nothing
        Private _EstimateContactName As String = Nothing
        Private _EstimateContactAddress1 As String = Nothing
        Private _EstimateContactAddress2 As String = Nothing
        Private _EstimateContactCity As String = Nothing
        Private _EstimateContactState As String = Nothing
        Private _EstimateContactZip As String = Nothing
        Private _EstimateContactCountry As String = Nothing
        Private _EstimateContactPhone As String = Nothing
        Private _EstimateContactFax As String = Nothing
        Private _EstimateContactEmail As String = Nothing
        Private _EstimateContactTitle As String = Nothing
        Private _QuoteNumber As Short = Nothing
        Private _QuoteDescription As String = Nothing
        Private _QuoteComment As String = Nothing
        Private _QuoteCommentHtml As String = Nothing
        'Private _RevisionNumber As Nullable(Of Short) = Nothing
        Private _RevisionComment As String = Nothing
        Private _RevisionCommentHtml As String = Nothing
        Private _DefaultComment As String = Nothing
        Private _DefaultCommentHtml As String = Nothing
        'Private _ApprovalType As Nullable(Of Integer) = Nothing
        'Private _ApprovalTypeDescription As String = Nothing
        'Private _ClientApprovalName As String = Nothing
        'Private _ClientApprovalDate As Nullable(Of Date) = Nothing
        'Private _InternalApprovalName As String = Nothing
        'Private _InternalApprovalDate As Nullable(Of Date) = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobClientReference As String = Nothing
        Private _EstimateCampaignID As Nullable(Of Integer) = Nothing
        Private _EstimateCampaignCode As String = Nothing
        Private _EstimateCampaignName As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        'Private _JobCreateDate As Nullable(Of Date) = Nothing
        'Private _JobDateOpened As Nullable(Of Date) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutiveName As String = Nothing
        'Private _JobClientPO As String = Nothing
        'Private _ComponentDateOpened As Nullable(Of Date) = Nothing
        Private _JobDueDate As Nullable(Of Date) = Nothing
        'Private _JobStartDate As Nullable(Of Date) = Nothing
        'Private _JobProcessingControl As String = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionHeadingID As Nullable(Of Integer) = Nothing
        Private _FunctionHeadingDescription As String = Nothing
        Private _FunctionHeadingSequence As Nullable(Of Integer) = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionOrder As Nullable(Of Short) = Nothing
        'Private _SequenceNumber As Nullable(Of Integer) = Nothing
        Private _DetailComments As String = Nothing
        Private _DetailCommentsHtml As String = Nothing
        'Private _SuppliedByCode As String = Nothing
        'Private _SuppliedByName As String = Nothing
        Private _SuppliedByNotes As String = Nothing
        Private _SuppliedByNotesHtml As String = Nothing
        'Private _EstimateQuantity As Nullable(Of Decimal) = Nothing
        'Private _EstimateRate As Nullable(Of Decimal) = Nothing
        'Private _EstimateExtAmount As Nullable(Of Decimal) = Nothing
        'Private _EstimateNetAmount As Nullable(Of Decimal) = Nothing
        'Private _EstimateCostAmount As Nullable(Of Decimal) = Nothing
        'Private _EstimateTaxAmount As Nullable(Of Decimal) = Nothing
        'Private _EstimateMarkupAmount As Nullable(Of Decimal) = Nothing
        'Private _EstimateTotalAmount As Nullable(Of Decimal) = Nothing
        'Private _EstimateContingencyAmount As Nullable(Of Decimal) = Nothing
        'Private _EstimateMarkupContingency As Nullable(Of Decimal) = Nothing
        Private _EstimateFunctionType As String = Nothing
        Private _EmployeeTitleID As Nullable(Of Integer) = Nothing
        Private _EstimatePhaseID As Nullable(Of Short) = Nothing
        Private _EstimatePhaseDescription As String = Nothing
        Private _JobQuantity As Nullable(Of Integer) = Nothing
        Private _CPU As Nullable(Of Decimal) = Nothing
        Private _CPM As Nullable(Of Decimal) = Nothing
        Private _EstimateComponentQuote As Nullable(Of Integer) = Nothing
        'Private _EstimateComponent As String = Nothing
        Private _InOut As String = Nothing
        Private _FunctionOption As String = Nothing
        Private _GroupOption As String = Nothing
        Private _SortOption As String = Nothing
        Private _TaxSeparate As Nullable(Of Short) = Nothing
        Private _CommissionSeparate As Nullable(Of Short) = Nothing
        Private _ContingencySeparate As Nullable(Of Short) = Nothing
        Private _IncludeContingency As Nullable(Of Short) = Nothing
        Private _PrintNonBillable As Nullable(Of Short) = Nothing
        Private _AdNumber As String = Nothing
        Private _LabelFromUDFTable1 As String = Nothing
        Private _LabelFromUDFTable2 As String = Nothing
        Private _LabelFromUDFTable3 As String = Nothing
        Private _LabelFromUDFTable4 As String = Nothing
        Private _LabelFromUDFTable5 As String = Nothing
        Private _CompLabelFromUDFTable1 As String = Nothing
        Private _CompLabelFromUDFTable2 As String = Nothing
        Private _CompLabelFromUDFTable3 As String = Nothing
        Private _CompLabelFromUDFTable4 As String = Nothing
        Private _CompLabelFromUDFTable5 As String = Nothing
        Private _OriginalAmount As Nullable(Of Decimal) = Nothing
        Private _OriginalMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _OriginalContingency As Nullable(Of Decimal) = Nothing
        Private _OriginalMarkupContingency As Nullable(Of Decimal) = Nothing
        Private _OriginalTax As Nullable(Of Decimal) = Nothing
        Private _OriginalJobQuantity As Nullable(Of Integer) = Nothing
        Private _OriginalCPU As Nullable(Of Decimal) = Nothing
        Private _OriginalCPM As Nullable(Of Decimal) = Nothing
        Private _OriginalLineTotal As Nullable(Of Decimal) = Nothing
        Private _OriginalLineContingencyTotal As Nullable(Of Decimal) = Nothing
        Private _RevisedAmount As Nullable(Of Decimal) = Nothing
        Private _RevisedMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _RevisedContingency As Nullable(Of Decimal) = Nothing
        Private _RevisedMarkupContingency As Nullable(Of Decimal) = Nothing
        Private _RevisedTax As Nullable(Of Decimal) = Nothing
        Private _RevisedJobQuantity As Nullable(Of Integer) = Nothing
        Private _RevisedCPU As Nullable(Of Decimal) = Nothing
        Private _RevisedCPM As Nullable(Of Decimal) = Nothing
        Private _RevisedLineTotal As Nullable(Of Decimal) = Nothing
        Private _RevisedLineContingencyTotal As Nullable(Of Decimal) = Nothing
        Private _FinalActual As Nullable(Of Decimal) = Nothing
        Private _OneRevision As Nullable(Of Short) = Nothing
        Private _MaxRevision As Nullable(Of Short) = Nothing
        Private _ActualMarkup As Nullable(Of Decimal) = Nothing
        Private _ActualTax As Nullable(Of Decimal) = Nothing
        Private _ActualTotal As Nullable(Of Decimal) = Nothing
        Private _NonBillableMarkup As Nullable(Of Decimal) = Nothing
        Private _NonBillableTax As Nullable(Of Decimal) = Nothing
        Private _NonBillableTotal As Nullable(Of Decimal) = Nothing
        Private _GroupingID As Nullable(Of Integer) = Nothing
        Private _OriginalApprovalType As Nullable(Of Integer) = Nothing
        Private _RevisedApprovalType As Nullable(Of Integer) = Nothing



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ProductUDF1() As String
        '    Get
        '        ProductUDF1 = _ProductUDF1
        '    End Get
        '    Set(ByVal value As String)
        '        _ProductUDF1 = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ProductUDF2() As String
        '    Get
        '        ProductUDF2 = _ProductUDF2
        '    End Get
        '    Set(ByVal value As String)
        '        _ProductUDF2 = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ProductUDF3() As String
        '    Get
        '        ProductUDF3 = _ProductUDF3
        '    End Get
        '    Set(ByVal value As String)
        '        _ProductUDF3 = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ProductUDF4() As String
        '    Get
        '        ProductUDF4 = _ProductUDF4
        '    End Get
        '    Set(ByVal value As String)
        '        _ProductUDF4 = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateNumber() As Integer
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(value As Integer)
                _EstimateNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateDescription() As String
            Get
                EstimateDescription = _EstimateDescription
            End Get
            Set(ByVal value As String)
                _EstimateDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComment() As String
            Get
                EstimateComment = _EstimateComment
            End Get
            Set(ByVal value As String)
                _EstimateComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateCommentHtml() As String
            Get
                EstimateCommentHtml = _EstimateCommentHtml
            End Get
            Set(ByVal value As String)
                _EstimateCommentHtml = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentNumber() As Short
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(value As Short)
                _EstimateComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentDescription() As String
            Get
                EstimateComponentDescription = _EstimateComponentDescription
            End Get
            Set(ByVal value As String)
                _EstimateComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentComment() As String
            Get
                EstimateComponentComment = _EstimateComponentComment
            End Get
            Set(ByVal value As String)
                _EstimateComponentComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentCommentHtml() As String
            Get
                EstimateComponentCommentHtml = _EstimateComponentCommentHtml
            End Get
            Set(ByVal value As String)
                _EstimateComponentCommentHtml = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContactID() As Nullable(Of Integer)
            Get
                EstimateContactID = _EstimateContactID
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateContactID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContactCode() As String
            Get
                EstimateContactCode = _EstimateContactCode
            End Get
            Set(ByVal value As String)
                _EstimateContactCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContactName() As String
            Get
                EstimateContactName = _EstimateContactName
            End Get
            Set(ByVal value As String)
                _EstimateContactName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContactAddress1() As String
            Get
                EstimateContactAddress1 = _EstimateContactAddress1
            End Get
            Set(ByVal value As String)
                _EstimateContactAddress1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContactAddress2() As String
            Get
                EstimateContactAddress2 = _EstimateContactAddress2
            End Get
            Set(ByVal value As String)
                _EstimateContactAddress2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContactCity() As String
            Get
                EstimateContactCity = _EstimateContactCity
            End Get
            Set(ByVal value As String)
                _EstimateContactCity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContactState() As String
            Get
                EstimateContactState = _EstimateContactState
            End Get
            Set(ByVal value As String)
                _EstimateContactState = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContactZip() As String
            Get
                EstimateContactZip = _EstimateContactZip
            End Get
            Set(ByVal value As String)
                _EstimateContactZip = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContactCountry() As String
            Get
                EstimateContactCountry = _EstimateContactCountry
            End Get
            Set(ByVal value As String)
                _EstimateContactCountry = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactPhone() As String
            Get
                EstimateContactPhone = _EstimateContactPhone
            End Get
            Set(ByVal value As String)
                _EstimateContactPhone = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactFax() As String
            Get
                EstimateContactFax = _EstimateContactFax
            End Get
            Set(ByVal value As String)
                _EstimateContactFax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactEmail() As String
            Get
                EstimateContactEmail = _EstimateContactEmail
            End Get
            Set(ByVal value As String)
                _EstimateContactEmail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactTitle() As String
            Get
                EstimateContactTitle = _EstimateContactTitle
            End Get
            Set(ByVal value As String)
                _EstimateContactTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuoteNumber() As Short
            Get
                QuoteNumber = _QuoteNumber
            End Get
            Set(value As Short)
                _QuoteNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuoteDescription() As String
            Get
                QuoteDescription = _QuoteDescription
            End Get
            Set(ByVal value As String)
                _QuoteDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuoteComment() As String
            Get
                QuoteComment = _QuoteComment
            End Get
            Set(ByVal value As String)
                _QuoteComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteCommentHtml() As String
            Get
                QuoteCommentHtml = _QuoteCommentHtml
            End Get
            Set(ByVal value As String)
                _QuoteCommentHtml = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property RevisionNumber() As Nullable(Of Short)
        '    Get
        '        RevisionNumber = _RevisionNumber
        '    End Get
        '    Set(ByVal value As Nullable(Of Short))
        '        _RevisionNumber = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisionComment() As String
            Get
                RevisionComment = _RevisionComment
            End Get
            Set(ByVal value As String)
                _RevisionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RevisionCommentHtml() As String
            Get
                RevisionCommentHtml = _RevisionCommentHtml
            End Get
            Set(ByVal value As String)
                _RevisionCommentHtml = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultComment() As String
            Get
                DefaultComment = _DefaultComment
            End Get
            Set(ByVal value As String)
                _DefaultComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultCommentHtml() As String
            Get
                DefaultCommentHtml = _DefaultCommentHtml
            End Get
            Set(ByVal value As String)
                _DefaultCommentHtml = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ApprovalType() As Nullable(Of Integer)
        '    Get
        '        ApprovalType = _ApprovalType
        '    End Get
        '    Set(ByVal value As Nullable(Of Integer))
        '        _ApprovalType = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ApprovalTypeDescription() As String
        '    Get
        '        ApprovalTypeDescription = _ApprovalTypeDescription
        '    End Get
        '    Set(ByVal value As String)
        '        _ApprovalTypeDescription = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ClientApprovalName() As String
        '    Get
        '        ClientApprovalName = _ClientApprovalName
        '    End Get
        '    Set(ByVal value As String)
        '        _ClientApprovalName = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ClientApprovalDate() As Nullable(Of Date)
        '    Get
        '        ClientApprovalDate = _ClientApprovalDate
        '    End Get
        '    Set(ByVal value As Nullable(Of Date))
        '        _ClientApprovalDate = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property InternalApprovalName() As String
        '    Get
        '        InternalApprovalName = _InternalApprovalName
        '    End Get
        '    Set(ByVal value As String)
        '        _InternalApprovalName = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property InternalApprovalDate() As Nullable(Of Date)
        '    Get
        '        InternalApprovalDate = _InternalApprovalDate
        '    End Get
        '    Set(ByVal value As Nullable(Of Date))
        '        _InternalApprovalDate = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobClientReference() As String
            Get
                JobClientReference = _JobClientReference
            End Get
            Set(ByVal value As String)
                _JobClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
       AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateCampaignID() As Nullable(Of Integer)
            Get
                EstimateCampaignID = _EstimateCampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EstimateCampaignID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateCampaignCode() As String
            Get
                EstimateCampaignCode = _EstimateCampaignCode
            End Get
            Set(ByVal value As String)
                _EstimateCampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateCampaignName() As String
            Get
                EstimateCampaignName = _EstimateCampaignName
            End Get
            Set(ByVal value As String)
                _EstimateCampaignName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property JobCreateDate() As Nullable(Of Date)
        '    Get
        '        JobCreateDate = _JobCreateDate
        '    End Get
        '    Set(ByVal value As Nullable(Of Date))
        '        _JobCreateDate = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property JobDateOpened() As Nullable(Of Date)
        '    Get
        '        JobDateOpened = _JobDateOpened
        '    End Get
        '    Set(ByVal value As Nullable(Of Date))
        '        _JobDateOpened = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutiveName() As String
            Get
                AccountExecutiveName = _AccountExecutiveName
            End Get
            Set(ByVal value As String)
                _AccountExecutiveName = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property JobClientPO() As String
        '    Get
        '        JobClientPO = _JobClientPO
        '    End Get
        '    Set(ByVal value As String)
        '        _JobClientPO = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ComponentDateOpened() As Nullable(Of Date)
        '    Get
        '        ComponentDateOpened = _ComponentDateOpened
        '    End Get
        '    Set(ByVal value As Nullable(Of Date))
        '        _ComponentDateOpened = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDueDate() As Nullable(Of Date)
            Get
                JobDueDate = _JobDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobDueDate = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property JobStartDate() As Nullable(Of Date)
        '    Get
        '        JobStartDate = _JobStartDate
        '    End Get
        '    Set(ByVal value As Nullable(Of Date))
        '        _JobStartDate = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property JobProcessingControl() As String
        '    Get
        '        JobProcessingControl = _JobProcessingControl
        '    End Get
        '    Set(ByVal value As String)
        '        _JobProcessingControl = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionHeadingID() As Nullable(Of Integer)
            Get
                FunctionHeadingID = _FunctionHeadingID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionHeadingID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionHeadingDescription() As String
            Get
                FunctionHeadingDescription = _FunctionHeadingDescription
            End Get
            Set(ByVal value As String)
                _FunctionHeadingDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionHeadingSequence() As Nullable(Of Integer)
            Get
                FunctionHeadingSequence = _FunctionHeadingSequence
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionHeadingSequence = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionOrder() As Nullable(Of Short)
            Get
                FunctionOrder = _FunctionOrder
            End Get
            Set(ByVal value As Nullable(Of Short))
                _FunctionOrder = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property SequenceNumber() As Nullable(Of Integer)
        '    Get
        '        SequenceNumber = _SequenceNumber
        '    End Get
        '    Set(ByVal value As Nullable(Of Integer))
        '        _SequenceNumber = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DetailComments() As String
            Get
                DetailComments = _DetailComments
            End Get
            Set(ByVal value As String)
                _DetailComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DetailCommentsHtml() As String
            Get
                DetailCommentsHtml = _DetailCommentsHtml
            End Get
            Set(ByVal value As String)
                _DetailCommentsHtml = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property SuppliedByCode() As String
        '    Get
        '        SuppliedByCode = _SuppliedByCode
        '    End Get
        '    Set(ByVal value As String)
        '        _SuppliedByCode = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property SuppliedByName() As String
        '    Get
        '        SuppliedByName = _SuppliedByName
        '    End Get
        '    Set(ByVal value As String)
        '        _SuppliedByName = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SuppliedByNotes() As String
            Get
                SuppliedByNotes = _SuppliedByNotes
            End Get
            Set(ByVal value As String)
                _SuppliedByNotes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SuppliedByNotesHtml() As String
            Get
                SuppliedByNotesHtml = _SuppliedByNotesHtml
            End Get
            Set(ByVal value As String)
                _SuppliedByNotesHtml = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateQuantity() As Nullable(Of Decimal)
        '    Get
        '        EstimateQuantity = _EstimateQuantity
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateQuantity = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateRate() As Nullable(Of Decimal)
        '    Get
        '        EstimateRate = _EstimateRate
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateRate = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateExtAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateExtAmount = _EstimateExtAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateExtAmount = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateNetAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateNetAmount = _EstimateNetAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateNetAmount = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateCostAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateCostAmount = _EstimateCostAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateCostAmount = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateTaxAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateTaxAmount = _EstimateTaxAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateTaxAmount = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateMarkupAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateMarkupAmount = _EstimateMarkupAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateMarkupAmount = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateTotalAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateTotalAmount = _EstimateTotalAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateTotalAmount = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateContingencyAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateContingencyAmount = _EstimateContingencyAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateContingencyAmount = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateMarkupContingency() As Nullable(Of Decimal)
        '    Get
        '        EstimateMarkupContingency = _EstimateMarkupContingency
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateMarkupContingency = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateFunctionType() As String
            Get
                EstimateFunctionType = _EstimateFunctionType
            End Get
            Set(ByVal value As String)
                _EstimateFunctionType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
            Get
                EmployeeTitleID = _EmployeeTitleID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EmployeeTitleID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimatePhaseID() As Nullable(Of Short)
            Get
                EstimatePhaseID = _EstimatePhaseID
            End Get
            Set(ByVal value As Nullable(Of Short))
                _EstimatePhaseID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimatePhaseDescription() As String
            Get
                EstimatePhaseDescription = _EstimatePhaseDescription
            End Get
            Set(ByVal value As String)
                _EstimatePhaseDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobQuantity() As Nullable(Of Integer)
            Get
                JobQuantity = _JobQuantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CPU() As Nullable(Of Decimal)
            Get
                CPU = _CPU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CPU = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CPM() As Nullable(Of Decimal)
            Get
                CPM = _CPM
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CPM = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentQuote() As Nullable(Of Integer)
            Get
                EstimateComponentQuote = _EstimateComponentQuote
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EstimateComponentQuote = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EstimateComponent() As String
        '    Get
        '        EstimateComponent = _EstimateComponent
        '    End Get
        '    Set(ByVal value As String)
        '        _EstimateComponent = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InOut() As String
            Get
                InOut = _InOut
            End Get
            Set(ByVal value As String)
                _InOut = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionOption() As String
            Get
                FunctionOption = _FunctionOption
            End Get
            Set(ByVal value As String)
                _FunctionOption = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupOption() As String
            Get
                GroupOption = _GroupOption
            End Get
            Set(ByVal value As String)
                _GroupOption = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SortOption() As String
            Get
                SortOption = _SortOption
            End Get
            Set(ByVal value As String)
                _SortOption = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxSeparate() As Nullable(Of Short)
            Get
                TaxSeparate = _TaxSeparate
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TaxSeparate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionSeparate() As Nullable(Of Short)
            Get
                CommissionSeparate = _CommissionSeparate
            End Get
            Set(ByVal value As Nullable(Of Short))
                _CommissionSeparate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ContingencySeparate() As Nullable(Of Short)
            Get
                ContingencySeparate = _ContingencySeparate
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ContingencySeparate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeContingency() As Nullable(Of Short)
            Get
                IncludeContingency = _IncludeContingency
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IncludeContingency = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintNonBillable() As Nullable(Of Short)
            Get
                PrintNonBillable = _PrintNonBillable
            End Get
            Set(ByVal value As Nullable(Of Short))
                _PrintNonBillable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(ByVal value As String)
                _AdNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable1() As String
            Get
                LabelFromUDFTable1 = _LabelFromUDFTable1
            End Get
            Set(value As String)
                _LabelFromUDFTable1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable2() As String
            Get
                LabelFromUDFTable2 = _LabelFromUDFTable2
            End Get
            Set(value As String)
                _LabelFromUDFTable2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable3() As String
            Get
                LabelFromUDFTable3 = _LabelFromUDFTable3
            End Get
            Set(value As String)
                _LabelFromUDFTable3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable4() As String
            Get
                LabelFromUDFTable4 = _LabelFromUDFTable4
            End Get
            Set(value As String)
                _LabelFromUDFTable4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable5() As String
            Get
                LabelFromUDFTable5 = _LabelFromUDFTable5
            End Get
            Set(value As String)
                _LabelFromUDFTable5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable1() As String
            Get
                CompLabelFromUDFTable1 = _CompLabelFromUDFTable1
            End Get
            Set(value As String)
                _CompLabelFromUDFTable1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable2() As String
            Get
                CompLabelFromUDFTable2 = _CompLabelFromUDFTable2
            End Get
            Set(value As String)
                _CompLabelFromUDFTable2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable3() As String
            Get
                CompLabelFromUDFTable3 = _CompLabelFromUDFTable3
            End Get
            Set(value As String)
                _CompLabelFromUDFTable3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable4() As String
            Get
                CompLabelFromUDFTable4 = _CompLabelFromUDFTable4
            End Get
            Set(value As String)
                _CompLabelFromUDFTable4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable5() As String
            Get
                CompLabelFromUDFTable5 = _CompLabelFromUDFTable5
            End Get
            Set(value As String)
                _CompLabelFromUDFTable5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalAmount() As Nullable(Of Decimal)
            Get
                OriginalAmount = _OriginalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OriginalAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalMarkupAmount() As Nullable(Of Decimal)
            Get
                OriginalMarkupAmount = _OriginalMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OriginalMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalContingency() As Nullable(Of Decimal)
            Get
                OriginalContingency = _OriginalContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OriginalContingency = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalMarkupContingency() As Nullable(Of Decimal)
            Get
                OriginalMarkupContingency = _OriginalMarkupContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OriginalMarkupContingency = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalTax() As Nullable(Of Decimal)
            Get
                OriginalTax = _OriginalTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OriginalTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalJobQuantity() As Nullable(Of Integer)
            Get
                OriginalJobQuantity = _OriginalJobQuantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _OriginalJobQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalCPU() As Nullable(Of Decimal)
            Get
                OriginalCPU = _OriginalCPU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OriginalCPU = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalCPM() As Nullable(Of Decimal)
            Get
                OriginalCPM = _OriginalCPM
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OriginalCPM = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalLineTotal() As Nullable(Of Decimal)
            Get
                OriginalLineTotal = _OriginalLineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OriginalLineTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalLineContingencyTotal() As Nullable(Of Decimal)
            Get
                OriginalLineContingencyTotal = _OriginalLineContingencyTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OriginalLineContingencyTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedAmount() As Nullable(Of Decimal)
            Get
                RevisedAmount = _RevisedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RevisedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedMarkupAmount() As Nullable(Of Decimal)
            Get
                RevisedMarkupAmount = _RevisedMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RevisedMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedContingency() As Nullable(Of Decimal)
            Get
                RevisedContingency = _RevisedContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RevisedContingency = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedMarkupContingency() As Nullable(Of Decimal)
            Get
                RevisedMarkupContingency = _RevisedMarkupContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RevisedMarkupContingency = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedTax() As Nullable(Of Decimal)
            Get
                RevisedTax = _RevisedTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RevisedTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedJobQuantity() As Nullable(Of Integer)
            Get
                RevisedJobQuantity = _RevisedJobQuantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _RevisedJobQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedCPU() As Nullable(Of Decimal)
            Get
                RevisedCPU = _RevisedCPU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RevisedCPU = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedCPM() As Nullable(Of Decimal)
            Get
                RevisedCPM = _RevisedCPM
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RevisedCPM = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedLineTotal() As Nullable(Of Decimal)
            Get
                RevisedLineTotal = _RevisedLineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RevisedLineTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedLineContingencyTotal() As Nullable(Of Decimal)
            Get
                RevisedLineContingencyTotal = _RevisedLineContingencyTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RevisedLineContingencyTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FinalActual() As Nullable(Of Decimal)
            Get
                FinalActual = _FinalActual
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _FinalActual = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OneRevision() As Nullable(Of Short)
            Get
                OneRevision = _OneRevision
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OneRevision = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaxRevision() As Nullable(Of Short)
            Get
                MaxRevision = _MaxRevision
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MaxRevision = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualMarkup() As Nullable(Of Decimal)
            Get
                ActualMarkup = _ActualMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualMarkup = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualTax() As Nullable(Of Decimal)
            Get
                ActualTax = _ActualTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualTotal() As Nullable(Of Decimal)
            Get
                ActualTotal = _ActualTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableMarkup() As Nullable(Of Decimal)
            Get
                NonBillableMarkup = _NonBillableMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableMarkup = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableTax() As Nullable(Of Decimal)
            Get
                NonBillableTax = _NonBillableTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableTotal() As Nullable(Of Decimal)
            Get
                NonBillableTotal = _NonBillableTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupingID() As Nullable(Of Integer)
            Get
                GroupingID = _GroupingID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _GroupingID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalApprovalType() As Nullable(Of Integer)
            Get
                OriginalApprovalType = _OriginalApprovalType
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _OriginalApprovalType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisedApprovalType() As Nullable(Of Integer)
            Get
                RevisedApprovalType = _RevisedApprovalType
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _RevisedApprovalType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EstimateNumber.ToString

        End Function

#End Region

    End Class

End Namespace

