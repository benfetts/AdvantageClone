Namespace AccountPayable.Classes

    <Serializable()>
    Public Class ImportAccountPayableHeader
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            IsOnHold
            VendorCode
            VendorName
            InvoiceNumber
            InvoiceDescription
            InvoiceDate
            InvoiceTotalNet
            InvoiceTotalTax
            OfficeCode
            GLAccount
            StateTaxGLAccount
            StateTaxAmount
            CityTaxGLAccount
            CityTaxAmount
            TotalInvoice
            MediaDisbursed
            JobDisbursed
            GLDisbursed
            TotalDisbursed
        End Enum

#End Region

#Region " Variables "

        Private _ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
        Private _ImportAccountPayableGLs As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableGL) = Nothing
        Private _ImportAccountPayableJobs As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob) = Nothing
        Private _ImportAccountPayableMedias As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia) = Nothing
        Private _IsAPLimitByOfficeEnabled As Boolean = False
        Private _IsInterCompanyTransactionsEnabled As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportAccountPayable.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property BatchName() As String
            Get
                BatchName = _ImportAccountPayable.BatchName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsOnHold() As Boolean
            Get
                IsOnHold = _ImportAccountPayable.IsOnHold
            End Get
            Set(value As Boolean)
                _ImportAccountPayable.IsOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.VendorCode, IsImportDefaultProperty:=True)>
        Public Property VendorCode() As String
            Get
                VendorCode = _ImportAccountPayable.VendorCode
            End Get
            Set(value As String)
                _ImportAccountPayable.VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorName() As String
            Get
                VendorName = _ImportAccountPayable.VendorName
            End Get
            Set(value As String)
                _ImportAccountPayable.VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _ImportAccountPayable.InvoiceNumber
            End Get
            Set(value As String)
                _ImportAccountPayable.InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property InvoiceDescription() As String
            Get
                InvoiceDescription = _ImportAccountPayable.InvoiceDescription
            End Get
            Set(value As String)
                _ImportAccountPayable.InvoiceDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _ImportAccountPayable.InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _ImportAccountPayable.InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property InvoiceTotalNet() As Nullable(Of Decimal)
            Get
                InvoiceTotalNet = _ImportAccountPayable.InvoiceTotalNet
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayable.InvoiceTotalNet = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property InvoiceTotalTax() As Nullable(Of Decimal)
            Get
                InvoiceTotalTax = _ImportAccountPayable.InvoiceTotalTax
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayable.InvoiceTotalTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _ImportAccountPayable.OfficeCode
            End Get
            Set(value As String)
                _ImportAccountPayable.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLAccount() As String
            Get
                GLAccount = _ImportAccountPayable.GLAccount
            End Get
            Set(value As String)
                _ImportAccountPayable.GLAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property StateTaxGLAccount() As String
            Get
                StateTaxGLAccount = _ImportAccountPayable.StateTaxGLAccount
            End Get
            Set(value As String)
                _ImportAccountPayable.StateTaxGLAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property StateTaxAmount() As Nullable(Of Decimal)
            Get
                StateTaxAmount = _ImportAccountPayable.StateTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayable.StateTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property CityTaxGLAccount() As String
            Get
                CityTaxGLAccount = _ImportAccountPayable.CityTaxGLAccount
            End Get
            Set(value As String)
                _ImportAccountPayable.CityTaxGLAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CityTaxAmount() As Nullable(Of Decimal)
            Get
                CityTaxAmount = _ImportAccountPayable.CityTaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayable.CityTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SourceCode() As String
            Get
                SourceCode = _ImportAccountPayable.SourceCode
            End Get
            Set(value As String)
                _ImportAccountPayable.SourceCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public ReadOnly Property TotalInvoice() As Decimal
            Get
                TotalInvoice = InvoiceTotalNet.GetValueOrDefault(0) + InvoiceTotalTax.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property MediaDisbursed() As Decimal
            Get
                MediaDisbursed = _ImportAccountPayable.ImportAccountPayableMedias.Sum(Function(Media) Media.MediaNetAmount.GetValueOrDefault(0) + Media.MediaVendorTax.GetValueOrDefault(0) + Media.MediaNetCharge.GetValueOrDefault(0))
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property JobDisbursed() As Decimal
            Get
                JobDisbursed = _ImportAccountPayable.ImportAccountPayableJobs.Sum(Function(Job) Job.JobNetAmount.GetValueOrDefault(0) + Job.JobVendorTax.GetValueOrDefault(0))
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property GLDisbursed() As Decimal
            Get
                GLDisbursed = _ImportAccountPayable.ImportAccountPayableGLs.Sum(Function(GL) GL.GLNetAmount.GetValueOrDefault(0)) + Me.StateTaxAmount.GetValueOrDefault(0) + Me.CityTaxAmount.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property TotalDisbursed() As Decimal
            Get
                TotalDisbursed = MediaDisbursed + JobDisbursed + GLDisbursed
            End Get
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportAccountPayableGLs As Generic.List(Of ImportAccountPayableGL)
            Get
                ImportAccountPayableGLs = _ImportAccountPayableGLs
            End Get
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportAccountPayableJobs As Generic.List(Of ImportAccountPayableJob)
            Get
                ImportAccountPayableJobs = _ImportAccountPayableJobs
            End Get
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportAccountPayableMedias As Generic.List(Of ImportAccountPayableMedia)
            Get
                ImportAccountPayableMedias = _ImportAccountPayableMedias
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public ReadOnly Property IsAPLimitByOfficeEnabled() As Boolean
            Get
                IsAPLimitByOfficeEnabled = _IsAPLimitByOfficeEnabled
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public ReadOnly Property IsInterCompanyTransactionsEnabled() As Boolean
            Get
                IsInterCompanyTransactionsEnabled = _IsInterCompanyTransactionsEnabled
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportTemplateID() As Short
            Get
                ImportTemplateID = _ImportAccountPayable.ImportTemplateID
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportAccountPayable = New AdvantageFramework.Database.Entities.ImportAccountPayable

            _ImportAccountPayableGLs = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableGL)
            _ImportAccountPayableJobs = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob)
            _ImportAccountPayableMedias = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia)

        End Sub
        Public Sub New(ByVal ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable, ByVal IsAPLimitByOfficeEnabled As Boolean, ByVal IsInterCompanyTransactionsEnabled As Boolean,
                       Session As AdvantageFramework.Security.Session)

            _ImportAccountPayable = ImportAccountPayable

            _IsAPLimitByOfficeEnabled = IsAPLimitByOfficeEnabled
            _IsInterCompanyTransactionsEnabled = IsInterCompanyTransactionsEnabled

            _ImportAccountPayableGLs = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableGL)
            _ImportAccountPayableJobs = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob)
            _ImportAccountPayableMedias = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia)

            If _ImportAccountPayable.ImportAccountPayableGLs.Any Then

                For Each DetailEntity In _ImportAccountPayable.ImportAccountPayableGLs

                    _ImportAccountPayableGLs.Add(New AdvantageFramework.AccountPayable.Classes.ImportAccountPayableGL(DetailEntity, Me, Session))

                Next

            End If

            If _ImportAccountPayable.ImportAccountPayableJobs.Any Then

                For Each DetailEntity In _ImportAccountPayable.ImportAccountPayableJobs

                    _ImportAccountPayableJobs.Add(New AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob(DetailEntity, Me))

                Next

            End If

            If _ImportAccountPayable.ImportAccountPayableMedias.Any Then

                For Each DetailEntity In _ImportAccountPayable.ImportAccountPayableMedias

                    _ImportAccountPayableMedias.Add(New AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia(DetailEntity, Me))

                Next

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = _ImportAccountPayable.ID

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorString As String = ""
            Dim ErrorText As String = ""
            Dim SubItemIsValid As Boolean = True

            SetRequiredFields()

            ErrorString = MyBase.ValidateEntity(IsValid)

            For Each ImportAccountPayableGL In Me.ImportAccountPayableGLs

                ImportAccountPayableGL.DbContext = DbContext

                ErrorText = ImportAccountPayableGL.ValidateEntity(SubItemIsValid)

                If SubItemIsValid = False Then

                    IsValid = False

                    ErrorString = If(ErrorString = "", ErrorText, ErrorString & vbNewLine & ErrorText)

                End If

            Next

            If Me.ImportAccountPayableJobs.Count > 0 Then

                AdvantageFramework.AccountPayable.ValidateAllImportJobs(DbContext, Me.ImportAccountPayableJobs, IsValid, ErrorString)

            End If

            If Me.ImportAccountPayableMedias.Count > 0 Then

                AdvantageFramework.AccountPayable.ValidateAllImportMedias(DbContext, Me.ImportAccountPayableMedias, IsValid, ErrorString, Me.BatchName)

            End If

            If IsValid Then

                Me.IsOnHold = False

            End If

            ValidateEntity = ErrorString

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader.Properties.OfficeCode.ToString

                        If Me.IsInterCompanyTransactionsEnabled OrElse Me.IsAPLimitByOfficeEnabled Then

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
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader.Properties.VendorCode.ToString

                    PropertyValue = Value

                    If Not (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Vendors
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                  Entity.ActiveFlag = 1
                            Select Entity).Any Then

                        IsValid = False

                        ErrorText = "Please enter a valid vendor code."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader.Properties.TotalInvoice.ToString

                    PropertyValue = Value

                    If Me.TotalDisbursed <> PropertyValue Then

                        IsValid = False

                        ErrorText = "Total Disbursed must equal Total Invoice."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader.Properties.InvoiceNumber.ToString

                    PropertyValue = Value

                    Try

                        AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadByVendorAndInvoiceNumber(DbContext, Me.VendorCode, PropertyValue)

                    Catch ex As Exception
                        AccountPayable = Nothing
                    End Try

                    If AccountPayable IsNot Nothing Then

                        IsValid = False

                        ErrorText = "Invoice Number exists for Vendor."

                    End If

                    If IsValid Then

                        If (From Item In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ImportAccountPayables
                            Where Item.BatchName = Me.BatchName AndAlso
                                  Item.VendorCode = Me.VendorCode AndAlso
                                  Item.InvoiceNumber.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                  Item.InvoiceNumber <> DirectCast(PropertyValue, String)
                            Select Item).Any Then

                            IsValid = False

                            ErrorText = "Invoice Number exists for this Vendor in this batch."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader.Properties.OfficeCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                        If AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Session).Where(Function(Office) Office.Code = DirectCast(PropertyValue, String)).Any = False Then

                            IsValid = False

                            ErrorText = "Office code is invalid."

                        End If

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader.Properties.GLAccount.ToString

                    PropertyValue = Value

                    If String.IsNullOrWhiteSpace(Me.OfficeCode) = False AndAlso Me.IsInterCompanyTransactionsEnabled OrElse Me.IsAPLimitByOfficeEnabled AndAlso PropertyValue IsNot Nothing Then

                        GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, DirectCast(PropertyValue, String))

                        If GeneralLedgerAccount IsNot Nothing AndAlso GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                            If GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode <> Me.OfficeCode Then

                                IsValid = False

                                ErrorText = "GL Account is invalid."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ImportAccountPayable

            GetEntity = _ImportAccountPayable

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function

#End Region

    End Class

End Namespace
