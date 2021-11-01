Namespace FinanceAndAccounting.Presentation

    Public Class EmployeeTimeForecastJobComponentsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeTimeForecastOfficeDetailID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeTimeForecastOfficeDetailID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID

        End Sub
        Private Function LoadEmployeeTimeForecastOfficeDetail() As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecastOfficeDetailJobComponents").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailJobComponents.JobComponent").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailJobComponents.JobComponent.Job").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailJobComponents.JobComponent.Job.Office").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailJobComponents.JobComponent.Job.Client").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailJobComponents.JobComponent.Job.Division").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailJobComponents.JobComponent.Job.Product")
                                                        Where Entity.ID = _EmployeeTimeForecastOfficeDetailID
                                                        Select Entity).SingleOrDefault

                Catch ex As Exception
                    EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End Using

            LoadEmployeeTimeForecastOfficeDetail = EmployeeTimeForecastOfficeDetail

        End Function
        Private Sub LoadCurrentJobComponents(Optional ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing)

            'objects
            Dim CurrentJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing

            If EmployeeTimeForecastOfficeDetail Is Nothing Then

                EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    CurrentJobComponentsList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.Select(Function(EmployeeTimeForecastOfficeDetailJobComponent) EmployeeTimeForecastOfficeDetailJobComponent.JobComponent).ToList

                    DataGridViewForm_CurrentJobComponents.DataSource = CurrentJobComponentsList.OrderBy(Function(Entity) Entity.JobNumber).ThenBy(Function(Entity) Entity.Number).ToList

                End If

            End Using

            DataGridViewForm_CurrentJobComponents.CurrentView.BestFitColumns()

            ModifyJobComponentsGrid(DataGridViewForm_CurrentJobComponents)

        End Sub
        Private Sub LoadAvailableJobComponents(Optional ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing)

            'objects
            Dim AvailableJobComponentsList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing

            If EmployeeTimeForecastOfficeDetail Is Nothing Then

                EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        AvailableJobComponentsList = AdvantageFramework.EmployeeTimeForecast.LoadAvailableJobComponentsOnEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, ComboBoxForm_Client.GetSelectedValue, ComboBoxForm_Division.GetSelectedValue,
                                                                                                                                                          ComboBoxForm_Product.GetSelectedValue, CheckBoxForm_ShowJobsForAllOffices.Checked, SecurityDbContext, Session)

                        If AvailableJobComponentsList IsNot Nothing Then

                            DataGridViewForm_AvailableJobComponents.DataSource = AvailableJobComponentsList

                        Else

                            DataGridViewForm_AvailableJobComponents.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)

                        End If

                    End If

                End Using

            End Using

            DataGridViewForm_AvailableJobComponents.CurrentView.BestFitColumns()

            ModifyJobComponentsGrid(DataGridViewForm_AvailableJobComponents)

        End Sub
        Private Sub LoadDivisions()

            Dim ClientCode As String = Nothing

            If ComboBoxForm_Client.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_Division.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext)
                                                       Where Division.ClientCode = ClientCode
                                                       Select Division

                End Using

            Else

                ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)

            End If

            ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

            LoadAvailableJobComponents()

        End Sub
        Private Sub LoadProducts()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If ComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Division.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue
                DivisionCode = ComboBoxForm_Division.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_Product.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext).ToList
                                                       Where Product.ClientCode = ClientCode AndAlso
                                                             Product.DivisionCode = DivisionCode
                                                       Select Product).ToList

                End Using

            Else

                ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

            End If

            LoadAvailableJobComponents()

        End Sub
        Private Sub AddJobComponentsToEmployeeTimeForecast(ByVal SelectedJobComponentIDs As IEnumerable(Of Integer))

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
            Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing
            Dim UseJobComponentBudgetAmountForDefaultRevenue As Boolean = False
            Dim JobComponentID As Integer = 0
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If SelectedJobComponentIDs IsNot Nothing Then

                Me.ShowWaitForm()
                Me.ShowWaitForm("Adding Job Component(s) to Employee Time Forecast...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        Try

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                UseJobComponentBudgetAmountForDefaultRevenue = AdvantageFramework.EmployeeTimeForecast.LoadUseJobComponentBudgetAmountForDefaultRevenueSetting(DataContext)

                            End Using

                        Catch ex As Exception
                            UseJobComponentBudgetAmountForDefaultRevenue = False
                        End Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            OfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode).Include("Office").Select(Function(EmployeeOffice) EmployeeOffice.Office).ToList

                            For Each JobComponentID In SelectedJobComponentIDs

                                Try

                                    EmployeeTimeForecastOfficeDetailJobComponent = (From Entity In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents
                                                                                    Where Entity.JobComponent.ID = JobComponentID
                                                                                    Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                End Try

                                If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                    AdvantageFramework.EmployeeTimeForecast.SyncJobComponentOnEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponent)

                                Else

                                    Try

										JobComponent = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext).Include("Job").Include("EstimateApproval.EstimateRevision").Include("EstimateApproval.EstimateRevision.EstimateRevisionDetails").Include("EstimateApproval.EstimateRevision.EstimateRevisionDetails.Function")
														Where Entity.ID = JobComponentID
														Select Entity).FirstOrDefault

									Catch ex As Exception
                                        JobComponent = Nothing
                                    End Try

                                    If JobComponent IsNot Nothing Then

                                        If OfficeList.Count > 0 Then

                                            If OfficeList.Any(Function(Office) Office.Code = JobComponent.Job.OfficeCode) Then

                                                AdvantageFramework.EmployeeTimeForecast.InsertJobComponentInEmployeeTimeForecastOfficeDetail(DbContext, Me.Session.ConnectionString, EmployeeTimeForecastOfficeDetail, JobComponent, True, 0, UseJobComponentBudgetAmountForDefaultRevenue)

                                            End If

                                        Else

                                            AdvantageFramework.EmployeeTimeForecast.InsertJobComponentInEmployeeTimeForecastOfficeDetail(DbContext, Me.Session.ConnectionString, EmployeeTimeForecastOfficeDetail, JobComponent, True, 0, UseJobComponentBudgetAmountForDefaultRevenue)

                                        End If

                                    End If

                                End If

                            Next

                            EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                            EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, EmployeeTimeForecastOfficeDetail)

                        End Using

                    End If

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
                Me.ShowWaitForm("Loading...")

                Try

                    LoadCurrentJobComponents()

                Catch ex As Exception

                End Try

                Try

                    LoadAvailableJobComponents()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ModifyJobComponentsGrid(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            DataGridView.HideOrShowColumn("OfficeCode", False)
            DataGridView.HideOrShowColumn("OfficeName", False)
            DataGridView.HideOrShowColumn("JobNumber", True, 0)
            DataGridView.HideOrShowColumn("Number", True, 1)
            DataGridView.HideOrShowColumn("Description", True, 2)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimeForecastJobComponentsDialog As AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastJobComponentsDialog = Nothing

            EmployeeTimeForecastJobComponentsDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastJobComponentsDialog(EmployeeTimeForecastOfficeDetailID)

            ShowFormDialog = EmployeeTimeForecastJobComponentsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastJobComponentsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim OfficeClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            DataGridViewForm_AvailableJobComponents.OptionsView.ShowFooter = False
            DataGridViewForm_CurrentJobComponents.OptionsView.ShowFooter = False

            EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).OrderBy(Function(Entity) Entity.Name).ToList

                    End Using

                End Using

                LoadCurrentJobComponents(EmployeeTimeForecastOfficeDetail)

                LoadAvailableJobComponents(EmployeeTimeForecastOfficeDetail)

            Else

                ComboBoxForm_Client.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

                AdvantageFramework.WinForm.MessageBox.Show("Employee Time Forecast you are trying to access is not valid.")
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

            ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
            ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

            ButtonForm_AddAllJobComponents.Enabled = DataGridViewForm_AvailableJobComponents.HasRows
            ButtonForm_AddJobComponent.Enabled = DataGridViewForm_AvailableJobComponents.HasASelectedRow

            ButtonForm_RemoveJobComponent.Enabled = DataGridViewForm_CurrentJobComponents.HasASelectedRow

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_Client_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Client.SelectedValueChanged

            If Me.FormShown Then

                LoadDivisions()

            End If

        End Sub
        Private Sub ComboBoxForm_Division_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Division.SelectedValueChanged

            If Me.FormShown Then

                LoadProducts()

            End If

        End Sub
        Private Sub ComboBoxForm_Product_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Product.SelectedValueChanged

            If Me.FormShown Then

                If ComboBoxForm_Product.HasASelectedValue Then

                    LoadAvailableJobComponents()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_AvailableJobComponents_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_AvailableJobComponents.SelectionChangedEvent

            ButtonForm_AddAllJobComponents.Enabled = DataGridViewForm_AvailableJobComponents.HasRows
            ButtonForm_AddJobComponent.Enabled = DataGridViewForm_AvailableJobComponents.HasASelectedRow

        End Sub
        Private Sub DataGridViewForm_CurrentJobComponents_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_CurrentJobComponents.SelectionChangedEvent

            ButtonForm_RemoveJobComponent.Enabled = DataGridViewForm_CurrentJobComponents.HasASelectedRow

        End Sub
        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_AddAllJobComponents_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_AddAllJobComponents.Click

            'objects
            Dim SelectedJobComponentIDs As IEnumerable(Of Integer) = Nothing

            If DataGridViewForm_AvailableJobComponents.HasRows Then

                SelectedJobComponentIDs = DataGridViewForm_AvailableJobComponents.GetAllRowsBookmarkValues.OfType(Of Integer)()

                AddJobComponentsToEmployeeTimeForecast(SelectedJobComponentIDs)

            End If

        End Sub
        Private Sub ButtonForm_AddJobComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_AddJobComponent.Click

            'objects
            Dim SelectedJobComponentIDs As IEnumerable(Of Integer) = Nothing

            If DataGridViewForm_AvailableJobComponents.HasASelectedRow Then

                SelectedJobComponentIDs = DataGridViewForm_AvailableJobComponents.GetAllSelectedRowsBookmarkValues.OfType(Of Integer)()

                AddJobComponentsToEmployeeTimeForecast(SelectedJobComponentIDs)

            End If

        End Sub
        Private Sub ButtonForm_RemoveJobComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_RemoveJobComponent.Click

            'objects
            Dim SelectedJobComponentIDs As IEnumerable(Of Integer) = Nothing
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
            Dim JobComponentID As Integer = 0
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If DataGridViewForm_CurrentJobComponents.HasASelectedRow Then

                SelectedJobComponentIDs = DataGridViewForm_CurrentJobComponents.GetAllSelectedRowsBookmarkValues.OfType(Of Integer)()

                Me.ShowWaitForm()
                Me.ShowWaitForm("Removing Job Component(s) from Employee Time Forecast...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each JobComponentID In SelectedJobComponentIDs

                                Try

                                    EmployeeTimeForecastOfficeDetailJobComponent = (From Entity In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents
                                                                                    Where Entity.JobComponent.ID = JobComponentID
                                                                                    Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                End Try

                                If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                    AdvantageFramework.EmployeeTimeForecast.DeleteJobComponentFromEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponent)

                                End If

                            Next

                            EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                            EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, EmployeeTimeForecastOfficeDetail)

                        End Using

                    End If

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
                Me.ShowWaitForm("Loading...")

                Try

                    LoadCurrentJobComponents()

                Catch ex As Exception

                End Try

                Try

                    LoadAvailableJobComponents()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub CheckBoxForm_ShowJobsForAllOffices_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_ShowJobsForAllOffices.CheckedChanged

            If Me.FormShown Then

                LoadAvailableJobComponents()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace