Namespace Maintenance.Media.Presentation

    Public Class PartnerAllocationSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LastSearchMediaOrderType As AdvantageFramework.Database.Entities.MediaOrderType = Nothing
        Private _LastSearchPartnerAllocationType As AdvantageFramework.Database.Entities.PartnerAllocationType = Nothing

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

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_CampaignsOrOrders.DataSource = AdvantageFramework.Database.Procedures.Campaign.LoadCore(DbContext)

            End Using

            DataGridViewLeftSection_CampaignsOrOrders.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGrid(ByVal MediaOrderType As AdvantageFramework.Database.Entities.MediaOrderType)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Select Case MediaOrderType

                    Case Database.Entities.MediaOrderType.Internet

                        DataGridViewLeftSection_CampaignsOrOrders.DataSource = From Entity In AdvantageFramework.Database.Procedures.InternetOrder.Load(DbContext)
                                                                               Where Entity.OrderProcessControl <> 6 AndAlso
                                                                                     Entity.OrderProcessControl <> 12
                                                                               Select Entity
                                                                               Order By Entity.OrderNumber Descending

                    Case Database.Entities.MediaOrderType.Magazine

                        DataGridViewLeftSection_CampaignsOrOrders.ItemDescription = "Magazine Order(s)"
                        DataGridViewLeftSection_CampaignsOrOrders.DataSource = From Entity In AdvantageFramework.Database.Procedures.MagazineView.Load(DbContext)
                                                                               Where Entity.OrderProcessControl <> 6 AndAlso
                                                                                     Entity.OrderProcessControl <> 12
                                                                               Select Entity
                                                                               Order By Entity.OrderNumber Descending

                    Case Database.Entities.MediaOrderType.Newspaper

                        DataGridViewLeftSection_CampaignsOrOrders.ItemDescription = "Newspaper Order(s)"
                        DataGridViewLeftSection_CampaignsOrOrders.DataSource = From Entity In AdvantageFramework.Database.Procedures.NewspaperHeaderView.Load(DbContext)
                                                                               Where Entity.OrderProcessControl <> 6 AndAlso
                                                                                     Entity.OrderProcessControl <> 12
                                                                               Select Entity
                                                                               Order By Entity.OrderNumber Descending

                    Case Database.Entities.MediaOrderType.OutOfHome

                        DataGridViewLeftSection_CampaignsOrOrders.DataSource = From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrder.Load(DbContext)
                                                                               Where Entity.OrderProcessControl <> 6 AndAlso
                                                                                     Entity.OrderProcessControl <> 12
                                                                               Select Entity
                                                                               Order By Entity.OrderNumber Descending

                    Case Database.Entities.MediaOrderType.Radio

                        DataGridViewLeftSection_CampaignsOrOrders.DataSource = From Entity In AdvantageFramework.Database.Procedures.RadioOrder.Load(DbContext)
                                                                               Where Entity.OrderProcessControl <> 6 AndAlso
                                                                                     Entity.OrderProcessControl <> 12
                                                                               Select Entity
                                                                               Order By Entity.OrderNumber Descending

                    Case Database.Entities.MediaOrderType.Television

                        DataGridViewLeftSection_CampaignsOrOrders.DataSource = From Entity In AdvantageFramework.Database.Procedures.TVOrder.Load(DbContext)
                                                                               Where Entity.OrderProcessControl <> 6 AndAlso
                                                                                     Entity.OrderProcessControl <> 12
                                                                               Select Entity
                                                                               Order By Entity.OrderNumber Descending

                End Select

            End Using

            DataGridViewLeftSection_CampaignsOrOrders.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                PartnerAllocationControlRightSection_PartnerAllocation.ClearControl()

                PartnerAllocationControlRightSection_PartnerAllocation.Enabled = DataGridViewLeftSection_CampaignsOrOrders.HasOnlyOneSelectedRow

                If PartnerAllocationControlRightSection_PartnerAllocation.Enabled Then

                    PartnerAllocationControlRightSection_PartnerAllocation.Enabled = PartnerAllocationControlRightSection_PartnerAllocation.LoadControl(DataGridViewLeftSection_CampaignsOrOrders.GetFirstSelectedRowBookmarkValue, _LastSearchPartnerAllocationType, _LastSearchMediaOrderType)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            PartnerAllocationControlRightSection_PartnerAllocation.Enabled = (DataGridViewLeftSection_CampaignsOrOrders.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Delete.Enabled = PartnerAllocationControlRightSection_PartnerAllocation.PartnerAllocationDetailCount > 0
            ButtonItemPartners_Cancel.Enabled = PartnerAllocationControlRightSection_PartnerAllocation.IsNewItemRowPartnerAllocationDetail
            ButtonItemPartners_Delete.Enabled = PartnerAllocationControlRightSection_PartnerAllocation.HasASelectedPartnerAllocationDetail

            RibbonBarOptions_Partners.Visible = PartnerAllocationControlRightSection_PartnerAllocation.IsAllocateTabSelected

        End Sub
        Private Sub Search()

            If ComboBoxSearch_AllocateBy.HasASelectedValue Then

                If ComboBoxSearch_AllocateBy.Tag = AdvantageFramework.Database.Entities.PartnerAllocationType.Campaign Then

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Try

                        DataGridViewLeftSection_CampaignsOrOrders.CurrentView.AFActiveFilterString = "[IsClosed] = False"

                    Catch ex As Exception

                    End Try

                Else

                    Try

                        LoadGrid(ComboBoxSearch_OrderType.Tag)

                    Catch ex As Exception

                    End Try

                    Try

                        DataGridViewLeftSection_CampaignsOrOrders.CurrentView.AFActiveFilterString = ""

                    Catch ex As Exception

                    End Try

                End If

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = PartnerAllocationControlRightSection_PartnerAllocation.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_CampaignsOrOrders.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If PartnerAllocationControlRightSection_PartnerAllocation.Save() Then

                            Me.ClearChanged()

                            Search()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_CampaignsOrOrders.FocusToFindPanel(False)

                        DataGridViewLeftSection_CampaignsOrOrders.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a partner allocation to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim PartnerAllocationSetupForm As AdvantageFramework.Maintenance.Media.Presentation.PartnerAllocationSetupForm = Nothing

            PartnerAllocationSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.PartnerAllocationSetupForm()

            PartnerAllocationSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub PartnerAllocationSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage

            ButtonItemPartners_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemPartners_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage

            DataGridViewLeftSection_CampaignsOrOrders.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ComboBoxSearch_AllocateBy.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.PartnerAllocationType)).ToList
            ComboBoxSearch_OrderType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaOrderType)).ToList

            Try

                Search()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub PartnerAllocationSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PartnerAllocationSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PartnerAllocationSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_CampaignsOrOrders.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_CampaignsOrOrders_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_CampaignsOrOrders.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_CampaignsOrOrders_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_CampaignsOrOrders.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemPartners_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemPartners_Delete.Click

            If PartnerAllocationControlRightSection_PartnerAllocation.HasASelectedPartnerAllocationDetail Then

                If PartnerAllocationControlRightSection_PartnerAllocation.PartnerAllocationDetailCount = 1 Then

                    ButtonItemActions_Delete.RaiseClick()

                Else

                    PartnerAllocationControlRightSection_PartnerAllocation.DeleteSelectedDetail()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemPartners_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemPartners_Cancel.Click

            PartnerAllocationControlRightSection_PartnerAllocation.CancelAddDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxSearch_AllocateBy_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxSearch_AllocateBy.SelectedValueChanged

            'objects
            Dim SelectedValue As String = Nothing

            If ComboBoxSearch_AllocateBy.HasASelectedValue Then

                SelectedValue = ComboBoxSearch_AllocateBy.GetSelectedValue

                If SelectedValue = "C" Then

                    ComboBoxSearch_AllocateBy.Tag = AdvantageFramework.Database.Entities.PartnerAllocationType.Campaign
                    ComboBoxSearch_OrderType.Enabled = False

                ElseIf SelectedValue = "O" Then

                    ComboBoxSearch_AllocateBy.Tag = AdvantageFramework.Database.Entities.PartnerAllocationType.Order
                    ComboBoxSearch_OrderType.Enabled = True

                Else

                    ComboBoxSearch_AllocateBy.Tag = Nothing
                    ComboBoxSearch_OrderType.Enabled = False

                End If

            Else

                ComboBoxSearch_AllocateBy.Tag = Nothing
                ComboBoxSearch_OrderType.Enabled = False

            End If

        End Sub
        Private Sub ComboBoxSearch_OrderType_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxSearch_OrderType.SelectedValueChanged

            'objects
            Dim SelectedValue As String = Nothing

            If ComboBoxSearch_OrderType.HasASelectedValue Then

                SelectedValue = ComboBoxSearch_OrderType.GetSelectedValue

                If SelectedValue = "I" Then

                    ComboBoxSearch_OrderType.Tag = AdvantageFramework.Database.Entities.MediaOrderType.Internet

                ElseIf SelectedValue = "M" Then

                    ComboBoxSearch_OrderType.Tag = AdvantageFramework.Database.Entities.MediaOrderType.Magazine

                ElseIf SelectedValue = "N" Then

                    ComboBoxSearch_OrderType.Tag = AdvantageFramework.Database.Entities.MediaOrderType.Newspaper

                ElseIf SelectedValue = "O" Then

                    ComboBoxSearch_OrderType.Tag = AdvantageFramework.Database.Entities.MediaOrderType.OutOfHome

                ElseIf SelectedValue = "R" Then

                    ComboBoxSearch_OrderType.Tag = AdvantageFramework.Database.Entities.MediaOrderType.Radio

                ElseIf SelectedValue = "T" Then

                    ComboBoxSearch_OrderType.Tag = AdvantageFramework.Database.Entities.MediaOrderType.Television

                Else

                    ComboBoxSearch_OrderType.Tag = Nothing

                End If

            Else

                ComboBoxSearch_OrderType.Tag = Nothing

            End If

        End Sub
        Private Sub ButtonItemSearch_Search_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSearch_Search.Click

            If CheckForUnsavedChanges() = True Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                _LastSearchPartnerAllocationType = ComboBoxSearch_AllocateBy.Tag
                _LastSearchMediaOrderType = ComboBoxSearch_OrderType.Tag

                DataGridViewLeftSection_CampaignsOrOrders.ClearGridCustomization()

                Search()

                PartnerAllocationControlRightSection_PartnerAllocation.ClearControl()

                DataGridViewLeftSection_CampaignsOrOrders.FocusToFindPanel(True)

                Me.FormAction = WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

                Me.ClearChanged()

                PartnerAllocationControlRightSection_PartnerAllocation.Enabled = False

            End If

        End Sub
        Private Sub PartnerAllocationControlRightSection_PartnerAllocation_PartnerAllocationDetailSelectionChangedEvent() Handles PartnerAllocationControlRightSection_PartnerAllocation.PartnerAllocationDetailSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub PartnerAllocationControlRightSection_PartnerAllocation_SelectedTabChanged() Handles PartnerAllocationControlRightSection_PartnerAllocation.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_CampaignsOrOrders.HasASelectedRow AndAlso PartnerAllocationControlRightSection_PartnerAllocation.PartnerAllocationDetailCount > 0 Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If PartnerAllocationControlRightSection_PartnerAllocation.Delete() Then

                            Search()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_CampaignsOrOrders.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a partner allocation to delete.")

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace