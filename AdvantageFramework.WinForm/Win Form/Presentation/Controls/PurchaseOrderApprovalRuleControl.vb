Namespace WinForm.Presentation.Controls

    Public Class PurchaseOrderApprovalRuleControl

        Public Event PurchaseOrderApprovalRuleDetailInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event PurchaseOrderApprovalRuleDetailSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event PurchaseOrderApprovalRuleInActiveChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _PurchaseOrderApprovalRuleCode As String = Nothing
        Private _PurchaseOrderApprovalRuleDetailList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) = Nothing
        Private _IsLoading As Boolean = False
        Private _IsClearing As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property PurchaseOrderApprovalRuleDetailHasRows() As Boolean
            Get
                PurchaseOrderApprovalRuleDetailHasRows = DataGridViewControl_PurchaseOrderApprovalRuleDetails.HasRows
            End Get
        End Property
        Public ReadOnly Property PurchaseOrderApprovalRuleDetailHasOnlyOneSelectedRow(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get
                PurchaseOrderApprovalRuleDetailHasOnlyOneSelectedRow = DataGridViewControl_PurchaseOrderApprovalRuleDetails.HasOnlyOneSelectedRow(ExcludeNonDataRows)
            End Get
        End Property
        Public ReadOnly Property PurchaseOrderApprovalRuleDetailIsNewItemRow(ByVal RowHandle As Integer) As Boolean
            Get
                PurchaseOrderApprovalRuleDetailIsNewItemRow = DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.IsNewItemRow(RowHandle)
            End Get
        End Property
        Public ReadOnly Property PurchaseOrderApprovalRuleDetailFocusedRowHandle() As Integer
            Get
                PurchaseOrderApprovalRuleDetailFocusedRowHandle = DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.FocusedRowHandle
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

                            TextBoxControl_Code.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule.Properties.Code)
                            TextBoxControl_Description.SetPropertySettings(AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule.Properties.Description)

                        End Using

                    End If

                    CheckBoxControl_Inactive.ByPassUserEntryChanged = True

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadSelectedRuleDetails()

            Dim PurchaseOrderApprovalRuleDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) = Nothing

            PurchaseOrderApprovalRuleDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail)

            If _PurchaseOrderApprovalRuleCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PurchaseOrderApprovalRuleDetailsList.AddRange(From PurchaseOrderApprovalDetail In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.LoadByPurchaseOrderApprovalRuleCode(DbContext, _PurchaseOrderApprovalRuleCode).ToList
                                                                  Order By PurchaseOrderApprovalDetail.ApprovalMinimum
                                                                  Select New AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail(DbContext, PurchaseOrderApprovalDetail))

                    DataGridViewControl_PurchaseOrderApprovalRuleDetails.DataSource = PurchaseOrderApprovalRuleDetailsList

                    DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.BestFitColumns()

                    DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

                End Using

            Else

                For Each PurchaseOrderApprovalRuleDetailList In _PurchaseOrderApprovalRuleDetailList

                    PurchaseOrderApprovalRuleDetailsList.Add(PurchaseOrderApprovalRuleDetailList)

                Next

                DataGridViewControl_PurchaseOrderApprovalRuleDetails.DataSource = PurchaseOrderApprovalRuleDetailsList

                DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Function DuplicateApproverExists(ByVal PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail, ByVal FieldName As String, ByVal Value As String) As Boolean

            If PurchaseOrderApprovalRuleDetail.EmployeeName IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName.ToString Then
                    Return True
                End If

            End If
            If PurchaseOrderApprovalRuleDetail.EmployeeName2 IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName2 AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName2.ToString Then
                    Return True
                End If

            End If
            If PurchaseOrderApprovalRuleDetail.EmployeeName3 IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName3 AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName3.ToString Then
                    Return True
                End If

            End If
            If PurchaseOrderApprovalRuleDetail.EmployeeName4 IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName4 AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName4.ToString Then
                    Return True
                End If

            End If
            If PurchaseOrderApprovalRuleDetail.EmployeeName5 IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName5 AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName5.ToString Then
                    Return True
                End If

            End If
            If PurchaseOrderApprovalRuleDetail.EmployeeName6 IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName6 AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName6.ToString Then
                    Return True
                End If

            End If
            If PurchaseOrderApprovalRuleDetail.EmployeeName7 IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName7 AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName7.ToString Then
                    Return True
                End If

            End If
            If PurchaseOrderApprovalRuleDetail.EmployeeName8 IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName8 AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName8.ToString Then
                    Return True
                End If

            End If
            If PurchaseOrderApprovalRuleDetail.EmployeeName9 IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName9 AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName9.ToString Then
                    Return True
                End If

            End If
            If PurchaseOrderApprovalRuleDetail.EmployeeName10 IsNot Nothing Then

                If Value = PurchaseOrderApprovalRuleDetail.EmployeeName10 AndAlso FieldName <> AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName10.ToString Then
                    Return True
                End If

            End If

            Return False

        End Function
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                DataGridViewControl_PurchaseOrderApprovalRuleDetails.UseEmbeddedNavigator = True

            Else

                DataGridViewControl_PurchaseOrderApprovalRuleDetails.UseEmbeddedNavigator = False

            End If

        End Sub

#Region " Public "

        Public Sub ClearControl()

            _IsClearing = True

            TextBoxControl_Code.Text = ""
            TextBoxControl_Description.Text = ""
            CheckBoxControl_Inactive.Checked = False

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsClearing = False

        End Sub
        Public Sub LoadPurchaseOrderApprovalRuleEntity(ByVal PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)

            If PurchaseOrderApprovalRule IsNot Nothing Then

                PurchaseOrderApprovalRule.Code = TextBoxControl_Code.Text
                PurchaseOrderApprovalRule.Description = TextBoxControl_Description.Text
                PurchaseOrderApprovalRule.IsInactive = Convert.ToInt16(CheckBoxControl_Inactive.Checked)

            End If

        End Sub
        Public Sub DeletePurchaseOrderApprovalRuleDetail()

            Dim PurchaseOrderApprovalRuleDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) = Nothing
            Dim PurchaseOrderApprovalRuleDetailEntity As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail = Nothing

            If DataGridViewControl_PurchaseOrderApprovalRuleDetails.HasASelectedRow Then

                DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    PurchaseOrderApprovalRuleDetails = DataGridViewControl_PurchaseOrderApprovalRuleDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail)().ToList

                    If _PurchaseOrderApprovalRuleCode <> "" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each PurchaseOrderApprovalRuleDetail In PurchaseOrderApprovalRuleDetails

                                PurchaseOrderApprovalRuleDetailEntity = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.LoadByPurchaseOrderApprovalRuleCodeSeqNum(DbContext, PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleDetail.SequenceNumber)

                                If PurchaseOrderApprovalRuleDetailEntity IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.Delete(DbContext, PurchaseOrderApprovalRuleDetailEntity)

                                End If

                            Next

                        End Using

                    Else

                        For Each PurchaseOrderApprovalRuleDetail In PurchaseOrderApprovalRuleDetails

                            _PurchaseOrderApprovalRuleDetailList.Remove(PurchaseOrderApprovalRuleDetail)

                        Next

                    End If

                    LoadSelectedRuleDetails()

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Public Sub CancelNewItemRowPurchaseOrderApprovalRuleDetail()

            DataGridViewControl_PurchaseOrderApprovalRuleDetails.CancelNewItemRow()

        End Sub
        Public Sub AddNewApprovers(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail)

            Dim PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee = Nothing

            If PurchaseOrderApprovalRuleDetail.EmployeeName IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

            If PurchaseOrderApprovalRuleDetail.EmployeeName2 IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName2
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

            If PurchaseOrderApprovalRuleDetail.EmployeeName3 IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName3
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

            If PurchaseOrderApprovalRuleDetail.EmployeeName4 IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName4
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

            If PurchaseOrderApprovalRuleDetail.EmployeeName5 IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName5
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

            If PurchaseOrderApprovalRuleDetail.EmployeeName6 IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName6
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

            If PurchaseOrderApprovalRuleDetail.EmployeeName7 IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName7
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

            If PurchaseOrderApprovalRuleDetail.EmployeeName8 IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName8
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

            If PurchaseOrderApprovalRuleDetail.EmployeeName9 IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName9
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

            If PurchaseOrderApprovalRuleDetail.EmployeeName10 IsNot Nothing Then

                PurchaseOrderApprovalRuleEmployee = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode
                PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                PurchaseOrderApprovalRuleEmployee.EmployeeCode = PurchaseOrderApprovalRuleDetail.EmployeeName10
                PurchaseOrderApprovalRuleEmployee.IsInactive = 0

                AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Insert(DbContext, PurchaseOrderApprovalRuleEmployee)

            End If

        End Sub
        Public Function LoadControl(ByVal PurchaseApprovalRuleCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim PurchaseOrderApproval As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing

            _PurchaseOrderApprovalRuleCode = PurchaseApprovalRuleCode


            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _PurchaseOrderApprovalRuleCode <> "" Then

                    TextBoxControl_Code.Enabled = False

                    PurchaseOrderApproval = LoadPurchaseOrderApprovalRule()

                    If PurchaseOrderApproval IsNot Nothing Then

                        _IsLoading = True

                        TextBoxControl_Code.Text = PurchaseOrderApproval.Code
                        TextBoxControl_Description.Text = PurchaseOrderApproval.Description
                        CheckBoxControl_Inactive.Checked = Convert.ToBoolean(PurchaseOrderApproval.IsInactive.GetValueOrDefault(0))

                        _IsLoading = False

                    Else

                        Loaded = False

                    End If

                Else

                    TextBoxControl_Code.Enabled = True

                    DataGridViewControl_PurchaseOrderApprovalRuleDetails.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail)

                    DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.BestFitColumns()

                End If

            End Using

            LoadSelectedRuleDetails()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule

            Dim PurchaseOrderApproval As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing

            Try

                If IsNew Then

                    PurchaseOrderApproval = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule

                    LoadPurchaseOrderApprovalRuleEntity(PurchaseOrderApproval)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PurchaseOrderApproval = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadByPurchaseOrderApprovalRuleCode(DbContext, _PurchaseOrderApprovalRuleCode)

                    End Using

                    If PurchaseOrderApproval IsNot Nothing Then

                        LoadPurchaseOrderApprovalRuleEntity(PurchaseOrderApproval)

                    End If

                End If

            Catch ex As Exception
                PurchaseOrderApproval = Nothing
            End Try

            FillObject = PurchaseOrderApproval

        End Function
        Public Function FillPORuleDetailsObject() As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail)

            Dim PurchaseOrderApprovalRuleDetailList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) = Nothing
            Dim Row As Object = Nothing

            Try

                PurchaseOrderApprovalRuleDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail)

                For RowHandle = 0 To DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.RowCount

                    Row = DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.GetRow(RowHandle)

                    If Row IsNot Nothing AndAlso DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.IsNewItemRow(RowHandle) = False Then

                        PurchaseOrderApprovalRuleDetailList.Add(Row)

                    End If

                Next

            Catch ex As Exception
                PurchaseOrderApprovalRuleDetailList = Nothing
            End Try

            FillPORuleDetailsObject = PurchaseOrderApprovalRuleDetailList

        End Function
        Public Function LoadPurchaseOrderApprovalRule() As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule

            Dim PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PurchaseOrderApprovalRule = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadByPurchaseOrderApprovalRuleCode(DbContext, _PurchaseOrderApprovalRuleCode)

                End Using

            Catch ex As Exception
                PurchaseOrderApprovalRule = Nothing
            End Try

            LoadPurchaseOrderApprovalRule = PurchaseOrderApprovalRule

        End Function
        Public Function Save() As Boolean

            'objects
            Dim PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing
            Dim PurchaseOrderApprovalRuleDetails As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) = Nothing
            Dim PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PurchaseOrderApprovalRule = Me.FillObject(False)

                    If PurchaseOrderApprovalRule IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.Update(DbContext, PurchaseOrderApprovalRule) Then

                            Saved = True

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                            Try

                                PurchaseOrderApprovalRuleDetails = FillPORuleDetailsObject()

                                For Each POARD In PurchaseOrderApprovalRuleDetails

                                    PurchaseOrderApprovalRuleDetail = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.LoadByPurchaseOrderApprovalRuleCodeSeqNum(DbContext, POARD.PurchaseOrderApprovalRuleCode, POARD.SequenceNumber)

                                    PurchaseOrderApprovalRuleDetail.ApprovalMinimum = POARD.ApprovalMinimum
                                    PurchaseOrderApprovalRuleDetail.ApprovalMaximum = POARD.ApprovalMaximum

                                    If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.Update(DbContext, PurchaseOrderApprovalRuleDetail) = False Then

                                        DbContext.UndoChanges(PurchaseOrderApprovalRuleDetail)

                                    End If

                                Next

                            Catch ex As Exception

                            End Try

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PurchaseOrderApprovalRule = Me.FillObject(False)

                    If PurchaseOrderApprovalRule IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.Delete(DbContext, PurchaseOrderApprovalRule)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The PO Approval Rule is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef PurchaseOrderApprovalRuleCode As String) As Boolean

            'objects
            Dim PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing
            Dim ErrorMessage As String = Nothing
            Dim PurchaseOrderApprovalRuleDetailEntity As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PurchaseOrderApprovalRule = Me.FillObject(True)

                    If PurchaseOrderApprovalRule IsNot Nothing Then

                        PurchaseOrderApprovalRule.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.Insert(DbContext, PurchaseOrderApprovalRule) Then

                            Inserted = True

                            For Each PurchaseOrderApprovalRuleDetail In FillPORuleDetailsObject()

                                PurchaseOrderApprovalRuleDetailEntity = New AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail

                                PurchaseOrderApprovalRuleDetailEntity.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRule.Code
                                PurchaseOrderApprovalRuleDetailEntity.ApprovalMinimum = PurchaseOrderApprovalRuleDetail.ApprovalMinimum
                                PurchaseOrderApprovalRuleDetailEntity.ApprovalMaximum = PurchaseOrderApprovalRuleDetail.ApprovalMaximum
                                PurchaseOrderApprovalRuleDetailEntity.IsInactive = PurchaseOrderApprovalRuleDetail.IsInactive.GetValueOrDefault(0)

                                If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.Insert(DbContext, PurchaseOrderApprovalRuleDetailEntity) Then

                                    PurchaseOrderApprovalRuleDetail.SequenceNumber = PurchaseOrderApprovalRuleDetailEntity.SequenceNumber

                                    AddNewApprovers(DbContext, PurchaseOrderApprovalRuleDetail)

                                End If

                            Next

                            PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRule.Code

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub PurchaseOrderApprovalRuleControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _PurchaseOrderApprovalRuleDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail)

            LoadModalOptions()

            DataGridViewControl_PurchaseOrderApprovalRuleDetails.MultiSelect = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub CheckBoxControl_Inactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxControl_Inactive.CheckedChanged

            Dim PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule = Nothing

            If Me.FindForm.Modal = False AndAlso Not _IsLoading AndAlso Not _IsClearing Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PurchaseOrderApprovalRule = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadByPurchaseOrderApprovalRuleCode(DbContext, _PurchaseOrderApprovalRuleCode)

                    If PurchaseOrderApprovalRule IsNot Nothing Then

                        PurchaseOrderApprovalRule.IsInactive = CheckBoxControl_Inactive.Checked

                        If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.Update(DbContext, PurchaseOrderApprovalRule) Then

                            RaiseEvent PurchaseOrderApprovalRuleInActiveChanged()

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewControl_PurchaseOrderApprovalRuleDetails_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewControl_PurchaseOrderApprovalRuleDetails.AddNewRowEvent

            Dim PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail Then

                Me.ShowWaitForm("Processing...")

                DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.CloseEditorForUpdating()

                Try

                    PurchaseOrderApprovalRuleDetail = RowObject

                    If _PurchaseOrderApprovalRuleCode IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            PurchaseOrderApprovalRuleDetail.DbContext = DbContext

                            PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleDetail.IsInactive = PurchaseOrderApprovalRuleDetail.IsInactive.GetValueOrDefault(0)

                            If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.Insert(DbContext, PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleDetail) Then

                                PurchaseOrderApprovalRuleDetail.SequenceNumber = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleDetail.SequenceNumber

                                AddNewApprovers(DbContext, PurchaseOrderApprovalRuleDetail)

                                LoadSelectedRuleDetails()

                            End If

                        End Using

                    Else

                        _PurchaseOrderApprovalRuleDetailList.Add(PurchaseOrderApprovalRuleDetail)

                        LoadSelectedRuleDetails()

                    End If

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewControl_PurchaseOrderApprovalRuleDetails_CellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_PurchaseOrderApprovalRuleDetails.CellValueChangedEvent

            Dim ApprovalMinimum As Decimal = Nothing
            Dim ApprovalMaximum As Decimal = Nothing

            If TypeOf DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.ApprovalMaximum.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.ApprovalMinimum.ToString Then

                    ApprovalMinimum = DirectCast(DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail).ApprovalMinimum.GetValueOrDefault(0)
                    ApprovalMaximum = DirectCast(DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail).ApprovalMaximum.GetValueOrDefault(0)

                    If ApprovalMinimum > ApprovalMaximum Then

                        If ApprovalMaximum <> 0 Then

                            AdvantageFramework.WinForm.MessageBox.Show("Approval Minimum cannot be greater than Approval Maximum.")

                        End If

                        DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.ApprovalMaximum.ToString, ApprovalMinimum)

                    End If

                ElseIf e.Column.FieldName.StartsWith(AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName.ToString) Then

                    If IsNumeric(e.Value) AndAlso e.Value < 1 Then

                        DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.SetRowCellValue(e.RowHandle, e.Column, Nothing)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_PurchaseOrderApprovalRuleDetails_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_PurchaseOrderApprovalRuleDetails.CellValueChangingEvent

            Dim PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail = Nothing

            If TypeOf DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail Then

                If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.IsInactive.ToString Then

                    Try

                        PurchaseOrderApprovalRuleDetail = DataGridViewControl_PurchaseOrderApprovalRuleDetails.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        PurchaseOrderApprovalRuleDetail = Nothing
                    End Try

                    If PurchaseOrderApprovalRuleDetail IsNot Nothing Then

                        Try

                            PurchaseOrderApprovalRuleDetail.IsInactive = Convert.ToInt16(e.Value)

                        Catch ex As Exception
                            PurchaseOrderApprovalRuleDetail.IsInactive = PurchaseOrderApprovalRuleDetail.IsInactive
                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Try

                            Me.ShowWaitForm("Processing...")

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                PurchaseOrderApprovalRuleDetail.DbContext = DbContext

                                Saved = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.Update(DbContext, PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleDetail)

                            End Using

                            If Saved Then

                                DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.RefreshData()

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
        Private Sub DataGridViewControl_PurchaseOrderApprovalRuleDetails_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewControl_PurchaseOrderApprovalRuleDetails.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        CancelNewItemRowPurchaseOrderApprovalRuleDetail()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DeletePurchaseOrderApprovalRuleDetail()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewControl_PurchaseOrderApprovalRuleDetails_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_PurchaseOrderApprovalRuleDetails.InitNewRowEvent

            If TypeOf DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail Then

                DirectCast(DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail).PurchaseOrderApprovalRuleCode = TextBoxControl_Code.Text

            End If

            RaiseEvent PurchaseOrderApprovalRuleDetailInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_PurchaseOrderApprovalRuleDetails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewControl_PurchaseOrderApprovalRuleDetails.SelectionChangedEvent

            RaiseEvent PurchaseOrderApprovalRuleDetailSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_PurchaseOrderApprovalRuleDetails_ValidatingEditorEvent(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewControl_PurchaseOrderApprovalRuleDetails.ValidatingEditorEvent

            Dim PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail = Nothing

            PurchaseOrderApprovalRuleDetail = DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.GetRow(DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.FocusedRowHandle)

            If DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.FocusedColumn.FieldName.ToString.StartsWith(AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail.Properties.EmployeeName.ToString) Then

                If DuplicateApproverExists(PurchaseOrderApprovalRuleDetail, DataGridViewControl_PurchaseOrderApprovalRuleDetails.CurrentView.FocusedColumn.FieldName, e.Value) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Cannot have duplicate approvers.")

                    e.Valid = False

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
