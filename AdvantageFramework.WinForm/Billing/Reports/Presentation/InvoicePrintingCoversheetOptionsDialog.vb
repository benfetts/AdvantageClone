Namespace Billing.Reports.Presentation

    Public Class InvoicePrintingCoversheetOptionsDialog

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

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub EnableOrDisableActions()

            If RadioButtonContact_ContactType.Checked Then

                SearchableComboBoxContact_ContactType.Enabled = True
                SearchableComboBoxContact_ContactType.SetRequired(True)

            Else

                SearchableComboBoxContact_ContactType.Enabled = False
                SearchableComboBoxContact_ContactType.SetRequired(False)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As Windows.Forms.DialogResult

            'objects
            Dim InvoicePrintingCoversheetOptionsDialog As InvoicePrintingCoversheetOptionsDialog = Nothing

            InvoicePrintingCoversheetOptionsDialog = New InvoicePrintingCoversheetOptionsDialog()

            ShowFormDialog = InvoicePrintingCoversheetOptionsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub InvoicePrintingCoversheetOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
            Dim CoversheetContact As AdvantageFramework.InvoicePrinting.CoversheetContacts = AdvantageFramework.InvoicePrinting.CoversheetContacts.None
            Dim ContactTypeID As Integer = -1
            Dim CoversheetContactLocation As AdvantageFramework.InvoicePrinting.CoversheetContactLocations = AdvantageFramework.InvoicePrinting.CoversheetContactLocations.AttnLine

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SearchableComboBoxContact_ContactType.DataSource = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).OrderBy(Function(Entity) Entity.Description)

                End Using

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CoversheetLayout = AdvantageFramework.InvoicePrinting.LoadCoversheetLayout(DataContext)

                    If CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default Then

                        RadioButtonForm_CoversheetTypeDefault.Checked = True
                        RadioButtonForm_CoversheetTypeAlternate.Checked = False

                    ElseIf CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Alternate Then

                        RadioButtonForm_CoversheetTypeDefault.Checked = False
                        RadioButtonForm_CoversheetTypeAlternate.Checked = True

                    End If

                    TextBoxForm_Title.Text = AdvantageFramework.InvoicePrinting.LoadCoversheetTitle(DataContext)

                    CoversheetContact = AdvantageFramework.InvoicePrinting.LoadCoversheetContact(DataContext)
                    ContactTypeID = AdvantageFramework.InvoicePrinting.LoadCoversheetContactType(DataContext)

                    If CoversheetContact = AdvantageFramework.InvoicePrinting.CoversheetContacts.None Then

                        RadioButtonContact_None.Checked = True
                        RadioButtonContact_ContactType.Checked = False
                        SearchableComboBoxContact_ContactType.Enabled = False
                        SearchableComboBoxContact_ContactType.SetRequired(False)
                        RadioButtonContact_FirstFound.Checked = False

                    ElseIf CoversheetContact = AdvantageFramework.InvoicePrinting.CoversheetContacts.ContactType Then

                        RadioButtonContact_None.Checked = False
                        RadioButtonContact_ContactType.Checked = True
                        SearchableComboBoxContact_ContactType.Enabled = True
                        SearchableComboBoxContact_ContactType.SetRequired(True)
                        RadioButtonContact_FirstFound.Checked = False

                    ElseIf CoversheetContact = AdvantageFramework.InvoicePrinting.CoversheetContacts.FirstFound Then

                        RadioButtonContact_None.Checked = False
                        RadioButtonContact_ContactType.Checked = False
                        SearchableComboBoxContact_ContactType.Enabled = False
                        SearchableComboBoxContact_ContactType.SetRequired(False)
                        RadioButtonContact_FirstFound.Checked = True

                    End If

                    If ContactTypeID > 0 Then

                        SearchableComboBoxContact_ContactType.EditValue = ContactTypeID

                    End If

                    CoversheetContactLocation = AdvantageFramework.InvoicePrinting.LoadCoversheetContactLocation(DataContext)

                    If CoversheetContactLocation = AdvantageFramework.InvoicePrinting.CoversheetContactLocations.AttnLine Then

                        RadioButtonContactLocation_AttnLine.Checked = True
                        RadioButtonContactLocation_AddressBlock.Checked = False

                    ElseIf CoversheetContactLocation = AdvantageFramework.InvoicePrinting.CoversheetContactLocations.AddressBlock Then

                        RadioButtonContactLocation_AttnLine.Checked = False
                        RadioButtonContactLocation_AddressBlock.Checked = True

                    End If

                End Using

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub InvoicePrintingCoversheetOptionsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub
        Private Sub InvoicePrintingCoversheetOptionsDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub InvoicePrintingCoversheetOptionsDialog_UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If RadioButtonForm_CoversheetTypeDefault.Checked Then

                        AdvantageFramework.InvoicePrinting.SaveCoversheetLayout(DataContext, AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default)

                    ElseIf RadioButtonForm_CoversheetTypeAlternate.Checked Then

                        AdvantageFramework.InvoicePrinting.SaveCoversheetLayout(DataContext, AdvantageFramework.InvoicePrinting.CoversheetLayouts.Alternate)

                    End If

                    AdvantageFramework.InvoicePrinting.SaveCoversheetTitle(DataContext, TextBoxForm_Title.Text)

                    If RadioButtonContact_None.Checked Then

                        AdvantageFramework.InvoicePrinting.SaveCoversheetContact(DataContext, AdvantageFramework.InvoicePrinting.CoversheetContacts.None)

                    ElseIf RadioButtonContact_ContactType.Checked Then

                        AdvantageFramework.InvoicePrinting.SaveCoversheetContact(DataContext, AdvantageFramework.InvoicePrinting.CoversheetContacts.ContactType)

                    ElseIf RadioButtonContact_FirstFound.Checked Then

                        AdvantageFramework.InvoicePrinting.SaveCoversheetContact(DataContext, AdvantageFramework.InvoicePrinting.CoversheetContacts.FirstFound)

                    End If

                    AdvantageFramework.InvoicePrinting.SaveCoversheetContactType(DataContext, SearchableComboBoxContact_ContactType.EditValue)

                    If RadioButtonContactLocation_AttnLine.Checked Then

                        AdvantageFramework.InvoicePrinting.SaveCoversheetContactLocation(DataContext, AdvantageFramework.InvoicePrinting.CoversheetContactLocations.AttnLine)

                    ElseIf RadioButtonContactLocation_AddressBlock.Checked Then

                        AdvantageFramework.InvoicePrinting.SaveCoversheetContactLocation(DataContext, AdvantageFramework.InvoicePrinting.CoversheetContactLocations.AddressBlock)

                    End If

                End Using

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonContact_None_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonContact_None.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonContact_ContactType_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonContact_ContactType.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonContact_FirstFound_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonContact_FirstFound.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
