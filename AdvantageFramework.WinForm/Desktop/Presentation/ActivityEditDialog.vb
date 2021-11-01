Namespace Desktop.Presentation

    Public Class ActivityEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeNonTaskID As Integer = 0
        Private _PreselectedActivityType As String = ""
        Private _PreselectedStart As Date = Nothing
        Private _PreselectedEnd As Date = Nothing
        Private _PreselectedEmployeeCode As String = ""
        Private _PreselectedClientCode As String = ""
        Private _PreselectedDivisionCode As String = ""
        Private _PreselectedProductCode As String = ""
        Private _PreselectedJobNumber As Integer = 0
        Private _PreselectedJobComponentNumber As Short = 0
        Private _PreselectedFunctionCode As String = ""
        Private _Employees As Generic.List(Of AdvantageFramework.Database.Core.Employee) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property EmployeeNonTaskID As Integer
            Get
                EmployeeNonTaskID = _EmployeeNonTaskID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeNonTaskID As Integer, ByVal PreselectedActivityType As String, ByVal PreselectedStart As Date, ByVal PreselectedEnd As Date, ByVal PreselectedEmployeeCode As String,
                        ByVal PreselectedClientCode As String, ByVal PreselectedDivisionCode As String, ByVal PreselectedProductCode As String,
                        ByVal PreselectedJobNumber As Integer, ByVal PreselectedJobComponentNumber As Short, ByVal PreselectedFunctionCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeNonTaskID = EmployeeNonTaskID
            _PreselectedActivityType = PreselectedActivityType
            _PreselectedStart = PreselectedStart
            _PreselectedEnd = PreselectedEnd
            _PreselectedEmployeeCode = PreselectedEmployeeCode
            _PreselectedClientCode = PreselectedClientCode
            _PreselectedDivisionCode = PreselectedDivisionCode
            _PreselectedProductCode = PreselectedProductCode
            _PreselectedJobNumber = PreselectedJobNumber
            _PreselectedJobComponentNumber = PreselectedJobComponentNumber
            _PreselectedFunctionCode = PreselectedFunctionCode

        End Sub
        Private Sub AddEmployees(ParamArray EmployeeCodes() As String)

            'objects
            Dim AvailableEmployees As Generic.List(Of AdvantageFramework.Database.Core.Employee) = Nothing
            Dim SelectedEmployees As Generic.List(Of AdvantageFramework.Database.Core.Employee) = Nothing
            Dim CurrentSelectedEmployeeCodes As Generic.List(Of String) = Nothing
            Dim SelectedEmployeeCodes() As String = Nothing

            CurrentSelectedEmployeeCodes = DataGridViewEmployeeRightSection_SelectedEmployees.GetAllRowsBookmarkValues(0).OfType(Of String).ToList

            CurrentSelectedEmployeeCodes.AddRange(EmployeeCodes)

            CurrentSelectedEmployeeCodes = CurrentSelectedEmployeeCodes.Distinct.ToList

            SelectedEmployeeCodes = CurrentSelectedEmployeeCodes.ToArray

            DataGridViewEmployeeLeftSection_AvailableEmployees.DataSource = (From Employee In _Employees
                                                                             Where SelectedEmployeeCodes.Contains(Employee.Code) = False
                                                                             Select Employee).ToList

            DataGridViewEmployeeRightSection_SelectedEmployees.DataSource = (From Employee In _Employees
                                                                             Where SelectedEmployeeCodes.Contains(Employee.Code) = True
                                                                             Select Employee).ToList

            DataGridViewEmployeeLeftSection_AvailableEmployees.CurrentView.BestFitColumns()
            DataGridViewEmployeeRightSection_SelectedEmployees.CurrentView.BestFitColumns()

        End Sub
        Private Sub RemoveEmployees(ParamArray EmployeeCodes() As String)

            'objects
            Dim AvailableEmployees As Generic.List(Of AdvantageFramework.Database.Core.Employee) = Nothing
            Dim SelectedEmployees As Generic.List(Of AdvantageFramework.Database.Core.Employee) = Nothing
            Dim CurrentSelectedEmployeeCodes As Generic.List(Of String) = Nothing
            Dim SelectedEmployeeCodes() As String = Nothing

            CurrentSelectedEmployeeCodes = DataGridViewEmployeeRightSection_SelectedEmployees.GetAllRowsBookmarkValues(0).OfType(Of String).ToList

            For Each EmployeeCode In EmployeeCodes

                CurrentSelectedEmployeeCodes.Remove(EmployeeCode)

            Next

            CurrentSelectedEmployeeCodes = CurrentSelectedEmployeeCodes.Distinct.ToList

            SelectedEmployeeCodes = CurrentSelectedEmployeeCodes.ToArray

            DataGridViewEmployeeLeftSection_AvailableEmployees.DataSource = (From Employee In _Employees
                                                                             Where SelectedEmployeeCodes.Contains(Employee.Code) = False
                                                                             Select Employee).ToList

            DataGridViewEmployeeRightSection_SelectedEmployees.DataSource = (From Employee In _Employees
                                                                             Where SelectedEmployeeCodes.Contains(Employee.Code) = True
                                                                             Select Employee).ToList

            DataGridViewEmployeeLeftSection_AvailableEmployees.CurrentView.BestFitColumns()
            DataGridViewEmployeeRightSection_SelectedEmployees.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadDivisions()

            'objects
            Dim ClientCode As String = ""
            Dim DivisionCodes() As String = Nothing

            If SearchableComboBoxGeneral_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DivisionCodes = AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode).Where(Function(Entity) Entity.ClientCode = ClientCode).Select(Function(Entity) Entity.Code).ToArray

                    End Using

                    SearchableComboBoxGeneral_Division.DataSource = From Entity In AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext)
                                                                    Where Entity.ClientCode = ClientCode AndAlso
                                                                          DivisionCodes.Contains(Entity.DivisionCode) AndAlso
                                                                          Entity.IsActive = 1
                                                                    Select Entity

                    Try

                        SearchableComboBoxGeneral_Division.SelectedValue = Nothing

                    Catch ex As Exception

                    End Try

                    SearchableComboBoxGeneral_Division.SelectSingleItemDataSource()

                End Using

            Else

                Try

                    SearchableComboBoxGeneral_Division.SelectedValue = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub LoadProducts()

            'objects
            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""

            If SearchableComboBoxGeneral_Division.HasASelectedValue AndAlso SearchableComboBoxGeneral_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue
                        DivisionCode = SearchableComboBoxGeneral_Division.GetSelectedValue

                        SearchableComboBoxGeneral_Product.DataSource = From Entity In AdvantageFramework.Database.Procedures.ProductView.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode, True)
                                                                       Where Entity.ClientCode = ClientCode AndAlso
                                                                             Entity.DivisionCode = DivisionCode
                                                                       Select Entity

                        Try

                            SearchableComboBoxGeneral_Product.SelectedValue = Nothing

                        Catch ex As Exception

                        End Try

                        SearchableComboBoxGeneral_Product.SelectSingleItemDataSource()

                    End Using

                End Using

            Else

                Try

                    SearchableComboBoxGeneral_Product.SelectedValue = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub LoadJobs()

            'objects
            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ProductCode As String = ""

            If SearchableComboBoxGeneral_Product.HasASelectedValue AndAlso SearchableComboBoxGeneral_Division.HasASelectedValue AndAlso SearchableComboBoxGeneral_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue
                        DivisionCode = SearchableComboBoxGeneral_Division.GetSelectedValue
                        ProductCode = SearchableComboBoxGeneral_Product.GetSelectedValue

                        SearchableComboBoxGeneral_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.JobView.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                   Where Entity.ClientCode = ClientCode AndAlso
                                                                         Entity.DivisionCode = DivisionCode AndAlso
                                                                         Entity.ProductCode = ProductCode
                                                                   Select Entity

                        Try

                            SearchableComboBoxGeneral_Job.SelectedValue = Nothing

                        Catch ex As Exception

                        End Try

                        SearchableComboBoxGeneral_Job.SelectSingleItemDataSource()

                    End Using

                End Using

            Else

                Try

                    SearchableComboBoxGeneral_Job.SelectedValue = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub LoadJobComponents()

            'objects
            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ProductCode As String = ""
            Dim JobNumber As Integer = 0

            If SearchableComboBoxGeneral_Job.HasASelectedValue AndAlso SearchableComboBoxGeneral_Product.HasASelectedValue AndAlso
                    SearchableComboBoxGeneral_Division.HasASelectedValue AndAlso SearchableComboBoxGeneral_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue
                    DivisionCode = SearchableComboBoxGeneral_Division.GetSelectedValue
                    ProductCode = SearchableComboBoxGeneral_Product.GetSelectedValue
                    JobNumber = SearchableComboBoxGeneral_Job.GetSelectedValue

                    SearchableComboBoxGeneral_Component.DataSource = From Entity In AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext)
                                                                     Where Entity.ClientCode = ClientCode AndAlso
                                                                           Entity.DivisionCode = DivisionCode AndAlso
                                                                           Entity.ProductCode = ProductCode AndAlso
                                                                           Entity.JobNumber = JobNumber AndAlso
                                                                           Entity.IsOpen = 1
                                                                     Select Entity

                    Try

                        SearchableComboBoxGeneral_Component.SelectedValue = Nothing

                    Catch ex As Exception

                    End Try

                    SearchableComboBoxGeneral_Component.SelectSingleItemDataSource()

                End Using

            Else

                Try

                    SearchableComboBoxGeneral_Component.SelectedValue = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub LoadContacts()

            'objects
            Dim ClientContactIDs As Generic.List(Of Integer) = Nothing
            Dim ClientContactDetailList As Integer() = Nothing
            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ProductCode As String = ""

            If SearchableComboBoxGeneral_Product.HasASelectedValue AndAlso SearchableComboBoxGeneral_Division.HasASelectedValue AndAlso SearchableComboBoxGeneral_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue
                        DivisionCode = SearchableComboBoxGeneral_Division.GetSelectedValue
                        ProductCode = SearchableComboBoxGeneral_Product.GetSelectedValue

                        ClientContactIDs = New Generic.List(Of Integer)

                        ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                                   Where Entity.DivisionCode = DivisionCode AndAlso
                                                         Entity.ProductCode = ProductCode
                                                   Select Entity.ContactID).ToArray)

                        ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                                   Where Entity.DivisionCode = DivisionCode AndAlso
                                                         Entity.ProductCode Is Nothing
                                                   Select Entity.ContactID).ToArray)

                        ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, ClientCode).Include("ClientContactDetail")
                                                   Where Entity.ClientContactDetail.Count = 0
                                                   Select Entity.ContactID).ToArray)

                        ClientContactDetailList = ClientContactIDs.Distinct.ToArray

                        ComboBoxGeneral_Contact.DataSource = (From Entity In AdvantageFramework.Security.Database.Procedures.ClientContact.LoadAllActive(SecurityDbContext).OrderBy(Function(Entity) Entity.FullNameFML)
                                                              Where ClientContactDetailList.Contains(Entity.ContactID)).ToList

                        Try

                            ComboBoxGeneral_Contact.SelectedValue = Nothing

                        Catch ex As Exception

                        End Try

                        ComboBoxGeneral_Contact.SelectSingleItemDataSource()

                    End Using

                End Using

            Else

                Try

                    ComboBoxGeneral_Contact.SelectedValue = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Function ValidateForAddingNewActivity(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ComboBoxGeneral_Type.SelectedValue = "A" AndAlso DataGridViewEmployeeRightSection_SelectedEmployees.CurrentView.RowCount > 1 Then

                    ErrorMessage = "Please select only one employee for appointment."
                    IsValid = False

                End If

                If IsValid Then

                    If DateTimePickerGeneral_Start.Value > DateTimePickerGeneral_End.Value Then

                        ErrorMessage = "End date cannot be less than start date."
                        IsValid = False

                    End If

                End If

                If IsValid Then

                    If ComboBoxGeneral_Type.SelectedValue = "A" AndAlso ComboBoxGeneral_Category.SelectedValue = "no" Then

                        ErrorMessage = "Please select a category."
                        IsValid = False

                    End If

                End If

                If IsValid Then

                    If ComboBoxGeneral_Type.SelectedValue = "H" Then

                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[usp_wv_calendar_check_holidays] '{0}', '{1}'", DateTimePickerGeneral_Start.Value.ToShortDateString, DateTimePickerGeneral_End.Value.ToShortDateString)).FirstOrDefault > 0 Then

                            ErrorMessage = "Holiday already exists for this day."
                            IsValid = False

                        End If

                    End If

                End If

                If IsValid Then

                    If SearchableComboBoxGeneral_Client.HasASelectedValue Then

                        If SearchableComboBoxGeneral_Division.HasASelectedValue = False Then

                            ErrorMessage = "Please select a Division."
                            IsValid = False

                        ElseIf SearchableComboBoxGeneral_Product.HasASelectedValue = False Then

                            ErrorMessage = "Please select a Product."
                            IsValid = False

                        End If

                    End If

                End If

                If IsValid Then

                    If SearchableComboBoxGeneral_Division.HasASelectedValue Then

                        If SearchableComboBoxGeneral_Client.HasASelectedValue = False Then

                            ErrorMessage = "Please select a Client."
                            IsValid = False

                        ElseIf SearchableComboBoxGeneral_Product.HasASelectedValue = False Then

                            ErrorMessage = "Please select a Product."
                            IsValid = False

                        End If

                    End If

                End If

                If IsValid Then

                    If SearchableComboBoxGeneral_Product.HasASelectedValue Then

                        If SearchableComboBoxGeneral_Client.HasASelectedValue = False Then

                            ErrorMessage = "Please select a Client."
                            IsValid = False

                        ElseIf SearchableComboBoxGeneral_Division.HasASelectedValue = False Then

                            ErrorMessage = "Please select a Division."
                            IsValid = False

                        End If

                    End If

                End If

                If IsValid Then

                    If SearchableComboBoxGeneral_Job.HasASelectedValue Then

                        If SearchableComboBoxGeneral_Component.HasASelectedValue = False Then

                            ErrorMessage = "Please select a Component."
                            IsValid = False

                        End If

                    End If

                End If

                If IsValid Then

                    If SearchableComboBoxGeneral_Component.HasASelectedValue Then

                        If SearchableComboBoxGeneral_Job.HasASelectedValue = False Then

                            ErrorMessage = "Please select a Job."
                            IsValid = False

                        End If

                    End If

                End If

            End Using

            ValidateForAddingNewActivity = IsValid

        End Function
        Private Sub SetupDateTimePickers()

            If CheckBoxGeneral_AllDay.Checked Then

                TimePickerGeneral_StartTime.Enabled = False
                TimePickerGeneral_EndTime.Enabled = False

            Else

                TimePickerGeneral_StartTime.Enabled = True
                TimePickerGeneral_EndTime.Enabled = True

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonEmployeeRightSection_AddEmployee.Enabled = DataGridViewEmployeeLeftSection_AvailableEmployees.HasASelectedRow
            ButtonEmployeeRightSection_RemoveEmployee.Enabled = DataGridViewEmployeeRightSection_SelectedEmployees.HasASelectedRow

            If ComboBoxGeneral_Type.HasASelectedValue Then

                ComboBoxGeneral_Category.Enabled = (ComboBoxGeneral_Type.GetSelectedValue = "A" OrElse ComboBoxGeneral_Type.GetSelectedValue = "H")
                SearchableComboBoxGeneral_Client.Enabled = (ComboBoxGeneral_Type.GetSelectedValue <> "A" AndAlso ComboBoxGeneral_Type.GetSelectedValue <> "H")
                SearchableComboBoxGeneral_Division.Enabled = (ComboBoxGeneral_Type.GetSelectedValue <> "A" AndAlso ComboBoxGeneral_Type.GetSelectedValue <> "H" AndAlso SearchableComboBoxGeneral_Client.HasASelectedValue)
                SearchableComboBoxGeneral_Product.Enabled = (ComboBoxGeneral_Type.GetSelectedValue <> "A" AndAlso ComboBoxGeneral_Type.GetSelectedValue <> "H" AndAlso SearchableComboBoxGeneral_Client.HasASelectedValue AndAlso SearchableComboBoxGeneral_Division.HasASelectedValue)
                SearchableComboBoxGeneral_Job.Enabled = (ComboBoxGeneral_Type.GetSelectedValue <> "A" AndAlso ComboBoxGeneral_Type.GetSelectedValue <> "H" AndAlso SearchableComboBoxGeneral_Client.HasASelectedValue AndAlso SearchableComboBoxGeneral_Division.HasASelectedValue AndAlso SearchableComboBoxGeneral_Product.HasASelectedValue)
                SearchableComboBoxGeneral_Component.Enabled = (ComboBoxGeneral_Type.GetSelectedValue <> "A" AndAlso ComboBoxGeneral_Type.GetSelectedValue <> "H" AndAlso SearchableComboBoxGeneral_Client.HasASelectedValue AndAlso SearchableComboBoxGeneral_Division.HasASelectedValue AndAlso SearchableComboBoxGeneral_Product.HasASelectedValue AndAlso SearchableComboBoxGeneral_Job.HasASelectedValue)
                ComboBoxGeneral_Contact.Enabled = (ComboBoxGeneral_Type.GetSelectedValue <> "A" AndAlso ComboBoxGeneral_Type.GetSelectedValue <> "H" AndAlso SearchableComboBoxGeneral_Client.HasASelectedValue AndAlso SearchableComboBoxGeneral_Division.HasASelectedValue AndAlso SearchableComboBoxGeneral_Product.HasASelectedValue)
                ComboBoxGeneral_Function.Enabled = (ComboBoxGeneral_Type.GetSelectedValue <> "A" AndAlso ComboBoxGeneral_Type.GetSelectedValue <> "H")

            Else

                ComboBoxGeneral_Category.Enabled = False
                SearchableComboBoxGeneral_Client.Enabled = False
                SearchableComboBoxGeneral_Division.Enabled = False
                SearchableComboBoxGeneral_Product.Enabled = False
                SearchableComboBoxGeneral_Job.Enabled = False
                SearchableComboBoxGeneral_Component.Enabled = False
                ComboBoxGeneral_Contact.Enabled = False
                ComboBoxGeneral_Function.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef EmployeeNonTaskID As Integer, Optional ByVal PreselectedActivityType As String = "", Optional ByVal PreselectedStart As Date = Nothing, Optional ByVal PreselectedEnd As Date = Nothing, Optional ByVal PreselectedEmployeeCode As String = "",
                                              Optional ByVal PreselectedClientCode As String = "", Optional ByVal PreselectedDivisionCode As String = "", Optional ByVal PreselectedProductCode As String = "",
                                              Optional ByVal PreselectedJobNumber As Integer = 0, Optional ByVal PreselectedJobComponentNumber As Short = 0, Optional ByVal PreselectedFunctionCode As String = "") As System.Windows.Forms.DialogResult

            'objects
            Dim ActivityEditDialog As AdvantageFramework.Desktop.Presentation.ActivityEditDialog = Nothing

            ActivityEditDialog = New AdvantageFramework.Desktop.Presentation.ActivityEditDialog(EmployeeNonTaskID, PreselectedActivityType, PreselectedStart, PreselectedEnd,
                                                                                                PreselectedEmployeeCode, PreselectedClientCode, PreselectedDivisionCode,
                                                                                                PreselectedProductCode, PreselectedJobNumber, PreselectedJobComponentNumber,
                                                                                                PreselectedFunctionCode)

            ShowFormDialog = ActivityEditDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                EmployeeNonTaskID = ActivityEditDialog.EmployeeNonTaskID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ActivityEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewEmployeeLeftSection_AvailableEmployees.MultiSelect = True
            DataGridViewEmployeeLeftSection_AvailableEmployees.ShowSelectDeselectAllButtons = True
            DataGridViewEmployeeRightSection_SelectedEmployees.MultiSelect = True
            DataGridViewEmployeeRightSection_SelectedEmployees.ShowSelectDeselectAllButtons = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxGeneral_Type.SetPropertySettings("Type", GetType(Integer), True)
                TextBoxGeneral_Subject.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeNonTask.Properties.Description, "Subject")
                TextBoxGeneral_Subject.SetRequired(True)

                DateTimePickerGeneral_Start.DisplayName = "Start Date"
                DateTimePickerGeneral_Start.SetRequired(True)
                DateTimePickerGeneral_End.DisplayName = "End Date"
                DateTimePickerGeneral_End.SetRequired(True)

                TimePickerGeneral_StartTime.DisplayName = "Start Time"
                TimePickerGeneral_StartTime.SetRequired(True)
                TimePickerGeneral_EndTime.DisplayName = "End Time"
                TimePickerGeneral_EndTime.SetRequired(True)

                ComboBoxGeneral_Priority.SetPropertySettings("Priority", GetType(Short))
                ComboBoxGeneral_Reminder.SetPropertySettings("Reminder", GetType(Integer))

                SearchableComboBoxGeneral_Client.DisplayName = "Client"
                SearchableComboBoxGeneral_Division.DisplayName = "Division"
                SearchableComboBoxGeneral_Product.DisplayName = "Product"
                SearchableComboBoxGeneral_Job.DisplayName = "Job"
                SearchableComboBoxGeneral_Component.DisplayName = "Component"
                ComboBoxGeneral_Contact.DisplayName = "Contact"
                ComboBoxGeneral_Function.DisplayName = "Function"

            End Using

            ComboBoxGeneral_Priority.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.AlertSystem.PriorityLevels), False)
            ComboBoxGeneral_Priority.SelectedValue = CShort(AdvantageFramework.AlertSystem.PriorityLevels.Normal)
            ComboBoxGeneral_Reminder.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Calendar.ReminderOptions))

            TabItemActivitySettings_EmployeeTab.Visible = AdvantageFramework.Security.LoadUserGroupSetting(Me.Session, Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees).OfType(Of Boolean).Any(Function(Setting) Setting = True)

            If AdvantageFramework.Security.LoadUserGroupSetting(Me.Session, Security.GroupSettings.Calendar_AllowGroupToAddHolidays).OfType(Of Boolean).Any(Function(Setting) Setting = True) Then

                ComboBoxGeneral_Type.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Calendar.ActivityTypes))

            Else

                ComboBoxGeneral_Type.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Calendar.ActivityTypes)).Where(Function(EnumObject) EnumObject.Code <> "H").ToList

            End If

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.Connection.Open()

                        ComboBoxGeneral_Category.DataSource = AdvantageFramework.Database.Procedures.IndirectCategory.LoadAllActive(DbContext)
                        ComboBoxGeneral_Category.AddComboItemToExistingDataSource("", "no", True)
                        ComboBoxGeneral_Category.AddComboItemToExistingDataSource("*NONE*", "", False)
                        SearchableComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                        ComboBoxGeneral_Function.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext))
                        _Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext))

                        DataGridViewEmployeeLeftSection_AvailableEmployees.DataSource = _Employees
                        DataGridViewEmployeeRightSection_SelectedEmployees.DataSource = New Generic.List(Of AdvantageFramework.Database.Core.Employee)

                        If _EmployeeNonTaskID = 0 Then

                            ButtonItemActions_Add.Visible = True
                            ButtonItemActions_Save.Visible = False
                            ButtonItemActions_Delete.Visible = False
                            ButtonItemActions_Cancel.Visible = True

                            If String.IsNullOrEmpty(_PreselectedActivityType) = False Then

                                ComboBoxGeneral_Type.SelectedValue = _PreselectedActivityType

                            End If

                            AdvantageFramework.Calendar.GetDefaultStartAndEndTimes(StartDate, EndDate)

                            If IsNothing(_PreselectedStart) = False Then

                                DateTimePickerGeneral_Start.Value = _PreselectedStart
                                TimePickerGeneral_StartTime.Value = _PreselectedStart

                            Else

                                DateTimePickerGeneral_Start.Value = StartDate
                                TimePickerGeneral_StartTime.Value = StartDate

                            End If

                            If IsNothing(_PreselectedEnd) = False Then

                                DateTimePickerGeneral_End.Value = _PreselectedEnd
                                TimePickerGeneral_EndTime.Value = _PreselectedEnd

                            Else

                                DateTimePickerGeneral_End.Value = EndDate
                                TimePickerGeneral_EndTime.Value = EndDate

                            End If

                            If String.IsNullOrEmpty(_PreselectedEmployeeCode) = False Then

                                AddEmployees(_PreselectedEmployeeCode)

                            End If

                            If String.IsNullOrEmpty(_PreselectedClientCode) = False Then

                                SearchableComboBoxGeneral_Client.EditValue = _PreselectedClientCode

                                LoadDivisions()

                            End If

                            If String.IsNullOrEmpty(_PreselectedDivisionCode) = False Then

                                SearchableComboBoxGeneral_Division.EditValue = _PreselectedDivisionCode

                                LoadProducts()

                            End If

                            If String.IsNullOrEmpty(_PreselectedProductCode) = False Then

                                SearchableComboBoxGeneral_Product.EditValue = _PreselectedProductCode

                                LoadJobs()

                                LoadContacts()

                            End If

                            If _PreselectedJobNumber > 0 Then

                                SearchableComboBoxGeneral_Job.EditValue = _PreselectedJobNumber

                                LoadJobComponents()

                            End If

                            If _PreselectedJobComponentNumber > 0 Then

                                SearchableComboBoxGeneral_Component.EditValue = _PreselectedJobComponentNumber

                            End If

                        Else

                            EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, _EmployeeNonTaskID)

                            If EmployeeNonTask IsNot Nothing Then

                                ButtonItemActions_Add.Visible = False
                                ButtonItemActions_Save.Visible = True
                                ButtonItemActions_Delete.Visible = True
                                ButtonItemActions_Cancel.Visible = True

                                ComboBoxGeneral_Type.SelectedValue = EmployeeNonTask.Type
                                TextBoxGeneral_Subject.Text = EmployeeNonTask.Description
                                CheckBoxGeneral_AllDay.CheckValue = EmployeeNonTask.IsAllDay.GetValueOrDefault(0)

                                SetupDateTimePickers()

                                DateTimePickerGeneral_Start.Value = EmployeeNonTask.StartDateAndTime.GetValueOrDefault(Now)
                                DateTimePickerGeneral_End.Value = EmployeeNonTask.EndDateAndTime.GetValueOrDefault(Now)

                                TimePickerGeneral_StartTime.Value = EmployeeNonTask.StartDateAndTime.GetValueOrDefault(Now)
                                TimePickerGeneral_EndTime.Value = EmployeeNonTask.EndDateAndTime.GetValueOrDefault(Now)

                                ComboBoxGeneral_Priority.SelectedValue = EmployeeNonTask.Priority.GetValueOrDefault(CShort(AdvantageFramework.AlertSystem.PriorityLevels.Normal))
                                ComboBoxGeneral_Reminder.SelectedValue = EmployeeNonTask.Reminder

                                If String.IsNullOrEmpty(EmployeeNonTask.ClientCode) = False Then

                                    SearchableComboBoxGeneral_Client.EditValue = EmployeeNonTask.ClientCode

                                    LoadDivisions()

                                End If

                                If String.IsNullOrEmpty(EmployeeNonTask.DivisionCode) = False Then

                                    SearchableComboBoxGeneral_Division.EditValue = EmployeeNonTask.DivisionCode

                                    LoadProducts()

                                End If

                                If String.IsNullOrEmpty(EmployeeNonTask.ProductCode) = False Then

                                    SearchableComboBoxGeneral_Product.EditValue = EmployeeNonTask.ProductCode

                                    LoadJobs()

                                    LoadContacts()

                                End If

                                If EmployeeNonTask.JobNumber.HasValue AndAlso EmployeeNonTask.JobNumber > 0 Then

                                    SearchableComboBoxGeneral_Job.EditValue = EmployeeNonTask.JobNumber

                                    LoadJobComponents()

                                End If

                                If EmployeeNonTask.JobComponentNumber.HasValue AndAlso EmployeeNonTask.JobComponentNumber > 0 Then

                                    SearchableComboBoxGeneral_Component.EditValue = EmployeeNonTask.JobComponentNumber

                                End If

                                AddEmployees(DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0}", EmployeeNonTask.ID)).ToArray)

                                RichEditDetails_Description.Text = EmployeeNonTask.NontaskDescription

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("The activity you are trying to edit does not exist anymore.")
                                Me.Close()

                            End If

                        End If

                        DbContext.Database.Connection.Close()

                    End Using

                End Using

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub ActivityEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Added As Boolean = False
            Dim ErrorMessage As String = ""
            Dim DayDifference As Integer = 0
            Dim EmployeeCodes() As String = Nothing

            If Me.Validator Then

                If ValidateForAddingNewActivity(ErrorMessage) Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                    Me.ShowWaitForm("Adding...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                            If Agency IsNot Nothing AndAlso Employee IsNot Nothing Then

                                EmployeeNonTask = New AdvantageFramework.Database.Entities.EmployeeNonTask

                                EmployeeNonTask.DbContext = DbContext

                                EmployeeNonTask.EmployeeCode = Employee.Code
                                EmployeeNonTask.Type = ComboBoxGeneral_Type.GetSelectedValue
                                EmployeeNonTask.Description = TextBoxGeneral_Subject.Text
                                EmployeeNonTask.Category = ComboBoxGeneral_Category.GetSelectedValue
                                EmployeeNonTask.StartDate = CDate(DateTimePickerGeneral_Start.Value.ToShortDateString)
                                EmployeeNonTask.EndDate = CDate(DateTimePickerGeneral_End.Value.ToShortDateString)

                                EmployeeNonTask.IsAllDay = CheckBoxGeneral_AllDay.CheckValue

                                If CheckBoxGeneral_AllDay.Checked Then

                                    EmployeeNonTask.StartDateAndTime = CDate(DateTimePickerGeneral_Start.Value.ToShortDateString & " 12:00:00 AM")
                                    EmployeeNonTask.EndDateAndTime = CDate(DateTimePickerGeneral_End.Value.ToShortDateString & " 11:59:00 PM")

                                Else

                                    EmployeeNonTask.StartDateAndTime = TimePickerGeneral_StartTime.Value
                                    EmployeeNonTask.EndDateAndTime = TimePickerGeneral_EndTime.Value

                                End If

                                DayDifference = Math.Abs(DateDiff(DateInterval.Day, CDate(EmployeeNonTask.StartDateAndTime), CDate(EmployeeNonTask.EndDateAndTime)))

                                If CheckBoxGeneral_AllDay.Checked Then

                                    If EmployeeNonTask.Type = "H" Then

                                        EmployeeNonTask.Hours = 0

                                    Else

                                        If DayDifference = 0 Then

                                            EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0), 2))

                                        Else

                                            EmployeeNonTask.Hours = CDec(FormatNumber(Agency.StandardHours.GetValueOrDefault(0) * DayDifference, 2))

                                        End If

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

                                EmployeeNonTask.Priority = CShort(ComboBoxGeneral_Priority.SelectedValue)
                                EmployeeNonTask.Reminder = ComboBoxGeneral_Reminder.GetSelectedValue

                                If ComboBoxGeneral_Type.GetSelectedValue <> "A" AndAlso ComboBoxGeneral_Type.GetSelectedValue <> "H" Then

                                    EmployeeNonTask.ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue
                                    EmployeeNonTask.DivisionCode = SearchableComboBoxGeneral_Division.GetSelectedValue
                                    EmployeeNonTask.ProductCode = SearchableComboBoxGeneral_Product.GetSelectedValue
                                    EmployeeNonTask.JobNumber = SearchableComboBoxGeneral_Job.GetSelectedValue
                                    EmployeeNonTask.JobComponentNumber = SearchableComboBoxGeneral_Component.GetSelectedValue
                                    EmployeeNonTask.ContactID = ComboBoxGeneral_Contact.GetSelectedValue
                                    EmployeeNonTask.FunctionCode = ComboBoxGeneral_Function.GetSelectedValue

                                End If

                                EmployeeNonTask.NontaskDescription = RichEditDetails_Description.Text

                                If AdvantageFramework.Database.Procedures.EmployeeNonTask.Insert(DbContext, EmployeeNonTask) Then

                                    If ComboBoxGeneral_Type.GetSelectedValue <> "H" Then

                                        EmployeeCodes = DataGridViewEmployeeRightSection_SelectedEmployees.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToArray

                                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[EMP_NON_TASKS_EMPS]([NON_TASK_ID],[EMP_CODE],[EMAIL_ADDRESS]) SELECT {0}, [EMP_CODE], [EMP_EMAIL] FROM dbo.EMPLOYEE WHERE EMP_CODE IN ('{1}')", EmployeeNonTask.ID, Join(EmployeeCodes, "', '")))

                                        AdvantageFramework.Calendar.Sync(Me.Session.ConnectionString, Me.Session.UserCode, EmployeeNonTask, False, False, False, Me.Session.UseWindowsAuthentication)

                                    Else

                                        AdvantageFramework.Calendar.Sync(Me.Session.ConnectionString, Me.Session.UserCode, EmployeeNonTask, True, False, False, Me.Session.UseWindowsAuthentication)

                                    End If

                                    Added = True

                                End If

                            End If

                        End Using

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If Added Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If


                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

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
        Private Sub ComboBoxGeneral_Type_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxGeneral_Type.SelectedValueChanged

            If ComboBoxGeneral_Type.HasASelectedValue Then

                If (ComboBoxGeneral_Type.GetSelectedValue <> "A" AndAlso ComboBoxGeneral_Type.GetSelectedValue <> "H") Then

                    ComboBoxGeneral_Category.SelectedValue = "no"

                End If

                If ComboBoxGeneral_Type.GetSelectedValue = "H" Then

                    TabControlPanelEmployeeTab_Employee.Enabled = False

                Else

                    TabControlPanelEmployeeTab_Employee.Enabled = True

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxGeneral_AllDay_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxGeneral_AllDay.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                SetupDateTimePickers()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonEmployeeRightSection_AddEmployee_Click(sender As Object, e As EventArgs) Handles ButtonEmployeeRightSection_AddEmployee.Click

            If DataGridViewEmployeeLeftSection_AvailableEmployees.HasASelectedRow Then

                AddEmployees(DataGridViewEmployeeLeftSection_AvailableEmployees.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToArray)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonEmployeeRightSection_RemoveEmployee_Click(sender As Object, e As EventArgs) Handles ButtonEmployeeRightSection_RemoveEmployee.Click

            If DataGridViewEmployeeRightSection_SelectedEmployees.HasASelectedRow Then

                RemoveEmployees(DataGridViewEmployeeRightSection_SelectedEmployees.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToArray)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SearchableComboBoxGeneral_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneral_Client.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadDivisions()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SearchableComboBoxGeneral_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneral_Division.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadProducts()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SearchableComboBoxGeneral_Product_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneral_Product.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadJobs()

                LoadContacts()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SearchableComboBoxGeneral_Job_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneral_Job.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadJobComponents()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DateTimePickerGeneral_Start_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerGeneral_Start.ValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                Try

                    DateTimePickerGeneral_End.Value = DateTimePickerGeneral_Start.Value
                    TimePickerGeneral_StartTime.Value = CDate(DateTimePickerGeneral_Start.Value.ToShortDateString & " " & TimePickerGeneral_StartTime.Value.GetValueOrDefault(DateTimePickerGeneral_Start.Value).ToShortTimeString)
                    TimePickerGeneral_EndTime.Value = CDate(DateTimePickerGeneral_Start.Value.ToShortDateString & " " & TimePickerGeneral_EndTime.Value.GetValueOrDefault(DateTimePickerGeneral_Start.Value).ToShortTimeString)

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub DateTimePickerGeneral_End_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerGeneral_End.ValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                Try

                    If DateTimePickerGeneral_End.Value < DateTimePickerGeneral_Start.Value Then

                        DateTimePickerGeneral_Start.Value = DateTimePickerGeneral_End.Value
                        TimePickerGeneral_StartTime.Value = CDate(DateTimePickerGeneral_End.Value & " " & TimePickerGeneral_StartTime.Value.GetValueOrDefault(DateTimePickerGeneral_End.Value).ToShortTimeString)

                    End If

                    TimePickerGeneral_EndTime.Value = CDate(DateTimePickerGeneral_End.Value & " " & TimePickerGeneral_EndTime.Value.GetValueOrDefault(TimePickerGeneral_EndTime.Value).ToShortTimeString)

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub TimePickerGeneral_StartTime_ValueChanged(sender As Object, e As EventArgs) Handles TimePickerGeneral_StartTime.ValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                Try

                    If TimePickerGeneral_StartTime.Value.HasValue Then

                        TimePickerGeneral_EndTime.Value = TimePickerGeneral_StartTime.Value.Value.AddMinutes(30)

                    End If

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace