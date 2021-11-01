Public Class AdvantageOutlookAddin

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Inspectors As Microsoft.Office.Interop.Outlook.Inspectors = Nothing
    Private _EventLog As System.Diagnostics.EventLog = Nothing
    Private WithEvents _CommandBarPopup As Microsoft.Office.Core.CommandBarPopup = Nothing
    Private WithEvents _SetupCommandBarButton As Microsoft.Office.Core.CommandBarButton = Nothing
    'Private WithEvents _SyncCommandBarButton As Microsoft.Office.Core.CommandBarButton = Nothing
    Private _Session As AdvantageFramework.Security.Session = Nothing
    Private _AllowImportItem As Boolean = True
    Private _HasLoaded As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    'Private Function ImportICSFile(ByVal File As String, ByVal DeleteFileAfterImporting As Boolean) As Boolean

    '    'objects
    '    Dim AppointmentItem As Microsoft.Office.Interop.Outlook.AppointmentItem = Nothing
    '    Dim FileImported As Boolean = False
    '    Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder = Nothing
    '    Dim OutlookCalendar As Microsoft.Office.Interop.Outlook.MAPIFolder = Nothing
    '    Dim OutlookCalendarItem As Microsoft.Office.Interop.Outlook.AppointmentItem = Nothing
    '    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
    '    Dim EmployeeNonTaskList As List(Of AdvantageFramework.Database.Entities.EmployeeNonTask) = Nothing
    '    Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing

    '    Try

    '        If My.Settings.SyncOutlookAndAdvantageAppointments AndAlso My.Settings.ConnectionString <> "" AndAlso AdvantageFramework.Database.TestConnectionString(My.Settings.ConnectionString) Then

    '            My.Settings.SyncOutlookAndAdvantageAppointments = False

    '            My.Settings.Save()

    '            Try

    '                OutlookCalendar = Me.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar)

    '                Using DataContext = New AdvantageFramework.Database.DataContext(My.Settings.ConnectionString, "")

    '                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DataContext, Me.Application.Session.CurrentUser.Address)

    '                    If Employee IsNot Nothing Then

    '                        EmployeeNonTaskList = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeCode(DataContext, Employee.Code).ToList

    '                        If My.Computer.FileSystem.FileExists(File) Then

    '                            Try

    '                                AppointmentItem = Me.Application.Session.OpenSharedItem(File)

    '                                If AppointmentItem IsNot Nothing Then

    '                                    Try

    '                                        EmployeeNonTask = (From Entity In EmployeeNonTaskList.AsQueryable _
    '                                                            Where Entity.Type = "A" AndAlso _
    '                                                                  Entity.StartTime = AppointmentItem.Start AndAlso _
    '                                                                  Entity.EndTime = AppointmentItem.End AndAlso _
    '                                                                  Entity.Description = AppointmentItem.Subject AndAlso _
    '                                                                  CBool(Entity.IsAllDay.GetValueOrDefault(0)) = AppointmentItem.AllDayEvent _
    '                                                            Select Entity).Single

    '                                    Catch ex As Exception
    '                                        EmployeeNonTask = Nothing
    '                                    End Try

    '                                    If EmployeeNonTask IsNot Nothing Then

    '                                        AppointmentItem.BillingInformation = EmployeeNonTask.Type & EmployeeNonTask.ID.ToString

    '                                        OutlookCalendarItem = OutlookCalendar.Items.Find("[BillingInformation]=" + EmployeeNonTask.Type & EmployeeNonTask.ID.ToString)

    '                                        If OutlookCalendarItem IsNot Nothing Then

    '                                            OutlookCalendarItem.Delete()

    '                                        End If

    '                                    End If

    '                                    AppointmentItem.Save()

    '                                    FileImported = True

    '                                End If

    '                            Catch ex As Exception
    '                                FileImported = False
    '                            End Try

    '                            If FileImported = False Then

    '                                Try

    '                                    Folder = Me.Application.Session.OpenSharedFolder(File)

    '                                    For Each Item In Folder.Items

    '                                        If TypeOf Item Is Microsoft.Office.Interop.Outlook.AppointmentItem Then

    '                                            AppointmentItem = OutlookCalendar.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem)

    '                                            AppointmentItem.AllDayEvent = DirectCast(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).AllDayEvent
    '                                            AppointmentItem.Start = DirectCast(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).Start
    '                                            AppointmentItem.End = DirectCast(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).End
    '                                            AppointmentItem.Subject = DirectCast(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).Subject
    '                                            AppointmentItem.Body = DirectCast(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).Body
    '                                            AppointmentItem.Location = DirectCast(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).Location

    '                                            Try

    '                                                EmployeeNonTask = (From Entity In EmployeeNonTaskList.AsQueryable _
    '                                                                    Where Entity.Type = "A" AndAlso _
    '                                                                          Entity.StartTime = AppointmentItem.Start AndAlso _
    '                                                                          Entity.EndTime = AppointmentItem.End AndAlso _
    '                                                                          Entity.Description = AppointmentItem.Subject AndAlso _
    '                                                                          CBool(Entity.IsAllDay.GetValueOrDefault(0)) = AppointmentItem.AllDayEvent _
    '                                                                    Select Entity).Single

    '                                            Catch ex As Exception
    '                                                EmployeeNonTask = Nothing
    '                                            End Try

    '                                            If EmployeeNonTask IsNot Nothing Then

    '                                                AppointmentItem.BillingInformation = EmployeeNonTask.Type & EmployeeNonTask.ID.ToString

    '                                                OutlookCalendarItem = OutlookCalendar.Items.Find("[BillingInformation]=" + EmployeeNonTask.Type & EmployeeNonTask.ID.ToString)

    '                                                If OutlookCalendarItem IsNot Nothing Then

    '                                                    OutlookCalendarItem.Delete()

    '                                                End If

    '                                            End If

    '                                            AppointmentItem.Save()

    '                                        End If

    '                                    Next

    '                                    Folder.Delete()

    '                                    FileImported = True

    '                                Catch ex As Exception
    '                                    FileImported = False
    '                                End Try

    '                            End If

    '                        End If

    '                    End If

    '                End Using

    '            Catch ex As Exception

    '            Finally

    '                My.Settings.SyncOutlookAndAdvantageAppointments = True

    '                My.Settings.Save()

    '            End Try

    '        End If

    '        If DeleteFileAfterImporting Then

    '            My.Computer.FileSystem.DeleteFile(File)

    '        End If

    '    Catch ex As Exception
    '        FileImported = False
    '    Finally
    '        ImportICSFile = FileImported
    '    End Try

    'End Function
    Private Function ImportItem(ByVal File As String, ByVal IsTask As Boolean) As Boolean

        'objects
        Dim FileImported As Boolean = False
        Dim OutlookCalendar As Microsoft.Office.Interop.Outlook.MAPIFolder = Nothing
        Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
        Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
        Dim AppointmentItem As Microsoft.Office.Interop.Outlook.AppointmentItem = Nothing
        Dim TaskItem As Microsoft.Office.Interop.Outlook.TaskItem = Nothing
        Dim XmlTextReader As System.Xml.XmlTextReader = Nothing
        Dim XML As String = ""

        Try

            If (My.Settings.SyncOutlookAndAdvantageAppointments OrElse My.Settings.SyncAdvantageAppointmentsOnly) AndAlso _AllowImportItem Then

                _AllowImportItem = False

                Try

                    Try

                        XmlTextReader = New System.Xml.XmlTextReader(File)

                        Do Until XmlTextReader.Read() = False

                            If XmlTextReader.Name = "EmployeeNonTask" OrElse XmlTextReader.Name = "JobComponentTask" Then

                                XML = XmlTextReader.ReadOuterXml
                                Exit Do

                            End If

                        Loop

                    Catch ex As Exception
                        XML = ""
                    Finally

                        If XmlTextReader IsNot Nothing Then

                            XmlTextReader.Close()

                        End If

                        XmlTextReader = Nothing

                    End Try

                    If XML <> "" Then

                        If IsTask Then

                            JobComponentTask = AdvantageFramework.BaseClasses.ImportFromXML(XML, GetType(AdvantageFramework.Database.Entities.JobComponentTask))

                            If JobComponentTask IsNot Nothing Then

                                Try

                                    OutlookCalendar = Me.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderTasks)

                                    TaskItem = OutlookCalendar.Items.Find("[BillingInformation]=JobComponentTaskID" & JobComponentTask.ID)

                                    If TaskItem IsNot Nothing Then

                                        TaskItem.StartDate = JobComponentTask.StartDate.GetValueOrDefault("01/01/1900")
                                        TaskItem.DueDate = JobComponentTask.DueDate.GetValueOrDefault("01/01/1900")
                                        TaskItem.DateCompleted = JobComponentTask.CompletedDate.GetValueOrDefault("01/01/1900")
                                        TaskItem.Subject = JobComponentTask.Description
                                        TaskItem.Body = JobComponentTask.Description
                                        TaskItem.BillingInformation = "JobComponentTaskID" & JobComponentTask.ID

                                        TaskItem.Save()

                                    Else

                                        TaskItem = Me.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem)

                                        TaskItem.StartDate = JobComponentTask.StartDate.GetValueOrDefault("01/01/1900")
                                        TaskItem.DueDate = JobComponentTask.DueDate.GetValueOrDefault("01/01/1900")
                                        TaskItem.DateCompleted = JobComponentTask.CompletedDate.GetValueOrDefault("01/01/1900")
                                        TaskItem.Subject = JobComponentTask.Description
                                        TaskItem.Body = JobComponentTask.Description
                                        TaskItem.BillingInformation = "JobComponentTaskID" & JobComponentTask.ID

                                        TaskItem.Save()

                                    End If

                                    FileImported = True

                                Catch ex As Exception
                                    FileImported = False
                                End Try

                            End If

                        Else

                            EmployeeNonTask = AdvantageFramework.BaseClasses.ImportFromXML(XML, GetType(AdvantageFramework.Database.Entities.EmployeeNonTask))

                            If EmployeeNonTask IsNot Nothing Then

                                Try

                                    OutlookCalendar = Me.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar)

                                    AppointmentItem = OutlookCalendar.Items.Find("[BillingInformation]=" & EmployeeNonTask.Type & EmployeeNonTask.ID)

                                    If AppointmentItem IsNot Nothing Then

                                        AppointmentItem.AllDayEvent = EmployeeNonTask.IsAllDay
                                        AppointmentItem.Start = EmployeeNonTask.StartDateAndTime.Value
                                        AppointmentItem.End = EmployeeNonTask.EndDateAndTime.Value
                                        AppointmentItem.Subject = EmployeeNonTask.Description
                                        AppointmentItem.Body = EmployeeNonTask.Description
                                        AppointmentItem.BillingInformation = EmployeeNonTask.Type & EmployeeNonTask.ID

                                        If EmployeeNonTask.Type = "H" Then

                                            AppointmentItem.Categories = "Holiday"

                                        End If

                                        AppointmentItem.Save()

                                        AddHandler AppointmentItem.Write, AddressOf AppointmentWrite
                                        AddHandler AppointmentItem.BeforeDelete, AddressOf AppointmentBeforeDelete

                                    Else

                                        AppointmentItem = Me.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem)

                                        AppointmentItem.AllDayEvent = EmployeeNonTask.IsAllDay
                                        AppointmentItem.Start = EmployeeNonTask.StartDateAndTime.Value
                                        AppointmentItem.End = EmployeeNonTask.EndDateAndTime.Value
                                        AppointmentItem.Subject = EmployeeNonTask.Description
                                        AppointmentItem.Body = EmployeeNonTask.Description
                                        AppointmentItem.BillingInformation = EmployeeNonTask.Type & EmployeeNonTask.ID

                                        If EmployeeNonTask.Type = "H" Then

                                            AppointmentItem.Categories = "Holiday"

                                        End If

                                        AppointmentItem.Save()

                                        AddHandler AppointmentItem.Write, AddressOf AppointmentWrite
                                        AddHandler AppointmentItem.BeforeDelete, AddressOf AppointmentBeforeDelete

                                    End If

                                    FileImported = True

                                Catch ex As Exception
                                    FileImported = False
                                End Try

                            End If

                        End If

                    End If

                Catch ex As Exception

                Finally

                    _AllowImportItem = True

                End Try

            End If

            If My.Computer.FileSystem.FileExists(File) Then

                My.Computer.FileSystem.DeleteFile(File)

            End If

        Catch ex As Exception
            FileImported = False
        Finally
            ImportItem = FileImported
        End Try

    End Function
    Private Sub NewMailEx(ByVal EntryIDCollection As String)

        'objects
        Dim Item As Object = Nothing
        Dim AppointmentItem As Microsoft.Office.Interop.Outlook.AppointmentItem = Nothing
        Dim Attachment As Microsoft.Office.Interop.Outlook.Attachment = Nothing
        Dim BodyLines() As String = Nothing
        Dim OutlookCalendar As Microsoft.Office.Interop.Outlook.MAPIFolder = Nothing
        Dim EmployeeNonTaskTypeAndID As String = ""

        For Each EntryID In Split(EntryIDCollection, ",")

            Item = Me.Application.Session.GetItemFromID(EntryID)

            If Item IsNot Nothing AndAlso TypeOf Item Is Microsoft.Office.Interop.Outlook.MailItem Then

                If DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).Subject <> Nothing AndAlso _
                        (DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).Subject.ToUpper = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Calendar.Outlook.EmailSubjects.AdvantageCalendarSyncEmail.ToString).ToUpper OrElse _
                         DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).Subject.ToUpper = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Calendar.Outlook.EmailSubjects.AdvantageTaskSyncEmail.ToString).ToUpper) Then

                    For Each Attachment In DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).Attachments.OfType(Of Microsoft.Office.Interop.Outlook.Attachment)()

                        If Attachment IsNot Nothing AndAlso Attachment.FileName.EndsWith("xml") Then

                            Attachment.SaveAsFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & Attachment.FileName)

                            If DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).Subject.ToUpper = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Calendar.Outlook.EmailSubjects.AdvantageCalendarSyncEmail.ToString).ToUpper Then

                                ImportItem(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & Attachment.FileName, False)

                            ElseIf DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).Subject.ToUpper = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Calendar.Outlook.EmailSubjects.AdvantageTaskSyncEmail.ToString).ToUpper Then

                                ImportItem(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & Attachment.FileName, True)

                            End If

                        End If

                    Next

                    If My.Settings.SyncOutlookAndAdvantageAppointments AndAlso _Session IsNot Nothing Then

                        If DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).Body <> Nothing Then

                            BodyLines = Split(DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).Body, vbCrLf)

                            If BodyLines.Length > 0 Then

                                If BodyLines(0).Contains("Delete Calender Item: ") Then

                                    EmployeeNonTaskTypeAndID = BodyLines(0).Replace("Delete Calender Item: ", "").Trim

                                    OutlookCalendar = Me.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar)

                                    AppointmentItem = OutlookCalendar.Items.Find("[BillingInformation]=" & EmployeeNonTaskTypeAndID)

                                    If AppointmentItem IsNot Nothing Then

                                        AppointmentItem.Delete()

                                    End If

                                End If

                            End If

                        End If

                    End If

                    DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).UnRead = False

                    DirectCast(Item, Microsoft.Office.Interop.Outlook.MailItem).Delete()

                End If

            End If

        Next

    End Sub
    'Private Sub SetupSyncAdvantageCalendarMenuItem()

    'If _CommandBarPopup IsNot Nothing AndAlso _SyncCommandBarButton Is Nothing AndAlso _
    '        My.Settings.ConnectionString <> "" AndAlso AdvantageFramework.Database.TestConnectionString(My.Settings.ConnectionString) Then

    '    _SyncCommandBarButton = _CommandBarPopup.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton)
    '    _SyncCommandBarButton.Caption = "Sync Advantage Calendar..."
    '    _SyncCommandBarButton.Style = Microsoft.Office.Core.MsoButtonStyle.msoButtonCaption

    'End If

    'End Sub
    Private Sub AddMenuBar()

        Try

            For Each Control In Me.Application.ActiveExplorer.CommandBars.ActiveMenuBar.Controls.OfType(Of Microsoft.Office.Core.CommandBarPopup)()

                If Control.Caption = "Advantage" Then

                    Control.Delete()

                End If

            Next

            _CommandBarPopup = Me.Application.ActiveExplorer.CommandBars.ActiveMenuBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlPopup)

            If _CommandBarPopup IsNot Nothing Then

                _CommandBarPopup.Visible = True
                _CommandBarPopup.Caption = "Advantage"

                _SetupCommandBarButton = _CommandBarPopup.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton)
                _SetupCommandBarButton.Caption = "Settings..."
                _SetupCommandBarButton.Style = Microsoft.Office.Core.MsoButtonStyle.msoButtonCaption

                '_ImportCommandBarButton = _CommandBarPopup.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton)
                '_ImportCommandBarButton.Caption = "Import ICS File..."
                '_ImportCommandBarButton.Style = Microsoft.Office.Core.MsoButtonStyle.msoButtonCaption

                'SetupSyncAdvantageCalendarMenuItem()

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub _SetupCommandBarButton_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean) Handles _SetupCommandBarButton.Click

        If AdvantageOutlookAddinSettingsDialog.ShowFormDialog(_Session) = Windows.Forms.DialogResult.OK Then

            'SetupSyncAdvantageCalendarMenuItem()

        End If

    End Sub
    'Private Sub _ImportCommandBarButton_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean) Handles _ImportCommandBarButton.Click

    '    'objects
    '    Dim File As String = ""

    '    File = AdvantageFramework.WinForm.Presentation.SelectFileToOpen("", "ICS Files (*.ics)|*.ics")

    '    If File <> "" Then

    '        If ImportICSFile(File, False) Then

    '            AdvantageFramework.Navigation.ShowMessageBox("File imported sucessfully.")

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox("File import failed.")

    '        End If

    '    End If

    'End Sub
    'Private Sub _SyncCommandBarButton_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean) Handles _SyncCommandBarButton.Click

    '    Advantage_Outlook_Addin.CalendarSyncDialog.ShowFormDialog()

    'End Sub
    Private Sub AdvantageOutlookAddin_Startup() Handles Application.Startup

        'objects
        Dim OutlookCalendar As Microsoft.Office.Interop.Outlook.MAPIFolder = Nothing
        Dim Password As String = ""
        Dim ErrorMessage As String = ""

        Try

            If Me.Application IsNot Nothing Then

                AddHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf AdvantageFramework.WinForm.MessageBox.Show

                AddMenuBar()

                AddHandler Me.Application.NewMailEx, AddressOf NewMailEx
                AddHandler Me.Application.ItemContextMenuDisplay, AddressOf ItemContextMenuDisplay

                _Inspectors = Me.Application.Inspectors

                AddHandler _Inspectors.NewInspector, AddressOf OnNewInspector

                OutlookCalendar = Me.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar)

                AddHandler OutlookCalendar.Items.ItemChange, AddressOf CalendarItemChange
                AddHandler OutlookCalendar.Items.ItemAdd, AddressOf CalendarItemAdd

                For Each Item In OutlookCalendar.Items.OfType(Of Microsoft.Office.Interop.Outlook.AppointmentItem).Where(Function(Apt) Apt.Start > Now.AddYears(-1) AndAlso Apt.End < Now.AddYears(1)).ToList

                    AddHandler CType(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).Write, AddressOf AppointmentWrite
                    AddHandler CType(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).BeforeDelete, AddressOf AppointmentBeforeDelete

                Next

                If System.Diagnostics.EventLog.SourceExists("Adv Outlook Addin Source") = False Then

                    System.Diagnostics.EventLog.CreateEventSource("Adv Outlook Addin Source", "Adv Outlook Addin Log")

                End If

                _EventLog = New System.Diagnostics.EventLog("Adv Outlook Addin Log", My.Computer.Name, "Adv Outlook Addin Source")

                If My.Settings.Password <> "" Then

                    Password = AdvantageFramework.StringUtilities.Decrypt(My.Settings.Password)

                End If

                If String.IsNullOrEmpty(My.Settings.ServerName) = False OrElse String.IsNullOrEmpty(My.Settings.DatabaseName) = False Then

                    AdvantageFramework.Security.Login(AdvantageFramework.Security.Application.Outlook_Addin, Nothing, _Session, My.Settings.ServerName, My.Settings.DatabaseName, My.Settings.UseWindowsAuthentication, My.Settings.UserName, Password, ErrorMessage, 0)

                End If

                _HasLoaded = True

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Application_ItemLoad(Item As Object) Handles Application.ItemLoad

        If _HasLoaded AndAlso TypeOf Item Is Microsoft.Office.Interop.Outlook.AppointmentItem Then

            AddHandler CType(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).Write, AddressOf AppointmentWrite
            AddHandler CType(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).BeforeDelete, AddressOf AppointmentBeforeDelete

        End If

    End Sub
    Private Sub ItemContextMenuDisplay(ByVal CommandBar As Microsoft.Office.Core.CommandBar, ByVal Selection As Microsoft.Office.Interop.Outlook.Selection)

        For SelectionIndex As Integer = 1 To Selection.Count

            If TypeOf Selection.Item(SelectionIndex) Is Microsoft.Office.Interop.Outlook.AppointmentItem Then

                AddHandler CType(Selection.Item(SelectionIndex), Microsoft.Office.Interop.Outlook.AppointmentItem).Write, AddressOf AppointmentWrite
                AddHandler CType(Selection.Item(SelectionIndex), Microsoft.Office.Interop.Outlook.AppointmentItem).BeforeDelete, AddressOf AppointmentBeforeDelete

            End If

        Next

    End Sub
    Private Sub CalendarItemAdd(ByVal Item As Object)

        If TypeOf (Item) Is Microsoft.Office.Interop.Outlook.AppointmentItem Then

            AddHandler CType(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).Write, AddressOf AppointmentWrite
            AddHandler CType(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).BeforeDelete, AddressOf AppointmentBeforeDelete

        End If

    End Sub
    Private Sub CalendarItemChange(ByVal Item As Object)

        If TypeOf (Item) Is Microsoft.Office.Interop.Outlook.AppointmentItem Then

            AddHandler CType(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).Write, AddressOf AppointmentWrite
            AddHandler CType(Item, Microsoft.Office.Interop.Outlook.AppointmentItem).BeforeDelete, AddressOf AppointmentBeforeDelete

        End If

    End Sub
    Private Sub OnNewInspector(ByVal Inspector As Microsoft.Office.Interop.Outlook.Inspector)

        If TypeOf (Inspector.CurrentItem) Is Microsoft.Office.Interop.Outlook.AppointmentItem Then

            AddHandler CType(Inspector.CurrentItem, Microsoft.Office.Interop.Outlook.AppointmentItem).Write, AddressOf AppointmentWrite
            AddHandler CType(Inspector.CurrentItem, Microsoft.Office.Interop.Outlook.AppointmentItem).BeforeDelete, AddressOf AppointmentBeforeDelete

        End If

    End Sub
    Private Sub AppointmentBeforeDelete(ByVal Item As Object, ByRef Cancel As Boolean)

        'objects
        Dim AppointmentItem As Microsoft.Office.Interop.Outlook.AppointmentItem = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
        Dim UserGroupSettingValues As System.Collections.Generic.List(Of Object) = Nothing
        Dim CanEditHoliday As Boolean = False

        If TypeOf Item Is Microsoft.Office.Interop.Outlook.AppointmentItem Then

            AppointmentItem = Item

            If My.Settings.SyncOutlookAndAdvantageAppointments AndAlso AppointmentItem.BillingInformation <> "" AndAlso _Session IsNot Nothing Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, AdvantageFramework.StringUtilities.RemoveAllNonNumeric(AppointmentItem.BillingInformation))

                        If EmployeeNonTask IsNot Nothing Then

                            If EmployeeNonTask.Type = "H" Then

                                Try

                                    UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToAddHolidays)

                                    For Each UserGroupSettingValue In UserGroupSettingValues

                                        Try

                                            If UserGroupSettingValue = True Then

                                                CanEditHoliday = True
                                                Exit For

                                            End If

                                        Catch ex As Exception

                                        End Try

                                    Next

                                Catch ex As Exception
                                    CanEditHoliday = False
                                End Try

                                If CanEditHoliday = True Then

                                    If AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, EmployeeNonTask) Then

                                        _EventLog.WriteEntry("appointment deleted --> " & AppointmentItem.Subject)

                                    Else

                                        _EventLog.WriteEntry("failed to delete appointment --> " & AppointmentItem.Subject)

                                    End If

                                End If

                            Else

                                If AdvantageFramework.Database.Procedures.EmployeeNonTask.Delete(DbContext, EmployeeNonTask) Then

                                    _EventLog.WriteEntry("appointment deleted --> " & AppointmentItem.Subject)

                                Else

                                    _EventLog.WriteEntry("failed to delete appointment --> " & AppointmentItem.Subject)

                                End If

                            End If

                        Else

                            _EventLog.WriteEntry("failed to delete appointment --> " & AppointmentItem.Subject)

                        End If

                    End Using

                Catch ex As Exception
                    _EventLog.WriteEntry("error deleting appointment in advantage --> " & AppointmentItem.Subject & " --> " & ex.Message)
                End Try

            End If

        End If

    End Sub
    Private Sub AppointmentWrite()

        'objects
        Dim AppointmentItemList As System.Collections.Generic.List(Of Microsoft.Office.Interop.Outlook.AppointmentItem) = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim DayDifference As Integer = 0
        Dim UserGroupSettingValues As System.Collections.Generic.List(Of Object) = Nothing
        Dim CanEdit As Boolean = False
        Dim SelectedItemCount As Integer = 0
        Dim Counter As Integer = 1

        Try

            AppointmentItemList = New System.Collections.Generic.List(Of Microsoft.Office.Interop.Outlook.AppointmentItem)

            If Me.Application.ActiveInspector IsNot Nothing Then

                AppointmentItemList.Add(CType(Me.Application.ActiveInspector.CurrentItem, Microsoft.Office.Interop.Outlook.AppointmentItem))

            ElseIf Me.Application.ActiveExplorer IsNot Nothing Then

                For Each SelectedItem In Me.Application.ActiveExplorer.Selection.OfType(Of Microsoft.Office.Interop.Outlook.AppointmentItem)()

                    AppointmentItemList.Add(SelectedItem)

                Next

            End If

            If My.Settings.SyncOutlookAndAdvantageAppointments AndAlso _Session IsNot Nothing AndAlso AppointmentItemList.Count > 0 Then

                For Each AppointmentItem In AppointmentItemList

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                        If Employee IsNot Nothing AndAlso Agency IsNot Nothing Then

                            If AppointmentItem.BillingInformation <> "" Then

                                EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, AdvantageFramework.StringUtilities.RemoveAllNonNumeric(AppointmentItem.BillingInformation))

                            Else

                                EmployeeNonTask = New AdvantageFramework.Database.Entities.EmployeeNonTask

                            End If

                            If EmployeeNonTask IsNot Nothing Then

                                If AppointmentItem.Categories = "Holiday" Then

                                    Try

                                        UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToAddHolidays)

                                        For Each UserGroupSettingValue In UserGroupSettingValues

                                            Try

                                                If UserGroupSettingValue = True Then

                                                    CanEdit = True
                                                    Exit For

                                                End If

                                            Catch ex As Exception

                                            End Try

                                        Next

                                    Catch ex As Exception
                                        CanEdit = False
                                    End Try

                                Else

                                    CanEdit = True

                                End If

                                If CanEdit Then

                                    EmployeeNonTask.DbContext = DbContext

                                    EmployeeNonTask.Description = AppointmentItem.Subject

                                    If AppointmentItem.Categories = "Holiday" Then

                                        EmployeeNonTask.Type = "H"

                                    Else

                                        EmployeeNonTask.Type = "A"

                                    End If

                                    If AppointmentItem.AllDayEvent Then

                                        EmployeeNonTask.IsAllDay = 1

                                        EmployeeNonTask.StartDate = AppointmentItem.Start.ToShortDateString
                                        EmployeeNonTask.EndDate = AppointmentItem.Start.ToShortDateString

                                        EmployeeNonTask.StartDateAndTime = AppointmentItem.Start.ToShortDateString & " " & AppointmentItem.Start.ToLongTimeString
                                        EmployeeNonTask.EndDateAndTime = AppointmentItem.Start.ToShortDateString & " 11:59 PM"

                                    Else

                                        EmployeeNonTask.IsAllDay = 0

                                        EmployeeNonTask.StartDate = AppointmentItem.Start.ToShortDateString
                                        EmployeeNonTask.EndDate = AppointmentItem.End.ToShortDateString

                                        EmployeeNonTask.StartDateAndTime = AppointmentItem.Start.ToShortDateString & " " & AppointmentItem.Start.ToLongTimeString
                                        EmployeeNonTask.EndDateAndTime = AppointmentItem.End.ToShortDateString & " " & AppointmentItem.End.ToLongTimeString

                                    End If

                                    DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)))

                                    If EmployeeNonTask.IsAllDay = 1 Then

                                        If DayDifference = 0 Then

                                            EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                                        Else

                                            EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0) * DayDifference, 2))

                                        End If

                                    Else

                                        If DayDifference = 0 Then

                                            EmployeeNonTask.Hours = CDec(FormatNumber(CDate(EmployeeNonTask.EndDateAndTime).Subtract(CDate(EmployeeNonTask.StartDateAndTime)).TotalHours, 2))

                                            If EmployeeNonTask.Hours > Agency.StandardHours.GetValueOrDefault(0) Then

                                                EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                                            End If

                                        Else

                                            EmployeeNonTask.Hours = CDec(FormatNumber(AdvantageFramework.EmployeeUtilities.LoadTotalHoursWorked(Employee, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)), 2))

                                        End If

                                    End If

                                    EmployeeNonTask.EmployeeCode = Employee.Code

                                    If AppointmentItem.BillingInformation <> "" Then

                                        If AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask) Then

                                            Try

                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, Employee.Code)).FirstOrDefault = 0 Then

                                                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Employee.Code, Employee.Email))

                                                End If

                                            Catch ex As Exception

                                            End Try

                                            _EventLog.WriteEntry("appointment updated --> " & AppointmentItem.Subject)

                                        Else

                                            _EventLog.WriteEntry("failed to update appointment --> " & AppointmentItem.Subject)

                                        End If

                                    Else

                                        If AdvantageFramework.Database.Procedures.EmployeeNonTask.Insert(DbContext, EmployeeNonTask) Then

                                            AppointmentItem.BillingInformation = EmployeeNonTask.Type & EmployeeNonTask.ID

                                            AppointmentItem.Save()

                                            AddHandler AppointmentItem.Write, AddressOf AppointmentWrite
                                            AddHandler AppointmentItem.BeforeDelete, AddressOf AppointmentBeforeDelete

                                            Try

                                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", EmployeeNonTask.ID, Employee.Code)).FirstOrDefault = 0 Then

                                                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) VALUES ({0}, '{1}', '{2}')", EmployeeNonTask.ID, Employee.Code, Employee.Email))

                                                End If

                                            Catch ex As Exception

                                            End Try

                                            _EventLog.WriteEntry("appointment inserted --> " & AppointmentItem.Subject)

                                        Else

                                            _EventLog.WriteEntry("failed to insert appointment --> " & AppointmentItem.Subject)

                                        End If

                                    End If

                                End If

                            Else

                                If AppointmentItem.BillingInformation <> "" Then

                                    _EventLog.WriteEntry("failed to update appointment --> " & AppointmentItem.Subject)

                                Else

                                    _EventLog.WriteEntry("failed to insert appointment --> " & AppointmentItem.Subject)

                                End If

                            End If

                        End If

                    End Using

                Next

            End If

        Catch ex As Exception
            _EventLog.WriteEntry("error inserting\updating appointment in advantage --> " & ex.Message)
        End Try

    End Sub

#End Region

End Class