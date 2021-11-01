Imports DevComponents.DotNetBar

Namespace Maintenance.General.Presentation

    Public Class DocumentsEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SelectedNode As AdvantageFramework.Database.Entities.Label = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()



        End Sub

        Private Sub LoadColors()

            DevCompColor.CustomStandardColors = New ColorItem()() _
           {
              New ColorItem() _
              {
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFCDD2")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#F8BBD0")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#E1BEE7")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#CE93D8")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#D1C4E9")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#C5CAE9")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#BBDEFB")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#B3E5FC")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#B2EBF2")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#B2DFDB")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#C8E6C9")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#DCEDC8")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#F0F4C3")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFF9C4")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFECB3")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFE0B2")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFCCBC")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#D7CCC8")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#BDBDBD")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#B0BEC5")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFFFFF"))}}


        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal SelectedNode As AdvantageFramework.Database.Entities.Label) As System.Windows.Forms.DialogResult

            'objects
            Dim DocumentsEditDialog As AdvantageFramework.Maintenance.General.Presentation.DocumentsEditDialog = Nothing

            DocumentsEditDialog = New AdvantageFramework.Maintenance.General.Presentation.DocumentsEditDialog()

            DocumentsEditDialog._SelectedNode = SelectedNode

            ShowFormDialog = DocumentsEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DocumentsEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.CheckBoxOptions_LabelInactive.Checked = True

            LoadColors()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim StandardCommentID As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    Using dc = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Dim Label As AdvantageFramework.Database.Entities.Label = Nothing

                        'If Me._SelectedNode Is Nothing Then

                        If Me.CheckBoxOptions_TopLevelLabel.Checked = False AndAlso _SelectedNode Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a parent label or check the ""\Top Level""\ checkbox")
                            Exit Sub

                        End If

                        Label = New AdvantageFramework.Database.Entities.Label

                        Label.Name = Me.TextBoxLabelInformation_Name.Text.Trim()
                        Label.Description = Me.TextBoxLabelInformation_Description.Text.Trim()
                        Label.HexColor = System.Drawing.ColorTranslator.ToHtml(Me.DevCompColor.SelectedColor)
                        Label.IsInactive = Not Me.CheckBoxOptions_LabelInactive.Checked
                        Label.CreatedBy = Me.Session.UserCode

                        If _SelectedNode IsNot Nothing Then

                            Label.ParentID = _SelectedNode.ID

                        End If
                        If Me.CheckBoxOptions_TopLevelLabel.Checked Then

                            Label.ParentID = Nothing

                        End If

                        If AdvantageFramework.Database.Procedures.Label.Insert(dc, Label) = True Then

                            'Me._SelectedLabelID = Label.ID
                            'Me.LoadLabels()

                            'If Me._SelectedLabelID > 0 AndAlso Me.RadTreeViewLabels.Nodes.Count > 0 Then

                            '    Dim SelectedNode As RadTreeNode = Me.RadTreeViewLabels.Nodes.FindNodeByValue(Me._SelectedLabelID)

                            '    If SelectedNode IsNot Nothing Then SelectedNode.Selected = True

                            'End If

                            'If Me._SelectedLabelID > 0 Then Me.LoadEditForm()

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Could not add new label")

                        End If

                        'Else

                        'Label = AdvantageFramework.Database.Procedures.Label.LoadByLabelID(dc, Me._SelectedNode.ID)

                        'If Label IsNot Nothing Then

                        '    Label.Name = Me.TextBoxLabelInformation_Name.Text.Trim()
                        '    Label.Description = Me.TextBoxLabelInformation_Description.Text.Trim()
                        '    Label.HexColor = System.Drawing.ColorTranslator.ToHtml(Me.ColorEdit_Labels.Color)
                        '    Label.IsInactive = Not Me.CheckBoxOptions_LabelInactive.Checked

                        '    If AdvantageFramework.Database.Procedures.Label.Update(dc, Label) = True Then

                        '        'If Me._SelectedLabelID > 0 Then Me.LoadEditForm()

                        '    Else

                        '        AdvantageFramework.WinForm.MessageBox.Show("Could not update label")

                        '    End If

                        'End If

                        'End If

                    End Using

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

        Private Sub DevCompColor_SelectedColorChanged(sender As Object, e As EventArgs) Handles DevCompColor.SelectedColorChanged
            Me.PictureBox1.BackColor = DevCompColor.SelectedColor
        End Sub

#End Region

#End Region

    End Class

End Namespace