Namespace WinForm.MVC.Presentation.Controls.Classes

	Public Class PrintingSystemCommandHandler
		Implements DevExpress.XtraPrinting.ICommandHandler

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _Session As AdvantageFramework.Security.Session = Nothing
		Private _AgencyImportPath As String = ""
		Private _ItemDescription As String = ""
		Private _AddDateInfoToFileName As Boolean = True

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Public Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal AgencyImportPath As String, ByVal ItemDescription As String, Optional AddDateInfoToFileName As Boolean = True)

			_Session = Session
			_AgencyImportPath = AgencyImportPath
			_ItemDescription = ItemDescription
			_AddDateInfoToFileName = AddDateInfoToFileName

		End Sub
		Public Overridable Function CanHandleCommand(ByVal PrintingSystemCommand As DevExpress.XtraPrinting.PrintingSystemCommand, PrintControl As DevExpress.XtraPrinting.IPrintControl) As Boolean Implements DevExpress.XtraPrinting.ICommandHandler.CanHandleCommand

			If PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.Save Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportCsv Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportGraphic Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportMht Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportPdf Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportRtf Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportTxt Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXlsx Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.Open Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendCsv Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendGraphic Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendMht Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendPdf Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendRtf Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendTxt Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendXls Then

				CanHandleCommand = True

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendXlsx Then

				CanHandleCommand = True

			Else

				CanHandleCommand = False

			End If

		End Function
		Public Overridable Sub HandleCommand(ByVal PrintingSystemCommand As DevExpress.XtraPrinting.PrintingSystemCommand, ByVal Args() As Object, PrintControl As DevExpress.XtraPrinting.IPrintControl, ByRef Handled As Boolean) Implements DevExpress.XtraPrinting.ICommandHandler.HandleCommand

			'objects
			Dim Saved As Boolean = True
			Dim File As String = ""
			Dim Files() As String = Nothing
			Dim AgencyImportPath As String = Nothing
			Dim DefaultFileName As String = Nothing
			Dim ToRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
			Dim CcRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
			Dim BccRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
			Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.EmailSent
			Dim ErrorMessage As String = ""
			Dim [To] As String = Nothing
			Dim [Cc] As String = Nothing
			Dim [Bcc] As String = Nothing
			Dim EmailSent As Boolean = False
			Dim CsvExportOptions As DevExpress.XtraPrinting.CsvExportOptions = Nothing
			Dim ImageExportOptions As DevExpress.XtraPrinting.ImageExportOptions = Nothing
			Dim MhtExportOptions As DevExpress.XtraPrinting.MhtExportOptions = Nothing
			Dim PdfExportOptions As DevExpress.XtraPrinting.PdfExportOptions = Nothing
			Dim RtfExportOptions As DevExpress.XtraPrinting.RtfExportOptions = Nothing
			Dim TextExportOptions As DevExpress.XtraPrinting.TextExportOptions = Nothing
			Dim XlsExportOptions As DevExpress.XtraPrinting.XlsExportOptions = Nothing
			Dim XlsxExportOptions As DevExpress.XtraPrinting.XlsxExportOptions = Nothing
            Dim ContinueSending As Boolean = False
            Dim EmailSubject As String = Nothing
            Dim EmailBody As String = Nothing

            Handled = True

            EmailSubject = _ItemDescription

            If _AddDateInfoToFileName Then

				_ItemDescription = AdvantageFramework.FileSystem.CreateValidFileName(_ItemDescription) & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")

			Else

				_ItemDescription = AdvantageFramework.FileSystem.CreateValidFileName(_ItemDescription)

			End If

			If PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.Save Then

				Try

					PrintControl.PrintingSystem.SaveDocument(_AgencyImportPath & _ItemDescription & ".prnx")

				Catch ex As Exception
					Saved = False
				End Try

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportCsv Then

				Try

					CsvExportOptions = New DevExpress.XtraPrinting.CsvExportOptions

					If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(CsvExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

						PrintControl.PrintingSystem.ExportToCsv(_AgencyImportPath & _ItemDescription & ".csv", CsvExportOptions)

					End If

				Catch ex As Exception
					Saved = False
				End Try

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportGraphic Then

				Try

					ImageExportOptions = New DevExpress.XtraPrinting.ImageExportOptions

					If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(ImageExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

						PrintControl.PrintingSystem.ExportToImage(_AgencyImportPath & _ItemDescription & ".jpg", ImageExportOptions)

					End If

				Catch ex As Exception
					Saved = False
				End Try

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportMht Then

				Try

					MhtExportOptions = New DevExpress.XtraPrinting.MhtExportOptions

					If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(MhtExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

						PrintControl.PrintingSystem.ExportToMht(_AgencyImportPath & _ItemDescription & ".mht", MhtExportOptions)

					End If

				Catch ex As Exception
					Saved = False
				End Try

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportPdf Then

				Try

					PdfExportOptions = New DevExpress.XtraPrinting.PdfExportOptions

					If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(PdfExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

						PrintControl.PrintingSystem.ExportToPdf(_AgencyImportPath & _ItemDescription & ".pdf", PdfExportOptions)

					End If

				Catch ex As Exception
					Saved = False
				End Try

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportRtf Then

				Try

					RtfExportOptions = New DevExpress.XtraPrinting.RtfExportOptions

					If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(RtfExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

						PrintControl.PrintingSystem.ExportToRtf(_AgencyImportPath & _ItemDescription & ".rtf", RtfExportOptions)

					End If

				Catch ex As Exception
					Saved = False
				End Try

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportTxt Then

				Try

					TextExportOptions = New DevExpress.XtraPrinting.TextExportOptions

					If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(TextExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

						PrintControl.PrintingSystem.ExportToText(_AgencyImportPath & _ItemDescription & ".txt", TextExportOptions)

					End If

				Catch ex As Exception
					Saved = False
				End Try

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls Then

				Try

					XlsExportOptions = New DevExpress.XtraPrinting.XlsExportOptions

					If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(XlsExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

						PrintControl.PrintingSystem.ExportToXls(_AgencyImportPath & _ItemDescription & ".xls", XlsExportOptions)

					End If

				Catch ex As Exception
					Saved = False
				End Try

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXlsx Then

				Try

					XlsxExportOptions = New DevExpress.XtraPrinting.XlsxExportOptions

					If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(XlsxExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

						PrintControl.PrintingSystem.ExportToXlsx(_AgencyImportPath & _ItemDescription & ".xlsx", XlsxExportOptions)

					End If

				Catch ex As Exception
					Saved = False
				End Try

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.Open Then

				If AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyImportPath, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({FileSystem.FileFilters.PRNX}), False, Files) = Windows.Forms.DialogResult.OK Then

					Try

						File = Files(0)

					Catch ex As Exception
						File = ""
					End Try

					PrintControl.PrintingSystem.LoadDocument(File)

				End If

			ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendCsv OrElse
						PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendGraphic OrElse
						PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendMht OrElse
						PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendPdf OrElse
						PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendRtf OrElse
						PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendTxt OrElse
						PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendXls OrElse
						PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendXlsx OrElse
						PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendXps Then

				If PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendCsv Then

					Try

						CsvExportOptions = New DevExpress.XtraPrinting.CsvExportOptions

						If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(CsvExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

							ContinueSending = True

						End If

					Catch ex As Exception
						Saved = False
					End Try

				ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendGraphic Then

					Try

						ImageExportOptions = New DevExpress.XtraPrinting.ImageExportOptions

						If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(ImageExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

							ContinueSending = True

						End If

					Catch ex As Exception
						Saved = False
					End Try

				ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendMht Then

					Try

						MhtExportOptions = New DevExpress.XtraPrinting.MhtExportOptions

						If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(MhtExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

							ContinueSending = True

						End If

					Catch ex As Exception
						Saved = False
					End Try

				ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendPdf Then

					Try

						PdfExportOptions = New DevExpress.XtraPrinting.PdfExportOptions

						If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(PdfExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

							ContinueSending = True

						End If

					Catch ex As Exception
						Saved = False
					End Try

				ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendRtf Then

					Try

						RtfExportOptions = New DevExpress.XtraPrinting.RtfExportOptions

						If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(RtfExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

							ContinueSending = True

						End If

					Catch ex As Exception
						Saved = False
					End Try

				ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendTxt Then

					Try

						TextExportOptions = New DevExpress.XtraPrinting.TextExportOptions

						If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(TextExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

							ContinueSending = True

						End If

					Catch ex As Exception
						Saved = False
					End Try

				ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendXls Then

					Try

						XlsExportOptions = New DevExpress.XtraPrinting.XlsExportOptions

						If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(XlsExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

							ContinueSending = True

						End If

					Catch ex As Exception
						Saved = False
					End Try

				ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendXlsx Then

					Try

						XlsxExportOptions = New DevExpress.XtraPrinting.XlsxExportOptions

						If DevExpress.XtraPrinting.ExportOptionsTool.EditExportOptions(XlsxExportOptions, PrintControl.PrintingSystem) = Windows.Forms.DialogResult.OK Then

							ContinueSending = True

						End If

					Catch ex As Exception
						Saved = False
					End Try

				End If

                If ContinueSending AndAlso AdvantageFramework.WinForm.Presentation.EmailRecipientDialog.ShowFormDialog(ToRecipients, CcRecipients, BccRecipients, EmailSubject, EmailBody) = Windows.Forms.DialogResult.OK Then

                    If ToRecipients IsNot Nothing AndAlso ToRecipients.Count > 0 Then

                        [To] = Join(ToRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    If CcRecipients IsNot Nothing AndAlso CcRecipients.Count > 0 Then

                        [Cc] = Join(CcRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    If BccRecipients IsNot Nothing AndAlso BccRecipients.Count > 0 Then

                        [Bcc] = Join(BccRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    If PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendCsv Then

                        Try

                            DefaultFileName = _AgencyImportPath & _ItemDescription & ".csv"
                            PrintControl.PrintingSystem.ExportToCsv(DefaultFileName, CsvExportOptions)

                        Catch ex As Exception
                            Saved = False
                        End Try

                    ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendGraphic Then

                        Try

                            DefaultFileName = _AgencyImportPath & _ItemDescription & ".jpg"
                            PrintControl.PrintingSystem.ExportToImage(DefaultFileName, ImageExportOptions)

                        Catch ex As Exception
                            Saved = False
                        End Try

                    ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendMht Then

                        Try

                            DefaultFileName = _AgencyImportPath & _ItemDescription & ".mht"
                            PrintControl.PrintingSystem.ExportToMht(DefaultFileName, MhtExportOptions)

                        Catch ex As Exception
                            Saved = False
                        End Try

                    ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendPdf Then

                        Try

                            DefaultFileName = _AgencyImportPath & _ItemDescription & ".pdf"
                            PrintControl.PrintingSystem.ExportToPdf(DefaultFileName, PdfExportOptions)

                        Catch ex As Exception
                            Saved = False
                        End Try

                    ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendRtf Then

                        Try

                            DefaultFileName = _AgencyImportPath & _ItemDescription & ".rtf"
                            PrintControl.PrintingSystem.ExportToRtf(DefaultFileName, RtfExportOptions)

                        Catch ex As Exception
                            Saved = False
                        End Try

                    ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendTxt Then

                        Try

                            DefaultFileName = _AgencyImportPath & _ItemDescription & ".txt"
                            PrintControl.PrintingSystem.ExportToText(DefaultFileName, TextExportOptions)

                        Catch ex As Exception
                            Saved = False
                        End Try

                    ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendXls Then

                        Try

                            DefaultFileName = _AgencyImportPath & _ItemDescription & ".xls"
                            PrintControl.PrintingSystem.ExportToXls(DefaultFileName, XlsExportOptions)

                        Catch ex As Exception
                            Saved = False
                        End Try

                    ElseIf PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.SendXlsx Then

                        Try

                            DefaultFileName = _AgencyImportPath & _ItemDescription & ".xlsx"
                            PrintControl.PrintingSystem.ExportToXlsx(DefaultFileName, XlsxExportOptions)

                        Catch ex As Exception
                            Saved = False
                        End Try

                    End If

                    If Saved Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            EmailSent = AdvantageFramework.Email.Send(DbContext, [To], [Cc], [Bcc], EmailSubject, EmailBody, 3, New String() {DefaultFileName}, SendingEmailStatus, ErrorMessage, False)

                        End Using

                        If My.Computer.FileSystem.FileExists(DefaultFileName) Then

                            My.Computer.FileSystem.DeleteFile(DefaultFileName)

                        End If

                    End If

                End If

            Else

				Handled = False

			End If

			If Handled Then

				If PrintingSystemCommand <> DevExpress.XtraPrinting.PrintingSystemCommand.Open Then

					If Saved Then

						If PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.Save Then

							AdvantageFramework.WinForm.MessageBox.Show("Document saved!")

						Else

							If PrintingSystemCommand.ToString.StartsWith("Send") Then

								If EmailSent Then

									AdvantageFramework.WinForm.MessageBox.Show("Document sent!")

								Else

									If SendingEmailStatus <> Email.SendingEmailStatus.EmailSent Then

										AdvantageFramework.WinForm.MessageBox.Show(AdvantageFramework.Email.LoadEmailErrorMessage(SendingEmailStatus))

									ElseIf String.IsNullOrEmpty(ErrorMessage) = False Then

										AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

									Else

										AdvantageFramework.WinForm.MessageBox.Show("Failed creating or sending document.  Please contact software support.")

									End If

								End If

							Else

								AdvantageFramework.WinForm.MessageBox.Show("Document exported!")

							End If

						End If

					Else

						If PrintingSystemCommand = DevExpress.XtraPrinting.PrintingSystemCommand.Save Then

							AdvantageFramework.WinForm.MessageBox.Show("Failed to save the document.")

						Else

							If PrintingSystemCommand.ToString.StartsWith("Send") Then

								AdvantageFramework.WinForm.MessageBox.Show("Failed to send the document.")

							Else

								AdvantageFramework.WinForm.MessageBox.Show("Failed to export the document.")

							End If

						End If

					End If

				End If

			End If

		End Sub

#End Region

	End Class

End Namespace

