Namespace Database.Procedures.SearchComplexType

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        'Public Function Load(ByVal DbContext As Database.DbContext) As System.Collections.Generic.List(Of Database.Classes.Search)

        '    Load = DbContext.ExecuteFunction(Of Database.Classes.Search)("LoadSearchAll")

        'End Function
        'Public Function Load(ByVal DbContext As Database.DbContext,
        '                     ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Collections.Generic.List(Of Database.Classes.Search)

        '    Load = Load(DbContext,
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.EmployeeCode.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.UserCode.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.SearchTerm.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ExactSearch.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.JobsOpen.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.JobsClosed.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.JobsDescription.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.JobsComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsStandard.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsAssignments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsSubject.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsDescription.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsOpen.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.AlertsDismissedCompleted.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleIncludeClosed.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskIncludeClosed.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskDescription.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskFunctionComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskDueDateComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ScheduleTaskRevisionDateComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateDescription.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateFooterComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateComponentDescription.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateComponentComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateQuoteDetailComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.EstimateQuoteDetailDescription.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.CampaignComments.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDescription.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderMainInstruction.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDeliveryInstruction.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDetailDescription.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDetailLineDescription.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.PurchaseOrderDetailInstruction.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ClientPortal.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.ClientPortalID.ToString()),
        '                ParameterDictionary(AdvantageFramework.Database.Entities.SearchAllParameters.JobRequests.ToString()))

        'End Function
        Public Function Load(DbContext As Database.DbContext,
                             EmployeeCode As String,
                             UserCode As String,
                             SearchTerm As String,
                             Optional ByVal ExactSearch As Boolean = False,
                             Optional ByVal JobsOpen As Boolean = False,
                             Optional ByVal JobsClosed As Boolean = False,
                             Optional ByVal JobsDescription As Boolean = False,
                             Optional ByVal JobsComments As Boolean = False,
                             Optional ByVal AlertsStandard As Boolean = False,
                             Optional ByVal AlertsAssignments As Boolean = False,
                             Optional ByVal AlertsSubject As Boolean = False,
                             Optional ByVal AlertsDescription As Boolean = False,
                             Optional ByVal AlertsOpen As Boolean = False,
                             Optional ByVal AlertsDismissedCompleted As Boolean = False,
                             Optional ByVal ScheduleComments As Boolean = False,
                             Optional ByVal ScheduleIncludeClosed As Boolean = False,
                             Optional ByVal ScheduleTaskIncludeClosed As Boolean = False,
                             Optional ByVal ScheduleTaskDescription As Boolean = False,
                             Optional ByVal ScheduleTaskFunctionComments As Boolean = False,
                             Optional ByVal ScheduleTaskDueDateComments As Boolean = False,
                             Optional ByVal ScheduleTaskRevisionDateComments As Boolean = False,
                             Optional ByVal EstimateDescription As Boolean = False,
                             Optional ByVal EstimateComments As Boolean = False,
                             Optional ByVal EstimateFooterComments As Boolean = False,
                             Optional ByVal EstimateComponentDescription As Boolean = False,
                             Optional ByVal EstimateComponentComments As Boolean = False,
                             Optional ByVal EstimateQuoteDetailComments As Boolean = False,
                             Optional ByVal EstimateQuoteDetailDescription As Boolean = False,
                             Optional ByVal CampaignComments As Boolean = False,
                             Optional ByVal PurchaseOrderDescription As Boolean = False,
                             Optional ByVal PurchaseOrderMainInstruction As Boolean = False,
                             Optional ByVal PurchaseOrderDeliveryInstruction As Boolean = False,
                             Optional ByVal PurchaseOrderDetailDescription As Boolean = False,
                             Optional ByVal PurchaseOrderDetailLineDescription As Boolean = False,
                             Optional ByVal PurchaseOrderDetailInstruction As Boolean = False,
                             Optional ByVal ClientPortal As Boolean = False,
                             Optional ByVal ClientPortalID As Integer = 0,
                             Optional ByVal JobRequest As Boolean = False) As System.Collections.Generic.List(Of Database.Classes.Search)

            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSearchTerm As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterExactSearch As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobsOpen As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobsClosed As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobsDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobsComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertsStandard As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertsAssignments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertsSubject As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertsDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertsOpen As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertsDismissedCompleted As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterScheduleComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterScheduleIncludeClosed As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterScheduleTaskIncludeClosed As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterScheduleTaskDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterScheduleTaskFunctionComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterScheduleTaskDueDateComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterScheduleTaskRevisionDateComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEstimateDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEstimateComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEstimateFooterComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEstimateComponentDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEstimateComponentComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEstimateQuoteDetailComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEstimateQuoteDetailDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCampaignComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPurchaseOrderDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPurchaseOrderMainInstruction As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPurchaseOrderDeliveryInstruction As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPurchaseOrderDetailDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPurchaseOrderDetailLineDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPurchaseOrderDetailInstruction As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientPortal As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientPortalID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobRequest As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
            SqlParameterSearchTerm = New System.Data.SqlClient.SqlParameter("@SEARCH_TERM", SqlDbType.VarChar)
            SqlParameterExactSearch = New System.Data.SqlClient.SqlParameter("@EXACT_SEARCH", SqlDbType.Bit)
            SqlParameterJobsOpen = New System.Data.SqlClient.SqlParameter("@JOBS_OPEN", SqlDbType.Bit)
            SqlParameterJobsClosed = New System.Data.SqlClient.SqlParameter("@JOBS_CLOSED", SqlDbType.Bit)
            SqlParameterJobsDescription = New System.Data.SqlClient.SqlParameter("@JOBS_DESC", SqlDbType.Bit)
            SqlParameterJobsComments = New System.Data.SqlClient.SqlParameter("@JOBS_COMMENTS", SqlDbType.Bit)
            SqlParameterAlertsStandard = New System.Data.SqlClient.SqlParameter("@ALERTS_STANDARD", SqlDbType.Bit)
            SqlParameterAlertsAssignments = New System.Data.SqlClient.SqlParameter("@ALERTS_ASSIGNMENTS", SqlDbType.Bit)
            SqlParameterAlertsSubject = New System.Data.SqlClient.SqlParameter("@ALERTS_SUBJECT", SqlDbType.Bit)
            SqlParameterAlertsDescription = New System.Data.SqlClient.SqlParameter("@ALERTS_DESC", SqlDbType.Bit)
            SqlParameterAlertsOpen = New System.Data.SqlClient.SqlParameter("@ALERTS_OPEN", SqlDbType.Bit)
            SqlParameterAlertsDismissedCompleted = New System.Data.SqlClient.SqlParameter("@ALERTS_DISMISSED_COMPLETED", SqlDbType.Bit)
            SqlParameterScheduleComments = New System.Data.SqlClient.SqlParameter("@SCHED_COMMENTS", SqlDbType.Bit)
            SqlParameterScheduleIncludeClosed = New System.Data.SqlClient.SqlParameter("@SCHED_INCL_CLOSED", SqlDbType.Bit)
            SqlParameterScheduleTaskIncludeClosed = New System.Data.SqlClient.SqlParameter("@SCHED_TASK_INCL_CLOSED", SqlDbType.Bit)
            SqlParameterScheduleTaskDescription = New System.Data.SqlClient.SqlParameter("@SCHED_TASK_DESC", SqlDbType.Bit)
            SqlParameterScheduleTaskFunctionComments = New System.Data.SqlClient.SqlParameter("@SCHED_TASK_FNC_COMMENTS", SqlDbType.Bit)
            SqlParameterScheduleTaskDueDateComments = New System.Data.SqlClient.SqlParameter("@SCHED_TASK_DUE_DATE_COMMENTS", SqlDbType.Bit)
            SqlParameterScheduleTaskRevisionDateComments = New System.Data.SqlClient.SqlParameter("@SCHED_TASK_REV_DATE_COMMENTS", SqlDbType.Bit)
            SqlParameterEstimateDescription = New System.Data.SqlClient.SqlParameter("@EST_DESC", SqlDbType.Bit)
            SqlParameterEstimateComments = New System.Data.SqlClient.SqlParameter("@EST_COMMENTS", SqlDbType.Bit)
            SqlParameterEstimateFooterComments = New System.Data.SqlClient.SqlParameter("@EST_FOOTER_COMMENTS", SqlDbType.Bit)
            SqlParameterEstimateComponentDescription = New System.Data.SqlClient.SqlParameter("@EST_COMPONENT_DESC", SqlDbType.Bit)
            SqlParameterEstimateComponentComments = New System.Data.SqlClient.SqlParameter("@EST_COMPONENT_COMMENTS", SqlDbType.Bit)
            SqlParameterEstimateQuoteDetailComments = New System.Data.SqlClient.SqlParameter("@EST_QUOTE_DET_COMMENTS", SqlDbType.Bit)
            SqlParameterEstimateQuoteDetailDescription = New System.Data.SqlClient.SqlParameter("@EST_QUOTE_DET_DESC", SqlDbType.Bit)
            SqlParameterCampaignComments = New System.Data.SqlClient.SqlParameter("@CAMP_COMMENTS", SqlDbType.Bit)
            SqlParameterPurchaseOrderDescription = New System.Data.SqlClient.SqlParameter("@PO_DESCRIPTION", SqlDbType.Bit)
            SqlParameterPurchaseOrderMainInstruction = New System.Data.SqlClient.SqlParameter("@PO_MAIN_INSTRUCT", SqlDbType.Bit)
            SqlParameterPurchaseOrderDeliveryInstruction = New System.Data.SqlClient.SqlParameter("@PO_DEL_INSTRUCT", SqlDbType.Bit)
            SqlParameterPurchaseOrderDetailDescription = New System.Data.SqlClient.SqlParameter("@PO_DETAIL_DESC", SqlDbType.Bit)
            SqlParameterPurchaseOrderDetailLineDescription = New System.Data.SqlClient.SqlParameter("@PO_DETAIL_LINE_DESC", SqlDbType.Bit)
            SqlParameterPurchaseOrderDetailInstruction = New System.Data.SqlClient.SqlParameter("@PO_DETAIL_DET_INSTRUCT", SqlDbType.Bit)
            SqlParameterClientPortal = New System.Data.SqlClient.SqlParameter("@CP", SqlDbType.Bit)
            SqlParameterClientPortalID = New System.Data.SqlClient.SqlParameter("@CPID", SqlDbType.Int)
            SqlParameterJobRequest = New System.Data.SqlClient.SqlParameter("@JOB_REQUESTS", SqlDbType.Bit)

            SqlParameterEmployeeCode.Value = EmployeeCode
            SqlParameterUserCode.Value = UserCode
            SqlParameterSearchTerm.Value = SearchTerm
            SqlParameterExactSearch.Value = ExactSearch
            SqlParameterJobsOpen.Value = JobsOpen
            SqlParameterJobsClosed.Value = JobsClosed
            SqlParameterJobsDescription.Value = JobsDescription
            SqlParameterJobsComments.Value = JobsComments
            SqlParameterAlertsStandard.Value = AlertsStandard
            SqlParameterAlertsAssignments.Value = AlertsAssignments
            SqlParameterAlertsSubject.Value = AlertsSubject
            SqlParameterAlertsDescription.Value = AlertsDescription
            SqlParameterAlertsOpen.Value = AlertsOpen
            SqlParameterAlertsDismissedCompleted.Value = AlertsDismissedCompleted
            SqlParameterScheduleComments.Value = ScheduleComments
            SqlParameterScheduleIncludeClosed.Value = ScheduleIncludeClosed
            SqlParameterScheduleTaskIncludeClosed.Value = ScheduleTaskIncludeClosed
            SqlParameterScheduleTaskDescription.Value = ScheduleTaskDescription
            SqlParameterScheduleTaskFunctionComments.Value = ScheduleTaskFunctionComments
            SqlParameterScheduleTaskDueDateComments.Value = ScheduleTaskDueDateComments
            SqlParameterScheduleTaskRevisionDateComments.Value = ScheduleTaskRevisionDateComments
            SqlParameterEstimateDescription.Value = EstimateDescription
            SqlParameterEstimateComments.Value = EstimateComments
            SqlParameterEstimateFooterComments.Value = EstimateFooterComments
            SqlParameterEstimateComponentDescription.Value = EstimateComponentDescription
            SqlParameterEstimateComponentComments.Value = EstimateComponentComments
            SqlParameterEstimateQuoteDetailComments.Value = EstimateQuoteDetailComments
            SqlParameterEstimateQuoteDetailDescription.Value = EstimateQuoteDetailDescription
            SqlParameterCampaignComments.Value = CampaignComments
            SqlParameterPurchaseOrderDescription.Value = PurchaseOrderDescription
            SqlParameterPurchaseOrderMainInstruction.Value = PurchaseOrderMainInstruction
            SqlParameterPurchaseOrderDeliveryInstruction.Value = PurchaseOrderDeliveryInstruction
            SqlParameterPurchaseOrderDetailDescription.Value = PurchaseOrderDetailDescription
            SqlParameterPurchaseOrderDetailLineDescription.Value = PurchaseOrderDetailLineDescription
            SqlParameterPurchaseOrderDetailInstruction.Value = PurchaseOrderDetailInstruction
            SqlParameterClientPortal.Value = ClientPortal
            SqlParameterClientPortalID.Value = ClientPortalID
            SqlParameterJobRequest.Value = JobRequest

            Load = DbContext.Database.SqlQuery(Of Database.Classes.Search)("EXEC dbo.usp_wv_SearchAll @EMP_CODE, @USER_CODE, @SEARCH_TERM, @EXACT_SEARCH, @JOBS_OPEN, @JOBS_CLOSED, @JOBS_DESC, @JOBS_COMMENTS, @ALERTS_STANDARD, @ALERTS_ASSIGNMENTS, @ALERTS_SUBJECT, @ALERTS_DESC, @ALERTS_OPEN, @ALERTS_DISMISSED_COMPLETED, @SCHED_COMMENTS, @SCHED_INCL_CLOSED, @SCHED_TASK_INCL_CLOSED, @SCHED_TASK_DESC, @SCHED_TASK_FNC_COMMENTS, @SCHED_TASK_DUE_DATE_COMMENTS, @SCHED_TASK_REV_DATE_COMMENTS, @EST_DESC, @EST_COMMENTS, @EST_COMPONENT_DESC, @EST_COMPONENT_COMMENTS, @EST_FOOTER_COMMENTS, @EST_QUOTE_DET_COMMENTS, @EST_QUOTE_DET_DESC, @CAMP_COMMENTS, @PO_DESCRIPTION, @PO_MAIN_INSTRUCT, @PO_DEL_INSTRUCT, @PO_DETAIL_DESC, @PO_DETAIL_LINE_DESC, @PO_DETAIL_DET_INSTRUCT, @CP, @CPID, @JOB_REQUESTS",
                                                                           SqlParameterEmployeeCode,
                                                                           SqlParameterUserCode,
                                                                           SqlParameterSearchTerm,
                                                                           SqlParameterExactSearch,
                                                                           SqlParameterJobsOpen,
                                                                           SqlParameterJobsClosed,
                                                                           SqlParameterJobsDescription,
                                                                           SqlParameterJobsComments,
                                                                           SqlParameterAlertsStandard,
                                                                           SqlParameterAlertsAssignments,
                                                                           SqlParameterAlertsSubject,
                                                                           SqlParameterAlertsDescription,
                                                                           SqlParameterAlertsOpen,
                                                                           SqlParameterAlertsDismissedCompleted,
                                                                           SqlParameterScheduleComments,
                                                                           SqlParameterScheduleIncludeClosed,
                                                                           SqlParameterScheduleTaskIncludeClosed,
                                                                           SqlParameterScheduleTaskDescription,
                                                                           SqlParameterScheduleTaskFunctionComments,
                                                                           SqlParameterScheduleTaskDueDateComments,
                                                                           SqlParameterScheduleTaskRevisionDateComments,
                                                                           SqlParameterEstimateDescription,
                                                                           SqlParameterEstimateComments,
                                                                           SqlParameterEstimateFooterComments,
                                                                           SqlParameterEstimateComponentDescription,
                                                                           SqlParameterEstimateComponentComments,
                                                                           SqlParameterEstimateQuoteDetailComments,
                                                                           SqlParameterEstimateQuoteDetailDescription,
                                                                           SqlParameterCampaignComments,
                                                                           SqlParameterPurchaseOrderDescription,
                                                                           SqlParameterPurchaseOrderMainInstruction,
                                                                           SqlParameterPurchaseOrderDeliveryInstruction,
                                                                           SqlParameterPurchaseOrderDetailDescription,
                                                                           SqlParameterPurchaseOrderDetailLineDescription,
                                                                           SqlParameterPurchaseOrderDetailInstruction,
                                                                           SqlParameterClientPortal,
                                                                           SqlParameterClientPortalID,
                                                                           SqlParameterJobRequest).ToList

        End Function

#End Region

    End Module

End Namespace
