Namespace Database.Classes

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
            TotalInvoice
            MediaDisbursed
            JobDisbursed
            GLDisbursed
            TotalDisbursed
        End Enum

#End Region

#Region " Variables "

        Private _ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
        Private _ImportAccountPayableGLs As Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayableGL) = Nothing
        Private _ImportAccountPayableJobs As Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayableJob) = Nothing
        Private _ImportAccountPayableMedias As Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayableMedia) = Nothing
        Private _IsAPLimitByOfficeEnabled As Boolean = False

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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACode() As String
            Get
                GLACode = _ImportAccountPayable.GLACode
            End Get
            Set(value As String)
                _ImportAccountPayable.GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property TotalInvoice() As Decimal
            Get
                TotalInvoice = InvoiceTotalNet.GetValueOrDefault(0) + InvoiceTotalTax.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property MediaDisbursed() As Decimal
            Get
                MediaDisbursed = _ImportAccountPayable.ImportAccountPayableMedias.Sum(Function(Media) Media.MediaNetAmount.GetValueOrDefault(0) + Media.MediaVendorTax.GetValueOrDefault(0) + Media.MediaNetCharge.GetValueOrDefault(0)) '_MediaDisbursed
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property JobDisbursed() As Decimal
            Get
                JobDisbursed = _ImportAccountPayable.ImportAccountPayableJobs.Sum(Function(Job) Job.JobNetAmount.GetValueOrDefault(0) + Job.JobVendorTax.GetValueOrDefault(0)) '_JobDisbursed
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property GLDisbursed() As Decimal
            Get
                GLDisbursed = _ImportAccountPayable.ImportAccountPayableGLs.Sum(Function(GL) GL.GLNetAmount.GetValueOrDefault(0)) '_GLDisbursed
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

#End Region

#Region " Methods "

        Public Sub New()

            _ImportAccountPayable = New AdvantageFramework.Database.Entities.ImportAccountPayable

            _ImportAccountPayableGLs = New Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayableGL)
            _ImportAccountPayableJobs = New Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayableJob)
            _ImportAccountPayableMedias = New Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayableMedia)

        End Sub
        Public Sub New(ByVal ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable, ByVal IsAPLimitByOfficeEnabled As Boolean)

            _ImportAccountPayable = ImportAccountPayable

            _IsAPLimitByOfficeEnabled = IsAPLimitByOfficeEnabled

            _ImportAccountPayableGLs = New Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayableGL)
            _ImportAccountPayableJobs = New Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayableJob)
            _ImportAccountPayableMedias = New Generic.List(Of AdvantageFramework.Database.Classes.ImportAccountPayableMedia)

            If _ImportAccountPayable.ImportAccountPayableGLs.Any Then

                For Each DetailEntity In _ImportAccountPayable.ImportAccountPayableGLs

                    _ImportAccountPayableGLs.Add(New AdvantageFramework.Database.Classes.ImportAccountPayableGL(DetailEntity, Me))

                Next

            End If

            If _ImportAccountPayable.ImportAccountPayableJobs.Any Then

                For Each DetailEntity In _ImportAccountPayable.ImportAccountPayableJobs

                    _ImportAccountPayableJobs.Add(New AdvantageFramework.Database.Classes.ImportAccountPayableJob(DetailEntity, Me))

                Next

            End If

            If _ImportAccountPayable.ImportAccountPayableMedias.Any Then

                For Each DetailEntity In _ImportAccountPayable.ImportAccountPayableMedias

                    _ImportAccountPayableMedias.Add(New AdvantageFramework.Database.Classes.ImportAccountPayableMedia(DetailEntity, Me))

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

            ErrorString = MyBase.ValidateEntity(IsValid)

            For Each ImportAccountPayableGL In Me.ImportAccountPayableGLs

                ImportAccountPayableGL.ObjectContext = ObjectContext

                ErrorText = ImportAccountPayableGL.ValidateEntity(SubItemIsValid)

                If SubItemIsValid = False Then

                    IsValid = False

                    ErrorString = If(ErrorString = "", ErrorText, ErrorString & vbNewLine & ErrorText)

                End If

            Next

            For Each ImportAccountPayableJob In Me.ImportAccountPayableJobs

                ImportAccountPayableJob.ObjectContext = ObjectContext

                ErrorText = ImportAccountPayableJob.ValidateEntity(SubItemIsValid)

                If SubItemIsValid = False Then

                    IsValid = False

                    ErrorString = If(ErrorString = "", ErrorText, ErrorString & vbNewLine & ErrorText)

                End If

            Next

            For Each ImportAccountPayableMedia In Me.ImportAccountPayableMedias

                ImportAccountPayableMedia.ObjectContext = ObjectContext

                ErrorText = ImportAccountPayableMedia.ValidateEntity(SubItemIsValid)

                If SubItemIsValid = False Then

                    IsValid = False

                    ErrorString = If(ErrorString = "", ErrorText, ErrorString & vbNewLine & ErrorText)

                End If

            Next

            ValidateEntity = ErrorString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.ImportAccountPayableHeader.Properties.TotalInvoice.ToString

                    PropertyValue = Value

                    If Me.TotalDisbursed <> PropertyValue Then

                        IsValid = False

                        ErrorText = "Total Disbursed must equal Total Invoice."

                    End If

                Case AdvantageFramework.Database.Classes.ImportAccountPayableHeader.Properties.InvoiceNumber.ToString

                    PropertyValue = Value

                    Try

                        AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadByVendorAndInvoiceNumber(ObjectContext, Me.VendorCode, PropertyValue)

                    Catch ex As Exception
                        AccountPayable = Nothing
                    End Try

                    If AccountPayable IsNot Nothing Then

                        IsValid = False

                        ErrorText = "Invoice Number exists for Vendor."

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

