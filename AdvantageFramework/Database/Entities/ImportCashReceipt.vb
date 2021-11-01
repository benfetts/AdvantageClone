Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.IMP_CR_HEADER")>
    Public Class ImportCashReceipt
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            IsOnHold
            ImportTemplateID
            CheckNumber
            CheckDate
            CheckAmount
            DepositDate
            IsCleared
            PaymentTypeDescription
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _BatchName As String = Nothing
        Private _IsOnHold As Short = 0
        Private _ImportTemplateID As Short = 0
        Private _CheckNumber As String = Nothing
        Private _CheckDate As System.Nullable(Of DateTime) = Nothing
        Private _CheckAmount As System.Nullable(Of Decimal) = Nothing
        Private _DepositDate As System.Nullable(Of DateTime) = Nothing
        Private _IsCleared As Nullable(Of Short) = 0
        Private _PaymentTypeDescription As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BATCH_NAME", Storage:="_BatchName", DbType:="varchar"),
		System.ComponentModel.DisplayName("BatchName"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property BatchName() As String
			Get
				BatchName = _BatchName
			End Get
			Set(ByVal value As String)
				_BatchName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ON_HOLD", Storage:="_IsOnHold", DbType:="smallint"),
		System.ComponentModel.DisplayName("IsOnHold")>
		Public Property IsOnHold() As Short
			Get
				IsOnHold = _IsOnHold
			End Get
			Set(ByVal value As Short)
				_IsOnHold = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TEMPLATE_ID", Storage:="_ImportTemplateID", DbType:="smallint"),
		System.ComponentModel.DisplayName("ImportTemplateID")>
		Public Property ImportTemplateID() As Short
			Get
				ImportTemplateID = _ImportTemplateID
			End Get
			Set(ByVal value As Short)
				_ImportTemplateID = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CHECK_NBR", Storage:="_CheckNumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("CheckNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(15)>
		Public Property CheckNumber() As String
			Get
				CheckNumber = _CheckNumber
			End Get
			Set(ByVal value As String)
				_CheckNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CHECK_DATE", Storage:="_CheckDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("CheckDate")>
		Public Property CheckDate() As System.Nullable(Of DateTime)
			Get
				CheckDate = _CheckDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_CheckDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CHECK_AMT", Storage:="_CheckAmount", DbType:="decimal"),
		System.ComponentModel.DisplayName("CheckAmount")>
		Public Property CheckAmount() As System.Nullable(Of Decimal)
			Get
				CheckAmount = _CheckAmount
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_CheckAmount = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DEPOSIT_DATE", Storage:="_DepositDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("DepositDate")>
		Public Property DepositDate() As System.Nullable(Of DateTime)
			Get
				DepositDate = _DepositDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_DepositDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CLEARED", Storage:="_IsCleared", DbType:="smallint"),
		System.ComponentModel.DisplayName("IsCleared")>
		Public Property IsCleared() As System.Nullable(Of Short)
			Get
				IsCleared = _IsCleared
			End Get
			Set(ByVal value As System.Nullable(Of Short))
				_IsCleared = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PAYMENT_TYPE_DESCRIPTION", Storage:="_PaymentTypeDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("CheckNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property PaymentTypeDescription() As String
            Get
                PaymentTypeDescription = _PaymentTypeDescription
            End Get
            Set(ByVal value As String)
                _PaymentTypeDescription = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
