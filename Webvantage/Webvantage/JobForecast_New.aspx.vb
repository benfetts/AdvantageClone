Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar

Public Class JobForecast_New
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0
    Private _AvailableRevisions As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastView) = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
        Get
            If _DbContext Is Nothing Then
                _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            End If
            Return _DbContext
        End Get
    End Property
    Private ReadOnly Property AvailableRevisions As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastView)
        Get
            If _AvailableRevisions Is Nothing Then

            End If
        End Get
    End Property
    Private ReadOnly Property CanUserUpdate As Boolean
        Get
            If ViewState("JF_CanUserUpdate") Is Nothing Then
                ViewState("JF_CanUserUpdate") = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Methods.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserUpdate")
        End Get
    End Property
    Private ReadOnly Property CanUserAdd As Boolean
        Get
            If ViewState("JF_CanUserAdd") Is Nothing Then
                ViewState("JF_CanUserAdd") = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Methods.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserAdd")
        End Get
    End Property
    Private ReadOnly Property IsFromJobComponent As Boolean
        Get
            Return (_JobNumber > 0 AndAlso _JobComponentNumber > 0)
        End Get
    End Property
    Private Property IsCopying As Boolean
        Get
            Try
                Return ViewState("JF_IsCopying")
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("JF_IsCopying") = value
        End Set
    End Property
    Private Property CopyFromRevisionID As Integer
        Get
            Try
                Return ViewState("JF_CopyFromRevisionID")
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(value As Integer)
            ViewState("JF_CopyFromRevisionID") = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub LoadControlSettings()

        'objects
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.EmployeeTimeForecast.Properties.Description)

        If PropertyDescriptor IsNot Nothing Then

            RadTextBoxDescription.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)
            RadTextBoxDescription.CssClass = "RequiredInput"

        End If

    End Sub
    Private Sub LoadRadPageView(ByVal RadPageView As Telerik.Web.UI.RadPageView)

        'objects
        Dim AllowGoBack As Boolean = False
        Dim AllowSave As Boolean = False
        Dim AllowGoForward As Boolean = False

        If RadPageView Is Nothing Then

            RadPageView = RadPageViewForecastOptions

        End If

        RadMultiPageForecast.SelectedIndex = RadPageView.Index

        If RadPageView Is RadPageViewForecastOptions Then

            LoadRadPageViewForecastOptions()
            Me.Title = "Forecast Options"

        ElseIf RadPageView Is RadPageViewSelectForecast Then

            LoadRadPageViewSelectForecast()
            Me.Title = "Select Existing Forecast"
            AllowGoBack = True
            AllowSave = Me.IsFromJobComponent
            AllowGoForward = Not Me.IsFromJobComponent

        ElseIf RadPageView Is RadPageViewNew Then

            LoadRadPageViewNew()
            If Me.IsCopying Then
                Me.Title = "Copy Forecast"
            Else
                Me.Title = "Create New Forecast"
            End If
            AllowGoBack = True
            AllowSave = True

        End If

        Me.HiddenFieldWindowTitle.Value = Me.Title

        RadToolBarButtonBack.Visible = AllowGoBack
        RadToolBarButtonBackSeparator.Visible = AllowGoBack
        RadToolBarButtonSave.Visible = AllowSave
        RadToolBarButtonSelectForecast.Visible = AllowGoForward
        RadToolBarButtonFirstSeparator.Visible = AllowSave OrElse AllowGoForward

    End Sub
    Private Sub LoadRadPageViewForecastOptions()

        ButtonAddToExisting.Enabled = Me.CanUserUpdate
        ButtonNewForecast.Enabled = Me.CanUserAdd
        ButtonCopyForecast.Enabled = Me.CanUserAdd

        If Me.IsFromJobComponent Then

            ButtonCopyForecast.Visible = False

        Else

            ButtonAddToExisting.Visible = False

        End If

    End Sub
    Private Sub LoadRadPageViewSelectForecast()

        'objects
        Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim EmployeeCodes As String() = Nothing

        EmployeeCodes = AdvantageFramework.Database.Procedures.JobForecast.Load(Me.DbContext).Select(Function(item) item.AssignedToEmployeeCode).Distinct.ToArray

        Employees = (From Item In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(_Session, Me.DbContext)
                     Join EmpCode In EmployeeCodes On EmpCode Equals Item.Code
                     Select Item).ToList

        DropDownListAssignedTo.DataSource = (From Item In Employees
                                             Select [Code] = Item.Code,
                                                 [Name] = Item.ToString()).ToList
        DropDownListAssignedTo.DataBind()
        DropDownListAssignedTo.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please Select]", ""))

        If Employees.Any(Function(item) item.Code = _Session.User.EmployeeCode) Then

            DropDownListAssignedTo.SelectedValue = _Session.User.EmployeeCode

        End If

        If Me.IsFromJobComponent Then

            CheckBoxHighestRevisionOnly.Visible = False

        End If

        RadGridJobForecasts.Rebind()

    End Sub
    Private Sub LoadRadPageViewNew()

        LoadControlSettings()

        DropDownListPostPeriodStart.DataSource = From PostPeriod In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(Me.DbContext).OrderByDescending(Function(PostPeriod) PostPeriod.Code).ToList
                                                 Select [MonthAndYear] = PostPeriod.ToString(),
                                                                [Code] = PostPeriod.Code
        DropDownListPostPeriodStart.DataBind()
        DropDownListPostPeriodStart.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(Me.DbContext, _Session.User.EmployeeCode).Count > 0 Then

            DropDownListOffice.DataSource = (From Item In AdvantageFramework.Database.Procedures.Office.LoadAllActive(Me.DbContext)
                                             Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(Me.DbContext, _Session.User.EmployeeCode) On Item.Code Equals EmpOffice.OfficeCode
                                             Order By Item.Name Ascending
                                             Select Item).ToList

        Else

            DropDownListOffice.DataSource = (From Item In AdvantageFramework.Database.Procedures.Office.LoadAllActive(Me.DbContext)
                                             Order By Item.Name Ascending
                                             Select Item).ToList

        End If

        DropDownListOffice.DataBind()
        DropDownListOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        If DropDownListOffice.Items.Count = 2 Then

            DropDownListOffice.Items(1).Selected = True

        End If

        DropDownListEmployee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(_Session, Me.DbContext).ToList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                                                                                                   .Name = Employee.ToString})
        DropDownListEmployee.DataBind()
        DropDownListEmployee.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        DropDownListPostPeriodStart.SelectedValue = Nothing
        DropDownListPostPeriodEnd.SelectedValue = Nothing
        DropDownListPostPeriodEnd.Enabled = False
        DropDownListEmployee.SelectedValue = Nothing
        RadTextBoxDescription.Text = ""
        RadTextBoxComment.Text = ""
        RadNumericTextBoxBudget.Value = Nothing

        If Me.IsCopying Then

            Try

                With AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(Me.DbContext, Me.CopyFromRevisionID)

                    If .JobForecast IsNot Nothing Then

                        RadTextBoxDescription.Text = .JobForecast.Description
                        DropDownListEmployee.SelectedValue = .JobForecast.AssignedToEmployeeCode
                        DropDownListPostPeriodStart.SelectedValue = .JobForecast.PostPeriodStart
                        DropDownListPostPeriodEnd.SelectedValue = .JobForecast.PostPeriodEnd
                        DropDownListOffice.SelectedValue = .JobForecast.OfficeCode
                        RadNumericTextBoxBudget.Value = .JobForecast.Budget

                    End If

                    RadTextBoxComment.Text = .Comment

                    LoadPostPeriodEndDropDown()

                End With

            Catch ex As Exception

            End Try

        End If

        RadTextBoxDescription.Focus()

    End Sub
    Private Function Save() As Boolean

        If RadMultiPageForecast.SelectedPageView Is RadPageViewNew Then

            Save = SaveNew()

        ElseIf RadMultiPageForecast.SelectedPageView Is RadPageViewSelectForecast Then

            Save = AddToExisting()

        Else

            Save = False

        End If

    End Function
    Private Function SaveNew() As Boolean

        'objects
        Dim Save As Boolean = True
        Dim Created As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
        Dim JobForecastToCopy As AdvantageFramework.Database.Entities.JobForecast = Nothing
        Dim JobForecastRevisionToCopy As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing

        If String.IsNullOrWhiteSpace(RadTextBoxDescription.Text) Then

            Me.ShowMessage("Description is required.")
            Exit Function

        End If

        If String.IsNullOrWhiteSpace(DropDownListPostPeriodStart.SelectedValue) OrElse
            String.IsNullOrWhiteSpace(DropDownListPostPeriodEnd.SelectedValue) Then

            Me.ShowMessage("Please select a post period range.")
            Exit Function

        End If

        If String.IsNullOrWhiteSpace(DropDownListOffice.SelectedValue) Then

            Me.ShowMessage("Please select an office.")
            Exit Function

        Else

            With AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(Me.DbContext, _Session.User.EmployeeCode)

                If .Count > 0 Then

                    If .Any(Function(item) item.OfficeCode = DropDownListOffice.SelectedValue) = False Then

                        Me.ShowMessage("The selected office is not valid. Please select another office.")
                        Exit Function

                    End If

                End If

            End With

        End If

        If String.IsNullOrWhiteSpace(DropDownListEmployee.SelectedValue) Then

            Me.ShowMessage("Please select an employee.")
            Exit Function

        Else

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, DropDownListEmployee.SelectedValue)

            If Employee Is Nothing Then

                Me.ShowMessage("The selected employee is not valid.  Please select another employee.")
                Exit Function

            End If

        End If

        If Me.IsCopying Then

            JobForecastRevisionToCopy = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(Me.DbContext, Me.CopyFromRevisionID)

            If JobForecastRevisionToCopy IsNot Nothing Then

                If AdvantageFramework.JobForecast.CopyJobForecastFromJobForecastRevision(Me.DbContext, RadTextBoxDescription.Text, RadTextBoxComment.Text, DropDownListPostPeriodStart.SelectedValue,
                                                                                         DropDownListPostPeriodEnd.SelectedValue, DropDownListEmployee.SelectedValue, DropDownListOffice.SelectedValue, RadNumericTextBoxBudget.Value,
                                                                                         JobForecastRevisionToCopy, JobForecastRevision) Then

                    Created = True

                End If

            End If

        Else

            If AdvantageFramework.JobForecast.CreateNewJobForecast(Me.DbContext, RadTextBoxDescription.Text, RadTextBoxComment.Text, DropDownListPostPeriodStart.SelectedValue, DropDownListPostPeriodEnd.SelectedValue,
                                                                   RadNumericTextBoxBudget.Value, DropDownListEmployee.SelectedValue, DropDownListOffice.SelectedValue, _JobNumber, _JobComponentNumber, JobForecastRevision) = True Then

                Created = True

            End If

        End If

        If Created = True AndAlso JobForecastRevision IsNot Nothing Then

            Me.RefreshCaller("JobForecast_Main.aspx", False, False, False)
            Me.CloseThisWindowAndOpenNewWindow([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", JobForecastRevision.ID))

        End If

        SaveNew = Created

    End Function
    Private Function AddToExisting() As Boolean

        'objects
        Dim Added As Boolean = False
        Dim JobForecastRevisionID As Integer = 0
        Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
        Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

        If RadGridJobForecasts.MasterTableView.GetSelectedItems().Count <> 1 Then

            Me.ShowMessage("Please select a revision.")
            Exit Function

        End If

        JobForecastRevisionID = CInt(RadGridJobForecasts.MasterTableView.GetSelectedItems().First.GetDataKeyValue("JobForecastRevisionID"))

        JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(Me.DbContext, JobForecastRevisionID)

        If JobForecastRevision Is Nothing Then

            Me.ShowMessage("Error loading revision!")
            Exit Function

        End If

        JobComponent = (From Item In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(Me.DbContext)
                        Where Item.JobNumber = _JobNumber AndAlso
                              Item.Number = _JobComponentNumber
                        Select Item).SingleOrDefault

        If JobComponent Is Nothing Then

            Me.ShowMessage("Error loading job component!")
            Exit Function

        End If

        If (From Item In AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(Me.DbContext, JobForecastRevisionID)
            Where Item.JobNumber = _JobNumber AndAlso
                  Item.JobComponentNumber = _JobComponentNumber
            Select Item).Any Then

            Me.ShowMessage("This Job Component is already included on the Forecast. Please select another Forecast.")
            Exit Function

        End If

        If AdvantageFramework.JobForecast.InsertNewJobForecastJob(Me.DbContext, JobForecastRevision, JobComponent) Then

            Added = True

            Me.RefreshCaller("JobForecast_Main.aspx", False, False, False)
            Me.CloseThisWindowAndOpenNewWindow([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", JobForecastRevision.ID))

        End If

        AddToExisting = Added

    End Function
    Private Sub LoadPostPeriodEndDropDown()

        'objects
        Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Dim PostPeriodList As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
        Dim CurrentSelectedPostPeriodEnd As String = Nothing
        Dim MaxDate As Date = Nothing
        Dim CurrentDate As Date = Nothing

        If [String].IsNullOrWhiteSpace(DropDownListPostPeriodStart.SelectedValue) = False Then

            CurrentSelectedPostPeriodEnd = DropDownListPostPeriodEnd.SelectedValue

            DropDownListPostPeriodEnd.Enabled = True
            DropDownListPostPeriodEnd.Items.Clear()

            PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(Me.DbContext, DropDownListPostPeriodStart.SelectedValue)

            If PostPeriod IsNot Nothing Then

                CurrentDate = PostPeriod.StartDate
                MaxDate = CurrentDate.AddMonths(AdvantageFramework.JobForecast._MaximumPostPeriodsPerForecast - 1)

            End If

            PostPeriodList = (From Item In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(Me.DbContext).OrderBy(Function(Item) Item.Code).ToList
                              Where Item.StartDate <= MaxDate AndAlso
                                        Item.StartDate >= CurrentDate
                              Select Item).ToList

            DropDownListPostPeriodEnd.DataSource = From Item In PostPeriodList.OrderByDescending(Function(Item) Item.Code)
                                                   Select [MonthAndYear] = Item.ToString(),
                                                              [Code] = Item.Code
            DropDownListPostPeriodEnd.DataBind()
            DropDownListPostPeriodEnd.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

            If String.IsNullOrWhiteSpace(CurrentSelectedPostPeriodEnd) = False Then

                If PostPeriodList.Any(Function(PPeriod) PPeriod.Code = CurrentSelectedPostPeriodEnd) = True Then

                    DropDownListPostPeriodEnd.SelectedValue = CurrentSelectedPostPeriodEnd

                Else

                    DropDownListPostPeriodEnd.SelectedIndex = 0

                End If

            Else

                'default to 12 months out
                If PostPeriodList.Count >= AdvantageFramework.JobForecast._MaximumPostPeriodsPerForecast Then

                    DropDownListPostPeriodEnd.SelectedValue = PostPeriodList(11).Code

                Else

                    DropDownListPostPeriodEnd.SelectedValue = PostPeriodList.Last.Code

                End If

            End If

            DropDownListPostPeriodEnd.Focus()

        Else

            DropDownListPostPeriodStart.Focus()
            DropDownListPostPeriodEnd.Enabled = False
            DropDownListPostPeriodEnd.SelectedIndex = 0

        End If


    End Sub

#Region "  Form Event Handlers "

    Private Sub JobForecast_New_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString

        QueryString = QueryString.FromCurrent()

        Try

            _JobNumber = QueryString.JobNumber

        Catch ex As Exception

        End Try

        Try

            _JobComponentNumber = CShort(QueryString.JobComponentNumber)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub JobForecast_New_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim RadPageView As Telerik.Web.UI.RadPageView = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            LoadRadPageView(Nothing)

        End If

    End Sub
    Private Sub JobForecast_New_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()
                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()
                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarJobForecast_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobForecast.ButtonClick

        Select Case e.Item.Value

            Case "Save"

                Save()

            Case "Cancel"

                Me.CloseThisWindow()

            Case "Previous"

                If Me.IsCopying AndAlso RadPageViewNew.Selected Then

                    LoadRadPageView(RadPageViewSelectForecast)

                Else

                    LoadRadPageView(RadPageViewForecastOptions)

                End If

            Case "SelectForecast"

                If RadGridJobForecasts.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem).Count > 0 Then

                    Me.CopyFromRevisionID = RadGridJobForecasts.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem).FirstOrDefault.GetDataKeyValue("JobForecastRevisionID")

                    LoadRadPageView(RadPageViewNew)

                Else

                    Me.ShowMessage("Please select a revision.")

                End If

        End Select

    End Sub
    Private Sub DropDownListPostPeriodStart_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles DropDownListPostPeriodStart.SelectedIndexChanged

        LoadPostPeriodEndDropDown()

    End Sub
    Private Sub RadGridJobForecasts_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridJobForecasts.NeedDataSource

        'objects
        Dim EmployeeCode As String = ""
        Dim DateToSearch As Date? = Nothing
        Dim JobForecastViews As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastView) = Nothing
        Dim RevsWithJob As Integer() = Nothing

        If RadPageViewSelectForecast.Selected = True Then

            EmployeeCode = DropDownListAssignedTo.SelectedValue

            If RadMonthYearPicker.SelectedDate.HasValue Then

                DateToSearch = RadMonthYearPicker.SelectedDate

            End If

            If Me.IsFromJobComponent Then 'adding job to existing forecast

                RevsWithJob = (From Item In AdvantageFramework.Database.Procedures.JobForecastJob.Load(Me.DbContext)
                               Where Item.JobNumber = _JobNumber AndAlso
                               Item.JobComponentNumber = _JobComponentNumber
                               Select Item.JobForecastRevisionID).ToArray

                JobForecastViews = (From Item In AdvantageFramework.JobForecast.LoadCurrentJobForecasts(Me.DbContext, EmployeeCode, Nothing, Nothing, DateToSearch, _Session.UserCode)
                                    Where RevsWithJob.Contains(Item.JobForecastRevisionID) = False AndAlso
                                                        Item.IsApproved = False
                                    Select Item).ToList

            Else ' copying forecast

                JobForecastViews = AdvantageFramework.JobForecast.LoadRevisions(Me.DbContext, EmployeeCode, Nothing, Nothing, DateToSearch, CheckBoxHighestRevisionOnly.Checked, _Session.UserCode)

            End If

            RadGridJobForecasts.DataSource = JobForecastViews.OrderBy(Function(Item) Item.PostPeriodStartDate).ThenByDescending(Function(item) item.CreatedDate).ToList

        End If

    End Sub
    Private Sub DropDownListAssignedTo_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles DropDownListAssignedTo.SelectedIndexChanged

        RadGridJobForecasts.Rebind()

    End Sub
    Private Sub RadMonthYearPicker_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles RadMonthYearPicker.SelectedDateChanged

        RadGridJobForecasts.Rebind()

    End Sub
    Protected Sub ForecastOptionsButtonClickHandler(sender As Object, e As EventArgs)

        'objects
        Dim RadPageView As Telerik.Web.UI.RadPageView = Nothing

        Me.IsCopying = False

        If sender Is ButtonAddToExisting Then

            RadPageView = RadPageViewSelectForecast

        ElseIf sender Is ButtonCopyForecast Then

            Me.IsCopying = True
            RadPageView = RadPageViewSelectForecast

        ElseIf sender Is ButtonNewForecast Then

            RadPageView = RadPageViewNew

        End If

        LoadRadPageView(RadPageView)

    End Sub
    Private Sub CheckBoxHighestRevisionOnly_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxHighestRevisionOnly.CheckedChanged

        RadGridJobForecasts.Rebind()

    End Sub

#End Region

#End Region

End Class
