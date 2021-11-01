Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.BILLING")>
    Public Class Billing
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillingUserCode
            Selection
            ApprovalOL
            ApprovalPrint
            Adjustments
            InvoiceAssigned
            InvoicePrinted
            InvoiceDate
            PostPeriodCode
            ProductionSelectBy
            IsMedia
            IsProduction
            ServiceFees
            FirstInvoice
            LastInvoice
            EmployeeTimeCutoffDate
            ProductionPostPeriodCodeCutoff
            MediaSelectBy
            MediaEndDate
            IsNewspaper
            IsMagazine
            IsRadio
            IsTelevision
            IsOutOfHome
            MediaBroadcastStartDate
            MediaBroadcastEndDate
            IncomeOnlyCutoffDate
            AdvancedBillingCutoffDate
            IsInternet
            IncludeNoDetail
            AdvanceBillJobsOnly
            BCCFlag
            MediaStartDate
            MediaDateToUseFlag
        End Enum

#End Region

#Region " Variables "

        Private _BillingUserCode As String = ""
        Private _Selection As System.Nullable(Of Long) = 0
        Private _ApprovalOL As System.Nullable(Of Long) = 0
        Private _ApprovalPrint As System.Nullable(Of Long) = 0
        Private _Adjustments As System.Nullable(Of Long) = 0
        Private _InvoiceAssigned As System.Nullable(Of Long) = 0
        Private _InvoicePrinted As System.Nullable(Of Long) = 0
        Private _InvoiceDate As System.Nullable(Of DateTime) = Nothing
        Private _PostPeriodCode As String = ""
        Private _ProductionSelectBy As System.Nullable(Of Long) = 0
        Private _IsMedia As System.Nullable(Of Long) = 0
        Private _IsProduction As System.Nullable(Of Long) = 0
        Private _ServiceFees As System.Nullable(Of Long) = 0
        Private _FirstInvoice As System.Nullable(Of Long) = 0
        Private _LastInvoice As System.Nullable(Of Long) = 0
        Private _EmployeeTimeCutoffDate As System.Nullable(Of DateTime) = Nothing
        Private _ProductionPostPeriodCodeCutoff As String = ""
        Private _MediaSelectBy As System.Nullable(Of Long) = 0
        Private _MediaEndDate As System.Nullable(Of DateTime) = Nothing
        Private _IsNewspaper As System.Nullable(Of Long) = 0
        Private _IsMagazine As System.Nullable(Of Long) = 0
        Private _IsRadio As System.Nullable(Of Long) = 0
        Private _IsTelevision As System.Nullable(Of Long) = 0
        Private _IsOutOfHome As System.Nullable(Of Long) = 0
        Private _MediaBroadcastStartDate As System.Nullable(Of DateTime) = Nothing
        Private _MediaBroadcastEndDate As System.Nullable(Of DateTime) = Nothing
        Private _IncomeOnlyCutoffDate As System.Nullable(Of DateTime) = Nothing
        Private _AdvancedBillingCutoffDate As System.Nullable(Of DateTime) = Nothing
        Private _IsInternet As System.Nullable(Of Long) = 0
        Private _IncludeNoDetail As System.Nullable(Of Long) = 0
        Private _AdvanceBillJobsOnly As System.Nullable(Of Long) = 0
        Private _BCCFlag As System.Nullable(Of Long) = 0
        Private _MediaStartDate As System.Nullable(Of DateTime) = Nothing
        Private _MediaDateToUseFlag As System.Nullable(Of Long) = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BILLING_USER", Storage:="_BillingUserCode", DbType:="varchar", IsPrimaryKey:=True),
        System.ComponentModel.DisplayName("BillingUserCode"),
        System.ComponentModel.DataAnnotations.MaxLength(100)>
        Public Property BillingUserCode() As String
			Get
				BillingUserCode = _BillingUserCode
			End Get
			Set(ByVal value As String)
				_BillingUserCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SELECTION", Storage:="_Selection", DbType:="smallint"),
		System.ComponentModel.DisplayName("Selection")>
		Public Property Selection() As System.Nullable(Of Long)
			Get
				Selection = _Selection
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Selection = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="APPROVAL_OL", Storage:="_ApprovalOL", DbType:="smallint"),
		System.ComponentModel.DisplayName("ApprovalOL")>
		Public Property ApprovalOL() As System.Nullable(Of Long)
			Get
				ApprovalOL = _ApprovalOL
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ApprovalOL = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="APPROVAL_PRN", Storage:="_ApprovalPrint", DbType:="smallint"),
		System.ComponentModel.DisplayName("ApprovalPrint")>
		Public Property ApprovalPrint() As System.Nullable(Of Long)
			Get
				ApprovalPrint = _ApprovalPrint
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ApprovalPrint = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADJUSTMENTS", Storage:="_Adjustments", DbType:="smallint"),
		System.ComponentModel.DisplayName("Adjustments")>
		Public Property Adjustments() As System.Nullable(Of Long)
			Get
				Adjustments = _Adjustments
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_Adjustments = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INV_ASSIGN", Storage:="_InvoiceAssigned", DbType:="smallint"),
		System.ComponentModel.DisplayName("InvoiceAssigned")>
		Public Property InvoiceAssigned() As System.Nullable(Of Long)
			Get
				InvoiceAssigned = _InvoiceAssigned
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_InvoiceAssigned = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INV_PRINT", Storage:="_InvoicePrinted", DbType:="smallint"),
		System.ComponentModel.DisplayName("InvoicePrinted")>
		Public Property InvoicePrinted() As System.Nullable(Of Long)
			Get
				InvoicePrinted = _InvoicePrinted
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_InvoicePrinted = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INV_DATE", Storage:="_InvoiceDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("InvoiceDate")>
		Public Property InvoiceDate() As System.Nullable(Of DateTime)
			Get
				InvoiceDate = _InvoiceDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_InvoiceDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="POST_PERIOD", Storage:="_PostPeriodCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("PostPeriodCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property PostPeriodCode() As String
			Get
				PostPeriodCode = _PostPeriodCode
			End Get
			Set(ByVal value As String)
				_PostPeriodCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SELECT_BY", Storage:="_ProductionSelectBy", DbType:="smallint"),
		System.ComponentModel.DisplayName("ProductionSelectBy")>
		Public Property ProductionSelectBy() As System.Nullable(Of Long)
			Get
				ProductionSelectBy = _ProductionSelectBy
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ProductionSelectBy = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA", Storage:="_IsMedia", DbType:="smallint"),
		System.ComponentModel.DisplayName("IsMedia")>
		Public Property IsMedia() As System.Nullable(Of Long)
			Get
				IsMedia = _IsMedia
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_IsMedia = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRODUCTION", Storage:="_IsProduction", DbType:="smallint"),
		System.ComponentModel.DisplayName("IsProduction")>
		Public Property IsProduction() As System.Nullable(Of Long)
			Get
				IsProduction = _IsProduction
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_IsProduction = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SERVICE_FEES", Storage:="_ServiceFees", DbType:="smallint"),
		System.ComponentModel.DisplayName("ServiceFees")>
		Public Property ServiceFees() As System.Nullable(Of Long)
			Get
				ServiceFees = _ServiceFees
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ServiceFees = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FIRST_INV", Storage:="_FirstInvoice", DbType:="int"),
		System.ComponentModel.DisplayName("FirstInvoice")>
		Public Property FirstInvoice() As System.Nullable(Of Long)
			Get
				FirstInvoice = _FirstInvoice
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_FirstInvoice = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LAST_INV", Storage:="_LastInvoice", DbType:="int"),
		System.ComponentModel.DisplayName("LastInvoice")>
		Public Property LastInvoice() As System.Nullable(Of Long)
			Get
				LastInvoice = _LastInvoice
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_LastInvoice = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="P_EMPTIME_DATE", Storage:="_EmployeeTimeCutoffDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("EmployeeTimeCutoffDate")>
		Public Property EmployeeTimeCutoffDate() As System.Nullable(Of DateTime)
			Get
				EmployeeTimeCutoffDate = _EmployeeTimeCutoffDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_EmployeeTimeCutoffDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="P_CUTOFF_PP", Storage:="_ProductionPostPeriodCodeCutoff", DbType:="varchar"),
		System.ComponentModel.DisplayName("ProductionPostPeriodCodeCutoff"),
		System.ComponentModel.DataAnnotations.MaxLength(8)>
		Public Property ProductionPostPeriodCodeCutoff() As String
            Get
                ProductionPostPeriodCodeCutoff = _ProductionPostPeriodCodeCutoff
            End Get
            Set(ByVal value As String)
                _ProductionPostPeriodCodeCutoff = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="M_SELECT_BY", Storage:="_MediaSelectBy", DbType:="smallint"),
        System.ComponentModel.DisplayName("MediaSelectBy")>
        Public Property MediaSelectBy() As System.Nullable(Of Long)
            Get
                MediaSelectBy = _MediaSelectBy
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _MediaSelectBy = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="M_CUTOFF_DATE", Storage:="_MediaEndDate", DbType:="smalldatetime"),
        System.ComponentModel.DisplayName("MediaEndDate")>
        Public Property MediaEndDate() As System.Nullable(Of DateTime)
            Get
                MediaEndDate = _MediaEndDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _MediaEndDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NEWSPAPER", Storage:="_IsNewspaper", DbType:="smallint"),
        System.ComponentModel.DisplayName("IsNewspaper")>
        Public Property IsNewspaper() As System.Nullable(Of Long)
            Get
                IsNewspaper = _IsNewspaper
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsNewspaper = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MAGAZINE", Storage:="_IsMagazine", DbType:="smallint"),
        System.ComponentModel.DisplayName("IsMagazine")>
        Public Property IsMagazine() As System.Nullable(Of Long)
            Get
                IsMagazine = _IsMagazine
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsMagazine = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RADIO", Storage:="_IsRadio", DbType:="smallint"),
        System.ComponentModel.DisplayName("IsRadio")>
        Public Property IsRadio() As System.Nullable(Of Long)
            Get
                IsRadio = _IsRadio
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsRadio = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TELEVISION", Storage:="_IsTelevision", DbType:="smallint"),
        System.ComponentModel.DisplayName("IsTelevision")>
        Public Property IsTelevision() As System.Nullable(Of Long)
            Get
                IsTelevision = _IsTelevision
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsTelevision = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OUTDOOR", Storage:="_IsOutOfHome", DbType:="smallint"),
        System.ComponentModel.DisplayName("IsOutOfHome")>
        Public Property IsOutOfHome() As System.Nullable(Of Long)
            Get
                IsOutOfHome = _IsOutOfHome
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsOutOfHome = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="M_CUTOFF_MONTH1", Storage:="_MediaBroadcastStartDate", DbType:="smalldatetime"),
        System.ComponentModel.DisplayName("MediaBroadcastStartDate")>
        Public Property MediaBroadcastStartDate() As System.Nullable(Of DateTime)
            Get
                MediaBroadcastStartDate = _MediaBroadcastStartDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _MediaBroadcastStartDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="M_CUTOFF_MONTH2", Storage:="_MediaBroadcastEndDate", DbType:="smalldatetime"),
        System.ComponentModel.DisplayName("MediaBroadcastEndDate")>
        Public Property MediaBroadcastEndDate() As System.Nullable(Of DateTime)
            Get
                MediaBroadcastEndDate = _MediaBroadcastEndDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _MediaBroadcastEndDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="P_INCOMEONLY_DATE", Storage:="_IncomeOnlyCutoffDate", DbType:="smalldatetime"),
        System.ComponentModel.DisplayName("IncomeOnlyCutoffDate")>
        Public Property IncomeOnlyCutoffDate() As System.Nullable(Of DateTime)
            Get
                IncomeOnlyCutoffDate = _IncomeOnlyCutoffDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _IncomeOnlyCutoffDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="P_ADVBILL_DATE", Storage:="_AdvancedBillingCutoffDate", DbType:="smalldatetime"),
        System.ComponentModel.DisplayName("AdvancedBillingCutoffDate")>
        Public Property AdvancedBillingCutoffDate() As System.Nullable(Of DateTime)
            Get
                AdvancedBillingCutoffDate = _AdvancedBillingCutoffDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _AdvancedBillingCutoffDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INTERNET", Storage:="_IsInternet", DbType:="smallint"),
        System.ComponentModel.DisplayName("IsInternet")>
        Public Property IsInternet() As System.Nullable(Of Long)
            Get
                IsInternet = _IsInternet
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsInternet = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INC_NO_DTL", Storage:="_IncludeNoDetail", DbType:="bit"),
        System.ComponentModel.DisplayName("IncludeNoDetail")>
        Public Property IncludeNoDetail() As System.Nullable(Of Long)
            Get
                IncludeNoDetail = _IncludeNoDetail
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IncludeNoDetail = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AB_JOBS_ONLY", Storage:="_AdvanceBillJobsOnly", DbType:="bit"),
        System.ComponentModel.DisplayName("AdvanceBillJobsOnly")>
        Public Property AdvanceBillJobsOnly() As System.Nullable(Of Long)
            Get
                AdvanceBillJobsOnly = _AdvanceBillJobsOnly
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _AdvanceBillJobsOnly = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BCC_FLAG", Storage:="_BCCFlag", DbType:="smallint"),
        System.ComponentModel.DisplayName("BCCFlag")>
        Public Property BCCFlag() As System.Nullable(Of Long)
            Get
                BCCFlag = _BCCFlag
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _BCCFlag = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="M_START_DATE", Storage:="_MediaStartDate", DbType:="smalldatetime"),
        System.ComponentModel.DisplayName("MediaStartDate")>
        Public Property MediaStartDate() As System.Nullable(Of DateTime)
            Get
                MediaStartDate = _MediaStartDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _MediaStartDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE_TO_USE", Storage:="_MediaDateToUseFlag", DbType:="smallint"),
        System.ComponentModel.DisplayName("MediaDateToUseFlag")>
        Public Property MediaDateToUseFlag() As System.Nullable(Of Long)
            Get
                MediaDateToUseFlag = _MediaDateToUseFlag
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _MediaDateToUseFlag = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
