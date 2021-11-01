Imports System.Data.SqlClient

Public Class Alert_RecipientUC
    Inherits Webvantage.BaseChildPageUserControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "
    Private _UseWebService As Boolean = False

    Public Property Width As WebControls.Unit
        Get
            Return Me.RadAutoCompleteBoxEmployees.Width
        End Get
        Set(value As WebControls.Unit)
            Me.RadAutoCompleteBoxEmployees.Width = value
        End Set
    End Property

    Public Property AlertId As Long = 0
    Public Property IsAssignment As Boolean = False

    Public Property ClientCode As String = ""
    Public Property DivisionCode As String = ""
    Public Property ProductCode As String = ""
    Public Property JobNumber As Integer = 0
    Public Property JobComponentNumber As Integer = 0
    Public Property CampaignIdentifier As Integer = 0
    Public Property OnlyConceptShareUsers As Boolean = False
    Public Property ShowAllButMarkConceptShareUsers As Boolean = False
    Public Property EmailGroupCode As String = String.Empty
    Public Property UseWebservice As Boolean
        Get
            Return _UseWebService
        End Get
        Set(value As Boolean)
            _UseWebService = value
            SetDataSource()
        End Set
    End Property

    Public ReadOnly Property Inserted As Boolean
        Get
            Return _Inserted
        End Get
    End Property
    Public ReadOnly Property Deleted As Boolean
        Get
            Return Me._Deleted
        End Get
    End Property

    Private Property _Inserted As Boolean = False
    Private Property _Deleted As Boolean = False

    Private Property _ClientPortalUserId As Integer = 0

#End Region

#Region " Page "

    Private Sub Alert_RecipientUC_Init(sender As Object, e As EventArgs) Handles Me.Init

        If UseWebservice = False Then

            Me.RadAutoCompleteBoxEmployees.WebServiceSettings.Method = Nothing
            Me.RadAutoCompleteBoxEmployees.WebServiceSettings.Path = Nothing
            Me.RadAutoCompleteBoxEmployees.OnClientRequesting = Nothing

        Else

            Me.RadAutoCompleteBoxEmployees.WebServiceSettings.Method = "LoadAutoComplete"
            Me.RadAutoCompleteBoxEmployees.WebServiceSettings.Path = "Alert_View.aspx"
            Me.RadAutoCompleteBoxEmployees.OnClientRequesting = "OnClientRequesting"

        End If

    End Sub
    Protected Sub AutoCompleteEmployeeUC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If UseWebservice = False Then

            Me.LoadData()

        End If

        'Me.RadAutoCompleteBoxEmployees.Focus()

        ''If Me.AlertId > 0 Then

        ''    AddHandler Me.RadAutoCompleteBoxEmployees.EntryAdded, AddressOf Me.RadAutoCompleteBoxEmployees_EntryAdded
        ''    AddHandler Me.RadAutoCompleteBoxEmployees.EntryRemoved, AddressOf Me.RadAutoCompleteBoxEmployees_EntryRemoved

        ''Else

        ''    RemoveHandler Me.RadAutoCompleteBoxEmployees.EntryAdded, AddressOf Me.RadAutoCompleteBoxEmployees_EntryAdded
        ''    RemoveHandler Me.RadAutoCompleteBoxEmployees.EntryRemoved, AddressOf Me.RadAutoCompleteBoxEmployees_EntryRemoved

        ''End If

    End Sub

#End Region

#Region " Controls "

    Public Event RadAutoCompleteBoxEmployeesEntryAdded(sender As Object, e As Telerik.Web.UI.AutoCompleteEntryEventArgs)
    Private Sub RadAutoCompleteBoxEmployees_EntryAdded(sender As Object, e As Telerik.Web.UI.AutoCompleteEntryEventArgs) 'Handles RadAutoCompleteBoxEmployees.EntryAdded

        If Me.AlertId > 0 Then

            Dim cEmp As New Webvantage.cEmployee(HttpContext.Current.Session("ConnString"))
            Using DbContext As New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim ExistingRecipient As New AdvantageFramework.Database.Entities.AlertRecipient
                ExistingRecipient = Nothing

                ExistingRecipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCodeExcludeAssignee(DbContext, Me.AlertId, e.Entry.Value)

                If ExistingRecipient Is Nothing Then

                    Dim Recipient As New AdvantageFramework.Database.Entities.AlertRecipient
                    With Recipient

                        .AlertID = Me.AlertId
                        .EmployeeCode = e.Entry.Value
                        .EmployeeEmail = cEmp.GetEmail(e.Entry.Value)
                        .ID = 0

                    End With

                    Me._Inserted = AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient)

                Else

                    Me.ShowMessage("This person is already a recipient.")
                    Me.RadAutoCompleteBoxEmployees.Entries.Remove(e.Entry)
                    Exit Sub

                End If

            End Using

            RaiseEvent RadAutoCompleteBoxEmployeesEntryAdded(sender, e)

        End If


    End Sub
    Private Sub RadAutoCompleteBoxEmployees_EntryRemoved(sender As Object, e As Telerik.Web.UI.AutoCompleteEntryEventArgs) 'Handles RadAutoCompleteBoxEmployees.EntryRemoved

        If Me.AlertId > 0 Then

            'e.Entry.Value
            Using DbContext As New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim ExistingRecipient As New AdvantageFramework.Database.Entities.AlertRecipient
                ExistingRecipient = Nothing

                ExistingRecipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, Me.AlertId, e.Entry.Value)

                If Not ExistingRecipient Is Nothing Then

                    If ExistingRecipient.HasBeenRead Is Nothing AndAlso ExistingRecipient.IsNewAlert Is Nothing AndAlso ExistingRecipient.ProcessedDate Is Nothing AndAlso
                        ExistingRecipient.IsCurrentNotify Is Nothing Then

                        AdvantageFramework.Database.Procedures.AlertRecipient.Delete(DbContext, ExistingRecipient)
                        Me._Deleted = True

                    Else

                        Me.ShowMessage("Cannot remove a recipient that has read the alert")
                        Exit Sub

                    End If

                Else

                    Dim DismissedRecipient As New AdvantageFramework.Database.Entities.AlertRecipientDismissed
                    DismissedRecipient = Nothing

                    DismissedRecipient = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertIDAndEmployeeCode(DbContext, Me.AlertId, e.Entry.Value)

                    If Not DismissedRecipient Is Nothing Then

                        'If DismissedRecipient.HasBeenRead Is Nothing AndAlso DismissedRecipient.IsNewAlert Is Nothing AndAlso DismissedRecipient.ProcessedDate Is Nothing AndAlso _
                        '   DismissedRecipient.IsCurrentNotify Is Nothing Then

                        '    AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Delete(DbContext, DismissedRecipient)

                        'End If
                        Me.ShowMessage("Cannot remove a recipient that has dismissed the alert")
                        Exit Sub

                    End If

                End If

            End Using

            RaiseEvent RadAutoCompleteBoxEmployeesEntryAdded(sender, e)

        End If

    End Sub

#End Region

#Region " Methods "

    Public Sub SetDataSource()

        If _UseWebService = False Then

            Me.RadAutoCompleteBoxEmployees.WebServiceSettings.Method = Nothing
            Me.RadAutoCompleteBoxEmployees.WebServiceSettings.Path = Nothing
            Me.RadAutoCompleteBoxEmployees.OnClientRequesting = Nothing

        Else

            Me.RadAutoCompleteBoxEmployees.WebServiceSettings.Method = "LoadAutoComplete"
            Me.RadAutoCompleteBoxEmployees.WebServiceSettings.Path = "Alert_View.aspx"
            Me.RadAutoCompleteBoxEmployees.OnClientRequesting = "OnClientRequesting"

        End If

    End Sub

    Public Sub LoadData()

        If Me.IsAssignment = False AndAlso Me.JobNumber > 0 AndAlso Me.ClientCode = "" Then

            Using DbContext As New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Me.ClientCode = Me.GetClientCodeFromJob(DbContext)

            End Using

        End If


        Try
            If Not Session("UserID") Is Nothing Then

                Me._ClientPortalUserId = CType(Session("UserID"), Integer)

            End If
        Catch ex As Exception
            Me._ClientPortalUserId = 0
        End Try

        If Me.OnlyConceptShareUsers = False Then

            Dim AutoCompleteRecipientsDatatable As New DataTable
            AutoCompleteRecipientsDatatable = SqlHelper.ExecuteDataTable(HttpContext.Current.Session("ConnString"),
                                                                               CommandType.StoredProcedure,
                                                                               "usp_wv_AutoCompleteRecipientsLoad",
                                                                               "DtData",
                                                                               New SqlParameter("@CL_CODE", Me.ClientCode),
                                                                               New SqlParameter("@DIV_CODE", Me.DivisionCode),
                                                                               New SqlParameter("@PRD_CODE", Me.ProductCode),
                                                                               New SqlParameter("@JOB_NUMBER", Me.JobNumber),
                                                                               New SqlParameter("@JOB_COMPONENT_NBR", Me.JobComponentNumber),
                                                                               New SqlParameter("@CMP_IDENTIFIER", Me.CampaignIdentifier),
                                                                               New SqlParameter("@CLIENT_PORTAL_USER_ID", Me._ClientPortalUserId),
                                                                               New SqlParameter("@ALERT_ID", AlertId),
                                                                               New SqlParameter("@USER_CODE", Session("UserCode")),
                                                                               New SqlParameter("@IS_REVIEWERS", Me.OnlyConceptShareUsers),
                                                                               New SqlParameter("@EMAIL_GR_CODE", Me.EmailGroupCode)
                                                                               )

            Me.RadAutoCompleteBoxEmployees.DataSource = AutoCompleteRecipientsDatatable


        Else

            Dim AutoCompleteReviewersDatatable As New DataTable
            AutoCompleteReviewersDatatable = SqlHelper.ExecuteDataTable(HttpContext.Current.Session("ConnString"),
                                                                               CommandType.StoredProcedure,
                                                                               "usp_wv_AutoCompleteRecipientsLoad",
                                                                               "DtData",
                                                                               New SqlParameter("@CL_CODE", Me.ClientCode),
                                                                               New SqlParameter("@DIV_CODE", Me.DivisionCode),
                                                                               New SqlParameter("@PRD_CODE", Me.ProductCode),
                                                                               New SqlParameter("@JOB_NUMBER", Me.JobNumber),
                                                                               New SqlParameter("@JOB_COMPONENT_NBR", Me.JobComponentNumber),
                                                                               New SqlParameter("@CMP_IDENTIFIER", Me.CampaignIdentifier),
                                                                               New SqlParameter("@CLIENT_PORTAL_USER_ID", Me._ClientPortalUserId),
                                                                               New SqlParameter("@ALERT_ID", AlertId),
                                                                               New SqlParameter("@USER_CODE", Session("UserCode")),
                                                                               New SqlParameter("@IS_REVIEWERS", Me.OnlyConceptShareUsers),
                                                                               New SqlParameter("@EMAIL_GR_CODE", Me.EmailGroupCode)
                                                                               )

            Me.RadAutoCompleteBoxEmployees.DataSource = AutoCompleteReviewersDatatable

        End If


        Me.RadAutoCompleteBoxEmployees.DataTextField = "FullName"

        'If Me.OnlyConceptShareUsers = False Then

        Me.RadAutoCompleteBoxEmployees.DataValueField = "Code"

        'Else

        '    Me.RadAutoCompleteBoxEmployees.DataValueField = "CS_USERID"

        'End If

    End Sub

    Private Sub InsertDataRow(ByRef dt As DataTable, ByRef emp As AdvantageFramework.Database.Views.Employee)

        Dim FullName As String = ""
        If emp.MiddleInitial Is Nothing OrElse emp.MiddleInitial = "" Then

            FullName = emp.FirstName & " " & emp.LastName

        Else

            FullName = emp.FirstName & " " & emp.MiddleInitial & ". " & emp.LastName

        End If

        Dim row As DataRow
        row = dt.NewRow()
        row.Item("EmpCode") = emp.Code
        row.Item("EmpFML") = FullName

        dt.Rows.Add(row)

    End Sub
    Private Sub InsertClientContactDataRow(ByRef dt As DataTable, ByRef c As AdvantageFramework.Database.Entities.ClientContact)

        Dim FullName As String = ""
        If c.MiddleInitial Is Nothing OrElse c.MiddleInitial = "" Then

            FullName = c.FirstName & " " & c.LastName

        Else

            FullName = c.FirstName & " " & c.MiddleInitial & ". " & c.LastName

        End If

        Dim row As DataRow
        row = dt.NewRow()
        row.Item("EmpCode") = c.ContactID
        row.Item("EmpFML") = FullName & " (CC)"

        dt.Rows.Add(row)


    End Sub
    Private Function GetClientCodeFromJob(DbContext As AdvantageFramework.Database.DbContext) As String

        Dim Value As String = ""
        Dim SessionKey As String = "JobClientCode_" & Me.JobNumber.ToString()

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Dim j As New AdvantageFramework.Database.Entities.Job
            j = Nothing
            j = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNumber)

            Value = j.ClientCode
            HttpContext.Current.Session(SessionKey) = Value

        Else

            Value = HttpContext.Current.Session(SessionKey).ToString()

        End If

        Return Value

    End Function
    Public Sub FocusTextBox()

        Me.RadAutoCompleteBoxEmployees.Focus()

    End Sub

    Public Function GetListsOfIDsForReview(ByRef EmployeeCodes As Generic.List(Of String),
                                           ByRef ConceptShareIds As Generic.List(Of Integer),
                                           ByRef ClientContactIds As Generic.List(Of Integer)) As Boolean
        Try

            For Each entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.RadAutoCompleteBoxEmployees.Entries

                If entry.Value.Contains("|") = True Then

                    Dim ar() As String
                    ar = entry.Value.Split("|")

                    If ar.Length = 2 Then

                        If entry.Text.Contains("CC") Then

                            ClientContactIds.Add(ar(0))

                        Else

                            EmployeeCodes.Add(ar(0))

                        End If

                        ConceptShareIds.Add(ar(1))

                    End If

                End If

            Next

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetListOfEmployeeCodes() As Generic.List(Of String)

        Dim list As Generic.List(Of String)
        Dim CommaDelimitedStringOfEmployeeCodes = Me.GetCommaDelimitedStringOfEmployeeCodes

        If String.IsNullOrWhiteSpace(CommaDelimitedStringOfEmployeeCodes) = False Then

            list = CommaDelimitedStringOfEmployeeCodes.Split(",").ToList

        End If

        If list Is Nothing Then list = New Generic.List(Of String)

        Return list

    End Function
    Public Function GetCommaDelimitedStringOfEmployeeCodes() As String

        Dim sb As New System.Text.StringBuilder

        For Each entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.RadAutoCompleteBoxEmployees.Entries

            If entry.Text.Contains("(CC)") = False Then

                sb.Append(entry.Value)
                sb.Append(",")

            End If
            If entry.Text.Contains("|") = True Then

                Dim ar() As String
                ar = entry.Text.Split("|")

                If ar.Length = 2 Then

                    sb.Append(ar(0))
                    sb.Append(",")

                End If

            End If

        Next

        Return MiscFN.CleanStringForSplit(sb.ToString(), ",")

    End Function
    Public Function GetCommaDelimitedStringOfClientContactCodes() As String

        Dim sb As New System.Text.StringBuilder
        Dim ClientContacts As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
        Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing

        Using DbContext As New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            ClientContacts = AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, Me.ClientCode).ToList

        End Using

        For Each entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.RadAutoCompleteBoxEmployees.Entries

            If entry.Text.Contains("(CC)") = True Then

                Try

                    ClientContact = ClientContacts.SingleOrDefault(Function(Entity) Entity.ContactID = entry.Value)

                Catch ex As Exception
                    ClientContact = Nothing
                End Try

                If ClientContact IsNot Nothing Then

                    sb.Append(ClientContact.ContactCode & "(CC)")
                    sb.Append(",")

                End If

            End If

        Next

        Return MiscFN.CleanStringForSplit(sb.ToString(), ",")

    End Function

    Public Function GetListOfClientContactIDs() As Generic.List(Of Integer)

        Dim list As New Generic.List(Of Integer)
        Dim s As String = GetCommaDelimitedStringOfClientContacts()

        For Each entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.RadAutoCompleteBoxEmployees.Entries

            If entry.Text.Contains("(CC)") = True AndAlso IsNumeric(entry.Value) = True Then

                list.Add(CType(entry.Value, Integer))

            End If

        Next

        Return list

    End Function
    Public Function GetCommaDelimitedStringOfClientContacts() As String

        Dim sb As New System.Text.StringBuilder

        For Each entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.RadAutoCompleteBoxEmployees.Entries

            If entry.Text.Contains("(CC)") = True Then

                sb.Append(entry.Value)
                sb.Append(",")

            End If

        Next

        Return MiscFN.CleanStringForSplit(sb.ToString(), ",")

    End Function

    Public Overloads Sub AddEntries(ByVal CommaDelimitedStringOfEmployeeCodes As String)

        CommaDelimitedStringOfEmployeeCodes = MiscFN.CleanStringForSplit(CommaDelimitedStringOfEmployeeCodes, ",")
        Dim ar() As String
        ar = CommaDelimitedStringOfEmployeeCodes.Split(",")

        Me.AddEntries(ar)

    End Sub
    Public Overloads Sub AddEntries(ByVal Strings As String())

        Dim e As New cEmployee(HttpContext.Current.Session("ConnString"))
        Dim Name As String = ""

        Me.RadAutoCompleteBoxEmployees.Entries.Clear()

        For Each Str As String In Strings

            Str = Str.Trim()

            If Str <> "" Then

                Dim NewEntry As New Telerik.Web.UI.AutoCompleteBoxEntry

                Name = e.GetName(Str)

                If Name Is Nothing OrElse Name = "" Then

                    Name = Str

                End If

                NewEntry.Text = Name
                NewEntry.Value = Str

                Me.RadAutoCompleteBoxEmployees.Entries.Add(NewEntry)

            End If

        Next

    End Sub
    Public Sub AddExistingAlertRecipients()

        If Me.AlertId > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim Recipients As String()

                Recipients = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM ALERT_RCPT WHERE ALERT_ID = {0};", Me.AlertId)).ToArray

                If Recipients IsNot Nothing AndAlso Recipients.Count > 0 Then

                    Me.AddEntries(Recipients)

                End If

                Dim DismissedRecipients As String()

                DismissedRecipients = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0};", Me.AlertId)).ToArray

                If DismissedRecipients IsNot Nothing AndAlso DismissedRecipients.Count > 0 Then

                    Me.AddEntries(DismissedRecipients)

                End If

            End Using

        End If

    End Sub
    Public Sub AddExistingClientRecipients(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer)

        Dim ClientRecipients = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientPortalAlertRecipient)
                                Join Names In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientContact) On Names.ContactID Equals Entity.ClientContactID
                                Where Entity.AlertID = AlertID
                                Select New With {.ID = Entity.ClientContactID,
                                                 .Name = Names.FirstName & " " & Names.LastName & " (CC)"})

        If ClientRecipients IsNot Nothing Then

            For Each item In ClientRecipients

                Dim NewEntry As New Telerik.Web.UI.AutoCompleteBoxEntry

                NewEntry.Text = item.Name
                NewEntry.Value = item.ID

                Me.RadAutoCompleteBoxEmployees.Entries.Add(NewEntry)

            Next

        End If

    End Sub
    Public Function AddNewAlertRecipients() As Boolean

        If Me.AlertId > 0 Then


        End If

    End Function
    Public Function GetClientID() As String

        Return Me.RadAutoCompleteBoxEmployees.ClientID

    End Function
    Public Sub Clear()

        Me.RadAutoCompleteBoxEmployees.Entries.Clear()

    End Sub
    Public Function HasEntries() As Boolean

        Return Me.RadAutoCompleteBoxEmployees.Entries.Count > 0

    End Function

#End Region

End Class
