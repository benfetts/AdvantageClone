Namespace Database.Entities

    <Table("IMP_ACCT_REC")>
    Public Class AccountReceivableImportStaging
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            RecordNumber
            ImportARInvoiceNumber
            AdvanARInvoiceNumber
            AdvanARInvoiceSequenceNumber
            AdvanARType
            ClientCode
            DivisionCode
            ProductCode
            InvoiceDate
            InvoiceAmount
            SaleAmount
            DeferredAmount
            OffsetAmount
            CostOfSalesAmount
            EmployeeTime
            IOAmount
            CommissionAmount
            StateAmount
            CountyAmount
            CityAmount
            GLACodeAR
            GLACodeSales
            GLACodeDefSales
            GLACodeCOS
            GLACodeOffset
            GLACodeState
            GLACodeCounty
            GLACodeCity
            CampaignCode
            SalesClassCode
            JobNumber
            JobComponentNumber
            ClientPO
            IsVoided
            VoidDate
            RecordType
            PriorRecordNumber
            PostFlag
            BatchName
            IsOnHold
            OfficeCode
            DueDate
            ImportTemplateID

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("REC_NBR")>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RecordNumber() As Integer
        <Required>
        <MaxLength(40)>
        <Column("IMP_AR_INV_NBR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ImportARInvoiceNumber() As String
        <Column("ADVAN_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanARInvoiceNumber() As Nullable(Of Integer)
        <Column("ADVAN_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanARInvoiceSequenceNumber() As Nullable(Of Short)
        <Required>
        <MaxLength(3)>
        <Column("ADVAN_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AdvanARType() As String
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
        <Required>
        <MaxLength(8)>
        <Column("AR_INV_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InvoiceDate() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        <Column("AR_INV_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InvoiceAmount() As Decimal
        <Column("AR_SALE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property SaleAmount() As Nullable(Of Decimal)
        <Column("AR_DEF_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property DeferredAmount() As Nullable(Of Decimal)
        <Column("AR_OFFSET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property OffsetAmount() As Nullable(Of Decimal)
        <Column("AR_COS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property CostOfSalesAmount() As Nullable(Of Decimal)
        <Column("AR_EMP_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property EmployeeTime() As Nullable(Of Decimal)
        <Column("AR_IO_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property IOAmount() As Nullable(Of Decimal)
        <Column("AR_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property CommissionAmount() As Nullable(Of Decimal)
        <Column("AR_STATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property StateAmount() As Nullable(Of Decimal)
        <Column("AR_COUNTY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property CountyAmount() As Nullable(Of Decimal)
        <Column("AR_CITY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 2)>
        Public Property CityAmount() As Nullable(Of Decimal)
        <MaxLength(30)>
        <Column("GLACODE_AR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeAR() As String
        <MaxLength(30)>
        <Column("GLACODE_SALES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeSales() As String
        <MaxLength(30)>
        <Column("GLACODE_DEF_SALES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeDefSales() As String
        <MaxLength(30)>
        <Column("GLACODE_COS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeCOS() As String
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
        <MaxLength(30)>
        <Column("PRD_CLI_REF", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPO() As String
        <Column("VOID_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsVoided() As Nullable(Of Short)
        <MaxLength(8)>
        <Column("VOID_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VoidDate() As String
        <MaxLength(1)>
        <Column("REC_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RecordType() As String
        <Column("PRIOR_REC_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PriorRecordNumber() As Nullable(Of Integer)
        <MaxLength(2)>
        <Column("POST_FLAG", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostFlag() As String
        <MaxLength(50)>
        <Column("BATCH_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BatchName() As String
        <Column("ON_HOLD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsOnHold() As Nullable(Of Boolean)
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <Column("DUE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As Nullable(Of Date)
        <Column("TEMPLATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ImportTemplateID() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.RecordNumber.ToString

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String,
                                                                 ByVal IsEntityKey As Boolean, ByVal IsNullable As Boolean, ByVal IsRequired As Boolean, ByVal MaxLength As Integer,
                                                                 ByVal Precision As Long, ByVal Scale As Long, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.DivisionCode.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.ProductCode.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeCity.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeCOS.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeCounty.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeDefSales.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeOffset.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeState.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.CampaignCode.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.SalesClassCode.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.ClientPO.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.OfficeCode.ToString

                    If Value = "" Then

                        Value = Nothing

                    End If

            End Select

        End Sub
        Protected Overrides Sub ClearNonRequiredPropertiesWithInvalidBlankValues(ByVal PropertyName As String, ByRef Value As Object)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.DivisionCode.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.ProductCode.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeCity.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeCOS.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeCounty.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeDefSales.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeOffset.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.GLACodeState.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.CampaignCode.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.SalesClassCode.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.ClientPO.ToString,
                        AdvantageFramework.Database.Entities.AccountReceivableImportStaging.Properties.OfficeCode.ToString

                    Value = Nothing

            End Select

        End Sub

#End Region

    End Class

End Namespace
