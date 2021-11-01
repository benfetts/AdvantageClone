Namespace Employee.Presentation

    Public Class ExpenseReportPrintOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PrintApproverName As Boolean = False
        Private _ExcludeEmployeeSignature As Boolean = False
        Private _IncludeReceipts As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property PrintApproverName As Boolean
            Get
                PrintApproverName = _PrintApproverName
            End Get
        End Property
        Private ReadOnly Property ExcludeEmployeeSignature As Boolean
            Get
                ExcludeEmployeeSignature = _ExcludeEmployeeSignature
            End Get
        End Property
        Private ReadOnly Property IncludeReceipts As Boolean
            Get
                IncludeReceipts = _IncludeReceipts
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef PrintApproverName As Boolean, ByRef ExcludeEmployeeSignature As Boolean, ByRef IncludeReceipts As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ExcludeEmployeeSignature = ExcludeEmployeeSignature
            _PrintApproverName = PrintApproverName
            _IncludeReceipts = IncludeReceipts

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef PrintApproverName As Boolean, ByRef ExcludeEmployeeSignature As Boolean, ByRef IncludeReceipts As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim ExpenseReportPrintOptionsDialog As AdvantageFramework.Employee.Presentation.ExpenseReportPrintOptionsDialog = Nothing

            ExpenseReportPrintOptionsDialog = New AdvantageFramework.Employee.Presentation.ExpenseReportPrintOptionsDialog(PrintApproverName, ExcludeEmployeeSignature, IncludeReceipts)

            ShowFormDialog = ExpenseReportPrintOptionsDialog.ShowDialog()

            PrintApproverName = ExpenseReportPrintOptionsDialog.PrintApproverName
            ExcludeEmployeeSignature = ExpenseReportPrintOptionsDialog.ExcludeEmployeeSignature
            IncludeReceipts = ExpenseReportPrintOptionsDialog.IncludeReceipts

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExpenseReportPrintOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            CheckBoxForm_ExcludeEmployeeSignature.ByPassUserEntryChanged = True
            CheckBoxForm_PrintSupervisiorName.ByPassUserEntryChanged = True
            CheckBoxIncludeReceipts.ByPassUserEntryChanged = True

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Print_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Print.Click

            _PrintApproverName = CheckBoxForm_PrintSupervisiorName.Checked
            _ExcludeEmployeeSignature = CheckBoxForm_ExcludeEmployeeSignature.Checked
            _IncludeReceipts = CheckBoxIncludeReceipts.Checked

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace