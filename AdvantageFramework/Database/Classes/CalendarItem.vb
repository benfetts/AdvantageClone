Namespace Database.Classes

    <Serializable()>
    Public Class CalendarItem

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EMPCODE
            EMPFNAME
            EMPMI
            EMPLNAME
            EMPFMLNAME
            EMPFMLNAMEGROUP
            CLCODE
            DIVCODE
            PRDCODE
            JOBNUMBER
            JOBCOMPONENTNBR
            CLNAME
            DIVNAME
            PRDDESCRIPTION
            JOBDESC
            JOBCOMPDESC
            TASKNONTASKDISPLAY
            TASKNONTASKDESCRIPTION
            TASKSTATUS
            TASKSEQNBR
            FNCCODE
            TASKDESCRIPTION
            TASKHOURSALLOWED
            TRFCODE
            TRFDESCRIPTION
            THISDAY
            STARTDAY
            ENDDAY
            ALLDAY
            NUMDAYS
            TASKTEMPCOMPLETEDATE
            STARTDATE
            ENDDATE
            STARTTIME
            ENDTIME
            WEEKVIEWENDTIME
            HASTIME
            NONTASKID
            NONTASKTYPE
            NONTASKHOURS
            NONTASKCATEGORY
            ISNONTASK
            WEEKVIEWALLDAY
            RECTYPE
            RECORDER
            ICALID
            ADNBR
            ADNBRDESC
            ADNBRCOLOR
            RESOURCECODE
            RESOURCEDESC
            PRIORITY
            HoursAllowed
            DUETIME
            EMPDESCHRS
            REMINDER
            RECURRENCE
            RECURRENCEPARENT
            RESOURCETYPE
            EMP_CODE_HOURS
            EMP_NAME_HOURS
            ALERT_ID
            SPRINT_ID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID() As Integer

        Public Property EMP_CODE() As String

        Public Property EMP_FNAME() As String

        Public Property EMP_MI() As String

        Public Property EMP_LNAME() As String

        Public Property EMP_FML_NAME() As String

        Public Property EMP_FML_NAME_GROUP() As String

        Public Property CL_CODE() As String

        Public Property DIV_CODE() As String

        Public Property PRD_CODE() As String

        Public Property JOB_NUMBER() As Nullable(Of Integer)

        Public Property JOB_COMPONENT_NBR() As Nullable(Of Short)

        Public Property CL_NAME() As String

        Public Property DIV_NAME() As String

        Public Property PRD_DESCRIPTION() As String

        Public Property JOB_DESC() As String

        Public Property JOB_COMP_DESC() As String

        Public Property TASK_NON_TASK_DISPLAY() As String

        Public Property TASK_NON_TASK_DESCRIPTION() As String

        Public Property TASK_STATUS() As String

        Public Property TASK_SEQ_NBR() As Nullable(Of Integer)

        Public Property FNC_CODE() As String

        Public Property TASK_DESCRIPTION() As String

        Public Property TASK_HOURS_ALLOWED() As Nullable(Of Decimal)

        Public Property TRF_CODE() As String

        Public Property TRF_DESCRIPTION() As String

        Public Property THIS_DAY() As Nullable(Of Integer)

        Public Property START_DAY() As Nullable(Of Integer)

        Public Property END_DAY() As Nullable(Of Integer)

        Public Property ALL_DAY() As Nullable(Of Integer)

        Public Property NUM_DAYS() As Nullable(Of Integer)

        Public Property TASK_TEMP_COMPLETE_DATE() As Nullable(Of Date)

        Public Property START_DATE() As Nullable(Of Date)

        Public Property END_DATE() As Nullable(Of Date)

        Public Property START_TIME() As Nullable(Of Date)

        Public Property END_TIME() As Nullable(Of Date)

        Public Property WEEK_VIEW_END_TIME() As Nullable(Of Date)

        Public Property HAS_TIME() As Nullable(Of Short)

        Public Property NON_TASK_ID() As Nullable(Of Integer)

        Public Property NON_TASK_TYPE() As String

        Public Property NON_TASK_HOURS() As Nullable(Of Decimal)

        Public Property NON_TASK_CATEGORY() As String

        Public Property IS_NON_TASK() As Nullable(Of Short)

        Public Property WEEK_VIEW_ALL_DAY() As Nullable(Of Boolean)

        Public Property REC_TYPE() As String

        Public Property REC_ORDER() As Nullable(Of Short)

        Public Property ICAL_ID() As String

        Public Property AD_NBR() As String

        Public Property AD_NBR_DESC() As String

        Public Property AD_NBR_COLOR() As String

        Public Property RESOURCE_CODE() As String

        Public Property RESOURCE_DESC() As String

        Public Property PRIORITY() As String

        Public Property HoursAllowed() As String

        Public Property DUE_TIME() As String

        Public Property EMP_DESC_HRS() As String

        Public Property REMINDER() As String

        Public Property RECURRENCE() As String

        Public Property RECURRENCE_PARENT() As Nullable(Of Integer)

        Public Property RESOURCE_TYPE() As String

        Public Property EMP_CODE_HOURS() As String

        Public Property EMP_NAME_HOURS() As String

        Public Property ALERT_ID As Nullable(Of Integer)
        Public Property SPRINT_ID As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
