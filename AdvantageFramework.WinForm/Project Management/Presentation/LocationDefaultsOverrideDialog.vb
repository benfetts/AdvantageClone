Namespace ProjectManagement.Presentation

    Public Class LocationDefaultsOverrideDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Location As AdvantageFramework.Database.Entities.Location = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByRef Location As AdvantageFramework.Database.Entities.Location)

            ' This call is required by the designer.
            InitializeComponent()

            _Location = Location

        End Sub
        Private Sub LoadLocationDefaults()

            If _Location IsNot Nothing Then

                LabelForm_LocationDetails.Text = _Location.ID & " - " & _Location.Name

                If _Location.LogoLocation = "N" Then

                    RadioButtonControlForm_Hide.Checked = True

                Else

                    RadioButtonControlForm_Show.Checked = True

                End If

                CheckBoxHeader_PrintHeader.Checked = CBool(_Location.PrintHeader.GetValueOrDefault(0))
                CheckBoxHeader_Name.Checked = CBool(_Location.PrintNameHeader.GetValueOrDefault(0))
                CheckBoxHeader_Addr1.Checked = CBool(_Location.PrintAddressHeader.GetValueOrDefault(0))
                CheckBoxHeader_Addr2.Checked = CBool(_Location.PrintAddress2Header.GetValueOrDefault(0))
                CheckBoxHeader_City.Checked = CBool(_Location.PrintCityHeader.GetValueOrDefault(0))
                CheckBoxHeader_State.Checked = CBool(_Location.PrintStateHeader.GetValueOrDefault(0))
                CheckBoxHeader_Zip.Checked = CBool(_Location.PrintZipHeader.GetValueOrDefault(0))
                CheckBoxHeader_Phone.Checked = CBool(_Location.PrintPhoneHeader.GetValueOrDefault(0))
                CheckBoxHeader_Fax.Checked = CBool(_Location.PrintFaxHeader.GetValueOrDefault(0))
                CheckBoxHeader_Email.Checked = CBool(_Location.PrintEmailHeader.GetValueOrDefault(0))

                CheckBoxFooter_PrintFooter.Checked = CBool(_Location.PrintFooter.GetValueOrDefault(0))
                CheckBoxFooter_Name.Checked = CBool(_Location.PrintNameFooter.GetValueOrDefault(0))
                CheckBoxFooter_Addr1.Checked = CBool(_Location.PrintAddressFooter.GetValueOrDefault(0))
                CheckBoxFooter_Addr2.Checked = CBool(_Location.PrintAddress2Footer.GetValueOrDefault(0))
                CheckBoxFooter_City.Checked = CBool(_Location.PrintCityFooter.GetValueOrDefault(0))
                CheckBoxFooter_State.Checked = CBool(_Location.PrintStateFooter.GetValueOrDefault(0))
                CheckBoxFooter_Zip.Checked = CBool(_Location.PrintZipFooter.GetValueOrDefault(0))
                CheckBoxFooter_Phone.Checked = CBool(_Location.PrintPhoneFooter.GetValueOrDefault(0))
                CheckBoxFooter_Fax.Checked = CBool(_Location.PrintFaxFooter.GetValueOrDefault(0))
                CheckBoxFooter_Email.Checked = CBool(_Location.PrintEmailFooter.GetValueOrDefault(0))

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef Location As AdvantageFramework.Database.Entities.Location) As System.Windows.Forms.DialogResult

            'objects
            Dim LocationDefaultsOverrideDialog As AdvantageFramework.ProjectManagement.Presentation.LocationDefaultsOverrideDialog = Nothing

            LocationDefaultsOverrideDialog = New AdvantageFramework.ProjectManagement.Presentation.LocationDefaultsOverrideDialog(Location)

            ShowFormDialog = LocationDefaultsOverrideDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub LocationDefaultsOverrideDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _Location IsNot Nothing Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                Me.ShowUnsavedChangesOnFormClosing = False
                Me.ByPassUserEntryChanged = True

                Try

                    LoadLocationDefaults()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

            Else

                AdvantageFramework.Navigation.ShowMessageBox("There was an error loading the location.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If Me.Validator Then

                If _Location IsNot Nothing Then

                    If RadioButtonControlForm_Hide.Checked Then

                        _Location.LogoLocation = "N"

                    Else

                        _Location.LogoLocation = "C"

                    End If

                    _Location.PrintHeader = Convert.ToInt64(CheckBoxHeader_PrintHeader.Checked)
                    _Location.PrintNameHeader = Convert.ToInt64(CheckBoxHeader_Name.Checked)
                    _Location.PrintAddressHeader = Convert.ToInt64(CheckBoxHeader_Addr1.Checked)
                    _Location.PrintAddress2Header = Convert.ToInt64(CheckBoxHeader_Addr2.Checked)
                    _Location.PrintCityHeader = Convert.ToInt64(CheckBoxHeader_City.Checked)
                    _Location.PrintStateHeader = Convert.ToInt64(CheckBoxHeader_State.Checked)
                    _Location.PrintZipHeader = Convert.ToInt64(CheckBoxHeader_Zip.Checked)
                    _Location.PrintPhoneHeader = Convert.ToInt64(CheckBoxHeader_Phone.Checked)
                    _Location.PrintFaxHeader = Convert.ToInt64(CheckBoxHeader_Fax.Checked)
                    _Location.PrintEmailHeader = Convert.ToInt64(CheckBoxHeader_Email.Checked)

                    _Location.PrintFooter = Convert.ToInt64(CheckBoxFooter_PrintFooter.Checked)
                    _Location.PrintNameFooter = Convert.ToInt64(CheckBoxFooter_Name.Checked)
                    _Location.PrintAddressFooter = Convert.ToInt64(CheckBoxFooter_Addr1.Checked)
                    _Location.PrintAddress2Footer = Convert.ToInt64(CheckBoxFooter_Addr2.Checked)
                    _Location.PrintCityFooter = Convert.ToInt64(CheckBoxFooter_City.Checked)
                    _Location.PrintStateFooter = Convert.ToInt64(CheckBoxFooter_State.Checked)
                    _Location.PrintZipFooter = Convert.ToInt64(CheckBoxFooter_Zip.Checked)
                    _Location.PrintPhoneFooter = Convert.ToInt64(CheckBoxFooter_Phone.Checked)
                    _Location.PrintFaxFooter = Convert.ToInt64(CheckBoxFooter_Fax.Checked)
                    _Location.PrintEmailFooter = Convert.ToInt64(CheckBoxFooter_Email.Checked)

                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace