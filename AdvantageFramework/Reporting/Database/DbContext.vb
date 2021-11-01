Namespace Reporting.Database

    Public Class DbContext
        Inherits BaseClasses.DbContext

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
            DynamicReportDatasets
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
            UserDefinedReportCategories
            UserDefinedReports
            VendorContractsReports
            VendorReports
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Overridable Property AlertsReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.AlertsReport)
        Public Overridable Property AlertsWithCommentsReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.AlertsWithCommentsReport)
        Public Overridable Property AlertsWithRecipientsReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.AlertsWithRecipientsReport)
        Public Overridable Property CampaignReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.CampaignReport)
        Public Overridable Property ClientContactReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.ClientContactReport)
        Public Overridable Property ClientReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.ClientReport)
        Public Overridable Property CRMClientContractsReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.CRMClientContractsReport)
        Public Overridable Property CRMOpportunityDetailReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.CRMOpportunityDetailReport)
        Public Overridable Property CRMOpportunityToInvestmentReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.CRMOpportunityToInvestmentReport)
        Public Overridable Property CRMProspectsReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.CRMProspectsReport)
        Public Overridable Property CustomInvoices As System.Data.Entity.DbSet(Of Reporting.Database.Entities.CustomInvoice)
        Public Overridable Property DirectIndirectTimeCostReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.DirectIndirectTimeCostReport)
        Public Overridable Property DirectIndirectTimeReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.DirectIndirectTimeReport)
        Public Overridable Property DirectTimeCostReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.DirectTimeCostReport)
        Public Overridable Property DirectTimeReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.DirectTimeReport)
        Public Overridable Property DivisionReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.DivisionReport)
        Public Overridable Property DynamicReportColumns As System.Data.Entity.DbSet(Of Reporting.Database.Entities.DynamicReportColumn)
        Public Overridable Property DynamicReportDatasets As System.Data.Entity.DbSet(Of Reporting.Database.Entities.DynamicReportDataset)
        Public Overridable Property DynamicReports As System.Data.Entity.DbSet(Of Reporting.Database.Entities.DynamicReport)
        Public Overridable Property DynamicReportSummaryItems As System.Data.Entity.DbSet(Of Reporting.Database.Entities.DynamicReportSummaryItem)
        Public Overridable Property DynamicReportUnboundColumns As System.Data.Entity.DbSet(Of Reporting.Database.Entities.DynamicReportUnboundColumn)
        Public Overridable Property EmployeeReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.EmployeeReport)
        Public Overridable Property EstimateReports As System.Data.Entity.DbSet(Of Reporting.Database.Entities.EstimateReport)
        Public Overridable Property JobProjectScheduleSummaryReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.JobProjectScheduleSummaryReport)
        'Public Overridable Property JobPurchaseOrderReports As System.Data.Entity.DbSet(Of Reporting.Database.Classes.JobPurchaseOrderReportSP)
        Public Overridable Property JobSummaryReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.JobSummaryReport)
        Public Overridable Property MediaPlanReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.MediaPlanReport)
        Public Overridable Property NewspaperOrderDetailReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.NewspaperOrderDetailReport)
        Public Overridable Property ProductReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.ProductReport)
        Public Overridable Property ProjectHoursUsedReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.ProjectHoursUsedReport)
        Public Overridable Property UserDefinedReportCategories As System.Data.Entity.DbSet(Of Reporting.Database.Entities.UserDefinedReportCategory)
        Public Overridable Property UserDefinedReports As System.Data.Entity.DbSet(Of Reporting.Database.Entities.UserDefinedReport)
        Public Overridable Property VendorContractsReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.VendorContractsReport)
        Public Overridable Property VendorReports As System.Data.Entity.DbSet(Of Reporting.Database.Views.VendorReport)

#End Region

#Region " Methods "

        <System.Obsolete>
        Public Sub New()

            MyBase.New("Data Source=TASC-CODE\TFS;Initial Catalog=ADV67000;Persist Security Info=True;User ID=SYSADM;Password=sysadm;MultipleActiveResultSets=True;APP=EntityFramework")

        End Sub
        <System.Obsolete>
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode, AdvantageFramework.Database.Methods.DatabaseTypes.Reporting)

            System.Data.Entity.Database.SetInitializer(Of AdvantageFramework.Reporting.Database.DbContext)(Nothing)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            'modelBuilder.Properties.Having(Function(Prop) Prop.GetCustomAttributes(False).OfType(Of AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute).FirstOrDefault).
            '                        Configure(Function(Prop, Attribute) Prop.HasPrecision(Attribute.Precision, Attribute.Scale))

            MyBase.OnModelCreating(modelBuilder)

        End Sub

#End Region

    End Class

End Namespace
