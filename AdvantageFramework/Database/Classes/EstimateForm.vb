Namespace Database.Classes

    <Serializable()>
    Public Class EstimateForm

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            ClientBillingAddress
            ClientBillingAddress2
            ClientBillingCity
            ClientBillingCounty
            ClientBillingState
            ClientBillingZip
            ClientBillingCountry
            DivisionCode
            DivisionName
            DivisionBillingAddress
            DivisionBillingAddress2
            DivisionBillingCity
            DivisionBillingCounty
            DivisionBillingState
            DivisionBillingZip
            DivisionBillingCountry
            ProductCode
            ProductDescription
            ProductBillingAddress
            ProductBillingAddress2
            ProductBillingCity
            ProductBillingCounty
            ProductBillingState
            ProductBillingZip
            ProductBillingCountry
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            EstimateNumber
            EstimateDescription
            EstimateComment
            EstimateCommentHTML
            EstimateComponentNumber
            EstimateComponentDescription
            EstimateComponentComment
            EstimateComponentCommentHTML
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
            QuoteCommentHTML
            RevisionNumber
            RevisionComment
            RevisionCommentHTML
            DefaultComment
            DefaultCommentHTML
            ApprovalType
            ApprovalTypeDescription
            ClientApprovalName
            ClientApprovalDate
            InternalApprovalName
            InternalApprovalDate
            JobNumber
            JobDescription
            JobClientReference
            CampaignID
            CampaignCode
            CampaignName
            SalesClassCode
            SalesClassDescription
            JobCreateDate
            JobDateOpened
            JobComponentNumber
            JobComponentDescription
            AccountExecutiveCode
            AccountExecutiveName
            JobClientPO
            ComponentDateOpened
            JobDueDate
            JobStartDate
            JobProcessingControl
            FunctionType
            FunctionHeadingID
            FunctionHeadingDescription
            FunctionHeadingOrder
            FunctionCode
            FunctionDescription
            FunctionOrder
            SequenceNumber
            DetailComments
            DetailCommentsHTML
            SuppliedByCode
            SuppliedByName
            SuppliedByNotes
            SuppliedByNotesHTML
            EstimateQuantity
            EstimateRate
            EstimateExtAmount
            EstimateNetAmount
            EstimateCostAmount
            EstimateTaxAmount
            EstimateMarkupAmount
            EstimateTotalAmount
            EstimateContingencyAmount
            EstimateMarkupContingency
            EstimateFunctionType
            EmployeeTitleID
            EmployeeTitle
            EstimatePhaseID
            EstimatePhaseDescription
            JobQuantity
            CPU
            CPM
            EstimateComponentQuote
            EstimateComponent
            InOut
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

        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _ClientBillingAddress As String = Nothing
        Private _ClientBillingAddress2 As String = Nothing
        Private _ClientBillingCity As String = Nothing
        Private _ClientBillingCounty As String = Nothing
        Private _ClientBillingState As String = Nothing
        Private _ClientBillingZip As String = Nothing
        Private _ClientBillingCountry As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _DivisionBillingAddress As String = Nothing
        Private _DivisionBillingAddress2 As String = Nothing
        Private _DivisionBillingCity As String = Nothing
        Private _DivisionBillingCounty As String = Nothing
        Private _DivisionBillingState As String = Nothing
        Private _DivisionBillingZip As String = Nothing
        Private _DivisionBillingCountry As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _ProductBillingAddress As String = Nothing
        Private _ProductBillingAddress2 As String = Nothing
        Private _ProductBillingCity As String = Nothing
        Private _ProductBillingCounty As String = Nothing
        Private _ProductBillingState As String = Nothing
        Private _ProductBillingZip As String = Nothing
        Private _ProductBillingCountry As String = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _EstimateNumber As Integer = Nothing
        Private _EstimateDescription As String = Nothing
        Private _EstimateComment As String = Nothing
        Private _EstimateCommentHTML As String = Nothing
        Private _EstimateComponentNumber As Short = Nothing
        Private _EstimateComponentDescription As String = Nothing
        Private _EstimateComponentComment As String = Nothing
        Private _EstimateComponentCommentHTML As String = Nothing
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
        Private _QuoteCommentHTML As String = Nothing
        Private _RevisionNumber As Nullable(Of Short) = Nothing
        Private _RevisionComment As String = Nothing
        Private _RevisionCommentHTML As String = Nothing
        Private _DefaultComment As String = Nothing
        Private _DefaultCommentHTML As String = Nothing
        Private _ApprovalType As Nullable(Of Integer) = Nothing
        Private _ApprovalTypeDescription As String = Nothing
        Private _ClientApprovalName As String = Nothing
        Private _ClientApprovalDate As Nullable(Of Date) = Nothing
        Private _InternalApprovalName As String = Nothing
        Private _InternalApprovalDate As Nullable(Of Date) = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobClientReference As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _JobCreateDate As Nullable(Of Date) = Nothing
        Private _JobDateOpened As Nullable(Of Date) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutiveName As String = Nothing
        Private _JobClientPO As String = Nothing
        Private _ComponentDateOpened As Nullable(Of Date) = Nothing
        Private _JobDueDate As Nullable(Of Date) = Nothing
        Private _JobStartDate As Nullable(Of Date) = Nothing
        Private _JobProcessingControl As String = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionHeadingID As Nullable(Of Integer) = Nothing
        Private _FunctionHeadingDescription As String = Nothing
        Private _FunctionHeadingOrder As Nullable(Of Integer) = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionOrder As Nullable(Of Short) = Nothing
        Private _SequenceNumber As Nullable(Of Integer) = Nothing
        Private _DetailComments As String = Nothing
        Private _DetailCommentsHTML As String = Nothing
        Private _SuppliedByCode As String = Nothing
        Private _SuppliedByName As String = Nothing
        Private _SuppliedByNotes As String = Nothing
        Private _SuppliedByNotesHTML As String = Nothing
        Private _EstimateQuantity As Nullable(Of Decimal) = Nothing
        Private _EstimateRate As Nullable(Of Decimal) = Nothing
        Private _EstimateExtAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateNetAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateCostAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateTaxAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateTotalAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateContingencyAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupContingency As Nullable(Of Decimal) = Nothing
        Private _EstimateFunctionType As String = Nothing
        Private _EmployeeTitleID As Nullable(Of Integer) = Nothing
        Private _EmployeeTitle As String = Nothing
        Private _EstimatePhaseID As Nullable(Of Short) = Nothing
        Private _EstimatePhaseDescription As String = Nothing
        Private _JobQuantity As Nullable(Of Integer) = Nothing
        Private _CPU As Nullable(Of Decimal) = Nothing
        Private _CPM As Nullable(Of Decimal) = Nothing
        Private _EstimateComponentQuote As String = Nothing
        Private _EstimateComponent As String = Nothing
        Private _InOut As String = Nothing
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
        Public Property ClientBillingAddress() As String
            Get
                ClientBillingAddress = _ClientBillingAddress
            End Get
            Set(ByVal value As String)
                _ClientBillingAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingAddress2() As String
            Get
                ClientBillingAddress2 = _ClientBillingAddress2
            End Get
            Set(ByVal value As String)
                _ClientBillingAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingCity() As String
            Get
                ClientBillingCity = _ClientBillingCity
            End Get
            Set(ByVal value As String)
                _ClientBillingCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingCounty() As String
            Get
                ClientBillingCounty = _ClientBillingCounty
            End Get
            Set(ByVal value As String)
                _ClientBillingCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingState() As String
            Get
                ClientBillingState = _ClientBillingState
            End Get
            Set(ByVal value As String)
                _ClientBillingState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingZip() As String
            Get
                ClientBillingZip = _ClientBillingZip
            End Get
            Set(ByVal value As String)
                _ClientBillingZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientBillingCountry() As String
            Get
                ClientBillingCountry = _ClientBillingCountry
            End Get
            Set(ByVal value As String)
                _ClientBillingCountry = value
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
        Public Property DivisionBillingAddress() As String
            Get
                DivisionBillingAddress = _DivisionBillingAddress
            End Get
            Set(ByVal value As String)
                _DivisionBillingAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionBillingAddress2() As String
            Get
                DivisionBillingAddress2 = _DivisionBillingAddress2
            End Get
            Set(ByVal value As String)
                _DivisionBillingAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionBillingCity() As String
            Get
                DivisionBillingCity = _DivisionBillingCity
            End Get
            Set(ByVal value As String)
                _DivisionBillingCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionBillingCounty() As String
            Get
                DivisionBillingCounty = _DivisionBillingCounty
            End Get
            Set(ByVal value As String)
                _DivisionBillingCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionBillingState() As String
            Get
                DivisionBillingState = _DivisionBillingState
            End Get
            Set(ByVal value As String)
                _DivisionBillingState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionBillingZip() As String
            Get
                DivisionBillingZip = _DivisionBillingZip
            End Get
            Set(ByVal value As String)
                _DivisionBillingZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionBillingCountry() As String
            Get
                DivisionBillingCountry = _DivisionBillingCountry
            End Get
            Set(ByVal value As String)
                _DivisionBillingCountry = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingAddress() As String
            Get
                ProductBillingAddress = _ProductBillingAddress
            End Get
            Set(ByVal value As String)
                _ProductBillingAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingAddress2() As String
            Get
                ProductBillingAddress2 = _ProductBillingAddress2
            End Get
            Set(ByVal value As String)
                _ProductBillingAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingCity() As String
            Get
                ProductBillingCity = _ProductBillingCity
            End Get
            Set(ByVal value As String)
                _ProductBillingCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingCounty() As String
            Get
                ProductBillingCounty = _ProductBillingCounty
            End Get
            Set(ByVal value As String)
                _ProductBillingCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingState() As String
            Get
                ProductBillingState = _ProductBillingState
            End Get
            Set(ByVal value As String)
                _ProductBillingState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingZip() As String
            Get
                ProductBillingZip = _ProductBillingZip
            End Get
            Set(ByVal value As String)
                _ProductBillingZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductBillingCountry() As String
            Get
                ProductBillingCountry = _ProductBillingCountry
            End Get
            Set(ByVal value As String)
                _ProductBillingCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(ByVal value As String)
                _ProductUDF1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(ByVal value As String)
                _ProductUDF2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(ByVal value As String)
                _ProductUDF3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(ByVal value As String)
                _ProductUDF4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
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
        Public Property EstimateCommentHTML() As String
            Get
                EstimateCommentHTML = _EstimateCommentHTML
            End Get
            Set(ByVal value As String)
                _EstimateCommentHTML = value
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
        Public Property EstimateComponentCommentHTML() As String
            Get
                EstimateComponentCommentHTML = _EstimateComponentCommentHTML
            End Get
            Set(ByVal value As String)
                _EstimateComponentCommentHTML = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteNumber() As Short
            Get
                QuoteNumber = _QuoteNumber
            End Get
            Set(value As Short)
                _QuoteNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuoteDescription() As String
            Get
                QuoteDescription = _QuoteDescription
            End Get
            Set(ByVal value As String)
                _QuoteDescription = value
            End Set
        End Property
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
        Public Property QuoteCommentHTML() As String
            Get
                QuoteCommentHTML = _QuoteCommentHTML
            End Get
            Set(ByVal value As String)
                _QuoteCommentHTML = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RevisionNumber() As Nullable(Of Short)
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RevisionNumber = value
            End Set
        End Property
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
        Public Property RevisionCommentHTML() As String
            Get
                RevisionCommentHTML = _RevisionCommentHTML
            End Get
            Set(ByVal value As String)
                _RevisionCommentHTML = value
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
        Public Property DefaultCommentHTML() As String
            Get
                DefaultCommentHTML = _DefaultCommentHTML
            End Get
            Set(ByVal value As String)
                _DefaultCommentHTML = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalType() As Nullable(Of Integer)
            Get
                ApprovalType = _ApprovalType
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ApprovalType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalTypeDescription() As String
            Get
                ApprovalTypeDescription = _ApprovalTypeDescription
            End Get
            Set(ByVal value As String)
                _ApprovalTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientApprovalName() As String
            Get
                ClientApprovalName = _ClientApprovalName
            End Get
            Set(ByVal value As String)
                _ClientApprovalName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientApprovalDate() As Nullable(Of Date)
            Get
                ClientApprovalDate = _ClientApprovalDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ClientApprovalDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternalApprovalName() As String
            Get
                InternalApprovalName = _InternalApprovalName
            End Get
            Set(ByVal value As String)
                _InternalApprovalName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternalApprovalDate() As Nullable(Of Date)
            Get
                InternalApprovalDate = _InternalApprovalDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InternalApprovalDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(ByVal value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(ByVal value As String)
                _CampaignName = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCreateDate() As Nullable(Of Date)
            Get
                JobCreateDate = _JobCreateDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobCreateDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDateOpened() As Nullable(Of Date)
            Get
                JobDateOpened = _JobDateOpened
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobDateOpened = value
            End Set
        End Property
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobClientPO() As String
            Get
                JobClientPO = _JobClientPO
            End Get
            Set(ByVal value As String)
                _JobClientPO = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDateOpened() As Nullable(Of Date)
            Get
                ComponentDateOpened = _ComponentDateOpened
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ComponentDateOpened = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDueDate() As Nullable(Of Date)
            Get
                JobDueDate = _JobDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobDueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobStartDate() As Nullable(Of Date)
            Get
                JobStartDate = _JobStartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobStartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobProcessingControl() As String
            Get
                JobProcessingControl = _JobProcessingControl
            End Get
            Set(ByVal value As String)
                _JobProcessingControl = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
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
        Public Property FunctionHeadingOrder() As Nullable(Of Integer)
            Get
                FunctionHeadingOrder = _FunctionHeadingOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionHeadingOrder = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Nullable(Of Integer)
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _SequenceNumber = value
            End Set
        End Property
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
        Public Property DetailCommentsHTML() As String
            Get
                DetailCommentsHTML = _DetailCommentsHTML
            End Get
            Set(ByVal value As String)
                _DetailCommentsHTML = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByCode() As String
            Get
                SuppliedByCode = _SuppliedByCode
            End Get
            Set(ByVal value As String)
                _SuppliedByCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByName() As String
            Get
                SuppliedByName = _SuppliedByName
            End Get
            Set(ByVal value As String)
                _SuppliedByName = value
            End Set
        End Property
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
        Public Property SuppliedByNotesHTML() As String
            Get
                SuppliedByNotesHTML = _SuppliedByNotesHTML
            End Get
            Set(ByVal value As String)
                _SuppliedByNotesHTML = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateQuantity() As Nullable(Of Decimal)
            Get
                EstimateQuantity = _EstimateQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateRate() As Nullable(Of Decimal)
            Get
                EstimateRate = _EstimateRate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateExtAmount() As Nullable(Of Decimal)
            Get
                EstimateExtAmount = _EstimateExtAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateExtAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateNetAmount() As Nullable(Of Decimal)
            Get
                EstimateNetAmount = _EstimateNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateCostAmount() As Nullable(Of Decimal)
            Get
                EstimateCostAmount = _EstimateCostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateCostAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateTaxAmount() As Nullable(Of Decimal)
            Get
                EstimateTaxAmount = _EstimateTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateMarkupAmount() As Nullable(Of Decimal)
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateTotalAmount() As Nullable(Of Decimal)
            Get
                EstimateTotalAmount = _EstimateTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateContingencyAmount() As Nullable(Of Decimal)
            Get
                EstimateContingencyAmount = _EstimateContingencyAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateContingencyAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateMarkupContingency() As Nullable(Of Decimal)
            Get
                EstimateMarkupContingency = _EstimateMarkupContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateMarkupContingency = value
            End Set
        End Property
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
        Public Property EmployeeTitle() As String
            Get
                EmployeeTitle = _EmployeeTitle
            End Get
            Set(ByVal value As String)
                _EmployeeTitle = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Inside/Outside")>
        Public Property InOut() As String
            Get
                InOut = _InOut
            End Get
            Set(ByVal value As String)
                _InOut = value
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


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
