Namespace Maintenance.Media.Presentation

    Public Class DemographicEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaDemographicID As Integer = 0
        Private _Type As String = String.Empty
        Private _MediaDemoSourceID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property MediaDemographicID As Integer
            Get
                MediaDemographicID = _MediaDemographicID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef MediaDemographicID As Integer, Type As String, MediaDemoSourceID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _Type = Type
            _MediaDemoSourceID = MediaDemoSourceID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MediaDemographicID As Integer, Type As String, MediaDemoSourceID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim DemographicEditDialog As AdvantageFramework.Maintenance.Media.Presentation.DemographicEditDialog = Nothing

            DemographicEditDialog = New AdvantageFramework.Maintenance.Media.Presentation.DemographicEditDialog(MediaDemographicID, Type, MediaDemoSourceID)

            ShowFormDialog = DemographicEditDialog.ShowDialog()

            MediaDemographicID = DemographicEditDialog.MediaDemographicID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DemographicEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _MediaDemographicID <> 0 Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If MediaDemographicControlForm_MediaDemographic.LoadControl(_MediaDemographicID, _Type, _MediaDemoSourceID) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The demographic you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                If MediaDemographicControlForm_MediaDemographic.Save(ErrorMessage, _MediaDemographicID) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace