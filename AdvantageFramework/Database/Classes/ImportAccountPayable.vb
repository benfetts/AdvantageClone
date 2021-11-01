Namespace Database.Classes

    <Serializable()>
    Public Class ImportAccountPayable
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
            TotalInvoice
            MediaDisbursed
            JobDisbursed
            GLDisbursed
            TotalDisbursed
            ImportAccountPayableGLID
            GLACode
            GLNetAmount
            GLComment
            GLOfficeCode
            ImportAccountPayableJobID
            PONumber
            POLine
            JobNumber
            JobComponentNumber
            FunctionCode
            JobQuantity
            JobNetAmount
            JobVendorTax
            PreviouslyPostedNetAmount
            PONetAmount
            PONetVariance
            JobComment
            JobOfficeCode
            JobClientCode
            JobClientName
            JobDivisionCode
            JobDivisionName
            JobProductCode
            JobProductName
            ImportAccountPayableMediaID
            MediaType
            OrderID
            OrderNumber
            Month
            Year
            SalesClassCode
            OrderLineID
            OrderLineNumber
            LineDate
            MediaQuantity
            MediaNetAmount
            MediaVendorTax
            MediaNetCharge
            MediaMarkupPercent
            MediaAddAmount
            MediaPreviouslyPostedNetAmount
            OrderNetAmount
            OrderNetVariance
            MediaOfficeCode
            MediaClientCode
            MediaClientName
            MediaDivisionCode
            MediaDivisionName
            MediaProductCode
            MediaProductName
            MediaOrderNumberIsBroadcastLegacy
        End Enum

#End Region

#Region " Variables "

        Private _ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader = Nothing
        Private _ImportAccountPayableGL As AdvantageFramework.Database.Classes.ImportAccountPayableGL = Nothing
        Private _ImportAccountPayableJob As AdvantageFramework.Database.Classes.ImportAccountPayableJob = Nothing
        Private _ImportAccountPayableMedia As AdvantageFramework.Database.Classes.ImportAccountPayableMedia = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportAccountPayableHeader.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property BatchName() As String
            Get
                BatchName = _ImportAccountPayableHeader.BatchName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsOnHold() As Boolean
            Get
                IsOnHold = _ImportAccountPayableHeader.IsOnHold
            End Get
            Set(value As Boolean)
                _ImportAccountPayableHeader.IsOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.VendorCode, IsImportDefaultProperty:=True)>
        Public Property VendorCode() As String
            Get
                VendorCode = _ImportAccountPayableHeader.VendorCode
            End Get
            Set(value As String)
                _ImportAccountPayableHeader.VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorName() As String
            Get
                VendorName = _ImportAccountPayableHeader.VendorName
            End Get
            Set(value As String)
                _ImportAccountPayableHeader.VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _ImportAccountPayableHeader.InvoiceNumber
            End Get
            Set(value As String)
                _ImportAccountPayableHeader.InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property InvoiceDescription() As String
            Get
                InvoiceDescription = _ImportAccountPayableHeader.InvoiceDescription
            End Get
            Set(value As String)
                _ImportAccountPayableHeader.InvoiceDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsImportDefaultProperty:=True)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _ImportAccountPayableHeader.InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _ImportAccountPayableHeader.InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property InvoiceTotalNet() As Nullable(Of Decimal)
            Get
                InvoiceTotalNet = _ImportAccountPayableHeader.InvoiceTotalNet
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableHeader.InvoiceTotalNet = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property InvoiceTotalTax() As Nullable(Of Decimal)
            Get
                InvoiceTotalTax = _ImportAccountPayableHeader.InvoiceTotalTax
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableHeader.InvoiceTotalTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.OfficeCode, IsImportDefaultProperty:=True)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _ImportAccountPayableHeader.OfficeCode
            End Get
            Set(value As String)
                _ImportAccountPayableHeader.OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode, IsImportDefaultProperty:=True, CustomColumnCaption:="GL Account")>
        Public Property GLAccount() As String
            Get
                GLAccount = _ImportAccountPayableHeader.GLACode
            End Get
            Set(value As String)
                _ImportAccountPayableHeader.GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property TotalInvoice() As Decimal
            Get
                TotalInvoice = _ImportAccountPayableHeader.TotalInvoice
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property MediaDisbursed() As Decimal
            Get
                MediaDisbursed = _ImportAccountPayableHeader.MediaDisbursed
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property JobDisbursed() As Decimal
            Get
                JobDisbursed = _ImportAccountPayableHeader.JobDisbursed
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property GLDisbursed() As Decimal
            Get
                GLDisbursed = _ImportAccountPayableHeader.GLDisbursed
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property TotalDisbursed() As Decimal
            Get
                TotalDisbursed = _ImportAccountPayableHeader.TotalDisbursed
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportAccountPayableMediaID() As Integer
            Get
                ImportAccountPayableMediaID = _ImportAccountPayableMedia.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaOfficeCode() As String
            Get
                MediaOfficeCode = _ImportAccountPayableMedia.MediaOfficeCode
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.MediaOfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode, CustomColumnCaption:="Client Code")>
        Public Property MediaClientCode() As String
            Get
                MediaClientCode = _ImportAccountPayableMedia.MediaClientCode
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.MediaClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Name", IsReadOnlyColumn:=True)>
        Public Property MediaClientName() As String
            Get
                MediaClientName = _ImportAccountPayableMedia.ClientName
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode, CustomColumnCaption:="Division Code")>
        Public Property MediaDivisionCode() As String
            Get
                MediaDivisionCode = _ImportAccountPayableMedia.MediaDivisionCode
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.MediaDivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division Name", IsReadOnlyColumn:=True)>
        Public Property MediaDivisionName() As String
            Get
                MediaDivisionName = _ImportAccountPayableMedia.DivisionName
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode, CustomColumnCaption:="Product Code")>
        Public Property MediaProductCode() As String
            Get
                MediaProductCode = _ImportAccountPayableMedia.MediaProductCode
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.MediaProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Name", IsReadOnlyColumn:=True)>
        Public Property MediaProductName() As String
            Get
                MediaProductName = _ImportAccountPayableMedia.ProductName
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MediaOrderNumberIsBroadcastLegacy() As Boolean
            Get
                MediaOrderNumberIsBroadcastLegacy = _ImportAccountPayableMedia.IsLegacyBroadcastOrder
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.MediaType, IsImportDefaultProperty:=True)>
        Public Property MediaType() As String
            Get
                MediaType = _ImportAccountPayableMedia.MediaType
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderID() As Nullable(Of Integer)
            Get
                OrderID = _ImportAccountPayableMedia.OrderID
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableMedia.OrderID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _ImportAccountPayableMedia.OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableMedia.OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Month() As String
            Get
                Month = _ImportAccountPayableMedia.Month
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.Month = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Year() As Nullable(Of Short)
            Get
                Year = _ImportAccountPayableMedia.Year
            End Get
            Set(value As Nullable(Of Short))
                _ImportAccountPayableMedia.Year = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.SalesClassCode, IsImportDefaultProperty:=True)>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _ImportAccountPayableMedia.SalesClassCode
            End Get
            Set(value As String)
                _ImportAccountPayableMedia.SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderLineID() As Nullable(Of Integer)
            Get
                OrderLineID = _ImportAccountPayableMedia.OrderLineID
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableMedia.OrderLineID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderLineNumber() As Nullable(Of Short)
            Get
                OrderLineNumber = _ImportAccountPayableMedia.OrderLineNumber
            End Get
            Set(value As Nullable(Of Short))
                _ImportAccountPayableMedia.OrderLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineDate() As Nullable(Of Date)
            Get
                LineDate = _ImportAccountPayableMedia.LineDate
            End Get
            Set(value As Nullable(Of Date))
                _ImportAccountPayableMedia.LineDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaQuantity() As Nullable(Of Decimal)
            Get
                MediaQuantity = _ImportAccountPayableMedia.MediaQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property MediaNetAmount() As Nullable(Of Decimal)
            Get
                MediaNetAmount = _ImportAccountPayableMedia.MediaNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaVendorTax() As Nullable(Of Decimal)
            Get
                MediaVendorTax = _ImportAccountPayableMedia.MediaVendorTax
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaVendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaNetCharge() As Nullable(Of Decimal)
            Get
                MediaNetCharge = _ImportAccountPayableMedia.MediaNetCharge
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaNetCharge = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MediaMarkupPercent() As Nullable(Of Decimal)
            Get
                MediaMarkupPercent = _ImportAccountPayableMedia.MediaMarkupPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaMarkupPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Media Fee Amount")>
        Public Property MediaAddAmount() As Nullable(Of Decimal)
            Get
                MediaAddAmount = _ImportAccountPayableMedia.MediaAddAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.MediaAddAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Previously Posted Net Amount", IsReadOnlyColumn:=True)>
        Public Property MediaPreviouslyPostedNetAmount() As Nullable(Of Decimal)
            Get
                MediaPreviouslyPostedNetAmount = _ImportAccountPayableMedia.PreviouslyPostedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.PreviouslyPostedNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property OrderNetAmount() As Nullable(Of Decimal)
            Get
                OrderNetAmount = _ImportAccountPayableMedia.OrderNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableMedia.OrderNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property OrderNetVariance() As Nullable(Of Decimal)
            Get
                OrderNetVariance = _ImportAccountPayableMedia.OrderNetVariance
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportAccountPayableJobID() As Integer
            Get
                ImportAccountPayableJobID = _ImportAccountPayableJob.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobOfficeCode() As String
            Get
                JobOfficeCode = _ImportAccountPayableJob.JobOfficeCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.JobOfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode, CustomColumnCaption:="Client Code")>
        Public Property JobClientCode() As String
            Get
                JobClientCode = _ImportAccountPayableJob.JobClientCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.JobClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Name")>
        Public Property JobClientName() As String
            Get
                JobClientName = _ImportAccountPayableJob.ClientName
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode, CustomColumnCaption:="Division Code")>
        Public Property JobDivisionCode() As String
            Get
                JobDivisionCode = _ImportAccountPayableJob.JobDivisionCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.JobDivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division Name")>
        Public Property JobDivisionName() As String
            Get
                JobDivisionName = _ImportAccountPayableJob.DivisionName
            End Get
            Set(value As String)
                _ImportAccountPayableJob.DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode, CustomColumnCaption:="Product Code")>
        Public Property JobProductCode() As String
            Get
                JobProductCode = _ImportAccountPayableJob.JobProductCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.JobProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Name")>
        Public Property JobProductName() As String
            Get
                JobProductName = _ImportAccountPayableJob.ProductName
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PONumber() As Nullable(Of Integer)
            Get
                PONumber = _ImportAccountPayableJob.PONumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableJob.PONumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property POLine() As Nullable(Of Integer)
            Get
                POLine = _ImportAccountPayableJob.POLine
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableJob.POLine = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobNumber, IsImportDefaultProperty:=True)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _ImportAccountPayableJob.JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableJob.JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobComponent, IsImportDefaultProperty:=True)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _ImportAccountPayableJob.JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _ImportAccountPayableJob.JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.FunctionCode, IsImportDefaultProperty:=True)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _ImportAccountPayableJob.FunctionCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property JobQuantity() As Nullable(Of Decimal)
            Get
                JobQuantity = _ImportAccountPayableJob.JobQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.JobQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property JobNetAmount() As Nullable(Of Decimal)
            Get
                JobNetAmount = _ImportAccountPayableJob.JobNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.JobNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property JobVendorTax() As Nullable(Of Decimal)
            Get
                JobVendorTax = _ImportAccountPayableJob.JobVendorTax
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.JobVendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property PreviouslyPostedNetAmount() As Nullable(Of Decimal)
            Get
                PreviouslyPostedNetAmount = _ImportAccountPayableJob.PreviouslyPostedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.PreviouslyPostedNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property PONetAmount() As Nullable(Of Decimal)
            Get
                PONetAmount = _ImportAccountPayableJob.PONetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.PONetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property PONetVariance() As Nullable(Of Decimal)
            Get
                PONetVariance = _ImportAccountPayableJob.PONetVariance
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComment() As String
            Get
                JobComment = _ImportAccountPayableJob.JobComment
            End Get
            Set(value As String)
                _ImportAccountPayableJob.JobComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportAccountPayableGLID() As Integer
            Get
                ImportAccountPayableGLID = _ImportAccountPayableGL.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode, IsImportDefaultProperty:=True)>
        Public Property GLACode() As String
            Get
                GLACode = _ImportAccountPayableGL.GLACode
            End Get
            Set(value As String)
                _ImportAccountPayableGL.GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property GLNetAmount() As Nullable(Of Decimal)
            Get
                GLNetAmount = _ImportAccountPayableGL.GLNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableGL.GLNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLComment() As String
            Get
                GLComment = _ImportAccountPayableGL.GLComment
            End Get
            Set(value As String)
                _ImportAccountPayableGL.GLComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Office Code")>
        Public Property GLOfficeCode() As String
            Get
                GLOfficeCode = _ImportAccountPayableGL.GLOfficeCode
            End Get
            Set(value As String)
                _ImportAccountPayableGL.GLOfficeCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportAccountPayableHeader = New AdvantageFramework.Database.Classes.ImportAccountPayableHeader
            _ImportAccountPayableGL = New AdvantageFramework.Database.Classes.ImportAccountPayableGL
            _ImportAccountPayableJob = New AdvantageFramework.Database.Classes.ImportAccountPayableJob
            _ImportAccountPayableMedia = New AdvantageFramework.Database.Classes.ImportAccountPayableMedia

        End Sub
        Public Sub New(ByVal ObjectContext As AdvantageFramework.BaseClasses.ObjectContext, _
                       ByVal ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable, _
                       ByVal ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader, _
                       ByVal ImportAccountPayableGL As AdvantageFramework.Database.Classes.ImportAccountPayableGL)

            _ImportAccountPayableHeader = ImportAccountPayableHeader
            _ImportAccountPayableGL = ImportAccountPayableGL
            _ImportAccountPayableJob = New AdvantageFramework.Database.Classes.ImportAccountPayableJob
            _ImportAccountPayableMedia = New AdvantageFramework.Database.Classes.ImportAccountPayableMedia

            Me.ObjectContext = ObjectContext

            For Each ImportAccountPayableError In ImportAccountPayable.ImportAccountPayableErrors.Where(Function(E) E.ImportAccountPayableID = ImportAccountPayable.ID)

                If Not Me._ErrorHashtable.ContainsKey(ImportAccountPayableError.PropertyName) Then

                    Me._ErrorHashtable.Add(ImportAccountPayableError.PropertyName, ImportAccountPayableError.ErrorDescription)

                    If EntityError Is Nothing OrElse EntityError = "" Then

                        EntityError = ImportAccountPayableError.ErrorDescription

                    Else

                        EntityError += vbCrLf & ImportAccountPayableError.ErrorDescription

                    End If

                End If

                If ImportAccountPayableError.ImportAccountPayableGLID = _ImportAccountPayableGL.ID Then

                    If Not Me._ImportAccountPayableGL.ErrorHashtable.ContainsKey(ImportAccountPayableError.PropertyName) Then

                        Me._ImportAccountPayableGL.ErrorHashtable.Add(ImportAccountPayableError.PropertyName, ImportAccountPayableError.ErrorDescription)

                    End If

                End If

            Next

            If EntityError IsNot Nothing Then

                Me.EntityError = EntityError

            End If

        End Sub
        Public Sub New(ByVal ObjectContext As AdvantageFramework.BaseClasses.ObjectContext, _
                       ByVal ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable, _
                       ByVal ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader, _
                       ByVal ImportAccountPayableJob As AdvantageFramework.Database.Classes.ImportAccountPayableJob)

            Dim EntityError As String = Nothing

            _ImportAccountPayableHeader = ImportAccountPayableHeader
            _ImportAccountPayableJob = ImportAccountPayableJob
            _ImportAccountPayableGL = New AdvantageFramework.Database.Classes.ImportAccountPayableGL
            _ImportAccountPayableMedia = New AdvantageFramework.Database.Classes.ImportAccountPayableMedia

            Me.ObjectContext = ObjectContext

            For Each ImportAccountPayableError In ImportAccountPayable.ImportAccountPayableErrors.Where(Function(E) E.ImportAccountPayableID = ImportAccountPayable.ID)

                If Not Me._ErrorHashtable.ContainsKey(ImportAccountPayableError.PropertyName) Then

                    Me._ErrorHashtable.Add(ImportAccountPayableError.PropertyName, ImportAccountPayableError.ErrorDescription)

                    If EntityError Is Nothing OrElse EntityError = "" Then

                        EntityError = ImportAccountPayableError.ErrorDescription

                    Else

                        EntityError += vbCrLf & ImportAccountPayableError.ErrorDescription

                    End If

                End If

                If ImportAccountPayableError.ImportAccountPayableJobID = _ImportAccountPayableJob.ID Then

                    If Not Me._ImportAccountPayableJob.ErrorHashtable.ContainsKey(ImportAccountPayableError.PropertyName) Then

                        Me._ImportAccountPayableJob.ErrorHashtable.Add(ImportAccountPayableError.PropertyName, ImportAccountPayableError.ErrorDescription)

                    End If

                End If

            Next

            If EntityError IsNot Nothing Then

                Me.EntityError = EntityError

            End If

        End Sub
        Public Sub New(ByVal ObjectContext As AdvantageFramework.BaseClasses.ObjectContext, _
                       ByVal ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable, _
                       ByVal ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader, _
                       ByVal ImportAccountPayableMedia As AdvantageFramework.Database.Classes.ImportAccountPayableMedia)

            _ImportAccountPayableHeader = ImportAccountPayableHeader
            _ImportAccountPayableMedia = ImportAccountPayableMedia
            _ImportAccountPayableGL = New AdvantageFramework.Database.Classes.ImportAccountPayableGL
            _ImportAccountPayableJob = New AdvantageFramework.Database.Classes.ImportAccountPayableJob

            Me.ObjectContext = ObjectContext

            For Each ImportAccountPayableError In ImportAccountPayable.ImportAccountPayableErrors.Where(Function(E) E.ImportAccountPayableID = ImportAccountPayable.ID)

                If Not Me._ErrorHashtable.ContainsKey(ImportAccountPayableError.PropertyName) Then

                    Me._ErrorHashtable.Add(ImportAccountPayableError.PropertyName, ImportAccountPayableError.ErrorDescription)

                    If EntityError Is Nothing OrElse EntityError = "" Then

                        EntityError = ImportAccountPayableError.ErrorDescription

                    Else

                        EntityError += vbCrLf & ImportAccountPayableError.ErrorDescription

                    End If

                End If

                If ImportAccountPayableError.ImportAccountPayableMediaID = _ImportAccountPayableMedia.ID Then

                    If Not Me._ImportAccountPayableMedia.ErrorHashtable.ContainsKey(ImportAccountPayableError.PropertyName) Then

                        Me._ImportAccountPayableMedia.ErrorHashtable.Add(ImportAccountPayableError.PropertyName, ImportAccountPayableError.ErrorDescription)

                    End If

                End If

            Next

            If EntityError IsNot Nothing Then

                Me.EntityError = EntityError

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = _ImportAccountPayableHeader.ID

        End Function
        Public Function GetHeader() As AdvantageFramework.Database.Entities.ImportAccountPayable

            GetHeader = _ImportAccountPayableHeader.GetEntity

        End Function
        Public Function GetDetail() As AdvantageFramework.BaseClasses.Entity

            If _ImportAccountPayableGL.ID <> 0 Then

                GetDetail = _ImportAccountPayableGL.GetEntity

            ElseIf _ImportAccountPayableJob.ID <> 0 Then

                GetDetail = _ImportAccountPayableJob.GetEntity

            Else

                GetDetail = _ImportAccountPayableMedia.GetEntity

            End If

        End Function
        Public Function GetImportAccountPayableHeader() As AdvantageFramework.Database.Classes.ImportAccountPayableHeader

            GetImportAccountPayableHeader = _ImportAccountPayableHeader

        End Function
        Public Function GetImportAccountPayableGL() As AdvantageFramework.Database.Classes.ImportAccountPayableGL

            GetImportAccountPayableGL = _ImportAccountPayableGL

        End Function
        Public Function GetImportAccountPayableJob() As AdvantageFramework.Database.Classes.ImportAccountPayableJob

            GetImportAccountPayableJob = _ImportAccountPayableJob

        End Function
        Public Function GetImportAccountPayableMedia() As AdvantageFramework.Database.Classes.ImportAccountPayableMedia

            GetImportAccountPayableMedia = _ImportAccountPayableMedia

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function
        Public Overrides Function LoadErrorText(ByVal PropertyName As String) As String

            'objects
            Dim ErrorText As String = ""

            Try

                If Me.ImportAccountPayableGLID = 0 AndAlso _
                        (PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.GLACode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.GLNetAmount.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.GLOfficeCode.ToString) Then

                    ErrorText = Nothing

                ElseIf Me.ImportAccountPayableGLID <> 0 AndAlso _
                        (PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.GLACode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.GLNetAmount.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.GLOfficeCode.ToString) AndAlso _
                        _ImportAccountPayableGL.ErrorHashtable.Item(PropertyName) = "" Then

                    ErrorText = Nothing

                ElseIf Me.ImportAccountPayableJobID = 0 AndAlso _
                        (PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.POLine.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobNumber.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobComponentNumber.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.FunctionCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobClientCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobDivisionCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobProductCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobOfficeCode.ToString) Then

                    ErrorText = Nothing

                ElseIf Me.ImportAccountPayableJobID <> 0 AndAlso _
                        (PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.POLine.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobNumber.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobComponentNumber.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.FunctionCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobClientCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobDivisionCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobProductCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.JobOfficeCode.ToString) AndAlso _
                        _ImportAccountPayableJob.ErrorHashtable.Item(PropertyName) = "" Then

                    ErrorText = Nothing

                ElseIf Me.ImportAccountPayableMediaID = 0 AndAlso _
                        (PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaType.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.OrderID.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.OrderNumber.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.Month.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.Year.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.OrderLineID.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.LineDate.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaNetAmount.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaDivisionCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaProductCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaOfficeCode.ToString) Then

                    ErrorText = Nothing

                ElseIf Me.ImportAccountPayableMediaID <> 0 AndAlso _
                        (PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaType.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.OrderID.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.OrderNumber.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.Month.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.Year.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.OrderLineID.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.OrderLineNumber.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.LineDate.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaNetAmount.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaDivisionCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaProductCode.ToString OrElse _
                         PropertyName = AdvantageFramework.Database.Classes.ImportAccountPayable.Properties.MediaOfficeCode.ToString) AndAlso _
                        _ImportAccountPayableMedia.ErrorHashtable.Item(PropertyName) = "" Then

                    ErrorText = Nothing

                Else

                    ErrorText = _ErrorHashtable(PropertyName)

                End If

            Catch ex As Exception
                ErrorText = ""
            Finally
                LoadErrorText = ErrorText
            End Try

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            _ImportAccountPayableHeader.ObjectContext = Me.ObjectContext

            _EntityError = _ImportAccountPayableHeader.ValidateEntity(IsValid)

            RefreshErrorHashtable()

            ValidateEntity = _EntityError

        End Function
        Public Sub RefreshErrorHashtable()

            Dim ErrorString As String = Nothing

            Me.ErrorHashtable.Clear()

            For Each Key In _ImportAccountPayableHeader.ErrorHashtable.Keys

                If _ImportAccountPayableHeader.ErrorHashtable.Item(Key) <> "" AndAlso Me.ErrorHashtable.ContainsKey(Key) = False Then

                    Me.ErrorHashtable.Add(Key, _ImportAccountPayableHeader.ErrorHashtable.Item(Key))

                End If

            Next

            For Each ImportAccountPayableGL In _ImportAccountPayableHeader.ImportAccountPayableGLs

                For Each Key In ImportAccountPayableGL.ErrorHashtable.Keys

                    If ImportAccountPayableGL.ErrorHashtable.Item(Key) <> "" AndAlso Me.ErrorHashtable.ContainsKey(Key) = False Then

                        Me.ErrorHashtable.Add(Key, ImportAccountPayableGL.ErrorHashtable.Item(Key))

                    End If

                Next

            Next

            For Each ImportAccountPayableJob In _ImportAccountPayableHeader.ImportAccountPayableJobs

                For Each Key In ImportAccountPayableJob.ErrorHashtable.Keys

                    If ImportAccountPayableJob.ErrorHashtable.Item(Key) <> "" AndAlso Me.ErrorHashtable.ContainsKey(Key) = False Then

                        Me.ErrorHashtable.Add(Key, ImportAccountPayableJob.ErrorHashtable.Item(Key))

                    End If

                Next

            Next

            For Each ImportAccountPayableMedia In _ImportAccountPayableHeader.ImportAccountPayableMedias

                For Each Key In ImportAccountPayableMedia.ErrorHashtable.Keys

                    If ImportAccountPayableMedia.ErrorHashtable.Item(Key) <> "" AndAlso Me.ErrorHashtable.ContainsKey(Key) = False Then

                        Me.ErrorHashtable.Add(Key, ImportAccountPayableMedia.ErrorHashtable.Item(Key))

                    End If

                Next

            Next

            For Each Key In Me.ErrorHashtable.Keys

                ErrorString = If(ErrorString Is Nothing, Me.ErrorHashtable.Item(Key).ToString, ErrorString + vbNewLine + Me.ErrorHashtable.Item(Key).ToString)

            Next

            _EntityError = ErrorString

        End Sub

#End Region

    End Class

End Namespace

