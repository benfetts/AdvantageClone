Namespace Maintenance.Client.Presentation

    Public Class AccountExecutiveSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _AccountExecutiveList As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            DataGridViewRightSection_AccountExecutives.ByPassUserEntryChanged = True

        End Sub
        Private Sub LoadProducts()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					DataGridViewLeftSection_Products.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, False)
																   Where Entity.Client.IsActive = 1 AndAlso
																		 Entity.Division.IsActive = 1
																   Select Entity).ToList

					DataGridViewLeftSection_Products.CurrentView.BestFitColumns()

                    If DataGridViewRightSection_AccountExecutives.Columns("AccountExecutive") IsNot Nothing Then

                        If DataGridViewRightSection_AccountExecutives.Columns("AccountExecutive").Visible Then

                            DataGridViewRightSection_AccountExecutives.Columns("AccountExecutive").Visible = False

                        End If

                    End If

                End Using

            End Using

        End Sub
        Private Sub LoadEmployeesAndAccountExecutives()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim FinalEmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim AddEmployee As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If DataGridViewLeftSection_Products.HasOnlyOneSelectedRow Then

                    ClientCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.ClientCode.ToString)
                    DivisionCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.DivisionCode.ToString)
                    ProductCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.Code.ToString)

                    EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserOffice(DbContext, Me.Session.User.EmployeeCode).ToList

                    _AccountExecutiveList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode).Include("Employee").Include("Product").Include("Product.Client").Include("Product.Division").ToList

                    FinalEmployeeList = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                    For Each Employee In EmployeeList

                        AddEmployee = True

                        For Each AccountExecutive In _AccountExecutiveList

                            If _AccountExecutiveList.Any(Function(AccExe) AccExe.EmployeeCode = Employee.Code) = True Then

                                AddEmployee = False

                                Exit For

                            End If

                        Next

                        If AddEmployee Then

                            FinalEmployeeList.Add(Employee)

                        End If

                    Next

                    ButtonRightSection_AddAccountExecutive.Enabled = True
                    ButtonRightSection_RemoveAccountExecutive.Enabled = True

                Else

                    FinalEmployeeList = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
                    _AccountExecutiveList = New Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive)

                End If

                DataGridViewRightSection_Export.DataSource = _AccountExecutiveList
                DataGridViewRightSection_AccountExecutives.DataSource = _AccountExecutiveList.Select(Function(AcctExec) New AdvantageFramework.Database.Classes.AccountExecutive(AcctExec)).ToList
                DataGridViewMiddleSection_Employees.DataSource = FinalEmployeeList.Where(Function(Entity) Entity.TerminationDate Is Nothing)

                DataGridViewRightSection_Export.CurrentView.BestFitColumns()
                DataGridViewMiddleSection_Employees.CurrentView.BestFitColumns()
                DataGridViewRightSection_AccountExecutives.CurrentView.BestFitColumns()

                EnableOrDisableControls()

            End Using

        End Sub
        Private Sub EnableOrDisableControls()

            ButtonItemActions_Copy.Enabled = (DataGridViewLeftSection_Products.HasOnlyOneSelectedRow AndAlso DataGridViewLeftSection_Products.HasRows)
            ButtonItemActions_Update.Enabled = DataGridViewRightSection_AccountExecutives.HasOnlyOneSelectedRow

            ButtonRightSection_AddAccountExecutive.Enabled = DataGridViewMiddleSection_Employees.HasASelectedRow
            ButtonRightSection_RemoveAccountExecutive.Enabled = DataGridViewRightSection_AccountExecutives.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AccountExecutiveSetupForm As AdvantageFramework.Maintenance.Client.Presentation.AccountExecutiveSetupForm = Nothing

            AccountExecutiveSetupForm = New AdvantageFramework.Maintenance.Client.Presentation.AccountExecutiveSetupForm()

            AccountExecutiveSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountExecutiveSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            DataGridViewLeftSection_Products.MultiSelect = False

            LoadProducts()

            EnableOrDisableControls()

            DataGridViewLeftSection_Products.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            DataGridViewRightSection_AccountExecutives.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim UserProductsList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim AccountExecutivesList As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AccountExecutivesList = (From AE In AdvantageFramework.Database.Procedures.AccountExecutive.Load(DbContext).Include("Employee").Include("Product").Include("Product.Client").Include("Product.Division").ToList
                                             Join Row In DataGridViewLeftSection_Products.GetAllRowsDataBoundItems() On AE.ClientCode Equals Row.ClientCode And AE.DivisionCode Equals Row.DivisionCode And AE.ProductCode Equals Row.Code
                                             Select AE).ToList

                    UserProductsList = AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode, False).ToList

                    For Each AccountExecutive In AccountExecutivesList.ToList

                        If UserProductsList.Any(Function(UserProduct) UserProduct.ClientCode = AccountExecutive.ClientCode AndAlso UserProduct.DivisionCode = AccountExecutive.DivisionCode AndAlso UserProduct.Code = AccountExecutive.ProductCode) = False Then

                            AccountExecutivesList.Remove(AccountExecutive)

                        End If

                    Next

                    DataGridViewRightSection_Export.DataSource = AccountExecutivesList

                    DataGridViewRightSection_Export.CurrentView.BestFitColumns()

                    DataGridViewRightSection_Export.Print(DefaultLookAndFeel.LookAndFeel, "AEClientManager")

                    DataGridViewRightSection_Export.DataSource = _AccountExecutiveList

                End Using

            End Using

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            DataGridViewRightSection_Export.Print(DefaultLookAndFeel.LookAndFeel, "AEClientManager")

        End Sub
        Private Sub ButtonItemActions_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim EmployeeCode As String = Nothing

            If DataGridViewRightSection_AccountExecutives.HasOnlyOneSelectedRow Then

                EmployeeCode = DataGridViewRightSection_AccountExecutives.GetFirstSelectedRowBookmarkValue()

                If AdvantageFramework.Maintenance.Client.Presentation.AccountExecutiveUpdateDialog.ShowFormDialog(EmployeeCode) = Windows.Forms.DialogResult.OK Then

                    LoadEmployeesAndAccountExecutives()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim SelectedProducts As IEnumerable = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim CurrentAccountExecutiveClassList As Generic.List(Of AdvantageFramework.Database.Classes.AccountExecutive) = Nothing
            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim ProductAccountExecutivesList As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
            Dim AccountExecutiveClass As AdvantageFramework.Database.Classes.AccountExecutive = Nothing
            Dim CopiedCount As Integer = 0

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Product, True, True, SelectedProducts, True, "Copy To", True) = System.Windows.Forms.DialogResult.OK Then

                If SelectedProducts IsNot Nothing Then

                    Try

                        CurrentAccountExecutiveClassList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountExecutive)

                        For Each CurrentAccountExecutiveClass In DataGridViewRightSection_AccountExecutives.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.AccountExecutive)().ToList

                            If CurrentAccountExecutiveClass.IsInactive = False Then

                                CurrentAccountExecutiveClassList.Add(CurrentAccountExecutiveClass)

                            End If

                        Next

                    Catch ex As Exception
                        CurrentAccountExecutiveClassList = Nothing
                    End Try

                    If CurrentAccountExecutiveClassList IsNot Nothing Then

                        Me.ShowWaitForm()
                        Me.ShowWaitForm("Copying...")

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each Product In SelectedProducts

                                ClientCode = Nothing
                                DivisionCode = Nothing
                                ProductCode = Nothing

                                ProductAccountExecutivesList = Nothing

                                Try

                                    ClientCode = Product.ClientCode
                                    DivisionCode = Product.DivisionCode
                                    ProductCode = Product.Code

                                Catch ex As Exception
                                    ClientCode = Nothing
                                    DivisionCode = Nothing
                                    ProductCode = Nothing
                                End Try

                                Try

                                    If ClientCode <> Nothing AndAlso DivisionCode <> Nothing AndAlso ProductCode <> Nothing Then

                                        ProductAccountExecutivesList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode).ToList

                                        For Each AccountExecutiveClass In CurrentAccountExecutiveClassList

                                            AccountExecutive = Nothing

                                            If ProductAccountExecutivesList.Any(Function(ProductAccountExecutive) ProductAccountExecutive.EmployeeCode = AccountExecutiveClass.EmployeeCode) = False Then

                                                AccountExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                                                AccountExecutive.DbContext = DbContext

                                                AccountExecutive.ClientCode = ClientCode
                                                AccountExecutive.DivisionCode = DivisionCode
                                                AccountExecutive.ProductCode = ProductCode
                                                AccountExecutive.EmployeeCode = AccountExecutiveClass.EmployeeCode
                                                AccountExecutive.IsInactive = AccountExecutiveClass.AccountExecutive.IsInactive

                                                If AccountExecutiveClass.AccountExecutive.IsDefaultAccountExecutive = 1 AndAlso ProductAccountExecutivesList.Any(Function(ProductAccountExecutive) ProductAccountExecutive.IsDefaultAccountExecutive.GetValueOrDefault(0) = 1) = False Then

                                                    AccountExecutive.IsDefaultAccountExecutive = AccountExecutiveClass.AccountExecutive.IsDefaultAccountExecutive

                                                End If

                                                AccountExecutive.ManagementLevelID = AccountExecutiveClass.AccountExecutive.ManagementLevelID

                                                If AdvantageFramework.Database.Procedures.AccountExecutive.Insert(DbContext, AccountExecutive) = True Then

                                                    CopiedCount += 1

                                                End If

                                            End If

                                        Next

                                    End If

                                Catch ex As Exception

                                End Try

                            Next

                        End Using

                        Me.CloseWaitForm()

                        AdvantageFramework.WinForm.MessageBox.Show(CopiedCount & " AE/Client Manager(s) copied.", WinForm.MessageBox.MessageBoxButtons.OK, "Copy Complete")

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Products_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Products.SelectionChangedEvent

            LoadEmployeesAndAccountExecutives()

        End Sub
        Private Sub DataGridViewRightSection_AccountExecutives_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_AccountExecutives.CellValueChangingEvent

            'objects
            Dim AccountExecutive As AdvantageFramework.Database.Classes.AccountExecutive = Nothing
            Dim CurrentRowAccountExecutive As AdvantageFramework.Database.Classes.AccountExecutive = Nothing
            Dim DisplayMessage As String = Nothing
            Dim IsDefault As Boolean = Nothing
            Dim HasError As Boolean = Nothing
            Dim DoSave As Boolean = Nothing
            Dim ManagementLevel As AdvantageFramework.Database.Entities.ManagementLevel = Nothing

            If e.Column.FieldName <> AdvantageFramework.Database.Classes.AccountExecutive.Properties.ManagementLevel.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DoSave = False
                    HasError = False

                    AccountExecutive = DataGridViewRightSection_AccountExecutives.CurrentView.GetRow(e.RowHandle)

                    If AccountExecutive IsNot Nothing Then

                        If e.Column.FieldName = AdvantageFramework.Database.Classes.AccountExecutive.Properties.IsDefault.ToString Then

                            If e.Value Then

                                For RowHandle = 0 To DataGridViewRightSection_AccountExecutives.CurrentView.RowCount - 1

                                    CurrentRowAccountExecutive = DataGridViewRightSection_AccountExecutives.CurrentView.GetRow(RowHandle)

                                    If CurrentRowAccountExecutive IsNot AccountExecutive AndAlso CurrentRowAccountExecutive.IsDefault Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Only one default A/E is allowed.")

                                        HasError = True

                                        Exit For

                                    End If

                                Next

                                If AccountExecutive.IsInactive AndAlso HasError = False Then

                                    If AdvantageFramework.WinForm.MessageBox.Show("This A/E is inactive. Marking this A/E as the default will activate the A/E. Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                        AccountExecutive.IsDefault = True
                                        AccountExecutive.IsInactive = False

                                        AccountExecutive.AccountExecutive.IsInactive = 0
                                        AccountExecutive.AccountExecutive.IsDefaultAccountExecutive = 1

                                        DoSave = True

                                    End If

                                ElseIf HasError = False Then

                                    If AccountExecutive.ManagementLevelID <> 1 Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Management Level must be 'Account Executive' to set.")

                                        DoSave = False

                                    Else

                                        AccountExecutive.IsDefault = True
                                        AccountExecutive.AccountExecutive.IsDefaultAccountExecutive = 1

                                        DoSave = True

                                    End If

                                End If

                            Else

                                AccountExecutive.IsDefault = False
                                AccountExecutive.AccountExecutive.IsDefaultAccountExecutive = 0

                                DoSave = True

                            End If

                        ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.AccountExecutive.Properties.IsInactive.ToString Then

                            If AccountExecutive.IsDefault AndAlso e.Value Then

                                If AdvantageFramework.WinForm.MessageBox.Show("This A/E is the default A/E. Marking this A/E inactive will remove the default status. Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    AccountExecutive.IsDefault = False
                                    AccountExecutive.IsInactive = True

                                    AccountExecutive.AccountExecutive.IsInactive = 1
                                    AccountExecutive.AccountExecutive.IsDefaultAccountExecutive = 0

                                    DoSave = True

                                End If

                            Else

                                AccountExecutive.IsInactive = e.Value
                                AccountExecutive.AccountExecutive.IsInactive = Convert.ToInt16(e.Value)

                                DoSave = True

                            End If

                        End If

                    End If

                    If DoSave Then

                        AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, AccountExecutive.AccountExecutive)

                    End If

                    LoadEmployeesAndAccountExecutives()

                End Using

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.AccountExecutive.Properties.ManagementLevel.ToString Then

                AccountExecutive = DataGridViewRightSection_AccountExecutives.CurrentView.GetRow(e.RowHandle)

                If AccountExecutive IsNot Nothing AndAlso e.Value IsNot Nothing AndAlso IsNumeric(e.Value) AndAlso e.Value <> 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ManagementLevel = AdvantageFramework.Database.Procedures.ManagementLevel.LoadByID(DbContext, e.Value)

                        If AccountExecutive.IsDefault AndAlso ManagementLevel.Description <> "Account Executive" Then

                            AdvantageFramework.WinForm.MessageBox.Show("Default A/E must be 'Account Executive'")

                            LoadEmployeesAndAccountExecutives()

                        ElseIf AccountExecutive.ManagementLevelID <> e.Value Then

                            AccountExecutive.ManagementLevelID = e.Value
                            AccountExecutive.AccountExecutive.ManagementLevelID = e.Value

                            AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, AccountExecutive.AccountExecutive)

                            AccountExecutive.ManagementLevel = ManagementLevel.Description

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub ButtonRightSection_AddAccountExecutive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_AddAccountExecutive.Click

            'objects
            Dim EmployeeCode As String = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim EmployeeCodesList As IEnumerable(Of Object) = Nothing

            If DataGridViewLeftSection_Products.HasOnlyOneSelectedRow AndAlso DataGridViewMiddleSection_Employees.HasASelectedRow Then

                ClientCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.ClientCode.ToString)
                DivisionCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.DivisionCode.ToString)
                ProductCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.Code.ToString)

                EmployeeCodesList = DataGridViewMiddleSection_Employees.CurrentView.GetSelectedRows.Select(Function(RowHandle) DataGridViewMiddleSection_Employees.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.Employee.Properties.Code.ToString)).ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each EmployeeCode In EmployeeCodesList.OfType(Of String)()

                            AccountExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                            AccountExecutive.ClientCode = ClientCode
                            AccountExecutive.DivisionCode = DivisionCode
                            AccountExecutive.ProductCode = ProductCode
                            AccountExecutive.EmployeeCode = EmployeeCode
                            AccountExecutive.IsInactive = 0
                            AccountExecutive.IsDefaultAccountExecutive = 0

                            AdvantageFramework.Database.Procedures.AccountExecutive.Insert(DbContext, AccountExecutive)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadEmployeesAndAccountExecutives()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveAccountExecutive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_RemoveAccountExecutive.Click

            'objects
            Dim EmployeeCode As String = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim EmployeeCodesList As IEnumerable(Of Object) = Nothing

            If DataGridViewLeftSection_Products.HasASelectedRow AndAlso DataGridViewRightSection_AccountExecutives.HasASelectedRow Then

                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ClientCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.Code.ToString)

                        EmployeeCodesList = DataGridViewRightSection_AccountExecutives.CurrentView.GetSelectedRows.Select(Function(RowHandle) DataGridViewRightSection_AccountExecutives.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.AccountExecutive.Properties.EmployeeCode.ToString)).ToList

                        For Each EmployeeCode In EmployeeCodesList.OfType(Of String)()

                            AccountExecutive = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductAndEmployeeCode(DbContext, ClientCode, DivisionCode, ProductCode, EmployeeCode)

                            AdvantageFramework.Database.Procedures.AccountExecutive.Delete(DbContext, AccountExecutive)

                        Next

                        LoadEmployeesAndAccountExecutives()

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRightSection_AccountExecutives_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRightSection_AccountExecutives.SelectionChangedEvent

            EnableOrDisableControls()

        End Sub
        Private Sub DataGridViewRightSection_AccountExecutives_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRightSection_AccountExecutives.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim AccountExecutive As AdvantageFramework.Database.Classes.AccountExecutive = Nothing
            Dim RepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TypeOf DataGridViewRightSection_AccountExecutives.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DataGridViewRightSection_AccountExecutives.CurrentView.ActiveEditor

                    If DataGridViewRightSection_AccountExecutives.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.AccountExecutive.Properties.ManagementLevel.ToString Then

                        AccountExecutive = DataGridViewRightSection_AccountExecutives.CurrentView.GetRow(DataGridViewRightSection_AccountExecutives.CurrentView.FocusedRowHandle)

                        BindingSource = New System.Windows.Forms.BindingSource

                        BindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ManagementLevel.LoadAllActive(DbContext).ToList
                                                    Select Entity.ID,
                                                           Entity.Description).ToList

                        GridLookUpEdit.Properties.DataSource = BindingSource

                        If GridLookUpEdit.Properties.GetDisplayValueByKeyValue(AccountExecutive.ManagementLevelID) Is Nothing Then

                            RepositoryItemGridLookUpEdit = DirectCast(GridLookUpEdit.Properties, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)

                            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, RepositoryItemGridLookUpEdit.DisplayMember, RepositoryItemGridLookUpEdit.ValueMember, AccountExecutive.ManagementLevel, AccountExecutive.ManagementLevelID, True, False, Nothing)

                        End If

                    End If

                End If

            End Using

        End Sub
        Private Sub DataGridViewMiddleSection_Employees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewMiddleSection_Employees.SelectionChangedEvent

            EnableOrDisableControls()

        End Sub

#End Region

#End Region

    End Class

End Namespace