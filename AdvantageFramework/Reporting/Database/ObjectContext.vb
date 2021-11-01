
<Assembly: System.Data.Objects.DataClasses.EdmSchemaAttribute("dc7a9c11-7991-4286-8f95-f3aaba662b44")> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ReportingObjectContext", "DynamicReportDynamicReportSummaryItem", "DynamicReport", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(AdvantageFramework.Reporting.Database.Entities.DynamicReport), "DynamicReportSummaryItem", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ReportingObjectContext", "DynamicReportDynamicReportColumn", "DynamicReport", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(AdvantageFramework.Reporting.Database.Entities.DynamicReport), "DynamicReportColumn", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ReportingObjectContext", "UserDefinedReportCategoryUserDefinedReport", "UserDefinedReportCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory), "UserDefinedReport", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(AdvantageFramework.Reporting.Database.Entities.UserDefinedReport), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ReportingObjectContext", "UserDefinedReportCategoryDynamicReport", "UserDefinedReportCategory", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory), "DynamicReport", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(AdvantageFramework.Reporting.Database.Entities.DynamicReport), True)> 
<Assembly: System.Data.Objects.DataClasses.EdmRelationshipAttribute("ReportingObjectContext", "DynamicReportDynamicReportUnboundColumn", "DynamicReport", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(AdvantageFramework.Reporting.Database.Entities.DynamicReport), "DynamicReportUnboundColumns", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn), True)> 

Namespace Reporting.Database

    Public Class ObjectContext
        Inherits BaseClasses.ObjectContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertsReports
            AlertsWithCommentsReports
            AlertsWithRecipientsReports
            CampaignReports
            ClientContactReports
            ClientReports
            CRMClientContractsReports
            CRMOpportunityDetailReports
            CRMOpportunityToInvestmentReports
            CRMProspectsReports
            CustomInvoices
            DirectIndirectTimeCostReports
            DirectIndirectTimeReports
            DirectTimeCostReports
            DirectTimeReports
            DivisionReports
            DynamicReportColumns
            DynamicReports
            DynamicReportSummaryItems
            DynamicReportUnboundColumns
            EmployeeReports
            EstimateReports
            JobProjectScheduleSummaryReports
            JobPurchaseOrderReports
            JobSummaryReports
            MediaPlanReports
            NewspaperOrderDetailReports
            ProductReports
            ProjectHoursUsedReports
            ProjectScheduleReports
            UserDefinedReportCategories
            UserDefinedReports
            VendorContractsReports
            VendorReports
        End Enum

#End Region

#Region " Variables "

        Private _AlertsReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.AlertsReport) = Nothing
        Private _AlertsWithCommentsReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.AlertsWithCommentsReport) = Nothing
        Private _AlertsWithRecipientsReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.AlertsWithRecipientsReport) = Nothing
        Private _CampaignReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CampaignReport) = Nothing
        Private _ClientContactReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ClientContactReport) = Nothing
        Private _ClientReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ClientReport) = Nothing
        Private _CRMClientContractsReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CRMClientContractsReport) = Nothing
        Private _CRMOpportunityDetailReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CRMOpportunityDetailReport) = Nothing
        Private _CRMOpportunityToInvestmentReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CRMOpportunityToInvestmentReport) = Nothing
        Private _CRMProspectsReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CRMProspectsReport) = Nothing
        Private _CustomInvoices As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.CustomInvoice) = Nothing
        Private _DirectIndirectTimeCostReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DirectIndirectTimeCostReport) = Nothing
        Private _DirectIndirectTimeReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DirectIndirectTimeReport) = Nothing
        Private _DirectTimeCostReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DirectTimeCostReport) = Nothing
        Private _DirectTimeReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DirectTimeReport) = Nothing
        Private _DivisionReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DivisionReport) = Nothing
        Private _DynamicReportColumns As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.DynamicReportColumn) = Nothing
        Private _DynamicReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.DynamicReport) = Nothing
        Private _DynamicReportSummaryItems As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.DynamicReportSummaryItem) = Nothing
        Private _DynamicReportUnboundColumns As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.DynamicReportUnboundColumn) = Nothing
        Private _EmployeeReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.EmployeeReport) = Nothing
        Private _EstimateReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.EstimateReport) = Nothing
        Private _JobProjectScheduleSummaryReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.JobProjectScheduleSummaryReport) = Nothing
        Private _JobPurchaseOrderReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.JobPurchaseOrderReport) = Nothing
        Private _JobSummaryReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.JobSummaryReport) = Nothing
        Private _MediaPlanReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.MediaPlanReport) = Nothing
        Private _NewspaperOrderDetailReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.NewspaperOrderDetailReport) = Nothing
        Private _ProductReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ProductReport) = Nothing
        Private _ProjectHoursUsedReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ProjectHoursUsedReport) = Nothing
        Private _ProjectScheduleReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ProjectScheduleReport) = Nothing
        Private _UserDefinedReportCategories As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.UserDefinedReportCategory) = Nothing
        Private _UserDefinedReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.UserDefinedReport) = Nothing
        Private _VendorContractsReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.VendorContractsReport) = Nothing
        Private _VendorReports As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.VendorReport) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property AlertsReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.AlertsReport)
            Get

                If _AlertsReports Is Nothing Then

                    _AlertsReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.AlertsReport)(Reporting.Database.ObjectContext.Properties.AlertsReports.ToString)

                End If

                AlertsReports = _AlertsReports

            End Get
        End Property
        Public ReadOnly Property AlertsWithCommentsReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.AlertsWithCommentsReport)
            Get

                If _AlertsWithCommentsReports Is Nothing Then

                    _AlertsWithCommentsReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.AlertsWithCommentsReport)(Reporting.Database.ObjectContext.Properties.AlertsWithCommentsReports.ToString)

                End If

                AlertsWithCommentsReports = _AlertsWithCommentsReports

            End Get
        End Property
        Public ReadOnly Property AlertsWithRecipientsReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.AlertsWithRecipientsReport)
            Get

                If _AlertsWithRecipientsReports Is Nothing Then

                    _AlertsWithRecipientsReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.AlertsWithRecipientsReport)(Reporting.Database.ObjectContext.Properties.AlertsWithRecipientsReports.ToString)

                End If

                AlertsWithRecipientsReports = _AlertsWithRecipientsReports

            End Get
        End Property
        Public ReadOnly Property CampaignReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CampaignReport)
            Get

                If _CampaignReports Is Nothing Then

                    _CampaignReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.CampaignReport)(Reporting.Database.ObjectContext.Properties.CampaignReports.ToString)

                End If

                CampaignReports = _CampaignReports

            End Get
        End Property
        Public ReadOnly Property ClientContactReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ClientContactReport)
            Get

                If _ClientContactReports Is Nothing Then

                    _ClientContactReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.ClientContactReport)(Reporting.Database.ObjectContext.Properties.ClientContactReports.ToString)

                End If

                ClientContactReports = _ClientContactReports

            End Get
        End Property
        Public ReadOnly Property ClientReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ClientReport)
            Get

                If _ClientReports Is Nothing Then

                    _ClientReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.ClientReport)(Reporting.Database.ObjectContext.Properties.ClientReports.ToString)

                End If

                ClientReports = _ClientReports

            End Get
        End Property
        Public ReadOnly Property CRMClientContractsReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CRMClientContractsReport)
            Get

                If _CRMClientContractsReports Is Nothing Then

                    _CRMClientContractsReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.CRMClientContractsReport)(Reporting.Database.ObjectContext.Properties.CRMClientContractsReports.ToString)

                End If

                CRMClientContractsReports = _CRMClientContractsReports

            End Get
        End Property
        Public ReadOnly Property CRMOpportunityDetailReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CRMOpportunityDetailReport)
            Get

                If _CRMOpportunityDetailReports Is Nothing Then

                    _CRMOpportunityDetailReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.CRMOpportunityDetailReport)(Reporting.Database.ObjectContext.Properties.CRMOpportunityDetailReports.ToString)

                End If

                CRMOpportunityDetailReports = _CRMOpportunityDetailReports

            End Get
        End Property
        Public ReadOnly Property CRMOpportunityToInvestmentReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CRMOpportunityToInvestmentReport)
            Get

                If _CRMOpportunityToInvestmentReports Is Nothing Then

                    _CRMOpportunityToInvestmentReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.CRMOpportunityToInvestmentReport)(Reporting.Database.ObjectContext.Properties.CRMOpportunityToInvestmentReports.ToString)

                End If

                CRMOpportunityToInvestmentReports = _CRMOpportunityToInvestmentReports

            End Get
        End Property
        Public ReadOnly Property CRMProspectsReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.CRMProspectsReport)
            Get

                If _CRMProspectsReports Is Nothing Then

                    _CRMProspectsReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.CRMProspectsReport)(Reporting.Database.ObjectContext.Properties.CRMProspectsReports.ToString)

                End If

                CRMProspectsReports = _CRMProspectsReports

            End Get
        End Property
        Public ReadOnly Property CustomInvoices() As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.CustomInvoice)
            Get

                If _CustomInvoices Is Nothing Then

                    _CustomInvoices = MyBase.CreateObjectSet(Of Database.Entities.CustomInvoice)(Reporting.Database.ObjectContext.Properties.CustomInvoices.ToString)

                End If

                CustomInvoices = _CustomInvoices

            End Get
        End Property
        Public ReadOnly Property DirectIndirectTimeCostReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DirectIndirectTimeCostReport)
            Get

                If _DirectIndirectTimeCostReports Is Nothing Then

                    _DirectIndirectTimeCostReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.DirectIndirectTimeCostReport)(Reporting.Database.ObjectContext.Properties.DirectIndirectTimeCostReports.ToString)

                End If

                DirectIndirectTimeCostReports = _DirectIndirectTimeCostReports

            End Get
        End Property
        Public ReadOnly Property DirectIndirectTimeReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DirectIndirectTimeReport)
            Get

                If _DirectIndirectTimeReports Is Nothing Then

                    _DirectIndirectTimeReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.DirectIndirectTimeReport)(Reporting.Database.ObjectContext.Properties.DirectIndirectTimeReports.ToString)

                End If

                DirectIndirectTimeReports = _DirectIndirectTimeReports

            End Get
        End Property
        Public ReadOnly Property DirectTimeCostReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DirectTimeCostReport)
            Get

                If _DirectTimeCostReports Is Nothing Then

                    _DirectTimeCostReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.DirectTimeCostReport)(Reporting.Database.ObjectContext.Properties.DirectTimeCostReports.ToString)

                End If

                DirectTimeCostReports = _DirectTimeCostReports

            End Get
        End Property
        Public ReadOnly Property DirectTimeReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DirectTimeReport)
            Get

                If _DirectTimeReports Is Nothing Then

                    _DirectTimeReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.DirectTimeReport)(Reporting.Database.ObjectContext.Properties.DirectTimeReports.ToString)

                End If

                DirectTimeReports = _DirectTimeReports

            End Get
        End Property
        Public ReadOnly Property DivisionReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.DivisionReport)
            Get

                If _DivisionReports Is Nothing Then

                    _DivisionReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.DivisionReport)(Reporting.Database.ObjectContext.Properties.DivisionReports.ToString)

                End If

                DivisionReports = _DivisionReports

            End Get
        End Property
        Public ReadOnly Property DynamicReportColumns() As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.DynamicReportColumn)
            Get

                If _DynamicReportColumns Is Nothing Then

                    _DynamicReportColumns = MyBase.CreateObjectSet(Of Reporting.Database.Entities.DynamicReportColumn)(Reporting.Database.ObjectContext.Properties.DynamicReportColumns.ToString)

                End If

                DynamicReportColumns = _DynamicReportColumns

            End Get
        End Property
        Public ReadOnly Property DynamicReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.DynamicReport)
            Get

                If _DynamicReports Is Nothing Then

                    _DynamicReports = MyBase.CreateObjectSet(Of Reporting.Database.Entities.DynamicReport)(Reporting.Database.ObjectContext.Properties.DynamicReports.ToString)

                End If

                DynamicReports = _DynamicReports

            End Get
        End Property
        Public ReadOnly Property DynamicReportSummaryItems() As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.DynamicReportSummaryItem)
            Get

                If _DynamicReportSummaryItems Is Nothing Then

                    _DynamicReportSummaryItems = MyBase.CreateObjectSet(Of Reporting.Database.Entities.DynamicReportSummaryItem)(Reporting.Database.ObjectContext.Properties.DynamicReportSummaryItems.ToString)

                End If

                DynamicReportSummaryItems = _DynamicReportSummaryItems

            End Get
        End Property
        Public ReadOnly Property DynamicReportUnboundColumns() As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.DynamicReportUnboundColumn)
            Get

                If _DynamicReportUnboundColumns Is Nothing Then

                    _DynamicReportUnboundColumns = MyBase.CreateObjectSet(Of Reporting.Database.Entities.DynamicReportUnboundColumn)(Reporting.Database.ObjectContext.Properties.DynamicReportUnboundColumns.ToString)

                End If

                DynamicReportUnboundColumns = _DynamicReportUnboundColumns

            End Get
        End Property
        Public ReadOnly Property EmployeeReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.EmployeeReport)
            Get

                If _EmployeeReports Is Nothing Then

                    _EmployeeReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.EmployeeReport)(Reporting.Database.ObjectContext.Properties.EmployeeReports.ToString)

                End If

                EmployeeReports = _EmployeeReports

            End Get
        End Property
        Public ReadOnly Property EstimateReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.EstimateReport)
            Get

                If _EstimateReports Is Nothing Then

                    _EstimateReports = MyBase.CreateObjectSet(Of Reporting.Database.Entities.EstimateReport)(Reporting.Database.ObjectContext.Properties.EstimateReports.ToString)

                End If

                EstimateReports = _EstimateReports

            End Get
        End Property
        Public ReadOnly Property JobProjectScheduleSummaryReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.JobProjectScheduleSummaryReport)
            Get

                If _JobProjectScheduleSummaryReports Is Nothing Then

                    _JobProjectScheduleSummaryReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.JobProjectScheduleSummaryReport)(Reporting.Database.ObjectContext.Properties.JobProjectScheduleSummaryReports.ToString)

                End If

                JobProjectScheduleSummaryReports = _JobProjectScheduleSummaryReports

            End Get
        End Property
        Public ReadOnly Property JobPurchaseOrderReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.JobPurchaseOrderReport)
            Get

                If _JobPurchaseOrderReports Is Nothing Then

                    _JobPurchaseOrderReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.JobPurchaseOrderReport)(Reporting.Database.ObjectContext.Properties.JobPurchaseOrderReports.ToString)

                End If

                JobPurchaseOrderReports = _JobPurchaseOrderReports

            End Get
        End Property
        Public ReadOnly Property JobSummaryReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.JobSummaryReport)
            Get

                If _JobSummaryReports Is Nothing Then

                    _JobSummaryReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.JobSummaryReport)(Reporting.Database.ObjectContext.Properties.JobSummaryReports.ToString)

                End If

                JobSummaryReports = _JobSummaryReports

            End Get
        End Property
        Public ReadOnly Property MediaPlanReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.MediaPlanReport)
            Get

                If _MediaPlanReports Is Nothing Then

                    _MediaPlanReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.MediaPlanReport)(Reporting.Database.ObjectContext.Properties.MediaPlanReports.ToString)

                End If

                MediaPlanReports = _MediaPlanReports

            End Get
        End Property
        Public ReadOnly Property NewspaperOrderDetailReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.NewspaperOrderDetailReport)
            Get

                If _NewspaperOrderDetailReports Is Nothing Then

                    _NewspaperOrderDetailReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.NewspaperOrderDetailReport)(Reporting.Database.ObjectContext.Properties.NewspaperOrderDetailReports.ToString)

                End If

                NewspaperOrderDetailReports = _NewspaperOrderDetailReports

            End Get
        End Property
        Public ReadOnly Property ProductReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ProductReport)
            Get

                If _ProductReports Is Nothing Then

                    _ProductReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.ProductReport)(Reporting.Database.ObjectContext.Properties.ProductReports.ToString)

                End If

                ProductReports = _ProductReports

            End Get
        End Property
        Public ReadOnly Property ProjectHoursUsedReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ProjectHoursUsedReport)
            Get

                If _ProjectHoursUsedReports Is Nothing Then

                    _ProjectHoursUsedReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.ProjectHoursUsedReport)(Reporting.Database.ObjectContext.Properties.ProjectHoursUsedReports.ToString)

                End If

                ProjectHoursUsedReports = _ProjectHoursUsedReports

            End Get
        End Property
        Public ReadOnly Property ProjectScheduleReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.ProjectScheduleReport)
            Get

                If _ProjectScheduleReports Is Nothing Then

                    _ProjectScheduleReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.ProjectScheduleReport)(Reporting.Database.ObjectContext.Properties.ProjectScheduleReports.ToString)

                End If

                ProjectScheduleReports = _ProjectScheduleReports

            End Get
        End Property
        Public ReadOnly Property UserDefinedReportCategories() As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.UserDefinedReportCategory)
            Get

                If _UserDefinedReportCategories Is Nothing Then

                    _UserDefinedReportCategories = MyBase.CreateObjectSet(Of Reporting.Database.Entities.UserDefinedReportCategory)(Reporting.Database.ObjectContext.Properties.UserDefinedReportCategories.ToString)

                End If

                UserDefinedReportCategories = _UserDefinedReportCategories

            End Get
        End Property
        Public ReadOnly Property UserDefinedReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Entities.UserDefinedReport)
            Get

                If _UserDefinedReports Is Nothing Then

                    _UserDefinedReports = MyBase.CreateObjectSet(Of Reporting.Database.Entities.UserDefinedReport)(Reporting.Database.ObjectContext.Properties.UserDefinedReports.ToString)

                End If

                UserDefinedReports = _UserDefinedReports

            End Get
        End Property
        Public ReadOnly Property VendorContractsReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.VendorContractsReport)
            Get

                If _VendorContractsReports Is Nothing Then

                    _VendorContractsReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.VendorContractsReport)(Reporting.Database.ObjectContext.Properties.VendorContractsReports.ToString)

                End If

                VendorContractsReports = _VendorContractsReports

            End Get
        End Property
        Public ReadOnly Property VendorReports() As System.Data.Objects.ObjectSet(Of Reporting.Database.Views.VendorReport)
            Get

                If _VendorReports Is Nothing Then

                    _VendorReports = MyBase.CreateObjectSet(Of Reporting.Database.Views.VendorReport)(Reporting.Database.ObjectContext.Properties.VendorReports.ToString)

                End If

                VendorReports = _VendorReports

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode, ObjectContextType.Reporting)

        End Sub
        Public Shadows Sub AttachToOrGet(Of T As AdvantageFramework.BaseClasses.Entity)(ByVal EntitySetName As AdvantageFramework.Reporting.Database.ObjectContext.Properties, ByRef Entity As T)

            MyBase.AttachToOrGet(EntitySetName.ToString, Entity)

        End Sub

#End Region

    End Class

End Namespace

