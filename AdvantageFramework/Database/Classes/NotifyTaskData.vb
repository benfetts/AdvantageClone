Namespace Database.Classes

    <Serializable()>
    Public Class NotifyTaskData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EMPCODE
            CLIENTNAME
            JOBDESC
            COMPONENTDESC
            TASKDESC
            ALERTEMAIL
            COMPONENTNUMBER
            EMAIL
            JOBNUMBER
            DATEDIFF
            COMMENT
            STARTDATE
            DUEDATE
            HOURSALLOWED
            SUPERVISORCODE
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EMP_CODE() As String

        Public Property CLIENT_NAME() As String

        Public Property JOB_DESC() As String

        Public Property COMPONENT_DESC() As String

        Public Property TASK_DESC() As String

        Public Property ALERT_EMAIL() As Nullable(Of Short)

        Public Property COMPONENT_NUMBER() As Short

        Public Property EMAIL() As String

        Public Property JOB_NUMBER() As Integer

        Public Property DATE_DIFF() As Nullable(Of Integer)

        Public Property COMMENT() As String

        Public Property START_DATE() As Nullable(Of Date)

        Public Property DUE_DATE() As Nullable(Of Date)

        Public Property HOURS_ALLOWED() As Nullable(Of Decimal)

        Public Property SUPERVISOR_CODE() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EMP_CODE.ToString

        End Function

#End Region

    End Class

End Namespace
