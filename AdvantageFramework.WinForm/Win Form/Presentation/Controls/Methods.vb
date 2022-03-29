Namespace WinForm.Presentation.Controls

    <HideModuleName()>
    Public Module Methods

        'Friend Event LoadFormSettingsEvent(ByVal Form As System.Windows.Forms.Form)

        Public Delegate Sub SetTextOnTextBoxControlDelegate(ByRef TextBoxControl As AdvantageFramework.WinForm.Presentation.Controls.TextBox, ByVal Text As String)
        Public Delegate Sub SetTextOnLabelControlDelegate(ByRef LabelControl As AdvantageFramework.WinForm.Presentation.Controls.Label, ByVal Text As String)
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

        Public Enum ImportingMatchingColumns
            ImportFileColumnHeader
            ColumnHeader
        End Enum

        Public Enum CheckBoxValueType
            Int16
            Int32
            [Boolean]
            [String]
            [Byte]
            YesNoSkip
        End Enum

        Public Enum AddressTypeToValidate
            Billing
            Statement
            General
        End Enum

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
        'Public Sub SuspendDrawingAndLayout(ByVal Form As System.Windows.Forms.Form)

        '    For Each Control In Form.Controls.OfType(Of System.Windows.Forms.Control)()

        '        SuspendDrawingAndLayout(Control)

        '        If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IFormSettings OrElse _
        '                TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IUserControlFormSettings Then

        '            Control.SuspendLayout()
        '            Control.SuspendDrawing()

        '        End If

        '    Next

        'End Sub
        'Public Sub SuspendDrawingAndLayout(ByVal ParentControl As System.Windows.Forms.Control)

        '    For Each Control In ParentControl.Controls.OfType(Of System.Windows.Forms.Control)()

        '        SuspendDrawingAndLayout(Control)

        '        If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IFormSettings OrElse _
        '                TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IUserControlFormSettings Then

        '            Control.SuspendLayout()
        '            Control.SuspendDrawing()

        '        End If

        '    Next

        'End Sub
        'Public Sub ResumeDrawingAndLayout(ByVal Form As System.Windows.Forms.Form, ByVal Redraw As Boolean)

        '    For Each Control In Form.Controls.OfType(Of System.Windows.Forms.Control)()

        '        If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IFormSettings OrElse _
        '                TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IUserControlFormSettings Then

        '            Control.ResumeDrawing()
        '            Control.ResumeLayout()

        '        End If

        '        ResumeDrawingAndLayout(Control, Redraw)

        '    Next

        'End Sub
        'Public Sub ResumeDrawingAndLayout(ByVal ParentControl As System.Windows.Forms.Control, ByVal Redraw As Boolean)

        '    For Each Control In ParentControl.Controls.OfType(Of System.Windows.Forms.Control)()

        '        If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IFormSettings OrElse _
        '                TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IUserControlFormSettings Then

        '            Control.ResumeDrawing()
        '            Control.ResumeLayout()

        '        End If

        '        ResumeDrawingAndLayout(Control, Redraw)

        '    Next

        'End Sub
        Public Sub UserEntryChanged(ByVal Control As System.Windows.Forms.Control)

            If TypeOf Control.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                DirectCast(Control.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).BaseFormUserEntryChanged(Control)

            ElseIf TypeOf Control.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm Then

                DirectCast(Control.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).BaseFormUserEntryChanged(Control)

            ElseIf TypeOf Control.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                If TypeOf Control.FindForm.ActiveMdiChild Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    DirectCast(Control.FindForm.ActiveMdiChild, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).BaseFormUserEntryChanged(Control)

                ElseIf TypeOf Control.FindForm.ActiveMdiChild Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm Then

                    DirectCast(Control.FindForm.ActiveMdiChild, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).BaseFormUserEntryChanged(Control)

                End If

            ElseIf TypeOf Control.FindForm Is AdvantageFramework.Billing.Reports.Presentation.InvoiceViewingForm Then

                DirectCast(Control.FindForm, AdvantageFramework.Billing.Reports.Presentation.InvoiceViewingForm).BaseFormUserEntryChanged(Control)

            End If

        End Sub
        Public Sub AddSubItemCheckBox(ByVal Session As AdvantageFramework.Security.Session, ByVal PivotGridControl As DevExpress.XtraPivotGrid.PivotGridControl, ByRef PivotGridField As DevExpress.XtraPivotGrid.PivotGridField, ByVal IsReversedCheckBox As Boolean, ByVal CheckBoxValueType As CheckBoxValueType)

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

            RepositoryItemCheckEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

            If IsReversedCheckBox Then

                RepositoryItemCheckEdit.DisplayValueChecked = "Yes"
                RepositoryItemCheckEdit.DisplayValueUnchecked = "No"
                RepositoryItemCheckEdit.DisplayValueGrayed = "No"

                Select Case CheckBoxValueType

                    Case CheckBoxValueType.Boolean
                        RepositoryItemCheckEdit.ValueChecked = False
                        RepositoryItemCheckEdit.ValueUnchecked = True

                    Case CheckBoxValueType.Int16
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToInt16(0)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToInt16(1)

                    Case CheckBoxValueType.Int32
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToInt32(0)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToInt32(1)

                    Case CheckBoxValueType.String
                        RepositoryItemCheckEdit.ValueChecked = "N"
                        RepositoryItemCheckEdit.ValueUnchecked = "Y"

                    Case CheckBoxValueType.Byte
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

                    Case CheckBoxValueType.Boolean
                        RepositoryItemCheckEdit.ValueChecked = True
                        RepositoryItemCheckEdit.ValueUnchecked = False

                    Case CheckBoxValueType.Int16
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToInt16(1)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToInt16(0)

                    Case CheckBoxValueType.Int32
                        RepositoryItemCheckEdit.ValueChecked = Convert.ToInt32(1)
                        RepositoryItemCheckEdit.ValueUnchecked = Convert.ToInt32(0)

                    Case CheckBoxValueType.String
                        RepositoryItemCheckEdit.ValueChecked = "Y"
                        RepositoryItemCheckEdit.ValueUnchecked = "N"

                    Case CheckBoxValueType.Byte
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
        Public Sub AddSubItemNumericInput(ByVal Session As AdvantageFramework.Security.Session, ByVal PivotGridControl As DevExpress.XtraPivotGrid.PivotGridControl, ByVal PivotGridField As DevExpress.XtraPivotGrid.PivotGridField, ByVal SubItemNumericInputType As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput.Type, ByVal ObjectType As System.Type, ByVal IsNullable As Boolean, ByVal DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing
            Dim Scale As Long = 0
            Dim Precision As Long = 0
            Dim LoadedEntityFormat As Boolean = False
            Dim BaseClass As Object = Nothing

            SubItemNumericInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput

            SubItemNumericInput.ControlType = SubItemNumericInputType

            ' SubItemNumericInput.DbContext = DbContext

            If SubItemNumericInputType = AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput.Type.Default OrElse
                    SubItemNumericInputType = AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal OrElse
                    SubItemNumericInputType = AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency Then

                PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(ObjectType, PivotGridField.FieldName)

                If PropertyDescriptor IsNot Nothing Then

                    If PivotGridField.CellFormat.FormatString Is Nothing OrElse PivotGridField.CellFormat.FormatString = "" Then

                        Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)

                        If Scale > 0 Then

                            If SubItemNumericInputType = AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput.Type.Default OrElse SubItemNumericInputType = AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal Then

                                SubItemNumericInput.SetFormatString("f" & Scale)
                                LoadedEntityFormat = True

                            ElseIf SubItemNumericInputType = AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency Then

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

                If TypeOf FormControl Is AdvantageFramework.WinForm.Presentation.Controls.DataGridView Then

                    DirectCast(FormControl, AdvantageFramework.WinForm.Presentation.Controls.DataGridView).CurrentView.CloseEditorForUpdating()

                ElseIf TypeOf FormControl Is AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView Then

                    DirectCast(FormControl, AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView).CurrentView.CloseEditorForUpdating()

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
        'Public Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) 'As System.Threading.Tasks.Task

        'Dim CurrentTaskScheduler As System.Threading.Tasks.TaskScheduler = Nothing
        'Dim Task As System.Threading.Tasks.Task = Nothing
        'Dim NextTask As System.Threading.Tasks.Task = Nothing

        'CurrentTaskScheduler = System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext()

        'Task = System.Threading.Tasks.Task.Factory.StartNew(Sub()

        '                                                        System.Threading.Thread.Sleep(10)

        '                                                    End Sub, Threading.Tasks.TaskCreationOptions.PreferFairness)

        'Task.ContinueWith(Sub()

        ' RaiseEvent LoadFormSettingsEvent(Form)

        'End Sub, CurrentTaskScheduler)

        'NextTask.ContinueWith(Sub()

        '                          For Each Control In Form.Controls.OfType(Of System.Windows.Forms.Control)()

        '                              LoadUserControlFormSettings(Control, Form)

        '                              If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IUserControlFormSettings Then

        '                                  CType(Control, AdvantageFramework.WinForm.Presentation.Controls.Classes.IUserControlFormSettings).LoadFormSettings(Form)

        '                              End If

        '                          Next

        '                      End Sub, CurrentTaskScheduler)

        'LoadFormSettings = Task

        'End Sub
        'Public Sub LoadFormSettings(ByVal FormSettingsControl As System.Windows.Forms.Control, ByVal Form As System.Windows.Forms.Form)

        '    For Each Control In FormSettingsControl.Controls.OfType(Of System.Windows.Forms.Control)()

        '        LoadFormSettings(Control, Form)

        '        If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IFormSettings Then

        '            CType(Control, AdvantageFramework.WinForm.Presentation.Controls.Classes.IFormSettings).LoadFormSettings(Form)

        '        End If

        '    Next

        'End Sub
        'Public Sub LoadUserControlFormSettings(ByVal FormSettingsControl As System.Windows.Forms.Control, ByVal Form As System.Windows.Forms.Form)

        '    For Each Control In FormSettingsControl.Controls.OfType(Of System.Windows.Forms.Control)()

        '        LoadUserControlFormSettings(Control, Form)

        '        If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.Classes.IUserControlFormSettings Then

        '            CType(Control, AdvantageFramework.WinForm.Presentation.Controls.Classes.IUserControlFormSettings).LoadFormSettings(Form)

        '        End If

        '    Next

        'End Sub
        Public Sub SetTextOnLabelControl(ByRef Label As AdvantageFramework.WinForm.Presentation.Controls.Label, ByVal [Text] As String)

            'objects
            Dim SetTextDelegate As SetTextOnLabelControlDelegate = Nothing

            If Label.InvokeRequired Then

                SetTextDelegate = New SetTextOnLabelControlDelegate(AddressOf SetTextOnLabelControl)

                Label.Invoke(SetTextDelegate, New Object() {Label, [Text]})

            Else

                Label.Text = [Text]

            End If

        End Sub
        Public Sub SetTextOnTextBoxControl(ByRef TextBox As AdvantageFramework.WinForm.Presentation.Controls.TextBox, ByVal [Text] As String)

            'objects
            Dim SetTextDelegate As SetTextOnTextBoxControlDelegate = Nothing

            If TextBox.InvokeRequired Then

                SetTextDelegate = New SetTextOnTextBoxControlDelegate(AddressOf SetTextOnTextBoxControl)

                TextBox.Invoke(SetTextDelegate, New Object() {TextBox, [Text]})

            Else

                TextBox.Text = [Text]

            End If

        End Sub
        Friend Sub AddComboBoxColumn(ByVal [Property] As [Enum], ByRef DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

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
        Friend Sub AddComboBoxColumn(ByVal Name As String, ByRef DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

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
        Friend Sub AddComboBoxColumn(ByVal Name As String, ByRef BandedDataGridView As AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView, Optional ByVal IsVisible As Boolean = True)

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
        Friend Sub AddColumn(ByVal Name As String, ByRef DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

            FormatColumn(Name, Name, AdvantageFramework.StringUtilities.GetNameAsWords(Name).Trim, GridColumn, IsVisible)

            DataGridView.Columns.Add(GridColumn)

        End Sub
        Friend Sub AddColumn(ByVal Name As String, ByRef BandedDataGridView As AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView, Optional ByVal IsVisible As Boolean = True)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

            FormatColumn(Name, Name, AdvantageFramework.StringUtilities.GetNameAsWords(Name).Trim, GridColumn, IsVisible)

            BandedDataGridView.Columns.Add(GridColumn)

        End Sub
        Friend Sub AddColumn(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If PropertyDescriptor IsNot Nothing Then

                GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

                FormatColumn(PropertyDescriptor, GridColumn, IsVisible)

                DataGridView.Columns.Add(GridColumn)

            End If

        End Sub
        Friend Sub AddColumn(ByVal [Property] As [Enum], ByRef DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, Optional ByVal IsVisible As Boolean = True)

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

            AdvantageFramework.WinForm.Presentation.Controls.SuspendBindingOnABindingSource(BindingSource)

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

                            If Not (PropertyInfo.DeclaringType IsNot Nothing AndAlso PropertyInfo.DeclaringType.Name = "Attribute" AndAlso PropertyInfo.Name = "TypeId") Then

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

                    Else

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

            AdvantageFramework.WinForm.Presentation.Controls.ResumeBindingOnABindingSource(BindingSource)

        End Sub
        Public Function FindObjectInDataSource(ByVal BindingSource As System.Windows.Forms.BindingSource, ByVal PropertyName As String, ByVal Value As Object) As Object

            'objects
            Dim DataBoundType As System.Type = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim FoundObject As Object = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.SuspendBindingOnABindingSource(BindingSource)

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

            AdvantageFramework.WinForm.Presentation.Controls.ResumeBindingOnABindingSource(BindingSource)

            FindObjectInDataSource = FoundObject

        End Function
        Public Function ValidateControl(ByVal [Form] As System.Windows.Forms.Form, ByVal [Control] As System.Windows.Forms.Control) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                If TypeOf [Form] Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    IsValid = DirectCast([Form], AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ValidateControl([Control])

                ElseIf TypeOf [Form] Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm Then

                    IsValid = DirectCast([Form], AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).ValidateControl([Control])

                ElseIf TypeOf [Form] Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseSettingsForm Then

                    IsValid = DirectCast([Form], AdvantageFramework.WinForm.Presentation.BaseForms.BaseSettingsForm).ValidateControl([Control])

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
        Public Function LoadDefaultGridViewItemDescription(ByVal ObjectType As System.Type) As String

            'objects
            Dim ItemDescription As String = Nothing

            Try

                If ObjectType IsNot Nothing Then

                    If ObjectType Is GetType(AdvantageFramework.Database.Views.ProductView) OrElse
                       ObjectType Is GetType(AdvantageFramework.Database.Views.FunctionView) Then

                        ItemDescription = AdvantageFramework.StringUtilities.GetNameAsWords(ObjectType.Name.Replace("View", "")) & "(s)"

                    ElseIf ObjectType Is GetType(AdvantageFramework.Database.Classes.PurchaseOrderComplex) Then

                        ItemDescription = "Purchase Order(s)"

                    Else

                        ItemDescription = AdvantageFramework.StringUtilities.GetNameAsWords(ObjectType.Name) & "(s)"

                    End If

                Else

                    ItemDescription = "Item(s)"

                End If

            Catch ex As Exception
                ItemDescription = "Item(s)"
            Finally
                LoadDefaultGridViewItemDescription = ItemDescription
            End Try

        End Function
        Public Sub ResetRibbonBar(ByVal RibbonBar As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar)

            If RibbonBar IsNot Nothing Then

                RibbonBar.ResetCachedContentSize()
                RibbonBar.Refresh()
                RibbonBar.Width = RibbonBar.GetAutoSizeWidth
                RibbonBar.Refresh()

            End If

        End Sub
        Public Function GetFormAction(ByVal Form As System.Windows.Forms.Form) As AdvantageFramework.WinForm.Presentation.FormActions

            'objects
            Dim FormAction As AdvantageFramework.WinForm.Presentation.FormActions = Nothing

            If Form IsNot Nothing Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    FormAction = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).FormAction

                ElseIf TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm Then

                    FormAction = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).FormAction

                End If

            End If

            GetFormAction = FormAction

        End Function

#Region "  ComboBox Datasource Views "

        Private Function LoadComboBoxDataSourceView(ByVal Tasks As IEnumerable(Of AdvantageFramework.Database.Entities.Task)) As Object

            LoadComboBoxDataSourceView = (From Task In Tasks
                                          Select Task.Code,
                                                 Task.Description).ToList.Select(Function(Task) New With {.Code = Task.Code,
                                                                                                          .Description = Task.Code & " - " & Task.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Phases As IEnumerable(Of AdvantageFramework.Database.Entities.Phase)) As Object

            LoadComboBoxDataSourceView = (From Phase In Phases
                                          Select Phase.ID,
                                                 Phase.Description,
                                                 Phase.OrderNumber).ToList.Select(Function(Phase) New With {.ID = CLng(Phase.ID),
                                                                                                            .Description = Phase.Description & " - " & Phase.OrderNumber}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal PostPeriods As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)) As Object

            LoadComboBoxDataSourceView = (From PostPeriod In PostPeriods
                                          Select PostPeriod.Code,
                                                 PostPeriod.Description).ToList.Select(Function(PostPeriod) New With {.Code = PostPeriod.Code,
                                                                                                                      .Description = PostPeriod.Code & " - " & PostPeriod.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ServiceFeeReconciliationReports As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport)) As Object

            LoadComboBoxDataSourceView = (From ServiceFeeReconciliationReport In ServiceFeeReconciliationReports
                                          Select ServiceFeeReconciliationReport.ID,
                                                 ServiceFeeReconciliationReport.Description).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                                      .Description = Entity.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)) As Object

            LoadComboBoxDataSourceView = (From JobComponent In JobComponents
                                          Order By JobComponent.JobNumber Descending
                                          Select New With {.ID = JobComponent.ID,
                                                           .Description = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.Number, 2, "0", True, True) & " - " & JobComponent.Description).Trim,
                                                           .JobNumber = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.JobNumber, 6, "0", True, True)).Trim}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)) As Object

            LoadComboBoxDataSourceView = (From JobComponent In JobComponents
                                          Order By JobComponent.JobNumber Descending
                                          Select New With {.ID = JobComponent.ID,
                                                           .Description = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.Number, 2, "0", True, True) & " - " & JobComponent.Description).Trim,
                                                           .JobNumber = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.JobNumber, 6, "0", True, True)).Trim}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Entities.Job)) As Object

            LoadComboBoxDataSourceView = (From Job In Jobs
                                          Order By Job.Number Descending
                                          Select New With {.Number = Job.Number,
                                                           .Description = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Job.Number, 6, "0", True, True) & " - " & Job.Description).Trim}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Core.Job)) As Object

            LoadComboBoxDataSourceView = (From Job In Jobs
                                          Order By Job.Number Descending
                                          Select New With {.Number = Job.Number,
                                                           .Description = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Job.Number, 6, "0", True, True) & " - " & Job.Description).Trim}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Markets As IEnumerable(Of AdvantageFramework.Database.Entities.Market)) As Object

            LoadComboBoxDataSourceView = (From Market In Markets
                                          Select New With {.Code = Market.Code,
                                                           .Description = Market.Code & " - " & Market.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Ads As IEnumerable(Of AdvantageFramework.Database.Entities.Ad)) As Object

            LoadComboBoxDataSourceView = (From Ad In Ads
                                          Select New With {.Number = Ad.Number,
                                                           .Description = Ad.Number & " - " & Ad.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Campaigns As IEnumerable(Of AdvantageFramework.Database.Entities.Campaign)) As Object

            LoadComboBoxDataSourceView = (From Campaign In Campaigns
                                          Select Campaign.Code,
                                                 Campaign.Name).ToList.Select(Function(Entity) New With {.[Code] = Entity.Code,
                                                                                                         .[Name] = Entity.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal AdSizes As IEnumerable(Of AdvantageFramework.Database.Entities.AdSize)) As Object

            LoadComboBoxDataSourceView = (From AdSize In AdSizes
                                          Select New With {.Code = AdSize.Code,
                                                           .Description = AdSize.Code & " - " & AdSize.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal AlertGroups As IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup)) As Object

            LoadComboBoxDataSourceView = (From AlertGroup In AlertGroups
                                          Select AlertGroup.Code).Distinct.ToList.Select(Function(AlertGroup) New With {.Code = AlertGroup,
                                                                                                                        .Description = AlertGroup}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Entities.Client)) As Object

            LoadComboBoxDataSourceView = (From Client In Clients
                                          Select New With {.Code = Client.Code,
                                                           .Description = Client.Code & " - " & Client.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Core.Client)) As Object

            LoadComboBoxDataSourceView = (From Client In Clients
                                          Select New With {.Code = Client.Code,
                                                           .Description = Client.Code & " - " & Client.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Entities.Division)) As Object

            LoadComboBoxDataSourceView = (From Division In Divisions
                                          Select New With {.Code = Division.Code,
                                                           .Description = Division.Code & " - " & Division.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Core.Division)) As Object

            LoadComboBoxDataSourceView = (From Division In Divisions
                                          Select New With {.Code = Division.Code,
                                                           .Description = Division.Code & " - " & Division.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Entities.Product)) As Object

            LoadComboBoxDataSourceView = (From Product In Products
                                          Select New With {.Code = Product.Code,
                                                           .Description = Product.Code & " - " & Product.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Core.Product)) As Object

            LoadComboBoxDataSourceView = (From Product In Products
                                          Select New With {.Code = Product.Code,
                                                           .Description = Product.Code & " - " & Product.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ProductSortKeys As IEnumerable(Of AdvantageFramework.Database.Entities.ProductSortKey)) As Object

            LoadComboBoxDataSourceView = (From ProductSortKey In ProductSortKeys
                                          Select ProductSortKey.SortKey).ToList.Select(Function(PrdSrtKey) New With {.SortKey = PrdSrtKey}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal DivisionSortKeys As IEnumerable(Of AdvantageFramework.Database.Entities.DivisionSortKey)) As Object

            LoadComboBoxDataSourceView = (From DivisionSortKey In DivisionSortKeys
                                          Select DivisionSortKey.SortKey).ToList.ToList.Select(Function(DivSrtKey) New With {.SortKey = DivSrtKey}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ClientSortKeys As IEnumerable(Of AdvantageFramework.Database.Entities.ClientSortKey)) As Object

            LoadComboBoxDataSourceView = (From ClientSortKey In ClientSortKeys
                                          Select ClientSortKey.SortKey).ToList.ToList.Select(Function(ClSrtKey) New With {.SortKey = ClSrtKey}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal WorkspaceTemplates As IEnumerable(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplate)) As Object

            LoadComboBoxDataSourceView = (From WorkspaceTemplate In WorkspaceTemplates
                                          Select WorkspaceTemplate.ID,
                                                 WorkspaceTemplate.Name).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                  .Name = Entity.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Security.Database.Views.Employee)) As Object

            LoadComboBoxDataSourceView = (From Employee In Employees
                                          Select Employee.Code,
                                                 Employee.FirstName,
                                                 Employee.MiddleInitial,
                                                 Employee.LastName).ToList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                               .FullName = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "",
                                                                                                                              Employee.FirstName & " " & Employee.MiddleInitial & " " & Employee.LastName,
                                                                                                                              Employee.FirstName & " " & Employee.LastName)}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee)) As Object

            LoadComboBoxDataSourceView = (From Employee In Employees
                                          Select Employee.Code,
                                                 Employee.MiddleInitial,
                                                 Employee.FirstName,
                                                 Employee.LastName).ToList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                               .EmpCode = Employee.Code,
                                                                                                               .Description = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "",
                                                                                                                                 Employee.FirstName & " " & Employee.MiddleInitial & " " & Employee.LastName,
                                                                                                                                 Employee.FirstName & " " & Employee.LastName)}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Core.Employee)) As Object

            LoadComboBoxDataSourceView = (From Employee In Employees
                                          Select Employee.Code,
                                                 Employee.MiddleInitial,
                                                 Employee.FirstName,
                                                 Employee.LastName).ToList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                               .EmpCode = Employee.Code,
                                                                                                               .Description = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "",
                                                                                                                                 Employee.FirstName & " " & Employee.MiddleInitial & " " & Employee.LastName,
                                                                                                                                 Employee.FirstName & " " & Employee.LastName)}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ServerSQLUsers As IEnumerable(Of AdvantageFramework.Security.Database.Views.ServerSQLUser)) As Object

            LoadComboBoxDataSourceView = (From ServerSQLUser In ServerSQLUsers
                                          Select ServerSQLUser.ID,
                                                 ServerSQLUser.Name).ToList.Select(Function(ServerSQLUser) New With {.ID = ServerSQLUser.ID,
                                                                                                                     .Name = ServerSQLUser.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Roles As IEnumerable(Of AdvantageFramework.Database.Entities.Role)) As Object

            LoadComboBoxDataSourceView = (From Role In Roles
                                          Select Role.Code,
                                                 Role.Description).ToList.Select(Function(Role) New With {.Code = Role.Code,
                                                                                                          .Description = Role.Code & " - " & Role.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Applications As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application)) As Object

            LoadComboBoxDataSourceView = (From Application In Applications
                                          Select Application.ID,
                                                 Application.Name).ToList.Select(Function(Application) New With {.ID = Application.ID,
                                                                                                                 .Name = Application.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ClientContacts As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact)) As Object

            LoadComboBoxDataSourceView = (From ClientContact In ClientContacts
                                          Select ClientContact.ContactID,
                                                 ClientContact.FullNameFML).ToList.Select(Function(ClientContact) New With {.ID = ClientContact.ContactID,
                                                                                                                            .FullNameFML = ClientContact.FullNameFML}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ClientPortalUsers As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser)) As Object

            LoadComboBoxDataSourceView = (From ClientPortalUser In ClientPortalUsers
                                          Select ClientPortalUser.ClientContactID,
                                                 ClientPortalUser.ClientContact.FullNameFML).ToList.Select(Function(ClientPortalUser) New With {.ClientContactID = ClientPortalUser.ClientContactID,
                                                                                                                                                .FullNameFML = ClientPortalUser.FullNameFML}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal SalesTaxes As IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax)) As Object

            LoadComboBoxDataSourceView = (From SalesTax In SalesTaxes
                                          Select SalesTax.TaxCode,
                                                 SalesTax.Description).ToList.Select(Function(SalesTax) New With {.Code = SalesTax.TaxCode,
                                                                                                                  .Description = SalesTax.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Entities.Office)) As Object

            LoadComboBoxDataSourceView = (From Office In Offices
                                          Select Office.Code,
                                                 Office.Name).ToList.Select(Function(Office) New With {.Code = Office.Code,
                                                                                                       .Description = Office.Code & " - " & Office.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Core.Office)) As Object

            LoadComboBoxDataSourceView = (From Office In Offices
                                          Select Office.Code,
                                                 Office.Name).ToList.Select(Function(Office) New With {.Code = Office.Code,
                                                                                                       .Description = Office.Code & " - " & Office.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)) As Object

            LoadComboBoxDataSourceView = (From Vendor In Vendors
                                          Select Vendor.Code,
                                                 Vendor.Name).ToList.Select(Function(Vendor) New With {.Code = Vendor.Code,
                                                                                                       .Name = Vendor.Code & " - " & Vendor.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal CustomReports As IEnumerable(Of AdvantageFramework.Database.Entities.CustomReport)) As Object

            LoadComboBoxDataSourceView = (From CustomReport In CustomReports
                                          Select CustomReport.Name,
                                                 CustomReport.Description).ToList.Select(Function(CustomReport) New With {.Code = CustomReport.Name,
                                                                                                                          .Name = CustomReport.Name & " - " & CustomReport.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal CurrencyCodes As IEnumerable(Of AdvantageFramework.Database.Entities.CurrencyCode)) As Object

            LoadComboBoxDataSourceView = (From CurrencyCode In CurrencyCodes
                                          Select CurrencyCode.Code,
                                                 CurrencyCode.Description).ToList.Select(Function(CurrencyCode) New With {.Code = CurrencyCode.Code,
                                                                                                                          .Description = CurrencyCode.Code & " - " & CurrencyCode.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal PrintSpecRegions As IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion)) As Object

            LoadComboBoxDataSourceView = (From PrintSpecRegion In PrintSpecRegions
                                          Select PrintSpecRegion.Code,
                                                 PrintSpecRegion.Description).ToList.Select(Function(PrintSpecRegion) New With {.Code = PrintSpecRegion.Code,
                                                                                                                                .Description = PrintSpecRegion.Code & " - " & PrintSpecRegion.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ShortNumericList As IEnumerable(Of Int16)) As Object

            LoadComboBoxDataSourceView = From Number In ShortNumericList
                                         Select New With {.[Number] = Number}

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal LongNumericList As IEnumerable(Of Int32)) As Object

            LoadComboBoxDataSourceView = From Number In LongNumericList
                                         Select New With {.[Number] = Number}

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal DateList As IEnumerable(Of Date)) As Object

            LoadComboBoxDataSourceView = (From [Date] In DateList
                                          Select New With {.[Date] = [Date]}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ExportSystems As IEnumerable(Of AdvantageFramework.Database.Entities.ExportSystem)) As Object

            LoadComboBoxDataSourceView = (From ExportSystem In ExportSystems
                                          Select ExportSystem.Name,
                                                 ExportSystem.Label).ToList.Select(Function(ExportSystem) New With {.Name = ExportSystem.Name,
                                                                                                                    .Label = ExportSystem.Label}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal PurchaseOrderApprovalRules As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)) As Object

            LoadComboBoxDataSourceView = (From PurchaseOrderApprovalRule In PurchaseOrderApprovalRules
                                          Select PurchaseOrderApprovalRule.Code,
                                                 PurchaseOrderApprovalRule.Description).ToList.Select(Function(PurchaseOrderApprovalRule) New With {.Code = PurchaseOrderApprovalRule.Code,
                                                                                                                                                    .Description = PurchaseOrderApprovalRule.Code & " - " & PurchaseOrderApprovalRule.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal BillingRateLevels As IEnumerable(Of AdvantageFramework.Database.Entities.BillingRateLevel)) As Object

            LoadComboBoxDataSourceView = (From BillingRateLevel In BillingRateLevels
                                          Select BillingRateLevel.ID,
                                                 BillingRateLevel.Number,
                                                 BillingRateLevel.Description).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                        .Description = Entity.Number & " - " & Entity.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal EmployeeTitles As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle)) As Object

            LoadComboBoxDataSourceView = (From EmployeeTitle In EmployeeTitles
                                          Select EmployeeTitle.ID,
                                                 EmployeeTitle.Description).ToList.Select(Function(EmployeeTitle) New With {.ID = EmployeeTitle.ID,
                                                                                                                            .Description = EmployeeTitle.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Functions As IEnumerable(Of AdvantageFramework.Database.Entities.Function)) As Object

            LoadComboBoxDataSourceView = (From [Function] In Functions
                                          Select [Function].Code,
                                                 [Function].Type,
                                                 [Function].Description).Select(Function([Function]) New With {.Code = [Function].Code,
                                                                                                               .Type = [Function].Type,
                                                                                                               .Description = [Function].Code & " - " & [Function].Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Functions As IEnumerable(Of AdvantageFramework.Database.Core.Function)) As Object

            LoadComboBoxDataSourceView = (From [Function] In Functions
                                          Select [Function].Code,
                                                 [Function].Type,
                                                 [Function].Description).ToList.Select(Function([Function]) New With {.Code = [Function].Code,
                                                                                                                      .Type = [Function].Type,
                                                                                                                      .Description = [Function].Code & " - " & [Function].Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Users As IEnumerable(Of AdvantageFramework.Security.Database.Entities.User)) As Object

            LoadComboBoxDataSourceView = (From User In Users
                                          Select User.ID,
                                                 User.UserCode).ToList.Select(Function(User) New With {.ID = User.ID,
                                                                                                       .Name = User.UserCode}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ResourceTypes As IEnumerable(Of AdvantageFramework.Database.Entities.ResourceType)) As Object

            LoadComboBoxDataSourceView = (From ResourceType In ResourceTypes
                                          Select ResourceType.Code,
                                                 ResourceType.Description).ToList.Select(Function(ResourceType) New With {.Code = ResourceType.Code,
                                                                                                                          .Description = ResourceType.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal AlertCategories As IEnumerable(Of AdvantageFramework.Database.Entities.AlertCategory)) As Object

            LoadComboBoxDataSourceView = (From AlertCategory In AlertCategories
                                          Select AlertCategory.ID,
                                                 AlertCategory.Description).ToList.Select(Function(AlertCategory) New With {.ID = AlertCategory.ID,
                                                                                                                            .Description = AlertCategory.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal DocumentTypes As IEnumerable(Of AdvantageFramework.Database.Entities.DocumentType)) As Object

            LoadComboBoxDataSourceView = (From DocumentType In DocumentTypes
                                          Select DocumentType.ID,
                                                 DocumentType.Description).ToList.Select(Function(DocumentType) New With {.ID = DocumentType.ID,
                                                                                                                          .Description = DocumentType.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ImportTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)) As Object

            LoadComboBoxDataSourceView = (From ImportTemplate In ImportTemplates
                                          Select ImportTemplate.ID,
                                                 ImportTemplate.Name).ToList.Select(Function(ImportTemplate) New With {.ID = ImportTemplate.ID,
                                                                                                                       .Name = ImportTemplate.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal JobSpecificationVendorTabs As IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationVendorTab)) As Object

            LoadComboBoxDataSourceView = (From JobSpecificationVendorTab In JobSpecificationVendorTabs
                                          Select JobSpecificationVendorTab.ID,
                                                 JobSpecificationVendorTab.Description).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                                 .Description = Entity.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal EmployeeCategoryies As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeCategory)) As Object

            LoadComboBoxDataSourceView = (From EmployeeCategory In EmployeeCategoryies
                                          Select EmployeeCategory.ID,
                                                 EmployeeCategory.Description).ToList.Select(Function(EmployeeCategory) New With {.ID = EmployeeCategory.ID,
                                                                                                                                  .Description = EmployeeCategory.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Statuses As IEnumerable(Of AdvantageFramework.Database.Entities.Status)) As Object

            LoadComboBoxDataSourceView = (From Status In Statuses
                                          Select Status.Code,
                                                 Status.Description).ToList.Select(Function(Status) New With {.Code = Status.Code,
                                                                                                              .Description = Status.Code & " - " & Status.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ClientContacts As IEnumerable(Of AdvantageFramework.Database.Entities.ClientContact)) As Object

            LoadComboBoxDataSourceView = (From ClientContact In ClientContacts
                                          Select ClientContact.ContactID,
                                                 ClientContact.FirstName,
                                                 ClientContact.LastName,
                                                 ClientContact.ContactCode).ToList.Select(Function(ClientContact) New With {.ID = ClientContact.ContactID,
                                                                                                                            .Description = ClientContact.ContactCode & " - " & ClientContact.FirstName & " " & ClientContact.LastName}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal DepartmentTeams As IEnumerable(Of AdvantageFramework.Database.Entities.DepartmentTeam)) As Object

            LoadComboBoxDataSourceView = (From DepartmentTeam In DepartmentTeams
                                          Select DepartmentTeam.Code,
                                                 DepartmentTeam.Description).ToList.Select(Function(DepartmentTeam) New With {.Code = DepartmentTeam.Code,
                                                                                                                              .Description = DepartmentTeam.Code & " - " & DepartmentTeam.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)) As Object

            LoadComboBoxDataSourceView = (From GeneralLedgerAccount In GeneralLedgerAccounts
                                          Select GeneralLedgerAccount.Code,
                                                 GeneralLedgerAccount.Description).Select(Function(GeneralLedgerAccount) New With {.Code = GeneralLedgerAccount.Code,
                                                                                                                                   .Description = GeneralLedgerAccount.Code & " - " & GeneralLedgerAccount.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)) As Object

            LoadComboBoxDataSourceView = (From GeneralLedgerAccount In GeneralLedgerAccounts
                                          Select GeneralLedgerAccount.Code,
                                                 GeneralLedgerAccount.Description).Select(Function(GeneralLedgerAccount) New With {.Code = GeneralLedgerAccount.Code,
                                                                                                                                   .Description = GeneralLedgerAccount.Code & " - " & GeneralLedgerAccount.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal WebsiteTypes As IEnumerable(Of AdvantageFramework.Database.Entities.WebsiteType)) As Object

            LoadComboBoxDataSourceView = (From WebsiteType In WebsiteTypes
                                          Select WebsiteType.Code,
                                                 WebsiteType.Description).ToList.Select(Function(WebsiteType) New With {.Code = WebsiteType.Code,
                                                                                                                        .Description = WebsiteType.Code & " - " & WebsiteType.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal SalesClasses As IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass)) As Object

            LoadComboBoxDataSourceView = (From SalesClass In SalesClasses
                                          Select SalesClass.Code,
                                                 SalesClass.Description).ToList.Select(Function(SalesClass) New With {.Code = SalesClass.Code,
                                                                                                                      .Description = SalesClass.Code & " - " & SalesClass.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal FunctionHeadings As IEnumerable(Of AdvantageFramework.Database.Entities.FunctionHeading)) As Object

            LoadComboBoxDataSourceView = (From FunctionHeading In FunctionHeadings
                                          Select FunctionHeading.ID,
                                                 FunctionHeading.Description).ToList.Select(Function(FunctionHeading) New With {.Code = FunctionHeading.ID,
                                                                                                                                .Description = FunctionHeading.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal VendorTerms As IEnumerable(Of AdvantageFramework.Database.Entities.VendorTerm)) As Object

            LoadComboBoxDataSourceView = (From VendorTerm In VendorTerms
                                          Select VendorTerm.Code,
                                                 VendorTerm.Description).ToList.Select(Function(VendorTerm) New With {.Code = VendorTerm.Code,
                                                                                                                      .Description = VendorTerm.Code & " - " & VendorTerm.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal PurchaseOrders As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrder)) As Object

            LoadComboBoxDataSourceView = (From PurchaseOrder In PurchaseOrders
                                          Select PurchaseOrder.Number,
                                                 PurchaseOrder.Description,
                                                 PurchaseOrder.Date,
                                                 PurchaseOrder.DueDate,
                                                 PurchaseOrder.ApprovalFlag,
                                                 PurchaseOrder.IsWorkComplete).ToList.Select(Function(PurchaseOrder) New With {.Number = PurchaseOrder.Number,
                                                                                                                               .Description = PurchaseOrder.Description,
                                                                                                                               .Date = If(PurchaseOrder.Date IsNot Nothing, CDate(PurchaseOrder.Date).ToShortDateString, ""),
                                                                                                                               .DueDate = If(PurchaseOrder.DueDate IsNot Nothing, CDate(PurchaseOrder.DueDate).ToShortDateString, ""),
                                                                                                                               .POTotal = 0,
                                                                                                                               .POBalance = 0,
                                                                                                                               .Status = If(PurchaseOrder.ApprovalFlag Is Nothing, "[None]", If(PurchaseOrder.ApprovalFlag = 1, "Pending", "Approved")),
                                                                                                                               .WorkComplete = If(PurchaseOrder.IsWorkComplete Is Nothing, "No", If(PurchaseOrder.IsWorkComplete = 1, "Yes", "No"))}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal PurchaseOrderDetails As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail)) As Object

            LoadComboBoxDataSourceView = (From PurchaseOrderDetail In PurchaseOrderDetails
                                          Select PurchaseOrderDetail.LineNumber,
                                                 PurchaseOrderDetail.Description).ToList.Select(Function(PurchaseOrderDetail) New With {.LineNumber = PurchaseOrderDetail.LineNumber,
                                                                                                                                        .Description = PurchaseOrderDetail.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal ServiceFeeTypes As IEnumerable(Of AdvantageFramework.Database.Entities.ServiceFeeType)) As Object

            LoadComboBoxDataSourceView = (From ServiceFeeType In ServiceFeeTypes
                                          Select New With {.Code = ServiceFeeType.Code,
                                                           .Description = ServiceFeeType.Code & " - " & ServiceFeeType.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Cycles As IEnumerable(Of AdvantageFramework.Database.Entities.Cycle)) As Object

            LoadComboBoxDataSourceView = (From Cycle In Cycles
                                          Select New With {.Code = Cycle.Code,
                                                           .Name = Cycle.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Banks As IEnumerable(Of AdvantageFramework.Database.Entities.Bank)) As Object

            LoadComboBoxDataSourceView = (From Bank In Banks
                                          Select Bank.Code,
                                                 Bank.Description).ToList.Select(Function(Bank) New With {.Code = Bank.Code,
                                                                                                          .Description = Bank.Code & " - " & Bank.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal DayParts As IEnumerable(Of AdvantageFramework.Database.Entities.Daypart)) As Object

            LoadComboBoxDataSourceView = (From DayPart In DayParts
                                          Select DayPart.ID,
                                                 DayPart.Description).ToList.Select(Function(DayPart) New With {.ID = DayPart.ID,
                                                                                                                .Description = DayPart.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal JobVersionDatabaseTypes As IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionDatabaseType)) As Object

            LoadComboBoxDataSourceView = (From JobVersionDatabaseType In JobVersionDatabaseTypes
                                          Select JobVersionDatabaseType.ID,
                                                 JobVersionDatabaseType.Description).ToList.Select(Function(JobVersionDatabaseType) New With {.ID = JobVersionDatabaseType.ID,
                                                                                                                                              .Description = JobVersionDatabaseType.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal JobVersionTemplateDetails As IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)) As Object

            LoadComboBoxDataSourceView = (From JobVersionTemplateDetail In JobVersionTemplateDetails
                                          Select JobVersionTemplateDetail.ID,
                                                 JobVersionTemplateDetail.Label).ToList.Select(Function(JobVersionTemplateDetail) New With {.ID = JobVersionTemplateDetail.ID,
                                                                                                                                            .Description = JobVersionTemplateDetail.Label}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal UserDefinedReportCategories As IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory)) As Object

            LoadComboBoxDataSourceView = (From UserDefinedReportCategory In UserDefinedReportCategories
                                          Select New With {.ID = UserDefinedReportCategory.ID,
                                                           .Description = UserDefinedReportCategory.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal JobVersionTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplate)) As Object

            LoadComboBoxDataSourceView = (From JobVersionTemplate In JobVersionTemplates
                                          Select JobVersionTemplate.Code,
                                                 JobVersionTemplate.Description,
                                                 JobVersionTemplate.IsInactive
                                          Distinct).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                             .Description = Entity.Description,
                                                                                             .IsInactive = CBool(Entity.IsInactive.GetValueOrDefault(0))}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal AccountGroups As IEnumerable(Of AdvantageFramework.Database.Entities.AccountGroup)) As Object

            LoadComboBoxDataSourceView = (From AccountGroup In AccountGroups
                                          Select New With {.Code = AccountGroup.Code,
                                                           .Description = AccountGroup.Description}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal AlertStates As IEnumerable(Of AdvantageFramework.Database.Entities.AlertState)) As Object

            LoadComboBoxDataSourceView = (From AlertState In AlertStates
                                          Select New With {.ID = AlertState.ID,
                                                           .Name = AlertState.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal AlertAssignmentTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)) As Object

            LoadComboBoxDataSourceView = (From AlertAssignmentTemplate In AlertAssignmentTemplates
                                          Select New With {.ID = AlertAssignmentTemplate.ID,
                                                           .Name = AlertAssignmentTemplate.Name}).ToList

        End Function
		Private Function LoadComboBoxDataSourceView(ByVal ExportTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.ExportTemplate)) As Object

			LoadComboBoxDataSourceView = (From ExportTemplate In ExportTemplates
										  Select New With {.ID = ExportTemplate.ID,
														   .Name = ExportTemplate.Name}).ToList

		End Function
		Private Function LoadComboBoxDataSourceView(ByVal MediaPlans As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan)) As Object

			LoadComboBoxDataSourceView = (From MediaPlan In MediaPlans
										  Select New With {.ID = MediaPlan.ID,
														   .Description = MediaPlan.Description}).ToList

		End Function
        Private Function LoadComboBoxDataSourceView(ByVal VendorInvoiceCategories As IEnumerable(Of AdvantageFramework.Database.Entities.VendorInvoiceCategory)) As Object

            LoadComboBoxDataSourceView = (From VendorInvoiceCategory In VendorInvoiceCategories
                                          Select New With {.ID = VendorInvoiceCategory.ID,
                                                           .Name = VendorInvoiceCategory.Name}).ToList

        End Function
        Private Function LoadComboBoxDataSourceView(ByVal Images As IEnumerable(Of AdvantageFramework.Database.Entities.Image)) As Object

            LoadComboBoxDataSourceView = (From Image In Images
                                          Select New With {.ID = Image.ID,
                                                           .Name = Image.Name}).ToList

        End Function
        Public Function LoadComboBoxDataSourceView(ByVal Value As Object) As Object

            'objects
            Dim View As Object = Nothing

            If TypeOf Value Is IEnumerable Then

                If TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.Employee) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.Employee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Employee) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Employee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Views.Employee) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Views.Employee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Views.ServerSQLUser) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Views.ServerSQLUser)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Client) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Client)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Client) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Client)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplate) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Role) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Role)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Office) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Office)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Office) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Office)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ProductSortKey) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ProductSortKey)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DivisionSortKey) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DivisionSortKey)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientSortKey) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientSortKey)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Division) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Division)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Division) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Division)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Product) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Product)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Product) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Product)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CustomReport) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CustomReport)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CurrencyCode) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CurrencyCode)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Ad) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Ad)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Market) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Market)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.JobComponent) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.VendorTerm) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.VendorTerm)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ExportSystem) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ExportSystem)))

                ElseIf TypeOf Value Is IEnumerable(Of Int16) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of Int16)))

                ElseIf TypeOf Value Is IEnumerable(Of Int32) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of Int32)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.BillingRateLevel) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.BillingRateLevel)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Function) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Function)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Function) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Function)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.User) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.User)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Job) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Job)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Job) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Job)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ResourceType) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ResourceType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertCategory) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DocumentType) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DocumentType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationVendorTab) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationVendorTab)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AdSize) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AdSize)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Campaign) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Campaign)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Daypart) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Daypart)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionDatabaseType) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionDatabaseType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DepartmentTeam) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DepartmentTeam)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.FunctionHeading) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.FunctionHeading)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientContact) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientContact)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Phase) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Phase)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Task) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Task)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ServiceFeeType) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ServiceFeeType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Cycle) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Cycle)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplate) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AccountGroup) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AccountGroup)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertState) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertState)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ExportTemplate) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ExportTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of Date) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of Date)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.VendorInvoiceCategory) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.VendorInvoiceCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Image) Then

                    View = LoadComboBoxDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Image)))

                Else

                    View = Value

                End If

            Else

                View = Value

            End If

            LoadComboBoxDataSourceView = View

        End Function

#End Region

#Region "  GridView Datasource Views "

        Private Function LoadGridViewDataSourceView(ByVal PostPeriods As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)) As Object

            LoadGridViewDataSourceView = (From PostPeriod In PostPeriods
                                          Select New With {.Code = PostPeriod.Code,
                                                           .Description = PostPeriod.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ServiceFeeReconciliationReports As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport)) As Object

            LoadGridViewDataSourceView = (From ServiceFeeReconciliationReport In ServiceFeeReconciliationReports
                                          Select New With {.ID = ServiceFeeReconciliationReport.ID,
                                                           .Description = ServiceFeeReconciliationReport.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Markets As IEnumerable(Of AdvantageFramework.Database.Entities.Market)) As Object

            LoadGridViewDataSourceView = (From Market In Markets
                                          Select New With {.Code = Market.Code,
                                                           .Description = Market.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Ads As IEnumerable(Of AdvantageFramework.Database.Entities.Ad)) As Object

            LoadGridViewDataSourceView = (From Ad In Ads
                                          Select New With {.Number = Ad.Number,
                                                           .Description = Ad.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Campaigns As IEnumerable(Of AdvantageFramework.Database.Entities.Campaign)) As Object

            LoadGridViewDataSourceView = (From Campaign In Campaigns
                                          Select New With {.[ID] = Campaign.ID,
                                                           .[Code] = Campaign.Code,
                                                           .[Name] = Campaign.Name,
                                                           .[Office] = Campaign.OfficeCode,
                                                           .[Client] = Campaign.ClientCode,
                                                           .[Division] = Campaign.DivisionCode,
                                                           .[Product] = Campaign.ProductCode}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Campaigns As IEnumerable(Of AdvantageFramework.Database.Core.Campaign)) As Object

            LoadGridViewDataSourceView = (From Campaign In Campaigns
                                          Select New With {.[ID] = Campaign.ID,
                                                           .[Code] = Campaign.Code,
                                                           .[Name] = Campaign.Name,
                                                           .[Office] = Campaign.OfficeCode,
                                                           .[Client] = Campaign.ClientCode,
                                                           .[Division] = Campaign.DivisionCode,
                                                           .[Product] = Campaign.ProductCode}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal CampaignViews As IEnumerable(Of AdvantageFramework.Database.Views.CampaignView)) As Object

            LoadGridViewDataSourceView = (From CampaignView In CampaignViews
                                          Select New With {.[ID] = CampaignView.ID,
                                                           .[Code] = CampaignView.CampaignCode,
                                                           .[Name] = CampaignView.CampaignName,
                                                           .[Office] = CampaignView.OfficeCode,
                                                           .[Client] = CampaignView.ClientCode,
                                                           .[Division] = CampaignView.DivisionCode,
                                                           .[Product] = CampaignView.ProductCode}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AlertGroups As IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup)) As Object

            LoadGridViewDataSourceView = (From AlertGroup In AlertGroups
                                          Select AlertGroup.Code).Distinct.ToList.Select(Function(AlertGroup) New With {.Code = AlertGroup,
                                                                                                                        .Description = AlertGroup}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ProductSortKeys As IEnumerable(Of AdvantageFramework.Database.Entities.ProductSortKey)) As Object

            LoadGridViewDataSourceView = (From ProductSortKey In ProductSortKeys
                                          Select New With {.SortKey = ProductSortKey.SortKey}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal DivisionSortKeys As IEnumerable(Of AdvantageFramework.Database.Entities.DivisionSortKey)) As Object

            LoadGridViewDataSourceView = (From DivisionSortKey In DivisionSortKeys
                                          Select New With {.SortKey = DivisionSortKey.SortKey}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientSortKeys As IEnumerable(Of AdvantageFramework.Database.Entities.ClientSortKey)) As Object

            LoadGridViewDataSourceView = (From ClientSortKey In ClientSortKeys
                                          Select New With {.SortKey = ClientSortKey.SortKey}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal WorkspaceTemplates As IEnumerable(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplate)) As Object

            LoadGridViewDataSourceView = (From WorkspaceTemplate In WorkspaceTemplates
                                          Select New With {.ID = WorkspaceTemplate.ID,
                                                           .Name = WorkspaceTemplate.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Security.Database.Views.Employee)) As Object

            LoadGridViewDataSourceView = (From Employee In Employees
                                          Select Employee.Code,
                                                 Employee.FirstName,
                                                 Employee.MiddleInitial,
                                                 Employee.LastName).ToList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                               .FullName = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "",
                                                                                                                              Employee.FirstName & " " & Employee.MiddleInitial & " " & Employee.LastName,
                                                                                                                              Employee.FirstName & " " & Employee.LastName)}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ServerSQLUsers As IEnumerable(Of AdvantageFramework.Security.Database.Views.ServerSQLUser)) As Object

            LoadGridViewDataSourceView = (From ServerSQLUser In ServerSQLUsers
                                          Select New With {.ID = ServerSQLUser.ID,
                                                           .Name = ServerSQLUser.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Roles As IEnumerable(Of AdvantageFramework.Database.Entities.Role)) As Object

            LoadGridViewDataSourceView = (From Role In Roles
                                          Select New With {.Code = Role.Code,
                                                           .Description = Role.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Applications As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application)) As Object

            LoadGridViewDataSourceView = (From Application In Applications
                                          Select New With {.ID = Application.ID,
                                                           .Name = Application.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientContacts As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact)) As Object

            LoadGridViewDataSourceView = (From ClientContact In ClientContacts
                                          Select New With {.ID = ClientContact.ContactID,
                                                           .FullNameFML = ClientContact.FullNameFML}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientPortalUsers As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser)) As Object

            LoadGridViewDataSourceView = (From ClientPortalUser In ClientPortalUsers
                                          Select New With {.ClientContactID = ClientPortalUser.ClientContactID,
                                                           .FullNameFML = ClientPortalUser.FullName}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Core.Office)) As Object

            LoadGridViewDataSourceView = (From Office In Offices
                                          Select New With {.Code = Office.Code,
                                                           .Name = Office.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Core.Vendor)) As Object

            LoadGridViewDataSourceView = (From Vendor In Vendors
                                          Select New With {.Code = Vendor.Code,
                                                           .Name = Vendor.Name,
                                                           .Category = Vendor.VendorCategory}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)) As Object

            LoadGridViewDataSourceView = (From Vendor In Vendors
                                          Select New With {.Code = Vendor.Code,
                                                           .Name = Vendor.Name,
                                                           .Category = Vendor.VendorCategory}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal VendorContacts As IEnumerable(Of AdvantageFramework.Database.Entities.VendorContact)) As Object

            LoadGridViewDataSourceView = (From VendorContact In VendorContacts.ToList
                                          Select [Code] = VendorContact.Code,
                                                 [FullName] = VendorContact.FirstName & " " & If(VendorContact.MiddleInitial <> "", VendorContact.MiddleInitial & ". ", "") & VendorContact.LastName).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal CustomReports As IEnumerable(Of AdvantageFramework.Database.Entities.CustomReport)) As Object

            LoadGridViewDataSourceView = (From CustomReport In CustomReports
                                          Select New With {.Code = CustomReport.Name,
                                                           .Description = CustomReport.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal CurrencyCodes As IEnumerable(Of AdvantageFramework.Database.Entities.CurrencyCode)) As Object

            LoadGridViewDataSourceView = (From CurrencyCode In CurrencyCodes
                                          Select New With {.Code = CurrencyCode.Code,
                                                           .Description = CurrencyCode.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal PrintSpecRegions As IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion)) As Object

            LoadGridViewDataSourceView = (From PrintSpecRegion In PrintSpecRegions
                                          Select New With {.Code = PrintSpecRegion.Code,
                                                           .Description = PrintSpecRegion.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ShortNumericList As IEnumerable(Of Int16)) As Object

            LoadGridViewDataSourceView = From Number In ShortNumericList
                                         Select New With {.[Number] = Number}

        End Function
        Private Function LoadGridViewDataSourceView(ByVal LongNumericList As IEnumerable(Of Int32)) As Object

            LoadGridViewDataSourceView = From Number In LongNumericList
                                         Select New With {.[Number] = Number}

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ExportSystems As IEnumerable(Of AdvantageFramework.Database.Entities.ExportSystem)) As Object

            LoadGridViewDataSourceView = (From ExportSystem In ExportSystems
                                          Select New With {.Name = ExportSystem.Name,
                                                           .Label = ExportSystem.Label}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal PurchaseOrderApprovalRules As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)) As Object

            LoadGridViewDataSourceView = (From PurchaseOrderApprovalRule In PurchaseOrderApprovalRules
                                          Select New With {.Code = PurchaseOrderApprovalRule.Code,
                                                           .Description = PurchaseOrderApprovalRule.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal BillingRateLevels As IEnumerable(Of AdvantageFramework.Database.Entities.BillingRateLevel)) As Object

            LoadGridViewDataSourceView = (From BillingRateLevel In BillingRateLevels
                                          Select New With {.ID = BillingRateLevel.ID,
                                                           .Description = BillingRateLevel.Number & " - " & BillingRateLevel.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Users As IEnumerable(Of AdvantageFramework.Security.Database.Entities.User)) As Object

            LoadGridViewDataSourceView = (From User In Users
                                          Select New With {.ID = User.ID,
                                                           .Name = User.UserCode}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ResourceTypes As IEnumerable(Of AdvantageFramework.Database.Entities.ResourceType)) As Object

            LoadGridViewDataSourceView = (From ResourceType In ResourceTypes
                                          Select New With {.Code = ResourceType.Code,
                                                           .Description = ResourceType.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AlertCategories As IEnumerable(Of AdvantageFramework.Database.Entities.AlertCategory)) As Object

            LoadGridViewDataSourceView = (From AlertCategory In AlertCategories
                                          Select New With {.ID = AlertCategory.ID,
                                                           .Description = AlertCategory.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal DocumentTypes As IEnumerable(Of AdvantageFramework.Database.Entities.DocumentType)) As Object

            LoadGridViewDataSourceView = (From DocumentType In DocumentTypes
                                          Select New With {.ID = DocumentType.ID,
                                                           .Description = DocumentType.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ImportTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)) As Object

            LoadGridViewDataSourceView = (From ImportTemplate In ImportTemplates
                                          Select New With {.ID = ImportTemplate.ID,
                                                           .Name = ImportTemplate.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Industries As IEnumerable(Of AdvantageFramework.Database.Entities.Industry)) As Object

            LoadGridViewDataSourceView = (From Industry In Industries
                                          Select Industry.ID,
                                                 Industry.Description) _
                                          .Select(Function(Entity) New With {.ID = Entity.ID,
                                                                             .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal JobSpecificationVendorTabs As IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationVendorTab)) As Object

            LoadGridViewDataSourceView = (From JobSpecificationVendorTab In JobSpecificationVendorTabs
                                          Select New With {.ID = JobSpecificationVendorTab.ID,
                                                           .Description = JobSpecificationVendorTab.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal EmployeeCategoryies As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeCategory)) As Object

            LoadGridViewDataSourceView = (From EmployeeCategory In EmployeeCategoryies
                                          Select New With {.ID = EmployeeCategory.ID,
                                                           .Description = EmployeeCategory.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientContacts As IEnumerable(Of AdvantageFramework.Database.Entities.ClientContact)) As Object

            LoadGridViewDataSourceView = (From ClientContact In ClientContacts
                                          Select ClientContact.ContactID,
                                                 ClientContact.FirstName,
                                                 ClientContact.LastName,
                                                 ClientContact.ContactCode,
                                                 ClientContact.ContactTypeID).ToList.Select(Function(ClientContact) New With {.ID = ClientContact.ContactID,
                                                                                                                              .Code = ClientContact.ContactCode,
                                                                                                                              .Description = ClientContact.FirstName & " " & ClientContact.LastName,
                                                                                                                              .ContactTypeID = ClientContact.ContactTypeID.GetValueOrDefault(0)}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal DepartmentTeams As IEnumerable(Of AdvantageFramework.Database.Entities.DepartmentTeam)) As Object

            LoadGridViewDataSourceView = (From DepartmentTeam In DepartmentTeams
                                          Select New With {.Code = DepartmentTeam.Code,
                                                           .Description = DepartmentTeam.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)) As Object

            LoadGridViewDataSourceView = (From GeneralLedgerAccount In GeneralLedgerAccounts
                                          Select New With {.Code = GeneralLedgerAccount.Code,
                                                           .Description = GeneralLedgerAccount.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal SalesClasses As IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass)) As Object

            LoadGridViewDataSourceView = (From SalesClass In SalesClasses
                                          Select New With {.Code = SalesClass.Code,
                                                           .Description = SalesClass.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal FunctionHeadings As IEnumerable(Of AdvantageFramework.Database.Entities.FunctionHeading)) As Object

            LoadGridViewDataSourceView = (From FunctionHeading In FunctionHeadings
                                          Select New With {.Code = FunctionHeading.ID,
                                                           .Description = FunctionHeading.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal VendorTerms As IEnumerable(Of AdvantageFramework.Database.Entities.VendorTerm)) As Object

            LoadGridViewDataSourceView = (From VendorTerm In VendorTerms
                                          Select New With {.Code = VendorTerm.Code,
                                                           .Description = VendorTerm.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ServiceFeeTypes As IEnumerable(Of AdvantageFramework.Database.Entities.ServiceFeeType)) As Object

            LoadGridViewDataSourceView = (From ServiceFeeType In ServiceFeeTypes
                                          Select New With {.Code = ServiceFeeType.Code,
                                                           .Description = ServiceFeeType.Description,
                                                           .ID = ServiceFeeType.ID,
                                                           .CodeAndDescription = ServiceFeeType.Code & " - " & ServiceFeeType.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Sources As IEnumerable(Of AdvantageFramework.Database.Entities.Source)) As Object

            LoadGridViewDataSourceView = (From Source In Sources
                                          Select Source.ID,
                                                 Source.Description) _
                                          .Select(Function(Entity) New With {.ID = Entity.ID,
                                                                             .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Specialties As IEnumerable(Of AdvantageFramework.Database.Entities.Specialty)) As Object

            LoadGridViewDataSourceView = (From Specialty In Specialties
                                          Select Specialty.ID,
                                                 Specialty.Description) _
                                          .Select(Function(Entity) New With {.ID = Entity.ID,
                                                                             .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Cycles As IEnumerable(Of AdvantageFramework.Database.Entities.Cycle)) As Object

            LoadGridViewDataSourceView = (From Cycle In Cycles
                                          Select New With {.Code = Cycle.Code,
                                                           .Name = Cycle.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Banks As IEnumerable(Of AdvantageFramework.Database.Entities.Bank)) As Object

            LoadGridViewDataSourceView = (From Bank In Banks
                                          Select New With {.Code = Bank.Code,
                                                           .Description = Bank.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal JobServiceFees As IEnumerable(Of AdvantageFramework.Database.Entities.JobServiceFee)) As Object

            LoadGridViewDataSourceView = (From JobServiceFee In JobServiceFees.ToList
                                          Select New With {.ID = JobServiceFee.ID,
                                                           .Description = JobServiceFee.Description,
                                                           .Start = JobServiceFee.FeeStartDate,
                                                           .End = JobServiceFee.FeeEndDate}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal InternetTypes As IEnumerable(Of AdvantageFramework.Database.Entities.InternetType)) As Object

            LoadGridViewDataSourceView = (From InternetType In InternetTypes.ToList
                                          Select New With {.Code = InternetType.Code,
                                                           .Description = InternetType.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal JobProcesses As IEnumerable(Of AdvantageFramework.Database.Entities.JobProcess)) As Object

            LoadGridViewDataSourceView = (From JobProcess In JobProcesses.ToList
                                          Select New With {.ID = JobProcess.ID,
                                                           .Description = JobProcess.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal DayParts As IEnumerable(Of AdvantageFramework.Database.Entities.Daypart)) As Object

            LoadGridViewDataSourceView = (From DayPart In DayParts
                                          Select New With {.ID = DayPart.ID,
                                                           .Code = DayPart.Code,
                                                           .Description = DayPart.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal JobVersionDatabaseTypes As IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionDatabaseType)) As Object

            LoadGridViewDataSourceView = (From JobVersionDatabaseType In JobVersionDatabaseTypes
                                          Select New With {.ID = JobVersionDatabaseType.ID,
                                                           .Description = JobVersionDatabaseType.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal JobVersionTemplateDetails As IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)) As Object

            LoadGridViewDataSourceView = (From JobVersionTemplateDetail In JobVersionTemplateDetails
                                          Select New With {.ID = JobVersionTemplateDetail.ID,
                                                           .Description = JobVersionTemplateDetail.Label}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal UserDefinedReportCategories As IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory)) As Object

            LoadGridViewDataSourceView = (From UserDefinedReportCategory In UserDefinedReportCategories
                                          Select New With {.ID = UserDefinedReportCategory.ID,
                                                           .Description = UserDefinedReportCategory.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal JobVersionTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplate)) As Object

            LoadGridViewDataSourceView = (From JobVersionTemplate In JobVersionTemplates
                                          Select JobVersionTemplate.Code,
                                                 JobVersionTemplate.Description,
                                                 JobVersionTemplate.IsInactive
                                          Distinct).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                             .Description = Entity.Description,
                                                                                             .IsInactive = CBool(Entity.IsInactive.GetValueOrDefault(0))}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Entities.Client)) As Object

            LoadGridViewDataSourceView = (From Client In Clients
                                          Select New With {.Code = Client.Code,
                                                            .Name = Client.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Core.Client)) As Object

            LoadGridViewDataSourceView = (From Client In Clients
                                          Select New With {.Code = Client.Code,
                                                           .Name = Client.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Entities.Division)) As Object

            LoadGridViewDataSourceView = (From Division In Divisions
                                          Select New With {.Code = Division.Code,
                                                           .Name = Division.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Core.Division)) As Object

            LoadGridViewDataSourceView = (From Division In Divisions
                                          Select New With {.Code = Division.Code,
                                                           .Name = Division.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Views.DivisionView)) As Object

            LoadGridViewDataSourceView = (From Division In Divisions
                                          Select New With {.Code = Division.DivisionCode,
                                                           .Name = Division.DivisionName}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ProductCategories As IEnumerable(Of AdvantageFramework.Database.Entities.ProductCategory)) As Object

            LoadGridViewDataSourceView = (From ProductCategory In ProductCategories
                                          Select New With {.Code = ProductCategory.Code,
                                                           .Description = ProductCategory.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Entities.Product)) As Object

            LoadGridViewDataSourceView = (From Product In Products
                                          Select New With {.Code = Product.Code,
                                                           .Name = Product.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Core.Product)) As Object

            LoadGridViewDataSourceView = (From Product In Products
                                          Select New With {.Code = Product.Code,
                                                           .Name = Product.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Functions As IEnumerable(Of AdvantageFramework.Database.Entities.Function)) As Object

            LoadGridViewDataSourceView = (From [Function] In Functions
                                          Select [Function].Code,
                                                 [Function].Type,
                                                 [Function].Description).ToList.Select(Function([Function]) New With {.Code = [Function].Code,
                                                                                                                      .Type = [Function].Type,
                                                                                                                      .Description = [Function].Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Functions As IEnumerable(Of AdvantageFramework.Database.Views.FunctionView)) As Object

            LoadGridViewDataSourceView = (From [Function] In Functions
                                          Select [Function].Code,
                                                 [Function].Type,
                                                 [Function].Description).ToList.Select(Function([Function]) New With {.Code = [Function].Code,
                                                                                                                      .Type = [Function].Type,
                                                                                                                      .Description = [Function].Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Functions As IEnumerable(Of AdvantageFramework.Database.Core.Function)) As Object

            LoadGridViewDataSourceView = (From [Function] In Functions
                                          Select New With {.Code = [Function].Code,
                                                           .Type = [Function].Type,
                                                           .Description = [Function].Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Entities.Job)) As Object

            LoadGridViewDataSourceView = (From Job In Jobs
                                          Order By Job.Number Descending
                                          Select New With {.Number = Job.Number,
                                                           .Description = Job.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceAlternateView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Entities.Job)) As Object

            LoadGridViewDataSourceAlternateView = (From Job In Jobs
                                                   Order By Job.Number Descending
                                                   Select New With {.Number = Job.Number,
                                                                    .Description = Job.Description,
                                                                    .Client = Job.ClientCode,
                                                                    .Division = Job.DivisionCode,
                                                                    .Product = Job.ProductCode}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Core.Job)) As Object

            LoadGridViewDataSourceView = (From Job In Jobs
                                          Order By Job.Number Descending
                                          Select New With {.Number = Job.Number,
                                                           .Description = Job.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Views.JobView)) As Object

            Try

                LoadGridViewDataSourceView = (From Job In Jobs
                                              Order By Job.JobNumber Descending
                                              Select New With {.Number = Job.JobNumber,
                                                               .Description = Job.JobDescription}).ToList

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Private Function LoadGridViewDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)) As Object

            LoadGridViewDataSourceView = (From JobComponent In JobComponents
                                          Order By JobComponent.JobNumber Descending,
                                                   JobComponent.Number Ascending
                                          Select New With {.Number = JobComponent.Number,
                                                           .Description = JobComponent.Description,
                                                           .ID = JobComponent.ID,
                                                           .JobNumber = JobComponent.JobNumber}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)) As Object

            LoadGridViewDataSourceView = (From JobComponent In JobComponents
                                          Order By JobComponent.JobNumber Descending,
                                                   JobComponent.Number Ascending
                                          Select New With {.Number = JobComponent.Number,
                                                           .Description = JobComponent.Description,
                                                           .ID = JobComponent.ID,
                                                           .JobNumber = JobComponent.JobNumber}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)) As Object

            Try

                LoadGridViewDataSourceView = (From JobComponent In JobComponents
                                              Order By JobComponent.JobNumber Descending,
                                                   JobComponent.JobComponentNumber Ascending
                                              Select New With {.Number = JobComponent.JobComponentNumber,
                                                           .Description = JobComponent.JobComponentDescription,
                                                           .ID = JobComponent.ID,
                                                           .JobNumber = JobComponent.JobNumber}).ToList

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Private Function LoadGridViewDataSourceView(ByVal SalesTaxes As IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax)) As Object

            LoadGridViewDataSourceView = (From SalesTax In SalesTaxes
                                          Select New With {.TaxCode = SalesTax.TaxCode,
                                                           .Description = SalesTax.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)) As Object

            LoadGridViewDataSourceView = (From GeneralLedgerAccount In GeneralLedgerAccounts
                                          Select New With {.Code = GeneralLedgerAccount.Code,
                                                           .Description = GeneralLedgerAccount.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Entities.Office)) As Object

            LoadGridViewDataSourceView = (From Office In Offices
                                          Select New With {.Code = Office.Code,
                                                           .Name = Office.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal PurchaseOrders As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrder)) As Object

            LoadGridViewDataSourceView = (From PurchaseOrder In PurchaseOrders
                                          Select PurchaseOrder.Number,
                                                 PurchaseOrder.Description,
                                                 PurchaseOrder.Date,
                                                 PurchaseOrder.DueDate,
                                                 PurchaseOrder.ApprovalFlag,
                                                 PurchaseOrder.IsWorkComplete).ToList.Select(Function(PurchaseOrder) New With {.Number = PurchaseOrder.Number,
                                                                                                                               .Description = PurchaseOrder.Description,
                                                                                                                               .Date = If(PurchaseOrder.Date IsNot Nothing, CDate(PurchaseOrder.Date).ToShortDateString, ""),
                                                                                                                               .DueDate = If(PurchaseOrder.DueDate IsNot Nothing, CDate(PurchaseOrder.DueDate).ToShortDateString, ""),
                                                                                                                               .POTotal = 0,
                                                                                                                               .POBalance = 0,
                                                                                                                               .Status = If(PurchaseOrder.ApprovalFlag Is Nothing, "[None]", If(PurchaseOrder.ApprovalFlag = 1, "Pending", "Approved")),
                                                                                                                               .WorkComplete = If(PurchaseOrder.IsWorkComplete Is Nothing, "No", If(PurchaseOrder.IsWorkComplete = 1, "Yes", "No"))}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal PurchaseOrderDetails As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail)) As Object

            LoadGridViewDataSourceView = (From PurchaseOrderDetail In PurchaseOrderDetails
                                          Select New With {.LineNumber = PurchaseOrderDetail.LineNumber,
                                                           .LineDescription = PurchaseOrderDetail.LineDescription}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Locations As IEnumerable(Of AdvantageFramework.Database.Entities.Location)) As Object

            LoadGridViewDataSourceView = (From Location In Locations.ToList
                                          Select [ID] = Location.ID,
                                                 [Name] = Location.Name).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ManagementLevels As IEnumerable(Of AdvantageFramework.Database.Entities.ManagementLevel)) As Object

            LoadGridViewDataSourceView = (From ManagementLevel In ManagementLevels
                                          Select New With {.ID = ManagementLevel.ID,
                                                           .Description = ManagementLevel.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AdSizes As IEnumerable(Of AdvantageFramework.Database.Entities.AdSize)) As Object

            LoadGridViewDataSourceView = (From AdSize In AdSizes
                                          Select New With {.Code = AdSize.Code,
                                                           .Description = AdSize.Description,
                                                           .ID = AdSize.AdServerSizeID}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal PTORules As IEnumerable(Of AdvantageFramework.Database.Entities.PTORule)) As Object

            LoadGridViewDataSourceView = (From PTORule In PTORules
                                          Select New With {.ID = PTORule.ID,
                                                           .Name = PTORule.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Statii As IEnumerable(Of AdvantageFramework.Database.Entities.Status)) As Object

            LoadGridViewDataSourceView = (From Status In Statii
                                          Select New With {.Code = Status.Code,
                                                           .Description = Status.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal WebsiteTypes As IEnumerable(Of AdvantageFramework.Database.Entities.WebsiteType)) As Object

            LoadGridViewDataSourceView = (From WebsiteType In WebsiteTypes
                                          Select New With {.Code = WebsiteType.Code,
                                                           .Description = WebsiteType.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal EmployeeTitles As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle)) As Object

            LoadGridViewDataSourceView = (From EmployeeTitle In EmployeeTitles
                                          Select New With {.ID = EmployeeTitle.ID,
                                                           .Description = EmployeeTitle.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Tasks As IEnumerable(Of AdvantageFramework.Database.Entities.Task)) As Object

            LoadGridViewDataSourceView = (From Task In Tasks
                                          Select New With {.Code = Task.Code,
                                                           .Description = Task.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Phases As IEnumerable(Of AdvantageFramework.Database.Entities.Phase)) As Object

            LoadGridViewDataSourceView = (From Phase In Phases
                                          Select New With {.ID = Phase.ID,
                                                           .Description = Phase.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee)) As Object

            LoadGridViewDataSourceView = (From Employee In Employees
                                          Select New With {Employee.Code,
                                                           Employee.FirstName,
                                                           Employee.MiddleInitial,
                                                           Employee.LastName,
                                                           Employee.Office,
                                                           Employee.DepartmentTeam}).Select(Function(Entity) New With {.[Code] = Entity.Code,
                                                                                                                       .[Name] = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "",
                                                                                                                                    Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName,
                                                                                                                                    Entity.FirstName & " " & Entity.LastName),
                                                                                                                        .OfficeCode = If(Entity.Office IsNot Nothing, Entity.Office.Code, ""),
                                                                                                                        .OfficeName = If(Entity.Office IsNot Nothing, Entity.Office.Name, ""),
                                                                                                                        .DepartmentCode = If(Entity.DepartmentTeam IsNot Nothing, Entity.DepartmentTeam.Code, ""),
                                                                                                                        .DepartmentName = If(Entity.DepartmentTeam IsNot Nothing, Entity.DepartmentTeam.Description, "")}).ToList


        End Function
        Private Function LoadGridViewDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Core.Employee)) As Object

            LoadGridViewDataSourceView = (From Employee In Employees
                                          Select Employee.Code,
                                                 Employee.FirstName,
                                                 Employee.MiddleInitial,
                                                 Employee.LastName).ToList.Select(Function(Entity) New With {.[Code] = Entity.Code,
                                                                                                             .[Name] = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName)}).ToList


        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountPayableAvailableMagazineOrders As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders)) As Object

            LoadGridViewDataSourceView = (From AccountPayableAvailableMagazineOrder In AccountPayableAvailableMagazineOrders
                                          Select AccountPayableAvailableMagazineOrder.VendorCode,
                                                 AccountPayableAvailableMagazineOrder.ClientCode,
                                                 AccountPayableAvailableMagazineOrder.DivisionCode,
                                                 AccountPayableAvailableMagazineOrder.ProductCode,
                                                 AccountPayableAvailableMagazineOrder.OrderNumber,
                                                 AccountPayableAvailableMagazineOrder.LineNumber,
                                                 AccountPayableAvailableMagazineOrder.InsertDate,
                                                 AccountPayableAvailableMagazineOrder.OrderDescription,
                                                 AccountPayableAvailableMagazineOrder.LinkID,
                                                 AccountPayableAvailableMagazineOrder.ClientPO,
                                                 AccountPayableAvailableMagazineOrder.MarketCode).ToList.Select(Function(Entity) New With {.VendorCode = Entity.VendorCode,
                                                                                                                                           .ClientCode = Entity.ClientCode,
                                                                                                                                           .DivisionCode = Entity.DivisionCode,
                                                                                                                                           .ProductCode = Entity.ProductCode,
                                                                                                                                           .OrderNumber = Entity.OrderNumber,
                                                                                                                                           .InsertDate = Entity.InsertDate,
                                                                                                                                           .OrderDescription = Entity.OrderDescription,
                                                                                                                                           .LinkID = Entity.LinkID,
                                                                                                                                           .ClientPO = Entity.ClientPO,
                                                                                                                                           .MarketCode = Entity.MarketCode}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal MagazineDetails As IEnumerable(Of AdvantageFramework.Database.Views.MagazineDetail)) As Object

            LoadGridViewDataSourceView = (From MagazineDetail In MagazineDetails
                                          Select MagazineDetail.LineNumber,
                                                 MagazineDetail.InsertDate,
                                                 MagazineDetail.Headline).ToList.Select(Function(Entity) New With {.LineNumber = Entity.LineNumber,
                                                                                                                   .InsertDate = Entity.InsertDate,
                                                                                                                   .Headline = Entity.Headline}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountPayableAvailableNewspaperOrders As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders)) As Object

            LoadGridViewDataSourceView = (From AccountPayableAvailableNewspaperOrder In AccountPayableAvailableNewspaperOrders
                                          Select AccountPayableAvailableNewspaperOrder.VendorCode,
                                                 AccountPayableAvailableNewspaperOrder.ClientCode,
                                                 AccountPayableAvailableNewspaperOrder.DivisionCode,
                                                 AccountPayableAvailableNewspaperOrder.ProductCode,
                                                 AccountPayableAvailableNewspaperOrder.OrderNumber,
                                                 AccountPayableAvailableNewspaperOrder.LineNumber,
                                                 AccountPayableAvailableNewspaperOrder.InsertDate,
                                                 AccountPayableAvailableNewspaperOrder.OrderDescription,
                                                 AccountPayableAvailableNewspaperOrder.LinkID,
                                                 AccountPayableAvailableNewspaperOrder.ClientPO).ToList.Select(Function(Entity) New With {.VendorCode = Entity.VendorCode,
                                                                                                                                          .ClientCode = Entity.ClientCode,
                                                                                                                                          .DivisionCode = Entity.DivisionCode,
                                                                                                                                          .ProductCode = Entity.ProductCode,
                                                                                                                                          .OrderNumber = Entity.OrderNumber,
                                                                                                                                          .InsertDate = Entity.InsertDate,
                                                                                                                                          .OrderDescription = Entity.OrderDescription,
                                                                                                                                          .LinkID = Entity.LinkID,
                                                                                                                                          .ClientPO = Entity.ClientPO}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal NewspaperDetails As IEnumerable(Of AdvantageFramework.Database.Views.NewspaperDetail)) As Object

            LoadGridViewDataSourceView = (From NewspaperDetail In NewspaperDetails
                                          Select NewspaperDetail.LineNumber,
                                                 NewspaperDetail.InsertDate,
                                                 NewspaperDetail.Headline).ToList.Select(Function(Entity) New With {.LineNumber = Entity.LineNumber,
                                                                                                                    .InsertDate = Entity.InsertDate,
                                                                                                                    .Headline = Entity.Headline}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ProductViews As IEnumerable(Of AdvantageFramework.Database.Views.ProductView)) As Object

            LoadGridViewDataSourceView = (From ProductView In ProductViews.ToList
                                          Select [Code] = ProductView.ProductCode,
                                                 [Name] = ProductView.ProductDescription).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountPayableAvailableInternetOrders As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders)) As Object

            LoadGridViewDataSourceView = (From AccountPayableAvailableInternetOrder In AccountPayableAvailableInternetOrders
                                          Select AccountPayableAvailableInternetOrder.VendorCode,
                                                 AccountPayableAvailableInternetOrder.ClientCode,
                                                 AccountPayableAvailableInternetOrder.DivisionCode,
                                                 AccountPayableAvailableInternetOrder.ProductCode,
                                                 AccountPayableAvailableInternetOrder.OrderNumber,
                                                 AccountPayableAvailableInternetOrder.LineNumber,
                                                 AccountPayableAvailableInternetOrder.InsertDate,
                                                 AccountPayableAvailableInternetOrder.OrderDescription,
                                                 AccountPayableAvailableInternetOrder.LinkID,
                                                 AccountPayableAvailableInternetOrder.ClientPO,
                                                 AccountPayableAvailableInternetOrder.Type).ToList.Select(Function(Entity) New With {.VendorCode = Entity.VendorCode,
                                                                                                                                     .ClientCode = Entity.ClientCode,
                                                                                                                                     .DivisionCode = Entity.DivisionCode,
                                                                                                                                     .ProductCode = Entity.ProductCode,
                                                                                                                                     .OrderNumber = Entity.OrderNumber,
                                                                                                                                     .InsertDate = Entity.InsertDate,
                                                                                                                                     .OrderDescription = Entity.OrderDescription,
                                                                                                                                     .LinkID = Entity.LinkID,
                                                                                                                                     .ClientPO = Entity.ClientPO,
                                                                                                                                     .Type = Entity.type}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal InternetOrderDetails As IEnumerable(Of AdvantageFramework.Database.Entities.InternetOrderDetail)) As Object

            LoadGridViewDataSourceView = (From InternetOrderDetail In InternetOrderDetails
                                          Select InternetOrderDetail.LineNumber,
                                                 [InsertDate] = InternetOrderDetail.StartDate,
                                                 InternetOrderDetail.Headline).ToList.Select(Function(Entity) New With {.LineNumber = Entity.LineNumber,
                                                                                                                        .InsertDate = Entity.InsertDate,
                                                                                                                        .Headline = Entity.Headline}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountPayableAvailableOutOfHomeOrders As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders)) As Object

            LoadGridViewDataSourceView = (From AccountPayableAvailableOutOfHomeOrder In AccountPayableAvailableOutOfHomeOrders
                                          Select AccountPayableAvailableOutOfHomeOrder.VendorCode,
                                                 AccountPayableAvailableOutOfHomeOrder.ClientCode,
                                                 AccountPayableAvailableOutOfHomeOrder.DivisionCode,
                                                 AccountPayableAvailableOutOfHomeOrder.ProductCode,
                                                 AccountPayableAvailableOutOfHomeOrder.OrderNumber,
                                                 AccountPayableAvailableOutOfHomeOrder.LineNumber,
                                                 AccountPayableAvailableOutOfHomeOrder.InsertDate,
                                                 AccountPayableAvailableOutOfHomeOrder.OrderDescription,
                                                 AccountPayableAvailableOutOfHomeOrder.LinkID,
                                                 AccountPayableAvailableOutOfHomeOrder.ClientPO,
                                                 AccountPayableAvailableOutOfHomeOrder.Type).ToList.Select(Function(Entity) New With {.VendorCode = Entity.VendorCode,
                                                                                                                                      .ClientCode = Entity.ClientCode,
                                                                                                                                      .DivisionCode = Entity.DivisionCode,
                                                                                                                                      .ProductCode = Entity.ProductCode,
                                                                                                                                      .OrderNumber = Entity.OrderNumber,
                                                                                                                                      .InsertDate = Entity.InsertDate,
                                                                                                                                      .OrderDescription = Entity.OrderDescription,
                                                                                                                                      .LinkID = Entity.LinkID,
                                                                                                                                      .ClientPO = Entity.ClientPO,
                                                                                                                                      .Type = Entity.Type}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal OutOfHomeOrderDetails As IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeOrderDetail)) As Object

            LoadGridViewDataSourceView = (From OutOfHomeOrderDetail In OutOfHomeOrderDetails
                                          Select OutOfHomeOrderDetail.LineNumber,
                                                 [InsertDate] = OutOfHomeOrderDetail.PostDate,
                                                 OutOfHomeOrderDetail.Headline).ToList.Select(Function(Entity) New With {.LineNumber = Entity.LineNumber,
                                                                                                                         .InsertDate = Entity.InsertDate,
                                                                                                                         .Headline = Entity.Headline}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountPayableAvailableRadioOrders As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders)) As Object

            LoadGridViewDataSourceView = (From AccountPayableAvailableRadioOrder In AccountPayableAvailableRadioOrders
                                          Select AccountPayableAvailableRadioOrder.VendorCode,
                                                 AccountPayableAvailableRadioOrder.ClientCode,
                                                 AccountPayableAvailableRadioOrder.DivisionCode,
                                                 AccountPayableAvailableRadioOrder.ProductCode,
                                                 AccountPayableAvailableRadioOrder.OrderNumber,
                                                 AccountPayableAvailableRadioOrder.Description,
                                                 AccountPayableAvailableRadioOrder.LinkID,
                                                 AccountPayableAvailableRadioOrder.ClientPO,
                                                 AccountPayableAvailableRadioOrder.MarketCode,
                                                 AccountPayableAvailableRadioOrder.LineNumber,
                                                 AccountPayableAvailableRadioOrder.Month,
                                                 AccountPayableAvailableRadioOrder.Year,
                                                 AccountPayableAvailableRadioOrder.StartDate,
                                                 AccountPayableAvailableRadioOrder.EndDate,
                                                 AccountPayableAvailableRadioOrder.Quantity,
                                                 AccountPayableAvailableRadioOrder.GrossRate).ToList.Select(Function(Entity) New With {.VendorCode = Entity.VendorCode,
                                                                                                                                       .ClientCode = Entity.ClientCode,
                                                                                                                                       .DivisionCode = Entity.DivisionCode,
                                                                                                                                       .ProductCode = Entity.ProductCode,
                                                                                                                                       .OrderNumber = Entity.OrderNumber,
                                                                                                                                       .Description = Entity.Description,
                                                                                                                                       .LinkID = Entity.LinkID,
                                                                                                                                       .ClientPO = Entity.ClientPO,
                                                                                                                                       .MarketCode = Entity.MarketCode,
                                                                                                                                       .LineNumber = Entity.LineNumber,
                                                                                                                                       .Month = Entity.Month,
                                                                                                                                       .Year = Entity.Year,
                                                                                                                                       .StartDate = Entity.StartDate,
                                                                                                                                       .EndDate = Entity.EndDate,
                                                                                                                                       .Quantity = Entity.Quantity,
                                                                                                                                       .GrossRate = Entity.GrossRate}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal RadioOrderDetails As IEnumerable(Of AdvantageFramework.Database.Entities.RadioOrderDetail)) As Object

            LoadGridViewDataSourceView = (From RadioOrderDetail In RadioOrderDetails
                                          Select RadioOrderDetail.LineNumber,
                                                 [Month] = MonthName(RadioOrderDetail.MonthNumber, True).ToUpper,
                                                 [Year] = RadioOrderDetail.YearNumber,
                                                 [StartDate] = RadioOrderDetail.StartDate,
                                                 [EndDate] = RadioOrderDetail.EndDate,
                                                 [Quantity] = RadioOrderDetail.TotalSpots,
                                                 [GrossRate] = RadioOrderDetail.GrossRate,
                                                 [NetRate] = RadioOrderDetail.NetRate,
                                                 [Length] = RadioOrderDetail.Length,
                                                 RadioOrderDetail.Programming,
                                                 RadioOrderDetail.StartTime,
                                                 RadioOrderDetail.EndTime).ToList.Select(Function(Entity) New With {.LineNumber = Entity.LineNumber,
                                                                                                                        .Month = Entity.Month,
                                                                                                                        .Year = Entity.Year,
                                                                                                                        .StartDate = Entity.StartDate,
                                                                                                                        .EndDate = Entity.EndDate,
                                                                                                                        .Quantity = Entity.Quantity,
                                                                                                                        .GrossRate = Entity.GrossRate,
                                                                                                                        .NetRate = Entity.NetRate,
                                                                                                                        .Length = Entity.Length,
                                                                                                                        .Programming = Entity.Programming,
                                                                                                                        .StartTime = Entity.StartTime,
                                                                                                                        .EndTime = Entity.EndTime}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Ratings As IEnumerable(Of AdvantageFramework.Database.Entities.Rating)) As Object

            LoadGridViewDataSourceView = (From Rating In Ratings
                                          Select Rating.ID,
                                                 Rating.Description) _
                                          .Select(Function(Entity) New With {.ID = Entity.ID,
                                                                             .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Partners As IEnumerable(Of AdvantageFramework.Database.Entities.Partner)) As Object

            LoadGridViewDataSourceView = (From Partner In Partners
                                          Select New With {.Code = Partner.Code,
                                                           .Partner = Partner.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountPayableGLPurchaseOrders As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLPurchaseOrders)) As Object

            LoadGridViewDataSourceView = (From AccountPayableGLPurchaseOrder In AccountPayableGLPurchaseOrders
                                          Select AccountPayableGLPurchaseOrder.Number,
                                                 AccountPayableGLPurchaseOrder.Description,
                                                 AccountPayableGLPurchaseOrder.Date,
                                                 AccountPayableGLPurchaseOrder.DueDate,
                                                 AccountPayableGLPurchaseOrder.Status,
                                                 AccountPayableGLPurchaseOrder.POTotal,
                                                 AccountPayableGLPurchaseOrder.POBalance,
                                                 AccountPayableGLPurchaseOrder.WorkComplete).ToList.Select(Function(Entity) New With {.Number = Entity.Number,
                                                                                                                                      .Description = Entity.Description,
                                                                                                                                      .Date = Entity.Date,
                                                                                                                                      .DueDate = Entity.DueDate,
                                                                                                                                      .Status = Entity.Status,
                                                                                                                                      .POTotal = Entity.POTotal,
                                                                                                                                      .POBalance = Entity.POBalance,
                                                                                                                                      .WorkComplete = Entity.WorkComplete}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountPayableProductionPurchaseOrders As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders)) As Object

            LoadGridViewDataSourceView = (From AccountPayableProductionPurchaseOrder In AccountPayableProductionPurchaseOrders
                                          Select AccountPayableProductionPurchaseOrder.Number,
                                                 AccountPayableProductionPurchaseOrder.Description,
                                                 AccountPayableProductionPurchaseOrder.Date,
                                                 AccountPayableProductionPurchaseOrder.DueDate,
                                                 AccountPayableProductionPurchaseOrder.Status,
                                                 AccountPayableProductionPurchaseOrder.POTotal,
                                                 AccountPayableProductionPurchaseOrder.POBalance,
                                                 AccountPayableProductionPurchaseOrder.WorkComplete,
                                                 AccountPayableProductionPurchaseOrder.POComplete).ToList.Select(Function(Entity) New With {.Number = Entity.Number,
                                                                                                                                              .Description = Entity.Description,
                                                                                                                                              .Date = Entity.Date,
                                                                                                                                              .DueDate = Entity.DueDate,
                                                                                                                                              .Status = Entity.Status,
                                                                                                                                              .POTotal = Entity.POTotal,
                                                                                                                                              .POBalance = Entity.POBalance,
                                                                                                                                              .WorkComplete = Entity.WorkComplete,
                                                                                                                                              .POComplete = Entity.POComplete}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Classes.Employee)) As Object

            LoadGridViewDataSourceView = (From Employee In Employees.ToList
                                          Select [Code] = Employee.Code,
                                                 [Name] = Employee.Name,
                                                 [Terminated] = Employee.Terminated).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountPayableAvailableTVOrders As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders)) As Object

            LoadGridViewDataSourceView = (From AccountPayableAvailableTVOrder In AccountPayableAvailableTVOrders
                                          Select AccountPayableAvailableTVOrder.VendorCode,
                                                 AccountPayableAvailableTVOrder.ClientCode,
                                                 AccountPayableAvailableTVOrder.DivisionCode,
                                                 AccountPayableAvailableTVOrder.ProductCode,
                                                 AccountPayableAvailableTVOrder.OrderNumber,
                                                 AccountPayableAvailableTVOrder.Description,
                                                 AccountPayableAvailableTVOrder.LinkID,
                                                 AccountPayableAvailableTVOrder.ClientPO,
                                                 AccountPayableAvailableTVOrder.MarketCode,
                                                 AccountPayableAvailableTVOrder.LineNumber,
                                                 AccountPayableAvailableTVOrder.NetworkID,
                                                 AccountPayableAvailableTVOrder.Month,
                                                 AccountPayableAvailableTVOrder.Year,
                                                 AccountPayableAvailableTVOrder.StartDate,
                                                 AccountPayableAvailableTVOrder.EndDate,
                                                 AccountPayableAvailableTVOrder.Quantity,
                                                 AccountPayableAvailableTVOrder.GrossRate).ToList.Select(Function(Entity) New With {.VendorCode = Entity.VendorCode,
                                                                                                                                    .ClientCode = Entity.ClientCode,
                                                                                                                                    .DivisionCode = Entity.DivisionCode,
                                                                                                                                    .ProductCode = Entity.ProductCode,
                                                                                                                                    .OrderNumber = Entity.OrderNumber,
                                                                                                                                    .Description = Entity.Description,
                                                                                                                                    .LinkID = Entity.LinkID,
                                                                                                                                    .ClientPO = Entity.ClientPO,
                                                                                                                                    .MarketCode = Entity.MarketCode,
                                                                                                                                    .LineNumber = Entity.LineNumber,
                                                                                                                                    .NetworkID = Entity.NetworkID,
                                                                                                                                    .Month = Entity.Month,
                                                                                                                                    .Year = Entity.Year,
                                                                                                                                    .StartDate = Entity.StartDate,
                                                                                                                                    .EndDate = Entity.EndDate,
                                                                                                                                    .Quantity = Entity.Quantity,
                                                                                                                                    .GrossRate = Entity.GrossRate}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Accounts As IEnumerable(Of AdvantageFramework.Database.Entities.Account)) As Object

            LoadGridViewDataSourceView = (From Account In Accounts
                                          Select New With {.Number = Account.Number,
                                                           .Description = Account.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal TVOrderDetails As IEnumerable(Of AdvantageFramework.Database.Entities.TVOrderDetail)) As Object

            LoadGridViewDataSourceView = (From TVOrderDetail In TVOrderDetails
                                          Select TVOrderDetail.LineNumber,
                                                 [Month] = MonthName(TVOrderDetail.MonthNumber, True).ToUpper,
                                                 [Year] = TVOrderDetail.YearNumber,
                                                 [StartDate] = TVOrderDetail.StartDate,
                                                 [EndDate] = TVOrderDetail.EndDate,
                                                 [Quantity] = TVOrderDetail.TotalSpots,
                                                 [GrossRate] = TVOrderDetail.GrossRate,
                                                 [NetRate] = TVOrderDetail.NetRate,
                                                 [Length] = TVOrderDetail.Length,
                                                 TVOrderDetail.Programming,
                                                 TVOrderDetail.NetworkID,
                                                 TVOrderDetail.StartTime,
                                                 TVOrderDetail.EndTime).ToList.Select(Function(Entity) New With {.LineNumber = Entity.LineNumber,
                                                                                                                   .NetworkID = Entity.NetworkID,
                                                                                                                   .Month = Entity.Month,
                                                                                                                   .Year = Entity.Year,
                                                                                                                   .StartDate = Entity.StartDate,
                                                                                                                   .EndDate = Entity.EndDate,
                                                                                                                   .Quantity = Entity.Quantity,
                                                                                                                   .GrossRate = Entity.GrossRate,
                                                                                                                   .NetRate = Entity.NetRate,
                                                                                                                   .Length = Entity.Length,
                                                                                                                   .Programming = Entity.Programming,
                                                                                                                   .StartTime = Entity.StartTime,
                                                                                                                   .EndTime = Entity.EndTime}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Affiliations As IEnumerable(Of AdvantageFramework.Database.Entities.Affiliation)) As Object

            LoadGridViewDataSourceView = (From Affiliation In Affiliations
                                          Select Affiliation.ID,
                                                 Affiliation.Description).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                   .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal DaypartTypes As IEnumerable(Of AdvantageFramework.Database.Entities.DaypartType)) As Object

            LoadGridViewDataSourceView = (From DaypartType In DaypartTypes
                                          Select New With {.ID = DaypartType.ID,
                                                           .Description = DaypartType.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Competitions As IEnumerable(Of AdvantageFramework.Database.Entities.Competition)) As Object

            LoadGridViewDataSourceView = (From Competition In Competitions
                                          Select Competition.ID,
                                                 Competition.Description).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                   .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Blackplates As IEnumerable(Of AdvantageFramework.Database.Entities.Blackplate)) As Object

            LoadGridViewDataSourceView = (From Blackplate In Blackplates
                                          Select Blackplate.Code,
                                                 Blackplate.Description).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                  .Description = Entity.Description,
                                                                                                                  .CodeAndDescription = Entity.Code & " - " & Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal TimeCategoryTypes As IEnumerable(Of AdvantageFramework.Database.Entities.TimeCategoryType)) As Object

            LoadGridViewDataSourceView = (From TimeCategoryType In TimeCategoryTypes
                                          Select TimeCategoryType.ID,
                                                 TimeCategoryType.Description).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                        .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal IndirectCategories As IEnumerable(Of AdvantageFramework.Database.Entities.IndirectCategory)) As Object

            LoadGridViewDataSourceView = (From IndirectCategory In IndirectCategories.ToList
                                          Select New With {.[Code] = IndirectCategory.Code,
                                                           .[Description] = IndirectCategory.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal InvoiceCategories As IEnumerable(Of AdvantageFramework.Database.Entities.InvoiceCategory)) As Object

            LoadGridViewDataSourceView = (From InvoiceCategory In InvoiceCategories.ToList
                                          Select New With {.[Code] = InvoiceCategory.Code,
                                                           .[Description] = InvoiceCategory.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountPayables As IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayable)) As Object

            LoadGridViewDataSourceView = (From AccountPayable In AccountPayables.ToList
                                          Select [InvoiceNumber] = AccountPayable.InvoiceNumber,
                                                 [InvoiceDate] = AccountPayable.InvoiceDate,
                                                 [Description] = AccountPayable.InvoiceDescription,
                                                 [IsDeleted] = CBool(AccountPayable.Deleted.GetValueOrDefault(0))).OrderByDescending(Function(ap) ap.InvoiceDate).ThenByDescending(Function(ap) ap.InvoiceNumber).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AccountReceivables As IEnumerable(Of AdvantageFramework.Database.Entities.AccountReceivable)) As Object

            LoadGridViewDataSourceView = (From AccountReceivable In AccountReceivables
                                          Select New With {.InvoiceNumber = AccountReceivable.InvoiceNumber,
                                                           .SequenceNumber = AccountReceivable.SequenceNumber,
                                                           .Type = AccountReceivable.Type,
                                                           .ClientCode = AccountReceivable.ClientCode,
                                                           .ClientName = AccountReceivable.Client.Name,
                                                           .InvoiceDate = AccountReceivable.InvoiceDate,
                                                           .InvoiceNumberSequenceNumber = CStr(AccountReceivable.InvoiceNumber) & "|" & CStr(AccountReceivable.SequenceNumber)}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal MediaPlans As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan)) As Object

            LoadGridViewDataSourceView = (From MediaPlan In MediaPlans.ToList
                                          Select New With {.[ID] = MediaPlan.ID,
                                                   .[Description] = MediaPlan.Description,
                                                   .[Client] = MediaPlan.Client.ToString,
                                                   .[StartDate] = MediaPlan.StartDate.ToShortDateString,
                                                   .[EndDate] = MediaPlan.EndDate.ToShortDateString,
                                                   .[IsApproved] = MediaPlan.MediaPlanDetails.Where(Function(Detail) Detail.IsApproved = False).Any = False}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal MediaPlanDetails As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetail)) As Object

            'objects
            Dim MediaPlanID As Integer = 0
            Dim MediaPlanDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetail) = Nothing
            Dim FinalMediaPlanDetailsList = Nothing

            If MediaPlanDetails.Count > 0 Then

                For Each MediaPlanID In MediaPlanDetails.Select(Function(Entity) Entity.MediaPlanID).Distinct

                    MediaPlanDetailsList = MediaPlanDetails.Where(Function(Entity) Entity.MediaPlanID = MediaPlanID).OrderBy(Function(Entity) Entity.ID).ToList

                    If FinalMediaPlanDetailsList Is Nothing Then

                        FinalMediaPlanDetailsList = (From MediaPlanDetail In MediaPlanDetailsList
                                                     Select New With {.[ID] = MediaPlanDetail.ID,
                                                                      .[Description] = MediaPlanDetail.Name,
                                                                      .[MediaPlanID] = MediaPlanDetail.MediaPlanID,
                                                                      .[SalesClass] = If(MediaPlanDetail.SalesClass IsNot Nothing, MediaPlanDetail.SalesClass.ToString, Nothing)}).ToList

                    Else

                        FinalMediaPlanDetailsList.AddRange((From MediaPlanDetail In MediaPlanDetailsList
                                                            Select New With {.[ID] = MediaPlanDetail.ID,
                                                                             .[Description] = MediaPlanDetail.Name,
                                                                             .[MediaPlanID] = MediaPlanDetail.MediaPlanID,
                                                                             .[SalesClass] = If(MediaPlanDetail.SalesClass IsNot Nothing, MediaPlanDetail.SalesClass.ToString, Nothing)}).ToList)

                    End If

                Next

                LoadGridViewDataSourceView = FinalMediaPlanDetailsList

            Else

                MediaPlanDetailsList = MediaPlanDetails.ToList

                LoadGridViewDataSourceView = (From MediaPlanDetail In MediaPlanDetailsList
                                              Select New With {.[ID] = MediaPlanDetail.ID,
                                                               .[Description] = MediaPlanDetail.Name,
                                                               .[MediaPlanID] = MediaPlanDetail.MediaPlanID,
                                                               .[SalesClass] = If(MediaPlanDetail.SalesClass IsNot Nothing, MediaPlanDetail.SalesClass.ToString, Nothing)}).ToList

            End If

        End Function
        Private Function LoadGridViewDataSourceView(ByVal VendorServiceTaxes As IEnumerable(Of AdvantageFramework.Database.Entities.VendorServiceTax)) As Object

            LoadGridViewDataSourceView = (From VendorServiceTax In VendorServiceTaxes.ToList
                                          Select New With {.[ID] = VendorServiceTax.ID,
                                                           .[CodeAndDescription] = VendorServiceTax.Code & " - " & VendorServiceTax.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal OverheadAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.OverheadAccount)) As Object

            LoadGridViewDataSourceView = (From OverheadAccount In OverheadAccounts.ToList
                                          Select New With {.[Code] = OverheadAccount.Code,
                                                           .[Description] = OverheadAccount.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal CustomInvoices As IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.CustomInvoice)) As Object

            LoadGridViewDataSourceView = (From CustomInvoice In CustomInvoices.ToList
                                          Select New With {.[ID] = CustomInvoice.ID,
                                                           .[Type] = CustomInvoice.Type,
                                                           .[Description] = CustomInvoice.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal EstimateReports As IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.EstimateReport)) As Object

            LoadGridViewDataSourceView = (From EstimateReport In EstimateReports.ToList
                                          Select New With {.[ID] = EstimateReport.ID,
                                                           .[Type] = EstimateReport.EstimateReportType,
                                                           .[Description] = EstimateReport.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal BillingApprovalBatches As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingApprovalBatch)) As Object

            LoadGridViewDataSourceView = (From BillingApprovalBatch In BillingApprovalBatches.ToList
                                          Select New With {.[ID] = BillingApprovalBatch.ID,
                                                           .[Description] = BillingApprovalBatch.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal BillingCoops As IEnumerable(Of AdvantageFramework.Database.Entities.BillingCoop)) As Object

            LoadGridViewDataSourceView = (From BillingCoop In BillingCoops
                                          Select BillingCoop.Code,
                                                 BillingCoop.Description).Distinct.ToList.Select(Function(BillingCoop) New With {.Code = BillingCoop.Code,
                                                                                                                                 .Description = BillingCoop.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ContactTypes As IEnumerable(Of AdvantageFramework.Database.Entities.ContactType)) As Object

            LoadGridViewDataSourceView = (From ContactType In ContactTypes.ToList
                                          Select New With {.[ID] = ContactType.ID,
                                                           .[Description] = ContactType.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientCashReceipts As IEnumerable(Of AdvantageFramework.Database.Entities.ClientCashReceipt)) As Object

            LoadGridViewDataSourceView = (From ClientCashReceipt In ClientCashReceipts.ToList
                                          Select New With {.CheckNumber = ClientCashReceipt.CheckNumber,
                                                           .CheckDate = ClientCashReceipt.CheckDate,
                                                           .CheckAmount = ClientCashReceipt.CheckAmount}).OrderByDescending(Function(CR) CR.CheckDate).ThenByDescending(Function(CR) CR.CheckNumber).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Reports As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report)) As Object

            'Check Type needs Name & Number, all others need Name & Code
            LoadGridViewDataSourceView = (From Report In Reports.ToList
                                          Select New With {.[Number] = Report.Number,
                                                           .[Name] = Report.Name,
                                                           .[Code] = Report.Code}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal CashReceiptPaymentTypes As IEnumerable(Of AdvantageFramework.Database.Entities.CashReceiptPaymentType)) As Object

            LoadGridViewDataSourceView = (From CashReceiptPaymentType In CashReceiptPaymentTypes
                                          Select CashReceiptPaymentType.ID,
                                                 CashReceiptPaymentType.Description) _
                                          .Select(Function(Entity) New With {.ID = Entity.ID,
                                                                             .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal OutOfHomeTypes As IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeType)) As Object

            LoadGridViewDataSourceView = (From OutOfHomeType In OutOfHomeTypes.ToList
                                          Select New With {.Code = OutOfHomeType.Code,
                                                           .Description = OutOfHomeType.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal States As IEnumerable(Of AdvantageFramework.Database.Entities.State)) As Object

            LoadGridViewDataSourceView = (From State In States
                                          Select New With {.StateCode = State.StateCode}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientType1s As IEnumerable(Of AdvantageFramework.Database.Entities.ClientType1)) As Object

            LoadGridViewDataSourceView = (From ClientType1 In ClientType1s
                                          Select ClientType1.ID,
                                                 ClientType1.Description) _
                                          .Select(Function(Entity) New With {.ID = Entity.ID,
                                                                             .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientType2s As IEnumerable(Of AdvantageFramework.Database.Entities.ClientType2)) As Object

            LoadGridViewDataSourceView = (From ClientType2 In ClientType2s
                                          Select ClientType2.ID,
                                                 ClientType2.Description) _
                                          .Select(Function(Entity) New With {.ID = Entity.ID,
                                                                             .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientType3s As IEnumerable(Of AdvantageFramework.Database.Entities.ClientType3)) As Object

            LoadGridViewDataSourceView = (From ClientType3 In ClientType3s
                                          Select ClientType3.ID,
                                                 ClientType3.Description) _
                                          .Select(Function(Entity) New With {.ID = Entity.ID,
                                                                             .Description = Entity.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal GeneralLedgerSources As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerSource)) As Object

            LoadGridViewDataSourceView = (From GeneralLedgerSource In GeneralLedgerSources
                                          Select New With {.Code = GeneralLedgerSource.Code,
                                                           .Description = GeneralLedgerSource.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal NielsenStations As IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)) As Object

            LoadGridViewDataSourceView = (From NielsenStation In NielsenStations
                                          Select New With {.Code = NielsenStation.StationCode,
                                                           .Description = NielsenStation.CallLetters,
                                                           .Type = If(NielsenStation.SourceType = "B", "Bcst", "Cbl"),
                                                           .Affiliation = If(NielsenStation.SourceType = "B", NielsenStation.Affiliation, NielsenStation.CableName),
                                                           .Channel = If(NielsenStation.SourceType = "B", NielsenStation.ChannelNum, "")}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientWebsites As IEnumerable(Of AdvantageFramework.Database.Entities.ClientWebsite)) As Object

            LoadGridViewDataSourceView = (From ClientWebsite In ClientWebsites
                                          Select New With {.ID = ClientWebsite.ID,
                                                           .Description = ClientWebsite.WebsiteAddress,
                                                           .WebsiteType = ClientWebsite.WebsiteTypeCode,
                                                           .WebsiteName = ClientWebsite.WebsiteName}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal KeyValuePairs As Dictionary(Of Long, String)) As Object

            LoadGridViewDataSourceView = (From KeyValuePair In KeyValuePairs
                                          Select New With {.ID = KeyValuePair.Key,
                                                           .Description = KeyValuePair.Value}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal BroadcastTypes As IEnumerable(Of AdvantageFramework.Database.Entities.BroadcastType)) As Object

            LoadGridViewDataSourceView = (From BroadcastType In BroadcastTypes
                                          Select New With {.ID = BroadcastType.ID,
                                                           .Description = BroadcastType.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal RatingsServices As IEnumerable(Of AdvantageFramework.Database.Entities.RatingsService)) As Object

            LoadGridViewDataSourceView = (From RatingsService In RatingsServices
                                          Select New With {.ID = RatingsService.ID,
                                                           .Description = RatingsService.Name}).ToList

        End Function
        'Private Function LoadGridViewDataSourceView(ByVal MediaMarketBreaks As IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.MediaMarketBreak)) As Object

        '    LoadGridViewDataSourceView = (From MediaMarketBreak In MediaMarketBreaks
        '                                  Select New With {.ID = MediaMarketBreak.ID,
        '                                                   .Description = MediaMarketBreak.Description}).ToList

        'End Function
        Private Function LoadGridViewDataSourceView(ByVal NielsenRadioReportTypes As IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioReportType)) As Object

            LoadGridViewDataSourceView = (From NielsenRadioReportType In NielsenRadioReportTypes
                                          Select New With {.Code = NielsenRadioReportType.Code,
                                                           .Name = NielsenRadioReportType.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal NielsenRadioPeriods As IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod)) As Object

            LoadGridViewDataSourceView = (From NielsenRadioPeriod In NielsenRadioPeriods
                                          Select New With {.ID = NielsenRadioPeriod.ID,
                                                           .Name = NielsenRadioPeriod.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal NielsenRadioMarkets As IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket)) As Object

            LoadGridViewDataSourceView = (From NielsenRadioMarket In NielsenRadioMarkets
                                          Select New With {.Number = NielsenRadioMarket.Number,
                                                           .Name = NielsenRadioMarket.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal NielsenRadioQualitatives As IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative)) As Object

            LoadGridViewDataSourceView = (From NielsenRadioQualitative In NielsenRadioQualitatives
                                          Select New With {.ID = NielsenRadioQualitative.ID,
                                                           .Name = NielsenRadioQualitative.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal NielsenRadioDayparts As IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart)) As Object

            LoadGridViewDataSourceView = (From NielsenRadioDaypart In NielsenRadioDayparts
                                          Select New With {.ID = NielsenRadioDaypart.ID,
                                                           .Name = NielsenRadioDaypart.Name}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal NielsenRadioStations As IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)) As Object

            LoadGridViewDataSourceView = (From NielsenRadioStation In NielsenRadioStations
                                          Select New With {.ComboID = NielsenRadioStation.ComboID,
                                                           .Name = NielsenRadioStation.Name,
                                                           .Frequency = NielsenRadioStation.Frequency}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal AlertAssignmentTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)) As Object

            LoadGridViewDataSourceView = (From AlertAssignmentTemplate In AlertAssignmentTemplates
                                          Select New With {.ID = AlertAssignmentTemplate.ID,
                                                           .Name = AlertAssignmentTemplate.Name}).ToList

        End Function
		Private Function LoadGridViewDataSourceView(ByVal NCCTVSyscodes As IEnumerable(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)) As Object

			LoadGridViewDataSourceView = (From NCCTVSyscode In NCCTVSyscodes
										  Select New With {.ID = NCCTVSyscode.ID,
														   .Syscode = NCCTVSyscode.Syscode,
														   .Provider = NCCTVSyscode.Provider,
														   .SystemName = NCCTVSyscode.SystemName,
														   .Description = NCCTVSyscode.Description}).ToList

		End Function
        Private Function LoadGridViewDataSourceView(ByVal CableNetworkStations As IEnumerable(Of AdvantageFramework.Database.Entities.CableNetworkStation)) As Object

            LoadGridViewDataSourceView = (From CableNetworkStation In CableNetworkStations
                                          Select New With {.ID = CableNetworkStation.ID,
                                                           .Code = CableNetworkStation.Code,
                                                           .Description = CableNetworkStation.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal ClientDiscounts As IEnumerable(Of AdvantageFramework.Database.Entities.ClientDiscount)) As Object

            LoadGridViewDataSourceView = (From ClientDiscount In ClientDiscounts.ToList
                                          Select New With {.Code = ClientDiscount.Code,
                                                           .Name = ClientDiscount.Name,
                                                           .Percent = FormatPercent(ClientDiscount.Percent)}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal MediaDemographics As IEnumerable(Of AdvantageFramework.Database.Entities.MediaDemographic)) As Object

            LoadGridViewDataSourceView = (From MediaDemographic In MediaDemographics.ToList
                                          Select New With {.ID = MediaDemographic.ID,
                                                           .Description = MediaDemographic.Description}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal MediaDemographics As IEnumerable(Of AdvantageFramework.DTO.Media.MediaDemographic)) As Object

            LoadGridViewDataSourceView = (From MediaDemographic In MediaDemographics.ToList
                                          Select New With {.ID = MediaDemographic.ID,
                                                           .Description = MediaDemographic.Description,
                                                           .Group = MediaDemographic.Group,
                                                           .Category = MediaDemographic.Category}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Stations As IEnumerable(Of AdvantageFramework.DTO.Media.SpotTV.Station)) As Object

            LoadGridViewDataSourceView = (From Station In Stations
                                          Select New With {.ID = Station.ID,
                                                           .Name = Station.CallLetters,
                                                           .Type = Station.Type,
                                                           .Affiliation = Station.Affiliation}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Markets As IEnumerable(Of AdvantageFramework.DTO.Market)) As Object

            LoadGridViewDataSourceView = (From Market In Markets
                                          Select New With {.Code = Market.Code,
                                                           .Description = Market.Description,
                                                           .IsInactive = Market.IsInactive}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Counties As IEnumerable(Of AdvantageFramework.DTO.Media.SpotRadioCounty.County)) As Object

            LoadGridViewDataSourceView = (From County In Counties
                                          Select New With {.CountyCode = County.CountyCode,
                                                           .Name = County.Name,
                                                           .State = County.State,
                                                           .MarketNumber = County.MarketNumber,
                                                           .MarketName = County.MarketName}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Markets As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market)) As Object

            LoadGridViewDataSourceView = (From Market In Markets
                                          Select New With {.Code = Market.Code,
                                                           .Description = Market.Description,
                                                           .Country = Market.Country,
                                                           .StateProvince = Market.StateProvince}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Customers As IEnumerable(Of AdvantageFramework.Quickbooks.Classes.Customer)) As Object

            LoadGridViewDataSourceView = (From Customer In Customers
                                          Select New With {.ID = Customer.Id,
                                                           .DisplayName = Customer.DisplayName}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Quickbooks.Classes.Vendor)) As Object

            LoadGridViewDataSourceView = (From Vendor In Vendors
                                          Select New With {.ID = Vendor.Id,
                                                           .DisplayName = Vendor.DisplayName}).ToList

        End Function
        Private Function LoadGridViewDataSourceView(ByVal CheckRegisters As IEnumerable(Of AdvantageFramework.Database.Entities.CheckRegister)) As Object

            LoadGridViewDataSourceView = (From CheckRegister In CheckRegisters
                                          Select New With {.CheckRunID = CheckRegister.CheckRunID,
                                                           .ExportDate = CheckRegister.ExportDate}).ToList

        End Function
        Public Function LoadGridViewDataSourceView(ByVal Value As Object) As Object

            'objects
            Dim View As Object = Nothing

            If TypeOf Value Is IEnumerable Then

                If TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Client) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Client)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Client) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Client)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Division) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Division)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Division) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Division)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.DivisionView) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.DivisionView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Product) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Product)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Product) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Product)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Function) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Function)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.FunctionView) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.FunctionView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Function) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Function)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Job) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Job)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Job) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Job)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.JobView) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.JobView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.JobComponent) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Office) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Office)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Office) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Office)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrder) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrder)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ManagementLevel) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ManagementLevel)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AdSize) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AdSize)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PTORule) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PTORule)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Status) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Status)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.WebsiteType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.WebsiteType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Task) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Task)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Phase) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Phase)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.Employee) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.Employee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Employee) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Employee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.MagazineDetail) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.MagazineDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Partner) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Partner)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Views.Employee) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Views.Employee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Views.ServerSQLUser) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Views.ServerSQLUser)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplate) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Role) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Role)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ProductSortKey) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ProductSortKey)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DivisionSortKey) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DivisionSortKey)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientSortKey) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientSortKey)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CustomReport) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CustomReport)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CurrencyCode) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CurrencyCode)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Ad) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Ad)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Market) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Market)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.VendorTerm) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.VendorTerm)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ExportSystem) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ExportSystem)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.BillingRateLevel) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.BillingRateLevel)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.User) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.User)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ResourceType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ResourceType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertCategory) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DocumentType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DocumentType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationVendorTab) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationVendorTab)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Campaign) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Campaign)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Campaign) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Campaign)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.CampaignView) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.CampaignView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Daypart) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Daypart)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionDatabaseType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionDatabaseType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DepartmentTeam) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DepartmentTeam)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.FunctionHeading) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.FunctionHeading)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientContact) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientContact)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ServiceFeeType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ServiceFeeType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Cycle) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Cycle)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplate) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobVersionTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.NewspaperDetail) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.NewspaperDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.InternetOrderDetail) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.InternetOrderDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeOrderDetail) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeOrderDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.RadioOrderDetail) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.RadioOrderDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLPurchaseOrders) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLPurchaseOrders)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.TVOrderDetail) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.TVOrderDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Affiliation) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Affiliation)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DaypartType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DaypartType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Competition) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Competition)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Blackplate) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Blackplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.TimeCategoryType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.TimeCategoryType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AccountReceivable) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AccountReceivable)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.VendorContact) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.VendorContact)))

                ElseIf TypeOf Value Is IEnumerable(Of Int16) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of Int16)))

                ElseIf TypeOf Value Is IEnumerable(Of Int32) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of Int32)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetail) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeCategory) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Rating) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Rating)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Industry) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Industry)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Source) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Source)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Specialty) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Specialty)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Location) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Location)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.ProductView) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.ProductView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayable) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayable)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Classes.Employee) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Classes.Employee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Vendor) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Vendor)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.IndirectCategory) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.IndirectCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.InvoiceCategory) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.InvoiceCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Bank) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Bank)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ProductCategory) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ProductCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Account) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Account)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobServiceFee) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobServiceFee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.InternetType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.InternetType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobProcess) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobProcess)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.VendorServiceTax) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.VendorServiceTax)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.OverheadAccount) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.OverheadAccount)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.CustomInvoice) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.CustomInvoice)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingApprovalBatch) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingApprovalBatch)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.BillingCoop) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.BillingCoop)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ContactType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ContactType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientCashReceipt) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientCashReceipt)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.EstimateReport) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Reporting.Database.Entities.EstimateReport)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CashReceiptPaymentType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CashReceiptPaymentType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.OutOfHomeType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.State) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.State)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientType1) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientType1)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientType2) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientType2)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientType3) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientType3)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerSource) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerSource)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientWebsite) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientWebsite)))

                ElseIf TypeOf Value Is Dictionary(Of Long, String) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, Dictionary(Of Long, String)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.BroadcastType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.BroadcastType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.RatingsService) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.RatingsService)))

                    'ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.MediaMarketBreak) Then

                    '    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.MediaMarketBreak)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioReportType) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioReportType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CableNetworkStation) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CableNetworkStation)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientDiscount) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientDiscount)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.MediaDemographic) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.MediaDemographic)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.DTO.Media.MediaDemographic) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.DTO.Media.MediaDemographic)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.DTO.Media.SpotTV.Station) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.DTO.Media.SpotTV.Station)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.DTO.Market) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.DTO.Market)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.DTO.Media.SpotRadioCounty.County) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.DTO.Media.SpotRadioCounty.County)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Quickbooks.Classes.Customer) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Quickbooks.Classes.Customer)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Quickbooks.Classes.Vendor) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Quickbooks.Classes.Vendor)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CheckRegister) Then

                    View = LoadGridViewDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CheckRegister)))

                Else

                    View = Value

                End If

            Else

                View = Value

            End If

            LoadGridViewDataSourceView = View

        End Function
        Public Function LoadGridViewDataSourceAlternateView(ByVal Value As Object) As Object

            'objects
            Dim View As Object = Nothing

            If TypeOf Value Is IEnumerable Then

                If TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Job) Then

                    View = LoadGridViewDataSourceAlternateView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Job)))

                Else

                    View = Value

                End If

            Else

                View = Value

            End If

            LoadGridViewDataSourceAlternateView = View

        End Function

#End Region

#Region "  Repository Items "

        Public Function CreateSubItemGridLookupEdit(ByVal Session As AdvantageFramework.Security.Session,
                                                    ByVal SubItemComboBoxType As Presentation.Controls.SubItemGridLookUpEditControl.Type,
                                                    ByVal FieldName As String, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute,
                                                    ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                    Optional ByVal EnumType As System.Type = Nothing, Optional ByVal AllowExtraComboItems As Boolean = True) As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            Try

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

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
                            PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract) OrElse
                            (PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria) AndAlso
                             FieldName = AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ComboAssignInvoicesBy.ToString) Then

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
                            FieldName = AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.PaymentTypeDescription.ToString) OrElse
                           (PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria) AndAlso
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ProductionAssignInvoicesBy.ToString OrElse
                            FieldName = AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.MediaAssignInvoicesBy.ToString) Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                    ElseIf EntityAttribute IsNot Nothing AndAlso EntityAttribute.IsRequired = False Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.NullValue

                    End If

                    If PropertyDescriptor.ComponentType Is GetType(AdvantageFramework.Database.Entities.OfficeSalesTaxAccount) AndAlso
                            FieldName = AdvantageFramework.Database.Entities.OfficeSalesTaxAccount.Properties.SalesTaxCode.ToString Then

                        SubItemGridLookUpEditControl.IncludeInactive = True

                    End If

					If AdvantageFramework.BaseClasses.Entity.LoadPropertyIsNullable(PropertyDescriptor) = False Then

						SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

					End If

				Else

                    If EntityAttribute IsNot Nothing AndAlso EntityAttribute.IsRequired = False Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.NullValue

                    End If

                End If

                SubItemGridLookUpEditControl.Session = Session
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
        Public Function CreateSubItemNumericInput(ByVal Session As AdvantageFramework.Security.Session,
                                                  ByVal SubItemNumericInputType As Presentation.Controls.SubItemNumericInput.Type,
                                                  ByVal FieldName As String, ByVal FormatString As String, ByVal IsNullable As Boolean,
                                                  ByVal ObjectType As System.Type, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute) As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput

            'objects
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim Scale As Long = 0
            Dim Precision As Long = 0
            Dim LoadedEntityFormat As Boolean = False
            Dim BaseClass As Object = Nothing
            Dim ActualObjectType As System.Type = Nothing

            Try

                SubItemNumericInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput

                SubItemNumericInput.ControlType = SubItemNumericInputType

                If Session IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        'SubItemNumericInput.DbContext = DbContext

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

                    End Using

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

                    If EntityAttribute.UseMinValue AndAlso EntityAttribute.MinValue <> Nothing Then

                        SubItemNumericInput.MinValue = CDec(EntityAttribute.MinValue)

                    End If

                    If EntityAttribute.UseMaxValue AndAlso EntityAttribute.MaxValue <> Nothing Then

                        SubItemNumericInput.MaxValue = CDec(EntityAttribute.MaxValue)

                        If SubItemNumericInputType = SubItemNumericInput.Type.Integer OrElse
                           SubItemNumericInputType = SubItemNumericInput.Type.Long OrElse
                           SubItemNumericInputType = SubItemNumericInput.Type.Short Then

                            SubItemNumericInput.MaxLength = SubItemNumericInput.MaxValue.ToString.Length

                        Else

                            SubItemNumericInput.MaxLength = SubItemNumericInput.MaxValue.ToString.Length + 1

                        End If

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

                ElseIf ObjectType Is GetType(AdvantageFramework.Database.Views.BroadcastOrderDetailView) AndAlso
                        FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.Length.ToString Then

                    SubItemNumericInput.MinValue = 0

                ElseIf ObjectType Is GetType(AdvantageFramework.Database.Views.BroadcastOrderDetailView) AndAlso
                        FieldName = AdvantageFramework.Database.Views.BroadcastOrderDetailView.Properties.GrossRate.ToString Then

                    SubItemNumericInput.MaxLength = 15

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
        Public Function CreateSubItemTextBox(ByVal Session As AdvantageFramework.Security.Session,
                                             ByVal SubItemTextBoxType As Presentation.Controls.SubItemTextBox.Type,
                                             ByVal FieldName As String, ByVal ObjectType As System.Type) As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox


            'objects
            Dim SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox = Nothing
            Dim MaxLength As Long = -1
            Dim RealObjectType As System.Type = Nothing
            Dim BaseClass As Object = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
			Dim MaxLengthAttribute As System.ComponentModel.DataAnnotations.MaxLengthAttribute = Nothing

			Try

				SubItemTextBox = New AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox

				SubItemTextBox.Session = Session
				SubItemTextBox.ControlType = SubItemTextBoxType

				If Session IsNot Nothing Then

					Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

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

                            ElseIf ObjectType Is GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) AndAlso
                                    FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.GeneralLedgerOfficeCrossReferenceCode.ToString Then

                                MaxLength = AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigMaxLengthBySegmentType(Session, Database.Entities.GeneralLedgerConfigSegmentType.Office)

                            ElseIf ObjectType Is GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) AndAlso
                                    FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.BaseCode.ToString Then

                                MaxLength = AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigMaxLengthBySegmentType(Session, Database.Entities.GeneralLedgerConfigSegmentType.Base)

                            ElseIf ObjectType Is GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) AndAlso
                                    FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.DepartmentCode.ToString Then

                                MaxLength = AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigMaxLengthBySegmentType(Session, Database.Entities.GeneralLedgerConfigSegmentType.Department)

                            ElseIf ObjectType Is GetType(AdvantageFramework.GeneralLedger.Classes.ChartOfAccount) AndAlso
                                    FieldName = AdvantageFramework.GeneralLedger.Classes.ChartOfAccount.Properties.OtherCode.ToString Then

                                MaxLength = AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigMaxLengthBySegmentType(Session, Database.Entities.GeneralLedgerConfigSegmentType.Other)

                            ElseIf ObjectType Is GetType(AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference) AndAlso
                                    FieldName = AdvantageFramework.Database.Classes.GeneralLedgerOfficeCrossReference.Properties.Code.ToString Then

                                MaxLength = AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigMaxLengthBySegmentType(Session, Database.Entities.GeneralLedgerConfigSegmentType.Office)

                            ElseIf ObjectType Is GetType(AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference) AndAlso
                                    FieldName = AdvantageFramework.Database.Classes.GeneralLedgerDepartmentTeamCrossReference.Properties.Code.ToString Then

                                MaxLength = AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigMaxLengthBySegmentType(Session, Database.Entities.GeneralLedgerConfigSegmentType.Department)

                            ElseIf ObjectType Is GetType(AdvantageFramework.GeneralLedger.Classes.GLAOtherCode) AndAlso
                                    FieldName = AdvantageFramework.GeneralLedger.Classes.GLAOtherCode.Properties.Code.ToString Then

                                MaxLength = AdvantageFramework.GeneralLedger.GetGeneralLedgerConfigMaxLengthBySegmentType(Session, Database.Entities.GeneralLedgerConfigSegmentType.Other)

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
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorLocation.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetTargetAudience.ToString

                                        MaxLength = 60

                                    Case AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Issue.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperSection.ToString,
                                         AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProductionSize.ToString

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

                            ElseIf RealObjectType Is GetType(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification) AndAlso
                                    FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Program.ToString Then

                                MaxLength = 100

                            Else

                                MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(RealObjectType, FieldName))

                            End If

                        Catch ex As Exception
                            MaxLength = -1
                        End Try

                        If MaxLength <> -1 Then

                            SubItemTextBox.MaxLength = MaxLength

                        End If

                    End Using

                End If

            Catch ex As Exception
                SubItemTextBox = Nothing
            Finally
                CreateSubItemTextBox = SubItemTextBox
            End Try

        End Function
        Public Function CreateSubItemMemoEdit(ByVal Session As AdvantageFramework.Security.Session,
                                              ByVal FieldName As String, ByVal ObjectType As System.Type) As AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit

            Dim SubItemMemoEdit As AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit = Nothing
            Dim MaxLength As Long = -1
            Dim RealObjectType As System.Type = Nothing
            Dim BaseClass As Object = Nothing

            Try

                If Session IsNot Nothing Then

                    SubItemMemoEdit = New AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit
                    SubItemMemoEdit.ShowIcon = False

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

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

                    End Using

                End If

            Catch ex As Exception
                SubItemMemoEdit = Nothing
            Finally
                CreateSubItemMemoEdit = SubItemMemoEdit
            End Try

        End Function
        Public Function CreateSubItemTimeEdit(ByVal SubItemTimeInputType As AdvantageFramework.WinForm.Presentation.Controls.SubItemTimeInput.Type) As AdvantageFramework.WinForm.Presentation.Controls.SubItemTimeInput

            'objects
            Dim SubItemTimeInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemTimeInput = Nothing

            Try

                SubItemTimeInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemTimeInput

                SubItemTimeInput.ControlType = SubItemTimeInputType

                SubItemTimeInput.NullText = ""

            Catch ex As Exception
                SubItemTimeInput = Nothing
            Finally
                CreateSubItemTimeEdit = SubItemTimeInput
            End Try

        End Function
        Public Function CreateSubItemDateEdit() As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput

            Dim SubItemDateInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput = Nothing

            Try

                SubItemDateInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput

            Catch ex As Exception
                SubItemDateInput = Nothing
            Finally
                CreateSubItemDateEdit = SubItemDateInput
            End Try

        End Function
        Public Function CreateSubItemImageComboBox(ByVal SubItemImageComboBoxType As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox.Type) As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox

            Dim SubItemImageComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox = Nothing

            Try

                SubItemImageComboBox = New AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox

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
        Public Function CreateSubItemImageCheckBox(ByVal IsReadOnly As Boolean, ByVal SubItemImageCheckEditControlType As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl.Type,
                                                   ByVal ObjectType As System.Type, ByVal FieldName As String) As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl

            'objects
            Dim SubItemImageCheckEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl = Nothing

            Try

                SubItemImageCheckEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl

                SubItemImageCheckEditControl.ControlType = SubItemImageCheckEditControlType
                SubItemImageCheckEditControl.ReadOnly = IsReadOnly

                If (ObjectType Is GetType(AdvantageFramework.Database.Classes.ExpenseReportItem) AndAlso FieldName = AdvantageFramework.Database.Classes.ExpenseReportItem.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.Database.Views.ExpenseSummary) AndAlso FieldName = AdvantageFramework.Database.Views.ExpenseSummary.Properties.DocumentCount.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) AndAlso FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.AccountReceivable.Classes.ClientInvoice) AndAlso FieldName = AdvantageFramework.AccountReceivable.Classes.ClientInvoice.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem) AndAlso FieldName = AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem.Properties.HasDocuments.ToString) OrElse
                   (ObjectType Is GetType(AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory) AndAlso FieldName = AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory.Properties.HasDocuments.ToString) Then

                    SubItemImageCheckEditControl.PictureChecked = AdvantageFramework.My.Resources.DocumentGeneric

                ElseIf (ObjectType Is GetType(AdvantageFramework.MediaManager.Classes.VCCOrder) AndAlso FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.Cancelled.ToString) Then

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
        Public Function CreateSubItemComboBox(ByVal Session As AdvantageFramework.Security.Session,
                                              ByVal SubItemComboBoxType As Presentation.Controls.SubItemComboBox.Type) As AdvantageFramework.WinForm.Presentation.Controls.SubItemComboBox

            'objects
            Dim SubItemComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemComboBox = Nothing

            Try

                SubItemComboBox = New AdvantageFramework.WinForm.Presentation.Controls.SubItemComboBox

                SubItemComboBox.Session = Session
                SubItemComboBox.ControlType = SubItemComboBoxType

            Catch ex As Exception
                SubItemComboBox = Nothing
            Finally
                CreateSubItemComboBox = SubItemComboBox
            End Try

        End Function
        Public Function CreateSubItemByPropertyTypeAttribute(ByVal Session As AdvantageFramework.Security.Session,
                                                             ByVal FieldName As String, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes,
                                                             ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                             ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute,
                                                             ByVal ObjectType As System.Type, ByVal FormatString As String, Optional ByVal AllowExtraComboItems As Boolean = True) As DevExpress.XtraEditors.Repository.RepositoryItem

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            Select Case PropertyType

                Case BaseClasses.PropertyTypes.ClientCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Client, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DivisionCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Division, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ProductCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Product, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.FunctionCode

                    If ObjectType Is GetType(AdvantageFramework.Database.Classes.ExpenseReportItem) OrElse
                       ObjectType Is GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging) Then

                        RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.ExpenseFunction, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                    Else

                        RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.[Function], FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                    End If

                Case BaseClasses.PropertyTypes.VendorCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Vendor, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.EmployeeCode

                    If ObjectType Is GetType(AdvantageFramework.Database.Classes.BillingRateDetail) Then

                        RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EmployeeWithDepartmentAndOffice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                    Else

                        RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Employee, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                    End If

                Case BaseClasses.PropertyTypes.EmployeeTitleID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EmployeeTitle, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DepartmentTeamCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.DepartmentTeam, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.OfficeCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Office, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.RoleCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Role, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.SalesClassCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.SalesClass, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.GeneralLedgerAccountCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.GeneralLedgerAccount, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.SalesTaxCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.SalesTax, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.VendorTermCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.VendorTerm, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ImportVendorCategoryCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.ImportVendorCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.VendorFunctionCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.VendorFunction, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.EmployeeFunctionCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EmployeeFunction, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.FunctionHeadingID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.FunctionHeading, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.IndirectCategoryType

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.IndirectCategoryType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PurchaseOrderApprovalRuleCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.POApprovalRule, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ServiceFeeTypeCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.ServiceFeeType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.WebsiteTypeCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.WebSiteType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.JobComponent

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.JobComponent, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.JobNumber

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Job, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.BankCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Bank, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PTORule

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.PTORule, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ClientContactID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.ClientContact, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MarketCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Market, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AdSizeCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.AdSize, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DaypartID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Daypart, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.JobVersionDatabaseType

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.JobVersionDatabaseType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.TaskCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Task, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.Phase

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Phase, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PartnerCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Partner, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.JobComponentID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.JobComponentID, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DaypartTypeID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.DaypartType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ExpenseEmployee

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.ExpenseEmployee, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.Blackplate

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Blackplate, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CycleTypes

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CycleType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AccountReceivable

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.AccountReceivable, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CampaignDetailType

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EnumObject, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.CampaignDetailTypes), AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PostPeriodCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.PostPeriod, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.EmployeeCategoryID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EmployeeCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.PostPeriodStatus

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.PostPeriodStatus, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaPlanID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.MediaPlan, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaPlanDetailID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.MediaPlanDetail, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.MediaType

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.AccountPayableImportMediaType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ProductCategory

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.ProductCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.LocationID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Location, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.Status

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Status, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.DaypartCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.DaypartCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CurrencyCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CurrencyCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.InvoiceCategory

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.InvoiceCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomProductionInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CustomProductionInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomMagazineInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CustomMagazineInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomNewspaperInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CustomNewspaperInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomInternetInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CustomInternetInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomOutdoorInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CustomOutdoorInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomRadioInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CustomRadioInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CustomTVInvoice

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CustomTVInvoice, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CampaignCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Campaign, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.CampaignID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CampaignID, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.InternetType

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.InternetType, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.AdNumber

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.AdNumber, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.AvalaraTaxID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.AvalaraTaxID, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.OverheadAccountCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.OverheadAccountCode, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.JobProcess

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.JobProcess, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.BillingCoopCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.BillingCoopCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ContactTypeID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.ContactType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.VCCStatus

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.VCCStatus, FieldName, EntityAttribute, PropertyDescriptor, Nothing, False)

                Case BaseClasses.PropertyTypes.OutOfHomeType

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.OutOfHomeType, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.InternetCostType

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EnumObject, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.InternetCostType))

                Case BaseClasses.PropertyTypes.NewspaperCostRate

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EnumObject, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.NewspaperCostRate))

                Case BaseClasses.PropertyTypes.DocumentType

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.DocumentType, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.OrderProcess

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.OrderProcess, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.Methods.PropertyTypes.RateType

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.RateType, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.StateCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.StateCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.Methods.PropertyTypes.IndirectCategory

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.IndirectCategory, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.Methods.PropertyTypes.JobTemplateMapping

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.JobTemplateMapping, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.GeneralLedgerSource

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.GeneralLedgerSource, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.BuyerEmployeeCode

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.BuyerEmployeeCode, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AssignComboInvoiceBy

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EnumDataTable, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.AssignComboInvoicesBy))

                Case BaseClasses.PropertyTypes.AssignProductionInvoiceBy

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EnumObject, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.AssignProductionInvoicesBy))

                Case BaseClasses.PropertyTypes.AssignMediaInvoiceBy

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EnumObject, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.AssignMediaInvoicesBy))

                Case BaseClasses.PropertyTypes.DoubleClickReportRelativeDateRange

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EnumObject, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.DoubleClickReportRelativeDateRange))

				Case BaseClasses.PropertyTypes.CableNetworkStation

					RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CableNetworkStation, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ClientDiscount

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.ClientDiscount, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.BroadcastOrderLineNumber

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.RadioOrderLineNumber, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.ProductionAdvancedBillingIncome

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.EnumDataTable, FieldName, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome))

                Case BaseClasses.PropertyTypes.AlertTemplate

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.AlertTemplate, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.AlertState

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.AlertState, FieldName, EntityAttribute, PropertyDescriptor, Nothing, AllowExtraComboItems)

                Case BaseClasses.PropertyTypes.CampaignID2

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.CampaignID2, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.MediaChannelID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.MediaChannelID, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.MediaTacticID

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.MediaTacticID, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.PropertyTypes.Assignment

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.Assignment, FieldName, EntityAttribute, PropertyDescriptor)

                Case Else

                    RepositoryItem = CreateDefaultSubItem(Session, FieldName, PropertyDescriptor.PropertyType, FormatString, ObjectType)

            End Select

            CreateSubItemByPropertyTypeAttribute = RepositoryItem

        End Function
        Public Function CreateSubItemByDefaultColumnTypeAttribute(ByVal Session As AdvantageFramework.Security.Session,
                                                                  ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes,
                                                                  ByVal FieldName As String, ByVal FormatString As String,
                                                                  ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                                  ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute,
                                                                  ByVal ObjectType As System.Type) As DevExpress.XtraEditors.Repository.RepositoryItem

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            Select Case DefaultColumnType

                'Case BaseClasses.DefaultColumnTypes.JobComponentDescription

                '    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.JobComponentDescription, FieldName, EntityAttribute, PropertyDescriptor)

                'Case BaseClasses.DefaultColumnTypes.JobDescription

                '    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.JobDescription, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.DefaultColumnTypes.OfficeName

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.OfficeName, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.DefaultColumnTypes.DepartmentTeamName

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.DepartmentTeamName, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.GeneralLedgerAccountDescription, FieldName, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.DefaultColumnTypes.Memo

                    RepositoryItem = CreateSubItemMemoEdit(Session, FieldName, ObjectType)

                Case BaseClasses.DefaultColumnTypes.StateName

                    RepositoryItem = CreateSubItemGridLookupEdit(Session, SubItemGridLookUpEditControl.Type.StateName, FieldName, EntityAttribute, PropertyDescriptor)

                Case Else

					RepositoryItem = CreateSubItemByDefaultColumnTypeAttribute(Session, DefaultColumnType, FieldName, FormatString, PropertyDescriptor.PropertyType, ObjectType)

			End Select

			CreateSubItemByDefaultColumnTypeAttribute = RepositoryItem

		End Function
		Public Function CreateSubItemByDefaultColumnTypeAttribute(ByVal Session As AdvantageFramework.Security.Session,
																  ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes,
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

                    RepositoryItem = CreateSubItemTimeEdit(SubItemTimeInput.Type.Default)

                Case Else

					RepositoryItem = CreateDefaultSubItem(Session, FieldName, ValueType, FormatString, ObjectType)

			End Select

			CreateSubItemByDefaultColumnTypeAttribute = RepositoryItem

		End Function
		Public Function CreateDefaultSubItem(ByVal Session As AdvantageFramework.Security.Session,
											 ByVal FieldName As String, ByVal PropertyType As System.Type,
											 ByVal FormatString As String, ByVal ObjectType As System.Type) As DevExpress.XtraEditors.Repository.RepositoryItem

			'objects
			Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

			If PropertyType Is GetType(String) Then

				RepositoryItem = CreateSubItemTextBox(Session, Presentation.Controls.SubItemTextBox.Type.Default, FieldName, ObjectType)

			ElseIf PropertyType Is GetType(Decimal) Then

				RepositoryItem = CreateSubItemNumericInput(Session, SubItemNumericInput.Type.Decimal, FieldName, FormatString, False, ObjectType, Nothing)

			ElseIf PropertyType Is GetType(System.Nullable(Of Decimal)) Then

				RepositoryItem = CreateSubItemNumericInput(Session, SubItemNumericInput.Type.Decimal, FieldName, FormatString, True, ObjectType, Nothing)

			ElseIf PropertyType Is GetType(Long) Then

				RepositoryItem = CreateSubItemNumericInput(Session, SubItemNumericInput.Type.Long, FieldName, FormatString, False, ObjectType, Nothing)

			ElseIf PropertyType Is GetType(Integer) Then

				RepositoryItem = CreateSubItemNumericInput(Session, SubItemNumericInput.Type.Integer, FieldName, FormatString, False, ObjectType, Nothing)

			ElseIf PropertyType Is GetType(Short) Then

				RepositoryItem = CreateSubItemNumericInput(Session, SubItemNumericInput.Type.Short, FieldName, FormatString, False, ObjectType, Nothing)

			ElseIf PropertyType Is GetType(System.Nullable(Of Long)) Then

				RepositoryItem = CreateSubItemNumericInput(Session, SubItemNumericInput.Type.Long, FieldName, FormatString, True, ObjectType, Nothing)

			ElseIf PropertyType Is GetType(System.Nullable(Of Integer)) Then

				RepositoryItem = CreateSubItemNumericInput(Session, SubItemNumericInput.Type.Integer, FieldName, FormatString, True, ObjectType, Nothing)

			ElseIf PropertyType Is GetType(System.Nullable(Of Short)) Then

				RepositoryItem = CreateSubItemNumericInput(Session, SubItemNumericInput.Type.Short, FieldName, FormatString, True, ObjectType, Nothing)

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
        Private Sub SaveDataGridViewLayout(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                           ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
                                           ByVal OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid,
                                           Optional ByVal GridAdvantageSubType As Nullable(Of Integer) = Nothing)

            'objects
            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing
            Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim AFActiveFilterString As String = Nothing
            Dim FindFilterText As String = Nothing

            MemoryStreamLayout = New System.IO.MemoryStream()

            AFActiveFilterString = DataGridView.CurrentView.AFActiveFilterString
            FindFilterText = DataGridView.CurrentView.FindFilterText

            DataGridView.CurrentView.AFActiveFilterString = Nothing
            DataGridView.CurrentView.FindFilterText = Nothing
            DataGridView.CurrentView.SaveLayoutToStream(MemoryStreamLayout, OptionsLayoutGrid)

            MemoryStreamLayout.Position = 0

            StreamReader = New System.IO.StreamReader(MemoryStreamLayout)

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                If GridAdvantageSubType Is Nothing Then

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, GridAdvantageType, Session.UserCode)

                Else

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, GridAdvantageType, Session.UserCode, GridAdvantageSubType)

                End If

                If GridAdvantage IsNot Nothing Then

                    GridAdvantage.XmlLayout = StreamReader.ReadToEnd

                    AdvantageFramework.Database.Procedures.GridAdvantage.Update(DataContext, GridAdvantage)

                Else

                    GridAdvantage = New AdvantageFramework.Database.Entities.GridAdvantage
                    GridAdvantage.DataContext = DataContext

                    GridAdvantage.GridType = GridAdvantageType
                    GridAdvantage.UserCode = Session.UserCode
                    GridAdvantage.XmlLayout = StreamReader.ReadToEnd
                    GridAdvantage.GridSubtype = GridAdvantageSubType

                    AdvantageFramework.Database.Procedures.GridAdvantage.Insert(DataContext, GridAdvantage)

                End If

            End Using

            DataGridView.CurrentView.AFActiveFilterString = AFActiveFilterString
            DataGridView.CurrentView.FindFilterText = FindFilterText

        End Sub
        Private Sub SaveDataGridViewLayout(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView,
                                           ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
                                           ByVal OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid,
                                           Optional ByVal GridAdvantageSubType As Nullable(Of Integer) = Nothing)

            'objects
            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing
            Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing

            MemoryStreamLayout = New System.IO.MemoryStream()

            DataGridView.CurrentView.AFActiveFilterString = Nothing
            DataGridView.CurrentView.FindFilterText = Nothing
            DataGridView.CurrentView.SaveLayoutToStream(MemoryStreamLayout, OptionsLayoutGrid)

            MemoryStreamLayout.Position = 0

            StreamReader = New System.IO.StreamReader(MemoryStreamLayout)

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                If GridAdvantageSubType Is Nothing Then

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, GridAdvantageType, Session.UserCode)

                Else

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, GridAdvantageType, Session.UserCode, GridAdvantageSubType)

                End If

                If GridAdvantage IsNot Nothing Then

                    GridAdvantage.XmlLayout = StreamReader.ReadToEnd

                    AdvantageFramework.Database.Procedures.GridAdvantage.Update(DataContext, GridAdvantage)

                Else

                    GridAdvantage = New AdvantageFramework.Database.Entities.GridAdvantage
                    GridAdvantage.DataContext = DataContext

                    GridAdvantage.GridType = GridAdvantageType
                    GridAdvantage.UserCode = Session.UserCode
                    GridAdvantage.XmlLayout = StreamReader.ReadToEnd
                    GridAdvantage.GridSubtype = GridAdvantageSubType

                    AdvantageFramework.Database.Procedures.GridAdvantage.Insert(DataContext, GridAdvantage)

                End If

            End Using

        End Sub
        Public Sub SaveDataGridViewLayout(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView,
                                          ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
                                          Optional ByVal GridAdvantageSubType As Nullable(Of Integer) = Nothing)

            'objects
            Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

            OptionsLayoutGrid = New DevExpress.Utils.OptionsLayoutGrid

            OptionsLayoutGrid.Assign(DevExpress.Utils.OptionsLayoutBase.FullLayout)

            SaveDataGridViewLayout(Session, DataGridView, GridAdvantageType, OptionsLayoutGrid, GridAdvantageSubType)

        End Sub
        Public Sub SaveDataGridViewLayout(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                          ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
                                          Optional ByVal GridAdvantageSubType As Nullable(Of Integer) = Nothing)

            'objects
            Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

            OptionsLayoutGrid = New DevExpress.Utils.OptionsLayoutGrid

            OptionsLayoutGrid.Assign(DevExpress.Utils.OptionsLayoutBase.FullLayout)

            SaveDataGridViewLayout(Session, DataGridView, GridAdvantageType, OptionsLayoutGrid, GridAdvantageSubType)

        End Sub
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
        Public Sub SaveMinimalDataGridViewLayout(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType, Optional ByVal GridAdvantageSubType As Nullable(Of Integer) = Nothing)

            'objects
            Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

            OptionsLayoutGrid = LoadMinimalDataGridViewLayoutOptions()

            SaveDataGridViewLayout(Session, DataGridView, GridAdvantageType, OptionsLayoutGrid, GridAdvantageSubType)

        End Sub
        Public Function LoadMinimalDataGridViewLayout(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                                      ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
                                                      Optional ByVal GridAdvantageSubType As Nullable(Of Long) = Nothing,
                                                      Optional ByVal RemoveOldColumns As Boolean = False) As Boolean

            'objects
            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing
            Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
            Dim StreamWriter As System.IO.StreamWriter = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim LayoutExists As Boolean = False
            Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                If GridAdvantageSubType Is Nothing Then

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, GridAdvantageType, Session.UserCode)

                Else

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, GridAdvantageType, Session.UserCode, GridAdvantageSubType)

                End If

            End Using

            If GridAdvantage IsNot Nothing Then

                MemoryStreamLayout = New System.IO.MemoryStream
                StreamWriter = New System.IO.StreamWriter(MemoryStreamLayout)

                StreamWriter.AutoFlush = True
                StreamWriter.Write(GridAdvantage.XmlLayout)

                MemoryStreamLayout.Position = 0

                DataGridView.CurrentView.OptionsLayout.Columns.RemoveOldColumns = RemoveOldColumns

                DataGridView.SuspendLayout()

                OptionsLayoutGrid = LoadMinimalDataGridViewLayoutOptions()

                'when you pass a static OptionsLayoutBase.FullLayout object to the RestoreLayoutFromXml method, the AddNewColumns option is not taken into account
                'https://www.devexpress.com/Support/Center/Question/Details/Q334295
                DataGridView.CurrentView.RestoreLayoutFromStream(MemoryStreamLayout, OptionsLayoutGrid) ', DevExpress.Utils.OptionsLayoutBase.FullLayout)

                If DataGridView.Columns.Count > 0 Then

                    GridColumn = DataGridView.Columns(0)

                    DataGridView.CurrentView.FocusedColumn = GridColumn

                End If

                DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = DataGridView.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(Column) Column.Visible = False).ToList()

                DataGridView.ResumeLayout()

                LayoutExists = True

            Else

                DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = Nothing

            End If

            LoadMinimalDataGridViewLayout = LayoutExists

        End Function
        Public Function LoadDataGridViewLayout(DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView,
                                                GridAdvantage As AdvantageFramework.DTO.GridAdvantage,
                                                Optional RemoveOldColumns As Boolean = False) As Boolean

            'objects
            Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
            Dim StreamWriter As System.IO.StreamWriter = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim LayoutExists As Boolean = False
            Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

            OptionsLayoutGrid = New DevExpress.Utils.OptionsLayoutGrid

            OptionsLayoutGrid.Assign(DevExpress.Utils.OptionsLayoutBase.FullLayout)

            OptionsLayoutGrid.Columns.RemoveOldColumns = RemoveOldColumns

            If GridAdvantage IsNot Nothing AndAlso String.IsNullOrWhiteSpace(GridAdvantage.XmlLayout) = False Then

                MemoryStreamLayout = New System.IO.MemoryStream
                StreamWriter = New System.IO.StreamWriter(MemoryStreamLayout)

                StreamWriter.AutoFlush = True
                StreamWriter.Write(GridAdvantage.XmlLayout)

                MemoryStreamLayout.Position = 0

                DataGridView.CurrentView.OptionsLayout.Columns.RemoveOldColumns = RemoveOldColumns

                DataGridView.SuspendLayout()

                'when you pass a static OptionsLayoutBase.FullLayout object to the RestoreLayoutFromXml method, the AddNewColumns option is not taken into account
                'https://www.devexpress.com/Support/Center/Question/Details/Q334295
                DataGridView.CurrentView.RestoreLayoutFromStream(MemoryStreamLayout, OptionsLayoutGrid) ', DevExpress.Utils.OptionsLayoutBase.FullLayout)

                If DataGridView.Columns.Count > 0 Then

                    GridColumn = DataGridView.Columns(0)

                    DataGridView.CurrentView.FocusedColumn = GridColumn

                End If

                DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = DataGridView.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(Column) Column.Visible = False).ToList()

                DataGridView.ResumeLayout()

                LayoutExists = True

            Else

                DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = Nothing

            End If

            LoadDataGridViewLayout = LayoutExists

        End Function
        Public Function LoadDataGridViewLayout(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                               ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
                                               Optional ByVal GridAdvantageSubType As Nullable(Of Long) = Nothing,
                                               Optional ByVal RemoveOldColumns As Boolean = False) As Boolean

            'objects
            Dim OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid = Nothing

            OptionsLayoutGrid = New DevExpress.Utils.OptionsLayoutGrid

            OptionsLayoutGrid.Assign(DevExpress.Utils.OptionsLayoutBase.FullLayout)

            OptionsLayoutGrid.Columns.RemoveOldColumns = RemoveOldColumns

            LoadDataGridViewLayout = LoadDataGridViewLayout(Session, DataGridView, GridAdvantageType, OptionsLayoutGrid, GridAdvantageSubType)

        End Function
        Private Function LoadDataGridViewLayout(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                                ByVal GridAdvantageType As AdvantageFramework.Database.Entities.GridAdvantageType,
                                                ByVal OptionsLayoutGrid As DevExpress.Utils.OptionsLayoutGrid,
                                                Optional ByVal GridAdvantageSubType As Nullable(Of Long) = Nothing) As Boolean

            'objects
            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing
            Dim MemoryStreamLayout As System.IO.MemoryStream = Nothing
            Dim StreamWriter As System.IO.StreamWriter = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim LayoutExists As Boolean = False

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                If GridAdvantageSubType Is Nothing Then

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, GridAdvantageType, Session.UserCode)

                Else

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, GridAdvantageType, Session.UserCode, GridAdvantageSubType)

                End If

            End Using

            If GridAdvantage IsNot Nothing Then

                MemoryStreamLayout = New System.IO.MemoryStream
                StreamWriter = New System.IO.StreamWriter(MemoryStreamLayout)

                StreamWriter.AutoFlush = True
                StreamWriter.Write(GridAdvantage.XmlLayout)

                MemoryStreamLayout.Position = 0

                'DataGridView.CurrentView.OptionsLayout.Columns.RemoveOldColumns = RemoveOldColumns

                DataGridView.SuspendLayout()

                'when you pass a static OptionsLayoutBase.FullLayout object to the RestoreLayoutFromXml method, the AddNewColumns option is not taken into account
                'https://www.devexpress.com/Support/Center/Question/Details/Q334295
                DataGridView.CurrentView.RestoreLayoutFromStream(MemoryStreamLayout, OptionsLayoutGrid) ', DevExpress.Utils.OptionsLayoutBase.FullLayout)

                If DataGridView.Columns.Count > 0 Then

                    GridColumn = DataGridView.Columns(0)

                    DataGridView.CurrentView.FocusedColumn = GridColumn

                End If

                DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = DataGridView.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).Where(Function(Column) Column.Visible = False).ToList()

                DataGridView.ResumeLayout()

                LayoutExists = True

            Else

                DataGridView.CurrentView.RestoredLayoutNonVisibleGridColumnList = Nothing

            End If

            LoadDataGridViewLayout = LayoutExists

        End Function
        Public Sub AvataxValidateAddress(ByVal Session As AdvantageFramework.Security.Session, ByRef AddressControl As AdvantageFramework.WinForm.Presentation.Controls.AddressControl,
                                         ByVal AddressType As AddressTypeToValidate)

            Dim BillingCountry As String = Nothing
            Dim Address As AdvantageFramework.AvaTax.API.Address = Nothing
            Dim ValidatedAddress As AdvantageFramework.AvaTax.API.Address = Nothing
            Dim MessageString As String = Nothing
            Dim ValidCountries As IEnumerable(Of String) = Nothing
            Dim Proceed As Boolean = True

            ValidCountries = {"US", "CA"}

            If String.IsNullOrWhiteSpace(AddressControl.Country) Then

                BillingCountry = "US"

            ElseIf Not ValidCountries.Contains(AddressControl.Country.ToUpper) Then

                AdvantageFramework.WinForm.MessageBox.Show("Country must be either 'US' or 'CA'.")
                Proceed = False

            End If

            If Proceed Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) AndAlso AdvantageFramework.Agency.GetOptionAvaTaxAddressValidationEnabled(DbContext) Then

                        If (From FindString In AdvantageFramework.Agency.GetOptionAvaTaxEnableAddressValidationForCountries(DbContext)
                            Where FindString.ToUpper = BillingCountry).Any Then

                            Address = New AdvantageFramework.AvaTax.API.Address

                            Address.Line1 = AddressControl.Address
                            Address.Line2 = AddressControl.Address2
                            Address.City = AddressControl.City
                            Address.County = AddressControl.County
                            Address.Region = AddressControl.State
                            Address.PostalCode = AddressControl.Zip
                            Address.Country = BillingCountry

                            If AdvantageFramework.AvaTax.ValidateAddress(Session, Address, ValidatedAddress, MessageString) Then

                                AddressControl.Tag = Nothing

                                If Address.Line1 <> ValidatedAddress.Line1 OrElse Address.Line2 <> ValidatedAddress.Line2 OrElse Address.City <> ValidatedAddress.City OrElse
                                            Address.County <> ValidatedAddress.County OrElse Address.Region <> ValidatedAddress.Region OrElse Address.PostalCode <> ValidatedAddress.PostalCode OrElse
                                            Address.Country <> ValidatedAddress.Country Then

                                    If AdvantageFramework.WinForm.MessageBox.Show(MessageString, MessageBox.MessageBoxButtons.YesNo, "Update " & AddressType.ToString & " Address To:") = MessageBox.DialogResults.Yes Then

                                        AddressControl.Address = ValidatedAddress.Line1
                                        AddressControl.Address2 = ValidatedAddress.Line2
                                        AddressControl.City = ValidatedAddress.City
                                        AddressControl.County = ValidatedAddress.County
                                        AddressControl.State = ValidatedAddress.Region
                                        AddressControl.Zip = ValidatedAddress.PostalCode
                                        AddressControl.Country = ValidatedAddress.Country

                                    End If

                                End If

                            Else

                                AddressControl.Tag = "INVALID"

                                AdvantageFramework.WinForm.MessageBox.Show(MessageString, MessageBox.MessageBoxButtons.OK, "Avalara - Could Not Validate " & AddressType.ToString & " Address")

                            End If

                        End If

                    End If

                End Using

            End If

        End Sub
        Public Sub SortGridViewBySortedColumns(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            If DataGridView.CurrentView.SortedColumns.Count > 0 Then

                DataGridView.CurrentView.BeginSort()

                For SortedColumn As Integer = 0 To DataGridView.CurrentView.SortedColumns.Count - 1

                    If DataGridView.CurrentView.Columns(DataGridView.CurrentView.SortedColumns(SortedColumn).FieldName) IsNot Nothing Then

                        DataGridView.CurrentView.Columns(DataGridView.CurrentView.SortedColumns(SortedColumn).FieldName).SortOrder = DataGridView.CurrentView.SortedColumns(SortedColumn).SortOrder

                    End If

                Next

                DataGridView.CurrentView.EndSort()

            End If

        End Sub
        Public Function EntityColumnShowsInGrid(ByVal ObjectType As System.Type, ByVal ColumnFieldName As String) As Boolean

            Dim IsVisible As Boolean = False
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Try

                PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                      Where [Property].Name = ColumnFieldName
                                      Select [Property]).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        IsVisible = EntityAttribute.ShowColumnInGrid

                    End If

                End Try

            End If

            EntityColumnShowsInGrid = IsVisible

        End Function

#End Region

#End Region

    End Module

End Namespace
