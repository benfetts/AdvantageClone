Namespace Media.Presentation

    Public Class BroadcastResearchToolReportEditDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ResearchType
            SpotRadio
            SpotTV
            SpotRadioCounty
            SpotNational
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.ResearchCriteriaViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.ResearchCriteriaController = Nothing
        Protected _ResearchCriteria As AdvantageFramework.DTO.Media.ResearchCriteriaTypes = DTO.Media.Methods.ResearchCriteriaTypes.SpotTV
        Protected _ResearchID As Integer? = Nothing
        Protected _ResearchType As ResearchType = ResearchType.SpotTV
        Protected _IsCopy As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property ResearchID As Integer?
            Get
                ResearchID = _ResearchID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ResearchCriteria As AdvantageFramework.DTO.Media.ResearchCriteriaTypes, ResearchType As ResearchType, ResearchID As Integer?,
                        Optional IsCopy As Boolean = False)

            ' This call is required by the designer.
            InitializeComponent()

            _ResearchCriteria = ResearchCriteria
            _ResearchID = ResearchID
            _ResearchType = ResearchType
            _IsCopy = IsCopy

        End Sub
        Private Sub RefreshViewModel()

            ButtonForm_Add.Visible = _ViewModel.AddVisible
            ButtonForm_Update.Visible = _ViewModel.UpdateVisible
            ButtonForm_Copy.Visible = _ViewModel.CopyVisible

            Me.Text = _ViewModel.FormCaption
            TextBoxForm_CriteriaName.Text = _ViewModel.CriteriaName

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ResearchCriteria As AdvantageFramework.DTO.Media.ResearchCriteriaTypes, ResearchType As ResearchType,
                                              ByRef ResearchID As Integer?) As System.Windows.Forms.DialogResult

            'objects
            Dim BroadcastResearchToolReportEditDialog As AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog = Nothing

            BroadcastResearchToolReportEditDialog = New AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog(ResearchCriteria, ResearchType, ResearchID)

            ShowFormDialog = BroadcastResearchToolReportEditDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                ResearchID = BroadcastResearchToolReportEditDialog.ResearchID

            End If

        End Function
        Public Shared Function ShowFormDialog(ResearchCriteria As AdvantageFramework.DTO.Media.ResearchCriteriaTypes, ResearchType As ResearchType,
                                              CopyResearchID As Integer, ByRef NewResearchID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim BroadcastResearchToolReportEditDialog As AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog = Nothing

            BroadcastResearchToolReportEditDialog = New AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog(ResearchCriteria, ResearchType, CopyResearchID, True)

            ShowFormDialog = BroadcastResearchToolReportEditDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                NewResearchID = BroadcastResearchToolReportEditDialog.ResearchID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastResearchToolReportEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TextBoxForm_CriteriaName.ByPassUserEntryChanged = True

            TextBoxForm_CriteriaName.SetPropertySettings(AdvantageFramework.Database.Entities.MediaSpotTVResearch.Properties.CriteriaName)

            _Controller = New AdvantageFramework.Controller.Media.ResearchCriteriaController(Me.Session)

        End Sub
        Private Sub BroadcastResearchToolReportEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If _ResearchType = ResearchType.SpotTV Then

                _ViewModel = _Controller.Load(_ResearchID, "SpotTV", _IsCopy)

            ElseIf _ResearchType = ResearchType.SpotRadio Then

                _ViewModel = _Controller.Load(_ResearchID, "SpotRadio", _IsCopy)

            ElseIf _ResearchType = ResearchType.SpotRadioCounty Then

                _ViewModel = _Controller.Load(_ResearchID, "SpotRadioCounty", _IsCopy)

            ElseIf _ResearchType = ResearchType.SpotNational Then

                _ViewModel = _Controller.Load(_ResearchID, "National", _IsCopy)

            End If

            RefreshViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""

            If _ResearchType = ResearchType.SpotTV Then

                If _Controller.AddTV(_ViewModel, TextBoxForm_CriteriaName.GetText, ErrorMessage, _ResearchID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ResearchType = ResearchType.SpotRadio Then

                If _Controller.AddRadio(_ViewModel, TextBoxForm_CriteriaName.GetText, ErrorMessage, _ResearchID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ResearchType = ResearchType.SpotRadioCounty Then

                If _Controller.AddRadioCounty(_ViewModel, TextBoxForm_CriteriaName.GetText, ErrorMessage, _ResearchID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ResearchType = ResearchType.SpotNational Then

                If _Controller.AddNational(_ViewModel, TextBoxForm_CriteriaName.GetText, ErrorMessage, _ResearchID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Copy_Click(sender As Object, e As EventArgs) Handles ButtonForm_Copy.Click

            'objects
            Dim ErrorMessage As String = ""

            If _ResearchType = ResearchType.SpotTV Then

                If _Controller.CopyTV(_ViewModel, TextBoxForm_CriteriaName.GetText, _ResearchID, ErrorMessage, _ResearchID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ResearchType = ResearchType.SpotRadio Then

                If _Controller.CopyRadio(_ViewModel, TextBoxForm_CriteriaName.GetText, _ResearchID, ErrorMessage, _ResearchID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ResearchType = ResearchType.SpotRadioCounty Then

                If _Controller.CopyRadioCounty(_ViewModel, TextBoxForm_CriteriaName.GetText, _ResearchID, ErrorMessage, _ResearchID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ResearchType = ResearchType.SpotNational Then

                If _Controller.CopyNational(_ViewModel, TextBoxForm_CriteriaName.GetText, _ResearchID, ErrorMessage, _ResearchID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(sender As Object, e As EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If _ResearchType = ResearchType.SpotTV Then

                If _Controller.UpdateTV(_ViewModel, TextBoxForm_CriteriaName.GetText, ErrorMessage) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ResearchType = ResearchType.SpotRadio Then

                If _Controller.UpdateRadio(_ViewModel, TextBoxForm_CriteriaName.GetText, ErrorMessage) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ResearchType = ResearchType.SpotRadioCounty Then

                If _Controller.UpdateRadioCounty(_ViewModel, TextBoxForm_CriteriaName.GetText, ErrorMessage) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ResearchType = ResearchType.SpotNational Then

                If _Controller.UpdateNational(_ViewModel, TextBoxForm_CriteriaName.GetText, ErrorMessage) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
