Namespace AccountPayable.Classes

    <Serializable()>
    Public Class ImportAccountPayableJobBillingRate
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ImportAccountPayableJobID
            NonBillFlag
            Commission
            TaxCommission
            TaxCommissionOnly
            TaxCode
            BillingRate
            GLACodeWIP
        End Enum

#End Region

#Region " Variables "

        Private _ImportAccountPayableJobID As Integer = Nothing
        Private _BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
        Private _GLACodeWIP As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property ImportAccountPayableJobID() As Integer
            Get
                ImportAccountPayableJobID = _ImportAccountPayableJobID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property NonBillFlag() As Nullable(Of Short)
            Get
                NonBillFlag = _BillingRate.NOBILL_FLAG
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Commission() As Nullable(Of Decimal)
            Get
                Commission = _BillingRate.COMM
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property TaxCommission() As Nullable(Of Short)
            Get
                TaxCommission = _BillingRate.TAX_COMM
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property TaxCommissionOnly() As Nullable(Of Short)
            Get
                TaxCommissionOnly = _BillingRate.TAX_COMM_ONLY
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property TaxCode() As String
            Get
                TaxCode = _BillingRate.TAX_CODE
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property BillingRate() As Nullable(Of Decimal)
            Get
                BillingRate = _BillingRate.BILLING_RATE
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property GLACodeWIP() As String
            Get
                GLACodeWIP = _GLACodeWIP
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable, Job As AdvantageFramework.Database.Entities.Job)

            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing

            BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, ImportAccountPayable.FunctionCode, Job.ClientCode, Job.DivisionCode, Job.ProductCode, ImportAccountPayable.JobNumber, ImportAccountPayable.JobComponentNumber, Job.SalesClassCode)

            _ImportAccountPayableJobID = ImportAccountPayable.ImportAccountPayableJobID
            _BillingRate = BillingRate
            _GLACodeWIP = Job.Office.ProductionWorkInProgressGLACode

        End Sub

#End Region

    End Class

End Namespace

