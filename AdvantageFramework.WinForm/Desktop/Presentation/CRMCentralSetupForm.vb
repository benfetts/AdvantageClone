Namespace Desktop.Presentation

    Public Class CRMCentralSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsCRMUser As Boolean = False
        Private _CRMAddEditViewNewBusinessClientsOnly As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property SelectedGridColumnOption As AdvantageFramework.CRMCentral.GridColumnOptions
            Get

                If ButtonItemActions_ShowBoth.Checked Then

                    SelectedGridColumnOption = CRMCentral.GridColumnOptions.Both

                ElseIf ButtonItemActions_ShowCodes.Checked Then

                    SelectedGridColumnOption = CRMCentral.GridColumnOptions.Codes

                ElseIf ButtonItemActions_ShowDescriptions.Checked Then

                    SelectedGridColumnOption = CRMCentral.GridColumnOptions.Descriptions

                Else

                    SelectedGridColumnOption = CRMCentral.GridColumnOptions.Both

                End If

            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    If _CRMAddEditViewNewBusinessClientsOnly Then

                        DataGridViewForm_Products.DataSource = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.CRMCentral.Classes.CRMActivity)(String.Format("EXEC [dbo].[advsp_crm_load] '{0}'", Me.Session.UserCode))
                                                                Where Entity.NewBusiness = True
                                                                Select Entity).ToList

                    Else

                        DataGridViewForm_Products.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.CRMCentral.Classes.CRMActivity)(String.Format("EXEC [dbo].[advsp_crm_load] '{0}'", Me.Session.UserCode)).ToList

                    End If

                Catch ex As Exception
                    DataGridViewForm_Products.DataSource = New Generic.List(Of AdvantageFramework.CRMCentral.Classes.CRMActivity)
                End Try

            End Using

            RefreshColumnOrderAndVisibility()

        End Sub
        Private Sub RefreshColumnOrderAndVisibility()

            'objects
            Dim ColumnVisibleIndex As Integer = Nothing

            ColumnVisibleIndex = 1

            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeName.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutiveCode.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutive.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.NewBusiness.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.IsInactive.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityDate.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityType.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivitySubject.ToString, ColumnVisibleIndex)
            HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastContactDate.ToString, ColumnVisibleIndex)

            DataGridViewForm_Products.CurrentView.BestFitColumns()

        End Sub
        Private Sub HideOrShowColumn(ByVal FieldName As String, ByRef VisibleIndex As Integer)

            If DataGridViewForm_Products.CurrentView.Columns(FieldName) IsNot Nothing Then

                DataGridViewForm_Products.CurrentView.Columns(FieldName).Visible = AdvantageFramework.CRMCentral.IsColumnVisible(FieldName, Me.SelectedGridColumnOption)

                If DataGridViewForm_Products.CurrentView.Columns(FieldName).Visible Then

                    DataGridViewForm_Products.CurrentView.Columns(FieldName).VisibleIndex = VisibleIndex

                    VisibleIndex = VisibleIndex + 1

                End If

            End If

        End Sub
        Private Function LoadFirstSelectCRMActivity() As AdvantageFramework.CRMCentral.Classes.CRMActivity

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            If DataGridViewForm_Products.HasOnlyOneSelectedRow Then

                Try

                    CRMActivity = DataGridViewForm_Products.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    CRMActivity = Nothing
                End Try

            End If

            LoadFirstSelectCRMActivity = CRMActivity

        End Function
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Print.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow
            ButtonItemClient_Edit.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow
            ButtonItemDivision_Edit.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow
            ButtonItemProduct_Edit.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow
            ButtonItemProduct_CompanyProfile.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow
            ButtonItemProduct_ActivitySummary.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow
            ButtonItemProduct_Contracts.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow
            ButtonItemClientContacts_View.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow
            ButtonItemDiary_Add.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow
            ButtonItemActivity_Add.Enabled = DataGridViewForm_Products.HasOnlyOneSelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CRMCentralSetupForm As Presentation.CRMCentralSetupForm = Nothing

            CRMCentralSetupForm = New Presentation.CRMCentralSetupForm()

            CRMCentralSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CRMCentralSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim GridColumnOption As AdvantageFramework.CRMCentral.GridColumnOptions = CRMCentral.GridColumnOptions.Both
            Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing
            Dim EnumObjects As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim CanUserUpdateInClientMaintenance As Boolean = False
            Dim DoesUserHaveAccessToClientMaintenance As Boolean = False
            Dim DoesUserHaveAccessToClientContactMaintenance As Boolean = False

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_ShowBoth.Icon = AdvantageFramework.My.Resources.ShowAllColumnsIcon
            ButtonItemActions_ShowCodes.Icon = AdvantageFramework.My.Resources.ShowOnlyColumnCodesIcon
            ButtonItemActions_ShowDescriptions.Icon = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsIcon
            ButtonItemClient_Edit.Image = AdvantageFramework.My.Resources.ClientEditImage
            ButtonItemDivision_Edit.Image = AdvantageFramework.My.Resources.DivisionEditImage
            ButtonItemProduct_Edit.Image = AdvantageFramework.My.Resources.ProductEditImage
            ButtonItemProduct_CompanyProfile.Image = AdvantageFramework.My.Resources.CompanyProfileImage
            ButtonItemProduct_ActivitySummary.Image = AdvantageFramework.My.Resources.ActivitySummaryImage
            ButtonItemProduct_Contracts.Image = AdvantageFramework.My.Resources.ContractImage
            ButtonItemClientContacts_View.Image = AdvantageFramework.My.Resources.ClientContactsImage
            ButtonItemDiary_Add.Image = AdvantageFramework.My.Resources.DiaryAddImage
            ButtonItemActivity_Add.Image = AdvantageFramework.My.Resources.ActivityAddImage

            DataGridViewForm_Products.MultiSelect = False
            DataGridViewForm_Products.OptionsPrint.AutoWidth = False

            If AdvantageFramework.Security.LoadUserGroupSetting(Me.Session, Security.GroupSettings.Calendar_AllowGroupToAddHolidays).OfType(Of Boolean).Any(Function(Setting) Setting = True) Then

                EnumObjects = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Calendar.ActivityTypes))

            Else

                EnumObjects = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Calendar.ActivityTypes)).Where(Function(EnumObject) EnumObject.Code <> "H").ToList

            End If

            For Each EnumObject In EnumObjects

                ButtonItem = New DevComponents.DotNetBar.ButtonItem("ButtonItemActivityAdd_" & EnumObject.Code, EnumObject.Description)

                ButtonItem.Tag = EnumObject.Code

                AddHandler ButtonItem.Click, AddressOf ButtonItemActivityAdd_Click

                ButtonItemActivity_Add.SubItems.Add(ButtonItem)

            Next

            CanUserUpdateInClientMaintenance = AdvantageFramework.Security.CanUserUpdateInModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)
            DoesUserHaveAccessToClientMaintenance = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)
            DoesUserHaveAccessToClientContactMaintenance = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact)

            ButtonItemClient_Edit.SecurityEnabled = DoesUserHaveAccessToClientMaintenance
            ButtonItemDivision_Edit.SecurityEnabled = DoesUserHaveAccessToClientMaintenance
            ButtonItemProduct_Edit.SecurityEnabled = DoesUserHaveAccessToClientMaintenance
            ButtonItemProduct_ActivitySummary.SecurityEnabled = DoesUserHaveAccessToClientMaintenance
            ButtonItemProduct_CompanyProfile.SecurityEnabled = DoesUserHaveAccessToClientMaintenance
            ButtonItemProduct_Contracts.SecurityEnabled = DoesUserHaveAccessToClientMaintenance
            ButtonItemDiary_Add.SecurityEnabled = DoesUserHaveAccessToClientMaintenance AndAlso CanUserUpdateInClientMaintenance

            DataGridViewForm_Products.CurrentView.OptionsBehavior.Editable = DoesUserHaveAccessToClientMaintenance AndAlso CanUserUpdateInClientMaintenance

            ButtonItemClientContacts_View.SecurityEnabled = DoesUserHaveAccessToClientContactMaintenance

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            GridColumnOption = AdvantageFramework.CRMCentral.LoadDataGridViewUserSetting(Me.Session)

            Select Case GridColumnOption

                Case CRMCentral.GridColumnOptions.Both

                    ButtonItemActions_ShowBoth.Checked = True

                Case CRMCentral.GridColumnOptions.Codes

                    ButtonItemActions_ShowCodes.Checked = True

                Case CRMCentral.GridColumnOptions.Descriptions

                    ButtonItemActions_ShowDescriptions.Checked = True

            End Select

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.IsCRMUser)

            If _IsCRMUser Then

                _CRMAddEditViewNewBusinessClientsOnly = AdvantageFramework.Security.LoadUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.CRMAddEditViewNewBusinessClientsOnly)

            End If

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                If _IsCRMUser Then

                    DataGridViewForm_Products.CurrentView.AFActiveFilterString = "[NewBusiness] = True And [IsInactive] = False"

                Else

                    DataGridViewForm_Products.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_Products_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Products.CellValueChangedEvent

            'objects
            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            If e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastContactDate.ToString Then

                CRMActivity = LoadFirstSelectCRMActivity()

                If CRMActivity IsNot Nothing Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(DbContext, CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode)

                            If Activity IsNot Nothing Then

                                Activity.LastContactDate = e.Value

                                Activity.ModifiedByUserCode = Me.Session.UserCode
                                Activity.ModifiedDate = Now

                                AdvantageFramework.Database.Procedures.Activity.Update(DbContext, Activity)

                            Else

                                Activity = New AdvantageFramework.Database.Entities.Activity

                                Activity.LastContactDate = e.Value

                                Activity.ClientCode = CRMActivity.ClientCode
                                Activity.DivisionCode = CRMActivity.DivisionCode
                                Activity.ProductCode = CRMActivity.ProductCode

                                Activity.CreatedByUserCode = Me.Session.UserCode
                                Activity.CreateDate = Now

                                AdvantageFramework.Database.Procedures.Activity.Insert(DbContext, Activity)

                            End If

                        End Using

                    Catch ex As Exception
                        Activity = Nothing
                    End Try

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Products_RowDoubleClickEvent() Handles DataGridViewForm_Products.RowDoubleClickEvent

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            If ButtonItemClient_Edit.SecurityEnabled = True Then

                CRMActivity = LoadFirstSelectCRMActivity()

                If CRMActivity IsNot Nothing Then

                    If AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(False, CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode, False) = Windows.Forms.DialogResult.OK Then

                        Me.ShowWaitForm()

                        Try

                            LoadGrid()

                            EnableOrDisableActions()

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Products_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Products.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_Products.Print(DefaultLookAndFeel.LookAndFeel, "CRM Activity")

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                AdvantageFramework.Maintenance.Client.Presentation.ProductReportsDialog.ShowFormDialog(CRMActivity.ClientCode, CRMActivity.DivisionCode, Nothing, New String() {CRMActivity.ProductCode})

            End If

        End Sub
        Private Sub ButtonItemActions_ShowCodes_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowCodes.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemActions_ShowCodes.Checked Then

                    RefreshColumnOrderAndVisibility()

                    AdvantageFramework.CRMCentral.SaveDataGridViewUserSetting(Me.Session, CRMCentral.GridColumnOptions.Codes)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_ShowDescriptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowDescriptions.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemActions_ShowDescriptions.Checked Then

                    RefreshColumnOrderAndVisibility()

                    AdvantageFramework.CRMCentral.SaveDataGridViewUserSetting(Me.Session, CRMCentral.GridColumnOptions.Descriptions)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_ShowBoth_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowBoth.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemActions_ShowBoth.Checked Then

                    RefreshColumnOrderAndVisibility()

                    AdvantageFramework.CRMCentral.SaveDataGridViewUserSetting(Me.Session, CRMCentral.GridColumnOptions.Both)

                End If

            End If

        End Sub
        Private Sub ButtonItemClient_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemClient_Edit.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                If AdvantageFramework.Maintenance.Client.Presentation.ClientEditDialog.ShowFormDialog(False, CRMActivity.ClientCode, False) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm()

                    Try

                        LoadGrid()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemDivision_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDivision_Edit.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                If AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog.ShowFormDialog(False, CRMActivity.ClientCode, CRMActivity.DivisionCode, False) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm()

                    Try

                        LoadGrid()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemProduct_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_Edit.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                If AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(False, CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode, False) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm()

                    Try

                        LoadGrid()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemProduct_CompanyProfile_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_CompanyProfile.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                AdvantageFramework.Maintenance.Client.Presentation.CompanyProfileEditDialog.ShowFormDialog(CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode)

            End If

        End Sub
        Private Sub ButtonItemProduct_ActivitySummary_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_ActivitySummary.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                If AdvantageFramework.Maintenance.Client.Presentation.ActivitySummaryEditDialog.ShowFormDialog(CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode, CRMActivity.NewBusiness) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm()

                    Try

                        LoadGrid()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemProduct_Contracts_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_Contracts.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                AdvantageFramework.Maintenance.Client.Presentation.ContractManagerDialog.ShowFormDialog(CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode)

            End If

        End Sub
        Private Sub ButtonItemClientContacts_View_Click(sender As Object, e As EventArgs) Handles ButtonItemClientContacts_View.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                AdvantageFramework.Maintenance.Client.Presentation.ClientContactManagerDialog.ShowFormDialog(CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode)

            End If

        End Sub
        Private Sub ButtonItemDiary_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemDiary_Add.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                If AdvantageFramework.Maintenance.Client.Presentation.DiaryAddDialog.ShowFormDialog(11, 58, CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm()

                    Try

                        LoadGrid()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemActivity_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActivity_Add.Click

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                AdvantageFramework.Calendar.GetDefaultStartAndEndTimes(StartDate, EndDate)

                If AdvantageFramework.Desktop.Presentation.ActivityEditDialog.ShowFormDialog(0, "", StartDate, EndDate, Me.Session.User.EmployeeCode, CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm()

                    Try

                        LoadGrid()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemActivityAdd_Click(sender As Object, e As EventArgs)

            'objects
            Dim CRMActivity As AdvantageFramework.CRMCentral.Classes.CRMActivity = Nothing
            Dim ActivityType As String = ""
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            CRMActivity = LoadFirstSelectCRMActivity()

            If CRMActivity IsNot Nothing Then

                Try

                    ActivityType = CType(sender, DevComponents.DotNetBar.ButtonItem).Tag

                Catch ex As Exception
                    ActivityType = ""
                End Try

                AdvantageFramework.Calendar.GetDefaultStartAndEndTimes(StartDate, EndDate)

                If AdvantageFramework.Desktop.Presentation.ActivityEditDialog.ShowFormDialog(0, ActivityType, StartDate, EndDate, Me.Session.User.EmployeeCode, CRMActivity.ClientCode, CRMActivity.DivisionCode, CRMActivity.ProductCode) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm()

                    Try

                        LoadGrid()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace