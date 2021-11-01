Namespace WinForm.MVC.Presentation

    Public Class AlertRecipientDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum AlertRecipientSourceType
            MediaRFPHeader
            OrderNumber
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.AlertRecipientViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.AlertRecipientController = Nothing
        Protected _MediaRFPHeaderIDs As IEnumerable(Of Integer) = Nothing
        Protected _EmployeeCodes As Generic.List(Of String) = Nothing
        Protected _AlertRecipientSourceType As AlertRecipientSourceType = AlertRecipientSourceType.MediaRFPHeader
        Protected _DictionaryOrderNumbers As Dictionary(Of Integer, String) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee)
            Get
                Employees = _ViewModel.SelectedEmployees
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(MediaRFPHeaderIDs As IEnumerable(Of Integer), EmployeeCodes As Generic.List(Of String))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaRFPHeaderIDs = MediaRFPHeaderIDs

            _EmployeeCodes = EmployeeCodes

            _AlertRecipientSourceType = AlertRecipientSourceType.MediaRFPHeader

        End Sub
        Private Sub New(DictionaryOrderNumbers As Dictionary(Of Integer, String), EmployeeCodes As Generic.List(Of String))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _DictionaryOrderNumbers = DictionaryOrderNumbers

            _EmployeeCodes = EmployeeCodes

            _AlertRecipientSourceType = AlertRecipientSourceType.OrderNumber

        End Sub
        Private Sub CreateTreeListColumns()

            'objects
            Dim CodeTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing
            Dim DescriptionTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing

            TreeListForm_AlertRecipients.BeginUpdate()

            TreeListForm_AlertRecipients.Columns.Clear()
            TreeListForm_AlertRecipients.OptionsView.ShowColumns = False

            CodeTreeListColumn = TreeListForm_AlertRecipients.Columns.Add()
            CodeTreeListColumn.Caption = "Code"
            CodeTreeListColumn.FieldName = "Code"
            CodeTreeListColumn.VisibleIndex = -1
            CodeTreeListColumn.Visible = False
            DescriptionTreeListColumn = TreeListForm_AlertRecipients.Columns.Add()
            DescriptionTreeListColumn.Caption = "Description"
            DescriptionTreeListColumn.FieldName = "Description"
            DescriptionTreeListColumn.VisibleIndex = 0
            DescriptionTreeListColumn.Visible = True

            TreeListForm_AlertRecipients.OptionsView.ShowCheckBoxes = True

            TreeListForm_AlertRecipients.EndUpdate()

        End Sub
        Private Sub LoadViewModel()

            Dim ParentTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim AlertGroupNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim AlertGroupEmployee As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            If _AlertRecipientSourceType = AlertRecipientSourceType.MediaRFPHeader Then

                _ViewModel = _Controller.Load(_MediaRFPHeaderIDs, _EmployeeCodes)

            ElseIf _AlertRecipientSourceType = AlertRecipientSourceType.OrderNumber Then

                _ViewModel = _Controller.Load(_DictionaryOrderNumbers, _EmployeeCodes)

            End If

            TreeListForm_AlertRecipients.BeginUnboundLoad()

            For Each AlertGroup In _ViewModel.DistinctAlertGroups

                AlertGroupNode = TreeListForm_AlertRecipients.AppendNode(New Object() {AlertGroup.Code, AlertGroup.Code}, ParentTreeListNode)
                AlertGroupNode.Tag = AlertGroup

                For Each AlertGroupEmployee In _ViewModel.AlertGroups.Where(Function(AG) AG.Code = AlertGroup.Code)

                    Employee = (From Entity In _ViewModel.Employees
                                Where Entity.Code = AlertGroupEmployee.EmployeeCode
                                Select Entity).SingleOrDefault

                    If Employee IsNot Nothing Then

                        EmployeeNode = TreeListForm_AlertRecipients.AppendNode(New Object() {Employee.Code, Employee.ToString}, AlertGroupNode)

                        EmployeeNode.Tag = Employee

                    End If

                Next

            Next

            For Each Employee In _ViewModel.SelectedEmployees

                CheckFirstChildNode(Employee)

            Next

            TreeListForm_AlertRecipients.EndUnboundLoad()

        End Sub
        Private Sub CheckFirstChildNode(Employee As AdvantageFramework.Database.Views.Employee)

            For Each Node In TreeListForm_AlertRecipients.Nodes.ToList

                For Each ChildNode In Node.Nodes.ToList

                    If DirectCast(ChildNode.Tag, AdvantageFramework.Database.Views.Employee).Code = Employee.Code Then

                        ChildNode.Checked = True
                        ChildNode.ParentNode.Checked = True
                        ChildNode.ParentNode.Expanded = True

                        Exit Sub

                    End If

                Next

            Next

        End Sub
        Private Sub SaveViewModel()

            'objects
            Dim ChildTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            _ViewModel.SelectedEmployees.Clear()

            For Each TreeListNode In TreeListForm_AlertRecipients.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)()

                For Each ChildTreeListNode In TreeListNode.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)()

                    If ChildTreeListNode.Checked Then

                        Try

                            If _ViewModel.SelectedEmployees.Where(Function(Emp) Emp.Code = DirectCast(ChildTreeListNode.Tag, AdvantageFramework.Database.Views.Employee).Code).Any = False Then

                                _ViewModel.SelectedEmployees.Add(ChildTreeListNode.Tag)

                            End If

                        Catch ex As Exception

                        End Try

                    End If

                Next

            Next

        End Sub
        Private Sub RefreshViewModel()


        End Sub
        Private Sub SetControlPropertySettings()

            'TimeEditForm_StartTime.ControlType = Presentation.Controls.TimeEdit.Type.Default
            'TimeEditForm_EndTime.ControlType = Presentation.Controls.TimeEdit.Type.Default

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaRFPHeaderIDs As IEnumerable(Of Integer), EmployeeCodes As Generic.List(Of String),
                                              ByRef Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee)) As Windows.Forms.DialogResult

            'objects
            Dim AlertRecipientDialog As AdvantageFramework.WinForm.MVC.Presentation.AlertRecipientDialog = Nothing

            AlertRecipientDialog = New AdvantageFramework.WinForm.MVC.Presentation.AlertRecipientDialog(MediaRFPHeaderIDs, EmployeeCodes)

            ShowFormDialog = AlertRecipientDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                Employees = AlertRecipientDialog.Employees

            End If

        End Function
        Public Shared Function ShowFormDialog(DictionaryOrders As Dictionary(Of Integer, String), EmployeeCodes As Generic.List(Of String),
                                              ByRef Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee)) As Windows.Forms.DialogResult

            'objects
            Dim AlertRecipientDialog As AdvantageFramework.WinForm.MVC.Presentation.AlertRecipientDialog = Nothing

            AlertRecipientDialog = New AdvantageFramework.WinForm.MVC.Presentation.AlertRecipientDialog(DictionaryOrders, EmployeeCodes)

            ShowFormDialog = AlertRecipientDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                Employees = AlertRecipientDialog.Employees

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AlertRecipientDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TreeListForm_AlertRecipients.Nodes.Clear()
            TreeListForm_AlertRecipients.ByPassUserEntryChanged = True
            TreeListForm_AlertRecipients.OptionsView.ShowIndicator = False

            CreateTreeListColumns()

            _Controller = New AdvantageFramework.Controller.AlertRecipientController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub AlertRecipientDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Loading)

            LoadViewModel()

            RefreshViewModel()

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                SaveViewModel()

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub TreeListForm_AlertRecipients_NodeChanged(sender As Object, e As DevExpress.XtraTreeList.NodeChangedEventArgs) Handles TreeListForm_AlertRecipients.NodeChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If e.ChangeType = DevExpress.XtraTreeList.NodeChangeTypeEnum.CheckedState Then

                    Me.FormAction = WinForm.Presentation.FormActions.Modifying

                    If e.Node.Nodes.Count > 0 Then

                        If e.Node.Checked Then

                            e.Node.ExpandAll()

                        End If

                        For Each TreeListNode In e.Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)()

                            TreeListNode.Checked = e.Node.Checked

                        Next

                    ElseIf e.Node.ParentNode IsNot Nothing Then

                        If e.Node.Checked = False Then

                            If e.Node.ParentNode.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).Where(Function(TreeListNode) TreeListNode.Checked = True).Any = False Then

                                e.Node.ParentNode.Checked = False

                            End If

                        Else

                            e.Node.ParentNode.Checked = True

                        End If

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
