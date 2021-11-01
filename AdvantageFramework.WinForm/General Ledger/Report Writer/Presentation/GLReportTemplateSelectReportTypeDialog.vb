Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportTemplateSelectReportTypeDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ReportType As ReportTypes = ReportTypes.IncomeStatement

#End Region

#Region " Properties "

        Private ReadOnly Property ReportType As ReportTypes
            Get
                ReportType = _ReportType
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ReportType As ReportTypes) As System.Windows.Forms.DialogResult

            'objects
            Dim GLReportTemplateSelectReportTypeDialog As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateSelectReportTypeDialog = Nothing

            GLReportTemplateSelectReportTypeDialog = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateSelectReportTypeDialog()

            ShowFormDialog = GLReportTemplateSelectReportTypeDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ReportType = GLReportTemplateSelectReportTypeDialog.ReportType

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportTemplateSelectReportTypeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            ButtonForm_IncomeStatement.Image = My.Resources.IncomeStatementImage
            ButtonForm_BalanceSheet.Image = My.Resources.BalanceSheetImage
            ButtonForm_Other.Image = My.Resources.OtherStatementImage

        End Sub
        Private Sub GLReportTemplateSelectReportTypeDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If ButtonForm_IncomeStatement.Checked Then

                _ReportType = ReportTypes.IncomeStatement

            ElseIf ButtonForm_BalanceSheet.Checked Then

                _ReportType = ReportTypes.BalanceSheet

            ElseIf ButtonForm_Other.Checked Then

                _ReportType = ReportTypes.Other

            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_IncomeStatement_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonForm_IncomeStatement.CheckedChanged

            If ButtonForm_IncomeStatement.Checked Then

                ButtonForm_BalanceSheet.Checked = False
                ButtonForm_Other.Checked = False

            End If

        End Sub
        Private Sub ButtonForm_BalanceSheet_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonForm_BalanceSheet.CheckedChanged

            If ButtonForm_BalanceSheet.Checked Then

                ButtonForm_IncomeStatement.Checked = False
                ButtonForm_Other.Checked = False

            End If

        End Sub
        Private Sub ButtonForm_Other_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonForm_Other.CheckedChanged

            If ButtonForm_Other.Checked Then

                ButtonForm_IncomeStatement.Checked = False
                ButtonForm_BalanceSheet.Checked = False

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
