Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableGLDistributionDetail
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
            OfficeCode
            GLACode
            GLADescription
            ForeignAmount
            Amount
            POAmount
            POBalance
            Comment
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableGLDistribution As AdvantageFramework.Database.Entities.AccountPayableGLDistribution = Nothing
        Private _POComplete As Nullable(Of Short) = Nothing
        Private _POAmount As Nullable(Of Decimal) = Nothing
        Private _POBalance As Nullable(Of Decimal) = Nothing
        Private _GLADescription As String = Nothing
        Private _IsDeleted As Boolean = False
        Private _IsInterCompanyTransactionsEnabled As Boolean = False
        Private _ForeignAmount As Decimal = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.AccountPayableGLDistribution)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property AccountPayableGLDistribution As AdvantageFramework.Database.Entities.AccountPayableGLDistribution
            Get
                AccountPayableGLDistribution = _AccountPayableGLDistribution
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableGLDistribution.AccountPayableID
            End Get
            Set(ByVal value As Integer)
                _AccountPayableGLDistribution.AccountPayableID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableSequenceNumber() As Short
            Get
                AccountPayableSequenceNumber = _AccountPayableGLDistribution.AccountPayableSequenceNumber
            End Get
            Set(ByVal value As Short)
                _AccountPayableGLDistribution.AccountPayableSequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LineNumber() As Short
            Get
                LineNumber = _AccountPayableGLDistribution.LineNumber
            End Get
            Set(ByVal value As Short)
                _AccountPayableGLDistribution.LineNumber = value
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
                PONumber = _AccountPayableGLDistribution.PONumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AccountPayableGLDistribution.PONumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="P.O. Line")>
        Public Property PODetailLineNumber() As Nullable(Of Short)
            Get
                PODetailLineNumber = _AccountPayableGLDistribution.PODetailLineNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AccountPayableGLDistribution.PODetailLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="P.O. Complete", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property POComplete As Nullable(Of Short)
            Get
                POComplete = _POComplete
            End Get
            Set(ByVal value As Nullable(Of Short))
                _POComplete = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office", PropertyType:=BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _AccountPayableGLDistribution.OfficeCode
            End Get
            Set(ByVal value As String)
                _AccountPayableGLDistribution.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACode As String
            Get
                GLACode = _AccountPayableGLDistribution.GLACode
            End Get
            Set(ByVal value As String)
                _AccountPayableGLDistribution.GLACode = If(value Is Nothing, "", value)
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="GL Account Description", IsReadOnlyColumn:=True)>
        Public Property GLADescription As String
            Get
                GLADescription = _GLADescription
            End Get
            Set(ByVal value As String)
                _GLADescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ForeignAmount() As Decimal
            Get
                ForeignAmount = _ForeignAmount
            End Get
            Set(ByVal value As Decimal)
                _ForeignAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property Amount() As Decimal
            Get
                Amount = _AccountPayableGLDistribution.Amount
            End Get
            Set(ByVal value As Decimal)
                _AccountPayableGLDistribution.Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="P.O. Amount", IsReadOnlyColumn:=True)>
        Public Property POAmount() As Nullable(Of Decimal)
            Get
                POAmount = _POAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _POAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="P.O. Balance", IsReadOnlyColumn:=True)>
        Public Property POBalance() As Nullable(Of Decimal)
            Get
                POBalance = _POBalance
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _POBalance = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
            Get
                Comment = _AccountPayableGLDistribution.Comment
            End Get
            Set(ByVal value As String)
                _AccountPayableGLDistribution.Comment = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Shared Function CalculatePOBalance(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal POAmount As Decimal, ByVal PONumber As Integer, ByVal PODetailLineNumber As Integer) As Decimal

            Dim SumOfAmountApplied As Decimal = 0
            Dim Balance As Decimal = 0

            Try

                SumOfAmountApplied = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableGLDistribution.Load(DbContext)
                                      Where Entity.PONumber = PONumber AndAlso
                                            Entity.PODetailLineNumber = PODetailLineNumber AndAlso
                                            (Entity.ModifyDelete Is Nothing OrElse
                                            Entity.ModifyDelete = 0)
                                      Select Entity).ToList.Sum(Function(Entity) Entity.Amount)

            Catch ex As Exception
                SumOfAmountApplied = 0
            End Try

            Balance = POAmount - SumOfAmountApplied

            CalculatePOBalance = Balance

        End Function
        Public Function CalculatePOBalance(DbContext As AdvantageFramework.Database.DbContext) As String

            Dim Message As String = Nothing
            Dim POBalance As Decimal = 0

            If Me.PONumber.HasValue AndAlso Me.PODetailLineNumber.HasValue Then

                POBalance = DbContext.Database.SqlQuery(Of Decimal)(String.Format("exec advsp_ap_nonclient_calc_po_balance_excluding_ap_id {0}, {1}, {2}", Me.PONumber, Me.PODetailLineNumber, AccountPayableID)).FirstOrDefault

                Me.POBalance = POBalance - Me.Amount

            End If

            If AdvantageFramework.Database.Procedures.Agency.APPOMessage(DbContext) Then

                If Me.POBalance IsNot Nothing AndAlso
                        Me.PONumber IsNot Nothing AndAlso
                        Me.PODetailLineNumber IsNot Nothing AndAlso
                        Me.POBalance.Value < 0 Then

                    Message = AdvantageFramework.Database.Procedures.Agency.APPOMessageText(DbContext)

                End If

            ElseIf AdvantageFramework.Database.Procedures.Agency.APPOReject(DbContext) Then

                If Me.POBalance IsNot Nothing AndAlso
                        Me.PONumber IsNot Nothing AndAlso
                        Me.PODetailLineNumber IsNot Nothing AndAlso
                        Me.POBalance.Value < 0 Then

                    Message = AdvantageFramework.Database.Procedures.Agency.APPORejectText(DbContext)

                    Me.Amount = Me.POBalance

                End If

            End If

            CalculatePOBalance = Message

        End Function
        Public Sub New()

            _AccountPayableGLDistribution = New AdvantageFramework.Database.Entities.AccountPayableGLDistribution

        End Sub
        Public Sub New(ByVal AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem, ByVal DbContext As AdvantageFramework.Database.DbContext)

            _AccountPayableGLDistribution = New AdvantageFramework.Database.Entities.AccountPayableGLDistribution

            _IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

            _AccountPayableGLDistribution.Amount = AccountPayableExpenseReportItem.Amount
            _AccountPayableGLDistribution.Comment = AccountPayableExpenseReportItem.APComment
            _AccountPayableGLDistribution.GLACode = AccountPayableExpenseReportItem.GLACode
            _AccountPayableGLDistribution.OfficeCode = AccountPayableExpenseReportItem.OfficeCode
            _AccountPayableGLDistribution.ExpenseReportDetailID = AccountPayableExpenseReportItem.ExpenseReportDetailID

        End Sub
        Public Sub New(ByVal ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL, ByVal DbContext As AdvantageFramework.Database.DbContext)

            _AccountPayableGLDistribution = New AdvantageFramework.Database.Entities.AccountPayableGLDistribution

            _IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

            _AccountPayableGLDistribution.Amount = ImportAccountPayableGL.GLNetAmount
            _AccountPayableGLDistribution.Comment = ImportAccountPayableGL.GLComment
            _AccountPayableGLDistribution.GLACode = ImportAccountPayableGL.GLACode
            _AccountPayableGLDistribution.OfficeCode = ImportAccountPayableGL.OfficeCodeDetail

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableGLDistribution As AdvantageFramework.Database.Entities.AccountPayableGLDistribution)

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing

            _IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableGLDistribution.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            _AccountPayableGLDistribution = AccountPayableGLDistribution
            _GLADescription = AccountPayableGLDistribution.GeneralLedgerAccount.Description
            _ForeignAmount = Me.Amount / If(AccountPayable.CurrencyRate.HasValue AndAlso AccountPayable.CurrencyRate = 0, 1, AccountPayable.CurrencyRate.GetValueOrDefault(1))

            If AccountPayableGLDistribution.PONumber IsNot Nothing AndAlso AccountPayableGLDistribution.PODetailLineNumber IsNot Nothing Then

                PurchaseOrderDetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, AccountPayableGLDistribution.PONumber, AccountPayableGLDistribution.PODetailLineNumber)

            End If

            If PurchaseOrderDetail IsNot Nothing Then

                _POComplete = PurchaseOrderDetail.IsComplete
                _POAmount = PurchaseOrderDetail.ExtendedAmount

                _POBalance = CalculatePOBalance(DbContext, PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0), Me.PONumber, Me.PODetailLineNumber)

            Else

                _POComplete = Nothing
                _POAmount = Nothing
                _POBalance = Nothing

            End If

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PONumber As Integer, ByVal PODetailLineNumber As Integer, ByVal ExtendedAmount As Decimal, ByVal GLACode As String,
                       CurrencyRate As Decimal)

            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim GLAOfficeXREFCode As String = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            _AccountPayableGLDistribution = New AdvantageFramework.Database.Entities.AccountPayableGLDistribution

            _IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

            _AccountPayableGLDistribution.GLACode = GLACode

            If GLACode IsNot Nothing AndAlso GLACode <> "" Then

                GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLACode)

                If GeneralLedgerAccount IsNot Nothing Then

                    _GLADescription = GeneralLedgerAccount.Description

                End If

                GLAOfficeXREFCode = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLACode).GeneralLedgerOfficeCrossReferenceCode

                GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GLAOfficeXREFCode)

                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                    _AccountPayableGLDistribution.OfficeCode = GeneralLedgerOfficeCrossReference.OfficeCode

                End If

            End If

            If PONumber <> 0 AndAlso PODetailLineNumber <> 0 Then

                PurchaseOrderDetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, PONumber, PODetailLineNumber)

            End If

            If PurchaseOrderDetail IsNot Nothing Then

                Me.PONumber = PurchaseOrderDetail.PurchaseOrderNumber
                Me.PODetailLineNumber = PurchaseOrderDetail.LineNumber

                _POComplete = 1
                _POAmount = PurchaseOrderDetail.ExtendedAmount
                _AccountPayableGLDistribution.Comment = PurchaseOrderDetail.LineDescription

                _POBalance = CalculatePOBalance(DbContext, PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0), Me.PONumber, Me.PODetailLineNumber)

                _AccountPayableGLDistribution.Amount = _POBalance
                Me.ForeignAmount = Me.Amount / CurrencyRate

            Else

                Me.PONumber = Nothing
                Me.PODetailLineNumber = Nothing

                _POComplete = Nothing
                _POAmount = Nothing
                _POBalance = Nothing

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID

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

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.PODetailLineNumber.ToString

                        If Me.PONumber IsNot Nothing Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail.Properties.OfficeCode.ToString

                        If _IsInterCompanyTransactionsEnabled Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                End Select

            Next

        End Sub

#End Region

    End Class

End Namespace

