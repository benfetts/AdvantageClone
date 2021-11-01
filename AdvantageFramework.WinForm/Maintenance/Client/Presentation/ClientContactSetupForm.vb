Namespace Maintenance.Client.Presentation

    Public Class ClientContactSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientContactList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
        'Private _ClientContactDetails As Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail) = Nothing
        'Private _GridViewClientContactDetails As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_ClientContacts.DataSource = LoadClientContacts().OrderBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.ContactCode)
            DataGridViewLeftSection_ClientContacts.CurrentView.BestFitColumns()

        End Sub
        Private Function LoadClientContacts() As IEnumerable(Of AdvantageFramework.Database.Classes.ClientContact)

            'objects
            Dim ClientContactList As IEnumerable(Of AdvantageFramework.Database.Classes.ClientContact) = Nothing
            Dim ClientCodes As Generic.List(Of String) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ClientCodes = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList.Select(Function(Entity) Entity.Code).ToList

                        ClientContactList = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.Load(DbContext).Include("Client").ToList
                                             Where ClientCodes.Contains(Entity.ClientCode) = True
                                             Select New AdvantageFramework.Database.Classes.ClientContact(DbContext, Entity)).ToList

                    End Using

                End Using

            Catch ex As Exception
                ClientContactList = Nothing
            Finally
                LoadClientContacts = ClientContactList
            End Try

        End Function
        'Private Sub LoadDetailView()

        '    DataGridViewLeftSection_ClientContactExport.CurrentView.BeginUpdate()

        '    _GridViewClientContactDetails = New AdvantageFramework.WinForm.Presentation.Controls.GridView

        '    DataGridViewLeftSection_ClientContactExport.GridControl.LevelTree.Nodes.Add("ClientContactDetail", _GridViewClientContactDetails)

        '    _GridViewClientContactDetails.GridControl = DataGridViewLeftSection_ClientContactExport.GridControl
        '    _GridViewClientContactDetails.Name = "_GridViewClientContactDetails"

        '    _GridViewClientContactDetails.Session = Me.Session

        '    _GridViewClientContactDetails.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

        '    _GridViewClientContactDetails.ObjectType = GetType(AdvantageFramework.Database.Entities.ClientContactDetail)

        '    _GridViewClientContactDetails.OptionsView.ShowViewCaption = False
        '    _GridViewClientContactDetails.OptionsView.ShowFooter = False

        '    _GridViewClientContactDetails.ViewCaption = "Division / Product Assignments"

        '    _GridViewClientContactDetails.CreateColumnsBasedOnObjectType()

        '    If _GridViewClientContactDetails.Columns("ContactID") IsNot Nothing Then

        '        _GridViewClientContactDetails.Columns("ContactID").Visible = False

        '    End If

        '    If _GridViewClientContactDetails.Columns("ClientContact") IsNot Nothing Then

        '        _GridViewClientContactDetails.Columns("ClientContact").Visible = False

        '    End If

        '    If _GridViewClientContactDetails.Columns("SequenceNumber") IsNot Nothing Then

        '        _GridViewClientContactDetails.Columns("SequenceNumber").Visible = False

        '    End If

        '    _GridViewClientContactDetails.BestFitColumns()

        '    DataGridViewLeftSection_ClientContactExport.CurrentView.EndUpdate()

        'End Sub
        Private Sub LoadSelectedItemDetails()

            Dim ClientContactID As String = Nothing
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing

            ClientContactControlRightSection_ClientContact.ClearControl()

            ClientContactControlRightSection_ClientContact.Enabled = DataGridViewLeftSection_ClientContacts.HasOnlyOneSelectedRow

            If ClientContactControlRightSection_ClientContact.Enabled Then

                ClientContactControlRightSection_ClientContact.Enabled = ClientContactControlRightSection_ClientContact.LoadControl(DataGridViewLeftSection_ClientContacts.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            ClientContactControlRightSection_ClientContact.Enabled = (DataGridViewLeftSection_ClientContacts.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_ClientContacts.HasASelectedRow

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            ClientContactControlRightSection_ClientContact.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientContactSetupForm As AdvantageFramework.Maintenance.Client.Presentation.ClientContactSetupForm = Nothing

            ClientContactSetupForm = New AdvantageFramework.Maintenance.Client.Presentation.ClientContactSetupForm()

            ClientContactSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientContactSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            ButtonItemActions_Import.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContactImport)
            ButtonItemActions_Export.SecurityEnabled = AdvantageFramework.Security.CanUserPrintInModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact)
            ButtonItemActions_Add.SecurityEnabled = AdvantageFramework.Security.CanUserAddInModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact)
            ButtonItemActions_Save.SecurityEnabled = AdvantageFramework.Security.CanUserUpdateInModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact)

            DataGridViewLeftSection_ClientContacts.MultiSelect = True
            DataGridViewLeftSection_ClientContactExport.OptionsPrint.PrintDetails = True
            DataGridViewLeftSection_ClientContactExport.OptionsPrint.ExpandAllDetails = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            'Try

            '    LoadDetailView()

            'Catch ex As Exception

            'End Try

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_ClientContacts.CurrentView.AFActiveFilterString = "[IsInactive] = False AND [IsClientInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ClientContactSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientContactSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientContactSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_ClientContacts.FocusToFindPanel(True)
            ButtonItemActions_Delete.Enabled = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim ClientCode As String = Nothing
            Dim ClientContactID As Integer = 0
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_ClientContacts.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                Try

                    ClientContact = _ClientContactList.Where(Function(Entity) Entity.ContactID = DataGridViewLeftSection_ClientContacts.GetFirstSelectedRowBookmarkValue).SingleOrDefault

                Catch ex As Exception
                    ClientContact = Nothing
                End Try

                If ClientContact IsNot Nothing Then

                    ClientCode = ClientContact.ClientCode

                End If

                If AdvantageFramework.Maintenance.Client.Presentation.ClientContactEditDialog.ShowFormDialog(ClientCode, ClientContactID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_ClientContacts.SelectRow(ClientContactID)

                End If

            End If


        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_ClientContacts.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If ClientContactControlRightSection_ClientContact.Save Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_ClientContacts.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a client contact to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_ClientContacts.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If DataGridViewLeftSection_ClientContacts.HasOnlyOneSelectedRow Then

                            Deleted = ClientContactControlRightSection_ClientContact.Delete()

                        Else

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                            Try

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    For Each ContactID In DataGridViewLeftSection_ClientContacts.GetAllSelectedRowsBookmarkValues.OfType(Of Integer)()

                                        If AdvantageFramework.Database.Procedures.ClientContact.Delete(DbContext, ContactID) = False Then

                                            ErrorMessage = "One or more Contact is currently in use and cannot be deleted."

                                        Else

                                            Deleted = True

                                        End If

                                    Next

                                End Using

                            Catch ex As Exception

                            End Try

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        End If

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        End If

                        If Deleted Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a client contact to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewLeftSection_ClientContactExport.DataSource = LoadClientContacts()

            DataGridViewLeftSection_ClientContactExport.CurrentView.AFActiveFilterString = DataGridViewLeftSection_ClientContacts.CurrentView.AFActiveFilterString
            DataGridViewLeftSection_ClientContactExport.CurrentView.ApplyFindFilter(DataGridViewLeftSection_ClientContacts.CurrentView.FindFilterText)
            DataGridViewLeftSection_ClientContactExport.CurrentView.BestFitColumns()

            DataGridViewLeftSection_ClientContactExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub DataGridViewLeftSection_ClientContacts_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_ClientContacts.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_ClientContacts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_ClientContacts.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

				Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

				LoadSelectedItemDetails()

				Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

				EnableOrDisableActions()

			End If

        End Sub
        'Private Sub DataGridViewLeftSection_ClientContactExport_MasterRowEmptyEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewLeftSection_ClientContactExport.MasterRowEmptyEvent

        '    e.IsEmpty = False

        'End Sub
        'Private Sub DataGridViewLeftSection_ClientContactExport_MasterRowGetChildListEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewLeftSection_ClientContactExport.MasterRowGetChildListEvent

        '    Dim ClientContactID As String = Nothing
        '    Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
        '    Dim ClientContactDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail) = Nothing

        '    If e.ChildList Is Nothing Then

        '        Try

        '            ClientContact = (From Entity In _ClientContactList _
        '                             Where Entity.ContactID = DataGridViewLeftSection_ClientContactExport.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.ClientContact.Properties.ContactID.ToString) _
        '                             Select Entity).FirstOrDefault

        '        Catch ex As Exception
        '            ClientContact = Nothing
        '        End Try

        '        If ClientContact IsNot Nothing Then

        '            If e.RelationIndex = 0 Then

        '                ClientContactDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail)

        '                Try

        '                    ClientContactDetailList = (From Entity In _ClientContactDetails _
        '                                               Where Entity.ContactID = ClientContact.ContactID _
        '                                               Select Entity).ToList

        '                Catch ex As Exception
        '                    ClientContactDetailList = Nothing
        '                End Try

        '                e.ChildList = ClientContactDetailList

        '            End If

        '        End If

        '    End If

        'End Sub
        'Private Sub DataGridViewLeftSection_ClientContactExport_MasterRowGetLevelDefaultViewEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles DataGridViewLeftSection_ClientContactExport.MasterRowGetLevelDefaultViewEvent

        '    e.DefaultView = _GridViewClientContactDetails

        'End Sub
        'Private Sub DataGridViewLeftSection_ClientContactExport_MasterRowGetRelationCountEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewLeftSection_ClientContactExport.MasterRowGetRelationCountEvent

        '    e.RelationCount = 1

        'End Sub
        'Private Sub DataGridViewLeftSection_ClientContactExport_MasterRowGetRelationNameEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewLeftSection_ClientContactExport.MasterRowGetRelationNameEvent

        '    If e.RelationIndex = 0 Then

        '        e.RelationName = "Client Contact Details"

        '    End If

        'End Sub
        Private Sub ClientContactControlRightSection_ClientContact_CommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientContactControlRightSection_ClientContact.CommentGotFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = True

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ClientContactControlRightSection_ClientContact_CommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientContactControlRightSection_ClientContact.CommentLostFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = False

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf ClientContactControlRightSection_ClientContact.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(ClientContactControlRightSection_ClientContact.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                Me.ShowWaitForm("Processing...")

                Try

                    ClientContactControlRightSection_ClientContact.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_ClientContacts.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.Maintenance_Client_ClientContactImport)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace