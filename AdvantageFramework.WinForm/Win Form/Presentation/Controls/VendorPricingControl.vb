Namespace WinForm.Presentation.Controls

    Public Class VendorPricingControl

        Public Event VendorPricingSelectionChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _VendorCode As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property HasASelectedPricing As Boolean
            Get
                HasASelectedPricing = DataGridViewForm_VendorPricings.HasASelectedRow
            End Get
        End Property
        Public ReadOnly Property IsNewItemRow As Boolean
            Get
                IsNewItemRow = DataGridViewForm_VendorPricings.CurrentView.IsNewItemRow(DataGridViewForm_VendorPricings.CurrentView.FocusedRowHandle)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            ''AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)



                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadVendorPricings()

            If String.IsNullOrEmpty(_VendorCode) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewForm_VendorPricings.DataSource = AdvantageFramework.Database.Procedures.VendorPricing.LoadByVendorCode(DbContext, _VendorCode).ToList

                End Using

            Else

                DataGridViewForm_VendorPricings.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.VendorPricing))

            End If

            DataGridViewForm_VendorPricings.HideOrShowColumn("DateCreated", False)
            DataGridViewForm_VendorPricings.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim VendorPricings As Generic.List(Of AdvantageFramework.Database.Entities.VendorPricing) = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = True

            Try

                DataGridViewForm_VendorPricings.CurrentView.CloseEditorForUpdating()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorPricings = DataGridViewForm_VendorPricings.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.VendorPricing)().ToList

                    For Each VendorPricing In VendorPricings

                        If AdvantageFramework.Database.Procedures.VendorPricing.Update(DbContext, VendorPricing) = False Then

                            DbContext.UndoChanges(VendorPricing)

                            Saved = False

                        End If

                    Next

                End Using

                DataGridViewForm_VendorPricings.ValidateAllRowsAndClearChanged()

                If Not Saved Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim VendorPricing As AdvantageFramework.Database.Entities.VendorPricing = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False
            Dim DisplayMessage As String = Nothing

            If DataGridViewForm_VendorPricings.HasASelectedRow Then

                If DataGridViewForm_VendorPricings.CurrentView.RowCount > 1 Then

                    DisplayMessage = "Are you sure you want to delete?"

                Else

                    DisplayMessage = "There is only one row for this pricing sheet. The entire pricing sheet will be deleted. Are you sure you want to delete?"

                End If

                If AdvantageFramework.Navigation.ShowMessageBox(DisplayMessage, WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            RowHandlesAndDataBoundItems = DataGridViewForm_VendorPricings.GetAllSelectedRowsRowHandlesAndDataBoundItems

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    VendorPricing = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    VendorPricing = Nothing
                                End Try

                                If VendorPricing IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorPricing.Delete(DbContext, VendorPricing) Then

                                        Deleted = True

                                        DataGridViewForm_VendorPricings.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                        If Deleted = False Then

                            ErrorMessage = "Failed trying to delete from the database. Please contact software support."

                        End If

                    Catch ex As Exception
                        ErrorMessage = "Failed trying to delete from the database. Please contact software support."
                    End Try

                End If

            Else

                ErrorMessage = "Please select a vendor pricing to delete."

            End If

            If ErrorMessage <> "" Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function LoadControl(ByVal VendorCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            _VendorCode = VendorCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _VendorCode <> "" Then

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, _VendorCode)

                    If Vendor IsNot Nothing Then

                        LoadVendorPricings()

                    Else

                        Loaded = False

                    End If

                Else

                    LoadVendorPricings()

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            _VendorCode = ""

            DataGridViewForm_VendorPricings.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.VendorPricing))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub CancelAddVendorPricing()

            DataGridViewForm_VendorPricings.CancelNewItemRow()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub VendorPricingControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewForm_VendorPricings_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_VendorPricings.AddNewRowEvent

            'objects
            Dim VendorPricing As AdvantageFramework.Database.Entities.VendorPricing = Nothing
            Dim VendorCode As String = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.VendorPricing Then

                Me.ShowWaitForm("Processing...")

                VendorPricing = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If VendorPricing.IsEntityBeingAdded() Then

                        VendorPricing.DbContext = DbContext
                        VendorPricing.CreatedBy = _Session.UserCode
                        VendorPricing.DateCreated = Now.ToShortDateString

                        AdvantageFramework.Database.Procedures.VendorPricing.Insert(DbContext, VendorPricing)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_VendorPricings_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_VendorPricings.SelectionChangedEvent

            RaiseEvent VendorPricingSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewForm_VendorPricings_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_VendorPricings.InitNewRowEvent

            If TypeOf DataGridViewForm_VendorPricings.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.VendorPricing Then

                DirectCast(DataGridViewForm_VendorPricings.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.VendorPricing).VendorCode = _VendorCode

            End If

            EnableOrDisableActions()

            RaiseEvent VendorPricingSelectionChangedEvent()

        End Sub

#End Region

#End Region

    End Class

End Namespace
