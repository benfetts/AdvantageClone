Namespace Database.Entities

    <Table("AP_RECUR_HDR")>
    Public Class AccountPayableRecur
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            InvoiceNumber
            Description
            InvoiceAmount
            ShippingAmount
            SalesTaxAmount
            DiscountPercent
            GLACode
            VendorTermCode
            CycleCode
            StartPostPeriodCode
            NumberToPost
            IsUnlimited
            SequenceBy
            OfficeCode
            LastPostedDate
            LastPostPeriodCode
            TotalPosted
            InactiveDate
            InactiveByUserCode
            IsInactive
            Is1099Invoice
            AccountPayableRecurGeneralLedgers
            GeneralLedgerAccount
            PostPeriod
            PostPeriodCode2
            VendorTerm
            Cycle

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
        <Column("RECUR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("VENDOR_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorCode() As String
        <Required>
        <MaxLength(15)>
        <Column("INV_NBR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InvoiceNumber() As String
        <MaxLength(30)>
        <Column("RECURRING_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("INV_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InvoiceAmount() As Decimal
        <Column("SHIPPING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        Public Property ShippingAmount() As Nullable(Of Decimal)
        <Column("SALES_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        Public Property SalesTaxAmount() As Nullable(Of Decimal)
        <Column("DISC_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        Public Property DiscountPercent() As Nullable(Of Decimal)
        <Required>
        <MaxLength(30)>
        <Column("GLACODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property GLACode() As String
        <MaxLength(3)>
        <Column("VT_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorTermCode() As String
        <Required>
        <MaxLength(6)>
        <Column("CYCODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CycleCode() As String
        <Required>
        <MaxLength(6)>
        <Column("START_PP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartPostPeriodCode() As String
        <Column("NUMBER_TO_POST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NumberToPost() As Nullable(Of Integer)
        <Column("UNLIMITED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsUnlimited() As Nullable(Of Short)
        <Required>
        <Column("SEQUENCE_BY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SequenceBy() As Short
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <Column("LAST_POSTED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastPostedDate() As Nullable(Of Date)
        <MaxLength(6)>
        <Column("LAST_PP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastPostPeriodCode() As String
        <Column("TOTAL_POSTED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalPosted() As Nullable(Of Integer)
        <Column("INACTIVE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InactiveDate() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("INACTIVE_SET_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InactiveByUserCode() As String
        <Column("INACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Nullable(Of Short)
        <Column("FLAG_1099")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Is1099Invoice() As Nullable(Of Short)

        Public Overridable Property AccountPayableRecurGeneralLedgers As ICollection(Of Database.Entities.AccountPayableRecurGeneralLedger)
        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("StartPostPeriodCode")>
        Public Overridable Property PostPeriod As Database.Entities.PostPeriod
        <ForeignKey("LastPostPeriodCode")>
        Public Overridable Property PostPeriodCode2 As Database.Entities.PostPeriod
        Public Overridable Property VendorTerm As Database.Entities.VendorTerm
        Public Overridable Property Cycle As Database.Entities.Cycle

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.NumberToPost.ToString

                    PropertyValue = Value

                    If (PropertyValue Is Nothing OrElse PropertyValue <= 0) AndAlso Me.IsUnlimited = 0 Then

                        IsValid = False

                        ErrorText = "You must enter the number of postings or check 'Unlimited'."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

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

                    Case AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.NumberToPost.ToString

                        If Me.IsUnlimited Is Nothing OrElse Me.IsUnlimited = 0 Then

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
