Namespace ProjectManagement.Reports.Presentation

    Public Class EstimatePrintingEmailRecipientDialog

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
        Protected _Subject As String = ""
        Protected _Body As String = ""

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
        Public ReadOnly Property Subject As String
            Get
                Subject = _Subject
            End Get
        End Property
        Public ReadOnly Property Body As String
            Get
                Body = _Body
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
            Dim RecipientSource As EstimatePrintingEmailRecipientDialog.RecipientSource = Nothing

            If ComboBoxForm_Source.HasASelectedValue AndAlso DataGridViewForm_AvailableRecipients.HasASelectedRow Then

                RecipientSource = AdvantageFramework.EnumUtilities.GetValue(GetType(RecipientSource), ComboBoxForm_Source.GetSelectedValue)

                Select Case AdvantageFramework.EnumUtilities.GetValue(GetType(RecipientSource), ComboBoxForm_Source.GetSelectedValue)

                    Case EstimatePrintingEmailRecipientDialog.RecipientSource.Internal

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(2)

                    Case EstimatePrintingEmailRecipientDialog.RecipientSource.ClientContacts

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(3)

                    Case EstimatePrintingEmailRecipientDialog.RecipientSource.DivisionContacts

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(4)

                    Case EstimatePrintingEmailRecipientDialog.RecipientSource.ProductContacts

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(5)

                    Case EstimatePrintingEmailRecipientDialog.RecipientSource.VendorContacts

                        Contacts = DataGridViewForm_AvailableRecipients.GetAllSelectedRowsCellValues(3)

                    Case EstimatePrintingEmailRecipientDialog.RecipientSource.VendorRepresentatives

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
            Dim RecipientSource As EstimatePrintingEmailRecipientDialog.RecipientSource = Nothing

            If ComboBoxForm_Source.HasASelectedValue Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        RecipientSource = AdvantageFramework.EnumUtilities.GetValue(GetType(RecipientSource), ComboBoxForm_Source.GetSelectedValue)

                        DataGridViewForm_AvailableRecipients.ClearGridCustomization()
                        DataGridViewForm_AvailableRecipients.ItemDescription = "Contact(s)"

                        Try

                            Select Case RecipientSource

                                Case EstimatePrintingEmailRecipientDialog.RecipientSource.Internal

                                    DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(Me.Session, DbContext, SecurityDbContext).Where(Function(Entity) Entity.Email IsNot Nothing).ToList
                                                                                       Where Entity.Email IsNot Nothing AndAlso Entity.Email <> ""
                                                                                       Select New With {.Code = Entity.Code,
                                                                                                        .Name = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                        .EmailAddress = Entity.Email}).ToList

                                    DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(2)

                                Case EstimatePrintingEmailRecipientDialog.RecipientSource.ClientContacts

                                    DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.Load(DbContext).ToList
                                                                                       Where Entity.EmailAddress IsNot Nothing AndAlso Entity.EmailAddress <> ""
                                                                                       Select New With {.ClientCode = Entity.ClientCode,
                                                                                                    .ContactCode = Entity.ContactCode,
                                                                                                    .Name = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                        .EmailAddress = Entity.EmailAddress}).ToList

                                    DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(3)

                                Case EstimatePrintingEmailRecipientDialog.RecipientSource.DivisionContacts

                                    DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext).Include("ClientContact").ToList
                                                                                       Where Entity.ClientContact.EmailAddress IsNot Nothing AndAlso Entity.ClientContact.EmailAddress <> "" AndAlso
                                                                                         Entity.DivisionCode IsNot Nothing AndAlso Entity.ProductCode Is Nothing
                                                                                       Select New With {.ClientCode = Entity.ClientContact.ClientCode,
                                                                                                    .DivisionCode = Entity.DivisionCode,
                                                                                                    .ContactCode = Entity.ClientContact.ContactCode,
                                                                                                    .Name = If(Entity.ClientContact.MiddleInitial IsNot Nothing AndAlso Entity.ClientContact.MiddleInitial <> "", Entity.ClientContact.FirstName & " " & Entity.ClientContact.MiddleInitial & ". " & Entity.ClientContact.LastName, Entity.ClientContact.FirstName & " " & Entity.ClientContact.LastName),
                                                                                                        .EmailAddress = Entity.ClientContact.EmailAddress}).ToList.Distinct

                                    DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(4)

                                Case EstimatePrintingEmailRecipientDialog.RecipientSource.ProductContacts

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

                                Case EstimatePrintingEmailRecipientDialog.RecipientSource.VendorContacts

                                    DataGridViewForm_AvailableRecipients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VendorContact.Load(DbContext).ToList
                                                                                       Where Entity.Email IsNot Nothing AndAlso Entity.Email <> ""
                                                                                       Select New With {.VendorCode = Entity.VendorCode,
                                                                                                    .ContactCode = Entity.Code,
                                                                                                    .Name = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                        .EmailAddress = Entity.Email}).ToList

                                    DataGridViewForm_AvailableRecipients.SetBookmarkColumnIndex(3)

                                Case EstimatePrintingEmailRecipientDialog.RecipientSource.VendorRepresentatives

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

        Public Shared Function ShowFormDialog(ByRef ToRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress),
                                              ByRef CCRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress),
                                              ByRef BCCRecipients As IEnumerable(Of AdvantageFramework.Email.Classes.RecipientEmailAddress),
                                              ByRef Subject As String,
                                              ByRef Body As String) As System.Windows.Forms.DialogResult

            'objects
            Dim EstimatePrintingEmailRecipientDialog As EstimatePrintingEmailRecipientDialog = Nothing

            EstimatePrintingEmailRecipientDialog = New EstimatePrintingEmailRecipientDialog()

            ShowFormDialog = EstimatePrintingEmailRecipientDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ToRecipients = EstimatePrintingEmailRecipientDialog.ToRecipients
                CCRecipients = EstimatePrintingEmailRecipientDialog.CcRecipients
                BCCRecipients = EstimatePrintingEmailRecipientDialog.BccRecipients
                Subject = EstimatePrintingEmailRecipientDialog.Subject
                Body = EstimatePrintingEmailRecipientDialog.Body
            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Protected Sub EstimatePrintingEmailRecipientDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

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
        Protected Sub EstimatePrintingEmailRecipientDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadRecipients()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Protected Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If _ToRecipients.Count > 0 OrElse _CcRecipients.Count > 0 OrElse _BccRecipients.Count > 0 Then

                _ToRecipients = DataGridViewForm_To.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)().ToList()
                _CcRecipients = DataGridViewForm_CC.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)().ToList()
                _BccRecipients = DataGridViewForm_BCC.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Email.Classes.RecipientEmailAddress)().ToList()
                _Subject = Me.TextBoxForm_Subject.Text
                _Body = Me.TextBoxForm_Body.Text

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select at least one email recipient.")

            End If

        End Sub
        Protected Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            _ToRecipients.Clear()
            _CcRecipients.Clear()
            _BccRecipients.Clear()
            _Subject = ""
            _Body = ""

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

#End Region

#End Region

    End Class

End Namespace
