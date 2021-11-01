Namespace WinForm.Presentation.Controls

    Public Class VendorContractManagerControl

        Public Event RowCountChangedEvent()
        Public Event SelectionChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _VendorCode As String = Nothing
        Private _CanUserUpdateInVendorMaintenance As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property CanUserUpdateInVendorMaintenance() As Boolean
            Get
                CanUserUpdateInVendorMaintenance = _CanUserUpdateInVendorMaintenance
            End Get
        End Property
        Public ReadOnly Property ContractsDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                ContractsDataGridView = DataGridViewControl_Contracts
            End Get
        End Property
        Public ReadOnly Property HasASelectedContract As Boolean
            Get
                HasASelectedContract = DataGridViewControl_Contracts.HasASelectedRow
            End Get
        End Property
        Public ReadOnly Property HasOnlyOneSelectedContract As Boolean
            Get
                HasOnlyOneSelectedContract = DataGridViewControl_Contracts.HasOnlyOneSelectedRow
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

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _CanUserUpdateInVendorMaintenance = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)

                        DataGridViewControl_Contracts.MultiSelect = False

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadContracts()

            Dim VendorContracts As Generic.List(Of AdvantageFramework.Database.Entities.VendorContract) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _VendorCode <> "" Then

                    VendorContracts = AdvantageFramework.Database.Procedures.VendorContract.LoadByVendorCode(DbContext, _VendorCode).ToList

                End If

            End Using

            DataGridViewControl_Contracts.DataSource = VendorContracts
            DataGridViewControl_Contracts.CurrentView.BestFitColumns()

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal VendorCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _VendorCode = VendorCode

            LoadContracts()

            DataGridViewControl_Contracts.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub AddContract()

            If AdvantageFramework.Maintenance.Accounting.Presentation.VendorContractEditDialog.ShowFormDialog(_VendorCode, 0, False) = Windows.Forms.DialogResult.OK Then

                LoadContracts()

            End If

        End Sub
        Public Sub CopyContract()

            Dim ContractID As Integer = 0
            Dim VendorCode As String = Nothing

            If DataGridViewControl_Contracts.HasOnlyOneSelectedRow Then

                ContractID = DataGridViewControl_Contracts.GetFirstSelectedRowBookmarkValue(0)

                VendorCode = _VendorCode

                If AdvantageFramework.Maintenance.Accounting.Presentation.VendorContractEditDialog.ShowFormDialog(VendorCode, ContractID, True) = Windows.Forms.DialogResult.OK Then

                    LoadContracts()

                End If

            End If

        End Sub
        Public Sub EditContract()

            Dim ContractID As Integer = 0

            If DataGridViewControl_Contracts.HasOnlyOneSelectedRow Then

                ContractID = DataGridViewControl_Contracts.GetFirstSelectedRowBookmarkValue(0)

                AdvantageFramework.Maintenance.Accounting.Presentation.VendorContractEditDialog.ShowFormDialog(_VendorCode, ContractID, False)

                LoadContracts()

            End If

        End Sub
        Public Function DeleteSelectedContract() As Boolean

            'objects
            Dim VendorContract As AdvantageFramework.Database.Entities.VendorContract = Nothing
            Dim ContractID As Long = 0
            Dim Deleted As Boolean = False

            If DataGridViewControl_Contracts.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ContractID = DataGridViewControl_Contracts.GetFirstSelectedRowBookmarkValue(0)

                            VendorContract = AdvantageFramework.Database.Procedures.VendorContract.LoadByID(DbContext, ContractID)

                            If VendorContract IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.VendorContract.Delete(DbContext, VendorContract) = False Then

                                    AdvantageFramework.WinForm.MessageBox.Show("The vendor contract is in use and cannot be deleted.")

                                End If

                                LoadContracts()

                            End If

                        End Using

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    Me.CloseWaitForm()

                End If

            End If

            DeleteSelectedContract = Deleted

        End Function
        Public Sub ClearControl()

            DataGridViewControl_Contracts.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.VendorContract))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub VendorContractManagerControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_Contracts_RowCountChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_Contracts.RowCountChangedEvent

            RaiseEvent RowCountChangedEvent()

        End Sub
        Private Sub DataGridViewControl_Contracts_RowDoubleClickEvent() Handles DataGridViewControl_Contracts.RowDoubleClickEvent

            EditContract()

        End Sub
        Private Sub DataGridViewControl_Contracts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_Contracts.SelectionChangedEvent

            RaiseEvent SelectionChangedEvent()

        End Sub

#End Region

#End Region

    End Class

End Namespace
