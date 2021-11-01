Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ClientInvoiceDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ARInvoiceNumber
            ARInvoiceSequenceNumber
            ARDescription
            Category
            InvoiceDate
            OriginalInvoiceAmount
            CurrentBalance
            PaymentAmount
            GLACodeAdjustment
            GLACodeAdjustmentDescription
            AdjustmentAmount
            DivisionCode
            ProductCode
            OfficeCode
            SalesClassCode
            CollectionNote
            GeneralLedgerOfficeCrossReferenceCode
            PaymentAmountCopy
            AdjustmentAmountCopy
            GLACodeAdjustmentCopy
            CollectionNoteCopy
            OtherPayments
            ClientCashReceiptID
            ClientCashReceiptSequenceNumber
            ClientCashReceiptDetailItemID
        End Enum

#End Region

#Region " Variables "

        Private _ARInvoiceNumber As Integer = Nothing
        Private _ARInvoiceSequenceNumber As Short = Nothing
        Private _ARDescription As String = Nothing
        Private _Category As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _OriginalInvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _PaymentAmount As Nullable(Of Decimal) = Nothing
        Private _GLACodeAdjustment As String = Nothing
        Private _GLACodeAdjustmentDescription As String = Nothing
        Private _AdjustmentAmount As Nullable(Of Decimal) = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _CollectionNote As String = Nothing
        Private _GeneralLedgerOfficeCrossReferenceCode As String = Nothing
        Private _GLACodeAR As String = Nothing
        Private _ARType As String = Nothing
        Private _PaymentAmountCopy As Nullable(Of Decimal) = Nothing
        Private _AdjustmentAmountCopy As Nullable(Of Decimal) = Nothing
        Private _GLACodeAdjustmentCopy As String = Nothing
        Private _CollectionNoteCopy As String = Nothing
        Private _OtherPayments As Nullable(Of Decimal) = Nothing
        Private _ClientCashReceiptID As Nullable(Of Integer) = Nothing
        Private _ClientCashReceiptSequenceNumber As Nullable(Of Short) = Nothing
        Private _ClientCashReceiptDetailItemID As Nullable(Of Short) = Nothing
        Private _ClientCashReceiptPaymentDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail) = Nothing
        Private _ClientCashReceiptsPartialPaymentRequired As Boolean = False
        Private _IsManualInvoice As Boolean = False
        Private _HasBeenVoided As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Invoice Number")>
        Public Property ARInvoiceNumber() As Integer
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(value As Integer)
                _ARInvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Seq Nbr")>
        Public Property ARInvoiceSequenceNumber() As Short
            Get
                ARInvoiceSequenceNumber = _ARInvoiceSequenceNumber
            End Get
            Set(value As Short)
                _ARInvoiceSequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Description")>
        Public Property ARDescription() As String
            Get
                ARDescription = _ARDescription
            End Get
            Set(value As String)
                _ARDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Category() As String
            Get
                Category = _Category
            End Get
            Set(value As String)
                _Category = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Invoice Amount")>
        Public Property OriginalInvoiceAmount() As Decimal
            Get
                OriginalInvoiceAmount = _OriginalInvoiceAmount
            End Get
            Set(value As Decimal)
                _OriginalInvoiceAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property CurrentBalance() As Decimal
            Get
                CurrentBalance = _OriginalInvoiceAmount.GetValueOrDefault(0) - _OtherPayments.GetValueOrDefault(0) - _PaymentAmount.GetValueOrDefault(0) - AdjustmentAmount.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PaymentAmount() As Nullable(Of Decimal)
            Get
                PaymentAmount = _PaymentAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _PaymentAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode, CustomColumnCaption:="GL Account")>
        Public Property GLACodeAdjustment() As String
            Get
                GLACodeAdjustment = _GLACodeAdjustment
            End Get
            Set(value As String)
                _GLACodeAdjustment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="GL Account Description", DefaultColumnType:=BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription)>
        Public Property GLACodeAdjustmentDescription() As String
            Get
                GLACodeAdjustmentDescription = _GLACodeAdjustmentDescription
            End Get
            Set(value As String)
                _GLACodeAdjustmentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Write Off Amount")>
        Public Property AdjustmentAmount() As Nullable(Of Decimal)
            Get
                AdjustmentAmount = _AdjustmentAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AdjustmentAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.SalesClassCode)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CollectionNote() As String
            Get
                CollectionNote = _CollectionNote
            End Get
            Set(value As String)
                _CollectionNote = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GeneralLedgerOfficeCrossReferenceCode() As String
            Get
                GeneralLedgerOfficeCrossReferenceCode = _GeneralLedgerOfficeCrossReferenceCode
            End Get
            Set(value As String)
                _GeneralLedgerOfficeCrossReferenceCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GLACodeAR() As String
            Get
                GLACodeAR = _GLACodeAR
            End Get
            Set(value As String)
                _GLACodeAR = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ARType() As String
            Get
                ARType = _ARType
            End Get
            Set(value As String)
                _ARType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False)>
        Public Property PaymentAmountCopy() As Nullable(Of Decimal)
            Get
                PaymentAmountCopy = _PaymentAmountCopy
            End Get
            Set(value As Nullable(Of Decimal))
                _PaymentAmountCopy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False)>
        Public Property AdjustmentAmountCopy() As Nullable(Of Decimal)
            Get
                AdjustmentAmountCopy = _AdjustmentAmountCopy
            End Get
            Set(value As Nullable(Of Decimal))
                _AdjustmentAmountCopy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GLACodeAdjustmentCopy() As String
            Get
                GLACodeAdjustmentCopy = _GLACodeAdjustmentCopy
            End Get
            Set(value As String)
                _GLACodeAdjustmentCopy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CollectionNoteCopy() As String
            Get
                CollectionNoteCopy = _CollectionNoteCopy
            End Get
            Set(value As String)
                _CollectionNoteCopy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False)>
        Public Property OtherPayments() As Nullable(Of Decimal)
            Get
                OtherPayments = _OtherPayments
            End Get
            Set(value As Nullable(Of Decimal))
                _OtherPayments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ClientCashReceiptID() As Nullable(Of Integer)
            Get
                ClientCashReceiptID = _ClientCashReceiptID
            End Get
            Set(value As Nullable(Of Integer))
                _ClientCashReceiptID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ClientCashReceiptSequenceNumber() As Nullable(Of Short)
            Get
                ClientCashReceiptSequenceNumber = _ClientCashReceiptSequenceNumber
            End Get
            Set(value As Nullable(Of Short))
                _ClientCashReceiptSequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ClientCashReceiptDetailItemID() As Nullable(Of Short)
            Get
                ClientCashReceiptDetailItemID = _ClientCashReceiptDetailItemID
            End Get
            Set(value As Nullable(Of Short))
                _ClientCashReceiptDetailItemID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsManualInvoice() As Boolean
            Get
                IsManualInvoice = _IsManualInvoice
            End Get
            Set(value As Boolean)
                _IsManualInvoice = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property HasBeenVoided As Boolean
            Get
                HasBeenVoided = _HasBeenVoided
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

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.GLACodeAdjustment.ToString

                        If Me.AdjustmentAmount.GetValueOrDefault(0) <> 0 Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.PaymentAmount.ToString

                    PropertyValue = Value

                    If _ClientCashReceiptPaymentDetailList Is Nothing Then

                        LoadPaymentDetail(DbContext)

                    End If

                    If Me.CurrentBalance <> 0 AndAlso _ClientCashReceiptsPartialPaymentRequired AndAlso _IsManualInvoice = False Then

                        If _ClientCashReceiptPaymentDetailList.Sum(Function(CCRPP) CCRPP.PaymentAmount) <> Me.PaymentAmount Then

                            IsValid = False

                            ErrorText = "Payment detail total does not match payment amount."

                        End If

                    End If

                Case AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.GLACodeAdjustment.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If (From Entity In AdvantageFramework.CashReceipts.GetAdjustmentGLAccountList(DbContext, Me.OfficeCode, Me.Session)
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid GL Account."

                        End If

                    End If

                Case AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.ARInvoiceNumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso (Me.AdjustmentAmount <> 0 OrElse Me.PaymentAmount <> 0 OrElse String.IsNullOrWhiteSpace(Me.CollectionNote) = False) Then

                        If (From Entity In AdvantageFramework.Database.Procedures.AccountReceivable.LoadAllByInvoiceNumberAndSequenceNumber(DbContext, DirectCast(PropertyValue, Integer), Me.ARInvoiceSequenceNumber)
                            Where Entity.IsVoided = 1
                            Select Entity).Any Then

                            _HasBeenVoided = True

                            IsValid = False

                            ErrorText = "Invoice has since been voided, please zero amounts and clear collection note."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Private Sub LoadPaymentDetail(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim ClientCashReceiptDetailPaymentList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment) = Nothing
            Dim ClientCashReceiptDetailPayment As AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment = Nothing

            'Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

            _ClientCashReceiptsPartialPaymentRequired = AdvantageFramework.Agency.GetOptionClientCashReceiptsPartialPaymentRequired(DataContext)

            'End Using

            If _ClientCashReceiptPaymentDetailList Is Nothing Then

                _ClientCashReceiptPaymentDetailList = New Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail)

                _ClientCashReceiptPaymentDetailList.AddRange(From ARS In AdvantageFramework.Database.Procedures.AccountReceivableSummary.LoadByARInvoiceSeqType(DbContext, Me.ARInvoiceNumber, Me.ARInvoiceSequenceNumber, Me.ARType).ToList
                                                             Select New AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail(ARS, _ClientCashReceiptsPartialPaymentRequired))

            End If

            If Me.ClientCashReceiptID IsNot Nothing AndAlso Me.ClientCashReceiptSequenceNumber IsNot Nothing AndAlso Me.ClientCashReceiptDetailItemID IsNot Nothing Then

                ClientCashReceiptDetailPaymentList = AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.LoadByClientCashReceiptDetailIDandSeqandItemID(DbContext, Me.ClientCashReceiptID, Me.ClientCashReceiptSequenceNumber, Me.ClientCashReceiptDetailItemID).ToList

                If ClientCashReceiptDetailPaymentList IsNot Nothing AndAlso ClientCashReceiptDetailPaymentList.Count > 0 Then

                    For Each ClientCashReceiptPaymentDetail In _ClientCashReceiptPaymentDetailList

                        If ClientCashReceiptPaymentDetail.JobNumber IsNot Nothing Then

                            ClientCashReceiptDetailPayment = ClientCashReceiptDetailPaymentList.Where(Function(CCRDP) CCRDP.JobNumber = ClientCashReceiptPaymentDetail.JobNumber AndAlso
                                                                                                                      CCRDP.JobComponentNumber = ClientCashReceiptPaymentDetail.JobComponentNumber AndAlso
                                                                                                                      CCRDP.FunctionCode = ClientCashReceiptPaymentDetail.FunctionCode).FirstOrDefault

                            If ClientCashReceiptDetailPayment IsNot Nothing Then

                                ClientCashReceiptPaymentDetail.PaymentAmount = ClientCashReceiptDetailPayment.PaymentAmount

                            End If

                        Else

                            ClientCashReceiptDetailPayment = ClientCashReceiptDetailPaymentList.Where(Function(CCRDP) CCRDP.OrderNumber = ClientCashReceiptPaymentDetail.OrderNumber AndAlso
                                                                                                                      CCRDP.OrderLineNumber = ClientCashReceiptPaymentDetail.OrderLineNumber).FirstOrDefault

                            If ClientCashReceiptDetailPayment IsNot Nothing Then

                                ClientCashReceiptPaymentDetail.PaymentAmount = ClientCashReceiptDetailPayment.PaymentAmount

                            End If

                        End If

                    Next

                End If

            End If

        End Sub
        Public Function GetClientCashReceiptPaymentDetailList() As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail)

            GetClientCashReceiptPaymentDetailList = _ClientCashReceiptPaymentDetailList

        End Function
        Public Sub SetClientCashReceiptPaymentDetailList(ByVal ClientCashReceiptPaymentDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail))

            _ClientCashReceiptPaymentDetailList = ClientCashReceiptPaymentDetailList

        End Sub

#End Region

    End Class

End Namespace

