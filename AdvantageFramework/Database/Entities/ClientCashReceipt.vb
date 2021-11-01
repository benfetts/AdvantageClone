Namespace Database.Entities

	<Table("CR_CLIENT")>
	Public Class ClientCashReceipt
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			SequenceNumber
			Status
			ClientCode
			BankCode
			CheckNumber
			CheckDate
			CheckAmount
			DepositDate
			PostPeriodCode
			GLACode
			GLTransaction
			GLSequenceNumber
			IsCleared
			OfficeCode
			ReconcileStatementDate
			IsReconciled
			BatchName
			CashReceiptPaymentTypeID
			Bank
			Client
			ClientCashReceiptDetails
			GeneralLedgerAccount
			PostPeriod
			ClientCashReceiptOnAccounts

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("REC_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SequenceNumber() As Short
		<MaxLength(1)>
		<Column("STATUS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Status() As String
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(4)>
		<Column("BK_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property BankCode() As String
		<Required>
		<MaxLength(15)>
		<Column("CR_CHECK_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CheckNumber() As String
		<Required>
		<Column("CR_CHECK_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CheckDate() As Date
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<Column("CR_CHECK_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
		Public Property CheckAmount() As Decimal
		<Column("CR_DEP_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property DepositDate() As Nullable(Of Date)
		<Required>
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<Required>
		<MaxLength(30)>
		<Column("GLACODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property GLACode() As String
		<Required>
		<Column("GLEXACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Integer
		<Required>
		<Column("GLESEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumber() As Short
		<Column("CLEARED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsCleared() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<Column("REC_STMT_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReconcileStatementDate() As Nullable(Of Date)
		<Column("RECON_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsReconciled() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BatchName() As String
		<Column("CR_PAYMENT_TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CashReceiptPaymentTypeID() As Nullable(Of Integer)

        Public Overridable Property Bank As Database.Entities.Bank
        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property ClientCashReceiptDetails As ICollection(Of Database.Entities.ClientCashReceiptDetail)
        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property PostPeriod As Database.Entities.PostPeriod
        Public Overridable Property ClientCashReceiptOnAccounts As ICollection(Of Database.Entities.ClientCashReceiptOnAccount)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.ClientCashReceipt

            Dim EntityCopy As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.ClientCashReceipt

            With EntityCopy
                .ID = Me.ID
                .SequenceNumber = Me.SequenceNumber
                .Status = Me.Status
                .ClientCode = Me.ClientCode
                .BankCode = Me.BankCode
                .CheckNumber = Me.CheckNumber
                .CheckDate = Me.CheckDate
                .CheckAmount = Me.CheckAmount
                .DepositDate = Me.DepositDate
                .PostPeriodCode = Me.PostPeriodCode
                .GLACode = Me.GLACode
                .GLTransaction = Me.GLTransaction
                .GLSequenceNumber = Me.GLSequenceNumber
                .IsCleared = Me.IsCleared
                .OfficeCode = Me.OfficeCode
                .ReconcileStatementDate = Me.ReconcileStatementDate
                .IsReconciled = Me.IsReconciled
            End With

            Copy = EntityCopy

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.CheckNumber.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ClientCashReceipts
                            Where Entity.CheckNumber.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                  Entity.ClientCode = Me.ClientCode AndAlso
                                  Entity.Status Is Nothing
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Check number exists for client."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
