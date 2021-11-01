Namespace Maintenance.Accounting.Presentation

    Public Class AccountsReceivableStatementSetupForm

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

            LoadClientSetupTab()

            LoadProductSetupTab()

            LoadStatementCommentsTab()

        End Sub
        Private Sub LoadClientSetupTab()

            'objects
            Dim ClientCodes As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ClientCodes = AdvantageFramework.Database.Procedures.Client.LoadWithOfficeLimits(DbContext, Me.Session).Select(Function(Entity) Entity.Code).ToList

                DataGridViewClientSetup_ClientARStatement.DataSource = AdvantageFramework.Database.Procedures.ClientAccountsReceivableStatement.Load(DbContext).Include("ClientContact") _
                                                                        .Where(Function(Entity) ClientCodes.Contains(Entity.ClientCode)).ToList _
                                                                        .Select(Function(Entity) New AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement(Entity)).ToList

            End Using

            DataGridViewClientSetup_ClientARStatement.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadProductSetupTab()

            'objects
            Dim Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Products = AdvantageFramework.Database.Procedures.Product.LoadWithOfficeLimits(DbContext, Me.Session).ToList

                DataGridViewProductSetup_ProductARStatement.DataSource = AdvantageFramework.Database.Procedures.ProductAccountsReceivableStatement.Load(DbContext).Include("ClientContact").ToList _
                                                                            .Where(Function(Entity) Products.Any(Function(Product) Product.ClientCode = Entity.ClientCode AndAlso Product.DivisionCode = Entity.DivisionCode AndAlso Product.Code = Entity.ProductCode) = True).ToList _
                                                                            .Select(Function(Entity) New AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement(Entity)).ToList

            End Using

            DataGridViewProductSetup_ProductARStatement.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadStatementCommentsTab()

            Dim AgencyCommentType As AdvantageFramework.Database.Entities.AgencyCommentTypes = Nothing
            Dim AgencyComment As AdvantageFramework.Database.Entities.AgencyComment = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AgencyCommentType = AdvantageFramework.Database.Entities.AgencyCommentTypes.AUTO_AR_STATEMENT

                AgencyComment = AdvantageFramework.Database.Procedures.AgencyComment.LoadByCommentType(DbContext, AgencyCommentType)

                If AgencyComment IsNot Nothing Then
                    TextBoxStatementComments_Comments.Text = AgencyComment.Comment
                End If

                TextBoxStatementComments_Comments.Tag = AgencyCommentType

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewClientSetup_ClientARStatement.IsNewItemRow Then

                ButtonItemClient_Cancel.Enabled = True
                ButtonItemClient_Save.Enabled = False
                ButtonItemClient_Delete.Enabled = False

            Else

                ButtonItemClient_Cancel.Enabled = False
                ButtonItemClient_Save.Enabled = DataGridViewClientSetup_ClientARStatement.UserEntryChanged
                ButtonItemClient_Delete.Enabled = DataGridViewClientSetup_ClientARStatement.HasASelectedRow(True)

            End If

            If DataGridViewProductSetup_ProductARStatement.IsNewItemRow Then

                ButtonItemProduct_Cancel.Enabled = True
                ButtonItemProduct_Save.Enabled = False
                ButtonItemProduct_Delete.Enabled = False

            Else

                ButtonItemProduct_Cancel.Enabled = False
                ButtonItemProduct_Save.Enabled = DataGridViewProductSetup_ProductARStatement.UserEntryChanged
                ButtonItemProduct_Delete.Enabled = DataGridViewProductSetup_ProductARStatement.HasASelectedRow(True)

            End If

            ButtonItemComments_Save.Enabled = TextBoxStatementComments_Comments.UserEntryChanged

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AccountsReceivableStatementSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.AccountsReceivableStatementSetupForm = Nothing

            AccountsReceivableStatementSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.AccountsReceivableStatementSetupForm()

            AccountsReceivableStatementSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsReceivableStatementSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemClient_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemClient_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemClient_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemProduct_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemProduct_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemProduct_Save.Image = AdvantageFramework.My.Resources.SaveImage

            ButtonItemComments_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemComments_SpellCheck.Image = AdvantageFramework.My.Resources.ValidateImage

            DataGridViewClientSetup_ClientARStatement.AutoFilterLookupColumns = True
            DataGridViewClientSetup_ClientARStatement.AutoloadRepositoryDatasource = True

            DataGridViewProductSetup_ProductARStatement.AutoFilterLookupColumns = True
            DataGridViewProductSetup_ProductARStatement.AutoloadRepositoryDatasource = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxStatementComments_Comments.SetPropertySettings(AdvantageFramework.Database.Entities.AgencyComment.Properties.Comment)

            End Using

            ButtonItemClient_Save.Visible = True

            LoadGrid()

        End Sub
        Private Sub AccountsReceivableStatementSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemClient_Save.Enabled = DataGridViewClientSetup_ClientARStatement.UserEntryChanged
            ButtonItemProduct_Save.Enabled = DataGridViewProductSetup_ProductARStatement.UserEntryChanged
            ButtonItemComments_Save.Enabled = TextBoxStatementComments_Comments.UserEntryChanged

        End Sub
        Private Sub AccountsReceivableStatementSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemClient_Save.Enabled = DataGridViewClientSetup_ClientARStatement.UserEntryChanged
            ButtonItemProduct_Save.Enabled = DataGridViewProductSetup_ProductARStatement.UserEntryChanged
            ButtonItemComments_Save.Enabled = TextBoxStatementComments_Comments.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub TabControlForm_AgencySetup_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_ARStatementSetup.SelectedTabChanging

            RibbonBarOptions_Client.Visible = If(e.NewTab Is TabItemARStatementSetup_ClientSetupTab, True, False)
            RibbonBarOptions_Product.Visible = If(e.NewTab Is TabItemARStatementSetup_ProductSetupTab, True, False)
            RibbonBarOptions_Comments.Visible = If(e.NewTab Is TabItemARStatementSetup_StatementCommentsTab, True, False)

        End Sub

#Region "  Client "

        Private Sub ButtonItemClient_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemClient_Save.Click

            Dim ClientAccountsReceivableStatements As Generic.List(Of AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement) = Nothing
            Dim ErrorMessage As String = ""

            If DataGridViewClientSetup_ClientARStatement.HasRows Then

                DataGridViewClientSetup_ClientARStatement.CurrentView.CloseEditorForUpdating()

                ClientAccountsReceivableStatements = (From Entity In DataGridViewClientSetup_ClientARStatement.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement)()
                                                      Select Entity.GetEntity).ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ClientAccountsReceivableStatement In ClientAccountsReceivableStatements

                            AdvantageFramework.Database.Procedures.ClientAccountsReceivableStatement.Update(DbContext, ClientAccountsReceivableStatement)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewClientSetup_ClientARStatement.ClearChanged()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

                Me.RaiseClearChanged()

            End If

        End Sub
        Private Sub ButtonItemClient_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemClient_Delete.Click

            'objects
            Dim ClientAccountsReceivableStatement As AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewClientSetup_ClientARStatement.HasASelectedRow Then

                DataGridViewClientSetup_ClientARStatement.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewClientSetup_ClientARStatement.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    ClientAccountsReceivableStatement = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    ClientAccountsReceivableStatement = Nothing
                                End Try

                                If ClientAccountsReceivableStatement IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.ClientAccountsReceivableStatement.Delete(DbContext, ClientAccountsReceivableStatement.GetEntity) Then

                                        DataGridViewClientSetup_ClientARStatement.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewClientSetup_ClientARStatement.CheckForModifiedRows = False Then

                        DataGridViewClientSetup_ClientARStatement.ClearChanged()

                        Me.RaiseClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemClient_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemClient_Cancel.Click

            DataGridViewClientSetup_ClientARStatement.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewClientSetup_ClientARStatement_AddNewRowEvent(RowObject As Object) Handles DataGridViewClientSetup_ClientARStatement.AddNewRowEvent

            'objects
            Dim ClientAccountsReceivableStatementClass As AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement = Nothing
            Dim ClientAccountsReceivableStatement As AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement Then

                Me.ShowWaitForm("Processing...")

                ClientAccountsReceivableStatementClass = RowObject

                ClientAccountsReceivableStatement = ClientAccountsReceivableStatementClass.GetEntity()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ClientAccountsReceivableStatement.IsEntityBeingAdded() Then

                        ClientAccountsReceivableStatement.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.ClientAccountsReceivableStatement.Insert(DbContext, ClientAccountsReceivableStatement)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewClientSetup_ClientARStatement_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewClientSetup_ClientARStatement.CellValueChangedEvent

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            If DataGridViewClientSetup_ClientARStatement.CurrentView.IsNewItemRow(e.RowHandle) Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientContactID.ToString Then

                    SubItemGridLookUpEditControl = e.Column.ColumnEdit

                    If SubItemGridLookUpEditControl.GetRowByKeyValue(e.Value) IsNot Nothing Then

                        DataGridViewClientSetup_ClientARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientContactName.ToString, SubItemGridLookUpEditControl.GetRowByKeyValue(e.Value).Description)

                        If SubItemGridLookUpEditControl.GetRowByKeyValue(e.Value).ContactTypeID > 0 Then

                            DataGridViewClientSetup_ClientARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ContactTypeID.ToString, SubItemGridLookUpEditControl.GetRowByKeyValue(e.Value).ContactTypeID)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewClientSetup_ClientARStatement_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewClientSetup_ClientARStatement.CellValueChangingEvent

            'objects
            Dim ClientAccountsReceivableStatement As AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement = Nothing

            If DataGridViewClientSetup_ClientARStatement.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.DistributeViaEmail.ToString OrElse
                       e.Column.FieldName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.DistributeViaPrint.ToString OrElse
                       e.Column.FieldName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.IncludeOnAccount.ToString Then

                    Try

                        ClientAccountsReceivableStatement = DataGridViewClientSetup_ClientARStatement.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ClientAccountsReceivableStatement = Nothing
                    End Try

                    If ClientAccountsReceivableStatement IsNot Nothing Then

                        Try

                            Select Case e.Column.FieldName

                                Case AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement.Properties.DistributeViaEmail.ToString

                                    ClientAccountsReceivableStatement.DistributeViaEmail = Convert.ToInt16(e.Value)

                                Case AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement.Properties.DistributeViaPrint.ToString

                                    ClientAccountsReceivableStatement.DistributeViaPrint = Convert.ToInt16(e.Value)

                                Case AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement.Properties.IncludeOnAccount.ToString

                                    ClientAccountsReceivableStatement.IncludeOnAccount = Convert.ToInt16(e.Value)

                            End Select

                        Catch ex As Exception
                            ClientAccountsReceivableStatement.DistributeViaEmail = ClientAccountsReceivableStatement.DistributeViaEmail
                            ClientAccountsReceivableStatement.DistributeViaPrint = ClientAccountsReceivableStatement.DistributeViaPrint
                            ClientAccountsReceivableStatement.IncludeOnAccount = ClientAccountsReceivableStatement.IncludeOnAccount
                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                Saved = AdvantageFramework.Database.Procedures.ClientAccountsReceivableStatement.Update(DbContext, ClientAccountsReceivableStatement.GetEntity)

                            End Using

                        Catch ex As Exception

                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    End If

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientCode.ToString Then

                DataGridViewClientSetup_ClientARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientContactID.ToString, 0)

            End If

        End Sub
        Private Sub DataGridViewClientSetup_ClientARStatement_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewClientSetup_ClientARStatement.InitNewRowEvent

            EnableOrDisableActions()

            DataGridViewClientSetup_ClientARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.DistributeViaPrint.ToString, 1)
            DataGridViewClientSetup_ClientARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.IncludeOnAccount.ToString, 1)
            DataGridViewClientSetup_ClientARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.UseAddress.ToString, AdvantageFramework.Database.Entities.ClientARAddressSelection.ClientStatement)

        End Sub
        Private Sub DataGridViewClientSetup_ClientARStatement_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewClientSetup_ClientARStatement.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewClientSetup_ClientARStatement_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewClientSetup_ClientARStatement.QueryPopupNeedDatasourceEvent

            'objects
            Dim ClientCode As String = Nothing
            Dim ClientContactID As String = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim AddressList As Generic.List(Of AdvantageFramework.Database.Classes.Address) = Nothing
            Dim ClientAddress As AdvantageFramework.Database.Classes.Address = Nothing
            Dim ClientContactAddress As AdvantageFramework.Database.Classes.Address = Nothing

            Select Case FieldName

                Case AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientContactID.ToString

                    ClientCode = DataGridViewClientSetup_ClientARStatement.CurrentView.GetRowCellValue(DataGridViewClientSetup_ClientARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientCode.ToString)

                    If String.IsNullOrEmpty(ClientCode) = False Then

                        OverrideDefaultDatasource = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadAllActive(DbContext)
                                          Where Entity.ClientCode = ClientCode
                                          Select Entity).ToList

                        End Using

                    End If

                Case AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.UseAddress.ToString

                    ClientCode = DataGridViewClientSetup_ClientARStatement.CurrentView.GetRowCellValue(DataGridViewClientSetup_ClientARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientCode.ToString)
                    ClientContactID = DataGridViewClientSetup_ClientARStatement.CurrentView.GetRowCellValue(DataGridViewClientSetup_ClientARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientContactID.ToString)

                    If String.IsNullOrEmpty(ClientCode) = False Then

                        OverrideDefaultDatasource = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode)
                            ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, ClientContactID)

                            AddressList = New Generic.List(Of AdvantageFramework.Database.Classes.Address)

                            If Client IsNot Nothing Then

                                ClientAddress = New AdvantageFramework.Database.Classes.Address(AdvantageFramework.Database.Entities.ClientARAddressSelection.ClientStatement,
                                                                                                AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.ClientARAddressSelection), AdvantageFramework.Database.Entities.ClientARAddressSelection.ClientStatement),
                                                                                                Client.StatementAddress,
                                                                                                Client.StatementAddress2,
                                                                                                Client.StatementCity,
                                                                                                Client.StatementState,
                                                                                                Client.StatementZip,
                                                                                                Client.StatementCountry,
                                                                                                Client.StatementCounty)

                                AddressList.Add(ClientAddress)

                            End If

                            If ClientContact IsNot Nothing Then

                                ClientContactAddress = New AdvantageFramework.Database.Classes.Address(AdvantageFramework.Database.Entities.ClientARAddressSelection.ClientContact,
                                                                                                       AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.ClientARAddressSelection), AdvantageFramework.Database.Entities.ClientARAddressSelection.ClientContact),
                                                                                                       ClientContact.Address,
                                                                                                       ClientContact.Address2,
                                                                                                       ClientContact.City,
                                                                                                       ClientContact.State,
                                                                                                       ClientContact.Zip,
                                                                                                       ClientContact.Country,
                                                                                                       ClientContact.County)
                                AddressList.Add(ClientContactAddress)

                            End If

                            Datasource = AddressList

                        End Using

                    End If

            End Select

        End Sub
        Private Sub DataGridViewClientSetup_ClientARStatement_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewClientSetup_ClientARStatement.ShownEditorEvent

            'objects
            Dim ClientCode As String = Nothing
            Dim FieldName As String = Nothing
            Dim ClientContactID As String = Nothing

            FieldName = DataGridViewClientSetup_ClientARStatement.CurrentView.FocusedColumn.FieldName

            If FieldName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientContactID.ToString OrElse
                    FieldName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.UseAddress.ToString Then

                ClientCode = DataGridViewClientSetup_ClientARStatement.CurrentView.GetRowCellValue(DataGridViewClientSetup_ClientARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientCode.ToString)

                If String.IsNullOrEmpty(ClientCode) Then

                    DataGridViewClientSetup_ClientARStatement.CurrentView.CloseEditor()

                End If

            End If

        End Sub
        Private Sub DataGridViewClientSetup_ClientARStatement_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewClientSetup_ClientARStatement.CustomRowCellEditEvent

            If e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ContactTypeID.ToString Then

                If TypeOf e.RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit Then

                    CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit).ReadOnly = True
                    CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                    For Each EditorButton In CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit).Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                        EditorButton.Visible = False

                    Next

                End If

            End If

        End Sub
        Private Sub DataGridViewClientSetup_ClientARStatement_RepositoryDataSourceLoading(FieldName As String, ByRef Cancel As Boolean) Handles DataGridViewClientSetup_ClientARStatement.RepositoryDataSourceLoading

        End Sub

#End Region

#Region "  Product "

        Private Sub ButtonItemProduct_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemProduct_Save.Click

            Dim ProductAccountsReceivableStatements As Generic.List(Of AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement) = Nothing
            Dim ErrorMessage As String = ""

            If DataGridViewProductSetup_ProductARStatement.HasRows Then

                DataGridViewProductSetup_ProductARStatement.CurrentView.CloseEditorForUpdating()

                ProductAccountsReceivableStatements = (From Entity In DataGridViewProductSetup_ProductARStatement.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement)()
                                                       Select Entity.GetEntity).ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ProductAccountsReceivableStatement In ProductAccountsReceivableStatements

                            AdvantageFramework.Database.Procedures.ProductAccountsReceivableStatement.Update(DbContext, ProductAccountsReceivableStatement)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewProductSetup_ProductARStatement.ClearChanged()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

                Me.RaiseClearChanged()

            End If

        End Sub
        Private Sub ButtonItemProduct_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemProduct_Delete.Click

            'objects
            Dim ProductAccountsReceivableStatement As AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewProductSetup_ProductARStatement.HasASelectedRow Then

                DataGridViewProductSetup_ProductARStatement.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewProductSetup_ProductARStatement.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    ProductAccountsReceivableStatement = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    ProductAccountsReceivableStatement = Nothing
                                End Try

                                If ProductAccountsReceivableStatement IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.ProductAccountsReceivableStatement.Delete(DbContext, ProductAccountsReceivableStatement.GetEntity) Then

                                        DataGridViewProductSetup_ProductARStatement.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewProductSetup_ProductARStatement.CheckForModifiedRows = False Then

                        DataGridViewProductSetup_ProductARStatement.ClearChanged()

                        Me.RaiseClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemProduct_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemProduct_Cancel.Click

            DataGridViewProductSetup_ProductARStatement.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewProductSetup_ProductARStatement_AddNewRowEvent(RowObject As Object) Handles DataGridViewProductSetup_ProductARStatement.AddNewRowEvent

            'objects
            Dim ProductAccountsReceivableStatementClass As AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement = Nothing
            Dim ProductAccountsReceivableStatement As AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement Then

                Me.ShowWaitForm("Processing...")

                ProductAccountsReceivableStatementClass = RowObject

                ProductAccountsReceivableStatement = ProductAccountsReceivableStatementClass.GetEntity

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ProductAccountsReceivableStatement.IsEntityBeingAdded() Then

                        ProductAccountsReceivableStatement.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.ProductAccountsReceivableStatement.Insert(DbContext, ProductAccountsReceivableStatement)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewProductSetup_ProductARStatement_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewProductSetup_ProductARStatement.CellValueChangedEvent

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            If DataGridViewProductSetup_ProductARStatement.CurrentView.IsNewItemRow(e.RowHandle) Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientContactID.ToString Then

                    SubItemGridLookUpEditControl = e.Column.ColumnEdit

                    If SubItemGridLookUpEditControl.GetRowByKeyValue(e.Value) IsNot Nothing Then

                        DataGridViewProductSetup_ProductARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientContactName.ToString, SubItemGridLookUpEditControl.GetRowByKeyValue(e.Value).Description)

                        If SubItemGridLookUpEditControl.GetRowByKeyValue(e.Value).ContactTypeID > 0 Then

                            DataGridViewProductSetup_ProductARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ContactTypeID.ToString, SubItemGridLookUpEditControl.GetRowByKeyValue(e.Value).ContactTypeID)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewProductSetup_ProductARStatement_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewProductSetup_ProductARStatement.CellValueChangingEvent

            'objects
            Dim ProductAccountsReceivableStatement As AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement = Nothing

            If DataGridViewProductSetup_ProductARStatement.IsNewItemOrAutoFilterRow(e.RowHandle) = False Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement.Properties.DistributeViaEmail.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement.Properties.DistributeViaPrint.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement.Properties.IncludeOnAccount.ToString Then

                    Try

                        ProductAccountsReceivableStatement = DataGridViewProductSetup_ProductARStatement.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ProductAccountsReceivableStatement = Nothing
                    End Try

                    If ProductAccountsReceivableStatement IsNot Nothing Then

                        Try

                            Select Case e.Column.FieldName

                                Case AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement.Properties.DistributeViaEmail.ToString

                                    ProductAccountsReceivableStatement.DistributeViaEmail = Convert.ToInt16(e.Value)

                                Case AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement.Properties.DistributeViaPrint.ToString

                                    ProductAccountsReceivableStatement.DistributeViaPrint = Convert.ToInt16(e.Value)

                                Case AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement.Properties.IncludeOnAccount.ToString

                                    ProductAccountsReceivableStatement.IncludeOnAccount = Convert.ToInt16(e.Value)

                            End Select

                        Catch ex As Exception
                            ProductAccountsReceivableStatement.DistributeViaEmail = ProductAccountsReceivableStatement.DistributeViaEmail
                            ProductAccountsReceivableStatement.DistributeViaPrint = ProductAccountsReceivableStatement.DistributeViaPrint
                            ProductAccountsReceivableStatement.IncludeOnAccount = ProductAccountsReceivableStatement.IncludeOnAccount
                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                Saved = AdvantageFramework.Database.Procedures.ProductAccountsReceivableStatement.Update(DbContext, ProductAccountsReceivableStatement.GetEntity)

                            End Using

                        Catch ex As Exception

                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    End If

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientCode.ToString Then

                DataGridViewProductSetup_ProductARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientContactID.ToString, 0)

            End If

        End Sub
        Private Sub DataGridViewProductSetup_ProductARStatement_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewProductSetup_ProductARStatement.InitNewRowEvent

            EnableOrDisableActions()

            DataGridViewProductSetup_ProductARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.DistributeViaPrint.ToString, 1)
            DataGridViewProductSetup_ProductARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.IncludeOnAccount.ToString, 1)
            DataGridViewProductSetup_ProductARStatement.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.UseAddress.ToString, AdvantageFramework.Database.Entities.ProductARAddressSelection.ProductStatement)

        End Sub
        Private Sub DataGridViewProductSetup_ProductARStatement_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewProductSetup_ProductARStatement.QueryPopupNeedDatasourceEvent

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ClientContactID As String = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim AddressList As Generic.List(Of AdvantageFramework.Database.Classes.Address) = Nothing
            Dim ProductAddress As AdvantageFramework.Database.Classes.Address = Nothing
            Dim ClientContactAddress As AdvantageFramework.Database.Classes.Address = Nothing

            Select Case FieldName

                Case AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientContactID.ToString

                    ClientCode = DataGridViewProductSetup_ProductARStatement.CurrentView.GetRowCellValue(DataGridViewProductSetup_ProductARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientCode.ToString)

                    If String.IsNullOrEmpty(ClientCode) = False Then

                        OverrideDefaultDatasource = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadAllActive(DbContext)
                                          Where Entity.ClientCode = ClientCode
                                          Select Entity).ToList

                        End Using

                    End If

                Case AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.UseAddress.ToString

                    ClientCode = DataGridViewProductSetup_ProductARStatement.CurrentView.GetRowCellValue(DataGridViewProductSetup_ProductARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientCode.ToString)
                    DivisionCode = DataGridViewProductSetup_ProductARStatement.CurrentView.GetRowCellValue(DataGridViewProductSetup_ProductARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.DivisionCode.ToString)
                    ProductCode = DataGridViewProductSetup_ProductARStatement.CurrentView.GetRowCellValue(DataGridViewProductSetup_ProductARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ProductCode.ToString)
                    ClientContactID = DataGridViewProductSetup_ProductARStatement.CurrentView.GetRowCellValue(DataGridViewProductSetup_ProductARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientContactID.ToString)

                    If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                        OverrideDefaultDatasource = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)
                            ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, ClientContactID)

                            AddressList = New Generic.List(Of AdvantageFramework.Database.Classes.Address)

                            If Product IsNot Nothing Then

                                ProductAddress = New AdvantageFramework.Database.Classes.Address(AdvantageFramework.Database.Entities.ProductARAddressSelection.ProductStatement,
                                                                                                 AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.ProductARAddressSelection), AdvantageFramework.Database.Entities.ProductARAddressSelection.ProductStatement),
                                                                                                 Product.StatementAddress,
                                                                                                 Product.StatementAddress2,
                                                                                                 Product.StatementCity,
                                                                                                 Product.StatementState,
                                                                                                 Product.StatementZip,
                                                                                                 Product.StatementCountry,
                                                                                                 Product.StatementCounty)

                                AddressList.Add(ProductAddress)

                            End If

                            If ClientContact IsNot Nothing Then

                                ClientContactAddress = New AdvantageFramework.Database.Classes.Address(AdvantageFramework.Database.Entities.ProductARAddressSelection.ProductContact,
                                                                                                       AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.ProductARAddressSelection), AdvantageFramework.Database.Entities.ProductARAddressSelection.ProductContact),
                                                                                                       ClientContact.Address,
                                                                                                       ClientContact.Address2,
                                                                                                       ClientContact.City,
                                                                                                       ClientContact.State,
                                                                                                       ClientContact.Zip,
                                                                                                       ClientContact.Country,
                                                                                                       ClientContact.County)
                                AddressList.Add(ClientContactAddress)

                            End If

                            Datasource = AddressList

                        End Using

                    End If

            End Select

        End Sub
        Private Sub DataGridViewProductSetup_ProductARStatement_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewProductSetup_ProductARStatement.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewProductSetup_ProductARStatement_ShownEditorEvent(sender As Object, e As System.EventArgs) Handles DataGridViewProductSetup_ProductARStatement.ShownEditorEvent

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim FieldName As String = Nothing
            Dim ClientContactID As String = Nothing

            FieldName = DataGridViewProductSetup_ProductARStatement.CurrentView.FocusedColumn.FieldName

            If FieldName = AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientContactID.ToString OrElse
               FieldName = AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.UseAddress.ToString Then

                ClientCode = DataGridViewProductSetup_ProductARStatement.CurrentView.GetRowCellValue(DataGridViewProductSetup_ProductARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientCode.ToString)
                DivisionCode = DataGridViewProductSetup_ProductARStatement.CurrentView.GetRowCellValue(DataGridViewProductSetup_ProductARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.DivisionCode.ToString)
                ProductCode = DataGridViewProductSetup_ProductARStatement.CurrentView.GetRowCellValue(DataGridViewProductSetup_ProductARStatement.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ProductCode.ToString)

                If String.IsNullOrEmpty(ClientCode) OrElse String.IsNullOrEmpty(DivisionCode) OrElse String.IsNullOrEmpty(ProductCode) Then

                    DataGridViewProductSetup_ProductARStatement.CurrentView.CloseEditor()

                End If

            End If

        End Sub
        Private Sub DataGridViewProductSetup_ProductARStatement_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewProductSetup_ProductARStatement.CustomRowCellEditEvent

            If e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ContactTypeID.ToString Then

                If TypeOf e.RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit Then

                    CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit).ReadOnly = True
                    CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                    For Each EditorButton In CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit).Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                        EditorButton.Visible = False

                    Next

                End If

            End If

        End Sub
        Private Sub DataGridViewProductSetup_ProductARStatement_RepositoryDataSourceLoading(FieldName As String, ByRef Cancel As Boolean) Handles DataGridViewProductSetup_ProductARStatement.RepositoryDataSourceLoading

        End Sub

#End Region

#Region "  Comments "

        Private Sub ButtonItemComments_SpellCheck_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemComments_SpellCheck.Click

            TextBoxStatementComments_Comments.CheckSpelling()

        End Sub
        Private Sub ButtonItemComments_Save_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemComments_Save.Click

            Dim AgencyComment As AdvantageFramework.Database.Entities.AgencyComment = Nothing
            Dim AgencyCommentType As AdvantageFramework.Database.Entities.AgencyCommentTypes = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AgencyCommentType = DirectCast(TextBoxStatementComments_Comments.Tag, AdvantageFramework.Database.Entities.AgencyCommentTypes)

                        AgencyComment = AdvantageFramework.Database.Procedures.AgencyComment.LoadByCommentType(DbContext, AgencyCommentType)

                        If AgencyComment IsNot Nothing Then

                            AgencyComment.Comment = TextBoxStatementComments_Comments.Text

                            If AdvantageFramework.Database.Procedures.AgencyComment.Update(DbContext, AgencyComment) Then

                                TextBoxStatementComments_Comments.ClearChanged()

                                Me.RaiseClearChanged()

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace