Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table()>
    Public Class ScheduleHeader
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            TrafficCode
            AccountExecutiveEmployeeCode
            JobCompleted
            Comments
            TrafficDescription
            CompletedDate
            DateDelivered
            DateShipped
            ReceivedBy
            AccountExecutiveName
            OfficeCode
            OfficeName
            Assign1
            Assign2
            Assign3
            Assign4
            Assign5
            Assign1FullName
            Assign2FullName
            Assign3FullName
            Assign4FullName
            Assign5FullName
            Reference
            JobFirstUseDate
            StartDate
            JobRushCharges
            TrafficScheduleBy
            JobMarkupPercent
            NobillFlag
            JobAndComponent
            ClientDivisionProduct
            GutPercentComplete
            ScheduleCalculation
            AutoUpdateStatus
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _ClientCode As String = ""
        Private _ClientName As String = ""
        Private _DivisionCode As String = ""
        Private _DivisionName As String = ""
        Private _ProductCode As String = ""
        Private _ProductDescription As String = ""
        Private _JobNumber As Long = 0
        Private _JobDescription As String = ""
        Private _JobComponentNumber As Long = 0
        Private _JobComponentDescription As String = ""
        Private _TrafficCode As String = ""
        Private _AccountExecutiveEmployeeCode As String = ""
        Private _JobCompleted As System.Nullable(Of DateTime) = Nothing
        Private _Comments As String = ""
        Private _TrafficDescription As String = ""
        Private _CompletedDate As System.Nullable(Of DateTime) = Nothing
        Private _DateDelivered As System.Nullable(Of DateTime) = Nothing
        Private _DateShipped As System.Nullable(Of DateTime) = Nothing
        Private _ReceivedBy As String = ""
        Private _AccountExecutiveName As String = ""
        Private _OfficeCode As String = ""
        Private _OfficeName As String = ""
        Private _Assign1 As String = ""
        Private _Assign2 As String = ""
        Private _Assign3 As String = ""
        Private _Assign4 As String = ""
        Private _Assign5 As String = ""
        Private _Assign1FullName As String = ""
        Private _Assign2FullName As String = ""
        Private _Assign3FullName As String = ""
        Private _Assign4FullName As String = ""
        Private _Assign5FullName As String = ""
        Private _Reference As String = ""
        Private _JobFirstUseDate As System.Nullable(Of DateTime) = Nothing
        Private _StartDate As System.Nullable(Of DateTime) = Nothing
        Private _JobRushCharges As Long = 0
        Private _TrafficScheduleBy As System.Nullable(Of Long) = Nothing
        Private _JobMarkupPercent As System.Nullable(Of Decimal) = Nothing
        Private _NobillFlag As Long = 0
        Private _JobAndComponent As String = ""
        Private _ClientDivisionProduct As String = ""
        Private _GutPercentComplete As Decimal = 0
        Private _ScheduleCalculation As Long = 0
        Private _AutoUpdateStatus As System.Nullable(Of Long) = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ROWID", Storage:="_ID", DBType:="int"), _
        System.ComponentModel.DisplayName("ID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CL_CODE", Storage:="_ClientCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Client", IsReadOnlyColumn:=True)>
		Public Property ClientCode() As String
			Get
				ClientCode = _ClientCode
			End Get
			Set(ByVal value As String)
				_ClientCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CL_NAME", Storage:="_ClientName", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientName"),
		System.ComponentModel.DataAnnotations.MaxLength(40),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Client Name", IsReadOnlyColumn:=True)>
		Public Property ClientName() As String
			Get
				ClientName = _ClientName
			End Get
			Set(ByVal value As String)
				_ClientName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DIV_CODE", Storage:="_DivisionCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("DivisionCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Division", IsReadOnlyColumn:=True)>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(ByVal value As String)
				_DivisionCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DIV_NAME", Storage:="_DivisionName", DbType:="varchar"),
		System.ComponentModel.DisplayName("DivisionName"),
		System.ComponentModel.DataAnnotations.MaxLength(40),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Division Name", IsReadOnlyColumn:=True)>
		Public Property DivisionName() As String
			Get
				DivisionName = _DivisionName
			End Get
			Set(ByVal value As String)
				_DivisionName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRD_CODE", Storage:="_ProductCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("ProductCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Product", IsReadOnlyColumn:=True)>
		Public Property ProductCode() As String
			Get
				ProductCode = _ProductCode
			End Get
			Set(ByVal value As String)
				_ProductCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRD_DESCRIPTION", Storage:="_ProductDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("ProductDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(40),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Product Name", IsReadOnlyColumn:=True)>
		Public Property ProductDescription() As String
			Get
				ProductDescription = _ProductDescription
			End Get
			Set(ByVal value As String)
				_ProductDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_NUMBER", Storage:="_JobNumber", DbType:="int"),
		System.ComponentModel.DisplayName("JobNumber"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Job", IsReadOnlyColumn:=True)>
		Public Property JobNumber() As Long
			Get
				JobNumber = _JobNumber
			End Get
			Set(ByVal value As Long)
				_JobNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_DESC", Storage:="_JobDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("JobDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(60),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Job Description", IsReadOnlyColumn:=True)>
		Public Property JobDescription() As String
			Get
				JobDescription = _JobDescription
			End Get
			Set(ByVal value As String)
				_JobDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_COMPONENT_NBR", Storage:="_JobComponentNumber", DbType:="smallint"),
		System.ComponentModel.DisplayName("JobComponentNumber"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Component", IsReadOnlyColumn:=True)>
		Public Property JobComponentNumber() As Long
			Get
				JobComponentNumber = _JobComponentNumber
			End Get
			Set(ByVal value As Long)
				_JobComponentNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_COMP_DESC", Storage:="_JobComponentDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("JobComponentDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(60),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Component Description", IsReadOnlyColumn:=True)>
		Public Property JobComponentDescription() As String
			Get
				JobComponentDescription = _JobComponentDescription
			End Get
			Set(ByVal value As String)
				_JobComponentDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_CODE", Storage:="_TrafficCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("TrafficCode"),
		System.ComponentModel.DataAnnotations.MaxLength(10),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Status", PropertyType:=BaseClasses.PropertyTypes.Status)>
		Public Property TrafficCode() As String
			Get
				TrafficCode = _TrafficCode
			End Get
			Set(ByVal value As String)
				_TrafficCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_DESC", Storage:="_TrafficDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("TrafficDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(30),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Status Description", IsReadOnlyColumn:=True)>
		Public Property TrafficDescription() As String
			Get
				TrafficDescription = _TrafficDescription
			End Get
			Set(ByVal value As String)
				_TrafficDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_CODE_AE", Storage:="_AccountExecutiveEmployeeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("AccountExecutiveEmployeeCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="A/E", IsReadOnlyColumn:=True)>
		Public Property AccountExecutiveEmployeeCode() As String
			Get
				AccountExecutiveEmployeeCode = _AccountExecutiveEmployeeCode
			End Get
			Set(ByVal value As String)
				_AccountExecutiveEmployeeCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AE_NAME", Storage:="_AccountExecutiveName", DbType:="varchar"),
		System.ComponentModel.DisplayName("AccountExecutiveName"),
		System.ComponentModel.DataAnnotations.MaxLength(64),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="A/E Name", IsReadOnlyColumn:=True)>
		Public Property AccountExecutiveName() As String
			Get
				AccountExecutiveName = _AccountExecutiveName
			End Get
			Set(ByVal value As String)
				_AccountExecutiveName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="START_DATE", Storage:="_StartDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("StartDate"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Start")>
		Public Property StartDate() As System.Nullable(Of DateTime)
			Get
				StartDate = _StartDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_StartDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_FIRST_USE_DATE", Storage:="_JobFirstUseDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("JobFirstUseDate"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Due")>
		Public Property JobFirstUseDate() As System.Nullable(Of DateTime)
			Get
				JobFirstUseDate = _JobFirstUseDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_JobFirstUseDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JobCompleted", Storage:="_JobCompleted", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("JobCompleted"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Completed")>
		Public Property JobCompleted() As System.Nullable(Of DateTime)
			Get
				JobCompleted = _JobCompleted
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_JobCompleted = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GUT_PERCENT_COMPLETE", Storage:="_GutPercentComplete", DbType:="decimal"),
		System.ComponentModel.DisplayName("GutPercentComplete"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Gut % Complete")>
		Public Property GutPercentComplete() As Decimal
			Get
				GutPercentComplete = _GutPercentComplete
			End Get
			Set(ByVal value As Decimal)
				_GutPercentComplete = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="Comments", Storage:="_Comments", DbType:="varchar"),
		System.ComponentModel.DisplayName("Comments"),
		System.ComponentModel.DataAnnotations.MaxLength(4000),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
		Public Property Comments() As String
			Get
				Comments = _Comments
			End Get
			Set(ByVal value As String)
				_Comments = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COMPLETED_DATE", Storage:="_CompletedDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("CompletedDate"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property CompletedDate() As System.Nullable(Of DateTime)
			Get
				CompletedDate = _CompletedDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_CompletedDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE_DELIVERED", Storage:="_DateDelivered", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("DateDelivered"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property DateDelivered() As System.Nullable(Of DateTime)
			Get
				DateDelivered = _DateDelivered
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_DateDelivered = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE_SHIPPED", Storage:="_DateShipped", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("DateShipped"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property DateShipped() As System.Nullable(Of DateTime)
			Get
				DateShipped = _DateShipped
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_DateShipped = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RECEIVED_BY", Storage:="_ReceivedBy", DbType:="varchar"),
		System.ComponentModel.DisplayName("ReceivedBy"),
		System.ComponentModel.DataAnnotations.MaxLength(40),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property ReceivedBy() As String
			Get
				ReceivedBy = _ReceivedBy
			End Get
			Set(ByVal value As String)
				_ReceivedBy = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OFFICE_CODE", Storage:="_OfficeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("OfficeCode"),
		System.ComponentModel.DataAnnotations.MaxLength(4),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property OfficeCode() As String
			Get
				OfficeCode = _OfficeCode
			End Get
			Set(ByVal value As String)
				_OfficeCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OFFICE_NAME", Storage:="_OfficeName", DbType:="varchar"),
		System.ComponentModel.DisplayName("OfficeName"),
		System.ComponentModel.DataAnnotations.MaxLength(30),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property OfficeName() As String
			Get
				OfficeName = _OfficeName
			End Get
			Set(ByVal value As String)
				_OfficeName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_1", Storage:="_Assign1", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign1"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign1() As String
			Get
				Assign1 = _Assign1
			End Get
			Set(ByVal value As String)
				_Assign1 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_2", Storage:="_Assign2", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign2"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign2() As String
			Get
				Assign2 = _Assign2
			End Get
			Set(ByVal value As String)
				_Assign2 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_3", Storage:="_Assign3", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign3"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign3() As String
			Get
				Assign3 = _Assign3
			End Get
			Set(ByVal value As String)
				_Assign3 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_4", Storage:="_Assign4", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign4"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign4() As String
			Get
				Assign4 = _Assign4
			End Get
			Set(ByVal value As String)
				_Assign4 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_5", Storage:="_Assign5", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign5"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign5() As String
			Get
				Assign5 = _Assign5
			End Get
			Set(ByVal value As String)
				_Assign5 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_1_FML_NAME", Storage:="_Assign1FullName", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign1FullName"),
		System.ComponentModel.DataAnnotations.MaxLength(64),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign1FullName() As String
			Get
				Assign1FullName = _Assign1FullName
			End Get
			Set(ByVal value As String)
				_Assign1FullName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_2_FML_NAME", Storage:="_Assign2FullName", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign2FullName"),
		System.ComponentModel.DataAnnotations.MaxLength(64),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign2FullName() As String
			Get
				Assign2FullName = _Assign2FullName
			End Get
			Set(ByVal value As String)
				_Assign2FullName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_3_FML_NAME", Storage:="_Assign3FullName", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign3FullName"),
		System.ComponentModel.DataAnnotations.MaxLength(64),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign3FullName() As String
			Get
				Assign3FullName = _Assign3FullName
			End Get
			Set(ByVal value As String)
				_Assign3FullName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_4_FML_NAME", Storage:="_Assign4FullName", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign4FullName"),
		System.ComponentModel.DataAnnotations.MaxLength(64),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign4FullName() As String
			Get
				Assign4FullName = _Assign4FullName
			End Get
			Set(ByVal value As String)
				_Assign4FullName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ASSIGN_5_FML_NAME", Storage:="_Assign5FullName", DbType:="varchar"),
		System.ComponentModel.DisplayName("Assign5FullName"),
		System.ComponentModel.DataAnnotations.MaxLength(64),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Assign5FullName() As String
			Get
				Assign5FullName = _Assign5FullName
			End Get
			Set(ByVal value As String)
				_Assign5FullName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REFERENCE", Storage:="_Reference", DbType:="varchar"),
		System.ComponentModel.DisplayName("Reference"),
		System.ComponentModel.DataAnnotations.MaxLength(150),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Reference() As String
			Get
				Reference = _Reference
			End Get
			Set(ByVal value As String)
				_Reference = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_RUSH_CHARGES", Storage:="_JobRushCharges", DbType:="smallint"),
		System.ComponentModel.DisplayName("JobRushCharges"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property JobRushCharges() As Long
			Get
				JobRushCharges = _JobRushCharges
			End Get
			Set(ByVal value As Long)
				_JobRushCharges = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_SCHEDULE_BY", Storage:="_TrafficScheduleBy", DbType:="int"),
		System.ComponentModel.DisplayName("TrafficScheduleBy"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property TrafficScheduleBy() As System.Nullable(Of Long)
			Get
				TrafficScheduleBy = _TrafficScheduleBy
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_TrafficScheduleBy = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_MARKUP_PCT", Storage:="_JobMarkupPercent", DbType:="decimal"),
		System.ComponentModel.DisplayName("JobMarkupPercent"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property JobMarkupPercent() As System.Nullable(Of Decimal)
			Get
				JobMarkupPercent = _JobMarkupPercent
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_JobMarkupPercent = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NOBILL_FLAG", Storage:="_NobillFlag", DbType:="smallint"),
		System.ComponentModel.DisplayName("NobillFlag"),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property NobillFlag() As Long
			Get
				NobillFlag = _NobillFlag
			End Get
			Set(ByVal value As Long)
				_NobillFlag = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_AND_COMP", Storage:="_JobAndComponent", DbType:="varchar"),
		System.ComponentModel.DisplayName("JobAndComponent"),
		System.ComponentModel.DataAnnotations.MaxLength(8),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property JobAndComponent() As String
			Get
				JobAndComponent = _JobAndComponent
			End Get
			Set(ByVal value As String)
				_JobAndComponent = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CDP", Storage:="_ClientDivisionProduct", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientDivisionProduct"),
		System.ComponentModel.DataAnnotations.MaxLength(18),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property ClientDivisionProduct() As String
            Get
                ClientDivisionProduct = _ClientDivisionProduct
            End Get
            Set(ByVal value As String)
                _ClientDivisionProduct = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SCHEDULE_CALC", Storage:="_ScheduleCalculation", DBType:="int"), _
        System.ComponentModel.DisplayName("ScheduleCalculation"),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)> _
        Public Property ScheduleCalculation() As Long
            Get
                ScheduleCalculation = _ScheduleCalculation
            End Get
            Set(ByVal value As Long)
                _ScheduleCalculation = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AUTO_UPDATE_STATUS", Storage:="_AutoUpdateStatus", DBType:="bit"), _
        System.ComponentModel.DisplayName("AutoUpdateStatus"),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)> _
        Public Property AutoUpdateStatus() As System.Nullable(Of Long)
            Get
                AutoUpdateStatus = _AutoUpdateStatus
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _AutoUpdateStatus = value
            End Set
        End Property

#End Region

#Region " Methods "

#End Region

    End Class

End Namespace
