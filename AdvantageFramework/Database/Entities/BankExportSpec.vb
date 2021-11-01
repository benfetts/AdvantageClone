Namespace Database.Entities

	<Table("BANK_EXP_SPEC")>
	Public Class BankExportSpec
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			BankCode
			BankID
			ExportType
			BankIDFlag
			AccountNumberFlagDetail
			CheckNumberFlagDetail
			CheckDateTimeFlagDetail
			CheckVoidFlagDetail
			CheckAmountFlagDetail
			CheckPayeeFlagDetail
			BankIDCSVOrderDetail
			AccountNumberCSVOrderDetail
			CheckNumberCSVOrderDetail
			CheckDateTimeCSVOrderDetail
			CheckVoidCSVOrderDetail
			CheckAmountCSVOrderDetail
			CheckPayeeCSVOrderDetail
			BankIDBeginPositionDetail
			BankIDEndPositionDetail
			AccountNumberBeginPositionDetail
			AccountNumberEndPositionDetail
			CheckNumberBeginPositionDetail
			CheckNumberEndPositionDetail
			CheckDateTimeBeginPositionDetail
			CheckDateTimeEndPositionDetail
			CheckVoidBeginPositionDetail
			CheckVoidEndPositionDetail
			CheckAmountBeginPositionDetail
			CheckAmountEndPositionDetail
			CheckPayeeBeginPositionDetail
			CheckPayeeEndPositionDetail
			Filler1FlagDetail
			Filler1BeginPositionDetail
			Filler1EndPositionDetail
			Filler2FlagDetail
			Filler2BeginPositionDetail
			Filler2EndPositionDetail
			Filler3FlagDetail
			Filler3BeginPositionDetail
			Filler3EndPositionDetail
			Filler4FlagDetail
			Filler4BeginPositionDetail
			Filler4EndPositionDetail
			BankIDFlagTotal
			AccountNumberFlagTotal
			CheckNumberFlagTotal
			CheckDateTimeFlagTotal
			CheckVoidFlagTotal
			CheckAmountFlagTotal
			CheckPayeeFlagTotal
			BankIDCSVOrderTotal
			AccountNumberCSVOrderTotal
			CheckNumberCSVOrderTotal
			CheckDateTimeCSVOrderTotal
			CheckVoidCSVOrderTotal
			CheckAmountCSVOrderTotal
			CheckPayeeCSVOrderTotal
			BankIDBeginPositionTotal
			BankIDEndPositionTotal
			AccountNumberBeginPositionTotal
			AccountNumberEndPositionTotal
			CheckNumberBeginPositionTotal
			CheckNumberEndPositionTotal
			CheckDateTimeBeginPositionTotal
			CheckDateTimeEndPositionTotal
			CheckVoidBeginPositionTotal
			CheckVoidEndPositionTotal
			CheckAmountBeginPositionTotal
			CheckAmountEndPositionTotal
			CheckPayeeBeginPositionTotal
			CheckPayeeEndPositionTotal
			Filler1FlagTotal
			Filler1BeginPositionTotal
			Filler1EndPositionTotal
			Filler2FlagTotal
			Filler2BeginPositionTotal
			Filler2EndPositionTotal
			Filler3FlagTotal
			Filler3BeginPositionTotal
			Filler3EndPositionTotal
			Filler4FlagTotal
			Filler4BeginPositionTotal
			Filler4EndPositionTotal
			Filler1ValueDetail
			Filler2ValueDetail
			LastCheckNumber
			UseHeader
			Filler1FlagHeader
			Filler1BeginPositionHeader
			Filler1EndPositionHeader
			Filler1ValueHeader
			Filler2FlagHeader
			Filler2BeginPositionHeader
			Filler2EndPositionHeader
			Filler2ValueHeader
			AgencyFlagHeader
			AgencyCSVOrderHeader
			AgencyBeginPositionHeader
			AgencyEndPositionHeader
			CreateDateFlagHeader
			CreateDateCSVOrderHeader
			CreateDateBeginPositionHeader
			CreateDateEndPositionHeader
			RecordCountFlagTotal
			RecordCountCSVOrderTotal
			RecordCountBeginPositionTotal
			RecordCountEndPositionTotal
			Filler1ValueTotal
			Filler2ValueTotal
			UseTrailer
			BankIDFlagTrailer
			BankIDCSVOrderTrailer
			BankIDBeginPositionTrailer
			BankIDEndPositionTrailer
			AccountNumberFlagTrailer
			AccountNumberCSVOrderTrailer
			AccountNumberBeginPositionTrailer
			AccountNumberEndPositionTrailer
			CheckDateTimeFlagTrailer
			CheckDateTimeCSVOrderTrailer
			CheckDateTimeBeginPositionTrailer
			CheckDateTimeEndPositionTrailer
			CheckAmountFlagTrailer
			CheckAmountCSVOrderTrailer
			CheckAmountBeginPositionTrailer
			CheckAmountEndPositionTrailer
			CheckVoidFlagTrailer
			CheckVoidCSVOrderTrailer
			CheckVoidBeginPositionTrailer
			CheckVoidEndPositionTrailer
			Filler1FlagTrailer
			Filler1BeginPositionTrailer
			Filler1EndPositionTrailer
			Filler2FlagTrailer
			Filler2BeginPositionTrailer
			Filler2EndPositionTrailer
			Filler3FlagTrailer
			Filler3BeginPositionTrailer
			Filler3EndPositionTrailer
			Filler4FlagTrailer
			Filler4BeginPositionTrailer
			Filler4EndPositionTrailer
			Filler1ValueTrailer
			Filler2ValueTrailer
			RecordCountFlagTrailer
			RecordCountCSVOrderTrailer
			RecordCountBeginPositionTrailer
			RecordCountEndPositionTrailer
			Bank

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(4)>
        <Column("BK_CODE", TypeName:="varchar")>
        <ForeignKey("Bank")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BankCode() As String
		<MaxLength(20)>
		<Column("BANK_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BankID() As String
		<MaxLength(15)>
		<Column("EXPORT_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExportType() As String
		<Column("BANK_ID_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BankIDFlag() As Nullable(Of Short)
		<Column("ACCT_NBR_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountNumberFlagDetail() As Nullable(Of Short)
		<Column("CHECK_NBR_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckNumberFlagDetail() As Nullable(Of Short)
		<Column("CHECK_DT_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckDateTimeFlagDetail() As Nullable(Of Short)
		<Column("CHECK_VOID_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckVoidFlagDetail() As Nullable(Of Short)
		<Column("CHECK_AMT_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckAmountFlagDetail() As Nullable(Of Short)
		<Column("CHECK_PAYEE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckPayeeFlagDetail() As Nullable(Of Short)
		<Column("BANK_ID_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property BankIDCSVOrderDetail() As Nullable(Of Short)
		<Column("ACCT_NBR_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AccountNumberCSVOrderDetail() As Nullable(Of Short)
		<Column("CHECK_NBR_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckNumberCSVOrderDetail() As Nullable(Of Short)
		<Column("CHECK_DT_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckDateTimeCSVOrderDetail() As Nullable(Of Short)
		<Column("CHECK_VOID_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckVoidCSVOrderDetail() As Nullable(Of Short)
		<Column("CHECK_AMT_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountCSVOrderDetail() As Nullable(Of Short)
		<Column("CHECK_PAYEE_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckPayeeCSVOrderDetail() As Nullable(Of Short)
		<Column("BANK_ID_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property BankIDBeginPositionDetail() As Nullable(Of Short)
		<Column("BANK_ID_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property BankIDEndPositionDetail() As Nullable(Of Short)
		<Column("ACCT_NBR_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AccountNumberBeginPositionDetail() As Nullable(Of Short)
		<Column("ACCT_NBR_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AccountNumberEndPositionDetail() As Nullable(Of Short)
		<Column("CHECK_NBR_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckNumberBeginPositionDetail() As Nullable(Of Short)
		<Column("CHECK_NBR_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckNumberEndPositionDetail() As Nullable(Of Short)
		<Column("CHECK_DT_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckDateTimeBeginPositionDetail() As Nullable(Of Short)
		<Column("CHECK_DT_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckDateTimeEndPositionDetail() As Nullable(Of Short)
		<Column("CHECK_VOID_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckVoidBeginPositionDetail() As Nullable(Of Short)
		<Column("CHECK_VOID_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckVoidEndPositionDetail() As Nullable(Of Short)
		<Column("CHECK_AMT_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountBeginPositionDetail() As Nullable(Of Short)
		<Column("CHECK_AMT_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountEndPositionDetail() As Nullable(Of Short)
		<Column("CHECK_PAYEE_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckPayeeBeginPositionDetail() As Nullable(Of Short)
		<Column("CHECK_PAYEE_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckPayeeEndPositionDetail() As Nullable(Of Short)
		<Column("FILLER1_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler1FlagDetail() As Nullable(Of Short)
		<Column("FILLER1_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler1BeginPositionDetail() As Nullable(Of Short)
		<Column("FILLER1_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler1EndPositionDetail() As Nullable(Of Short)
		<Column("FILLER2_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler2FlagDetail() As Nullable(Of Short)
		<Column("FILLER2_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler2BeginPositionDetail() As Nullable(Of Short)
		<Column("FILLER2_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler2EndPositionDetail() As Nullable(Of Short)
		<Column("FILLER3_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler3FlagDetail() As Nullable(Of Short)
		<Column("FILLER3_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler3BeginPositionDetail() As Nullable(Of Short)
		<Column("FILLER3_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler3EndPositionDetail() As Nullable(Of Short)
		<Column("FILLER4_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler4FlagDetail() As Nullable(Of Short)
		<Column("FILLER4_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler4BeginPositionDetail() As Nullable(Of Short)
		<Column("FILLER4_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler4EndPositionDetail() As Nullable(Of Short)
		<Column("BANK_ID_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BankIDFlagTotal() As Nullable(Of Short)
		<Column("ACCT_NBR_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountNumberFlagTotal() As Nullable(Of Short)
		<Column("CHECK_NBR_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckNumberFlagTotal() As Nullable(Of Short)
		<Column("CHECK_DT_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckDateTimeFlagTotal() As Nullable(Of Short)
		<Column("CHECK_VOID_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckVoidFlagTotal() As Nullable(Of Short)
		<Column("CHECK_AMT_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckAmountFlagTotal() As Nullable(Of Short)
		<Column("CHECK_PAYEE_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckPayeeFlagTotal() As Nullable(Of Short)
		<Column("BANK_ID_ORD2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property BankIDCSVOrderTotal() As Nullable(Of Short)
		<Column("ACCT_NBR_ORD2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AccountNumberCSVOrderTotal() As Nullable(Of Short)
		<Column("CHECK_NBR_ORD2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckNumberCSVOrderTotal() As Nullable(Of Short)
		<Column("CHECK_DT_ORD2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckDateTimeCSVOrderTotal() As Nullable(Of Short)
		<Column("CHECK_VOID_ORD2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckVoidCSVOrderTotal() As Nullable(Of Short)
		<Column("CHECK_AMT_ORD2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountCSVOrderTotal() As Nullable(Of Short)
		<Column("CHECK_PAYEE_ORD2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckPayeeCSVOrderTotal() As Nullable(Of Short)
		<Column("BANK_ID_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property BankIDBeginPositionTotal() As Nullable(Of Short)
		<Column("BANK_ID_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property BankIDEndPositionTotal() As Nullable(Of Short)
		<Column("ACCT_NBR_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AccountNumberBeginPositionTotal() As Nullable(Of Short)
		<Column("ACCT_NBR_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AccountNumberEndPositionTotal() As Nullable(Of Short)
		<Column("CHECK_NBR_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckNumberBeginPositionTotal() As Nullable(Of Short)
		<Column("CHECK_NBR_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckNumberEndPositionTotal() As Nullable(Of Short)
		<Column("CHECK_DT_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckDateTimeBeginPositionTotal() As Nullable(Of Short)
		<Column("CHECK_DT_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckDateTimeEndPositionTotal() As Nullable(Of Short)
		<Column("CHECK_VOID_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckVoidBeginPositionTotal() As Nullable(Of Short)
		<Column("CHECK_VOID_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckVoidEndPositionTotal() As Nullable(Of Short)
		<Column("CHECK_AMT_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountBeginPositionTotal() As Nullable(Of Short)
		<Column("CHECK_AMT_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountEndPositionTotal() As Nullable(Of Short)
		<Column("CHECK_PAYEE_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckPayeeBeginPositionTotal() As Nullable(Of Short)
		<Column("CHECK_PAYEE_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckPayeeEndPositionTotal() As Nullable(Of Short)
		<Column("FILLER1_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler1FlagTotal() As Nullable(Of Short)
		<Column("FILLER1_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler1BeginPositionTotal() As Nullable(Of Short)
		<Column("FILLER1_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler1EndPositionTotal() As Nullable(Of Short)
		<Column("FILLER2_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler2FlagTotal() As Nullable(Of Short)
		<Column("FILLER2_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler2BeginPositionTotal() As Nullable(Of Short)
		<Column("FILLER2_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler2EndPositionTotal() As Nullable(Of Short)
		<Column("FILLER3_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler3FlagTotal() As Nullable(Of Short)
		<Column("FILLER3_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler3BeginPositionTotal() As Nullable(Of Short)
		<Column("FILLER3_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler3EndPositionTotal() As Nullable(Of Short)
		<Column("FILLER4_FLAG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler4FlagTotal() As Nullable(Of Short)
		<Column("FILLER4_BEG2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler4BeginPositionTotal() As Nullable(Of Short)
		<Column("FILLER4_END2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler4EndPositionTotal() As Nullable(Of Short)
		<MaxLength(254)>
		<Column("FILLER1_VALUE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d1")>
		Public Property Filler1ValueDetail() As String
		<MaxLength(254)>
		<Column("FILLER2_VALUE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d1")>
		Public Property Filler2ValueDetail() As String
		<Column("LAST_CHK_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastCheckNumber() As Nullable(Of Integer)
		<Column("USE_HEADER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseHeader() As Nullable(Of Short)
		<Column("FILLER1_FLAG1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler1FlagHeader() As Nullable(Of Short)
		<Column("FILLER1_BEG1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler1BeginPositionHeader() As Nullable(Of Short)
		<Column("FILLER1_END1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler1EndPositionHeader() As Nullable(Of Short)
		<MaxLength(254)>
		<Column("FILLER1_VALUE1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d1")>
		Public Property Filler1ValueHeader() As String
		<Column("FILLER2_FLAG1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler2FlagHeader() As Nullable(Of Short)
		<Column("FILLER2_BEG1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler2BeginPositionHeader() As Nullable(Of Short)
		<Column("FILLER2_END1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler2EndPositionHeader() As Nullable(Of Short)
		<MaxLength(254)>
		<Column("FILLER2_VALUE1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d2")>
		Public Property Filler2ValueHeader() As String
		<Column("AGENCY_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AgencyFlagHeader() As Nullable(Of Short)
		<Column("AGENCY_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AgencyCSVOrderHeader() As Nullable(Of Short)
		<Column("AGENCY_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AgencyBeginPositionHeader() As Nullable(Of Short)
		<Column("AGENCY_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AgencyEndPositionHeader() As Nullable(Of Short)
		<Column("CREATE_DATE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreateDateFlagHeader() As Nullable(Of Short)
		<Column("CREATE_DATE_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CreateDateCSVOrderHeader() As Nullable(Of Short)
		<Column("CREATE_DATE_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CreateDateBeginPositionHeader() As Nullable(Of Short)
		<Column("CREATE_DATE_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CreateDateEndPositionHeader() As Nullable(Of Short)
		<Column("RECORD_COUNT_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RecordCountFlagTotal() As Nullable(Of Short)
		<Column("RECORD_COUNT_ORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property RecordCountCSVOrderTotal() As Nullable(Of Short)
		<Column("RECORD_COUNT_BEG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property RecordCountBeginPositionTotal() As Nullable(Of Short)
		<Column("RECORD_COUNT_END")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property RecordCountEndPositionTotal() As Nullable(Of Short)
		<MaxLength(254)>
		<Column("FILLER1_VALUE2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d1")>
		Public Property Filler1ValueTotal() As String
		<MaxLength(254)>
		<Column("FILLER2_VALUE2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d1")>
		Public Property Filler2ValueTotal() As String
		<Column("USE_TRAILER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseTrailer() As Nullable(Of Short)
		<Column("BANK_ID_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BankIDFlagTrailer() As Nullable(Of Short)
		<Column("BANK_ID_ORD3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property BankIDCSVOrderTrailer() As Nullable(Of Short)
		<Column("BANK_ID_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property BankIDBeginPositionTrailer() As Nullable(Of Short)
		<Column("BANK_ID_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property BankIDEndPositionTrailer() As Nullable(Of Short)
		<Column("ACCT_NBR_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountNumberFlagTrailer() As Nullable(Of Short)
		<Column("ACCT_NBR_ORD3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AccountNumberCSVOrderTrailer() As Nullable(Of Short)
		<Column("ACCT_NBR_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AccountNumberBeginPositionTrailer() As Nullable(Of Short)
		<Column("ACCT_NBR_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property AccountNumberEndPositionTrailer() As Nullable(Of Short)
		<Column("CHECK_DT_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckDateTimeFlagTrailer() As Nullable(Of Short)
		<Column("CHECK_DT_ORD3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckDateTimeCSVOrderTrailer() As Nullable(Of Short)
		<Column("CHECK_DT_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckDateTimeBeginPositionTrailer() As Nullable(Of Short)
		<Column("CHECK_DT_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckDateTimeEndPositionTrailer() As Nullable(Of Short)
		<Column("CHECK_AMT_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckAmountFlagTrailer() As Nullable(Of Short)
		<Column("CHECK_AMT_ORD3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountCSVOrderTrailer() As Nullable(Of Short)
		<Column("CHECK_AMT_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountBeginPositionTrailer() As Nullable(Of Short)
		<Column("CHECK_AMT_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountEndPositionTrailer() As Nullable(Of Short)
		<Column("CHECK_VOID_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckVoidFlagTrailer() As Nullable(Of Short)
		<Column("CHECK_VOID_ORD3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckVoidCSVOrderTrailer() As Nullable(Of Short)
		<Column("CHECK_VOID_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckVoidBeginPositionTrailer() As Nullable(Of Short)
		<Column("CHECK_VOID_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckVoidEndPositionTrailer() As Nullable(Of Short)
		<Column("FILLER1_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler1FlagTrailer() As Nullable(Of Short)
		<Column("FILLER1_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler1BeginPositionTrailer() As Nullable(Of Short)
		<Column("FILLER1_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler1EndPositionTrailer() As Nullable(Of Short)
		<Column("FILLER2_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler2FlagTrailer() As Nullable(Of Short)
		<Column("FILLER2_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler2BeginPositionTrailer() As Nullable(Of Short)
		<Column("FILLER2_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler2EndPositionTrailer() As Nullable(Of Short)
		<Column("FILLER3_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler3FlagTrailer() As Nullable(Of Short)
		<Column("FILLER3_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler3BeginPositionTrailer() As Nullable(Of Short)
		<Column("FILLER3_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler3EndPositionTrailer() As Nullable(Of Short)
		<Column("FILLER4_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Filler4FlagTrailer() As Nullable(Of Short)
		<Column("FILLER4_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler4BeginPositionTrailer() As Nullable(Of Short)
		<Column("FILLER4_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property Filler4EndPositionTrailer() As Nullable(Of Short)
		<MaxLength(254)>
		<Column("FILLER1_VALUE3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d1")>
		Public Property Filler1ValueTrailer() As String
		<MaxLength(254)>
		<Column("FILLER2_VALUE3", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d1")>
		Public Property Filler2ValueTrailer() As String
		<Column("RECORD_COUNT_FLAG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RecordCountFlagTrailer() As Nullable(Of Short)
		<Column("RECORD_COUNT_ORD3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property RecordCountCSVOrderTrailer() As Nullable(Of Short)
		<Column("RECORD_COUNT_BEG3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property RecordCountBeginPositionTrailer() As Nullable(Of Short)
		<Column("RECORD_COUNT_END3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property RecordCountEndPositionTrailer() As Nullable(Of Short)

        Public Overridable Property Bank As Database.Entities.Bank

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.BankCode

        End Function

#End Region

	End Class

End Namespace
