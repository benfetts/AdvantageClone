Namespace WinForm.MVC.Presentation.Controls

	<HideModuleName()>
	Public Module Methods

		Public Delegate Sub SetTextOnTextBoxControlDelegate(ByRef TextBoxControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox, ByVal Text As String)
		Public Delegate Sub SetTextOnLabelControlDelegate(ByRef LabelControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label, ByVal Text As String)
		Public Delegate Sub SetVisibleOnControlDelegate(ByRef Control As System.Windows.Forms.Control, ByVal Visible As Boolean)
		Public Delegate Sub SetVisibleOnDockContainerItemControlDelegate(ByRef DockContainerItem As DevComponents.DotNetBar.DockContainerItem, ByVal Visible As Boolean)
		Public Delegate Sub SetTextOnLabelItemDelegate(ByRef LabelItem As DevComponents.DotNetBar.LabelItem, ByVal Text As String)
		Public Delegate Sub SetVisibleOnBubbleBarDelegate(ByRef BubbleBar As DevComponents.DotNetBar.BubbleBar, ByVal Visible As Boolean)
		Public Delegate Sub SetVisibleOnDelegate(ByRef Control As System.Windows.Forms.Control, ByVal Visible As Boolean)
		Public Delegate Sub SetCheckedOnButtonItemDelegate(ByRef ButtonItem As DevComponents.DotNetBar.ButtonItem, ByVal Visible As Boolean)
		Public Delegate Sub SetTextOnControlDelegate(ByRef Control As System.Windows.Forms.Control, ByVal Text As String)
		Public Delegate Sub SetTextOnSideBarPanelItemDelegate(ByRef SideBarPanelItem As DevComponents.DotNetBar.SideBarPanelItem, ByVal Text As String)
		Public Delegate Sub SetTextOnButtonItemDelegate(ByRef ButtonItem As DevComponents.DotNetBar.ButtonItem, ByVal Text As String)

#Region " Constants "

		Private Const WM_SETREDRAW As Integer = &HB

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

		<System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint:="SendMessageA", ExactSpelling:=True, CharSet:=Runtime.InteropServices.CharSet.Ansi, SetLastError:=True)>
		Private Function SendMessage(hwnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer) As Integer

		End Function
		<System.Runtime.CompilerServices.Extension>
		Public Sub SuspendDrawing(ByVal Target As System.Windows.Forms.Control)

			SendMessage(Target.Handle, WM_SETREDRAW, 0, 0)

		End Sub
		<System.Runtime.CompilerServices.Extension>
		Public Sub ResumeDrawing(ByVal Target As System.Windows.Forms.Control)

			ResumeDrawing(Target, True)

		End Sub
		<System.Runtime.CompilerServices.Extension>
		Public Sub ResumeDrawing(ByVal Target As System.Windows.Forms.Control, ByVal Redraw As Boolean)

			SendMessage(Target.Handle, WM_SETREDRAW, 1, 0)

			If Redraw Then

				Target.Refresh()

			End If

		End Sub
		Public Sub UserEntryChanged(ByVal Control As System.Windows.Forms.Control)

            If TypeOf Control.FindForm Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm Then

                DirectCast(Control.FindForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).BaseFormUserEntryChanged(Control)

            ElseIf TypeOf Control.FindForm Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm Then

                DirectCast(Control.FindForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).BaseFormUserEntryChanged(Control)

            ElseIf TypeOf Control.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                If TypeOf Control.FindForm.ActiveMdiChild Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm Then

                    DirectCast(Control.FindForm.ActiveMdiChild, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).BaseFormUserEntryChanged(Control)

                ElseIf TypeOf Control.FindForm.ActiveMdiChild Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm Then

                    DirectCast(Control.FindForm.ActiveMdiChild, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).BaseFormUserEntryChanged(Control)

                End If

            ElseIf TypeOf Control.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm Then

                DirectCast(Control.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).BaseFormUserEntryChanged(Control)

            ElseIf TypeOf Control.FindForm Is AdvantageFramework.Billing.Reports.Presentation.InvoiceViewingForm Then

				DirectCast(Control.FindForm, AdvantageFramework.Billing.Reports.Presentation.InvoiceViewingForm).BaseFormUserEntryChanged(Control)

			End If

		End Sub
        Public Sub AddSubItemCheckBox(ByVal PivotGridControl As DevExpress.XtraPivotGrid.PivotGridControl, ByRef PivotGridField As DevExpress.XtraPivotGrid.PivotGridField, ByVal IsReversedCheckBox As Boolean, ByVal CheckBoxValueType As AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType)

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

            RepositoryItemCheckEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

            If IsReversedCheckBox Then

                RepositoryItemCheckEdit.DisplayValueChecked = "Yes"
                RepositoryItemCheckEdit.DisplayValueUnchecked = "No"
                RepositoryItemCheckEdit.DisplayValueGrayed = "No"

                Select Case CheckBoxValueType

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.Boolean
                        RepositoryItemCheckEdit.ValueChecked = False
                        RepositoryItemCheckEdit.ValueUnchecked = True

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.Int16
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToInt16(0)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToInt16(1)

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.Int32
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToInt32(0)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToInt32(1)

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.String
                        RepositoryItemCheckEdit.ValueChecked = "N"
                        RepositoryItemCheckEdit.ValueUnchecked = "Y"

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.Byte
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToByte(0)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToByte(1)

                End Select

                RepositoryItemCheckEdit.ValueGrayed = Nothing

                RepositoryItemCheckEdit.NullText = "No"
                RepositoryItemCheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked

            Else

                RepositoryItemCheckEdit.DisplayValueChecked = "Yes"
                RepositoryItemCheckEdit.DisplayValueUnchecked = "No"
                RepositoryItemCheckEdit.DisplayValueGrayed = "No"

                Select Case CheckBoxValueType

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.Boolean
                        RepositoryItemCheckEdit.ValueChecked = True
                        RepositoryItemCheckEdit.ValueUnchecked = False

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.Int16
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToInt16(1)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToInt16(0)

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.Int32
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToInt32(1)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToInt32(0)

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.String
                        RepositoryItemCheckEdit.ValueChecked = "Y"
                        RepositoryItemCheckEdit.ValueUnchecked = "N"

                    Case AdvantageFramework.WinForm.Presentation.Controls.CheckBoxValueType.Byte
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToByte(1)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToByte(0)

                End Select

                RepositoryItemCheckEdit.ValueGrayed = Nothing

                RepositoryItemCheckEdit.NullText = "No"
                RepositoryItemCheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked

            End If

            PivotGridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

            PivotGridField.FieldEdit = RepositoryItemCheckEdit

        End Sub
        Public Sub AddSubItemNumericInput(ByVal PivotGridControl As DevExpress.XtraPivotGrid.PivotGridControl, ByVal PivotGridField As DevExpress.XtraPivotGrid.PivotGridField, ByVal SubItemNumericInputType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type, ByVal ObjectType As System.Type, ByVal IsNullable As Boolean)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim SubItemNumericInput As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput = Nothing
            Dim Scale As Long = 0
            Dim Precision As Long = 0
            Dim LoadedEntityFormat As Boolean = False
            Dim BaseClass As Object = Nothing

            SubItemNumericInput = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput

            SubItemNumericInput.ControlType = SubItemNumericInputType

            If SubItemNumericInputType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Default OrElse
                    SubItemNumericInputType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Decimal OrElse
                    SubItemNumericInputType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Currency Then

                PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(ObjectType, PivotGridField.FieldName)

                If PropertyDescriptor IsNot Nothing Then

                    If PivotGridField.CellFormat.FormatString Is Nothing OrElse PivotGridField.CellFormat.FormatString = "" Then

                        Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)

                        If Scale > 0 Then

                            If SubItemNumericInputType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Default OrElse SubItemNumericInputType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Decimal Then

                                SubItemNumericInput.SetFormatString("f" & Scale)
                                LoadedEntityFormat = True

                            ElseIf SubItemNumericInputType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type.Currency Then

                                SubItemNumericInput.SetFormatString("c" & Scale)
                                LoadedEntityFormat = True

                            End If

                        End If

                    End If

                    Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(PropertyDescriptor)

                    If Precision > 0 Then

                        SubItemNumericInput.MaxLength = Precision + 1

                    End If

                End If

            End If

            If IsNullable Then

                SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

            Else

                SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

            End If

            If LoadedEntityFormat = False AndAlso PivotGridField.CellFormat IsNot Nothing AndAlso PivotGridField.CellFormat.FormatString <> "" Then

                SubItemNumericInput.SetFormatString(PivotGridField.CellFormat.FormatString)

            End If

            PivotGridControl.RepositoryItems.Add(SubItemNumericInput)

            PivotGridField.FieldEdit = SubItemNumericInput

        End Sub
        Public Sub SetSuspendedForLoading(ByVal UserEntryControl As System.Windows.Forms.Control, ByVal SuspendedForLoading As Boolean)

			For Each Control In UserEntryControl.Controls.OfType(Of System.Windows.Forms.Control)()

				SetSuspendedForLoading(Control, SuspendedForLoading)

				If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl Then

					DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).SuspendedForLoading = SuspendedForLoading

				End If

			Next

		End Sub
		Public Sub SetByPassUserEntryChanged(ByVal UserEntryControl As System.Windows.Forms.Control, ByVal ByPassUserEntryChanged As Boolean)

			'objects
			Dim UserEntryChanged As Boolean = False

			For Each Control In UserEntryControl.Controls.OfType(Of System.Windows.Forms.Control)()

				SetByPassUserEntryChanged(Control, ByPassUserEntryChanged)

				If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl Then

					DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ByPassUserEntryChanged = ByPassUserEntryChanged

				End If

			Next

		End Sub
		Public Function CheckUserEntryChangedSetting(ByVal UserEntryControl As System.Windows.Forms.Control) As Boolean

			'objects
			Dim UserEntryChanged As Boolean = False

			For Each Control In UserEntryControl.Controls.OfType(Of System.Windows.Forms.Control)()

				UserEntryChanged = CheckUserEntryChangedSetting(Control)

				If UserEntryChanged = False Then

					If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl Then

						UserEntryChanged = DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).UserEntryChanged

						If UserEntryChanged Then

							Exit For

						End If

					End If

				Else

					Exit For

				End If

			Next

			CheckUserEntryChangedSetting = UserEntryChanged

		End Function
		Public Sub CloseEditorsOnDataGridViews(ByVal Control As System.Windows.Forms.Control)

			For Each FormControl In Control.Controls.OfType(Of System.Windows.Forms.Control)()

				If TypeOf FormControl Is AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView Then

					DirectCast(FormControl, AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView).CurrentView.CloseEditorForUpdating()

				ElseIf TypeOf FormControl Is AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView Then

					DirectCast(FormControl, AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView).CurrentView.CloseEditorForUpdating()

				Else

					CloseEditorsOnDataGridViews(FormControl)

				End If

			Next

		End Sub
		Public Sub ClearUserEntryChangedSetting(ByVal UserEntryControl As System.Windows.Forms.Control)

			For Each Control In UserEntryControl.Controls.OfType(Of System.Windows.Forms.Control)()

				ClearUserEntryChangedSetting(Control)

				If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl Then

					DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ClearChanged()

				End If

			Next

		End Sub
		Public Sub SetTextOnButtonItem(ByRef ButtonItem As DevComponents.DotNetBar.ButtonItem, ByVal Text As String)

			If ButtonItem.InvokeRequired Then

				ButtonItem.Invoke(New SetTextOnButtonItemDelegate(AddressOf SetTextOnButtonItem), New Object() {ButtonItem, Text})

			Else

				ButtonItem.Text = Text

			End If

		End Sub
		Public Sub SetTextOnSideBarPanelItem(ByRef SideBarPanelItem As DevComponents.DotNetBar.SideBarPanelItem, ByVal Text As String)

			If SideBarPanelItem.InvokeRequired Then

				SideBarPanelItem.Invoke(New SetTextOnSideBarPanelItemDelegate(AddressOf SetTextOnSideBarPanelItem), New Object() {SideBarPanelItem, Text})

			Else

				SideBarPanelItem.Text = Text

			End If

		End Sub
		Public Sub SetTextOnControl(ByRef Control As System.Windows.Forms.Control, ByVal Text As String)

			If Control.InvokeRequired Then

				Control.Invoke(New SetTextOnControlDelegate(AddressOf SetTextOnControl), New Object() {Control, Text})

			Else

				Control.Text = Text

			End If

		End Sub
		Public Sub SetCheckedOnButtonItem(ByRef ButtonItem As DevComponents.DotNetBar.ButtonItem, ByVal Checked As Boolean)

			If ButtonItem.InvokeRequired Then

				ButtonItem.Invoke(New SetCheckedOnButtonItemDelegate(AddressOf SetCheckedOnButtonItem), New Object() {ButtonItem, Checked})

			Else

				ButtonItem.Checked = Checked
			End If

		End Sub
		Public Sub SetVisibleOnBubbleBar(ByRef BubbleBar As DevComponents.DotNetBar.BubbleBar, ByVal Visible As Boolean)

			If BubbleBar.InvokeRequired Then

				BubbleBar.Invoke(New SetVisibleOnBubbleBarDelegate(AddressOf SetVisibleOnBubbleBar), New Object() {BubbleBar, Visible})

			Else

				BubbleBar.Visible = Visible

			End If

		End Sub
		Public Sub SetTextOnLabelItem(ByRef LabelItem As DevComponents.DotNetBar.LabelItem, ByVal Text As String)

			If LabelItem.InvokeRequired Then

				LabelItem.Invoke(New SetTextOnLabelItemDelegate(AddressOf SetTextOnLabelItem), New Object() {LabelItem, Text})

			Else

				LabelItem.Text = Text

			End If

		End Sub
		Public Sub SetVisibleOnDockContainerItemControl(ByRef DockContainerItem As DevComponents.DotNetBar.DockContainerItem, ByVal Visible As Boolean)

			'objects
			Dim SetVisibleOnDockContainerItem As SetVisibleOnDockContainerItemControlDelegate = Nothing

			If DockContainerItem.InvokeRequired Then

				SetVisibleOnDockContainerItem = New SetVisibleOnDockContainerItemControlDelegate(AddressOf SetVisibleOnDockContainerItemControl)

				DockContainerItem.Invoke(SetVisibleOnDockContainerItem, New Object() {DockContainerItem, Visible})

			Else

				DockContainerItem.Visible = Visible

			End If

		End Sub
		Public Sub SetVisibleOnControl(ByRef Control As System.Windows.Forms.Control, ByVal Visible As Boolean)

			'objects
			Dim SetVisibleDelegate As SetVisibleOnControlDelegate = Nothing

			If Control.InvokeRequired Then

				SetVisibleDelegate = New SetVisibleOnControlDelegate(AddressOf SetVisibleOnControl)

				Control.Invoke(SetVisibleDelegate, New Object() {Control, Visible})

			Else

				Control.Visible = Visible

			End If

		End Sub
		Public Sub ResumeBindingOnABindingSource(ByVal DataSource As Object)

			If DataSource IsNot Nothing AndAlso
					TypeOf DataSource Is System.Windows.Forms.BindingSource Then

				DirectCast(DataSource, System.Windows.Forms.BindingSource).ResumeBinding()

			End If

		End Sub
		Public Sub SuspendBindingOnABindingSource(ByVal DataSource As Object)

			If DataSource IsNot Nothing AndAlso
					TypeOf DataSource Is System.Windows.Forms.BindingSource Then

				DirectCast(DataSource, System.Windows.Forms.BindingSource).SuspendBinding()

			End If

		End Sub
		Public Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

			For Each Control In Form.Controls.OfType(Of System.Windows.Forms.Control)()

				LoadFormSettings(Form, Control)

				If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl Then

					DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl).LoadFormSettings(Form)

				End If

			Next

		End Sub
		Private Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form, ByVal UserEntryControl As System.Windows.Forms.Control)

			For Each Control In UserEntryControl.Controls.OfType(Of System.Windows.Forms.Control)()

				LoadFormSettings(Form, Control)

				If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl Then

					DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl).LoadFormSettings(Form)

				End If

			Next

		End Sub
		Public Sub SetTextOnLabelControl(ByRef Label As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label, ByVal [Text] As String)

			'objects
			Dim SetTextDelegate As SetTextOnLabelControlDelegate = Nothing

			If Label.InvokeRequired Then

				SetTextDelegate = New SetTextOnLabelControlDelegate(AddressOf SetTextOnLabelControl)

				Label.Invoke(SetTextDelegate, New Object() {Label, [Text]})

			Else

				Label.Text = [Text]

			End If

		End Sub
		Public Sub SetTextOnTextBoxControl(ByRef TextBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox, ByVal [Text] As String)

			'objects
			Dim SetTextDelegate As SetTextOnTextBoxControlDelegate = Nothing

			If TextBox.InvokeRequired Then

				SetTextDelegate = New SetTextOnTextBoxControlDelegate(AddressOf SetTextOnTextBoxControl)

				TextBox.Invoke(SetTextDelegate, New Object() {TextBox, [Text]})

			Else

				TextBox.Text = [Text]

			End If

		End Sub
		Friend Sub AddComboBoxColumn(ByVal [Property] As [Enum], ByRef DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

			'objects
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
			Dim RepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = Nothing

			PropertyDescriptor = AdvantageFramework.ClassUtilities.GetPropertyDescriptorByPropertyNameFromType([Property].ToString, System.ComponentModel.TypeDescriptor.GetReflectionType([Property].GetType).DeclaringType)

			If PropertyDescriptor IsNot Nothing Then

				GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

				FormatColumn(PropertyDescriptor, GridColumn, IsVisible)

				RepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox

				RepositoryItemComboBox.AutoHeight = False
				RepositoryItemComboBox.Name = "RepositoryItemComboBox" & GridColumn.Name

				GridColumn.OptionsColumn.AllowEdit = True

				DataGridView.GridControl.RepositoryItems.Add(RepositoryItemComboBox)
				GridColumn.ColumnEdit = RepositoryItemComboBox

				DataGridView.Columns.Add(GridColumn)

			End If

		End Sub
		Friend Sub AddComboBoxColumn(ByVal Name As String, ByRef DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

			'objects
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
			Dim RepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = Nothing

			GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

			FormatColumn(Name, Name, AdvantageFramework.StringUtilities.GetNameAsWords(Name).Trim, GridColumn, IsVisible)

			RepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox

			RepositoryItemComboBox.AutoHeight = False
			RepositoryItemComboBox.Name = "RepositoryItemComboBox" & GridColumn.Name

			GridColumn.OptionsColumn.AllowEdit = True

			DataGridView.GridControl.RepositoryItems.Add(RepositoryItemComboBox)
			GridColumn.ColumnEdit = RepositoryItemComboBox

			DataGridView.Columns.Add(GridColumn)

		End Sub
		Friend Sub AddComboBoxColumn(ByVal Name As String, ByRef BandedDataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView, Optional ByVal IsVisible As Boolean = True)

			'objects
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
			Dim RepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = Nothing

			GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

			FormatColumn(Name, Name, AdvantageFramework.StringUtilities.GetNameAsWords(Name).Trim, GridColumn, IsVisible)

			RepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox

			RepositoryItemComboBox.AutoHeight = False
			RepositoryItemComboBox.Name = "RepositoryItemComboBox" & GridColumn.Name

			GridColumn.OptionsColumn.AllowEdit = True

			BandedDataGridView.GridControl.RepositoryItems.Add(RepositoryItemComboBox)
			GridColumn.ColumnEdit = RepositoryItemComboBox

			BandedDataGridView.Columns.Add(GridColumn)

		End Sub
		Friend Sub AddColumn(ByVal Name As String, ByRef DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

			'objects
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

			GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

			FormatColumn(Name, Name, AdvantageFramework.StringUtilities.GetNameAsWords(Name).Trim, GridColumn, IsVisible)

			DataGridView.Columns.Add(GridColumn)

		End Sub
		Friend Sub AddColumn(ByVal Name As String, ByRef BandedDataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView, Optional ByVal IsVisible As Boolean = True)

			'objects
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

			GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

			FormatColumn(Name, Name, AdvantageFramework.StringUtilities.GetNameAsWords(Name).Trim, GridColumn, IsVisible)

			BandedDataGridView.Columns.Add(GridColumn)

		End Sub
		Friend Sub AddColumn(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

			'objects
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

			If PropertyDescriptor IsNot Nothing Then

				GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

				FormatColumn(PropertyDescriptor, GridColumn, IsVisible)

				DataGridView.Columns.Add(GridColumn)

			End If

		End Sub
		Friend Sub AddColumn(ByVal [Property] As [Enum], ByRef DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

			'objects
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

			PropertyDescriptor = AdvantageFramework.ClassUtilities.GetPropertyDescriptorByPropertyNameFromType([Property].ToString, System.ComponentModel.TypeDescriptor.GetReflectionType([Property].GetType).DeclaringType)

			If PropertyDescriptor IsNot Nothing Then

				GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

				FormatColumn(PropertyDescriptor, GridColumn, IsVisible)

				DataGridView.Columns.Add(GridColumn)

			End If

		End Sub
		Friend Sub FormatColumn(ByVal Name As String, ByVal FieldName As String, ByVal Caption As String, ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, Optional ByVal IsVisible As Boolean = True)

			GridColumn.Name = Name
			GridColumn.FieldName = FieldName
			GridColumn.Caption = Caption
			GridColumn.Visible = IsVisible
			GridColumn.OptionsColumn.AllowEdit = False

		End Sub
		Friend Sub FormatColumn(ByRef PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, Optional ByVal IsVisible As Boolean = True)

			If PropertyDescriptor IsNot Nothing AndAlso GridColumn IsNot Nothing Then

				If PropertyDescriptor.DisplayName = PropertyDescriptor.Name OrElse PropertyDescriptor.DisplayName = "" Then

					FormatColumn(PropertyDescriptor.Name, PropertyDescriptor.Name, AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name).Trim, GridColumn, IsVisible)

				Else

					FormatColumn(PropertyDescriptor.Name, PropertyDescriptor.Name, PropertyDescriptor.DisplayName, GridColumn, IsVisible)

				End If

			End If

		End Sub
		Public Sub AddComboItemToExistingDataSource(ByVal BindingSource As System.Windows.Forms.BindingSource, ByVal DisplayMember As String, ByVal ValueMember As String,
													 ByVal DisplayValue As String, ByVal Value As String,
													 ByVal InsertInFirstPosition As Boolean, ByVal IsExtraComboItem As Boolean,
													 Optional ByRef AddedItemsToDataSource As Generic.List(Of Object) = Nothing,
													 Optional ByVal PostionIndex As Integer = -1)

			'objects
			Dim DataBoundType As System.Type = Nothing
			Dim NewListItem = Nothing
			Dim ParametersList As Generic.List(Of Object) = Nothing
			Dim DataTable As System.Data.DataTable = Nothing
			Dim DataRow As System.Data.DataRow = Nothing
			Dim UnderlyingType As System.Type = Nothing
			Dim ConstructorInfos() As System.Reflection.ConstructorInfo = Nothing
			Dim HasConstructor As Boolean = False
			Dim PropertyInfo As System.Reflection.PropertyInfo = Nothing

			AdvantageFramework.WinForm.MVC.Presentation.Controls.SuspendBindingOnABindingSource(BindingSource)

			Try

				If TypeOf BindingSource.List Is System.Data.DataView Then

					DataRow = DirectCast(BindingSource.List, System.Data.DataView).Table.NewRow

					For Each Column In DirectCast(BindingSource.List, System.Data.DataView).Table.Columns.OfType(Of System.Data.DataColumn).ToList

						If Column.ColumnName = ValueMember Then

							DataRow(Column.ColumnName) = If(Value Is Nothing OrElse Value = Nothing, System.DBNull.Value, Value)

						ElseIf Column.ColumnName = DisplayMember Then

							DataRow(Column.ColumnName) = DisplayValue

						End If

					Next

					If InsertInFirstPosition Then

						DirectCast(BindingSource.List, System.Data.DataView).Table.Rows.InsertAt(DataRow, 0)

					Else

						If PostionIndex = -1 Then

							DirectCast(BindingSource.List, System.Data.DataView).Table.Rows.Add(DataRow)

						Else

							DirectCast(BindingSource.List, System.Data.DataView).Table.Rows.InsertAt(DataRow, PostionIndex)

						End If

					End If

				ElseIf DisplayMember = ValueMember Then

					DataBoundType = System.Type.GetType(BindingSource.List.AsQueryable.ElementType.AssemblyQualifiedName)

					ParametersList = New Generic.List(Of Object)

					For Each PropertyInfo In DataBoundType.GetProperties

						UnderlyingType = GetUnderlyingType(PropertyInfo.PropertyType)

						If UnderlyingType Is GetType(String) Then

							If PropertyInfo.Name = ValueMember Then

								ParametersList.Add(CStr(Value))

							Else

								ParametersList.Add(CStr(DisplayValue))

							End If

						ElseIf UnderlyingType Is GetType(Long) Then

							If PropertyInfo.Name = ValueMember Then

								If IsNumeric(Value) Then

									ParametersList.Add(CLng(Value))

								Else

									ParametersList.Add(Nothing)

								End If

							Else

								If IsNumeric(DisplayValue) Then

									ParametersList.Add(CLng(DisplayValue))

								Else

									ParametersList.Add(Nothing)

								End If

							End If

						ElseIf UnderlyingType Is GetType(Decimal) Then

							If PropertyInfo.Name = ValueMember Then

								If IsNumeric(Value) Then

									ParametersList.Add(CDec(Value))

								Else

									ParametersList.Add(Nothing)

								End If

							Else

								If IsNumeric(DisplayValue) Then

									ParametersList.Add(CDec(DisplayValue))

								Else

									ParametersList.Add(Nothing)

								End If

							End If

						ElseIf UnderlyingType Is GetType(Integer) Then

							If PropertyInfo.Name = ValueMember Then

								If IsNumeric(Value) Then

									ParametersList.Add(CInt(Value))

								Else

									ParametersList.Add(Nothing)

								End If

							Else

								If IsNumeric(DisplayValue) Then

									ParametersList.Add(CInt(DisplayValue))

								Else

									ParametersList.Add(Nothing)

								End If

							End If

						ElseIf UnderlyingType Is GetType(Short) Then

							If PropertyInfo.Name = ValueMember Then

								If IsNumeric(Value) Then

									ParametersList.Add(CShort(Value))

								Else

									ParametersList.Add(Nothing)

								End If

							Else

								If IsNumeric(DisplayValue) Then

									ParametersList.Add(CShort(DisplayValue))

								Else

									ParametersList.Add(Nothing)

								End If

							End If

						Else

							If Not (PropertyInfo.DeclaringType IsNot Nothing AndAlso PropertyInfo.DeclaringType.Name = "Attribute" AndAlso PropertyInfo.Name = "TypeId") Then

								ParametersList.Add(Nothing)

							Else

								If PropertyInfo.Name = ValueMember Then

									ParametersList.Add(CObj(Value))

								Else

									ParametersList.Add(CObj(DisplayValue))

								End If

							End If

						End If

					Next

					ConstructorInfos = DataBoundType.GetConstructors()

					For Each ConstructorInfo In ConstructorInfos

						If ConstructorInfo.GetParameters.Count = ParametersList.Count Then

							HasConstructor = True
							Exit For

						End If

					Next

					If HasConstructor Then

						NewListItem = System.Activator.CreateInstance(DataBoundType, ParametersList.ToArray)

						If InsertInFirstPosition Then

							BindingSource.Insert(0, NewListItem)

						Else

							If PostionIndex = -1 Then

								BindingSource.Add(NewListItem)

							Else

								BindingSource.Insert(PostionIndex, NewListItem)

							End If

						End If

					End If

				Else

					DataBoundType = System.Type.GetType(BindingSource.List.AsQueryable.ElementType.AssemblyQualifiedName)

					ParametersList = New Generic.List(Of Object)

					For Each PropertyInfo In DataBoundType.GetProperties

						UnderlyingType = GetUnderlyingType(PropertyInfo.PropertyType)

						If PropertyInfo.Name = DisplayMember Then

							If UnderlyingType Is GetType(String) Then

								ParametersList.Add(DisplayValue)

							End If

						ElseIf PropertyInfo.Name = ValueMember Then

							If UnderlyingType Is GetType(String) Then

								ParametersList.Add(CStr(Value))

							ElseIf UnderlyingType Is GetType(Long) Then

								If IsNumeric(Value) Then

									ParametersList.Add(CLng(Value))

								Else

									ParametersList.Add(Nothing)

								End If

							ElseIf UnderlyingType Is GetType(Decimal) Then

								If IsNumeric(Value) Then

									ParametersList.Add(CDec(Value))

								Else

									ParametersList.Add(Nothing)

								End If

							ElseIf UnderlyingType Is GetType(Integer) Then

								If IsNumeric(Value) Then

									ParametersList.Add(CInt(Value))

								Else

									ParametersList.Add(Nothing)

								End If

							ElseIf UnderlyingType Is GetType(Short) Then

								If IsNumeric(Value) Then

									ParametersList.Add(CShort(Value))

								Else

									ParametersList.Add(Nothing)

								End If

							Else

								ParametersList.Add(CObj(Value))

							End If

						Else

							If Not (PropertyInfo.DeclaringType IsNot Nothing AndAlso PropertyInfo.DeclaringType.Name = "Attribute" AndAlso PropertyInfo.Name = "TypeId") AndAlso
									DataBoundType.FullName <> GetType(AdvantageFramework.DTO.ComboBoxItem).FullName Then

								ParametersList.Add(Nothing)

							End If

						End If

					Next

					ConstructorInfos = DataBoundType.GetConstructors()

					For Each ConstructorInfo In ConstructorInfos

						If ConstructorInfo.GetParameters.Count = ParametersList.Count Then

							HasConstructor = True
							Exit For

						End If

					Next

					If HasConstructor Then

						NewListItem = System.Activator.CreateInstance(DataBoundType, ParametersList.ToArray)

						If InsertInFirstPosition Then

							BindingSource.Insert(0, NewListItem)

						Else

							If PostionIndex = -1 Then

								BindingSource.Add(NewListItem)

							Else

								BindingSource.Insert(PostionIndex, NewListItem)

							End If

						End If

					ElseIf DataBoundType.GetConstructors().Any(Function(ConstructorInfo) ConstructorInfo.GetParameters.Count = 0) Then

						NewListItem = System.Activator.CreateInstance(DataBoundType)

						PropertyInfo = NewListItem.GetType().GetProperty(DisplayMember, System.Reflection.BindingFlags.[Public] Or Reflection.BindingFlags.Instance)

						If PropertyInfo IsNot Nothing AndAlso PropertyInfo.CanWrite Then

							PropertyInfo.SetValue(NewListItem, DisplayValue, Nothing)

						End If

						PropertyInfo = NewListItem.GetType().GetProperty(ValueMember, System.Reflection.BindingFlags.[Public] Or Reflection.BindingFlags.Instance)

						If PropertyInfo IsNot Nothing AndAlso PropertyInfo.CanWrite Then

							UnderlyingType = GetUnderlyingType(PropertyInfo.PropertyType)

							If UnderlyingType Is GetType(String) Then

								PropertyInfo.SetValue(NewListItem, CStr(Value), Nothing)

							ElseIf UnderlyingType Is GetType(Long) Then

								If IsNumeric(Value) Then

									PropertyInfo.SetValue(NewListItem, CLng(Value), Nothing)

								Else

									PropertyInfo.SetValue(NewListItem, Nothing, Nothing)

								End If

							ElseIf UnderlyingType Is GetType(Decimal) Then

								If IsNumeric(Value) Then

									PropertyInfo.SetValue(NewListItem, CDec(Value), Nothing)

								Else

									PropertyInfo.SetValue(NewListItem, Nothing, Nothing)

								End If

							ElseIf UnderlyingType Is GetType(Integer) Then

								If IsNumeric(Value) Then

									PropertyInfo.SetValue(NewListItem, CInt(Value), Nothing)

								Else

									PropertyInfo.SetValue(NewListItem, Nothing, Nothing)

								End If

							ElseIf UnderlyingType Is GetType(Short) Then

								If IsNumeric(Value) Then

									PropertyInfo.SetValue(NewListItem, CShort(Value), Nothing)

								Else

									PropertyInfo.SetValue(NewListItem, Nothing, Nothing)

								End If

							Else

								PropertyInfo.SetValue(NewListItem, Value, Nothing)

							End If

						End If

						If InsertInFirstPosition Then

							BindingSource.Insert(0, NewListItem)

						Else

							If PostionIndex = -1 Then

								BindingSource.Add(NewListItem)

							Else

								BindingSource.Insert(PostionIndex, NewListItem)

							End If

						End If

					End If

				End If

			Catch ex As Exception
				DataBoundType = Nothing
				NewListItem = Nothing
				ParametersList = Nothing
			End Try

			Try

				If IsExtraComboItem = False AndAlso NewListItem IsNot Nothing AndAlso AddedItemsToDataSource IsNot Nothing Then

					AddedItemsToDataSource.Add(NewListItem)

				End If

			Catch ex As Exception

			End Try

			AdvantageFramework.WinForm.MVC.Presentation.Controls.ResumeBindingOnABindingSource(BindingSource)

		End Sub
		Public Function FindObjectInDataSource(ByVal BindingSource As System.Windows.Forms.BindingSource, ByVal PropertyName As String, ByVal Value As Object) As Object

			'objects
			Dim DataBoundType As System.Type = Nothing
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
			Dim FoundObject As Object = Nothing

			AdvantageFramework.WinForm.MVC.Presentation.Controls.SuspendBindingOnABindingSource(BindingSource)

			Try

				DataBoundType = System.Type.GetType(BindingSource.List.AsQueryable.ElementType.AssemblyQualifiedName)

				PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(DataBoundType).Find(PropertyName, False)

				For Each ListObject As Object In BindingSource

					If PropertyDescriptor.GetValue(ListObject) = Value Then

						FoundObject = ListObject
						Exit For

					End If

				Next

			Catch ex As Exception
				DataBoundType = Nothing
				FoundObject = Nothing
			End Try

			AdvantageFramework.WinForm.MVC.Presentation.Controls.ResumeBindingOnABindingSource(BindingSource)

			FindObjectInDataSource = FoundObject

		End Function
		Public Function ValidateControl(ByVal [Form] As System.Windows.Forms.Form, ByVal [Control] As System.Windows.Forms.Control) As Boolean

			'objects
			Dim IsValid As Boolean = True

			Try

				If TypeOf [Form] Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm Then

					IsValid = DirectCast([Form], AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).ValidateControl([Control])

				ElseIf TypeOf [Form] Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm Then

					IsValid = DirectCast([Form], AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).ValidateControl([Control])

				End If

			Catch ex As Exception
				IsValid = True
			Finally
				ValidateControl = IsValid
			End Try

		End Function
		Public Function GetNewColumn(ByVal FieldName As String, Optional ByVal Visible As Boolean = True, Optional ByVal Caption As String = "") As DevExpress.XtraGrid.Columns.GridColumn

			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

			GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

			If Caption = "" Then

				GridColumn.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(FieldName)

			Else

				GridColumn.Caption = Caption

			End If

			GridColumn.FieldName = FieldName
			GridColumn.Visible = Visible

			GetNewColumn = GridColumn

		End Function
		Public Function GetUnderlyingType(ByVal PropertyType As System.Type) As System.Type

			'objects
			Dim UnderlyingType As System.Type = Nothing

			Try

				If Nullable.GetUnderlyingType(PropertyType) IsNot Nothing Then

					UnderlyingType = Nullable.GetUnderlyingType(PropertyType)

				Else

					UnderlyingType = PropertyType

				End If

			Catch ex As Exception
				UnderlyingType = PropertyType
			Finally
				GetUnderlyingType = UnderlyingType
			End Try

		End Function
		Public Function GetFormAction(ByVal Form As System.Windows.Forms.Form) As AdvantageFramework.WinForm.Presentation.FormActions

			'objects
			Dim FormAction As AdvantageFramework.WinForm.Presentation.FormActions = Nothing

			If Form IsNot Nothing Then

				If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm Then

					FormAction = DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).FormAction

				ElseIf TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm Then

					FormAction = DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).FormAction

				End If

			End If

			GetFormAction = FormAction

		End Function

#Region "  Repository Items "

        Public Function CreateSubItemGridLookupEdit(ByVal SubItemComboBoxType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type,
                                                    ByVal FieldName As String, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute,
                                                    ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                    Optional ByVal EnumType As System.Type = Nothing, Optional ByVal AllowExtraComboItems As Boolean = True) As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            Try

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.EnumType = EnumType

                If PropertyDescriptor IsNot Nothing Then

                    SubItemGridLookUpEditControl.ValueType = PropertyDescriptor.PropertyType

                    If PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.ExpenseReportItem) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.PostPeriod) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.PostPeriod) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.GLATrailer) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.PurchaseOrderDetail) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.NonbilledEmployeeTime) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.EmployeeTimeTemplate) OrElse
                           (PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) AndAlso
                            (FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientCode.ToString OrElse
                             FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString OrElse
                             FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString OrElse
                             FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeTitleID.ToString OrElse
                             FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionCode.ToString OrElse
                             FieldName = AdvantageFramework.Database.Classes.BillingRateDetail.Properties.SalesClassCode.ToString)) OrElse
                           (PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.Ad) AndAlso
                            (FieldName = AdvantageFramework.Database.Entities.Ad.Properties.BlackplateCode1.ToString OrElse
                             FieldName = AdvantageFramework.Database.Entities.Ad.Properties.BlackplateCode2.ToString)) OrElse
                            (PropertyDescriptor.ComponentType = GetType(AdvantageFramework.Database.Entities.EstimateProcessingOption) AndAlso
                             FieldName = AdvantageFramework.Database.Entities.EstimateProcessingOption.Properties.ExceedOption.ToString) OrElse
                            PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                    ElseIf PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.EmployeeHRInformation) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.EmployeeGeneralInformation) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.EmployeeSetting) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Views.ExpenseSummary) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.DigitalResult) OrElse
                           PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.DigitalResultsView) OrElse
                           (PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) AndAlso
                            (FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobClientCode.ToString OrElse
                             FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString OrElse
                             FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.FunctionCode.ToString OrElse
                             FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString)) Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                    ElseIf (PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData) AndAlso
                            (FieldName = AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData.Properties.PlanID.ToString OrElse
                             FieldName = AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData.Properties.EstimateID.ToString)) OrElse
                           (PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) AndAlso
                            FieldName = AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceCategoryCode.ToString) OrElse
                           (PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting) AndAlso
                            FieldName = AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting.Properties.CustomFormatName.ToString) OrElse
                           (PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt) AndAlso
                            FieldName = AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.PaymentTypeDescription.ToString) Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                    ElseIf EntityAttribute IsNot Nothing AndAlso EntityAttribute.IsRequired = False Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.NullValue

                    End If

                    If PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.OfficeSalesTaxAccount) AndAlso
                            FieldName = AdvantageFramework.Database.Entities.OfficeSalesTaxAccount.Properties.SalesTaxCode.ToString Then

                        SubItemGridLookUpEditControl.IncludeInactive = True

                    End If

                    If AdvantageFramework.BaseClasses.Entity.LoadPropertyIsNullable(PropertyDescriptor) Then

                        SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                    End If

                Else

                    If EntityAttribute IsNot Nothing AndAlso EntityAttribute.IsRequired = False Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.NullValue

                    End If

                End If

                SubItemGridLookUpEditControl.ControlType = SubItemComboBoxType

                If PropertyDescriptor IsNot Nothing Then

                    If PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Classes.NonbilledEmployeeTime) OrElse
                            PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                    ElseIf PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) Then

                        If SubItemGridLookUpEditControl.ControlType = Controls.SubItemGridLookUpEditControl.Type.Campaign Then

                            If FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignID.ToString Then

                                SubItemGridLookUpEditControl.DisplayMember = "ID"

                                If SubItemGridLookUpEditControl.View.Columns("ID") IsNot Nothing Then

                                    SubItemGridLookUpEditControl.View.Columns("ID").Visible = True

                                End If

                            End If

                        End If

                    End If

                End If

                If AllowExtraComboItems = False Then

                    SubItemGridLookUpEditControl.ExtraComboBoxItem = False

                End If

            Catch ex As Exception
                SubItemGridLookUpEditControl = Nothing
            Finally
                CreateSubItemGridLookupEdit = SubItemGridLookUpEditControl
            End Try

        End Function
        Public Function CreateSubItemNumericInput(ByVal SubItemNumericInputType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput.Type,
                                                  ByVal FieldName As String, ByVal FormatString As String, ByVal IsNullable As Boolean,
                                                  ByVal ObjectType As System.Type, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute) As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput

            'objects
            Dim SubItemNumericInput As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim Scale As Long = 0
            Dim Precision As Long = 0
            Dim LoadedEntityFormat As Boolean = False
            Dim BaseClass As Object = Nothing
            Dim ActualObjectType As System.Type = Nothing

            Try

                SubItemNumericInput = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemNumericInput

                SubItemNumericInput.ControlType = SubItemNumericInputType

                If SubItemNumericInputType = Controls.SubItemNumericInput.Type.Default OrElse
                           SubItemNumericInputType = Controls.SubItemNumericInput.Type.Decimal OrElse
                           SubItemNumericInputType = Controls.SubItemNumericInput.Type.Currency Then

                    If ObjectType IsNot Nothing AndAlso ObjectType.IsSubclassOf(GetType(AdvantageFramework.BaseClasses.BaseClass)) Then

                        Try

                            If ObjectType.GetConstructor(Type.EmptyTypes) IsNot Nothing Then

                                BaseClass = System.Activator.CreateInstance(ObjectType)

                                If DirectCast(BaseClass, AdvantageFramework.BaseClasses.BaseClass).AttachedEntityType IsNot Nothing Then

                                    ActualObjectType = DirectCast(BaseClass, AdvantageFramework.BaseClasses.BaseClass).AttachedEntityType

                                End If

                            End If

                        Catch ex As Exception
                            ActualObjectType = ObjectType
                        End Try

                    End If

                    If ActualObjectType Is Nothing Then

                        ActualObjectType = ObjectType

                    End If

                    PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(ActualObjectType, FieldName)

                    If PropertyDescriptor IsNot Nothing Then

                        If FormatString Is Nothing OrElse FormatString = "" Then

                            Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)

                            If Scale > 0 Then

                                If SubItemNumericInputType = Controls.SubItemNumericInput.Type.Default OrElse SubItemNumericInputType = Controls.SubItemNumericInput.Type.Decimal Then

                                    SubItemNumericInput.SetFormatString("f" & Scale)
                                    LoadedEntityFormat = True

                                ElseIf SubItemNumericInputType = Controls.SubItemNumericInput.Type.Currency Then

                                    SubItemNumericInput.SetFormatString("c" & Scale)
                                    LoadedEntityFormat = True

                                End If

                            End If

                        End If

                        Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(PropertyDescriptor)

                        If Precision > 0 Then

                            SubItemNumericInput.MaxLength = Precision + 1

                        End If

                    End If

                End If

                If IsNullable Then

                    SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

                Else

                    SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                End If

                If LoadedEntityFormat = False AndAlso FormatString <> "" Then

                    SubItemNumericInput.SetFormatString(FormatString)

                End If

                If EntityAttribute IsNot Nothing Then

                    If EntityAttribute.UseMinValue Then ' AndAlso EntityAttribute.MinValue <> Nothing Then

                        SubItemNumericInput.MinValue = CDec(EntityAttribute.MinValue)

                    End If

                    If EntityAttribute.UseMaxValue Then 'AndAlso EntityAttribute.MaxValue <> Nothing Then

                        SubItemNumericInput.MaxValue = CDec(EntityAttribute.MaxValue)
                        SubItemNumericInput.MaxLength = SubItemNumericInput.MaxValue.ToString.Length + 1

                    End If

                End If

                SubItemNumericInput.AllowMouseWheel = False

                If ObjectType Is GetType(AdvantageFramework.Database.Entities.Phase) AndAlso FieldName = AdvantageFramework.Database.Entities.Phase.Properties.OrderNumber.ToString Then

                    SubItemNumericInput.MaxLength = 6

                ElseIf FieldName = AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.Hours.ToString AndAlso
                       ObjectType Is GetType(AdvantageFramework.Database.Entities.EstimateTemplateDetail) Then

                    SubItemNumericInput.MaxLength = 12

                ElseIf FieldName = AdvantageFramework.Database.Entities.CurrencyDetail.Properties.ExchangeRate.ToString AndAlso
                       ObjectType Is GetType(AdvantageFramework.Database.Entities.CurrencyDetail) Then

                    SubItemNumericInput.MaxLength = 13

                ElseIf (FieldName = AdvantageFramework.Database.Entities.SalesTax.Properties.StatePercent.ToString OrElse
                        FieldName = AdvantageFramework.Database.Entities.SalesTax.Properties.CountyPercent.ToString OrElse
                        FieldName = AdvantageFramework.Database.Entities.SalesTax.Properties.CityPercent.ToString) AndAlso
                        ObjectType Is GetType(AdvantageFramework.Database.Entities.SalesTax) Then

                    SubItemNumericInput.MaxLength = 9

                ElseIf FieldName = AdvantageFramework.Database.Classes.BillingCoop.Properties.Percent.ToString AndAlso
                        ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingCoop) Then

                    SubItemNumericInput.SetFormatString("n3")
                    SubItemNumericInput.MinValue = 0
                    SubItemNumericInput.MaxValue = 100

                ElseIf FieldName = AdvantageFramework.Database.Entities.Associate.Properties.Percent.ToString AndAlso
                        ObjectType Is GetType(AdvantageFramework.Database.Entities.Associate) Then

                    SubItemNumericInput.MaxLength = 7
                    SubItemNumericInput.MinValue = 0
                    SubItemNumericInput.MaxValue = 100

                ElseIf ObjectType Is GetType(AdvantageFramework.Database.Classes.ExpenseReportItem) AndAlso
                      FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.Quantity.ToString Then

                    SubItemNumericInput.MaxLength = 14
                    SubItemNumericInput.MaxValue = 2147483647

                ElseIf FieldName = AdvantageFramework.Database.Entities.PartnerAllocationDetail.Properties.PercentAllocation.ToString AndAlso
                        ObjectType Is GetType(AdvantageFramework.Database.Entities.PartnerAllocationDetail) Then

                    SubItemNumericInput.SetFormatString("##0.##0")
                    SubItemNumericInput.MinValue = 0
                    SubItemNumericInput.MaxValue = 100

                ElseIf FieldName = AdvantageFramework.Database.Classes.NonbilledEmployeeTime.Properties.BillingRate.ToString AndAlso
                       ObjectType Is GetType(AdvantageFramework.Database.Classes.NonbilledEmployeeTime) Then

                    SubItemNumericInput.MinValue = 0
                    SubItemNumericInput.MaxLength = 10
                    SubItemNumericInput.SetFormatString("n" & 2)

                ElseIf (ObjectType Is GetType(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) AndAlso
                     (FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString OrElse
                      FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString OrElse
                      FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString OrElse
                      FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString OrElse
                      FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString OrElse
                      FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString OrElse
                      FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString)) OrElse
                    (ObjectType Is GetType(AdvantageFramework.EmployeeTimesheet.Classes.CommentView) AndAlso
                     FieldName = AdvantageFramework.EmployeeTimesheet.Classes.CommentView.Properties.CommentHours.ToString) Then

                    SubItemNumericInput.MinValue = 0
                    SubItemNumericInput.MaxLength = 8
                    SubItemNumericInput.SetFormatString("f" & 2)

                ElseIf ObjectType Is GetType(AdvantageFramework.Database.Classes.EmployeeTimeTemplate) AndAlso
                       FieldName = AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.EmployeeHours.ToString Then

                    SubItemNumericInput.MinValue = 0
                    SubItemNumericInput.MaxValue = 24
                    SubItemNumericInput.SetFormatString("f" & 2)

                ElseIf ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem) Then

                    If FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.BillableRate.ToString Then

                        SubItemNumericInput.MaxLength = 10

                    ElseIf FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CommissionPercentage.ToString Then

                        SubItemNumericInput.MaxLength = 11

                    ElseIf (FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.StateResaleAmount.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CountyResaleAmount.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.CityResaleAmount.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem.Properties.MarkupAmount.ToString) Then

                        SubItemNumericInput.MaxLength = 15

                    End If

                ElseIf ObjectType Is GetType(AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) AndAlso
                           (FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.PaymentAmount.ToString OrElse
                            FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.AdjustmentAmount.ToString) Then

                    SubItemNumericInput.MaxLength = 15

                ElseIf ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) Then

                    If FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.CommissionPercent.ToString Then

                        SubItemNumericInput.MaxLength = 11

                    ElseIf (FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedStateResale.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCountyResale.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedCityResale.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.ExtendedMarkupAmount.ToString) Then

                        SubItemNumericInput.MaxLength = 15

                    End If

                ElseIf ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem) Then

                    If FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CommissionPercent.ToString Then

                        SubItemNumericInput.MaxLength = 11

                    ElseIf FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Rate.ToString Then

                        SubItemNumericInput.MaxLength = 13

                    ElseIf (FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.Amount.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.StateResaleTaxAmount.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CountyResaleTaxAmount.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.CityResaleTaxAmount.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem.Properties.MarkupAmount.ToString) Then

                        SubItemNumericInput.MaxLength = 15

                    End If

                ElseIf ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) Then

                    If FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.InvoiceTotalNet.ToString OrElse
                            FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetAmount.ToString OrElse
                            FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaNetCharge.ToString OrElse
                            FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaAddAmount.ToString OrElse
                            FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNetAmount.ToString OrElse
                            FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLNetAmount.ToString Then

                        SubItemNumericInput.MaxLength = 15
                        SubItemNumericInput.SetFormatString("n" & 2)

                    ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.InvoiceTotalTax.ToString OrElse
                            FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaVendorTax.ToString OrElse
                            FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobVendorTax.ToString Then

                        SubItemNumericInput.MaxLength = 12
                        SubItemNumericInput.SetFormatString("n" & 2)

                    ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaQuantity.ToString OrElse
                            FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobQuantity.ToString Then

                        SubItemNumericInput.MaxLength = 11
                        SubItemNumericInput.SetFormatString("n" & 2)

                    ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaMarkupPercent.ToString Then

                        SubItemNumericInput.MaxLength = 7
                        SubItemNumericInput.SetFormatString("n" & 3)

                    End If

                ElseIf ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) Then

                    If FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.AmountToRecognize.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.NetAmount.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.ExtendedMarkupAmount.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.ExtendedNonResaleTax.ToString Then

                        SubItemNumericInput.MaxLength = 15
                        SubItemNumericInput.SetFormatString("n" & 2)

                    ElseIf FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.MarkupPercent.ToString Then

                        SubItemNumericInput.MaxLength = 10
                        SubItemNumericInput.SetFormatString("n" & 3)

                    ElseIf FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.QuantityHours.ToString Then

                        SubItemNumericInput.MaxLength = 16
                        SubItemNumericInput.SetFormatString("n" & 2)

                    ElseIf FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem.Properties.Rate.ToString Then

                        SubItemNumericInput.MaxLength = 16
                        SubItemNumericInput.SetFormatString("n" & 4)

                    End If

                ElseIf ObjectType Is GetType(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) Then

                    If FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdditionalChargeAmount.ToString OrElse
                            FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NetChargeAmount.ToString Then

                        SubItemNumericInput.MaxLength = 9
                        SubItemNumericInput.SetFormatString("n" & 2)

                    ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Rate.ToString Then

                        SubItemNumericInput.MaxLength = 14
                        SubItemNumericInput.SetFormatString("n" & 4)

                    End If

                ElseIf ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote) AndAlso
                        FieldName = AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote.Properties.PercentToQuote.ToString Then

                    SubItemNumericInput.MaxLength = 7

                ElseIf ObjectType Is GetType(AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent) AndAlso
                        FieldName = AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent.Properties.Percent.ToString Then

                    SubItemNumericInput.MaxLength = 6

                End If

            Catch ex As Exception
                SubItemNumericInput = Nothing
            Finally
                CreateSubItemNumericInput = SubItemNumericInput
            End Try

        End Function
        Public Function CreateSubItemHyperLinkEdit() As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit


			'objects
			Dim RepositoryItemHyperLinkEdit As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit = Nothing

			Try

				RepositoryItemHyperLinkEdit = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()

				RepositoryItemHyperLinkEdit.BrowserWindowStyle = ProcessWindowStyle.Normal
				RepositoryItemHyperLinkEdit.SingleClick = True

			Catch ex As Exception
				RepositoryItemHyperLinkEdit = Nothing
			Finally
				CreateSubItemHyperLinkEdit = RepositoryItemHyperLinkEdit
			End Try

		End Function
        Public Function CreateSubItemTextBox(ByVal SubItemTextBoxType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox.Type,
                                             ByVal FieldName As String, ByVal ObjectType As System.Type) As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox


            'objects
            Dim SubItemTextBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox = Nothing
            Dim MaxLength As Long = -1
            Dim RealObjectType As System.Type = Nothing
            Dim BaseClass As Object = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim MaxLengthAttribute As System.ComponentModel.DataAnnotations.MaxLengthAttribute = Nothing

            Try

                SubItemTextBox = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox

                SubItemTextBox.ControlType = SubItemTextBoxType

                Try

                    If ObjectType.IsSubclassOf(GetType(AdvantageFramework.BaseClasses.BaseClass)) AndAlso ObjectType.GetConstructor(Type.EmptyTypes) IsNot Nothing Then

                        Try

                            BaseClass = System.Activator.CreateInstance(ObjectType)

                            If DirectCast(BaseClass, AdvantageFramework.BaseClasses.BaseClass).AttachedEntityType IsNot Nothing Then

                                RealObjectType = DirectCast(BaseClass, AdvantageFramework.BaseClasses.BaseClass).AttachedEntityType

                            End If

                        Catch ex As Exception
                            RealObjectType = ObjectType
                        End Try

                    End If

                    If RealObjectType Is Nothing Then

                        RealObjectType = ObjectType

                    End If

                    If RealObjectType Is GetType(AdvantageFramework.Database.Classes.JobTemplateDetail) AndAlso
                               FieldName = AdvantageFramework.Database.Classes.JobTemplateDetail.Properties.Label.ToString Then

                        MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.JobTemplateDetail), FieldName))

                    ElseIf RealObjectType Is GetType(AdvantageFramework.Database.Classes.JobSpecificationField) AndAlso
                                   FieldName = AdvantageFramework.Database.Classes.JobSpecificationField.Properties.Description.ToString Then

                        MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.JobSpecificationField), FieldName))

                    ElseIf ObjectType Is GetType(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) AndAlso
                                   (FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString OrElse
                                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString OrElse
                                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString OrElse
                                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString OrElse
                                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString OrElse
                                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString OrElse
                                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString) Then

                        MaxLength = 5

                    ElseIf RealObjectType Is GetType(AdvantageFramework.Database.Entities.JobServiceFee) AndAlso
                                   FieldName = AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeDescription.ToString Then

                        MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.JobServiceFee), AdvantageFramework.Database.Entities.JobServiceFee.Properties.Description.ToString))

                    ElseIf (RealObjectType Is GetType(AdvantageFramework.Database.Entities.VendorServiceTax) AndAlso
                                    (FieldName = AdvantageFramework.Database.Entities.VendorServiceTax.Properties.Code.ToString OrElse
                                     FieldName = AdvantageFramework.Database.Entities.VendorServiceTax.Properties.Description.ToString)) OrElse
                                   (RealObjectType Is GetType(AdvantageFramework.Database.Entities.AvalaraTax) AndAlso
                                    (FieldName = AdvantageFramework.Database.Entities.AvalaraTax.Properties.Code.ToString OrElse
                                     FieldName = AdvantageFramework.Database.Entities.AvalaraTax.Properties.Description.ToString OrElse
                                     FieldName = AdvantageFramework.Database.Entities.AvalaraTax.Properties.LongDescription.ToString)) OrElse
                                   (RealObjectType Is GetType(AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging) AndAlso
                                    (FieldName = AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties.Code.ToString OrElse
                                     FieldName = AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties.Description.ToString OrElse
                                     FieldName = AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties.LongDescription.ToString)) OrElse
                                   (RealObjectType Is GetType(AdvantageFramework.Database.Entities.ClientPO) AndAlso
                                    (FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.ClientPONumber.ToString OrElse
                                     FieldName = AdvantageFramework.Database.Classes.ClientPO.Properties.ClientPODescription.ToString)) Then

                        Try

                            PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(RealObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList
                                                  Where [Property].Name = FieldName
                                                  Select [Property]).SingleOrDefault

                        Catch ex As Exception
                            PropertyDescriptor = Nothing
                        End Try

                        If PropertyDescriptor IsNot Nothing Then

                            MaxLengthAttribute = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).SingleOrDefault

                            If MaxLengthAttribute IsNot Nothing Then

                                MaxLength = MaxLengthAttribute.Length

                            End If

                        End If

                    ElseIf RealObjectType Is GetType(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) Then

                        Select Case FieldName

                            Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OrderDescription.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Buyer.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorCopyArea.ToString

                                MaxLength = 40

                            Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ClientPO.ToString

                                MaxLength = 25

                            Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Headline.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Material.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetURL.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorLocation.ToString

                                MaxLength = 60

                            Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Issue.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperSection.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProductionSize.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetTargetAudience.ToString

                                MaxLength = 30

                            Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetPlacement1.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetPlacement2.ToString

                                MaxLength = 160

                            Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastProgramming.ToString

                                MaxLength = 50

                            Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastStartTime.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastEndTime.ToString

                                MaxLength = 10

                            Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastRemarks.ToString

                                MaxLength = 254

                        End Select

                    Else

                        MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(RealObjectType, FieldName))

                    End If

                Catch ex As Exception
                    MaxLength = -1
                End Try

                If MaxLength <> -1 Then

                    SubItemTextBox.MaxLength = MaxLength

                End If

            Catch ex As Exception
                SubItemTextBox = Nothing
            Finally
                CreateSubItemTextBox = SubItemTextBox
            End Try

        End Function
        Public Function CreateSubItemMemoEdit(ByVal FieldName As String, ByVal ObjectType As System.Type) As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemMemoEdit

            Dim SubItemMemoEdit As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemMemoEdit = Nothing
            Dim MaxLength As Long = -1
            Dim RealObjectType As System.Type = Nothing
            Dim BaseClass As Object = Nothing

            Try

                SubItemMemoEdit = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemMemoEdit
                SubItemMemoEdit.ShowIcon = False

                If ObjectType IsNot Nothing AndAlso ObjectType.IsSubclassOf(GetType(AdvantageFramework.BaseClasses.BaseClass)) Then

                    Try

                        If ObjectType.GetConstructor(Type.EmptyTypes) IsNot Nothing Then

                            BaseClass = System.Activator.CreateInstance(ObjectType)

                            If DirectCast(BaseClass, AdvantageFramework.BaseClasses.BaseClass).AttachedEntityType IsNot Nothing Then

                                RealObjectType = DirectCast(BaseClass, AdvantageFramework.BaseClasses.BaseClass).AttachedEntityType

                            End If

                        End If

                    Catch ex As Exception
                        RealObjectType = ObjectType
                    End Try

                End If

                If RealObjectType Is Nothing Then

                    RealObjectType = ObjectType

                End If

                Try

                    MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(RealObjectType, FieldName))

                Catch ex As Exception
                    MaxLength = -1
                End Try

                If MaxLength <> -1 Then

                    SubItemMemoEdit.MaxLength = MaxLength

                End If

            Catch ex As Exception
                SubItemMemoEdit = Nothing
            Finally
                CreateSubItemMemoEdit = SubItemMemoEdit
            End Try

        End Function
        Public Function CreateSubItemTimeEdit() As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit

			'objects
			Dim RepositoryItemTimeEdit As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit = Nothing

			Try

				RepositoryItemTimeEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit

				RepositoryItemTimeEdit.NullText = ""

			Catch ex As Exception
				RepositoryItemTimeEdit = Nothing
			Finally
				CreateSubItemTimeEdit = RepositoryItemTimeEdit
			End Try

		End Function
		Public Function CreateSubItemDateEdit() As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput

			Dim SubItemDateInput As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput = Nothing

			Try

				SubItemDateInput = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput

			Catch ex As Exception
				SubItemDateInput = Nothing
			Finally
				CreateSubItemDateEdit = SubItemDateInput
			End Try

		End Function
		Public Function CreateSubItemImageComboBox(ByVal SubItemImageComboBoxType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageComboBox.Type) As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageComboBox

			Dim SubItemImageComboBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageComboBox = Nothing

			Try

				SubItemImageComboBox = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageComboBox

				SubItemImageComboBox.ControlType = SubItemImageComboBoxType

			Catch ex As Exception
				SubItemImageComboBox = Nothing
			Finally
				CreateSubItemImageComboBox = SubItemImageComboBox
			End Try

		End Function
		Public Function CreateSubItemColorPicker() As DevExpress.XtraEditors.Repository.RepositoryItemColorEdit

			Dim RepositoryItemColorEdit As DevExpress.XtraEditors.Repository.RepositoryItemColorEdit = Nothing

			Try

				RepositoryItemColorEdit = New DevExpress.XtraEditors.Repository.RepositoryItemColorEdit

				RepositoryItemColorEdit.StoreColorAsInteger = True

			Catch ex As Exception
				RepositoryItemColorEdit = Nothing
			Finally
				CreateSubItemColorPicker = RepositoryItemColorEdit
			End Try

		End Function
		Public Function CreateSubItemRichText() As DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit

			Dim RepositoryItemRichTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit = Nothing

			Try

				RepositoryItemRichTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit

			Catch ex As Exception
				RepositoryItemRichTextEdit = Nothing
			Finally
				CreateSubItemRichText = RepositoryItemRichTextEdit
			End Try

		End Function
		Public Function CreateSubItemImageCheckBox(ByVal IsReadOnly As Boolean, ByVal SubItemImageCheckEditControlType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl.Type,
												   ByVal ObjectType As System.Type, ByVal FieldName As String) As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl

			'objects
			Dim SubItemImageCheckEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl = Nothing

			Try

				SubItemImageCheckEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemImageCheckEditControl

				SubItemImageCheckEditControl.ControlType = SubItemImageCheckEditControlType
				SubItemImageCheckEditControl.ReadOnly = IsReadOnly

                If (ObjectType Is GetType(AdvantageFramework.Database.Classes.ExpenseReportItem) AndAlso FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.Database.Views.ExpenseSummary) AndAlso FieldName = AdvantageFramework.Database.Views.ExpenseSummary.Properties.DocumentCount.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) AndAlso FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoice) AndAlso FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) AndAlso FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory) AndAlso FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.DTO.Media.Traffic.Detail) AndAlso FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.DTO.Media.Traffic.Detail) AndAlso FieldName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.AdNumberDocument.ToString) Then

                    SubItemImageCheckEditControl.PictureChecked = AdvantageFramework.My.Resources.DocumentGeneric

                ElseIf (ObjectType Is GetType(AdvantageFramework.MediaManager.Classes.VCCOrder) AndAlso FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.Cancelled.ToString) OrElse
                       (ObjectType Is GetType(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel) AndAlso FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.RequiresUpdate.ToString) Then

                    SubItemImageCheckEditControl.PictureChecked = AdvantageFramework.My.Resources.SmallRedCircleImage

				ElseIf (ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) AndAlso FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.IsNonBillable.ToString) OrElse
						(ObjectType Is GetType(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) AndAlso FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.HasBillingApprovalStatus.ToString) OrElse
						(ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary) AndAlso FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.HasBillingApprovalStatus.ToString) OrElse
						(ObjectType Is GetType(AdvantageFramework.MediaManager.Classes.OrderProcessControl) AndAlso (FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.QualifiedToClose.ToString OrElse
						 FieldName = AdvantageFramework.MediaManager.Classes.OrderProcessControl.Properties.LineComplete.ToString)) Then

					SubItemImageCheckEditControl.PictureUnchecked = AdvantageFramework.My.Resources.SmallRedCircleImage

				End If

			Catch ex As Exception
				SubItemImageCheckEditControl = Nothing
			Finally
				CreateSubItemImageCheckBox = SubItemImageCheckEditControl
			End Try

		End Function
		Public Function CreateSubItemCheckBox(ByVal IsReversedCheckBox As Boolean, ByVal PropertyType As System.Type) As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

			'objects
			Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
			Dim BasePropertyType As System.Type = Nothing
			Dim ValueChecked As Integer = Nothing
			Dim ValueUnchecked As Integer = Nothing

			Try

				Try

					BasePropertyType = If(Nullable.GetUnderlyingType(PropertyType) IsNot Nothing, Nullable.GetUnderlyingType(PropertyType), PropertyType)

				Catch ex As Exception
					BasePropertyType = GetType(Boolean)
				End Try

				ValueChecked = If(IsReversedCheckBox, 0, 1)
				ValueUnchecked = If(IsReversedCheckBox, 1, 0)

				RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

				RepositoryItemCheckEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
				RepositoryItemCheckEdit.DisplayValueChecked = "Yes"
				RepositoryItemCheckEdit.DisplayValueUnchecked = "No"
				RepositoryItemCheckEdit.DisplayValueGrayed = "No"
				RepositoryItemCheckEdit.ValueGrayed = Nothing
				RepositoryItemCheckEdit.NullText = "No"
				RepositoryItemCheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked

				Select Case BasePropertyType

					Case GetType(System.String)

						RepositoryItemCheckEdit.ValueChecked = If(IsReversedCheckBox, "N", "Y")
						RepositoryItemCheckEdit.ValueUnchecked = If(IsReversedCheckBox, "Y", "N")

					Case Else

						Try

							RepositoryItemCheckEdit.ValueChecked = Convert.ChangeType(ValueChecked, BasePropertyType)
							RepositoryItemCheckEdit.ValueUnchecked = Convert.ChangeType(ValueUnchecked, BasePropertyType)

						Catch ex As Exception
							RepositoryItemCheckEdit.ValueChecked = If(IsReversedCheckBox, False, True)
							RepositoryItemCheckEdit.ValueUnchecked = If(IsReversedCheckBox, True, False)
						End Try

				End Select

			Catch ex As Exception
				RepositoryItemCheckEdit = Nothing
			Finally
				CreateSubItemCheckBox = RepositoryItemCheckEdit
			End Try

		End Function
        Public Function CreateSubItemComboBox(ByVal SubItemComboBoxType As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemComboBox.Type) As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemComboBox

            'objects
            Dim SubItemComboBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemComboBox = Nothing

            Try

                SubItemComboBox = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemComboBox

                SubItemComboBox.ControlType = SubItemComboBoxType

            Catch ex As Exception
                SubItemComboBox = Nothing
            Finally
                CreateSubItemComboBox = SubItemComboBox
            End Try

        End Function
        Public Function CreateSubItemByPropertyTypeAttribute(ByVal FieldName As String, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes,
                                                             ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                             ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute,
                                                             ByVal ObjectType As System.Type, ByVal FormatString As String, Optional ByVal AllowExtraComboItems As Boolean = True) As DevExpress.XtraEditors.Repository.RepositoryItem

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            Select Case PropertyType

                Case BaseClasses.PropertyTypes.ClientCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Client, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DivisionCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Division, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ProductCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Product, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.FunctionCode

                    If ObjectType Is GetType(AdvantageFramework.Database.Classes.ExpenseReportItem) OrElse
                       ObjectType Is GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging) Then

                        RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.ExpenseFunction, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                    Else

                        RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.[Function], FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                    End If

                Case BaseClasses.PropertyTypes.VendorCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Vendor, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.EmployeeCode

                    If ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) Then

                        RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.EmployeeWithDepartmentAndOffice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                    Else

                        RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Employee, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                    End If

                Case BaseClasses.PropertyTypes.EmployeeTitleID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.EmployeeTitle, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DepartmentTeamCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.DepartmentTeam, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.OfficeCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Office, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.RoleCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Role, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.SalesClassCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.SalesClass, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.GeneralLedgerAccountCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.GeneralLedgerAccount, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.SalesTaxCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.SalesTax, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.VendorTermCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.VendorTerm, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ImportVendorCategoryCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.ImportVendorCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.VendorFunctionCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.VendorFunction, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.EmployeeFunctionCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.EmployeeFunction, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.FunctionHeadingID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.FunctionHeading, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.IndirectCategoryType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.IndirectCategoryType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PurchaseOrderApprovalRuleCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.POApprovalRule, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ServiceFeeTypeCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.ServiceFeeType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.WebsiteTypeCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.WebSiteType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.JobComponent

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.JobComponent, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.JobNumber

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Job, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.BankCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Bank, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PTORule

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.PTORule, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ClientContactID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.ClientContact, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MarketCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Market, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AdSizeCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.AdSize, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DaypartID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Daypart, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.JobVersionDatabaseType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.JobVersionDatabaseType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.TaskCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Task, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.Phase

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Phase, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PartnerCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Partner, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.JobComponentID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.JobComponentID, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DaypartTypeID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.DaypartType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ExpenseEmployee

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.ExpenseEmployee, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.Blackplate

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Blackplate, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CycleTypes

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CycleType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AccountReceivable

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.AccountReceivable, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CampaignDetailType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.EnumObject, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.CampaignDetailTypes), AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PostPeriodCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.PostPeriod, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.EmployeeCategoryID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.EmployeeCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PostPeriodStatus

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.PostPeriodStatus, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaPlanID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaPlan, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaPlanDetailID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaPlanDetail, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.AccountPayableImportMediaType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ProductCategory

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.ProductCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.LocationID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Location, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.Status

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Status, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DaypartCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.DaypartCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CurrencyCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CurrencyCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.InvoiceCategory

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.InvoiceCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomProductionInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CustomProductionInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomMagazineInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CustomMagazineInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomNewspaperInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CustomNewspaperInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomInternetInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CustomInternetInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomOutdoorInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CustomOutdoorInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomRadioInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CustomRadioInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomTVInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CustomTVInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CampaignCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Campaign, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.CampaignID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CampaignID, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.InternetType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.InternetType, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.AdNumber

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.AdNumber, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.AvalaraTaxID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.AvalaraTaxID, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.OverheadAccountCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.OverheadAccountCode, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.JobProcess

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.JobProcess, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.BillingCoopCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.BillingCoopCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ContactTypeID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.ContactType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.VCCStatus

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.VCCStatus, FieldName, EntityAttribute, PropertyDescriptor, Nothing, False)

                Case BaseClasses.PropertyTypes.OutOfHomeType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.OutOfHomeType, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.InternetCostType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.EnumObject, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.InternetCostType))

                Case BaseClasses.PropertyTypes.NewspaperCostRate

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.EnumObject, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.NewspaperCostRate))

                Case BaseClasses.PropertyTypes.DocumentType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.DocumentType, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.OrderProcess

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.OrderProcess, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.Methods.PropertyTypes.RateType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.RateType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.StateCode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.StateCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.Methods.PropertyTypes.IndirectCategory

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.IndirectCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.Methods.PropertyTypes.JobTemplateMapping

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.JobTemplateMapping, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.GeneralLedgerSource

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.GeneralLedgerSource, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AdServerAdvertiserID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.AdServerAdvertiserID, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AdServerCampaignID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.AdServerCampaignID, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AdServerSiteID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.AdServerSiteID, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AdServerPlacementID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.AdServerPlacementID, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

				Case BaseClasses.PropertyTypes.BuyerEmployeeCode

					RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.BuyerEmployeeCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.NielsenTVBook

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.NielsenTVBook, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.NielsenRadioPeriod

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.NielsenRadioPeriod, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.NielsenRadioDaypart

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.NielsenRadioDaypart, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

				Case BaseClasses.PropertyTypes.MediaDemographic

					RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaDemographic, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

				Case BaseClasses.PropertyTypes.CableNetworkStation

					RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.CableNetworkStation, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.NielsenMarket

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.NielsenMarket, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.NielsenRadioStation

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.NielsenRadioStation, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.NielsenTVStation

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.NielsenTVStation, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.Methods.PropertyTypes.BroadcastOrderLineNumber

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.RadioOrderLineNumber, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.NCCTVSyscode

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.NCCTVSyscode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaRFPAvailLineStatus

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaRFPAvailLineStatus, FieldName, EntityAttribute, PropertyDescriptor, Nothing, False)

                Case BaseClasses.PropertyTypes.ClientDiscount

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.ClientDiscount, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.YearMonth

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.YearMonth, FieldName, EntityAttribute, PropertyDescriptor, Nothing, False)

                Case BaseClasses.PropertyTypes.NielsenCountyState

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.NielsenCountyState, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.Year

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.Year, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.BroadcastMediaType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.BroadcastMediaType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaTrafficRevision

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaTrafficRevision, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaTrafficCreativeGroup

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaTrafficCreativeGroup, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaTacticID

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaTacticID, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaPlanEstimateTemplateMediaType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaPlanEstimateTemplateMediaType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.QuarterYear

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.QuarterYear, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaPlanEstimateTemplate

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaPlanEstimateTemplate, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaPlanDetailPeriodType

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.MediaPlanDetailPeriodType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case Else

                    RepositoryItem = CreateDefaultSubItem(FieldName, PropertyDescriptor.PropertyType, FormatString, ObjectType)

            End Select

            CreateSubItemByPropertyTypeAttribute = RepositoryItem

        End Function
        Public Function CreateSubItemByDefaultColumnTypeAttribute(ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes,
                                                                  ByVal FieldName As String, ByVal FormatString As String,
                                                                  ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                                  ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute,
                                                                  ByVal ObjectType As System.Type) As DevExpress.XtraEditors.Repository.RepositoryItem

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            Select Case DefaultColumnType

                Case BaseClasses.DefaultColumnTypes.OfficeName

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.OfficeName, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.DefaultColumnTypes.DepartmentTeamName

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.DepartmentTeamName, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.GeneralLedgerAccountDescription, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.DefaultColumnTypes.Memo

                    RepositoryItem = CreateSubItemMemoEdit(FieldName, ObjectType)

                Case BaseClasses.DefaultColumnTypes.StateName

                    RepositoryItem = CreateSubItemGridLookupEdit(SubItemGridLookUpEditControl.Type.StateName, FieldName, EntityAttribute, PropertyDescriptor)

                Case Else

                    RepositoryItem = CreateSubItemByDefaultColumnTypeAttribute(DefaultColumnType, FieldName, FormatString, PropertyDescriptor.PropertyType, ObjectType)

            End Select

            CreateSubItemByDefaultColumnTypeAttribute = RepositoryItem

        End Function
        Public Function CreateSubItemByDefaultColumnTypeAttribute(ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes,
                                                                  ByVal FieldName As String, ByVal FormatString As String,
                                                                  ByVal ValueType As System.Type, ByVal ObjectType As System.Type) As DevExpress.XtraEditors.Repository.RepositoryItem

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            Select Case DefaultColumnType

                Case BaseClasses.DefaultColumnTypes.ReversedCheckBox

                    RepositoryItem = CreateSubItemCheckBox(True, ValueType)

                Case BaseClasses.DefaultColumnTypes.StandardCheckBox

                    RepositoryItem = CreateSubItemCheckBox(False, ValueType)

                Case BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox

                    RepositoryItem = CreateSubItemImageCheckBox(True, SubItemImageCheckEditControl.Type.ImageWhenChecked, ObjectType, FieldName)

                Case BaseClasses.DefaultColumnTypes.ColorPicker

                    RepositoryItem = CreateSubItemColorPicker()

                Case BaseClasses.DefaultColumnTypes.HyperLink

                    RepositoryItem = CreateSubItemHyperLinkEdit()

                Case BaseClasses.DefaultColumnTypes.ImageWhenUnCheckedCheckBox

                    RepositoryItem = CreateSubItemImageCheckBox(True, SubItemImageCheckEditControl.Type.ImageWhenUnChecked, ObjectType, FieldName)

                Case BaseClasses.Methods.DefaultColumnTypes.Time

                    RepositoryItem = CreateSubItemTimeEdit()

                Case Else

                    RepositoryItem = CreateDefaultSubItem(FieldName, ValueType, FormatString, ObjectType)

            End Select

            CreateSubItemByDefaultColumnTypeAttribute = RepositoryItem

        End Function
        Public Function CreateDefaultSubItem(ByVal FieldName As String, ByVal PropertyType As System.Type,
                                             ByVal FormatString As String, ByVal ObjectType As System.Type,
                                             Optional ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing) As DevExpress.XtraEditors.Repository.RepositoryItem

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            If PropertyType Is GetType(String) Then

                RepositoryItem = CreateSubItemTextBox(AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemTextBox.Type.Default, FieldName, ObjectType)

            ElseIf PropertyType Is GetType(Decimal) Then

                RepositoryItem = CreateSubItemNumericInput(SubItemNumericInput.Type.Decimal, FieldName, FormatString, False, ObjectType, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Decimal)) Then

                RepositoryItem = CreateSubItemNumericInput(SubItemNumericInput.Type.Decimal, FieldName, FormatString, True, ObjectType, EntityAttribute)

            ElseIf PropertyType Is GetType(Long) Then

                RepositoryItem = CreateSubItemNumericInput(SubItemNumericInput.Type.Long, FieldName, FormatString, False, ObjectType, EntityAttribute)

            ElseIf PropertyType Is GetType(Integer) Then

                RepositoryItem = CreateSubItemNumericInput(SubItemNumericInput.Type.Integer, FieldName, FormatString, False, ObjectType, EntityAttribute)

            ElseIf PropertyType Is GetType(Short) Then

                RepositoryItem = CreateSubItemNumericInput(SubItemNumericInput.Type.Short, FieldName, FormatString, False, ObjectType, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Long)) Then

                RepositoryItem = CreateSubItemNumericInput(SubItemNumericInput.Type.Long, FieldName, FormatString, True, ObjectType, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Integer)) Then

                RepositoryItem = CreateSubItemNumericInput(SubItemNumericInput.Type.Integer, FieldName, FormatString, True, ObjectType, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Short)) Then

                RepositoryItem = CreateSubItemNumericInput(SubItemNumericInput.Type.Short, FieldName, FormatString, True, ObjectType, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Boolean)) OrElse
                    PropertyType Is GetType(Boolean) Then

                RepositoryItem = CreateSubItemCheckBox(False, GetType(Boolean))

            ElseIf PropertyType Is GetType(System.Nullable(Of Date)) OrElse
                PropertyType Is GetType(Date) Then

                RepositoryItem = CreateSubItemDateEdit()

            End If

            CreateDefaultSubItem = RepositoryItem

        End Function
        Public Function CreateBlankSubItemCheckBox() As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

			Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

			RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
			RepositoryItemCheckEdit.PictureChecked = Nothing
			RepositoryItemCheckEdit.PictureGrayed = Nothing
			RepositoryItemCheckEdit.PictureUnchecked = Nothing
			RepositoryItemCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
			RepositoryItemCheckEdit.ValueUnchecked = CShort(0)
			RepositoryItemCheckEdit.ValueChecked = CShort(1)

			CreateBlankSubItemCheckBox = RepositoryItemCheckEdit

		End Function
		Public Function CreateSubItemProgressBar() As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar

			Dim RepositoryItemProgressBar As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar = Nothing

			RepositoryItemProgressBar = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar

			CreateSubItemProgressBar = RepositoryItemProgressBar

		End Function
        'Private Sub SaveDataGridViewLayout(ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
        '                                   ByVal OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid,
        '                                   Optional ByVal GridAdvantageSubType As Nullable(Of Integer) = Nothing)

        '    'objects
        '    Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing
        '    Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
        '    Dim StreamReader As System.IO.StreamReader = Nothing

        '    MemoryStreamLayout = New System.IO.MemoryStream()

        '    DataGridView.CurrentView.AFActiveFilterString = Nothing

        '    DataGridView.CurrentView.SaveLayoutToStream(MemoryStreamLayout, OptionsLayoutGrid)

        '    MemoryStreamLayout.Position = 0

        '    StreamReader = New System.IO.StreamReader(MemoryStreamLayout)

        '    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

        '        If GridAdvantageSubType Is Nothing Then

        '            GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, GridAdvantageType, Session.UserCode)

        '        Else

        '            GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, GridAdvantageType, Session.UserCode, GridAdvantageSubType)

        '        End If

        '        If GridAdvantage IsNot Nothing Then

        '            GridAdvantage.XmlLayout = StreamReader.ReadToEnd

        '            AdvantageFramework.Database.Procedures.GridAdvantage.Update(DataContext, GridAdvantage)

        '        Else

        '            GridAdvantage = New AdvantageFramework.Database.Entities.GridAdvantage
        '            GridAdvantage.DataContext = DataContext

        '            GridAdvantage.GridType = GridAdvantageType
        '            GridAdvantage.UserCode = Session.UserCode
        '            GridAdvantage.XmlLayout = StreamReader.ReadToEnd
        '            GridAdvantage.GridSubtype = GridAdvantageSubType

        '            AdvantageFramework.Database.Procedures.GridAdvantage.Insert(DataContext, GridAdvantage)

        '        End If

        '    End Using

        'End Sub
        'Public Sub SaveDataGridViewLayout(ByVal DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView,
        '                                  ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
        '                                  Optional ByVal GridAdvantageSubType As Nullable(Of Integer) = Nothing)

        '    'objects
        '    Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

        '    OptionsLayoutGrid = New DevExpress.Utils.OptionsLayoutGrid

        '    OptionsLayoutGrid.Assign(DevExpress.Utils.OptionsLayoutBase.FullLayout)

        '    SaveDataGridViewLayout(DataGridView, GridAdvantageType, OptionsLayoutGrid, GridAdvantageSubType)

        'End Sub
        Private Function LoadMinimalDataGridViewLayoutOptions() As DevExpress.Utils.OptionsLayoutGrid

			'objects
			Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

			OptionsLayoutGrid = New DevExpress.Utils.OptionsLayoutGrid()

			With OptionsLayoutGrid

				' see document https://documentation.devexpress.com/#WindowsForms/CustomDocument1875
				.StoreAllOptions = False 'default is false
				.StoreAppearance = False 'default is false
				.StoreDataSettings = False 'default is true
				.StoreVisualOptions = True ' default is true
				.Columns.AddNewColumns = True ' default is true
				.Columns.RemoveOldColumns = True ' default is true
				.Columns.StoreAllOptions = False ' default is False
				.Columns.StoreAppearance = False ' default is False
				.Columns.StoreLayout = True ' default is true

			End With

			Return OptionsLayoutGrid

		End Function
        'Public Sub SaveMinimalDataGridViewLayout(ByVal DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType, Optional ByVal GridAdvantageSubType As Nullable(Of Integer) = Nothing)

        '    'objects
        '    Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

        '    OptionsLayoutGrid = LoadMinimalDataGridViewLayoutOptions()

        '    SaveDataGridViewLayout(DataGridView, GridAdvantageType, OptionsLayoutGrid, GridAdvantageSubType)

        'End Sub
        'Public Function LoadMinimalDataGridViewLayout(ByVal DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView,
        '                                              ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
        '                                              Optional ByVal GridAdvantageSubType As Nullable(Of Long) = Nothing,
        '                                              Optional ByVal RemoveOldColumns As Boolean = False) As Boolean

        '    'objects
        '    Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing
        '    Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
        '    Dim StreamWriter As System.IO.StreamWriter = Nothing
        '    Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
        '    Dim LayoutExists As Boolean = False
        '    Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

        '    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

        '        If GridAdvantageSubType Is Nothing Then

        '            GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, GridAdvantageType, Session.UserCode)

        '        Else

        '            GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, GridAdvantageType, Session.UserCode, GridAdvantageSubType)

        '        End If

        '    End Using

        '    If GridAdvantage IsNot Nothing Then

        '        MemoryStreamLayout = New System.IO.MemoryStream
        '        StreamWriter = New System.IO.StreamWriter(MemoryStreamLayout)

        '        StreamWriter.AutoFlush = True
        '        StreamWriter.Write(GridAdvantage.XmlLayout)

        '        MemoryStreamLayout.Position = 0

        '        DataGridView.CurrentView.OptionsLayout.Columns.RemoveOldColumns = RemoveOldColumns

        '        DataGridView.SuspendLayout()

        '        OptionsLayoutGrid = LoadMinimalDataGridViewLayoutOptions()

        '        'when you pass a static OptionsLayoutBase.FullLayout object to the RestoreLayoutFromXml method, the AddNewColumns option is not taken into account
        '        'https://www.devexpress.com/Support/Center/Question/Details/Q334295
        '        DataGridView.CurrentView.RestoreLayoutFromStream(MemoryStreamLayout, OptionsLayoutGrid) ', DevExpress.Utils.OptionsLayoutBase.FullLayout)

        '        If DataGridView.Columns.Count > 0 Then

        '            GridColumn = DataGridView.Columns(0)

        '            DataGridView.CurrentView.FocusedColumn = GridColumn

        '        End If

        '        DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = DataGridView.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(Column) Column.Visible = False).ToList()

        '        DataGridView.ResumeLayout()

        '        LayoutExists = True

        '    Else

        '        DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = Nothing

        '    End If

        '    LoadMinimalDataGridViewLayout = LayoutExists

        'End Function
        'Public Function LoadDataGridViewLayout(ByVal DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView,
        '                                       ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
        '                                       Optional ByVal GridAdvantageSubType As Nullable(Of Long) = Nothing,
        '                                       Optional ByVal RemoveOldColumns As Boolean = False) As Boolean

        '    'objects
        '    Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

        '    OptionsLayoutGrid = New DevExpress.Utils.OptionsLayoutGrid

        '    OptionsLayoutGrid.Assign(DevExpress.Utils.OptionsLayoutBase.FullLayout)

        '    OptionsLayoutGrid.Columns.RemoveOldColumns = RemoveOldColumns

        '    LoadDataGridViewLayout = LoadDataGridViewLayout(DataGridView, GridAdvantageType, OptionsLayoutGrid, GridAdvantageSubType)

        'End Function
        'Private Function LoadDataGridViewLayout(ByVal DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView,
        '                                        ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
        '                                        ByVal OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid,
        '                                        Optional ByVal GridAdvantageSubType As Nullable(Of Long) = Nothing) As Boolean

        '    'objects
        '    Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing
        '    Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
        '    Dim StreamWriter As System.IO.StreamWriter = Nothing
        '    Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
        '    Dim LayoutExists As Boolean = False

        '    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

        '        If GridAdvantageSubType Is Nothing Then

        '            GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, GridAdvantageType, Session.UserCode)

        '        Else

        '            GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, GridAdvantageType, Session.UserCode, GridAdvantageSubType)

        '        End If

        '    End Using

        '    If GridAdvantage IsNot Nothing Then

        '        MemoryStreamLayout = New System.IO.MemoryStream
        '        StreamWriter = New System.IO.StreamWriter(MemoryStreamLayout)

        '        StreamWriter.AutoFlush = True
        '        StreamWriter.Write(GridAdvantage.XmlLayout)

        '        MemoryStreamLayout.Position = 0

        '        'DataGridView.CurrentView.OptionsLayout.Columns.RemoveOldColumns = RemoveOldColumns

        '        DataGridView.SuspendLayout()

        '        'when you pass a static OptionsLayoutBase.FullLayout object to the RestoreLayoutFromXml method, the AddNewColumns option is not taken into account
        '        'https://www.devexpress.com/Support/Center/Question/Details/Q334295
        '        DataGridView.CurrentView.RestoreLayoutFromStream(MemoryStreamLayout, OptionsLayoutGrid) ', DevExpress.Utils.OptionsLayoutBase.FullLayout)

        '        If DataGridView.Columns.Count > 0 Then

        '            GridColumn = DataGridView.Columns(0)

        '            DataGridView.CurrentView.FocusedColumn = GridColumn

        '        End If

        '        DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = DataGridView.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(Column) Column.Visible = False).ToList()

        '        DataGridView.ResumeLayout()

        '        LayoutExists = True

        '    Else

        '        DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = Nothing

        '    End If

        '    LoadDataGridViewLayout = LayoutExists

        'End Function
        Public Sub SortGridViewBySortedColumns(ByVal DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView)

			If DataGridView.CurrentView.SortedColumns.Count > 0 Then

				DataGridView.CurrentView.BeginSort()

				For SortedColumn As Integer = 0 To DataGridView.CurrentView.SortedColumns.Count - 1

					DataGridView.CurrentView.Columns(DataGridView.CurrentView.SortedColumns(SortedColumn).FieldName).SortOrder = DataGridView.CurrentView.SortedColumns(SortedColumn).SortOrder

				Next

				DataGridView.CurrentView.EndSort()

			End If

		End Sub
        Public Function GetRowAndInitialize(VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute) As DevExpress.XtraVerticalGrid.Rows.BaseRow

            'objects
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                Row = VerticalGrid.Rows.GetRowByFieldName(PropertyDescriptor.Name, True)

            Catch ex As Exception
                Row = Nothing
            End Try

            If Row IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                End Try

                If EntityAttribute IsNot Nothing Then

                    If EntityAttribute.DisplayFormat <> "" Then

                        If EntityAttribute.DisplayFormat.StartsWith("c") OrElse EntityAttribute.DisplayFormat.StartsWith("n") Then

                            Row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric

                        ElseIf EntityAttribute.DisplayFormat.StartsWith("d") Then

                            Row.Properties.Format.FormatType = DevExpress.Utils.FormatType.DateTime

                        End If

                        Row.Properties.Format.FormatString = EntityAttribute.DisplayFormat

                    End If

                End If

                Row.OptionsRow.AllowMove = False
                Row.OptionsRow.AllowMoveToCustomizationForm = False
                Row.OptionsRow.ShowInCustomizationForm = False

            End If

            GetRowAndInitialize = Row

        End Function

#End Region

#End Region

    End Module

End Namespace
