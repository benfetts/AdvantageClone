Namespace Database.Presentation

	Public Class DatabaseUpdateForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _InternalOnlyMode As Boolean = False
		Private WithEvents _BackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing
		Private _BatchMode As Boolean = False
		Private _SetTextDelegate As AdvantageFramework.WinForm.Presentation.Controls.SetTextOnTextBoxControlDelegate = Nothing
		Private _Lines As Generic.List(Of String) = Nothing
		Private _StreamReader As System.IO.StreamReader = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New(ByVal InternalOnlyMode As Boolean, ByVal BatchMode As Boolean, ByVal StreamReader As System.IO.StreamReader)

			' This call is required by the designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_InternalOnlyMode = InternalOnlyMode
			RadTreeViewForm_Updates.CheckBoxes = _InternalOnlyMode

			_BatchMode = BatchMode
			_StreamReader = StreamReader

		End Sub
		Private Sub LoadScriptUpdates()

			'objects
			Dim ParentRadTreeNode As Telerik.WinControls.UI.RadTreeNode = Nothing
			Dim RadTreeNode As Telerik.WinControls.UI.RadTreeNode = Nothing
			Dim DirectoryInfoList As Generic.List(Of System.IO.DirectoryInfo) = Nothing
			Dim ProgressValue As Integer = 0
			Dim DatabaseVersion As String = ""
			Dim ReleaseDatabaseVersion As String = ""
			Dim UnappliedDatabaseChangesList As Generic.List(Of System.IO.FileInfo) = Nothing

			RadTreeViewForm_Updates.Nodes.Clear()

			Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

				Try

					DatabaseVersion = SecurityDbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

				Catch ex As Exception
					DatabaseVersion = ""
				End Try

			End Using

			If DatabaseVersion <> "" Then

				If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Scripts") Then

					ReleaseDatabaseVersion = If(DatabaseVersion.Length = 11, DatabaseVersion.Substring(0, DatabaseVersion.Length - 3), DatabaseVersion)

					DirectoryInfoList = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath & "\Scripts").GetDirectories.ToList

					TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetupProgressBar(0, DirectoryInfoList.Count, 0)

					Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

						DbContext.Database.Connection.Open()

						For Each DirectoryInfo In DirectoryInfoList

							If _InternalOnlyMode OrElse AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DirectoryInfo.Name) >= AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ReleaseDatabaseVersion) OrElse
									DirectoryInfo.Name = "vX.XX.XX" Then

								UnappliedDatabaseChangesList = New Generic.List(Of System.IO.FileInfo)

								ParentRadTreeNode = New Telerik.WinControls.UI.RadTreeNode

								ParentRadTreeNode.Checked = True

								If DirectoryInfo.Name = "vX.XX.XX" Then

									ParentRadTreeNode.Text = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00")

								Else

									ParentRadTreeNode.Text = DirectoryInfo.Name

								End If

								RadTreeViewForm_Updates.Nodes.Add(ParentRadTreeNode)

								AdvantageFramework.Security.LoadDirectoryScripts(Me.Session, UnappliedDatabaseChangesList, DirectoryInfo, DbContext, ParentRadTreeNode.Text)

								If UnappliedDatabaseChangesList.Count = 0 Then

									RadTreeViewForm_Updates.Nodes.Remove(ParentRadTreeNode)

								Else

									For Each FileInfo In UnappliedDatabaseChangesList

										RadTreeNode = New Telerik.WinControls.UI.RadTreeNode

										RadTreeNode.Checked = True
										RadTreeNode.Text = FileInfo.Name.Replace(".advenc", "").Replace(".sql", "").Replace(".xml", "")
										RadTreeNode.Tag = FileInfo

										ParentRadTreeNode.Nodes.Add(RadTreeNode)

									Next

								End If

							End If

							ProgressValue += 1

							TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetProgressBarValue(ProgressValue)

						Next

						DbContext.Database.Connection.Close()

					End Using

				End If

			End If

            If RadTreeViewForm_Updates.Nodes.Count = 0 Then

                ButtonItemActions_Process.Enabled = False
                ButtonItemView_ExpandAll.Enabled = False
                ButtonItemView_CollapseAll.Enabled = False

            Else

                ButtonItemActions_Process.Enabled = True
                ButtonItemView_ExpandAll.Enabled = True
                ButtonItemView_CollapseAll.Enabled = True

            End If

            TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CloseProgressBar()

		End Sub
		'Private Sub LoadDirectoryScripts(ByVal DirectoryInfo As System.IO.DirectoryInfo, ByVal ParentRadTreeNode As Telerik.WinControls.UI.RadTreeNode, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext)

		'    'objects
		'    Dim RadTreeNode As Telerik.WinControls.UI.RadTreeNode = Nothing

		'    For Each SubDirectoryInfo In DirectoryInfo.GetDirectories

		'        LoadDirectoryScripts(SubDirectoryInfo, ParentRadTreeNode, SecurityDbContext)

		'    Next

		'    For Each FileInfo In DirectoryInfo.GetFiles.Where(Function(FileIn) FileIn.Extension.ToUpper = ".SQL" OrElse FileIn.Extension.ToUpper = ".ADVENC")

		'        If SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.DB_UPDATE WHERE FUNCTION_NAME = '{0}'", FileInfo.Name.Replace(".advenc", "").Replace(".sql", "") & "_" & FileInfo.LastWriteTime.ToString("yyyyMMddHHmmss"))).FirstOrDefault = 0 Then

		'            RadTreeNode = New Telerik.WinControls.UI.RadTreeNode

		'            RadTreeNode.Checked = True
		'            RadTreeNode.Text = FileInfo.Name.Replace(".advenc", "").Replace(".sql", "")
		'            RadTreeNode.Tag = FileInfo

		'            ParentRadTreeNode.Nodes.Add(RadTreeNode)

		'        End If

		'    Next

		'End Sub
		Private Function LoadCheckedNodes(ByVal RadTreeNodes As Telerik.WinControls.UI.RadTreeNodeCollection) As Generic.List(Of Telerik.WinControls.UI.RadTreeNode)

			'objects
			Dim RadTreeNodeList As Generic.List(Of Telerik.WinControls.UI.RadTreeNode) = Nothing

			RadTreeNodeList = New Generic.List(Of Telerik.WinControls.UI.RadTreeNode)

			For Each Node In RadTreeNodes

				If Node.Checked AndAlso Node.Tag IsNot Nothing AndAlso TypeOf Node.Tag Is System.IO.FileInfo Then

					RadTreeNodeList.Add(Node)

				End If

				If Node.Nodes.Count > 0 Then

					RadTreeNodeList.AddRange(LoadCheckedNodes(Node.Nodes))

				End If

			Next

			LoadCheckedNodes = RadTreeNodeList

		End Function
		Private Sub CheckChildNodes(ByVal Node As Telerik.WinControls.UI.RadTreeNode, ByVal Checked As Boolean)

			For Each ChildNode In Node.Nodes

				ChildNode.Checked = Checked

				If ChildNode.Nodes.Count > 0 Then

					CheckChildNodes(ChildNode, Checked)

				End If

			Next

		End Sub
		Private Function CheckToSeeIfUserWantsToBackupDatabase() As Boolean

			'objects
			Dim DatabaseHasBeenBackedUp As Boolean = True
			Dim BackupFolder As String = ""
			Dim BackupDatabaseError As String = ""
			Dim StreamWriter As System.IO.StreamWriter = Nothing

			If _BatchMode = False Then

				If AdvantageFramework.Navigation.ShowMessageBox("Has the database been backed up?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

					If AdvantageFramework.Navigation.ShowMessageBox("Do you want to backup the database now?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

						If AdvantageFramework.WinForm.Presentation.BrowseForFolder(BackupFolder) Then

							TextBoxForm_UpdateLog.Text &= "Backing up database..." & vbNewLine

							Me.ShowWaitForm()
							Me.ShowWaitForm("Processing...")

							Try

								Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

									If My.Computer.FileSystem.FileExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(BackupFolder, "\") & Me.Session.DatabaseName & ".bak") Then

										My.Computer.FileSystem.DeleteFile(AdvantageFramework.StringUtilities.AppendTrailingCharacter(BackupFolder, "\") & Me.Session.DatabaseName & ".bak")

									End If

									StreamWriter = New System.IO.StreamWriter(AdvantageFramework.StringUtilities.AppendTrailingCharacter(BackupFolder, "\") & Me.Session.DatabaseName & ".bak", False)

									StreamWriter.Close()

									StreamWriter.Dispose()

									StreamWriter = Nothing

									Try

										SecurityDbContext.Database.ExecuteSqlCommand(String.Format("BACKUP DATABASE {0} TO DISK='{1}'", Me.Session.DatabaseName, AdvantageFramework.StringUtilities.AppendTrailingCharacter(BackupFolder, "\") & Me.Session.DatabaseName & ".bak"))

									Catch ex As Exception
										BackupDatabaseError = "Backing up the database failed --> " & ex.Message & vbNewLine
										DatabaseHasBeenBackedUp = False
									End Try

								End Using

							Catch ex As Exception

							End Try

							Me.CloseWaitForm()

							If DatabaseHasBeenBackedUp Then

								TextBoxForm_UpdateLog.Text &= BackupDatabaseError

							End If

						Else

							TextBoxForm_UpdateLog.Text &= "Backing up the database failed --> user failed to select folder" & vbNewLine
							DatabaseHasBeenBackedUp = False

						End If

					Else

						TextBoxForm_UpdateLog.Text &= "Backing up the database failed --> database has not been backed up" & vbNewLine
						DatabaseHasBeenBackedUp = False

					End If

				End If

				If DatabaseHasBeenBackedUp = False Then

					AdvantageFramework.Navigation.ShowMessageBox("Please backup your database before updating.")

				Else

					TextBoxForm_UpdateLog.Text &= "Backing up the database complete..." & vbNewLine

				End If

			End If

			CheckToSeeIfUserWantsToBackupDatabase = DatabaseHasBeenBackedUp

		End Function
		Private Sub ExecuteText(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ScriptText As String, ByRef FirstExecution As Boolean, ByVal NodeText As String)

			If FirstExecution Then

				FirstExecution = False

				If NodeText.Contains(".proc") Then

					SecurityDbContext.Database.ExecuteSqlCommand(String.Format("IF OBJECT_ID( N'[dbo].[{0}]', 'P' ) IS NOT NULL " & vbCrLf &
																				"DROP PROCEDURE [dbo].[{0}]", NodeText.Replace(".proc", "")))

				ElseIf NodeText.Contains(".function") Then

					SecurityDbContext.Database.ExecuteSqlCommand(String.Format("IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[{0}]' ) AND xtype IN ( N'FN', N'IF', N'TF' )) " & vbCrLf &
																				"DROP FUNCTION [dbo].[{0}]", NodeText.Replace(".function", "")))

				ElseIf NodeText.Contains(".view") Then

					SecurityDbContext.Database.ExecuteSqlCommand(String.Format("IF OBJECT_ID( N'[dbo].[{0}]', 'V' ) IS NOT NULL " & vbCrLf &
																				"DROP VIEW [dbo].[{0}]", NodeText.Replace(".view", "")))

				End If

			End If

			SetLogText("Executing text...")

			SecurityDbContext.Database.ExecuteSqlCommand(ScriptText)

			SetLogText("Executed successfully...")

		End Sub
		Private Sub LoadVersionNumbers()

			Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

				Try

					LabelForm_AdvantageVersionNumber.Text = SecurityDbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault

				Catch ex As Exception
					LabelForm_AdvantageVersionNumber.Text = ""
				End Try

				Try

					LabelForm_WebvantageVersionNumber.Text = SecurityDbContext.Database.SqlQuery(Of String)("SELECT WEBVAN_VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault

				Catch ex As Exception
					LabelForm_AdvantageVersionNumber.Text = ""
				End Try

			End Using

		End Sub
		Private Sub UpdateCustomReportImportProgress(ByVal StatusMessage As String, ByVal OverallProgress As Integer, ByVal CurrentActionProgress As Integer)

			SetLogText(StatusMessage)

			TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetProgressBarValue(OverallProgress)

		End Sub
		Private Sub ResetCustomReportImportOverallProgressValues(ByVal Minimum As Integer, ByVal Maximum As Integer, ByVal StartValue As Integer)

			TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetupProgressBar(Minimum, Maximum, StartValue)

		End Sub
		Private Sub SetLogText(ByVal LogText As String)

			_Lines.Insert(0, LogText)

			If _Lines.Count > 100 Then

				_Lines.RemoveAt(100)

			End If

			TextBoxForm_UpdateLog.Invoke(_SetTextDelegate, New Object() {TextBoxForm_UpdateLog, Join(_Lines.ToArray, vbNewLine)})

		End Sub
		Private Sub CreateOrUpdateMenuItem(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByRef FirstExecution As Boolean, ByVal NodeText As String, ByVal MenuBuilder As AdvantageFramework.Security.Classes.MenuBuilder, ByVal MenuBuilders As Generic.List(Of AdvantageFramework.Security.Classes.MenuBuilder), ByVal InMenuUpdateModuleCodes As Generic.List(Of String))

			'objects
			Dim ScriptText As String = ""

			For Each Application In MenuBuilder.Applications

				ScriptText &= vbNewLine & "EXEC [dbo].[advsp_sec_module_create] " &
																				"" & Application & ", " &
																				"'" & MenuBuilder.Code & "', " &
																				"'" & MenuBuilder.Description & "', " &
																				"" & Convert.ToInt16(MenuBuilder.IsInactive) & ", " &
																				"" & Convert.ToInt16(MenuBuilder.IsMenuItem) & ", " &
																				"" & Convert.ToInt16(MenuBuilder.IsCategory) & ", " &
																				"" & Convert.ToInt16(MenuBuilder.IsApplication) & ", " &
																				"" & Convert.ToInt16(MenuBuilder.IsReport) & ", " &
																				"" & Convert.ToInt16(MenuBuilder.IsDesktopObject) & ", " &
																				"" & Convert.ToInt16(MenuBuilder.IsDashQuery) & ", " &
																				"'" & MenuBuilder.ParentModuleCode & "', " &
																				"'" & MenuBuilder.ImageName & "', " &
																				"" & Convert.ToInt16(MenuBuilders.IndexOf(MenuBuilder)) & ", " &
																				"" & Convert.ToInt16(MenuBuilder.HasCustomPermission) & ", " &
																				"'" & MenuBuilder.WebvantageURL & "', " &
																				"'" & MenuBuilder.WebvantageImagePathActive & "', " &
																				"'" & MenuBuilder.WebvantageImagePath & "', " &
																				"'" & MenuBuilder.ApplicationName & "', " &
																				"'" & MenuBuilder.MenuName & "', " &
																				"'" & MenuBuilder.ApplicationCode & "', " &
																				"'" & MenuBuilder.CommandString & "', " &
																				"" & Convert.ToInt16(MenuBuilder.IconIndex) & ", " &
																				"" & Convert.ToInt16(MenuBuilder.AllowMultipleInstances) & ", " &
																				"'" & MenuBuilder.DesktopObjectName & "', " &
																				"" & Convert.ToInt16(MenuBuilder.DesktopObjectSize) & ", " &
																				"'" & MenuBuilder.ReportURL & "', " &
																				"'" & MenuBuilder.ReportImagePathActive & "', " &
																				"'" & MenuBuilder.ReportImagePath & "', " &
																				"'" & MenuBuilder.ReportDescription & "', " &
																				"'" & MenuBuilder.ReportPreviewLocation & "', " &
																				"" & Convert.ToInt16(MenuBuilder.ReportIsLocked) & ", " &
																				"" & Convert.ToInt16(Not SecurityDbContext.Database.SqlQuery(Of String)("SELECT ModuleCode FROM dbo.V_SEC_MODULES WHERE ModuleCode = '" & MenuBuilder.Code & "'").Any) & ", " &
																				"'" & MenuBuilder.WebvantageLargeImagePath & "', " &
																				"'" & MenuBuilder.ReportLargeImagePath & "'"

			Next

			ExecuteText(SecurityDbContext, ScriptText, FirstExecution, NodeText)

			InMenuUpdateModuleCodes.Add(MenuBuilder.Code)

			If MenuBuilder.SubModules.Any Then

				For Each SubMenuBuilder In MenuBuilder.SubModules

					CreateOrUpdateMenuItem(SecurityDbContext, FirstExecution, NodeText, SubMenuBuilder, MenuBuilder.SubModules, InMenuUpdateModuleCodes)

				Next

			End If

		End Sub
		Private Function StopUpdateExists() As Boolean

			Dim DatabaseVersion As String = ""
			Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
			Dim StopUpdates As Generic.List(Of AdvantageFramework.Security.Classes.StopUpdate) = Nothing
			Dim StopResult As Integer = 0
			Dim UpdateStopped As Boolean = False

			If _StreamReader IsNot Nothing Then

				Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

					Try

						DatabaseVersion = SecurityDbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault()

					Catch ex As Exception
						DatabaseVersion = ""
					End Try

				End Using

				If DatabaseVersion <> "" Then

					XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(Generic.List(Of AdvantageFramework.Security.Classes.StopUpdate)))

					StopUpdates = XmlSerializer.Deserialize(_StreamReader.BaseStream)

					Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

						For Each StopUpdate In StopUpdates

							If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(StopUpdate.ReleaseVersion) > AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DatabaseVersion) Then

								Try
									StopResult = DbContext.Database.SqlQuery(Of Integer)(StopUpdate.SQL).FirstOrDefault()
								Catch ex As Exception
									StopResult = 0
								End Try

								If StopResult = 1 Then

									UpdateStopped = True

									If Not _BatchMode Then

										AdvantageFramework.Navigation.ShowMessageBox(StopUpdate.Message)

									End If

									Exit For

								End If

							End If

						Next

					End Using

				End If

			ElseIf Not _BatchMode Then

				AdvantageFramework.Navigation.ShowMessageBox("Cannot find embedded resource StopUpdate.xml!")

				UpdateStopped = True

			End If

			StopUpdateExists = UpdateStopped

		End Function
		Private Function ExecuteNielsenScript(FileInfo As System.IO.FileInfo) As Boolean

			'objects
			Dim ScriptText As String = ""
			Dim ScriptLine As String = ""
			Dim StreamReader As System.IO.StreamReader = Nothing
			Dim DbContextTransaction As System.Data.Entity.DbContextTransaction = Nothing
			Dim ReadWholeFileCorrectly As Boolean = False

			Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Session.UserCode)

				NielsenDbContext.Database.Connection.Open()

				DbContextTransaction = NielsenDbContext.Database.BeginTransaction

				Try

					StreamReader = FileInfo.OpenText

					ScriptText = StreamReader.ReadLine() & vbCrLf

					Do Until StreamReader.EndOfStream

						ScriptLine = ""

						ScriptLine = StreamReader.ReadLine()

						If ScriptLine.Trim = "GO" Then

							If ScriptText <> "" Then

								ExecuteNielsenText(NielsenDbContext, ScriptText)

							End If

							ScriptText = ""

						Else

							ScriptText &= ScriptLine & vbNewLine

						End If

					Loop

					ScriptText = ScriptText.Trim

					If ScriptText <> "" AndAlso ScriptText <> "GO" Then

						ExecuteNielsenText(NielsenDbContext, ScriptText)

					End If

					ReadWholeFileCorrectly = True

				Catch ex As Exception

					If ex.InnerException IsNot Nothing Then

						SetLogText("Execution failed --> " & ex.Message & vbCrLf & ex.InnerException.ToString)

					Else

						SetLogText("Execution failed --> " & ex.Message)

					End If

					ReadWholeFileCorrectly = False
					ScriptText = "Failed Executing."
				Finally

					If StreamReader IsNot Nothing Then

						StreamReader.Close()
						StreamReader.Dispose()
						StreamReader = Nothing

					End If

				End Try

				If ReadWholeFileCorrectly Then

					DbContextTransaction.Commit()

				Else

					DbContextTransaction.Rollback()

				End If

			End Using

			ExecuteNielsenScript = ReadWholeFileCorrectly

		End Function
		Private Sub ExecuteNielsenText(NielsenDbContext As AdvantageFramework.Nielsen.Database.DbContext, ScriptText As String)

			SetLogText("Executing text...")

			NielsenDbContext.Database.ExecuteSqlCommand(ScriptText)

			SetLogText("Executed successfully...")

		End Sub

#Region "  Show Form Methods "

		Public Shared Sub ShowForm(ByVal InternalOnlyMode As Boolean, ByVal BatchMode As Boolean, ByVal StreamReader As System.IO.StreamReader)

			'objects
			Dim DatabaseUpdateForm As AdvantageFramework.Database.Presentation.DatabaseUpdateForm = Nothing

			DatabaseUpdateForm = New AdvantageFramework.Database.Presentation.DatabaseUpdateForm(InternalOnlyMode, BatchMode, StreamReader)

			DatabaseUpdateForm.Show()

		End Sub

#End Region

#Region "  Form Event Handlers "

		Private Sub DatabaseUpdateForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			_SetTextDelegate = New AdvantageFramework.WinForm.Presentation.Controls.SetTextOnTextBoxControlDelegate(AddressOf AdvantageFramework.WinForm.Presentation.Controls.SetTextOnTextBoxControl)

			Me.ShowUnsavedChangesOnFormClosing = False

			AddHandler AdvantageFramework.Reporting.Presentation.UpdateCustomReportImportProgressEvent, AddressOf UpdateCustomReportImportProgress
			AddHandler AdvantageFramework.Reporting.Presentation.ResetCustomReportImportOverallProgressValuesEvent, AddressOf ResetCustomReportImportOverallProgressValues

			Me.Text = Me.Session.DatabaseName

			ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage

			LoadVersionNumbers()

		End Sub
		Private Sub DatabaseUpdateForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

			If Not StopUpdateExists() Then

				LoadScriptUpdates()

				If _BatchMode Then

					If RadTreeViewForm_Updates.Nodes.Count > 0 Then

						ButtonItemActions_Process.RaiseClick(DevComponents.DotNetBar.eEventSource.Code)

					Else

						System.Windows.Forms.Application.Exit()

					End If

				End If

			Else

				System.Windows.Forms.Application.Exit()

			End If

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonItemActions_Process_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Process.Click

			'objects
			Dim RadTreeNodeList As Generic.List(Of Telerik.WinControls.UI.RadTreeNode) = Nothing

            ButtonItemActions_Process.Enabled = False
            ButtonItemView_ExpandAll.Enabled = False
            ButtonItemView_CollapseAll.Enabled = False

            TextBoxForm_UpdateLog.Text = ""
			_Lines = New Generic.List(Of String)

			If AdvantageFramework.Database.LoadDatabaseCollation(Me.Session.ConnectionString) = "SQL_Latin1_General_CP1_CS_AS" Then

                If CheckToSeeIfUserWantsToBackupDatabase() Then

                    RadTreeNodeList = LoadCheckedNodes(RadTreeViewForm_Updates.Nodes)

                    TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetupProgressBar(0, RadTreeNodeList.Count, 0)

                    _BackgroundWorker = New System.ComponentModel.BackgroundWorker

                    _BackgroundWorker.WorkerReportsProgress = True

                    _BackgroundWorker.RunWorkerAsync(RadTreeNodeList)

                    Me.ShowOverlay()

                Else

                    If RadTreeViewForm_Updates.Nodes.Count = 0 Then

                        ButtonItemActions_Process.Enabled = False
                        ButtonItemView_ExpandAll.Enabled = False
                        ButtonItemView_CollapseAll.Enabled = False

                    Else

                        ButtonItemActions_Process.Enabled = True
                        ButtonItemView_ExpandAll.Enabled = True
                        ButtonItemView_CollapseAll.Enabled = True

                    End If

                End If

			Else

				TextBoxForm_UpdateLog.Text = "Database has wrong collation..." & vbNewLine & TextBoxForm_UpdateLog.Text

				If _BatchMode = False Then

					AdvantageFramework.Navigation.ShowMessageBox("Your database has wrong collation.  Please set collation to 'SQL_Latin1_General_CP1_CS_AS'.")

				End If

			End If

		End Sub
		Private Sub ButtonItemView_ExpandAll_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemView_ExpandAll.Click

			RadTreeViewForm_Updates.ExpandAll()

		End Sub
		Private Sub ButtonItemView_CollapseAll_Click(sender As Object, e As System.EventArgs) Handles ButtonItemView_CollapseAll.Click

			RadTreeViewForm_Updates.CollapseAll()

		End Sub
		Private Sub RadTreeViewForm_Updates_NodeCheckedChanged(sender As Object, e As Telerik.WinControls.UI.RadTreeViewEventArgs) Handles RadTreeViewForm_Updates.NodeCheckedChanged

			If e.Node.Nodes.Count > 0 Then

				CheckChildNodes(e.Node, e.Node.Checked)

			End If

		End Sub
		Private Sub _BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

			'objects
			Dim ScriptText As String = ""
			Dim ScriptLine As String = ""
			Dim FileInfo As System.IO.FileInfo = Nothing
			Dim StreamReader As System.IO.StreamReader = Nothing
			Dim ReadWholeFileCorrectly As Boolean = False
			Dim AllScriptsRanCorrectly As Boolean = True
			Dim ProgressValue As Integer = 0
			Dim RadTreeNodeList As Generic.List(Of Telerik.WinControls.UI.RadTreeNode) = Nothing
			Dim DbContextTransaction As System.Data.Entity.DbContextTransaction = Nothing
			Dim FirstExecution As Boolean = True
			Dim StringReader As System.IO.StringReader = Nothing
			Dim Hash As String = ""
			Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
			Dim MenuBuilders As Generic.List(Of AdvantageFramework.Security.Classes.MenuBuilder) = Nothing
            Dim InMenuUpdateModuleCodes As Generic.List(Of String) = Nothing
            Dim SQLUser As String = String.Empty

            SQLUser = AdvantageFramework.Database.LoadSQLUser(Session.ConnectionString)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

				SecurityDbContext.Database.Connection.Open()

				RadTreeNodeList = e.Argument

				SetLogText("Closing connections and restricting user access...")

				SecurityDbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, String.Format("ALTER DATABASE {0} SET RESTRICTED_USER WITH ROLLBACK IMMEDIATE", Me.Session.DatabaseName))

				SetLogText("Clear version info...")

				SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.ADVAN_UPDATE SET VERSION_ID = NULL")

				For Each Node In RadTreeNodeList

					If Node.Tag IsNot Nothing AndAlso TypeOf Node.Tag Is System.IO.FileInfo Then

						FileInfo = Node.Tag

						SetLogText("***********************************************************************************")
						SetLogText("Parsing script " & FileInfo.Name.Replace(".advenc", "").Replace(".sql", "").Replace(".xml", "") & "...")

						ScriptLine = ""
						ScriptText = ""
						ReadWholeFileCorrectly = False
						FirstExecution = True
						Hash = ""

						DbContextTransaction = SecurityDbContext.Database.BeginTransaction

						Try
							If FileInfo.Name.ToUpper = "NIELSENSCRIPT.SQL" Then

								ReadWholeFileCorrectly = ExecuteNielsenScript(FileInfo)

							Else

								If FileInfo.Extension.ToUpper = ".ADVENC" Then

                                    StringReader = New System.IO.StringReader(AdvantageFramework.Security.Encryption.Decrypt(My.Computer.FileSystem.ReadAllText(FileInfo.FullName)))

                                    ScriptText = StringReader.ReadLine() & vbCrLf

                                    Do While StringReader.Peek <> -1

										ScriptLine = ""

										ScriptLine = StringReader.ReadLine()

										If ScriptLine.Trim = "GO" Then

											If ScriptText <> "" Then

												ExecuteText(SecurityDbContext, ScriptText, FirstExecution, Node.Text)

											End If

											ScriptText = ""

										Else

											ScriptText &= ScriptLine & vbNewLine

										End If

									Loop

								ElseIf FileInfo.Name = "MenuUpdate.xml" Then

									InMenuUpdateModuleCodes = New Generic.List(Of String)

									XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(Generic.List(Of AdvantageFramework.Security.Classes.MenuBuilder)))
									StringReader = New System.IO.StringReader(My.Computer.FileSystem.ReadAllText(FileInfo.FullName))

									MenuBuilders = XmlSerializer.Deserialize(StringReader)

									For Each MenuBuilder In MenuBuilders

										CreateOrUpdateMenuItem(SecurityDbContext, FirstExecution, Node.Text, MenuBuilder, MenuBuilders, InMenuUpdateModuleCodes)

									Next

									For Each ModuleCode In (From [Module] In SecurityDbContext.Modules
															Where InMenuUpdateModuleCodes.Contains([Module].Code) = False
															Select [Module].Code).ToList

										ScriptText = "EXEC [dbo].[advsp_sec_module_delete] '" & ModuleCode & "'"

										ExecuteText(SecurityDbContext, ScriptText, FirstExecution, Node.Text)

									Next

								Else

									StreamReader = FileInfo.OpenText

									ScriptText = StreamReader.ReadLine() & vbCrLf

									Do Until StreamReader.EndOfStream

										ScriptLine = ""

										ScriptLine = StreamReader.ReadLine()

										If ScriptLine.Trim = "GO" Then

											If ScriptText <> "" Then

												ExecuteText(SecurityDbContext, ScriptText, FirstExecution, Node.Text)

											End If

											ScriptText = ""

										Else

											ScriptText &= ScriptLine & vbNewLine

										End If

									Loop

								End If

								ScriptText = ScriptText.Trim

								If ScriptText <> "" AndAlso ScriptText <> "GO" Then

									ExecuteText(SecurityDbContext, ScriptText, FirstExecution, Node.Text)

								End If

								ReadWholeFileCorrectly = True

							End If

						Catch ex As Exception

							If ex.InnerException IsNot Nothing Then

								SetLogText("Execution failed --> " & ex.Message & vbCrLf & ex.InnerException.ToString)

							Else

								SetLogText("Execution failed --> " & ex.Message)

							End If

							ReadWholeFileCorrectly = False
							ScriptText = "Failed Executing."
						Finally

							If StreamReader IsNot Nothing Then

								StreamReader.Close()
								StreamReader.Dispose()
								StreamReader = Nothing

							End If

						End Try

						If ReadWholeFileCorrectly Then

							DbContextTransaction.Commit()

							SetLogText("Updating database update table...")

							Using FileStream = FileInfo.OpenRead

								Using MD5CryptoServiceProvider As New System.Security.Cryptography.MD5CryptoServiceProvider

									Hash = AdvantageFramework.StringUtilities.ByteArrayToString(MD5CryptoServiceProvider.ComputeHash(FileStream))

								End Using

							End Using

							If SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.DB_UPDATE WHERE PATCH = '{0}' AND FILE_HASH = '{1}' AND VERSION_ID = '{2}'", FileInfo.Name, Hash, Node.Parent.Text)).FirstOrDefault = 0 Then

                                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.DB_UPDATE([VERSION_ID], [PATCH], [DESCRIPTION], [DATE_APPLIED], [FUNCTION_NAME], [FILE_HASH], [SQL_USER])" &
                                                                                        "VALUES('{0}', '{1}', '{2}', GETDATE(), '{3}', '{4}', '{5}')", Node.Parent.Text, FileInfo.Name, Node.Text, Node.Text, Hash, SQLUser))

                            End If

							SetLogText("Database update table updated...")
							SetLogText("***********************************************************************************")

						Else

							DbContextTransaction.Rollback()

							AllScriptsRanCorrectly = False

						End If

					End If

					ProgressValue += 1

					_BackgroundWorker.ReportProgress(ProgressValue)

					If AllScriptsRanCorrectly = False Then

						_BackgroundWorker.ReportProgress(RadTreeNodeList.Count)

						Exit For

					End If

				Next

				If AllScriptsRanCorrectly Then

					ScriptText = ""

				End If

				SecurityDbContext.Database.Connection.Close()

			End Using

			e.Result = ScriptText

		End Sub
		Private Sub _BackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged

			TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetProgressBarValue(e.ProgressPercentage)

		End Sub
        Private Sub _BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

            'objects
            Dim ScriptText As String = ""
            Dim ReportsFolder As String = ""
            Dim CreationTime As Date = Nothing
            Dim SqlParameterCreationTime As System.Data.SqlClient.SqlParameter = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim POP3EmailListenerAccount As AdvantageFramework.Database.Entities.POP3EmailListenerAccount = Nothing
            Dim POP3AutomatedAssignmentAccount As AdvantageFramework.Database.Entities.POP3AutomatedAssignmentAccount = Nothing
            Dim RegistrationServices As System.Runtime.InteropServices.RegistrationServices = Nothing
            Dim Assembly As System.Reflection.Assembly = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ScriptText = e.Result

                If ScriptText = "" Then

                    SetLogText("Checking for custom report updates...")

                    Try

                        For Each Directory In My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).Parent.GetDirectories()

                            If Directory.Name.ToUpper = "reports".ToUpper Then

                                ReportsFolder = Directory.FullName

                            End If

                        Next

                    Catch ex As Exception
                        ReportsFolder = ""
                    End Try

                    If ReportsFolder <> "" Then

                        AdvantageFramework.Reporting.Presentation.LegacyCustomReportUpdate(Me.Session, AdvantageFramework.StringUtilities.AppendTrailingCharacter(ReportsFolder, "\") & "rpt_format.csv")

                    Else

                        SetLogText("Custom report file not found...")

                    End If

                    SetLogText("Updating custom reports complete...")

                    Me.Refresh()

                    SetLogText("Updating version number...")

                    Me.Refresh()

                    Try

                        SecurityDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ADVAN_UPDATE SET VERSION_ID = '{0}'", "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00")))

                    Catch ex As Exception
                        SetLogText("Failed updating version number...")
                    End Try

                    SetLogText("Updating version number complete...")

                    Me.Refresh()

                    SetLogText("Granting permissions on stored procedures...")

                    Me.Refresh()

                    Try

                        SecurityDbContext.Database.ExecuteSqlCommand("GRANT EXECUTE ON usp_grant_execute_on_sp_to_public TO PUBLIC")

                        SecurityDbContext.Database.ExecuteSqlCommand("EXEC usp_grant_execute_on_sp_to_public")

                    Catch ex As Exception
                        SetLogText("Failed granting permissions on stored procedures...")
                    End Try

                    SetLogText("Successful granting permissions on stored procedures...")

                    Me.Refresh()

                    SetLogText("Updating database update date...")

                    Me.Refresh()

                    Try

                        SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.ADVAN_UPDATE SET DB_UPDATE = GETDATE()")

                    Catch ex As Exception
                        SetLogText("Failed updating database update date...")
                    End Try

                    SetLogText("Updating database update date complete...")

                    Me.Refresh()

                    SetLogText("Updating application date...")

                    Me.Refresh()

                    Try

                        SqlParameterCreationTime = New System.Data.SqlClient.SqlParameter("@UPDATE_APP", System.Data.SqlDbType.SmallDateTime)

                        CreationTime = My.Computer.FileSystem.GetFileInfo(System.Windows.Forms.Application.ExecutablePath).CreationTime

                        SqlParameterCreationTime.Value = CreationTime

                        SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.ADVAN_UPDATE SET UPDATE_APP = @UPDATE_APP", SqlParameterCreationTime)

                    Catch ex As Exception
                        SetLogText("Failed updating application date...")
                    End Try

                    SetLogText("Updating application date complete...")

                    Me.Refresh()

                    SetLogText("Checking\updating encryption changes phase 1...")

                    Me.Refresh()

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            DbContext.Database.Connection.Open()

                            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                If AdvantageFramework.Agency.LoadEncryptedPasswordsPhase1(DataContext) = False Then

                                    For Each Employee In DbContext.Employees.ToList

                                        If String.IsNullOrWhiteSpace(Employee.EmailPassword) = False Then

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMPLOYEE SET EMAIL_PWD = '{0}' WHERE EMP_CODE = '{1}'", AdvantageFramework.Security.Encryption.Encrypt(Employee.EmailPassword).Replace("'", "''"), Employee.Code))

                                        End If

                                    Next

                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                    If Agency IsNot Nothing Then

                                        If String.IsNullOrWhiteSpace(Agency.EmailPassword) = False Then

                                            Agency.EmailPassword = AdvantageFramework.Security.Encryption.Encrypt(Agency.EmailPassword)

                                        End If

                                        If String.IsNullOrWhiteSpace(Agency.POP3Password) = False Then

                                            Agency.POP3Password = AdvantageFramework.Security.Encryption.Encrypt(Agency.POP3Password)

                                        End If

                                        AdvantageFramework.Database.Procedures.Agency.Update(DbContext, Agency)

                                    End If

                                    For Each POP3EmailListenerAccount In DbContext.POP3EmailListenerAccounts.ToList

                                        If String.IsNullOrWhiteSpace(POP3EmailListenerAccount.Password) = False Then

                                            POP3EmailListenerAccount.Password = AdvantageFramework.Security.Encryption.Encrypt(POP3EmailListenerAccount.Password)

                                            AdvantageFramework.Database.Procedures.POP3EmailListenerAccount.Update(DbContext, POP3EmailListenerAccount)

                                        End If

                                    Next

                                    For Each POP3AutomatedAssignmentAccount In DbContext.POP3AutomatedAssignmentAccounts.ToList

                                        If String.IsNullOrWhiteSpace(POP3AutomatedAssignmentAccount.Password) = False Then

                                            POP3AutomatedAssignmentAccount.Password = AdvantageFramework.Security.Encryption.Encrypt(POP3AutomatedAssignmentAccount.Password)

                                            AdvantageFramework.Database.Procedures.POP3AutomatedAssignmentAccount.Update(DbContext, POP3AutomatedAssignmentAccount)

                                        End If

                                    Next

                                    AdvantageFramework.Agency.SaveEncryptedPasswordsPhase1(DataContext, True)

                                End If

                            End Using

                        End Using

                    Catch ex As Exception
                        SetLogText("Failed Checking\updating encryption changes phase 1...")
                    End Try

                    SetLogText("Checking\updating encryption changes phase 1 complete...")

                    Me.Refresh()

                    SetLogText("Clearing all logged in user licenses...")

                    Me.Refresh()

                    Try

                        AdvantageFramework.Security.LicenseKey.ClearAllUsers(Me.Session, "")

                    Catch ex As Exception
                        SetLogText("Failed clearing all logged in user licenses...")
                    End Try

                    SetLogText("Clearing all logged in user licenses complete...")

                    Me.Refresh()

                    If _BatchMode = False Then

                        Me.CloseOverlay()

                        AdvantageFramework.Navigation.ShowMessageBox("Update complete!")

                    End If

                    LoadVersionNumbers()

                Else

                    SetLogText("Update failed...")

                    If _BatchMode = False Then

                        Me.CloseOverlay()

                        If _InternalOnlyMode Then

                            AdvantageFramework.WinForm.Presentation.TextBoxMessageDialog.ShowFormDialog(e.Result, "Update failed with this script!")

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox("Update failed!")

                        End If

                    Else

                        Try

                            My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & Me.Session.DatabaseName & "_" & Now.ToFileTime & ".log", TextBoxForm_UpdateLog.Text, False)

                        Catch ex As Exception

                        End Try

                    End If

                End If

                SecurityDbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, String.Format("ALTER DATABASE {0} SET MULTI_USER", Me.Session.DatabaseName))

            End Using

            LoadScriptUpdates()

            Me.CloseOverlay()

            If _BatchMode Then

                System.Diagnostics.Process.GetCurrentProcess.Kill()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
