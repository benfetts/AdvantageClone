Namespace Reporting.Database.Classes

    <Serializable>
    Public Class JobProjectScheduleSummaryReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            OfficeCode
            OfficeDescription
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            CampaignID
            CampaignCode
            CampaignName
            SalesClassCode
            SalesClassDescription
            UserCode
            JobCreateDate
            JobDescription
            JobDateOpened
            RushChargesApproved
            ApprovedEstimateRequired
            Comment
            ClientReference
            BillingCoopCode
            SalesClassFormatCode
            ComplexityCode
            ComplexityDescription
            PromotionCode
            BillingComment
            LabelFromUDFTable1
            LabelFromUDFTable2
            LabelFromUDFTable3
            LabelFromUDFTable4
            LabelFromUDFTable5
            JobOpen
            ComponentNumber
            JobComponent
            BillHold
            AccountExecutiveCode
            AccountExecutive
            ComponentDateOpened
            DueDate
            StartDate
            AdSize
            DepartmentTeamCode
            DepartmentTeam
            MarkupPercent
            CreativeInstructions
            JobProcessControl
            ComponentDescription
            ComponentComments
            ComponentBudget
            EstimateNumber
            EstimateComponentNumber
            BillingUser
            AdvanceBillFlag
            DeliveryInstructions
            JobTypeCode
            JobTypeDescription
            Taxable
            TaxCode
            TaxCodeDescription
            NonBillable
            AlertGroup
            AdNumber
            AccountNumber
            IncomeRecognitionMethod
            MarketCode
            MarketDescription
            ServiceFeeJob
            Archived
            TrafficScheduleRequired
            ClientPO
            CompLabelFromUDFTable1
            CompLabelFromUDFTable2
            CompLabelFromUDFTable3
            CompLabelFromUDFTable4
            CompLabelFromUDFTable5
            JobTemplateCode
            FiscalPeriodCode
            FiscalPeriodDescription
            JobQuantity
            BlackplateVersionCode
            BlackplateVersionDesc
            ClientContactCode
            ClientContactID
            BABatchID
            ClientContact
            SelectedBABatchID
            BillingCommandCenterID
            AlertAssignmentTemplate
            JobCycleTime
            StatusCode
            Status
            GutPercentComplete
            Comments
            LabelAssign1
            LabelAssign2
            LabelAssign3
            LabelAssign4
            LabelAssign5
            CompletedDate
            JobEarlyOrLate
            DateDelivered
            DateShipped
            ReceivedBy
            Reference
            ManagerCode
            Manager
            TaskSequence
            TaskCode
            EstimateFunctionCode
            TaskDescription
            TaskStartDate
            TaskOriginalDueDate
            TaskRevisedDueDate
            DueDateChange
            TaskCycleTime
            TaskEarlyOrLate
            Locked
            TaskCompletedDate
            TaskOrder
            TaskDays
            TaskComments
            DueDateComments
            RevDueDateComments
            DefaultHoursAllowed
            TimeDue
            RevisedTimeDue
            TaskStatus
            Milestone
            Phase
            HoursAllowed
            Employee
            Employees
            TempCompleteDate
            JobProcessControlNumber
            JobProcessControlDate
            BlackplateVersion2Code
            BlackplateVersion2Desc
            ClientType1Code
            ClientType1Description
            ClientType2Code
            ClientType2Description
            ClientType3Code
            ClientType3Description

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <Required>
        <Column("JobNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Integer
        <MaxLength(4)>
        <Column("OfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("OfficeDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeDescription() As String
        <Required>
        <MaxLength(6)>
        <Column("ClientCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
        <MaxLength(40)>
        <Column("ClientDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDescription() As String
        <Required>
        <MaxLength(6)>
        <Column("DivisionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <Column("DivisionDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionDescription() As String
        <Required>
        <MaxLength(6)>
        <Column("ProductCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <Column("ProductDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
        <Column("CampaignID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("CampaignCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
        <MaxLength(60)>
        <Column("CampaignName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
        <MaxLength(6)>
        <Column("SalesClassCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
        <MaxLength(30)>
        <Column("SalesClassDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription() As String
        <MaxLength(100)>
        <Column("UserCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
        <Column("JobCreateDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCreateDate() As Nullable(Of Date)
        <MaxLength(60)>
        <Column("JobDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
        <Column("JobDateOpened")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDateOpened() As Nullable(Of Date)
        <Required>
        <MaxLength(3)>
        <Column("RushChargesApproved", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RushChargesApproved() As String
        <Required>
        <MaxLength(3)>
        <Column("ApprovedEstimateRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovedEstimateRequired() As String
        <Column("Comment")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
        <MaxLength(30)>
        <Column("ClientReference", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientReference() As String
        <MaxLength(6)>
        <Column("BillingCoopCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCoopCode() As String
        <MaxLength(6)>
        <Column("SalesClassFormatCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassFormatCode() As String
        <MaxLength(8)>
        <Column("ComplexityCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComplexityCode() As String
        <MaxLength(40)>
        <Column("ComplexityDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComplexityDescription() As String
        <MaxLength(8)>
        <Column("PromotionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PromotionCode() As String
        <MaxLength(254)>
        <Column("BillingComment", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property BillingComment() As String
        <MaxLength(40)>
        <Column("LabelFromUDFTable1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable1() As String
        <MaxLength(40)>
        <Column("LabelFromUDFTable2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable2() As String
        <MaxLength(40)>
        <Column("LabelFromUDFTable3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable3() As String
        <MaxLength(40)>
        <Column("LabelFromUDFTable4", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable4() As String
        <MaxLength(40)>
        <Column("LabelFromUDFTable5", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable5() As String
        <Required>
        <MaxLength(3)>
        <Column("JobOpen", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobOpen() As String
        <Required>
        <Column("ComponentNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentNumber() As Short
        <MaxLength(9)>
        <Column("JobComponent", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
        <Required>
        <MaxLength(3)>
        <Column("BillHold", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillHold() As String
        <Required>
        <MaxLength(6)>
        <Column("AccountExecutiveCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveCode() As String
        <MaxLength(64)>
        <Column("AccountExecutive", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutive() As String
        <Column("ComponentDateOpened")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDateOpened() As Nullable(Of Date)
        <Column("DueDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As Nullable(Of Date)
        <Column("StartDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
        <MaxLength(60)>
        <Column("AdSize", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdSize() As String
        <MaxLength(4)>
        <Column("DepartmentTeamCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentTeamCode() As String
        <MaxLength(30)>
        <Column("DepartmentTeam", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentTeam() As String
        <Column("MarkupPercent")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
        <Column("CreativeInstructions")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property CreativeInstructions() As String
        <MaxLength(40)>
        <Column("JobProcessControl", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobProcessControl() As String
        <Required>
        <MaxLength(60)>
        <Column("ComponentDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDescription() As String
        <Column("ComponentComments")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property ComponentComments() As String
        <Column("ComponentBudget")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentBudget() As Nullable(Of Decimal)
        <Column("EstimateNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property EstimateNumber() As Nullable(Of Integer)
        <Column("EstimateComponentNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentNumber() As Nullable(Of Short)
        <MaxLength(100)>
        <Column("BillingUser", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingUser() As String
        <MaxLength(32)>
        <Column("AdvanceBillFlag", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillFlag() As String
        <Column("DeliveryInstructions")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property DeliveryInstructions() As String
        <MaxLength(10)>
        <Column("JobTypeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeCode() As String
        <MaxLength(30)>
        <Column("JobTypeDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeDescription() As String
        <Required>
        <MaxLength(3)>
        <Column("Taxable", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Taxable() As String
        <MaxLength(4)>
        <Column("TaxCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCode() As String
        <MaxLength(30)>
        <Column("TaxCodeDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCodeDescription() As String
        <Column("NonBillable")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NonBillable() As Nullable(Of Short)
        <MaxLength(50)>
        <Column("AlertGroup", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertGroup() As String
        <MaxLength(30)>
        <Column("AdNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdNumber() As String
        <MaxLength(30)>
        <Column("AccountNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountNumber() As String
        <MaxLength(19)>
        <Column("IncomeRecognitionMethod", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncomeRecognitionMethod() As String
        <MaxLength(10)>
        <Column("MarketCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketCode() As String
        <MaxLength(40)>
        <Column("MarketDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketDescription() As String
        <Required>
        <MaxLength(3)>
        <Column("ServiceFeeJob", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceFeeJob() As String
        <Required>
        <MaxLength(3)>
        <Column("Archived", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Archived() As String
        <Required>
        <MaxLength(3)>
        <Column("TrafficScheduleRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TrafficScheduleRequired() As String
        <MaxLength(40)>
        <Column("ClientPO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPO() As String
        <MaxLength(40)>
        <Column("CompLabelFromUDFTable1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable1() As String
        <MaxLength(40)>
        <Column("CompLabelFromUDFTable2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable2() As String
        <MaxLength(40)>
        <Column("CompLabelFromUDFTable3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable3() As String
        <MaxLength(40)>
        <Column("CompLabelFromUDFTable4", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable4() As String
        <MaxLength(40)>
        <Column("CompLabelFromUDFTable5", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable5() As String
        <MaxLength(6)>
        <Column("JobTemplateCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTemplateCode() As String
        <MaxLength(6)>
        <Column("FiscalPeriodCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalPeriodCode() As String
        <MaxLength(30)>
        <Column("FiscalPeriodDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalPeriodDescription() As String
        <Column("JobQuantity")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobQuantity() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("BlackplateVersionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BlackplateVersionCode() As String
        <MaxLength(60)>
        <Column("BlackplateVersionDesc", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BlackplateVersionDesc() As String
        <Column("ClientContactCode")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactCode() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("ClientContactID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactID() As String
        <Column("BABatchID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property BABatchID() As Nullable(Of Integer)
        <MaxLength(64)>
        <Column("ClientContact", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContact() As String
        <Column("SelectedBABatchID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property SelectedBABatchID() As Nullable(Of Integer)
        <Column("BillingCommandCenterID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property BillingCommandCenterID() As Nullable(Of Integer)
        <MaxLength(100)>
        <Column("AlertAssignmentTemplate", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertAssignmentTemplate() As String
        <Column("JobCycleTime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCycleTime() As Nullable(Of Integer)
        <MaxLength(10)>
        <Column("StatusCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatusCode() As String
        <MaxLength(30)>
        <Column("Status", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Status() As String
        <Column("GutPercentComplete")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GutPercentComplete() As Nullable(Of Decimal)
        <Column("Comments")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Comments() As String
        <MaxLength(64)>
        <Column("LabelAssign1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign1() As String
        <MaxLength(64)>
        <Column("LabelAssign2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign2() As String
        <MaxLength(64)>
        <Column("LabelAssign3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign3() As String
        <MaxLength(64)>
        <Column("LabelAssign4", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign4() As String
        <MaxLength(64)>
        <Column("LabelAssign5", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign5() As String
        <Column("CompletedDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompletedDate() As Nullable(Of Date)
        <Column("JobEarlyOrLate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobEarlyOrLate() As Nullable(Of Integer)
        <Column("DateDelivered")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateDelivered() As Nullable(Of Date)
        <Column("DateShipped")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateShipped() As Nullable(Of Date)
        <MaxLength(40)>
        <Column("ReceivedBy", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReceivedBy() As String
        <MaxLength(150)>
        <Column("Reference", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Reference() As String
        <MaxLength(6)>
        <Column("ManagerCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ManagerCode() As String
        <MaxLength(64)>
        <Column("Manager", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Manager() As String
        <Column("TaskSequence")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskSequence() As Nullable(Of Short)
        <MaxLength(10)>
        <Column("TaskCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskCode() As String
        <MaxLength(6)>
        <Column("EstimateFunctionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateFunctionCode() As String
        <MaxLength(40)>
        <Column("TaskDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskDescription() As String
        <Column("TaskStartDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskStartDate() As Nullable(Of Date)
        <Column("TaskOriginalDueDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskOriginalDueDate() As Nullable(Of Date)
        <Column("TaskRevisedDueDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskRevisedDueDate() As Nullable(Of Date)
        <MaxLength(7)>
        <Column("DueDateChange", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDateChange() As String
        <Column("TaskCycleTime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskCycleTime() As Nullable(Of Integer)
        <Column("TaskEarlyOrLate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskEarlyOrLate() As Nullable(Of Integer)
        <Required>
        <MaxLength(3)>
        <Column("Locked", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Locked() As String
        <Column("TaskCompletedDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskCompletedDate() As Nullable(Of Date)
        <Column("TaskOrder")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskOrder() As Nullable(Of Short)
        <Column("TaskDays")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskDays() As Nullable(Of Short)
        <Column("TaskComments")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskComments() As String
        <Column("DueDateComments")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property DueDateComments() As String
        <Column("RevDueDateComments")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property RevDueDateComments() As String
        <Column("DefaultHoursAllowed")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property DefaultHoursAllowed() As Nullable(Of Decimal)
        <MaxLength(10)>
        <Column("TimeDue", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimeDue() As String
        <MaxLength(10)>
        <Column("RevisedTimeDue", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RevisedTimeDue() As String
        <Required>
        <MaxLength(1)>
        <Column("TaskStatus", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskStatus() As String
        <Required>
        <MaxLength(3)>
        <Column("Milestone", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Milestone() As String
        <MaxLength(40)>
        <Column("Phase", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Phase() As String
        <Column("HoursAllowed")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HoursAllowed() As Nullable(Of Decimal)
        <MaxLength(6)>
        <Column("Employee", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Employee() As String
        <MaxLength(4000)>
        <Column("Employees", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Employees() As String
        <Column("TempCompleteDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TempCompleteDate() As Nullable(Of Date)
        <Column("JobProcessControlNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobProcessControlNumber() As Nullable(Of Short)
        <Column("JobProcessControlDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobProcessControlDate() As Nullable(Of Date)
        <MaxLength(6)>
        <Column("BlackplateVersion2Code", TypeName:="varchar")>
        Public Property BlackplateVersion2Code() As String
        <MaxLength(60)>
        <Column("BlackplateVersion2Desc", TypeName:="varchar")>
        Public Property BlackplateVersion2Desc() As String

        <Column("ClientType1Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 1 Code")>
        Public Property ClientType1Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("ClientType1Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 1 Description")>
        Public Property ClientType1Description() As String

        <Column("ClientType2Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 2 Code")>
        Public Property ClientType2Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("ClientType2Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 2 Description")>
        Public Property ClientType2Description() As String

        <Column("ClientType3Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 3 Code")>
        Public Property ClientType3Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("ClientType3Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 3 Description")>
        Public Property ClientType3Description() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
