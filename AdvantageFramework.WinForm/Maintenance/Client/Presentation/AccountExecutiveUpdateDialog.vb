Namespace Maintenance.Client.Presentation

    Public Class AccountExecutiveUpdateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CurrentAccountExecutiveEmployeeCode As String = Nothing
        Private _Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
        Private _AccountExecutivesList As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal CurrentAccountExecutiveEmployeeCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _CurrentAccountExecutiveEmployeeCode = CurrentAccountExecutiveEmployeeCode

        End Sub
        Private Sub EnableOrDisableActions()

            If CheckBoxForm_AssignToClosed.Checked OrElse CheckBoxForm_AssignToOpen.Checked OrElse CheckBoxForm_MakeInactive.Checked OrElse CheckBoxForm_SetAsDefault.Checked Then

                ButtonForm_Update.Enabled = True

            Else

                ButtonForm_Update.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal CurrentAccountExecutiveEmployeeCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim AccountExecutiveUpdateDialog As AdvantageFramework.Maintenance.Client.Presentation.AccountExecutiveUpdateDialog = Nothing

            AccountExecutiveUpdateDialog = New AdvantageFramework.Maintenance.Client.Presentation.AccountExecutiveUpdateDialog(CurrentAccountExecutiveEmployeeCode)

            ShowFormDialog = AccountExecutiveUpdateDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountExecutiveUpdateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim UserProductsList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        _AccountExecutivesList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByEmployeeCode(DbContext, _CurrentAccountExecutiveEmployeeCode).Include("Product").Include("Product.Office").Include("Product.Client").Include("Product.Division").ToList

                    Catch ex As Exception
                        _AccountExecutivesList = Nothing
                    End Try

                    Try

                        LabelForm_CurrentAEDescription.Text = _AccountExecutivesList.FirstOrDefault.Employee.ToString

                    Catch ex As Exception
                        LabelForm_CurrentAEDescription.Text = ""
                    End Try

                    _Products = _AccountExecutivesList.Select(Function(AccountExecutive) AccountExecutive.Product).ToList

                    UserProductsList = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, True, False).ToList

                    For Each Product In _Products.ToList

                        If UserProductsList.Any(Function(UserProduct) UserProduct.ClientCode = Product.ClientCode AndAlso UserProduct.DivisionCode = Product.DivisionCode AndAlso UserProduct.Code = Product.Code) = False Then

                            _Products.Remove(Product)

                        End If

                    Next

                    DataGridViewForm_Products.DataSource = _Products

                    DataGridViewForm_Products.CurrentView.BestFitColumns()

                    If DataGridViewForm_Products.Columns("AccountExecutive") IsNot Nothing Then

                        If DataGridViewForm_Products.Columns("AccountExecutive").Visible Then

                            DataGridViewForm_Products.Columns("AccountExecutive").Visible = False

                        End If

                    End If

                    DataGridViewForm_Products.ShowSelectDeselectAllButtons = True

                    ComboBoxForm_NewAccountExecutive.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(Me.Session, DbContext).OrderBy(Function(Entity) Entity.FirstName).ThenBy(Function(Entity) Entity.LastName).ToList

                End Using

            End Using

            ButtonForm_Update.Enabled = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim SelectedProducts As IEnumerable = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim IsAccountExecutiveAddedToProduct As Boolean = False
            Dim AccountExecutiveUpdateList As Generic.List(Of AdvantageFramework.Database.Classes.AccountExecutiveUpdate) = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim NewAccountExecutive As String = Nothing

            If ComboBoxForm_NewAccountExecutive.HasASelectedValue Then

                If DataGridViewForm_Products.HasASelectedRow Then

                    Me.ShowWaitForm("Processing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            AccountExecutiveUpdateList = New Generic.List(Of AdvantageFramework.Database.Classes.AccountExecutiveUpdate)

                            SelectedProducts = DataGridViewForm_Products.GetAllSelectedRowsDataBoundItems

                            For Each SelectedProduct In SelectedProducts

                                ClientCode = Nothing
                                DivisionCode = Nothing
                                ProductCode = Nothing

                                Try

                                    ClientCode = SelectedProduct.ClientCode
                                    DivisionCode = SelectedProduct.DivisionCode
                                    ProductCode = SelectedProduct.Code

                                Catch ex As Exception
                                    ClientCode = Nothing
                                    DivisionCode = Nothing
                                    ProductCode = Nothing
                                End Try

                                Try

                                    If ClientCode <> Nothing AndAlso DivisionCode <> Nothing AndAlso ProductCode <> Nothing Then

                                        IsAccountExecutiveAddedToProduct = False

                                        Try

                                            Product = _Products.SingleOrDefault(Function(Prd) Prd.ClientCode = ClientCode AndAlso Prd.DivisionCode = DivisionCode AndAlso Prd.Code = ProductCode)

                                        Catch ex As Exception
                                            Product = Nothing
                                        End Try

                                        If Product IsNot Nothing Then

                                            NewAccountExecutive = ComboBoxForm_NewAccountExecutive.GetSelectedValue.ToString

                                            If AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code).Any(Function(ProductAccountExecutive) ProductAccountExecutive.EmployeeCode = NewAccountExecutive) = False Then

                                                If CheckBoxForm_AssignToOpen.Checked OrElse CheckBoxForm_AssignToClosed.Checked Then

                                                    AccountExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                                                    AccountExecutive.DbContext = DbContext

                                                    AccountExecutive.ClientCode = ClientCode
                                                    AccountExecutive.DivisionCode = DivisionCode
                                                    AccountExecutive.ProductCode = ProductCode
                                                    AccountExecutive.EmployeeCode = ComboBoxForm_NewAccountExecutive.GetSelectedValue
                                                    AccountExecutive.IsInactive = 0
                                                    AccountExecutive.IsDefaultAccountExecutive = CShort(CheckBoxForm_SetAsDefault.CheckValue)

                                                    If AdvantageFramework.Database.Procedures.AccountExecutive.Insert(DbContext, AccountExecutive) Then

                                                        AccountExecutiveUpdateList.Add(New AdvantageFramework.Database.Classes.AccountExecutiveUpdate(LabelForm_CurrentAEDescription.Text, ComboBoxForm_NewAccountExecutive.Text,
                                                                                                                                                      Product.Client.ToString, Product.Division.ToString, Product.ToString,
                                                                                                                                                      "Account Executive " & ComboBoxForm_NewAccountExecutive.Text & " added for " & Product.ClientCode & "/" &
                                                                                                                                                      Product.DivisionCode & "/" & Product.Code & "."))

                                                        If CheckBoxForm_SetAsDefault.Checked Then

                                                            For Each ProductAccountExecutive In AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code).ToList

                                                                If ProductAccountExecutive.IsDefaultAccountExecutive.GetValueOrDefault(0) = 1 AndAlso
                                                                        ProductAccountExecutive.EmployeeCode <> AccountExecutive.EmployeeCode Then

                                                                    ProductAccountExecutive.IsDefaultAccountExecutive = 0

                                                                    AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, ProductAccountExecutive)

                                                                End If

                                                            Next

                                                            AccountExecutiveUpdateList.Add(New AdvantageFramework.Database.Classes.AccountExecutiveUpdate(LabelForm_CurrentAEDescription.Text, ComboBoxForm_NewAccountExecutive.Text,
                                                                                                                                                          Product.Client.ToString, Product.Division.ToString, Product.ToString,
                                                                                                                                                          "Account Executive " & ComboBoxForm_NewAccountExecutive.Text & " is the new default A/E for " & Product.ClientCode & "/" &
                                                                                                                                                          Product.DivisionCode & "/" & Product.Code & "."))

                                                        End If

                                                        IsAccountExecutiveAddedToProduct = True

                                                    End If

                                                End If

                                            Else

                                                If AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code).Any(Function(ProductAccountExecutive) ProductAccountExecutive.EmployeeCode = NewAccountExecutive AndAlso ProductAccountExecutive.IsInactive = 1) Then

                                                    IsAccountExecutiveAddedToProduct = False

                                                    AccountExecutiveUpdateList.Add(New AdvantageFramework.Database.Classes.AccountExecutiveUpdate(LabelForm_CurrentAEDescription.Text, ComboBoxForm_NewAccountExecutive.Text,
                                                                                                                                                  Product.Client.ToString, Product.Division.ToString, Product.ToString,
                                                                                                                                                  "No change was made because the new Account Executive " & ComboBoxForm_NewAccountExecutive.Text & " is inactive for " & Product.ClientCode & "/" &
                                                                                                                                                  Product.DivisionCode & "/" & Product.Code & "."))

                                                Else

                                                    If CheckBoxForm_SetAsDefault.Checked Then

                                                        For Each ProductAccountExecutive In AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code).ToList

                                                            If ProductAccountExecutive.EmployeeCode = ComboBoxForm_NewAccountExecutive.GetSelectedValue Then

                                                                ProductAccountExecutive.IsDefaultAccountExecutive = 1

                                                                AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, ProductAccountExecutive)

                                                            Else

                                                                If ProductAccountExecutive.IsDefaultAccountExecutive.GetValueOrDefault(0) = 1 Then

                                                                    ProductAccountExecutive.IsDefaultAccountExecutive = 0

                                                                    AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, ProductAccountExecutive)

                                                                End If

                                                            End If

                                                        Next

                                                        AccountExecutiveUpdateList.Add(New AdvantageFramework.Database.Classes.AccountExecutiveUpdate(LabelForm_CurrentAEDescription.Text, ComboBoxForm_NewAccountExecutive.Text,
                                                                                                                                                      Product.Client.ToString, Product.Division.ToString, Product.ToString,
                                                                                                                                                      "Account Executive " & ComboBoxForm_NewAccountExecutive.Text & " is the new default A/E for " & Product.ClientCode & "/" &
                                                                                                                                                      Product.DivisionCode & "/" & Product.Code & "."))

                                                    End If

                                                    IsAccountExecutiveAddedToProduct = True

                                                End If

                                            End If

                                            If CheckBoxForm_AssignToOpen.Checked AndAlso IsAccountExecutiveAddedToProduct Then

                                                For Each Job In AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode).Include("JobComponents").ToList

                                                    For Each JobComponent In Job.JobComponents.Where(Function(Entity) Entity.AccountExecutiveEmployeeCode = _CurrentAccountExecutiveEmployeeCode).ToList

                                                        If JobComponent.JobProcessNumber <> 6 AndAlso JobComponent.JobProcessNumber <> 12 Then

                                                            JobComponent.AccountExecutiveEmployeeCode = ComboBoxForm_NewAccountExecutive.GetSelectedValue

                                                            DbContext.UpdateObject(JobComponent)

                                                            AccountExecutiveUpdateList.Add(New AdvantageFramework.Database.Classes.AccountExecutiveUpdate(LabelForm_CurrentAEDescription.Text, ComboBoxForm_NewAccountExecutive.Text,
                                                                                                                                                          Product.Client.ToString, Product.Division.ToString, Product.ToString,
                                                                                                                                                          "The Account Executive for job-component " & JobComponent.ToString(True, False) & " was changed to " & ComboBoxForm_NewAccountExecutive.Text & "."))

                                                        End If

                                                    Next

                                                Next

                                                Try

                                                    DbContext.SaveChanges()

                                                Catch ex As Exception

                                                End Try

                                            End If

                                            If CheckBoxForm_AssignToClosed.Checked AndAlso IsAccountExecutiveAddedToProduct Then

                                                For Each Job In AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode).Include("JobComponents").ToList

                                                    For Each JobComponent In Job.JobComponents.Where(Function(Entity) Entity.AccountExecutiveEmployeeCode = _CurrentAccountExecutiveEmployeeCode).ToList

                                                        If JobComponent.JobProcessNumber = 6 OrElse JobComponent.JobProcessNumber = 12 Then

                                                            JobComponent.AccountExecutiveEmployeeCode = ComboBoxForm_NewAccountExecutive.GetSelectedValue

                                                            DbContext.UpdateObject(JobComponent)

                                                            AccountExecutiveUpdateList.Add(New AdvantageFramework.Database.Classes.AccountExecutiveUpdate(LabelForm_CurrentAEDescription.Text, ComboBoxForm_NewAccountExecutive.Text,
                                                                                                                                                          Product.Client.ToString, Product.Division.ToString, Product.ToString,
                                                                                                                                                          "The Account Executive for job-component " & JobComponent.ToString(True, False) & " was changed to " & ComboBoxForm_NewAccountExecutive.Text & "."))

                                                        End If

                                                    Next

                                                Next

                                                Try

                                                    DbContext.SaveChanges()

                                                Catch ex As Exception

                                                End Try

                                            End If

                                        End If

                                    End If

                                    If CheckBoxForm_MakeInactive.Checked Then

                                        Try

                                            AccountExecutive = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code).SingleOrDefault(Function(AE) AE.EmployeeCode = _CurrentAccountExecutiveEmployeeCode)

                                        Catch ex As Exception
                                            AccountExecutive = Nothing
                                        End Try

                                        If AccountExecutive IsNot Nothing Then

                                            AccountExecutive.IsInactive = 1
                                            AccountExecutive.IsDefaultAccountExecutive = 0

                                            DbContext.UpdateObject(AccountExecutive)

                                            AccountExecutiveUpdateList.Add(New AdvantageFramework.Database.Classes.AccountExecutiveUpdate(LabelForm_CurrentAEDescription.Text, ComboBoxForm_NewAccountExecutive.Text,
                                                                                                                                          AccountExecutive.Product.Client.ToString, AccountExecutive.Product.Division.ToString, AccountExecutive.Product.ToString,
                                                                                                                                          "Account Executive " & LabelForm_CurrentAEDescription.Text & " marked inactive for " & AccountExecutive.ClientCode & "/" &
                                                                                                                                          AccountExecutive.DivisionCode & "/" & AccountExecutive.ProductCode & "."))

                                            Try

                                                DbContext.SaveChanges()

                                            Catch ex As Exception

                                            End Try

                                        End If

                                    End If

                                Catch ex As Exception

                                End Try

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                    AdvantageFramework.WinForm.MessageBox.Show("Account Executive update complete.")

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    ParameterDictionary("DataSource") = AccountExecutiveUpdateList

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountExecutiveUpdate, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one client/division/product.")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a New A/E.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub CheckBoxForm_AssignToClosed_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_AssignToClosed.CheckValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxForm_AssignToOpen_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_AssignToOpen.CheckValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxForm_MakeInactive_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_MakeInactive.CheckValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxForm_SetAsDefault_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_SetAsDefault.CheckValueChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace