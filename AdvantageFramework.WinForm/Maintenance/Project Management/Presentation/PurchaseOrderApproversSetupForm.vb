Namespace Maintenance.ProjectManagement.Presentation

    Public Class PurchaseOrderApprovalRuleEmployeesSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _POApprovalRuleCode As String = Nothing
        Private _POApprovalRuleDetailSequenceNumber As Short = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal PurchaseOrderApprovalRuleCode As String, ByVal PurchaseOrderApprovalRuleDetailSequenceNumber As Short)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _POApprovalRuleCode = PurchaseOrderApprovalRuleCode
            _POApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetailSequenceNumber

        End Sub
        Private Sub LoadPOApprovalRuleEmployees()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_POApprovalRuleEmployees.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.LoadByPurchaseOrderApprovalRuleCodeSeqNum(DbContext, _POApprovalRuleCode, _POApprovalRuleDetailSequenceNumber)
                                                                       Select Entity
                                                                       Order By Entity.Order).ToList

                DataGridViewForm_POApprovalRuleEmployees.CurrentView.BestFitColumns()

                DataGridViewForm_POApprovalRuleEmployees.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

                If DataGridViewForm_POApprovalRuleEmployees.CurrentView.RowCount = 10 Then

                    DataGridViewForm_POApprovalRuleEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                Else

                    DataGridViewForm_POApprovalRuleEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                End If

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_POApprovalRuleEmployees.CurrentView.IsNewItemRow(DataGridViewForm_POApprovalRuleEmployees.CurrentView.FocusedRowHandle) Then

                DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons(0).Enabled = False
                DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons(1).Enabled = True
                DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons(2).Enabled = False
                DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons(3).Enabled = False

            Else

                DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons(0).Enabled = True
                DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons(1).Enabled = False
                DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons(2).Enabled = True
                DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons(3).Enabled = True

            End If

        End Sub
        Private Sub CancelAddNewApprover()

            DataGridViewForm_POApprovalRuleEmployees.CancelNewItemRow()

            LoadPOApprovalRuleEmployees()

        End Sub
        Private Sub DeleteSelectedApprover()

            Dim PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee = Nothing

            If DataGridViewForm_POApprovalRuleEmployees.HasASelectedRow Then

                DataGridViewForm_POApprovalRuleEmployees.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    PurchaseOrderApprovalRuleEmployee = DataGridViewForm_POApprovalRuleEmployees.GetFirstSelectedRowDataBoundItem

                    If PurchaseOrderApprovalRuleEmployee IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            PurchaseOrderApprovalRuleEmployee.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Delete(DbContext, PurchaseOrderApprovalRuleEmployee) Then

                                DataGridViewForm_POApprovalRuleEmployees.CurrentView.DeleteSelectedRows()

                            End If

                        End Using

                    End If

                    Me.CloseWaitForm()

                    LoadPOApprovalRuleEmployees()

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowFormDialog(ByVal PurchaseOrderApprovalRuleCode As String, ByVal PurchaseOrderApprovalRuleDetailSequenceNumber As Short, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

            DialogResult = AdvantageFramework.Maintenance.ProjectManagement.Presentation.PurchaseOrderApprovalRuleEmployeesSetupForm.ShowFormDialog(PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleDetailSequenceNumber)

        End Sub
        Public Shared Function ShowFormDialog(ByVal PurchaseOrderApprovalRuleCode As String, ByVal PurchaseOrderApprovalRuleDetailSequenceNumber As Short) As Windows.Forms.DialogResult

            'objects
            Dim PurchaseOrderApprovalRuleEmployeesSetupForm As PurchaseOrderApprovalRuleEmployeesSetupForm = Nothing

            PurchaseOrderApprovalRuleEmployeesSetupForm = New PurchaseOrderApprovalRuleEmployeesSetupForm(PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleDetailSequenceNumber)

            ShowFormDialog = PurchaseOrderApprovalRuleEmployeesSetupForm.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderApprovalRuleEmployeesSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                PurchaseOrderApprovalRuleDetail = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.LoadByPurchaseOrderApprovalRuleCodeSeqNum(DbContext, _POApprovalRuleCode, _POApprovalRuleDetailSequenceNumber)

                LabelForm_MinMaxRange.Text = String.Format("Minimum Range: {0}  Maximum Range:  {1}", PurchaseOrderApprovalRuleDetail.ApprovalMinimum, PurchaseOrderApprovalRuleDetail.ApprovalMaximum)

            End Using

            LoadPOApprovalRuleEmployees()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_Ok.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_POApprovalRuleEmployees_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_POApprovalRuleEmployees.AddNewRowEvent

            'objects
            Dim PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee Then

                Me.ShowWaitForm("Processing...")

                PurchaseOrderApprovalRuleEmployee = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If PurchaseOrderApprovalRuleEmployee.IsEntityBeingAdded() Then

                        PurchaseOrderApprovalRuleEmployee.DbContext = DbContext

                        PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = _POApprovalRuleCode

                        PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = _POApprovalRuleDetailSequenceNumber

                        If PurchaseOrderApprovalRuleEmployee.IsInactive Is Nothing Then

                            PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                        End If

                        If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee) Then

                            LoadPOApprovalRuleEmployees()

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_POApprovalRuleEmployees_CellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_POApprovalRuleEmployees.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.EmployeeCode.ToString Then

                If e.Value IsNot Nothing AndAlso e.Value <> "" Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If (From PurchaseOrderApprovalEmployee In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.LoadByPurchaseOrderApprovalRuleCodeSeqNum(DbContext, _POApprovalRuleCode, _POApprovalRuleDetailSequenceNumber).ToList
                            Where PurchaseOrderApprovalEmployee.EmployeeCode = e.Value).Any Then

                            AdvantageFramework.WinForm.MessageBox.Show("Cannot have duplicate approvers.")

                            DataGridViewForm_POApprovalRuleEmployees.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.EmployeeCode.ToString, "")

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_POApprovalRuleEmployees_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_POApprovalRuleEmployees.CellValueChangingEvent

            'objects
            Dim PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee = Nothing

            If DataGridViewForm_POApprovalRuleEmployees.CurrentView.IsNewItemRow(DataGridViewForm_POApprovalRuleEmployees.CurrentView.FocusedRowHandle) = False Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.IsInactive.ToString Then

                    Try

                        PurchaseOrderApprovalRuleEmployee = DataGridViewForm_POApprovalRuleEmployees.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        PurchaseOrderApprovalRuleEmployee = Nothing
                    End Try

                    If PurchaseOrderApprovalRuleEmployee IsNot Nothing Then

                        Try

                            PurchaseOrderApprovalRuleEmployee.IsInactive = CShort(e.Value)

                        Catch ex As Exception
                            PurchaseOrderApprovalRuleEmployee.IsInactive = PurchaseOrderApprovalRuleEmployee.IsInactive
                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Try

                            Me.ShowWaitForm("Processing...")

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                PurchaseOrderApprovalRuleEmployee.DbContext = DbContext

                                Saved = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Update(DbContext, PurchaseOrderApprovalRuleEmployee)

                            End Using

                            If Saved Then

                                DataGridViewForm_POApprovalRuleEmployees.CurrentView.RefreshData()

                            End If

                        Catch ex As Exception

                        Finally
                            Me.CloseWaitForm()
                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    End If

                End If

            End If

        End Sub
        Private Sub MoveUp()

            Dim PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee = Nothing
            Dim PreviousPurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee = Nothing

            If DataGridViewForm_POApprovalRuleEmployees.HasOnlyOneSelectedRow AndAlso DataGridViewForm_POApprovalRuleEmployees.CurrentView.IsNewItemRow(DataGridViewForm_POApprovalRuleEmployees.CurrentView.FocusedRowHandle) = False Then

                Try

                    PurchaseOrderApprovalRuleEmployee = DataGridViewForm_POApprovalRuleEmployees.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    PurchaseOrderApprovalRuleEmployee = Nothing
                End Try

                If PurchaseOrderApprovalRuleEmployee IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            PreviousPurchaseOrderApprovalRuleEmployee = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Load(DbContext).ToList
                                                                         Where Entity.Order < PurchaseOrderApprovalRuleEmployee.Order AndAlso
                                                        Entity.PurchaseOrderApprovalRuleCode = _POApprovalRuleCode AndAlso
                                                        Entity.PurchaseOrderApprovalRuleDetailSequenceNumber = _POApprovalRuleDetailSequenceNumber
                                                                         Select Entity
                                                                         Order By Entity.Order Descending).FirstOrDefault

                        Catch ex As Exception
                            PreviousPurchaseOrderApprovalRuleEmployee = Nothing
                        End Try

                        If PreviousPurchaseOrderApprovalRuleEmployee IsNot Nothing Then

                            PurchaseOrderApprovalRuleEmployee.Order = PreviousPurchaseOrderApprovalRuleEmployee.Order
                            PreviousPurchaseOrderApprovalRuleEmployee.Order = PurchaseOrderApprovalRuleEmployee.Order + 10

                            If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Update(DbContext, PurchaseOrderApprovalRuleEmployee) Then

                                If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Update(DbContext, PreviousPurchaseOrderApprovalRuleEmployee) Then

                                    LoadPOApprovalRuleEmployees()

                                End If

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub MoveDown()

            Dim PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee = Nothing
            Dim NextPurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee = Nothing

            If DataGridViewForm_POApprovalRuleEmployees.HasOnlyOneSelectedRow AndAlso DataGridViewForm_POApprovalRuleEmployees.CurrentView.IsNewItemRow(DataGridViewForm_POApprovalRuleEmployees.CurrentView.FocusedRowHandle) = False Then

                Try

                    PurchaseOrderApprovalRuleEmployee = DataGridViewForm_POApprovalRuleEmployees.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    PurchaseOrderApprovalRuleEmployee = Nothing
                End Try

                If PurchaseOrderApprovalRuleEmployee IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            NextPurchaseOrderApprovalRuleEmployee = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Load(DbContext).ToList
                                                                     Where Entity.Order > PurchaseOrderApprovalRuleEmployee.Order AndAlso
                                                    Entity.PurchaseOrderApprovalRuleCode = _POApprovalRuleCode AndAlso
                                                    Entity.PurchaseOrderApprovalRuleDetailSequenceNumber = _POApprovalRuleDetailSequenceNumber
                                                                     Select Entity
                                                                     Order By Entity.Order Ascending).FirstOrDefault

                        Catch ex As Exception
                            NextPurchaseOrderApprovalRuleEmployee = Nothing
                        End Try

                        If NextPurchaseOrderApprovalRuleEmployee IsNot Nothing Then

                            PurchaseOrderApprovalRuleEmployee.Order = NextPurchaseOrderApprovalRuleEmployee.Order
                            NextPurchaseOrderApprovalRuleEmployee.Order = PurchaseOrderApprovalRuleEmployee.Order - 10

                            If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Update(DbContext, PurchaseOrderApprovalRuleEmployee) Then

                                If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Update(DbContext, NextPurchaseOrderApprovalRuleEmployee) Then

                                    LoadPOApprovalRuleEmployees()

                                End If

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_POApprovalRuleEmployees_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        CancelAddNewApprover()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DeleteSelectedApprover()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Custom

                        If e.Button.Hint.ToUpper = "MOVE UP" Then

                            MoveUp()

                        ElseIf e.Button.Hint.ToUpper = "MOVE DOWN" Then

                            MoveDown()

                        End If

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewForm_POApprovalRuleEmployees_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_POApprovalRuleEmployees.InitNewRowEvent

            'objects
            Dim POApprovalRuleEmployeeOrderNumber As Short = Nothing

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    POApprovalRuleEmployeeOrderNumber = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.GetNextAvailableOrder(DbContext, _POApprovalRuleCode, _POApprovalRuleDetailSequenceNumber)

                End Using

            Catch ex As Exception
                POApprovalRuleEmployeeOrderNumber = Nothing
            End Try

            DataGridViewForm_POApprovalRuleEmployees.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.Order.ToString, POApprovalRuleEmployeeOrderNumber)
            DataGridViewForm_POApprovalRuleEmployees.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.PurchaseOrderApprovalRuleCode.ToString, _POApprovalRuleCode)

        End Sub
        Private Sub DataGridViewForm_POApprovalRuleEmployees_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_POApprovalRuleEmployees.Load

            Dim ImageCollection As DevExpress.Utils.ImageCollection = Nothing
            Dim Button As DevExpress.XtraEditors.NavigatorCustomButton = Nothing

            DataGridViewForm_POApprovalRuleEmployees.MultiSelect = False
            'DataGridViewForm_POApprovalRuleEmployees.OptionsCustomization.AllowSort = False
            DataGridViewForm_POApprovalRuleEmployees.UseEmbeddedNavigator = True

            ImageCollection = DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.DefaultImageList
            ImageCollection.AddImage(AdvantageFramework.My.Resources.UpImage)
            ImageCollection.AddImage(AdvantageFramework.My.Resources.DownImage)

            Button = DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons.Add()
            Button.Tag = DevExpress.XtraEditors.NavigatorButtonType.Custom
            Button.Enabled = DataGridViewForm_POApprovalRuleEmployees.HasASelectedRow
            Button.Visible = True
            Button.Hint = "Move Up"
            Button.ImageIndex = ImageCollection.Images.Count - 2

            Button = DataGridViewForm_POApprovalRuleEmployees.EmbeddedNavigator.Buttons.CustomButtons.Add()
            Button.Tag = DevExpress.XtraEditors.NavigatorButtonType.Custom
            Button.Enabled = DataGridViewForm_POApprovalRuleEmployees.HasASelectedRow
            Button.Visible = True
            Button.Hint = "Move Down"
            Button.ImageIndex = ImageCollection.Images.Count - 1

        End Sub
        Private Sub DataGridViewForm_POApprovalRuleEmployees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_POApprovalRuleEmployees.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace