Namespace Database.Classes

    <Serializable()>
    Public Class EstimatePrintDetail002

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
            'QuoteNumber
            'QuoteDescription
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
            EstimateComponent
            InOut
            FunctionOption
            GroupOption
            SortOption
            TaxSeparate
            CommissionSeparate
            ContingencySeparate
            IncludeContingency
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
            Quote1
            Quote1Markup
            Quote1Contingency
            Quote1MarkupContingency
            Quote1Tax
            Quote1JobQuantity
            Quote1CPU
            Quote1CPM
            Quote1LineTotal
            Quote2
            Quote2Markup
            Quote2Contingency
            Quote2MarkupContingency
            Quote2Tax
            Quote2JobQuantity
            Quote2CPU
            Quote2CPM
            Quote2LineTotal
            Quote3
            Quote3Markup
            Quote3Contingency
            Quote3MarkupContingency
            Quote3Tax
            Quote3JobQuantity
            Quote3CPU
            Quote3CPM
            Quote3LineTotal
            Quote4
            Quote4Markup
            Quote4Contingency
            Quote4MarkupContingency
            Quote4Tax
            Quote4JobQuantity
            Quote4CPU
            Quote4CPM
            Quote4LineTotal
            Quote1LineContingencyTotal
            Quote2LineContingencyTotal
            Quote3LineContingencyTotal
            Quote4LineContingencyTotal
            Quote1QuoteComment
            Quote1QuoteCommentHtml
            Quote2QuoteComment
            Quote2QuoteCommentHtml
            Quote3QuoteComment
            Quote3QuoteCommentHtml
            Quote4QuoteComment
            Quote4QuoteCommentHtml
            GroupingID
            Quote1ApprovalType
            Quote2ApprovalType
            Quote3ApprovalType
            Quote4ApprovalType

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
        'Private _QuoteNumber As Short = Nothing
        'Private _QuoteDescription As String = Nothing
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
        Private _EstimateComponentQuote As String = Nothing
        Private _EstimateComponent As String = Nothing
        Private _InOut As String = Nothing
        Private _FunctionOption As String = Nothing
        Private _GroupOption As String = Nothing
        Private _SortOption As String = Nothing
        Private _TaxSeparate As Nullable(Of Short) = Nothing
        Private _CommissionSeparate As Nullable(Of Short) = Nothing
        Private _ContingencySeparate As Nullable(Of Short) = Nothing
        Private _IncludeContingency As Nullable(Of Short) = Nothing
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
        Private _Quote1 As Nullable(Of Decimal) = Nothing
        Private _Quote1Markup As Nullable(Of Decimal) = Nothing
        Private _Quote1Contingency As Nullable(Of Decimal) = Nothing
        Private _Quote1MarkupContingency As Nullable(Of Decimal) = Nothing
        Private _Quote1Tax As Nullable(Of Decimal) = Nothing
        Private _Quote1JobQuantity As Nullable(Of Integer) = Nothing
        Private _Quote1CPU As Nullable(Of Decimal) = Nothing
        Private _Quote1CPM As Nullable(Of Decimal) = Nothing
        Private _Quote1LineTotal As Nullable(Of Decimal) = Nothing
        Private _Quote2 As Nullable(Of Decimal) = Nothing
        Private _Quote2Markup As Nullable(Of Decimal) = Nothing
        Private _Quote2Contingency As Nullable(Of Decimal) = Nothing
        Private _Quote2MarkupContingency As Nullable(Of Decimal) = Nothing
        Private _Quote2Tax As Nullable(Of Decimal) = Nothing
        Private _Quote2JobQuantity As Nullable(Of Integer) = Nothing
        Private _Quote2CPU As Nullable(Of Decimal) = Nothing
        Private _Quote2CPM As Nullable(Of Decimal) = Nothing
        Private _Quote2LineTotal As Nullable(Of Decimal) = Nothing
        Private _Quote3 As Nullable(Of Decimal) = Nothing
        Private _Quote3Markup As Nullable(Of Decimal) = Nothing
        Private _Quote3Contingency As Nullable(Of Decimal) = Nothing
        Private _Quote3MarkupContingency As Nullable(Of Decimal) = Nothing
        Private _Quote3Tax As Nullable(Of Decimal) = Nothing
        Private _Quote3JobQuantity As Nullable(Of Integer) = Nothing
        Private _Quote3CPU As Nullable(Of Decimal) = Nothing
        Private _Quote3CPM As Nullable(Of Decimal) = Nothing
        Private _Quote3LineTotal As Nullable(Of Decimal) = Nothing
        Private _Quote4 As Nullable(Of Decimal) = Nothing
        Private _Quote4Markup As Nullable(Of Decimal) = Nothing
        Private _Quote4Contingency As Nullable(Of Decimal) = Nothing
        Private _Quote4MarkupContingency As Nullable(Of Decimal) = Nothing
        Private _Quote4Tax As Nullable(Of Decimal) = Nothing
        Private _Quote4JobQuantity As Nullable(Of Integer) = Nothing
        Private _Quote4CPU As Nullable(Of Decimal) = Nothing
        Private _Quote4CPM As Nullable(Of Decimal) = Nothing
        Private _Quote4LineTotal As Nullable(Of Decimal) = Nothing
        Private _Quote1LineContingencyTotal As Nullable(Of Decimal) = Nothing
        Private _Quote2LineContingencyTotal As Nullable(Of Decimal) = Nothing
        Private _Quote3LineContingencyTotal As Nullable(Of Decimal) = Nothing
        Private _Quote4LineContingencyTotal As Nullable(Of Decimal) = Nothing
        Private _Quote1QuoteComment As String = Nothing
        Private _Quote1QuoteCommentHtml As String = Nothing
        Private _Quote2QuoteComment As String = Nothing
        Private _Quote2QuoteCommentHtml As String = Nothing
        Private _Quote3QuoteComment As String = Nothing
        Private _Quote3QuoteCommentHtml As String = Nothing
        Private _Quote4QuoteComment As String = Nothing
        Private _Quote4QuoteCommentHtml As String = Nothing
        Private _GroupingID As Nullable(Of Integer) = Nothing
        Private _Quote1ApprovalType As Nullable(Of Integer) = Nothing
        Private _Quote2ApprovalType As Nullable(Of Integer) = Nothing
        Private _Quote3ApprovalType As Nullable(Of Integer) = Nothing
        Private _Quote4ApprovalType As Nullable(Of Integer) = Nothing


#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property ProductUDF1() As String
        '    Get
        '        ProductUDF1 = _ProductUDF1
        '    End Get
        '    Set(ByVal value As String)
        '        _ProductUDF1 = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property ProductUDF2() As String
        '    Get
        '        ProductUDF2 = _ProductUDF2
        '    End Get
        '    Set(ByVal value As String)
        '        _ProductUDF2 = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property ProductUDF3() As String
        '    Get
        '        ProductUDF3 = _ProductUDF3
        '    End Get
        '    Set(ByVal value As String)
        '        _ProductUDF3 = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property ProductUDF4() As String
        '    Get
        '        ProductUDF4 = _ProductUDF4
        '    End Get
        '    Set(ByVal value As String)
        '        _ProductUDF4 = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateNumber() As Integer
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(value As Integer)
                _EstimateNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateDescription() As String
            Get
                EstimateDescription = _EstimateDescription
            End Get
            Set(ByVal value As String)
                _EstimateDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComment() As String
            Get
                EstimateComment = _EstimateComment
            End Get
            Set(ByVal value As String)
                _EstimateComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateCommentHtml() As String
            Get
                EstimateCommentHtml = _EstimateCommentHtml
            End Get
            Set(ByVal value As String)
                _EstimateCommentHtml = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentNumber() As Short
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(value As Short)
                _EstimateComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentDescription() As String
            Get
                EstimateComponentDescription = _EstimateComponentDescription
            End Get
            Set(ByVal value As String)
                _EstimateComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentComment() As String
            Get
                EstimateComponentComment = _EstimateComponentComment
            End Get
            Set(ByVal value As String)
                _EstimateComponentComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentCommentHtml() As String
            Get
                EstimateComponentCommentHtml = _EstimateComponentCommentHtml
            End Get
            Set(ByVal value As String)
                _EstimateComponentCommentHtml = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactID() As Nullable(Of Integer)
            Get
                EstimateContactID = _EstimateContactID
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateContactID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactCode() As String
            Get
                EstimateContactCode = _EstimateContactCode
            End Get
            Set(ByVal value As String)
                _EstimateContactCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactName() As String
            Get
                EstimateContactName = _EstimateContactName
            End Get
            Set(ByVal value As String)
                _EstimateContactName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactAddress1() As String
            Get
                EstimateContactAddress1 = _EstimateContactAddress1
            End Get
            Set(ByVal value As String)
                _EstimateContactAddress1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactAddress2() As String
            Get
                EstimateContactAddress2 = _EstimateContactAddress2
            End Get
            Set(ByVal value As String)
                _EstimateContactAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactCity() As String
            Get
                EstimateContactCity = _EstimateContactCity
            End Get
            Set(ByVal value As String)
                _EstimateContactCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactState() As String
            Get
                EstimateContactState = _EstimateContactState
            End Get
            Set(ByVal value As String)
                _EstimateContactState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactZip() As String
            Get
                EstimateContactZip = _EstimateContactZip
            End Get
            Set(ByVal value As String)
                _EstimateContactZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactCountry() As String
            Get
                EstimateContactCountry = _EstimateContactCountry
            End Get
            Set(ByVal value As String)
                _EstimateContactCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactPhone() As String
            Get
                EstimateContactPhone = _EstimateContactPhone
            End Get
            Set(ByVal value As String)
                _EstimateContactPhone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactFax() As String
            Get
                EstimateContactFax = _EstimateContactFax
            End Get
            Set(ByVal value As String)
                _EstimateContactFax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactEmail() As String
            Get
                EstimateContactEmail = _EstimateContactEmail
            End Get
            Set(ByVal value As String)
                _EstimateContactEmail = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateContactTitle() As String
            Get
                EstimateContactTitle = _EstimateContactTitle
            End Get
            Set(ByVal value As String)
                _EstimateContactTitle = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property QuoteNumber() As Short
        '    Get
        '        QuoteNumber = _QuoteNumber
        '    End Get
        '    Set(value As Short)
        '        _QuoteNumber = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property QuoteDescription() As String
        '    Get
        '        QuoteDescription = _QuoteDescription
        '    End Get
        '    Set(ByVal value As String)
        '        _QuoteDescription = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteComment() As String
            Get
                QuoteComment = _QuoteComment
            End Get
            Set(ByVal value As String)
                _QuoteComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteCommentHtml() As String
            Get
                QuoteCommentHtml = _QuoteCommentHtml
            End Get
            Set(ByVal value As String)
                _QuoteCommentHtml = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property RevisionNumber() As Nullable(Of Short)
        '    Get
        '        RevisionNumber = _RevisionNumber
        '    End Get
        '    Set(ByVal value As Nullable(Of Short))
        '        _RevisionNumber = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RevisionComment() As String
            Get
                RevisionComment = _RevisionComment
            End Get
            Set(ByVal value As String)
                _RevisionComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RevisionCommentHtml() As String
            Get
                RevisionCommentHtml = _RevisionCommentHtml
            End Get
            Set(ByVal value As String)
                _RevisionCommentHtml = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultComment() As String
            Get
                DefaultComment = _DefaultComment
            End Get
            Set(ByVal value As String)
                _DefaultComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultCommentHtml() As String
            Get
                DefaultCommentHtml = _DefaultCommentHtml
            End Get
            Set(ByVal value As String)
                _DefaultCommentHtml = value
            End Set
        End Property
        ' <' AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property ApprovalType() As Nullable(Of Integer)
        '     Get
        '         ApprovalType = _ApprovalType
        '     End Get
        '     Set(ByVal value As Nullable(Of Integer))
        '         _ApprovalType = value
        '     End Set
        ' End Property
        ' <' AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property ApprovalTypeDescription() As String
        '     Get
        '         ApprovalTypeDescription = _ApprovalTypeDescription
        '     End Get
        '     Set(ByVal value As String)
        '         _ApprovalTypeDescription = value
        '     End Set
        ' End Property
        ' <' AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property ClientApprovalName() As String
        '     Get
        '         ClientApprovalName = _ClientApprovalName
        '     End Get
        '     Set(ByVal value As String)
        '         _ClientApprovalName = value
        '     End Set
        ' End Property
        ' <'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property ClientApprovalDate() As Nullable(Of Date)
        '     Get
        '         ClientApprovalDate = _ClientApprovalDate
        '     End Get
        '     Set(ByVal value As Nullable(Of Date))
        '         _ClientApprovalDate = value
        '     End Set
        ' End Property
        ' <' AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property InternalApprovalName() As String
        '     Get
        '         InternalApprovalName = _InternalApprovalName
        '     End Get
        '     Set(ByVal value As String)
        '         _InternalApprovalName = value
        '     End Set
        ' End Property
        ' <'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property InternalApprovalDate() As Nullable(Of Date)
        '     Get
        '         InternalApprovalDate = _InternalApprovalDate
        '     End Get
        '     Set(ByVal value As Nullable(Of Date))
        '         _InternalApprovalDate = value
        '     End Set
        ' End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobClientReference() As String
            Get
                JobClientReference = _JobClientReference
            End Get
            Set(ByVal value As String)
                _JobClientReference = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateCampaignID() As Nullable(Of Integer)
            Get
                EstimateCampaignID = _EstimateCampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EstimateCampaignID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateCampaignCode() As String
            Get
                EstimateCampaignCode = _EstimateCampaignCode
            End Get
            Set(ByVal value As String)
                _EstimateCampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateCampaignName() As String
            Get
                EstimateCampaignName = _EstimateCampaignName
            End Get
            Set(ByVal value As String)
                _EstimateCampaignName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        ' <'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property JobCreateDate() As Nullable(Of Date)
        '     Get
        '         JobCreateDate = _JobCreateDate
        '     End Get
        '     Set(ByVal value As Nullable(Of Date))
        '         _JobCreateDate = value
        '     End Set
        ' End Property
        ' <'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property JobDateOpened() As Nullable(Of Date)
        '     Get
        '         JobDateOpened = _JobDateOpened
        '     End Get
        '     Set(ByVal value As Nullable(Of Date))
        '         _JobDateOpened = value
        '     End Set
        ' End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveName() As String
            Get
                AccountExecutiveName = _AccountExecutiveName
            End Get
            Set(ByVal value As String)
                _AccountExecutiveName = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property JobClientPO() As String
        '    Get
        '        JobClientPO = _JobClientPO
        '    End Get
        '    Set(ByVal value As String)
        '        _JobClientPO = value
        '    End Set
        'End Property
        ' <'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property ComponentDateOpened() As Nullable(Of Date)
        '     Get
        '         ComponentDateOpened = _ComponentDateOpened
        '     End Get
        '     Set(ByVal value As Nullable(Of Date))
        '         _ComponentDateOpened = value
        '     End Set
        ' End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDueDate() As Nullable(Of Date)
            Get
                JobDueDate = _JobDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobDueDate = value
            End Set
        End Property
        ' <'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        ' Public Property JobStartDate() As Nullable(Of Date)
        '     Get
        '         JobStartDate = _JobStartDate
        '     End Get
        '     Set(ByVal value As Nullable(Of Date))
        '         _JobStartDate = value
        '     End Set
        ' End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property JobProcessingControl() As String
        '    Get
        '        JobProcessingControl = _JobProcessingControl
        '    End Get
        '    Set(ByVal value As String)
        '        _JobProcessingControl = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeadingID() As Nullable(Of Integer)
            Get
                FunctionHeadingID = _FunctionHeadingID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionHeadingID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeadingDescription() As String
            Get
                FunctionHeadingDescription = _FunctionHeadingDescription
            End Get
            Set(ByVal value As String)
                _FunctionHeadingDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeadingSequence() As Nullable(Of Integer)
            Get
                FunctionHeadingSequence = _FunctionHeadingSequence
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionHeadingSequence = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionOrder() As Nullable(Of Short)
            Get
                FunctionOrder = _FunctionOrder
            End Get
            Set(ByVal value As Nullable(Of Short))
                _FunctionOrder = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property SequenceNumber() As Nullable(Of Integer)
        '    Get
        '        SequenceNumber = _SequenceNumber
        '    End Get
        '    Set(ByVal value As Nullable(Of Integer))
        '        _SequenceNumber = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DetailComments() As String
            Get
                DetailComments = _DetailComments
            End Get
            Set(ByVal value As String)
                _DetailComments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DetailCommentsHtml() As String
            Get
                DetailCommentsHtml = _DetailCommentsHtml
            End Get
            Set(ByVal value As String)
                _DetailCommentsHtml = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property SuppliedByCode() As String
        '    Get
        '        SuppliedByCode = _SuppliedByCode
        '    End Get
        '    Set(ByVal value As String)
        '        _SuppliedByCode = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property SuppliedByName() As String
        '    Get
        '        SuppliedByName = _SuppliedByName
        '    End Get
        '    Set(ByVal value As String)
        '        _SuppliedByName = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByNotes() As String
            Get
                SuppliedByNotes = _SuppliedByNotes
            End Get
            Set(ByVal value As String)
                _SuppliedByNotes = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByNotesHtml() As String
            Get
                SuppliedByNotesHtml = _SuppliedByNotesHtml
            End Get
            Set(ByVal value As String)
                _SuppliedByNotesHtml = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateQuantity() As Nullable(Of Decimal)
        '    Get
        '        EstimateQuantity = _EstimateQuantity
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateQuantity = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateRate() As Nullable(Of Decimal)
        '    Get
        '        EstimateRate = _EstimateRate
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateRate = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateExtAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateExtAmount = _EstimateExtAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateExtAmount = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateNetAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateNetAmount = _EstimateNetAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateNetAmount = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateCostAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateCostAmount = _EstimateCostAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateCostAmount = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateTaxAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateTaxAmount = _EstimateTaxAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateTaxAmount = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateMarkupAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateMarkupAmount = _EstimateMarkupAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateMarkupAmount = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateTotalAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateTotalAmount = _EstimateTotalAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateTotalAmount = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateContingencyAmount() As Nullable(Of Decimal)
        '    Get
        '        EstimateContingencyAmount = _EstimateContingencyAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateContingencyAmount = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property EstimateMarkupContingency() As Nullable(Of Decimal)
        '    Get
        '        EstimateMarkupContingency = _EstimateMarkupContingency
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _EstimateMarkupContingency = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateFunctionType() As String
            Get
                EstimateFunctionType = _EstimateFunctionType
            End Get
            Set(ByVal value As String)
                _EstimateFunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
            Get
                EmployeeTitleID = _EmployeeTitleID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EmployeeTitleID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimatePhaseID() As Nullable(Of Short)
            Get
                EstimatePhaseID = _EstimatePhaseID
            End Get
            Set(ByVal value As Nullable(Of Short))
                _EstimatePhaseID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimatePhaseDescription() As String
            Get
                EstimatePhaseDescription = _EstimatePhaseDescription
            End Get
            Set(ByVal value As String)
                _EstimatePhaseDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobQuantity() As Nullable(Of Integer)
            Get
                JobQuantity = _JobQuantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CPU() As Nullable(Of Decimal)
            Get
                CPU = _CPU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CPU = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CPM() As Nullable(Of Decimal)
            Get
                CPM = _CPM
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CPM = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentQuote() As String
            Get
                EstimateComponentQuote = _EstimateComponentQuote
            End Get
            Set(ByVal value As String)
                _EstimateComponentQuote = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponent() As String
            Get
                EstimateComponent = _EstimateComponent
            End Get
            Set(ByVal value As String)
                _EstimateComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InOut() As String
            Get
                InOut = _InOut
            End Get
            Set(ByVal value As String)
                _InOut = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionOption() As String
            Get
                FunctionOption = _FunctionOption
            End Get
            Set(ByVal value As String)
                _FunctionOption = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupOption() As String
            Get
                GroupOption = _GroupOption
            End Get
            Set(ByVal value As String)
                _GroupOption = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortOption() As String
            Get
                SortOption = _SortOption
            End Get
            Set(ByVal value As String)
                _SortOption = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxSeparate() As Nullable(Of Short)
            Get
                TaxSeparate = _TaxSeparate
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TaxSeparate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionSeparate() As Nullable(Of Short)
            Get
                CommissionSeparate = _CommissionSeparate
            End Get
            Set(ByVal value As Nullable(Of Short))
                _CommissionSeparate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContingencySeparate() As Nullable(Of Short)
            Get
                ContingencySeparate = _ContingencySeparate
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ContingencySeparate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeContingency() As Nullable(Of Short)
            Get
                IncludeContingency = _IncludeContingency
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IncludeContingency = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1() As Nullable(Of Decimal)
            Get
                Quote1 = _Quote1
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1Markup() As Nullable(Of Decimal)
            Get
                Quote1Markup = _Quote1Markup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote1Markup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1Contingency() As Nullable(Of Decimal)
            Get
                Quote1Contingency = _Quote1Contingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote1Contingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1MarkupContingency() As Nullable(Of Decimal)
            Get
                Quote1MarkupContingency = _Quote1MarkupContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote1MarkupContingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1Tax() As Nullable(Of Decimal)
            Get
                Quote1Tax = _Quote1Tax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote1Tax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1JobQuantity() As Nullable(Of Integer)
            Get
                Quote1JobQuantity = _Quote1JobQuantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quote1JobQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1CPU() As Nullable(Of Decimal)
            Get
                Quote1CPU = _Quote1CPU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote1CPU = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1CPM() As Nullable(Of Decimal)
            Get
                Quote1CPM = _Quote1CPM
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote1CPM = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1LineTotal() As Nullable(Of Decimal)
            Get
                Quote1LineTotal = _Quote1LineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote1LineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2() As Nullable(Of Decimal)
            Get
                Quote2 = _Quote2
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2Markup() As Nullable(Of Decimal)
            Get
                Quote2Markup = _Quote2Markup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote2Markup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2Contingency() As Nullable(Of Decimal)
            Get
                Quote2Contingency = _Quote2Contingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote2Contingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2MarkupContingency() As Nullable(Of Decimal)
            Get
                Quote2MarkupContingency = _Quote2MarkupContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote2MarkupContingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2Tax() As Nullable(Of Decimal)
            Get
                Quote2Tax = _Quote2Tax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote2Tax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2JobQuantity() As Nullable(Of Integer)
            Get
                Quote2JobQuantity = _Quote2JobQuantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quote2JobQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2CPU() As Nullable(Of Decimal)
            Get
                Quote2CPU = _Quote2CPU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote2CPU = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2CPM() As Nullable(Of Decimal)
            Get
                Quote2CPM = _Quote2CPM
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote2CPM = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2LineTotal() As Nullable(Of Decimal)
            Get
                Quote2LineTotal = _Quote2LineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote2LineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3() As Nullable(Of Decimal)
            Get
                Quote3 = _Quote3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3Markup() As Nullable(Of Decimal)
            Get
                Quote3Markup = _Quote3Markup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote3Markup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3Contingency() As Nullable(Of Decimal)
            Get
                Quote3Contingency = _Quote3Contingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote3Contingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3MarkupContingency() As Nullable(Of Decimal)
            Get
                Quote3MarkupContingency = _Quote3MarkupContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote3MarkupContingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3Tax() As Nullable(Of Decimal)
            Get
                Quote3Tax = _Quote3Tax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote3Tax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3JobQuantity() As Nullable(Of Integer)
            Get
                Quote3JobQuantity = _Quote3JobQuantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quote3JobQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3CPU() As Nullable(Of Decimal)
            Get
                Quote3CPU = _Quote3CPU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote3CPU = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3CPM() As Nullable(Of Decimal)
            Get
                Quote3CPM = _Quote3CPM
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote3CPM = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3LineTotal() As Nullable(Of Decimal)
            Get
                Quote3LineTotal = _Quote3LineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote3LineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4() As Nullable(Of Decimal)
            Get
                Quote4 = _Quote4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4Markup() As Nullable(Of Decimal)
            Get
                Quote4Markup = _Quote4Markup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote4Markup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4Contingency() As Nullable(Of Decimal)
            Get
                Quote4Contingency = _Quote4Contingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote4Contingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4MarkupContingency() As Nullable(Of Decimal)
            Get
                Quote4MarkupContingency = _Quote4MarkupContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote4MarkupContingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4Tax() As Nullable(Of Decimal)
            Get
                Quote4Tax = _Quote4Tax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote4Tax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4JobQuantity() As Nullable(Of Integer)
            Get
                Quote4JobQuantity = _Quote4JobQuantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quote4JobQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4CPU() As Nullable(Of Decimal)
            Get
                Quote4CPU = _Quote4CPU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote4CPU = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4CPM() As Nullable(Of Decimal)
            Get
                Quote4CPM = _Quote4CPM
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote4CPM = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4LineTotal() As Nullable(Of Decimal)
            Get
                Quote4LineTotal = _Quote4LineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote4LineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote1LineContingencyTotal() As Nullable(Of Decimal)
            Get
                Quote1LineContingencyTotal = _Quote1LineContingencyTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote1LineContingencyTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote2LineContingencyTotal() As Nullable(Of Decimal)
            Get
                Quote2LineContingencyTotal = _Quote2LineContingencyTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote2LineContingencyTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote3LineContingencyTotal() As Nullable(Of Decimal)
            Get
                Quote3LineContingencyTotal = _Quote3LineContingencyTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote3LineContingencyTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quote4LineContingencyTotal() As Nullable(Of Decimal)
            Get
                Quote4LineContingencyTotal = _Quote4LineContingencyTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quote4LineContingencyTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quote1QuoteComment() As String
            Get
                Quote1QuoteComment = _Quote1QuoteComment
            End Get
            Set(ByVal value As String)
                _Quote1QuoteComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quote1QuoteCommentHtml() As String
            Get
                Quote1QuoteCommentHtml = _Quote1QuoteCommentHtml
            End Get
            Set(ByVal value As String)
                _Quote1QuoteCommentHtml = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quote2QuoteComment() As String
            Get
                Quote2QuoteComment = _Quote2QuoteComment
            End Get
            Set(ByVal value As String)
                _Quote2QuoteComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quote2QuoteCommentHtml() As String
            Get
                Quote2QuoteCommentHtml = _Quote2QuoteCommentHtml
            End Get
            Set(ByVal value As String)
                _Quote2QuoteCommentHtml = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quote3QuoteComment() As String
            Get
                Quote3QuoteComment = _Quote3QuoteComment
            End Get
            Set(ByVal value As String)
                _Quote3QuoteComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quote3QuoteCommentHtml() As String
            Get
                Quote3QuoteCommentHtml = _Quote3QuoteCommentHtml
            End Get
            Set(ByVal value As String)
                _Quote3QuoteCommentHtml = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quote4QuoteComment() As String
            Get
                Quote4QuoteComment = _Quote4QuoteComment
            End Get
            Set(ByVal value As String)
                _Quote4QuoteComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quote4QuoteCommentHtml() As String
            Get
                Quote4QuoteCommentHtml = _Quote4QuoteCommentHtml
            End Get
            Set(ByVal value As String)
                _Quote4QuoteCommentHtml = value
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
        Public Property Quote1ApprovalType() As Nullable(Of Integer)
            Get
                Quote1ApprovalType = _Quote1ApprovalType
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quote1ApprovalType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Quote2ApprovalType() As Nullable(Of Integer)
            Get
                Quote2ApprovalType = _Quote2ApprovalType
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quote2ApprovalType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Quote3ApprovalType() As Nullable(Of Integer)
            Get
                Quote3ApprovalType = _Quote3ApprovalType
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quote3ApprovalType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Quote4ApprovalType() As Nullable(Of Integer)
            Get
                Quote4ApprovalType = _Quote4ApprovalType
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quote4ApprovalType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
