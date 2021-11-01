Namespace Web.Presentation.SettingPage

	<HideModuleName()>
	Public Module Methods

		Public Event LoadTabEvent(ByRef [Page] As System.Web.UI.Page)
        Public Event CheckBoxCheckedEvent(ByRef [Page] As System.Web.UI.Page, ByRef Checked As Boolean)

#Region " Constants "

        Private Const DefaultWebControlPrefix As String = "ctl00_ContentPlaceHolderMain_"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Public Sub TextBoxTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

			'objects
			Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
			Dim SettingCode As String = sender.ID.ToString().Replace(DefaultWebControlPrefix, "")


			Using DataContext = New AdvantageFramework.Database.DataContext(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("ConnString").ToString, DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("UserCode").ToString)

				Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, SettingCode)

				If Setting IsNot Nothing Then

					Setting.Value = sender.Text

					AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

				End If

			End Using

			RaiseEvent LoadTabEvent(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page)

		End Sub
		Public Sub NumericInputTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

			'objects
			Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

			Using DataContext = New AdvantageFramework.Database.DataContext(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("ConnString").ToString, DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("UserCode").ToString)

				Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, sender.ID)

				If Setting IsNot Nothing Then

					Setting.Value = sender.Value

					AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

				End If

			End Using

			RaiseEvent LoadTabEvent(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page)

		End Sub
		Public Sub CheckBoxCheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

			'objects
			Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

			Using DataContext = New AdvantageFramework.Database.DataContext(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("ConnString").ToString, DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("UserCode").ToString)

				Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, sender.ID)

				If Setting IsNot Nothing Then

                    If sender.Checked AndAlso Setting.Code <> AdvantageFramework.Agency.Settings.DC_ENABLED.ToString Then

                        Setting.Value = 1

                    Else

                        Setting.Value = 0

                    End If

                    AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                    If Setting.Code = AdvantageFramework.Agency.Settings.DC_ENABLED.ToString Then

                        RaiseEvent CheckBoxCheckedEvent(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page, sender.Checked)

                    End If

                End If

            End Using

			RaiseEvent LoadTabEvent(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page)

		End Sub
		Public Sub DropDownListSelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

			'objects
			Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
			Dim Status As AdvantageFramework.Database.Entities.Status = Nothing
			Dim PreviousSettingValue As Object = Nothing

			Using DataContext = New AdvantageFramework.Database.DataContext(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("ConnString").ToString, DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("UserCode").ToString)

				Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, sender.ID)

				If Setting IsNot Nothing Then

					PreviousSettingValue = Setting.Value

					Setting.Value = sender.SelectedValue

					If AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting) Then

						If Setting.Code = AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString AndAlso PreviousSettingValue <> Setting.Value Then

							Try

								Using DbContext = New AdvantageFramework.Database.DbContext(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("ConnString").ToString, DirectCast(sender, System.Web.UI.WebControls.WebControl).Page.Session("UserCode").ToString)

									Status = AdvantageFramework.Database.Procedures.Status.LoadByStatusCode(DbContext, PreviousSettingValue)

									If Status IsNot Nothing Then

										If Status.IsInactive.GetValueOrDefault(0) = 1 Then

											AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString, Status.Code)

										End If

									End If

								End Using

							Catch ex As Exception

							End Try

						End If

					End If

				End If

			End Using

			RaiseEvent LoadTabEvent(DirectCast(sender, System.Web.UI.WebControls.WebControl).Page)

		End Sub
		Public Sub LoadTab(ByRef PlaceHolderSetting As System.Web.UI.WebControls.PlaceHolder, Session As AdvantageFramework.Security.Session, SettingModuleID As Long, SettingModuleTabID As Long)

			'objects
			Dim Table As System.Web.UI.WebControls.Table = Nothing
			Dim TableRow As System.Web.UI.WebControls.TableRow = Nothing
			Dim LabelTableCell As System.Web.UI.WebControls.TableCell = Nothing
			Dim ControlTableCell As System.Web.UI.WebControls.TableCell = Nothing
			Dim SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType = Nothing
			Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing
			Dim CheckBox As System.Web.UI.WebControls.CheckBox = Nothing
			Dim NumericInput As Telerik.Web.UI.RadNumericTextBox = Nothing
			Dim DropDownList As System.Web.UI.WebControls.DropDownList = Nothing
			Dim LookupHyperlink As System.Web.UI.WebControls.HyperLink = Nothing
			Dim SettingValuesList As Generic.List(Of AdvantageFramework.Database.Entities.SettingValue) = Nothing
			Dim TabIndex As Integer = 0
			Dim SettingParent As AdvantageFramework.Database.Entities.Setting = Nothing
			Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

			PlaceHolderSetting.Controls.Clear()

			Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

				Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

					Table = New System.Web.UI.WebControls.Table

					For Each Setting In AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleIDAndSettingModuleTabID(DataContext, SettingModuleID, SettingModuleTabID)

						TextBox = Nothing
						CheckBox = Nothing
						NumericInput = Nothing
						DropDownList = Nothing
						LookupHyperlink = Nothing

						TableRow = New System.Web.UI.WebControls.TableRow

						LabelTableCell = New System.Web.UI.WebControls.TableCell

						LabelTableCell.Text = Setting.Description & ":"

						Select Case Setting.Code
							Case "USE_PHASE", "TRF_CALC_CONCUR_DT"

								LabelTableCell.Text &= "*"

							Case "TRF_SCHEDULE_BY"

								LabelTableCell.Text = LabelTableCell.Text.Replace("due date", "due date*")

							Case "TRF_DFLT_STATUS"

								'LookupHyperlink = New System.Web.UI.WebControls.HyperLink

								'With LookupHyperlink
								'    .Text = Setting.Description & ":"
								'    .NavigateUrl = "#"
								'    .Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & DefaultWebControlPrefix & Setting.Code & _
								'                    "&type=statuscodes&autosave=" & Setting.Code & "');return false;")
								'End With

								'LabelTableCell.Controls.Add(LookupHyperlink)

							Case "JR_ASSIGN_STATE"

								SettingParent = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, "JR_ASSIGN_TMPLT")

						End Select

						LabelTableCell.Width = System.Web.UI.WebControls.Unit.Point(350)

						TableRow.Cells.Add(LabelTableCell)

						ControlTableCell = New System.Web.UI.WebControls.TableCell
						ControlTableCell.Width = System.Web.UI.WebControls.Unit.Point(250)
						ControlTableCell.VerticalAlign = System.Web.UI.WebControls.VerticalAlign.Middle
						ControlTableCell.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left

						TableRow.Cells.Add(ControlTableCell)

						Table.Rows.Add(TableRow)

						SettingDatabaseType = AdvantageFramework.Database.Procedures.SettingDatabaseType.LoadBySettingDatabaseTypeID(DataContext, Setting.SettingDatabaseTypeID.GetValueOrDefault(0))

						If SettingDatabaseType IsNot Nothing Then

							Select Case SettingDatabaseType.DatabaseTypeID

								Case 1

									SettingValuesList = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, Setting.Code).OrderBy(Function(SettingValue) SettingValue.DisplayText).ToList

									If Setting.Code = "JR_DFLT_CONTACT" Then

										Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

											Try

												Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext).ToList

											Catch ex As Exception
												Employees = Nothing
											End Try

										End Using

										If Employees IsNot Nothing Then

											SettingValuesList = SettingValuesList.Where(Function(SV) Employees.Any(Function(Entity) Entity.Code = SV.Value)).ToList

										End If

									End If

									If SettingValuesList.Count > 0 Then

										DropDownList = New System.Web.UI.WebControls.DropDownList

										DropDownList.ID = Setting.Code

										DropDownList.DataTextField = AdvantageFramework.Database.Entities.SettingValue.Properties.DisplayText.ToString
										DropDownList.DataValueField = AdvantageFramework.Database.Entities.SettingValue.Properties.Value.ToString

										DropDownList.DataSource = SettingValuesList.AsQueryable

										DropDownList.DataBind()

										If Setting.DefaultValue Is Nothing Then

											DropDownList.Items.Insert(0, New System.Web.UI.WebControls.ListItem("[Please select]", ""))

										End If

										DropDownList.SelectedValue = Setting.Value

										DropDownList.Width = System.Web.UI.WebControls.Unit.Point(200)
										'DropDownList.CssClass = "CssListBox"
										DropDownList.AutoPostBack = True
										DropDownList.TabIndex = TabIndex

										AddHandler DropDownList.SelectedIndexChanged, AddressOf DropDownListSelectedIndexChanged

										ControlTableCell.Controls.Add(DropDownList)

									ElseIf SettingParent IsNot Nothing Then

										DropDownList = New System.Web.UI.WebControls.DropDownList

										DropDownList.ID = Setting.Code

										If SettingParent.Code = "JR_ASSIGN_TMPLT" Then

											Dim AlertAssignmentStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateState) = Nothing
											If IsNumeric(SettingParent.Value) = False Then SettingParent.Value = 0
											AlertAssignmentStates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, SettingParent.Value).OrderBy(Function(AlertAssignmentTemplateState) AlertAssignmentTemplateState.AlertState.Name).ToList()

											If Not AlertAssignmentStates Is Nothing Then

												For Each t As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState In AlertAssignmentStates

													DropDownList.Items.Add(New System.Web.UI.WebControls.ListItem(t.AlertState.Name, t.AlertStateID))

												Next

											End If

											If Setting.DefaultValue Is Nothing Then

												DropDownList.Items.Insert(0, New System.Web.UI.WebControls.ListItem("[Please select]", ""))

											End If

											DropDownList.SelectedValue = Setting.Value

											DropDownList.Width = System.Web.UI.WebControls.Unit.Point(200)
											'DropDownList.CssClass = "CssListBox"
											DropDownList.AutoPostBack = True
											DropDownList.TabIndex = TabIndex

										End If

										AddHandler DropDownList.SelectedIndexChanged, AddressOf DropDownListSelectedIndexChanged

										ControlTableCell.Controls.Add(DropDownList)

									Else

										TextBox = New System.Web.UI.WebControls.TextBox

										TextBox.ID = Setting.Code

										TextBox.Text = Setting.Value

										TextBox.MaxLength = SettingDatabaseType.Precision.GetValueOrDefault(0)
										TextBox.Width = System.Web.UI.WebControls.Unit.Point(200)
										TextBox.CssClass = "CssTextBox"

										If Setting.Code = AdvantageFramework.Agency.Settings.PROOFHQ_SA_PASSWORD.ToString OrElse
												Setting.Code = AdvantageFramework.Agency.Settings.VCC_SA_PASSWORD.ToString OrElse
												Setting.Code = AdvantageFramework.Agency.Settings.CS_SA_PASSWORD.ToString Then

											TextBox.TextMode = System.Web.UI.WebControls.TextBoxMode.Password

											TextBox.Attributes.Add("value", Setting.Value)

										End If

										TextBox.AutoPostBack = True
										TextBox.TabIndex = TabIndex

										AddHandler TextBox.TextChanged, AddressOf TextBoxTextChanged

										ControlTableCell.Controls.Add(TextBox)

									End If

                                Case 2

                                    NumericInput = New Telerik.Web.UI.RadNumericTextBox

                                    NumericInput.ID = Setting.Code
                                    NumericInput.Type = Telerik.Web.UI.NumericType.Number

                                    NumericInput.NumberFormat.GroupSeparator = ""

                                    'NumericInput.MaxValue = Setting.MaximumValue.GetValueOrDefault(0)
                                    NumericInput.MinValue = Setting.MinimumValue.GetValueOrDefault(0)

                                    NumericInput.Value = CInt(Setting.Value)

                                    NumericInput.MaxLength = SettingDatabaseType.Precision.GetValueOrDefault(0)
                                    NumericInput.NumberFormat.DecimalDigits = SettingDatabaseType.Scale.GetValueOrDefault(0)
                                    NumericInput.EnabledStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right

                                    NumericInput.Width = System.Web.UI.WebControls.Unit.Point(100)

                                    NumericInput.AllowOutOfRangeAutoCorrect = False

                                    NumericInput.NumberFormat.KeepTrailingZerosOnFocus = True
                                    NumericInput.AutoPostBack = True
                                    NumericInput.TabIndex = TabIndex

                                    NumericInput.ClientEvents.OnValueChanging = "NumericInputOnValueChanging"
                                    AddHandler NumericInput.TextChanged, AddressOf NumericInputTextChanged

                                    ControlTableCell.Controls.Add(NumericInput)

                                Case 5

									SettingValuesList = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, Setting.Code).OrderBy(Function(SettingValue) SettingValue.DisplayText).ToList

									If SettingValuesList.Count > 0 Then

										DropDownList = New System.Web.UI.WebControls.DropDownList

										DropDownList.ID = Setting.Code

										DropDownList.DataTextField = AdvantageFramework.Database.Entities.SettingValue.Properties.DisplayText.ToString
										DropDownList.DataValueField = AdvantageFramework.Database.Entities.SettingValue.Properties.Value.ToString

										DropDownList.DataSource = SettingValuesList.AsQueryable

										DropDownList.DataBind()

										If Setting.DefaultValue Is Nothing Then

											DropDownList.Items.Insert(0, New System.Web.UI.WebControls.ListItem("[Please select]", ""))

										End If

										DropDownList.SelectedValue = Setting.Value

										DropDownList.Width = System.Web.UI.WebControls.Unit.Point(200)
										'DropDownList.CssClass = "CssListBox"
										DropDownList.AutoPostBack = True
										DropDownList.TabIndex = TabIndex

										AddHandler DropDownList.SelectedIndexChanged, AddressOf DropDownListSelectedIndexChanged

										ControlTableCell.Controls.Add(DropDownList)

									Else

                                        NumericInput = New Telerik.Web.UI.RadNumericTextBox

                                        NumericInput.ID = Setting.Code
                                        NumericInput.Type = Telerik.Web.UI.NumericType.Number

                                        NumericInput.Value = CDbl(Setting.Value)

										NumericInput.MaxValue = Setting.MaximumValue.GetValueOrDefault(0)
										NumericInput.MinValue = Setting.MinimumValue.GetValueOrDefault(0)

										NumericInput.MaxLength = SettingDatabaseType.Precision.GetValueOrDefault(0)
										NumericInput.NumberFormat.DecimalDigits = SettingDatabaseType.Scale.GetValueOrDefault(0)
										NumericInput.EnabledStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right

										NumericInput.Width = System.Web.UI.WebControls.Unit.Point(50)

										NumericInput.AllowOutOfRangeAutoCorrect = False

										NumericInput.NumberFormat.KeepTrailingZerosOnFocus = True
										NumericInput.AutoPostBack = True
										NumericInput.TabIndex = TabIndex

										NumericInput.ClientEvents.OnValueChanging = "NumericInputOnValueChanging"
										AddHandler NumericInput.TextChanged, AddressOf NumericInputTextChanged

										ControlTableCell.Controls.Add(NumericInput)

									End If

								Case 7

									CheckBox = New System.Web.UI.WebControls.CheckBox

									CheckBox.ID = Setting.Code

									CheckBox.Text = ""

									If Setting.Code = AdvantageFramework.Agency.Settings.CS_ENABLED.ToString Then

										If TypeOf Setting.Value Is Boolean Then

											CheckBox.Checked = Setting.Value

										Else

											If IsNumeric(Setting.Value) AndAlso CLng(Setting.Value) = 1 Then

												CheckBox.Checked = True

											Else

												CheckBox.Checked = False

											End If

										End If

									Else

										If TypeOf Setting.Value Is Boolean Then

											CheckBox.Checked = Setting.Value

										Else

											If IsNumeric(Setting.Value) AndAlso CLng(Setting.Value) = 1 Then

												CheckBox.Checked = True

											Else

												CheckBox.Checked = False

											End If

										End If

									End If

									CheckBox.Width = System.Web.UI.WebControls.Unit.Point(50)

									CheckBox.AutoPostBack = True
									CheckBox.TabIndex = TabIndex

									AddHandler CheckBox.CheckedChanged, AddressOf CheckBoxCheckedChanged

									ControlTableCell.Controls.Add(CheckBox)

							End Select

						Else

							SettingValuesList = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, Setting.Code).OrderBy(Function(SettingValue) SettingValue.DisplayText).ToList

							If SettingValuesList.Count > 0 Then

								DropDownList = New System.Web.UI.WebControls.DropDownList

								DropDownList.ID = Setting.Code

								DropDownList.DataTextField = AdvantageFramework.Database.Entities.SettingValue.Properties.DisplayText.ToString
								DropDownList.DataValueField = AdvantageFramework.Database.Entities.SettingValue.Properties.Value.ToString

								DropDownList.DataSource = SettingValuesList.AsQueryable

								DropDownList.DataBind()

								If Setting.DefaultValue Is Nothing Then

									DropDownList.Items.Insert(0, New System.Web.UI.WebControls.ListItem("[Please select]", ""))

								End If

								DropDownList.SelectedValue = Setting.Value

								DropDownList.Width = System.Web.UI.WebControls.Unit.Point(200)
								'DropDownList.CssClass = "CssListBox"
								DropDownList.AutoPostBack = True
								DropDownList.TabIndex = TabIndex

								AddHandler DropDownList.SelectedIndexChanged, AddressOf DropDownListSelectedIndexChanged

								ControlTableCell.Controls.Add(DropDownList)

							Else

								TextBox = New System.Web.UI.WebControls.TextBox

								TextBox.ID = Setting.Code

								TextBox.Text = Setting.Value

								TextBox.Width = System.Web.UI.WebControls.Unit.Point(200)
								TextBox.CssClass = "CssTextBox"

								If Setting.Code = AdvantageFramework.Agency.Settings.PROOFHQ_SA_PASSWORD.ToString Then

									TextBox.TextMode = System.Web.UI.WebControls.TextBoxMode.Password

									TextBox.Attributes.Add("value", Setting.Value)

								End If

								TextBox.AutoPostBack = True
								TextBox.TabIndex = TabIndex

								AddHandler TextBox.TextChanged, AddressOf TextBoxTextChanged

								ControlTableCell.Controls.Add(TextBox)

							End If

						End If

						TabIndex += 1

					Next

				End Using

			End Using

			PlaceHolderSetting.Controls.Add(Table)

		End Sub
		Public Sub LoadTabs(ByRef RadTabStripSettings As Telerik.Web.UI.RadTabStrip, Session As AdvantageFramework.Security.Session, SettingModuleID As Long)

			'objects
			Dim Tab As Telerik.Web.UI.RadTab = Nothing

			Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

				For Each SettingModuleTab In AdvantageFramework.Database.Procedures.SettingModuleTab.LoadBySettingModuleID(DataContext, SettingModuleID)

                    'If SettingModuleTab.SettingModuleID = 7 AndAlso (SettingModuleTab.ID = 6 OrElse SettingModuleTab.ID = 7 OrElse SettingModuleTab.ID = 8) Then
                    '    'do not add to webvantage settings

                    'Else

                    Tab = New Telerik.Web.UI.RadTab

                    Tab.Text = SettingModuleTab.Description

                    RadTabStripSettings.Tabs.Add(Tab)

                    'End If

                Next

			End Using

			If RadTabStripSettings.Tabs.Count > 0 Then

				RadTabStripSettings.SelectedIndex = 0

			End If

		End Sub
		Public Sub LoadDefaults(ByVal ConnectionString As String, ByVal UserCode As String, ByVal SettingModuleID As Long)

			Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

				For Each Setting In AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleID(DataContext, SettingModuleID)

					Setting.Value = Setting.DefaultValue

					AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

				Next

			End Using

		End Sub
		Public Sub FindControl(ByRef [Page] As System.Web.UI.Page, ByRef PlaceHolderSettings As System.Web.UI.WebControls.PlaceHolder)

			'objects
			Dim ControlName As String = ""
			Dim Control As System.Web.UI.WebControls.WebControl = Nothing

			ControlName = [Page].Request.Params.Get("__EVENTTARGET")

			If ControlName IsNot Nothing AndAlso ControlName <> String.Empty Then

				Control = [Page].FindControl(ControlName)

				If Control IsNot Nothing Then

					If (TypeOf Control Is System.Web.UI.WebControls.TextBox OrElse TypeOf Control Is Telerik.Web.UI.RadNumericTextBox) Then

						Try

							For Each TableRow In DirectCast(PlaceHolderSettings.Controls(0), System.Web.UI.WebControls.Table).Controls.OfType(Of System.Web.UI.WebControls.TableRow)()

								For Each TableCell In TableRow.Controls.OfType(Of System.Web.UI.WebControls.TableCell)()

									For Each TableCellControl In TableCell.Controls.OfType(Of System.Web.UI.WebControls.WebControl)()

										If TypeOf TableCellControl Is System.Web.UI.WebControls.TextBox OrElse TypeOf TableCellControl Is Telerik.Web.UI.RadNumericTextBox OrElse
												TypeOf TableCellControl Is System.Web.UI.WebControls.CheckBox OrElse TypeOf TableCellControl Is System.Web.UI.WebControls.DropDownList Then

											If TableCellControl.TabIndex = Control.TabIndex + 1 Then

												TableCellControl.Focus()
												Exit For

											End If

										End If

									Next

								Next

							Next

						Catch ex As Exception

						End Try

					ElseIf TypeOf Control Is System.Web.UI.WebControls.CheckBox OrElse TypeOf Control Is System.Web.UI.WebControls.DropDownList Then

						Control.Focus()

					End If

				End If

			End If

		End Sub

#End Region

    End Module

End Namespace
