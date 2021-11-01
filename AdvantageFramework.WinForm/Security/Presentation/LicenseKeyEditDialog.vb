Namespace Security.Presentation

	Public Class LicenseKeyEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _ClientCode As String = ""
        Private _LicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String, LicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ClientCode = ClientCode
            _LicenseKeyHistory = LicenseKeyHistory

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ClientCode As String, LicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory) As System.Windows.Forms.DialogResult

            'objects
            Dim LicenseKeyEditDialog As AdvantageFramework.Security.Presentation.LicenseKeyEditDialog = Nothing

            LicenseKeyEditDialog = New AdvantageFramework.Security.Presentation.LicenseKeyEditDialog(ClientCode, LicenseKeyHistory)

            ShowFormDialog = LicenseKeyEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub LicenseKeyEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			'objects
			Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

			TextBoxForm_AgencyName.MaxLength = 40

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

				If Client IsNot Nothing Then

					TextBoxForm_AgencyName.Text = Client.Name

				Else

					AdvantageFramework.WinForm.MessageBox.Show("The client you are trying to create license key for does not exist.")

					Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
					Me.Close()

				End If

			End Using

            If _LicenseKeyHistory IsNot Nothing Then

                TextBoxForm_AgencyName.Text = _LicenseKeyHistory.AgencyName

                NumericInputForm_PowerUsersQuantity.Value = _LicenseKeyHistory.PowerLicenseQuantity
                NumericInputForm_WVOnlyUsersQuantity.Value = _LicenseKeyHistory.WebvantageOnlyLicenseQuantity
                NumericInputForm_ClientPortalUsersQuantity.Value = _LicenseKeyHistory.ClientPortalLicenseQuantity
                NumericInputForm_MediaToolsUsersQuantity.Value = _LicenseKeyHistory.MediaToolsUsersQuantity
                NumericInputForm_APIUsersQuantity.Value = _LicenseKeyHistory.APIUsersQuantity

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonForm_Create_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Create.Click

			'objects
			Dim EncryptedLicenseKey As String = ""
			Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
			Dim Folder As String = ""
			Dim LicenseKeyExpireDate As Date = Nothing
			Dim CreatedDate As Date = Nothing
            Dim LicenseKeyHistoryRecordCreated As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

				If Employee IsNot Nothing Then

                    EncryptedLicenseKey = AdvantageFramework.Security.LicenseKey.Create(NumericInputForm_DaysUntilFileExpires.Value, NumericInputForm_DaysUntilKeyExpires.Value,
                                                                                        NumericInputForm_PowerUsersQuantity.Value, NumericInputForm_WVOnlyUsersQuantity.Value,
                                                                                        NumericInputForm_ClientPortalUsersQuantity.Value, TextBoxForm_AgencyName.Text, 0,
                                                                                        NumericInputForm_MediaToolsUsersQuantity.Value, NumericInputForm_APIUsersQuantity.Value,
                                                                                        CheckBoxForm_EnableProofingTool.Checked)

                    If EncryptedLicenseKey <> "" Then

                        LicenseKeyExpireDate = Now.AddDays(NumericInputForm_DaysUntilKeyExpires.Value)

                        CreatedDate = Now

                        Try

                            If DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO " &
                                                                                  "[dbo].[LicenseKeyHistory]([ClientCode], [AgencyName], [UserCode], [EmployeeCode], [EmployeeName], " &
                                                                                  "[CreatedDate], [DaysUntilFileExpires], [DaysUntilKeyExpires], " &
                                                                                  "[PowerLicenseQuantity], [WebvantageOnlyLicenseQuantity], " &
                                                                                  "[ClientPortalLicenseQuantity], [IsActive], [DeactivatedDate], " &
                                                                                  "[Comment], [EncrpytedLicenseKey], [MediaToolsUsersQuantity], [APIUsersQuantity]) " &
                                                                                  "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', " &
                                                                                  "'{5}', {6}, {7}, " &
                                                                                  "{8}, {9}, " &
                                                                                  "{10}, {11}, '{12}', " &
                                                                                  "'{13}', '{14}', {15}, {16})",
                                                                                _ClientCode, TextBoxForm_AgencyName.Text.Replace("'", "`"), Me.Session.UserCode, Employee.Code, Employee.ToString,
                                                                                CreatedDate, NumericInputForm_DaysUntilFileExpires.Value, NumericInputForm_DaysUntilKeyExpires.Value,
                                                                                NumericInputForm_PowerUsersQuantity.Value, NumericInputForm_WVOnlyUsersQuantity.Value,
                                                                                NumericInputForm_ClientPortalUsersQuantity.Value, 1, LicenseKeyExpireDate.ToShortDateString,
                                                                                TextBoxForm_Comment.Text.Replace("'", "`"), EncryptedLicenseKey, NumericInputForm_MediaToolsUsersQuantity.Value,
                                                                                NumericInputForm_APIUsersQuantity.Value)) > 0 Then

                                LicenseKeyHistoryRecordCreated = True

                            Else

                                LicenseKeyHistoryRecordCreated = False
                                AdvantageFramework.WinForm.MessageBox.Show("Creating LicenseKeyHistory failed")

                            End If

                        Catch ex As Exception
                            LicenseKeyHistoryRecordCreated = False
                            AdvantageFramework.WinForm.MessageBox.Show("Creating LicenseKeyHistory failed" &
                                                                       Environment.NewLine &
                                                                       AdvantageFramework.StringUtilities.FullErrorToString(ex))
                        End Try

                        If LicenseKeyHistoryRecordCreated = True Then

                            Try

                                DbContext.Database.ExecuteSqlCommand("UPDATE [dbo].[LicenseKeyHistory] " &
                                                                     "SET [IsActive] = 0, [DeactivatedDate] = '" & Now & "' " &
                                                                     "WHERE [ClientCode] = '" & _ClientCode & "' AND " &
                                                                     "[AgencyName]  = '" & TextBoxForm_AgencyName.Text.Replace("'", "`") & "' AND " &
                                                                     "[CreatedDate] <> '" & CreatedDate.ToString & "'")

                            Catch ex As Exception
                                AdvantageFramework.WinForm.MessageBox.Show("Update LicenseKeyHistory failed" &
                                                                           Environment.NewLine &
                                                                           AdvantageFramework.StringUtilities.FullErrorToString(ex))
                            End Try

                        End If

                        If CheckBoxForm_CreateFileAfterKeyCreated.Checked Then

                            If AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder) Then

                                My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\") & "LicenseKey_" & _ClientCode & "_" & Now.ToString("MMddyyyy") & ".advlic", EncryptedLicenseKey, False)

                            End If

                        End If

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Creating encrypted license key failed")

                    End If

				Else

					AdvantageFramework.WinForm.MessageBox.Show("Creating license key failed")

				End If

			End Using

		End Sub
		Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Close()

		End Sub
		'Private Sub NumericInputForm_PowerUsersQuantity_LockUpdateChanged(sender As Object, e As System.EventArgs) Handles NumericInputForm_PowerUsersQuantity.ch

		'    If NumericInputForm_PowerUsersQuantity.LockUpdateChecked Then

		'        NumericInputForm_PowerUsersQuantity.MinValue = 0
		'        NumericInputForm_PowerUsersQuantity.Value = 0

		'    Else

		'        NumericInputForm_PowerUsersQuantity.MinValue = -1
		'        NumericInputForm_PowerUsersQuantity.Value = -1

		'    End If

		'End Sub
		'Private Sub NumericInputForm_WVOnlyUsersQuantity_LockUpdateChanged(sender As Object, e As System.EventArgs) Handles NumericInputForm_WVOnlyUsersQuantity.LockUpdateChanged

		'    If NumericInputForm_WVOnlyUsersQuantity.LockUpdateChecked Then

		'        NumericInputForm_WVOnlyUsersQuantity.MinValue = 0
		'        NumericInputForm_WVOnlyUsersQuantity.Value = 0

		'    Else

		'        NumericInputForm_WVOnlyUsersQuantity.MinValue = -1
		'        NumericInputForm_WVOnlyUsersQuantity.Value = -1

		'    End If

		'End Sub
		'Private Sub NumericInputForm_ClientPortalUsersQuantity_LockUpdateChanged(sender As Object, e As System.EventArgs) Handles NumericInputForm_ClientPortalUsersQuantity.LockUpdateChanged

		'    If NumericInputForm_ClientPortalUsersQuantity.LockUpdateChecked Then

		'        NumericInputForm_ClientPortalUsersQuantity.MinValue = 0
		'        NumericInputForm_ClientPortalUsersQuantity.Value = 0

		'    Else

		'        NumericInputForm_ClientPortalUsersQuantity.MinValue = -1
		'        NumericInputForm_ClientPortalUsersQuantity.Value = -1

		'    End If

		'End Sub
		'Private Sub NumericInputForm_MediaToolsUsersQuantity_LockUpdateChanged(sender As Object, e As System.EventArgs) Handles NumericInputForm_MediaToolsUsersQuantity.LockUpdateChanged

		'    If NumericInputForm_MediaToolsUsersQuantity.LockUpdateChecked Then

		'        NumericInputForm_MediaToolsUsersQuantity.MinValue = 0
		'        NumericInputForm_MediaToolsUsersQuantity.Value = 0

		'    Else

		'        NumericInputForm_MediaToolsUsersQuantity.MinValue = -1
		'        NumericInputForm_MediaToolsUsersQuantity.Value = -1

		'    End If

		'End Sub
		'Private Sub NumericInputForm_APIUsersQuantity_LockUpdateChanged(sender As Object, e As System.EventArgs) Handles NumericInputForm_APIUsersQuantity.LockUpdateChanged

		'    If NumericInputForm_APIUsersQuantity.LockUpdateChecked Then

		'        NumericInputForm_APIUsersQuantity.MinValue = 0
		'        NumericInputForm_APIUsersQuantity.Value = 0

		'    Else

		'        NumericInputForm_APIUsersQuantity.MinValue = -1
		'        NumericInputForm_APIUsersQuantity.Value = -1

		'    End If

		'End Sub

#End Region

#End Region

	End Class

End Namespace
