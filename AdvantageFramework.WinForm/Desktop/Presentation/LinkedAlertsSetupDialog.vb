Namespace Desktop.Presentation

    Public Class LinkedAlertsSetupDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ShowTypes
            AllAlertsAndAssignments
            AllAlerts
            MyAssignments
            AllAssignments
            Unassigned
        End Enum

        Public Enum GroupOptions
            None
            Category
            Office
            Client
            Division
            Product
            Campaign
            Estimate
            EstimateComponent
            Job
            JobComponent
            Task
            Template
            State
            DueDate
            Priority
        End Enum

#End Region

#Region " Variables "

        Private _DefaultTemplateID As Integer = 0
        Private _DefaultStateID As Integer = 0

#End Region

#Region " Properties "

        Private _AccountPayableID As Integer = 0
        Private _AccountPayableSequenceNumber As Integer = 0

#End Region

#Region " Methods "

        Private Sub New(ByVal AccountPayableID As Integer, ByVal AccountPayableSequenceNumber As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _AccountPayableID = AccountPayableID
            _AccountPayableSequenceNumber = AccountPayableSequenceNumber

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim LinkedAlerts As Generic.List(Of LinkedAlert) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Security.Database.Views.Employee) = Nothing
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing
            Dim Divisions As Generic.List(Of AdvantageFramework.Database.Core.Division) = Nothing
            Dim Products As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing
            Dim Offices As Generic.List(Of AdvantageFramework.Database.Core.Office) = Nothing
            Dim Campaigns As Generic.List(Of AdvantageFramework.Database.Core.Campaign) = Nothing
            Dim Estimates As Generic.List(Of Estimate) = Nothing
            Dim EstimateComponents As Generic.List(Of EstimateComponent) = Nothing
            Dim Jobs As Generic.List(Of AdvantageFramework.Database.Views.JobView) = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim AlertAssignmentTemplates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate) = Nothing
            Dim JobComponentTasks As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing
            Dim Images As DevExpress.Utils.ImageCollection = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Employees = AdvantageFramework.Security.Database.Procedures.EmployeeView.Load(SecurityDbContext).Include("Users").ToList

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)
                Clients = AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext)
                Divisions = AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext)
                Products = AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext)
                Offices = AdvantageFramework.Database.Procedures.Office.LoadCore(DbContext)
                Campaigns = AdvantageFramework.Database.Procedures.Campaign.LoadCore(DbContext)
                Estimates = DbContext.Database.SqlQuery(Of Estimate)("SELECT [Number] = ESTIMATE_NUMBER, [Description] = EST_LOG_DESC FROM [dbo].[ESTIMATE_LOG]").ToList
                EstimateComponents = DbContext.Database.SqlQuery(Of EstimateComponent)("SELECT [EstimateNumber] = ESTIMATE_NUMBER, [Number] = EST_COMPONENT_NBR, [Description] = EST_COMP_DESC FROM [dbo].[ESTIMATE_COMPONENT]").ToList
                Jobs = AdvantageFramework.Database.Procedures.JobView.Load(DbContext).ToList
                JobComponents = AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext).ToList
                AlertAssignmentTemplates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.Load(DbContext).ToList
                JobComponentTasks = AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext).ToList

                LinkedAlerts = AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertComments").
                                                                                                Include("AlertType").Include("AlertAttachments").Include("AlertCategory").
                                                                                                Include("AlertState").Where(Function(Entity) Entity.AccountPayableID = _AccountPayableID).ToList.Select(Function(Entity) New LinkedAlert(Entity, Employee, Employees, Clients, Divisions, Products, Offices, Campaigns, Estimates, EstimateComponents, Jobs, JobComponents, AlertAssignmentTemplates, JobComponentTasks)).ToList

                DbContext.Database.Connection.Close()

            End Using

            If ComboBoxShow_Show.HasASelectedValue Then

                If ComboBoxShow_Show.SelectedValue = ShowTypes.AllAlerts Then

                    LinkedAlerts = LinkedAlerts.Where(Function(Entity) Entity.IsAlertAssignment = False).ToList

                ElseIf ComboBoxShow_Show.SelectedValue = ShowTypes.MyAssignments Then

                    LinkedAlerts = LinkedAlerts.Where(Function(Entity) Entity.IsAlertAssignment = True AndAlso Entity.AssignedToEmployeeCode = Me.Session.User.EmployeeCode).ToList

                ElseIf ComboBoxShow_Show.SelectedValue = ShowTypes.AllAssignments Then

                    LinkedAlerts = LinkedAlerts.Where(Function(Entity) Entity.IsAlertAssignment = True).ToList

                ElseIf ComboBoxShow_Show.SelectedValue = ShowTypes.Unassigned Then

                    LinkedAlerts = LinkedAlerts.Where(Function(Entity) Entity.IsAlertAssignment = True AndAlso Entity.AssignedToEmployeeCode = "").ToList

                End If

            End If

            If ButtonItemView_ShowCompleted.Checked = False Then

                LinkedAlerts = LinkedAlerts.Where(Function(Entity) Entity.IsDismissedOrCompleted = False).ToList

            End If

            For Each GridColumn In DataGridViewForm_Alerts.CurrentView.GroupedColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.UnGroup()

            Next

            DataGridViewForm_Alerts.CurrentView.BeginUpdate()

            DataGridViewForm_Alerts.DataSource = LinkedAlerts

            Images = New DevExpress.Utils.ImageCollection

            Images.AddImage(AdvantageFramework.My.Resources.MailInfoImage)
            Images.AddImage(AdvantageFramework.My.Resources.RecycleBinImage)
            Images.AddImage(AdvantageFramework.My.Resources.DocumentAttachedImage)

            DataGridViewForm_Alerts.CurrentView.Images = Images

            DataGridViewForm_Alerts.CurrentView.Columns(LinkedAlert.Properties.HasBeenRead.ToString).ImageAlignment = Drawing.StringAlignment.Center
            DataGridViewForm_Alerts.CurrentView.Columns(LinkedAlert.Properties.HasBeenRead.ToString).ImageIndex = 0
            DataGridViewForm_Alerts.CurrentView.Columns(LinkedAlert.Properties.HasBeenRead.ToString).OptionsColumn.ShowCaption = False

            DataGridViewForm_Alerts.CurrentView.Columns(LinkedAlert.Properties.IsDismissedOrCompleted.ToString).ImageAlignment = Drawing.StringAlignment.Center
            DataGridViewForm_Alerts.CurrentView.Columns(LinkedAlert.Properties.IsDismissedOrCompleted.ToString).ImageIndex = 1
            DataGridViewForm_Alerts.CurrentView.Columns(LinkedAlert.Properties.IsDismissedOrCompleted.ToString).OptionsColumn.ShowCaption = False

            DataGridViewForm_Alerts.CurrentView.Columns(LinkedAlert.Properties.HasAlertAttachments.ToString).ImageAlignment = Drawing.StringAlignment.Center
            DataGridViewForm_Alerts.CurrentView.Columns(LinkedAlert.Properties.HasAlertAttachments.ToString).ImageIndex = 2
            DataGridViewForm_Alerts.CurrentView.Columns(LinkedAlert.Properties.HasAlertAttachments.ToString).OptionsColumn.ShowCaption = False

            DataGridViewForm_Alerts.CurrentView.BestFitColumns()

            DataGridViewForm_Alerts.CurrentView.EndUpdate()

            If ComboBoxGroup_Group.HasASelectedValue Then

                If ComboBoxGroup_Group.SelectedValue <> GroupOptions.None Then

                    DataGridViewForm_Alerts.CurrentView.Columns(CType(ComboBoxGroup_Group.SelectedValue, GroupOptions).ToString).Group()

                    DataGridViewForm_Alerts.CurrentView.ExpandAllGroups()

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal AccountPayableID As Integer, ByVal AccountPayableSequenceNumber As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim LinkedAlertsSetupDialog As AdvantageFramework.Desktop.Presentation.LinkedAlertsSetupDialog = Nothing

            LinkedAlertsSetupDialog = New AdvantageFramework.Desktop.Presentation.LinkedAlertsSetupDialog(AccountPayableID, AccountPayableSequenceNumber)

            ShowFormDialog = LinkedAlertsSetupDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub LinkedAlertsSetupDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim RibbonBarMergeContainer As DevComponents.DotNetBar.RibbonBarMergeContainer = Nothing
            Dim RibbonTabItem As DevComponents.DotNetBar.RibbonTabItem = Nothing
            Dim RibbonPanel As DevComponents.DotNetBar.RibbonPanel = Nothing
            Dim RibbonBar As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar = Nothing

            Me.CloseButtonVisible = False
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_Alerts.OptionsView.ShowFooter = False
            DataGridViewForm_Alerts.ItemDescription = "Alert(s)"

            ButtonItemActions_AddAlert.Icon = AdvantageFramework.My.Resources.NewAlertIcon
            ButtonItemActions_AddAlertAssignment.Icon = AdvantageFramework.My.Resources.NewAlertAssignmentIcon
            ButtonItemView_ShowCompleted.Image = AdvantageFramework.My.Resources.DocumentCheckImage

            ButtonItemActions_AddAlert.Enabled = False

            ComboBoxGroup_Group.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(GroupOptions), False)
            ComboBoxShow_Show.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(ShowTypes), False)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadByAccountPayableIDAndSequenceNumber(DbContext, _AccountPayableID, _AccountPayableSequenceNumber)

                If AccountPayable IsNot Nothing Then

                    Me.Text = "Alerts: " & AccountPayable.Vendor.Name & " " & AccountPayable.InvoiceNumber & " " & AccountPayable.InvoiceDate.ToShortDateString

                End If

                _DefaultTemplateID = AdvantageFramework.Agency.GetOptionAPApprovalAlertDefaultTemplate(DbContext)
                _DefaultStateID = AdvantageFramework.Agency.GetOptionAPApprovalAlertDefaultState(DbContext)

            End Using

            'If Me.IsFormModal = False Then

            '    For Each BaseItem As DevComponents.DotNetBar.BaseItem In RibbonControlForm_MainRibbon.Items

            '        RibbonTabItem = TryCast(BaseItem, DevComponents.DotNetBar.RibbonTabItem)

            '        If RibbonTabItem IsNot Nothing Then

            '            RibbonBarMergeContainer = New DevComponents.DotNetBar.RibbonBarMergeContainer

            '            RibbonBarMergeContainer.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '            RibbonBarMergeContainer.Name = "RibbonBarMergeContainer" & Me.Controls.OfType(Of DevComponents.DotNetBar.RibbonBarMergeContainer).ToList.Count + 1
            '            RibbonBarMergeContainer.RibbonTabText = If(RibbonTabItem.Text = "File", "Options", RibbonTabItem.Text)
            '            RibbonBarMergeContainer.Visible = False

            '            Me.Controls.Add(RibbonBarMergeContainer)

            '            RibbonPanel = RibbonTabItem.Panel

            '            For Each Control As System.Windows.Forms.Control In RibbonPanel.Controls.OfType(Of System.Windows.Forms.Control).ToList

            '                RibbonBar = TryCast(Control, AdvantageFramework.WinForm.Presentation.Controls.RibbonBar)

            '                If RibbonBar IsNot Nothing Then

            '                    RibbonBarMergeContainer.Controls.Add(RibbonBar)

            '                End If

            '            Next

            '        End If

            '    Next

            '    RibbonControlForm_MainRibbon.CaptionVisible = False
            '    RibbonControlForm_MainRibbon.Hide()
            '    BarForm_StatusBar.Hide()

            'End If

        End Sub
        Private Sub LinkedAlertsSetupDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_Alerts_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DataGridViewForm_Alerts.RowCellStyleEvent

            ''objects
            'Dim LinkedAlert As LinkedAlert = Nothing

            'If e.Column IsNot Nothing Then

            '    Try

            '        LinkedAlert = DataGridViewForm_Alerts.CurrentView.GetRow(e.RowHandle)

            '    Catch ex As Exception
            '        LinkedAlert = Nothing
            '    End Try

            '    If LinkedAlert IsNot Nothing Then

            '        If LinkedAlert.HasBeenRead = False Then

            '            e.Appearance.BackColor = System.Drawing.Color.FromArgb(194, 217, 247)

            '        Else

            '            e.Appearance.BackColor = Drawing.Color.White

            '        End If

            '    End If

            'End If

        End Sub
        Private Sub DataGridViewForm_Alerts_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Alerts.CustomRowCellEditEvent

            'objects
            Dim Images As DevExpress.Utils.ImageCollection = Nothing
            Dim RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = Nothing

            If e.Column.FieldName = LinkedAlert.Properties.HasBeenRead.ToString OrElse
                    e.Column.FieldName = LinkedAlert.Properties.IsDismissedOrCompleted.ToString OrElse
                    e.Column.FieldName = LinkedAlert.Properties.HasAlertAttachments.ToString Then

                If TypeOf e.RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Then

                    If DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).Images Is Nothing Then

                        Images = New DevExpress.Utils.ImageCollection

                        Images.AddImage(AdvantageFramework.My.Resources.MailOpenImage)
                        Images.AddImage(AdvantageFramework.My.Resources.MailImage)

                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).Images = Images
                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).ImageIndexChecked = 0
                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).ImageIndexUnchecked = 1
                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

                        Images = New DevExpress.Utils.ImageCollection

                        Images.AddImage(AdvantageFramework.My.Resources.RecycleBinOkImage)

                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).Images = Images
                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).ImageIndexChecked = 0
                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

                        Images = New DevExpress.Utils.ImageCollection

                        Images.AddImage(AdvantageFramework.My.Resources.LinkImage)

                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).Images = Images
                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).ImageIndexChecked = 0
                        DirectCast(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

                    End If

                End If

            ElseIf e.Column.FieldName = LinkedAlert.Properties.Priority.ToString Then

                If Not TypeOf e.RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox Then

                    RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
                    Images = New DevExpress.Utils.ImageCollection

                    Images.AddImage(AdvantageFramework.My.Resources.SmallPriorityHighestImage)
                    Images.AddImage(AdvantageFramework.My.Resources.SmallPriorityHighImage)
                    Images.AddImage(AdvantageFramework.My.Resources.SmallPriorityLowImage)
                    Images.AddImage(AdvantageFramework.My.Resources.SmallPriorityLowestImage)

                    RepositoryItemImageComboBox.SmallImages = Images

                    RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Highest", 1, 0))
                    RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", 2, 1))
                    RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("--", 3, -1))
                    RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", 4, 2))
                    RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Lowest", 5, 3))

                    e.RepositoryItem = RepositoryItemImageComboBox

                End If

            End If

        End Sub
        Private Sub ComboBoxGroup_Group_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxGroup_Group.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ComboBoxShow_Show_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxShow_Show.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemView_ShowCompleted_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ShowCompleted.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_AddAlertAssignment_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AddAlertAssignment.Click

            'objects
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadByAccountPayableIDAndSequenceNumber(DbContext, _AccountPayableID, _AccountPayableSequenceNumber)

            End Using

            If AccountPayable IsNot Nothing Then

                If AdvantageFramework.Desktop.Presentation.AlertAssignmentEditDialog.ShowFormDialog(AccountPayable.VendorCode, _AccountPayableID, _AccountPayableSequenceNumber, AccountPayable.InvoiceNumber, AccountPayable.InvoiceDate, _DefaultTemplateID, _DefaultStateID) = Windows.Forms.DialogResult.OK Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

    <Serializable()>
    Public Class LinkedAlert
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertID
            HasBeenRead
            IsDismissedOrCompleted
            HasAlertAttachments
            Subject
            LastUpdatedBy
            LastUpdated
            DueDate
            State
            Priority
            AssignedTo
            AssignedToEmployeeCode
            AlertType
            Category
            Client
            ID
            Version
            Build
            Office
            Division
            Product
            Campaign
            Estimate
            EstimateComponent
            Job
            JobComponent
            Task
            Template
            IsAlertAssignment
        End Enum

#End Region

#Region " Variables "

        Private _AlertID As Integer = Nothing
        Private _HasBeenRead As Boolean = Nothing
        Private _IsDismissedOrCompleted As Boolean = Nothing
        Private _HasAlertAttachments As Boolean = Nothing
        Private _Subject As String = Nothing
        Private _LastUpdatedBy As String = Nothing
        Private _LastUpdated As Date = Nothing
        Private _DueDate As Nullable(Of Date) = Nothing
        Private _State As String = Nothing
        Private _Priority As Integer = Nothing
        Private _AssignedTo As String = Nothing
        Private _AssignedToEmployeeCode As String = Nothing
        Private _AlertType As String = Nothing
        Private _Category As String = Nothing
        Private _Client As String = Nothing
        Private _ID As Integer = Nothing
        Private _Version As String = Nothing
        Private _Build As String = Nothing
        Private _Office As String = Nothing
        Private _Division As String = Nothing
        Private _Product As String = Nothing
        Private _Campaign As String = Nothing
        Private _Estimate As String = Nothing
        Private _EstimateComponent As String = Nothing
        Private _Job As String = Nothing
        Private _JobComponent As String = Nothing
        Private _Task As String = Nothing
        Private _Template As String = Nothing
        Private _IsAlertAssignment As Boolean = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property AlertID() As Integer
            Get
                AlertID = _AlertID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property HasBeenRead() As Boolean
            Get
                HasBeenRead = _HasBeenRead
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property IsDismissedOrCompleted() As Boolean
            Get
                IsDismissedOrCompleted = _IsDismissedOrCompleted
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property HasAlertAttachments() As Boolean
            Get
                HasAlertAttachments = _HasAlertAttachments
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Subject() As String
            Get
                Subject = _Subject
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="By")>
        Public ReadOnly Property LastUpdatedBy() As String
            Get
                LastUpdatedBy = _LastUpdatedBy
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property LastUpdated() As Date
            Get
                LastUpdated = _LastUpdated
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property DueDate() As Nullable(Of Date)
            Get
                DueDate = _DueDate
            End Get
            Set(value As Nullable(Of Date))
                _DueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property State() As String
            Get
                State = _State
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property Priority() As Integer
            Get
                Priority = _Priority
            End Get
            Set(value As Integer)
                _Priority = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property AssignedTo() As String
            Get
                AssignedTo = _AssignedTo
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property AssignedToEmployeeCode() As String
            Get
                AssignedToEmployeeCode = _AssignedToEmployeeCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property AlertType() As String
            Get
                AlertType = _AlertType
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Category() As String
            Get
                Category = _Category
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Client() As String
            Get
                Client = _Client
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Version() As String
            Get
                Version = _Version
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Build() As String
            Get
                Build = _Build
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Office() As String
            Get
                Office = _Office
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Division() As String
            Get
                Division = _Division
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Product() As String
            Get
                Product = _Product
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Campaign() As String
            Get
                Campaign = _Campaign
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Estimate() As String
            Get
                Estimate = _Estimate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property EstimateComponent() As String
            Get
                EstimateComponent = _EstimateComponent
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Job() As String
            Get
                Job = _Job
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Task() As String
            Get
                Task = _Task
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Template() As String
            Get
                Template = _Template
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property IsAlertAssignment() As Boolean
            Get
                IsAlertAssignment = _IsAlertAssignment
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal Alert As AdvantageFramework.Database.Entities.Alert, ByVal Employee As AdvantageFramework.Database.Views.Employee, _
                       ByVal Employees As Generic.List(Of AdvantageFramework.Security.Database.Views.Employee), ByVal Clients As Generic.List(Of AdvantageFramework.Database.Core.Client), _
                       ByVal Divisions As Generic.List(Of AdvantageFramework.Database.Core.Division), ByVal Products As Generic.List(Of AdvantageFramework.Database.Core.Product), _
                       ByVal Offices As Generic.List(Of AdvantageFramework.Database.Core.Office), ByVal Campaigns As Generic.List(Of AdvantageFramework.Database.Core.Campaign), _
                       ByVal Estimates As Generic.List(Of Estimate), ByVal EstimateComponents As Generic.List(Of EstimateComponent), _
                       ByVal Jobs As Generic.List(Of AdvantageFramework.Database.Views.JobView), ByVal JobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView), _
                       ByVal AlertAssignmentTemplates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate), ByVal JobComponentTasks As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask))

            'objects
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing
            Dim AssignedToEmployee As AdvantageFramework.Security.Database.Views.Employee = Nothing
            Dim Client As AdvantageFramework.Database.Core.Client = Nothing
            Dim Division As AdvantageFramework.Database.Core.Division = Nothing
            Dim Product As AdvantageFramework.Database.Core.Product = Nothing
            Dim Office As AdvantageFramework.Database.Core.Office = Nothing
            Dim Campaign As AdvantageFramework.Database.Core.Campaign = Nothing
            Dim Estimate As Estimate = Nothing
            Dim EstimateComponent As EstimateComponent = Nothing
            Dim Job As AdvantageFramework.Database.Views.JobView = Nothing
            Dim JobComponent As AdvantageFramework.Database.Views.JobComponentView = Nothing
            Dim AlertAssignmentTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate = Nothing
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            _IsAlertAssignment = AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert)

            _AlertID = Alert.ID
            _HasBeenRead = Alert.AlertRecipients.Any(Function(Entity) Entity.EmployeeCode = Employee.Code AndAlso Entity.IsNewAlert IsNot Nothing AndAlso Entity.IsNewAlert = 1)

            If _IsAlertAssignment Then

                If Alert.AlertRecipients.Any(Function(Entity) Entity.IsCurrentNotify IsNot Nothing AndAlso Entity.IsCurrentNotify = 1 AndAlso Entity.ProcessedDate IsNot Nothing) Then

                    _IsDismissedOrCompleted = True

                ElseIf Alert.AlertRecipientDismisseds.Any(Function(Entity) Entity.IsCurrentNotify IsNot Nothing AndAlso Entity.IsCurrentNotify = 1 AndAlso Entity.ProcessedDate IsNot Nothing) Then

                    _IsDismissedOrCompleted = True

                Else

                    _IsDismissedOrCompleted = False

                End If

            Else

                If Alert.AlertRecipients.Any(Function(Entity) Entity.EmployeeCode = Employee.Code) Then

                    _IsDismissedOrCompleted = True

                Else

                    _IsDismissedOrCompleted = False

                End If

            End If

            _HasAlertAttachments = Alert.AlertAttachments.Any
            _Subject = Alert.Subject

            Try

                AlertComment = Alert.AlertComments.OrderByDescending(Function(Entity) Entity.GeneratedDate).FirstOrDefault()

            Catch ex As Exception
                AlertComment = Nothing
            End Try

            If AlertComment Is Nothing Then

                Try

                    _LastUpdatedBy = Employees.FirstOrDefault(Function(Entity) Entity.Users.Any(Function(User) User.UserCode = Alert.UserCode) = True).ToString

                Catch ex As Exception
                    _LastUpdatedBy = ""
                End Try

                _LastUpdated = Alert.GeneratedDate.GetValueOrDefault(Now)

            Else

                Try

                    _LastUpdatedBy = Employees.FirstOrDefault(Function(Entity) Entity.Users.Any(Function(User) User.UserCode = AlertComment.UserCode) = True).ToString

                Catch ex As Exception
                    _LastUpdatedBy = ""
                End Try

                _LastUpdated = AlertComment.GeneratedDate

            End If

            _DueDate = Alert.DueDate

            If Me.IsAlertAssignment AndAlso Alert.AlertState IsNot Nothing Then

                _State = Alert.AlertState.Name

            Else

                _State = ""

            End If

            _Priority = Alert.PriorityLevel.GetValueOrDefault(3)

            If Me.IsAlertAssignment Then

                If _IsDismissedOrCompleted Then

                    _AssignedTo = "Completed"
                    _AssignedToEmployeeCode = ""

                Else

                    Try

                        AlertRecipient = Alert.AlertRecipients.FirstOrDefault(Function(Entity) Entity.IsCurrentNotify IsNot Nothing AndAlso Entity.IsCurrentNotify = 1 AndAlso Entity.ProcessedDate Is Nothing)

                    Catch ex As Exception
                        AlertRecipient = Nothing
                    End Try

                    If AlertRecipient IsNot Nothing Then

                        Try

                            AssignedToEmployee = Employees.SingleOrDefault(Function(Entity) Entity.Code = AlertRecipient.EmployeeCode)

                        Catch ex As Exception
                            AssignedToEmployee = Nothing
                        End Try

                        If AssignedToEmployee IsNot Nothing Then

                            _AssignedTo = AssignedToEmployee.ToString
                            _AssignedToEmployeeCode = AssignedToEmployee.Code

                        Else

                            _AssignedTo = "Unassigned"
                            _AssignedToEmployeeCode = ""

                        End If

                    Else

                        Try

                            AlertRecipientDismissed = Alert.AlertRecipientDismisseds.FirstOrDefault(Function(Entity) Entity.IsCurrentNotify IsNot Nothing AndAlso Entity.IsCurrentNotify = 1 AndAlso Entity.ProcessedDate Is Nothing)

                        Catch ex As Exception
                            AlertRecipientDismissed = Nothing
                        End Try

                        If AlertRecipientDismissed IsNot Nothing Then

                            Try

                                AssignedToEmployee = Employees.SingleOrDefault(Function(Entity) Entity.Code = AlertRecipientDismissed.EmployeeCode)

                            Catch ex As Exception
                                AssignedToEmployee = Nothing
                            End Try

                            If AssignedToEmployee IsNot Nothing Then

                                _AssignedTo = AssignedToEmployee.ToString
                                _AssignedToEmployeeCode = AssignedToEmployee.Code

                            Else

                                _AssignedTo = "Unassigned"
                                _AssignedToEmployeeCode = ""

                            End If

                        Else

                            _AssignedTo = "Unassigned"
                            _AssignedToEmployeeCode = ""

                        End If

                    End If

                End If

            Else

                _AssignedTo = ""
                _AssignedToEmployeeCode = ""

            End If

            _AlertType = Alert.AlertType.Description
            _Category = Alert.AlertCategory.Description

            If String.IsNullOrEmpty(Alert.ClientCode) = False Then

                Try

                    Client = Clients.SingleOrDefault(Function(Entity) Entity.Code = Alert.ClientCode)

                    If Client IsNot Nothing Then

                        _Client = Client.ToString

                    Else

                        _Client = ""

                    End If

                Catch ex As Exception
                    _Client = ""
                End Try

            Else

                _Client = ""

            End If

            If Alert.AlertSequenceNumber.HasValue Then

                _ID = Alert.AlertSequenceNumber.GetValueOrDefault(0)

            Else

                _ID = Alert.ID

            End If

            _Version = Alert.Version
            _Build = Alert.Build

            If String.IsNullOrEmpty(Alert.OfficeCode) = False Then

                Try

                    Office = Offices.SingleOrDefault(Function(Entity) Entity.Code = Alert.OfficeCode)

                    If Office IsNot Nothing Then

                        _Office = Office.ToString

                    Else

                        _Office = ""

                    End If

                Catch ex As Exception
                    _Office = ""
                End Try

            Else

                _Office = ""

            End If

            If String.IsNullOrEmpty(Alert.ClientCode) = False AndAlso String.IsNullOrEmpty(Alert.DivisionCode) = False Then

                Try

                    Division = Divisions.SingleOrDefault(Function(Entity) Entity.ClientCode = Alert.ClientCode AndAlso Entity.Code = Alert.DivisionCode)

                    If Division IsNot Nothing Then

                        _Division = Division.ToString

                    Else

                        _Division = ""

                    End If

                Catch ex As Exception
                    _Division = ""
                End Try

            Else

                _Division = ""

            End If

            If String.IsNullOrEmpty(Alert.ClientCode) = False AndAlso String.IsNullOrEmpty(Alert.DivisionCode) = False AndAlso String.IsNullOrEmpty(Alert.ProductCode) = False Then

                Try

                    Product = Products.SingleOrDefault(Function(Entity) Entity.ClientCode = Alert.ClientCode AndAlso Entity.DivisionCode = Alert.DivisionCode AndAlso Entity.Code = Alert.ProductCode)

                    If Product IsNot Nothing Then

                        _Product = Product.ToString

                    Else

                        _Product = ""

                    End If

                Catch ex As Exception
                    _Product = ""
                End Try

            Else

                _Product = ""

            End If

            If Alert.CampaignID.HasValue AndAlso Alert.CampaignID > 0 Then

                Try

                    Campaign = Campaigns.SingleOrDefault(Function(Entity) Entity.ID = Alert.CampaignID)

                    If Campaign IsNot Nothing Then

                        _Campaign = Campaign.ToString

                    Else

                        _Campaign = ""

                    End If

                Catch ex As Exception
                    _Campaign = ""
                End Try

            Else

                _Campaign = ""

            End If

            If Alert.EstimateNumber.HasValue AndAlso Alert.EstimateNumber > 0 Then

                Try

                    Estimate = Estimates.SingleOrDefault(Function(Entity) Entity.Number = Alert.EstimateNumber)

                    If Estimate IsNot Nothing Then

                        _Estimate = Estimate.ToString

                    Else

                        _Estimate = ""

                    End If

                Catch ex As Exception
                    _Estimate = ""
                End Try

            Else

                _Estimate = ""

            End If

            If Alert.EstimateNumber.HasValue AndAlso Alert.EstimateNumber > 0 AndAlso Alert.EstimateComponentNumber.HasValue AndAlso Alert.EstimateComponentNumber > 0 Then

                Try

                    EstimateComponent = EstimateComponents.SingleOrDefault(Function(Entity) Entity.EstimateNumber = Alert.EstimateNumber AndAlso Entity.Number = Alert.EstimateComponentNumber)

                    If EstimateComponent IsNot Nothing Then

                        _EstimateComponent = EstimateComponent.ToString

                    Else

                        _EstimateComponent = ""

                    End If

                Catch ex As Exception
                    _EstimateComponent = ""
                End Try

            Else

                _EstimateComponent = ""

            End If

            If Alert.JobNumber.HasValue AndAlso Alert.JobNumber > 0 Then

                Try

                    Job = Jobs.SingleOrDefault(Function(Entity) Entity.JobNumber = Alert.JobNumber)

                    If Job IsNot Nothing Then

                        _Job = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Job.JobNumber, 6, "0", True, True) & " - " & Job.JobDescription).Trim

                    Else

                        _Job = ""

                    End If

                Catch ex As Exception
                    _Job = ""
                End Try

            Else

                _Job = ""

            End If

            If Alert.JobNumber.HasValue AndAlso Alert.JobNumber > 0 AndAlso Alert.JobComponentNumber.HasValue AndAlso Alert.JobComponentNumber > 0 Then

                Try

                    JobComponent = JobComponents.SingleOrDefault(Function(Entity) Entity.JobNumber = Alert.JobNumber AndAlso Entity.JobComponentNumber = Alert.JobComponentNumber)

                    If JobComponent IsNot Nothing Then

                        _JobComponent = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.JobNumber, 6, "0", True, True) & "/" & AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.JobComponentNumber, 2, "0", True, True) & " - " & JobComponent.JobComponentDescription).Trim

                    Else

                        _JobComponent = ""

                    End If

                Catch ex As Exception
                    _JobComponent = ""
                End Try

            Else

                _JobComponent = ""

            End If

            If Alert.JobNumber.HasValue AndAlso Alert.JobNumber > 0 AndAlso Alert.JobComponentNumber.HasValue AndAlso Alert.JobComponentNumber > 0 AndAlso Alert.TaskSequenceNumber.HasValue AndAlso Alert.TaskSequenceNumber > 0 Then

                Try

                    JobComponentTask = JobComponentTasks.SingleOrDefault(Function(Entity) Entity.JobNumber = Alert.JobNumber AndAlso Entity.JobComponentNumber = Alert.JobComponentNumber AndAlso Entity.SequenceNumber = Alert.TaskSequenceNumber)

                    If JobComponentTask IsNot Nothing Then

                        If String.IsNullOrEmpty(JobComponentTask.FuctionCode) Then

                            _Task = JobComponentTask.Description

                        Else

                            _Task = JobComponentTask.FuctionCode & " - " & JobComponentTask.Description

                        End If

                    Else

                        _Task = ""

                    End If

                Catch ex As Exception
                    _Task = ""
                End Try

            Else

                _Task = ""

            End If

            If Alert.AlertAssignmentTemplateID.HasValue AndAlso Alert.AlertAssignmentTemplateID > 0 Then

                Try

                    AlertAssignmentTemplate = AlertAssignmentTemplates.SingleOrDefault(Function(Entity) Entity.ID = Alert.AlertAssignmentTemplateID)

                    If AlertAssignmentTemplate IsNot Nothing Then

                        _Template = AlertAssignmentTemplate.Name

                    Else

                        _Template = ""

                    End If

                Catch ex As Exception
                    _Template = ""
                End Try

            Else

                _Template = ""

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.AlertID

        End Function

#End Region

    End Class

    <Serializable()>
    Public Class Estimate
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            Description
        End Enum

#End Region

#Region " Variables "

        Private _Number As Integer = Nothing
        Private _Description As String = Nothing
        
#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property Number() As Integer
            Get
                Number = _Number
            End Get
            Set(value As Integer)
                _Number = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal Number As Integer, ByVal Description As String)

            _Number = Number
            _Description = Description

        End Sub
        Public Overrides Function ToString() As String

            ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 6, "0", True, True) & " - " & Me.Description).Trim

        End Function

#End Region

    End Class

    <Serializable()>
    Public Class EstimateComponent
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EstimateNumber
            Number
            Description
        End Enum

#End Region

#Region " Variables "

        Private _EstimateNumber As Integer = Nothing
        Private _Number As Short = Nothing
        Private _Description As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property EstimateNumber() As Integer
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(value As Integer)
                _EstimateNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property Number() As Short
            Get
                Number = _Number
            End Get
            Set(value As Short)
                _Number = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal EstimateNumber As Integer, ByVal Number As Short, ByVal Description As String)

            _EstimateNumber = EstimateNumber
            _Number = Number
            _Description = Description

        End Sub
        Public Overrides Function ToString() As String

            ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.EstimateNumber, 6, "0", True, True) & "/" & AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 2, "0", True, True) & " - " & Me.Description).Trim

        End Function

#End Region

    End Class

End Namespace