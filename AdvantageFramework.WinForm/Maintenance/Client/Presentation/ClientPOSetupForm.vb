Namespace Maintenance.Client.Presentation

    Public Class ClientPOSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Dim ClientPOList As Generic.List(Of AdvantageFramework.Database.Classes.ClientPO) = Nothing
            Dim Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientPOList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.ClientPO)("exec advsp_maintenance_clientpo_select").ToList
                    Products = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, False)

                    DataGridViewForm_ClientPO.DataSource = (From ClientPO In ClientPOList
                                                            Where Products.Any(Function(Entity) Entity.ID = ClientPO.ProductID) = True
                                                            Select ClientPO).ToList

                End Using

            End Using

            ToggleColumnVisibility()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_ClientPO.IsNewItemRow Then

                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Cancel.Enabled = True

            Else

                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Cancel.Enabled = False

            End If

        End Sub
        Private Sub LoadRepositoryItems()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            For Each GridColumn In DataGridViewForm_ClientPO.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.Visible AndAlso TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                    Try

                        SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                    Catch ex As Exception
                        SubItemGridLookUpEditControl = Nothing
                    End Try

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Select Case GridColumn.FieldName

                                Case AdvantageFramework.Database.Classes.ClientPO.Properties.ClientCode.ToString

                                    SubItemGridLookUpEditControl.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList

                                Case AdvantageFramework.Database.Classes.ClientPO.Properties.DivisionCode.ToString

                                    SubItemGridLookUpEditControl.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)

                                Case AdvantageFramework.Database.Classes.ClientPO.Properties.ProductCode.ToString

                                    SubItemGridLookUpEditControl.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

                            End Select

                        End Using

                    End If

                End If

            Next

        End Sub
        Private Sub ToggleColumnVisibility()

            Dim IsVisible As Boolean = False
            Dim VisibleIndex As Integer = 0

            IsVisible = ButtonItemView_ShowDescriptions.Checked

            For Each GridColumn In DataGridViewForm_ClientPO.Columns

                If (GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.ClientName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.ProductDescription.ToString) AndAlso
                        Not IsVisible Then

                    GridColumn.VisibleIndex = -1
                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.ID.ToString Then

                    GridColumn.VisibleIndex = -1
                    GridColumn.Visible = False

                Else

                    GridColumn.VisibleIndex = VisibleIndex
                    VisibleIndex += 1
                    GridColumn.Visible = True

                End If

            Next

            DataGridViewForm_ClientPO.CurrentView.BestFitColumns()

        End Sub
        Private Function CreateEntityFromObject(ByVal RowObject As Object, ByVal IsNew As Boolean, ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.ClientPO

            Dim ClientPO As AdvantageFramework.Database.Entities.ClientPO = Nothing
            Dim ClientPOClass As AdvantageFramework.Database.Classes.ClientPO = Nothing

            ClientPOClass = DirectCast(RowObject, AdvantageFramework.Database.Classes.ClientPO)

            If IsNew Then

                ClientPO = New AdvantageFramework.Database.Entities.ClientPO
                ClientPO.CreateDate = ClientPOClass.CreateDate

            Else

                ClientPO = AdvantageFramework.Database.Procedures.ClientPO.LoadByID(DataContext, ClientPOClass.ID)

            End If

            If ClientPO IsNot Nothing Then

                ClientPO.ClientCode = ClientPOClass.ClientCode
                ClientPO.DivisionCode = ClientPOClass.DivisionCode
                ClientPO.ProductCode = ClientPOClass.ProductCode
                ClientPO.ClientPONumber = ClientPOClass.ClientPONumber
                ClientPO.ClientPODescription = ClientPOClass.ClientPODescription
                ClientPO.IsInactive = If(ClientPOClass.IsInactive, 1, 0)

            End If

            CreateEntityFromObject = ClientPO

        End Function
        Private Function GetClientPOLastUsed() As Object

            GetClientPOLastUsed = AdvantageFramework.Agency.GetValue(Session, Agency.Methods.Settings.CLIENTPO_LAST_USED)

        End Function
        Private Sub SaveClientPOLastUsed(ByVal LastUsed As Object)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If IsNumeric(LastUsed) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = {0} WHERE [AGY_SETTINGS_CODE] = '{1}'", LastUsed, AdvantageFramework.Agency.Settings.CLIENTPO_LAST_USED.ToString))

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = NULL WHERE [AGY_SETTINGS_CODE] = '{0}'", AdvantageFramework.Agency.Settings.CLIENTPO_LAST_USED.ToString))

                End If

                Me.NumericInputControlVertical_LastNumberUsed.ClearChanged()

            End Using

        End Sub
        Private Function GetClientPOAutoNumberEnabled() As Boolean

            Try

                GetClientPOAutoNumberEnabled = CBool(AdvantageFramework.Agency.GetValue(Session, Agency.Methods.Settings.CLIENTPO_ENBL_AUTONM))

            Catch ex As Exception
                GetClientPOAutoNumberEnabled = False
            End Try

        End Function
        Private Sub SaveClientPOAutoNumberEnabled(ByVal Enabled As Boolean)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[AGY_SETTINGS] SET [AGY_SETTINGS_VALUE] = {0} WHERE [AGY_SETTINGS_CODE] = '{1}'", If(Enabled, 1, 0), AdvantageFramework.Agency.Settings.CLIENTPO_ENBL_AUTONM.ToString))

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientPOSetupForm As Presentation.ClientPOSetupForm = Nothing

            ClientPOSetupForm = New Presentation.ClientPOSetupForm()

            ClientPOSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientPOSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemAutoGenerate_Enabled.Image = AdvantageFramework.My.Resources.CheckImage

            ButtonItemView_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage

            DataGridViewForm_ClientPO.AutoloadRepositoryDatasource = False
            DataGridViewForm_ClientPO.AutoFilterLookupColumns = True
            DataGridViewForm_ClientPO.MultiSelect = False

            NumericInputControlVertical_LastNumberUsed.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
            NumericInputControlVertical_LastNumberUsed.Value = Nothing
            NumericInputControlVertical_LastNumberUsed.EditValue = GetClientPOLastUsed()

            ButtonItemAutoGenerate_Enabled.Checked = GetClientPOAutoNumberEnabled()

            LoadGrid()

            LoadRepositoryItems()

            DataGridViewForm_ClientPO.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub ClientPOSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ClientPOSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_ClientPO.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ClientPOs As Generic.List(Of AdvantageFramework.Database.Classes.ClientPO) = Nothing
            Dim ClientPO As AdvantageFramework.Database.Entities.ClientPO = Nothing

            SaveClientPOLastUsed(NumericInputControlVertical_LastNumberUsed.GetValue)

            If DataGridViewForm_ClientPO.HasRows Then

                DataGridViewForm_ClientPO.CurrentView.CloseEditorForUpdating()

                DataGridViewForm_ClientPO.ValidateAllRows()

                If DataGridViewForm_ClientPO.HasAnyInvalidRows Then

                    AdvantageFramework.WinForm.MessageBox.Show("Fix errors in grid.")

                Else

                    ClientPOs = DataGridViewForm_ClientPO.GetAllModifiedRows().OfType(Of AdvantageFramework.Database.Classes.ClientPO).ToList

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")
                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each CP In ClientPOs

                                ClientPO = CreateEntityFromObject(CP, False, DataContext)

                                AdvantageFramework.Database.Procedures.ClientPO.Update(DataContext, ClientPO)

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    Me.CloseWaitForm()

                End If

            End If

            Try

                DataGridViewForm_ClientPO.ValidateAllRowsAndClearChanged(True)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_ClientPO.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemView_ShowDescriptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ShowDescriptions.CheckedChanged

            ToggleColumnVisibility()

        End Sub
        Private Sub DataGridViewForm_ClientPO_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_ClientPO.AddNewRowEvent

            'objects
            Dim ClientPO As AdvantageFramework.Database.Entities.ClientPO = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.ClientPO Then

                Me.ShowWaitForm("Processing...")

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientPO = CreateEntityFromObject(RowObject, True, DataContext)

                    ClientPO.DataContext = DataContext

                    AdvantageFramework.Database.Procedures.ClientPO.Insert(DataContext, ClientPO)

                    SaveClientPOLastUsed(NumericInputControlVertical_LastNumberUsed.GetValue)

                End Using

                Me.CloseWaitForm()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_ClientPO_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ClientPO.CellValueChangingEvent

            Dim ClientPO As AdvantageFramework.Database.Entities.ClientPO = Nothing
            Dim ID As Integer = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.IsInactive.ToString Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ID = DirectCast(DataGridViewForm_ClientPO.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.ClientPO).ID

                    ClientPO = AdvantageFramework.Database.Procedures.ClientPO.LoadByID(DataContext, ID)

                    If ClientPO IsNot Nothing Then

                        Try

                            ClientPO.IsInactive = e.Value

                        Catch ex As Exception
                            ClientPO.IsInactive = ClientPO.IsInactive
                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Try

                            Saved = AdvantageFramework.Database.Procedures.ClientPO.Update(DataContext, ClientPO)

                        Catch ex As Exception

                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_ClientPO_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_ClientPO.InitNewRowEvent

            Dim ClientPO As AdvantageFramework.Database.Classes.ClientPO = Nothing
            Dim NextNumber As Integer = Nothing

            If TypeOf DataGridViewForm_ClientPO.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.ClientPO Then

                ClientPO = DirectCast(DataGridViewForm_ClientPO.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.ClientPO)

                ClientPO.CreateDate = Now.ToShortDateString

                If ButtonItemAutoGenerate_Enabled.Checked AndAlso NumericInputControlVertical_LastNumberUsed.GetValue IsNot Nothing Then

                    NumericInputControlVertical_LastNumberUsed.ByPassUserEntryChanged = True

                    NextNumber = NumericInputControlVertical_LastNumberUsed.EditValue + 1

                    NumericInputControlVertical_LastNumberUsed.Value = NextNumber

                    NumericInputControlVertical_LastNumberUsed.ByPassUserEntryChanged = False

                    ClientPO.ClientPONumber = NextNumber

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ClientPO_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_ClientPO.QueryPopupNeedDatasourceEvent

            Dim ClientPO As AdvantageFramework.Database.Classes.ClientPO = Nothing

            ClientPO = DataGridViewForm_ClientPO.CurrentView.GetRow(DataGridViewForm_ClientPO.CurrentView.FocusedRowHandle)

            If FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.ClientCode.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Datasource = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList
                                      Where Entity.IsActive = 1
                                      Select Entity).ToList

                    End Using

                End Using

            ElseIf FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.DivisionCode.ToString AndAlso ClientPO IsNot Nothing AndAlso ClientPO.ClientCode IsNot Nothing Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Datasource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList
                                      Where Entity.IsActive = 1 AndAlso
                                            Entity.ClientCode = ClientPO.ClientCode
                                      Select Entity).ToList

                    End Using

                End Using

            ElseIf FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.ProductCode.ToString AndAlso ClientPO IsNot Nothing AndAlso ClientPO.ClientCode IsNot Nothing AndAlso ClientPO.DivisionCode IsNot Nothing Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Datasource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, False).ToList
                                      Where Entity.IsActive = 1 AndAlso
                                            Entity.ClientCode = ClientPO.ClientCode AndAlso
                                            Entity.DivisionCode = ClientPO.DivisionCode
                                      Select Entity).ToList

                    End Using

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_ClientPO_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_ClientPO.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub NumericInputControlVertical_LastNumberUsed_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputControlVertical_LastNumberUsed.EditValueChanged


        End Sub

        Private Sub NumericInputControlVertical_LastNumberUsed_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles NumericInputControlVertical_LastNumberUsed.EditValueChanging


        End Sub

        Private Sub ButtonItemAutoGenerate_Enabled_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemAutoGenerate_Enabled.CheckedChanged

            SaveClientPOAutoNumberEnabled(ButtonItemAutoGenerate_Enabled.Checked)

        End Sub

#End Region

#End Region

    End Class

End Namespace