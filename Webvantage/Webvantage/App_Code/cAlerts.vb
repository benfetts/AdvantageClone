'PRIOR:
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Mail
Imports Webvantage.cSecurity
Imports System.IO
Imports Telerik.Web.UI

<Serializable()>
Public Class cAlerts

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum AlertGroupingModule

        AlertInbox
        AlertsDO
        AlertCardsDO
        AssignmentCardsDO
        ReviewCardsDO

    End Enum
    Public Enum AAManagerFolders
        <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Current")>
        Current = 1
        <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Dismissed/Completed")>
        DismissedCompleted = 2
        <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "All")>
        All = 3
        <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Task List View")>
        Drafts = 4
        <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Drafts")>
        TaskView = 5
    End Enum

#End Region

#Region " Variables "

    Private oSQL As SqlHelper
    Private mConnString As String = ""
    Private mUserID As String = ""
    Private mEmpCode As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Function AlertRecipients(ByRef Session As AdvantageFramework.Security.Session, ByVal AlertID As Integer,
                                    ByRef Review As AdvantageFramework.ConceptShareAPI.Review,
                                    ByVal SendEmail As Boolean, ByVal IncludeOriginator As Boolean, ByVal IsNew As Boolean,
                                    ByRef RefreshEmployee As Boolean,
                                    ByRef OnlyTheseEmployeeCodes As Generic.List(Of String),
                                    ByRef OnlyTheseClientContactIds As Generic.List(Of Integer),
                                    ByVal CustomSubject As String,
                                    ByRef ErrorMessage As String) As Boolean

        ErrorMessage = String.Empty

        If AlertID > 0 Then

            Try

                Dim EmployeeCodes As New Generic.List(Of String)
                Dim ClientContactIds As New Generic.List(Of Integer)
                Dim EmpString As String = String.Empty
                Dim CpString As String = String.Empty
                Dim HasEmployeeFilter As Boolean = False
                Dim HasClientContactFilter As Boolean = False

                If OnlyTheseEmployeeCodes IsNot Nothing AndAlso OnlyTheseEmployeeCodes.Count > 0 Then

                    EmployeeCodes = OnlyTheseEmployeeCodes
                    HasEmployeeFilter = True

                End If
                If OnlyTheseClientContactIds IsNot Nothing AndAlso OnlyTheseClientContactIds.Count > 0 Then

                    ClientContactIds = OnlyTheseClientContactIds
                    HasClientContactFilter = True

                End If
                If HasEmployeeFilter = False AndAlso HasClientContactFilter = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Try
                            EmployeeCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM ALERT_RCPT WHERE ALERT_ID = {0} UNION SELECT EMP_CODE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0};", AlertID)).ToList
                        Catch ex As Exception
                        End Try
                        Try
                            ClientContactIds = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CDP_CONTACT_ID FROM CP_ALERT_RCPT WHERE ALERT_ID = {0} UNION SELECT CDP_CONTACT_ID FROM CP_ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0};", AlertID)).ToList
                        Catch ex As Exception
                        End Try

                    End Using

                End If

                If EmployeeCodes IsNot Nothing AndAlso EmployeeCodes.Count > 0 Then

                    For Each EmpCode As String In EmployeeCodes

                        EmpString &= "'" & EmpCode & "',"

                    Next

                    EmpString = MiscFN.CleanStringForSplit(EmpString, ",")

                End If
                If ClientContactIds IsNot Nothing AndAlso ClientContactIds.Count > 0 Then

                    For Each ClId As Integer In ClientContactIds

                        CpString &= ClId.ToString & ","

                    Next

                    CpString = MiscFN.CleanStringForSplit(CpString, ",")

                End If

                Dim a As New cAlerts()

                a.UpdateAlertRecipients(AlertID, EmpString, "", True)
                a.UpdateAlertRecipientsCP(AlertID, CpString, "", True)

                If SendEmail = True Then

                    Dim SubjectLine As String = String.Empty

                    If IsNew = True Then

                        SubjectLine = "[New Review]"

                    Else

                        SubjectLine = "[Review Updated]"

                    End If
                    If String.IsNullOrWhiteSpace(CustomSubject) = False Then

                        SubjectLine &= CustomSubject

                    End If

                    Dim eso As New EmailSessionObject(Session.ConnectionString,
                                                  Session.UserCode,
                                                  Session,
                                                  HttpContext.Current.Session("WebvantageURL"),
                                                  HttpContext.Current.Session("ClientPortalURL"))

                    With eso

                        .AlertId = AlertID
                        .Subject = SubjectLine

                        If EmployeeCodes IsNot Nothing AndAlso EmployeeCodes.Count > 0 Then

                            .EmployeeCodesToSendEmailTo = EmpString

                        End If
                        If ClientContactIds IsNot Nothing AndAlso ClientContactIds.Count > 0 Then

                            .ClientPortalEmailAddressessToSendTo = CpString

                        End If

                        .IsClientPortal = MiscFN.IsClientPortal
                        .IncludeOriginator = IncludeOriginator
                        .SessionID = HttpContext.Current.Session.SessionID.ToString()
                        .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath

                        .Send()

                    End With

                End If

                Return True

            Catch ex As Exception
                ErrorMessage = "Error occurred sending mail.  " & ex.Message
                Return False
            End Try

        End If

    End Function

    Public Function LoadAlertCategories(Optional ByVal SelectedAlertType As Integer = 0) As AlertCategory

        Dim AlertCategories As New AlertCategory(Me.mConnString)

        If HttpContext.Current.Session("AlertCategories") Is Nothing Then

            If MiscFN.IsClientPortal = True Then
                If SelectedAlertType > 0 Then
                    AlertCategories.Where.ALERT_TYPE_ID.Value = SelectedAlertType
                    AlertCategories.Where.ALERT_CAT_ID.Value = "5,6,7,8,9,10,11,12,13,14,17,18,19,28,29,30,31,38,39,40,41,42,43,44,45,46,47,48,50,51,52,53,54"
                Else
                    AlertCategories.Where.ALERT_CAT_ID.Value = "5,6,7,8,9,10,11,12,13,14,17,18,19,28,29,30,31,32,33,34,35,36,38,39,40,41,42,43,44,45,46,47,48,50,51,52,53,54"
                End If
            Else
                If SelectedAlertType > 0 Then
                    AlertCategories.Where.ALERT_TYPE_ID.Value = SelectedAlertType
                    AlertCategories.Where.ALERT_CAT_ID.Value = "28,29,30,31"
                Else
                    AlertCategories.Where.ALERT_CAT_ID.Value = "28,29,30,31,32,33,34,35,36"
                End If
            End If

            AlertCategories.Where.ALERT_CAT_ID.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotIn
            AlertCategories.Query.AddOrderBy("ALERT_DESC", MyGeneration.dOOdads.WhereParameter.Dir.ASC)

            If AlertCategories.Query.Load() Then

                HttpContext.Current.Session("AlertInbox_Cateogories") = AlertCategories.ToXml().ToString()

            End If

        Else

            AlertCategories.FromXml(HttpContext.Current.Session("AlertInbox_Cateogories"))

        End If

        Return AlertCategories

    End Function
    Public Function LoadAlertTypes() As AlertType

        Dim AlertTypes As New AlertType(Me.mConnString)

        If HttpContext.Current.Session("AlertTypes") Is Nothing Then

            If MiscFN.IsClientPortal = True Then

                AlertTypes.Where.ALERT_TYPE_ID.Value = "1,2,3,4,5,8,9,11"
                AlertTypes.Where.ALERT_TYPE_ID.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotIn

            Else

                AlertTypes.Where.ALERT_TYPE_ID.Value = "11"
                AlertTypes.Where.ALERT_TYPE_ID.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotIn

            End If

            AlertTypes.Query.AddOrderBy(AlertTypes.ColumnNames.ALERT_TYPE_DESC, MyGeneration.dOOdads.WhereParameter.Dir.ASC)

            If AlertTypes.Query.Load() Then

                HttpContext.Current.Session("AlertInbox_FillAlertTypes") = AlertTypes.ToXml().ToString()

            End If

        Else

            AlertTypes.FromXml(HttpContext.Current.Session("AlertInbox_FillAlertTypes"))

        End If

        Return AlertTypes

    End Function
    Public Sub LoadAlertGroupingOptions(ByRef Combo As RadComboBox, ByVal AlertModule As AlertGroupingModule)

        Combo.Items.Clear()
        Combo.Width = New Unit(180, UnitType.Pixel)
        Combo.TabIndex = -1

        Dim NewItem As RadComboBoxItem

        NewItem = New RadComboBoxItem
        NewItem.Text = "Custom"
        NewItem.Value = ""
        Combo.Items.Add(NewItem)

        Select Case AlertModule
            Case AlertGroupingModule.AlertInbox, AlertGroupingModule.AlertsDO

                NewItem = New RadComboBoxItem
                NewItem.Text = "Level"
                NewItem.Value = "LEVEL"
                Combo.Items.Add(NewItem)

                If MiscFN.IsClientPortal = False Then

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Category"
                    NewItem.Value = "CAT"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Office"
                    NewItem.Value = "O"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Client"
                    NewItem.Value = "C"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Division"
                    NewItem.Value = "CD"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Product"
                    NewItem.Value = "CDP"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Campaign"
                    NewItem.Value = "CM"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Estimate"
                    NewItem.Value = "ES"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Estimate Component"
                    NewItem.Value = "EST"
                    Combo.Items.Add(NewItem)

                End If

                NewItem = New RadComboBoxItem
                NewItem.Text = "Job"
                NewItem.Value = "CDPJ"
                Combo.Items.Add(NewItem)

                NewItem = New RadComboBoxItem
                NewItem.Text = "Job/Component"
                NewItem.Value = "CDPJC"
                Combo.Items.Add(NewItem)

                If MiscFN.IsClientPortal = False Then

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Task"
                    NewItem.Value = "PST"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Template"
                    NewItem.Value = "ALERT_NOTIFY_NAME"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "State"
                    NewItem.Value = "STATE"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Due Date (Desc)"
                    NewItem.Value = "DUE_DATE"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Due Date (Asc)"
                    NewItem.Value = "DUE_DATE_ASC"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Priority"
                    NewItem.Value = "PRIORITY"
                    Combo.Items.Add(NewItem)

                    'NewItem = New RadComboBoxItem
                    'NewItem.Text = "Authorization to Buy"
                    'NewItem.Value = "AB"
                    'Combo.Items.Add(NewItem)

                End If

            Case AlertGroupingModule.AssignmentCardsDO

                NewItem = New RadComboBoxItem
                NewItem.Text = "Read Status"
                NewItem.Value = "NEW_UNREAD"
                Combo.Items.Add(NewItem)

                If MiscFN.IsClientPortal = False Then

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Category"
                    NewItem.Value = "CAT"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Priority"
                    NewItem.Value = "PRIORITY"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Due Date (Desc)"
                    NewItem.Value = "DUE_DATE"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Due Date (Asc)"
                    NewItem.Value = "DUE_DATE_ASC"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Version/Build"
                    NewItem.Value = "VER_BLD"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "State"
                    NewItem.Value = "STATE"
                    Combo.Items.Add(NewItem)

                End If

                NewItem = New RadComboBoxItem
                NewItem.Text = "Last Updated"
                NewItem.Value = "LAST_UPD"
                Combo.Items.Add(NewItem)

                If MiscFN.IsClientPortal = False Then

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Client"
                    NewItem.Value = "C"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Division"
                    NewItem.Value = "CD"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Product"
                    NewItem.Value = "CDP"
                    Combo.Items.Add(NewItem)

                End If

                NewItem = New RadComboBoxItem
                NewItem.Text = "Job"
                NewItem.Value = "CDPJ"
                Combo.Items.Add(NewItem)

                NewItem = New RadComboBoxItem
                NewItem.Text = "Job/Component"
                NewItem.Value = "CDPJC"
                Combo.Items.Add(NewItem)

            Case AlertGroupingModule.AlertCardsDO

                NewItem = New RadComboBoxItem
                NewItem.Text = "Read Status"
                NewItem.Value = "NEW_UNREAD"
                Combo.Items.Add(NewItem)

                If MiscFN.IsClientPortal = False Then

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Category"
                    NewItem.Value = "CAT"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Priority"
                    NewItem.Value = "PRIORITY"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Due Date (Desc)"
                    NewItem.Value = "DUE_DATE"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Due Date (Asc)"
                    NewItem.Value = "DUE_DATE_ASC"
                    Combo.Items.Add(NewItem)

                End If

                NewItem = New RadComboBoxItem
                NewItem.Text = "Last Updated"
                NewItem.Value = "LAST_UPD"
                Combo.Items.Add(NewItem)

                If MiscFN.IsClientPortal = False Then

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Client"
                    NewItem.Value = "C"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Division"
                    NewItem.Value = "CD"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Product"
                    NewItem.Value = "CDP"
                    Combo.Items.Add(NewItem)

                End If

                NewItem = New RadComboBoxItem
                NewItem.Text = "Job"
                NewItem.Value = "CDPJ"
                Combo.Items.Add(NewItem)

                NewItem = New RadComboBoxItem
                NewItem.Text = "Job/Component"
                NewItem.Value = "CDPJC"
                Combo.Items.Add(NewItem)

            Case AlertGroupingModule.ReviewCardsDO

                If MiscFN.IsClientPortal = False Then

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Category"
                    NewItem.Value = "CAT"
                    Combo.Items.Add(NewItem)

                    'NewItem = New RadComboBoxItem
                    'NewItem.Text = "Office"
                    'NewItem.Value = "O"
                    'Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Client"
                    NewItem.Value = "C"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Division"
                    NewItem.Value = "CD"
                    Combo.Items.Add(NewItem)

                    NewItem = New RadComboBoxItem
                    NewItem.Text = "Product"
                    NewItem.Value = "CDP"
                    Combo.Items.Add(NewItem)

                End If

                NewItem = New RadComboBoxItem
                NewItem.Text = "Job"
                NewItem.Value = "CDPJ"
                Combo.Items.Add(NewItem)

                NewItem = New RadComboBoxItem
                NewItem.Text = "Job/Component"
                NewItem.Value = "CDPJC"
                Combo.Items.Add(NewItem)

                'NewItem = New RadComboBoxItem
                'NewItem.Text = "Due Date (Desc)"
                'NewItem.Value = "DUE_DATE"
                'Combo.Items.Add(NewItem)

                'NewItem = New RadComboBoxItem
                'NewItem.Text = "Due Date (Asc)"
                'NewItem.Value = "DUE_DATE_ASC"
                'Combo.Items.Add(NewItem)

                NewItem = New RadComboBoxItem
                NewItem.Text = "Priority"
                NewItem.Value = "PRIORITY"
                Combo.Items.Add(NewItem)

                If MiscFN.IsClientPortal = False Then


                End If


        End Select

    End Sub

    Public Function DeleteAlert(ByVal AlertID As Integer, ByRef ErrorMessage As String) As Boolean

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.mConnString, Me.mUserID)

                Dim DocumentIDs As Integer()

                DocumentIDs = (From Entity In DbContext.AlertAttachments
                               Where Entity.AlertID = AlertID
                               Select Entity.DocumentID).ToArray()

                If DocumentIDs IsNot Nothing AndAlso DocumentIDs.Count > 0 Then

                    Dim documentRepositiory As New DocumentRepository(Me.mConnString)
                    Dim Document As AdvantageFramework.Database.Entities.Document

                    For Each DocumentID As Integer In DocumentIDs

                        Document = Nothing
                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                        If Document IsNot Nothing Then

                            If documentRepositiory.DeleteDocument(0, Document.FileSystemFileName) = True Then

                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM ALERT_ATTACHMENT WITH(ROWLOCK) WHERE ALERT_ID = {0} AND DOCUMENT_ID = {1};", AlertID, Document.ID))

                                If AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document) = True Then

                                End If

                            End If

                        End If

                    Next

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM ALERT_RCPT WITH(ROWLOCK) WHERE ALERT_ID = {0};DELETE FROM ALERT_RCPT_DISMISSED WITH(ROWLOCK) WHERE ALERT_ID = {0};DELETE FROM ALERT WITH(ROWLOCK) WHERE ALERT_ID = {0};", AlertID))

            End Using

            Return True

        Catch ex As Exception

            ErrorMessage = ex.Message.ToString()

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= " INNER EXCEPTION: " & ex.InnerException.Message.ToString()

            End If

            Return False

        End Try

    End Function
    Public Function SearchForJobComponentOrSpecificAlert(ByVal SearchString As String, ByRef QS As AdvantageFramework.Web.QueryString) As Boolean

        Dim ReturnValue As Boolean = False

        If SearchString.Contains("/") = True Then

            Dim ar() As String
            ar = SearchString.Split("/")

            If ar.Length = 2 Then

                If IsNumeric(ar(0)) = True AndAlso IsNumeric(ar(1)) = True Then


                    QS.Page = "Alert_Inbox.aspx"
                    QS.JobNumber = ar(0)
                    QS.JobComponentNumber = ar(1)
                    QS.Add("bm", "1")
                    QS.Add("ai_folder", "Inbox")
                    QS.Add("ai_type", "0")
                    QS.Add("ai_cat", "0")
                    QS.Add("ai_show", "myalertsandassignments")
                    QS.Add("ai_gf", "")
                    QS.Add("ai_search", "")
                    QS.Add("ai_level", "JC")

                    ReturnValue = True

                End If

            ElseIf ar.Length = 3 Then

                If IsNumeric(ar(0)) = True AndAlso IsNumeric(ar(1)) = True AndAlso IsNumeric(ar(2)) = True Then

                    Dim AlertId As Integer = 0
                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.mConnString, Me.mUserID)

                            AlertId = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 ALERT_ID FROM ALERT WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBER = {1} AND ALERT_SEQ_NBR = {3};", ar(0), ar(1), ar(2))).FirstOrDefault()

                        End Using

                    Catch ex As Exception

                        AlertId = 0

                    End Try

                    If AlertId > 0 Then

                        QS.Page = "Desktop_AlertView"
                        QS.AlertID = AlertId.ToString()
                        QS.Add("AlertID", AlertId)

                        ReturnValue = True

                    End If

                End If

            End If

        End If

        Return ReturnValue

    End Function
    Public Enum Priority
        Highest = 1
        High = 2
        Normal = 3
        Low = 4
        Lowest = 5
    End Enum
    Public Function MarkAllAsRead(Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Dim SQL As New System.Text.StringBuilder
            If MiscFN.IsClientPortal = True Then
                With SQL
                    .Append("UPDATE CP_ALERT_RCPT SET READ_ALERT = 1 ")
                    .Append(" FROM   ALERT WITH(NOLOCK) ")
                    .Append(" INNER JOIN CP_ALERT_RCPT WITH(ROWLOCK) ")
                    .Append(" ON ALERT.ALERT_ID = CP_ALERT_RCPT.ALERT_ID ")
                    .Append(" WHERE  CP_ALERT_RCPT.READ_ALERT IS NULL ")
                    '.Append(" AND CP_ALERT_RCPT.PROCESSED IS NULL ")
                    .Append(" AND CP_ALERT_RCPT.CDP_CONTACT_ID = ")
                    .Append(HttpContext.Current.Session("UserID").ToString())
                    .Append(" ")
                    .Append("; ")
                End With
            Else
                With SQL
                    .Append("UPDATE ALERT_RCPT SET READ_ALERT = 1 ")
                    .Append(" FROM   ALERT WITH(NOLOCK) ")
                    .Append(" INNER JOIN ALERT_RCPT WITH(ROWLOCK) ")
                    .Append(" ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID ")
                    .Append(" WHERE  ALERT_RCPT.READ_ALERT IS NULL ")
                    '.Append(" AND ALERT_RCPT.PROCESSED IS NULL ")
                    .Append(" AND ALERT_RCPT.EMP_CODE = '")
                    .Append(HttpContext.Current.Session("EmpCode").ToString())
                    .Append("' ")
                    .Append("; ")
                End With
            End If
            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.Text, SQL.ToString())
            ErrorMessage = ""
            Return True
        Catch ex As Exception
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try
    End Function
    'Public Function SendEmailAlert(ByVal AlertID As Integer, _
    '                            Optional ByVal EmployeeCodesToSendAnEmailTo As String = "", Optional ByVal ClientPortalEmailAddresses As String = "", _
    '                            Optional ByVal IncludeOriginator As Boolean = False, _
    '                            Optional ByRef ErrorMessage As String = "") As Boolean

    '    Dim alert As New Alert(mConnString)
    '    Dim bool As Boolean
    '    alert.LoadByPrimaryKey(AlertID)

    '    EmployeeCodesToSendAnEmailTo = MiscFN.CleanStringForSplit(EmployeeCodesToSendAnEmailTo, ",")

    '    Try
    '        bool = alert.SendEmail("[Alert Updated]", EmployeeCodesToSendAnEmailTo, ClientPortalEmailAddresses, , , , , MiscFN.IsClientPortal, IncludeOriginator)
    '        If bool = False Then
    '            ErrorMessage = alert.ErrorString
    '            Return False
    '        Else
    '            ErrorMessage = ""
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        ErrorMessage = ex.Message.ToString()
    '        Return False
    '    End Try

    'End Function
    Public Sub LoadPrioritiesComboBox(ByRef ComboBox As Telerik.Web.UI.RadComboBox, Optional ByVal SetDefault As Boolean = True, Optional ShowImages As Boolean = True, Optional ShowAbbreviations As Boolean = False)
        Try

            If Not ComboBox Is Nothing Then

                Dim EnumType As System.Type = GetType(cAlerts.Priority)
                Dim Values As System.Array = System.Enum.GetValues(EnumType)

                ComboBox.Items.Clear()

                For Each Value As Integer In Values

                    Dim [Text] As String = ""
                    Dim Abbreviation As String = ""

                    Select Case Value
                        Case 1
                            Abbreviation = "HH"
                        Case 2
                            Abbreviation = "H"
                        Case 3
                            Abbreviation = "--"
                        Case 4
                            Abbreviation = "L"
                        Case 5
                            Abbreviation = "LL"
                    End Select

                    If ShowAbbreviations = False Then

                        [Text] = System.Enum.GetName(EnumType, Value)

                    Else

                        [Text] = Abbreviation

                    End If

                    Dim item As New Telerik.Web.UI.RadComboBoxItem
                    With item

                        .Text = [Text]
                        .Value = Value.ToString()
                        .ToolTip = System.Enum.GetName(EnumType, Value) & " Priority"

                    End With

                    ComboBox.Items.Add(item)

                Next





                If SetDefault = True Then

                    ComboBox.SelectedValue = CType(cAlerts.Priority.Normal, Integer)

                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

#Region " Alert Notification Templates and State "

    Public Function CopyNotifyTemplate(ByVal AlrtNotifyHdrId_ToCopy As Integer, ByVal NewTemplateName As String, ByVal CopyTeam As Boolean) As String
        Try
            Dim arP(3) As SqlParameter

            Dim pAlrtNotifyHdrId_ToCopy As New SqlParameter("@ALRT_NOTIFY_HDR_ID_TO_COPY", SqlDbType.Int)
            pAlrtNotifyHdrId_ToCopy.Value = AlrtNotifyHdrId_ToCopy
            arP(0) = pAlrtNotifyHdrId_ToCopy

            Dim pNewTemplateName As New SqlParameter("@NEW_ALERT_NOTIFY_NAME", SqlDbType.VarChar, 100)
            pNewTemplateName.Value = NewTemplateName
            arP(1) = pNewTemplateName

            Dim pCopyTeam As New SqlParameter("@COPY_TEAM", SqlDbType.SmallInt)
            pCopyTeam.Value = MiscFN.BoolToInt(CopyTeam)
            arP(2) = pCopyTeam

            Return SqlHelper.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_TEMPLATE_COPY", arP)


        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function CopyAssignmentTeam(ByVal SourceAlrtNotifyHdrId As Integer, ByVal SourceAlertStateId As Integer,
                                       ByVal TargetAlrtNotifyHdrId As Integer, ByVal TargetAlertStateId As Integer) As String
        Try
            Dim arP(4) As SqlParameter

            Dim pSourceAlrtNotifyHdrId As New SqlParameter("@SOURCE_ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pSourceAlrtNotifyHdrId.Value = SourceAlrtNotifyHdrId
            arP(0) = pSourceAlrtNotifyHdrId

            Dim pSourceAlertStateId As New SqlParameter("@SOURCE_ALERT_STATE_ID", SqlDbType.Int)
            pSourceAlertStateId.Value = SourceAlertStateId
            arP(1) = pSourceAlertStateId

            Dim pTargetAlrtNotifyHdrId As New SqlParameter("@TARGET_ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pTargetAlrtNotifyHdrId.Value = TargetAlrtNotifyHdrId
            arP(2) = pTargetAlrtNotifyHdrId

            Dim pTargetAlertStateId As New SqlParameter("@TARGET_ALERT_STATE_ID", SqlDbType.Int)
            pTargetAlertStateId.Value = TargetAlertStateId
            arP(3) = pTargetAlertStateId


            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_EMPS_COPY", arP)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function MarkAssignmentRead(ByVal AlertId As Integer) As String
        Try
            Dim StrSQL As String = "UPDATE ALERT_RCPT WITH(ROWLOCK) SET READ_ALERT = 1 WHERE ALERT_ID = " & AlertId.ToString() & " AND EMP_CODE = '" & HttpContext.Current.Session("EmpCode") & "' AND CURRENT_NOTIFY = 1;"
            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.Text, StrSQL)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function MarkAlertRead(ByVal AlertId As Integer) As String
        Try
            Dim StrSQL As String = "UPDATE ALERT_RCPT WITH(ROWLOCK) SET READ_ALERT = 1 WHERE ALERT_ID = " & AlertId.ToString() & " AND EMP_CODE = '" & HttpContext.Current.Session("EmpCode") & "';"
            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.Text, StrSQL)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Function MarkClientPortalAlertRead(ByVal AlertId As Integer) As String
        Try
            Dim StrSQL As String = "UPDATE CP_ALERT_RCPT WITH(ROWLOCK) SET READ_ALERT = 1 WHERE ALERT_ID = " & AlertId.ToString() & " AND CDP_CONTACT_ID = " & HttpContext.Current.Session("UserID") & ";"
            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.Text, StrSQL)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function SetAssignmentComboBox(ByRef Combo As RadComboBox, ByVal AlertId As Integer, Optional ByVal ErrorMessage As String = "") As Boolean

        Try

            Dim CurrAssignEmp As String = Me.GetCurrentNotifyAssignment(AlertId)
            Dim CurrAssignEmpFml As String = ""
            Dim ListHasCurrent As Boolean = False

            If CurrAssignEmp <> "" Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.mConnString, Me.mUserID)

                    Dim emp As AdvantageFramework.Database.Views.Employee = Nothing
                    emp = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, CurrAssignEmp)

                    If Not emp Is Nothing Then
                        CurrAssignEmpFml = emp.FirstName & IIf(emp.MiddleInitial = Nothing Or emp.MiddleInitial = "", " ", " " & emp.MiddleInitial & ". ") & emp.LastName
                    End If

                End Using
                For Each item As Telerik.Web.UI.RadComboBoxItem In Combo.Items
                    If item.Value = CurrAssignEmp Then

                        item.Selected = True
                        ListHasCurrent = True

                    End If
                Next
                If ListHasCurrent = False Then
                    Dim CurrItem As New RadComboBoxItem(CurrAssignEmpFml, CurrAssignEmp)
                    Combo.Items.Add(CurrItem)
                    CurrItem.Selected = True
                    If CurrAssignEmpFml <> "" Then Combo.Text = CurrAssignEmpFml
                End If

            End If

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = ex.Message.ToString()
            Return False

        End Try
    End Function
    Public Function GetNotificationRecipients(ByVal AlertStateId As Integer, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal AlertNotifyHdrId As Integer,
                                              Optional ByVal UserFilterInput As String = "", Optional ByVal ForceShowAll As Boolean = False,
                                              Optional ByVal IncludePleaseSelect As Boolean = True, Optional ByVal IncludeUnassigned As Boolean = True) As DataTable

        Using MyObjectContext = New AdvantageFramework.Database.DbContext(Me.mConnString, Me.mUserID)

            Try

                Dim MyDatatable As DataTable
                MyDatatable = New System.Data.DataTable

                Using MySqlCommand = MyObjectContext.CreateCommand()

                    MySqlCommand.CommandType = CommandType.StoredProcedure
                    MySqlCommand.CommandText = "usp_wv_ALERT_NOTIFY_EMPS_BY_STID"

                    MySqlCommand.Parameters.AddWithValue("@ALERT_STATE_ID", AlertStateId)
                    MySqlCommand.Parameters.AddWithValue("@JOB_NUMBER", JobNumber)
                    MySqlCommand.Parameters.AddWithValue("@JOB_COMPONENT_NBR", JobComponentNbr)
                    MySqlCommand.Parameters.AddWithValue("@ALRT_NOTIFY_HDR_ID", AlertNotifyHdrId)
                    MySqlCommand.Parameters.AddWithValue("@USER_FILTER_INPUT", UserFilterInput)
                    MySqlCommand.Parameters.AddWithValue("@FORCE_SHOW_ALL", ForceShowAll)
                    MySqlCommand.Parameters.AddWithValue("@INCL_PLEASE_SELECT", IncludePleaseSelect)
                    MySqlCommand.Parameters.AddWithValue("@INCL_UNASSIGNED", IncludeUnassigned)

                    MySqlCommand.Connection.Open()

                    Try

                        MyDatatable.Load(MySqlCommand.ExecuteReader)

                    Catch ex As Exception

                    Finally

                        MySqlCommand.Connection.Close()

                    End Try


                End Using

                Return MyDatatable

            Catch ex As Exception

                Return Nothing

            End Try

        End Using
    End Function

    Public Function GetAvailableEmployees(ByVal AlertNotifyHdrId As Integer, ByVal AlertStateId As Integer, ByVal RoleCode As String, ByVal AlertGrpCode As String) As DataTable
        Try
            Dim arP(5) As SqlParameter

            Dim pAlertNotifyHdrId As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pAlertNotifyHdrId.Value = AlertNotifyHdrId
            arP(0) = pAlertNotifyHdrId

            Dim pAlertStateId As New SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
            pAlertStateId.Value = AlertStateId
            arP(1) = pAlertStateId

            Dim pRoleCode As New SqlParameter("@ROLE_CODE", SqlDbType.VarChar, 6)
            pRoleCode.Value = RoleCode
            arP(2) = pRoleCode

            Dim pAlertGrpCode As New SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)
            pAlertGrpCode.Value = AlertGrpCode
            arP(3) = pAlertGrpCode

            Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserCode.Value = HttpContext.Current.Session("UserCode")
            arP(4) = pUserCode

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_EMPS_GET_AVAILABLE", "DtNotifyRecipientsAvailable", arP)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetNotificationRecipients_EmailString(ByVal AlertStateId As Integer, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As String
        Try
            Dim sb As New System.Text.StringBuilder
            Dim ret As String = ""

            Dim dt As New DataTable
            dt = GetNotificationRecipients(AlertStateId, JobNumber, JobComponentNbr, 0)

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        With sb
                            If AdvantageFramework.Email.IsValidEmailAddress(dt.Rows(i)("EMP_EMAIL").ToString()) = True Then
                                .Append(dt.Rows(i)("EMP_EMAIL").ToString())
                                .Append(",")
                            End If
                        End With
                    Next
                End If
                ret = MiscFN.RemoveTrailingDelimiter(sb.ToString(), ",")
            Else
                ret = ""
            End If
            Return ret
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GetNotificationRecipients_EmpCode(ByVal AlertStateId As Integer, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As String
        Try
            Dim sb As New System.Text.StringBuilder
            Dim ret As String = ""

            Dim dt As New DataTable
            dt = GetNotificationRecipients(AlertStateId, JobNumber, JobComponentNbr, 0)

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        With sb
                            Try
                                .Append(dt.Rows(i)("EMP_CODE").ToString())
                                .Append(",")
                            Catch ex As Exception
                            End Try
                        End With
                    Next
                End If
                ret = MiscFN.RemoveTrailingDelimiter(sb.ToString(), ",")
            Else
                ret = ""
            End If
            Return ret
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GetNotificationRecipients_ByAlertNotifyHdrId(ByVal AlertNotifyHdrId As Integer) As DataTable
        Try
            Dim arP(1) As SqlParameter

            Dim pAlertNotifyHdrId As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pAlertNotifyHdrId.Value = AlertNotifyHdrId
            arP(0) = pAlertNotifyHdrId

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_EMPS_BY_HDRID", "DtNotifyRecipients", arP)

        Catch ex As Exception

        End Try
    End Function

    Public Function GetNotificationRecipients_ByAlertId(ByVal AlertId As Integer) As DataTable
        Try
            Dim arP(1) As SqlParameter

            Dim pAlertId As New SqlParameter("@ALERT_ID", SqlDbType.Int)
            pAlertId.Value = AlertId
            arP(0) = pAlertId

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_EMPS_BY_ALERT_ID", "DtNotifyRecipients", arP)

        Catch ex As Exception
        End Try

    End Function

    Public Function UpdateAlertState(ByVal AlertId As Integer, ByVal AlertStateId As Integer) As String
        Try
            Dim StrSQL As String
            If AlertStateId > 0 Then
                StrSQL = "UPDATE ALERT WITH(ROWLOCK) SET ALERT_STATE_ID = " & AlertStateId & " WHERE ALERT_ID = " & AlertId & ";"
            Else
                StrSQL = "UPDATE ALERT WITH(ROWLOCK) SET ALERT_STATE_ID = NULL WHERE ALERT_ID = " & AlertId & ";"
            End If
            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.Text, StrSQL)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function GetTemplateName(ByVal AlertAssignmentTemplateID As Integer) As String

        If AlertAssignmentTemplateID > 0 Then

            Return SqlHelper.ExecuteScalar(Me.mConnString, CommandType.Text, String.Format("SELECT ALERT_NOTIFY_NAME FROM ALERT_NOTIFY_HDR WITH(NOLOCK) WHERE ALRT_NOTIFY_HDR_ID = {0};", AlertAssignmentTemplateID))

        Else

            Return String.Empty

        End If

    End Function
    Public Function GetInactiveTemplateInUse(ByVal AlrtNotifyHdrId As Integer) As DataTable
        Try

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, "SELECT ALRT_NOTIFY_HDR_ID, ALERT_NOTIFY_NAME+'**' AS ALERT_NOTIFY_NAME FROM ALERT_NOTIFY_HDR WITH(NOLOCK) WHERE ALRT_NOTIFY_HDR_ID = " & AlrtNotifyHdrId.ToString() & " AND ACTIVE_FLAG = 0;", "DtInactiveTemplateInUse")

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetInactiveStateInUse(ByVal AlertStateId As Integer) As DataTable
        Try

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, "SELECT ALERT_STATE_ID, ALERT_STATE_NAME+'**' AS ALERT_STATE_NAME FROM ALERT_STATES WITH(NOLOCK) WHERE ACTIVE_FLAG = 0 AND ALERT_STATE_ID = " & AlertStateId.ToString() & ";", "DtInactiveStateInUse")

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAlertStates(Optional ByVal JobNumber As String = "", Optional ByVal JobComponentNbr As String = "", Optional ByVal AlertNotifyHdrId As String = "") As DataTable
        Try
            Dim j As Integer = 0
            Dim jc As Integer = 0
            Dim anhi As Integer = 0
            If IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                j = CType(JobNumber, Integer)
                jc = CType(JobComponentNbr, Integer)
                anhi = 0
            Else
                j = 0
                jc = 0
            End If

            If IsNumeric(AlertNotifyHdrId) = True Then
                anhi = CType(AlertNotifyHdrId, Integer)
                j = 0
                jc = 0
            Else
                anhi = 0
            End If

            Dim arP(3) As SqlParameter
            Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJobNumber.Value = j
            arP(0) = pJobNumber

            Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJobComponentNbr.Value = jc
            arP(1) = pJobComponentNbr

            Dim pAlertNotifyHdrId As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pAlertNotifyHdrId.Value = anhi
            arP(2) = pAlertNotifyHdrId

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_GET_STATES", "DtNotifyStates", arP)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function GetSoftwareVersions() As DataTable
        Try
            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, "SELECT * FROM SOFTWARE_VERSION WITH(NOLOCK) ORDER BY VERSION DESC", "DtSoftwareVersion")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Overloads Function GetSoftwareVersions(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataTable
        Try
            Dim arP(2) As SqlParameter

            Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJobNumber.Value = JobNumber
            arP(0) = pJobNumber

            Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJobComponentNbr.Value = JobComponentNbr
            arP(1) = pJobComponentNbr

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_SOFTWARE_VERSION_GET_BY_JC", "DtData", arP)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetSoftwareBuilds(ByVal VersionId As Integer) As DataTable
        Try
            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, "SELECT * FROM SOFTWARE_BUILD WITH(NOLOCK) WHERE (SOFTWARE_BUILD.ACTIVE_FLAG = 1 OR SOFTWARE_BUILD.ACTIVE_FLAG IS NULL) AND VERSION_ID = " & VersionId.ToString() & " ORDER BY BUILD DESC", "DtSoftwareBuild")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetTemplateAvailableAlertStates(ByVal AlertNotifyHdrId As Integer) As DataTable
        Try

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, "SELECT ALERT_STATE_ID, ALERT_STATE_NAME, SORT_ORDER, ISNULL(ACTIVE_FLAG,1) AS ACTIVE_FLAG, DFLT_ALERT_CAT_ID FROM ALERT_STATES WITH(NOLOCK) WHERE (ACTIVE_FLAG = 1 OR ACTIVE_FLAG IS NULL) AND ALERT_STATE_ID NOT IN (SELECT ALERT_STATE_ID FROM ALERT_NOTIFY_STATES WITH(NOLOCK) WHERE ALRT_NOTIFY_HDR_ID = " & AlertNotifyHdrId & ") AND ALERT_STATE_ID > 0 ORDER BY ALERT_STATE_NAME;", "DtNotifyAvailableStates")

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetDefaultCategory(ByVal AlertStateId As Integer) As Integer
        Try
            Dim StrSQL As String = "SELECT ISNULL(DFLT_ALERT_CAT_ID,0) FROM ALERT_STATES WITH(NOLOCK) WHERE ALERT_STATE_ID = " & AlertStateId & ";"
            Return CType(SqlHelper.ExecuteScalar(Me.mConnString, CommandType.Text, StrSQL), Integer)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function JobCompHasNotifyTemplate(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As Boolean
        Try
            Dim i As Integer = CType(SqlHelper.ExecuteScalar(Me.mConnString, CommandType.Text, "SELECT ISNULL(ALRT_NOTIFY_HDR_ID,0) FROM JOB_COMPONENT WITH(NOLOCK)" & " WHERE JOB_NUMBER = " & JobNumber & " AND JOB_COMPONENT_NBR = " & JobComponentNbr & ";"), Integer)
            If i > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetJobCompNotifyTemplate(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As Integer
        Try
            Dim i As Integer = CType(SqlHelper.ExecuteScalar(Me.mConnString, CommandType.Text, "SELECT ISNULL(ALRT_NOTIFY_HDR_ID,0) FROM JOB_COMPONENT WITH(NOLOCK)" & " WHERE JOB_NUMBER = " & JobNumber & " AND JOB_COMPONENT_NBR = " & JobComponentNbr & ";"), Integer)
            Return i
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetAlertNotifyTemplates(ByVal ShowAll As Boolean) As DataTable
        Try

            'If HttpContext.Current.Session("AlertAssignmentTemplates_" & ShowAll.ToString()) Is Nothing Then

            '    Dim arP(1) As SqlParameter
            '    Dim pShowAll As New SqlParameter("@SHOW_ALL", SqlDbType.Bit)
            '    pShowAll.Value = ShowAll
            '    arP(0) = pShowAll

            '    HttpContext.Current.Session("AlertAssignmentTemplates_" & ShowAll.ToString()) = SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_HDR_GET", "DtNotifyTemplates", arP)

            'End If

            'Return HttpContext.Current.Session("AlertAssignmentTemplates_" & ShowAll.ToString())

            Dim arP(1) As SqlParameter
            Dim pShowAll As New SqlParameter("@SHOW_ALL", SqlDbType.Bit)
            pShowAll.Value = ShowAll
            arP(0) = pShowAll

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_HDR_GET", "DtNotifyTemplates", arP)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function SaveNotifyAssignmentAlertRecipient(ByVal AlertId As Integer, ByVal EmpCode As String, ByVal CommentType As Integer, ByVal AlertStateId As Integer,
                                                       ByVal AlertNotifyHdrId As Integer, ByVal AlertComment As String, ByVal SaveUnassigned As Boolean,
                                                       ByVal IsNewAssignment As Boolean, Optional ByVal ErrorMessage As String = "") As Boolean

        Dim IsUnassigned As Boolean = False

        If (EmpCode.Trim().ToLower().IndexOf("unassigned") > -1 Or EmpCode.Trim().ToLower().IndexOf("un-assigned") > -1) Then

            IsUnassigned = True

        End If

        Try
            Dim arP(10) As SqlParameter

            Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserCode.Value = HttpContext.Current.Session("UserCode")
            arP(0) = pUserCode

            Dim pAlertId As New SqlParameter("@ALERT_ID", SqlDbType.Int)
            pAlertId.Value = AlertId
            arP(1) = pAlertId

            Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEmpCode.Value = EmpCode
            arP(2) = pEmpCode

            Dim pCommentType As New SqlParameter("@COMMENT_TYPE", SqlDbType.Int)
            pCommentType.Value = CommentType
            arP(3) = pCommentType

            Dim pAlertStateId As New SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
            pAlertStateId.Value = AlertStateId
            arP(4) = pAlertStateId

            Dim pAlertNotifyHdrId As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pAlertNotifyHdrId.Value = AlertNotifyHdrId
            arP(5) = pAlertNotifyHdrId

            Dim pAlertComment As New SqlParameter("@ALERT_COMMENT", SqlDbType.Text)
            pAlertComment.Value = AlertComment.Trim()
            arP(6) = pAlertComment

            Dim pIsUnassigned As New SqlParameter("@IS_UNASSIGNED", SqlDbType.TinyInt)
            pIsUnassigned.Value = MiscFN.BoolToInt(IsUnassigned)
            arP(7) = pIsUnassigned

            Dim pSaveUnassigned As New SqlParameter("@SAVE_UNASSIGNED", SqlDbType.TinyInt)
            pSaveUnassigned.Value = MiscFN.BoolToInt(SaveUnassigned)
            arP(8) = pSaveUnassigned

            Dim pIsNewAssignment As New SqlParameter("@IS_NEW_ASSIGNMENT", SqlDbType.TinyInt)
            pIsNewAssignment.Value = MiscFN.BoolToInt(IsNewAssignment)
            arP(9) = pIsNewAssignment

            Return oSQL.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_SAVE", arP)

        Catch ex As Exception

            ErrorMessage = ex.Message.ToString()
            Return False

        End Try
    End Function

    Public Function SaveNotifyTemplateToAlert(ByVal AlertId As Integer) As String
        If AlertId > 0 Then
            Try
                Dim arP(1) As SqlParameter

                Dim pAlertId As New SqlParameter("@ALERT_ID", SqlDbType.Int)
                pAlertId.Value = AlertId
                arP(0) = pAlertId

                oSQL.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_ALERT_INSERT_HDR_ID", arP)
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        End If
    End Function

    Public Function AlertStatesUpdate(ByVal AlertStateId As Integer, ByVal AlertStateName As String, ByVal ActiveFlag As Boolean, ByVal DfltAlertCatId As Integer) As String
        Try
            Dim arP(4) As SqlParameter

            Dim pALERT_STATE_ID As New SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
            pALERT_STATE_ID.Value = AlertStateId
            arP(0) = pALERT_STATE_ID

            Dim pALERT_STATE_NAME As New SqlParameter("@ALERT_STATE_NAME", SqlDbType.VarChar, 100)
            pALERT_STATE_NAME.Value = AlertStateName
            arP(1) = pALERT_STATE_NAME

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = ActiveFlag
            arP(2) = pACTIVE_FLAG

            Dim pDFLT_ALERT_CAT_ID As New SqlParameter("@DFLT_ALERT_CAT_ID", SqlDbType.Int)
            If DfltAlertCatId > 0 Then
                pDFLT_ALERT_CAT_ID.Value = DfltAlertCatId
            Else
                pDFLT_ALERT_CAT_ID.Value = System.DBNull.Value
            End If
            arP(3) = pDFLT_ALERT_CAT_ID

            oSQL.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_STATES_UPDATE", arP)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function AlertStatesInsert(ByVal AlertStateName As String, ByVal ActiveFlag As Boolean, ByVal DfltAlertCatId As Integer) As String
        Try
            Dim arP(3) As SqlParameter


            Dim pALERT_STATE_NAME As New SqlParameter("@ALERT_STATE_NAME", SqlDbType.VarChar, 100)
            pALERT_STATE_NAME.Value = AlertStateName
            arP(0) = pALERT_STATE_NAME

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = ActiveFlag
            arP(1) = pACTIVE_FLAG

            Dim pDFLT_ALERT_CAT_ID As New SqlParameter("@DFLT_ALERT_CAT_ID", SqlDbType.Int)
            If DfltAlertCatId > 0 Then
                pDFLT_ALERT_CAT_ID.Value = DfltAlertCatId
            Else
                pDFLT_ALERT_CAT_ID.Value = System.DBNull.Value
            End If
            arP(2) = pDFLT_ALERT_CAT_ID

            Return oSQL.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_STATES_INSERT", arP)
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function GetCurrentNotifyAssignment(ByVal AlertId As Integer) As String
        Try
            'Dim StrSQL As String = "SELECT ISNULL(EMP_CODE,'') FROM ALERT_RCPT WITH(NOLOCK) WHERE ALERT_ID = " & AlertId & " AND CURRENT_NOTIFY = 1 UNION SELECT ISNULL(EMP_CODE,'') FROM ALERT_RCPT_DISMISSED WITH(NOLOCK) WHERE ALERT_ID = " & AlertId & " AND CURRENT_NOTIFY = 1;"
            Dim StrSQL As String = String.Format("SELECT ISNULL(ASSIGNED_EMP_CODE, '') FROM ALERT WHERE ALERT_ID = {0};", AlertId)
            Return oSQL.ExecuteScalar(Me.mConnString, CommandType.Text, StrSQL)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function AlertTemplateUpdate(ByVal AlertNotifyHeaderId As Integer,
                                        ByVal AlertTemplateName As String,
                                        ByVal ActiveFlag As Boolean,
                                        ByVal Type As Short,
                                        ByVal ForceComplete As Boolean) As String

        Try

            Dim arP(5) As SqlParameter

            Dim pALERT_STATE_ID As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pALERT_STATE_ID.Value = AlertNotifyHeaderId
            arP(0) = pALERT_STATE_ID

            Dim pALERT_STATE_NAME As New SqlParameter("@ALERT_NOTIFY_NAME", SqlDbType.VarChar, 100)
            pALERT_STATE_NAME.Value = AlertTemplateName
            arP(1) = pALERT_STATE_NAME

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = ActiveFlag
            arP(2) = pACTIVE_FLAG

            Dim pTYPE As New SqlParameter("@TYPE", SqlDbType.SmallInt)
            pTYPE.Value = Type
            arP(3) = pTYPE

            Dim pAUTO_NXT_STATE As New SqlParameter("@AUTO_NXT_STATE", SqlDbType.Bit)
            pAUTO_NXT_STATE.Value = ForceComplete
            arP(4) = pAUTO_NXT_STATE

            oSQL.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_HDR_UPDATE", arP)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function AlertTemplateInsert(ByVal AlertTemplateName As String, ByVal ActiveFlag As Boolean,
                                        ByVal Type As Short,
                                        ByVal ForceComplete As Boolean) As String
        Try

            Dim arP(4) As SqlParameter

            Dim pALERT_STATE_NAME As New SqlParameter("@ALERT_NOTIFY_NAME", SqlDbType.VarChar, 100)
            pALERT_STATE_NAME.Value = AlertTemplateName
            arP(0) = pALERT_STATE_NAME

            Dim pACTIVE_FLAG As New SqlParameter("@ACTIVE_FLAG", SqlDbType.Bit)
            pACTIVE_FLAG.Value = ActiveFlag
            arP(1) = pACTIVE_FLAG

            Dim pTYPE As New SqlParameter("@TYPE", SqlDbType.SmallInt)
            If Type = 0 Then
                pTYPE.Value = System.DBNull.Value
            Else
                pTYPE.Value = Type
            End If
            arP(2) = pTYPE

            Dim pAUTO_NXT_STATE As New SqlParameter("@AUTO_NXT_STATE", SqlDbType.Bit)
            pAUTO_NXT_STATE.Value = ForceComplete
            arP(3) = pAUTO_NXT_STATE

            oSQL.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_HDR_INSERT", arP)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function UpdateCompletedState(ByVal AlrtNotifyHdrId As Integer, ByVal AlertStateId As Integer) As String
        Try
            Dim StrSQL As String = "UPDATE ALERT_NOTIFY_STATES WITH(ROWLOCK) SET IS_COMPLETED = NULL WHERE ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID;"
            If AlertStateId > 0 Then
                StrSQL &= "UPDATE ALERT_NOTIFY_STATES WITH(ROWLOCK) SET IS_COMPLETED = 1 WHERE ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID AND ALERT_STATE_ID = @ALERT_STATE_ID;"
            End If


            Dim arP(2) As SqlParameter

            Dim pALRT_NOTIFY_HDR_ID As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pALRT_NOTIFY_HDR_ID.Value = AlrtNotifyHdrId
            arP(0) = pALRT_NOTIFY_HDR_ID

            If AlertStateId > 0 Then
                Dim pALERT_STATE_ID As New SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
                pALERT_STATE_ID.Value = AlertStateId
                arP(1) = pALERT_STATE_ID
            End If

            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.Text, StrSQL, arP)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function UpdateDefaultEmployee(ByVal EmployeeCode As String, ByVal AlrtNotifyHdrId As Integer, ByVal AlertStateId As Integer) As String
        Try

            Dim arP(3) As SqlParameter

            Dim pDFLT_EMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pDFLT_EMP_CODE.Value = EmployeeCode
            arP(0) = pDFLT_EMP_CODE

            Dim pALRT_NOTIFY_HDR_ID As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pALRT_NOTIFY_HDR_ID.Value = AlrtNotifyHdrId
            arP(1) = pALRT_NOTIFY_HDR_ID

            Dim pALERT_STATE_ID As New SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
            pALERT_STATE_ID.Value = AlertStateId
            arP(2) = pALERT_STATE_ID

            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "advsp_assignment_SetTemplateStateDefaultEmployee", arP)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Function DeleteAlertState(ByVal AlertStateId As Integer, ByVal ExlcudeTemplateCheck As Boolean) As String
        If AlertStateId > 0 Then
            Try
                Dim arP(2) As SqlParameter

                Dim pALERT_STATE_ID As New SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
                pALERT_STATE_ID.Value = AlertStateId
                arP(0) = pALERT_STATE_ID

                Dim pEXCLUDE_TMPLT_CHK As New SqlParameter("@EXCLUDE_TMPLT_CHK", SqlDbType.Bit)
                pEXCLUDE_TMPLT_CHK.Value = ExlcudeTemplateCheck
                arP(1) = pEXCLUDE_TMPLT_CHK

                Return oSQL.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_STATES_DELETE", arP)

            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        End If
    End Function

    Public Function DeleteAlertTemplate(ByVal AlrtNotifyHdrId As Integer) As String
        If AlrtNotifyHdrId > 0 Then
            Try
                Dim arP(1) As SqlParameter

                Dim pAlrtNotifyHdrId As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
                pAlrtNotifyHdrId.Value = AlrtNotifyHdrId
                arP(0) = pAlrtNotifyHdrId
                Return oSQL.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_HDR_DELETE", arP)

            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        End If
    End Function

    Public Function GetAlertComments(ByVal AlertId As Integer, ByVal HideSystemComments As Boolean) As DataTable

        If AlertId > 0 Then

            Try

                Dim TimeZoneOffset As Decimal = 0.0
                Dim cEmployee As New cEmployee(mConnString)

                TimeZoneOffset = cEmployee.GetTimeZoneOffset(False)

                Dim arP(5) As SqlParameter

                Dim pAlertId As New SqlParameter("@ALERT_ID", SqlDbType.Int)
                pAlertId.Value = AlertId
                arP(0) = pAlertId

                Dim pDocumentId As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
                pDocumentId.Value = 0
                arP(1) = pDocumentId

                Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = HttpContext.Current.Session("EmpCode")
                arP(2) = pEmpCode

                Dim parameterTimeZoneOffSet As New SqlParameter("@OFFSET", SqlDbType.Decimal)
                parameterTimeZoneOffSet.Value = TimeZoneOffset
                arP(3) = parameterTimeZoneOffSet

                Dim parameterHideSystemComments As New SqlParameter("@HIDE_SYSTEM_COMMENTS", SqlDbType.Bit)
                parameterHideSystemComments.Value = HideSystemComments
                arP(4) = parameterHideSystemComments

                Return oSQL.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "advsp_alert_load_comments", "DtComments", arP)

            Catch ex As Exception
                Return Nothing
            End Try

        Else

            Return Nothing

        End If

    End Function

    Public Function AssignmentIsCompleted(ByVal AlertId As Integer) As Boolean

        Dim IsCompleted As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, mUserID)

                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertId)

                If Alert IsNot Nothing Then

                    If Alert.AssignmentCompleted IsNot Nothing AndAlso Alert.AssignmentCompleted = True Then

                        IsCompleted = True

                    End If

                End If

            End Using

        Catch ex As Exception
            IsCompleted = False
        End Try

        Return IsCompleted

    End Function
    Public Function EmployeeIsCCRecipient(ByVal AlertId As Integer, ByVal EmpCode As String) As Boolean
        Try
            Dim arP(2) As SqlParameter

            Dim pAlertId As New SqlParameter("@ALERT_ID", SqlDbType.Int)
            pAlertId.Value = AlertId
            arP(0) = pAlertId
            Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEmpCode.Value = EmpCode
            arP(1) = pEmpCode

            Return CType(oSQL.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_IsCcRecipient", arP), Boolean)

        Catch ex As Exception

            Return False

        End Try

    End Function

    Public Function GetJobTrafficTaskAssignments(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal SeqNbr As Integer) As DataTable
        Try
            Dim arParams(3) As SqlParameter

            Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJobNumber.Value = JobNumber
            arParams(0) = pJobNumber

            Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJobComponentNbr.Value = JobComponentNbr
            arParams(1) = pJobComponentNbr

            Dim pSeqNbr As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            pSeqNbr.Value = SeqNbr
            arParams(2) = pSeqNbr

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NOTIFY_TASK_ASSIGNMENTS", "DtTaskAssignments", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
    Public Function GetAlert(ByVal AlertId As Integer, Optional ByVal ClientContactId As Integer = 0) As DataSet

        Dim TimeZoneOffset As Decimal = 0.0
        Dim cEmployee As New cEmployee(mConnString)

        TimeZoneOffset = cEmployee.GetTimeZoneOffset(False)

        Dim arP(4) As SqlParameter

        Dim pAlertId As New SqlParameter("@ALERT_ID", SqlDbType.Int)
        pAlertId.Value = AlertId
        arP(0) = pAlertId

        Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        pEmpCode.Value = HttpContext.Current.Session("EmpCode") 'EmpCode
        arP(1) = pEmpCode


        Dim pCPID As New SqlParameter("@CDP_CONTACT_ID", SqlDbType.Int)
        If ClientContactId = 0 Then
            pCPID.Value = System.DBNull.Value
        Else
            pCPID.Value = ClientContactId
        End If
        arP(3) = pCPID

        Dim parameterTimeZoneOffSet As New SqlParameter("@OFFSET", SqlDbType.Decimal)
        parameterTimeZoneOffSet.Value = TimeZoneOffset
        arP(4) = parameterTimeZoneOffSet

        Try
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_GET", arP)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetAlertSummary(ByVal EmpCode As String) As DataTable
        Dim arP(1) As SqlParameter

        Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        pEmpCode.Value = EmpCode
        arP(0) = pEmpCode

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_SUMMARY", "DtSummary", arP)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    'Select Case GroupBy
    '    Case "CAT"
    '    Case "O"
    '    Case "C"
    '    Case "CD"
    '    Case "CDP"
    '    Case "CDPJ"
    '    Case "CDPJC"
    '    Case "CM"
    '    Case "PST"
    '    Case "ES"
    '    Case "EST"
    '    Case "DUE_DATE"
    '    Case "ALERT_NOTIFY_NAME"
    '    Case "STATE"
    '    Case "PRIORITY"
    'End Select
    Public Function UploadControlHasOverSizedFile(ByRef UploadControl As Telerik.Web.UI.RadUpload,
                                                  Optional ByRef OverLimitFilenames As String = "") As Boolean
        Dim ReturnValue As Boolean = False

        If UploadControl.UploadedFiles.Count > 0 Then

            Dim a As New cAlerts()
            Dim SomethingAdded As Boolean = False
            Dim IsOverSizeLimit As Boolean = False
            For i = 0 To UploadControl.UploadedFiles.Count - 1

                Dim ThisFC As New DocumentRepository.FileCompare
                Dim doc As New DocumentRepository("", True)
                Dim FileToUpload As Telerik.Web.UI.UploadedFile
                Dim FileLength As Integer = 0

                FileToUpload = UploadControl.UploadedFiles(i)

                If Not FileToUpload Is Nothing Then

                    FileLength = FileToUpload.InputStream.Length
                    ThisFC.FileByteLength = CType(FileLength, Long)
                    IsOverSizeLimit = doc.IsOverFileSizeLimit(ThisFC)

                    If IsOverSizeLimit = True Then

                        ReturnValue = True
                        OverLimitFilenames &= FileToUpload.FileName & "\n"

                    End If

                End If

            Next

        End If

        If ReturnValue = True Then

            OverLimitFilenames = "The following files exceed the file size limit:\n\n" & OverLimitFilenames & "\nPlease correct before sending alert"

        Else

            OverLimitFilenames = ""

        End If

        Return ReturnValue

    End Function
    Public Function UploadAlertDocument(ByRef FileToUpload As Telerik.Web.UI.UploadedFile, ByVal CurrentAlert As Webvantage.Alert, ByRef SomethingAdded As Boolean, ByRef HasOverSizedFile As Boolean,
                                        ByVal UploadToRepository As Boolean) As Integer

        Try

            Dim DocumentId As Integer = 0
            Dim realFilename As String = FileToUpload.GetName
            Dim MIMEType As String = "" 'FileToUpload.ContentType
            Dim FileLength As Integer = FileToUpload.InputStream.Length
            Dim FileDescription As String = FileToUpload.GetNameWithoutExtension
            Dim FileKeywords As String = String.Empty

            If Not FileToUpload.ContentType Is Nothing Then

                MIMEType = FileToUpload.ContentType

            Else

                MIMEType = ""

            End If

            Try
                FileKeywords = realFilename.Replace(" ", ", ").Replace(".", ", ").Replace("_", ", ").Replace("/", ", ").Replace("|", ", ").Replace("\", ", ")
            Catch ex As Exception
                FileKeywords = ""
            End Try

            Dim ThisFC As New DocumentRepository.FileCompare
            Dim doc As New DocumentRepository("", True)

            ThisFC.FileByteLength = CType(FileLength, Long)
            HasOverSizedFile = doc.IsOverFileSizeLimit(ThisFC)

            If HasOverSizedFile = False Then

                If DocumentRepository.RadAsyncUploadFileTypeIsValid(FileToUpload) = True Then

                    If FileLength > 0 Then

                        Dim FileBytes(FileLength - 1) As Byte
                        Dim UsePrefix As String = "a_"

                        FileToUpload.InputStream.Read(FileBytes, 0, FileLength)

                        If UploadToRepository = True Then

                            UsePrefix = "d_"

                        Else

                            UsePrefix = "a_"

                        End If

                        Dim Repository As New DocumentRepository(Me.mConnString)
                        Dim RepositoryFilename As String = Repository.AddDocument(realFilename, FileBytes, FileDescription, FileKeywords, Me.mUserID, "Alert View", "Attached Doc", UsePrefix) 'save the file to the repository
                        Dim Document As New Document(Me.mConnString)

                        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                        Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity

                        If MiscFN.IsNTAuth = True Then

                            currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                            impersonationContext = currentWindowsIdentity.Impersonate()

                        End If

                        If MiscFN.IsClientPortal = True Then

                            DocumentId = CurrentAlert.AddAttachment(realFilename, MIMEType, RepositoryFilename, FileLength, "", HttpContext.Current.Session("UserID"), FileDescription, FileKeywords)

                        Else

                            DocumentId = CurrentAlert.AddAttachment(realFilename, MIMEType, RepositoryFilename, FileLength, Me.mUserID, 0, FileDescription, FileKeywords)

                        End If
                        If UploadToRepository = True Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                                Using DataContext = New AdvantageFramework.Database.DataContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                                    Dim JobNumber As Integer = 0 'CurrentAlert.JOB_NUMBER
                                    Dim JobComponentNbr As Integer = 0 'CurrentAlert.JOB_COMPONENT_NBR

                                    Try

                                        JobNumber = CurrentAlert.JOB_NUMBER

                                    Catch ex As Exception
                                        JobNumber = 0
                                    End Try
                                    Try

                                        JobComponentNbr = CurrentAlert.JOB_COMPONENT_NBR

                                    Catch ex As Exception
                                        JobComponentNbr = 0
                                    End Try
                                    Select Case CurrentAlert.s_ALERT_LEVEL.ToUpper()
                                        Case "OF"

                                            AdvantageFramework.DocumentManager.AddOfficeDocument(DbContext, CurrentAlert.OFFICE_CODE, DocumentId)

                                        Case "CL"

                                            AdvantageFramework.DocumentManager.AddClientDocument(DataContext, CurrentAlert.CL_CODE, DocumentId)

                                        Case "DI"

                                            AdvantageFramework.DocumentManager.AddDivisionDocument(DataContext, CurrentAlert.CL_CODE, CurrentAlert.DIV_CODE, DocumentId)

                                        Case "PR"

                                            AdvantageFramework.DocumentManager.AddProductDocument(DataContext, CurrentAlert.CL_CODE, CurrentAlert.DIV_CODE, CurrentAlert.PRD_CODE, DocumentId)

                                        Case "CM"

                                            If CurrentAlert.CMP_IDENTIFIER > 0 Then

                                                AdvantageFramework.DocumentManager.AddCampaignDocument(DataContext, CurrentAlert.CMP_IDENTIFIER, DocumentId)

                                            End If

                                        Case "JO"

                                            If JobNumber > 0 Then

                                                Dim DocumentJ As New JobDocument(Me.mConnString)
                                                DocumentId = DocumentJ.Add(JobNumber, realFilename, MIMEType, RepositoryFilename, FileLength, Me.mUserID, FileDescription, FileKeywords, 0, 2) 'save record to JOB_DOCUMENTS

                                            End If

                                        Case "JC", "ES", "EST"

                                            If JobNumber > 0 And JobComponentNbr > 0 Then

                                                Dim DocumentJC As New JobComponentDocuments(Me.mConnString)
                                                DocumentId = DocumentJC.Add(JobNumber, JobComponentNbr, realFilename, MIMEType, RepositoryFilename, FileLength, Me.mUserID, FileDescription, FileKeywords, 0, 2) 'save record to JOB_COMPONENT_DOCUMENTS

                                            End If

                                        Case "PST", "BRD"

                                            AdvantageFramework.DocumentManager.AddTaskDocument(DataContext, JobNumber, JobComponentNbr, CurrentAlert.TASK_SEQ_NBR, DocumentId)

                                    End Select
                                    If MiscFN.IsClientPortal = True Then

                                        CurrentAlert.AddAttachment(DocumentId, Me.mUserID, HttpContext.Current.Session("UserID")) 'save record to ALERT_ATTACHMENT

                                    Else

                                        CurrentAlert.AddAttachment(DocumentId, Me.mUserID, 0) 'save record to ALERT_ATTACHMENT

                                    End If

                                End Using

                            End Using

                        End If

                        If MiscFN.IsNTAuth = True Then
                            'impersonationContext.Undo()
                        End If

                        SomethingAdded = True

                    End If

                End If

            End If

            Return DocumentId

        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Function UploadDocument(ByRef FileToUpload As Telerik.Web.UI.UploadedFile, ByVal CurrentAlert As Webvantage.Alert, ByRef SomethingAdded As Boolean, ByRef HasOverSizedFile As Boolean,
                                        ByVal UploadToRepository As Boolean, Optional ByVal job As Integer = 0, Optional ByVal comp As Integer = 0) As Integer
        Try


            Dim DocumentId As Integer = 0
            Dim realFilename As String = FileToUpload.GetName
            Dim MIMEType As String = "" 'FileToUpload.ContentType
            Dim FileLength As Integer = FileToUpload.InputStream.Length
            Dim FileDescription As String = FileToUpload.GetNameWithoutExtension
            Dim FileKeywords As String = String.Empty

            If Not FileToUpload.ContentType Is Nothing Then

                MIMEType = FileToUpload.ContentType

            Else

                MIMEType = ""

            End If

            Try
                FileKeywords = realFilename.Replace(" ", ", ").Replace(".", ", ").Replace("_", ", ").Replace("/", ", ").Replace("|", ", ").Replace("\", ", ")
            Catch ex As Exception
                FileKeywords = ""
            End Try

            Dim ThisFC As New DocumentRepository.FileCompare
            Dim doc As New DocumentRepository("", True)
            ThisFC.FileByteLength = CType(FileLength, Long)
            HasOverSizedFile = doc.IsOverFileSizeLimit(ThisFC)


            If HasOverSizedFile = False Then

                If DocumentRepository.RadAsyncUploadFileTypeIsValid(FileToUpload) = True Then

                    If FileLength > 0 Then
                        Dim FileBytes(FileLength - 1) As Byte
                        FileToUpload.InputStream.Read(FileBytes, 0, FileLength)
                        Dim UsePrefix As String = "a_"
                        If UploadToRepository = True Then
                            UsePrefix = "d_"
                        Else
                            UsePrefix = "a_"
                        End If
                        Dim Repository As New DocumentRepository(Me.mConnString)
                        Dim RepositoryFilename As String = Repository.AddDocument(realFilename, FileBytes, FileDescription, FileKeywords, Me.mUserID, "Alert View", "Attached Doc", UsePrefix) 'save the file to the repository
                        Dim Document As New Document(Me.mConnString)

                        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                        Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
                        If MiscFN.IsNTAuth = True Then
                            currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                            impersonationContext = currentWindowsIdentity.Impersonate()
                        End If

                        If UploadToRepository = False Then
                            If MiscFN.IsClientPortal = True Then
                                DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, HttpContext.Current.Session("UserID"), "", "")
                            Else
                                DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Me.mUserID, "", "")
                            End If
                        Else
                            If job > 0 And comp = 0 Then
                                Dim DocumentJ As New JobDocument(Me.mConnString)
                                DocumentId = DocumentJ.Add(job, realFilename, MIMEType, RepositoryFilename, FileLength, Me.mUserID, FileDescription, FileKeywords, 0, 2) 'save record to JOB_DOCUMENTS
                            End If

                            If job > 0 And comp > 0 Then
                                Dim DocumentJC As New JobComponentDocuments(Me.mConnString)
                                DocumentId = DocumentJC.Add(job, comp, realFilename, MIMEType, RepositoryFilename, FileLength, Me.mUserID, FileDescription, FileKeywords, 0, 2) 'save record to JOB_COMPONENT_DOCUMENTS
                            End If

                        End If

                        If MiscFN.IsNTAuth = True Then
                            'impersonationContext.Undo()
                        End If

                        SomethingAdded = True
                    End If

                End If

            End If

            Return DocumentId

        Catch ex As Exception
            Return -1
        End Try
    End Function
    'Public Function LoadAlerts(ByVal EmpCode As String, ByVal InboxType As String, ByVal FilterLevel As String,
    '                           ByVal OfficeCode As String,
    '                           ByVal ClCode As String,
    '                           ByVal DivCode As String,
    '                           ByVal PrdCode As String,
    '                           ByVal CmpIdentifier As String,
    '                           ByVal CmpCode As String,
    '                           ByVal JobNumber As Integer,
    '                           ByVal JobComponentNbr As Integer,
    '                           ByVal AlertTypeId As String,
    '                           ByVal AlertCategoryId As String,
    '                           ByVal StartDate As String,
    '                           ByVal EndDate As String,
    '                           ByVal AlertLevel As String,
    '                           ByVal VnCode As String,
    '                           ByVal EstimateNumber As Integer,
    '                           ByVal EstComponentNbr As Integer,
    '                           ByVal TaskCode As String,
    '                           ByVal TaskDescription As String,
    '                           ByVal ATBNumber As Integer,
    '                           ByVal ShowAssignmentType As String,
    '                           ByVal AlrtNotifyHdrId As Integer,
    '                           ByVal AlertNotifyName As String,
    '                           ByVal IncludeCompletedAssignments As Boolean,
    '                           ByVal IsJobAlertsPage As Boolean,
    '                           ByVal AlertAssignmentSeqNbr As Integer,
    '                           ByVal GroupBy As String,
    '                           ByVal SearchCriteria As String,
    '                           ByVal AccountExecutiveCode As String,
    '                           ByVal ManagerCode As String,
    '                           ByVal StateId As Integer,
    '                           ByVal RecordsToReturn As Integer,
    '                           ByVal IsCount As Boolean,
    '                           ByRef RecordCount As Integer,
    '                           ByVal IncludeReviews As Boolean,
    '                           ByVal IncludeBoardLevel As Boolean,
    '                           ByRef ErrorMessage As String) As DataTable

    '    Dim DataTable As System.Data.DataTable = Nothing
    '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.mConnString, Me.mUserID)

    '        Try

    '            DataTable = AdvantageFramework.AlertSystem.LoadAlertsAsDataTable(DbContext,
    '                                                                             HttpContext.Current.Session("EmpCode"),
    '                                                                              EmpCode,
    '                                                                              InboxType,
    '                                                                              FilterLevel,
    '                                                                              OfficeCode,
    '                                                                              ClCode,
    '                                                                              DivCode,
    '                                                                              PrdCode,
    '                                                                              CmpIdentifier,
    '                                                                              CmpCode,
    '                                                                              JobNumber,
    '                                                                              JobComponentNbr,
    '                                                                              AlertTypeId,
    '                                                                              AlertCategoryId,
    '                                                                              StartDate,
    '                                                                              EndDate,
    '                                                                              AlertLevel,
    '                                                                              VnCode,
    '                                                                              EstimateNumber,
    '                                                                              EstComponentNbr,
    '                                                                              TaskCode,
    '                                                                              TaskDescription,
    '                                                                              ATBNumber,
    '                                                                              ShowAssignmentType,
    '                                                                              AlrtNotifyHdrId,
    '                                                                              AlertNotifyName,
    '                                                                              IncludeCompletedAssignments,
    '                                                                              IsJobAlertsPage,
    '                                                                              AlertAssignmentSeqNbr,
    '                                                                              GroupBy,
    '                                                                              SearchCriteria,
    '                                                                              AccountExecutiveCode,
    '                                                                              ManagerCode,
    '                                                                              StateId,
    '                                                                              RecordsToReturn,
    '                                                                              IsCount,
    '                                                                              RecordCount,
    '                                                                              IncludeReviews,
    '                                                                              IncludeBoardLevel,
    '                                                                              ErrorMessage)

    '        Catch ex As Exception
    '            ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
    '        End Try

    '    End Using

    '    Return DataTable

    'End Function
    Public Function LoadAlertsCP(ByVal CPID As Integer, ByVal InboxType As String, ByVal FilterLevel As String, ByVal OfficeCode As String, ByVal ClCode As String,
                           ByVal DivCode As String, ByVal PrdCode As String, ByVal CmpIdentifier As String, ByVal CmpCode As String, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
                           ByVal AlertTypeId As String, ByVal AlertCategoryId As String, ByVal StartDate As String, ByVal EndDate As String, ByVal AlertLevel As String,
                           ByVal VnCode As String, ByVal EstimateNumber As Integer, ByVal EstComponentNbr As Integer, ByVal TaskCode As String, ByVal TaskDescription As String,
                           ByVal ShowAssignmentType As String, ByVal AlrtNotifyHdrId As Integer, ByVal AlertNotifyName As String, ByVal IncludeCompletedAssignments As Boolean,
                           ByVal IsJobAlertsPage As Boolean, ByVal AlertAssignmentSeqNbr As Integer, ByVal GroupBy As String,
                           ByVal SearchCriteria As String, ByVal RecordsToReturn As Integer, ByVal IsCount As Boolean,
                           ByRef RecordCount As Integer, ByVal IncludeReviews As Boolean, ByRef ErrorMessage As String) As DataTable
        Dim SQL As String = ""
        Try

            InboxType = InboxType.Trim().ToLower()
            ShowAssignmentType = ShowAssignmentType.Trim().ToLower()

            ErrorMessage = ""

            Dim DateStart As DateTime = Nothing
            Dim DateEnd As DateTime = Nothing
            Dim IncludeBothAlertRcptTables As Boolean = False
            Dim ExcludeBothAlertRcptTables As Boolean = False

            If (InboxType = "inbox" And ShowAssignmentType = "unassigned") OrElse
               (InboxType = "sent" And ShowAssignmentType = "unassigned") Then

                ExcludeBothAlertRcptTables = True

            End If


            Dim ExcludeFieldsThatWillCauseDuplicates As Boolean = False

            If IsJobAlertsPage = True Or InboxType = "sent" Then

                ExcludeFieldsThatWillCauseDuplicates = True

            End If

            If IsJobAlertsPage = False Then 'ignore completed

                IncludeCompletedAssignments = False

            End If

            'If IsJobAlertsPage = True Then
            '    EmpCode = ""
            'End If

            Dim RecipientTableName As String = "CP_ALERT_RCPT"

            If IsJobAlertsPage = False AndAlso InboxType = "dismissed" Then

                RecipientTableName = "CP_ALERT_RCPT_DISMISSED"

            End If

            If (IsJobAlertsPage = False And InboxType = "received") OrElse ShowAssignmentType <> "myalerts" Then

                IncludeBothAlertRcptTables = True

            End If

            If InboxType = "inbox" Then

                IncludeBothAlertRcptTables = False

            End If

            If IsJobAlertsPage = True Then

                IncludeBothAlertRcptTables = True

            End If

            Dim Offset As Decimal = cEmployee.GetTimeZoneOffset

            Dim sb As New System.Text.StringBuilder
            With sb

                .Append("SELECT ")
                .Append(" DISTINCT ")

                If RecordsToReturn > 0 Then

                    .Append(String.Format(" TOP {0} ", RecordsToReturn))

                End If

                .Append(" ALERT.ALERT_ID,")
                .Append(" ALERT.SUBJECT,")

                If Offset = 0 Then

                    .Append(" ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED) AS GENERATED,")

                Else

                    .Append(String.Format(" ISNULL(DATEADD(mi, (CONVERT(INT, {0}) * 60) + ({0} - CONVERT(INT, {0})), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)) AS GENERATED,", Offset))

                End If

                .Append(" CASE ")
                .Append(" WHEN ALERT.CP_ALERT = 1 AND ")
                .Append("   ALERT.ALERT_USER_CP IS NOT NULL THEN (")
                .Append(" SELECT CONT_FML")
                .Append(" FROM   CDP_CONTACT_HDR WITH (NOLOCK)")
                .Append(" WHERE  CDP_CONTACT_ID = ALERT_USER_CP")
                .Append("   )")
                .Append("   ELSE (SELECT [dbo].[wvfn_alert_get_last_user_name](ALERT.ALERT_ID))")
                .Append(" END AS USER_NAME,")
                .Append(" ISNULL(ALERT.PRIORITY,3) AS PRIORITY,")
                .Append(" ALERT_TYPE.ALERT_TYPE_DESC AS TYPE,")
                .Append(" ALERT_CATEGORY.ALERT_DESC AS CATEGORY,")
                .Append(" (")
                .Append("   SELECT COUNT(1) AS ATTACHMENTCOUNT")
                .Append("   FROM   ALERT_ATTACHMENT WITH (NOLOCK)")
                .Append("   WHERE  (ALERT_ID = ALERT.ALERT_ID)")
                .Append(" ) AS ATTACHMENTCOUNT,")
                .Append(" ALERT.START_DATE,")
                .Append(" ALERT.DUE_DATE,")
                .Append(" CLIENT.CL_NAME,")

                .Append(" ( ")
                .Append("   SELECT SOFTWARE_VERSION.VERSION ")
                .Append("   FROM   SOFTWARE_VERSION WITH(NOLOCK) ")
                .Append("   WHERE  SOFTWARE_VERSION.VERSION_ID = ALERT.VER ")
                .Append(" ) AS [VERSION], ")
                .Append(" ( ")
                .Append("   SELECT SOFTWARE_BUILD.BUILD ")
                .Append("   FROM   SOFTWARE_BUILD WITH(NOLOCK) ")
                .Append("   WHERE  SOFTWARE_BUILD.VERSION_ID = ALERT.VER ")
                .Append(" AND SOFTWARE_BUILD.BUILD_ID = ALERT.BUILD ")
                .Append(" ) AS [BUILD], ")

                If GroupBy = "myalertsandassignments" Then
                    .Append(" ISNULL(ALERT_STATES.ALERT_STATE_NAME,'N/A') AS ALERT_STATE_NAME,")
                Else
                    .Append(" ALERT_STATES.ALERT_STATE_NAME AS ALERT_STATE_NAME,")
                End If

                If InboxType = "drafts" Then ExcludeBothAlertRcptTables = True

                If ExcludeBothAlertRcptTables = False Then

                    Dim MarkReadAlertForNoDuplicates As Boolean = False

                    If IsJobAlertsPage = True Or InboxType = "sent" Or ShowAssignmentType = "allalertassignments" Then

                        MarkReadAlertForNoDuplicates = True

                    End If

                    If MarkReadAlertForNoDuplicates = True Or ExcludeBothAlertRcptTables = True Then

                        .Append("  1 AS READ_ALERT,")
                        .Append("  0 AS CURRENT_NOTIFY,")

                    Else

                        .Append(" " & RecipientTableName & ".READ_ALERT,")
                        .Append(" " & RecipientTableName & ".CURRENT_NOTIFY,")

                    End If

                    .Append(" ISNULL(CAST(" & RecipientTableName & ".IS_DELETED AS VARCHAR), '') AS IS_DELETED,")

                Else

                    .Append(" 1 AS READ_ALERT,")
                    .Append("  0 AS CURRENT_NOTIFY,")

                End If

                'If ShowAssignmentType = "unassigned" Then
                '    .Append(" 'Unassigned' AS CURRENT_NOTIFY_EMP_FML,")
                'Else
                '    .Append(" '' AS CURRENT_NOTIFY_EMP_FML,")
                'End If

                .Append(" (SELECT TOP 1 EMP_CODE FROM [dbo].[wvtf_GetAlertAssignedEmployee] (ALERT.ALERT_ID)) AS CURRENT_NOTIFY_EMP_CODE, ")
                .Append(" (SELECT TOP 1 EMP_FML FROM [dbo].[wvtf_GetAlertAssignedEmployee] (ALERT.ALERT_ID)) AS CURRENT_NOTIFY_EMP_FML, ")

                .Append(" RIGHT(")
                .Append("   REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_NUMBER),")
                .Append("   6")
                .Append(" ) + '/' + RIGHT(")
                .Append("   REPLICATE('0', 3) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_COMPONENT_NBR),")
                .Append("   2")
                .Append(" ) ")
                .Append(" + ' - ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '') AS GRP_COMPONENT,")

                Select Case GroupBy
                    Case "O"
                        .Append(" OFFICE.OFFICE_CODE + ' - ' + OFFICE.OFFICE_NAME AS GRP_OFFICE,")
                    Case "C"
                        .Append(" ALERT.CL_CODE + ' - ' + CLIENT.CL_NAME AS GRP_CLIENT,")
                    Case "CD"
                        .Append(" ALERT.CL_CODE + ', ' + ALERT.DIV_CODE + ' - ' + DIVISION.DIV_NAME AS GRP_DIVISION,")
                    Case "CDP"
                        .Append(" ALERT.CL_CODE + ', ' + ALERT.DIV_CODE + ', ' + ALERT.PRD_CODE +")
                        .Append(" ' - ' + PRODUCT.PRD_DESCRIPTION AS GRP_PRODUCT,")
                    Case "CDPJ"
                        .Append(" RIGHT(")
                        .Append("   REPLICATE('0', 6) ")
                        .Append("   + CONVERT(VARCHAR(20), JOB_LOG.JOB_NUMBER),")
                        .Append("   6")
                        .Append(" ) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') AS GRP_JOB,")
                        'Case "CDPJC"
                        '    .Append(" RIGHT(")
                        '    .Append("   REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_NUMBER),")
                        '    .Append("   6")
                        '    .Append(" ) + '/' + RIGHT(")
                        '    .Append("   REPLICATE('0', 2) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_COMPONENT_NBR),")
                        '    .Append("   2")
                        '    .Append(" ) ")
                        '    .Append(" + ' - ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '') AS GRP_COMPONENT,")
                    Case "CM"
                        .Append(" ISNULL(CAMPAIGN.CMP_CODE + ' - ', '') + ISNULL(CAMPAIGN.CMP_NAME, '') AS GRP_CAMPAIGN,")
                    Case "PST"
                        .Append(" CASE ")
                        .Append(" WHEN JOB_TRAFFIC_DET.FNC_CODE IS NULL OR")
                        .Append("   JOB_TRAFFIC_DET.FNC_CODE = '' THEN JOB_TRAFFIC_DET.TASK_DESCRIPTION")
                        .Append(" ELSE JOB_TRAFFIC_DET.FNC_CODE + '-' + JOB_TRAFFIC_DET.TASK_DESCRIPTION")
                        .Append(" END AS GRP_TASK,")
                    Case "ES"
                        .Append(" RIGHT(")
                        .Append("   REPLICATE('0', 6) + CONVERT(VARCHAR(20), ALERT.ESTIMATE_NUMBER),")
                        .Append("   6")
                        .Append(" ) + ' - ' + ISNULL(ESTIMATE_LOG.EST_LOG_DESC, '') AS GRP_ESTIMATE,")
                    Case "EST"
                        .Append(" RIGHT(")
                        .Append("   REPLICATE('0', 6) + CONVERT(VARCHAR(20), ALERT.ESTIMATE_NUMBER),")
                        .Append("   6")
                        .Append(" ) + '/' + RIGHT(")
                        .Append("   REPLICATE('0', 2) + CONVERT(VARCHAR(20), ALERT.EST_COMPONENT_NBR),")
                        .Append("   2")
                        .Append(" ) + ' - ' + ISNULL(ESTIMATE_COMPONENT.EST_COMP_DESC, '') AS GRP_ESTIMATE_COMPONENT,")
                    Case "DUE_DATE", "DUE_DATE_ASC"
                        .Append(" dbo.udf_format_date_time(ALERT.DUE_DATE, 'YYYY-MM-DD') AS GRP_DUE_DATE,")
                        .Append(" dbo.udf_format_date_time(ALERT.DUE_DATE, 'LONGDATE') AS GRP_DUE_DATE_DISPLAY,")
                    Case "ALERT_NOTIFY_NAME"
                        .Append(" ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID,")
                        .Append(" ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME,")
                    Case "PRIORITY"
                        .Append(" CASE ")
                        .Append(" WHEN ALERT.PRIORITY = 1 THEN 'Highest'")
                        .Append(" WHEN ALERT.PRIORITY = 2 THEN 'High'")
                        .Append(" WHEN ALERT.PRIORITY = 3 THEN 'Medium'")
                        .Append(" WHEN ALERT.PRIORITY = 4 THEN 'Low'")
                        .Append(" WHEN ALERT.PRIORITY = 5 THEN 'Lowest'")
                        .Append(" ELSE 'Medium'")
                        .Append(" END AS GRP_PRIORITY,")
                End Select
                .Append(" COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) AS ID,")
                .Append(" CASE WHEN (NOT ALERT.ALERT_STATE_ID IS NULL AND NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS IS_ASSIGNMENT,")
                .Append(" ISNULL(ALERT.IS_WORK_ITEM, 0) AS IS_WORK_ITEM,")

                .Append(" ISNULL(ALERT.JOB_NUMBER, 0) AS JOB_NUMBER,")
                .Append(" ISNULL(ALERT.JOB_COMPONENT_NBR, 0) AS JOB_COMPONENT_NBR,")
                .Append(" ALERT.TIME_DUE,")
                .Append(" ALERT.IS_DRAFT,")

                .Append(" JOB_LOG.JOB_DESC,")
                .Append(" JOB_COMPONENT.JOB_COMP_DESC,")
                .Append(" ISNULL(ALERT.TASK_SEQ_NBR, 0) AS TASK_SEQ_NBR,")

                If InboxType = "dismissed" Then

                    .Append(" 1 AS IS_DISMISSED,")

                Else

                    .Append(" 0 AS IS_DISMISSED,")

                End If

                .Append(" ISNULL(ALERT.IS_CS_REVIEW, 0) AS IS_CS_REVIEW,")
                .Append(" ISNULL(ALERT.CS_PROJECT_ID, 0) AS CS_PROJECT_ID,")
                .Append(" ISNULL(ALERT.CS_REVIEW_ID, 0) AS CS_REVIEW_ID,")
                .Append(" ISNULL(ALERT.CS_NUM_REVIEWER, 0) AS CS_NUM_REVIEWER,")
                .Append(" ISNULL(ALERT.CS_NUM_CMPLT, 0) AS CS_NUM_CMPLT,")
                .Append(" CAST(ALERT.CS_ASSET_IMG AS VARBINARY(MAX)) AS CS_ASSET_IMG,")
                .Append(" ISNULL(ALERT.CS_NUM_REJECT, 0) AS CS_NUM_REJECT,")
                .Append(" ISNULL(ALERT.CS_NUM_DEFER, 0) AS CS_NUM_DEFER,")
                .Append(" ISNULL(ALERT.CS_NUM_APPR, 0) AS CS_NUM_APPR,")

                .Append(" 0 AS IS_CC, ")

                Dim JobLogTableIsJoined As Boolean = False
                Dim JobComponentTableIsJoined As Boolean = False

                .Append("ISNULL(SD.SPRINT_HDR_ID, 0) AS SPRINT_ID,")

                .Append(" NULL AS END_SELECT_CLAUSE")

                .Append(" FROM  ALERT WITH (NOLOCK)")
                .Append(" INNER JOIN ALERT_TYPE WITH (NOLOCK)")
                .Append(" ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID")
                .Append(" INNER JOIN ALERT_CATEGORY WITH (NOLOCK)")
                .Append(" ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID")
                .Append(" LEFT OUTER JOIN CLIENT WITH (NOLOCK)")
                .Append(" ON ALERT.CL_CODE = CLIENT.CL_CODE")
                .Append(" LEFT OUTER JOIN SPRINT_DTL SD ON SD.ALERT_ID = ALERT.ALERT_ID")

                If ExcludeBothAlertRcptTables = False Then
                    If ShowAssignmentType <> "unassigned" Then
                        .Append(" INNER JOIN CP_USER WITH (NOLOCK)")
                        .Append(" INNER JOIN " & RecipientTableName & " WITH (NOLOCK)")
                        .Append(" ON  CP_USER.CDP_CONTACT_ID = " & RecipientTableName & ".CDP_CONTACT_ID")
                        .Append(" ON ALERT.ALERT_ID = " & RecipientTableName & ".ALERT_ID")
                    Else
                        If ShowAssignmentType = "unassigned" Then
                            .Append(" LEFT OUTER JOIN ")
                        Else
                            .Append(" INNER JOIN ")
                        End If
                        .Append(RecipientTableName)
                        .Append(" ON ALERT.ALERT_ID = " & RecipientTableName & ".ALERT_ID")
                    End If
                End If

                If GroupBy <> "CDPJ" Then

                    .Append(" LEFT OUTER JOIN JOB_LOG WITH (NOLOCK)")
                    .Append(" ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER")
                    JobLogTableIsJoined = True

                End If
                If GroupBy <> "CDPJC" Then

                    .Append(" LEFT OUTER JOIN JOB_COMPONENT WITH (NOLOCK)")
                    .Append(" ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER")
                    .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR")
                    JobComponentTableIsJoined = True

                End If

                Select Case GroupBy
                    Case "O"
                        .Append(" INNER JOIN OFFICE WITH (NOLOCK)")
                        .Append(" ON ALERT.OFFICE_CODE = OFFICE.OFFICE_CODE")
                        'Case "C"
                        '    .Append(" INNER JOIN CLIENT WITH (NOLOCK)")
                        '    .Append(" ON ALERT.CL_CODE = CLIENT.CL_CODE")
                    Case "CD"
                        .Append(" INNER JOIN DIVISION WITH (NOLOCK)")
                        .Append(" ON ALERT.CL_CODE = DIVISION.CL_CODE")
                        .Append(" AND ALERT.DIV_CODE = DIVISION.DIV_CODE")
                    Case "CDP"
                        .Append(" INNER JOIN PRODUCT WITH (NOLOCK)")
                        .Append(" ON ALERT.CL_CODE = PRODUCT.CL_CODE")
                        .Append(" AND ALERT.DIV_CODE = PRODUCT.DIV_CODE")
                        .Append(" AND ALERT.PRD_CODE = PRODUCT.PRD_CODE")
                    Case "CDPJ"

                        If JobLogTableIsJoined = False Then

                            .Append(" INNER JOIN JOB_LOG WITH (NOLOCK)")
                            .Append(" ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER")

                            JobLogTableIsJoined = True

                        End If

                    Case "CDPJC"

                        If JobComponentTableIsJoined = False Then

                            .Append(" INNER JOIN JOB_COMPONENT WITH (NOLOCK)")
                            .Append(" ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER")
                            .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR")

                            JobComponentTableIsJoined = True

                        End If
                    'Case "CDPJ"
                    '    .Append(" INNER JOIN JOB_LOG WITH (NOLOCK)")
                    '    .Append(" ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER")
                    'Case "CDPJC"
                    '    .Append(" INNER JOIN JOB_COMPONENT WITH (NOLOCK)")
                    '    .Append(" ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER")
                    '    .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR")
                    Case "CM"
                        .Append(" INNER JOIN CAMPAIGN WITH (NOLOCK)")
                        .Append(" ON ALERT.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER")
                    Case "ES"
                        .Append(" INNER JOIN ESTIMATE_LOG WITH (NOLOCK)")
                        .Append(" ON ALERT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER")
                    Case "EST"
                        .Append(" INNER JOIN ESTIMATE_COMPONENT WITH (NOLOCK)")
                        .Append(" ON ALERT.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER")
                        .Append(" AND ALERT.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR")
                    Case "ALERT_NOTIFY_NAME"
                        .Append(" INNER JOIN ALERT_NOTIFY_HDR WITH (NOLOCK)")
                        .Append(" ON ALERT.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID")
                        'Case "STATE"
                        '    .Append(" INNER JOIN ALERT_STATES WITH (NOLOCK)")
                        '    .Append(" ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID")
                End Select

                If ShowAssignmentType <> "myalertsandassignments" And GroupBy = "STATE" Then
                    .Append(" INNER JOIN ALERT_STATES WITH (NOLOCK)")
                    .Append(" ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID")
                Else
                    .Append(" LEFT OUTER JOIN ALERT_STATES WITH (NOLOCK)")
                    .Append(" ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID")
                End If


                'If GroupBy <> "STATE" Then
                '    .Append(" LEFT OUTER JOIN ALERT_STATES WITH (NOLOCK)")
                '    .Append(" ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID")
                'End If

                If GroupBy = "PST" Or FilterLevel = "PST" Then
                    .Append(" INNER JOIN JOB_TRAFFIC_DET WITH (NOLOCK)")
                    .Append(" ON ALERT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER")
                    .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR")
                    .Append(" AND ALERT.TASK_SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR")

                End If

                .Append(" LEFT OUTER JOIN [dbo].[advtf_alert_inactive_work_items]() IWI ON ALERT.ALERT_ID = IWI.ALERT_ID  ")

                .Append(" WHERE 1 = 1  AND (ALERT_LEVEL <> 'BRD') ")


                If IncludeCompletedAssignments = True Then
                    IncludeBothAlertRcptTables = True
                End If

                Select Case ShowAssignmentType
                    Case "myalertassignments"
                        'CPID = Me.mEmpCode
                        .Append(" AND (NOT(ALERT.ALERT_STATE_ID IS NULL))")
                        If ExcludeBothAlertRcptTables = False Then
                            .Append(" AND (")
                            .Append(" " & RecipientTableName & ".CDP_CONTACT_ID = @CPID")
                            '.Append(" AND (" & RecipientTableName & ".CURRENT_NOTIFY = 1)")
                            .Append(")")
                        End If
                    Case "allalertassignments"
                        .Append(" AND (NOT(ALERT.ALERT_STATE_ID IS NULL))")

                        If CPID <> 0 And ExcludeBothAlertRcptTables = False Then
                            .Append(" AND (")

                            If InboxType <> "sent" Then
                                .Append(" " & RecipientTableName & ".CDP_CONTACT_ID = @CPID")
                                '.Append(" AND (" & RecipientTableName & ".CURRENT_NOTIFY = 1 )")
                            Else
                                '.Append(" (" & RecipientTableName & ".CURRENT_NOTIFY = 1 )")
                            End If

                            .Append(")")
                        End If

                    Case "unassigned"
                        .Append(" AND (NOT(ALERT.ALERT_STATE_ID IS NULL))")
                        If ExcludeBothAlertRcptTables = False Then
                            '.Append(" AND (( " & RecipientTableName & ".CURRENT_NOTIFY IS NULL))")
                        End If
                        If (InboxType = "inbox") Or (InboxType = "sent") Then
                            .Append(" AND ALERT.ALERT_ID NOT IN (SELECT DISTINCT ALERT_ID FROM ALERT_RCPT_DISMISSED WITH (NOLOCK))")
                            .Append(" AND ALERT.ALERT_ID NOT IN (SELECT DISTINCT ALERT_ID FROM ALERT_RCPT WITH (NOLOCK))")
                        End If

                    Case "myalerts"
                        '.Append(" AND (ALERT.ALERT_STATE_ID IS NULL)")
                        If IsJobAlertsPage = False And CPID <> 0 And InboxType <> "sent" And ExcludeBothAlertRcptTables = False Then
                            .Append(" AND (" & RecipientTableName & ".CDP_CONTACT_ID = @CPID)")
                        End If

                        If IncludeReviews = False Then .Append(" AND (ALERT.IS_CS_REVIEW = 0 OR ALERT.IS_CS_REVIEW IS NULL)")

                    Case "myalertsandassignments"

                        If IsJobAlertsPage = False And CPID <> 0 And InboxType <> "sent" And ExcludeBothAlertRcptTables = False Then
                            .Append(" AND (" & RecipientTableName & ".CDP_CONTACT_ID = @CPID)")
                        End If
                        'CPID = Me.mEmpCode

                        If IncludeReviews = False Then .Append(" AND (ALERT.IS_CS_REVIEW = 0 OR ALERT.IS_CS_REVIEW IS NULL)")

                    Case "myreviews"

                        If IsJobAlertsPage = False And CPID <> 0 And InboxType <> "sent" And ExcludeBothAlertRcptTables = False Then

                            .Append(" AND (" & RecipientTableName & ".CDP_CONTACT_ID = @CPID)")

                        End If

                        .Append(" AND (ALERT.ALERT_TYPE_ID = 15)")
                        .Append(" AND (ALERT.IS_CS_REVIEW = 1)")


                End Select

                If IsJobAlertsPage = False Then
                    Select Case InboxType
                        Case "inbox", ""
                            'NOW CONTROLLED BY TABLE
                            '.Append(" AND ((" & RecipientTableName & ".PROCESSED IS NULL))")
                        Case "sent"
                            If CPID <> 0 Then
                                .Append(" AND (CP_ALERT_RCPT.CDP_CONTACT_ID = @CPID)")
                                .Append(" AND (ALERT.ALERT_USER = CAST(@CPID AS VARCHAR(6)))")
                            End If
                        Case "dismissed"
                            'NOW CONTROLLED BY TABLE
                            '.Append(" AND (NOT(" & RecipientTableName & ".PROCESSED IS NULL))")
                        Case "received"

                        Case "action"
                            .Append(" AND (ALERT.ALERT_CAT_ID = 33)")
                        Case "discussion"
                            .Append(" AND (ALERT.ALERT_CAT_ID = 26)")
                        Case "event"
                            .Append(" AND (ALERT.ALERT_CAT_ID = 24)")
                        Case "review"
                            .Append(" AND (ALERT.ALERT_CAT_ID = 27)")
                        Case "issue"
                            .Append(" AND (ALERT.ALERT_CAT_ID = 47)")
                    End Select
                Else
                    If IncludeCompletedAssignments = False Then
                        IncludeBothAlertRcptTables = False
                    End If
                End If

                Select Case FilterLevel
                    Case "OF"
                        If OfficeCode.Trim() <> "" Then
                            .Append(" AND (ALERT.OFFICE_CODE = @OFFICE_CODE)")
                        End If
                    Case "CL"
                        If ClCode.Trim() <> "" Then
                            .Append(" AND (ALERT.CL_CODE = @CL_CODE)")
                        End If
                    Case "DI"
                        If ClCode.Trim() <> "" Then
                            .Append(" AND (ALERT.CL_CODE = @CL_CODE)")
                        End If
                        If DivCode.Trim() <> "" Then
                            .Append(" AND (ALERT.DIV_CODE = @DIV_CODE)")
                        End If
                    Case "PR"
                        If ClCode.Trim() <> "" Then
                            .Append(" AND (ALERT.CL_CODE = @CL_CODE)")
                        End If
                        If DivCode.Trim() <> "" Then
                            .Append(" AND (ALERT.DIV_CODE = @DIV_CODE)")
                        End If
                        If PrdCode.Trim() <> "" Then
                            .Append(" AND (ALERT.PRD_CODE = @PRD_CODE)")
                        End If
                    Case "CM"
                        If ClCode.Trim() <> "" Then
                            .Append(" AND (ALERT.CL_CODE = @CL_CODE)")
                        End If
                        If DivCode.Trim() <> "" Then
                            .Append(" AND (ALERT.DIV_CODE = @DIV_CODE)")
                        End If
                        If PrdCode.Trim() <> "" Then
                            .Append(" AND (ALERT.PRD_CODE = @PRD_CODE)")
                        End If
                        If CmpCode.Trim() <> "" Then
                            .Append(" AND (ALERT.CMP_CODE = @CMP_CODE)")
                        End If
                    Case "JO"
                        If JobNumber > 0 Then
                            .Append(" AND (ALERT.JOB_NUMBER = @JOB_NUMBER)")
                        End If
                    Case "JC"
                        .Append(" AND (")
                        .Append("(ALERT.JOB_NUMBER = @JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)")
                        .Append(" OR (ALERT.JOB_COMPONENT_NBR IS NULL AND ALERT.ALERT_LEVEL = 'JO' AND ALERT.JOB_NUMBER = @JOB_NUMBER)")
                        .Append(")")
                    Case "VN"
                        If VnCode.Trim() <> "" Then
                            .Append(" AND (ALERT.VN_CODE = @VN_CODE)")
                        End If
                    Case "DO"
                        If AlertLevel.Trim() <> "" Then
                            .Append(" AND (ALERT.ALERT_LEVEL = @ALERT_LEVEL)") ' should be either AD or ED
                        End If
                    Case "ES"
                        If EstimateNumber > 0 Then
                            .Append(" AND (ALERT.ESTIMATE_NUMBER = @ESTIMATE_NUMBER)")
                        End If
                    Case "EST"
                        If EstimateNumber > 0 Then
                            .Append(" AND (ALERT.ESTIMATE_NUMBER = @ESTIMATE_NUMBER)")
                        End If
                        If EstComponentNbr > 0 Then
                            .Append(" AND (ALERT.EST_COMPONENT_NBR = @EST_COMPONENT_NBR)")
                        End If
                    Case "PST"
                        If JobNumber > 0 Then
                            .Append(" AND (ALERT.JOB_NUMBER = @JOB_NUMBER)")
                        End If
                        If JobComponentNbr > 0 Then
                            .Append(" AND (ALERT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)")
                        End If
                        'be sure to include the table join on this alert level and not just when grouping by this level
                        If TaskCode.Trim() <> "" And TaskDescription.Trim() <> "" Then
                            .Append(" AND (JOB_TRAFFIC_DET.FNC_CODE = @TASK_FNC_CODE)")
                        ElseIf TaskCode.Trim() = "" And TaskDescription.Trim() <> "" Then
                            .Append(" AND (UPPER(JOB_TRAFFIC_DET.TASK_DESCRIPTION) LIKE '%' + UPPER(@TASK_FNC_DESC) + '%')")
                        ElseIf TaskCode.Trim() <> "" And TaskDescription.Trim() = "" Then
                            .Append(" AND (JOB_TRAFFIC_DET.FNC_CODE = @TASK_FNC_CODE)")
                        ElseIf TaskCode.Trim() = "" And TaskDescription.Trim() = "" Then

                        End If
                    Case "ID"
                        If AlertAssignmentSeqNbr > 0 Then
                            .Append(" AND (COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) = @ID)")
                        End If
                    Case "ALRT_NOTIFY_HDR"
                        If AlrtNotifyHdrId > 0 Then
                            .Append(" AND (ALERT.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID)")
                        End If
                End Select

                Select Case GroupBy
                    Case "DUE_DATE", "DUE_DATE_ASC"
                        .Append(" AND (NOT (DUE_DATE IS NULL))")
                End Select

                If AlertTypeId > 0 Then
                    .Append(" AND (ALERT.ALERT_TYPE_ID = @ALERT_TYPE_ID)")
                End If
                If AlertCategoryId > 0 Then
                    .Append(" AND (ALERT.ALERT_CAT_ID = @ALERT_CAT_ID)")
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''
                Try
                    If StartDate.Trim() <> "" Then
                        If cGlobals.wvIsDate(StartDate.Trim()) = True Then
                            DateStart = cGlobals.wvCDate(StartDate.Trim())
                            If DateStart.ToShortDateString().IndexOf("1950") > -1 Then
                                DateStart = Nothing
                            End If
                        Else
                            DateStart = Nothing
                        End If
                    Else
                        DateStart = Nothing
                    End If
                Catch ex As Exception
                    DateStart = Nothing
                End Try

                Try
                    If EndDate.Trim() <> "" Then
                        If cGlobals.wvIsDate(EndDate.Trim()) = True Then
                            DateEnd = cGlobals.wvCDate(CDate(EndDate.Trim()).ToShortDateString() & " 11:59 PM")
                        Else
                            DateEnd = Nothing
                        End If
                    Else
                        DateEnd = Nothing
                    End If
                Catch ex As Exception
                    DateEnd = Nothing
                End Try

                If IsJobAlertsPage = False Then
                    If Not DateStart = Nothing And Not DateEnd = Nothing Then
                        .Append(" AND (ALERT.GENERATED BETWEEN @START_DATE AND @END_DATE)")
                    ElseIf DateStart = Nothing And Not DateEnd = Nothing Then
                        .Append(" AND (ALERT.GENERATED  <= @END_DATE)")
                    ElseIf Not DateStart = Nothing And DateEnd = Nothing Then
                        .Append(" AND (ALERT.GENERATED >= @START_DATE)")
                    End If
                End If

                If SearchCriteria.Trim() <> "" Then
                    .Append(" AND (")
                    .Append(" (UPPER(ALERT.[SUBJECT]) LIKE '%' + UPPER(@SEARCH_CRITERIA) + '%')")
                    .Append(" OR (UPPER(ALERT.ALERT_USER) LIKE '%' + UPPER(@SEARCH_CRITERIA) + '%')")
                    .Append(" OR (UPPER(CAST(ALERT.[BODY] AS VARCHAR)) LIKE '%' + UPPER(@SEARCH_CRITERIA) + '%')")

                    If IsNumeric(SearchCriteria) = True Then
                        .Append(" OR (ALERT.JOB_NUMBER = CAST(@SEARCH_CRITERIA AS INTEGER))")
                        .Append(" OR (COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) = CAST(@SEARCH_CRITERIA AS INTEGER))")
                    End If

                    .Append(")")
                End If

                If InboxType = "drafts" Then

                    .Append(" AND ALERT.IS_DRAFT = 1")

                End If

                If IsJobAlertsPage = False Then
                    If (InboxType.Trim().ToLower() = "dismissed" And ShowAssignmentType = "unassigned") Or
                       (InboxType.Trim().ToLower() = "received" And ShowAssignmentType = "unassigned") Then
                        .Append(" AND 0 = 1")
                    End If
                End If

            End With

            Dim arP(30) As SqlParameter

            Dim pCPID As New SqlParameter("@CPID", SqlDbType.Int)
            If CPID <> 0 Then
                pCPID.Value = CPID
            Else
                pCPID.Value = System.DBNull.Value
            End If
            arP(0) = pCPID

            Dim pOFFICE_CODE As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 4)
            If OfficeCode.Trim() <> "" Then
                pOFFICE_CODE.Value = OfficeCode.Trim()
            Else
                pOFFICE_CODE.Value = System.DBNull.Value
            End If
            arP(1) = pOFFICE_CODE

            Dim pCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            If ClCode.Trim() <> "" Then
                pCL_CODE.Value = ClCode.Trim()
            Else
                pCL_CODE.Value = System.DBNull.Value
            End If
            arP(2) = pCL_CODE

            Dim pDIV_CODE As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
            If DivCode.Trim() <> "" Then
                pDIV_CODE.Value = DivCode.Trim()
            Else
                pDIV_CODE.Value = System.DBNull.Value
            End If
            arP(3) = pDIV_CODE

            Dim pPRD_CODE As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
            If PrdCode.Trim() <> "" Then
                pPRD_CODE.Value = PrdCode.Trim()
            Else
                pPRD_CODE.Value = System.DBNull.Value
            End If
            arP(4) = pPRD_CODE

            Dim pCMP_CODE As New SqlParameter("@CMP_CODE", SqlDbType.VarChar, 6)
            If CmpCode.Trim() <> "" Then
                pCMP_CODE.Value = CmpCode.Trim()
            Else
                pCMP_CODE.Value = System.DBNull.Value
            End If
            arP(5) = pCMP_CODE

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            If JobNumber > 0 Then
                pJOB_NUMBER.Value = JobNumber
            Else
                pJOB_NUMBER.Value = System.DBNull.Value
            End If
            arP(6) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            If JobComponentNbr > 0 Then
                pJOB_COMPONENT_NBR.Value = JobComponentNbr
            Else
                pJOB_COMPONENT_NBR.Value = System.DBNull.Value
            End If
            arP(7) = pJOB_COMPONENT_NBR

            Dim pALERT_TYPE_ID As New SqlParameter("@ALERT_TYPE_ID", SqlDbType.Int)
            If AlertTypeId > 0 Then
                pALERT_TYPE_ID.Value = AlertTypeId
            Else
                pALERT_TYPE_ID.Value = System.DBNull.Value
            End If
            arP(8) = pALERT_TYPE_ID

            Dim pALERT_CAT_ID As New SqlParameter("@ALERT_CAT_ID", SqlDbType.Int)
            If AlertCategoryId > 0 Then
                pALERT_CAT_ID.Value = AlertCategoryId
            Else
                pALERT_CAT_ID.Value = System.DBNull.Value
            End If
            arP(9) = pALERT_CAT_ID

            Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            If Not DateStart = Nothing Then
                pSTART_DATE.Value = DateStart
            Else
                pSTART_DATE.Value = System.DBNull.Value
            End If
            arP(10) = pSTART_DATE

            Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            If Not DateEnd = Nothing Then
                pEND_DATE.Value = DateEnd
            Else
                pEND_DATE.Value = System.DBNull.Value
            End If
            arP(11) = pEND_DATE

            Dim pALERT_LEVEL As New SqlParameter("@ALERT_LEVEL", SqlDbType.VarChar, 50)
            If AlertLevel.Trim() <> "" Then
                pALERT_LEVEL.Value = AlertLevel.Trim()
            Else
                pALERT_LEVEL.Value = System.DBNull.Value
            End If
            arP(12) = pALERT_LEVEL

            Dim pVN_CODE As New SqlParameter("@VN_CODE", SqlDbType.VarChar, 6)
            If VnCode.Trim() <> "" Then
                pVN_CODE.Value = VnCode.Trim()
            Else
                pVN_CODE.Value = System.DBNull.Value
            End If
            arP(13) = pVN_CODE

            Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
            If EstimateNumber > 0 Then
                pESTIMATE_NUMBER.Value = EstimateNumber
            Else
                pESTIMATE_NUMBER.Value = System.DBNull.Value
            End If
            arP(14) = pESTIMATE_NUMBER

            Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
            If EstComponentNbr > 0 Then
                pEST_COMPONENT_NBR.Value = EstComponentNbr
            Else
                pEST_COMPONENT_NBR.Value = System.DBNull.Value
            End If
            arP(15) = pEST_COMPONENT_NBR

            Dim pTASK_FNC_CODE As New SqlParameter("@TASK_FNC_CODE", SqlDbType.VarChar, 6)
            If TaskCode.Trim() <> "" Then
                pTASK_FNC_CODE.Value = TaskCode.Trim()
            Else
                pTASK_FNC_CODE.Value = System.DBNull.Value
            End If
            arP(16) = pTASK_FNC_CODE

            Dim pTASK_FNC_DESC As New SqlParameter("@TASK_FNC_DESC", SqlDbType.VarChar, 40)
            If TaskDescription.Trim() <> "" Then
                pTASK_FNC_DESC.Value = TaskDescription.Trim()
            Else
                pTASK_FNC_DESC.Value = System.DBNull.Value
            End If
            arP(17) = pTASK_FNC_DESC

            Dim pALERT_NOTIFY_NAME As New SqlParameter("@ALERT_NOTIFY_NAME", SqlDbType.VarChar, 100)
            If AlertNotifyName.Trim() <> "" Then
                pALERT_NOTIFY_NAME.Value = AlertNotifyName.Trim()
            Else
                pALERT_NOTIFY_NAME.Value = System.DBNull.Value
            End If
            arP(18) = pALERT_NOTIFY_NAME

            Dim pID As New SqlParameter("@ID", SqlDbType.Int)
            If AlertAssignmentSeqNbr > 0 Then
                pID.Value = AlertAssignmentSeqNbr
            Else
                pID.Value = System.DBNull.Value
            End If
            arP(19) = pID

            Dim pALRT_NOTIFY_HDR_ID As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            If AlrtNotifyHdrId > 0 Then
                pALRT_NOTIFY_HDR_ID.Value = AlrtNotifyHdrId
            Else
                pALRT_NOTIFY_HDR_ID.Value = System.DBNull.Value
            End If
            arP(20) = pALRT_NOTIFY_HDR_ID

            Dim pSEARCH_CRITERIA As New SqlParameter("@SEARCH_CRITERIA", SqlDbType.VarChar, 1000)
            If SearchCriteria.Trim() <> "" Then
                pSEARCH_CRITERIA.Value = SearchCriteria.Trim()
            Else
                pSEARCH_CRITERIA.Value = System.DBNull.Value
            End If
            arP(21) = pSEARCH_CRITERIA

            SQL = sb.ToString()

            If ShowAssignmentType = "unassigned" Then
                IncludeBothAlertRcptTables = False
            End If

            If IncludeBothAlertRcptTables = True Then
                SQL = SQL & " UNION " & SQL.Replace("CP_ALERT_RCPT", "CP_ALERT_RCPT_DISMISSED")
                SQL = "SELECT A.* FROM ( " & SQL & ") AS A "
            Else
                ' SQL = SQL & " ORDER BY GENERATED DESC;"
            End If

            'QUICK FIX FOR DISMISSED ALERTS WITH ASSIGNMENTS
            SQL = SQL.Replace("CP_ALERT_RCPT_DISMISSED_DISMISSED", "CP_ALERT_RCPT_DISMISSED")

            'Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, SQL, "DtAlerts", arP)

            Dim SelectText As String = ""

            If IsCount = True Then

                SelectText = "COUNT(1) AS REC_COUNT"

            Else

                SelectText = "B.*"

            End If

            If IsJobAlertsPage = True Then

                Dim IncludeCompletedAssignmentsSQL As String = ""

                If ShowAssignmentType = "myalerts" Then

                    SQL = String.Format("SELECT {0} FROM ({1}) AS B WHERE IS_ASSIGNMENT = 0", SelectText, SQL)

                ElseIf ShowAssignmentType = "myalertassignments" Then

                    If IncludeCompletedAssignments = False Then

                        IncludeCompletedAssignmentsSQL = " AND (B.CURRENT_NOTIFY_EMP_FML <> 'Completed' OR B.CURRENT_NOTIFY_EMP_FML IS NULL) "

                    End If

                    SQL = String.Format("SELECT {0} FROM ({1}) AS B WHERE CURRENT_NOTIFY_EMP_CODE = @EMP_CODE {2}", SelectText, SQL, IncludeCompletedAssignmentsSQL)

                ElseIf ShowAssignmentType = "myalertsandassignments" Then

                    If IncludeCompletedAssignments = False Then

                        IncludeCompletedAssignmentsSQL = " WHERE (B.CURRENT_NOTIFY_EMP_FML <> 'Completed' OR B.CURRENT_NOTIFY_EMP_FML IS NULL) "

                    End If

                    SQL = String.Format("SELECT {0} FROM ({1}) AS B {2}", SelectText, SQL, IncludeCompletedAssignmentsSQL)

                ElseIf ShowAssignmentType = "allalertassignments" Then

                    If IncludeCompletedAssignments = False Then

                        IncludeCompletedAssignmentsSQL = " WHERE (B.CURRENT_NOTIFY_EMP_FML <> 'Completed') "

                    End If

                    SQL = String.Format("SELECT {0} FROM ({1}) AS B {2}", SelectText, SQL, IncludeCompletedAssignmentsSQL)

                Else

                    SQL = String.Format("SELECT {0} FROM ({1} ) AS B", SelectText, SQL)

                End If

            Else

                If ShowAssignmentType = "myalerts" Then

                    SQL = String.Format("SELECT {0} FROM ({1}) AS B WHERE (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0) ", SelectText, SQL)

                ElseIf ShowAssignmentType <> "myalertsandassignments" AndAlso ShowAssignmentType <> "myreviews" AndAlso InboxType = "inbox" Then

                    SQL = String.Format("SELECT {0} FROM ({1}) AS B WHERE CURRENT_NOTIFY_EMP_FML <> 'Completed'", SelectText, SQL)

                Else

                    SQL = String.Format("SELECT {0} FROM ({1}) AS B", SelectText, SQL)

                End If

            End If

            If IsCount = False Then

                Dim SbSort As New System.Text.StringBuilder

                SbSort.Append(" ORDER BY ")
                Select Case GroupBy
                    Case "O"

                        SbSort.Append("B.GRP_OFFICE,")

                    Case "C"

                        SbSort.Append("B.GRP_CLIENT,")

                    Case "CAT"

                        SbSort.Append("B.CATEGORY,")

                    Case "CD"

                        SbSort.Append("B.GRP_DIVISION,")

                    Case "CDP"

                        SbSort.Append("B.GRP_PRODUCT,")

                    Case "CDPJ"

                        SbSort.Append("B.GRP_JOB,")

                    Case "CM"

                        SbSort.Append("B.GRP_CAMPAIGN,")

                    Case "PST"

                        SbSort.Append("B.GRP_TASK,")

                    Case "ES"

                        SbSort.Append("B.GRP_ESTIMATE,")

                    Case "EST"

                        SbSort.Append("B.GRP_ESTIMATE_COMPONENT,")

                    Case "DUE_DATE"

                        SbSort.Append("B.DUE_DATE DESC,")

                    Case "DUE_DATE_ASC"

                        SbSort.Append("B.DUE_DATE ASC,")

                    Case "ALERT_NOTIFY_NAME"

                        SbSort.Append("B.ALERT_NOTIFY_NAME,")

                    Case "PRIORITY"

                        SbSort.Append("B.PRIORITY,")

                    Case "STATE"

                        SbSort.Append("B.ALERT_STATE_NAME,")

                    Case "AB"

                        SbSort.Append("B.GRP_ATB,")

                    Case "LAST_UPD"

                        SbSort.Append("B.GENERATED DESC,")

                    Case "VER_BLD"

                        SbSort.Append("B.[VERSION] DESC, B.BUILD ASC,")

                    Case "NEW_UNREAD"

                        SbSort.Append("B.READ_ALERT,")

                End Select

                If GroupBy <> "LAST_UPD" Then

                    SbSort.Append(" B.GENERATED DESC OPTION (RECOMPILE);")

                Else

                    'SbSort.Append(" B.CARD_SEQ_NBR OPTION (RECOMPILE);")

                End If

                SQL &= SbSort.ToString()

            Else

                SQL &= "  OPTION (RECOMPILE);"

            End If


            ' For testing to copy/paste query into enterprise mgr
            SQL = SQL.Replace(vbTab, " ").Replace(vbCrLf, " ")

            If IsCount = False Then

                Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, SQL, "DtAlerts", arP)

            Else

                Try

                    RecordCount = CType(SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, SQL, "DtAlerts", arP).Rows(0)("REC_COUNT"), Integer)

                    ErrorMessage = ""
                    Return Nothing

                Catch ex As Exception

                    ErrorMessage = MiscFN.JavascriptSafe("COUNT ERROR: " & ex.Message.ToString())
                    RecordCount = -1
                    Return Nothing

                End Try

            End If

        Catch ex As Exception
            'ErrorMessage = ex.Message.ToString() & "\n\n" & SQL
            'ErrorMessage = ErrorMessage.Replace("'", "\'").Replace("""", "\""").Replace("\", "\\")
            ErrorMessage = "Error retrieving alerts:\n" & ex.Message.ToString().Replace("'", "")
            Return Nothing
        End Try
    End Function
    Public Function UnDismissAlert(ByVal AlertId As Integer, Optional ByVal cp As Boolean = False, Optional ByVal cpid As Integer = 0, Optional ForceAssignmentComplete As Boolean = False) As String
        Try

            Dim arParams(6) As SqlParameter

            Dim pALERT_ID As New SqlParameter("@ALERT_ID", SqlDbType.Int)
            pALERT_ID.Value = AlertId
            arParams(0) = pALERT_ID

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = HttpContext.Current.Session("EmpCode")
            arParams(1) = pEMP_CODE

            Dim pUSER_CODE As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUSER_CODE.Value = HttpContext.Current.Session("UserCode")
            arParams(2) = pUSER_CODE

            Dim pCP As New SqlParameter("@CP", SqlDbType.Int)
            If cp = True Then
                pCP.Value = 1
            Else
                pCP.Value = 0
            End If
            arParams(3) = pCP

            Dim pCPID As New SqlParameter("@CPID", SqlDbType.Int)
            pCPID.Value = cpid
            arParams(4) = pCPID

            Dim pFORCE_ASSIGNMENT_COMPLETE As New SqlParameter("@FORCE_ASSIGNMENT_COMPLETE", SqlDbType.Bit)
            pFORCE_ASSIGNMENT_COMPLETE.Value = ForceAssignmentComplete
            arParams(5) = pFORCE_ASSIGNMENT_COMPLETE

            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_UNDISMISS", arParams)

            Return ""
        Catch ex As Exception
            Return "Could not un-dismiss alert.\nPlease check the repository settings.\n\n" & ex.Message.ToString()
        End Try
    End Function
    Public Sub ClearAllAlertAppVars()
        Try
            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.Text, "DELETE FROM APP_VARS WITH(ROWLOCK) WHERE USERID = '" & HttpContext.Current.Session("UserCode") & "' AND [APPLICATION] = 'ALERT_INBOX' AND VARIABLE_NAME <> 'RadComboBoxAssignments';")
        Catch ex As Exception
        End Try
    End Sub

    Public Function AlertIsDismissed(ByVal AlertId As Integer, ByVal EmpCode As String) As Boolean

    End Function
    Public Function GetScheduleTaskInfo(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As DataTable
        Try
            Dim arParams(3) As SqlParameter

            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum

            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum

            Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_NEW_GET_TASK", "DtTaskHeader", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function UpdateAlert(ByVal AlertId As Integer,
                                ByVal OldSubject As String, ByVal NewSubject As String,
                                ByVal OldDescription As String, ByVal NewDescription As String,
                                ByVal OldDescriptionHTML As String, ByVal NewDescriptionHTML As String,
                                ByVal OldPriority As Integer, ByVal NewPriority As Integer,
                                ByVal OldDueDate As String, ByVal NewDueDate As String,
                                ByVal OldTimeDue As String, ByVal NewTimeDue As String,
                                ByVal OldAlertCategoryId As Integer, ByVal NewAlertCategoryId As Integer,
                                ByVal OldAlertCategoryDesc As String, ByVal NewAlertCategoryDesc As String,
                                ByVal OldVersion As String, ByVal NewVersion As String,
                                ByVal OldBuild As String, ByVal NewBuild As String,
                                Optional ByVal cpid As Integer = 0) As String

        Try
            OldDueDate = Convert.ToDateTime(OldDueDate).ToShortDateString()
        Catch ex As Exception
            OldDueDate = ""
        End Try
        Try
            NewDueDate = Convert.ToDateTime(NewDueDate).ToShortDateString()
        Catch ex As Exception
            NewDueDate = ""
        End Try

        If IsNumeric(OldVersion) = False Then OldVersion = "0"
        If IsNumeric(NewVersion) = False Then NewVersion = "0"
        If IsNumeric(OldBuild) = False Then OldBuild = "0"
        If IsNumeric(NewBuild) = False Then NewBuild = "0"

        If OldSubject.Trim() = NewSubject.Trim() And
            OldDescription.Trim() = NewDescription.Trim() And
            OldDescriptionHTML.Trim() = NewDescriptionHTML.Trim() And
            OldPriority = NewPriority And
            OldDueDate.Trim() = NewDueDate.Trim() And
            OldTimeDue.Trim() = NewTimeDue.Trim() And
            OldAlertCategoryId = NewAlertCategoryId And
            OldVersion.Trim() = NewVersion.Trim() And
            OldBuild.Trim() = NewBuild.Trim() And
            OldAlertCategoryDesc.Trim() = NewAlertCategoryDesc.Trim() Then
            Return "NO_CHANGE"
        End If

        Try
            Dim SbComment As New System.Text.StringBuilder

            Dim arP(21) As SqlParameter

            Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            If MiscFN.IsClientPortal = True Then
                pUserCode.Value = DBNull.Value
            Else
                pUserCode.Value = HttpContext.Current.Session("UserCode")
            End If
            arP(0) = pUserCode

            Dim pAlertId As New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            pAlertId.Value = AlertId
            arP(1) = pAlertId

            Dim pSubject As New System.Data.SqlClient.SqlParameter("@SUBJECT", SqlDbType.VarChar, 254)
            pSubject.Value = NewSubject
            arP(2) = pSubject

            Dim pBody As New System.Data.SqlClient.SqlParameter("@BODY", SqlDbType.Text)
            pBody.Value = NewDescription
            arP(3) = pBody

            Dim pBodyHTML As New System.Data.SqlClient.SqlParameter("@BODY_HTML", SqlDbType.Text)
            pBodyHTML.Value = NewDescriptionHTML
            arP(4) = pBodyHTML

            Dim pPRIORITY As New System.Data.SqlClient.SqlParameter("@PRIORITY", SqlDbType.SmallInt)
            pPRIORITY.Value = NewPriority
            arP(5) = pPRIORITY

            Dim pDUE_DATE As New System.Data.SqlClient.SqlParameter("@DUE_DATE", SqlDbType.SmallDateTime)
            If cGlobals.wvIsDate(NewDueDate) = True Then
                pDUE_DATE.Value = Convert.ToDateTime(NewDueDate)
            Else
                pDUE_DATE.Value = System.DBNull.Value
            End If
            arP(6) = pDUE_DATE

            Dim pTIME_DUE As New System.Data.SqlClient.SqlParameter("@TIME_DUE", SqlDbType.VarChar, 10)
            Try
                If NewTimeDue.Trim() <> "" Then
                    pTIME_DUE.Value = NewTimeDue.Trim()
                Else
                    pTIME_DUE.Value = System.DBNull.Value
                End If
            Catch ex As Exception
                pTIME_DUE.Value = System.DBNull.Value
            End Try
            arP(7) = pTIME_DUE

            Dim pVersion As New System.Data.SqlClient.SqlParameter("@VER", SqlDbType.VarChar, 10)
            If NewVersion = "" Or NewVersion = "0" Then
                pVersion.Value = System.DBNull.Value
            Else
                pVersion.Value = NewVersion
            End If
            arP(8) = pVersion

            Dim pBuild As New System.Data.SqlClient.SqlParameter("@BUILD", SqlDbType.VarChar, 10)
            If NewBuild = "" Or NewBuild = "0" Then
                pBuild.Value = System.DBNull.Value
            Else
                pBuild.Value = NewBuild
            End If
            arP(9) = pBuild

            Dim pAlertCatId As New System.Data.SqlClient.SqlParameter("@ALERT_CAT_ID", SqlDbType.Int)
            pAlertCatId.Value = NewAlertCategoryId
            arP(10) = pAlertCatId

            If OldAlertCategoryId <> NewAlertCategoryId Then
                With SbComment
                    .Append("Alert Category changed from:  ")
                    .Append(OldAlertCategoryDesc)
                    .Append(Environment.NewLine())
                End With
            End If
            If OldPriority <> NewPriority Then
                With SbComment
                    .Append("Priority changed from:  ")
                    .Append(Me.GetPriorityText(OldPriority))
                    .Append(Environment.NewLine())
                End With
            End If
            If OldDueDate <> NewDueDate Then
                With SbComment
                    .Append("Due Date changed from:  ")
                    If OldDueDate.Trim() = "" Then
                        .Append("[No prior entry]")
                    ElseIf cGlobals.wvIsDate(OldDueDate) = True Then
                        .Append(CType(OldDueDate, DateTime).ToShortDateString())
                    End If
                    .Append(Environment.NewLine())
                End With
            End If
            If OldTimeDue <> NewTimeDue Then
                With SbComment
                    .Append("Time Due changed from:  ")
                    If OldTimeDue.Trim() = "" Then OldTimeDue = "[No prior entry]"
                    .Append(OldTimeDue)
                    .Append(Environment.NewLine())
                End With
            End If
            If OldVersion <> NewVersion Then
                With SbComment
                    .Append("Version changed.")
                    .Append(Environment.NewLine())
                End With
            End If
            If OldBuild <> NewBuild Then
                With SbComment
                    .Append("Build changed.")
                    .Append(Environment.NewLine())
                End With
            End If

            Dim CompareOldSubject As String = OldSubject
            Dim CompareNewSubject As String = NewSubject
            If CompareOldSubject.Trim().Replace(" ", "") <> CompareNewSubject.Trim().Replace(" ", "") Then
                With SbComment
                    .Append("Subject changed from:  ")
                    If OldSubject.Trim() = "" Then OldSubject = "[No prior entry]"
                    .Append(OldSubject)
                    .Append(Environment.NewLine())
                End With
            End If

            Dim CompareOldDescription As String = OldDescription
            Dim CompareNewDescription As String = NewDescription
            If OldDescription.Trim().Replace(" ", "") <> NewDescription.Trim().Replace(" ", "") Then
                With SbComment
                    .Append("Description changed.")
                    .Append(Environment.NewLine())
                End With
            End If

            Dim pGeneratedComment As New System.Data.SqlClient.SqlParameter("@GENERATED_COMMENT", SqlDbType.Text)
            pGeneratedComment.Value = SbComment.ToString()
            arP(11) = pGeneratedComment

            Dim pCPID As New SqlParameter("@CPID", SqlDbType.Int)
            pCPID.Value = cpid
            arP(12) = pCPID

            SqlHelper.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_UPDATE", arP)

            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Function UpdateAlertRecipients(ByVal AlertId As Integer, ByVal EmpCodeListChecked As String, ByVal EmpCodeListUnChecked As String, ByVal MarkAsNew As Boolean, Optional ByVal LeaveEmployeeCodeReadFlag As String = "") As String
        Try
            Dim arP(5) As SqlParameter

            Dim pAlertId As New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            pAlertId.Value = AlertId
            arP(0) = pAlertId

            Dim pEmpCodeListChecked As New System.Data.SqlClient.SqlParameter("@EMP_LIST_CHECKED", SqlDbType.VarChar)
            pEmpCodeListChecked.Value = EmpCodeListChecked
            arP(1) = pEmpCodeListChecked

            Dim pEmpCodeListUnChecked As New System.Data.SqlClient.SqlParameter("@EMP_LIST_UNCHECKED", SqlDbType.VarChar)
            pEmpCodeListUnChecked.Value = EmpCodeListUnChecked
            arP(2) = pEmpCodeListUnChecked

            Dim pMarkAsNew As New System.Data.SqlClient.SqlParameter("@SET_AS_NEW", SqlDbType.Bit)
            pMarkAsNew.Value = MarkAsNew
            arP(3) = pMarkAsNew

            Dim pLeaveEmployeeCode As New System.Data.SqlClient.SqlParameter("@LEAVE_READ_EMP_CODE", SqlDbType.VarChar)
            pLeaveEmployeeCode.Value = LeaveEmployeeCodeReadFlag
            arP(4) = pLeaveEmployeeCode

            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_UPDATE_RECIPIENTS", arP)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Function UpdateAlertRecipientsCP(ByVal AlertId As Integer, ByVal EmpCodeListChecked As String, ByVal EmpCodeListUnChecked As String, ByVal MarkAsNew As Boolean) As String
        Try
            Dim arP(4) As SqlParameter

            Dim pAlertId As New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            pAlertId.Value = AlertId
            arP(0) = pAlertId

            Dim pEmpCodeListChecked As New System.Data.SqlClient.SqlParameter("@EMP_LIST_CHECKED", SqlDbType.VarChar)
            pEmpCodeListChecked.Value = EmpCodeListChecked
            arP(1) = pEmpCodeListChecked

            Dim pEmpCodeListUnChecked As New System.Data.SqlClient.SqlParameter("@EMP_LIST_UNCHECKED", SqlDbType.VarChar)
            pEmpCodeListUnChecked.Value = EmpCodeListUnChecked
            arP(2) = pEmpCodeListUnChecked

            Dim pMarkAsNew As New System.Data.SqlClient.SqlParameter("@SET_AS_NEW", SqlDbType.Bit)
            pMarkAsNew.Value = MarkAsNew
            arP(3) = pMarkAsNew

            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_UPDATE_RECIPIENTS_CP", arP)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Function UpdateAssignmentRecipient(ByVal AlertId As Integer) As String
        Try

            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.Text, "UPDATE ALERT_RCPT WITH(ROWLOCK) SET PROCESSED = NULL, NEW_ALERT = NULL, READ_ALERT = NULL WHERE ALERT_ID = " &
                                      AlertId & " AND CURRENT_NOTIFY = 1;")

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try
    End Function
    Public Function TrackChanges() As Boolean
        Try
            Dim i As Integer = CType(SqlHelper.ExecuteScalar(Me.mConnString, CommandType.Text, "SELECT ISNULL(CONVERT(VARCHAR, AGY_SETTINGS_VALUE), '0') FROM   AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'ALRT_ASSGN_TRK_SD';"), Integer)
            If i = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GetAlertRecipients(ByVal AlertId As Integer) As DataTable
        Try
            Dim arP(1) As SqlParameter

            Dim pAlertId As New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            pAlertId.Value = AlertId
            arP(0) = pAlertId

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_GET_RECIPIENTS", "DtRecipients", arP)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetAlertAttachments(ByVal AlertId As Integer) As DataTable
        Try
            Dim TimeZoneOffset As Decimal = 0.0
            Dim cEmployee As New cEmployee(mConnString)

            TimeZoneOffset = cEmployee.GetTimeZoneOffset(False)

            Dim arP(3) As SqlParameter

            Dim pAlertId As New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            pAlertId.Value = AlertId
            arP(0) = pAlertId

            Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEmpCode.Value = HttpContext.Current.Session("EmpCode")
            arP(1) = pEmpCode

            Dim parameterTimeZoneOffSet As New SqlParameter("@OFFSET", SqlDbType.Decimal)
            parameterTimeZoneOffSet.Value = TimeZoneOffset
            arP(2) = parameterTimeZoneOffSet

            Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_GET_ATTACHMENTS", "DtAttachments", arP)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetPriorityText(ByVal PriorityCode As Integer) As String
        Try
            If PriorityCode = 0 Then PriorityCode = 3
            Dim EnumType As System.Type = GetType(cAlerts.Priority)
            Return System.Enum.GetName(EnumType, PriorityCode)
        Catch ex As Exception
            Return "Normal"
        End Try
    End Function
    Public Function SetPriority(ByRef EmailMessage As MailBee.SmtpMail.Smtp, ByVal PriorityLevel As cAlerts.Priority)
        Try
            If CType(PriorityLevel, Integer) = 0 Then
                PriorityLevel = Priority.Normal
            End If
        Catch ex As Exception
        End Try
        Try
            With EmailMessage.Message
                .Priority = CType(CType(PriorityLevel, Integer), MailBee.Mime.MailPriority)
                .Importance = CType(CType(PriorityLevel, Integer), MailBee.Mime.MailPriority)
                Try
                    .Headers.Add("X-MSMail-Priority", Me.GetPriorityText(CType(PriorityLevel, Integer)), True)
                Catch ex As Exception
                End Try
            End With
        Catch ex As Exception
        End Try
    End Function
    Public Overloads Function LoadSearchAlerts(ByVal strEmpCode As String, ByVal strSearchValue As String) As DataView
        Try
            Dim arP(2) As SqlParameter

            Dim pSearchValue As New SqlParameter("@SearchCriteria", SqlDbType.VarChar, 100)
            pSearchValue.Value = strSearchValue
            arP(0) = pSearchValue

            Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            pEmpCode.Value = strEmpCode
            arP(1) = pEmpCode

            'Dim ds As New DataSet
            'ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "proc_SearchAlertInbox", arP)

            'Return ds.Tables(0).DefaultView

            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "proc_SearchAlertInbox", "dtSearchResults", arP)
            Return dt.DefaultView

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetAlerts", Err.Description)
        End Try
    End Function
    Public Overloads Function LoadSearchAlerts(ByVal EmpCode As String, ByVal SearchCriteria As String, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataView
        Try
            Dim arP(4) As SqlParameter

            Dim pSEARCH_CRITERIA As New SqlParameter("@SEARCH_CRITERIA", SqlDbType.VarChar, 100)
            pSEARCH_CRITERIA.Value = SearchCriteria
            arP(0) = pSEARCH_CRITERIA

            Dim pEMP_CODE As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = EmpCode
            arP(1) = pEMP_CODE

            Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            arP(2) = pJOB_NUMBER

            Dim pJOB_COMPONENT_NBR As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            arP(3) = pJOB_COMPONENT_NBR

            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_INBOX_SEARCH_JOB_COMP", "dtSearchResults", arP)
            Return dt.DefaultView

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function LoadSearchAlertsJJ(ByVal strEmpCode As String, ByVal strSearchValue As String, ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataView
        Try
            Dim arP(4) As SqlParameter

            Dim pSearchValue As New SqlParameter("@SearchCriteria", SqlDbType.VarChar, 100)
            pSearchValue.Value = strSearchValue
            arP(0) = pSearchValue

            Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            pEmpCode.Value = strEmpCode
            arP(1) = pEmpCode

            Dim pJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
            pJobNum.Value = JobNum
            arP(2) = pJobNum

            Dim pJobCompNum As New System.Data.SqlClient.SqlParameter("@JobCompNum", SqlDbType.Int)
            pJobCompNum.Value = JobCompNum
            arP(3) = pJobCompNum

            Dim dt As New DataTable
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "proc_SearchAlertInboxJJ", "dtSearchResults", arP)
            Return dt.DefaultView

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetAlertsJJ", Err.Description)
        End Try
    End Function
    Public Function GetAlerts(ByVal intCatID As Integer, ByVal intTypeID As Integer, ByVal strEmpCode As String, ByVal strProcessed As String) As SqlDataReader
        Dim dr As SqlDataReader

        Dim arParams(4) As SqlParameter
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = strEmpCode
        arParams(0) = parameterEmpCode
        Dim parameterCatID As New SqlParameter("@CatID", SqlDbType.Int)
        parameterCatID.Value = intCatID
        arParams(1) = parameterCatID
        Dim parameterTypeID As New SqlParameter("@TypeID", SqlDbType.Int)
        parameterTypeID.Value = intTypeID
        arParams(2) = parameterTypeID

        Dim parameterProcessed As New SqlParameter("@Processed", SqlDbType.VarChar, 1)
        parameterProcessed.Value = strProcessed
        arParams(3) = parameterProcessed

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_Get_Alerts", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetAlerts", Err.Description)
        End Try
        Return dr
    End Function
    Public Function GetAlertCategories(ByVal intTypeID As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim parameterTypeID As New SqlParameter("@Type", SqlDbType.Int)
        parameterTypeID.Value = intTypeID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_Get_Alert_Cat_By_TypeID", parameterTypeID)
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetAlertCategories", Err.Description)
        End Try
        Return dr
    End Function
    Private Sub LoadListCategories(ByRef ddl As Telerik.Web.UI.RadComboBox)
        Try
            Dim AlertCategories As New AlertCategory(mConnString)
            With AlertCategories
                .Where.ALERT_TYPE_ID.Value = "6"
                .Where.ALERT_TYPE_ID.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal
                .Query.AddOrderBy(AlertCategories.ColumnNames.ALERT_DESC, MyGeneration.dOOdads.WhereParameter.Dir.ASC)
            End With
            If AlertCategories.Query.Load() Then
                Do Until AlertCategories.EOF
                    'If AlertCategories.ALERT_CAT_ID < 28 Then
                    '    Me.CategoryDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AlertCategories.ALERT_DESC, AlertCategories.ALERT_CAT_ID))
                    'End If
                    Select Case AlertCategories.ALERT_CAT_ID
                        Case 28, 29, 30, 31
                            'don't add
                        Case Else
                            ddl.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AlertCategories.ALERT_DESC, AlertCategories.ALERT_CAT_ID))
                    End Select
                    AlertCategories.MoveNext()
                Loop
            End If
        Catch
            Err.Raise(Err.Number, "Error: Loading Categories", Err.Description)
        End Try
    End Sub
    Public Function GetManualAlertCategories(ByVal AllowTaskCategory As Boolean, ByVal AllowStoryCategory As Boolean) As DataTable

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim StoryDataRow As System.Data.DataRow = Nothing
        Dim TaskDataRow As System.Data.DataRow = Nothing

        Try

            DataTable = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_ALERT_CATEGORY_MANUAL_ALRTS", "DtAlertCategories")

            If DataTable IsNot Nothing Then

                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)

                    If CInt(DataRow("ALERT_CAT_ID")) = 70 Then

                        StoryDataRow = DataRow

                    End If

                    If CInt(DataRow("ALERT_CAT_ID")) = 71 Then

                        TaskDataRow = DataRow

                    End If

                Next

                If Not AllowTaskCategory AndAlso TaskDataRow IsNot Nothing Then

                    TaskDataRow.Delete()

                End If

                If Not AllowStoryCategory AndAlso StoryDataRow IsNot Nothing Then

                    StoryDataRow.Delete()

                End If

            End If

            Return DataTable
        Catch
            Return Nothing
        End Try

    End Function
    Public Function GetAlertCategoriesDT(ByVal intTypeID As Integer) As DataTable
        Dim parameterTypeID As New SqlParameter("@Type", SqlDbType.Int)
        parameterTypeID.Value = intTypeID

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_Get_Alert_Cat_By_TypeID", "DtAlertCategories", parameterTypeID)
        Catch
            Return Nothing
        End Try
    End Function
    Public Function GetAlertTypes() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_Get_Alert_Types")
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetAlertTypes", Err.Description)
        End Try
        Return dr
    End Function
    Public Function UpdateAlerts(ByVal intAlertID As Integer, ByVal intAlertRcptID As Integer, ByVal dtDisDate As Date) As Boolean

        Dim arParams(3) As SqlParameter

        Dim parameterAlertID As New SqlParameter("@AlertID", SqlDbType.Int)
        parameterAlertID.Value = intAlertID
        arParams(0) = parameterAlertID
        Dim parameterAlertRcptID As New SqlParameter("@AlertRcptID", SqlDbType.Int)
        parameterAlertRcptID.Value = intAlertRcptID
        arParams(1) = parameterAlertRcptID
        Dim parameterDisDate As New SqlParameter("@DisDate", SqlDbType.DateTime)
        parameterDisDate.Value = dtDisDate
        arParams(2) = parameterDisDate

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_update_alert", arParams)
            Return True
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:UpdateAlerts", Err.Description)
            Return False
        End Try

    End Function
    ''Public Function GetAlertLevel(ByVal intAlertID As Integer, ByVal strAlertLevel As String) As SqlDataReader
    ''    Dim dr As SqlDataReader
    ''    Dim arParams(2) As SqlParameter
    ''    Dim parameterAlertID As New SqlParameter("@AlertID", SqlDbType.Int)
    ''    parameterAlertID.Value = intAlertID
    ''    arParams(0) = parameterAlertID
    ''    Dim parameterAlertLevel As New SqlParameter("@AlertLevel", SqlDbType.VarChar, 50)
    ''    parameterAlertLevel.Value = strAlertLevel
    ''    arParams(1) = parameterAlertLevel

    ''    Try
    ''        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Get_AlertLevel", arParams)
    ''    Catch
    ''        Err.Raise(Err.Number, "Class:cAlerts Routine:GetAlertLevel", Err.Description)
    ''    End Try
    ''    Return dr
    ''End Function
    Public Overloads Function AddAlerts(ByVal intAlertTypeID As Integer, ByVal intAlertCatID As Integer, ByVal strSubject As String, ByVal strBody As String, ByVal dtGenerated As Date,
                                   ByVal strOFCode As String, ByVal strCLCode As String, ByVal strDIVCode As String, ByVal strPRDCode As String, ByVal strCMPCode As String,
                                   ByVal intJOBNumber As Integer, ByVal intJOBComponentNbr As Integer, ByVal strEMPCode As String, ByVal strALertLevel As String,
                                   ByVal strAlertUser As String) As Integer

        Dim arParams(16) As SqlParameter

        Dim parameterALERT_TYPE_ID As New SqlParameter("@ALERT_TYPE_ID", SqlDbType.Int)
        parameterALERT_TYPE_ID.Value = intAlertTypeID
        arParams(0) = parameterALERT_TYPE_ID
        Dim parameterALERT_CAT_ID As New SqlParameter("@ALERT_CAT_ID", SqlDbType.Int)
        parameterALERT_CAT_ID.Value = intAlertCatID
        arParams(1) = parameterALERT_CAT_ID
        Dim parameterSUBJECT As New SqlParameter("@SUBJECT", SqlDbType.VarChar, 254)
        parameterSUBJECT.Value = strSubject
        arParams(2) = parameterSUBJECT
        Dim parameterBODY As New SqlParameter("@BODY", SqlDbType.Text)
        parameterBODY.Value = strBody
        arParams(3) = parameterBODY
        Dim parameterGENERATED As New SqlParameter("@GENERATED", SqlDbType.DateTime)
        parameterGENERATED.Value = dtGenerated
        arParams(4) = parameterGENERATED
        Dim parameterPRIORITY As New SqlParameter("@PRIORITY", SqlDbType.Int)
        parameterPRIORITY.Value = 3
        arParams(5) = parameterPRIORITY
        Dim parameterOF_CODE As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 4)
        parameterOF_CODE.Value = strOFCode
        arParams(6) = parameterOF_CODE
        Dim parameterCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        parameterCL_CODE.Value = strCLCode
        arParams(7) = parameterCL_CODE
        Dim parameterDIV_CODE As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
        parameterDIV_CODE.Value = strDIVCode
        arParams(8) = parameterDIV_CODE
        Dim parameterPRD_CODE As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
        parameterPRD_CODE.Value = strPRDCode
        arParams(9) = parameterPRD_CODE
        Dim parameterCMP_CODE As New SqlParameter("@CMP_CODE", SqlDbType.VarChar, 6)
        If strCMPCode.Trim() = "" Then
            parameterCMP_CODE.Value = System.DBNull.Value
        Else
            parameterCMP_CODE.Value = strCMPCode
        End If
        arParams(10) = parameterCMP_CODE
        Dim parameterJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJOB_NUMBER.Value = intJOBNumber
        arParams(11) = parameterJOB_NUMBER
        Dim parameterJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        parameterJOB_COMPONENT_NBR.Value = intJOBComponentNbr
        arParams(12) = parameterJOB_COMPONENT_NBR
        Dim parameterEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterEMP_CODE.Value = strEMPCode
        arParams(13) = parameterEMP_CODE
        Dim parameterALERT_LEVEL As New SqlParameter("@ALERT_LEVEL", SqlDbType.VarChar, 50)
        parameterALERT_LEVEL.Value = strALertLevel
        arParams(14) = parameterALERT_LEVEL
        Dim parameterALERTUser As New SqlParameter("@ALERT_USER", SqlDbType.VarChar, 100)
        parameterALERTUser.Value = strAlertUser
        arParams(15) = parameterALERTUser

        Try

            Return CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_add_alert", arParams))

        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:AddAlerts", Err.Description)
        End Try

    End Function
    Public Overloads Function AddAlerts(ByVal intAlertTypeID As Integer, ByVal intAlertCatID As Integer, ByVal strSubject As String, ByVal strBody As String, ByVal dtGenerated As Date,
                                   ByVal strOFCode As String, ByVal strCLCode As String, ByVal strDIVCode As String, ByVal strPRDCode As String, ByVal strCMPCode As String,
                                   ByVal intJOBNumber As Integer, ByVal intJOBComponentNbr As Integer, ByVal strEMPCode As String, ByVal strALertLevel As String,
                                   ByVal strAlertUser As String, ByVal strBodyHTML As String) As Integer

        Dim arParams(16) As SqlParameter

        Dim parameterALERT_TYPE_ID As New SqlParameter("@ALERT_TYPE_ID", SqlDbType.Int)
        parameterALERT_TYPE_ID.Value = intAlertTypeID
        arParams(0) = parameterALERT_TYPE_ID
        Dim parameterALERT_CAT_ID As New SqlParameter("@ALERT_CAT_ID", SqlDbType.Int)
        parameterALERT_CAT_ID.Value = intAlertCatID
        arParams(1) = parameterALERT_CAT_ID
        Dim parameterSUBJECT As New SqlParameter("@SUBJECT", SqlDbType.VarChar, 254)
        parameterSUBJECT.Value = strSubject
        arParams(2) = parameterSUBJECT
        Dim parameterBODY As New SqlParameter("@BODY", SqlDbType.Text)
        parameterBODY.Value = strBody
        arParams(3) = parameterBODY
        Dim parameterGENERATED As New SqlParameter("@GENERATED", SqlDbType.DateTime)
        parameterGENERATED.Value = dtGenerated
        arParams(4) = parameterGENERATED
        Dim parameterPRIORITY As New SqlParameter("@PRIORITY", SqlDbType.Int)
        parameterPRIORITY.Value = 0
        arParams(5) = parameterPRIORITY
        Dim parameterOF_CODE As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 4)
        parameterOF_CODE.Value = strOFCode
        arParams(6) = parameterOF_CODE
        Dim parameterCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        parameterCL_CODE.Value = strCLCode
        arParams(7) = parameterCL_CODE
        Dim parameterDIV_CODE As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
        parameterDIV_CODE.Value = strDIVCode
        arParams(8) = parameterDIV_CODE
        Dim parameterPRD_CODE As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
        parameterPRD_CODE.Value = strPRDCode
        arParams(9) = parameterPRD_CODE
        Dim parameterCMP_CODE As New SqlParameter("@CMP_ID", SqlDbType.Int)
        parameterCMP_CODE.Value = CType(strCMPCode, Integer)
        arParams(10) = parameterCMP_CODE
        Dim parameterJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJOB_NUMBER.Value = intJOBNumber
        arParams(11) = parameterJOB_NUMBER
        Dim parameterJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
        parameterJOB_COMPONENT_NBR.Value = intJOBComponentNbr
        arParams(12) = parameterJOB_COMPONENT_NBR
        Dim parameterEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterEMP_CODE.Value = strEMPCode
        arParams(13) = parameterEMP_CODE
        Dim parameterALERT_LEVEL As New SqlParameter("@ALERT_LEVEL", SqlDbType.VarChar, 50)
        parameterALERT_LEVEL.Value = strALertLevel
        arParams(14) = parameterALERT_LEVEL
        Dim parameterALERTUser As New SqlParameter("@ALERT_USER", SqlDbType.VarChar, 100)
        parameterALERTUser.Value = strAlertUser
        arParams(15) = parameterALERTUser
        Dim parameterBODYHTML As New SqlParameter("@BODY_HTML", SqlDbType.Text)
        parameterBODYHTML.Value = strBodyHTML
        arParams(16) = parameterBODYHTML

        Try

            Return CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_add_alert_bodyHTML", arParams))

        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:AddAlerts", Err.Description)
        End Try

    End Function
    Public Function addStringtoAlert(ByVal AlertID As Integer, ByVal Colname As String, ByVal ColValue As String) As Integer
        Dim SQLString As String
        Dim oSQL As SqlHelper

        SQLString = "UPDATE ALERT SET " & Colname & " = '" & ColValue & "' WHERE ALERT_ID = " & CStr(AlertID)

        Try
            Return CInt(oSQL.ExecuteScalar(mConnString, CommandType.Text, SQLString))

        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:AddAlerts", Err.Description)
        End Try

    End Function
    Public Function AddAlertRecipient(ByVal AlertID As Integer, ByVal EmpCode As String, Optional ByVal EmailAddress As String = "") As Boolean
        Dim arParams(3) As SqlParameter

        Dim parameterALERTID As New SqlParameter("@ALERTID", SqlDbType.Int)
        parameterALERTID.Value = AlertID
        arParams(0) = parameterALERTID
        Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(1) = parameterEmpCode
        Dim parameterEmailAddress As New SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50)
        parameterEmailAddress.Value = EmailAddress
        arParams(2) = parameterEmailAddress

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_alert_add_recipient", arParams)
            Return True
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cAlerts Routine:AddAlertRecipient", Err.Description)
            Return False
        End Try

    End Function
    Public Function AddAlertCPRecipient(ByVal AlertID As Integer, ByVal CDPID As Integer, ByVal EmailAddress As String) As Boolean
        Dim arParams(3) As SqlParameter

        Dim parameterALERTID As New SqlParameter("@ALERTID", SqlDbType.Int)
        parameterALERTID.Value = AlertID
        arParams(0) = parameterALERTID
        Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterCDPID.Value = CDPID
        arParams(1) = parameterCDPID
        Dim parameterEmailAddress As New SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50)
        parameterEmailAddress.Value = EmailAddress
        arParams(2) = parameterEmailAddress

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_alert_add_cprecipient", arParams)
            Return True
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cAlerts Routine:AddAlertCPRecipient", Err.Description)
            Return False
        End Try

    End Function
    Public Function CPGetContactCodeID(ByVal ContactCode As String, ByVal ClientCode As String) As Integer
        Dim SessionKey As String = "CPGetContactCodeID" & ContactCode & ClientCode
        Dim ReturnInteger As Integer = 0
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter
            Dim parameterContactCode As New SqlParameter("@ContactCode", SqlDbType.VarChar, 6)
            parameterContactCode.Value = ContactCode
            arParams(0) = parameterContactCode
            Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClientCode.Value = ClientCode
            arParams(1) = parameterClientCode

            Try
                ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_cp_getContactCodeID", arParams)
            Catch
                ReturnInteger = 0
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnInteger
        Else
            ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        End If

        Return ReturnInteger

    End Function
    Public Function getContactCode(ByVal ucode As Integer) As String
        Dim SessionKey As String = "getContactCode" & ucode
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim oSql As SqlHelper
            Dim parameterUserCode As New SqlParameter("@CDPID", SqlDbType.Int)
            parameterUserCode.Value = ucode

            Try
                ReturnString = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_cp_GetContactCode", parameterUserCode)
            Catch
                ReturnString = ""
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString
    End Function
    Public Function GetCPAlertEmailFlag(ByVal CDPID As Integer) As Integer
        Dim ThisReturn As Integer
        Dim dr As SqlDataReader

        Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterCDPID.Value = CDPID

        Try
            ThisReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_cp_getCPUsersEmailFlag", parameterCDPID)
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetCCEmailflag", Err.Description)
        End Try
        'Do While dr.Read
        '    ThisReturn = dr.GetInt16(7)
        'Loop
        'dr.Close()
        Return ThisReturn
    End Function
    Public Function GetEmail(ByVal CDPID As Integer) As String
        Dim ThisReturn As String
        Dim dr As SqlDataReader

        Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterCDPID.Value = CDPID

        Try
            ThisReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_cp_getCPUsersEmail", parameterCDPID)
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetCCEmail", Err.Description)
        End Try
        'Do While dr.Read
        '    ThisReturn = dr.GetString(2)
        'Loop
        'dr.Close()
        Return ThisReturn
    End Function
    Public Function GetAlertClientContact(ByVal CDPID As Integer) As String
        Dim ThisReturn As String
        Dim dr As SqlDataReader

        Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterCDPID.Value = CDPID

        Try
            ThisReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Get_AlertClientContact", parameterCDPID)
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetCC", Err.Description)
        End Try
        'Do While dr.Read
        '    ThisReturn = dr.GetString(2)
        'Loop
        'dr.Close()
        Return ThisReturn
    End Function
    Public Function GetNames(ByVal strOffice As String, ByVal strClient As String, ByVal strDivision As String, ByVal strProduct As String, ByVal strCampaign As String, ByVal intJobNumber As Integer, ByVal intJobComponent As Integer) As SqlDataReader
        Dim dr As SqlDataReader

        Dim arParams(7) As SqlParameter

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar, 6)
        parameterOffice.Value = strOffice
        arParams(0) = parameterOffice
        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClient.Value = strClient
        arParams(1) = parameterClient
        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivision.Value = strDivision
        arParams(2) = parameterDivision
        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProduct.Value = strProduct
        arParams(3) = parameterProduct
        Dim parameterCampaign As New SqlParameter("@Campaign", SqlDbType.VarChar, 6)
        parameterCampaign.Value = strCampaign
        arParams(4) = parameterCampaign
        Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        parameterJobNumber.Value = intJobNumber
        arParams(5) = parameterJobNumber
        Dim parameterJobComponent As New SqlParameter("@JobComponent", SqlDbType.Int)
        parameterJobComponent.Value = intJobComponent
        arParams(6) = parameterJobComponent

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Get_Alert_Names", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetNames", Err.Description)
        End Try
        Return dr
    End Function
    Public Function GetCampaignAlertGroup(ByVal CmpIdentifier As Integer) As String
        Try
            Dim StrSQL = "SELECT ISNULL(ALERT_GROUP,'')  FROM CAMPAIGN WITH(NOLOCK) WHERE CMP_IDENTIFIER = " & CmpIdentifier.ToString()
            Return oSQL.ExecuteScalar(mConnString, CommandType.Text, StrSQL)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GetAlertUserEmail(ByVal strUserName As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim parameterUserName As New SqlParameter("@UserName", SqlDbType.VarChar, 6)
        parameterUserName.Value = strUserName

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Get_Alert_UserEmail", parameterUserName)
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetAlertUserEmail", Err.Description)
        End Try
        Return dr
    End Function
    Public Function GetDefaultGroup(ByVal strClient As String, ByVal strDivision As String, ByVal strProduct As String, ByVal intJobNumber As Integer, ByVal intJobComponent As Integer) As String
        Dim dr As SqlDataReader
        Dim strGroup As String
        Dim arParams(5) As SqlParameter

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClient.Value = strClient
        arParams(0) = parameterClient
        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivision.Value = strDivision
        arParams(1) = parameterDivision
        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProduct.Value = strProduct
        arParams(2) = parameterProduct
        Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        parameterJobNumber.Value = intJobNumber
        arParams(3) = parameterJobNumber
        Dim parameterJobComponent As New SqlParameter("@JobComponent", SqlDbType.Int)
        parameterJobComponent.Value = intJobComponent
        arParams(4) = parameterJobComponent

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Get_Alert_DefaultGroup", arParams)

            If dr.HasRows Then
                Do While dr.Read
                    If IsDBNull(dr("EmailGroup")) Then
                        strGroup = ""
                    Else
                        strGroup = CStr(dr("EmailGroup"))
                    End If
                Loop
            Else
                strGroup = ""
            End If
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetDefaultGroup", Err.Description)
        End Try
        Return strGroup
    End Function
    Public Function LoadEmailGroups(ByVal strGroup As String, ByRef treeview As Telerik.Web.UI.RadTreeView, Optional ByVal client As String = "", Optional ByVal division As String = "", Optional ByVal product As String = "", Optional ByVal level As String = "", Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNbr As Integer = 0, Optional ByVal ShowAutoGroup As Boolean = False)
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader

        Dim arP(4) As SqlParameter

        Dim parameterGroup As New SqlParameter("@Group", SqlDbType.VarChar, 50)
        parameterGroup.Value = strGroup.Trim()
        arP(0) = parameterGroup

        Dim parameterJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJOB_NUMBER.Value = JobNumber
        arP(1) = parameterJOB_NUMBER

        Dim parameterJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        parameterJOB_COMPONENT_NBR.Value = JobComponentNbr
        arP(2) = parameterJOB_COMPONENT_NBR

        Dim parameterAUTO_GROUP As New SqlParameter("@AUTO_GROUP", SqlDbType.SmallInt)
        If ShowAutoGroup = True Then
            parameterAUTO_GROUP.Value = 1
        Else
            parameterAUTO_GROUP.Value = 0
        End If
        arP(3) = parameterAUTO_GROUP

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Get_Alert_EmailGroups", arP)
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:LoadEmailGroups", Err.Description)
        End Try

        treeview.Nodes.Clear()
        treeview.Nodes.Add(New Telerik.Web.UI.RadTreeNode("Alert Groups", "Root"))
        treeview.FindNodeByValue("Root").Checkable = False
        treeview.FindNodeByValue("Root").Expanded = True
        treeview.CheckBoxes = True

        ' Populate Treeview.
        Do While dr.Read()
            Dim rootNode As Telerik.Web.UI.RadTreeNode = treeview.FindNodeByValue(dr("EMPGROUP"))
            If Not rootNode Is Nothing Then
                Dim newNode As New Telerik.Web.UI.RadTreeNode(dr("DESCRIPTION"), dr("EMPCODE"))
                newNode.Checked = dr("Checked")

                If newNode.Checked Then
                    newNode.Expanded = True
                End If

                rootNode.Nodes.Add(newNode)
            End If
            'oTree.Add(dr("EMPGROUP"), dr("EMPCODE"), dr("DESCRIPTION"), dr("Expand"), dr("icon"))
        Loop
        dr.Close()
        If level <> "OF" And client <> "" Then
            Dim arParams(3) As SqlParameter
            Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
            parameterClient.Value = client
            arParams(0) = parameterClient
            Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar, 6)
            parameterDivision.Value = division
            arParams(1) = parameterDivision
            Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar, 6)
            parameterProduct.Value = product
            arParams(2) = parameterProduct
            Try
                'dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_getCPUsers", parameterClient)
                dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_getCPUsersAlerts", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cAlerts Routine:LoadClientContacts", Err.Description)
            End Try
            If dr2.HasRows = True Then
                treeview.Nodes.Add(New Telerik.Web.UI.RadTreeNode("Client Contacts", "Root2"))
                treeview.FindNodeByValue("Root2").Checkable = False
                treeview.FindNodeByValue("Root2").Expanded = True
                treeview.CheckBoxes = True

                ' Populate Treeview.
                Do While dr2.Read()
                    Dim rootNode2 As Telerik.Web.UI.RadTreeNode = treeview.FindNodeByValue("Root2")
                    If Not rootNode2 Is Nothing And dr2("CP_ALERTS") = 1 Then
                        Dim newNode2 As New Telerik.Web.UI.RadTreeNode(dr2("CONT_FML"), dr2("CONT_CODE") & "(CC)")

                        If newNode2.Checked Then
                            newNode2.Expanded = True
                        End If

                        rootNode2.Nodes.Add(newNode2)
                    End If
                    'oTree.Add(dr("EMPGROUP"), dr("EMPCODE"), dr("DESCRIPTION"), dr("Expand"), dr("icon"))
                Loop
                dr2.Close()
            End If
        End If

    End Function
    Public Function LoadEmailGroupsWebUI(ByVal strGroup As String, ByRef treeview As Telerik.Web.UI.RadTreeView, Optional ByVal client As String = "",
                                         Optional ByVal division As String = "", Optional ByVal product As String = "",
                                         Optional ByVal level As String = "", Optional ByVal JobNumber As Integer = 0,
                                         Optional ByVal JobComponentNbr As Integer = 0, Optional ByVal ShowAutoGroup As Boolean = False, Optional ByVal CmpIdentifier As Integer = 0,
                                         Optional ByVal isClientPortal As Boolean = False)
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        Dim drCP As SqlDataReader
        Dim osec As New cSecurity(HttpContext.Current.Session("ConnString"))

        Dim arP(4) As SqlParameter
        Dim GrpCode As String = ""
        'override user input with db value
        If (JobNumber > 0 And JobComponentNbr > 0) Or
            CmpIdentifier > 0 Then
            Dim StrSQL As String = ""
            If JobNumber > 0 And JobComponentNbr > 0 Then
                StrSQL = "SELECT ISNULL(EMAIL_GR_CODE,'') FROM JOB_COMPONENT WITH(NOLOCK) WHERE JOB_NUMBER = " & JobNumber & " AND JOB_COMPONENT_NBR = " & JobComponentNbr & ";"
            ElseIf CmpIdentifier > 0 Then
                StrSQL = "SELECT ISNULL(ALERT_GROUP,'') FROM CAMPAIGN WITH(NOLOCK) WHERE CMP_IDENTIFIER = " & CmpIdentifier & ";"
            End If
            Try
                GrpCode = oSQL.ExecuteScalar(mConnString, CommandType.Text, StrSQL)
            Catch ex As Exception
                GrpCode = ""
            End Try
            If GrpCode <> "" Then
                strGroup = GrpCode
            End If
        End If

        If isClientPortal = True Then
            If level = "PS" Then
                level = "JC"
            End If
            If level = "CL" Or GrpCode = "" Then
                Dim parameterGroup As New SqlParameter("@Group", SqlDbType.VarChar, 50)
                parameterGroup.Value = strGroup.Trim
                Try
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_GetAlertGroup", parameterGroup)
                Catch
                    Err.Raise(Err.Number, "Class:cAlerts Routine:LoadEmailGroups", Err.Description)
                End Try
            End If
            If level = "JC" And GrpCode <> "" Then
                Dim arParams(3) As SqlParameter
                Dim parameterGroup As New SqlParameter("@Group", SqlDbType.VarChar, 50)
                parameterGroup.Value = strGroup.Trim
                arParams(0) = parameterGroup

                Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
                parameterJobNum.Value = JobNumber
                arParams(1) = parameterJobNum

                Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.Int)
                parameterJobCompNum.Value = JobComponentNbr
                arParams(2) = parameterJobCompNum

                Try
                    dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_GetAlertRecipients", arParams)
                Catch
                    Err.Raise(Err.Number, "Class:cAlerts Routine:LoadEmailGroupsCP", Err.Description)
                End Try
            End If

            drCP = osec.getUsersCPData(HttpContext.Current.Session("UserID"))

        Else
            Dim parameterGroup As New SqlParameter("@Group", SqlDbType.VarChar, 50)
            parameterGroup.Value = strGroup.Trim()
            arP(0) = parameterGroup

            Dim parameterJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            parameterJOB_NUMBER.Value = JobNumber
            arP(1) = parameterJOB_NUMBER

            Dim parameterJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            parameterJOB_COMPONENT_NBR.Value = JobComponentNbr
            arP(2) = parameterJOB_COMPONENT_NBR

            Dim parameterAUTO_GROUP As New SqlParameter("@AUTO_GROUP", SqlDbType.SmallInt)
            If ShowAutoGroup = True Then
                parameterAUTO_GROUP.Value = 1
            Else
                parameterAUTO_GROUP.Value = 0
            End If
            arP(3) = parameterAUTO_GROUP

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Get_Alert_EmailGroups", arP)
            Catch
                Err.Raise(Err.Number, "Class:cAlerts Routine:LoadEmailGroups", Err.Description)
            End Try
        End If

        treeview.Nodes.Clear()
        treeview.Nodes.Add(New Telerik.Web.UI.RadTreeNode("Alert Groups", "Root"))
        treeview.FindNodeByValue("Root").Checkable = False
        treeview.FindNodeByValue("Root").Expanded = True
        treeview.CheckBoxes = True

        If JobNumber > 0 Then
            Dim oTS As wvTimeSheet.cTimeSheet = New wvTimeSheet.cTimeSheet(CStr(HttpContext.Current.Session("ConnString")))
            oTS.GetJobInfo(JobNumber, "", "", client, division, product)
        End If

        ' Populate Treeview.
        Do While dr.Read()
            Dim rootNode As Telerik.Web.UI.RadTreeNode = treeview.FindNodeByValue(dr("EMPGROUP"))
            If Not rootNode Is Nothing And dr("EMPGROUP") = "Root" Then
                Dim newNode As New Telerik.Web.UI.RadTreeNode(dr("DESCRIPTION"), dr("EMPCODE"))
                newNode.Checked = dr("Checked")

                If newNode.Checked Then
                    newNode.Expanded = True
                End If

                rootNode.Nodes.Add(newNode)
            Else
                rootNode = treeview.FindNodeByValue(dr("EMPGROUP").ToString() & ":Root")
                If Not rootNode Is Nothing Then
                    Dim newNode As New Telerik.Web.UI.RadTreeNode(dr("DESCRIPTION"), dr("EMPCODE"))
                    newNode.Checked = dr("Checked")

                    If newNode.Checked Then
                        newNode.Expanded = True
                    End If

                    rootNode.Nodes.Add(newNode)
                End If
            End If
        Loop
        dr.Close()
        If level <> "OF" And client <> "" Then
            Dim arParams(3) As SqlParameter
            Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
            parameterClient.Value = client
            arParams(0) = parameterClient
            Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar, 6)
            parameterDivision.Value = division
            arParams(1) = parameterDivision
            Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar, 6)
            parameterProduct.Value = product
            arParams(2) = parameterProduct
            Try
                dr2 = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_getCPUsersAlerts", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cAlerts Routine:LoadClientContacts", Err.Description)
            End Try
            If isClientPortal = True Then
                If drCP.HasRows = True Then
                    drCP.Read()
                    If drCP("AGENCY_CONTACT_CODE").ToString <> "" Then
                        treeview.Nodes.Add(New Telerik.Web.UI.RadTreeNode("Agency Contact", "Root3"))
                        treeview.FindNodeByValue("Root3").Checkable = False
                        treeview.FindNodeByValue("Root3").Expanded = True
                        treeview.CheckBoxes = True
                        ' Populate Treeview.

                        Dim rootNode3 As Telerik.Web.UI.RadTreeNode = treeview.FindNodeByValue("Root3")
                        If Not rootNode3 Is Nothing Then
                            Dim newNode3 As New Telerik.Web.UI.RadTreeNode(drCP("CONTACT_NAME"), drCP("AGENCY_CONTACT_CODE"))

                            If newNode3.Checked Then
                                newNode3.Expanded = True
                            End If

                            rootNode3.Nodes.Add(newNode3)
                        End If
                    End If
                    drCP.Close()
                End If
            End If
            If dr2.HasRows = True Then
                treeview.Nodes.Add(New Telerik.Web.UI.RadTreeNode("Client Contacts", "Root2"))
                treeview.FindNodeByValue("Root2").Checkable = False
                treeview.FindNodeByValue("Root2").Expanded = True
                treeview.CheckBoxes = True
                ' Populate Treeview.
                Do While dr2.Read()
                    Dim rootNode2 As Telerik.Web.UI.RadTreeNode = treeview.FindNodeByValue("Root2")
                    If Not rootNode2 Is Nothing And dr2("CP_ALERTS") = 1 Then
                        Dim newNode2 As New Telerik.Web.UI.RadTreeNode(dr2("CONT_FML"), dr2("CONT_CODE") & "(CC)")

                        If newNode2.Checked Then
                            newNode2.Expanded = True
                        End If

                        rootNode2.Nodes.Add(newNode2)
                    End If
                Loop
                dr2.Close()
            End If
        End If

    End Function
    Public Function GetAgencyPDFSettings() As DataTable
        Dim StrSQL As String = "SELECT ISNULL(EMAIL_ATTACH_DEF,0) AS EMAIL_ATTACH_DEF,ISNULL(PDF_ALERT_ONLY,0) AS PDF_ALERT_ONLY FROM AGENCY WITH(NOLOCK);"
        Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, StrSQL, "DtSettings")
    End Function

    Public Function UpdateAllReviewRecipients(ByRef SecuritySession As AdvantageFramework.Security.Session,
                                              ByVal AlertID As Integer, ByVal AlertCategoryID As Integer, ByVal IncludeOriginator As Boolean,
                                              ByRef CurrentEmployeeeRefreshed As Boolean, ByRef EmailSent As Boolean,
                                              ByVal CustomSubject As String, ByVal CustomComment As String,
                                              ByVal SendEmail As Boolean) As Boolean
        If AlertID > 0 Then

            Try

                Dim EmployeeCodes As New Generic.List(Of String)
                Dim ClientContactIds As New Generic.List(Of Integer)
                Dim EmpString As String = String.Empty
                Dim CpString As String = String.Empty

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Try
                        EmployeeCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM ALERT_RCPT WHERE ALERT_ID = {0} UNION SELECT EMP_CODE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0};", AlertID)).ToList
                    Catch ex As Exception
                    End Try
                    Try
                        ClientContactIds = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CDP_CONTACT_ID FROM CP_ALERT_RCPT WHERE ALERT_ID = {0} UNION SELECT CDP_CONTACT_ID FROM CP_ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0};", AlertID)).ToList
                    Catch ex As Exception
                    End Try

                    If EmployeeCodes IsNot Nothing AndAlso EmployeeCodes.Count > 0 Then

                        For Each EmpCode As String In EmployeeCodes

                            EmpString &= "'" & EmpCode & "',"

                        Next

                        EmpString = MiscFN.CleanStringForSplit(EmpString, ",")

                    End If
                    If ClientContactIds IsNot Nothing AndAlso ClientContactIds.Count > 0 Then

                        For Each ClId As Integer In ClientContactIds

                            CpString &= ClId.ToString & ","

                        Next

                        CpString = MiscFN.CleanStringForSplit(CpString, ",")

                    End If

                    If AlertCategoryID > 0 OrElse String.IsNullOrWhiteSpace(CustomComment) = False Then

                        Dim Alert As AdvantageFramework.Database.Entities.Alert

                        Alert = Nothing
                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                        If Alert IsNot Nothing Then

                            Alert.AlertCategoryID = AlertCategoryID

                            If AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert) = True Then

                            End If

                            If String.IsNullOrWhiteSpace(CustomComment) = False Then

                                Try

                                    Dim AlertComment As New AdvantageFramework.Database.Entities.AlertComment

                                    AlertComment.Alert = Alert
                                    AlertComment.AlertID = AlertID
                                    AlertComment.UserCode = SecuritySession.UserCode
                                    AlertComment.Comment = CustomComment
                                    AlertComment.GeneratedDate = Now.Date

                                    AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment)

                                Catch ex As Exception
                                End Try

                            End If

                        End If

                    End If


                End Using

                UpdateAlertRecipients(AlertID, EmpString, "", True)
                UpdateAlertRecipientsCP(AlertID, CpString, "", True)

                If SendEmail = True Then

                    Dim eso As New EmailSessionObject(SecuritySession.ConnectionString,
                                                  SecuritySession.UserCode,
                                                  SecuritySession,
                                                  HttpContext.Current.Session("WebvantageURL"),
                                                  HttpContext.Current.Session("ClientPortalURL"))

                    With eso

                        .AlertId = AlertID

                        If String.IsNullOrWhiteSpace(CustomSubject) = True Then

                            .Subject = "[Review Request]"

                        Else

                            .Subject = String.Format("[Review Request] {0}", CustomSubject)

                        End If

                        .IsClientPortal = MiscFN.IsClientPortal
                        .IncludeOriginator = IncludeOriginator
                        .SessionID = HttpContext.Current.Session.SessionID.ToString()
                        .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath

                        .Send()

                    End With

                    EmailSent = True

                End If

                If EmployeeCodes IsNot Nothing AndAlso EmployeeCodes.Contains(HttpContext.Current.Session("EmpCode")) = True Then

                    CurrentEmployeeeRefreshed = True

                Else

                    CurrentEmployeeeRefreshed = False

                End If

                Return True

            Catch ex As Exception
                Return False
            End Try

        End If

    End Function
    Public Sub New(Optional ByVal UserID As String = "", Optional ByVal EmpCode As String = "", Optional ByVal ConnectionString As String = "")
        Try
            If UserID <> "" Then
                mUserID = UserID
            Else
                mUserID = HttpContext.Current.Session("UserCode")
            End If
        Catch ex As Exception
            mUserID = ""
        End Try
        Try
            If EmpCode <> "" Then
                mEmpCode = EmpCode
            Else
                mEmpCode = HttpContext.Current.Session("EmpCode")
            End If
        Catch ex As Exception
            mEmpCode = ""
        End Try
        Try
            If ConnectionString <> "" Then
                mConnString = ConnectionString
            Else
                mConnString = HttpContext.Current.Session("ConnString")
            End If
        Catch ex As Exception
            mUserID = ""
        End Try

    End Sub

    Public Function LoadAlertsNew(ByVal EmpCode As String, ByVal InboxType As String, ByVal FilterLevel As String,
                                   ByVal OfficeCode As String,
                                   ByVal ClCode As String,
                                   ByVal DivCode As String,
                                   ByVal PrdCode As String,
                                   ByVal CmpIdentifier As String,
                                   ByVal CmpCode As String,
                                   ByVal JobNumber As Integer,
                                   ByVal JobComponentNbr As Integer,
                                   ByVal AlertTypeId As String,
                                   ByVal AlertCategoryId As String,
                                   ByVal StartDate As String,
                                   ByVal EndDate As String,
                                   ByVal AlertLevel As String,
                                   ByVal VnCode As String,
                                   ByVal EstimateNumber As Integer,
                                   ByVal EstComponentNbr As Integer,
                                   ByVal TaskCode As String,
                                   ByVal TaskDescription As String,
                                   ByVal ATBNumber As Integer,
                                   ByVal ShowAssignmentType As String,
                                   ByVal AlrtNotifyHdrId As Integer,
                                   ByVal AlertNotifyName As String,
                                   ByVal IncludeCompletedAssignments As Boolean,
                                   ByVal IsJobAlertsPage As Boolean,
                                   ByVal AlertAssignmentSeqNbr As Integer,
                                   ByVal GroupBy As String,
                                   ByVal SearchCriteria As String,
                                   ByVal AccountExecutiveCode As String,
                                   ByVal ManagerCode As String,
                                   ByVal StateId As Integer,
                                   ByVal RecordsToReturn As Integer,
                                   ByVal IsCount As Boolean,
                                   ByRef RecordCount As Integer,
                                   ByVal IncludeReviews As Boolean,
                                   ByVal IncludeBoardLevel As Boolean,
                                   ByRef ErrorMessage As String) As DataTable

        Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
        Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
        Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
        Dim DataTable As System.Data.DataTable = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(Me.mConnString, Me.mUserID)

            Try

                SqlConnection = DbContext.Database.Connection

                SqlCommand = New SqlClient.SqlCommand("usp_wv_dto_assignments_alerts_manager", SqlConnection)

                If String.IsNullOrWhiteSpace(EmpCode) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EMP_CODE", EmpCode))

                End If

                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@INBOX_TYPE", InboxType))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ShowAssignmentType", ShowAssignmentType))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IsJobAlertsPage", IsJobAlertsPage))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@GroupBy", GroupBy))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IncludeCompletedAssignments", IncludeCompletedAssignments))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RecordsToReturn", RecordsToReturn))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FILTER_LEVEL", FilterLevel))

                If String.IsNullOrWhiteSpace(SearchCriteria) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SEARCH_CRITERIA", SearchCriteria))

                End If

                If String.IsNullOrWhiteSpace(OfficeCode) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OFFICE_CODE", OfficeCode))

                End If

                If String.IsNullOrWhiteSpace(ClCode) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CL_CODE", ClCode))

                End If

                If String.IsNullOrWhiteSpace(DivCode) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DIV_CODE", DivCode))

                End If

                If String.IsNullOrWhiteSpace(PrdCode) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PRD_CODE", PrdCode))

                End If

                'If String.IsNullOrWhiteSpace(CmpIdentifier) = False Then

                '    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CMP_ID", CmpIdentifier))

                'End If

                If String.IsNullOrWhiteSpace(CmpCode) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CMP_CODE", CmpCode))

                End If

                If JobNumber <> 0 Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", JobNumber))

                End If

                If JobComponentNbr <> 0 Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JOB_COMP_NUMBER", JobComponentNbr))

                End If

                If String.IsNullOrWhiteSpace(AlertTypeId) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ALERT_TYPE_ID", AlertTypeId))

                End If

                If String.IsNullOrWhiteSpace(AlertCategoryId) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ALERT_CAT_ID", AlertCategoryId))

                End If

                If String.IsNullOrWhiteSpace(StartDate) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@START_DATE", StartDate))

                End If

                If String.IsNullOrWhiteSpace(EndDate) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@END_DATE", EndDate))

                End If

                If String.IsNullOrWhiteSpace(AlertLevel) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ALERT_LEVEL", AlertLevel))

                End If

                If String.IsNullOrWhiteSpace(VnCode) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@VN_CODE", VnCode))

                End If

                If EstimateNumber <> 0 Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ESTIMATE_NUMBER", EstimateNumber))

                End If

                If EstComponentNbr <> 0 Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EST_COMPONENT_NBR", EstComponentNbr))

                End If

                If String.IsNullOrWhiteSpace(TaskCode) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TASK_FNC_CODE", TaskCode))

                End If

                If String.IsNullOrWhiteSpace(TaskDescription) = False Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TASK_FNC_DESC", TaskDescription))

                End If

                If AlrtNotifyHdrId <> 0 Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ALRT_NOTIFY_HDR_ID", AlrtNotifyHdrId))

                End If

                If AlertAssignmentSeqNbr <> 0 Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", AlertAssignmentSeqNbr))

                End If

                If StateId <> 0 Then

                    SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ALERT_STATE_ID", StateId))

                End If

                'SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ATB_NUMBER", ATBNumber))
                'SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("", AlertNotifyName))
                'SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("", AccountExecutiveCode))
                'SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("", ManagerCode))
                'SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("", IsCount))

                SqlCommand.CommandType = CommandType.StoredProcedure

                SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

                Using SqlCommand

                    DataTable = New DataTable

                    SqlDataAdapter.Fill(DataTable)

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

        End Using

        Return DataTable

    End Function

    Public Function LoadAlertsNewer(ByVal EmployeeCode As String,
                                    ByVal SearchCriteria As String,
                                    ByVal InboxType As String,
                                    ByVal ShowAssignmentType As String,
                                    ByVal IsJobAlertsPage As Boolean,
                                    ByVal FilterLevel As String,
                                    ByVal OfficeCode As String,
                                    ByVal ClientCode As String,
                                    ByVal DivisionCode As String,
                                    ByVal ProductCode As String,
                                    ByVal CampaignCode As String,
                                    ByVal JobNumber As Integer?,
                                    ByVal JobComponentNumber As Short?,
                                    ByVal AlertTypeID As Integer?,
                                    ByVal AlertCategoryID As Integer?,
                                    ByVal StartDate As Date?,
                                    ByVal EndDate As Date?,
                                    ByVal AlertLevel As String,
                                    ByVal VendorCode As String,
                                    ByVal EstimateNumber As Integer?,
                                    ByVal EstimateComponentNumber As Short?,
                                    ByVal TaskFunctionCode As String,
                                    ByVal TaskDescription As String,
                                    ByVal AlertAssignmentSequenceNumber As Integer?,
                                    ByVal AlertTemplateID As Integer?,
                                    ByVal AlertStateID As Integer?,
                                    ByVal IncludeCompletedAssignments As Boolean,
                                    ByVal GroupBy As String,
                                    ByVal IsCount As Boolean,
                                    ByVal IncludeReviews As Boolean,
                                    ByVal IncludeBoardLevel As Boolean,
                                    ByVal IncludeBacklog As Boolean,
                                    ByRef RecordCount As Integer,
                                    ByRef ErrorMessage As String) As DataTable

        Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
        Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
        Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
        Dim DataTable As System.Data.DataTable = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(Me.mConnString, Me.mUserID)

            Try

                SqlConnection = DbContext.Database.Connection

                SqlCommand = New SqlClient.SqlCommand("advsp_alert_aam", SqlConnection)

                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(EmployeeCode) = False, EmployeeCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SearchCriteria",
                                                                                 IIf(String.IsNullOrWhiteSpace(SearchCriteria) = False, SearchCriteria, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@InboxType",
                                                                                 InboxType))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ShowAssignmentType",
                                                                                 ShowAssignmentType))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IsJobAlertsPage",
                                                                                 IsJobAlertsPage))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FilterLevel",
                                                                                 FilterLevel))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OfficeCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(OfficeCode) = False, OfficeCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClientCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(ClientCode) = False, ClientCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@DivisionCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(DivisionCode) = False, DivisionCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(ProductCode) = False, ProductCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CampaignCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(CampaignCode) = False, CampaignCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobNumber",
                                                                                 IIf(JobNumber IsNot Nothing AndAlso JobNumber > 0, JobNumber, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobComponentNumber",
                                                                                 IIf(JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0, JobComponentNumber, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlertTypeID",
                                                                                 IIf(AlertTypeID IsNot Nothing AndAlso AlertTypeID > 0, AlertTypeID, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlertCategoryID",
                                                                                 IIf(AlertCategoryID IsNot Nothing AndAlso AlertCategoryID > 0, AlertCategoryID, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@StartDate",
                                                                                 IIf(StartDate IsNot Nothing, StartDate, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EndDate",
                                                                                 IIf(EndDate IsNot Nothing, EndDate, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlertLevel",
                                                                                 IIf(String.IsNullOrWhiteSpace(AlertLevel) = False, AlertLevel, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@VendorCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(VendorCode) = False, VendorCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EstimateNumber",
                                                                                 IIf(EstimateNumber IsNot Nothing AndAlso EstimateNumber > 0, EstimateNumber, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EstimateComponentNumber",
                                                                                 IIf(EstimateComponentNumber IsNot Nothing AndAlso EstimateComponentNumber > 0, EstimateComponentNumber, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TaskFunctionCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(TaskFunctionCode) = False, TaskFunctionCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TaskDescription",
                                                                                 IIf(String.IsNullOrWhiteSpace(TaskDescription) = False, TaskDescription, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlertAssignmentSequenceNumber",
                                                                                 IIf(AlertAssignmentSequenceNumber IsNot Nothing AndAlso AlertAssignmentSequenceNumber > 0, AlertAssignmentSequenceNumber, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlertTemplateID",
                                                                                 IIf(AlertTemplateID IsNot Nothing AndAlso AlertTemplateID > 0, AlertTemplateID, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AlertStateID",
                                                                                 IIf(AlertStateID IsNot Nothing AndAlso AlertStateID > 0, AlertStateID, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IncludeCompletedAssignments",
                                                                                 IncludeCompletedAssignments))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@GroupBy",
                                                                                 GroupBy))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IsCount",
                                                                                 IsCount))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RecordCount",
                                                                                 RecordCount))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IncludeReviews",
                                                                                 IncludeReviews))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IncludeBoardLevel",
                                                                                 IncludeBoardLevel))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IncludeBacklog",
                                                                                 IncludeBacklog))

                SqlCommand.CommandType = CommandType.StoredProcedure

                SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

                Using SqlCommand

                    DataTable = New DataTable

                    SqlDataAdapter.Fill(DataTable)

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If DataTable IsNot Nothing AndAlso
                DataTable.Rows IsNot Nothing Then

                RecordCount = DataTable.Rows.Count

            End If

        End Using

        Return DataTable

    End Function

#End Region

End Class

<Serializable()>
Public Class CommentDocument

    Public Property Filename As String = ""
    Public Property DocumentId As Integer = 0
    Public Property MimeType As String = ""
    Public Property FileExtension As String = ""
    Public Property Title As String = ""

    Public Function ObjectToString(ByVal TheObject As Generic.List(Of CommentDocument)) As String

        Dim formatter As LosFormatter = New LosFormatter
        Dim writer As StringWriter = New StringWriter

        formatter.Serialize(writer, TheObject)

        Return writer.ToString()

    End Function
    Public Function StringToObject(ByVal TheString As String) As Generic.List(Of CommentDocument)

        Dim formatter As LosFormatter = New LosFormatter
        Dim reader As StringReader = New StringReader(TheString)

        Return CType(formatter.Deserialize(reader), Generic.List(Of CommentDocument))

    End Function

    Sub New()

    End Sub

End Class
