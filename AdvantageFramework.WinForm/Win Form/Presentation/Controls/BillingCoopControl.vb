Namespace WinForm.Presentation.Controls

    Public Class BillingCoopControl

        Public Event SelectedCodeDeletedEvent()
        Public Event TotalPercentChangedEvent(ByVal TotalPercent As Decimal)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _BillingCoopCode As String = Nothing
        Private _BillingCoopList As Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property HasAtLeastOneProduct As Boolean
            Get
                HasAtLeastOneProduct = CBool(DataGridViewRightSection_BillingCoopProducts.CurrentView.RowCount)
            End Get
        End Property
        Public ReadOnly Property PercentTotal As Decimal
            Get
                PercentTotal = DataGridViewRightSection_BillingCoopProducts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.BillingCoop).Select(Function(BillCoop) BillCoop.Percent).Sum
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            Dim FontSizeList As Generic.List(Of Short) = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            TextBoxTopSection_Code.SetPropertySettings(AdvantageFramework.Database.Entities.BillingCoop.Properties.Code)
                            TextBoxTopSection_Description.SetPropertySettings(AdvantageFramework.Database.Entities.BillingCoop.Properties.Description)

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadBillCoopProducts()

            'objects
            Dim BillingCoopList As Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    BillingCoopList = _BillingCoopList

                    Try

                        If BillingCoopList IsNot Nothing AndAlso BillingCoopList.Count > 0 Then

                            DataGridViewLeftSection_Products.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True) _
                                                                                                                                                                            .Where(Function(Entity) Entity.ClientActiveFlag = 1 AndAlso
                                                                                                                                                                                                    Entity.DivisionActiveFlag = 1).ToList
                                                                           Where BillingCoopList.Where(Function(BillCoop) BillCoop.ClientCode = Entity.ClientCode AndAlso
                                                                                                                          BillCoop.DivisionCode = Entity.DivisionCode AndAlso
                                                                                                                          BillCoop.ProductCode = Entity.ProductCode).Any = False
                                                                           Select Entity).ToList

                        Else

                            DataGridViewLeftSection_Products.DataSource = AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True) _
                                                                                                                                                            .Where(Function(Entity) Entity.ClientActiveFlag = 1 AndAlso
                                                                                                                                                                                    Entity.DivisionActiveFlag = 1).ToList

                        End If

                    Catch ex As Exception

                    End Try

                    DataGridViewRightSection_BillingCoopProducts.DataSource = (From Entity In BillingCoopList
                                                                               Join Prod In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext) On Entity.ProductCode Equals Prod.ProductCode And Entity.DivisionCode Equals Prod.DivisionCode And Entity.ClientCode Equals Prod.ClientCode
                                                                               Select New AdvantageFramework.Database.Classes.BillingCoop(Entity) With {.ClientCode = Prod.ClientCode,
                                                                                                                                                        .ClientName = Prod.ClientName,
                                                                                                                                                        .DivisionCode = Prod.DivisionCode,
                                                                                                                                                        .DivisionName = Prod.DivisionName,
                                                                                                                                                        .ProductCode = Prod.ProductCode,
                                                                                                                                                        .ProductName = Prod.ProductDescription,
                                                                                                                                                        .OfficeCode = Prod.OfficeCode,
                                                                                                                                                        .OfficeName = Prod.OfficeName}).ToList

                    If DataGridViewLeftSection_Products.Columns("IsInactive") IsNot Nothing Then

                        If DataGridViewLeftSection_Products.Columns("IsInactive").Visible Then

                            DataGridViewLeftSection_Products.Columns("IsInactive").Visible = False

                        End If

                    End If

                    If DataGridViewLeftSection_Products.Columns(AdvantageFramework.Database.Views.ProductView.Properties.ProductCode.ToString) IsNot Nothing Then

                        DataGridViewLeftSection_Products.Columns(AdvantageFramework.Database.Views.ProductView.Properties.ProductCode.ToString).Caption = "Product Code"

                    End If

                    If DataGridViewLeftSection_Products.Columns(AdvantageFramework.Database.Views.ProductView.Properties.ProductDescription.ToString) IsNot Nothing Then

                        DataGridViewLeftSection_Products.Columns(AdvantageFramework.Database.Views.ProductView.Properties.ProductDescription.ToString).Caption = "Product Description"

                    End If

                    If DataGridViewRightSection_BillingCoopProducts.Columns("IsInactive") IsNot Nothing Then

                        If DataGridViewRightSection_BillingCoopProducts.Columns("IsInactive").Visible Then

                            DataGridViewRightSection_BillingCoopProducts.Columns("IsInactive").Visible = False

                        End If

                    End If

                    If DataGridViewRightSection_BillingCoopProducts.Columns(AdvantageFramework.Database.Classes.BillingCoop.Properties.ProductName.ToString) IsNot Nothing Then

                        DataGridViewRightSection_BillingCoopProducts.Columns(AdvantageFramework.Database.Classes.BillingCoop.Properties.ProductName.ToString).Caption = "Product Description"

                    End If

                    DataGridViewLeftSection_Products.CurrentView.BestFitColumns()
                    DataGridViewRightSection_BillingCoopProducts.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Function FillObject() As Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop)

            Dim BillingCoopList As Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop) = Nothing

            Try

                DataGridViewRightSection_BillingCoopProducts.CurrentView.CloseEditorForUpdating()

                BillingCoopList = New Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop)

                For Each BillingCoop In _BillingCoopList

                    BillingCoop.Code = TextBoxTopSection_Code.Text
                    BillingCoop.Description = TextBoxTopSection_Description.Text
                    BillingCoop.IsInactive = Convert.ToInt16(CheckBoxTopSection_Inactive.Checked)

                    BillingCoopList.Add(BillingCoop)

                Next

            Catch ex As Exception
                BillingCoopList = Nothing
            End Try

            FillObject = BillingCoopList

        End Function
        Private Sub GetUpdatedBillingCoopList()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _BillingCoopList = AdvantageFramework.Database.Procedures.BillingCoop.LoadByBillingCoopCode(DbContext, _BillingCoopCode).Include("Product").Include("Product.Office").Include("Product.Client").Include("Product.Division").ToList

            End Using

        End Sub
        Private Sub AddProducts(ByVal AddAll As Boolean)

            'objects
            Dim BillingCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing
            Dim Products As IEnumerable = Nothing
            Dim RefreshBillingCoopList As Boolean = False

            If DataGridViewLeftSection_Products.HasRows Then

                If AddAll Then

                    Products = DataGridViewLeftSection_Products.GetAllRowsDataBoundItems

                Else

                    Products = DataGridViewLeftSection_Products.GetAllSelectedRowsDataBoundItems

                End If

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each Product In Products

                            BillingCoop = New AdvantageFramework.Database.Entities.BillingCoop

                            BillingCoop.DbContext = DbContext
                            BillingCoop.ClientCode = Product.ClientCode
                            BillingCoop.DivisionCode = Product.DivisionCode
                            BillingCoop.ProductCode = Product.ProductCode
                            BillingCoop.Description = TextBoxTopSection_Description.Text
                            BillingCoop.Code = TextBoxTopSection_Code.Text

                            If _BillingCoopCode <> "" Then

                                If AdvantageFramework.Database.Procedures.BillingCoop.Insert(DbContext, BillingCoop) Then

                                    RefreshBillingCoopList = True

                                End If

                            Else

                                _BillingCoopList.Add(BillingCoop)

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    If RefreshBillingCoopList Then

                        GetUpdatedBillingCoopList()

                    End If

                    LoadBillCoopProducts()

                    If DataGridViewRightSection_BillingCoopProducts.HasRows Then

                        DataGridViewRightSection_BillingCoopProducts.Focus()

                        Try

                            If DataGridViewRightSection_BillingCoopProducts.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Classes.BillingCoop.Properties.Percent.ToString Then

                                DataGridViewRightSection_BillingCoopProducts.CurrentView.FocusedColumn = DataGridViewRightSection_BillingCoopProducts.Columns(AdvantageFramework.Database.Classes.BillingCoop.Properties.Percent.ToString)

                            End If

                        Catch ex As Exception

                        End Try

                    End If

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal BillingCoopCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim BillingCoopList As Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop) = Nothing
            Dim BillingCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing

            _BillingCoopCode = BillingCoopCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _BillingCoopCode <> "" Then

                    _BillingCoopList = AdvantageFramework.Database.Procedures.BillingCoop.LoadByBillingCoopCode(DbContext, _BillingCoopCode).Include("Product").Include("Product.Office").Include("Product.Client").Include("Product.Division").ToList

                    Try

                        BillingCoop = _BillingCoopList.FirstOrDefault

                    Catch ex As Exception
                        BillingCoop = Nothing
                    End Try

                    If BillingCoop IsNot Nothing Then

                        TextBoxTopSection_Code.Enabled = False
                        TextBoxTopSection_Code.ReadOnly = True

                        TextBoxTopSection_Code.Text = BillingCoop.Code
                        TextBoxTopSection_Description.Text = BillingCoop.Description
                        CheckBoxTopSection_Inactive.CheckValue = BillingCoop.IsInactive.GetValueOrDefault(0)

                        LoadBillCoopProducts()

                    Else

                        Loaded = False

                    End If

                Else

                    _BillingCoopList = New Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop)

                    TextBoxTopSection_Code.Enabled = True
                    TextBoxTopSection_Code.ReadOnly = False

                    LoadBillCoopProducts()

                End If

                If DataGridViewRightSection_BillingCoopProducts.Columns("Percent") IsNot Nothing Then

                    DataGridViewRightSection_BillingCoopProducts.Columns("Percent").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    DataGridViewRightSection_BillingCoopProducts.Columns("Percent").SummaryItem.DisplayFormat = "Total: {0}"
                    DataGridViewRightSection_BillingCoopProducts.Columns("Percent").AllowSummaryMenu = False
                    DataGridViewRightSection_BillingCoopProducts.Columns("Percent").MinWidth = 75

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            DataGridViewRightSection_BillingCoopProducts.CurrentView.BestFitColumns()

            LoadControl = Loaded

        End Function
        Public Function Save() As Boolean

            'objects
            Dim BillingCoops As Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop) = Nothing
            Dim BillCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing
            Dim BillingCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing
            Dim PercentSum As Decimal = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Me.HasAtLeastOneProduct Then

                        BillingCoops = Me.FillObject()

                        If BillingCoops IsNot Nothing Then

                            Try

                                PercentSum = BillingCoops.Select(Function(BllCoop) BllCoop.Percent).Sum

                            Catch ex As Exception
                                PercentSum = Nothing
                            End Try

                            If PercentSum = 100 Then

                                For Each BillCoop In BillingCoops

                                    Try

                                        BillingCoop = (From Entity In AdvantageFramework.Database.Procedures.BillingCoop.LoadByBillingCoopCode(DbContext, BillCoop.Code).ToList
                                                       Where Entity.Code = BillCoop.Code AndAlso
                                                                 Entity.ClientCode = BillCoop.ClientCode AndAlso
                                                                 Entity.DivisionCode = BillCoop.DivisionCode AndAlso
                                                                 Entity.ProductCode = BillCoop.ProductCode
                                                       Select Entity).FirstOrDefault

                                    Catch ex As Exception
                                        BillingCoop = Nothing
                                    End Try

                                    If BillingCoop IsNot Nothing Then

                                        BillingCoop.IsInactive = BillCoop.IsInactive
                                        BillingCoop.Code = BillCoop.Code
                                        BillingCoop.Description = BillCoop.Description
                                        BillingCoop.Percent = BillCoop.Percent

                                        If AdvantageFramework.Database.Procedures.BillingCoop.Update(DbContext, BillingCoop) Then

                                            Saved = True

                                        End If

                                    End If

                                Next

                            Else

                                ErrorMessage = "Total must equal 100%."

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                Saved = False
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Deleted = AdvantageFramework.Database.Procedures.BillingCoop.Delete(DbContext, _BillingCoopCode)

                    'If Deleted = False Then

                    '    ErrorMessage = "Failed trying to delete from the database. Please contact software support."

                    'End If

                End Using

            Catch ex As Exception
                Deleted = False
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef BillingCoopCode As String) As Boolean

            'objects
            Dim BillingCoops As Generic.List(Of AdvantageFramework.Database.Entities.BillingCoop) = Nothing
            Dim BillingCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing
            Dim NewBillingCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing
            Dim PercentSum As Decimal = Nothing
            Dim Inserted As Boolean = True
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Me.HasAtLeastOneProduct Then

                        BillingCoops = Me.FillObject()

                        If (From Entity In AdvantageFramework.Database.Procedures.BillingCoop.Load(DbContext).ToList
                            Where Entity.Code.ToUpper = BillingCoops.Select(Function(BillCoop) BillCoop.Code).FirstOrDefault.ToUpper
                            Select Entity).Any Then

                            ErrorMessage = "Please enter a unique code."

                        Else

                            Try

                                PercentSum = BillingCoops.Select(Function(BillCoop) BillCoop.Percent).Sum

                            Catch ex As Exception
                                PercentSum = Nothing
                            End Try

                            If PercentSum = 100 Then

                                For Each BillingCoop In BillingCoops

                                    NewBillingCoop = New AdvantageFramework.Database.Entities.BillingCoop

                                    NewBillingCoop.DbContext = DbContext
                                    NewBillingCoop.IsInactive = BillingCoop.IsInactive
                                    NewBillingCoop.Code = BillingCoop.Code
                                    NewBillingCoop.Description = BillingCoop.Description
                                    NewBillingCoop.Percent = BillingCoop.Percent
                                    NewBillingCoop.ClientCode = BillingCoop.ClientCode
                                    NewBillingCoop.DivisionCode = BillingCoop.DivisionCode
                                    NewBillingCoop.ProductCode = BillingCoop.ProductCode

                                    If AdvantageFramework.Database.Procedures.BillingCoop.Insert(DbContext, NewBillingCoop) = False Then

                                        Inserted = False

                                        AdvantageFramework.Database.Procedures.BillingCoop.Delete(DbContext, NewBillingCoop.Code)

                                        ErrorMessage = "Failed trying to insert into the database. Please contact software support."

                                        Exit For

                                    End If

                                Next

                                If Inserted Then

                                    Try

                                        BillingCoopCode = (From Entity In BillingCoops
                                                           Select Entity.Code).FirstOrDefault

                                    Catch ex As Exception
                                        BillingCoopCode = ""
                                    End Try

                                End If

                            Else

                                ErrorMessage = "Total must equal 100%."

                            End If

                        End If

                    Else

                        ErrorMessage = "You must select at least one product."

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Sub ClearControl()

            TextBoxTopSection_Code.Text = ""
            TextBoxTopSection_Description.Text = ""
            CheckBoxTopSection_Inactive.Checked = False

            DataGridViewLeftSection_Products.DataSource = Nothing
            DataGridViewRightSection_BillingCoopProducts.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub ExportBillingCoopCodes()

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                DataGridViewRightSection_BillingCoopProducts.Print(DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).DefaultLookAndFeel.LookAndFeel, Me.FindForm.Name.Replace("SetupForm", ""))

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub BillingCoopControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            DataGridViewRightSection_BillingCoopProducts.OptionsView.ShowFooter = True

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ButtonRightSection_AddAllProducts_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddAllProducts.Click

            AddProducts(True)

        End Sub
        Private Sub ButtonRightSection_AddProducts_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddProducts.Click

            AddProducts(False)

        End Sub
        Private Sub ButtonRightSection_RemoveAllProducts_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveAllProducts.Click

            DeleteAllBillingCoops()

        End Sub
        Private Sub ButtonRightSection_RemoveProducts_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveProducts.Click

            'objects
            Dim BillingCoops As Generic.List(Of AdvantageFramework.Database.Classes.BillingCoop) = Nothing
            Dim BillCoop As AdvantageFramework.Database.Classes.BillingCoop = Nothing
            Dim BillingCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing
            Dim RefreshBillingCoopList As Boolean = False
            Dim DeleteBillingCoop As Boolean = True
            Dim BillingCoopCodeExists As Boolean = True
            Dim RemainingBillingCoops As Generic.List(Of AdvantageFramework.Database.Classes.BillingCoop) = Nothing

            If DataGridViewRightSection_BillingCoopProducts.HasRows Then

                BillingCoops = DataGridViewRightSection_BillingCoopProducts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.BillingCoop)().ToList

                If DataGridViewRightSection_BillingCoopProducts.CurrentView.RowCount = BillingCoops.Count Then

                    DeleteAllBillingCoops()

                Else

                    If _BillingCoopCode <> "" Then

                        RemainingBillingCoops = DataGridViewRightSection_BillingCoopProducts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.BillingCoop)().ToList

                        For Each BillingCoopClass In RemainingBillingCoops.ToList

                            If BillingCoops.Contains(BillingCoopClass) Then

                                RemainingBillingCoops.Remove(BillingCoopClass)

                            End If

                        Next

                        If RemainingBillingCoops.Select(Function(Entity) Entity.Percent).Sum <> 100 Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please update the percent on each remaining products to equal 100 before removing the product.")
                            DeleteBillingCoop = False

                        Else

                            For Each BillingCoopClass In BillingCoops

                                BillingCoopClass.Percent = 0

                            Next

                            Try

                                Save()

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                    If DeleteBillingCoop Then

                        AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Deleting...")

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                For Each BillCoop In BillingCoops

                                    If _BillingCoopCode <> "" Then

                                        Try

                                            BillingCoop = (From Entity In AdvantageFramework.Database.Procedures.BillingCoop.LoadByBillingCoopCode(DbContext, _BillingCoopCode).ToList
                                                           Where Entity.Code = BillCoop.Code AndAlso
                                                                 Entity.ClientCode = BillCoop.GetBillingCoop.ClientCode AndAlso
                                                                 Entity.DivisionCode = BillCoop.GetBillingCoop.DivisionCode AndAlso
                                                                 Entity.ProductCode = BillCoop.GetBillingCoop.ProductCode
                                                           Select Entity).FirstOrDefault

                                        Catch ex As Exception
                                            BillingCoop = Nothing
                                        End Try

                                        If BillingCoop IsNot Nothing AndAlso AdvantageFramework.Database.Procedures.BillingCoop.Delete(DbContext, BillingCoop) Then

                                            RefreshBillingCoopList = True

                                        End If

                                    Else

                                        _BillingCoopList.Remove(BillCoop.GetBillingCoop)

                                    End If

                                Next

                            End Using

                        Catch ex As Exception

                        End Try

                        AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                        If RefreshBillingCoopList Then

                            GetUpdatedBillingCoopList()

                            If _BillingCoopList Is Nothing OrElse _BillingCoopList.Count = 0 Then

                                BillingCoopCodeExists = False

                            End If

                        End If

                        If BillingCoopCodeExists Then

                            LoadBillCoopProducts()

                        Else

                            RaiseEvent SelectedCodeDeletedEvent()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_BillingCoopProducts_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewRightSection_BillingCoopProducts.CustomSummaryCalculateEvent

            Dim TotalPercent As Decimal = Nothing

            Try

                TotalPercent = DataGridViewRightSection_BillingCoopProducts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.BillingCoop)().Select(Function(BillingCoop) BillingCoop.Percent).Sum

            Catch ex As Exception
                TotalPercent = Nothing
            End Try

            e.TotalValue = TotalPercent

            RaiseEvent TotalPercentChangedEvent(TotalPercent)

            DataGridViewRightSection_BillingCoopProducts.CurrentView.BestFitColumns()

        End Sub
        Private Sub DeleteAllBillingCoops()

            'objects
            Dim BillingCoops As Generic.List(Of AdvantageFramework.Database.Classes.BillingCoop) = Nothing
            Dim BillingCoop As AdvantageFramework.Database.Entities.BillingCoop = Nothing
            Dim BillCoop As AdvantageFramework.Database.Classes.BillingCoop = Nothing
            Dim RefreshBillingCoopList As Boolean = False
            Dim DeleteBillingCoop As Boolean = True
            Dim BillingCoopCodeExists As Boolean = True

            If DataGridViewRightSection_BillingCoopProducts.HasRows Then

                If _BillingCoopCode <> "" Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Removing all products will delete the billing coop code completely. Do you want to continue?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.No Then

                        DeleteBillingCoop = False

                    End If

                End If

                If DeleteBillingCoop Then

                    AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                    AdvantageFramework.WinForm.Presentation.ShowWaitForm("Deleting...")

                    Try

                        If _BillingCoopCode <> "" Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.BillingCoop.Delete(DbContext, _BillingCoopCode) Then

                                    RefreshBillingCoopList = True

                                End If

                            End Using

                        Else

                            BillingCoops = DataGridViewRightSection_BillingCoopProducts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.BillingCoop)().ToList

                            For Each BillCoop In BillingCoops

                                _BillingCoopList.Remove(BillCoop.GetBillingCoop)

                            Next

                        End If

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                    If RefreshBillingCoopList Then

                        GetUpdatedBillingCoopList()

                        If _BillingCoopList Is Nothing OrElse _BillingCoopList.Count = 0 Then

                            BillingCoopCodeExists = False

                        End If

                    End If

                    If BillingCoopCodeExists Then

                        LoadBillCoopProducts()

                    Else

                        RaiseEvent SelectedCodeDeletedEvent()

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
