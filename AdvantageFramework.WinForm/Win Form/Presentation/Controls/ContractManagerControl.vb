Namespace WinForm.Presentation.Controls

    Public Class ContractManagerControl

        Public Event RowCountChangedEvent()
        Public Event SelectionChangedEvent()

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
        Private _CanUserUpdateInClientMaintenance As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property CanUserUpdateInClientMaintenance() As Boolean
            Get
                CanUserUpdateInClientMaintenance = _CanUserUpdateInClientMaintenance
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

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _CanUserUpdateInClientMaintenance = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)

                        DataGridViewControl_Contracts.MultiSelect = False

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadContracts()

            Dim Contracts As Generic.List(Of AdvantageFramework.Database.Entities.Contract) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    Contracts = AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList

                ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                    Contracts = AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode).ToList

                ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                    Contracts = AdvantageFramework.Database.Procedures.Contract.LoadByClientCode(DbContext, _ClientCode).ToList

                End If

            End Using

            DataGridViewControl_Contracts.DataSource = Contracts
            DataGridViewControl_Contracts.CurrentView.BestFitColumns()

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

            LoadContracts()

            DataGridViewControl_Contracts.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub AddContract()

            If AdvantageFramework.Maintenance.Client.Presentation.ContractEditDialog.ShowFormDialog(_ClientCode, _DivisionCode, _ProductCode, 0, False) = Windows.Forms.DialogResult.OK Then

                LoadContracts()

            End If

        End Sub
        Public Sub CopyContract()

            Dim ContractID As Integer = 0
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            If DataGridViewControl_Contracts.HasOnlyOneSelectedRow Then

                ContractID = DataGridViewControl_Contracts.GetFirstSelectedRowBookmarkValue(0)

                ClientCode = _ClientCode
                DivisionCode = _DivisionCode
                ProductCode = _ProductCode

                If AdvantageFramework.Maintenance.Client.Presentation.ContractEditDialog.ShowFormDialog(ClientCode, DivisionCode, ProductCode, ContractID, True) = Windows.Forms.DialogResult.OK Then

                    LoadContracts()

                End If

            End If

        End Sub
        Public Sub EditContract()

            Dim ContractID As Integer = 0

            If DataGridViewControl_Contracts.HasOnlyOneSelectedRow Then

                ContractID = DataGridViewControl_Contracts.GetFirstSelectedRowBookmarkValue(0)

                AdvantageFramework.Maintenance.Client.Presentation.ContractEditDialog.ShowFormDialog(_ClientCode, _DivisionCode, _ProductCode, ContractID, False)

                LoadContracts()

            End If

        End Sub
        Public Function DeleteSelectedContract() As Boolean

            'objects
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
            Dim ContractID As Long = 0
            Dim Deleted As Boolean = False

            If DataGridViewControl_Contracts.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ContractID = DataGridViewControl_Contracts.GetFirstSelectedRowBookmarkValue(0)

                            Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, ContractID)

                            If Contract IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.Contract.Delete(DbContext, Contract) = False Then

                                    AdvantageFramework.WinForm.MessageBox.Show("The contract is in use and cannot be deleted.")

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

            DataGridViewControl_Contracts.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.Contract))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ContractManagerControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



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
