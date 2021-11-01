Namespace Database.Entities

	<Table("ACCT_REC")>
	Public Class AccountReceivable
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			InvoiceNumber
			SequenceNumber
			Type
			ClientCode
			DivisionCode
			ProductCode
			OfficeCode
			InvoiceDate
			Description
			InvoiceAmount
			PostPeriodCode
			GLACodeAR
			GLACodeSales
			CostOfSalesGLACode
			GLACodeOffset
			GLACodeState
			GLACodeCounty
			GLACodeCity
			GLTransaction
			GLSequenceNumberAR
			GLSequenceNumberSales
			GLSequenceNumberCOS
			GLSequenceNumberOffset
			GLSequenceNumberState
			GLSequenceNumberCounty
			GLSequenceNumberCity
			CostOfSalesAmount
			StateAmount
			CountyAmount
			CityAmount
			EmployeeTime
			IOAmount
			CommissionAmount
			CampaignCode
			SalesClassCode
			JobNumber
			JobComponentNumber
			ProductPONumber
			IsManualInvoice
			UserCode
			CreateDate
			AdvanceAmount
			InvoiceType
			IsVoided
			VoidDate
			VoidedByUserCode
			RecordType
			Modified
			SaleAmount
			OffsetAmount
			GLACodeDeferredSales
			GLSequenceNumberDeferredSales
			DeferredSaleAmount
			IsImportedInvoice
			VoidComment
			InvoiceCategoryCode
			DueDate
            BatchName
            ClientContactID
            QuickbooksInvoiceID
            QuickbooksCreateDate
            QuickbooksCreateByUserCode
            GeneralLedgerAccount
			InvoiceCategory
			Job
			JobComponent
			Office
			PostPeriod
			Product
			RadioOrderDetailLegaciesApr
			RadioOrderDetailLegaciesAug
			RadioOrderDetailLegaciesDec
			RadioOrderDetailLegaciesFeb
			RadioOrderDetailLegaciesJan
			RadioOrderDetailLegaciesJul
			RadioOrderDetailLegaciesJun
			RadioOrderDetailLegaciesMar
			RadioOrderDetailLegaciesMay
			RadioOrderDetailLegacies
			RadioOrderDetailLegaciesNov
			RadioOrderDetailLegaciesOct
			RadioOrderDetailLegaciesSep
			TVOrderDetailLegaciesApr
			TVOrderDetailLegaciesAug
			TVOrderDetailLegaciesDec
			TVOrderDetailLegaciesFeb
			TVOrderDetailLegaciesJan
			TVOrderDetailLegaciesJul
			TVOrderDetailLegaciesJun
			TVOrderDetailLegaciesMar
			TVOrderDetailLegaciesMay
			TVOrderDetailLegacies
			TVOrderDetailLegaciesNov
			TVOrderDetailLegaciesOct
			TVOrderDetailLegaciesSep
			Client
			ClientCashReceiptDetails
			AccountReceivableDocuments
            IncomeOnlys
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("AR_INV_NBR", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceNumber() As Integer
		<Key>
		<Required>
        <Column("AR_INV_SEQ", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SequenceNumber() As Short
		<Key>
		<Required>
		<MaxLength(3)>
        <Column("AR_TYPE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Type() As String
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<Column("AR_INV_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceDate() As Nullable(Of Date)
		<MaxLength(40)>
		<Column("AR_DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("AR_INV_AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property InvoiceAmount() As Nullable(Of Decimal)
		<MaxLength(6)>
		<Column("AR_POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<MaxLength(30)>
		<Column("GLACODE_AR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeAR() As String
		<MaxLength(30)>
		<Column("GLACODE_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeSales() As String
		<MaxLength(30)>
		<Column("GLACODE_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_OFFSET", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeOffset() As String
		<MaxLength(30)>
		<Column("GLACODE_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeState() As String
		<MaxLength(30)>
		<Column("GLACODE_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeCounty() As String
		<MaxLength(30)>
		<Column("GLACODE_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeCity() As String
		<Column("GLEXACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Nullable(Of Integer)
		<Column("GLESEQ_AR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberAR() As Nullable(Of Short)
		<Column("GLESEQ_SALES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberSales() As Nullable(Of Short)
		<Column("GLESEQ_COS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberCOS() As Nullable(Of Short)
		<Column("GLESEQ_OFFSET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberOffset() As Nullable(Of Short)
		<Column("GLESEQ_STATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberState() As Nullable(Of Short)
		<Column("GLESEQ_COUNTY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberCounty() As Nullable(Of Short)
		<Column("GLESEQ_CITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberCity() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AR_COS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CostOfSalesAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AR_STATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property StateAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AR_COUNTY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CountyAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AR_CITY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CityAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AR_EMP_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTime() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AR_IO_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property IOAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AR_COMM_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property CommissionAmount() As Nullable(Of Decimal)
		<MaxLength(6)>
		<Column("CMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignCode() As String
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesClassCode() As String
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<MaxLength(40)>
		<Column("PRD_PO_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductPONumber() As String
		<Column("MANUAL_INV")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsManualInvoice() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("USERID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("AR_ADVANCE_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property AdvanceAmount() As Nullable(Of Decimal)
		<Column("INV_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceType() As Nullable(Of Short)
		<Column("VOID_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsVoided() As Nullable(Of Short)
		<Column("VOID_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VoidDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("VOIDED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VoidedByUserCode() As String
		<MaxLength(1)>
		<Column("REC_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RecordType() As String
		<Column("MODIFY_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Modified() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        <Column("AR_SALE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SaleAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        <Column("AR_OFFSET_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property OffsetAmount() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("GLACODE_DEF_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeDeferredSales() As String
		<Column("GLESEQ_DEF_SALES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberDeferredSales() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        <Column("AR_DEF_SALE_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property DeferredSaleAmount() As Nullable(Of Decimal)
		<Column("IMPORTED_INV")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsImportedInvoice() As Nullable(Of Short)
		<MaxLength(254)>
		<Column("VO_COMMENT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VoidComment() As String
		<MaxLength(6)>
		<Column("INV_CAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceCategoryCode() As String
		<Column("DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DueDate() As Nullable(Of Date)
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BatchName() As String
		<Column("CDP_CONTACT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactID() As Nullable(Of Integer)
        <MaxLength(21)>
        <Column("QUICKBOOKS_INVOICE_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuickbooksInvoiceID() As String
        <Column("QB_CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuickbooksCreateDate() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("QB_CREATE_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuickbooksCreateByUserCode() As String

        <ForeignKey("GLACodeAR")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property InvoiceCategory As Database.Entities.InvoiceCategory
        Public Overridable Property Job As Database.Entities.Job
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property PostPeriod As Database.Entities.PostPeriod
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property AccountReceivableDocuments As ICollection(Of Database.Entities.AccountReceivableDocument)
        Public Overridable Property IncomeOnlys As ICollection(Of Database.Entities.IncomeOnly)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber.ToString

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

                    Case AdvantageFramework.Database.Entities.AccountReceivable.Properties.InvoiceAmount.ToString

                        If Me.IsManualInvoice = 1 Then

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

                Case AdvantageFramework.Database.Entities.AccountReceivable.Properties.InvoiceAmount.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If Me.IsManualInvoice = 1 AndAlso PropertyValue = 0 Then

                            IsValid = False

                            ErrorText = "An invoice amount must be entered."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
