Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketReplaceBuyerDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Private _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketBuyerViewModel = Nothing
        Private _FindBuyerEmployeeCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(FindBuyerEmployeeCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _FindBuyerEmployeeCode = FindBuyerEmployeeCode

        End Sub
        Private Sub LoadViewModel()

            Me.SearchableComboBoxForm_FindBuyer.DataSource = _ViewModel.MediaBuyerEmployeeCodes

            If _ViewModel.MissingMediaBuyerEmployeeCodes IsNot Nothing AndAlso _ViewModel.MissingMediaBuyerEmployeeCodes.Count > 0 Then

                For Each MissingMediaBuyerEmployeeCode In _ViewModel.MissingMediaBuyerEmployeeCodes

                    SearchableComboBoxForm_FindBuyer.AddComboItemToExistingDataSource(MissingMediaBuyerEmployeeCode.Name & "*", MissingMediaBuyerEmployeeCode.Code, False)

                Next

            End If

            Me.SearchableComboBoxForm_ReplaceBuyer.DataSource = _ViewModel.MediaBuyerEmployeeCodes

            Me.SearchableComboBoxForm_FindBuyer.SelectedValue = _FindBuyerEmployeeCode

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.FindBuyerEmployeeCode = Me.SearchableComboBoxForm_FindBuyer.GetSelectedValue
            _ViewModel.ReplaceBuyerEmployeeCode = Me.SearchableComboBoxForm_ReplaceBuyer.GetSelectedValue

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(FindBuyerEmployeeCode As String) As Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketReplaceBuyerDialog As AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketReplaceBuyerDialog = Nothing

            MediaBroadcastWorksheetMarketReplaceBuyerDialog = New AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketReplaceBuyerDialog(FindBuyerEmployeeCode)

            ShowFormDialog = MediaBroadcastWorksheetMarketReplaceBuyerDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketReplaceBuyerDialog_Load(sender As Object, e As EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            _ViewModel = _Controller.Buyer_Load(_FindBuyerEmployeeCode)

            Me.SearchableComboBoxForm_FindBuyer.SetRequired(True)
            Me.SearchableComboBoxForm_ReplaceBuyer.SetRequired(True)

            LoadViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                SaveViewModel()

                If _Controller.Buyer_Replace(_ViewModel) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Replacement successful.")

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
