Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ImportClientCashReceipt
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            IsOnHold
            CheckNumber
            CheckDate
            CheckAmount
            DepositDate
            IsCleared
            ARInvoiceNumber
            ARInvoiceSequence
            ClientCode
            ClientName
            PaymentAmount
            DetailID
            PaymentTypeDescription
            AltInvoiceNumber
        End Enum

#End Region

#Region " Variables "

        Private _ImportClientCashReceiptHeader As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptHeader = Nothing
        Private _ImportClientCashReceiptDetail As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportClientCashReceiptHeader.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property BatchName() As String
            Get
                BatchName = _ImportClientCashReceiptHeader.BatchName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsOnHold() As Short
            Get
                IsOnHold = _ImportClientCashReceiptHeader.IsOnHold
            End Get
            Set(value As Short)
                _ImportClientCashReceiptHeader.IsOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property CheckNumber() As String
            Get
                CheckNumber = _ImportClientCashReceiptHeader.CheckNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property CheckDate() As Nullable(Of Date)
            Get
                CheckDate = _ImportClientCashReceiptHeader.CheckDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public ReadOnly Property CheckAmount() As Nullable(Of Decimal)
            Get
                CheckAmount = _ImportClientCashReceiptHeader.CheckAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property DepositDate() As Nullable(Of Date)
            Get
                DepositDate = _ImportClientCashReceiptHeader.DepositDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsCleared() As Nullable(Of Short)
            Get
                IsCleared = _ImportClientCashReceiptHeader.IsCleared
            End Get
            Set(value As Nullable(Of Short))
                _ImportClientCashReceiptHeader.IsCleared = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
            Get
                ARInvoiceNumber = _ImportClientCashReceiptDetail.ARInvoiceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportClientCashReceiptDetail.ARInvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="INV SEQ")>
        Public Property ARInvoiceSequence() As Nullable(Of Short)
            Get
                ARInvoiceSequence = _ImportClientCashReceiptDetail.ARInvoiceSequence
            End Get
            Set(value As Nullable(Of Short))
                _ImportClientCashReceiptDetail.ARInvoiceSequence = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ImportClientCashReceiptDetail.ClientCode
            End Get
            Set(value As String)
                _ImportClientCashReceiptDetail.ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ImportClientCashReceiptDetail.ClientName
            End Get
            Set(value As String)
                _ImportClientCashReceiptDetail.ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public ReadOnly Property PaymentAmount() As Nullable(Of Decimal)
            Get
                PaymentAmount = _ImportClientCashReceiptDetail.PaymentAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property PaymentTypeDescription() As String
            Get
                PaymentTypeDescription = _ImportClientCashReceiptHeader.PaymentTypeDescription
            End Get
            Set(value As String)
                _ImportClientCashReceiptHeader.PaymentTypeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property AltInvoiceNumber() As String
            Get
                AltInvoiceNumber = _ImportClientCashReceiptDetail.AltInvoiceNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property DetailID() As Integer
            Get
                DetailID = _ImportClientCashReceiptDetail.DetailID
            End Get
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportClientCashReceiptDetail As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail
            Get
                ImportClientCashReceiptDetail = _ImportClientCashReceiptDetail
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportClientCashReceiptHeader = New AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptHeader
            _ImportClientCashReceiptDetail = New AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail

        End Sub
        Public Sub New(ByVal ImportClientCashReceiptHeader As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptHeader,
                       ByVal ImportClientCashReceiptDetail As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail)

            _ImportClientCashReceiptHeader = ImportClientCashReceiptHeader
            _ImportClientCashReceiptDetail = ImportClientCashReceiptDetail

        End Sub
        Public Sub SetClientValues(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing

            AccountReceivable = AdvantageFramework.Database.Procedures.AccountReceivable.LoadByInvoiceNumberAndSequenceNumber(DbContext, Me.ARInvoiceNumber, Me.ARInvoiceSequence)

            If AccountReceivable IsNot Nothing Then

                Me.ClientCode = AccountReceivable.ClientCode
                Me.ClientName = AccountReceivable.Client.Name

            End If

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            _ImportClientCashReceiptHeader.DbContext = Me.DbContext

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.DbContext.ConnectionString, Me.DbContext.UserCode)

                _ImportClientCashReceiptHeader.DbContext = DbContext

                _EntityError = _ImportClientCashReceiptHeader.ValidateEntity(IsValid)

                RefreshErrorHashtable()

            End Using

            ValidateEntity = _EntityError

        End Function
        Public Sub RefreshErrorHashtable()

            Dim ErrorString As String = Nothing

            _ErrorHashtable.Clear()

            For Each Key In _ImportClientCashReceiptHeader.ErrorHashtable.Keys

                If _ImportClientCashReceiptHeader.ErrorHashtable.Item(Key) <> "" AndAlso _ErrorHashtable.ContainsKey(Key) = False Then

                    _ErrorHashtable.Add(Key, _ImportClientCashReceiptHeader.ErrorHashtable.Item(Key))

                End If

            Next

            _ImportClientCashReceiptHeader.ImportClientCashReceiptDetails.ForEach(Sub(ImportClientCashReceiptDetail As ImportClientCashReceiptDetail)

                                                                                      For Each Key In ImportClientCashReceiptDetail.ErrorHashtable.Keys

                                                                                          If ImportClientCashReceiptDetail.ErrorHashtable.Item(Key) <> "" AndAlso _ErrorHashtable.ContainsKey(Key) = False Then

                                                                                              _ErrorHashtable.Add(Key, ImportClientCashReceiptDetail.ErrorHashtable.Item(Key))

                                                                                          End If

                                                                                      Next

                                                                                  End Sub)

            For Each Key In _ErrorHashtable.Keys

                ErrorString = If(ErrorString Is Nothing, _ErrorHashtable.Item(Key).ToString, ErrorString + vbNewLine + _ErrorHashtable.Item(Key).ToString)

            Next

            _EntityError = ErrorString

        End Sub

#End Region

    End Class

End Namespace
