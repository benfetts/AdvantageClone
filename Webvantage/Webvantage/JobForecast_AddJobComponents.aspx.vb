Public Class JobForecast_AddJobComponents
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _AllJobComponentsList As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
    Private _JobForecastRevisionID As Integer = 0

#End Region

#Region " Properties "

    Private Property HasMultipleRevisions As Boolean
        Get
            Try

                HasMultipleRevisions = Me.ViewState("JF_HasMultipleRevisions")

            Catch ex As Exception
                HasMultipleRevisions = True
            End Try
        End Get
        Set(value As Boolean)
            Me.ViewState("JF_HasMultipleRevisions") = value
        End Set
    End Property
    Private ReadOnly Property AllJobComponentsList(ByVal OfficeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal AccountExecCode As String) As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)
        Get

            'objects
            Dim AllJobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            If _AllJobComponentsList Is Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _AllJobComponentsList = AdvantageFramework.JobForecast.LoadAllJobComponents(Me.DbContext, SecurityDbContext, _Session.User)

                End Using

            End If

            AllJobComponents = _AllJobComponentsList

            If Not String.IsNullOrWhiteSpace(OfficeCode) Then

                AllJobComponents = AllJobComponents.Where(Function(item) item.OfficeCode = OfficeCode).ToList

            End If

            If Not String.IsNullOrWhiteSpace(ClientCode) Then

                AllJobComponents = AllJobComponents.Where(Function(item) item.ClientCode = ClientCode).ToList

            End If

            If Not String.IsNullOrWhiteSpace(DivisionCode) Then

                AllJobComponents = AllJobComponents.Where(Function(item) item.DivisionCode = DivisionCode).ToList

            End If

            If Not String.IsNullOrWhiteSpace(ProductCode) Then

                AllJobComponents = AllJobComponents.Where(Function(item) item.ProductCode = ProductCode).ToList

            End If

            If Not String.IsNullOrWhiteSpace(AccountExecCode) Then

                AllJobComponents = (From Item In AllJobComponents
                                    Join Comp In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(Me.DbContext).Select(Function(item) New With {.ID = item.ID, .AccountExexCode = item.AccountExecutiveEmployeeCode}).ToList On Item.ID Equals Comp.ID
                                    Where Comp.AccountExexCode = AccountExecCode
                                    Select Item).ToList

            End If

            Return AllJobComponents

        End Get
    End Property
    Private ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
        Get
            If _DbContext Is Nothing Then
                _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            End If
            Return _DbContext
        End Get
    End Property
    Private ReadOnly Property JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision
        Get

            If _JobForecastRevision Is Nothing Then
                _JobForecastRevision = (From Item In Me.DbContext.JobForecastRevisions
                                        Where Item.ID = _JobForecastRevisionID
                                        Select Item).SingleOrDefault
            End If
            Return _JobForecastRevision
        End Get
    End Property

#End Region

#Region " Methods "

    Public Function ConfirmDeleteMessage() As String

        Return AdvantageFramework.JobForecast.GetConfirmDeleteMessage(Me.HasMultipleRevisions)

    End Function
    Private Sub LoadAvailableJobComponents()

        'objects
        Dim AvailableJobComponentsList As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

        If Me.JobForecastRevision IsNot Nothing Then

            AvailableJobComponentsList = (From Item In Me.AllJobComponentsList(DropDownListOffice.SelectedValue, DropDownListClient.SelectedValue, DropDownListDivision.SelectedValue, DropDownListProduct.SelectedValue, DropDownListAccountExecutive.SelectedValue)
                                          Group Join JfJob In AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(Me.DbContext, Me.JobForecastRevision.ID).ToList On Item.JobNumber Equals JfJob.JobNumber And Item.JobComponentNumber Equals JfJob.JobComponentNumber Into CompList = Group
                                          From Comp In CompList.DefaultIfEmpty()
                                          Where Comp Is Nothing
                                          Select Item).ToList

            If AvailableJobComponentsList IsNot Nothing Then

                RadListBoxAvailableJobComponents.DataSource = FormatJobComponentListForListBox(AvailableJobComponentsList)

            Else

                RadListBoxAvailableJobComponents.Items.Clear()
                RadListBoxAvailableJobComponents.DataSource = Nothing

            End If

            RadListBoxAvailableJobComponents.DataBind()

        End If

    End Sub
    Private Function FormatJobComponentListForListBox(ByVal JobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)) As IEnumerable

        Try

            FormatJobComponentListForListBox = From JobComponent In JobComponents.OrderByDescending(Function(Entity) Entity.JobNumber).ThenBy(Function(Entity) Entity.JobComponentNumber)
                                               Select [ID] = JobComponent.ID,
                                                      [Description] = String.Format("{0}-{1} | {2} | {3} - {4} - {5}",
                                                                                    AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.JobNumber, 6, "0", True),
                                                                                    AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.JobComponentNumber, 3, "0", True),
                                                                                    JobComponent.JobComponentDescription, JobComponent.ClientCode, JobComponent.DivisionCode, JobComponent.ProductCode),
                                                      [JobNumber] = JobComponent.JobNumber,
                                                      [JobComponentNumber] = JobComponent.JobComponentNumber

        Catch ex As Exception
            FormatJobComponentListForListBox = Nothing
        End Try

    End Function
    Private Sub LoadOffices()

        DropDownListOffice.DataSource = Me.AllJobComponentsList(Nothing, Nothing, Nothing, Nothing, Nothing) _
                                            .GroupBy(Function(item) item.OfficeCode) _
                                            .Select(Function(item) New With {.Code = item.First.OfficeCode, .Name = item.First.OfficeName}) _
                                            .OrderBy(Function(item) item.Name).ToList
        DropDownListOffice.DataBind()
        DropDownListOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

    End Sub
    Private Sub LoadClients()

        'objects
        Dim ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing

        DropDownListClient.DataSource = Me.AllJobComponentsList(DropDownListOffice.SelectedValue, Nothing, Nothing, Nothing, Nothing) _
                                        .GroupBy(Function(item) item.ClientCode) _
                                        .Select(Function(item) New With {.Code = item.First.ClientCode, .Name = item.First.ClientName}) _
                                        .OrderBy(Function(item) item.Name).ToList
        DropDownListClient.DataBind()
        DropDownListClient.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        DropDownListDivision.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
        DropDownListDivision.DataBind()
        DropDownListDivision.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        DropDownListProduct.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
        DropDownListProduct.DataBind()
        DropDownListProduct.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        LoadAvailableJobComponents()

    End Sub
    Private Sub LoadDivisions()

        If DropDownListClient.SelectedValue IsNot Nothing AndAlso DropDownListClient.SelectedValue <> "" Then

            DropDownListDivision.DataSource = Me.AllJobComponentsList(DropDownListOffice.SelectedValue, DropDownListClient.SelectedValue, Nothing, Nothing, Nothing) _
                                                .GroupBy(Function(item) item.DivisionCode) _
                                                .Select(Function(item) New With {.Code = item.First.DivisionCode, .Name = item.First.DivisionName}) _
                                                .OrderBy(Function(item) item.Name).ToList
            DropDownListDivision.DataBind()
            DropDownListDivision.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        Else

            DropDownListDivision.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
            DropDownListDivision.DataBind()
            DropDownListDivision.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End If

        DropDownListProduct.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
        DropDownListProduct.DataBind()
        DropDownListProduct.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        LoadAvailableJobComponents()

    End Sub
    Private Sub LoadProducts()

        If DropDownListClient.SelectedValue IsNot Nothing AndAlso DropDownListClient.SelectedValue <> "" AndAlso
                DropDownListDivision.SelectedValue IsNot Nothing AndAlso DropDownListDivision.SelectedValue <> "" Then

            DropDownListProduct.DataSource = Me.AllJobComponentsList(DropDownListOffice.SelectedValue, DropDownListClient.SelectedValue, DropDownListDivision.SelectedValue, Nothing, Nothing) _
                                                .GroupBy(Function(item) item.DivisionCode) _
                                                .Select(Function(item) New With {.Code = item.First.ProductCode, .Name = item.First.ProductDescription}) _
                                                .OrderBy(Function(item) item.Name).ToList
            DropDownListProduct.DataBind()
            DropDownListProduct.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        Else

            DropDownListProduct.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
            DropDownListProduct.DataBind()
            DropDownListProduct.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End If

        LoadAvailableJobComponents()

    End Sub
    Private Sub LoadEmployees()

        Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

        If Me.JobForecastRevision IsNot Nothing Then

            EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadWithOfficeLimits(Me.DbContext, _Session).ToList

        Else

            EmployeeList = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

        End If

        DropDownListAccountExecutive.DataSource = EmployeeList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                   .Name = Employee.ToString})
        DropDownListAccountExecutive.DataBind()
        DropDownListAccountExecutive.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please Select]", ""))

    End Sub
    Private Sub AddJobComponentAttributeToRadListBoxItem(ByVal RadListBoxItem As Telerik.Web.UI.RadListBoxItem)

        If RadListBoxItem.DataItem IsNot Nothing Then

            Try

                RadListBoxItem.Attributes.Add("JobNumber", RadListBoxItem.DataItem.JobNumber)
                RadListBoxItem.Attributes.Add("JobComponentNumber", RadListBoxItem.DataItem.JobComponentNumber)

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub GetJobComponentAttributesFromRadListBoxItem(ByVal RadListBoxItem As Telerik.Web.UI.RadListBoxItem, ByRef JobNumber As Integer, ByRef JobComponentNumber As Short)

        If RadListBoxItem IsNot Nothing Then

            Try

                JobNumber = CInt(RadListBoxItem.Attributes("JobNumber"))
                JobComponentNumber = CShort(RadListBoxItem.Attributes("JobComponentNumber"))

            Catch ex As Exception
                JobNumber = 0
                JobComponentNumber = 0
            End Try

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub JobForecast_AddJobComponents_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            _JobForecastRevisionID = CType(Request.QueryString("JobForecastRevisionID"), Integer)

        Catch ex As Exception
            _JobForecastRevisionID = 0
        End Try

    End Sub
    Private Sub JobForecast_AddJobComponents_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim JobForecastRevisionID As Integer = 0
        Dim CurrentJobComponentsList As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
        Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing
        Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Try

                If Request.QueryString("JobForecastRevisionID") IsNot Nothing Then

                    JobForecastRevisionID = CType(Request.QueryString("JobForecastRevisionID"), Integer)

                End If

            Catch ex As Exception
                JobForecastRevisionID = 0
            End Try

            If Me.JobForecastRevision IsNot Nothing Then

                LoadOffices()
                LoadClients()
                LoadEmployees()

                Try

                    CurrentJobComponentsList = (From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadAllOpen(Me.DbContext).ToList
                                                Join JobForecastJob In Me.JobForecastRevision.JobForecastJobs On Item.JobNumber Equals JobForecastJob.JobNumber And Item.JobComponentNumber Equals JobForecastJob.JobComponentNumber
                                                Select Item).ToList

                Catch ex As Exception
                    CurrentJobComponentsList = New Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)
                End Try

                RadListBoxCurrentJobComponents.DataSource = FormatJobComponentListForListBox(CurrentJobComponentsList)
                RadListBoxCurrentJobComponents.DataBind()

                If AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(_DbContext, Me.JobForecastRevision.JobForecastID).Count() > 1 Then

                    Me.HasMultipleRevisions = True

                End If

                LabelAddRemoveJobsNote.Visible = Me.HasMultipleRevisions

            End If

        End If

    End Sub
    Private Sub JobForecast_AddJobComponents_Unload(sender As Object, e As EventArgs) Handles Me.Unload

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

    Private Sub DropDownListOffice_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles DropDownListOffice.SelectedIndexChanged

        LoadClients()

    End Sub
    Private Sub DropDownListClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListClient.SelectedIndexChanged

        LoadDivisions()

    End Sub
    Private Sub DropDownListDivision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDivision.SelectedIndexChanged

        LoadProducts()

    End Sub
    Private Sub DropDownListProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListProduct.SelectedIndexChanged

        LoadAvailableJobComponents()

    End Sub
    Private Sub DropDownListAccountExecutive_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles DropDownListAccountExecutive.SelectedIndexChanged

        LoadAvailableJobComponents()

    End Sub
    Private Sub RadToolBarJobForecastJobComponent_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobForecastJobComponent.ButtonClick

        Select Case e.Item.Value

            Case "Done"

                Me.CloseThisWindow()

        End Select

    End Sub
    Private Sub RadListBoxCurrentJobComponents_Deleted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCurrentJobComponents.Deleted

        'objects
        Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
        Dim JobNumber As Integer = Nothing
        Dim JobComponentNumber As Short = Nothing

        If Me.JobForecastRevision IsNot Nothing Then

            For Each RadListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                JobForecastJob = Nothing

                Try

                    GetJobComponentAttributesFromRadListBoxItem(RadListBoxItem, JobNumber, JobComponentNumber)

                    JobForecastJob = (From Entity In _DbContext.JobForecastJobs
                                      Where Entity.JobNumber = JobNumber AndAlso
                                            Entity.JobComponentNumber = JobComponentNumber AndAlso
                                            Entity.JobForecastRevisionID = Me.JobForecastRevision.ID
                                      Select Entity).FirstOrDefault

                Catch ex As Exception
                    JobForecastJob = Nothing
                Finally

                    If JobForecastJob IsNot Nothing Then

                        If AdvantageFramework.JobForecast.DeleteJobForecastJobFromForecast(_DbContext, JobForecastJob) Then

                            LoadAvailableJobComponents()

                        End If

                    End If

                End Try

            Next

        End If

    End Sub
    Private Sub RadListBoxCurrentJobComponents_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCurrentJobComponents.Inserted

        'objects
        Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
        Dim CurrentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim JobComponentList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
        Dim JobNumber As Integer = Nothing
        Dim JobComponentNumber As Short = Nothing

        If Me.JobForecastRevision IsNot Nothing Then

            For Each RadListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                JobForecastJob = Nothing

                Try

                    GetJobComponentAttributesFromRadListBoxItem(RadListBoxItem, JobNumber, JobComponentNumber)

                    JobForecastJob = (From Entity In _DbContext.JobForecastJobs
                                      Where Entity.JobNumber = JobNumber AndAlso
                                            Entity.JobComponentNumber = JobComponentNumber AndAlso
                                            Entity.JobForecastRevisionID = Me.JobForecastRevision.ID
                                      Select Entity).FirstOrDefault

                Catch ex As Exception
                    JobForecastJob = Nothing
                Finally

                    If JobForecastJob IsNot Nothing Then

                        'AdvantageFramework.EmployeeTimeForecast.SyncJobComponentOnEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponent)

                    Else

                        Try

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(Me.DbContext, JobNumber, JobComponentNumber)

                        Catch ex As Exception
                            JobComponent = Nothing
                        End Try

                        If JobComponent IsNot Nothing Then

                            AdvantageFramework.JobForecast.InsertNewJobForecastJob(_DbContext, Me.JobForecastRevision, JobComponent)

                        End If

                    End If

                End Try

            Next

            Me.JobForecastRevision.ModifiedDate = Now
            Me.JobForecastRevision.ModifiedByUserCode = _DbContext.UserCode

            AdvantageFramework.Database.Procedures.JobForecastRevision.Update(_DbContext, Me.JobForecastRevision)

        End If

    End Sub
    Private Sub RadListBoxAvailableJobComponents_ItemDataBound(sender As Object, e As Telerik.Web.UI.RadListBoxItemEventArgs) Handles RadListBoxAvailableJobComponents.ItemDataBound

        AddJobComponentAttributeToRadListBoxItem(e.Item)

    End Sub
    Private Sub RadListBoxCurrentJobComponents_ItemDataBound(sender As Object, e As Telerik.Web.UI.RadListBoxItemEventArgs) Handles RadListBoxCurrentJobComponents.ItemDataBound

        AddJobComponentAttributeToRadListBoxItem(e.Item)

    End Sub

#End Region

#End Region

End Class