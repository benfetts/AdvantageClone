Namespace Database.Classes

    <Serializable()>
    Public Class ExpenseReportItem
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            InvoiceNumber
            LineNumber
            ItemDate
            Description
            PaymentType
            CreditCardFlag
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentRowID
            JobComponentDescription
            FunctionCode
            Quantity
            Rate
            CreditCardAmount
            Amount
            PayableAmount
            APComment
            CreatedBy
            ModifiedBy
            ModifiedDate
            NonBillable
            HasDocuments
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _InvoiceNumber As Integer = Nothing
        Private _LineNumber As Integer = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _Description As String = Nothing
        Private _PaymentType As Nullable(Of Short) = Nothing
        Private _CreditCardFlag As Nullable(Of Boolean) = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentRowID As Nullable(Of Integer) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _Quantity As Nullable(Of Integer) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _CreditCardAmount As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _APComment As String = Nothing
        Private _CreatedBy As String = Nothing
        Private _ModifiedBy As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _NonBillable As Boolean = Nothing
        Private _EmployeeCode As String = Nothing
        Private _HasDocuments As Boolean = Nothing
        Private _ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Overrides ReadOnly Property AttachedEntityType As System.Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.ExpenseReportDetail)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Date")>
        Public Property ItemDate() As Nullable(Of Date)
            Get
                ItemDate = _ItemDate
            End Get
            Set(value As Nullable(Of Date))
                _ItemDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property LineNumber() As Integer
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Integer)
                _LineNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="", PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobDescription)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Comp", PropertyType:=BaseClasses.PropertyTypes.JobComponentID)>
        Public Property JobComponentRowID() As Nullable(Of Integer)
            Get
                JobComponentRowID = _JobComponentRowID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobComponentRowID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Comp Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobComponentDescription)>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Function", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As Nullable(Of Integer)
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Quantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="F2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2", ShowColumnInGrid:=False)>
        Public ReadOnly Property PayableAmount() As Nullable(Of Decimal)
            Get
                If Me.CreditCardFlag.GetValueOrDefault(False) = True Then

                    PayableAmount = 0

                Else

                    PayableAmount = _Amount

                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PaymentType() As Nullable(Of Short)
            Get
                PaymentType = _PaymentType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _PaymentType = value
                SetCreditCardFlag()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Credit Card", ShowColumnInGrid:=False)>
        Public ReadOnly Property CreditCardFlag() As Nullable(Of Boolean)
            Get
                CreditCardFlag = _CreditCardFlag
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CreditCardAmount() As Nullable(Of Decimal)
            Get
                CreditCardAmount = _CreditCardAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CreditCardAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property APComment() As String
            Get
                APComment = _APComment
            End Get
            Set(value As String)
                _APComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CreatedBy() As String
            Get
                CreatedBy = _CreatedBy
            End Get
            Set(value As String)
                _CreatedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ModifiedBy() As String
            Get
                ModifiedBy = _ModifiedBy
            End Get
            Set(value As String)
                _ModifiedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property NonBillable() As Boolean
            Get

                If Me.JobNumber.GetValueOrDefault(0) <= 0 Then

                    _NonBillable = True

                End If

                NonBillable = _NonBillable

            End Get
            Set(value As Boolean)

                If Me.JobNumber.GetValueOrDefault(0) <= 0 Then

                    _NonBillable = True

                Else

                    _NonBillable = value

                End If

            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property HasDocuments() As Boolean
            Get
                HasDocuments = _HasDocuments
            End Get
            Set(value As Boolean)
                _HasDocuments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsImported() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail, ByVal EmployeeCode As String, ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

            _ExpenseReportDetail = ExpenseReportDetail

            Me.DbContext = DbContext

            _ID = ExpenseReportDetail.ID
            _InvoiceNumber = ExpenseReportDetail.InvoiceNumber
            _LineNumber = ExpenseReportDetail.LineNumber
            _ItemDate = ExpenseReportDetail.ItemDate
            _Description = ExpenseReportDetail.Description

            ' for older expense reports before PaymentType field was added
            If ExpenseReportDetail.PaymentType.HasValue Then

                _PaymentType = ExpenseReportDetail.PaymentType

            ElseIf ExpenseReportDetail.CreditCardFlag.GetValueOrDefault(False) = True Then

                _PaymentType = AdvantageFramework.Database.Entities.ExpenseItemPaymentType.CorporateCreditCard

            Else

                _PaymentType = AdvantageFramework.Database.Entities.ExpenseItemPaymentType.Cash

            End If

            _CreditCardFlag = ExpenseReportDetail.CreditCardFlag
            _ClientCode = ExpenseReportDetail.ClientCode
            _DivisionCode = ExpenseReportDetail.DivisionCode
            _ProductCode = ExpenseReportDetail.ProductCode

            _JobComponentNumber = ExpenseReportDetail.JobComponentNumber
            _FunctionCode = ExpenseReportDetail.FunctionCode
            _Quantity = ExpenseReportDetail.Quantity
            _Rate = ExpenseReportDetail.Rate
            _CreditCardAmount = ExpenseReportDetail.CreditCardAmount
            _Amount = ExpenseReportDetail.Amount
            _APComment = ExpenseReportDetail.APComment
            _CreatedBy = ExpenseReportDetail.CreatedBy
            _ModifiedBy = ExpenseReportDetail.ModifiedBy
            _ModifiedDate = ExpenseReportDetail.ModifiedDate
            _IsImported = ExpenseReportDetail.IsImported

            _JobNumber = ExpenseReportDetail.JobNumber

            If _JobNumber.HasValue AndAlso _JobNumber.Value > 0 Then

                Try

                    _JobDescription = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, _JobNumber).Description

                Catch ex As Exception
                    _JobDescription = Nothing
                End Try

            End If

            If _JobNumber.HasValue AndAlso _JobNumber.Value > 0 AndAlso ExpenseReportDetail.JobComponentNumber.HasValue AndAlso ExpenseReportDetail.JobComponentNumber.Value > 0 Then

                Try

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, ExpenseReportDetail.JobComponentNumber)

                    _JobComponentRowID = CInt(JobComponent.ID)
                    _JobComponentDescription = JobComponent.Description

                Catch ex As Exception
                    _JobComponentRowID = Nothing
                End Try

            End If

            Try

                _HasDocuments = If(AdvantageFramework.Database.Procedures.ExpenseDetailDocument.LoadByExpenseDetailID(DbContext, ExpenseReportDetail.ID).Count > 0, True, False)

            Catch ex As Exception
                _HasDocuments = False
            End Try

            SetNonBillableFlag(DbContext)

        End Sub
        Public Sub SetNonBillableFlag(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing

            Try

                If Me.JobNumber.GetValueOrDefault(0) > 0 Then

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRateByItem(DbContext, Me)

                    _NonBillable = CBool(BillingRate.NOBILL_FLAG.GetValueOrDefault(0))

                Else

                    _NonBillable = True 'items w/o job cannot be billed

                End If

            Catch ex As Exception
                _NonBillable = False
            End Try

        End Sub
        Public Function GetExpenseReportDetail(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.ExpenseReportDetail

            'objects
            Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing

            Try

                If _ExpenseReportDetail IsNot Nothing Then

                    ExpenseReportDetail = _ExpenseReportDetail

                Else

                    ExpenseReportDetail = New AdvantageFramework.Database.Entities.ExpenseReportDetail

                End If

                ExpenseReportDetail.InvoiceNumber = Me.InvoiceNumber
                ExpenseReportDetail.ItemDate = Me.ItemDate
                ExpenseReportDetail.Description = Me.Description
                ExpenseReportDetail.PaymentType = Me.PaymentType
                ExpenseReportDetail.CreditCardFlag = Me.CreditCardFlag

                ExpenseReportDetail.ClientCode = Me.ClientCode
                ExpenseReportDetail.DivisionCode = Me.DivisionCode
                ExpenseReportDetail.ProductCode = Me.ProductCode

                ExpenseReportDetail.JobNumber = Me.JobNumber

                Try

                    If Me.JobComponentRowID.HasValue AndAlso Me.JobComponentRowID.Value > 0 Then

                        ExpenseReportDetail.JobComponentNumber = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, Me.JobComponentRowID).Number

                    Else

                        ExpenseReportDetail.JobComponentNumber = Nothing

                    End If

                Catch ex As Exception
                    ExpenseReportDetail.JobComponentNumber = Nothing
                End Try

                ExpenseReportDetail.FunctionCode = Me.FunctionCode

                ExpenseReportDetail.Quantity = Me.Quantity
                ExpenseReportDetail.Rate = Me.Rate
                ExpenseReportDetail.CreditCardAmount = Me.CreditCardAmount

                If Me.Amount.HasValue Then

                    ExpenseReportDetail.Amount = FormatNumber(Me.Amount, 2)

                End If

                ExpenseReportDetail.APComment = Me.APComment
                ExpenseReportDetail.CreatedBy = Me.CreatedBy
                ExpenseReportDetail.ModifiedBy = Me.ModifiedBy
                ExpenseReportDetail.ModifiedDate = Me.ModifiedDate

            Catch ex As Exception
                ExpenseReportDetail = Nothing
            Finally
                GetExpenseReportDetail = ExpenseReportDetail
            End Try

        End Function
        Private Sub SetCreditCardFlag()

            Select Case DirectCast(_PaymentType.GetValueOrDefault(0), AdvantageFramework.Database.Entities.ExpenseItemPaymentType)

                Case Entities.ExpenseItemPaymentType.Cash

                    _CreditCardFlag = False

                Case Entities.ExpenseItemPaymentType.CorporateCreditCard

                    _CreditCardFlag = True

                Case Entities.ExpenseItemPaymentType.PersonalCreditCard

                    _CreditCardFlag = False

            End Select

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            _ExpenseReportDetail = GetExpenseReportDetail(_DbContext)

            _ExpenseReportDetail.DbContext = _DbContext

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            ' Objects
            Dim ErrorText As String = ""

            If PropertyName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobComponentRowID.ToString Then

                ErrorText = MyBase.ValidateCustomProperties(PropertyName, IsValid, Value)

            Else

                ErrorText = _ExpenseReportDetail.ValidateCustomProperties(PropertyName, IsValid, Value)

            End If

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = Nothing
            Dim IsRequired As Boolean = False

            _ExpenseReportDetail = GetExpenseReportDetail(_DbContext)

            _ExpenseReportDetail.DbContext = _DbContext

            If PropertyName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobComponentRowID.ToString Then

                SetRequired(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobComponentRowID.ToString, IsCDPJobCompRequired())

                ErrorText = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

            ElseIf PropertyName <> AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobComponentNumber.ToString Then

                ErrorText = _ExpenseReportDetail.ValidateEntityProperty(PropertyName, IsValid, Value)

            End If

            _ErrorHashtable(PropertyName) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function
        Private Function IsCDPJobCompRequired() As Boolean

            'objects
            Dim IsRequired As Boolean = False

            Try

                If String.IsNullOrEmpty(Me.ClientCode) = False OrElse
                String.IsNullOrEmpty(Me.DivisionCode) = False OrElse
                String.IsNullOrEmpty(Me.ProductCode) = False OrElse
                Me.JobNumber.HasValue OrElse
                Me.JobComponentRowID.HasValue Then

                    IsRequired = True

                End If

            Catch ex As Exception
                IsRequired = False
            End Try

            IsCDPJobCompRequired = IsRequired

        End Function
        Public Overrides Sub SetRequiredFields()

            'objects
            Dim IsRequired As Boolean = False

            IsRequired = IsCDPJobCompRequired()

            SetRequired(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ClientCode.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.DivisionCode.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.ProductCode.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobNumber.ToString, IsRequired)
            SetRequired(AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.JobComponentRowID.ToString, IsRequired)

        End Sub

#End Region

    End Class

End Namespace