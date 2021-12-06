Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevExpress.XtraGrid.Views.Base

Namespace GeneralLedger.Reports.Presentation

    Public Class GeneralLedgerReportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SelectedOffices As Generic.List(Of String) = Nothing
        Private _SelectedDepartments As Generic.List(Of String) = Nothing
        Private _SelectedOtherCodes As Generic.List(Of String) = Nothing
        Private _SelectedBaseCodes As Generic.List(Of String) = Nothing
        Private _SelectedTypes As Generic.List(Of String) = Nothing
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _IsUserDefinedReport As Boolean = False
        Private _DynamicReportType As Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property
        Private ReadOnly Property SelectedReport As ReportWriter.Methods.StandardGeneralLedgerReports
            Get

                'objects
                Dim StandardGeneralLedgerReport As ReportWriter.Methods.StandardGeneralLedgerReports = Nothing

                Select Case ListBoxOptions_Reports.SelectedValue

                    Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountLandscape).Code

                        StandardGeneralLedgerReport = ReportWriter.Methods.StandardGeneralLedgerReports.DetailByAccountLandscape

                    Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountPortrait).Code

                        StandardGeneralLedgerReport = ReportWriter.Methods.StandardGeneralLedgerReports.DetailByAccountPortrait

                    Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.TrialBalance).Code

                        StandardGeneralLedgerReport = ReportWriter.Methods.StandardGeneralLedgerReports.TrialBalance

                    Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByTransaction).Code

                        StandardGeneralLedgerReport = ReportWriter.Methods.StandardGeneralLedgerReports.DetailByTransaction

                    Case Else

                        StandardGeneralLedgerReport = Nothing

                End Select

                SelectedReport = StandardGeneralLedgerReport

            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal IsUserDefinedReport As Boolean, ByVal DynamicReportType As Reporting.DynamicReports)

            ' This call is required by the designer.
            InitializeComponent()

            _ParameterDictionary = ParameterDictionary
            _IsUserDefinedReport = IsUserDefinedReport
            _DynamicReportType = DynamicReportType

        End Sub
        Private Sub LoadOfficeTab()

            'objects
            Dim Offices As Generic.Dictionary(Of String, AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _SelectedOffices Is Nothing Then

                    _SelectedOffices = New List(Of String)

                End If

                DataGridViewOfficeLeftSection_Offices.ItemDescription = "Office(s)"
                DataGridViewOfficeRightSection_Presets.ItemDescription = "Selected Office(s)"

                Offices = AdvantageFramework.GeneralLedger.LoadGeneralLedgerReportsOffices(Me.Session, DbContext)

                DataGridViewOfficeLeftSection_Offices.DataSource = (From Office In Offices
                                                                    Where _SelectedOffices.Contains(Office.Key) = False
                                                                    Select [Code] = Office.Key,
                                                                           [Description] = If(Office.Value IsNot Nothing AndAlso Office.Value.Office IsNot Nothing, Office.Value.Office.Name, ""),
                                                                           [IsInactive] = CBool(If(Office.Value IsNot Nothing AndAlso Office.Value.Office IsNot Nothing, Office.Value.Office.IsInactive.GetValueOrDefault(0), False))).ToList

                DataGridViewOfficeRightSection_Presets.DataSource = (From Office In Offices
                                                                     Where _SelectedOffices.Contains(Office.Key)
                                                                     Select [Code] = Office.Key,
                                                                            [Description] = If(Office.Value IsNot Nothing AndAlso Office.Value.Office IsNot Nothing, Office.Value.Office.Name, ""),
                                                                            [IsInactive] = CBool(If(Office.Value IsNot Nothing AndAlso Office.Value.Office IsNot Nothing, Office.Value.Office.IsInactive.GetValueOrDefault(0), False))).ToList

            End Using

            DataGridViewOfficeLeftSection_Offices.CurrentView.BestFitColumns()
            DataGridViewOfficeRightSection_Presets.CurrentView.BestFitColumns()

            If TabItemReportTemplatePresets_OfficeTab.Tag = False Then

                ConvertCheckBoxToYesNo(DataGridViewOfficeLeftSection_Offices.CurrentView.Columns("IsInactive"))
                ConvertCheckBoxToYesNo(DataGridViewOfficeRightSection_Presets.CurrentView.Columns("IsInactive"))

                DataGridViewOfficeLeftSection_Offices.CurrentView.AFActiveFilterString = "[IsInactive] = False"
                'DataGridViewOfficeRightSection_Presets.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            End If

            TabItemReportTemplatePresets_OfficeTab.Tag = True

            EnableOrDisableActions()

        End Sub
        Private Sub LoadDepartmentTeamTab()

            'objects
            Dim Departments As Dictionary(Of String, AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _SelectedDepartments Is Nothing Then

                    _SelectedDepartments = New List(Of String)

                End If

                DataGridViewDTLeftSection_DepartmentTeams.ItemDescription = "Department(s)"
                DataGridViewDTRightSection_Presets.ItemDescription = "Selected Department(s)"

                Departments = AdvantageFramework.GeneralLedger.LoadGeneralLedgerReportsDepartments(DbContext)

                DataGridViewDTLeftSection_DepartmentTeams.DataSource = (From Department In Departments
                                                                        Where _SelectedDepartments.Contains(Department.Key) = False
                                                                        Select [Code] = Department.Key,
                                                                               [Description] = If(Department.Value IsNot Nothing AndAlso Department.Value.DepartmentTeam IsNot Nothing, Department.Value.DepartmentTeam.Description, ""),
                                                                               [IsInactive] = CBool(If(Department.Value IsNot Nothing AndAlso Department.Value.DepartmentTeam IsNot Nothing, Department.Value.DepartmentTeam.IsInactive.GetValueOrDefault(0), False))).ToList

                DataGridViewDTRightSection_Presets.DataSource = (From Department In Departments
                                                                 Where _SelectedDepartments.Contains(Department.Key) = True
                                                                 Select [Code] = Department.Key,
                                                                        [Description] = If(Department.Value IsNot Nothing AndAlso Department.Value.DepartmentTeam IsNot Nothing, Department.Value.DepartmentTeam.Description, ""),
                                                                        [IsInactive] = CBool(If(Department.Value IsNot Nothing AndAlso Department.Value.DepartmentTeam IsNot Nothing, Department.Value.DepartmentTeam.IsInactive.GetValueOrDefault(0), False))).ToList

            End Using

            DataGridViewDTLeftSection_DepartmentTeams.CurrentView.BestFitColumns()
            DataGridViewDTRightSection_Presets.CurrentView.BestFitColumns()

            If TabItemReportTemplatePresets_DepartmentTeamTab.Tag = False Then

                ConvertCheckBoxToYesNo(DataGridViewDTLeftSection_DepartmentTeams.CurrentView.Columns("IsInactive"))
                ConvertCheckBoxToYesNo(DataGridViewDTRightSection_Presets.CurrentView.Columns("IsInactive"))

                DataGridViewDTLeftSection_DepartmentTeams.CurrentView.AFActiveFilterString = "[IsInactive] = False"
                'DataGridViewDTRightSection_Presets.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            End If

            TabItemReportTemplatePresets_DepartmentTeamTab.Tag = True

            EnableOrDisableActions()

        End Sub
        Private Sub ConvertCheckBoxToYesNo(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If GridColumn IsNot Nothing Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                With RepositoryItemCheckEdit

                    .DisplayValueChecked = "Yes"
                    .DisplayValueGrayed = "No"
                    .DisplayValueUnchecked = "No"

                End With

                GridColumn.ColumnEdit = RepositoryItemCheckEdit

            End If

        End Sub
        Private Sub LoadOtherTab()

            'objects
            Dim AvailableGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AvailableGeneralLedgerAccounts = LoadOtherAccounts(DbContext)

                If _SelectedOtherCodes Is Nothing Then

                    _SelectedOtherCodes = New List(Of String)

                End If

                DataGridViewOtherLeftSection_Other.ItemDescription = "Other Code(s)"
                DataGridViewOtherRightSection_Other.ItemDescription = "Selected Other Code(s)"

                If AvailableGeneralLedgerAccounts IsNot Nothing Then

                    _SelectedOtherCodes = FilterSelectedOtherCodes(AvailableGeneralLedgerAccounts)

                    DataGridViewOtherLeftSection_Other.DataSource = (From Item In AvailableGeneralLedgerAccounts
                                                                     Where _SelectedOtherCodes.Contains(Item.OtherCode) = False
                                                                     Select [Code] = Item.OtherCode,
                                                                            [IsInactive] = CBool(If(Item.Active = "A", False, True))).OrderBy(Function(oc) oc.Code).ToList

                    DataGridViewOtherRightSection_Other.DataSource = (From Item In AvailableGeneralLedgerAccounts
                                                                      Where _SelectedOtherCodes.Contains(Item.OtherCode) = True
                                                                      Select [Code] = Item.OtherCode,
                                                                             [IsInactive] = CBool(If(Item.Active = "A", False, True))).OrderBy(Function(oc) oc.Code).ToList

                End If

            End Using

            DataGridViewOtherLeftSection_Other.CurrentView.BestFitColumns()
            DataGridViewOtherRightSection_Other.CurrentView.BestFitColumns()

            If TabItemReportTemplatePresets_OtherTab.Tag = False Then

                ConvertCheckBoxToYesNo(DataGridViewOtherLeftSection_Other.CurrentView.Columns("IsInactive"))
                ConvertCheckBoxToYesNo(DataGridViewOtherRightSection_Other.CurrentView.Columns("IsInactive"))

                DataGridViewOtherLeftSection_Other.CurrentView.AFActiveFilterString = "[IsInactive] = False"
                'DataGridViewOtherRightSection_Other.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            End If

            TabItemReportTemplatePresets_OtherTab.Tag = True

            EnableOrDisableActions()

        End Sub
        Private Sub LoadBaseTab()

            'objects
            Dim AvailableGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AvailableGeneralLedgerAccounts = LoadBaseAccounts(DbContext)

                If _SelectedBaseCodes Is Nothing Then

                    _SelectedBaseCodes = New List(Of String)

                End If

                DataGridViewBaseLeftSection_Base.ItemDescription = "Base Code(s)"
                DataGridViewBaseRightSection_Base.ItemDescription = "Selected Base Code(s)"

                If AvailableGeneralLedgerAccounts IsNot Nothing Then

                    _SelectedBaseCodes = FilterSelectedBaseCodes(AvailableGeneralLedgerAccounts)

                    DataGridViewBaseLeftSection_Base.DataSource = (From Item In AvailableGeneralLedgerAccounts
                                                                   Where _SelectedBaseCodes.Contains(Item.BaseCode) = False
                                                                   Select [Code] = Item.BaseCode,
                                                                          [Description] = Item.Description,
                                                                          [IsInactive] = CBool(If(Item.Active = "A", False, True))).OrderBy(Function(bc) bc.Code).ToList

                    DataGridViewBaseRightSection_Base.DataSource = (From Item In AvailableGeneralLedgerAccounts
                                                                    Where _SelectedBaseCodes.Contains(Item.BaseCode) = True
                                                                    Select [Code] = Item.BaseCode,
                                                                           [Description] = Item.Description,
                                                                           [IsInactive] = CBool(If(Item.Active = "A", False, True))).OrderBy(Function(bc) bc.Code).ToList

                End If

            End Using

            DataGridViewBaseLeftSection_Base.CurrentView.BestFitColumns()
            DataGridViewBaseRightSection_Base.CurrentView.BestFitColumns()

            If TabItemReportTemplatePresets_BaseTab.Tag = False Then

                ConvertCheckBoxToYesNo(DataGridViewBaseLeftSection_Base.CurrentView.Columns("IsInactive"))
                ConvertCheckBoxToYesNo(DataGridViewBaseRightSection_Base.CurrentView.Columns("IsInactive"))

                DataGridViewBaseLeftSection_Base.CurrentView.AFActiveFilterString = "[IsInactive] = False"
                'DataGridViewBaseRightSection_Base.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            End If

            TabItemReportTemplatePresets_BaseTab.Tag = True

            EnableOrDisableActions()

        End Sub
        Private Function LoadOtherAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            'objects
            Dim AvailableGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            Try

                AvailableGeneralLedgerAccounts = (From Item In LoadFilteredAccounts(DbContext).ToList
                                                  Group By Item.OtherCode Into Group
                                                  Select New AdvantageFramework.Database.Entities.GeneralLedgerAccount() With {
                                                                                                .Code = Group.First.Code,
                                                                                                .Description = Group.First.Description,
                                                                                                .Type = Group.First.Type,
                                                                                                .CDPRequired = Group.First.CDPRequired,
                                                                                                .Active = If(Group.Where(Function(gla) gla.Active = "A").Any, "A", ""),
                                                                                                .DepartmentCode = Group.First.DepartmentCode,
                                                                                                .UserCode = Group.First.UserCode,
                                                                                                .EnteredDate = Group.First.EnteredDate,
                                                                                                .ModifiedDate = Group.First.ModifiedDate,
                                                                                                .BalanceType = Group.First.BalanceType,
                                                                                                .BaseCode = Group.First.BaseCode,
                                                                                                .GeneralLedgerOfficeCrossReferenceCode = Group.First.GeneralLedgerOfficeCrossReferenceCode,
                                                                                                .ID = Group.First.ID,
                                                                                                .Payroll = Group.First.Payroll,
                                                                                                .PurchaseOrder = Group.First.PurchaseOrder,
                                                                                                .OtherCode = Group.First.OtherCode
                                                                                                }).ToList

            Catch ex As Exception
                AvailableGeneralLedgerAccounts = Nothing
            Finally
                LoadOtherAccounts = AvailableGeneralLedgerAccounts
            End Try

        End Function
        Private Function FilterSelectedOtherCodes(ByVal AvailableGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)) As Generic.List(Of String)

            Return AvailableGeneralLedgerAccounts.Where(Function(item) _SelectedOtherCodes.Contains(item.OtherCode)).Select(Function(item) item.OtherCode).ToList

        End Function
        Private Function LoadBaseAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            'objects
            Dim AvailableGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            Try

                AvailableGeneralLedgerAccounts = (From Item In LoadFilteredAccounts(DbContext).ToList
                                                  Group By Item.BaseCode Into Group
                                                  Select New AdvantageFramework.Database.Entities.GeneralLedgerAccount() With {
                                                                                                .Code = Group.First.Code,
                                                                                                .Description = Group.First.Description,
                                                                                                .Type = Group.First.Type,
                                                                                                .CDPRequired = Group.First.CDPRequired,
                                                                                                .Active = If(Group.Where(Function(gla) gla.Active = "A").Any, "A", ""),
                                                                                                .DepartmentCode = Group.First.DepartmentCode,
                                                                                                .UserCode = Group.First.UserCode,
                                                                                                .EnteredDate = Group.First.EnteredDate,
                                                                                                .ModifiedDate = Group.First.ModifiedDate,
                                                                                                .BalanceType = Group.First.BalanceType,
                                                                                                .BaseCode = Group.First.BaseCode,
                                                                                                .GeneralLedgerOfficeCrossReferenceCode = Group.First.GeneralLedgerOfficeCrossReferenceCode,
                                                                                                .ID = Group.First.ID,
                                                                                                .Payroll = Group.First.Payroll,
                                                                                                .PurchaseOrder = Group.First.PurchaseOrder,
                                                                                                .OtherCode = Group.First.OtherCode
                                                                                                }).ToList

            Catch ex As Exception
                AvailableGeneralLedgerAccounts = Nothing
            Finally
                LoadBaseAccounts = AvailableGeneralLedgerAccounts
            End Try

        End Function
        Private Function FilterSelectedBaseCodes(ByVal AvailableGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)) As Generic.List(Of String)

            Return AvailableGeneralLedgerAccounts.Where(Function(item) _SelectedBaseCodes.Contains(item.BaseCode)).Select(Function(item) item.BaseCode).ToList

        End Function
        Private Sub LoadTypesTab()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _SelectedTypes Is Nothing Then

                    _SelectedTypes = New List(Of String)

                End If

                DataGridViewLeftSection_AvailableTypes.ItemDescription = "Account Type(s)"
                DataGridViewRightSection_SelectedTypes.ItemDescription = "Selected Account Type(s)"

                DataGridViewLeftSection_AvailableTypes.DataSource = (From Item In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(ReportWriter.Methods.AccountTypes))
                                                                     Where _SelectedTypes.Contains(Item.Code) = False
                                                                     Select Item.Code, Item.Description).ToList

                DataGridViewRightSection_SelectedTypes.DataSource = (From Item In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(ReportWriter.Methods.AccountTypes))
                                                                     Where _SelectedTypes.Contains(Item.Code) = True
                                                                     Select Item.Code, Item.Description).ToList


                DataGridViewLeftSection_AvailableTypes.HideOrShowColumn("Code", False)
                DataGridViewRightSection_SelectedTypes.HideOrShowColumn("Code", False)

            End Using

            DataGridViewLeftSection_AvailableTypes.CurrentView.BestFitColumns()
            DataGridViewRightSection_SelectedTypes.CurrentView.BestFitColumns()

            TabItemReportTemplatePresets_TypesTab.Tag = True

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonDTRightSection_Add.Enabled = DataGridViewDTLeftSection_DepartmentTeams.HasASelectedRow
            ButtonDTRightSection_AddAll.Enabled = DataGridViewDTLeftSection_DepartmentTeams.HasASelectedRow
            ButtonDTRightSection_Remove.Enabled = DataGridViewDTRightSection_Presets.HasASelectedRow
            ButtonDTRightSection_RemoveAll.Enabled = DataGridViewDTRightSection_Presets.HasASelectedRow

            ButtonOfficeRightSection_Add.Enabled = DataGridViewOfficeLeftSection_Offices.HasASelectedRow
            ButtonOfficeRightSection_AddAll.Enabled = DataGridViewOfficeLeftSection_Offices.HasASelectedRow
            ButtonOfficeRightSection_Remove.Enabled = DataGridViewOfficeRightSection_Presets.HasASelectedRow
            ButtonOfficeRightSection_RemoveAll.Enabled = DataGridViewOfficeRightSection_Presets.HasASelectedRow

            ButtonOtherRightSection_Add.Enabled = DataGridViewOtherLeftSection_Other.HasASelectedRow
            ButtonOtherRightSection_AddAll.Enabled = DataGridViewOtherLeftSection_Other.HasASelectedRow
            ButtonOtherRightSection_Remove.Enabled = DataGridViewOtherRightSection_Other.HasASelectedRow
            ButtonOtherRightSection_RemoveAll.Enabled = DataGridViewOtherRightSection_Other.HasASelectedRow

            ButtonBaseRightSection_Add.Enabled = DataGridViewBaseLeftSection_Base.HasASelectedRow
            ButtonBaseRightSection_AddAll.Enabled = DataGridViewBaseLeftSection_Base.HasASelectedRow
            ButtonBaseRightSection_Remove.Enabled = DataGridViewBaseRightSection_Base.HasASelectedRow
            ButtonBaseRightSection_RemoveAll.Enabled = DataGridViewBaseRightSection_Base.HasASelectedRow

        End Sub
        Private Sub OfficeDepartmentOrTypeChanged()

            TabItemReportTemplatePresets_OtherTab.Tag = False
            TabItemReportTemplatePresets_BaseTab.Tag = False

        End Sub
        Private Sub SetupTabs()

            For Each TabItem In TabControlForm_OptionsPresets.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)

                TabItem.Tag = False

            Next

            HideOrShowGeneralLedgerConfigTabs()
            HideOrShowReportTabs()

            If Not TabItemReportTemplatePresets_OfficeTab.Visible Then

                _SelectedOffices = Nothing

            End If

            If Not TabItemReportTemplatePresets_DepartmentTeamTab.Visible Then

                _SelectedDepartments = Nothing

            End If

            If Not TabItemReportTemplatePresets_TypesTab.Visible Then

                _SelectedTypes = Nothing

            End If

            If Not TabItemReportTemplatePresets_OtherTab.Visible Then

                _SelectedOtherCodes = Nothing

            End If

            If Not TabItemReportTemplatePresets_BaseTab.Visible Then

                _SelectedBaseCodes = Nothing

            End If

            LoadTab(Nothing)

        End Sub
        Private Sub SetupSelectedReportOptions()

            If _IsUserDefinedReport = True Then

                If _DynamicReportType = Reporting.DynamicReports.TrialBalance Then

                    Me.Text = "Trial Balance Criteria"
                    SetupTrialBalanceCriteria()

                ElseIf _DynamicReportType = Reporting.DynamicReports.GeneralLedgerReport Then

                    Me.Text = "General Ledger Reports"
                    SetupDetailByAccountReport()

                End If

            ElseIf Me.SelectedReport <> Nothing Then

                If Me.SelectedReport = ReportWriter.Methods.StandardGeneralLedgerReports.TrialBalance Then

                    SetupTrialBalanceCriteria()

                ElseIf Me.SelectedReport = ReportWriter.StandardGeneralLedgerReports.DetailByAccountLandscape OrElse
                       Me.SelectedReport = ReportWriter.StandardGeneralLedgerReports.DetailByAccountPortrait OrElse
                       Me.SelectedReport = ReportWriter.StandardGeneralLedgerReports.DetailByTransaction Then

                    SetupDetailByAccountReport()

                End If

            End If

        End Sub
        Private Sub SetupTrialBalanceCriteria()

            LabelOptions_PostPeriodStart.Text = "Ending Post Period"
            LabelOptions_PostPeriodEnd.Visible = False
            ComboBoxOptions_PostPeriodEnd.Visible = False
            ButtonOptions_1Year.Visible = False
            ButtonOptions_YTD.Visible = False
            ButtonOptions_2Years.Visible = False
            ButtonOptions_MTD.Visible = False
            ComboBoxOptions_PostPeriodEnd.SetRequired(False)

        End Sub
        Private Sub SetupDetailByAccountReport()

            LabelOptions_PostPeriodStart.Text = "Starting Post Period"
            LabelOptions_PostPeriodEnd.Visible = True
            ComboBoxOptions_PostPeriodEnd.Visible = True
            ButtonOptions_1Year.Visible = True
            ButtonOptions_YTD.Visible = True
            ButtonOptions_2Years.Visible = True
            ButtonOptions_MTD.Visible = True
            ComboBoxOptions_PostPeriodEnd.SetRequired(True)

        End Sub
        Private Sub HideOrShowGeneralLedgerConfigTabs()

            'objects
            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing

            TabItemReportTemplatePresets_OfficeTab.Visible = False
            TabItemReportTemplatePresets_DepartmentTeamTab.Visible = False
            TabItemReportTemplatePresets_OtherTab.Visible = False
            TabItemReportTemplatePresets_BaseTab.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                If GeneralLedgerConfig IsNot Nothing Then

                    ShowGeneralLedgerConfigTab(GeneralLedgerConfig.Segment1Format, GeneralLedgerConfig.Segment1Type)
                    ShowGeneralLedgerConfigTab(GeneralLedgerConfig.Segment2Format, GeneralLedgerConfig.Segment2Type)
                    ShowGeneralLedgerConfigTab(GeneralLedgerConfig.Segment3Format, GeneralLedgerConfig.Segment3Type)
                    ShowGeneralLedgerConfigTab(GeneralLedgerConfig.Segment4Format, GeneralLedgerConfig.Segment4Type)

                End If

            End Using

        End Sub
        Private Sub ShowGeneralLedgerConfigTab(ByVal SegmentFormat As String, ByVal SegmentType As Long?)

            'objects
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing

            If Not String.IsNullOrWhiteSpace(SegmentFormat) Then

                Select Case SegmentType.GetValueOrDefault(0)

                    Case 1 ' base

                        TabItem = TabItemReportTemplatePresets_BaseTab

                    Case 2 ' office

                        TabItem = TabItemReportTemplatePresets_OfficeTab

                    Case 3 ' department

                        TabItem = TabItemReportTemplatePresets_DepartmentTeamTab

                    Case 4 ' other

                        TabItem = TabItemReportTemplatePresets_OtherTab

                End Select

                If TabItem IsNot Nothing Then

                    TabItem.Visible = True

                End If

            End If

        End Sub
        Private Sub HideOrShowReportTabs()

            If _IsUserDefinedReport Then

                TabItemReportTemplatePresets_TypesTab.Visible = False
                TabItemReportTemplatePresets_BaseTab.Visible = False
                TabItemReportTemplatePresets_OtherTab.Visible = False

            Else

                TabItemReportTemplatePresets_TypesTab.Visible = True

            End If

        End Sub
        Private Sub LoadTab(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            If TabItem Is Nothing Then

                For Each TabItem In TabControlForm_OptionsPresets.Tabs

                    TabItem.Tag = False

                Next

                TabItem = TabControlForm_OptionsPresets.SelectedTab

            End If

            If TabItem IsNot Nothing AndAlso TabItem.Tag = False Then

                If TabItem Is TabItemReportTemplatePresets_OfficeTab Then

                    LoadOfficeTab()

                ElseIf TabItem Is TabItemReportTemplatePresets_DepartmentTeamTab Then

                    LoadDepartmentTeamTab()

                ElseIf TabItem Is TabItemReportTemplatePresets_OtherTab Then

                    LoadOtherTab()

                ElseIf TabItem Is TabItemReportTemplatePresets_BaseTab Then

                    LoadBaseTab()

                ElseIf TabItem Is TabItemReportTemplatePresets_TypesTab Then

                    LoadTypesTab()

                End If

            End If

        End Sub
        Private Function LoadFilteredAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext) As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            'objects
            Dim GLObjectQuery As Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            GLObjectQuery = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Session)

            If _SelectedTypes IsNot Nothing AndAlso _SelectedTypes.Any Then

                GLObjectQuery = GLObjectQuery.Where(Function(item) _SelectedTypes.Contains(item.Type))

            End If

            If _SelectedOffices IsNot Nothing AndAlso _SelectedOffices.Any Then

                GLObjectQuery = GLObjectQuery.Where(Function(item) _SelectedOffices.Contains(item.GeneralLedgerOfficeCrossReferenceCode))

            End If

            If _SelectedDepartments IsNot Nothing AndAlso _SelectedDepartments.Any Then

                GLObjectQuery = GLObjectQuery.Where(Function(item) _SelectedDepartments.Contains(item.DepartmentCode))

            End If

            Return GLObjectQuery

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal IsUserDefinedReport As Boolean, Optional ByVal DynamicReportType As Reporting.DynamicReports = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim GeneralLedgerReportDialog As AdvantageFramework.GeneralLedger.Reports.Presentation.GeneralLedgerReportDialog = Nothing

            GeneralLedgerReportDialog = New AdvantageFramework.GeneralLedger.Reports.Presentation.GeneralLedgerReportDialog(ParameterDictionary, IsUserDefinedReport, DynamicReportType)

            ShowFormDialog = GeneralLedgerReportDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = GeneralLedgerReportDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GeneralLedgerReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects

            Dim HasAccessToReport As Boolean = True
            Dim CurrentPostPeriod As String = Nothing

            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewDTLeftSection_DepartmentTeams.OptionsView.ShowFooter = False
            DataGridViewDTRightSection_Presets.OptionsView.ShowFooter = False
            DataGridViewOfficeLeftSection_Offices.OptionsView.ShowFooter = False
            DataGridViewOfficeRightSection_Presets.OptionsView.ShowFooter = False

            ComboBoxOptions_PostPeriodStart.SetRequired(True)
            ComboBoxOptions_PostPeriodEnd.SetRequired(True)

            If _IsUserDefinedReport = False Then

                'HasAccessToReport = AdvantageFramework.Security.DoesUserHaveAccessToReport(Me.Session, "ADBYCODE.QRP")

            Else

                PanelOptions_Left.Visible = False

            End If

            If HasAccessToReport Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxOptions_PostPeriodStart.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                    ComboBoxOptions_PostPeriodEnd.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                    ComboBoxOptions_RecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)

                    Try

                        CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                    Catch ex As Exception

                    End Try

                    If String.IsNullOrWhiteSpace(CurrentPostPeriod) = False Then

                        Try

                            ComboBoxOptions_PostPeriodStart.SelectedValue = CurrentPostPeriod

                        Catch ex As Exception
                            ComboBoxOptions_PostPeriodStart.SelectedValue = Nothing
                        End Try

                        Try

                            ComboBoxOptions_PostPeriodEnd.SelectedValue = CurrentPostPeriod

                        Catch ex As Exception
                            ComboBoxOptions_PostPeriodEnd.SelectedValue = Nothing
                        End Try

                    End If

                End Using

                If _IsUserDefinedReport = False Then

                    ListBoxOptions_Reports.ValueMember = "Code"
                    ListBoxOptions_Reports.DisplayMember = "Description"
                    ListBoxOptions_Reports.DataSource = (From item In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports))
                                                         Select [Code] = item.Code,
                                                                [Description] = item.Description).ToList

                Else

                    SetupSelectedReportOptions()

                End If

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                Try

                    If _IsUserDefinedReport = False Then

                        ListBoxOptions_Reports.SelectedValue = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountPortrait).Code

                    End If

                    SetupTabs()
                    SetupSelectedReportOptions()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

            Else

                AdvantageFramework.Navigation.ShowMessageBox("You do not have rights to view this report.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim FromPostPeriod As String = ""
            Dim ToPostPeriod As String = ""
            Dim Offices As String = ""
            Dim Departments As String = ""
            Dim BaseCodes As String = ""
            Dim OtherCodes As String = ""
            Dim IncludeCurrentAssets As Boolean = True
            Dim IncludeNonCurrentAssets As Boolean = True
            Dim IncludeFixedAssets As Boolean = True
            Dim IncludeCurrentLiabilities As Boolean = True
            Dim IncludeNonCurrentLiabilities As Boolean = True
            Dim IncludeEquity As Boolean = True
            Dim IncludeIncome As Boolean = True
            Dim IncludeIncomeOther As Boolean = True
            Dim IncludeExpenseCOS As Boolean = True
            Dim IncludeExpenseOperating As Boolean = True
            Dim IncludeExpenseOther As Boolean = True
            Dim IncludeExpenseTaxes As Boolean = True
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim Datasource As IEnumerable(Of AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport) = Nothing
            Dim StandardGeneralLedgerReport As AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports = Nothing

            If Me.Validator Then

                If ComboBoxOptions_PostPeriodStart.GetSelectedValue <= ComboBoxOptions_PostPeriodEnd.GetSelectedValue OrElse Not ComboBoxOptions_PostPeriodEnd.Visible Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If _ParameterDictionary Is Nothing Then

                                _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                            End If

                            If _SelectedOffices IsNot Nothing AndAlso _SelectedOffices.Count > 0 Then

                                Offices = String.Join(",", _SelectedOffices)

                            End If

                            If _SelectedDepartments IsNot Nothing AndAlso _SelectedDepartments.Count > 0 Then

                                Departments = String.Join(",", _SelectedDepartments)

                            End If

                            If _SelectedBaseCodes IsNot Nothing AndAlso _SelectedBaseCodes.Count > 0 Then

                                If TabItemReportTemplatePresets_BaseTab.Tag = False Then

                                    _SelectedBaseCodes = FilterSelectedBaseCodes(LoadBaseAccounts(DbContext))

                                End If

                                BaseCodes = String.Join(",", _SelectedBaseCodes)

                            End If

                            If _SelectedOtherCodes IsNot Nothing AndAlso _SelectedOtherCodes.Count > 0 Then

                                If TabItemReportTemplatePresets_OtherTab.Tag = False Then

                                    _SelectedOtherCodes = FilterSelectedOtherCodes(LoadOtherAccounts(DbContext))

                                End If

                                OtherCodes = String.Join(",", _SelectedOtherCodes)

                            End If

                            If _SelectedTypes IsNot Nothing AndAlso _SelectedTypes.Any Then

                                IncludeCurrentAssets = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.CurrentAsset).Code)
                                IncludeNonCurrentAssets = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.NonCurrentAsset).Code)
                                IncludeFixedAssets = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.FixedAsset).Code)
                                IncludeCurrentLiabilities = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.CurrentLiability).Code)
                                IncludeNonCurrentLiabilities = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.NonCurrentLiability).Code)
                                IncludeEquity = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.Equity).Code)
                                IncludeIncome = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.Income).Code)
                                IncludeIncomeOther = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.IncomeOther).Code)
                                IncludeExpenseCOS = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseCOS).Code)
                                IncludeExpenseOperating = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseOperating).Code)
                                IncludeExpenseOther = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseOther).Code)
                                IncludeExpenseTaxes = _SelectedTypes.Any(Function(acctType) acctType = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseTaxes).Code)

                            End If

                            If _IsUserDefinedReport = False Then

                                _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Report.ToString) = Me.SelectedReport

                            End If

                            If ComboBoxOptions_RecordSource.HasASelectedValue Then

                                _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.RecordSourceID.ToString) = ComboBoxOptions_RecordSource.GetSelectedValue

                            Else

                                _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.RecordSourceID.ToString) = 0

                            End If

                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString) = ComboBoxOptions_PostPeriodStart.GetSelectedValue
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.EndingPostPeriodCode.ToString) = ComboBoxOptions_PostPeriodEnd.GetSelectedValue
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Offices.ToString) = Offices
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Departments.ToString) = Departments
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.BaseCodes.ToString) = BaseCodes
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.OtherCodes.ToString) = OtherCodes
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeCurrentAssets.ToString) = IncludeCurrentAssets
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeNonCurrentAssets.ToString) = IncludeNonCurrentAssets
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeFixedAssets.ToString) = IncludeFixedAssets
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeCurrentLiabilities.ToString) = IncludeCurrentLiabilities
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeNonCurrentLiabilities.ToString) = IncludeNonCurrentLiabilities
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeEquity.ToString) = IncludeEquity
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeIncome.ToString) = IncludeIncome
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeIncomeOther.ToString) = IncludeIncomeOther
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseCOS.ToString) = IncludeExpenseCOS
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseOperating.ToString) = IncludeExpenseOperating
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseOther.ToString) = IncludeExpenseOther
                            _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseTaxes.ToString) = IncludeExpenseTaxes

                        End Using

                    End Using

                    If _IsUserDefinedReport Then

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.GeneralLedgerReport, _ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a starting post period that is before the ending post period.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonDTRightSection_Add_Click(sender As Object, e As EventArgs) Handles ButtonDTRightSection_Add.Click

            'objects
            Dim DepartmentCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                DepartmentCodes = DataGridViewDTLeftSection_DepartmentTeams.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If DepartmentCodes IsNot Nothing AndAlso DepartmentCodes.Count > 0 Then

                    For Each DepartmentCode In DepartmentCodes

                        If Not String.IsNullOrWhiteSpace(DepartmentCode) Then

                            If _SelectedDepartments Is Nothing Then

                                _SelectedDepartments = New List(Of String)

                            End If

                            If Not _SelectedDepartments.Any(Function(dc) dc = DepartmentCode) Then

                                _SelectedDepartments.Add(DepartmentCode)

                            End If

                        End If

                    Next

                End If

                OfficeDepartmentOrTypeChanged()
                LoadDepartmentTeamTab()

            End If

        End Sub
        Private Sub ButtonDTRightSection_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonDTRightSection_AddAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                For Each DepartmentCode In DataGridViewDTLeftSection_DepartmentTeams.GetAllRowsBookmarkValues

                    If Not String.IsNullOrWhiteSpace(DepartmentCode) Then

                        If _SelectedDepartments Is Nothing Then

                            _SelectedDepartments = New List(Of String)

                        End If

                        If Not _SelectedDepartments.Any(Function(dc) dc = DepartmentCode) Then

                            _SelectedDepartments.Add(DepartmentCode)

                        End If

                    End If

                Next

                OfficeDepartmentOrTypeChanged()
                LoadDepartmentTeamTab()

            End If

        End Sub
        Private Sub ButtonDTRightSection_Remove_Click(sender As Object, e As EventArgs) Handles ButtonDTRightSection_Remove.Click

            'objects
            Dim DepartmentCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                DepartmentCodes = DataGridViewDTRightSection_Presets.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If DepartmentCodes IsNot Nothing AndAlso DepartmentCodes.Count > 0 Then

                    For Each DepartmentCode In DepartmentCodes

                        If Not String.IsNullOrWhiteSpace(DepartmentCode) Then

                            If _SelectedDepartments IsNot Nothing Then

                                Try

                                    _SelectedDepartments.Remove(DepartmentCode)

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                End If

                OfficeDepartmentOrTypeChanged()
                LoadDepartmentTeamTab()

            End If

        End Sub
        Private Sub ButtonDTRightSection_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonDTRightSection_RemoveAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If _SelectedDepartments IsNot Nothing Then

                    _SelectedDepartments.Clear()

                End If

                OfficeDepartmentOrTypeChanged()
                LoadDepartmentTeamTab()

            End If

        End Sub
        Private Sub ButtonOfficeRightSection_Add_Click(sender As Object, e As EventArgs) Handles ButtonOfficeRightSection_Add.Click

            'objects
            Dim OfficeCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                OfficeCodes = DataGridViewOfficeLeftSection_Offices.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If OfficeCodes IsNot Nothing AndAlso OfficeCodes.Count > 0 Then

                    For Each OfficeCode In OfficeCodes

                        If Not String.IsNullOrWhiteSpace(OfficeCode) Then

                            If _SelectedOffices Is Nothing Then

                                _SelectedOffices = New List(Of String)

                            End If

                            If Not _SelectedOffices.Any(Function(oc) oc = OfficeCode) Then

                                _SelectedOffices.Add(OfficeCode)

                            End If

                        End If

                    Next

                End If

                OfficeDepartmentOrTypeChanged()
                LoadOfficeTab()

            End If

        End Sub
        Private Sub ButtonOfficeRightSection_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonOfficeRightSection_AddAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                For Each OfficeCode In DataGridViewOfficeLeftSection_Offices.GetAllRowsBookmarkValues

                    If Not String.IsNullOrWhiteSpace(OfficeCode) Then

                        If _SelectedOffices Is Nothing Then

                            _SelectedOffices = New List(Of String)

                        End If

                        If Not _SelectedOffices.Any(Function(oc) oc = OfficeCode) Then

                            _SelectedOffices.Add(OfficeCode)

                        End If

                    End If

                Next

                OfficeDepartmentOrTypeChanged()
                LoadOfficeTab()

            End If

        End Sub
        Private Sub ButtonOfficeRightSection_Remove_Click(sender As Object, e As EventArgs) Handles ButtonOfficeRightSection_Remove.Click

            'objects
            Dim OfficeCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                OfficeCodes = DataGridViewOfficeRightSection_Presets.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If OfficeCodes IsNot Nothing AndAlso OfficeCodes.Count > 0 Then

                    For Each OfficeCode In OfficeCodes

                        If Not String.IsNullOrWhiteSpace(OfficeCode) Then

                            If _SelectedOffices IsNot Nothing Then

                                Try

                                    _SelectedOffices.Remove(OfficeCode)

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                End If

                OfficeDepartmentOrTypeChanged()
                LoadOfficeTab()

            End If

        End Sub
        Private Sub ButtonOfficeRightSection_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonOfficeRightSection_RemoveAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If _SelectedOffices IsNot Nothing Then

                    _SelectedOffices.Clear()

                End If

                OfficeDepartmentOrTypeChanged()
                LoadOfficeTab()

            End If

        End Sub
        Private Sub ButtonBaseRightSection_Add_Click(sender As Object, e As EventArgs) Handles ButtonBaseRightSection_Add.Click

            'objects
            Dim BaseCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                BaseCodes = DataGridViewBaseLeftSection_Base.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If BaseCodes IsNot Nothing AndAlso BaseCodes.Count > 0 Then

                    For Each BaseCode In BaseCodes

                        If Not String.IsNullOrWhiteSpace(BaseCode) Then

                            If _SelectedBaseCodes Is Nothing Then

                                _SelectedBaseCodes = New List(Of String)

                            End If

                            If Not _SelectedBaseCodes.Any(Function(bc) bc = BaseCode) Then

                                _SelectedBaseCodes.Add(BaseCode)

                            End If

                        End If

                    Next

                End If

                LoadBaseTab()

            End If

        End Sub
        Private Sub ButtonBaseRightSection_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonBaseRightSection_AddAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                For Each BaseCode In DataGridViewBaseLeftSection_Base.GetAllRowsBookmarkValues

                    If Not String.IsNullOrWhiteSpace(BaseCode) Then

                        If _SelectedBaseCodes Is Nothing Then

                            _SelectedBaseCodes = New List(Of String)

                        End If

                        If Not _SelectedBaseCodes.Any(Function(bc) bc = BaseCode) Then

                            _SelectedBaseCodes.Add(BaseCode)

                        End If

                    End If

                Next

                LoadBaseTab()

            End If

        End Sub
        Private Sub ButtonBaseRightSection_Remove_Click(sender As Object, e As EventArgs) Handles ButtonBaseRightSection_Remove.Click

            'objects
            Dim BaseCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                BaseCodes = DataGridViewBaseRightSection_Base.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If BaseCodes IsNot Nothing AndAlso BaseCodes.Count > 0 Then

                    For Each BaseCode In BaseCodes

                        If Not String.IsNullOrWhiteSpace(BaseCode) Then

                            If _SelectedBaseCodes IsNot Nothing Then

                                Try

                                    _SelectedBaseCodes.Remove(BaseCode)

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                End If

                LoadBaseTab()

            End If

        End Sub
        Private Sub ButtonBaseRightSection_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonBaseRightSection_RemoveAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If _SelectedBaseCodes IsNot Nothing Then

                    _SelectedBaseCodes.Clear()

                End If

                LoadBaseTab()

            End If

        End Sub
        Private Sub ButtonOtherRightSection_Add_Click(sender As Object, e As EventArgs) Handles ButtonOtherRightSection_Add.Click

            'objects
            Dim OtherCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                OtherCodes = DataGridViewOtherLeftSection_Other.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If OtherCodes IsNot Nothing AndAlso OtherCodes.Count > 0 Then

                    For Each OtherCode In OtherCodes

                        If Not String.IsNullOrWhiteSpace(OtherCode) Then

                            If _SelectedOtherCodes Is Nothing Then

                                _SelectedOtherCodes = New List(Of String)

                            End If

                            If Not _SelectedOtherCodes.Any(Function(oc) oc = OtherCode) Then

                                _SelectedOtherCodes.Add(OtherCode)

                            End If

                        End If

                    Next

                End If

                LoadOtherTab()

            End If

        End Sub
        Private Sub ButtonOtherRightSection_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonOtherRightSection_AddAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                For Each OtherCode In DataGridViewOtherLeftSection_Other.GetAllRowsBookmarkValues

                    If Not String.IsNullOrWhiteSpace(OtherCode) Then

                        If _SelectedOtherCodes Is Nothing Then

                            _SelectedOtherCodes = New List(Of String)

                        End If

                        If Not _SelectedOtherCodes.Any(Function(oc) oc = OtherCode) Then

                            _SelectedOtherCodes.Add(OtherCode)

                        End If

                    End If

                Next

                LoadOtherTab()

            End If

        End Sub
        Private Sub ButtonOtherRightSection_Remove_Click(sender As Object, e As EventArgs) Handles ButtonOtherRightSection_Remove.Click

            'objects
            Dim OtherCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                OtherCodes = DataGridViewOtherRightSection_Other.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If OtherCodes IsNot Nothing AndAlso OtherCodes.Count > 0 Then

                    For Each OtherCode In OtherCodes

                        If Not String.IsNullOrWhiteSpace(OtherCode) Then

                            If _SelectedOtherCodes IsNot Nothing Then

                                Try

                                    _SelectedOtherCodes.Remove(OtherCode)

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                End If

                LoadOtherTab()

            End If

        End Sub
        Private Sub ButtonOtherRightSection_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonOtherRightSection_RemoveAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If _SelectedOtherCodes IsNot Nothing Then

                    _SelectedOtherCodes.Clear()

                End If

                LoadOtherTab()

            End If

        End Sub
        Private Sub ButtonTypesRightSection_Add_Click(sender As Object, e As EventArgs) Handles ButtonTypesRightSection_Add.Click

            'objects
            Dim TypeCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                TypeCodes = DataGridViewLeftSection_AvailableTypes.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If TypeCodes IsNot Nothing AndAlso TypeCodes.Count > 0 Then

                    For Each TypeCode In TypeCodes

                        If Not String.IsNullOrWhiteSpace(TypeCode) Then

                            If _SelectedTypes Is Nothing Then

                                _SelectedTypes = New List(Of String)

                            End If

                            If Not _SelectedTypes.Any(Function(tc) tc = TypeCode) Then

                                _SelectedTypes.Add(TypeCode)

                            End If

                        End If

                    Next

                End If

                OfficeDepartmentOrTypeChanged()
                LoadTypesTab()

            End If

        End Sub
        Private Sub ButtonTypesRightSection_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonTypesRightSection_AddAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                For Each TypeCode In DataGridViewLeftSection_AvailableTypes.GetAllRowsBookmarkValues

                    If Not String.IsNullOrWhiteSpace(TypeCode) Then

                        If _SelectedTypes Is Nothing Then

                            _SelectedTypes = New List(Of String)

                        End If

                        If Not _SelectedTypes.Any(Function(tc) tc = TypeCode) Then

                            _SelectedTypes.Add(TypeCode)

                        End If

                    End If

                Next

                OfficeDepartmentOrTypeChanged()
                LoadTypesTab()

            End If

        End Sub
        Private Sub ButtonTypesRightSection_Remove_Click(sender As Object, e As EventArgs) Handles ButtonTypesRightSection_Remove.Click

            'objects
            Dim TypeCodes As String() = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                TypeCodes = DataGridViewRightSection_SelectedTypes.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                If TypeCodes IsNot Nothing AndAlso TypeCodes.Count > 0 Then

                    For Each TypeCode In TypeCodes

                        If Not String.IsNullOrWhiteSpace(TypeCode) Then

                            If _SelectedTypes IsNot Nothing Then

                                Try

                                    _SelectedTypes.Remove(TypeCode)

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                End If

                OfficeDepartmentOrTypeChanged()
                LoadTypesTab()

            End If

        End Sub
        Private Sub ButtonTypesRightSection_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonTypesRightSection_RemoveAll.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If _SelectedTypes IsNot Nothing Then

                    _SelectedTypes.Clear()

                End If

                OfficeDepartmentOrTypeChanged()
                LoadTypesTab()

            End If

        End Sub
        Private Sub DataGridViewDTLeftSection_DepartmentTeams_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDTLeftSection_DepartmentTeams.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewDTRightSection_Presets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDTRightSection_Presets.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOfficeLeftSection_Offices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOfficeLeftSection_Offices.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOfficeRightSection_Presets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOfficeRightSection_Presets.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOtherLeftSection_Other_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOtherLeftSection_Other.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewOtherRightSection_Other_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOtherRightSection_Other.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewBaseLeftSection_Base_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewBaseLeftSection_Base.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewBaseRightSection_Base_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewBaseRightSection_Base.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonOptions_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOptions_YTD.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                    PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, CurrentPostPeriod.Year)

                    Try

						ComboBoxOptions_PostPeriodStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), PostPeriod.Year.ToString).Code

					Catch ex As Exception
                        ComboBoxOptions_PostPeriodStart.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxOptions_PostPeriodEnd.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxOptions_PostPeriodEnd.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonOptions_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOptions_MTD.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    Try

                        ComboBoxOptions_PostPeriodStart.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxOptions_PostPeriodStart.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxOptions_PostPeriodEnd.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxOptions_PostPeriodEnd.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonOptions_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOptions_1Year.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Month As Integer = 0
            Dim Year As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    If CurrentPostPeriod IsNot Nothing Then

                        Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
                        Year = CInt(CurrentPostPeriod.Year) - 1

                    End If

                    Try

                        ComboBoxOptions_PostPeriodStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

                    Catch ex As Exception
                        ComboBoxOptions_PostPeriodStart.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxOptions_PostPeriodEnd.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxOptions_PostPeriodEnd.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonOptions_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOptions_2Years.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Month As Integer = 0
            Dim Year As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    If CurrentPostPeriod IsNot Nothing Then

                        Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
                        Year = CInt(CurrentPostPeriod.Year) - 2

                    End If

                    Try

                        ComboBoxOptions_PostPeriodStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

                    Catch ex As Exception
                        ComboBoxOptions_PostPeriodStart.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxOptions_PostPeriodEnd.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxOptions_PostPeriodEnd.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub TabControlForm_OptionsPresets_SelectedTabChanging(sender As Object, e As TabStripTabChangingEventArgs) Handles TabControlForm_OptionsPresets.SelectedTabChanging

            LoadTab(e.NewTab)

        End Sub
        Private Sub ListBoxOptions_Reports_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBoxOptions_Reports.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                SetupSelectedReportOptions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
