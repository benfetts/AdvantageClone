Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Data.SqlClient
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports System.Data.Entity.Core.Objects
Imports System.Collections

Namespace AdvantageMobile.DataService.Alert

    <System.Serializable()> Public Class Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Clients As Dictionary(Of String, String)

#End Region

#Region " Properties "

        Private Property _DataEntities As DataEntities
        Private Property _DataServiceUser As DataServiceUser
        Private Property _ConnectionString As String = ""
        Private Property _UserCode As String = ""

#End Region

#Region " Methods "

        Public Function DismissCompleteAlert(ByVal AlertID As Integer, ByVal EmployeeCode As String,
                                             ByVal ForceAssignmentComplete As Boolean,
                                             ByRef ErrorMessage As String) As Boolean

            Dim DismissedCompleted As Boolean = False
            Dim PromptForFullTaskComplete As Boolean = False
            Dim PromptForTempTaskComplete As Boolean = False
            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                    If ForceAssignmentComplete = False Then

                        DismissedCompleted = AdvantageFramework.AlertSystem.DismissAlert(DbContext,
                                                                    AlertID, EmployeeCode, Me._UserCode,
                                                                    0, ForceAssignmentComplete,
                                                                    PromptForFullTaskComplete, PromptForTempTaskComplete,
                                                                    ErrorMessage)

                    Else

                        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
                        Dim Result As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing

                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                        If Alert IsNot Nothing Then

                            Result = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, Alert, EmployeeCode, Me._UserCode, Nothing, Nothing)

                            If Result IsNot Nothing Then

                                DismissedCompleted = Result.Success

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception

            End Try

            Return DismissedCompleted

        End Function

        Public Function GetAlertAttachments(ByVal AlertID As Integer, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As ObjectResult(Of AlertAttachmentsList)

            Dim EmployeeCode As String = String.Empty
            Dim OffSet As Decimal = 0.0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_DataServiceUser.ConnectionString, _DataServiceUser.UserCode)
                    Dim Employee As AdvantageFramework.Database.Views.Employee

                    Employee = Nothing


                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, Me._DataServiceUser.UserCode)


                    If Employee IsNot Nothing Then

                        EmployeeCode = Employee.Code
                        OffSet = AdvantageFramework.Database.Procedures.Generic.LoadEmployeeHoursOffset(DbContext, EmployeeCode)

                    End If

                End Using

            Catch ex As Exception
                EmployeeCode = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                Return Me._DataEntities.GetAlertAttachments(AlertID, EmployeeCode, OffSet)

            Else

                Return Nothing

            End If

        End Function
        Public Function GetAlertComments(ByVal AlertID As Integer, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As ObjectResult(Of AlertCommentsList)

            Dim EmployeeCode As String = String.Empty
            Dim OffSet As Decimal = 0.0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_DataServiceUser.ConnectionString, _DataServiceUser.UserCode)

                    Dim Employee As AdvantageFramework.Database.Views.Employee
                    Employee = Nothing

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, Me._DataServiceUser.UserCode)

                    If Employee IsNot Nothing Then

                        EmployeeCode = Employee.Code
                        OffSet = AdvantageFramework.Database.Procedures.Generic.LoadEmployeeHoursOffset(DbContext, EmployeeCode)

                    End If

                End Using

            Catch ex As Exception
                EmployeeCode = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                Return Me._DataEntities.GetAlertComments(AlertID, EmployeeCode, OffSet, True)

            Else

                Return Nothing

            End If

        End Function
        Public Function GetAlertRecipients(ByVal AlertID As Integer,
                                           ByVal Filter As String,
                                           ByVal Sort As String,
                                           ByVal Skip As Integer, ByVal Take As Integer) As IQueryable(Of advtf_alert_recipient_get_Result)

            Return (From Entity In Me._DataEntities.advtf_alert_recipient_get(AlertID)
                    Where Entity.IsCurrentRecipient = True
                    Select Entity)

        End Function
        Public Function GetAlertAssignees(ByVal AlertID As Integer) As IQueryable(Of advtf_alert_recipient_get_Result)

            Return (From Entity In Me._DataEntities.advtf_alert_recipient_get(AlertID)
                    Where Entity.IsCurrentNotify = True
                    Select Entity)

        End Function

        Public Function GetAlerts(ByVal EmployeeCode As String, ByVal SearchValue As String,
                                  ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer,
                                  ByVal Take As Integer) As IQueryable(Of Global.AdvantageMobile.Alert)

            Dim s As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Me._ConnectionString, Me._UserCode, 0, Me._ConnectionString)
            Dim d As New AdvantageFramework.Controller.Dashboard.DashboardController(s)
            Dim CardGroups As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup) = Nothing
            Dim AssignmentsCount As Integer
            Dim AlertsCount As Integer
            Dim ListOfAlertID As New Generic.List(Of Integer)

            s.User.EmployeeCode = EmployeeCode

            SearchValue = SearchValue.Trim()

            If s IsNot Nothing Then

                CardGroups = d.GetDashboardCardGroups(AdvantageFramework.Controller.Dashboard.DashboardController.DashboardType.Alerts,
                                                      "", SearchValue, False, 0, 0, AssignmentsCount, AlertsCount)

                If CardGroups IsNot Nothing Then

                    For Each group In CardGroups

                        If group.Cards IsNot Nothing And group.Cards.Count > 0 Then

                            For Each Card In group.Cards

                                ListOfAlertID.Add(Card.AlertID)

                            Next

                        End If

                    Next

                End If

            End If

            'GetAlerts = GetAlertsAndAssignments(EmployeeCode).Where(Function(Alert) Alert.AlertRecipient.Any(Function(AlertRecipient) AlertRecipient.IsAssignee Is Nothing OrElse If(AlertRecipient.IsAssignee, 0) = 0))
            Dim query As IQueryable(Of Global.AdvantageMobile.Alert)
            Dim list As New List(Of Integer)

            query = (From Alert In Me._DataEntities.Alerts
                     Where ListOfAlertID.Contains(Alert.ID)
                     Order By Alert.LastUpdatedDate Descending
                     Select Alert)

            Return query.Skip(Skip).Take(Take)

        End Function
        Public Function GetAssignments(ByVal EmployeeCode As String, ByVal SearchValue As String,
                                       ByVal Filter As String, ByVal Sort As String,
                                       ByVal Skip As Integer, ByVal Take As Integer) As IQueryable(Of Global.AdvantageMobile.Alert)

            Dim s As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Me._ConnectionString, Me._UserCode, 0, Me._ConnectionString)
            Dim d As New AdvantageFramework.Controller.Dashboard.DashboardController(s)
            Dim CardGroups As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup) = Nothing
            Dim AssignmentsCount As Integer
            Dim AlertsCount As Integer
            Dim ListOfAlertID As New Generic.List(Of Integer)

            s.User.EmployeeCode = EmployeeCode
            SearchValue = SearchValue.Trim()

            If s IsNot Nothing Then

                CardGroups = d.GetDashboardCardGroups(AdvantageFramework.Controller.Dashboard.DashboardController.DashboardType.Assignments,
                                                      "", SearchValue, False, 0, 0, AssignmentsCount, AlertsCount)

                If CardGroups IsNot Nothing Then

                    For Each group In CardGroups

                        If group.Cards IsNot Nothing And group.Cards.Count > 0 Then

                            For Each Card In group.Cards

                                ListOfAlertID.Add(Card.AlertID)

                            Next

                        End If

                    Next

                End If

            End If

            Dim query As IQueryable(Of Global.AdvantageMobile.Alert)
            Dim list As New List(Of Integer)

            query = (From Alert In Me._DataEntities.Alerts
                     Where ListOfAlertID.Contains(Alert.ID)
                     Order By Alert.LastUpdatedDate Descending
                     Select Alert)

            Return query.Skip(Skip).Take(Take)

        End Function
        Public Function GetAlertsAndAssignments(ByVal EmployeeCode As String, ByVal SearchValue As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As IQueryable(Of Global.AdvantageMobile.Alert)

            Dim query As IQueryable(Of Global.AdvantageMobile.Alert)
            Dim list As New List(Of Integer)

            list = (From Alert In Me._DataEntities.Alerts
                    Join AlertRecipients In Me._DataEntities.AlertRecipients
                    On Alert.ID Equals AlertRecipients.AlertID
                    Where AlertRecipients.EmployeeCode = EmployeeCode
                    Order By Alert.LastUpdatedDate Descending
                    Select Alert.ID).Distinct().ToList()

            query = (From Alert In Me._DataEntities.Alerts
                     Where list.Contains(Alert.ID)
                     Order By Alert.ID
                     Select Alert)

            SearchValue = SearchValue.Trim()

            If SearchValue <> "" Then

                Dim SearchFor As Application.SearchFor = Application.SearchFor.Standard
                Dim JobNumber As Integer = 0
                Dim JobComponentNumber As Short = 0

                SearchFor = AdvantageMobile.DataService.Application.GetSearchType(SearchValue, JobNumber, JobComponentNumber)

                Select Case SearchFor
                    Case Application.SearchFor.Standard

                        query = query.Where(Function(Alert) Alert.Subject.ToUpper().Contains(SearchValue.ToUpper())) ' OrElse Alert.Body.ToUpper().Contains(SearchValue.ToUpper()))

                    Case Application.SearchFor.JobNumber

                        query = query.Where(Function(Alert) Alert.JobNumber = JobNumber)

                    Case Application.SearchFor.JobNumberAndJobComponentNumber

                        query = query.Where(Function(Alert) Alert.JobNumber = JobNumber And Alert.JobComponentNumber = JobComponentNumber)

                End Select

            End If

            Return query.Skip(Skip).Take(Take)

        End Function
        Public Function GetAssignmentTemplates() As IQueryable(Of Global.AdvantageMobile.AlertAssignmentTemplate)

            GetAssignmentTemplates = (From AssignmentTemplate In Me._DataEntities.AlertAssignmentTemplates
                                      Where (AssignmentTemplate.IsActive = True OrElse AssignmentTemplate.IsActive Is Nothing)
                                      Order By AssignmentTemplate.Name
                                      Select AssignmentTemplate)

        End Function
        Public Function GetAssignmentTemplateStates(ByVal AssignmentTemplateID As Integer) As IQueryable(Of Global.AdvantageMobile.AlertAssignmentState)

            GetAssignmentTemplateStates = (From AlertAssignmentState In Me._DataEntities.AlertAssignmentStates
                                           Join aats In Me._DataEntities.AlertAssignmentTemplateStates
                                           On AlertAssignmentState.ID Equals aats.AlertAssignmentStateID
                                           Where (AlertAssignmentState.IsActive = True OrElse AlertAssignmentState.IsActive Is Nothing) _
                                           AndAlso aats.AlertAssignmentTemplateID = AssignmentTemplateID
                                           Order By aats.SortOrder
                                           Select AlertAssignmentState)
        End Function
        Public Function GetAssignmentTemplateStateEmployees(ByVal AssignmentTemplateID As Integer, ByVal AssignmentStateID As Integer, ByVal ShowAllActive As Boolean) As IQueryable(Of Global.AdvantageMobile.Employee)

            If ShowAllActive = True Then

                GetAssignmentTemplateStateEmployees = (From Employee In Me._DataEntities.Employees
                                                       Where (Employee.TerminatedDate Is Nothing OrElse (Employee.TerminatedDate IsNot Nothing AndAlso Employee.TerminatedDate >= Today.Date))
                                                       Order By Employee.FirstName, Employee.MiddleInitial, Employee.LastName
                                                       Select Employee)

            Else

                GetAssignmentTemplateStateEmployees = (From Employee In Me._DataEntities.Employees
                                                       Join aate In Me._DataEntities.AlertAssignmentTemplateEmployees
                                                       On Employee.Code Equals aate.EmployeeCode
                                                       Where aate.AlertAssignmentTemplate.ID = AssignmentTemplateID _
                                                       AndAlso aate.AlertAssignmentState.ID = AssignmentStateID _
                                                       AndAlso (Employee.TerminatedDate Is Nothing OrElse (Employee.TerminatedDate IsNot Nothing AndAlso Employee.TerminatedDate >= Today.Date))
                                                       Order By Employee.FirstName, Employee.MiddleInitial, Employee.LastName
                                                       Select Employee)

            End If

        End Function
        Public Function GetAssignmentTemplateStateDetails(ByVal AssignmentTemplateID As Integer, ByVal AssignmentStateID As Integer) As Global.AdvantageMobile.AlertAssignmentTemplateState

            Dim aats As Global.AdvantageMobile.AlertAssignmentTemplateState

            aats = (From AlertAssignmentTemplateState In Me._DataEntities.AlertAssignmentTemplateStates
                    Where AlertAssignmentTemplateState.AlertAssignmentTemplateID = AssignmentTemplateID _
                    AndAlso AlertAssignmentTemplateState.AlertAssignmentStateID = AssignmentStateID
                    Select AlertAssignmentTemplateState).SingleOrDefault()

            Return aats

        End Function
        Public Function GetAlertAssignedEmployee(ByVal AlertID As Integer) As Global.AdvantageMobile.Employee

            Dim emp As Global.AdvantageMobile.Employee = Nothing

            Try

                emp = (From Employee In Me._DataEntities.Employees
                       Join Alert In Me._DataEntities.Alerts On Employee.Code Equals Alert.ASSIGNED_EMP_CODE
                       Where Alert.ID = AlertID
                       Select Employee).FirstOrDefault

            Catch ex As Exception
                emp = Nothing
            End Try
            If emp Is Nothing Then

                Dim Assignees As Generic.List(Of advtf_alert_recipient_get_Result) = Nothing

                Assignees = GetAlertAssignees(AlertID).ToList()

                If Assignees IsNot Nothing Then

                    'If Assignees.Count = 1 Then

                    For Each Assignee As advtf_alert_recipient_get_Result In Assignees

                        Try

                            emp = (From Entity In Me._DataEntities.Employees
                                   Where Entity.Code = Assignee.EmployeeCode
                                   Select Entity).SingleOrDefault

                        Catch ex As Exception
                        End Try

                        Exit For

                    Next

                    'ElseIf Assignees.Count > 1 Then

                    '    'Show "Multiple"? or just get one?


                    'End If

                End If

            End If
            'If emp Is Nothing Then

            '    emp = (From Employee In Me._DataEntities.Employees _
            '           Join dar In Me._DataEntities.DismissedAlertRecipients _
            '           On Employee.Code Equals dar.EmployeeCode _
            '           Where dar.AlertID = AlertID _
            '           AndAlso dar.IsAssignee = 1 _
            '           Select Employee).FirstOrDefault()

            'End If

            Return emp

        End Function

        Public Sub GetClientDisplay(ByRef Alert As Global.AdvantageMobile.Alert)

            If Me._Clients.ContainsKey(Alert.ClientCode) Then

                Alert.ClientDisplay = Me._Clients.Item(Alert.ClientCode)

            Else

                Dim sb As New System.Text.StringBuilder()
                Dim ClientCode As String = Alert.ClientCode
                Dim ClientName As String = ""

                ClientName = Me._DataEntities.Database.SqlQuery(Of String)(String.Format("SELECT CL_NAME FROM CLIENT WITH(NOLOCK) WHERE CL_CODE = '{0}';", ClientCode)).SingleOrDefault()

                With sb
                    .Append(ClientName)

                    If Alert.DivisionCode IsNot Nothing OrElse Alert.ProductCode IsNot Nothing Then

                        .Append(" (")

                        If Alert.DivisionCode IsNot Nothing Then

                            .Append(Alert.DivisionCode)

                        End If
                        If Alert.ProductCode IsNot Nothing Then

                            .Append("|")
                            .Append(Alert.ProductCode)

                        End If

                        .Append(")")

                    End If

                End With

                Alert.ClientDisplay = sb.ToString()
                Me._Clients.Add(Alert.ClientCode, Alert.ClientDisplay)

                sb = Nothing

            End If

        End Sub

        Public Function GetRecipients(ByVal AlertID As Integer,
                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                      ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                      ByVal CampaignIdentifier As Integer, ByVal ClientPortalUserID As Integer) As ObjectResult(Of EmailRecipients)

            GetRecipients = Me._DataEntities.GetRecipients(ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber,
                                                           CampaignIdentifier, ClientPortalUserID, AlertID, _UserCode, False, Nothing)

        End Function

        Public Function NotifiyAlertRecipients(ByVal AlertID As Integer, ByVal IsNew As Boolean, Optional ByVal IncludeOriginator As Boolean = False) As Boolean

            Dim Sent As Boolean = False
            Dim Alert As Global.AdvantageMobile.Alert = Nothing

            Alert = (From Entity In Me._DataEntities.Alerts Where Entity.ID = AlertID Select Entity).FirstOrDefault()

            If Alert IsNot Nothing Then

                Dim IsAssignment As Boolean = Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso Alert.AlertAssignmentTemplateID > 0

                'AdvantageFramework
                Dim Email As New AdvantageFramework.AlertSystem.Classes.AlertEmail(Me._ConnectionString, Me._UserCode)

                Dim SbSubject As New System.Text.StringBuilder

                If IsNew = True AndAlso IsAssignment = False Then

                    SbSubject.Append("[New Alert] ")

                ElseIf IsNew = False AndAlso IsAssignment = False Then

                    SbSubject.Append("[Alert Updated] ")

                ElseIf IsNew = True AndAlso IsAssignment = True Then

                    SbSubject.Append("[New Assignment] ")

                ElseIf IsNew = False AndAlso IsAssignment = True Then

                    SbSubject.Append("[Assignment Updated] ")

                End If

                SbSubject.Append(Alert.Subject)

                If IsAssignment = True OrElse IncludeOriginator = True Then Email.IncludeOriginator = True

                Email.Subject = SbSubject.ToString()
                Email.AlertID = AlertID

                Email.Send()

                Sent = Email.Sent

            End If

            Return Sent

        End Function
        Public Function SaveAlertAssignment(ByVal AlertID As Integer,
                                            ByVal AlertTemplateID As Integer, ByVal AlertStateID As Integer,
                                            ByVal EmployeeCode As String, ByVal UserCode As String,
                                            ByVal Comments As String,
                                            ByVal IsUnassigned As Boolean,
                                            ByVal IsNewAssignment As Boolean,
                                            ByRef ErrorMessage As String) As Boolean

            Dim AllowSave As Boolean = True
            Dim Saved As Boolean? = False
            Dim Assignees As Generic.List(Of advtf_alert_recipient_get_Result) = Nothing

            Try

                Assignees = GetAlertAssignees(AlertID).ToList()

                If Assignees IsNot Nothing AndAlso Assignees.Count > 1 Then

                    AllowSave = False
                    ErrorMessage = "Cannot update a multi-assignee assignment in mobile right now!"

                End If

            Catch ex As Exception
            End Try

            'Temporarily disallow saving with multiple assignees
            If AllowSave = True Then

                Dim ByteIsUnassigned As Byte = 0
                Dim ByteIsNewAssignment As Byte = 0
                Dim ByteSaveUnassigned As Byte = 1

                If IsUnassigned = True Then ByteIsUnassigned = 1
                If IsNewAssignment = True Then ByteIsNewAssignment = 1

                Try

                    Saved = (Me._DataEntities.SaveAlertAssignment(UserCode, AlertID, EmployeeCode, 0,
                             AlertStateID, AlertTemplateID, Comments, ByteIsUnassigned, ByteSaveUnassigned, ByteIsNewAssignment)).FirstOrDefault()

                Catch ex As Exception
                    Saved = False
                End Try

                If Saved Is Nothing Then

                    Saved = False

                End If

                If Saved = True Then

                    Me.NotifiyAlertRecipients(AlertID, IsNewAssignment)

                    '    SaveAlertAssignment = True

                    'Else

                    '    SaveAlertAssignment = False

                End If

            End If

            Return Saved

        End Function
        Public Function SaveAlertComment(ByVal AlertID As Integer, ByVal Comment As String) As Boolean

            Using dc As New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                Return AdvantageFramework.AlertSystem.AddAlertComment(dc, AlertID, Nothing, Comment, Nothing, "")

            End Using

        End Function
        Public Function SaveAlertRecipients(ByVal AlertID As Integer, ByVal Codes As String) As Boolean

            Using dc As New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                Return AdvantageFramework.AlertSystem.AddAlertRecipients(dc, AlertID, Codes)

            End Using

        End Function
        Public Function UpdateAlertAssignment(ByVal AlertID As Integer, ByVal AlertAssignmentTemplateID As Integer, ByVal AlertStateID As Integer,
                                                  ByVal IsUnassigned As Boolean, ByVal EmployeeCode As String, ByVal Comment As String) As String

            Dim Message As String = ""
            Dim AssignmentUpdated As Boolean = False

            Try

                Dim IsUnassignedByte As Byte = 0
                If IsUnassigned = True Then IsUnassignedByte = 1

                Me._DataEntities.SaveAlertAssignment(_UserCode, AlertID, EmployeeCode, 0, AlertStateID, AlertAssignmentTemplateID, Comment, IsUnassignedByte, 1, 0)

            Catch ex As Exception

                AssignmentUpdated = False
                Message = ex.Message.ToString()

            End Try

            If AssignmentUpdated = True Then

                NotifiyAlertRecipients(AlertID, True, False)

            End If

            Return Message

        End Function

        Sub New(ByVal DataSource As Global.AdvantageMobile.DataEntities, ByVal CurrentDataServiceUser As Global.AdvantageMobile.DataServiceUser)

            Me._DataEntities = DataSource
            Me._DataServiceUser = CurrentDataServiceUser
            Me._ConnectionString = CurrentDataServiceUser.ConnectionString
            Me._UserCode = Me._DataServiceUser.UserCode
            Me._Clients = New Dictionary(Of String, String)

        End Sub

#End Region

    End Class

End Namespace

