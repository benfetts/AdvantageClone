Imports DevExpress.XtraGrid.Views.Base

Namespace WinForm.Presentation.Controls

    Public Class VendorContractControl
        Public Event SelectedDocumentChanged()
        Public Event SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs)
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)
        Public Event ContractContactInitNewRowEvent()
        Public Event ContractContactSelectionChangedEvent()
        Public Event CommentsGotFocusEvent(ByVal sender As Object, ByVal e As EventArgs)
        Public Event CommentsLostFocusEvent(ByVal sender As Object, ByVal e As EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ContractID As Integer = 0
        Private _VendorCode As String = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        Private _ContractContactList As Generic.List(Of AdvantageFramework.Database.Entities.VendorContractContact) = Nothing
        Private _HasAccessToDocuments As Boolean = False
        Private _CanUserUpdateInVendorMaintenance As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property CanUserUpdateInVendorMaintenance() As Boolean
            Get
                CanUserUpdateInVendorMaintenance = _CanUserUpdateInVendorMaintenance
            End Get
        End Property
        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = _SelectedTab
            End Get
        End Property
        Public ReadOnly Property DocumentManager() As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
            Get
                DocumentManager = DocumentManagerControlDocuments_VendorContractDocuments
            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_VendorContract)

                        _CanUserUpdateInVendorMaintenance = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ' general tab
                            CheckBoxGeneral_Inactive.ByPassUserEntryChanged = True

                            DateTimePickerGeneral_StartDate.ValueObject = Nothing
                            DateTimePickerGeneral_EndDate.ValueObject = Nothing

                            TextBoxGeneral_Code.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContract.Properties.Code)
                            TextBoxGeneral_Description.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContract.Properties.Description)

                            SearchableComboBoxGeneral_Client.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContract.Properties.VendorCode)

                            DateTimePickerGeneral_StartDate.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContract.Properties.StartDate)
                            DateTimePickerGeneral_EndDate.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContract.Properties.EndDate)

                            TextBoxGeneral_Comments.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContract.Properties.Comments)


                            ' internal contacts tab
                            _ContractContactList = New Generic.List(Of AdvantageFramework.Database.Entities.VendorContractContact)

                            DataGridViewInternalContacts_Contacts.DataSource = _ContractContactList

                            If Me.CanUserUpdateInVendorMaintenance Then

                                DataGridViewInternalContacts_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                                DataGridViewInternalContacts_Contacts.OptionsBehavior.Editable = True

                            Else

                                DataGridViewInternalContacts_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                                DataGridViewInternalContacts_Contacts.OptionsBehavior.Editable = False

                            End If

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.VendorContract

            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing

            Try

                If IsNew Then

                    VendorContract = New AdvantageFramework.Database.Entities.VendorContract

                    LoadContractEntity(VendorContract, True)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        VendorContract = AdvantageFramework.Database.Procedures.VendorContract.LoadByID(DbContext, _ContractID)

                        If VendorContract IsNot Nothing Then

                            LoadContractEntity(VendorContract, False)

                        End If

                    End Using

                End If

            Catch ex As Exception
                VendorContract = Nothing
            End Try

            FillObject = VendorContract

        End Function
        Private Sub LoadContractEntity(ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract, ByVal IsNew As Boolean)

            If VendorContract IsNot Nothing Then

                If IsNew = True OrElse TabItemContractSetup_GeneralTab.Tag = True Then

                    SaveGeneralTab(VendorContract)

                End If

            End If

        End Sub
        Private Sub LoadContractContacts()

            If _ContractID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _ContractContactList = AdvantageFramework.Database.Procedures.VendorContractContact.LoadByContractID(DbContext, _ContractID).ToList

                End Using

            End If

            DataGridViewInternalContacts_Contacts.DataSource = _ContractContactList
            DataGridViewInternalContacts_Contacts.CurrentView.BestFitColumns()

        End Sub
        Private Function LoadSelectedContract() As AdvantageFramework.Database.Entities.VendorContract

            'objects
            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing

            If _ContractID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        VendorContract = AdvantageFramework.Database.Procedures.VendorContract.LoadByID(DbContext, _ContractID)

                    Catch ex As Exception
                        VendorContract = Nothing
                    End Try

                End Using

            End If

            LoadSelectedContract = VendorContract

        End Function
        Private Sub LoadContractDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing

            If _ContractID <> 0 Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlControl_ContractSetup.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlControl_ContractSetup.SelectedTab

                End If

                If TabItem.Tag = False Then

                    VendorContract = LoadSelectedContract()

                    If VendorContract IsNot Nothing Then

                        If TabItem Is TabItemContractSetup_GeneralTab OrElse _IsCopy Then

                            LoadGeneralTab(VendorContract)

                        End If

                        If TabItem Is TabItemContractSetup_InternalContactsTab OrElse _IsCopy Then

                            LoadContactsTab(VendorContract)

                        End If

                        If TabItem Is TabItemContractSetup_DocumentsTab Then

                            LoadDocuments(VendorContract)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub LoadGeneralTab(ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract)

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If VendorContract IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _IsCopy Then

                        CheckBoxGeneral_Inactive.Checked = False

                    Else

                        CheckBoxGeneral_Inactive.Checked = VendorContract.IsInactive

                    End If

                    SearchableComboBoxGeneral_Client.SelectedValue = VendorContract.VendorCode

                    If VendorContract.VendorCode <> "" Then

                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorContract.VendorCode)

                    End If

                    DateTimePickerGeneral_StartDate.ValueObject = VendorContract.StartDate
                    DateTimePickerGeneral_EndDate.ValueObject = VendorContract.EndDate

                    TextBoxGeneral_Comments.Text = VendorContract.Comments

                End Using

                TabItemContractSetup_GeneralTab.Tag = True

            End If

        End Sub
        Private Sub LoadContactsTab(ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract)

            If VendorContract IsNot Nothing Then

                LoadContractContacts()

                TabItemContractSetup_InternalContactsTab.Tag = True

            End If

        End Sub
        Private Sub SaveGeneralTab(ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract)

            If VendorContract IsNot Nothing Then

                VendorContract.Code = TextBoxGeneral_Code.Text
                VendorContract.Description = TextBoxGeneral_Description.Text
                VendorContract.VendorCode = SearchableComboBoxGeneral_Client.GetSelectedValue
                VendorContract.IsInactive = CheckBoxGeneral_Inactive.Checked
                VendorContract.StartDate = DateTimePickerGeneral_StartDate.GetValue
                VendorContract.EndDate = DateTimePickerGeneral_EndDate.GetValue
                VendorContract.Comments = TextBoxGeneral_Comments.Text

            End If

        End Sub
        Private Sub SaveContractContacts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract)

            'objects
            Dim VendorContractContact As AdvantageFramework.Database.Entities.VendorContractContact = Nothing

            For Each ContractContact In _ContractContactList

                If ContractContact.ID = Nothing OrElse _IsCopy = True Then

                    VendorContractContact = New AdvantageFramework.Database.Entities.VendorContractContact

                    With VendorContractContact

                        VendorContractContact.DbContext = DbContext
                        VendorContractContact.ContractID = VendorContract.ID
                        VendorContractContact.EmployeeCode = ContractContact.EmployeeCode
                        VendorContractContact.IncludeInAlert = ContractContact.IncludeInAlert

                    End With

                    AdvantageFramework.Database.Procedures.VendorContractContact.Insert(DbContext, VendorContractContact, "")

                Else

                    AdvantageFramework.Database.Procedures.VendorContractContact.Update(DbContext, ContractContact, "")

                End If

            Next

        End Sub
        Private Sub LoadDocuments(ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract)

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If VendorContract IsNot Nothing Then

				DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.VendorContract) With {.VendorContractID = VendorContract.ID}

				DocumentManagerControlDocuments_VendorContractDocuments.Enabled = DocumentManagerControlDocuments_VendorContractDocuments.LoadControl(Database.Entities.DocumentLevel.VendorContract, DocumentLevelSetting, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

                TabItemContractSetup_DocumentsTab.Tag = True

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal VendorCode As String, ByVal ContractID As Integer, ByVal IsCopy As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            _ContractID = ContractID
            _VendorCode = VendorCode
            _IsCopy = IsCopy

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _VendorCode <> "" Then

                    SearchableComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)

                Else

                    SearchableComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)

                End If

                If _ContractID <> 0 Then

                    TextBoxGeneral_Code.Enabled = IsCopy
                    TextBoxGeneral_Code.ReadOnly = Not IsCopy
                    SearchableComboBoxGeneral_Client.Enabled = IsCopy

                    VendorContract = AdvantageFramework.Database.Procedures.VendorContract.LoadByID(DbContext, _ContractID)

                    If VendorContract IsNot Nothing Then

                        If IsCopy = False Then

                            TextBoxGeneral_Code.Text = VendorContract.Code
                            TextBoxGeneral_Description.Text = VendorContract.Description

                            CheckBoxGeneral_Inactive.Checked = VendorContract.IsInactive

                            TabItemContractSetup_DocumentsTab.Visible = _HasAccessToDocuments

                        Else

                            TextBoxGeneral_Code.Text = Nothing
                            TextBoxGeneral_Description.Text = Nothing

                            CheckBoxGeneral_Inactive.Checked = False

                            TabItemContractSetup_DocumentsTab.Visible = False

                        End If

                        LoadContractDetails(Nothing)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The vendor contract you are trying to edit does not exist anymore.")

                    End If

                Else

                    If _VendorCode <> "" Then

                        SearchableComboBoxGeneral_Client.Enabled = False
                        SearchableComboBoxGeneral_Client.SelectedValue = _VendorCode

                    End If

                    TextBoxGeneral_Code.Enabled = True
                    TextBoxGeneral_Code.ReadOnly = False

                    TabItemContractSetup_DocumentsTab.Visible = False

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save() As Boolean

            'objects
            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                DataGridViewInternalContacts_Contacts.CurrentView.CloseEditorForUpdating()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorContract = Me.FillObject(False)

                    If VendorContract IsNot Nothing Then

                        VendorContract.ModifiedByUserCode = _Session.UserCode
                        VendorContract.ModifiedDate = Now

                        Saved = AdvantageFramework.Database.Procedures.VendorContract.Update(DbContext, VendorContract, "")

                        If Saved Then

                            SaveContractContacts(DbContext, VendorContract)

                        End If

                    End If

                End Using

                If Not Saved Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorContract = Me.FillObject(False)

                    If VendorContract IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.VendorContract.Delete(DbContext, VendorContract)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The vendor contract is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef VendorCode As String) As Boolean

            'objects
            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorContract = Me.FillObject(True)

                    If VendorContract IsNot Nothing Then

                        VendorContract.DbContext = DbContext
                        VendorContract.CreateDate = Now
                        VendorContract.CreatedByUserCode = _Session.UserCode

                        Inserted = AdvantageFramework.Database.Procedures.VendorContract.Insert(DbContext, VendorContract, ErrorMessage)

                        If Inserted Then

                            SaveContractContacts(DbContext, VendorContract)

                            VendorCode = VendorContract.VendorCode

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Sub CancelAddNewContractContact()

            DataGridViewInternalContacts_Contacts.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedContractContact()

            'objects
            Dim VendorContractContact As AdvantageFramework.Database.Entities.VendorContractContact = Nothing

            If DataGridViewInternalContacts_Contacts.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        VendorContractContact = DataGridViewInternalContacts_Contacts.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        VendorContractContact = Nothing
                    End Try

                    If VendorContractContact IsNot Nothing Then

                        If _ContractID <> 0 AndAlso _IsCopy = False Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.VendorContractContact.Delete(DbContext, VendorContractContact) Then

                                    LoadContractContacts()

                                End If

                            End Using

                        Else

                            DataGridViewInternalContacts_Contacts.CurrentView.DeleteSelectedRows()

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub ClearControl()

            ' general tab
            TextBoxGeneral_Code.Text = ""
            TextBoxGeneral_Description.Text = ""
            SearchableComboBoxGeneral_Client.SelectedValue = Nothing
            CheckBoxGeneral_Inactive.Checked = False
            DateTimePickerGeneral_StartDate.ValueObject = Nothing
            DateTimePickerGeneral_EndDate.ValueObject = Nothing
            TextBoxGeneral_Comments.Text = ""

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub DownloadDocument()

            DocumentManagerControlDocuments_VendorContractDocuments.DownloadSelectedDocument()

        End Sub
        Public Sub DeleteDocument()

            DocumentManagerControlDocuments_VendorContractDocuments.DeleteSelectedDocument()

        End Sub
		Public Sub UploadDocument()

			DocumentManagerControlDocuments_VendorContractDocuments.UploadNewDocument()

		End Sub
		Public Sub SendASPUploadEmail()

			DocumentManagerControlDocuments_VendorContractDocuments.SendASPUploadEmail()

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub VendorContractControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub SearchableComboBoxGeneral_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneral_Client.EditValueChanged

        End Sub
        Private Sub TabControlControl_ContractSetup_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_ContractSetup.SelectedTabChanged

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = False

            End If

        End Sub
        Private Sub TabControlControl_ContractSetup_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_ContractSetup.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = True

            End If

            LoadContractDetails(e.NewTab)

            _SelectedTab = e.NewTab

            RaiseEvent SelectedTabChanging(sender, e)

        End Sub
        Private Sub DataGridViewInternalContacts_Contacts_AddNewRowEvent(RowObject As Object) Handles DataGridViewInternalContacts_Contacts.AddNewRowEvent

            'objects
            Dim VendorContractContact As AdvantageFramework.Database.Entities.VendorContractContact = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.VendorContractContact Then

                Me.ShowWaitForm("Processing...")

                VendorContractContact = RowObject

                If VendorContractContact.ID = Nothing Then

                    If _ContractID <> 0 AndAlso _IsCopy = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            VendorContractContact.DbContext = DbContext

                            VendorContractContact.ContractID = _ContractID

                            If AdvantageFramework.Database.Procedures.VendorContractContact.Insert(DbContext, VendorContractContact, "") Then

                                DataGridViewInternalContacts_Contacts.SelectRow(VendorContractContact.ID)

                            End If

                        End Using

                    Else

                        DataGridViewInternalContacts_Contacts.SetUserEntryChanged()

                    End If

                    If _IsCopy = False Then

                        LoadContractContacts()

                    End If

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewInternalContacts_Contacts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewInternalContacts_Contacts.InitNewRowEvent

            RaiseEvent ContractContactInitNewRowEvent()

        End Sub
        Private Sub DataGridViewInternalContacts_Contacts_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInternalContacts_Contacts.NewItemRowCellValueChangedEvent

            Dim ContractContactList As Generic.List(Of AdvantageFramework.Database.Entities.VendorContractContact) = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Entities.VendorContractContact.Properties.EmployeeCode.ToString Then

                ContractContactList = DataGridViewInternalContacts_Contacts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.VendorContractContact)().ToList

                If ContractContactList.Where(Function(Entity) Entity.EmployeeCode = e.Value).Any Then

                    AdvantageFramework.WinForm.MessageBox.Show("Employee has already been added.  Please choose another.")

                    DataGridViewInternalContacts_Contacts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.VendorContractContact.Properties.EmployeeCode.ToString, "")

                End If

            End If

        End Sub
        Private Sub DataGridViewInternalContacts_Contacts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInternalContacts_Contacts.SelectionChangedEvent

            RaiseEvent ContractContactSelectionChangedEvent()

        End Sub
        Private Sub CheckBoxGeneral_Inactive_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxGeneral_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxGeneral_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxGeneral_Inactive.Checked = Not CheckBoxGeneral_Inactive.Checked

                End If

            End If

        End Sub
        Private Sub DocumentManagerControlDocuments_ContractDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_VendorContractDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub DateTimePickerGeneral_StartDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerGeneral_StartDate.ValueChanged

            If DateTimePickerGeneral_StartDate.Value > DateTimePickerGeneral_EndDate.Value Then

                DateTimePickerGeneral_EndDate.Value = DateTimePickerGeneral_StartDate.Value

            End If

        End Sub
        Private Sub DateTimePickerGeneral_EndDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerGeneral_EndDate.ValueChanged

            If DateTimePickerGeneral_EndDate.Value < DateTimePickerGeneral_StartDate.Value Then

                DateTimePickerGeneral_StartDate.Value = DateTimePickerGeneral_EndDate.Value

            End If

        End Sub
        Private Sub TextBoxGeneral_Comments_GotFocus(sender As Object, e As EventArgs) Handles TextBoxGeneral_Comments.GotFocus

            RaiseEvent CommentsGotFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxGeneral_Comments_LostFocus(sender As Object, e As EventArgs) Handles TextBoxGeneral_Comments.LostFocus

            RaiseEvent CommentsLostFocusEvent(sender, e)

        End Sub

#End Region

#End Region

    End Class

End Namespace
