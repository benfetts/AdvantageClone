Namespace Maintenance.Media.Presentation

    Public Class AssociateSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Clients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
        Private _Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

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

            DataGridViewLeftSection_ClientsOrProducts.ClearGridCustomization()

            Select Case DirectCast(CShort(ComboBoxItemSearch_Level.ComboBoxEx.SelectedValue), AdvantageFramework.Database.Entities.AssociateLevel)

                Case Database.Entities.AssociateLevel.Client

                    DataGridViewLeftSection_ClientsOrProducts.DataSource = _Clients

                Case Database.Entities.AssociateLevel.Product

                    DataGridViewLeftSection_ClientsOrProducts.DataSource = _Products

            End Select

            DataGridViewLeftSection_ClientsOrProducts.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            AssociateControlRightSection_Associate.ClearControl()

            AssociateControlRightSection_Associate.Enabled = DataGridViewLeftSection_ClientsOrProducts.HasOnlyOneSelectedRow

            If AssociateControlRightSection_Associate.Enabled Then

                Select Case DirectCast(CShort(ComboBoxItemSearch_Level.ComboBoxEx.SelectedValue), AdvantageFramework.Database.Entities.AssociateLevel)

                    Case Database.Entities.AssociateLevel.Client

                        ClientCode = DataGridViewLeftSection_ClientsOrProducts.GetFirstSelectedRowBookmarkValue

                    Case Database.Entities.AssociateLevel.Product

                        ClientCode = DataGridViewLeftSection_ClientsOrProducts.CurrentView.GetRowCellValue(DataGridViewLeftSection_ClientsOrProducts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewLeftSection_ClientsOrProducts.CurrentView.GetRowCellValue(DataGridViewLeftSection_ClientsOrProducts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewLeftSection_ClientsOrProducts.GetFirstSelectedRowBookmarkValue

                End Select

                AssociateControlRightSection_Associate.Enabled = AssociateControlRightSection_Associate.LoadControl(ClientCode, DivisionCode, ProductCode)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            AssociateControlRightSection_Associate.Enabled = (DataGridViewLeftSection_ClientsOrProducts.HasOnlyOneSelectedRow AndAlso Me.FormShown)
            ButtonItemActions_Delete.Enabled = (AssociateControlRightSection_Associate.HasOnlyOneSelectedAssociate AndAlso AssociateControlRightSection_Associate.Enabled)
            ButtonItemActions_Copy.Enabled = If(AssociateControlRightSection_Associate.ViewingAll, False, AssociateControlRightSection_Associate.HasOnlyOneSelectedAssociate)
            ButtonItemActions_Cancel.Enabled = AssociateControlRightSection_Associate.IsNewItemRow
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            AssociateControlRightSection_Associate.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AssociateSetupForm As AdvantageFramework.Maintenance.Media.Presentation.AssociateSetupForm = Nothing

            AssociateSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.AssociateSetupForm()

            AssociateSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AssociateSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    _Clients = AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode).ToList
                    _Products = AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode, True).ToList

                    ComboBoxItemSearch_Level.ComboBoxEx.ValueMember = "Key"
                    ComboBoxItemSearch_Level.ComboBoxEx.DisplayMember = "Value"
                    ComboBoxItemSearch_Level.ComboBoxEx.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.AssociateLevel)).ToList

                End Using

            End Using

            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage

            DataGridViewLeftSection_ClientsOrProducts.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_ClientsOrProducts.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub AssociateSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AssociateSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AssociateSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_ClientsOrProducts.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_ClientsOrProducts_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_ClientsOrProducts.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_ClientsOrProducts_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_ClientsOrProducts.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_ClientsOrProducts.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If AssociateControlRightSection_Associate.Save() Then

                            Me.ClearChanged()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_ClientsOrProducts.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an associate to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim Associates As Generic.List(Of AdvantageFramework.Database.Entities.Associate) = Nothing

            Associates = AssociateControlRightSection_Associate.AssociatesInCurrentView

            If Associates IsNot Nothing AndAlso Associates.Count > 0 Then

                If AdvantageFramework.Maintenance.Media.Presentation.AssociateCopyDialog.ShowFormDialog(Associates) = Windows.Forms.DialogResult.OK Then


                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
            Dim BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec = Nothing

            If DataGridViewLeftSection_ClientsOrProducts.HasASelectedRow AndAlso AssociateControlRightSection_Associate.HasOnlyOneSelectedAssociate Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        AssociateControlRightSection_Associate.Delete()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an associate to delete.")

            End If

        End Sub
        Private Sub AssociateControlRightSection_Associate_SelectedAssociateChangedEvent() Handles AssociateControlRightSection_Associate.SelectedAssociateChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            AssociateControlRightSection_Associate.CancelNewItemRow()

        End Sub
        Private Sub ButtonItemSearch_Search_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSearch_Search.Click

            'objects
            Dim ContinueSearch As Boolean = True

            ContinueSearch = CheckForUnsavedChanges()

            If ContinueSearch Then

                LoadGrid()

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace