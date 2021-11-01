Namespace WinForm.Presentation.Controls

    Public Class ProductMediaOverrideControl

        Public Event InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property CheckUserEntryChangedSetting As Boolean
            Get
                CheckUserEntryChangedSetting = DataGridViewForm_ProductMediaOverrides.UserEntryChanged
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    DataGridViewForm_ProductMediaOverrides.MultiSelect = True

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(ClientCode As String, DivisionCode As String, ProductCode As String)

            'objects
            Dim Loaded As Boolean = True

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewForm_ProductMediaOverrides.DataSource = AdvantageFramework.Database.Procedures.ProductMediaOverrides.LoadByClientDivisionProduct(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList

            End Using

            If DataGridViewForm_ProductMediaOverrides.CurrentView.Columns(AdvantageFramework.Database.Entities.ProductMediaOverrides.Properties.ClientCode.ToString) IsNot Nothing Then

                DataGridViewForm_ProductMediaOverrides.CurrentView.Columns(AdvantageFramework.Database.Entities.ProductMediaOverrides.Properties.ClientCode.ToString).Visible = False

            End If

            If DataGridViewForm_ProductMediaOverrides.CurrentView.Columns(AdvantageFramework.Database.Entities.ProductMediaOverrides.Properties.DivisionCode.ToString) IsNot Nothing Then

                DataGridViewForm_ProductMediaOverrides.CurrentView.Columns(AdvantageFramework.Database.Entities.ProductMediaOverrides.Properties.DivisionCode.ToString).Visible = False

            End If

            If DataGridViewForm_ProductMediaOverrides.CurrentView.Columns(AdvantageFramework.Database.Entities.ProductMediaOverrides.Properties.ProductCode.ToString) IsNot Nothing Then

                DataGridViewForm_ProductMediaOverrides.CurrentView.Columns(AdvantageFramework.Database.Entities.ProductMediaOverrides.Properties.ProductCode.ToString).Visible = False

            End If

            DataGridViewForm_ProductMediaOverrides.CurrentView.BestFitColumns()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            DataGridViewForm_ProductMediaOverrides.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ProductMediaOverrides))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub Delete()

            'objects
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_ProductMediaOverrides.HasASelectedRow Then

                DataGridViewForm_ProductMediaOverrides.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_ProductMediaOverrides.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    ProductMediaOverrides = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    ProductMediaOverrides = Nothing
                                End Try

                                If ProductMediaOverrides IsNot Nothing Then

                                    If ProductMediaOverrides.ID <> 0 AndAlso AdvantageFramework.Database.Procedures.ProductMediaOverrides.Delete(DbContext, ProductMediaOverrides) Then

                                        DataGridViewForm_ProductMediaOverrides.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    ElseIf ProductMediaOverrides.ID = 0 Then

                                        DataGridViewForm_ProductMediaOverrides.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                    If DataGridViewForm_ProductMediaOverrides.CheckForModifiedRows = False AndAlso
                            DataGridViewForm_ProductMediaOverrides.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ProductMediaOverrides).Where(Function(PMO) PMO.ID = 0).Any = False Then

                        DataGridViewForm_ProductMediaOverrides.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim ProductMediaOverridess As Generic.List(Of AdvantageFramework.Database.Entities.ProductMediaOverrides) = Nothing
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing
            Dim ErrorMessage As String = Nothing

            If DataGridViewForm_ProductMediaOverrides.HasRows Then

                DataGridViewForm_ProductMediaOverrides.CurrentView.CloseEditorForUpdating()

                ProductMediaOverridess = DataGridViewForm_ProductMediaOverrides.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ProductMediaOverrides)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each PMO In ProductMediaOverridess

                        If PMO.ID <> 0 Then 'existing row

                            ProductMediaOverrides = DbContext.ProductMediaOverrides.Find(PMO.ID)

                            If ProductMediaOverrides IsNot Nothing Then

                                If PMO.RebatePercent Is Nothing AndAlso PMO.MarkupPercent Is Nothing Then

                                    DbContext.ProductMediaOverrides.Remove(ProductMediaOverrides)

                                Else

                                    ProductMediaOverrides.RebatePercent = PMO.RebatePercent
                                    ProductMediaOverrides.MarkupPercent = PMO.MarkupPercent

                                End If

                            End If

                        ElseIf PMO.RebatePercent.HasValue OrElse PMO.MarkupPercent.HasValue Then

                            PMO.CreatedDate = Now

                            DbContext.ProductMediaOverrides.Add(PMO)

                        End If

                    Next

                    Try

                        DbContext.SaveChanges()

                    Catch ex As Exception
                        Saved = False
                    End Try

                End Using

                If Saved Then

                    DataGridViewForm_ProductMediaOverrides.ValidateAllRowsAndClearChanged(True)

                End If

                Me.CloseWaitForm()

            End If

            Save = Saved

        End Function
        Public Sub ExportProductMediaDetails()

            Dim ProductMediaOverridesList As Generic.List(Of AdvantageFramework.Database.Entities.ProductMediaOverrides) = Nothing

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                ProductMediaOverridesList = DataGridViewForm_ProductMediaOverrides.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ProductMediaOverrides).ToList

                DataGridViewForm_Export.DataSource = ProductMediaOverridesList

                DataGridViewForm_Export.Print(DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ProductMediaOverrideControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewForm_ProductMediaOverrides_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_ProductMediaOverrides.QueryPopupNeedDatasourceEvent

            'objects
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing

            If FieldName = AdvantageFramework.Database.Entities.ProductMediaOverrides.Properties.SalesClassCode.ToString Then

                Try

                    If TypeOf DataGridViewForm_ProductMediaOverrides.CurrentView.GetRow(DataGridViewForm_ProductMediaOverrides.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Entities.ProductMediaOverrides Then

                        ProductMediaOverrides = DataGridViewForm_ProductMediaOverrides.CurrentView.GetRow(DataGridViewForm_ProductMediaOverrides.CurrentView.FocusedRowHandle)

                    End If

                Catch ex As Exception
                    ProductMediaOverrides = Nothing
                End Try

                If ProductMediaOverrides IsNot Nothing AndAlso ProductMediaOverrides.MediaType <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActiveBySalesClassTypeCode(DbContext, ProductMediaOverrides.MediaType).ToList

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ProductMediaOverrides_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_ProductMediaOverrides.InitNewRowEvent

            'objects
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing

            Try

                If TypeOf DataGridViewForm_ProductMediaOverrides.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.ProductMediaOverrides Then

                    ProductMediaOverrides = DataGridViewForm_ProductMediaOverrides.CurrentView.GetRow(e.RowHandle)

                    ProductMediaOverrides.ClientCode = _ClientCode
                    ProductMediaOverrides.DivisionCode = _DivisionCode
                    ProductMediaOverrides.ProductCode = _ProductCode
                    ProductMediaOverrides.CreatedByUserCode = _Session.UserCode
                    ProductMediaOverrides.CreatedDate = Now

                End If

            Catch ex As Exception

            End Try

            RaiseEvent InitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewForm_ProductMediaOverrides_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_ProductMediaOverrides.AddNewRowEvent

            'objects
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ProductMediaOverrides Then

                Me.ShowWaitForm("Adding...")

                ProductMediaOverrides = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ProductMediaOverrides.IsEntityBeingAdded() Then

                        ProductMediaOverrides.DbContext = DbContext
                        ProductMediaOverrides.CreatedDate = Now

                        AdvantageFramework.Database.Procedures.ProductMediaOverrides.Insert(DbContext, ProductMediaOverrides)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_ProductMediaOverrides_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_ProductMediaOverrides.SelectionChangedEvent

            RaiseEvent SelectionChangedEvent(sender, e)

        End Sub

#End Region



#End Region

    End Class

End Namespace
