Namespace Maintenance.Client.Presentation

    Public Class ProductCategoryCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub
        Private Sub LoadClients()

            If ComboBoxForm_Client.Enabled Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)

                    End Using

                End Using

            End If

        End Sub
        Private Sub LoadDivisions()

            Dim ClientCode As String = Nothing

            If ComboBoxForm_Client.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxForm_Division.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                           Where Division.ClientCode = ClientCode
                                                           Select Division

                    End Using

                End Using

            End If

        End Sub
        Private Sub LoadProducts()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If ComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Division.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue
                DivisionCode = ComboBoxForm_Division.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxForm_Product.DataSource = From Product In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                          Where Product.ClientCode = ClientCode AndAlso
                                                                Product.DivisionCode = DivisionCode
                                                          Select Product


                    End Using

                End Using

            End If

        End Sub
        Private Function CheckIfProductCategoryExists(ByVal ProductCategory As AdvantageFramework.Database.Entities.ProductCategory) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.ProductCategory.LoadByClientAndDivisionAndProductAndProductCategoryCode(DbContext, ProductCategory.ClientCode, ProductCategory.DivisionCode, ProductCategory.ProductCode, ProductCategory.Code) IsNot Nothing Then

                    CheckIfProductCategoryExists = True

                Else

                    CheckIfProductCategoryExists = False

                End If

            End Using

        End Function
        Private Sub FilterProductCategories()

            Dim ProductCategories As Generic.List(Of AdvantageFramework.Database.Entities.ProductCategory) = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ActiveFilterString As String = Nothing

            If Me.Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ComboBoxForm_Client.HasASelectedValue Then

                        ClientCode = ComboBoxForm_Client.GetSelectedValue

                        ActiveFilterString = "ClientCode <> '" & ClientCode & "'"

                    Else
                        ClientCode = ""
                    End If

                    If ComboBoxForm_Division.Enabled AndAlso ComboBoxForm_Division.HasASelectedValue Then

                        DivisionCode = ComboBoxForm_Division.GetSelectedValue

                        ActiveFilterString &= " OR DivisionCode <> '" & DivisionCode & "'"

                    Else
                        DivisionCode = ""
                    End If

                    If ComboBoxForm_Product.Enabled AndAlso ComboBoxForm_Product.HasASelectedValue Then

                        ProductCode = ComboBoxForm_Product.GetSelectedValue

                        ActiveFilterString &= " OR ProductCode <> '" & ProductCode & "'"

                    Else
                        ProductCode = ""
                    End If

                    DataGridViewForm_ProductCategory.CurrentView.AFActiveFilterString = ActiveFilterString

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim ProductCategoryCopyDialog As AdvantageFramework.Maintenance.Client.Presentation.ProductCategoryCopyDialog = Nothing

            ProductCategoryCopyDialog = New AdvantageFramework.Maintenance.Client.Presentation.ProductCategoryCopyDialog()

            ShowFormDialog = ProductCategoryCopyDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProductCategoryCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewForm_ProductCategory.MultiSelect = True

            DataGridViewForm_ProductCategory.OptionsCustomization.AllowFilter = False
            DataGridViewForm_ProductCategory.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_ProductCategory.DataSource = AdvantageFramework.Database.Procedures.ProductCategory.LoadAllActive(DbContext).ToList

                DataGridViewForm_ProductCategory.CurrentView.BestFitColumns()

            End Using

            FilterProductCategories()

            LoadClients()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Copy_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Copy.Click

            Dim ProductCategory As AdvantageFramework.Database.Entities.ProductCategory = Nothing
            Dim DuplicateCategory As AdvantageFramework.Database.Entities.ProductCategory = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim SelectedRows As Integer() = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ProductCategoryCode As String = Nothing
            Dim CopyToClientCode As String = Nothing
            Dim CopyToDivisionCode As String = Nothing
            Dim CopyToProductCode As String = Nothing
            Dim ProductCategoriesCopied As Boolean = False
            Dim NewProductCategoryCode As String = Nothing
            Dim CancelInsert As Boolean = False
            Dim CategoriesCopied As Short = 0

            If DataGridViewForm_ProductCategory.HasASelectedRow AndAlso ComboBoxForm_Client.HasASelectedValue AndAlso (ComboBoxForm_Division.HasASelectedValue OrElse CheckBoxForm_AllDivisions.Checked) AndAlso (ComboBoxForm_Product.HasASelectedValue OrElse CheckBoxForm_AllProducts.Checked) Then

                CopyToClientCode = ComboBoxForm_Client.GetSelectedValue
                CopyToDivisionCode = ComboBoxForm_Division.GetSelectedValue
                CopyToProductCode = ComboBoxForm_Product.GetSelectedValue

                If Me.Validator Then

                    Me.ShowWaitForm("Processing...")

                    Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            SelectedRows = DataGridViewForm_ProductCategory.CurrentView.GetSelectedRows()

                            For Each Row In SelectedRows

                                ClientCode = DataGridViewForm_ProductCategory.CurrentView.GetRowCellValue(Row, AdvantageFramework.Database.Entities.ProductCategory.Properties.ClientCode.ToString)
                                DivisionCode = DataGridViewForm_ProductCategory.CurrentView.GetRowCellValue(Row, AdvantageFramework.Database.Entities.ProductCategory.Properties.DivisionCode.ToString)
                                ProductCode = DataGridViewForm_ProductCategory.CurrentView.GetRowCellValue(Row, AdvantageFramework.Database.Entities.ProductCategory.Properties.ProductCode.ToString)
                                ProductCategoryCode = DataGridViewForm_ProductCategory.CurrentView.GetRowCellValue(Row, AdvantageFramework.Database.Entities.ProductCategory.Properties.Code.ToString)

                                ProductCategory = AdvantageFramework.Database.Procedures.ProductCategory.LoadByClientAndDivisionAndProductAndProductCategoryCode(DbContext, ClientCode, DivisionCode, ProductCode, ProductCategoryCode)

                                If ProductCategory IsNot Nothing Then

                                    If CheckBoxForm_AllDivisions.Checked Then

                                        ' Create category for all divisions & all products under current client
                                        ProductList = AdvantageFramework.Database.Procedures.Product.LoadByClientCode(DbContext, CopyToClientCode).ToList

                                        For Each Product In ProductList

                                            DuplicateCategory = New AdvantageFramework.Database.Entities.ProductCategory

                                            DuplicateCategory.ClientCode = CopyToClientCode
                                            DuplicateCategory.DivisionCode = Product.DivisionCode
                                            DuplicateCategory.ProductCode = Product.Code
                                            DuplicateCategory.Code = ProductCategory.Code
                                            DuplicateCategory.Description = ProductCategory.Description
                                            DuplicateCategory.IsInactive = ProductCategory.IsInactive

                                            DuplicateCategory.DbContext = DbContext

                                            If AdvantageFramework.Database.Procedures.ProductCategory.Insert(DbContext, DuplicateCategory) Then

                                                CategoriesCopied = CategoriesCopied + 1

                                            End If

                                        Next

                                    ElseIf CheckBoxForm_AllProducts.Checked Then

                                        ' Insert Category for all products under selected Client & Division
                                        ProductList = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, CopyToClientCode, CopyToDivisionCode).ToList

                                        For Each Product In ProductList

                                            DuplicateCategory = New AdvantageFramework.Database.Entities.ProductCategory

                                            DuplicateCategory.ClientCode = CopyToClientCode
                                            DuplicateCategory.DivisionCode = CopyToDivisionCode
                                            DuplicateCategory.ProductCode = Product.Code
                                            DuplicateCategory.Code = ProductCategory.Code
                                            DuplicateCategory.Description = ProductCategory.Description
                                            DuplicateCategory.IsInactive = ProductCategory.IsInactive

                                            DuplicateCategory.DbContext = DbContext

                                            If AdvantageFramework.Database.Procedures.ProductCategory.Insert(DbContext, DuplicateCategory) Then

                                                CategoriesCopied = CategoriesCopied + 1

                                            End If

                                        Next

                                    Else

                                        DuplicateCategory = New AdvantageFramework.Database.Entities.ProductCategory

                                        DuplicateCategory.ClientCode = CopyToClientCode
                                        DuplicateCategory.DivisionCode = CopyToDivisionCode
                                        DuplicateCategory.ProductCode = CopyToProductCode
                                        DuplicateCategory.Code = ProductCategory.Code
                                        DuplicateCategory.Description = ProductCategory.Description
                                        DuplicateCategory.IsInactive = ProductCategory.IsInactive

                                        DuplicateCategory.DbContext = DbContext

                                        If AdvantageFramework.Database.Procedures.ProductCategory.Insert(DbContext, DuplicateCategory) Then

                                            CategoriesCopied = CategoriesCopied + 1

                                        End If

                                    End If

                                End If

                            Next

                        End Using

                        ProductCategoriesCopied = True

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                    If ProductCategoriesCopied Then

                        AdvantageFramework.WinForm.MessageBox.Show("Copying was successful!")

                        ' AdvantageFramework.WinForm.MessageBox.Show("Successfully inserted " & CategoriesCopied.ToString & " record(s) into the PRODUCT_CATEGORY table.")

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                End If

            Else

                If DataGridViewForm_ProductCategory.HasASelectedRow = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a product category")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select client\division\product")

                End If

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_Client_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Client.SelectedValueChanged

            LoadDivisions()

            FilterProductCategories()

            ComboBoxForm_Division.Enabled = If(CheckBoxForm_AllDivisions.Checked, False, ComboBoxForm_Client.HasASelectedValue)

            ComboBoxForm_Product.Enabled = If(CheckBoxForm_AllProducts.Checked, False, ComboBoxForm_Division.HasASelectedValue)

            If ComboBoxForm_Product.Items.Count > 0 Then

                ComboBoxForm_Product.SelectedIndex = 0

            End If

        End Sub
        Private Sub ComboBoxForm_Division_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Division.SelectedValueChanged

            LoadProducts()

            FilterProductCategories()

            ComboBoxForm_Product.Enabled = If(CheckBoxForm_AllProducts.Checked, False, ComboBoxForm_Division.HasASelectedValue)

        End Sub
        Private Sub ComboBoxForm_Product_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Product.SelectedValueChanged

            FilterProductCategories()

        End Sub
        Private Sub CheckBoxForm_AllDivisions_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxForm_AllDivisions.CheckedChanged

            ComboBoxForm_Division.Enabled = Not CheckBoxForm_AllDivisions.Checked
            CheckBoxForm_AllProducts.Checked = If(CheckBoxForm_AllDivisions.Checked, True, CheckBoxForm_AllProducts.Checked)
            CheckBoxForm_AllProducts.Enabled = Not CheckBoxForm_AllDivisions.Checked

            FilterProductCategories()

            If ComboBoxForm_Division.Items.Count > 0 Then

                ComboBoxForm_Division.SelectedIndex = 0

            End If

            If ComboBoxForm_Product.Items.Count > 0 Then

                ComboBoxForm_Product.SelectedIndex = 0

            End If

        End Sub
        Private Sub CheckBoxForm_AllProducts_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxForm_AllProducts.CheckedChanged

            ComboBoxForm_Product.Enabled = Not CheckBoxForm_AllProducts.Checked

            FilterProductCategories()

            If ComboBoxForm_Product.Items.Count > 0 Then

                ComboBoxForm_Product.SelectedIndex = 0

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace