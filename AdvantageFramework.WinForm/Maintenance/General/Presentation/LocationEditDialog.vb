Namespace Maintenance.General.Presentation

    Public Class LocationEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LocationID As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property LocationID As String
            Get
                LocationID = _LocationID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef LocationID As String)

            ' This call is required by the designer.
            InitializeComponent()

            _LocationID = LocationID

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef LocationID As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim LocationEditDialog As AdvantageFramework.Maintenance.General.Presentation.LocationEditDialog = Nothing

            LocationEditDialog = New AdvantageFramework.Maintenance.General.Presentation.LocationEditDialog(LocationID)

            ShowFormDialog = LocationEditDialog.ShowDialog()

            LocationID = LocationEditDialog.LocationID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub LocationEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim ErrorText As String = Nothing

            LocationControlForm_Location.TextBoxFooterLogoSelection_Landscape.SetAgencyImportPathToLogoPath()
            LocationControlForm_Location.TextBoxFooterLogoSelection_Portrait.SetAgencyImportPathToLogoPath()
            LocationControlForm_Location.TextBoxHeaderLogoSelection_Landscape.SetAgencyImportPathToLogoPath()
            LocationControlForm_Location.TextBoxHeaderLogoSelection_Portrait.SetAgencyImportPathToLogoPath()

            If _LocationID <> "" Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True
                ErrorText = "The location you are trying to edit does not exist anymore."

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False
                ErrorText = "There was a problem creating a new location."

            End If

            If LocationControlForm_Location.LoadControl(_LocationID) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorText)
                Me.Close()

            End If

        End Sub
        Private Sub LocationEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                LocationControlForm_Location.TextBoxRightSection_ID.Focus()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim LocationID As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    LocationControlForm_Location.Insert(LocationID)

                    _LocationID = LocationID

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    LocationControlForm_Location.Save()

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

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
