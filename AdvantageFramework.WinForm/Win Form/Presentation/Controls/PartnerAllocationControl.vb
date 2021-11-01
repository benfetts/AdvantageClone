Namespace WinForm.Presentation.Controls

    Public Class PartnerAllocationControl

        Public Event SelectedTabChanged()
        Public Event PartnerAllocationDetailSelectionChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _CampaignID As Integer = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _HasOrders As Boolean = False
        Private _PartnerAllocationType As AdvantageFramework.Database.Entities.PartnerAllocationType = Database.Entities.PartnerAllocationType.Campaign
        Private _MediaOrderType As AdvantageFramework.Database.Entities.MediaOrderType = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property HasOrders() As Boolean
            Get

                If TabItemPartnerAllocation_MediaOrdersTab.Tag = True Then

                    HasOrders = DataGridViewMediaOrders_MediaOrders.HasRows

                Else

                    HasOrders = _HasOrders

                End If

            End Get
        End Property
        Public ReadOnly Property IsAllocateTabSelected As Boolean
            Get
                IsAllocateTabSelected = If(TabControlControl_PartnerAllocation.SelectedTab Is TabItemPartnerAllocation_AllocationTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsOrdersTabSelected As Boolean
            Get
                IsOrdersTabSelected = If(TabControlControl_PartnerAllocation.SelectedTab Is TabItemPartnerAllocation_MediaOrdersTab, True, False)
            End Get
        End Property
        Public ReadOnly Property HasASelectedPartnerAllocationDetail As Boolean
            Get
                HasASelectedPartnerAllocationDetail = DataGridViewAllocation_PartnerAllocation.HasASelectedRow
            End Get
        End Property
        Public ReadOnly Property IsNewItemRowPartnerAllocationDetail As Boolean
            Get
                IsNewItemRowPartnerAllocationDetail = DataGridViewAllocation_PartnerAllocation.CurrentView.IsNewItemRow(DataGridViewAllocation_PartnerAllocation.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property PartnerAllocationDetailCount As Integer
            Get
                PartnerAllocationDetailCount = DataGridViewAllocation_PartnerAllocation.CurrentView.RowCount
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

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                DataGridViewAllocation_PartnerAllocation.MultiSelect = False

                                NumericInputAllocation_ClientPercent.SetPropertySettings(AdvantageFramework.Database.Entities.PartnerAllocation.Properties.ClientPercent)

                                NumericInputAllocation_ClientPercent.Properties.MaxValue = 100

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation = Nothing

            If _CampaignID <> Nothing OrElse _OrderNumber <> Nothing Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlControl_PartnerAllocation.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlControl_PartnerAllocation.SelectedTab

                End If

                If TabItem.Tag = False Then

                    If TabItem Is TabItemPartnerAllocation_AllocationTab Then

                        PartnerAllocation = LoadSelectedPartnerAllocation()

                        If PartnerAllocation Is Nothing Then

                            PartnerAllocation = New AdvantageFramework.Database.Entities.PartnerAllocation

                        End If

                        LoadAllocationTab(PartnerAllocation)

                    End If

                    If TabItem Is TabItemPartnerAllocation_MediaOrdersTab Then

                        LoadOrdersTab()

                    End If

                End If

            End If

        End Sub
        Private Sub LoadAllocationTab(ByVal PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation)

            If PartnerAllocation IsNot Nothing Then

                NumericInputAllocation_ClientPercent.Value = PartnerAllocation.ClientPercent

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewAllocation_PartnerAllocation.DataSource = AdvantageFramework.Database.Procedures.PartnerAllocationDetail.LoadByOrderNumber(DbContext, PartnerAllocation.OrderNumber).ToList

                End Using

                DataGridViewAllocation_PartnerAllocation.CurrentView.BestFitColumns()

                TabItemPartnerAllocation_AllocationTab.Tag = True

            End If

        End Sub
        Private Sub LoadOrdersTab()

            'objects
            Dim MediaOrders As Generic.List(Of AdvantageFramework.Database.Views.MediaOrder) = Nothing

            If _CampaignID <> Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaOrders = (From Entity In AdvantageFramework.Database.Procedures.MediaOrderView.LoadByCampaignID(DbContext, _CampaignID)
                                   Where Entity.ProcessControl <> 6 AndAlso
                                         Entity.ProcessControl <> 12
                                   Select Entity
                                   Order By Entity.OrderNumber Descending).ToList

                    DataGridViewMediaOrders_MediaOrders.ItemDescription = "Media Order(s)"

                    DataGridViewMediaOrders_MediaOrders.DataSource = (From Entity In MediaOrders
                                                                      Select New With {.OrderNumber = Entity.OrderNumber,
                                                                                       .Description = Entity.Description,
                                                                                       .Media = Entity.MediaFrom.Replace("2", "").Replace("Mag", "Magazine").Replace("News", "Newspaper")}).ToList

                End Using

                DataGridViewMediaOrders_MediaOrders.CurrentView.BestFitColumns()

                TabItemPartnerAllocation_MediaOrdersTab.Tag = True

            End If

        End Sub
        Private Sub LoadPartnerAllocationEntity(ByVal PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation)

            If PartnerAllocation IsNot Nothing Then



            End If

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub
        Private Function LoadSelectedPartnerAllocation() As AdvantageFramework.Database.Entities.PartnerAllocation

            'objects
            Dim PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Select Case _PartnerAllocationType

                        Case Database.Entities.PartnerAllocationType.Campaign

                            PartnerAllocation = (From Entity In AdvantageFramework.Database.Procedures.PartnerAllocation.LoadByCampaignID(DbContext, _CampaignID)
                                                 Select Entity).FirstOrDefault

                        Case Database.Entities.PartnerAllocationType.Order

                            PartnerAllocation = AdvantageFramework.Database.Procedures.PartnerAllocation.LoadByOrderNumber(DbContext, _OrderNumber)

                    End Select

                End Using

            Catch ex As Exception
                PartnerAllocation = Nothing
            Finally
                LoadSelectedPartnerAllocation = PartnerAllocation
            End Try

        End Function

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim PartnerAllocationDetail As AdvantageFramework.Database.Entities.PartnerAllocationDetail = Nothing
            Dim PartnerAllocations As Generic.List(Of AdvantageFramework.Database.Entities.PartnerAllocation) = Nothing
            Dim PercentSum As Decimal = Nothing
            Dim PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation = Nothing
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim Magazine As AdvantageFramework.Database.Views.Magazine = Nothing
            Dim NewspaperHeader As AdvantageFramework.Database.Views.NewspaperHeader = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                PercentSum = (From Entity In DataGridViewAllocation_PartnerAllocation.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.PartnerAllocationDetail)()
                              Select Entity.PercentAllocation).Sum

            Catch ex As Exception
                PercentSum = Nothing
            End Try

            If PercentSum <> 100 Then

                ErrorMessage = "Total must equal 100%."

            Else

                Try

                    PartnerAllocations = New Generic.List(Of AdvantageFramework.Database.Entities.PartnerAllocation)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PartnerAllocation = LoadSelectedPartnerAllocation()

                        If PartnerAllocation IsNot Nothing Then

                            Delete()

                        End If

                        Select Case _PartnerAllocationType

                            Case Database.Entities.PartnerAllocationType.Campaign

                                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, _CampaignID)

                                If Campaign IsNot Nothing Then

                                    For Each InternetOrder In (From Entity In AdvantageFramework.Database.Procedures.InternetOrder.Load(DbContext)
                                                               Where Entity.CampaignID = Campaign.ID AndAlso
                                                                     Entity.OrderProcessControl <> 6 AndAlso
                                                                     Entity.OrderProcessControl <> 12
                                                               Select Entity).ToList

                                        PartnerAllocation = New AdvantageFramework.Database.Entities.PartnerAllocation
                                        PartnerAllocation.DbContext = DbContext
                                        PartnerAllocation.CampaignID = Campaign.ID
                                        PartnerAllocation.CampaignCode = Campaign.Code
                                        PartnerAllocation.OrderNumber = InternetOrder.OrderNumber
                                        PartnerAllocation.ClientCode = InternetOrder.ClientCode
                                        PartnerAllocation.DivisionCode = InternetOrder.DivisionCode
                                        PartnerAllocation.ProductCode = InternetOrder.ProductCode
                                        PartnerAllocation.MediaType = "I"

                                        PartnerAllocations.Add(PartnerAllocation)

                                    Next

                                    For Each Magazine In (From Entity In AdvantageFramework.Database.Procedures.MagazineView.Load(DbContext)
                                                          Where Entity.CampaignID = Campaign.ID AndAlso
                                                                     Entity.OrderProcessControl <> 6 AndAlso
                                                                     Entity.OrderProcessControl <> 12
                                                          Select Entity).ToList

                                        PartnerAllocation = New AdvantageFramework.Database.Entities.PartnerAllocation
                                        PartnerAllocation.DbContext = DbContext
                                        PartnerAllocation.CampaignID = Campaign.ID
                                        PartnerAllocation.CampaignCode = Campaign.Code
                                        PartnerAllocation.OrderNumber = Magazine.OrderNumber
                                        PartnerAllocation.ClientCode = Magazine.ClientCode
                                        PartnerAllocation.DivisionCode = Magazine.DivisionCode
                                        PartnerAllocation.ProductCode = Magazine.ProductCode
                                        PartnerAllocation.MediaType = "M"

                                        PartnerAllocations.Add(PartnerAllocation)

                                    Next

                                    For Each NewspaperHeader In (From Entity In AdvantageFramework.Database.Procedures.NewspaperHeaderView.Load(DbContext)
                                                                 Where Entity.CampaignID = Campaign.ID AndAlso
                                                                      Entity.OrderProcessControl <> 6 AndAlso
                                                                      Entity.OrderProcessControl <> 12
                                                                 Select Entity).ToList

                                        PartnerAllocation = New AdvantageFramework.Database.Entities.PartnerAllocation
                                        PartnerAllocation.DbContext = DbContext
                                        PartnerAllocation.CampaignID = Campaign.ID
                                        PartnerAllocation.CampaignCode = Campaign.Code
                                        PartnerAllocation.OrderNumber = NewspaperHeader.OrderNumber
                                        PartnerAllocation.ClientCode = NewspaperHeader.ClientCode
                                        PartnerAllocation.DivisionCode = NewspaperHeader.DivisionCode
                                        PartnerAllocation.ProductCode = NewspaperHeader.ProductCode
                                        PartnerAllocation.MediaType = "N"

                                        PartnerAllocations.Add(PartnerAllocation)

                                    Next

                                    For Each OutOfHomeOrder In (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrder.Load(DbContext)
                                                                Where Entity.CampaignID = Campaign.ID AndAlso
                                                                      Entity.OrderProcessControl <> 6 AndAlso
                                                                      Entity.OrderProcessControl <> 12
                                                                Select Entity).ToList

                                        PartnerAllocation = New AdvantageFramework.Database.Entities.PartnerAllocation
                                        PartnerAllocation.DbContext = DbContext
                                        PartnerAllocation.CampaignID = Campaign.ID
                                        PartnerAllocation.CampaignCode = Campaign.Code
                                        PartnerAllocation.OrderNumber = OutOfHomeOrder.OrderNumber
                                        PartnerAllocation.ClientCode = OutOfHomeOrder.ClientCode
                                        PartnerAllocation.DivisionCode = OutOfHomeOrder.DivisionCode
                                        PartnerAllocation.ProductCode = OutOfHomeOrder.ProductCode
                                        PartnerAllocation.MediaType = "I"

                                        PartnerAllocations.Add(PartnerAllocation)

                                    Next

                                    For Each RadioOrder In (From Entity In AdvantageFramework.Database.Procedures.RadioOrder.Load(DbContext)
                                                            Where Entity.CampaignID = Campaign.ID AndAlso
                                                                  Entity.OrderProcessControl <> 6 AndAlso
                                                                  Entity.OrderProcessControl <> 12
                                                            Select Entity).ToList

                                        PartnerAllocation = New AdvantageFramework.Database.Entities.PartnerAllocation
                                        PartnerAllocation.DbContext = DbContext
                                        PartnerAllocation.CampaignID = Campaign.ID
                                        PartnerAllocation.CampaignCode = Campaign.Code
                                        PartnerAllocation.OrderNumber = RadioOrder.OrderNumber
                                        PartnerAllocation.ClientCode = RadioOrder.ClientCode
                                        PartnerAllocation.DivisionCode = RadioOrder.DivisionCode
                                        PartnerAllocation.ProductCode = RadioOrder.ProductCode
                                        PartnerAllocation.MediaType = "I"

                                        PartnerAllocations.Add(PartnerAllocation)

                                    Next

                                    For Each TVOrder In (From Entity In AdvantageFramework.Database.Procedures.TVOrder.Load(DbContext)
                                                         Where Entity.CampaignID = Campaign.ID AndAlso
                                                               Entity.OrderProcessControl <> 6 AndAlso
                                                               Entity.OrderProcessControl <> 12
                                                         Select Entity).ToList

                                        PartnerAllocation = New AdvantageFramework.Database.Entities.PartnerAllocation
                                        PartnerAllocation.DbContext = DbContext
                                        PartnerAllocation.CampaignID = Campaign.ID
                                        PartnerAllocation.CampaignCode = Campaign.Code
                                        PartnerAllocation.OrderNumber = TVOrder.OrderNumber
                                        PartnerAllocation.ClientCode = TVOrder.ClientCode
                                        PartnerAllocation.DivisionCode = TVOrder.DivisionCode
                                        PartnerAllocation.ProductCode = TVOrder.ProductCode
                                        PartnerAllocation.MediaType = "I"

                                        PartnerAllocations.Add(PartnerAllocation)

                                    Next

                                End If

                            Case Database.Entities.PartnerAllocationType.Order

                                PartnerAllocation = New AdvantageFramework.Database.Entities.PartnerAllocation
                                PartnerAllocation.DbContext = DbContext

                                Select Case _MediaOrderType

                                    Case Database.Entities.MediaOrderType.Internet

                                        InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                                        If InternetOrder IsNot Nothing Then

                                            PartnerAllocation.OrderNumber = InternetOrder.OrderNumber
                                            PartnerAllocation.ClientCode = InternetOrder.ClientCode
                                            PartnerAllocation.DivisionCode = InternetOrder.DivisionCode
                                            PartnerAllocation.ProductCode = InternetOrder.ProductCode
                                            PartnerAllocation.MediaType = "I"

                                            PartnerAllocations.Add(PartnerAllocation)

                                        End If

                                    Case Database.Entities.MediaOrderType.Magazine

                                        Magazine = AdvantageFramework.Database.Procedures.MagazineView.LoadByOrderNumber(DbContext, _OrderNumber)

                                        If Magazine IsNot Nothing Then

                                            PartnerAllocation.OrderNumber = Magazine.OrderNumber
                                            PartnerAllocation.ClientCode = Magazine.ClientCode
                                            PartnerAllocation.DivisionCode = Magazine.DivisionCode
                                            PartnerAllocation.ProductCode = Magazine.ProductCode
                                            PartnerAllocation.MediaType = "M"

                                            PartnerAllocations.Add(PartnerAllocation)

                                        End If

                                    Case Database.Entities.MediaOrderType.Newspaper

                                        NewspaperHeader = AdvantageFramework.Database.Procedures.NewspaperHeaderView.LoadByOrderNumber(DbContext, _OrderNumber)

                                        If NewspaperHeader IsNot Nothing Then

                                            PartnerAllocation.OrderNumber = NewspaperHeader.OrderNumber
                                            PartnerAllocation.ClientCode = NewspaperHeader.ClientCode
                                            PartnerAllocation.DivisionCode = NewspaperHeader.DivisionCode
                                            PartnerAllocation.ProductCode = NewspaperHeader.ProductCode
                                            PartnerAllocation.MediaType = "N"

                                            PartnerAllocations.Add(PartnerAllocation)

                                        End If

                                    Case Database.Entities.MediaOrderType.OutOfHome

                                        OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                                        If OutOfHomeOrder IsNot Nothing Then

                                            PartnerAllocation.OrderNumber = OutOfHomeOrder.OrderNumber
                                            PartnerAllocation.ClientCode = OutOfHomeOrder.ClientCode
                                            PartnerAllocation.DivisionCode = OutOfHomeOrder.DivisionCode
                                            PartnerAllocation.ProductCode = OutOfHomeOrder.ProductCode
                                            PartnerAllocation.MediaType = "O"

                                            PartnerAllocations.Add(PartnerAllocation)

                                        End If

                                    Case Database.Entities.MediaOrderType.Radio

                                        RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                                        If RadioOrder IsNot Nothing Then

                                            PartnerAllocation.OrderNumber = RadioOrder.OrderNumber
                                            PartnerAllocation.ClientCode = RadioOrder.ClientCode
                                            PartnerAllocation.DivisionCode = RadioOrder.DivisionCode
                                            PartnerAllocation.ProductCode = RadioOrder.ProductCode
                                            PartnerAllocation.MediaType = "R"

                                            PartnerAllocations.Add(PartnerAllocation)

                                        End If

                                    Case Database.Entities.MediaOrderType.Television

                                        TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, _OrderNumber)

                                        If TVOrder IsNot Nothing Then

                                            PartnerAllocation.OrderNumber = TVOrder.OrderNumber
                                            PartnerAllocation.ClientCode = TVOrder.ClientCode
                                            PartnerAllocation.DivisionCode = TVOrder.DivisionCode
                                            PartnerAllocation.ProductCode = TVOrder.ProductCode
                                            PartnerAllocation.MediaType = "T"

                                            PartnerAllocations.Add(PartnerAllocation)

                                        End If

                                End Select

                        End Select

                        For Each PartnerAllocation In PartnerAllocations

                            PartnerAllocation.ClientPercent = NumericInputAllocation_ClientPercent.Value

                            If AdvantageFramework.Database.Procedures.PartnerAllocation.Insert(DbContext, PartnerAllocation) Then

                                Saved = True

                                For Each PartnerAllocationDtl In DataGridViewAllocation_PartnerAllocation.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.PartnerAllocationDetail)().ToList

                                    PartnerAllocationDetail = New AdvantageFramework.Database.Entities.PartnerAllocationDetail

                                    PartnerAllocationDetail.DbContext = DbContext
                                    PartnerAllocationDetail.OrderNumber = PartnerAllocation.OrderNumber
                                    PartnerAllocationDetail.PartnerCode = PartnerAllocationDtl.PartnerCode
                                    PartnerAllocationDetail.PercentAllocation = PartnerAllocationDtl.PercentAllocation

                                    AdvantageFramework.Database.Procedures.PartnerAllocationDetail.Insert(DbContext, PartnerAllocationDetail)

                                Next

                            End If

                        Next

                    End Using

                    If Not Saved Then

                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                    End If

                Catch ex As Exception
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                End Try

            End If

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                PartnerAllocation = LoadSelectedPartnerAllocation()

                If PartnerAllocation IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Select Case _PartnerAllocationType

                            Case Database.Entities.PartnerAllocationType.Campaign

                                Deleted = AdvantageFramework.Database.Procedures.PartnerAllocation.Delete(DbContext, _CampaignID)

                            Case Database.Entities.PartnerAllocationType.Order

                                Deleted = AdvantageFramework.Database.Procedures.PartnerAllocation.Delete(DbContext, PartnerAllocation)

                        End Select

                    End Using

                Else

                    'inserted rows but never saved
                    Deleted = True

                End If

                If Deleted = False Then

                    ErrorMessage = "The partner allocation cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function LoadControl(ByVal OrderNumberOrCampaignID As Integer, ByVal PartnerAllocationType As AdvantageFramework.Database.Entities.PartnerAllocationType, Optional ByVal MediaOrderType As AdvantageFramework.Database.Entities.MediaOrderType = Nothing) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation = Nothing
            Dim ErrorMessage As String = ""
            Dim ShowErrorPanel As Boolean = False
            Dim Locked As Boolean = False
            Dim CheckCampainAllocation As Boolean = False
            Dim LabelSize As System.Drawing.Size = Nothing
            Dim PanelSize As System.Drawing.Size = Nothing

            _PartnerAllocationType = PartnerAllocationType
            _MediaOrderType = MediaOrderType

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Select Case _PartnerAllocationType

                    Case Database.Entities.PartnerAllocationType.Campaign

                        _CampaignID = OrderNumberOrCampaignID
                        _OrderNumber = Nothing
                        TabItemPartnerAllocation_MediaOrdersTab.Visible = True

                        Try

                            Locked = Not (From Entity In AdvantageFramework.Database.Procedures.MediaOrderView.LoadByCampaignID(DbContext, _CampaignID)
                                          Where Entity.ProcessControl <> 6 AndAlso
                                                Entity.ProcessControl <> 12
                                          Select Entity).Any

                        Catch ex As Exception
                            Locked = False
                        End Try

                        If Locked Then

                            ShowErrorPanel = True

                            LabelSize = New System.Drawing.Size(LabelTopSection_WarningMessage.Size.Width, 20)
                            PanelSize = New System.Drawing.Size(LabelTopSection_WarningMessage.Size.Width, 28)

                            ErrorMessage = "There are no open media orders for this campaign."

                        End If

                    Case Database.Entities.PartnerAllocationType.Order

                        _CampaignID = Nothing
                        _OrderNumber = OrderNumberOrCampaignID
                        TabItemPartnerAllocation_MediaOrdersTab.Visible = False
                        CheckCampainAllocation = True

                End Select

                If Locked = False Then

                    PartnerAllocation = LoadSelectedPartnerAllocation()

                    If PartnerAllocation IsNot Nothing Then

                        If CheckCampainAllocation Then

                            Try

                                ShowErrorPanel = PartnerAllocation.CampaignID.HasValue

                            Catch ex As Exception
                                ShowErrorPanel = False
                            End Try

                            If ShowErrorPanel Then

                                LabelSize = New System.Drawing.Size(LabelTopSection_WarningMessage.Size.Width, 50)
                                PanelSize = New System.Drawing.Size(LabelTopSection_WarningMessage.Size.Width, 60)

                                ErrorMessage = String.Format("This order is allocated under a campaign." & vbCrLf &
                                                             "The client-division-product-campaign is {0}-{1}-{2}-{3}." & vbCrLf &
                                                             "If you continue the results may be unpredictable.",
                                                             PartnerAllocation.ClientCode, PartnerAllocation.DivisionCode,
                                                             PartnerAllocation.ProductCode, PartnerAllocation.CampaignCode)

                            End If

                        End If

                    End If

                    LoadDetails(Nothing)

                End If

                If ShowErrorPanel Then

                    PanelControl_TopSection.Visible = True
                    LabelTopSection_WarningMessage.Text = ErrorMessage
                    DataGridViewAllocation_PartnerAllocation.Enabled = Not Locked
                    NumericInputAllocation_ClientPercent.Enabled = Not Locked
                    TabControlControl_PartnerAllocation.Enabled = Not Locked
                    LabelTopSection_WarningMessage.Size = LabelSize
                    PanelControl_TopSection.Size = PanelSize

                Else

                    PanelControl_TopSection.Visible = False
                    LabelTopSection_WarningMessage.Text = ""
                    DataGridViewAllocation_PartnerAllocation.Enabled = True
                    NumericInputAllocation_ClientPercent.Enabled = True
                    TabControlControl_PartnerAllocation.Enabled = True

                End If

            End Using

            Try

                DataGridViewAllocation_PartnerAllocation.CurrentView.Columns("PercentAllocation").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                DataGridViewAllocation_PartnerAllocation.CurrentView.Columns("PercentAllocation").SummaryItem.DisplayFormat = "{0:F3}"

            Catch ex As Exception

            End Try

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.PartnerAllocation

            Dim PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation = Nothing

            Try

                If IsNew Then

                    PartnerAllocation = New AdvantageFramework.Database.Entities.PartnerAllocation

                    LoadPartnerAllocationEntity(PartnerAllocation)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        'PartnerAllocation = AdvantageFramework.Database.Procedures.PartnerAllocation.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                        'If Division IsNot Nothing Then

                        '    LoadDivisionEntity(Division)

                        'End If

                    End Using

                End If

            Catch ex As Exception
                PartnerAllocation = Nothing
            End Try

            FillObject = PartnerAllocation

        End Function
        Public Sub ClearControl()

            NumericInputAllocation_ClientPercent.Value = Nothing

            DataGridViewAllocation_PartnerAllocation.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.PartnerAllocationDetail))
            DataGridViewMediaOrders_MediaOrders.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function DeleteSelectedDetail() As Boolean

            'objects
            Dim PartnerAllocationDetail As AdvantageFramework.Database.Entities.PartnerAllocationDetail = Nothing
            Dim Deleted As Boolean = False

            If DataGridViewAllocation_PartnerAllocation.HasOnlyOneSelectedRow Then

                If DataGridViewAllocation_PartnerAllocation.CurrentView.RowCount = 1 Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                        Deleted = Delete()

                    End If

                Else

                    If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this partner allocation?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                        Try

                            PartnerAllocationDetail = DirectCast(DataGridViewAllocation_PartnerAllocation.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Entities.PartnerAllocationDetail)

                        Catch ex As Exception
                            PartnerAllocationDetail = Nothing
                        End Try

                        If PartnerAllocationDetail IsNot Nothing Then

                            Deleted = DataGridViewAllocation_PartnerAllocation.CurrentView.DeleteFromDataSource(PartnerAllocationDetail)

                            If Deleted Then

                                DataGridViewAllocation_PartnerAllocation.SetUserEntryChanged()

                            End If

                        End If

                    End If

                End If

            End If

            DeleteSelectedDetail = Deleted

        End Function
        Public Sub CancelAddDetail()

            DataGridViewAllocation_PartnerAllocation.CancelNewItemRow()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PartnerAllocationControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_PartnerAllocation_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_PartnerAllocation.SelectedTabChanged

            RaiseEvent SelectedTabChanged()

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = False

            End If

        End Sub
        Private Sub TabControlControl_PartnerAllocation_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_PartnerAllocation.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = True

            End If

            LoadDetails(e.NewTab)

        End Sub
        Private Sub DataGridViewAllocation_PartnerAllocation_AddNewRowEvent(RowObject As Object) Handles DataGridViewAllocation_PartnerAllocation.AddNewRowEvent

            'objects
            Dim PartnerAllocationDetail As AdvantageFramework.Database.Entities.PartnerAllocationDetail = Nothing
            Dim Partner As AdvantageFramework.Database.Entities.Partner = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.PartnerAllocationDetail Then

                Me.ShowWaitForm("Processing...")

                PartnerAllocationDetail = RowObject

                If DataGridViewAllocation_PartnerAllocation.HasRows = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Partner = AdvantageFramework.Database.Procedures.Partner.LoadByPartnerCode(DbContext, PartnerAllocationDetail.PartnerCode)

                        If Partner IsNot Nothing Then

                            If Partner.PartnerPercent = 100 Then

                                NumericInputAllocation_ClientPercent.Value = Partner.PartnerPercent

                            Else

                                NumericInputAllocation_ClientPercent.Value = 100 - Partner.PartnerPercent

                            End If

                        End If

                    End Using

                End If

                DataGridViewAllocation_PartnerAllocation.SetUserEntryChanged()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewAllocation_PartnerAllocation_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewAllocation_PartnerAllocation.NewItemRowCellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.Database.Entities.PartnerAllocationDetail.Properties.PartnerCode.ToString Then

                Try

                    For RowHandle = 0 To DataGridViewAllocation_PartnerAllocation.CurrentView.RowCount - 1

                        If DataGridViewAllocation_PartnerAllocation.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.PartnerAllocationDetail.Properties.PartnerCode.ToString) = e.Value Then

                            AdvantageFramework.Navigation.ShowMessageBox("Duplicate partner codes are not allowed.")

                            DataGridViewAllocation_PartnerAllocation.CurrentView.SetRowCellValue(e.RowHandle, e.Column.FieldName, "")

                            Exit For

                        End If

                    Next

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub DataGridViewAllocation_PartnerAllocation_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewAllocation_PartnerAllocation.SelectionChangedEvent

            RaiseEvent PartnerAllocationDetailSelectionChangedEvent()

        End Sub

#End Region

#End Region

    End Class

End Namespace
