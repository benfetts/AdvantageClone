Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableExpenseReport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Status
            Delete
            IsOnHold
            VendorCode
            EmployeeCode
            EmployeeName
            InvoiceNumber
            InvoiceDescription
            InvoiceDate
            ItemDate
            APComment
            InvoiceTotalNet
            OfficeCode
            DepartmentCode
            JobNumber
            JobComponentNumber
            FunctionCode
            Quantity
            Rate
            Amount
            GLACode
            GLACodeDescription
            HasDocuments
            CanModifyIsOnHold
            'FunctionIsRequired
            ExpenseReportDetailID
            IsSystemGenerated
            ClientName
            CCard
            EmployeeOfficeCode
        End Enum

#End Region

#Region " Variables "

        Private _PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _AccountPayableAvailableProductionJobs As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs) = Nothing
        Private _JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
        Private _Functions As Generic.List(Of AdvantageFramework.Database.Entities.Function) = Nothing
        Private _NonClientGLAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
        Private _ProductionGLAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
        Private _IsAPLimitByOfficeEnabled As Nullable(Of Boolean) = Nothing
        Private _APHeaderOfficeCode As String = Nothing
        Private _Status As String = Nothing
        Private _Delete As Boolean = False
        Private _IsOnHold As Boolean = False
        Private _InvoiceTotalNet As Decimal = 0
        Private _OfficeCode As String = Nothing
        Private _GLACode As String = Nothing
        Private _GLACodeDescription As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _CanModifyIsOnHold As Boolean = False
        'Private _FunctionIsRequired As Boolean = False
        Private _DepartmentCode As String = Nothing
        Private _HasDocuments As Boolean = False
        Private _IsNonbillable As Nullable(Of Short) = Nothing
        Private _CommissionPercent As Nullable(Of Decimal) = Nothing
        Private _TaxCommissions As Nullable(Of Short) = Nothing
        Private _TaxCommissionsOnly As Nullable(Of Short) = Nothing
        Private _SalesTaxCode As String = Nothing
        Private _IsSystemGenerated As Boolean = False
        Private _CreditCardGLAccountIsEmpty As Boolean = False
        Private _VendorCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _InvoiceNumber As Integer = Nothing
        Private _InvoiceDescription As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _APComment As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _FunctionCode As String = Nothing
        Private _Quantity As Nullable(Of Integer) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _ExpenseReportDetailID As Integer = Nothing
        Private _ClientName As String = Nothing
        Private _CCard As Boolean = False
        Private _EmployeeOfficeCode As String = Nothing
        Private _VendorOfficeCode As String = Nothing
        Private _HeaderStatus As Integer = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Delete() As Boolean
            Get
                Delete = _Delete
            End Get
            Set(value As Boolean)
                _Delete = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsOnHold() As Boolean
            Get
                IsOnHold = _IsOnHold
            End Get
            Set(value As Boolean)
                _IsOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.VendorCode, ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property InvoiceDescription() As String
            Get
                InvoiceDescription = _InvoiceDescription
            End Get
            Set(value As String)
                _InvoiceDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ItemDate() As Nullable(Of Date)
            Get
                ItemDate = _ItemDate
            End Get
            Set(value As Nullable(Of Date))
                _ItemDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Item Description", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property APComment() As String
            Get
                APComment = _APComment
            End Get
            Set(value As String)
                _APComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property InvoiceTotalNet() As Decimal
            Get
                InvoiceTotalNet = _InvoiceTotalNet
            End Get
            Set(value As Decimal)
                _InvoiceTotalNet = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Office Code")>
        Public Property EmployeeOfficeCode() As String
            Get
                EmployeeOfficeCode = _EmployeeOfficeCode
            End Get
            Set(value As String)
                _EmployeeOfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Dept", IsReadOnlyColumn:=True)>
        Public Property DepartmentCode() As String
            Get
                DepartmentCode = _DepartmentCode
            End Get
            Set(value As String)
                _DepartmentCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.JobComponent, CustomColumnCaption:="Job Comp")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Quantity() As Nullable(Of Integer)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Integer))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", IsReadOnlyColumn:=True)>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode, IsImportDefaultProperty:=True, CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(ByVal value As String)
                _GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription, IsReadOnlyColumn:=True, CustomColumnCaption:="GL Account Description")>
        Public Property GLACodeDescription() As String
            Get
                GLACodeDescription = _GLACodeDescription
            End Get
            Set(ByVal value As String)
                _GLACodeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox, IsReadOnlyColumn:=True)>
        Public Property CCard() As Boolean
            Get
                CCard = _CCard
            End Get
            Set(value As Boolean)
                _CCard = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property HasDocuments() As Boolean
            Get
                HasDocuments = _HasDocuments
            End Get
            Set(value As Boolean)
                _HasDocuments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property CanModifyIsOnHold() As Boolean
            Get
                CanModifyIsOnHold = _CanModifyIsOnHold
            End Get
            Set(value As Boolean)
                _CanModifyIsOnHold = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        'Public Property FunctionIsRequired() As Boolean
        '    Get
        '        FunctionIsRequired = _FunctionIsRequired
        '    End Get
        '    Set(value As Boolean)
        '        _FunctionIsRequired = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ExpenseReportDetailID() As Integer
            Get
                ExpenseReportDetailID = _ExpenseReportDetailID
            End Get
            Set(value As Integer)
                _ExpenseReportDetailID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsNonbillable() As Nullable(Of Short)
            Get
                IsNonbillable = _IsNonbillable
            End Get
            Set(value As Nullable(Of Short))
                _IsNonbillable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CommissionPercent() As Nullable(Of Decimal)
            Get
                CommissionPercent = _CommissionPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _CommissionPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxCommissions() As Nullable(Of Short)
            Get
                TaxCommissions = _TaxCommissions
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxCommissionsOnly() As Nullable(Of Short)
            Get
                TaxCommissionsOnly = _TaxCommissionsOnly
            End Get
            Set(value As Nullable(Of Short))
                _TaxCommissionsOnly = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SalesTaxCode() As String
            Get
                SalesTaxCode = _SalesTaxCode
            End Get
            Set(value As String)
                _SalesTaxCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsSystemGenerated() As Boolean
            Get
                IsSystemGenerated = _IsSystemGenerated
            End Get
            Set(value As Boolean)
                _IsSystemGenerated = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property CreditCardGLAccountIsEmpty() As Boolean
            Get
                CreditCardGLAccountIsEmpty = _CreditCardGLAccountIsEmpty
            End Get
            Set(value As Boolean)
                _CreditCardGLAccountIsEmpty = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorOfficeCode() As String
            Get
                VendorOfficeCode = _VendorOfficeCode
            End Get
            Set(value As String)
                _VendorOfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property HeaderStatus() As Integer
            Get
                HeaderStatus = _HeaderStatus
            End Get
            Set(value As Integer)
                _HeaderStatus = value
            End Set
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
        'Public Sub SetGLACodeBasedOnFunction(ByVal DbContext As AdvantageFramework.Database.DbContext)

        '    'objects
        '    Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
        '    Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
        '    Dim NewGLACode As String = Nothing
        '    Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
        '    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        '    [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, _FunctionCode)

        '    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

        '    If [Function] IsNot Nothing Then

        '        If [Function].OverheadGeneralLedgerAccount IsNot Nothing AndAlso Employee IsNot Nothing Then

        '            GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, Employee.OfficeCode)

        '            If GeneralLedgerOfficeCrossReference IsNot Nothing Then

        '                Try

        '                    GeneralLedgerAccount = (From GL In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext) _
        '                                            Where GL.BaseCode = [Function].OverheadGeneralLedgerAccount.BaseCode AndAlso _
        '                                                  GL.DepartmentCode = [Function].OverheadGeneralLedgerAccount.DepartmentCode AndAlso _
        '                                                  GL.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReference.Code _
        '                                            Select GL).SingleOrDefault

        '                Catch ex As Exception
        '                    GeneralLedgerAccount = Nothing
        '                End Try

        '                If GeneralLedgerAccount IsNot Nothing Then

        '                    NewGLACode = GeneralLedgerAccount.Code

        '                End If

        '            End If

        '        End If

        '        If NewGLACode IsNot Nothing Then

        '            _GLACode = NewGLACode

        '        Else

        '            _GLACode = [Function].OverheadGLACode

        '        End If

        '        _GLACodeDescription = AdvantageFramework.AccountPayable.GetGeneralLedgerAccountDescription(DbContext, _GLACode)

        '    End If

        'End Sub
        Public Sub SetBillingRateValues(ByVal DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            If Me.JobNumber IsNot Nothing Then

                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNumber)

                If Job IsNot Nothing AndAlso Me.JobComponentNumber.GetValueOrDefault(0) <> 0 AndAlso String.IsNullOrWhiteSpace(Me.FunctionCode) = False Then

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, Me.FunctionCode, Job.ClientCode,
                                                                                    Job.DivisionCode, Job.ProductCode, Job.Number,
                                                                                    Me.JobComponentNumber, Job.SalesClassCode, Nothing, Nothing)

                    If BillingRate IsNot Nothing Then

                        _IsNonbillable = BillingRate.NOBILL_FLAG
                        _CommissionPercent = BillingRate.COMM
                        _TaxCommissions = BillingRate.TAX_COMM
                        _TaxCommissionsOnly = BillingRate.TAX_COMM_ONLY
                        _SalesTaxCode = BillingRate.TAX_CODE

                    End If

                    _OfficeCode = Job.OfficeCode

                    If _IsNonbillable.GetValueOrDefault(0) = 0 Then

                        _GLACode = Job.Office.ProductionWorkInProgressGLACode

                    Else

                        [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, Me.FunctionCode)

                        If [Function] IsNot Nothing Then

                            If [Function].NonBillableClientGLACode Is Nothing Then

                                _GLACode = Nothing
                                _GLACodeDescription = Nothing

                            Else

                                _GLACode = [Function].NonBillableClientGLACode

                            End If

                        End If

                    End If

                    If _GLACode IsNot Nothing Then

                        _GLACodeDescription = AdvantageFramework.AccountPayable.GetGeneralLedgerAccountDescription(DbContext, _GLACode)

                    End If

                End If

            Else

                _IsNonbillable = Nothing
                _CommissionPercent = Nothing
                _TaxCommissions = Nothing
                _TaxCommissionsOnly = Nothing
                _SalesTaxCode = Nothing

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim GLAOfficeXREFCode As String = Nothing
            Dim OfficeCode As String = Nothing

            If _IsAPLimitByOfficeEnabled Is Nothing Then

                _IsAPLimitByOfficeEnabled = AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext)

            End If

            If _APHeaderOfficeCode Is Nothing Then

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Me.VendorCode)

                If Vendor IsNot Nothing AndAlso Vendor.GeneralLedgerAccount IsNot Nothing AndAlso Vendor.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                    _APHeaderOfficeCode = Vendor.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                End If

            End If

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobNumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If _AccountPayableAvailableProductionJobs Is Nothing Then

                            _AccountPayableAvailableProductionJobs = AdvantageFramework.AccountPayable.GetAvailableProductionJobs(DbContext, DbContext.UserCode, Nothing, Nothing, Nothing, Nothing)

                        End If

                        If _IsAPLimitByOfficeEnabled Then

                            OfficeCode = _APHeaderOfficeCode

                        End If

                        If _AccountPayableAvailableProductionJobs.Where(Function(Entity) Entity.Number = DirectCast(PropertyValue, Integer) AndAlso
                                                                                         Entity.OfficeCode = If(OfficeCode IsNot Nothing, OfficeCode, Entity.OfficeCode)).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid job."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.JobComponentNumber.ToString

                    PropertyValue = Value

                    If Me.JobNumber.GetValueOrDefault(0) <> 0 Then

                        If _JobComponents Is Nothing Then

                            _JobComponents = AdvantageFramework.AccountPayable.GetOpenJobComponentsForJobs(DbContext)

                        End If

                        If _JobComponents.Where(Function(Entity) Entity.JobNumber = Me.JobNumber AndAlso Entity.Number = (DirectCast(PropertyValue, Short))).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid job component."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.FunctionCode.ToString

                    If Me.JobNumber.GetValueOrDefault(0) <> 0 Then  'If _FunctionIsRequired Then

                        PropertyValue = Value

                        If _Functions Is Nothing Then

                            _Functions = AdvantageFramework.Database.Procedures.Function.LoadAllActiveVendorFunctions(DbContext).ToList()

                        End If

                        If String.IsNullOrWhiteSpace(PropertyValue) = False AndAlso _Functions.Where(Function(Entity) Entity.Code = (DirectCast(PropertyValue, String))).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid function."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.GLACode.ToString

                    PropertyValue = Value

                    If Me.JobNumber Is Nothing Then

                        If _IsAPLimitByOfficeEnabled Then

                            Try

                                GLAOfficeXREFCode = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, _APHeaderOfficeCode).Code

                            Catch ex As Exception
                                GLAOfficeXREFCode = Nothing
                            End Try

                        End If

                        If _NonClientGLAccountList Is Nothing Then

                            _NonClientGLAccountList = AdvantageFramework.AccountPayable.GetNonClientGLAccountList(DbContext, Me.Session, Nothing, Nothing)

                        End If

                        If _NonClientGLAccountList.Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String) AndAlso
                                                                          Entity.GeneralLedgerOfficeCrossReferenceCode = If(GLAOfficeXREFCode IsNot Nothing, GLAOfficeXREFCode, Entity.GeneralLedgerOfficeCrossReferenceCode)).Any = False Then

                            IsValid = False

                            ErrorText = "Invalid account."

                        End If

                    ElseIf _IsNonbillable.GetValueOrDefault(0) = 1 Then

                        If _ProductionGLAccountList Is Nothing Then

                            _ProductionGLAccountList = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, Nothing, Session)

                        End If

                        If _IsAPLimitByOfficeEnabled Then

                            Try

                                GLAOfficeXREFCode = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, Me.OfficeCode).Code

                            Catch ex As Exception
                                GLAOfficeXREFCode = Nothing
                            End Try

                        End If

                        If _IsAPLimitByOfficeEnabled AndAlso GLAOfficeXREFCode IsNot Nothing Then

                            If _ProductionGLAccountList.Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String) AndAlso Entity.GeneralLedgerOfficeCrossReferenceCode = GLAOfficeXREFCode).Any = False Then

                                IsValid = False

                                ErrorText = "Invalid account."

                            End If

                        Else

                            If _ProductionGLAccountList.Where(Function(Entity) Entity.Code = DirectCast(PropertyValue, String)).Any = False Then

                                IsValid = False

                                ErrorText = "Invalid account."

                            End If

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.OfficeCode.ToString

                    PropertyValue = Value

                    If _IsAPLimitByOfficeEnabled AndAlso _APHeaderOfficeCode <> _OfficeCode Then

                        IsValid = False

                        ErrorText = "Invalid office code."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            If _PropertyDescriptors Is Nothing Then

                _PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            End If

            For Each PropertyDescriptor In _PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.FunctionCode.ToString

                        'SetRequired(PropertyDescriptor, _FunctionIsRequired AndAlso Not Me.IsOnHold)
                        SetRequired(PropertyDescriptor, Me.JobNumber IsNot Nothing AndAlso Not Me.IsOnHold)

                End Select

            Next

        End Sub
        Public Function CustomValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            Dim PropertyIsValid As Boolean = True
            Dim PropertyErrorText As String = ""
            Dim ErrorText As String = ""
            Dim Value As Object = Nothing
            Dim OldValue As Object = Nothing

            SetRequiredFields()

            If _PropertyDescriptors Is Nothing Then

                _PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            End If

            For Each PropertyDescriptor In _PropertyDescriptors

                If PropertyDescriptor.Attributes.OfType(Of System.Xml.Serialization.XmlIgnoreAttribute).Any = False AndAlso
                        Not PropertyDescriptor.PropertyType Is GetType(Byte()) Then

                    OldValue = PropertyDescriptor.GetValue(Me)
                    Value = OldValue

                    PropertyErrorText = CustomValidateProperty(PropertyDescriptor.Name, PropertyIsValid, Value)

                    If Value <> OldValue OrElse (Value Is Nothing AndAlso OldValue IsNot Nothing) Then

                        PropertyDescriptor.SetValue(Me, Value)

                    End If

                    If PropertyIsValid = False Then

                        If IsValid Then

                            IsValid = False

                        End If

                        ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

                    ElseIf PropertyIsValid AndAlso PropertyErrorText IsNot Nothing AndAlso PropertyErrorText <> "" Then

                        ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

                    End If

                End If

            Next

            _EntityError = ErrorText

            CustomValidateEntity = ErrorText

        End Function
        Public Function CustomValidateProperty(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim IsRequired As Boolean = False
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = AdvantageFramework.BaseClasses.PropertyTypes.Default
            Dim DisplayName As String = ""

            LoadPropertyAttributes(Me.GetType, PropertyName, IsRequired, PropertyType, DisplayName)

            If DisplayName Is Nothing OrElse DisplayName = "" Then

                DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyName)

            End If

            IsValid = True

            Try

                ErrorText = AdvantageFramework.BaseClasses.ValidateData(Value, IsValid, DisplayName, False, IsRequired, True, 0, 0, 0)

                'If IsValid Then

                '    ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(_DbContext, _DataContext, Me, Me.GetType, PropertyType, Value, IsValid)

                'End If

                ErrorText &= ValidateCustomProperties(PropertyName, IsValid, Value)

            Catch ex As Exception
                IsValid = True
            End Try

            'FinalizeEntityPropertyValidation(PropertyName, IsValid, Value, ErrorText, False, True, IsRequired, 0, 0, 0, PropertyType)

            If IsValid = False AndAlso ErrorText = "" AndAlso PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

                ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

            End If

            If IsValid = False AndAlso IsRequired = False AndAlso
                    (Value = Nothing OrElse Value Is Nothing OrElse (Value IsNot Nothing AndAlso Value.ToString = "")) Then

                IsValid = True
                ErrorText = ""

                ClearNonRequiredPropertiesWithInvalidBlankValues(PropertyName, Value)

            End If

            _ErrorHashtable(PropertyName) = ErrorText

            CustomValidateProperty = ErrorText

        End Function
        Public Sub SetOfficeByGLACode(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim GLAOfficeXREFCode As String = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing

            GLAOfficeXREFCode = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, _GLACode).GeneralLedgerOfficeCrossReferenceCode

            GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GLAOfficeXREFCode)

            If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                _OfficeCode = GeneralLedgerOfficeCrossReference.OfficeCode

            End If

        End Sub

#End Region

    End Class

End Namespace