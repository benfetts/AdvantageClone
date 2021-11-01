Namespace Maintenance.Accounting.Presentation

    Public Class CopyOfficeGLAccountsDialog

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

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef CopyDefaultAccts As Boolean, ByRef CopyDefaultProductionAccts As Boolean, ByRef CopyDefaultMediaAccts As Boolean, ByRef CopyProductionSalesClassFunctionAccts As Boolean, ByRef CopyProductionFunctionAccts As Boolean, ByRef CopyMediaSalesClassAccts As Boolean, ByRef CopySalesTaxAccts As Boolean, ByRef ReplaceOfficeSegment As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim CopyOfficeGLAccountsDialog As AdvantageFramework.Maintenance.Accounting.Presentation.CopyOfficeGLAccountsDialog = Nothing

            CopyOfficeGLAccountsDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.CopyOfficeGLAccountsDialog()

            ShowFormDialog = CopyOfficeGLAccountsDialog.ShowDialog()

            CopyDefaultAccts = CopyOfficeGLAccountsDialog.CheckBoxCopy_DefaultAccounts.Checked
            CopyDefaultProductionAccts = CopyOfficeGLAccountsDialog.CheckBoxCopy_DefaultProductionAccounts.Checked
            CopyDefaultMediaAccts = CopyOfficeGLAccountsDialog.CheckBoxCopy_DefaultMediaAccounts.Checked
            CopyProductionSalesClassFunctionAccts = CopyOfficeGLAccountsDialog.CheckBoxCopy_ProductionSalesClassFunctionAccounts.Checked
            CopyProductionFunctionAccts = CopyOfficeGLAccountsDialog.CheckBoxCopy_ProductionFunctionAccounts.Checked
            CopyMediaSalesClassAccts = CopyOfficeGLAccountsDialog.CheckBoxCopy_MediaSalesClassAccounts.Checked
            CopySalesTaxAccts = CopyOfficeGLAccountsDialog.CheckBoxCopy_SalesTaxAccounts.Checked
            ReplaceOfficeSegment = CopyOfficeGLAccountsDialog.CheckBoxForm_ReplaceOfficeSegment.Checked

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CopyOfficeGLAccountsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            CheckBoxCopy_DefaultAccounts.Checked = True
            CheckBoxCopy_DefaultProductionAccounts.Checked = True
            CheckBoxCopy_DefaultMediaAccounts.Checked = True
            CheckBoxCopy_ProductionSalesClassFunctionAccounts.Checked = True
            CheckBoxCopy_ProductionFunctionAccounts.Checked = True
            CheckBoxCopy_MediaSalesClassAccounts.Checked = True
            CheckBoxCopy_SalesTaxAccounts.Checked = True

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Create_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Create.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        End Sub

#End Region

#End Region

    End Class

End Namespace