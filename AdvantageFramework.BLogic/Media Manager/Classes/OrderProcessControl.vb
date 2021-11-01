Namespace MediaManager.Classes

    <Serializable()>
    Public Class OrderProcessControl
        Inherits BaseClasses.BaseClass

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
            OrderNumber
            OrderDescription
            LineNumber
            OrderProcessControl
            NewProcessControl
            LineComplete
            QualifiedToClose
            ProcessControlComments
            BillableAmount
            BilledAmount
            TotalCostPayableToVendor
            ActualAmountPosted
            'CreatedDate
            ProcessedDate
            LastProcessControl
        End Enum

#End Region

#Region " Variables "

        Private _MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
        Private _NewProcessControl As Nullable(Of Short) = Nothing
        Private _ProcessControlComments As String = Nothing
        Private _ProcessedDate As Nullable(Of Date) = Nothing
        'Private _CreatedDate As Nullable(Of Date) = Nothing
        Private _LastProcessControl As String = Nothing
        Private _QualifiedToClose As Boolean = False

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail
            Get
                MediaManagerReviewDetail = _MediaManagerReviewDetail
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _MediaManagerReviewDetail.ClientCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ClientName() As String
            Get
                ClientName = _MediaManagerReviewDetail.ClientName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DivisionCode() As String
            Get
                DivisionCode = _MediaManagerReviewDetail.DivisionCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DivisionName() As String
            Get
                DivisionName = _MediaManagerReviewDetail.DivisionName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ProductCode() As String
            Get
                ProductCode = _MediaManagerReviewDetail.ProductCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ProductDescription() As String
            Get
                ProductDescription = _MediaManagerReviewDetail.ProductDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property OrderNumber() As Integer
            Get
                OrderNumber = _MediaManagerReviewDetail.OrderNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property OrderDescription() As String
            Get
                OrderDescription = _MediaManagerReviewDetail.OrderDescription
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property LineNumber() As Integer
            Get
                LineNumber = _MediaManagerReviewDetail.LineNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Process Control")>
        Public ReadOnly Property OrderProcessControl() As String
            Get
                OrderProcessControl = _MediaManagerReviewDetail.OrderProcessControl
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.OrderProcess)>
        Public Property NewProcessControl() As Nullable(Of Short)
            Get
                NewProcessControl = _NewProcessControl
            End Get
            Set(value As Nullable(Of Short))
                _NewProcessControl = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public ReadOnly Property LineComplete() As Boolean
            Get
                LineComplete = (_MediaManagerReviewDetail.OrderLineIsBilled OrElse _MediaManagerReviewDetail.BillableAmount = 0) AndAlso (_MediaManagerReviewDetail.BillableAmount = _MediaManagerReviewDetail.BilledAmount) AndAlso
                    (_MediaManagerReviewDetail.TotalCostPayableToVendor.GetValueOrDefault(0) = _MediaManagerReviewDetail.ActualAmountPosted.GetValueOrDefault(0))
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Quote() As Boolean
            Get
                Quote = _MediaManagerReviewDetail.Quote
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property QualifiedToClose() As Boolean
            Get
                QualifiedToClose = _QualifiedToClose
            End Get
            Set(value As Boolean)
                _QualifiedToClose = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property ProcessControlComments() As String
            Get
                ProcessControlComments = _ProcessControlComments
            End Get
            Set(value As String)
                _ProcessControlComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property BillableAmount() As Decimal
            Get
                BillableAmount = _MediaManagerReviewDetail.BillableAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property BilledAmount() As Nullable(Of Decimal)
            Get
                BilledAmount = _MediaManagerReviewDetail.BilledAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property TotalCostPayableToVendor() As Nullable(Of Decimal)
            Get
                TotalCostPayableToVendor = _MediaManagerReviewDetail.TotalCostPayableToVendor.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property ActualAmountPosted() As Nullable(Of Decimal)
            Get
                ActualAmountPosted = _MediaManagerReviewDetail.ActualAmountPosted.GetValueOrDefault(0)
            End Get
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date Opened")>
        'Public ReadOnly Property CreatedDate() As Nullable(Of Date)
        '    Get
        '        CreatedDate = _CreatedDate
        '    End Get
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Process Control Date")>
        Public ReadOnly Property ProcessedDate() As Nullable(Of Date)
            Get
                ProcessedDate = _ProcessedDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property LastProcessControl() As String
            Get
                LastProcessControl = _LastProcessControl
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property AmountsAreZero() As Boolean
            Get
                AmountsAreZero = _MediaManagerReviewDetail.VCCCardID.HasValue = False AndAlso _MediaManagerReviewDetail.BillableAmount = 0 AndAlso
                    _MediaManagerReviewDetail.NetAmount.GetValueOrDefault(0) = 0 AndAlso _MediaManagerReviewDetail.CommissionAmount.GetValueOrDefault(0) = 0 AndAlso
                    _MediaManagerReviewDetail.AdditionalChargeAmount.GetValueOrDefault(0) = 0 AndAlso _MediaManagerReviewDetail.NetChargeAmount.GetValueOrDefault(0) = 0 AndAlso
                    _MediaManagerReviewDetail.UnbilledTotal.GetValueOrDefault(0) = 0
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext,
                       ByVal MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail,
                       ByVal JobProcessList As Generic.List(Of AdvantageFramework.Database.Entities.JobProcess))

            Dim OrderProcessLog As AdvantageFramework.Database.Entities.OrderProcessLog = Nothing

            _MediaManagerReviewDetail = MediaManagerReviewDetail

            OrderProcessLog = AdvantageFramework.Database.Procedures.OrderProcessLog.LoadLatestByOrderNumber(DbContext, MediaManagerReviewDetail.OrderNumber)

            If OrderProcessLog IsNot Nothing Then

                _ProcessedDate = OrderProcessLog.ProcessedDate

                If OrderProcessLog.OriginalProcessControl.HasValue Then

                    _LastProcessControl = JobProcessList.Where(Function(JP) JP.ID = OrderProcessLog.OriginalProcessControl.Value).FirstOrDefault.Description

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace
