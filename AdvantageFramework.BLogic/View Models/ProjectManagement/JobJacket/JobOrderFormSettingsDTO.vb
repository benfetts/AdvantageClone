Namespace ViewModels.ProjectManagement.JobJacket

    <Serializable()>
    Public Class JobOrderFormSettingsDTO
#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "
        Property USER_ID As String = ""
        Property JOB_ORDER_FORM As Short
        Property TRAFFIC_SCHED As Short
        Property MILESTONE As Short
        Property DUE_DATE As Short
        Property EMPL_ASSIGN As Short
        Property OMIT_EMPTY_FLDS As Short
        Property TRAFFIC_SCHED_TITLE As String = ""
        Property SCHED_MILESTONE_TITLE As String = ""
        Property CREATIVE_BRIEF_TITLE As String = ""
        Property JOB_SPEC_TITLE As String = ""
        Property REPORT_TITLE_PLACEMENT As String = ""
        Property LOCATION_ID As String = ""
        Property CREATIVE_BRIEF As Short = 0
        Property CREATIVE_BRIEF_AO As Short = 0
        Property JOB_SPECS As Short = 0
        Property JOB_SPECS_AO As Short = 0
        Property TRAFFIC_GENERAL_ASSIGN As Short = 0
        Property KEY_ASSIGN_TITLE As String = ""
        Property SCHED_COMMENTS As Short = 0
        Property VENDOR_SPECS As Short = 0
        Property MEDIA_SPECS As Short = 0
        Property JOB_VERSIONS As Short = 0
        Property OMIT_EMPTY_FLDS_CB As Short = 0
        Property OMIT_EMPTY_FLDS_JV As Short = 0
        Property OMIT_EMPTY_FLDS_JS As Short = 0
#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region


    End Class

End Namespace
