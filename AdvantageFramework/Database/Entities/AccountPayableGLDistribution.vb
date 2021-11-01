Namespace Database.Entities

    <Table("AP_GL_DIST")>
    Public Class AccountPayableGLDistribution
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableID
            AccountPayableSequenceNumber
            LineNumber
            GLACode
            Amount
            PODetailLineNumber
            GLTransaction
            GLSequenceNumber
            PostPeriodCode
            PONumber
            Comment
            OfficeCode
            GLACodeDueFrom
            GLACodeDueTo
            GLSequenceNumberDueFrom
            GLSequenceNumberDueTo
            ModifyDelete
            IsDeleted
            CreatedBy
            CreateDate
            ModifiedBy
            ModifyDate
            ExpenseReportDetailID
            AccountPayable
            GeneralLedgerAccount
            GeneralLedger
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("AP_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AccountPayableID() As Integer
        <Key>
        <Required>
        <Column("AP_SEQ", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AccountPayableSequenceNumber() As Short
        <Key>
        <Required>
        <Column("LINE_NUMBER", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineNumber() As Short
        <Required>
        <MaxLength(30)>
        <Column("GLACODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("AP_GL_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Amount() As Decimal
        <Column("PO_LINE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PODetailLineNumber() As Nullable(Of Short)
        <Column("GLEXACT")>
        <ForeignKey("GeneralLedger")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLTransaction() As Nullable(Of Integer)
        <Column("GLESEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumber() As Nullable(Of Short)
        <MaxLength(8)>
        <Column("POST_PERIOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodCode)>
        Public Property PostPeriodCode() As String
        <Column("PO_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PONumber() As Nullable(Of Integer)
		<Column("AP_COMMENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("GLACODE_DUE_FROM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeDueFrom() As String
        <MaxLength(30)>
        <Column("GLACODE_DUE_TO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeDueTo() As String
        <Column("GLESEQ_DUE_FROM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberDueFrom() As Nullable(Of Short)
        <Column("GLESEQ_DUE_TO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberDueTo() As Nullable(Of Short)
        <Column("MODIFY_DELETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifyDelete() As Nullable(Of Short)
        <Column("DELETE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDeleted() As Nullable(Of Short)
        <MaxLength(100)>
        <Column("CREATED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedBy() As String
        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateDate() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("MODIFIED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedBy() As String
        <Column("MODIFY_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifyDate() As Nullable(Of Date)
        <Column("EXPDETAILID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExpenseReportDetailID() As Nullable(Of Integer)

        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property GeneralLedger As Database.Entities.GeneralLedger

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.AccountPayableGLDistribution

            Dim EntityCopy As AdvantageFramework.Database.Entities.AccountPayableGLDistribution = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.AccountPayableGLDistribution

            With EntityCopy
                .AccountPayableID = Me.AccountPayableID
                .AccountPayableSequenceNumber = Me.AccountPayableSequenceNumber
                .LineNumber = Me.LineNumber
                .GLACode = Me.GLACode
                .Amount = Me.Amount
                .PODetailLineNumber = Me.PODetailLineNumber
                .GLTransaction = Me.GLTransaction
                .GLSequenceNumber = Me.GLSequenceNumber
                .PostPeriodCode = Me.PostPeriodCode
                .PONumber = Me.PONumber
                .Comment = Me.Comment
                .OfficeCode = Me.OfficeCode
                .GLACodeDueFrom = Me.GLACodeDueFrom
                .GLACodeDueTo = Me.GLACodeDueTo
                .GLSequenceNumberDueFrom = Me.GLSequenceNumberDueFrom
                .GLSequenceNumberDueTo = Me.GLSequenceNumberDueTo
                .ModifyDelete = Me.ModifyDelete
                .IsDeleted = Me.IsDeleted
                .CreatedBy = Me.CreatedBy
                .CreateDate = Me.CreateDate
                .ModifiedBy = Me.ModifiedBy
                .ModifyDate = Me.ModifyDate
                .ExpenseReportDetailID = Me.ExpenseReportDetailID
            End With

            Copy = EntityCopy

        End Function

#End Region

    End Class

End Namespace
