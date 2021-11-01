Namespace GeneralLedger.Maintenance.Presentation

    Public Class AccountAllocationSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _GLAllocationID As Integer = Nothing
        Private _GLATrailersToBeDeleted As Generic.List(Of AdvantageFramework.Database.Classes.GLATrailer) = Nothing

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

            'objects
            Dim GLAllocations As Generic.List(Of AdvantageFramework.Database.Entities.GLAllocation) = Nothing
            Dim GLAccounts As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            Dim GLAllocationList As Generic.List(Of AdvantageFramework.Database.Classes.GLAllocation) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GLAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).ToList
                GLAllocations = AdvantageFramework.Database.Procedures.GLAllocation.Load(DbContext).ToList

                Try

                    GLAllocationList = (From Entity In GLAccounts
                                        Select New AdvantageFramework.Database.Classes.GLAllocation With {.GLAccountCode = Entity.Code,
                                                                                                          .GLAccountDescription = Entity.Description,
                                                                                                          .Status = (From GLAllocation In GLAllocations
                                                                                                                     Where GLAllocation.GLAccountCode = Entity.Code
                                                                                                                     Select GLAllocation.Status).SingleOrDefault(),
                                                                                                          .Comment = (From GLAllocation In GLAllocations
                                                                                                                      Where GLAllocation.GLAccountCode = Entity.Code
                                                                                                                      Select GLAllocation.Comment).SingleOrDefault()}).ToList

                Catch ex As Exception
                    GLAllocationList = New Generic.List(Of AdvantageFramework.Database.Classes.GLAllocation)
                End Try

                DataGridViewLeftSection_GLAccounts.DataSource = GLAllocationList

            End Using

            DataGridViewLeftSection_GLAccounts.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                ClearControl()

                PanelForm_RightSection.Enabled = DataGridViewLeftSection_GLAccounts.HasOnlyOneSelectedRow

                If PanelForm_RightSection.Enabled Then

                    PanelForm_RightSection.Enabled = LoadItem(DataGridViewLeftSection_GLAccounts.GetFirstSelectedRowBookmarkValue)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            PanelForm_RightSection.Enabled = (DataGridViewLeftSection_GLAccounts.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ComboBoxRightSection_Account.Enabled = False

            If PanelForm_RightSection.Enabled Then

                TextBoxRightSection_AllocationDescription.Enabled = Not CheckBoxRightSection_Inactive.Checked
                RadioButtonControlRightSection_NumberOfEmployees.Enabled = Not CheckBoxRightSection_Inactive.Checked
                RadioButtonControlRightSection_Percentage.Enabled = Not CheckBoxRightSection_Inactive.Checked
                RadioButtonControlRightSection_SquareFootage.Enabled = Not CheckBoxRightSection_Inactive.Checked
                DataGridViewRightSection_Allocations.Enabled = Not CheckBoxRightSection_Inactive.Checked

                ButtonItemDetails_Delete.Enabled = DataGridViewRightSection_Allocations.HasOnlyOneSelectedRow AndAlso Not CheckBoxRightSection_Inactive.Checked
                ButtonItemDetails_Cancel.Enabled = DataGridViewRightSection_Allocations.IsNewItemOrAutoFilterRow(DataGridViewRightSection_Allocations.CurrentView.FocusedRowHandle)

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

                            IsOkay = Save()

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
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing
            Dim GLAllocation As AdvantageFramework.Database.Entities.GLAllocation = Nothing
            Dim GLATrailers As Generic.List(Of AdvantageFramework.Database.Classes.GLATrailer) = Nothing
            Dim GLATrailer As AdvantageFramework.Database.Entities.GLATrailer = Nothing
            Dim IsValid As Boolean = True

            If DataGridViewLeftSection_GLAccounts.HasOnlyOneSelectedRow Then

                DataGridViewRightSection_Allocations.CurrentView.CloseEditorForUpdating()

                ErrorMessage = ValidateAllocationType(IsValid)

                If Me.Validator AndAlso IsValid AndAlso DataGridViewRightSection_Allocations.HasAnyInvalidRows = False Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            GLAllocation = AdvantageFramework.Database.Procedures.GLAllocation.LoadByGLAccountCode(DbContext, DataGridViewLeftSection_GLAccounts.GetFirstSelectedRowBookmarkValue)

                            If GLAllocation IsNot Nothing Then

                                FillEntityObject(GLAllocation)

                                GLAllocation.DateModified = System.DateTime.Today

                                Saved = AdvantageFramework.Database.Procedures.GLAllocation.Update(DbContext, GLAllocation)

                            Else

                                GLAllocation = New AdvantageFramework.Database.Entities.GLAllocation

                                FillEntityObject(GLAllocation)

                                GLAllocation.DbContext = DbContext

                                GLAllocation.UserCode = Me.Session.UserCode
                                GLAllocation.DateEntered = System.DateTime.Today

                                Saved = AdvantageFramework.Database.Procedures.GLAllocation.Insert(DbContext, GLAllocation)

                            End If

                            If Saved Then

                                If RadioButtonControlRightSection_SquareFootage.Checked OrElse RadioButtonControlRightSection_NumberOfEmployees.Checked Then

                                    CalculatePercentage()

                                End If

                                For Each GLATrailerClass In _GLATrailersToBeDeleted

                                    GLATrailer = AdvantageFramework.Database.Procedures.GLATrailer.LoadByGLAllocationIDAndGLACode(DbContext, GLATrailerClass.GLAllocationID, GLATrailerClass.GLAltCode)

                                    If GLATrailer IsNot Nothing Then

                                        AdvantageFramework.Database.Procedures.GLATrailer.Delete(DbContext, GLATrailer)

                                    End If

                                Next

                                For Each GLATrailerClass In DataGridViewRightSection_Allocations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.GLATrailer).ToList

                                    GLATrailer = AdvantageFramework.Database.Procedures.GLATrailer.LoadByGLAllocationIDAndGLACode(DbContext, GLATrailerClass.GLAllocationID, GLATrailerClass.GLAltCode)

                                    If GLATrailer IsNot Nothing Then

                                        GLATrailerClass.LoadEntity(GLATrailer)

                                        AdvantageFramework.Database.Procedures.GLATrailer.Update(DbContext, GLATrailer)

                                    Else

                                        GLATrailer = New AdvantageFramework.Database.Entities.GLATrailer

                                        GLATrailerClass.LoadEntity(GLATrailer)

                                        GLATrailer.DbContext = DbContext

                                        GLATrailer.GLAllocationID = GLAllocation.ID

                                        AdvantageFramework.Database.Procedures.GLATrailer.Insert(DbContext, GLATrailer)

                                    End If

                                Next

                            End If

                        End Using

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_GLAccounts.CurrentView.SetRowCellValue(DataGridViewLeftSection_GLAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.GLAllocation.Properties.Comment.ToString, TextBoxRightSection_AllocationDescription.Text)

                        DataGridViewLeftSection_GLAccounts.FocusToFindPanel(False)

                        DataGridViewLeftSection_GLAccounts.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    If ErrorMessage <> "" Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a GL Allocation to save.")

            End If

            Save = Saved

        End Function
        Private Sub SetupAllocationType()

            'objects
            Dim PercentColumnVisible As Boolean = False
            Dim SquareFootOrEmployeeVisible As Boolean = False
            Dim LabelText As String = ""
            Dim ColumnText As String = ""

            Try

                If RadioButtonControlRightSection_Percentage.Checked Then

                    PercentColumnVisible = True
                    SquareFootOrEmployeeVisible = False
                    LabelText = ""
                    ColumnText = ""

                ElseIf RadioButtonControlRightSection_SquareFootage.Checked Then

                    PercentColumnVisible = False
                    SquareFootOrEmployeeVisible = True
                    LabelText = "Total Square Feet"
                    ColumnText = "Square Feet"

                ElseIf RadioButtonControlRightSection_NumberOfEmployees.Checked Then

                    PercentColumnVisible = False
                    SquareFootOrEmployeeVisible = True
                    LabelText = "Total Employees"
                    ColumnText = "Employees"

                End If

                LabelRightSection_Total.Text = LabelText & ":"
                LabelRightSection_Total.Visible = SquareFootOrEmployeeVisible
                NumericInputRightSection_Total.Visible = SquareFootOrEmployeeVisible
                NumericInputRightSection_Total.SetPropertySettings(LabelText, SquareFootOrEmployeeVisible)

                If NumericInputRightSection_Total.Visible = False Then

                    Me.ValidateControl(NumericInputRightSection_Total)

                End If

                For Each GridColumn In DataGridViewRightSection_Allocations.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridColumn.Visible = False

                Next

                If DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltCode.ToString) IsNot Nothing Then

                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltCode.ToString).Visible = True
                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltCode.ToString).VisibleIndex = 1

                End If

                If DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLADescription.ToString) IsNot Nothing Then

                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLADescription.ToString).Visible = True
                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLADescription.ToString).VisibleIndex = 2

                End If

                If DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.CDPRequired.ToString) IsNot Nothing Then

                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.CDPRequired.ToString).Visible = True
                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.CDPRequired.ToString).VisibleIndex = 3

                End If

                If PercentColumnVisible Then

                    If DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltValue.ToString) IsNot Nothing Then

                        DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltValue.ToString).Visible = True
                        DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltValue.ToString).VisibleIndex = 4

                    End If

                ElseIf SquareFootOrEmployeeVisible Then

                    If DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString) IsNot Nothing Then

                        DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString).Visible = True
                        DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString).VisibleIndex = 4
                        DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString).Caption = ColumnText

                    End If

                End If

                If DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.ClientCode.ToString) IsNot Nothing Then

                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.ClientCode.ToString).Visible = True
                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.ClientCode.ToString).VisibleIndex = 5

                End If

                If DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.DivisionCode.ToString) IsNot Nothing Then

                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.DivisionCode.ToString).Visible = True
                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.DivisionCode.ToString).VisibleIndex = 6

                End If

                If DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.ProductCode.ToString) IsNot Nothing Then

                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.ProductCode.ToString).Visible = True
                    DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.ProductCode.ToString).VisibleIndex = 7

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Function ValidateAllocationType(ByRef IsValid As Boolean) As String

            'objects
            Dim GLATrailers As Generic.List(Of AdvantageFramework.Database.Classes.GLATrailer) = Nothing
            Dim ErrorText As String = ""
            Dim Total As Double = Nothing


            Try

                GLATrailers = DataGridViewRightSection_Allocations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.GLATrailer).ToList

                If RadioButtonControlRightSection_Percentage.Checked Then

                    Total = Math.Round((From Entity In GLATrailers
                                        Select Entity.GLAltValue).Sum.Value, 5)

                    If Total <> 100 Then

                        IsValid = False
                        ErrorText = "The percentage must equal 100."

                    End If

                Else

                    If (From Entity In GLATrailers
                        Select Entity.GLAltAllocation).Sum <> CDbl(NumericInputRightSection_Total.Value) Then

                        IsValid = False

                        If RadioButtonControlRightSection_SquareFootage.Checked Then

                            ErrorText = "The total square feet allocated does not match the total amount entered!"

                        ElseIf RadioButtonControlRightSection_NumberOfEmployees.Checked Then

                            ErrorText = "The total employees allocated does not match the total employees entered!"

                        End If

                    End If

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                ValidateAllocationType = ErrorText
            End Try

        End Function
        Private Sub FillEntityObject(ByVal GLAllocation As AdvantageFramework.Database.Entities.GLAllocation)

            If GLAllocation IsNot Nothing Then

                GLAllocation.GLAccountCode = ComboBoxRightSection_Account.GetSelectedValue
                GLAllocation.Comment = TextBoxRightSection_AllocationDescription.Text

                If RadioButtonControlRightSection_Percentage.Checked Then

                    GLAllocation.Type = AdvantageFramework.Database.Entities.AccountAllocationTypes.Percentage

                ElseIf RadioButtonControlRightSection_SquareFootage.Checked Then

                    GLAllocation.Type = AdvantageFramework.Database.Entities.AccountAllocationTypes.SquareFootage

                ElseIf RadioButtonControlRightSection_NumberOfEmployees.Checked Then

                    GLAllocation.Type = AdvantageFramework.Database.Entities.AccountAllocationTypes.NumberOfEmployees

                Else

                    GLAllocation.Type = Nothing

                End If

                If CheckBoxRightSection_Inactive.Checked Then

                    GLAllocation.Status = "1"

                Else

                    GLAllocation.Status = "0"

                End If

            End If

        End Sub

#Region "  Control Methods "

        Private Function LoadItem(ByVal AccountCode As String)

            'objects
            Dim Loaded As Boolean = False
            Dim GLAllocation As AdvantageFramework.Database.Entities.GLAllocation = Nothing

            _GLAllocationID = Nothing
            _GLATrailersToBeDeleted.Clear()

            If String.IsNullOrEmpty(AccountCode) = False Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxRightSection_Account.SelectedValue = AccountCode

                        GLAllocation = AdvantageFramework.Database.Procedures.GLAllocation.LoadByGLAccountCode(DbContext, AccountCode)

                        If GLAllocation IsNot Nothing Then

                            _GLAllocationID = GLAllocation.ID

                            TextBoxRightSection_AllocationDescription.Text = GLAllocation.Comment

                            DataGridViewRightSection_Allocations.DataSource = (From GLATrailer In AdvantageFramework.Database.Procedures.GLATrailer.LoadByGLAllocationID(DbContext, GLAllocation.ID)
                                                                               Join GLAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext) On GLAccount.Code Equals GLATrailer.GLAltCode
                                                                               Select New AdvantageFramework.Database.Classes.GLATrailer() With {.ID = GLATrailer.ID,
                                                                                                                                                 .GLAllocationID = GLATrailer.GLAllocationID,
                                                                                                                                                 .GLAltCode = GLATrailer.GLAltCode,
                                                                                                                                                 .GLADescription = GLAccount.Description,
                                                                                                                                                 .CDPRequired = GLAccount.CDPRequired,
                                                                                                                                                 .GLAltValue = GLATrailer.GLAltValue,
                                                                                                                                                 .GLAltAllocation = GLATrailer.GLAltAllocation,
                                                                                                                                                 .GLAltAmount = GLATrailer.GLAltAmount,
                                                                                                                                                 .ClientCode = GLATrailer.ClientCode,
                                                                                                                                                 .DivisionCode = GLATrailer.DivisionCode,
                                                                                                                                                 .ProductCode = GLATrailer.ProductCode}).ToList

                            If GLAllocation.Type.GetValueOrDefault(1) = 1 Then

                                RadioButtonControlRightSection_Percentage.Checked = True

                            Else

                                Try

                                    NumericInputRightSection_Total.EditValue = (From Entity In DataGridViewRightSection_Allocations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.GLATrailer).ToList
                                                                                Select Entity.GLAltAllocation).Sum

                                Catch ex As Exception
                                    NumericInputRightSection_Total.EditValue = 0
                                End Try

                                If GLAllocation.Type = AdvantageFramework.Database.Entities.AccountAllocationTypes.Percentage Then

                                    RadioButtonControlRightSection_Percentage.Checked = True

                                ElseIf GLAllocation.Type = AdvantageFramework.Database.Entities.AccountAllocationTypes.SquareFootage Then

                                    RadioButtonControlRightSection_SquareFootage.Checked = True

                                ElseIf GLAllocation.Type = AdvantageFramework.Database.Entities.AccountAllocationTypes.NumberOfEmployees Then

                                    RadioButtonControlRightSection_NumberOfEmployees.Checked = True

                                End If

                            End If

                            If CInt(GLAllocation.Status) = 1 Then

                                CheckBoxRightSection_Inactive.Checked = True

                            Else

                                CheckBoxRightSection_Inactive.Checked = False

                            End If

                        Else

                            DataGridViewRightSection_Allocations.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.GLATrailer)

                        End If

                        DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltValue.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltValue.ToString).SummaryItem.DisplayFormat = "Total Allocation: {0:n0}"

                        DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        DataGridViewRightSection_Allocations.Columns(AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString).SummaryItem.DisplayFormat = "Total Allocation: {0:n0}"

                        DataGridViewRightSection_Allocations.CurrentView.BestFitColumns()

                    End Using

                    Loaded = True

                Catch ex As Exception
                    Loaded = False
                End Try

            End If

            LoadItem = Loaded

        End Function
        Private Sub ClearControl()

            TextBoxRightSection_AllocationDescription.Text = Nothing
            RadioButtonControlRightSection_Percentage.Checked = True
            LabelRightSection_Total.Visible = False
            NumericInputRightSection_Total.Visible = False
            NumericInputRightSection_Total.EditValue = Nothing
            CheckBoxRightSection_Inactive.Checked = False
            DataGridViewRightSection_Allocations.ClearDatasource()

        End Sub
        Private Sub CalculatePercentage()

            'objects
            Dim GLATrailer As AdvantageFramework.Database.Classes.GLATrailer = Nothing
            Dim Total As Double = Nothing

            Try

                Total = CDbl(NumericInputRightSection_Total.Value)

            Catch ex As Exception

            End Try

            If Total > 0 Then

                For RowHandle = 0 To DataGridViewRightSection_Allocations.CurrentView.RowCount - 1

                    Try

                        GLATrailer = DirectCast(DataGridViewRightSection_Allocations.CurrentView.GetRow(RowHandle), AdvantageFramework.Database.Classes.GLATrailer)

                        GLATrailer.GLAltValue = (GLATrailer.GLAltAllocation / Total) * 100

                    Catch ex As Exception
                        GLATrailer.GLAltValue = GLATrailer.GLAltValue
                    End Try

                Next

            End If

        End Sub

#End Region

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AccountAllocationSetupForm As AdvantageFramework.GeneralLedger.Maintenance.Presentation.AccountAllocationSetupForm = Nothing

            AccountAllocationSetupForm = New AdvantageFramework.GeneralLedger.Maintenance.Presentation.AccountAllocationSetupForm()

            AccountAllocationSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountAllocationSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _GLATrailersToBeDeleted = New Generic.List(Of AdvantageFramework.Database.Classes.GLATrailer)

            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ComboBoxRightSection_Account.ByPassUserEntryChanged = True
            DataGridViewLeftSection_GLAccounts.MultiSelect = False
            NumericInputRightSection_Total.Properties.Buttons.Clear()

            DataGridViewRightSection_Allocations.AutoFilterLookupColumns = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxRightSection_Account.SetPropertySettings(AdvantageFramework.Database.Entities.GLAllocation.Properties.GLAccountCode)
                TextBoxRightSection_AllocationDescription.SetPropertySettings(AdvantageFramework.Database.Entities.GLAllocation.Properties.Comment)

                ComboBoxRightSection_Account.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub AccountAllocationSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AccountAllocationSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AccountAllocationSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_GLAccounts.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_GLAccounts_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_GLAccounts.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_GLAccounts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_GLAccounts.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                SetupAllocationType()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub CheckBoxRightSection_Inactive_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxRightSection_Inactive.CheckedChangedEx

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                    Save()

                End If

            End If

        End Sub
        Private Sub RadioButtonControlRightSection_NumberOfEmployees_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlRightSection_NumberOfEmployees.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                SetupAllocationType()

            End If

        End Sub
        Private Sub RadioButtonControlRightSection_Percentage_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlRightSection_Percentage.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                SetupAllocationType()

            End If

        End Sub
        Private Sub RadioButtonControlRightSection_SquareFootage_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlRightSection_SquareFootage.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                SetupAllocationType()

            End If

        End Sub
        Private Sub DataGridViewRightSection_Allocations_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_Allocations.CellValueChangedEvent

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso (e.Column.FieldName = AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAmount.ToString Or e.Column.FieldName = AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString) Then

                If RadioButtonControlRightSection_SquareFootage.Checked OrElse RadioButtonControlRightSection_NumberOfEmployees.Checked Then

                    CalculatePercentage()

                End If

            ElseIf e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString Then

                If RadioButtonControlRightSection_SquareFootage.Checked OrElse RadioButtonControlRightSection_NumberOfEmployees.Checked Then

                    CalculatePercentage()

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_Allocations_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewRightSection_Allocations.AddNewRowEvent

            DataGridViewRightSection_Allocations.SetUserEntryChanged()

        End Sub
        Private Sub DataGridViewRightSection_Allocations_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRightSection_Allocations.InitNewRowEvent

            If _GLAllocationID <> Nothing Then

                DataGridViewRightSection_Allocations.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAllocationID.ToString, _GLAllocationID)

            End If

        End Sub
        Private Sub DataGridViewRightSection_Allocations_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_Allocations.NewItemRowCellValueChangedEvent

            'objects
            Dim CDPRequired As Short = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltCode.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        CDPRequired = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value.ToString).CDPRequired.GetValueOrDefault(0)

                    Catch ex As Exception
                        CDPRequired = 0
                    End Try

                    DataGridViewRightSection_Allocations.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.GLATrailer.Properties.CDPRequired.ToString, CDPRequired)

                End Using

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltAllocation.ToString Then

                If RadioButtonControlRightSection_SquareFootage.Checked OrElse RadioButtonControlRightSection_NumberOfEmployees.Checked Then

                    CalculatePercentage()

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Cancel.Click

            DataGridViewRightSection_Allocations.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            'objects
            Dim GLATrailer As AdvantageFramework.Database.Classes.GLATrailer = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewRightSection_Allocations.HasASelectedRow Then

                DataGridViewRightSection_Allocations.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewRightSection_Allocations.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    GLATrailer = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    GLATrailer = Nothing
                                End Try

                                If GLATrailer IsNot Nothing Then

                                    _GLATrailersToBeDeleted.Add(GLATrailer)

                                    DataGridViewRightSection_Allocations.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    DataGridViewRightSection_Allocations.SetUserEntryChanged()

                                    EnableOrDisableActions()

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_Allocations_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_Allocations.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim GLACode As String = Nothing

            Try

                If DataGridViewLeftSection_GLAccounts.HasASelectedRow Then

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    GLACode = DataGridViewLeftSection_GLAccounts.GetFirstSelectedRowBookmarkValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Database.Procedures.GLAllocation.Load(DbContext)
                                                             Where Entity.GLAccountCode = GLACode
                                                             Select Entity).ToList

                    End Using

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.GLAccountAllocation, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                End If

            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace