Namespace Media.Presentation

    Public Class MediaManagerSendRemindersDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _VCCOrders = VCCOrders

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim OrderLines As IEnumerable(Of String) = Nothing
            Dim ReminderContacts As Generic.List(Of AdvantageFramework.MediaManager.Classes.ReminderContact) = Nothing
            Dim KeyValuePairs As Generic.List(Of KeyValuePair(Of String, Decimal)) = Nothing
            Dim KeyValueTotalCostPayableToVendorPairs As Generic.List(Of KeyValuePair(Of String, Decimal)) = Nothing
            Dim PONumbers As IEnumerable(Of Integer) = Nothing

            OrderLines = _VCCOrders.Where(Function(Entity) Entity.OrderNumber.HasValue AndAlso Entity.LineNumber.HasValue).Select(Function(Entity) CStr(Entity.OrderNumber.Value) + "|" + CStr(Entity.LineNumber.Value)).ToArray
            PONumbers = _VCCOrders.Where(Function(Entity) Entity.PONumber.HasValue).Select(Function(Entity) Entity.PONumber.Value).ToArray

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ReminderContacts = AdvantageFramework.MediaManager.LoadMediaManagerReminderContacts(DbContext, OrderLines, PONumbers)

            End Using

            KeyValuePairs = (From Entity In _VCCOrders.AsParallel
                             Group By Entity.VendorCode
                             Into Group = Group
                             Select New KeyValuePair(Of String, Decimal)(VendorCode, Group.Sum(Function(D) D.CardAmount))).ToList

            KeyValueTotalCostPayableToVendorPairs = (From Entity In _VCCOrders.AsParallel
                                                     Group By Entity.VendorCode
                                                     Into Group = Group
                                                     Select New KeyValuePair(Of String, Decimal)(VendorCode, Group.Sum(Function(D) D.TotalCostPayableToVendor))).ToList

            For Each ReminderContact In ReminderContacts

                ReminderContact.TotalCost = KeyValuePairs.Where(Function(K) K.Key = ReminderContact.VendorCode).Select(Function(K) K.Value).FirstOrDefault
                ReminderContact.TotalCostPayableToVendor = KeyValueTotalCostPayableToVendorPairs.Where(Function(K) K.Key = ReminderContact.VendorCode).Select(Function(K) K.Value).FirstOrDefault
                ReminderContact.Email = True

            Next

            DataGridViewForm_Contacts.DataSource = ReminderContacts

            DataGridViewForm_Contacts.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveDefaultEmailSettings()

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.VCC.SaveDefaultEmailSubject(DataContext, TextBoxForm_Subject.Text)
                AdvantageFramework.VCC.SaveDefaultEmailBody(DataContext, TextBoxForm_Body.Text)
                AdvantageFramework.VCC.SaveDefaultCCSender(DataContext, CheckBoxForm_CCToSender.Checked)

            End Using

            ButtonItemDefaultEmailSettings_Save.Enabled = False

        End Sub
        Private Sub SaveLastVCCReminderLocation()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.LastVCCReminderLocation.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing AndAlso SearchableComboBoxForm_Location.HasASelectedValue Then

                    UserSetting.StringValue = SearchableComboBoxForm_Location.GetSelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing AndAlso SearchableComboBoxForm_Location.HasASelectedValue Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.LastVCCReminderLocation.ToString, SearchableComboBoxForm_Location.GetSelectedValue, Nothing, Nothing, UserSetting)

                End If

            End Using

        End Sub
        Private Sub SelectDeselectAllRows(IsEmail As Boolean, [Select] As Boolean)

            For Each ReminderContact In DataGridViewForm_Contacts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.ReminderContact).ToList

                If IsEmail Then

                    ReminderContact.Email = [Select]

                Else

                    ReminderContact.Print = [Select]

                End If

            Next

            DataGridViewForm_Contacts.CurrentView.RefreshData()

        End Sub
        Private Sub SendPrint()

            'objects
            Dim ReminderContacts As Generic.List(Of AdvantageFramework.MediaManager.Classes.ReminderContact) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent
            Dim ErrorMessage As String = ""
            Dim [To] As String = Nothing
            Dim [Cc] As String = Nothing
            Dim AtLeastOneEmailFailed As Boolean = False
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim VCCCardIDs As IEnumerable(Of Integer) = Nothing
            Dim OrderLines As Generic.List(Of String) = Nothing
            Dim VCCCardNote As AdvantageFramework.Database.Entities.VCCCardNote = Nothing
            Dim VCCCardPOIDs As IEnumerable(Of Integer) = Nothing
            Dim PONumbers As Generic.List(Of Integer) = Nothing
            Dim VCCCardPONote As AdvantageFramework.Database.Entities.VCCCardPONote = Nothing

            AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

            OrderLines = New Generic.List(Of String)
            PONumbers = New Generic.List(Of Integer)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ReminderContacts = DataGridViewForm_Contacts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.ReminderContact)().ToList

                For Each ReminderContact In ReminderContacts

                    If ReminderContact.Email OrElse ReminderContact.Print Then

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaManagerReminderReport(Me.Session, ReminderContact, _VCCOrders, SearchableComboBoxForm_Location.GetSelectedValue)

                        If Report IsNot Nothing Then

                            Report.CreateDocument()

                            ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                            If ReminderContact.Print Then

                                ReportPrintTool.Print()

                            End If

                            If ReminderContact.Email Then

                                [To] = ReminderContact.EmailAddress

                                If CheckBoxForm_CCToSender.Checked Then

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                                    If Employee IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Employee.Email) Then

                                        [Cc] = Employee.Email

                                    End If

                                End If

                                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                MemoryStream = New System.IO.MemoryStream()

                                Report.ExportToPdf(MemoryStream)

                                Attachments.Add(New Email.Classes.Attachment("Reminder " & ReminderContact.VendorName & ".pdf", MemoryStream.ToArray))

                                If AdvantageFramework.Email.Send(DbContext, [To], [Cc], Nothing, TextBoxForm_Subject.GetText, TextBoxForm_Body.GetText, 3, Attachments, SendingEmailStatus, ErrorMessage, False) = False Then

                                    AtLeastOneEmailFailed = True

                                Else

                                    OrderLines.AddRange(DirectCast(Report, AdvantageFramework.Reporting.Reports.MediaManager.ReminderReport).ActualPrintedOrderLinesOnReport)
                                    PONumbers.AddRange(DirectCast(Report, AdvantageFramework.Reporting.Reports.MediaManager.ReminderReport).ActualPrintedPONumbersOnReport)

                                End If

                            End If

                        End If

                    End If

                Next

            End Using

            If OrderLines IsNot Nothing AndAlso OrderLines.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    VCCCardIDs = (From Entity In AdvantageFramework.Database.Procedures.VCCCard.Load(DbContext)
                                  Where OrderLines.Contains(Entity.OrderNumber & "|" & Entity.LineNumber)
                                  Select Entity.ID).Distinct.ToList

                    For Each VCCCardID In VCCCardIDs

                        VCCCardNote = New AdvantageFramework.Database.Entities.VCCCardNote
                        VCCCardNote.DbContext = DbContext

                        VCCCardNote.Note = "Reminder sent."
                        VCCCardNote.CreatedByUserCode = Session.UserCode
                        VCCCardNote.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                        VCCCardNote.VCCCardID = VCCCardID

                        DbContext.VCCCardNotes.Add(VCCCardNote)

                    Next

                    DbContext.SaveChanges()

                End Using

            End If

            If PONumbers IsNot Nothing AndAlso PONumbers.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    VCCCardPOIDs = (From Entity In AdvantageFramework.Database.Procedures.VCCCardPO.Load(DbContext)
                                    Where PONumbers.Contains(Entity.PONumber)
                                    Select Entity.ID).Distinct.ToList

                    For Each VCCCardPOID In VCCCardPOIDs

                        VCCCardPONote = New AdvantageFramework.Database.Entities.VCCCardPONote
                        VCCCardPONote.DbContext = DbContext

                        VCCCardPONote.Note = "Reminder sent."
                        VCCCardPONote.CreatedByUserCode = Session.UserCode
                        VCCCardPONote.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                        VCCCardPONote.VCCCardPOID = VCCCardPOID

                        DbContext.VCCCardPONotes.Add(VCCCardPONote)

                    Next

                    DbContext.SaveChanges()

                End Using

            End If

            If Not AtLeastOneEmailFailed Then

                AdvantageFramework.WinForm.MessageBox.Show("Reminders have been printed/sent.")

            Else

                AdvantageFramework.WinForm.MessageBox.Show("At least one email did not get sent.")

            End If

            AdvantageFramework.WinForm.Presentation.CloseWaitForm()

        End Sub
        Private Sub SetLastVCCReminderLocation()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.LastVCCReminderLocation.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    SearchableComboBoxForm_Location.SelectedValue = UserSetting.StringValue

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerSendRemindersDialog As MediaManagerSendRemindersDialog = Nothing

            MediaManagerSendRemindersDialog = New MediaManagerSendRemindersDialog(VCCOrders)

            ShowFormDialog = MediaManagerSendRemindersDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerSendRemindersDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage

            ButtonItemDefaultEmailSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemDefaultEmailSettings_Save.Enabled = False

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            DataGridViewForm_Contacts.ItemDescription = "Vendor Rep(s)"
            DataGridViewForm_Contacts.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            SetLastVCCReminderLocation()

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                TextBoxForm_Subject.Text = AdvantageFramework.VCC.LoadDefaultEmailSubject(DataContext)
                TextBoxForm_Body.Text = AdvantageFramework.VCC.LoadDefaultEmailBody(DataContext)
                CheckBoxForm_CCToSender.Checked = AdvantageFramework.VCC.LoadDefaultCCSender(DataContext)

                SearchableComboBoxForm_Location.DataSource = AdvantageFramework.Database.Procedures.Location.Load(DataContext)

            End Using

        End Sub
        Private Sub MediaManagerSendRemindersDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadGrid()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Process.Click

            DataGridViewForm_Contacts.CurrentView.CloseEditorForUpdating()

            If (From RC In DataGridViewForm_Contacts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.ReminderContact)()
                Where RC.Email OrElse RC.Print).Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("Please select at least one vendor rep to email or print.")

            Else

                If ButtonItemDefaultEmailSettings_Save.Enabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Would you like to save your email settings?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        SaveDefaultEmailSettings()

                    End If

                End If

                SaveLastVCCReminderLocation()

                SendPrint()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonItemDefaultEmailSettings_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemDefaultEmailSettings_Save.Click

            SaveDefaultEmailSettings()

        End Sub
        Private Sub ButtonItemQuickSelection_SelectAllEmail_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickSelection_SelectAllEmail.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying
            Me.ShowWaitForm("Processing...")

            Try

                SelectDeselectAllRows(True, True)

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemQuickSelection_DeselectAllEmail_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickSelection_DeselectAllEmail.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying
            Me.ShowWaitForm("Processing...")

            Try

                SelectDeselectAllRows(True, False)

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemQuickSelection_SelectAllPrint_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickSelection_SelectAllPrint.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying
            Me.ShowWaitForm("Processing...")

            Try

                SelectDeselectAllRows(False, True)

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemQuickSelection_DeselectAllPrint_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickSelection_DeselectAllPrint.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying
            Me.ShowWaitForm("Processing...")

            Try

                SelectDeselectAllRows(False, False)

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub CheckBoxForm_CCToSender_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_CCToSender.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub DataGridViewForm_Contacts_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Contacts.ShowingEditorEvent

            If DataGridViewForm_Contacts.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.ReminderContact.Properties.Email.ToString AndAlso
                    DataGridViewForm_Contacts.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.ReminderContact.Properties.Print.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TextBoxForm_Subject_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_Subject.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub TextBoxForm_Body_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_Body.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace