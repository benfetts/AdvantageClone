Namespace Estimate.Printing.Classes

    <Serializable()>
    Public Class EstimatePrintDetail301

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
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            ProductAttention
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
            QuoteNumber
            QuoteDescription
            QuoteComment
            QuoteCommentHtml
            RevisionNumber
            RevisionComment
            RevisionCommentHtml
            JobNumber
            JobDescription
            JobClientReference
            SalesClassCode
            SalesClassDescription
            JobComponentNumber
            JobComponentDescription
            AccountExecutiveCode
            AccountExecutiveName
            JobClientPO
            JobDueDate
            JobBudget
            PIF
            FiscalPeriod
            FunctionType
            FunctionCode
            FunctionDescription
            FunctionOrder
            DetailComments
            DetailCommentsHtml
            SuppliedByCode
            SuppliedByName
            SuppliedByNotes
            SuppliedByNotesHtml
            EstimateQuantity
            EstimateRate
            EstimateExtAmount
            EstimateTaxAmount
            EstimateMarkupAmount
            EstimateTotalAmount
            EstimateTotalContingencyAmount
            EstimateContingencyAmount
            EstimateMarkupContingency
            EstimateFunctionType
            EmployeeTitleID
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
            TacticID
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _ProductAttention As String = Nothing
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
        Private _QuoteNumber As Short = Nothing
        Private _QuoteDescription As String = Nothing
        Private _QuoteComment As String = Nothing
        Private _QuoteCommentHtml As String = Nothing
        Private _RevisionNumber As Nullable(Of Short) = Nothing
        Private _RevisionComment As String = Nothing
        Private _RevisionCommentHtml As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobClientReference As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutiveName As String = Nothing
        Private _JobClientPO As String = Nothing
        Private _JobDueDate As Nullable(Of Date) = Nothing
        Private _JobBudget As Nullable(Of Decimal) = Nothing
        Private _PIF As String = Nothing
        Private _FiscalPeriod As String = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionOrder As Nullable(Of Short) = Nothing
        Private _DetailComments As String = Nothing
        Private _DetailCommentsHtml As String = Nothing
        Private _SuppliedByCode As String = Nothing
        Private _SuppliedByName As String = Nothing
        Private _SuppliedByNotes As String = Nothing
        Private _SuppliedByNotesHtml As String = Nothing
        Private _EstimateQuantity As Nullable(Of Decimal) = Nothing
        Private _EstimateRate As Nullable(Of Decimal) = Nothing
        Private _EstimateExtAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateTaxAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateTotalAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateTotalContingencyAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateContingencyAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupContingency As Nullable(Of Decimal) = Nothing
        Private _EstimateFunctionType As String = Nothing
        Private _EmployeeTitleID As Nullable(Of Integer) = Nothing
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
        Private _TacticID As String = Nothing



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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(ByVal value As String)
                _ProductUDF1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(ByVal value As String)
                _ProductUDF2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(ByVal value As String)
                _ProductUDF3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(ByVal value As String)
                _ProductUDF4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductAttention() As String
            Get
                ProductAttention = _ProductAttention
            End Get
            Set(ByVal value As String)
                _ProductAttention = value
            End Set
        End Property
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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RevisionNumber() As Nullable(Of Short)
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RevisionNumber = value
            End Set
        End Property
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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobClientPO() As String
            Get
                JobClientPO = _JobClientPO
            End Get
            Set(ByVal value As String)
                _JobClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDueDate() As Nullable(Of Date)
            Get
                JobDueDate = _JobDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property JobBudget() As Nullable(Of Decimal)
            Get
                JobBudget = _JobBudget
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _JobBudget = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PIF() As String
            Get
                PIF = _PIF
            End Get
            Set(ByVal value As String)
                _PIF = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FiscalPeriod() As String
            Get
                FiscalPeriod = _FiscalPeriod
            End Get
            Set(ByVal value As String)
                _FiscalPeriod = value
            End Set
        End Property
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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SuppliedByCode() As String
            Get
                SuppliedByCode = _SuppliedByCode
            End Get
            Set(ByVal value As String)
                _SuppliedByCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SuppliedByName() As String
            Get
                SuppliedByName = _SuppliedByName
            End Get
            Set(ByVal value As String)
                _SuppliedByName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SuppliedByNotes() As String
            Get
                SuppliedByNotes = _SuppliedByNotes
            End Get
            Set(ByVal value As String)
                _SuppliedByNotes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByNotesHtml() As String
            Get
                SuppliedByNotesHtml = _SuppliedByNotesHtml
            End Get
            Set(ByVal value As String)
                _SuppliedByNotesHtml = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateQuantity() As Nullable(Of Decimal)
            Get
                EstimateQuantity = _EstimateQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateRate() As Nullable(Of Decimal)
            Get
                EstimateRate = _EstimateRate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateExtAmount() As Nullable(Of Decimal)
            Get
                EstimateExtAmount = _EstimateExtAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateExtAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateTaxAmount() As Nullable(Of Decimal)
            Get
                EstimateTaxAmount = _EstimateTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateMarkupAmount() As Nullable(Of Decimal)
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateTotalAmount() As Nullable(Of Decimal)
            Get
                EstimateTotalAmount = _EstimateTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTotalAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateTotalContingencyAmount() As Nullable(Of Decimal)
            Get
                EstimateTotalContingencyAmount = _EstimateTotalContingencyAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTotalContingencyAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContingencyAmount() As Nullable(Of Decimal)
            Get
                EstimateContingencyAmount = _EstimateContingencyAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateContingencyAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateMarkupContingency() As Nullable(Of Decimal)
            Get
                EstimateMarkupContingency = _EstimateMarkupContingency
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateMarkupContingency = value
            End Set
        End Property
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
        Public Property EstimateComponentQuote() As String
            Get
                EstimateComponentQuote = _EstimateComponentQuote
            End Get
            Set(ByVal value As String)
                _EstimateComponentQuote = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponent() As String
            Get
                EstimateComponent = _EstimateComponent
            End Get
            Set(ByVal value As String)
                _EstimateComponent = value
            End Set
        End Property
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
        Public Property TacticID() As String
            Get
                TacticID = _TacticID
            End Get
            Set(ByVal value As String)
                _TacticID = value
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

