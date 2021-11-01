Namespace FinanceAndAccounting.Presentation

    Public Class EmployeeTimeForecastIndirectCategoriesDialog

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

                    EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecastOfficeDetailIndirectCategories").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailIndirectCategories.IndirectCategory")
                                                        Where Entity.ID = _EmployeeTimeForecastOfficeDetailID
                                                        Select Entity).SingleOrDefault

                Catch ex As Exception
                    EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End Using

            LoadEmployeeTimeForecastOfficeDetail = EmployeeTimeForecastOfficeDetail

        End Function
        Private Sub LoadAvailableIndirectCategories(Optional ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing)

            'objects
            Dim AvailableIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory) = Nothing

            If EmployeeTimeForecastOfficeDetail Is Nothing Then

                EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    AvailableIndirectCategoriesList = AdvantageFramework.EmployeeTimeForecast.LoadAvailableIndirectCategoriesOnEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail)

                End If

            End Using

            If AvailableIndirectCategoriesList IsNot Nothing Then

                DataGridViewForm_AvailableIndirectCategories.DataSource = AvailableIndirectCategoriesList

            Else

                DataGridViewForm_AvailableIndirectCategories.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory)

            End If

            DataGridViewForm_AvailableIndirectCategories.CurrentView.BestFitColumns()

            If DataGridViewForm_AvailableIndirectCategories.Columns("IsInactive") IsNot Nothing Then

                If DataGridViewForm_AvailableIndirectCategories.Columns("IsInactive").Visible Then

                    DataGridViewForm_AvailableIndirectCategories.Columns("IsInactive").Visible = False

                End If

            End If

        End Sub
        Private Sub LoadCurrentIndirectCategories(Optional ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing)

            'objects
            Dim CurrentIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory) = Nothing

            If EmployeeTimeForecastOfficeDetail Is Nothing Then

                EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            End If

            If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                CurrentIndirectCategoriesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.Select(Function(EmployeeTimeForecastOfficeDetailIndirectCategory) EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategory).ToList

            End If

            If CurrentIndirectCategoriesList IsNot Nothing Then

                DataGridViewForm_CurrentIndirectCategories.DataSource = CurrentIndirectCategoriesList

            Else

                DataGridViewForm_CurrentIndirectCategories.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory)

            End If

            DataGridViewForm_CurrentIndirectCategories.CurrentView.BestFitColumns()

            If DataGridViewForm_CurrentIndirectCategories.Columns("IsInactive") IsNot Nothing Then

                If DataGridViewForm_CurrentIndirectCategories.Columns("IsInactive").Visible Then

                    DataGridViewForm_CurrentIndirectCategories.Columns("IsInactive").Visible = False

                End If

            End If

        End Sub
        Private Sub AddIndirectCategoriesToEmployeeTimeForecast(ByVal SelectedIndirectCategoryCodes As IEnumerable(Of String))

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim CurrentIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) = Nothing
            Dim IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing
            Dim IndirectCategoryCode As String = ""

            If SelectedIndirectCategoryCodes IsNot Nothing Then

                Me.ShowWaitForm()
                Me.ShowWaitForm("Adding Indirect Category(ies) to Employee Time Forecast...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        CurrentIndirectCategoriesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.ToList

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each IndirectCategoryCode In SelectedIndirectCategoryCodes

                                Try

                                    IndirectCategory = AdvantageFramework.Database.Procedures.IndirectCategory.LoadByIndirectCategoryCode(DbContext, IndirectCategoryCode)


                                Catch ex As Exception
                                    IndirectCategory = Nothing
                                End Try

                                If IndirectCategory IsNot Nothing AndAlso CurrentIndirectCategoriesList.Any(Function(Entity) Entity.IndirectCategoryCode = IndirectCategory.Code) = False Then

                                    AdvantageFramework.EmployeeTimeForecast.InsertIndirectCategoryInEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, IndirectCategory)

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

                    LoadCurrentIndirectCategories()

                Catch ex As Exception

                End Try

                Try

                    LoadAvailableIndirectCategories()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RemoveIndirectCategoriesToEmployeeTimeForecast(ByVal SelectedIndirectCategoryCodes As IEnumerable(Of String))

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing
            Dim CurrentIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) = Nothing
            Dim IndirectCategoryCode As String = ""

            If SelectedIndirectCategoryCodes IsNot Nothing Then

                Me.ShowWaitForm()
                Me.ShowWaitForm("Removing Indirect Category(ies) from Employee Time Forecast...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        CurrentIndirectCategoriesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.ToList

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each IndirectCategoryCode In SelectedIndirectCategoryCodes

                                Try

                                    EmployeeTimeForecastOfficeDetailIndirectCategory = (From Entity In CurrentIndirectCategoriesList
                                                                                        Where Entity.IndirectCategoryCode = IndirectCategoryCode
                                                                                        Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing
                                End Try

                                If EmployeeTimeForecastOfficeDetailIndirectCategory IsNot Nothing Then

                                    AdvantageFramework.EmployeeTimeForecast.DeleteIndirectCategoryInEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailIndirectCategory)

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

                    LoadCurrentIndirectCategories()

                Catch ex As Exception

                End Try

                Try

                    LoadAvailableIndirectCategories()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimeForecastIndirectCategoriesDialog As AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastIndirectCategoriesDialog = Nothing

            EmployeeTimeForecastIndirectCategoriesDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastIndirectCategoriesDialog(EmployeeTimeForecastOfficeDetailID)

            ShowFormDialog = EmployeeTimeForecastIndirectCategoriesDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastIndirectCategoriesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            DataGridViewForm_AvailableIndirectCategories.OptionsView.ShowFooter = False
            DataGridViewForm_CurrentIndirectCategories.OptionsView.ShowFooter = False

            EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                LoadAvailableIndirectCategories(EmployeeTimeForecastOfficeDetail)
                LoadCurrentIndirectCategories(EmployeeTimeForecastOfficeDetail)

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Employee Time Forecast you are trying to access is not valid.")
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

            ButtonForm_AddIndirectCategories.Enabled = DataGridViewForm_AvailableIndirectCategories.HasASelectedRow
            ButtonForm_AddAllIndirectCategories.Enabled = DataGridViewForm_AvailableIndirectCategories.HasRows

            ButtonForm_RemoveIndirectCategories.Enabled = DataGridViewForm_CurrentIndirectCategories.HasASelectedRow
            ButtonForm_RemoveAllIndirectCategories.Enabled = DataGridViewForm_CurrentIndirectCategories.HasRows

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_AvailableIndirectCategories_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_AvailableIndirectCategories.SelectionChangedEvent

            ButtonForm_AddIndirectCategories.Enabled = DataGridViewForm_AvailableIndirectCategories.HasASelectedRow
            ButtonForm_AddAllIndirectCategories.Enabled = DataGridViewForm_AvailableIndirectCategories.HasRows

        End Sub
        Private Sub DataGridViewForm_CurrentIndirectCategories_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_CurrentIndirectCategories.SelectionChangedEvent

            ButtonForm_RemoveIndirectCategories.Enabled = DataGridViewForm_CurrentIndirectCategories.HasASelectedRow
            ButtonForm_RemoveAllIndirectCategories.Enabled = DataGridViewForm_CurrentIndirectCategories.HasRows

        End Sub
        Private Sub ButtonForm_AddAllIndirectCategories_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_AddAllIndirectCategories.Click

            'objects
            Dim SelectedIndirectCategoryCodes As IEnumerable(Of String) = Nothing

            If DataGridViewForm_AvailableIndirectCategories.HasRows Then

                SelectedIndirectCategoryCodes = DataGridViewForm_AvailableIndirectCategories.GetAllRowsBookmarkValues.OfType(Of String)()

                AddIndirectCategoriesToEmployeeTimeForecast(SelectedIndirectCategoryCodes)

            End If

        End Sub
        Private Sub ButtonForm_AddIndirectCategories_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_AddIndirectCategories.Click

            'objects
            Dim SelectedIndirectCategoryCodes As IEnumerable(Of String) = Nothing

            If DataGridViewForm_AvailableIndirectCategories.HasASelectedRow Then

                SelectedIndirectCategoryCodes = DataGridViewForm_AvailableIndirectCategories.GetAllSelectedRowsBookmarkValues.OfType(Of String)()

                AddIndirectCategoriesToEmployeeTimeForecast(SelectedIndirectCategoryCodes)

            End If

        End Sub
        Private Sub ButtonForm_RemoveAllIndirectCategories_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_RemoveAllIndirectCategories.Click

            'objects
            Dim SelectedIndirectCategoryCodes As IEnumerable(Of String) = Nothing

            If DataGridViewForm_CurrentIndirectCategories.HasRows Then

                SelectedIndirectCategoryCodes = DataGridViewForm_CurrentIndirectCategories.GetAllRowsBookmarkValues.OfType(Of String)()

                RemoveIndirectCategoriesToEmployeeTimeForecast(SelectedIndirectCategoryCodes)

            End If

        End Sub
        Private Sub ButtonForm_RemoveIndirectCategories_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_RemoveIndirectCategories.Click

            'objects
            Dim SelectedIndirectCategoryCodes As IEnumerable(Of String) = Nothing

            If DataGridViewForm_CurrentIndirectCategories.HasASelectedRow Then

                SelectedIndirectCategoryCodes = DataGridViewForm_CurrentIndirectCategories.GetAllSelectedRowsBookmarkValues.OfType(Of String)()

                RemoveIndirectCategoriesToEmployeeTimeForecast(SelectedIndirectCategoryCodes)

            End If

        End Sub
        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace