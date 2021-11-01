Public Class EmployeeTimeForecast_AddJobComponents
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext)

        'objects
        Dim EmployeeTimeForecastOfficeDetailID As Integer = 0

        If _EmployeeTimeForecastOfficeDetail Is Nothing Then

            If DbContext IsNot Nothing Then

                Try

                    If Request.QueryString("EmployeeTimeForecastOfficeDetailID") IsNot Nothing Then

                        EmployeeTimeForecastOfficeDetailID = CType(Request.QueryString("EmployeeTimeForecastOfficeDetailID"), Integer)

                    End If

                Catch ex As Exception
                    EmployeeTimeForecastOfficeDetailID = 0
                End Try

                Try

                    _EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecastOfficeDetailJobComponents").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailJobComponents.JobComponent").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailJobComponents.JobComponent.Job")
                                                         Where Entity.ID = EmployeeTimeForecastOfficeDetailID
                                                         Select Entity).Single

                Catch ex As Exception
                    _EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End If

        End If

    End Sub
    Private Sub LoadAvailableJobComponents()

        'objects
        Dim AvailableJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadEmployeeTimeForecastOfficeDetail(DbContext)

                If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    AvailableJobComponentsList = AdvantageFramework.EmployeeTimeForecast.LoadAvailableJobComponentsOnEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, DropDownListClient.SelectedValue,
                                                                                                                                                      DropDownListDivision.SelectedValue, DropDownListProduct.SelectedValue,
                                                                                                                                                      CheckBoxShowJobsForAllOffices.Checked, SecurityDbContext, _Session)

                    If AvailableJobComponentsList IsNot Nothing Then

                        RadListBoxAvailableJobComponents.DataSource = From JobComponent In AvailableJobComponentsList
                                                                      Select [ID] = JobComponent.ID,
                                                                             [Description] = JobComponent.Job.Client.ToString & " | " & JobComponent.ToString(True, True)
                        RadListBoxAvailableJobComponents.DataBind()

                    Else

                        RadListBoxAvailableJobComponents.Items.Clear()
                        RadListBoxAvailableJobComponents.DataSource = Nothing
                        RadListBoxAvailableJobComponents.DataBind()

                    End If

                End If

            End Using

        End Using

    End Sub
    Private Sub LoadClients()

        'objects
        Dim ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
        Dim OfficeClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing

        If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _Session.HasLimitedOfficeCodes Then

                        ClientList = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Where(Function(Client) Client.IsActive = 1).ToList

                    Else

                        ClientList = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList

                    End If

                    OfficeClientList = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

                    For Each Client In ClientList

                        If OfficeClientList.Any(Function(Entity) Entity.Code = Client.Code) = False Then

                            OfficeClientList.Add(Client)

                        End If

                    Next

                    DropDownListClient.DataSource = OfficeClientList.OrderBy(Function(Client) Client.Name).ToList
                    DropDownListClient.DataBind()
                    DropDownListClient.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                End Using

            End Using

        Else

            DropDownListClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
            DropDownListClient.DataBind()
            DropDownListClient.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End If

        DropDownListDivision.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
        DropDownListDivision.DataBind()
        DropDownListDivision.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        DropDownListProduct.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
        DropDownListProduct.DataBind()
        DropDownListProduct.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        LoadAvailableJobComponents()

    End Sub
    Private Sub LoadDivisions()

        'objects
        Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing

        If DropDownListClient.SelectedValue IsNot Nothing AndAlso DropDownListClient.SelectedValue <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _Session.HasLimitedOfficeCodes Then

                        DivisionList = AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Where(Function(Division) Division.ClientCode = DropDownListClient.SelectedValue AndAlso Division.IsActive = 1).OrderBy(Function(Division) Division.Name).ToList

                    Else

                        DivisionList = AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext).Where(Function(Division) Division.ClientCode = DropDownListClient.SelectedValue).OrderBy(Function(Division) Division.Name).ToList

                    End If

                    DropDownListDivision.DataSource = DivisionList
                    DropDownListDivision.DataBind()
                    DropDownListDivision.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                End Using

            End Using

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

        'objects
        Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

        If DropDownListClient.SelectedValue IsNot Nothing AndAlso DropDownListClient.SelectedValue <> "" AndAlso
                DropDownListDivision.SelectedValue IsNot Nothing AndAlso DropDownListDivision.SelectedValue <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _Session.HasLimitedOfficeCodes Then

                        ProductList = AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList.Where(Function(Product) DropDownListClient.SelectedValue = Product.ClientCode AndAlso
                                                                                                                                             DropDownListDivision.SelectedValue = Product.DivisionCode AndAlso Product.IsActive = 1).OrderBy(Function(Product) Product.Name).ToList

                    Else

                        ProductList = AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext).ToList.Where(Function(Product) DropDownListClient.SelectedValue = Product.ClientCode AndAlso
                                                                                                                                             DropDownListDivision.SelectedValue = Product.DivisionCode).OrderBy(Function(Product) Product.Name).ToList

                    End If



                    DropDownListProduct.DataSource = ProductList
                    DropDownListProduct.DataBind()
                    DropDownListProduct.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                End Using

            End Using

        Else

            DropDownListProduct.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
            DropDownListProduct.DataBind()
            DropDownListProduct.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End If

        LoadAvailableJobComponents()

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_AddJobComponents_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim EmployeeTimeForecastOfficeDetailID As Integer = 0
        Dim CurrentJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
        Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing
        Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Try

                If Request.QueryString("EmployeeTimeForecastOfficeDetailID") IsNot Nothing Then

                    EmployeeTimeForecastOfficeDetailID = CType(Request.QueryString("EmployeeTimeForecastOfficeDetailID"), Integer)

                End If

            Catch ex As Exception
                EmployeeTimeForecastOfficeDetailID = 0
            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadEmployeeTimeForecastOfficeDetail(DbContext)

                If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    LoadClients()

                    CurrentJobComponentsList = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.Select(Function(EmployeeTimeForecastOfficeDetailJobComponent) EmployeeTimeForecastOfficeDetailJobComponent.JobComponent).ToList

                    RadListBoxCurrentJobComponents.DataSource = From JobComponent In CurrentJobComponentsList.OrderBy(Function(Entity) Entity.JobNumber).ThenBy(Function(Entity) Entity.Number)
                                                                Select [ID] = JobComponent.ID,
                                                                       [Description] = JobComponent.Job.Client.ToString & " | " & JobComponent.ToString(True, True)
                    RadListBoxCurrentJobComponents.DataBind()

                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub DropDownListClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListClient.SelectedIndexChanged

        LoadDivisions()

    End Sub
    Private Sub DropDownListDivision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDivision.SelectedIndexChanged

        LoadProducts()

    End Sub
    Private Sub DropDownListProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListProduct.SelectedIndexChanged

        LoadAvailableJobComponents()

    End Sub
    Private Sub RadToolBarEmployeeTimeForecastJobComponent_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecastJobComponent.ButtonClick

        Select Case e.Item.Value

            Case "Done"

                Me.CloseThisWindow()

        End Select

    End Sub
    Private Sub RadListBoxCurrentJobComponents_Deleted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCurrentJobComponents.Deleted

        'objects
        Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            LoadEmployeeTimeForecastOfficeDetail(DbContext)

            If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                For Each RadListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                    Try

                        EmployeeTimeForecastOfficeDetailJobComponent = (From Entity In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents
                                                                        Where Entity.JobComponent.ID = RadListBoxItem.Value
                                                                        Select Entity).First

                    Catch ex As Exception
                        EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                    Finally

                        AdvantageFramework.EmployeeTimeForecast.DeleteJobComponentFromEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponent)

                    End Try

                Next

                _EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, _EmployeeTimeForecastOfficeDetail)

            End If

        End Using

    End Sub
    Private Sub RadListBoxCurrentJobComponents_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCurrentJobComponents.Inserted

        'objects
        Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
        Dim CurrentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing
        Dim JobComponentList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
        Dim UseJobComponentBudgetAmountForDefaultRevenue As Boolean = False

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            LoadEmployeeTimeForecastOfficeDetail(DbContext)

            If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    UseJobComponentBudgetAmountForDefaultRevenue = AdvantageFramework.EmployeeTimeForecast.LoadUseJobComponentBudgetAmountForDefaultRevenueSetting(DataContext)

                End Using

                OfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Session("empcode").ToString()).Include("Office").Select(Function(EmployeeOffice) EmployeeOffice.Office).ToList

                For Each RadListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                    Try

                        EmployeeTimeForecastOfficeDetailJobComponent = (From Entity In _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents
                                                                        Where Entity.JobComponent.ID = RadListBoxItem.Value
                                                                        Select Entity).First

                    Catch ex As Exception
                        EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                    Finally

                        If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                            AdvantageFramework.EmployeeTimeForecast.SyncJobComponentOnEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponent)

                        Else

                            Try

                                JobComponent = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext).Include("Job").Include("EstimateApproval.EstimateRevision").Include("EstimateApproval.EstimateRevision.EstimateRevisionDetails").Include("EstimateApproval.EstimateRevision.EstimateRevisionDetails.Function")
                                                Where Entity.ID = RadListBoxItem.Value
                                                Select Entity).First

                            Catch ex As Exception
                                JobComponent = Nothing
                            End Try

                            If JobComponent IsNot Nothing Then

                                If OfficeList.Count > 0 Then

                                    If OfficeList.Any(Function(Office) Office.Code = JobComponent.Job.OfficeCode) Then

                                        AdvantageFramework.EmployeeTimeForecast.InsertJobComponentInEmployeeTimeForecastOfficeDetail(DbContext, Session("ConnString").ToString(), _EmployeeTimeForecastOfficeDetail, JobComponent, True, 0, UseJobComponentBudgetAmountForDefaultRevenue)

                                    End If

                                Else

                                    AdvantageFramework.EmployeeTimeForecast.InsertJobComponentInEmployeeTimeForecastOfficeDetail(DbContext, Session("ConnString").ToString(), _EmployeeTimeForecastOfficeDetail, JobComponent, True, 0, UseJobComponentBudgetAmountForDefaultRevenue)

                                End If

                            End If

                        End If

                    End Try

                Next

                _EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, _EmployeeTimeForecastOfficeDetail)

            End If

        End Using

    End Sub
    Private Sub CheckBoxShowJobsForAllOffices_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowJobsForAllOffices.CheckedChanged

        LoadAvailableJobComponents()

    End Sub

#End Region

#End Region

End Class
