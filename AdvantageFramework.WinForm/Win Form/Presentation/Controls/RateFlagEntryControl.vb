Namespace WinForm.Presentation.Controls

    Public Class RateFlagEntryControl

        Public Event SelectedBillingRateLevelChanging()
        Public Event SelectedBillingRateLevelChanged()
        Public Event SelectedBillingRateDetailChanged()
        Public Event BillingRateDetailInitNewRow()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RateFlagLevels
            [Default]
            Employee
        End Enum

#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _LimitToEmployeeLevels As Boolean = False
        Private _EmployeeCode As String = Nothing
        Private _BillingRateLevels As Generic.List(Of AdvantageFramework.Database.Entities.BillingRateLevel) = Nothing
        Private _RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
        Private _SubItemGridLookUpEditControl_FeeTimes As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
        Private _SubItemGridLookUpEditControl_Markup As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
        Private _SubItemGridLookUpEditControl_EmployeeTitle As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
        Private _SelectedBillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
        Private _HideStructureLevelSelection As Boolean = Nothing
        Private _RepositoryItemCheckEdit_Blank As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
        Private _MarkJobComponentsAsTaxable As Boolean = False
        Private _AllowEdit As Boolean = True
        Private _ViewInactiveBillingRateDetails As Boolean = False
        Private _SelectedLevelDetailCount As Integer = Nothing
        Private _DisableInactiveFilter As Boolean = False
        Private _ShowDescriptions As Boolean = False

#End Region

#Region " Properties "

        Public Property ShowDescriptions As Boolean
            Get
                ShowDescriptions = _ShowDescriptions
            End Get
            Set(ByVal value As Boolean)

                _ShowDescriptions = value

                If ComboBoxForm_BillingRateLevel.HasASelectedValue AndAlso ComboBoxBillingRateLevel.GetSelectedValue <> -1 Then

                    RefreshColumnOrderAndVisibility()

                End If

            End Set
        End Property
        Public Property LimitToEmployeeLevels As Boolean
            Get
                LimitToEmployeeLevels = _LimitToEmployeeLevels
            End Get
            Set(ByVal value As Boolean)
                _LimitToEmployeeLevels = value
            End Set
        End Property
        Public ReadOnly Property BillingRateDetails As Generic.List(Of AdvantageFramework.Database.Classes.BillingRateDetail)
            Get
                BillingRateDetails = DataGridViewForm_BillingRateFlags.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Classes.BillingRateDetail).ToList
            End Get
        End Property
        Public ReadOnly Property SelectedBillingRateDetail As AdvantageFramework.Database.Classes.BillingRateDetail
            Get
                SelectedBillingRateDetail = DirectCast(DataGridViewForm_BillingRateFlags.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Classes.BillingRateDetail)
            End Get
        End Property
        Public ReadOnly Property AllowBillingRateDetailCopy As Boolean
            Get
                AllowBillingRateDetailCopy = CheckIfCanCopyDetailsInSelectedLevel()
            End Get
        End Property
        Public ReadOnly Property AllowCopyByCDP As Boolean
            Get
                AllowCopyByCDP = CheckIfCanCopyByCDP()
            End Get
        End Property
        Public ReadOnly Property HasASelectedBillingRateDetail(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get
                HasASelectedBillingRateDetail = DataGridViewForm_BillingRateFlags.HasASelectedRow(ExcludeNonDataRows)
            End Get
        End Property
        Public ReadOnly Property HasOnlyOneSelectedBillingRateDetail(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get
                HasOnlyOneSelectedBillingRateDetail = DataGridViewForm_BillingRateFlags.HasOnlyOneSelectedRow(ExcludeNonDataRows)
            End Get
        End Property
        Public ReadOnly Property IsSelectedDetailNewItemRow As Boolean
            Get
                IsSelectedDetailNewItemRow = DataGridViewForm_BillingRateFlags.CurrentView.IsNewItemRow(DataGridViewForm_BillingRateFlags.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property ComboBoxBillingRateLevel As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
            Get
                ComboBoxBillingRateLevel = ComboBoxForm_BillingRateLevel
            End Get
        End Property
        Public ReadOnly Property ViewingAll As Boolean
            Get
                ViewingAll = DataGridViewForm_AllBillingRateDetails.Visible
            End Get
        End Property
        Public Property SelectedBillingRateLevel As Short
            Get
                SelectedBillingRateLevel = CShort(ComboBoxBillingRateLevel.GetSelectedValue)
            End Get
            Set(ByVal value As Short)

                Try

                    ComboBoxBillingRateLevel.SelectedValue = CShort(value)

                Catch ex As Exception
                    ComboBoxBillingRateLevel.SelectedIndex = 0
                End Try

            End Set
        End Property
        Public Property HideStructureLevelSelection As Boolean
            Get
                HideStructureLevelSelection = _HideStructureLevelSelection
            End Get
            Set(ByVal value As Boolean)
                _HideStructureLevelSelection = value
                HideStructureLevelSelectionCombobox()
            End Set
        End Property
        Public ReadOnly Property BillingRateFlagsGrid As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                BillingRateFlagsGrid = DataGridViewForm_BillingRateFlags
            End Get
        End Property
        Public Property ViewInactiveBillingRateDetails As Boolean
            Get
                ViewInactiveBillingRateDetails = _ViewInactiveBillingRateDetails
            End Get
            Set(ByVal value As Boolean)
                _ViewInactiveBillingRateDetails = value
                'LoadBillingRateDetails()
            End Set
        End Property
        Public Property DisableInactiveFilter As Boolean
            Get
                DisableInactiveFilter = _DisableInactiveFilter
            End Get
            Set(ByVal value As Boolean)
                _DisableInactiveFilter = value
            End Set
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

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                DataGridViewForm_BillingRateFlags.AutoloadRepositoryDatasource = True
                                DataGridViewForm_BillingRateFlags.AutoFilterLookupColumns = True

                                ComboBoxForm_BillingRateLevel.ByPassUserEntryChanged = True

                                ComboBoxForm_BillingRateLevel.SetPropertySettings(AdvantageFramework.Database.Entities.BillingRateLevel.Properties.ID)

                                _MarkJobComponentsAsTaxable = AdvantageFramework.Database.Procedures.Agency.JobComponentTaxable(DbContext)

                                _SubItemGridLookUpEditControl_Markup = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl
                                _SubItemGridLookUpEditControl_Markup.Session = _Session
                                _SubItemGridLookUpEditControl_Markup.ControlType = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.MarkupTaxFlags

                                _SubItemGridLookUpEditControl_FeeTimes = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl
                                _SubItemGridLookUpEditControl_FeeTimes.Session = _Session
                                _SubItemGridLookUpEditControl_FeeTimes.ControlType = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.FeeTime

                                _SubItemGridLookUpEditControl_EmployeeTitle = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl
                                _SubItemGridLookUpEditControl_EmployeeTitle.Session = _Session
                                _SubItemGridLookUpEditControl_EmployeeTitle.ControlType = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EmployeeTitle

                                _SubItemGridLookUpEditControl_EmployeeTitle.LoadDefaultDataSourceView(DbContext, DataContext)

                                _RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                                _RepositoryItemCheckEdit.DisplayValueChecked = "Yes"
                                _RepositoryItemCheckEdit.DisplayValueUnchecked = "No"
                                _RepositoryItemCheckEdit.DisplayValueGrayed = "Skip"
                                _RepositoryItemCheckEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
                                _RepositoryItemCheckEdit.PictureChecked = AdvantageFramework.My.Resources.SmallGreenCircleImage
                                _RepositoryItemCheckEdit.PictureGrayed = AdvantageFramework.My.Resources.SmallBlueCircleArrowDownImage
                                _RepositoryItemCheckEdit.PictureUnchecked = AdvantageFramework.My.Resources.SmallRedCircleImage
                                _RepositoryItemCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
                                _RepositoryItemCheckEdit.ValueUnchecked = CShort(0)
                                _RepositoryItemCheckEdit.ValueChecked = CShort(1)

                                _RepositoryItemCheckEdit_Blank = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                                _RepositoryItemCheckEdit_Blank.DisplayValueChecked = ""
                                _RepositoryItemCheckEdit_Blank.DisplayValueUnchecked = ""
                                _RepositoryItemCheckEdit_Blank.DisplayValueGrayed = ""
                                _RepositoryItemCheckEdit_Blank.ExportMode = Nothing
                                _RepositoryItemCheckEdit_Blank.PictureChecked = Nothing
                                _RepositoryItemCheckEdit_Blank.PictureGrayed = Nothing
                                _RepositoryItemCheckEdit_Blank.PictureUnchecked = Nothing
                                _RepositoryItemCheckEdit_Blank.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
                                _RepositoryItemCheckEdit_Blank.ValueUnchecked = CShort(0)
                                _RepositoryItemCheckEdit_Blank.ValueChecked = CShort(1)
                                _RepositoryItemCheckEdit_Blank.ValueGrayed = Nothing

                                DataGridViewForm_AllBillingRateDetails.GridControl.RepositoryItems.Add(_RepositoryItemCheckEdit)
                                DataGridViewForm_AllBillingRateDetails.GridControl.RepositoryItems.Add(_SubItemGridLookUpEditControl_Markup)
                                DataGridViewForm_AllBillingRateDetails.GridControl.RepositoryItems.Add(_SubItemGridLookUpEditControl_FeeTimes)
                                DataGridViewForm_AllBillingRateDetails.GridControl.RepositoryItems.Add(_SubItemGridLookUpEditControl_EmployeeTitle)

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadBillingRateLevels()

            'Objects
            Dim GenericList As Generic.List(Of Object) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _BillingRateLevels = (From BillingRateLevel In AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext).ToList
                                      Select BillingRateLevel
                                      Order By BillingRateLevel.Number).ToList

                If Me.LimitToEmployeeLevels Then

                    ComboBoxForm_BillingRateLevel.DataSource = (From Entity In _BillingRateLevels
                                                                Where Entity.IsEmployeeIncluded = 1
                                                                Select Entity).ToList

                Else

                    Try

                        GenericList = New Generic.List(Of Object)

                        For Each BillingRateLevel In _BillingRateLevels

                            GenericList.Add(New With {.ID = BillingRateLevel.ID, .Description = BillingRateLevel.Number & " - " & BillingRateLevel.Description})

                        Next

                        GenericList.Add(New With {.ID = CShort(-1), .Description = "[Show All] - View Only"})
                        ComboBoxForm_BillingRateLevel.DataSource = GenericList

                    Catch ex As Exception

                    End Try

                    'ComboBoxForm_BillingRateLevel.AddComboItemToExistingDataSource("[Show All] - View Only", -1, False)

                End If

            End Using

        End Sub
        Private Sub LoadAllBillingRateDetailGrid()

            Dim EntityInstantFeedbackSource As DevExpress.Data.Linq.EntityInstantFeedbackSource = Nothing
            EntityInstantFeedbackSource = New DevExpress.Data.Linq.EntityInstantFeedbackSource
            EntityInstantFeedbackSource.DesignTimeElementType = GetType(AdvantageFramework.Database.Views.BillingRateDetailView)
            EntityInstantFeedbackSource.KeyExpression = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.ID.ToString

            DataGridViewForm_AllBillingRateDetails.ItemDescription = "Billing Rate Detail(s)"
            DataGridViewForm_AllBillingRateDetails.DataSource = EntityInstantFeedbackSource

        End Sub
        Private Function CheckIfCanCopyDetailsInSelectedLevel() As Boolean

            'objects
            Dim CanCopy As Boolean = False

            If _SelectedBillingRateLevel IsNot Nothing Then

                If Convert.ToBoolean(_SelectedBillingRateLevel.IsClientIncluded.GetValueOrDefault(0)) OrElse
                           Convert.ToBoolean(_SelectedBillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0)) OrElse
                           Convert.ToBoolean(_SelectedBillingRateLevel.IsProductIncluded.GetValueOrDefault(0)) OrElse
                           Convert.ToBoolean(_SelectedBillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0)) OrElse
                           Convert.ToBoolean(_SelectedBillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0)) OrElse
                           Convert.ToBoolean(_SelectedBillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0)) OrElse
                           Convert.ToBoolean(_SelectedBillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0)) Then

                    CanCopy = True

                Else

                    CanCopy = False

                End If

            End If

            CheckIfCanCopyDetailsInSelectedLevel = CanCopy

        End Function
        Private Function CheckIfCanCopyByCDP() As Boolean

            'objects
            Dim CanCopy As Boolean = False

            If _SelectedBillingRateLevel IsNot Nothing Then

                If Convert.ToBoolean(_SelectedBillingRateLevel.IsClientIncluded.GetValueOrDefault(0)) OrElse
                        Convert.ToBoolean(_SelectedBillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0)) OrElse
                        Convert.ToBoolean(_SelectedBillingRateLevel.IsProductIncluded.GetValueOrDefault(0)) Then

                    CanCopy = True

                Else

                    CanCopy = False

                End If

            End If

            CheckIfCanCopyByCDP = CanCopy

        End Function
        Private Sub LoadBillingRateDetails()

            ' objects
            Dim BillingRateLevelID As String = Nothing
            Dim BillingRateDetails As Generic.List(Of AdvantageFramework.Database.Entities.BillingRateDetail) = Nothing
            Dim BillingRateDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.BillingRateDetail) = Nothing
            Dim Functions As Generic.List(Of AdvantageFramework.Database.Core.Function) = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim Divisions As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing
            Dim EntityServerModeSource As Generic.List(Of DevExpress.Data.Linq.EntityServerModeSource) = Nothing

            If ComboBoxForm_BillingRateLevel.HasASelectedValue Then

                BillingRateLevelID = CShort(ComboBoxForm_BillingRateLevel.GetSelectedValue)

                Try

                    If BillingRateLevelID = -1 Then ' -1 = "VIEW ALL"

                        _SelectedBillingRateLevel = Nothing

                        LoadAllBillingRateDetailGrid()

                        DataGridViewForm_AllBillingRateDetails.Visible = True
                        DataGridViewForm_BillingRateFlags.Visible = False

                    Else

                        Try

                            _SelectedBillingRateLevel = (From BillingRateLevel In _BillingRateLevels
                                                         Where BillingRateLevel.ID = BillingRateLevelID
                                                         Select BillingRateLevel).SingleOrDefault

                        Catch ex As Exception
                            _SelectedBillingRateLevel = Nothing
                        End Try

                        If _SelectedBillingRateLevel IsNot Nothing Then

                            Try

                                Try

                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        DbContext.Database.Connection.Open()

                                        'Functions = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).ToList
                                        'Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList
                                        'Clients = AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext).ToList
                                        'Divisions = AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext).ToList
                                        'Products = AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext).ToList
                                        'SalesClasses = AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext).ToList

                                        If _ViewInactiveBillingRateDetails Then

                                            If _EmployeeCode IsNot Nothing Then

                                                'BillingRateDetailsList = (From Entity In AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(DbContext, BillingRateLevelID)
                                                '                          Where Entity.EmployeeCode = _EmployeeCode _
                                                '                          Select Entity).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.BillingRateDetail(Entity, Functions, Employees, Clients, Divisions, Products, SalesClasses)).ToList
                                                'BillingRateDetails = AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(DbContext, BillingRateLevelID).Where(Function(Entity) Entity.EmployeeCode = _EmployeeCode).ToList

                                                BillingRateDetailsList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRateDetail)("EXEC [dbo].[advsp_rate_flag_entry_load] " & BillingRateLevelID & ", '" & _EmployeeCode & "', 1").ToList

                                            Else
                                                '.Include("Function").Include("Employee")
                                                'BillingRateDetailsList = (From Entity In AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(DbContext, BillingRateLevelID).ToList _
                                                '                          Select Entity).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.BillingRateDetail(Entity, Functions, Employees, Clients, Divisions, Products, SalesClasses)).ToList
                                                'BillingRateDetails = AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(DbContext, BillingRateLevelID).ToList

                                                BillingRateDetailsList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRateDetail)("EXEC [dbo].[advsp_rate_flag_entry_load] " & BillingRateLevelID & ", '', 1").ToList

                                            End If

                                        Else

                                            If _EmployeeCode IsNot Nothing Then

                                                'BillingRateDetailsList = (From Entity In AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(DbContext, BillingRateLevelID) _
                                                '                          Where Entity.EmployeeCode = _EmployeeCode AndAlso
                                                '                                (Entity.IsInactive Is Nothing OrElse _
                                                '                                 Entity.IsInactive = CShort(0)) _
                                                '                          Select Entity).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.BillingRateDetail(Entity, Functions, Employees, Clients, Divisions, Products, SalesClasses)).ToList
                                                'BillingRateDetails = AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(DbContext, BillingRateLevelID).Where(Function(Entity) Entity.EmployeeCode = _EmployeeCode  AndAlso (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = CShort(0))).ToList

                                                BillingRateDetailsList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRateDetail)("EXEC [dbo].[advsp_rate_flag_entry_load] " & BillingRateLevelID & ", '" & _EmployeeCode & "', 0").ToList

                                            Else

                                                'BillingRateDetailsList = (From Entity In AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(DbContext, BillingRateLevelID) _
                                                '                          Where Entity.IsInactive Is Nothing OrElse _
                                                '                                Entity.IsInactive = CShort(0) _
                                                '                          Select Entity).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.BillingRateDetail(Entity, Functions, Employees, Clients, Divisions, Products, SalesClasses)).ToList
                                                'BillingRateDetails = AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(DbContext, BillingRateLevelID).Where(Function(Entity) (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = CShort(0))).ToList

                                                BillingRateDetailsList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRateDetail)("EXEC [dbo].[advsp_rate_flag_entry_load] " & BillingRateLevelID & ", '', 0").ToList

                                            End If

                                        End If

                                        'BillingRateDetailsList = (From BillingRateDetail In BillingRateDetails _
                                        '                          From [Function] In Functions.Where(Function(Entity) Entity.Code = BillingRateDetail.FunctionCode).DefaultIfEmpty _
                                        '                          From Employee In Employees.Where(Function(Entity) Entity.Code = BillingRateDetail.EmployeeCode).DefaultIfEmpty _
                                        '                          From Client In Clients.Where(Function(Entity) Entity.Code = BillingRateDetail.ClientCode).DefaultIfEmpty _
                                        '                          From Division In Divisions.Where(Function(Entity) Entity.ClientCode = BillingRateDetail.ClientCode AndAlso Entity.Code = BillingRateDetail.DivisionCode).DefaultIfEmpty _
                                        '                          From Product In Products.Where(Function(Entity) Entity.ClientCode = BillingRateDetail.ClientCode AndAlso Entity.DivisionCode = BillingRateDetail.DivisionCode AndAlso Entity.Code = BillingRateDetail.ProductCode).DefaultIfEmpty _
                                        '                          From SalesClass In SalesClasses.Where(Function(Entity) Entity.Code = BillingRateDetail.SalesClassCode).DefaultIfEmpty _
                                        '                          Select New AdvantageFramework.Database.Classes.BillingRateDetail(BillingRateDetail, [Function], Employee, Client, Division, Product, SalesClass)).ToList

                                        DbContext.Database.Connection.Close()

                                    End Using

                                Catch ex As Exception
                                    BillingRateDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.BillingRateDetail)
                                End Try

                                If _SelectedBillingRateLevel IsNot Nothing Then

                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                            If _SelectedBillingRateLevel.IsClientIncluded Then

                                                If _SelectedBillingRateLevel.IsDivisionIncluded AndAlso _SelectedBillingRateLevel.IsProductIncluded Then

                                                    Products = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, False).ToList

                                                    BillingRateDetailsList = (From BillingRateDetail In BillingRateDetailsList
                                                                              Where Products.Any(Function(Entity) Entity.ClientCode = BillingRateDetail.ClientCode AndAlso Entity.DivisionCode = BillingRateDetail.DivisionCode AndAlso Entity.Code = BillingRateDetail.ProductCode) = True
                                                                              Select BillingRateDetail).ToList

                                                ElseIf _SelectedBillingRateLevel.IsDivisionIncluded AndAlso _SelectedBillingRateLevel.IsProductIncluded = False Then

                                                    Divisions = AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList

                                                    BillingRateDetailsList = (From BillingRateDetail In BillingRateDetailsList
                                                                              Where Divisions.Any(Function(Entity) Entity.ClientCode = BillingRateDetail.ClientCode AndAlso Entity.Code = BillingRateDetail.DivisionCode) = True
                                                                              Select BillingRateDetail).ToList

                                                ElseIf _SelectedBillingRateLevel.IsDivisionIncluded = False AndAlso _SelectedBillingRateLevel.IsProductIncluded = False Then

                                                    Clients = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList

                                                    BillingRateDetailsList = (From BillingRateDetail In BillingRateDetailsList
                                                                              Where Clients.Any(Function(Entity) Entity.Code = BillingRateDetail.ClientCode) = True
                                                                              Select BillingRateDetail).ToList

                                                End If

                                            End If

                                            If _SelectedBillingRateLevel.IsEmployeeIncluded Then

                                                Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList

                                                BillingRateDetailsList = (From BillingRateDetail In BillingRateDetailsList
                                                                          Where Employees.Any(Function(Entity) Entity.Code = BillingRateDetail.EmployeeCode) = True
                                                                          Select BillingRateDetail).ToList

                                            End If

                                        End Using

                                    End Using

                                End If

                                ModifyEntitySet(BillingRateDetailsList)

                                DataGridViewForm_BillingRateFlags.Visible = True
                                DataGridViewForm_AllBillingRateDetails.Visible = False

                                DataGridViewForm_BillingRateFlags.CurrentView.BeginUpdate()

                                _SelectedLevelDetailCount = BillingRateDetailsList.Count

                                DataGridViewForm_BillingRateFlags.DataSource = BillingRateDetailsList

                                DataGridViewForm_BillingRateFlags.CurrentView.BestFitColumns()

                                DataGridViewForm_BillingRateFlags.CurrentView.EndUpdate()

                                SetColumnOrderAndVisibility()
                                HideOrShowNewItemRow()

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub HideStructureLevelSelectionCombobox()

            PanelControl_TopSection.Visible = Not _HideStructureLevelSelection

        End Sub
        Private Function IsFieldIncluded(ByVal FieldName As String) As Boolean

            'objects
            Dim IsIncluded As Boolean = False

            Try

                Select Case FieldName

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientCode.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsClientIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientName.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsClientIncluded.GetValueOrDefault(0))

                        If IsIncluded Then

                            IsIncluded = _ShowDescriptions

                        End If

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionName.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0))

                        If IsIncluded Then

                            IsIncluded = _ShowDescriptions

                        End If

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsProductIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductName.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsProductIncluded.GetValueOrDefault(0))

                        If IsIncluded Then

                            IsIncluded = _ShowDescriptions

                        End If

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductOfficeCode.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsProductIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.SalesClassCode.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.SalesClassDescription.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0))

                        If IsIncluded Then

                            IsIncluded = _ShowDescriptions

                        End If

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionCode.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionDescription.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))

                        If IsIncluded Then

                            IsIncluded = _ShowDescriptions

                        End If

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionType.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeTitleID.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeName.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0))

                        If IsIncluded Then

                            IsIncluded = _ShowDescriptions

                        End If

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeOfficeCode.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.CurrentEmployeeTitleID.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EffectiveDate.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsEffectiveDateIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.RateAmount.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsBillingRateDetailIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsNonBillable.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsNonBillableIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsCommission.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsCommissionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTaxCommission.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCommission.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCommissionOnly.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTax.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsTaxIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCode.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsTaxIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsFeeTime.ToString

                        IsIncluded = CBool(_SelectedBillingRateLevel.IsFeeTimeIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsInactive.ToString

                        IsIncluded = True

                End Select

            Catch ex As Exception

            End Try

            IsFieldIncluded = IsIncluded

        End Function

#Region "   Grid Layout "

        Private Sub SortByFirstIncludedLevel()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            Try

                GridColumn = DataGridViewForm_BillingRateFlags.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(GridCol) GridCol.VisibleIndex = 0).FirstOrDefault

            Catch ex As Exception
                GridColumn = Nothing
            End Try

            If GridColumn IsNot Nothing Then

                DataGridViewForm_BillingRateFlags.CurrentView.BeginUpdate()
                DataGridViewForm_BillingRateFlags.CurrentView.BeginDataUpdate()

                GridColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                DataGridViewForm_BillingRateFlags.CurrentView.EndDataUpdate()
                DataGridViewForm_BillingRateFlags.CurrentView.EndUpdate()

                GridColumn.BestFit()

            End If

        End Sub
        Private Sub ColumnWorker(ByVal FieldName As String, ByVal IsIncluded As Boolean, ByRef VisibleIndex As Integer)

            If DataGridViewForm_BillingRateFlags.CurrentView.Columns(FieldName) IsNot Nothing Then

                DataGridViewForm_BillingRateFlags.CurrentView.Columns(FieldName).Visible = IsIncluded

                If IsIncluded Then

                    DataGridViewForm_BillingRateFlags.CurrentView.Columns(FieldName).VisibleIndex = VisibleIndex

                    VisibleIndex = VisibleIndex + 1

                End If

            End If

        End Sub
        Private Sub HideOrShowColumn(ByVal FieldName As String, ByRef VisibleIndex As Integer)

            'objects
            Dim Visible As Boolean = False
            Dim ShowMarkupTaxFlagsBreakDownColumns As Boolean = Nothing

            If DataGridViewForm_BillingRateFlags.CurrentView.Columns(FieldName) IsNot Nothing Then

                Select Case FieldName

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString,
                         AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeName.ToString,
                         AdvantageFramework.Database.Classes.BillingRateDetail.Properties.CurrentEmployeeTitleID.ToString

                        If _EmployeeCode IsNot Nothing Then

                            Visible = False

                        Else

                            Visible = IsFieldIncluded(FieldName)

                        End If

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCommission.ToString,
                         AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCommissionOnly.ToString

                        ShowMarkupTaxFlagsBreakDownColumns = DataGridViewForm_AllBillingRateDetails.Visible

                        Visible = If(IsFieldIncluded(FieldName), ShowMarkupTaxFlagsBreakDownColumns, False)

                    Case Else

                        Visible = IsFieldIncluded(FieldName)

                End Select

                DataGridViewForm_BillingRateFlags.CurrentView.Columns(FieldName).Visible = Visible
                DataGridViewForm_BillingRateFlags.CurrentView.Columns(FieldName).SortMode = DevExpress.XtraGrid.ColumnSortMode.Value

                If DataGridViewForm_BillingRateFlags.CurrentView.Columns(FieldName).Visible Then

                    DataGridViewForm_BillingRateFlags.CurrentView.Columns(FieldName).VisibleIndex = VisibleIndex

                    VisibleIndex = VisibleIndex + 1

                End If

            End If

        End Sub
        Private Sub ModifyEntitySet(ByVal BillingRateDetails As Generic.List(Of AdvantageFramework.Database.Classes.BillingRateDetail))

            'objects
            Dim EmployeeVisible As Boolean = False
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim ShowMarkupTaxFlagsBreakDownColumns As Boolean = False

            If BillingRateDetails IsNot Nothing Then

                BillingRateLevel = _SelectedBillingRateLevel

                If _EmployeeCode IsNot Nothing Then

                    EmployeeVisible = False

                Else

                    EmployeeVisible = Convert.ToBoolean(_SelectedBillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0))

                End If

                ShowMarkupTaxFlagsBreakDownColumns = DataGridViewForm_AllBillingRateDetails.Visible

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Classes.BillingRateDetail)).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    Try

                        EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                    Catch ex As Exception
                        EntityAttribute = Nothing
                    End Try

                    If EntityAttribute IsNot Nothing Then

                        Select Case PropertyDescriptor.Name

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientCode.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsClientIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsProductIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductOfficeCode.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsProductIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.SalesClassCode.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionCode.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionType.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeTitleID.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString

                                EntityAttribute.ShowColumnInGrid = EmployeeVisible

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.CurrentEmployeeTitleID.ToString

                                EntityAttribute.ShowColumnInGrid = EmployeeVisible

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeOfficeCode.ToString

                                EntityAttribute.ShowColumnInGrid = EmployeeVisible

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EffectiveDate.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsEffectiveDateIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.RateAmount.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsBillingRateDetailIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsNonBillable.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsNonBillableIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsCommission.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsCommissionIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTaxCommission.ToString

                                EntityAttribute.ShowColumnInGrid = If(CBool(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0)), Not ShowMarkupTaxFlagsBreakDownColumns, False)

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCommission.ToString

                                EntityAttribute.ShowColumnInGrid = If(CBool(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0)), ShowMarkupTaxFlagsBreakDownColumns, False)

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCommissionOnly.ToString

                                EntityAttribute.ShowColumnInGrid = If(CBool(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0)), ShowMarkupTaxFlagsBreakDownColumns, False)

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTax.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsTaxIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCode.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsTaxIncluded.GetValueOrDefault(0))

                            Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsFeeTime.ToString

                                EntityAttribute.ShowColumnInGrid = CBool(BillingRateLevel.IsFeeTimeIncluded.GetValueOrDefault(0))

                        End Select

                    End If

                Next

            End If

        End Sub
        Private Sub SetColumnOrderAndVisibility()

            If ComboBoxForm_BillingRateLevel.HasASelectedValue AndAlso ComboBoxBillingRateLevel.GetSelectedValue <> -1 Then

                DataGridViewForm_BillingRateFlags.CurrentView.ClearSorting()

                RefreshColumnOrderAndVisibility()

                SortByFirstIncludedLevel()

            End If

        End Sub
        Private Sub RefreshColumnOrderAndVisibility()

            'objects
            Dim ColumnVisibleIndex As Integer = Nothing

            ColumnVisibleIndex = 1

            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductOfficeCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.SalesClassCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.SalesClassDescription.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionDescription.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionType.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeTitleID.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeOfficeCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.CurrentEmployeeTitleID.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EffectiveDate.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.RateAmount.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsNonBillable.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsCommission.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTaxCommission.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCommission.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCommissionOnly.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTax.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsFeeTime.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsInactive.ToString, ColumnVisibleIndex)

        End Sub
        Private Sub HideOrShowNewItemRow()

            Dim VisibleKeyColumns As Short = Nothing

            If _AllowEdit Then

                If ComboBoxForm_BillingRateLevel.HasASelectedValue Then

                    If DataGridViewForm_BillingRateFlags.CurrentView.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString).Visible Then
                        VisibleKeyColumns = VisibleKeyColumns + 1
                    End If
                    If DataGridViewForm_BillingRateFlags.CurrentView.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionCode.ToString).Visible Then
                        VisibleKeyColumns = VisibleKeyColumns + 1
                    End If
                    If DataGridViewForm_BillingRateFlags.CurrentView.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientCode.ToString).Visible Then
                        VisibleKeyColumns = VisibleKeyColumns + 1
                    End If
                    If DataGridViewForm_BillingRateFlags.CurrentView.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString).Visible Then
                        VisibleKeyColumns = VisibleKeyColumns + 1
                    End If
                    If DataGridViewForm_BillingRateFlags.CurrentView.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString).Visible Then
                        VisibleKeyColumns = VisibleKeyColumns + 1
                    End If
                    If DataGridViewForm_BillingRateFlags.CurrentView.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.SalesClassCode.ToString).Visible Then
                        VisibleKeyColumns = VisibleKeyColumns + 1
                    End If
                    If DataGridViewForm_BillingRateFlags.CurrentView.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeTitleID.ToString).Visible Then
                        VisibleKeyColumns = VisibleKeyColumns + 1
                    End If

                    If VisibleKeyColumns = 0 AndAlso _SelectedLevelDetailCount > 0 Then

                        DataGridViewForm_BillingRateFlags.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                    Else

                        DataGridViewForm_BillingRateFlags.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                    End If

                End If

            End If

        End Sub
        Private Sub ModifyCellStyle(ByRef Cell As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs, ByVal IsIncluded As Boolean)

            If IsIncluded = False Then

                Cell.Appearance.BackColor = Drawing.Color.LightGray

            End If

        End Sub

#End Region

#Region "   Public "

        Public Function Save() As Boolean

            'objects
            Dim BillingRateDetails As Generic.List(Of AdvantageFramework.Database.Entities.BillingRateDetail) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ErrorText As String = Nothing
            Dim IsValid As Boolean = True
            Dim Saved As Boolean = True

            AdvantageFramework.WinForm.Presentation.ShowWaitForm("Saving...")

            Try

                CloseEditorForUpdating()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    BillingRateDetails = Me.BillingRateDetails.Select(Function(Entity) Entity.GetBillingRateDetail(DbContext)).ToList

                    For Each BillingRateDetail In BillingRateDetails

                        Try

                            DbContext.UpdateObject(BillingRateDetail)

                            ErrorText = BillingRateDetail.ValidateEntity(IsValid)

                            If IsValid = False Then

                                DbContext.UndoChanges(BillingRateDetail)

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    Try

                        DbContext.SaveChanges()

                    Catch ex As Exception

                    End Try

                End Using

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadBillingRateDetails()

                Catch ex As Exception

                End Try

            Catch ex As Exception
                Saved = False
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim BillingRateDetailList As Generic.List(Of AdvantageFramework.Database.Classes.BillingRateDetail) = Nothing
            Dim BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec = Nothing
            Dim OneOrMoreDeleted As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        BillingRateDetailList = DataGridViewForm_BillingRateFlags.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.BillingRateDetail).ToList

                    Catch ex As Exception
                        BillingRateDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.BillingRateDetail)
                    End Try

                    If BillingRateDetailList IsNot Nothing AndAlso BillingRateDetailList.Count > 0 Then

                        For Each BillingRateDetail In BillingRateDetailList.Select(Function(Entity) Entity.GetBillingRateDetail(DbContext)).ToList

                            If AdvantageFramework.Database.Procedures.BillingRateDetail.Delete(DbContext, BillingRateDetail) = False Then

                                ErrorMessage = "One of more billing rate details could not be deleted. Please contact software support."

                            Else

                                OneOrMoreDeleted = True

                            End If

                        Next

                        If OneOrMoreDeleted Then

                            LoadBillingRateDetails()

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = OneOrMoreDeleted

        End Function
        Public Function LoadControl(Optional ByVal EmployeeCode As String = Nothing, Optional ByVal BillingRateLevelID As Short = Nothing, Optional ByVal ViewAll As Boolean = False, Optional ByVal ShowDescriptions As Boolean = False) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim SetDefaultFilterString As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _EmployeeCode = EmployeeCode
                _ShowDescriptions = ShowDescriptions

                LoadBillingRateLevels()

                If BillingRateLevelID <> Nothing Then

                    Try

                        ComboBoxForm_BillingRateLevel.SelectedValue = CShort(BillingRateLevelID)

                    Catch ex As Exception

                    End Try

                ElseIf ViewAll Then

                    Try

                        ComboBoxForm_BillingRateLevel.SelectedValue = CShort(-1)

                    Catch ex As Exception
                        ComboBoxForm_BillingRateLevel.SelectedIndex = 0
                    End Try

                    If DataGridViewForm_AllBillingRateDetails.DataSource Is Nothing Then

                        SetDefaultFilterString = True

                    End If

                End If

                LoadBillingRateDetails()

                If SetDefaultFilterString Then

                    Try

                        DataGridViewForm_AllBillingRateDetails.CurrentView.ActiveFilterString = "[IsInactive] = 0s"

                    Catch ex As Exception

                    End Try

                End If

            End Using

            If _DisableInactiveFilter = False Then

                Try

                    DataGridViewForm_BillingRateFlags.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

                Catch ex As Exception

                End Try

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub DisableEdit()

            _AllowEdit = False

            DataGridViewForm_BillingRateFlags.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_BillingRateFlags.CurrentView.OptionsBehavior.Editable = False

        End Sub
        Public Sub CopySelectedRateFlag()

            'objects
            Dim BillingRateDetailIDs As Generic.List(Of Integer) = Nothing

            BillingRateDetailIDs = DataGridViewForm_BillingRateFlags.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

            If AdvantageFramework.Maintenance.Billing.Presentation.BillRateCopyDialog.ShowFormDialog(ComboBoxForm_BillingRateLevel.GetSelectedValue, BillingRateDetailIDs) = Windows.Forms.DialogResult.OK Then

                LoadBillingRateDetails()

            End If

        End Sub
        Public Sub CopyByCDP()

            'objects
            Dim BillingRateDetail As AdvantageFramework.Database.Classes.BillingRateDetail = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            Try

                BillingRateDetail = DataGridViewForm_BillingRateFlags.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                BillingRateDetail = Nothing
            End Try

            If BillingRateDetail IsNot Nothing Then

                ClientCode = BillingRateDetail.ClientCode
                DivisionCode = BillingRateDetail.DivisionCode
                ProductCode = BillingRateDetail.ProductCode

            End If

            If AdvantageFramework.Maintenance.Billing.Presentation.BillRateCopyCDPDialog.ShowFormDialog(ComboBoxForm_BillingRateLevel.GetSelectedValue, ClientCode, DivisionCode, ProductCode) = Windows.Forms.DialogResult.OK Then

                LoadBillingRateDetails()

            End If

        End Sub
        Public Sub CloseEditorForUpdating()

            DataGridViewForm_BillingRateFlags.CurrentView.CloseEditorForUpdating()

        End Sub
        Public Sub CancelNewItemRow()

            DataGridViewForm_BillingRateFlags.CancelNewItemRow()

        End Sub
        Public Sub ExportAllBillingRateDetails()

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                If DataGridViewForm_AllBillingRateDetails.HasRows = False Then

                    LoadAllBillingRateDetailGrid()

                End If

                DataGridViewForm_AllBillingRateDetails.Print(DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End If

        End Sub
        Public Sub ExportBillingRateDetails()

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                If DataGridViewForm_AllBillingRateDetails.Visible Then

                    DataGridViewForm_AllBillingRateDetails.Print(DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

                ElseIf DataGridViewForm_BillingRateFlags.Visible Then

                    DataGridViewForm_BillingRateFlags.Print(DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

                End If

            End If

        End Sub
        Public Sub ViewAll()

            Try

                ComboBoxForm_BillingRateLevel.SelectedValue = CShort(-1)

            Catch ex As Exception
                ComboBoxForm_BillingRateLevel.SelectedIndex = 0
            End Try

            LoadBillingRateDetails()

        End Sub
        Public Sub ClearControl()

            DataGridViewForm_BillingRateFlags.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.BillingRateDetail))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub RefreshSelectedRateFlag()

            LoadBillingRateDetails()

        End Sub
        Public Sub RefreshBillingRateLevels()

            LoadBillingRateLevels()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub RateFlagEntryControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ComboBoxForm_BillingRateLevel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_BillingRateLevel.SelectionChangeCommitted

            RaiseEvent SelectedBillingRateLevelChanging()

            DataGridViewForm_BillingRateFlags.CancelNewItemRow()

            LoadBillingRateDetails()

            RaiseEvent SelectedBillingRateLevelChanged()

        End Sub

#Region "    Selected Level Detail Grid "

        Private Sub DataGridViewForm_BillingRateFlags_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_BillingRateFlags.AddNewRowEvent

            'objects
            Dim BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing
            Dim Inserted As Boolean = False

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.BillingRateDetail Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    BillingRateDetail = DirectCast(RowObject, AdvantageFramework.Database.Classes.BillingRateDetail).GetBillingRateDetail(DbContext)

                    If BillingRateDetail.IsEntityBeingAdded() Then

                        BillingRateDetail.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.BillingRateDetail.Insert(DbContext, BillingRateDetail) = True Then

                            Inserted = True

                        End If

                        LoadBillingRateDetails()

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_BillingRateFlags.CellValueChangingEvent

            Dim ClientCode As String = Nothing
            Dim IsInactive As Boolean = Nothing
            Dim Refresh As Boolean = False
            Dim BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing
            Dim BillingRateDetailClass As AdvantageFramework.Database.Classes.BillingRateDetail = Nothing
            Dim FunctionCode As String = Nothing
            Dim FunctionType As String = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientCode.ToString Then

                Saved = False

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString Then

                Saved = False

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionCode.ToString Then

                FunctionCode = e.Value

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        FunctionType = AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext).SingleOrDefault(Function(Entity) Entity.Code = FunctionCode).Type

                    Catch ex As Exception
                        FunctionType = Nothing
                    End Try

                End Using

                DataGridViewForm_BillingRateFlags.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionType.ToString, FunctionType)

                Saved = False

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTax.ToString Then

                If IsNumeric(e.Value) = False OrElse e.Value <> AdvantageFramework.Database.Entities.Yes1No0.Yes Then

                    DataGridViewForm_BillingRateFlags.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCode.ToString, Nothing)

                    Saved = False

                End If

            ElseIf e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsInactive.ToString Then

                Try

                    BillingRateDetailClass = DirectCast(DataGridViewForm_BillingRateFlags.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.BillingRateDetail)

                Catch ex As Exception
                    BillingRateDetailClass = Nothing
                End Try

                If BillingRateDetailClass IsNot Nothing Then

                    Try

                        BillingRateDetailClass.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        BillingRateDetailClass.IsInactive = BillingRateDetailClass.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            BillingRateDetail = BillingRateDetailClass.GetBillingRateDetail(DbContext)

                            Saved = AdvantageFramework.Database.Procedures.BillingRateDetail.Update(DbContext, BillingRateDetail)

                            If Not Saved Then

                                DbContext.UndoChanges(BillingRateDetail)

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_CustomColumnDisplayTextEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_BillingRateFlags.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCode.ToString AndAlso e.Column.Visible Then

                If _SelectedBillingRateLevel IsNot Nothing AndAlso Convert.ToBoolean(_SelectedBillingRateLevel.IsTaxIncluded.GetValueOrDefault(0)) Then

                    If _MarkJobComponentsAsTaxable Then

                        e.DisplayText = "[Job]"
                        e.Column.ColumnEdit.ReadOnly = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_CustomRowCellEditEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_BillingRateFlags.CustomRowCellEditEvent

            ''objects
            'Dim FunctionType As String = ""
            'Dim FunctionCode As String = Nothing

            'If e.Column.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsFeeTime.ToString AndAlso _
            '   e.Column.Visible Then

            '    FunctionCode = DataGridViewForm_BillingRateFlags.CurrentView.GetRowCellValue(e.RowHandle, DataGridViewForm_BillingRateFlags.CurrentView.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionCode.ToString))

            '    If FunctionCode IsNot Nothing Then

            '        Try

            '            FunctionType = (From [Function] In _Functions _
            '                            Where [Function].Code = FunctionCode _
            '                            Select [Function].Type).SingleOrDefault

            '        Catch ex As Exception
            '            FunctionType = ""
            '        End Try

            '    End If

            '    If FunctionType <> "E" Then

            '        e.RepositoryItem = _RepositoryItemCheckEdit_Blank
            '        e.RepositoryItem.ReadOnly = True

            '    Else

            '        e.RepositoryItem = DataGridViewForm_BillingRateFlags.CurrentView.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsFeeTime.ToString).ColumnEdit
            '        e.RepositoryItem.ReadOnly = False

            '    End If

            'End If

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_BillingRateFlags.InitNewRowEvent

            ' objects
            Dim BillingRateLevelID As String = Nothing
            Dim BillRateLevel As String = Nothing

            If TypeOf DataGridViewForm_BillingRateFlags.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.BillingRateDetail Then

                BillingRateLevelID = ComboBoxForm_BillingRateLevel.GetSelectedValue

                DataGridViewForm_BillingRateFlags.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.BillingRateDetail.Properties.BillingRateLevelID.ToString, BillingRateLevelID)

                BillRateLevel = DataGridViewForm_BillingRateFlags.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.BillingRateDetail.Properties.BillingRateLevelID.ToString)

                If _EmployeeCode IsNot Nothing Then

                    DataGridViewForm_BillingRateFlags.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString, _EmployeeCode)

                End If

                If DataGridViewForm_BillingRateFlags.Columns(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EffectiveDate.ToString).Visible Then

                    DataGridViewForm_BillingRateFlags.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EffectiveDate.ToString, Now.ToShortDateString)

                End If

            End If

            RaiseEvent BillingRateDetailInitNewRow()

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_BillingRateFlags.ShownEditorEvent

            'objects
            Dim TaxFlag As Boolean = False
            Dim BillingRateDetail As AdvantageFramework.Database.Classes.BillingRateDetail = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim DataSource As Object = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    BillingRateDetail = DataGridViewForm_BillingRateFlags.CurrentView.GetRow(DataGridViewForm_BillingRateFlags.CurrentView.FocusedRowHandle)

                Catch ex As Exception
                    BillingRateDetail = Nothing
                End Try

                If TypeOf DataGridViewForm_BillingRateFlags.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DataGridViewForm_BillingRateFlags.CurrentView.ActiveEditor

                    If DataGridViewForm_BillingRateFlags.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCode.ToString Then

                        If BillingRateDetail IsNot Nothing Then

                            If CBool(BillingRateDetail.IsTax.GetValueOrDefault(0)) = False Then

                                DataGridViewForm_BillingRateFlags.CurrentView.CloseEditor()

                            End If

                        End If

                    ElseIf DataGridViewForm_BillingRateFlags.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionCode.ToString Then

                        If IsFieldIncluded(AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString) Then

                            GridLookUpEdit.Properties.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditActiveByType(DbContext, "E")

                        Else

                            GridLookUpEdit.Properties.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditAllActive(DbContext)

                        End If

                    End If

                End If

            End Using

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_BillingRateFlags.SelectionChangedEvent

            RaiseEvent SelectedBillingRateDetailChanged()

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_ShowingEditorEvent(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_BillingRateFlags.ShowingEditorEvent

            If _AllowEdit = False Then

                e.Cancel = True

            ElseIf DataGridViewForm_BillingRateFlags.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCode.ToString Then

                If _MarkJobComponentsAsTaxable Then

                    e.Cancel = True

                    Try

                        DataGridViewForm_BillingRateFlags.CurrentView.FocusedColumn = (From GridColumn In DataGridViewForm_BillingRateFlags.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()
                                                                                       Where GridColumn.VisibleIndex = (DataGridViewForm_BillingRateFlags.CurrentView.FocusedColumn.VisibleIndex + 1)
                                                                                       Select GridColumn).FirstOrDefault

                    Catch ex As Exception

                    End Try

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_RepositoryDataSourceLoading(ByVal FieldName As String, ByRef Cancel As Boolean) Handles DataGridViewForm_BillingRateFlags.RepositoryDataSourceLoading

            'objects
            'Dim FieldNamesToBypass() As String = Nothing

            'FieldNamesToBypass = {AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientCode.ToString, _
            '                      AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString, _
            '                      AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString, _
            '                      AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString, _
            '                      AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeTitleID.ToString, _
            '                      AdvantageFramework.Database.Classes.BillingRateDetail.Properties.CurrentEmployeeTitleID.ToString}

            'If FieldNamesToBypass.Contains(FieldName) Then

            '    Cancel = True

            'Else

            '    Cancel = Not IsFieldIncluded(FieldName)

            'End If

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_CanAutoFillValueEvent(ByRef CanAutoFillValue As Boolean, PropertyDescriptor As ComponentModel.PropertyDescriptor) Handles DataGridViewForm_BillingRateFlags.CanAutoFillValueEvent

            If PropertyDescriptor IsNot Nothing Then

                CanAutoFillValue = IsFieldIncluded(PropertyDescriptor.Name)

            End If

        End Sub
        Private Sub DataGridViewForm_BillingRateFlags_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_BillingRateFlags.QueryPopupNeedDatasourceEvent

            'objects
            Dim BillingRateDetail As AdvantageFramework.Database.Classes.BillingRateDetail = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            Try

                BillingRateDetail = DataGridViewForm_BillingRateFlags.CurrentView.GetFocusedRow

            Catch ex As Exception
                BillingRateDetail = Nothing
            End Try

            If BillingRateDetail IsNot Nothing Then

                ClientCode = BillingRateDetail.ClientCode
                DivisionCode = BillingRateDetail.DivisionCode
                ProductCode = BillingRateDetail.ProductCode

            End If

            OverrideDefaultDatasource = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Select Case FieldName

                        Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString

                            Datasource = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Include("DepartmentTeam").Include("Office").ToList

                            If Datasource IsNot Nothing Then

                                Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Datasource)

                            End If

                        Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientCode.ToString

                            Datasource = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList

                            If Datasource IsNot Nothing Then

                                Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Datasource)

                            End If

                        Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString

                            Datasource = AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Where(Function(Entity) Entity.ClientCode = ClientCode).ToList

                            If Datasource IsNot Nothing Then

                                Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Datasource)

                            End If

                        Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString

                            Datasource = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, False).Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode).ToList

                            If Datasource IsNot Nothing Then

                                Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Datasource)

                            End If

                        Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeTitleID.ToString, AdvantageFramework.Database.Classes.BillingRateDetail.Properties.CurrentEmployeeTitleID.ToString

                            Datasource = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext).ToList

                        Case Else

                            OverrideDefaultDatasource = False

                    End Select

                End Using

            End Using

        End Sub

#End Region

#Region "    All Details Grid "

        Private Sub DataGridViewForm_AllBillingRateDetails_CustomColumnDisplayTextEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_AllBillingRateDetails.CustomColumnDisplayTextEvent

            'objects
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            If DataGridViewForm_AllBillingRateDetails.CurrentView.IsRowLoaded(DataGridViewForm_AllBillingRateDetails.CurrentView.GetRowHandle(e.ListSourceRowIndex)) Then

                If e.Column.FieldName = AdvantageFramework.Database.Views.BillingRateDetailView.Properties.TaxCode.ToString Then

                    Try

                        BillingRateLevel = (From Entity In _BillingRateLevels
                                            Where Entity.Number = DataGridViewForm_AllBillingRateDetails.CurrentView.GetRowCellValue(DataGridViewForm_AllBillingRateDetails.CurrentView.GetRowHandle(e.ListSourceRowIndex), AdvantageFramework.Database.Views.BillingRateDetailView.Properties.Number.ToString)
                                            Select Entity).FirstOrDefault

                    Catch ex As Exception
                        BillingRateLevel = Nothing
                    End Try

                    If BillingRateLevel IsNot Nothing AndAlso Convert.ToBoolean(BillingRateLevel.IsTaxIncluded.GetValueOrDefault(0)) Then

                        If _MarkJobComponentsAsTaxable Then

                            e.DisplayText = "[Job]"

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_AllBillingRateDetails_CustomRowCellEditEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_AllBillingRateDetails.CustomRowCellEditEvent

            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim BillingRateLevelID As Integer = Nothing
            Dim FunctionType As String = Nothing

            If DataGridViewForm_AllBillingRateDetails.CurrentView.IsRowLoaded(e.RowHandle) Then

                Try

                    BillingRateLevel = (From Entity In _BillingRateLevels
                                        Where Entity.Number = DataGridViewForm_AllBillingRateDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Views.BillingRateDetailView.Properties.Number.ToString)
                                        Select Entity).FirstOrDefault

                Catch ex As Exception
                    BillingRateLevel = Nothing
                End Try

                Try

                    FunctionType = DataGridViewForm_AllBillingRateDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Views.BillingRateDetailView.Properties.FunctionType.ToString)

                Catch ex As Exception
                    FunctionType = ""
                End Try

                If BillingRateLevel IsNot Nothing Then

                    Select Case e.Column.FieldName

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsNonBillable.ToString

                            If CBool(BillingRateLevel.IsNonBillableIncluded.GetValueOrDefault(0)) Then

                                e.RepositoryItem = _RepositoryItemCheckEdit

                            End If

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.BillingRate.ToString

                            If CBool(BillingRateLevel.IsBillingRateDetailIncluded.GetValueOrDefault(0)) Then

                                If e.CellValue Is Nothing Then

                                    e.RepositoryItem = _RepositoryItemCheckEdit

                                End If

                            End If

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.TaxFlag.ToString

                            If CBool(BillingRateLevel.IsTaxIncluded.GetValueOrDefault(0)) Then

                                e.RepositoryItem = _RepositoryItemCheckEdit

                            End If

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsCommission.ToString

                            If CBool(BillingRateLevel.IsCommissionIncluded.GetValueOrDefault(0)) Then

                                If e.CellValue Is Nothing Then

                                    e.RepositoryItem = _RepositoryItemCheckEdit

                                End If

                            End If

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsFeeTime.ToString

                            If CBool(BillingRateLevel.IsFeeTimeIncluded.GetValueOrDefault(0)) Then

                                If e.CellValue Is Nothing OrElse FunctionType <> "E" Then

                                    e.RepositoryItem = _RepositoryItemCheckEdit

                                Else

                                    If _SubItemGridLookUpEditControl_FeeTimes.DataSource Is Nothing Then

                                        _SubItemGridLookUpEditControl_FeeTimes.LoadDefaultDataSourceView()

                                    End If

                                    e.RepositoryItem = _SubItemGridLookUpEditControl_FeeTimes

                                End If

                            End If

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsTaxCommission.ToString

                            If CBool(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0)) Then

                                If e.CellValue Is Nothing Then

                                    e.RepositoryItem = _RepositoryItemCheckEdit

                                Else

                                    If _SubItemGridLookUpEditControl_Markup.DataSource Is Nothing Then

                                        _SubItemGridLookUpEditControl_Markup.LoadDefaultDataSourceView()

                                    End If

                                    e.RepositoryItem = _SubItemGridLookUpEditControl_Markup

                                End If

                            End If

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsTaxCommissionOnly.ToString

                            If CBool(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0)) Then

                                e.RepositoryItem = _RepositoryItemCheckEdit

                            End If

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.EmployeeTitleID.ToString

                            If CBool(BillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0)) Then

                                e.RepositoryItem = _SubItemGridLookUpEditControl_EmployeeTitle

                            End If

                    End Select

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_AllBillingRateDetails_NeedQueryableDataSourceEvent(ByRef DbContext As AdvantageFramework.Database.DbContext, ByRef DataSource As Object) Handles DataGridViewForm_AllBillingRateDetails.NeedQueryableDataSourceEvent

            'objects
            Dim BillingRateDetails As Generic.List(Of AdvantageFramework.Database.Views.BillingRateDetailView) = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim Divisions As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim Removed As Boolean = False

            If _ViewInactiveBillingRateDetails Then

                BillingRateDetails = AdvantageFramework.Database.Procedures.BillingRateDetailView.Load(DbContext).ToList

            Else

                BillingRateDetails = AdvantageFramework.Database.Procedures.BillingRateDetailView.LoadAllActive(DbContext).ToList

            End If

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Products = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, False).ToList
                Divisions = AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList
                Clients = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList
                Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList

                For Each BillingRateDetail In BillingRateDetails.ToList

                    Removed = False

                    If String.IsNullOrWhiteSpace(BillingRateDetail.ClientCode) = False AndAlso
                            String.IsNullOrWhiteSpace(BillingRateDetail.DivisionCode) AndAlso
                            String.IsNullOrWhiteSpace(BillingRateDetail.ProductCode) Then

                        If Clients.Any(Function(Entity) Entity.Code = BillingRateDetail.ClientCode) = False Then

                            Removed = BillingRateDetails.Remove(BillingRateDetail)

                        End If

                    ElseIf String.IsNullOrWhiteSpace(BillingRateDetail.ClientCode) = False AndAlso
                            String.IsNullOrWhiteSpace(BillingRateDetail.DivisionCode) = False AndAlso
                            String.IsNullOrWhiteSpace(BillingRateDetail.ProductCode) Then

                        If Divisions.Any(Function(Entity) Entity.ClientCode = BillingRateDetail.ClientCode AndAlso Entity.Code = BillingRateDetail.DivisionCode) = False Then

                            Removed = BillingRateDetails.Remove(BillingRateDetail)

                        End If

                    ElseIf String.IsNullOrWhiteSpace(BillingRateDetail.ClientCode) = False AndAlso
                            String.IsNullOrWhiteSpace(BillingRateDetail.DivisionCode) = False AndAlso
                            String.IsNullOrWhiteSpace(BillingRateDetail.ProductCode) = False Then

                        If Products.Any(Function(Entity) Entity.ClientCode = BillingRateDetail.ClientCode AndAlso Entity.DivisionCode = BillingRateDetail.DivisionCode AndAlso Entity.Code = BillingRateDetail.ProductCode) = False Then

                            Removed = BillingRateDetails.Remove(BillingRateDetail)

                        End If

                    End If

                    If String.IsNullOrWhiteSpace(BillingRateDetail.EmployeeCode) = False AndAlso Removed = False Then

                        If Employees.Any(Function(Entity) Entity.Code = BillingRateDetail.EmployeeCode) = False Then

                            Removed = BillingRateDetails.Remove(BillingRateDetail)

                        End If

                    End If

            Next

            End Using

            DataSource = BillingRateDetails.AsQueryable

        End Sub
        Private Sub DataGridViewForm_AllBillingRateDetails_RowCellStyleEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DataGridViewForm_AllBillingRateDetails.RowCellStyleEvent

            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            If DataGridViewForm_AllBillingRateDetails.CurrentView.IsRowLoaded(e.RowHandle) Then

                Try

                    BillingRateLevel = (From Entity In _BillingRateLevels
                                        Where Entity.Number = DataGridViewForm_AllBillingRateDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Views.BillingRateDetailView.Properties.Number.ToString)
                                        Select Entity).FirstOrDefault

                Catch ex As Exception
                    BillingRateLevel = Nothing
                End Try

                If BillingRateLevel IsNot Nothing Then

                    Select Case e.Column.FieldName

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.ClientCode.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsClientIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.DivisionCode.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.ProductCode.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsProductIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.SalesClassCode.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.FunctionCode.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.FunctionType.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.EmployeeTitleID.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.EmployeeCode.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.EmployeeTitleID.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.EffectiveDate.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsEffectiveDateIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.BillingRate.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsBillingRateDetailIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsNonBillable.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsNonBillableIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsCommission.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsCommissionIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.TaxCode.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsTaxIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.TaxCode.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsTaxIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsTaxCommission.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsTaxCommission.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Views.BillingRateDetailView.Properties.IsTaxCommissionOnly.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsFeeTime.ToString

                            ModifyCellStyle(e, CBool(BillingRateLevel.IsFeeTimeIncluded.GetValueOrDefault(0)))

                    End Select

                End If

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
