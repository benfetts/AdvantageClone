Namespace ProjectManagement.Reports.Presentation

    Public Class EstimatePrintingSendEmailsDialog

#Region " Constants "



#End Region

#Region " Enum "

        Protected Enum RecipientSource As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Internal", "Internal")>
            Internal = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ClientContacts", "Client Contacts")>
            ClientContacts = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("DivisionContacts", "Division Contacts")>
            DivisionContacts = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ProductContacts", "Product Contacts")>
            ProductContacts = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("VendorContacts", "Vendor Contacts")>
            VendorContacts = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("VendorRepresentatives", "Vendor Representatives")>
            VendorRepresentatives = 6
        End Enum

#End Region

#Region " Variables "

        Protected _ToRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
        Protected _CcRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
        Protected _BccRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
        Protected _SendToDocumentManager As Boolean = False
        Private _EmailSettings As AdvantageFramework.Estimate.Printing.Classes.EmailSettings = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ToRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)
            Get
                ToRecipients = _ToRecipients
            End Get
        End Property
        Public ReadOnly Property CcRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)
            Get
                CcRecipients = _CcRecipients
            End Get
        End Property
        Public ReadOnly Property BccRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)
            Get
                BccRecipients = _BccRecipients
            End Get
        End Property
        Public ReadOnly Property SendToDocumentManager As Boolean
            Get
                SendToDocumentManager = _SendToDocumentManager
            End Get
        End Property
        Public ReadOnly Property EmailSettings As AdvantageFramework.Estimate.Printing.Classes.EmailSettings
            Get
                EmailSettings = _EmailSettings
            End Get
        End Property

#End Region

#Region " Methods "

        Protected Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Protected Sub AddRecipientsToGrid(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            Dim Contacts As IEnumerable(Of Object) = Nothing
            Dim RecipientSource As EstimatePrintingSendEmailsDialog.RecipientSource = Nothing

            If ComboBoxForm_Source.HasASelectedValue AndAlso DataGridViewForm_AvailableRecipients.HasASelectedRow Then

                RecipientSource = AdvantageFramework.EnumUtilities.GetValue(GetType(RecipientSource), ComboBoxForm_Source.GetSelectedValue)

                Select Case AdvantageFramework.EnumUtilities.GetValue(GetType(RecipientSource), ComboBoxForm_Source.GetSelectedValue)

                    Case EstimatePrintingSendEmailsDialog.RecipientSource.Internal

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(2)

                    Case EstimatePrintingSendEmailsDialog.RecipientSource.ClientContacts

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(3)

                    Case EstimatePrintingSendEmailsDialog.RecipientSource.DivisionContacts

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(4)

                    Case EstimatePrintingSendEmailsDialog.RecipientSource.ProductContacts

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(5)

                    Case EstimatePrintingSendEmailsDialog.RecipientSource.VendorContacts

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(3)

                    Case EstimatePrintingSendEmailsDialog.RecipientSource.VendorRepresentatives

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(3)

                End Select

                If DataGridViewForm_To Is DataGridView Then

                    For Each Contact In Contacts

                        _ToRecipients.Add(New Email.Classes.RecipientEmailAddress(Contact.ToString))

                    Next

                    DataGridView.DataSource = _ToRecipients

                ElseIf DataGridViewForm_CC Is DataGridView Then

                    For Each Contact In Contacts

                        _CcRecipients.Add(New Email.Classes.RecipientEmailAddress(Contact.ToString))

                    Next

                    DataGridView.DataSource = _CcRecipients

                ElseIf DataGridViewForm_BCC Is DataGridView Then

                    For Each Contact In Contacts

                        _BccRecipients.Add(New Email.Classes.RecipientEmailAddress(Contact.ToString))

                    Next

                    DataGridView.DataSource = _BccRecipients

                End If

                DataGridView.CurrentView.RefreshData()

                DataGridView.CurrentView.BestFitColumns()

            End If

        End Sub
        Protected Sub LoadRecipients()

            'objects
            Dim RecipientSource As EstimatePrintingSendEmailsDialog.RecipientSource = Nothing

            If ComboBoxForm_Source.HasASelectedValue Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        RecipientSource = AdvantageFramework.EnumUtilities.GetValue(GetType(RecipientSource), ComboBoxForm_Source.GetSelectedValue)

                        DataGridViewForm_AvailableRecipients.ClearGridCustomization()
                        DataGridViewForm_AvailableRecipients.ItemDescription = "Contact(s)"

                        Try

                            Select Case RecipientSource

                                Case EstimatePrintingSendEmailsDialog.RecipientSource.Internal

                                    DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(Me.Session, DbContext, SecurityDbContext).Where(Function(Entity) Entity.Email IsNot Nothing).ToList
                                                                                       Where Entity.Email IsNot Nothing AndAlso Entity.Email <> ""
                                                                                       Select New With {.Code = Entity.Code,
                                                                                                        .Name = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                        .EmailAddress = Entity.Email}).ToList

                                    DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(2)

                                Case EstimatePrintingSendEmailsDialog.RecipientSource.ClientContacts

                                    DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.Load(DbContext).ToList
                                                                                       Where Entity.EmailAddress IsNot Nothing AndAlso Entity.EmailAddress <> ""
                                                                                       Select New With {.ClientCode = Entity.ClientCode,
                                                                                                        .ContactCode = Entity.ContactCode,
                                                                                                        .Name = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                        .EmailAddress = Entity.EmailAddress}).ToList

                                    DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(3)

                                Case EstimatePrintingSendEmailsDialog.RecipientSource.DivisionContacts

                                    DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext).Include("ClientContact").ToList
                                                                                       Where Entity.ClientContact.EmailAddress IsNot Nothing AndAlso Entity.ClientContact.EmailAddress <> "" AndAlso
                                                                                             Entity.DivisionCode IsNot Nothing AndAlso Entity.ProductCode Is Nothing
                                                                                       Select New With {.ClientCode = Entity.ClientContact.ClientCode,
                                                                                                    .DivisionCode = Entity.DivisionCode,
                                                                                                    .ContactCode = Entity.ClientContact.ContactCode,
                                                                                                    .Name = If(Entity.ClientContact.MiddleInitial IsNot Nothing AndAlso Entity.ClientContact.MiddleInitial <> "", Entity.ClientContact.FirstName & " " & Entity.ClientContact.MiddleInitial & ". " & Entity.ClientContact.LastName, Entity.ClientContact.FirstName & " " & Entity.ClientContact.LastName),
                                                                                                    .EmailAddress = Entity.ClientContact.EmailAddress}).ToList.Distinct

                                    DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(4)

                                Case EstimatePrintingSendEmailsDialog.RecipientSource.ProductContacts

                                    DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext).Include("ClientContact").ToList
                                                                                       Where Entity.ClientContact.EmailAddress IsNot Nothing AndAlso Entity.ClientContact.EmailAddress <> "" AndAlso
                                                                                             Entity.DivisionCode IsNot Nothing AndAlso Entity.ProductCode IsNot Nothing
                                                                                       Select New With {.ClientCode = Entity.ClientContact.ClientCode,
                                                                                                    .DivisionCode = Entity.DivisionCode,
                                                                                                    .ProductCode = Entity.ProductCode,
                                                                                                    .ContactCode = Entity.ClientContact.ContactCode,
                                                                                                    .Name = If(Entity.ClientContact.MiddleInitial IsNot Nothing AndAlso Entity.ClientContact.MiddleInitial <> "", Entity.ClientContact.FirstName & " " & Entity.ClientContact.MiddleInitial & ". " & Entity.ClientContact.LastName, Entity.ClientContact.FirstName & " " & Entity.ClientContact.LastName),
                                                                                                    .EmailAddress = Entity.ClientContact.EmailAddress}).ToList

                                    DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(5)

                                Case EstimatePrintingSendEmailsDialog.RecipientSource.VendorContacts

                                    DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VendorContact.Load(DbContext).ToList
                                                                                       Where Entity.Email IsNot Nothing AndAlso Entity.Email <> ""
                                                                                       Select New With {.VendorCode = Entity.VendorCode,
                                                                                                        .ContactCode = Entity.Code,
                                                                                                        .Name = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                        .EmailAddress = Entity.Email}).ToList

                                    DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(3)

                                Case EstimatePrintingSendEmailsDialog.RecipientSource.VendorRepresentatives

                                    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                        DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext).ToList
                                                                                           Where Entity.EmailAddress IsNot Nothing AndAlso Entity.EmailAddress <> ""
                                                                                           Select New With {.VendorCode = Entity.VendorCode,
                                                                                                        .RepCode = Entity.Code,
                                                                                                        .Name = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                        .EmailAddress = Entity.EmailAddress}).ToList

                                        DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(3)

                                    End Using

                            End Select

                            DataGridViewForm_AvailableRecipients.CurrentView.BestFitColumns()

                        Catch ex As Exception

                        End Try

                    End Using

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef EmailSettings As AdvantageFramework.Estimate.Printing.Classes.EmailSettings) As System.Windows.Forms.DialogResult

            'objects
            Dim EstimatePrintingSendEmailsDialog As EstimatePrintingSendEmailsDialog = Nothing

            EstimatePrintingSendEmailsDialog = New EstimatePrintingSendEmailsDialog()

            ShowFormDialog = EstimatePrintingSendEmailsDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                EmailSettings = EstimatePrintingSendEmailsDialog.EmailSettings

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Protected Sub EstimatePrintingSendEmailsDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            'objects
            Dim PackageType As AdvantageFramework.Estimate.Printing.PackageTypes = AdvantageFramework.Estimate.Printing.PackageTypes.None

            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDefaultEmailSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemDefaultEmailSettings_Save.Enabled = False

            ButtonItemOptions_SendToDocumentManager.Image = AdvantageFramework.My.Resources.DocumentManagerImage
            ButtonItemOptions_IncludeCoverSheet.Image = AdvantageFramework.My.Resources.CoverSheetImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            'Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

            '    TextBoxForm_Subject.Text = AdvantageFramework.InvoicePrinting.LoadDefaultEmailSubject(DataContext)
            '    TextBoxForm_Body.Text = AdvantageFramework.InvoicePrinting.LoadDefaultEmailBody(DataContext)

            'End Using

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            _ToRecipients = New Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)
            _CcRecipients = New Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)
            _BccRecipients = New Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)

            ComboBoxForm_Source.DisplayMember = "Description"
            ComboBoxForm_Source.ValueMember = "Code"

            ComboBoxForm_Source.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(RecipientSource))
                                              Select EnumObject.Code, EnumObject.Description).ToList

            DataGridViewForm_To.DataSource = _ToRecipients
            DataGridViewForm_To.UseEmbeddedNavigator = True
            DataGridViewForm_To.CustomCancelEditButton.Visible = False
            DataGridViewForm_To.OptionsView.ColumnAutoWidth = True

            DataGridViewForm_CC.DataSource = _CcRecipients
            DataGridViewForm_CC.UseEmbeddedNavigator = True
            DataGridViewForm_CC.CustomCancelEditButton.Visible = False
            DataGridViewForm_CC.OptionsView.ColumnAutoWidth = True

            DataGridViewForm_BCC.DataSource = _BccRecipients
            DataGridViewForm_BCC.UseEmbeddedNavigator = True
            DataGridViewForm_BCC.CustomCancelEditButton.Visible = False
            DataGridViewForm_BCC.OptionsView.ColumnAutoWidth = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Protected Sub EstimatePrintingSendEmailsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadRecipients()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Protected Sub ButtonItemActions_Process_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Process.Click

            If _ToRecipients.Count > 0 OrElse _CcRecipients.Count > 0 OrElse _BccRecipients.Count > 0 Then

                'If ButtonItemDefaultEmailSettings_Save.Enabled Then

                '    If AdvantageFramework.WinForm.MessageBox.Show("Would you like to save your email settings?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                '        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                '            AdvantageFramework.InvoicePrinting.SaveDefaultEmailSubject(DataContext, TextBoxForm_Subject.Text)
                '            AdvantageFramework.InvoicePrinting.SaveDefaultEmailBody(DataContext, TextBoxForm_Body.Text)
                '            AdvantageFramework.InvoicePrinting.SaveDefaultUploadDocumentManager(DataContext, ButtonItemOptions_SendToDocumentManager.Checked)
                '            AdvantageFramework.InvoicePrinting.SaveDefaultIncludeCoverSheet(DataContext, ButtonItemOptions_IncludeCoverSheet.Checked)

                '            If ButtonItemPackageOptions_OneZip.Checked Then

                '                AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, AdvantageFramework.InvoicePrinting.PackageTypes.OneZip)

                '            Else

                '                AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, AdvantageFramework.InvoicePrinting.PackageTypes.OneZipPerInvoice)

                '            End If

                '        End Using

                '    End If

                'End If

                _EmailSettings = New AdvantageFramework.Estimate.Printing.Classes.EmailSettings

                _EmailSettings.ToRecipients = DataGridViewForm_To.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)().ToList()
                _EmailSettings.CCRecipients = DataGridViewForm_CC.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)().ToList()
                _EmailSettings.BCCRecipients = DataGridViewForm_BCC.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)().ToList()

                'If ButtonItemPackageOptions_OneZip.Checked Then

                '    _EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZip

                'ElseIf ButtonItemPackageOptions_OneZipPerInvoice.Checked Then

                '    _EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZipPerInvoice

                'Else

                '    _EmailSettings.PackageType = InvoicePrinting.PackageTypes.None

                'End If

                _EmailSettings.Subject = TextBoxForm_Subject.Text
                _EmailSettings.Body = TextBoxForm_Body.Text

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select at least one email recipient.")

            End If

        End Sub
        Protected Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            _ToRecipients.Clear()
            _CcRecipients.Clear()
            _BccRecipients.Clear()

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Protected Sub ComboBoxForm_Source_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_Source.SelectedValueChanged

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadRecipients()

            End If

        End Sub
        Protected Sub ButtonForm_AddTo_Click(sender As Object, e As EventArgs) Handles ButtonForm_AddTo.Click

            AddRecipientsToGrid(DataGridViewForm_To)

        End Sub
        Protected Sub ButtonForm_AddCC_Click(sender As Object, e As EventArgs) Handles ButtonForm_AddCC.Click

            AddRecipientsToGrid(DataGridViewForm_CC)

        End Sub
        Protected Sub ButtonForm_AddBCC_Click(sender As Object, e As EventArgs) Handles ButtonForm_AddBCC.Click

            AddRecipientsToGrid(DataGridViewForm_BCC)

        End Sub
        Protected Sub DataGridViewForm_To_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewForm_To.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DataGridViewForm_To.CurrentView.DeleteSelectedRows()

                        e.Handled = True

                End Select

            End If

        End Sub
        Protected Sub DataGridViewForm_CC_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewForm_CC.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DataGridViewForm_CC.CurrentView.DeleteSelectedRows()

                        e.Handled = True

                End Select

            End If

        End Sub
        Protected Sub DataGridViewForm_BCC_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewForm_BCC.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DataGridViewForm_BCC.CurrentView.DeleteSelectedRows()

                        e.Handled = True

                End Select

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
        Private Sub ButtonItemOptions_SendToDocumentManager_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_SendToDocumentManager.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemOptions_IncludeCoverSheet_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_IncludeCoverSheet.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemDefaultEmailSettings_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemDefaultEmailSettings_Save.Click

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.InvoicePrinting.SaveDefaultEmailSubject(DataContext, TextBoxForm_Subject.Text)
                AdvantageFramework.InvoicePrinting.SaveDefaultEmailBody(DataContext, TextBoxForm_Body.Text)
                AdvantageFramework.InvoicePrinting.SaveDefaultUploadDocumentManager(DataContext, ButtonItemOptions_SendToDocumentManager.Checked)
                AdvantageFramework.InvoicePrinting.SaveDefaultIncludeCoverSheet(DataContext, ButtonItemOptions_IncludeCoverSheet.Checked)

                If ButtonItemPackageOptions_OneZip.Checked Then

                    AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, InvoicePrinting.PackageTypes.OneZip)

                ElseIf ButtonItemPackageOptions_OneZipPerInvoice.Checked Then

                    AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, InvoicePrinting.PackageTypes.OneZipPerInvoice)

                Else

                    AdvantageFramework.InvoicePrinting.SaveDefaultPackageType(DataContext, InvoicePrinting.PackageTypes.None)

                End If

            End Using

            ButtonItemDefaultEmailSettings_Save.Enabled = False

        End Sub
        Private Sub ButtonItemPackageOptions_OneZip_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemPackageOptions_OneZip.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemPackageOptions_OneZip.Checked Then

                    ButtonItemPackageOptions_OneZipPerInvoice.Checked = False

                End If

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemPackageOptions_OneZipPerInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemPackageOptions_OneZipPerInvoice.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemPackageOptions_OneZipPerInvoice.Checked Then

                    ButtonItemPackageOptions_OneZip.Checked = False

                End If

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
