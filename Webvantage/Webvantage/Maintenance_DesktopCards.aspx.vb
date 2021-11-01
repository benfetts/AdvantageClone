Imports Telerik.Web.UI

Public Class Maintenance_DesktopCards
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Page "

    Private Sub DesktopCards_Options_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Me.IsClientPortal = True Then
            Me.DivAssignments.Visible = False
        End If
    End Sub
    Private Sub DesktopCards_Options_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.DivAssignments.Visible = Not Me.IsClientPortal

            Dim Settings As DesktopCardSettings

            Dim AlertAppVars As New cAppVars(cAppVars.Application.ALERT_CARDS)
            AlertAppVars.getAllAppVars()

            Try

                Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(AlertAppVars.getAppVar("settings", "String", ""))

            Catch ex As Exception
                Settings = Nothing
            End Try

            If Settings Is Nothing Then Settings = New DesktopCardSettings
            Me.CheckBoxShowClientNameAlerts.Checked = Settings.ShowClientName
            Me.CheckBoxShowJobNumberAlerts.Checked = Settings.ShowJobNumber
            Me.CheckBoxShowJobComponentNumberAlerts.Checked = Settings.ShowJobComponentNumber
            Me.CheckBoxShowJobDescriptionAlerts.Checked = Settings.ShowJobDescription
            Me.CheckBoxShowJobComponentDescriptionAlerts.Checked = Settings.ShowJobComponentDescription

            Settings = Nothing

            Dim AssignmentAppVars As New cAppVars(cAppVars.Application.ASSIGNMENT_CARDS)
            AssignmentAppVars.getAllAppVars()

            Try

                Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(AssignmentAppVars.getAppVar("settings", "String", ""))

            Catch ex As Exception
                Settings = Nothing
            End Try

            If Settings Is Nothing Then Settings = New DesktopCardSettings
            Me.CheckBoxShowClientNameAssignments.Checked = Settings.ShowClientName
            Me.CheckBoxShowJobNumberAssignments.Checked = Settings.ShowJobNumber
            Me.CheckBoxShowJobComponentNumberAssignments.Checked = Settings.ShowJobComponentNumber
            Me.CheckBoxShowJobDescriptionAssignments.Checked = Settings.ShowJobDescription
            Me.CheckBoxShowJobComponentDescriptionAssignments.Checked = Settings.ShowJobComponentDescription

            Settings = Nothing

            Dim TaskAppVars As New cAppVars(cAppVars.Application.TASK_CARDS)
            TaskAppVars.getAllAppVars()

            Try

                Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(TaskAppVars.getAppVar("settings", "String", ""))

            Catch ex As Exception
                Settings = Nothing
            End Try

            If Settings Is Nothing Then Settings = New DesktopCardSettings
            Me.CheckBoxShowClientNameTasks.Checked = Settings.ShowClientName
            Me.CheckBoxShowJobNumberTasks.Checked = Settings.ShowJobNumber
            Me.CheckBoxShowJobComponentNumberTasks.Checked = Settings.ShowJobComponentNumber
            Me.CheckBoxShowJobDescriptionTasks.Checked = Settings.ShowJobDescription
            Me.CheckBoxShowJobComponentDescriptionTasks.Checked = Settings.ShowJobComponentDescription
            Me.CheckBoxShowTaskCommentTasks.Checked = Settings.ShowTaskComment

            Settings = Nothing

            If cApplication.IsProofingToolActive(_Session) = True Then

                Me.DivReviewSettings.Visible = True

                Dim ReviewAppVars As New cAppVars(cAppVars.Application.REVIEW_CARDS)
                ReviewAppVars.getAllAppVars()

                Try

                    Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(ReviewAppVars.getAppVar("settings", "String", ""))

                Catch ex As Exception
                    Settings = Nothing
                End Try

                If Settings Is Nothing Then Settings = New DesktopCardSettings
                Me.CheckBoxShowClientNameReviews.Checked = Settings.ShowClientName
                Me.CheckBoxShowJobNumberReviews.Checked = Settings.ShowJobNumber
                Me.CheckBoxShowJobComponentNumberReviews.Checked = Settings.ShowJobComponentNumber
                Me.CheckBoxShowJobDescriptionReviews.Checked = Settings.ShowJobDescription
                Me.CheckBoxShowJobComponentDescriptionReviews.Checked = Settings.ShowJobComponentDescription
                Me.CheckBoxShowReviewInstructions.Checked = Settings.ShowReviewInstructions

            Else

                Me.DivReviewSettings.Visible = False

            End If

            Settings = Nothing

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "MyTasks", "ddType")
            If taskVar <> "" Then
                Me.RadComboBoxTaskStatus.SelectedValue = taskVar
            Else
                Me.RadComboBoxTaskStatus.SelectedValue = "All"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "MyTasks", "ddTaskShow")
            If taskVar <> "" Then
                Me.RadComboBoxTasks.SelectedValue = taskVar
            Else
                Me.RadComboBoxTasks.SelectedValue = "All"
            End If
            taskVar = otask.getAppVars(Session("UserCode"), "MyTasks", "TodayOnlyStartDue")
            If String.IsNullOrWhiteSpace(taskVar) = False AndAlso taskVar.ToLower = "true" Then
                Me.CheckBoxTodayOnlyWithStartDue.Checked = True
            Else
                Me.CheckBoxTodayOnlyWithStartDue.Checked = False
            End If


        End If

    End Sub

#End Region
#Region " Controls "

    Protected Sub CheckBoxShow_CheckedChanged(sender As Object, e As EventArgs)

        Dim CheckBox As CheckBox = sender
        Dim Settings As DesktopCardSettings

        If CheckBox.ID.EndsWith("Assignments") Then

            Dim av As New cAppVars(cAppVars.Application.ASSIGNMENT_CARDS)
            av.getAllAppVars()
            Try

                Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(av.getAppVar("settings", "String", ""))

            Catch ex As Exception
                Settings = Nothing
            End Try

            If Settings Is Nothing Then Settings = New DesktopCardSettings

            Settings.ShowClientName = CheckBoxShowClientNameAssignments.Checked
            Settings.ShowJobNumber = CheckBoxShowJobNumberAssignments.Checked
            Settings.ShowJobComponentNumber = CheckBoxShowJobComponentNumberAssignments.Checked
            Settings.ShowJobDescription = CheckBoxShowJobDescriptionAssignments.Checked
            Settings.ShowJobComponentDescription = CheckBoxShowJobComponentDescriptionAssignments.Checked

            av.setAppVar("settings", Newtonsoft.Json.JsonConvert.SerializeObject(Settings), "String")
            av.SaveAllAppVars()

        ElseIf CheckBox.ID.EndsWith("Alerts") Then

            Dim av As New cAppVars(cAppVars.Application.ALERT_CARDS)
            av.getAllAppVars()
            Try

                Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(av.getAppVar("settings", "String", ""))

            Catch ex As Exception
                Settings = Nothing
            End Try

            If Settings Is Nothing Then Settings = New DesktopCardSettings

            Settings.ShowClientName = CheckBoxShowClientNameAlerts.Checked
            Settings.ShowJobNumber = CheckBoxShowJobNumberAlerts.Checked
            Settings.ShowJobComponentNumber = CheckBoxShowJobComponentNumberAlerts.Checked
            Settings.ShowJobDescription = CheckBoxShowJobDescriptionAlerts.Checked
            Settings.ShowJobComponentDescription = CheckBoxShowJobComponentDescriptionAlerts.Checked

            av.setAppVar("settings", Newtonsoft.Json.JsonConvert.SerializeObject(Settings), "String")
            av.SaveAllAppVars()

        ElseIf CheckBox.ID.EndsWith("Tasks") Then

            Dim av As New cAppVars(cAppVars.Application.TASK_CARDS)
            av.getAllAppVars()
            Try

                Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(av.getAppVar("settings", "String", ""))

            Catch ex As Exception
                Settings = Nothing
            End Try

            If Settings Is Nothing Then Settings = New DesktopCardSettings

            Settings.ShowClientName = CheckBoxShowClientNameTasks.Checked
            Settings.ShowJobNumber = CheckBoxShowJobNumberTasks.Checked
            Settings.ShowJobComponentNumber = CheckBoxShowJobComponentNumberTasks.Checked
            Settings.ShowJobDescription = CheckBoxShowJobDescriptionTasks.Checked
            Settings.ShowJobComponentDescription = CheckBoxShowJobComponentDescriptionTasks.Checked

            Settings.ShowTaskComment = CheckBoxShowTaskCommentTasks.Checked

            av.setAppVar("settings", Newtonsoft.Json.JsonConvert.SerializeObject(Settings), "String")
            av.SaveAllAppVars()

        ElseIf CheckBox.ID.EndsWith("Reviews") Then

            Dim av As New cAppVars(cAppVars.Application.REVIEW_CARDS)
            av.getAllAppVars()
            Try

                Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(av.getAppVar("settings", "String", ""))

            Catch ex As Exception
                Settings = Nothing
            End Try

            If Settings Is Nothing Then Settings = New DesktopCardSettings

            Settings.ShowClientName = CheckBoxShowClientNameReviews.Checked
            Settings.ShowJobNumber = CheckBoxShowJobNumberReviews.Checked
            Settings.ShowJobComponentNumber = CheckBoxShowJobComponentNumberReviews.Checked
            Settings.ShowJobDescription = CheckBoxShowJobDescriptionReviews.Checked
            Settings.ShowJobComponentDescription = CheckBoxShowJobComponentDescriptionReviews.Checked

            Settings.ShowReviewInstructions = CheckBoxShowReviewInstructions.Checked

            av.setAppVar("settings", Newtonsoft.Json.JsonConvert.SerializeObject(Settings), "String")
            av.SaveAllAppVars()

        End If

    End Sub

    Private Sub RadComboBoxTaskStatus_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxTaskStatus.SelectedIndexChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyTasks", "ddType", "", Me.RadComboBoxTaskStatus.SelectedValue)

    End Sub

    Private Sub RadComboBoxTasks_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxTasks.SelectedIndexChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyTasks", "ddTaskShow", "", Me.RadComboBoxTasks.SelectedValue)
        otask.setAppVars(Session("UserCode"), "MyTasks", "TodayOnlyStartDue", "", CheckBoxTodayOnlyWithStartDue.Checked)

    End Sub
    Private Sub CheckBoxTodayOnlyWithStartDue_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTodayOnlyWithStartDue.CheckedChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyTasks", "TodayOnlyStartDue", "", CheckBoxTodayOnlyWithStartDue.Checked)

    End Sub

#End Region

#End Region

End Class

<Serializable()>
Public Class DesktopCardSettings

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum SettingType

        Alerts
        Assignments
        Tasks
        Reviews

    End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property ShowClientName As Boolean = False
    Public Property ShowJobNumber As Boolean = False
    Public Property ShowJobComponentNumber As Boolean = False
    Public Property ShowJobDescription As Boolean = False
    Public Property ShowJobComponentDescription As Boolean = False
    Public Property ShowTaskComment As Boolean = False
    Public Property ShowState As Boolean = False
    Public Property ShowReviewInstructions As Boolean = False
    Public Property DefaultSort As String = String.Empty

    Private Property SecuritySession As AdvantageFramework.Security.Session = Nothing
    Private Property DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private Property Type As SettingType

#End Region

#Region " Methods "

    'Public Sub Load()

    '    If DbContext IsNot Nothing AndAlso SecuritySession IsNot Nothing Then

    '        Dim SettingsString As String = String.Empty

    '        Try

    '            SettingsString = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(VARIABLE_VALUE, '') FROM APP_VARS WITH(NOLOCK) WHERE USERID = '{0}' AND [APPLICATION] = '{1}';",
    '                                                                              SecuritySession.UserCode, Type.ToString)).SingleOrDefault

    '        Catch ex As Exception
    '            SettingsString = String.Empty
    '        End Try

    '        If String.IsNullOrWhiteSpace(SettingsString) = False Then



    '        End If

    '    End If

    'End Sub

    Public Sub New()

    End Sub
    'Public Sub New(ByVal SettingType As SettingType)

    '    Me.Type = SettingType

    'End Sub
    'Public Sub New(ByVal SettingType As SettingType, ByVal SecuritySession As AdvantageFramework.Security.Session)

    '    Me.Type = SettingType
    '    Me.SecuritySession = SecuritySession

    'End Sub
    'Public Sub New(ByVal SettingType As SettingType, ByVal SecuritySession As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext)

    '    Me.Type = SettingType
    '    Me.SecuritySession = SecuritySession
    '    Me.DbContext = DbContext

    'End Sub

#End Region

End Class
