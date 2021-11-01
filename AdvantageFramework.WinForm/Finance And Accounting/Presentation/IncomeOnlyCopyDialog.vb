Namespace FinanceAndAccounting.Presentation

    Public Class IncomeOnlyCopyDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Mode
            CopyTo
            CopyFrom
        End Enum

#End Region

#Region " Variables "

        Private _SelectedJobComponents As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent) = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Integer = Nothing
        Private _Mode As AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyCopyDialog.Mode = Nothing
        Private WithEvents _BackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing

#End Region

#Region " Properties "


        Private ReadOnly Property SelectedJobComponents As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent)
            Get
                SelectedJobComponents = _SelectedJobComponents
            End Get
        End Property
        Private ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        Private ReadOnly Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        Private ReadOnly Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
        End Property
        Private ReadOnly Property JobNumber As Integer
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        Private ReadOnly Property JobComponentNumber As Integer
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal Mode As AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyCopyDialog.Mode, _
                        ByRef SelectedJobComponents As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent), _
                        ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, _
                        ByRef JobNumber As Integer, ByRef JobComponentNumber As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _Mode = Mode
            _SelectedJobComponents = SelectedJobComponents
            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber

        End Sub
        Private Sub LoadPage(ByVal Page As DevExpress.XtraWizard.WizardPage)

            If Page Is WizardPageWizard_SelectJobComponents Then

                LoadSelectJobComponentPage()

            ElseIf Page Is WizardPageWizard_SelectJob Then

                LoadSelectJobPage()

            End If

        End Sub
        Private Sub LoadSelectJobComponentPage()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectJobComponents_JobComponents.DataSource = AdvantageFramework.IncomeOnly.LoadJobComponentList(DbContext, Me.Session.UserCode, If(_Mode = Mode.CopyFrom, True, False)).OrderByDescending(Function(JC) JC.JobNumber).OrderBy(Function(JC) JC.JobComponentNumber).ToList()

                DataGridViewSelectJobComponents_JobComponents.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectJobPage()

            If DataGridViewSelectJobComponents_JobComponents.HasASelectedRow Then



            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Mode As AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyCopyDialog.Mode,
                                              ByRef SelectedJobComponents As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent),
                                              Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing,
                                              Optional ByVal ProductCode As String = Nothing, Optional ByRef JobNumber As Integer = 0,
                                              Optional ByRef JobComponentNumber As Integer = 0) As System.Windows.Forms.DialogResult

            'objects
            Dim IncomeOnlyCopyDialog As AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyCopyDialog = Nothing

            IncomeOnlyCopyDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyCopyDialog(Mode, SelectedJobComponents, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber)

            ShowFormDialog = IncomeOnlyCopyDialog.ShowDialog()

            SelectedJobComponents = IncomeOnlyCopyDialog.SelectedJobComponents
            JobNumber = IncomeOnlyCopyDialog.JobNumber
            JobComponentNumber = IncomeOnlyCopyDialog.JobComponentNumber

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub IncomeOnlyCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim JobNumber As Integer? = Nothing
            Dim JobComponentNumber As Short? = Nothing
            Dim Loaded As Boolean = True

            DataGridViewSelectJobComponents_JobComponents.MultiSelect = True

            If _Mode = Mode.CopyFrom Then

                SearchableComboBoxSelectJob_Client.SecurityEnabled = String.IsNullOrWhiteSpace(_ClientCode)
                SearchableComboBoxSelectJob_Division.SecurityEnabled = String.IsNullOrWhiteSpace(_DivisionCode)
                SearchableComboBoxSelectJob_Product.SecurityEnabled = String.IsNullOrWhiteSpace(_ProductCode)
                SearchableComboBoxSelectJob_Job.SecurityEnabled = Not _JobNumber > 0
                SearchableComboBoxSelectJob_Component.SecurityEnabled = Not _JobComponentNumber > 0

                If _JobNumber <= 0 OrElse _JobComponentNumber <= 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            CdpJobCompFilterForm_Filter.ClientSource = From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                       Where Entity.IsActive = 1
                                                                       Select Entity

                            CdpJobCompFilterForm_Filter.DivisionSource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                         Where Entity.IsActive = 1
                                                                         Select Entity

                            CdpJobCompFilterForm_Filter.ProductSource = From Entity In AdvantageFramework.Database.Procedures.Product.LoadCoreByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode, True)
                                                                        Where Entity.IsActive = 1
                                                                        Select Entity

                            CdpJobCompFilterForm_Filter.JobSource = AdvantageFramework.IncomeOnly.LoadAvailableJobs(DbContext, Me.Session.UserCode)

                            CdpJobCompFilterForm_Filter.JobComponentSource = AdvantageFramework.IncomeOnly.LoadAvailableComponents(DbContext, Me.Session.UserCode)

                            CdpJobCompFilterForm_Filter.InitializeDataControls()

                            JobNumber = Nothing
                            JobComponentNumber = Nothing

                            If _JobNumber > 0 Then

                                JobNumber = _JobNumber

                                If _JobComponentNumber > 0 Then

                                    JobComponentNumber = _JobComponentNumber

                                End If

                            End If

                            CdpJobCompFilterForm_Filter.SetInitialValues(_ClientCode, _DivisionCode, _ProductCode, JobNumber, JobComponentNumber)

                        End Using

                    End Using

                    SearchableComboBoxSelectJob_Job.SetRequired(True)
                    SearchableComboBoxSelectJob_Component.SetRequired(True)

                Else

                    WizardPageWizard_SelectJob.Visible = False

                End If

            ElseIf _Mode = Mode.CopyTo Then

                WizardPageWizard_SelectJob.Visible = False

            End If

            LoadPage(WizardPageWizard_SelectJobComponents)

            ' DataGridViewSelectJobComponents_JobComponents.OptionsBehavior.Editable = False

            If Loaded = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the Income Only copy wizard.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewSelectJobComponents_JobComponents_RowDoubleClickEvent() Handles DataGridViewSelectJobComponents_JobComponents.RowDoubleClickEvent

            WizardControlForm_Wizard.SetNextPage()

        End Sub
        Private Sub WizardControlForm_Wizard_CancelClick(sender As Object, e As ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.CancelClick

            Me.DialogResult = Windows.Forms.DialogResult.Cancel

        End Sub
        Private Sub WizardControlForm_Wizard_CustomizeCommandButtons(sender As Object, e As DevExpress.XtraWizard.CustomizeCommandButtonsEventArgs) Handles WizardControlForm_Wizard.CustomizeCommandButtons

            If e.Page Is WizardPageWizard_SelectJobComponents Then

                If WizardPageWizard_SelectJob.Visible = False Then

                    e.PrevButton.Visible = False

                End If

            End If

        End Sub
        Private Sub WizardControlForm_Wizard_FinishClick(sender As Object, e As ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.FinishClick

            'objects
            Dim Close As Boolean = True

            _SelectedJobComponents = DataGridViewSelectJobComponents_JobComponents.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.JobComponent)().ToList

            If _Mode = Mode.CopyFrom Then

                If WizardPageWizard_SelectJob.Visible Then

                    If Me.Validator Then

                        _JobNumber = CdpJobCompFilterForm_Filter.JobNumber
                        _JobComponentNumber = CdpJobCompFilterForm_Filter.JobComponentNumber

                    Else

                        Close = False

                    End If

                End If

            End If

            If Close Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub WizardControlForm_Wizard_NextClick(sender As Object, e As DevExpress.XtraWizard.WizardCommandButtonClickEventArgs) Handles WizardControlForm_Wizard.NextClick

            Dim CanContinue As Boolean = True
            Dim Message As String = ""

            If e.Page Is WizardPageWizard_SelectJobComponents Then

                If DataGridViewSelectJobComponents_JobComponents.HasOnlyOneSelectedRow = False Then

                    CanContinue = False
                    Message = "Please select a Job Component to continue."

                End If

            ElseIf e.Page Is WizardPageWizard_SelectJob Then

                If SearchableComboBoxSelectJob_Component.HasASelectedValue = False Then

                    CanContinue = False
                    Message = "Please select a Job Component to continue."

                End If

            End If

            If String.IsNullOrWhiteSpace(Message) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            End If

            e.Handled = Not CanContinue

        End Sub
        Private Sub WizardControlForm_Wizard_SelectedPageChanged(sender As Object, e As DevExpress.XtraWizard.WizardPageChangedEventArgs) Handles WizardControlForm_Wizard.SelectedPageChanged

            If e.Direction = DevExpress.XtraWizard.Direction.Forward Then

                If e.Page Is WizardPageWizard_SelectJobComponents Then

                    If WizardPageWizard_SelectJob.Visible = False Then

                        WizardPageWizard_SelectJobComponents.AllowNext = False

                    End If

                ElseIf e.Page Is WizardPageWizard_SelectJob Then

                    WizardPageWizard_SelectJob.AllowNext = False

                End If

            End If

        End Sub
        Private Sub WizardControlForm_Wizard_SelectedPageChanging(sender As Object, e As DevExpress.XtraWizard.WizardPageChangingEventArgs) Handles WizardControlForm_Wizard.SelectedPageChanging

            If e.Direction = DevExpress.XtraWizard.Direction.Forward Then

                If TypeOf e.Page Is DevExpress.XtraWizard.WizardPage Then

                    LoadPage(e.Page)

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectJobComponents_JobComponents_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewSelectJobComponents_JobComponents.ShowingEditorEvent

            e.Cancel = True

        End Sub

#End Region

#End Region

    End Class

End Namespace
