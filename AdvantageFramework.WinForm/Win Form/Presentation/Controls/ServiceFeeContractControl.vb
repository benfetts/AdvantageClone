Namespace WinForm.Presentation.Controls

    Public Class ServiceFeeContractControl

#Region " Events "

        Public Event SelectedContractChanged()
        Public Event CheckForUnsavedChangesEvent(ByRef Cancel As Boolean)
        Public Event ContractAddedEvent()

#End Region

#Region " Constants "


#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ServiceFeeContractID As Integer = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As Integer? = Nothing
        Private _JobComponentNumber As Integer? = Nothing
        Private _ShowAdditionalJobDataInGrid As Boolean = True
        Private _ShowDescriptions As Boolean = False
        Private _IsCopy As Boolean = False
        Private _IsAdding As Boolean = False
        Private _NewContractIDs As Generic.List(Of Integer) = Nothing
        Private _SecurityUpdateAllowed As Boolean = False
        Private _SecurityPrintAllowed As Boolean = False
        Private _SecurityAddAllowed As Boolean = False
        Private _SecurityGenerateFeesAllowed As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property DetailsDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                DetailsDataGridView = DataGridViewForm_Contracts
            End Get
        End Property
        Public ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        Public ReadOnly Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        Public ReadOnly Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
        End Property
        Public ReadOnly Property JobNumber As Integer?
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        Public ReadOnly Property JobComponentNumber As Integer?
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
        End Property
        Public Property ShowAdditionalJobDataInGrid As Boolean
            Get
                ShowAdditionalJobDataInGrid = _ShowAdditionalJobDataInGrid
            End Get
            Set(value As Boolean)
                _ShowAdditionalJobDataInGrid = value
                ReloadDataGridViewColumns()
            End Set
        End Property
        Public Property AllowAddNew As Boolean
            Get
                AllowAddNew = If(DataGridViewForm_Contracts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None, False, True)
            End Get
            Set(value As Boolean)

                If value = True AndAlso _SecurityAddAllowed = True Then

                    DataGridViewForm_Contracts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                Else

                    DataGridViewForm_Contracts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                End If

            End Set
        End Property
        Public Property ShowDescriptions As Boolean
            Get
                ShowDescriptions = _ShowDescriptions
            End Get
            Set(value As Boolean)

                _ShowDescriptions = value

                ReloadDataGridViewColumns()

            End Set
        End Property
        Public ReadOnly Property SelectedContractID As Integer
            Get

                'objects
                Dim ContractID As Integer = Nothing

                If DataGridViewForm_Contracts.HasOnlyOneSelectedRow Then

                    ContractID = CInt(DataGridViewForm_Contracts.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ID.ToString))

                End If

                SelectedContractID = ContractID

            End Get
        End Property
        Public ReadOnly Property SecurityAddAllowed As Boolean
            Get
                SecurityAddAllowed = _SecurityAddAllowed
            End Get
        End Property
        Public ReadOnly Property SecurityUpdateAllowed As Boolean
            Get
                SecurityUpdateAllowed = _SecurityUpdateAllowed
            End Get
        End Property
        Public ReadOnly Property SecurityPrintAllowed As Boolean
            Get
                SecurityPrintAllowed = _SecurityPrintAllowed
            End Get
        End Property
        Public ReadOnly Property SecurityGenerateFeesAllowed As Boolean
            Get
                SecurityGenerateFeesAllowed = _SecurityGenerateFeesAllowed
            End Get
        End Property
        Public ReadOnly Property CanViewOrGenerateFees As Boolean
            Get

                'objects
                Dim ViewOrGenerateFees As Boolean = False

                Try

                    If DataGridViewForm_Contracts.HasASelectedRow Then

                        ViewOrGenerateFees = (From Entity In DataGridViewForm_Contracts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)() _
                                              Where Entity.ID > 0 _
                                              Select Entity).Any

                    End If

                Catch ex As Exception
                    ViewOrGenerateFees = False
                Finally
                    CanViewOrGenerateFees = ViewOrGenerateFees
                End Try

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

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                DataGridViewForm_Contracts.AutoloadRepositoryDatasource = True
                                DataGridViewForm_Contracts.AutoFilterLookupColumns = True

                                _SecurityUpdateAllowed = AdvantageFramework.Security.CanUserUpdateInModule(_Session, Security.Modules.FinanceAccounting_ServiceFees)
                                _SecurityPrintAllowed = AdvantageFramework.Security.CanUserPrintInModule(_Session, Security.Modules.FinanceAccounting_ServiceFees)
                                _SecurityAddAllowed = AdvantageFramework.Security.CanUserAddInModule(_Session, Security.Modules.FinanceAccounting_ServiceFees)
                                _SecurityGenerateFeesAllowed = AdvantageFramework.Security.CanUserAddInModule(_Session, Security.Modules.FinanceAccounting_IncomeOnly)

                                Me.AllowAddNew = _SecurityAddAllowed

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub CalculateNumberOfFees(ByVal JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)

            'objects
            Dim NumberOfFees As Integer = Nothing
            Dim Divisor As Integer = Nothing

            If JobComponentServiceFeeContract IsNot Nothing Then

                If JobComponentServiceFeeContract.FeeStartDate.HasValue AndAlso JobComponentServiceFeeContract.FeeEndDate.HasValue Then

                    If JobComponentServiceFeeContract.FeeStartDate <= JobComponentServiceFeeContract.FeeEndDate Then

                        Select Case JobComponentServiceFeeContract.Frequency.GetValueOrDefault(0)

                            Case Database.Entities.ServiceFeeFrequency.Annually

                                Divisor = 365

                            Case Database.Entities.ServiceFeeFrequency.Monthly

                                Divisor = 30

                            Case Database.Entities.ServiceFeeFrequency.Weekly

                                Divisor = 7

                        End Select

                        If Divisor > 0 Then

                            NumberOfFees = CInt(Math.Round((JobComponentServiceFeeContract.FeeEndDate.Value - JobComponentServiceFeeContract.FeeStartDate.Value).Days / Divisor, 0, MidpointRounding.AwayFromZero))

                        End If

                    End If

                End If

                JobComponentServiceFeeContract.NumberOfFees = NumberOfFees

            End If

        End Sub
        Protected Sub SetNumberOfFeesAndContractMaximum(ByVal JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)

            CalculateNumberOfFees(JobComponentServiceFeeContract)
            CalculateContractMaximum(JobComponentServiceFeeContract)

        End Sub
        Protected Sub CalculateContractMaximum(ByVal JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)

            'objects
            Dim MaximumContractValue As Decimal = Nothing

            If JobComponentServiceFeeContract IsNot Nothing Then

                MaximumContractValue = JobComponentServiceFeeContract.NumberOfFees.GetValueOrDefault(0) * JobComponentServiceFeeContract.FeeAmount.GetValueOrDefault(0)

                JobComponentServiceFeeContract.MaxAmount = MaximumContractValue

            End If

        End Sub
        Protected Sub CalculateQuantityRateAmount(ByVal JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract, ByVal FieldChanged As BillingSystem.QtyRateAmount)

            If JobComponentServiceFeeContract IsNot Nothing Then

                AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(JobComponentServiceFeeContract.Quantity, JobComponentServiceFeeContract.Rate, JobComponentServiceFeeContract.FeeAmount, FieldChanged, 2, 4, 2, False)

            End If

        End Sub
        Protected Sub CalculateContract(ByVal JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract, ByVal FieldChanged As BillingSystem.QtyRateAmount)

            If JobComponentServiceFeeContract IsNot Nothing Then

                CalculateQuantityRateAmount(JobComponentServiceFeeContract, FieldChanged)
                CalculateContractMaximum(JobComponentServiceFeeContract)

            End If

        End Sub
        Protected Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _IsAdding Then

                    DataGridViewForm_Contracts.DataSource = (From Entity In AdvantageFramework.IncomeOnly.LoadContracts(DbContext, _ServiceFeeContractID, _ClientCode, _DivisionCode, _ProductCode, _JobNumber, _JobComponentNumber)
                                                             Where _NewContractIDs.Contains(Entity.ID)
                                                             Select Entity
                                                             Order By Entity.ID).ToList

                Else

                    DataGridViewForm_Contracts.DataSource = AdvantageFramework.IncomeOnly.LoadContracts(DbContext, _ServiceFeeContractID, _ClientCode, _DivisionCode, _ProductCode, _JobNumber, _JobComponentNumber).OrderBy(Function(Contract) Contract.ID).ToList

                End If

            End Using

            DataGridViewForm_Contracts.CurrentView.BestFitColumns()

        End Sub
        Protected Sub EnableOrDisableActions()



        End Sub
        Protected Function GenerateFees(ByVal ShowMissing As Boolean, ByVal JobServiceFeeContractID As Integer) As Boolean

            'objects
            Dim Generated As Boolean = False

            If JobServiceFeeContractID > 0 Then

                If AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeListDialog.ShowFormDialog(JobServiceFeeContractID, ShowMissing) = Windows.Forms.DialogResult.OK Then

                    If ShowMissing Then

                        Generated = True

                    End If

                End If

                RefreshHasRecordsData(False)

            End If

            GenerateFees = Generated

        End Function
        Protected Function GenerateFees(ByVal ShowMissing As Boolean, ByVal JobServiceFeeContractIDs As Integer()) As Boolean

            'objects
            Dim Generated As Boolean = False

            If JobServiceFeeContractIDs IsNot Nothing AndAlso JobServiceFeeContractIDs.Count > 0 Then

                If _SecurityGenerateFeesAllowed = False Then

                    ShowMissing = False

                End If

                If AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeListDialog.ShowFormDialog(JobServiceFeeContractIDs, ShowMissing) = Windows.Forms.DialogResult.OK Then

                    If ShowMissing Then

                        Generated = True

                        RefreshHasRecordsData(False)

                    End If

                End If

            End If

            GenerateFees = Generated

        End Function
        Protected Sub RefreshHasRecordsData(ByVal AllRows As Boolean)

            'objects
            Dim JobComponentServiceFeeContractList As Generic.List(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) = Nothing
            Dim IncomeOnlyList As Generic.List(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly) = Nothing
            Dim GeneratedCount As Integer = Nothing

            If AllRows Then

                JobComponentServiceFeeContractList = DataGridViewForm_Contracts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract).ToList

            Else

                JobComponentServiceFeeContractList = DataGridViewForm_Contracts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract).ToList

            End If

            If JobComponentServiceFeeContractList IsNot Nothing AndAlso JobComponentServiceFeeContractList.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each JobComponentServiceFeeContract In JobComponentServiceFeeContractList

                        Try

                            IncomeOnlyList = (From Entity In AdvantageFramework.IncomeOnly.Search(DbContext, JobComponentServiceFeeContract.ClientCode, JobComponentServiceFeeContract.DivisionCode, JobComponentServiceFeeContract.ProductCode, JobComponentServiceFeeContract.JobNumber, JobComponentServiceFeeContract.JobComponentNumber, False, Nothing)
                                              Where Entity.JobServiceFeeID = JobComponentServiceFeeContract.ID
                                              Select Entity).ToList

                            If IncomeOnlyList IsNot Nothing AndAlso IncomeOnlyList.Count > 0 Then

                                JobComponentServiceFeeContract.HasRecords = True

                                Try

                                    JobComponentServiceFeeContract.LastRecordGenerated = (From Entity In IncomeOnlyList
                                                                                          Where Entity.InvoiceDate.HasValue = True
                                                                                          Select Entity.InvoiceDate).Max

                                Catch ex As Exception
                                    JobComponentServiceFeeContract.LastRecordGenerated = Nothing
                                End Try

                                JobComponentServiceFeeContract.MissingRecords = JobComponentServiceFeeContract.NumberOfFees.GetValueOrDefault(0) - IncomeOnlyList.Count

                            Else

                                JobComponentServiceFeeContract.HasRecords = False
                                JobComponentServiceFeeContract.LastRecordGenerated = Nothing
                                JobComponentServiceFeeContract.MissingRecords = JobComponentServiceFeeContract.NumberOfFees

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                End Using

                DataGridViewForm_Contracts.CurrentView.RefreshData()

            End If

        End Sub
        Protected Sub ReloadDataGridViewColumns()

            'objects
            Dim ShowClient As Boolean = False
            Dim ShowDivision As Boolean = False
            Dim ShowProduct As Boolean = False
            Dim ShowJob As Boolean = False
            Dim ShowComponent As Boolean = False
            Dim ShowDescriptions As Boolean = False
            Dim VisibleIndex As Integer = 1

            If DataGridViewForm_Contracts.Columns IsNot Nothing AndAlso DataGridViewForm_Contracts.Columns.Count > 0 Then

                DataGridViewForm_Contracts.CurrentView.BeginUpdate()

                For Each GridColumn In DataGridViewForm_Contracts.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    GridColumn.Visible = False

                Next

                If _JobComponentNumber.GetValueOrDefault(0) > 0 Then

                    ShowClient = False
                    ShowDivision = False
                    ShowProduct = False
                    ShowJob = False
                    ShowComponent = False

                ElseIf _JobNumber.GetValueOrDefault(0) > 0 Then

                    ShowClient = False
                    ShowDivision = False
                    ShowProduct = False
                    ShowJob = False
                    ShowComponent = True

                ElseIf String.IsNullOrWhiteSpace(_ClientCode) = False AndAlso String.IsNullOrWhiteSpace(_DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(_ProductCode) = False Then

                    ShowClient = False
                    ShowDivision = False
                    ShowProduct = False
                    ShowJob = True
                    ShowComponent = True

                ElseIf String.IsNullOrWhiteSpace(_ClientCode) = False AndAlso String.IsNullOrWhiteSpace(_DivisionCode) = False Then

                    ShowClient = False
                    ShowDivision = False
                    ShowProduct = True
                    ShowJob = True
                    ShowComponent = True

                ElseIf String.IsNullOrWhiteSpace(_ClientCode) = False Then

                    ShowClient = False
                    ShowDivision = True
                    ShowProduct = True
                    ShowJob = True
                    ShowComponent = True

                Else

                    ShowClient = True
                    ShowDivision = True
                    ShowProduct = True
                    ShowJob = True
                    ShowComponent = True

                End If

                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.OfficeCode.ToString, False, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.OfficeName.ToString, False, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ClientCode.ToString, ShowClient, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ClientName.ToString, ShowClient AndAlso _ShowDescriptions, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.DivisionCode.ToString, ShowDivision, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.DivisionName.ToString, ShowDivision AndAlso _ShowDescriptions, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ProductCode.ToString, ShowProduct, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ProductName.ToString, ShowProduct AndAlso _ShowDescriptions, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ID.ToString, False, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeDescription.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.JobNumber.ToString, ShowJob, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.JobDescription.ToString, ShowJob AndAlso _ShowDescriptions, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.JobComponentNumber.ToString, ShowComponent, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.JobComponentDescription.ToString, ShowComponent AndAlso _ShowDescriptions, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.IsServiceFeeJob.ToString, _ShowAdditionalJobDataInGrid, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ServiceFeeTypeID.ToString, False, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ServiceFeeTypeCode.ToString, _ShowAdditionalJobDataInGrid, VisibleIndex, True)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ServiceFeeTypeDescription.ToString, _ShowAdditionalJobDataInGrid AndAlso _ShowDescriptions, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.SalesClassCode.ToString, _ShowAdditionalJobDataInGrid, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.SalesClassDescription.ToString, _ShowAdditionalJobDataInGrid AndAlso _ShowDescriptions, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.AccountExecutiveCode.ToString, _ShowAdditionalJobDataInGrid, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.AccountExecutiveName.ToString, _ShowAdditionalJobDataInGrid AndAlso _ShowDescriptions, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeStartDate.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeEndDate.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Frequency.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.NumberOfFees.ToString, True, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FunctionCode.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FunctionDescription.ToString, _ShowDescriptions, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Quantity.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Rate.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeAmount.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.MaxAmount.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ClientComments.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ContractNotes.ToString, True, VisibleIndex)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.HasRecords.ToString, Not _IsCopy, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.LastRecordGenerated.ToString, Not _IsCopy, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.CreatedDate.ToString, Not _IsCopy, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.CreatedBy.ToString, Not _IsCopy, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ModifiedDate.ToString, Not _IsCopy, VisibleIndex, False)
                ModifyColumn(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ModifiedBy.ToString, Not _IsCopy, VisibleIndex, False)

                DataGridViewForm_Contracts.CurrentView.EndUpdate()

                DataGridViewForm_Contracts.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub ModifyColumn(ByVal FieldName As String, ByVal Visible As Boolean, ByRef VisibleIndex As Integer, Optional ByVal AllowFocus As Boolean = True)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If DataGridViewForm_Contracts.CurrentView.Columns(FieldName) IsNot Nothing Then

                GridColumn = DataGridViewForm_Contracts.CurrentView.Columns(FieldName)

                GridColumn.Visible = Visible
                GridColumn.OptionsColumn.AllowFocus = AllowFocus

                If Visible Then

                    GridColumn.VisibleIndex = VisibleIndex

                    VisibleIndex = VisibleIndex + 1

                End If

            End If

        End Sub

#Region "  Public "

        Public Function Add() As Boolean

            'objects
            Dim Added As Boolean = False
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing

            Try

                If DataGridViewForm_Contracts.HasRows Then

                    DataGridViewForm_Contracts.CurrentView.CloseEditorForUpdating()

                    DataGridViewForm_Contracts.ValidateAllRows()

                    If DataGridViewForm_Contracts.HasAnyInvalidRows = False Then

                        Added = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each JobComponentServiceFeeContract In DataGridViewForm_Contracts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)()

                                JobServiceFee = JobComponentServiceFeeContract.GetJobServiceFeeEntity()

                                JobServiceFee.DbContext = DbContext

                                JobServiceFee.FeeType = 0
                                JobServiceFee.FeeSetupDate = System.DateTime.Today
                                JobServiceFee.Media = 0
                                JobServiceFee.Production = 0
                                JobServiceFee.EmployeeTime = 0

                                If AdvantageFramework.Database.Procedures.JobServiceFee.Insert(DbContext, JobServiceFee) Then

                                    _NewContractIDs.Add(JobServiceFee.ID)

                                Else

                                    Added = False

                                End If

                            Next

                        End Using

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please fix invalid row(s).")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please enter at least one service fee contract.")

                End If

            Catch ex As Exception
                Added = False
            Finally
                Add = Added
            End Try

        End Function
        Public Function Save(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim JobNumber As Integer = Nothing
            Dim ComponentNumber As Integer = Nothing
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract = Nothing
            Dim JobComponentServiceFeeContractList As Generic.List(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) = Nothing

            Try

                DataGridViewForm_Contracts.CurrentView.CloseEditorForUpdating()

                If DataGridViewForm_Contracts.HasAnyInvalidRows = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobComponentServiceFeeContractList = DataGridViewForm_Contracts.GetAllModifiedRows.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)().ToList

                        If JobComponentServiceFeeContractList IsNot Nothing AndAlso JobComponentServiceFeeContractList.Count > 0 Then

                            For Each JobComponentServiceFeeContract In JobComponentServiceFeeContractList

                                JobServiceFee = AdvantageFramework.Database.Procedures.JobServiceFee.LoadByID(DbContext, JobComponentServiceFeeContract.ID)

                                If JobServiceFee IsNot Nothing Then

                                    JobServiceFee.Description = JobComponentServiceFeeContract.FeeDescription
                                    JobServiceFee.JobNumber = JobComponentServiceFeeContract.JobNumber
                                    JobServiceFee.JobComponentNumber = JobComponentServiceFeeContract.JobComponentNumber
                                    'JobServiceFee.FeeSetupDate = JobComponentServiceFeeContract.date
                                    JobServiceFee.FeeStartDate = JobComponentServiceFeeContract.FeeStartDate
                                    JobServiceFee.FeeEndDate = JobComponentServiceFeeContract.FeeEndDate
                                    JobServiceFee.Frequency = JobComponentServiceFeeContract.Frequency
                                    JobServiceFee.NumberOfFees = JobComponentServiceFeeContract.NumberOfFees
                                    JobServiceFee.FeeType = 0
                                    'JobServiceFee.Media = JobComponentServiceFeeContract.
                                    'JobServiceFee.Production = JobComponentServiceFeeContract.Production
                                    'JobServiceFee.EmployeeTime = JobComponentServiceFeeContract.EmployeeTime
                                    JobServiceFee.FunctionCode = JobComponentServiceFeeContract.FunctionCode
                                    JobServiceFee.Quantity = JobComponentServiceFeeContract.Quantity
                                    JobServiceFee.Rate = JobComponentServiceFeeContract.Rate
                                    JobServiceFee.FeeAmount = JobComponentServiceFeeContract.FeeAmount
                                    JobServiceFee.MaxAmount = JobComponentServiceFeeContract.MaxAmount
                                    JobServiceFee.ContractInfo = JobComponentServiceFeeContract.ContractNotes
                                    JobServiceFee.ClientComment = JobComponentServiceFeeContract.ClientComments
                                    JobServiceFee.CreateDate = JobComponentServiceFeeContract.CreatedDate
                                    JobServiceFee.CreatedBy = JobComponentServiceFeeContract.CreatedBy
                                    JobServiceFee.ModifiedDate = JobComponentServiceFeeContract.ModifiedDate
                                    JobServiceFee.ModifiedBy = JobComponentServiceFeeContract.ModifiedBy

                                    If AdvantageFramework.Database.Procedures.JobServiceFee.Update(DbContext, JobServiceFee) Then

                                        Saved = True

                                    End If

                                End If

                            Next

                            If DataGridViewForm_Contracts.CurrentView.Columns(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.IsServiceFeeJob.ToString).Visible OrElse
                               DataGridViewForm_Contracts.CurrentView.Columns(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ServiceFeeTypeID.ToString).Visible OrElse
                               DataGridViewForm_Contracts.CurrentView.Columns(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ServiceFeeTypeCode.ToString).Visible Then

                                For Each JobNumber In (From Entity In JobComponentServiceFeeContractList
                                                       Select [JN] = Entity.JobNumber).Distinct.ToArray

                                    For Each ComponentNumber In (From Entity In JobComponentServiceFeeContractList
                                                                 Where Entity.JobNumber = JobNumber
                                                                 Select [JC] = Entity.JobComponentNumber).Distinct.ToArray

                                        JobComponentServiceFeeContract = (From Entity In JobComponentServiceFeeContractList
                                                                          Where Entity.JobNumber = JobNumber AndAlso
                                                                                Entity.JobComponentNumber
                                                                          Select Entity).FirstOrDefault

                                        If JobComponentServiceFeeContract IsNot Nothing Then

                                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, ComponentNumber)

                                            If JobComponent IsNot Nothing Then

                                                JobComponent.ServiceFeeFlag = If(JobComponentServiceFeeContract.IsServiceFeeJob.GetValueOrDefault(False), 1, 0)
                                                JobComponent.ServiceFeeTypeID = JobComponentServiceFeeContract.ServiceFeeTypeID

                                                AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                                            End If

                                        End If

                                    Next

                                Next

                            End If

                        Else

                            Saved = True ' none to save

                        End If

                    End Using

                Else

                    ErrorMessage = "Please fix invalid row(s)."

                End If

            Catch ex As Exception
                Saved = False
            Finally
                Save = Saved
            End Try

        End Function
        Public Function CopySelectedContract(Optional ByRef ContractID As Integer = Nothing, Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNumber As Integer = 0) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing
            Dim JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract = Nothing
            Dim NewJobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract = Nothing

            Try

                DataGridViewForm_Contracts.CurrentView.CloseEditorForUpdating()

                If DataGridViewForm_Contracts.HasOnlyOneSelectedRow Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            JobComponentServiceFeeContract = DirectCast(DataGridViewForm_Contracts.GetFirstSelectedRowDataBoundItem, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)

                        Catch ex As Exception

                        End Try

                        If JobComponentServiceFeeContract IsNot Nothing Then

                            If _IsAdding = False Then

                                JobServiceFee = New AdvantageFramework.Database.Entities.JobServiceFee

                                If JobNumber > 0 Then

                                    JobServiceFee.JobNumber = JobNumber

                                Else

                                    JobServiceFee.JobNumber = JobComponentServiceFeeContract.JobNumber

                                End If

                                If JobComponentNumber > 0 Then

                                    JobServiceFee.JobComponentNumber = JobComponentNumber

                                Else

                                    JobServiceFee.JobComponentNumber = JobComponentServiceFeeContract.JobComponentNumber

                                End If

                                JobServiceFee.Description = JobComponentServiceFeeContract.FeeDescription
                                JobServiceFee.FeeAmount = JobComponentServiceFeeContract.FeeAmount
                                JobServiceFee.MaxAmount = JobComponentServiceFeeContract.MaxAmount
                                JobServiceFee.FeeStartDate = JobComponentServiceFeeContract.FeeStartDate
                                JobServiceFee.FeeEndDate = JobComponentServiceFeeContract.FeeEndDate
                                JobServiceFee.FunctionCode = JobComponentServiceFeeContract.FunctionCode
                                JobServiceFee.Frequency = JobComponentServiceFeeContract.Frequency
                                JobServiceFee.NumberOfFees = JobComponentServiceFeeContract.NumberOfFees
                                JobServiceFee.CreateDate = System.DateTime.Today
                                JobServiceFee.CreatedBy = _Session.UserCode

                                If AdvantageFramework.Database.Procedures.JobServiceFee.Insert(DbContext, JobServiceFee) Then

                                    ContractID = JobServiceFee.ID

                                    Copied = True
                                    'LoadControl(_ServiceFeeContractID, _ClientCode, _DivisionCode, _ProductCode, _JobNumber.GetValueOrDefault(0), _JobComponentNumber.GetValueOrDefault(0), False)

                                End If

                            Else

                                NewJobComponentServiceFeeContract = New AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract

                                NewJobComponentServiceFeeContract.FeeDescription = JobComponentServiceFeeContract.FeeDescription
                                NewJobComponentServiceFeeContract.OfficeCode = JobComponentServiceFeeContract.OfficeCode
                                NewJobComponentServiceFeeContract.OfficeName = JobComponentServiceFeeContract.OfficeName
                                NewJobComponentServiceFeeContract.ClientCode = JobComponentServiceFeeContract.ClientCode
                                NewJobComponentServiceFeeContract.ClientName = JobComponentServiceFeeContract.ClientName
                                NewJobComponentServiceFeeContract.DivisionCode = JobComponentServiceFeeContract.DivisionCode
                                NewJobComponentServiceFeeContract.DivisionName = JobComponentServiceFeeContract.DivisionName
                                NewJobComponentServiceFeeContract.ProductCode = JobComponentServiceFeeContract.ProductCode
                                NewJobComponentServiceFeeContract.ProductName = JobComponentServiceFeeContract.ProductName
                                NewJobComponentServiceFeeContract.JobNumber = JobComponentServiceFeeContract.JobNumber
                                NewJobComponentServiceFeeContract.JobDescription = JobComponentServiceFeeContract.JobDescription
                                NewJobComponentServiceFeeContract.JobComponentNumber = JobComponentServiceFeeContract.JobComponentNumber
                                NewJobComponentServiceFeeContract.JobComponentDescription = JobComponentServiceFeeContract.JobComponentDescription
                                NewJobComponentServiceFeeContract.IsServiceFeeJob = JobComponentServiceFeeContract.IsServiceFeeJob
                                NewJobComponentServiceFeeContract.ServiceFeeTypeID = JobComponentServiceFeeContract.ServiceFeeTypeID
                                NewJobComponentServiceFeeContract.ServiceFeeTypeCode = JobComponentServiceFeeContract.ServiceFeeTypeCode
                                NewJobComponentServiceFeeContract.ServiceFeeTypeDescription = JobComponentServiceFeeContract.ServiceFeeTypeDescription
                                NewJobComponentServiceFeeContract.SalesClassCode = JobComponentServiceFeeContract.SalesClassCode
                                NewJobComponentServiceFeeContract.SalesClassDescription = JobComponentServiceFeeContract.SalesClassDescription
                                NewJobComponentServiceFeeContract.AccountExecutiveCode = JobComponentServiceFeeContract.AccountExecutiveCode
                                NewJobComponentServiceFeeContract.AccountExecutiveName = JobComponentServiceFeeContract.AccountExecutiveName
                                NewJobComponentServiceFeeContract.FeeStartDate = JobComponentServiceFeeContract.FeeStartDate
                                NewJobComponentServiceFeeContract.FeeEndDate = JobComponentServiceFeeContract.FeeEndDate
                                NewJobComponentServiceFeeContract.Frequency = JobComponentServiceFeeContract.Frequency
                                NewJobComponentServiceFeeContract.NumberOfFees = JobComponentServiceFeeContract.NumberOfFees
                                NewJobComponentServiceFeeContract.FunctionCode = JobComponentServiceFeeContract.FunctionCode
                                NewJobComponentServiceFeeContract.FunctionDescription = JobComponentServiceFeeContract.FunctionDescription
                                NewJobComponentServiceFeeContract.Quantity = JobComponentServiceFeeContract.Quantity
                                NewJobComponentServiceFeeContract.Rate = JobComponentServiceFeeContract.Rate
                                NewJobComponentServiceFeeContract.FeeAmount = JobComponentServiceFeeContract.FeeAmount
                                NewJobComponentServiceFeeContract.MaxAmount = JobComponentServiceFeeContract.MaxAmount
                                NewJobComponentServiceFeeContract.ClientComments = JobComponentServiceFeeContract.ClientComments
                                NewJobComponentServiceFeeContract.ContractNotes = JobComponentServiceFeeContract.ContractNotes
                                NewJobComponentServiceFeeContract.HasRecords = False
                                NewJobComponentServiceFeeContract.LastRecordGenerated = Nothing
                                NewJobComponentServiceFeeContract.CreatedDate = System.DateTime.Today
                                NewJobComponentServiceFeeContract.CreatedBy = _Session.UserCode
                                NewJobComponentServiceFeeContract.ModifiedDate = Nothing
                                NewJobComponentServiceFeeContract.ModifiedBy = Nothing
                                NewJobComponentServiceFeeContract.MissingRecords = NewJobComponentServiceFeeContract.NumberOfFees

                                DirectCast(DirectCast(DataGridViewForm_Contracts.DataSource, System.Windows.Forms.BindingSource).DataSource, List(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)).Add(NewJobComponentServiceFeeContract)

                                DataGridViewForm_Contracts.CurrentView.RefreshData()

                                Copied = True

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopySelectedContract = Copied
            End Try

        End Function
        Public Function GenerateFees(ByVal ShowMissing As Boolean) As Boolean

            'objects
            Dim JobServiceFeeContractIDs As Integer() = Nothing
            Dim JobComponentServiceFeeContractList As Generic.List(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) = Nothing
            Dim Generated As Boolean = False

            Try

                If DataGridViewForm_Contracts.HasASelectedRow Then

                    JobComponentServiceFeeContractList = DataGridViewForm_Contracts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract).ToList

                    Generated = GenerateFees(ShowMissing, JobComponentServiceFeeContractList.Select(Function(Contract) Contract.ID).ToArray)

                End If

            Catch ex As Exception

            End Try

            GenerateFees = Generated

        End Function
        Public Function GenerateAllFees() As Boolean

            'objects
            Dim Generated As Boolean = False

            Try

                If AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeGenerationWizardDialog.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                    Generated = True

                    RefreshHasRecordsData(True)

                End If

            Catch ex As Exception

            End Try

            GenerateAllFees = Generated

        End Function
        Public Function LoadControl(Optional ByVal ServiceFeeContractID As Integer = 0, Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing,
                                    Optional ByRef ProductCode As String = Nothing, Optional ByVal JobNumber As Integer? = Nothing, Optional ByVal JobComponentNumber As Integer? = Nothing,
                                    Optional ByVal IsCopy As Boolean = False, Optional ByVal IsAdding As Boolean = False) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing
            Dim JobComponent As AdvantageFramework.Database.Views.JobComponentView = Nothing

            _ServiceFeeContractID = ServiceFeeContractID
            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _JobNumber = JobNumber.GetValueOrDefault(0)
            _JobComponentNumber = JobComponentNumber.GetValueOrDefault(0)
            _IsCopy = IsCopy
            _IsAdding = IsAdding

            If _NewContractIDs Is Nothing Then

                _NewContractIDs = New Generic.List(Of Integer)

            End If

            _NewContractIDs.Clear()

            If _ServiceFeeContractID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobServiceFee = AdvantageFramework.Database.Procedures.JobServiceFee.LoadByID(DbContext, ServiceFeeContractID)

                    If JobServiceFee IsNot Nothing Then

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, JobServiceFee.JobNumber, JobServiceFee.JobComponentNumber)

                        If JobComponent IsNot Nothing Then

                            _ClientCode = JobComponent.ClientCode
                            _DivisionCode = JobComponent.DivisionCode
                            _ProductCode = JobComponent.ProductCode
                            _JobNumber = JobComponent.JobNumber
                            _JobComponentNumber = JobComponent.JobComponentNumber

                        End If

                    End If

                End Using

                If _IsCopy Then

                    Me.AllowAddNew = False

                End If

            End If

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            DataGridViewForm_Contracts.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function DeleteContract() As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing
            Dim JobComponentServiceFeeContracts As Generic.List(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) = Nothing
            Dim DeletedCount As Integer = 0

            Try

                If _SecurityUpdateAllowed Then

                    If DataGridViewForm_Contracts.HasASelectedRow Then

                        If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                                JobComponentServiceFeeContracts = DataGridViewForm_Contracts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)().ToList

                                For Each JobComponentServiceFeeContract In JobComponentServiceFeeContracts

                                    If JobComponentServiceFeeContract.ID > 0 Then

                                        JobServiceFee = AdvantageFramework.Database.Procedures.JobServiceFee.LoadByID(DbContext, JobComponentServiceFeeContract.ID)

                                        If JobServiceFee IsNot Nothing Then

                                            If AdvantageFramework.Database.Procedures.JobServiceFee.Delete(DbContext, JobServiceFee) Then

                                                DataGridViewForm_Contracts.CurrentView.DeleteFromDataSource(JobComponentServiceFeeContract)
                                                DeletedCount = DeletedCount + 1

                                            End If

                                        End If

                                    Else

                                        DataGridViewForm_Contracts.CurrentView.DeleteFromDataSource(JobComponentServiceFeeContract)
                                        DeletedCount = DeletedCount + 1

                                    End If

                                Next

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                            End Using

                        End If

                    End If

                    If DeletedCount > 0 Then

                        Deleted = True

                    End If

                    If DeletedCount <> JobComponentServiceFeeContracts.Count Then

                        AdvantageFramework.Navigation.ShowMessageBox("One or more service fee contract could not be deleted.")

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteContract = Deleted
            End Try

        End Function
        Public Sub Cancel()

            DataGridViewForm_Contracts.CancelNewItemRow()

        End Sub
        Public Sub ShowContractDialog()

            'objects
            Dim JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract = Nothing

            If _ServiceFeeContractID <= 0 Then

                If DataGridViewForm_Contracts.HasOnlyOneSelectedRow Then

                    JobComponentServiceFeeContract = DataGridViewForm_Contracts.GetFirstSelectedRowDataBoundItem

                    If JobComponentServiceFeeContract IsNot Nothing Then

                        AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeContractDialog.ShowFormDialog(JobComponentServiceFeeContract.ID, False)

                        LoadGrid()

                    End If

                End If

            End If

        End Sub
        Public Function EditSelectedContract() As Boolean

            'objects
            Dim ContractID As Integer = Nothing
            Dim Edited As Boolean = False

            Try

                If DataGridViewForm_Contracts.HasOnlyOneSelectedRow Then

                    ContractID = CInt(DataGridViewForm_Contracts.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ID.ToString))

                    If AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeContractDialog.ShowFormDialog(ContractID, False) = Windows.Forms.DialogResult.OK Then

                        Edited = True

                    End If

                End If

            Catch ex As Exception
                Edited = False
            Finally
                EditSelectedContract = Edited
            End Try

        End Function
        Public Sub SelectContract(ByVal ContractID As Integer, ByVal ClearSelection As Boolean)

            'objects
            Dim JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract = Nothing

            Try

                For RowHandle = 0 To DataGridViewForm_Contracts.CurrentView.RowCount - 1

                    JobComponentServiceFeeContract = DataGridViewForm_Contracts.CurrentView.GetRow(RowHandle)

                    If JobComponentServiceFeeContract.ID = ContractID Then

                        DataGridViewForm_Contracts.CurrentView.SelectRow(RowHandle)

                        Exit For

                    ElseIf ClearSelection Then

                        DataGridViewForm_Contracts.CurrentView.UnselectRow(RowHandle)

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ServiceFeeContractControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewForm_Contracts_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Contracts.CellValueChangingEvent

            'objects
            Dim JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If DataGridViewForm_Contracts.IsNewItemRow(e.RowHandle) = False Then

                Try

                    JobComponentServiceFeeContract = DirectCast(DataGridViewForm_Contracts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)

                Catch ex As Exception
                    JobComponentServiceFeeContract = Nothing
                End Try

                If e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.IsServiceFeeJob.ToString Then

                    If JobComponentServiceFeeContract IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobComponentServiceFeeContract.JobNumber, JobComponentServiceFeeContract.JobComponentNumber)

                            If JobComponent IsNot Nothing Then

                                JobComponent.ServiceFeeFlag = If(CBool(e.Value) = True, 1, 0)

                                Saved = AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                            End If

                            If Saved Then

                                For Each ServiceFeeContract In (From Entity In DataGridViewForm_Contracts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)()
                                                                Where Entity.JobNumber = JobComponentServiceFeeContract.JobNumber
                                                                Select Entity).ToList

                                    ServiceFeeContract.IsServiceFeeJob = e.Value

                                Next

                                DataGridViewForm_Contracts.CurrentView.RefreshData()

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Contracts_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Contracts.DataSourceChangedEvent

            If DataGridViewForm_Contracts.Columns IsNot Nothing AndAlso DataGridViewForm_Contracts.Columns.Count > 0 Then

                ReloadDataGridViewColumns()

            End If

        End Sub
        Private Sub DataGridViewForm_Contracts_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_Contracts.AddNewRowEvent

            'objects
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing
            Dim JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract = Nothing

            If TypeOf RowObject Is AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract Then

                Me.ShowWaitForm("Processing...")

                JobComponentServiceFeeContract = RowObject

                JobServiceFee = JobComponentServiceFeeContract.GetJobServiceFeeEntity

                If JobServiceFee IsNot Nothing Then

                    RaiseEvent ContractAddedEvent()

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Contracts_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Contracts.CellValueChangedEvent

            'objects
            Dim JobComponentServiceFeeContract As AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract = Nothing
            Dim ServiceFeeType As AdvantageFramework.Database.Entities.ServiceFeeType = Nothing
            Dim ServiceFeeTypeDescription As String = Nothing
            Dim ServiceFeeTypeID As Integer? = Nothing

            If e.Column.FieldName <> AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ModifiedBy.ToString AndAlso
                e.Column.FieldName <> AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ModifiedDate.ToString Then

                Try

                    JobComponentServiceFeeContract = DirectCast(DataGridViewForm_Contracts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)

                Catch ex As Exception

                End Try

                If JobComponentServiceFeeContract IsNot Nothing Then

                    If e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeStartDate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeEndDate.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Frequency.ToString Then

                        SetNumberOfFeesAndContractMaximum(JobComponentServiceFeeContract)
                        DataGridViewForm_Contracts.CurrentView.RefreshRow(e.RowHandle)

                    ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeAmount.ToString Then

                        CalculateContract(JobComponentServiceFeeContract, BillingSystem.QtyRateAmount.Amount)
                        DataGridViewForm_Contracts.CurrentView.RefreshRow(e.RowHandle)

                    ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Quantity.ToString Then

                        CalculateContract(JobComponentServiceFeeContract, BillingSystem.QtyRateAmount.Quantity)
                        DataGridViewForm_Contracts.CurrentView.RefreshRow(e.RowHandle)

                    ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Rate.ToString Then

                        CalculateContract(JobComponentServiceFeeContract, BillingSystem.QtyRateAmount.Rate)
                        DataGridViewForm_Contracts.CurrentView.RefreshRow(e.RowHandle)

                    ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ServiceFeeTypeCode.ToString Then

                        If String.IsNullOrWhiteSpace(JobComponentServiceFeeContract.ServiceFeeTypeCode) = False Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                ServiceFeeType = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadByServiceFeeTypeCode(DbContext, JobComponentServiceFeeContract.ServiceFeeTypeCode)

                                If ServiceFeeType IsNot Nothing Then

                                    ServiceFeeTypeDescription = ServiceFeeType.Description
                                    ServiceFeeTypeID = ServiceFeeType.ID

                                End If

                            End Using

                        End If

                        For Each ServiceFeeContract In (From Entity In DataGridViewForm_Contracts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)()
                                                        Where Entity.JobNumber = JobComponentServiceFeeContract.JobNumber AndAlso
                                                              Entity.JobComponentNumber = JobComponentServiceFeeContract.JobComponentNumber AndAlso
                                                              Entity.ID <> JobComponentServiceFeeContract.ID
                                                        Select Entity).ToList

                            ServiceFeeContract.ServiceFeeTypeDescription = ServiceFeeTypeDescription
                            ServiceFeeContract.ServiceFeeTypeID = ServiceFeeTypeID
                            ServiceFeeContract.ServiceFeeTypeCode = JobComponentServiceFeeContract.ServiceFeeTypeCode

                        Next

                        DataGridViewForm_Contracts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ServiceFeeTypeID.ToString, ServiceFeeTypeID)
                        DataGridViewForm_Contracts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ServiceFeeTypeDescription.ToString, ServiceFeeTypeDescription)

                        DataGridViewForm_Contracts.CurrentView.RefreshData()

                    End If

                    If DataGridViewForm_Contracts.IsNewItemRow(e.RowHandle) = False Then

                        DataGridViewForm_Contracts.CurrentView.SetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ModifiedDate.ToString, System.DateTime.Today)
                        DataGridViewForm_Contracts.CurrentView.SetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ModifiedBy.ToString, _Session.UserCode)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Contracts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Contracts.InitNewRowEvent

            If String.IsNullOrWhiteSpace(_ClientCode) Then

                DataGridViewForm_Contracts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ClientCode.ToString, _ClientCode)

            End If

            If String.IsNullOrWhiteSpace(_DivisionCode) Then

                DataGridViewForm_Contracts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.DivisionCode.ToString, _DivisionCode)

            End If

            If String.IsNullOrWhiteSpace(_ProductCode) Then

                DataGridViewForm_Contracts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ProductCode.ToString, _ProductCode)

            End If

            If _JobNumber.HasValue Then

                DataGridViewForm_Contracts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.JobNumber.ToString, _JobNumber)

            End If

            If _JobComponentNumber.HasValue Then

                DataGridViewForm_Contracts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.JobComponentNumber.ToString, _JobComponentNumber)

            End If

            DataGridViewForm_Contracts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.CreatedBy.ToString, _Session.UserCode)
            DataGridViewForm_Contracts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.CreatedDate.ToString, System.DateTime.Today)

        End Sub
        Private Sub DataGridViewForm_Contracts_NewItemRowCanceledEvent() Handles DataGridViewForm_Contracts.NewItemRowCanceledEvent

            RaiseEvent SelectedContractChanged()

        End Sub
        Private Sub DataGridViewForm_Contracts_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_Contracts.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FunctionCode.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.FunctionView.LoadAllActive(DbContext)
                                  Where Entity.Type = "I"
                                  Select Entity).ToList

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_Contracts_RowDoubleClickEvent() Handles DataGridViewForm_Contracts.RowDoubleClickEvent

            If _IsCopy = False Then

                GenerateFees(False)

            End If

        End Sub
        Private Sub DataGridViewForm_Contracts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Contracts.SelectionChangedEvent

            RaiseEvent SelectedContractChanged()

        End Sub
        Private Sub DataGridViewForm_Contracts_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_Contracts.ShowingEditorEvent

            'objects
            Dim ContractID As Integer = Nothing
            Dim FocusedColumnFieldName As String = Nothing
            Dim EditableColumns As String() = Nothing

            FocusedColumnFieldName = DataGridViewForm_Contracts.CurrentView.FocusedColumn.FieldName

            If DataGridViewForm_Contracts.IsNewItemRow = False Then

                If _SecurityUpdateAllowed = False Then

                    e.Cancel = True

                ElseIf FocusedColumnFieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FunctionCode.ToString Then

                    If _IsCopy = False Then

                        ContractID = DataGridViewForm_Contracts.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ID.ToString)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If (From Entity In AdvantageFramework.Database.Procedures.IncomeOnly.Load(DbContext)
                                Where Entity.JobServiceFeeID = ContractID AndAlso
                                      (Entity.DeleteFlag Is Nothing OrElse
                                       Entity.DeleteFlag = 0)
                                Select Entity).Any Then

                                e.Cancel = True

                            End If

                        End Using

                    End If

                Else

                    EditableColumns = {AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeDescription.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ServiceFeeTypeCode.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.IsServiceFeeJob.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Frequency.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeAmount.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Quantity.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.Rate.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ClientComments.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ContractNotes.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeStartDate.ToString, _
                                       AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeEndDate.ToString}

                    e.Cancel = Not EditableColumns.Contains(FocusedColumnFieldName)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Contracts_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_Contracts.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ID.ToString AndAlso DataGridViewForm_Contracts.CurrentView.IsNewItemRow(DataGridViewForm_Contracts.CurrentView.GetRowHandle(e.ListSourceRowIndex)) Then

                e.DisplayText = " "

            End If

        End Sub
        Private Sub DataGridViewForm_Contracts_RepositoryDataSourceLoading(FieldName As String, ByRef Cancel As Boolean) Handles DataGridViewForm_Contracts.RepositoryDataSourceLoading

            If _IsAdding = False Then

                If FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ClientCode.ToString OrElse _
                    FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.DivisionCode.ToString OrElse _
                    FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.ProductCode.ToString OrElse _
                    FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.JobNumber.ToString OrElse _
                    FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.JobComponentNumber.ToString Then

                    Cancel = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
