Namespace Database.Entities

    <Table("EXTERNAL_GLIFACE")>
    Public Class ExternalGLIFace
        Inherits BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            TransNum
            SeqNum
            PostedSW
            CompNum
            LocID
            PostingJL
            JournalNum
            TransCDate
            CreateCDate
            CreateUserID
            FiscalYear
            FiscalPD
            Source
            MediaType
            MediaID
            ClientInvoiceNum
            VendorInvoiceNum
            VendorID
            VendorName
            NetType
            ClientID
            DivisionID
            EmployeeID
            EmployeeName
            GLOrgID
            GLAcctID
            GLProjID
            Reference
            AccountDescription
            DebitAmount
            CreditAmount
            DtReserved4
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("EXTERNAL_GLIFACE_ID")>
        Public Property ID() As Integer

        <Column("TRANS_NUM")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        Public Property TransNum() As Decimal

        <Column("SEQ_NUM")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 0)>
        Public Property SeqNum() As Decimal

        <Column("POSTED_SW", TypeName:="varchar")>
        <MaxLength(1)>
        Public Property PostedSW() As String

        <Column("COMP_NUM")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(3, 0)>
        Public Property CompNum() As Nullable(Of Decimal)

        <Column("LOC_ID", TypeName:="varchar")>
        <MaxLength(3)>
        Public Property LocID() As String

        <Column("POSTING_JL", TypeName:="varchar")>
        <Required>
        <MaxLength(3)>
        Public Property PostingJL() As String

        <Column("JOURNAL_NUM")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 0)>
        Public Property JournalNum() As Nullable(Of Decimal)

        <Column("TRANS_CDATE")>
        Public Property TransCDate() As Nullable(Of Date)

        <Column("CREATE_CDATE")>
        Public Property CreateCDate() As Nullable(Of Date)

        <Column("CREATE_USER_ID", TypeName:="varchar")>
        <MaxLength(8)>
        Public Property CreateUserID() As String

        <Column("FISCAL_YEAR")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 0)>
        Public Property FiscalYear() As Nullable(Of Decimal)

        <Column("FISCAL_PD")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(2, 0)>
        Public Property FiscalPD() As Nullable(Of Decimal)

        <Column("SOURCE", TypeName:="varchar")>
        <MaxLength(2)>
        Public Property Source() As String

        <Column("MEDIA_TYPE", TypeName:="varchar")>
        <MaxLength(3)>
        Public Property MediaType() As String

        <Column("MEDIA_ID", TypeName:="varchar")>
        <MaxLength(12)>
        Public Property MediaID() As String

        <Column("CLIENT_INVOICE_NUM", TypeName:="varchar")>
        <MaxLength(11)>
        Public Property ClientInvoiceNum() As String

        <Column("VENDOR_INVOICE_NUM", TypeName:="varchar")>
        <Required>
        <MaxLength(15)>
        Public Property VendorInvoiceNum() As String

        <Column("VENDOR_ID", TypeName:="varchar")>
        <Required>
        <MaxLength(6)>
        Public Property VendorID() As String

        <Column("VENDOR_NAME", TypeName:="varchar")>
        <MaxLength(30)>
        Public Property VendorName() As String

        <Column("NET_TYPE", TypeName:="varchar")>
        <MaxLength(1)>
        Public Property NetType() As String

        <Column("CLIENT_ID", TypeName:="varchar")>
        <MaxLength(4)>
        Public Property ClientID() As String

        <Column("DIVIS_ID", TypeName:="varchar")>
        <MaxLength(4)>
        Public Property DivisionID() As String

        <Column("EMP_ID", TypeName:="varchar")>
        <MaxLength(5)>
        Public Property EmployeeID() As String

        <Column("EMP_NAME", TypeName:="varchar")>
        <MaxLength(30)>
        Public Property EmployeeName() As String

        <Column("GL_ORG_ID", TypeName:="varchar")>
        <MaxLength(12)>
        Public Property GLOrgID() As String

        <Column("GL_ACCT_ID", TypeName:="varchar")>
        <MaxLength(12)>
        Public Property GLAcctID() As String

        <Column("GL_PROJ_ID", TypeName:="varchar")>
        <MaxLength(12)>
        Public Property GLProjID() As String

        <Column("REFERENCE", TypeName:="varchar")>
        <MaxLength(30)>
        Public Property Reference() As String

        <Column("ACCT_DESCR", TypeName:="varchar")>
        <MaxLength(30)>
        Public Property AccountDescription() As String

        <Column("DB_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        Public Property DebitAmount() As Nullable(Of Decimal)

        <Column("CR_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        Public Property CreditAmount() As Nullable(Of Decimal)

        <Column("DT_RESERVED4", TypeName:="varchar")>
        <MaxLength(732)>
        Public Property DtReserved4() As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
