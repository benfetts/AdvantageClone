Namespace FinanceAndAccounting.Presentation

    Public Class SelectDateRangeDialog

#Region " Constants "



#End Region

#Region " Enum "

        

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private ReadOnly Property [From] As Date
            Get
                [From] = DateTimePickerPanelDates_From.Value
            End Get
        End Property
        Private ReadOnly Property [To] As Date
            Get
                [To] = DateTimePickerPanelDates_To.Value
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal FromDate As Date, ByVal ToDate As Date)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            DateTimePickerPanelDates_From.ByPassUserEntryChanged = True
            DateTimePickerPanelDates_To.ByPassUserEntryChanged = True

            DateTimePickerPanelDates_From.Value = FromDate
            DateTimePickerPanelDates_To.Value = ToDate

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef [From] As Date, ByRef [To] As Date) As Windows.Forms.DialogResult

            'objects
            Dim SelectDateRangeDialog As AdvantageFramework.FinanceAndAccounting.Presentation.SelectDateRangeDialog = Nothing

            SelectDateRangeDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.SelectDateRangeDialog([From], [To])

            ShowFormDialog = SelectDateRangeDialog.ShowDialog()

            [From] = SelectDateRangeDialog.[From]
            [To] = SelectDateRangeDialog.[To]

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub SelectDateRangeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList
                    
                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPanelDates_YTD.Click

            DateTimePickerPanelDates_From.Value = CDate("1/1/" & Now.Year)
            DateTimePickerPanelDates_To.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPanelDates_MTD.Click

            DateTimePickerPanelDates_From.Value = CDate(Now.Month & "/1/" & Now.Year)
            DateTimePickerPanelDates_To.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPanelDates_1Year.Click

            DateTimePickerPanelDates_From.Value = Now.AddYears(-1)
            DateTimePickerPanelDates_To.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPanelDates_2Years.Click

            DateTimePickerPanelDates_From.Value = Now.AddYears(-2)
            DateTimePickerPanelDates_To.Value = Now

        End Sub
        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerPanelDates_To.ValueChanged

            DateTimePickerPanelDates_From.MaxDate = DateTimePickerPanelDates_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerPanelDates_From.ValueChanged

            DateTimePickerPanelDates_To.MinDate = DateTimePickerPanelDates_From.Value

        End Sub

#End Region

#End Region

    End Class

End Namespace