Namespace Database.Entities

    <Table("INCOME_REC")>
    Public Class IncomeRecognize
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AdvanceBillingID
            SequenceNumber
            JobNumber
            JobComponentNumber
            ARInvoiceNumber
            ARInvoiceSequence
            ARType
            AdvanceBillFlag
            CreateDate
            UserCode
            BillingUser
            GLACodeSales
            GLACodeDeferredSales
            GLTransaction
            GLSequenceNumberSales
            GLSequenceNumberDeferredSales
            PostPeriodCode
            IsFinal
            MethodDescription
            BillDate
            IsVoided
            Amount
            BillingCommandCenterID
            FunctionCode

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("AB_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillingID() As Integer
        <Key>
        <Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Integer
        <Required>
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property JobNumber() As Integer
        <Required>
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property JobComponentNumber() As Short
        <Column("AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
        <Column("AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceSequence() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARType() As String
        <Column("AB_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillFlag() As Nullable(Of Short)
        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateDate() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("USER_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <MaxLength(100)>
        <Column("BILLING_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingUser() As String
        <MaxLength(30)>
        <Column("GLACODE_SALES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeSales() As String
        <MaxLength(30)>
        <Column("GLACODE_DEF_SALES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeDeferredSales() As String
        <Column("GLEXACT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLTransaction() As Nullable(Of Integer)
        <Column("GLESEQ_SALES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberSales() As Nullable(Of Short)
        <Column("GLESEQ_DEF_SALES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberDeferredSales() As Nullable(Of Short)
        <MaxLength(8)>
        <Column("POST_PERIOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodCode() As String
        <Column("FINAL_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsFinal() As Nullable(Of Short)
        <MaxLength(30)>
        <Column("METHOD_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MethodDescription() As String
        <Column("BILL_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillDate() As Nullable(Of Date)
        <Column("AR_INV_VOID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsVoided() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("REC_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Amount() As Nullable(Of Decimal)
        <Column("BCC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCommandCenterID() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AdvanceBillingID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.IncomeRecognize.Properties.FunctionCode.ToString

                    If Me.DatabaseAction = Database.Action.Inserting Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).IncomeRecognizes
                            Where Entity.JobNumber = Me.JobNumber AndAlso
                                  Entity.JobComponentNumber = Me.JobComponentNumber AndAlso
                                  Entity.FunctionCode = DirectCast(PropertyValue, String) AndAlso
                                  Entity.ARInvoiceNumber Is Nothing AndAlso
                                  Entity.AdvanceBillFlag <> 7
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Function exists."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function

#End Region

    End Class

End Namespace
