Namespace Desktop.Presentation

    Public Class AlertAssignmentEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _VendorCode As String = ""
        Private _AccountPayableID As Integer = 0
        Private _AccountPayableSequenceNumber As Integer = 0
        Private _InvoiceNumber As String = ""
        Private _InvoiceDate As Date = Nothing
        Private _AlertTemplateID As Integer = 0
        Private _AlertStateID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal VendorCode As String, ByVal AccountPayableID As Integer, ByVal AccountPayableSequenceNumber As Integer, ByVal InvoiceNumber As String, ByVal InvoiceDate As Date, ByVal AlertTemplateID As Integer, ByVal AlertStateID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _VendorCode = VendorCode
            _AccountPayableID = AccountPayableID
            _AccountPayableSequenceNumber = AccountPayableSequenceNumber
            _InvoiceNumber = InvoiceNumber
            _InvoiceDate = InvoiceDate
            _AlertTemplateID = AlertTemplateID
            _AlertStateID = AlertStateID

        End Sub
        Private Sub LoadAlertLevelItems()

            'objects
            Dim AccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable) = Nothing

            If ComboBoxAlertLevel_Level.HasASelectedValue Then

                If ComboBoxAlertLevel_Level.GetSelectedValue = "AP" Then

                    LabelAlertLevel_ItemFilter.Text = "Vendor:"
                    LabelAlertLevel_Item.Text = "Invoice:"

                    ComboBoxAlertLevel_ItemFilter.ControlType = WinForm.Presentation.Controls.ComboBox.Type.Vendor

                    SearchableComboBoxAlertLevel_Item.DisplayName = ""
                    SearchableComboBoxAlertLevel_Item.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.InvoiceNumber

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxAlertLevel_ItemFilter.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(DbContext)

                        AccountPayableList = AdvantageFramework.AccountPayable.GetAllAccountPayableListByVendor(DbContext, _VendorCode)

                        SearchableComboBoxAlertLevel_Item.DataSource = (From AccountPayable In AccountPayableList
                                                                        Select AccountPayable.InvoiceNumber,
                                                                                AccountPayable.InvoiceDate,
                                                                                AccountPayable.InvoiceDescription,
                                                                                [IsDeleted] = CBool(AccountPayable.Deleted.GetValueOrDefault(0))).OrderByDescending(Function(Entity) Entity.InvoiceDate).ThenByDescending(Function(Entity) Entity.InvoiceNumber).ToList

                    End Using

                End If

            Else

                ComboBoxAlertLevel_ItemFilter.ControlType = WinForm.Presentation.Controls.ComboBox.Type.Default
                ComboBoxAlertLevel_ItemFilter.DataSource = Nothing

                SearchableComboBoxAlertLevel_Item.ControlType = WinForm.Presentation.Controls.SearchableComboBox.Type.Default
                SearchableComboBoxAlertLevel_Item.DataSource = Nothing

            End If

        End Sub
        Private Sub LoadAlertAssignmentStates()

            'objects
            Dim CompletedAlertStateID As Integer = 0
            Dim AlertAssignmentTemplateStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateState) = Nothing
            Dim AlertAssignmentTemplateState As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing

            If ComboBoxAlertAssignment_Template.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AlertAssignmentTemplateStates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, ComboBoxAlertAssignment_Template.GetSelectedValue).Include("AlertState").OrderBy(Function(Entity) Entity.SortOrder).ToList

                    Try

                        AlertAssignmentTemplateState = AlertAssignmentTemplateStates.SingleOrDefault(Function(Entity) Entity.IsCompleted.GetValueOrDefault(False) = True)

                        If AlertAssignmentTemplateState IsNot Nothing Then

                            CompletedAlertStateID = AlertAssignmentTemplateState.AlertStateID

                        End If

                    Catch ex As Exception
                        CompletedAlertStateID = 0
                    End Try

                    ComboBoxAlertAssignment_State.DataSource = From AlertState In AlertAssignmentTemplateStates.Select(Function(Entity) Entity.AlertState)
                                                               Select New With {.ID = AlertState.ID,
                                                                                .Name = If(AlertState.ID = CompletedAlertStateID, AlertState.Name & "*", AlertState.Name)}

                End Using

            Else

                ComboBoxAlertAssignment_State.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AlertState)

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub LoadAlertAssignmentEmployees()

            'objects
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim DefaultEmployeeCode As String = ""
            Dim AlertAssignmentTemplateState As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing
            Dim EmployeeLookup As Integer = 0
            Dim AlertAssignmentTemplateID As Integer = 0
            Dim AlertAssignmentTemplateStateID As Integer = 0

            If ComboBoxAlertAssignment_Template.HasASelectedValue AndAlso ComboBoxAlertAssignment_State.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        AlertAssignmentTemplateState = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, ComboBoxAlertAssignment_Template.GetSelectedValue, ComboBoxAlertAssignment_State.GetSelectedValue)

                    Catch ex As Exception
                        AlertAssignmentTemplateState = Nothing
                    End Try

                    If AlertAssignmentTemplateState IsNot Nothing Then

                        DefaultEmployeeCode = AlertAssignmentTemplateState.DefaultEmployeeCode
                        EmployeeLookup = CInt(AlertAssignmentTemplateState.EmployeeLookupType.GetValueOrDefault(0))

                    End If

                    AlertAssignmentTemplateID = ComboBoxAlertAssignment_Template.GetSelectedValue
                    AlertAssignmentTemplateStateID = ComboBoxAlertAssignment_State.GetSelectedValue

                    If EmployeeLookup = 0 Then

                        EmployeeCodes = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateEmployee.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, ComboBoxAlertAssignment_Template.GetSelectedValue, ComboBoxAlertAssignment_State.GetSelectedValue).Select(Function(Entity) Entity.EmployeeCode).ToList

                    ElseIf EmployeeLookup = 1 Then

                        'EmployeeCodes = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateRole.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, ComboBoxAlertAssignment_Template.GetSelectedValue, ComboBoxAlertAssignment_State.GetSelectedValue).Select(Function(Entity) Entity.).ToList

                        EmployeeCodes = (From Employee In DbContext.Employees
                                         Join EmpRole In DbContext.EmployeeRoles On EmpRole.EmployeeCode Equals Employee.Code
                                         Join AlertRole In DbContext.AlertAssignmentTemplateRoles On AlertRole.RoleCode Equals EmpRole.RoleCode
                                         Where AlertRole.AlertAssignmentTemplateID = AlertAssignmentTemplateID AndAlso
                                               AlertRole.AlertStateID = AlertAssignmentTemplateStateID
                                         Select Employee.Code).ToList

                    ElseIf EmployeeLookup = 2 Then

                        'EmployeeCodes = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateDepartmentTeam.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, ComboBoxAlertAssignment_Template.GetSelectedValue, ComboBoxAlertAssignment_State.GetSelectedValue).Select(Function(Entity) Entity.).ToList

                        EmployeeCodes = (From Employee In DbContext.Employees
                                         Join EmpDeptTeam In DbContext.EmployeeDepartments On EmpDeptTeam.EmployeeCode Equals Employee.Code
                                         Join AlertDeptTeam In DbContext.AlertAssignmentTemplateDepartmentTeams On AlertDeptTeam.DepartmentTeamCode Equals EmpDeptTeam.DepartmentTeamCode
                                         Where AlertDeptTeam.AlertAssignmentTemplateID = AlertAssignmentTemplateID AndAlso
                                               AlertDeptTeam.AlertStateID = AlertAssignmentTemplateStateID
                                         Select Employee.Code).ToList

                    ElseIf EmployeeLookup = 3 Then

                        'EmployeeCodes = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateEmailGroup.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, ComboBoxAlertAssignment_Template.GetSelectedValue, ComboBoxAlertAssignment_State.GetSelectedValue).Select(Function(Entity) Entity.).ToList

                        EmployeeCodes = (From Employee In DbContext.Employees
                                         Join AlertGroup In DbContext.AlertGroups On AlertGroup.EmployeeCode Equals Employee.Code
                                         Join AlertAssignmentGroup In DbContext.AlertAssignmentTemplateEmailGroups On AlertAssignmentGroup.EmailGroupCode Equals AlertGroup.Code
                                         Where AlertAssignmentGroup.AlertAssignmentTemplateID = AlertAssignmentTemplateID AndAlso
                                               AlertAssignmentGroup.AlertStateID = AlertAssignmentTemplateStateID
                                         Select Employee.Code).ToList

                    End If

                    If EmployeeCodes IsNot Nothing AndAlso EmployeeCodes.Count > 0 Then

                        ComboBoxAlertAssignment_AssignTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                                       Select Entity.Code,
                                                                              Entity.FirstName,
                                                                              Entity.LastName,
                                                                              Entity.MiddleInitial).ToList.Where(Function(Employee) EmployeeCodes.Contains(Employee.Code)).Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                                                                                                               .FullName = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "", Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName, Employee.FirstName & " " & Employee.LastName) &
                                                                                                                                                                                                                           If(Employee.Code = DefaultEmployeeCode, "*", "")}).ToList

                    Else

                        ComboBoxAlertAssignment_AssignTo.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                    End If

                    ComboBoxAlertAssignment_AssignTo.AddComboItemToExistingDataSource("[Unassigned]", AdvantageFramework.AlertSystem.Unassigned, False, 1)

                    If String.IsNullOrEmpty(DefaultEmployeeCode) = False Then

                        ComboBoxAlertAssignment_AssignTo.SelectedValue = DefaultEmployeeCode

                    End If

                End Using

            Else

                ComboBoxAlertAssignment_AssignTo.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            SearchableComboBoxAlertLevel_Item.Enabled = ComboBoxAlertLevel_Level.HasASelectedValue
            ComboBoxAlertAssignment_State.Enabled = ComboBoxAlertAssignment_Template.HasASelectedValue
            ComboBoxAlertAssignment_AssignTo.Enabled = (ComboBoxAlertAssignment_Template.HasASelectedValue AndAlso ComboBoxAlertAssignment_State.HasASelectedValue)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal VendorCode As String, ByVal AccountPayableID As Integer, ByVal AccountPayableSequenceNumber As Integer, ByVal InvoiceNumber As String, ByVal InvoiceDate As Date, Optional ByVal AlertTemplateID As Integer = 0, Optional ByVal AlertStateID As Integer = 0) As System.Windows.Forms.DialogResult

            'objects
            Dim AlertAssignmentEditDialog As AdvantageFramework.Desktop.Presentation.AlertAssignmentEditDialog = Nothing

            AlertAssignmentEditDialog = New AdvantageFramework.Desktop.Presentation.AlertAssignmentEditDialog(VendorCode, AccountPayableID, AccountPayableSequenceNumber, InvoiceNumber, InvoiceDate, AlertTemplateID, AlertStateID)

            ShowFormDialog = AlertAssignmentEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AlertAssignmentEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            ButtonItemActions_Send.Image = My.Resources.AlertSendImage
            ButtonItemActions_Cancel.Image = My.Resources.CancelImage
            ButtonItemActions_Clear.Image = My.Resources.ClearImage

            CheckBoxAlertLevel_IsAssignment.SecurityEnabled = False
            CheckBoxAlertLevel_IsAssignment.Checked = True
            ComboBoxAlertLevel_Level.SecurityEnabled = False

            DateTimePickerForm_DueDate.Value = Nothing
            DateTimePickerForm_DueDate.ValueObject = Nothing
            DateTimePickerForm_DueTime.Value = Nothing
            DateTimePickerForm_DueTime.ValueObject = Nothing

            ComboBoxAlertLevel_Level.SetRequired(True)
            SearchableComboBoxAlertLevel_Item.SetRequired(True)
            ComboBoxAlertAssignment_Template.SetRequired(True)
            ComboBoxAlertAssignment_State.SetRequired(True)
            ComboBoxAlertAssignment_AssignTo.SetRequired(True)

            ComboBoxAlertAssignment_Template.DisplayName = "Template"
            ComboBoxAlertAssignment_State.DisplayName = "State"
            ComboBoxAlertAssignment_AssignTo.DisplayName = "Employee"
            ComboBoxForm_Category.DisplayName = "Category"
            ComboBoxForm_Priority.DisplayName = "Priority"

            ComboBoxAlertLevel_Level.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.AlertSystem.Levels))
            ComboBoxForm_Priority.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.AlertSystem.PriorityLevels), False)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxAlertAssignment_Template.DataSource = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext).OrderBy(Function(Entity) Entity.Name)

                If _AlertTemplateID > 0 Then

                    Try

                        ComboBoxAlertAssignment_Template.SelectedValue = _AlertTemplateID

                    Catch ex As Exception
                        ComboBoxAlertAssignment_Template.SelectedIndex = 0
                    End Try

                    If ComboBoxAlertAssignment_Template.SelectedIndex > 0 Then

                        If _AlertStateID > 0 Then

                            LoadAlertAssignmentStates()

                            Try

                                ComboBoxAlertAssignment_State.SelectedValue = _AlertStateID

                            Catch ex As Exception
                                ComboBoxAlertAssignment_State.SelectedIndex = 0
                            End Try

                            If ComboBoxAlertAssignment_State.SelectedIndex > 0 Then

                                LoadAlertAssignmentEmployees()

                            End If

                        End If

                    End If

                End If

                ComboBoxForm_Category.DataSource = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeID(DbContext, 6).Where(Function(Entity) Entity.ID <> 28 AndAlso Entity.ID <> 29 AndAlso Entity.ID <> 30 AndAlso Entity.ID <> 31).OrderBy(Function(Entity) Entity.Description)

                TextBoxForm_Subject.SetPropertySettings(AdvantageFramework.Database.Entities.Alert.Properties.Subject, "")

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, _VendorCode)

            End Using

            TextBoxForm_Subject.SetRequired(True)

            ComboBoxAlertLevel_Level.SelectedValue = "AP"
            ComboBoxForm_Priority.SelectedValue = CInt(AdvantageFramework.AlertSystem.PriorityLevels.Normal)
            ComboBoxForm_Category.SelectedValue = 25

            If Vendor IsNot Nothing Then

                TextBoxForm_Subject.Text = If(Vendor IsNot Nothing, Vendor.Name, "") & " " & _InvoiceNumber & " " & _InvoiceDate.ToShortDateString

            End If

            LoadAlertLevelItems()

            Me.Text = "New Alert Assignment"

        End Sub
        Private Sub AlertAssignmentEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Try

                ComboBoxAlertLevel_ItemFilter.SelectedValue = _VendorCode

            Catch ex As Exception
                ComboBoxAlertLevel_ItemFilter.SelectedIndex = 0
            End Try

            SearchableComboBoxAlertLevel_Item.SelectedValue = _InvoiceNumber

            ComboBoxAlertLevel_ItemFilter.Enabled = False
            SearchableComboBoxAlertLevel_Item.Enabled = False
            SearchableComboBoxAlertLevel_Item.Properties.ReadOnly = True

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Send_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Send.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim DocumentIDs() As Integer = Nothing
            Dim DueDate As Nullable(Of Date) = Nothing
            Dim DueTime As String = Nothing
            Dim EmailSent As Boolean = False

            If Me.Validator Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DocumentIDs = AdvantageFramework.Database.Procedures.AccountPayableDocument.LoadByAccountPayableID(DataContext, _AccountPayableID).ToList.Select(Function(Entity) CInt(Entity.DocumentID)).ToArray()

                End Using

                Try

                    If DateTimePickerForm_DueDate.Text <> "" Then

                        DueDate = DateTimePickerForm_DueDate.Value

                    End If

                Catch ex As Exception

                End Try

                Try

                    If DateTimePickerForm_DueTime.Text <> "" Then

                        DueTime = DateTimePickerForm_DueTime.Text

                    End If

                Catch ex As Exception

                End Try

                If AdvantageFramework.AlertSystem.CreateAndSendAlertAssignment(Me.Session, 6, ComboBoxForm_Category.GetSelectedValue, ComboBoxAlertLevel_Level.GetSelectedValue, _
                                                                               ComboBoxAlertAssignment_Template.GetSelectedValue, ComboBoxAlertAssignment_State.GetSelectedValue, ComboBoxForm_Priority.GetSelectedValue, _
                                                                               TextBoxForm_Subject.Text, RichEditForm_Description.Text, RichEditForm_Description.HtmlText, Me.Session.User.EmployeeCode, Me.Session.UserCode, _
                                                                               ComboBoxAlertAssignment_AssignTo.GetSelectedValue, CheckBoxForm_ExcludeAttachmentFromEmail.Checked, ErrorMessage, EmailSent, _
                                                                               DueDate, DueTime, DocumentIDs, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, _
                                                                               _VendorCode, Nothing, Nothing, _AccountPayableID, _AccountPayableSequenceNumber, Nothing, Nothing, Nothing) Then

                    If EmailSent = False AndAlso ErrorMessage <> "" Then

                        AdvantageFramework.WinForm.MessageBox.Show("An alert assignment was created but email failed to send. " & vbNewLine & vbNewLine & vbNewLine & "Reason: " & ErrorMessage)

                    End If

                    Me.DialogResult = Windows.Forms.DialogResult.OK

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Failed to create alert assignment. Please contact Software Support.")

                    Me.DialogResult = Windows.Forms.DialogResult.Cancel

                End If

                Me.ClearChanged()

                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Clear_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Clear.Click

            SearchableComboBoxAlertLevel_ItemView.SelectRow(0)

            ComboBoxAlertAssignment_Template.SelectedIndex = 0
            ComboBoxAlertAssignment_State.SelectedIndex = 0
            ComboBoxAlertAssignment_AssignTo.SelectedIndex = 0

            ComboBoxForm_Category.SelectedIndex = 0
            ComboBoxForm_Priority.SelectedIndex = 0

            DateTimePickerForm_DueDate.Value = Nothing
            DateTimePickerForm_DueDate.ValueObject = Nothing
            DateTimePickerForm_DueTime.Value = Nothing
            DateTimePickerForm_DueTime.ValueObject = Nothing

            ComboBoxForm_Priority.SelectedValue = CInt(AdvantageFramework.AlertSystem.PriorityLevels.Normal)
            ComboBoxForm_Category.SelectedValue = 25

            TextBoxForm_Subject.Text = ""
            RichEditForm_Description.Text = ""

        End Sub
        Private Sub ComboBoxAlertLevel_Level_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAlertLevel_Level.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadAlertLevelItems()

            End If

        End Sub
        Private Sub ComboBoxAlertAssignment_Template_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAlertAssignment_Template.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadAlertAssignmentStates()

            End If

        End Sub
        Private Sub ComboBoxAlertAssignment_State_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAlertAssignment_State.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadAlertAssignmentEmployees()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
