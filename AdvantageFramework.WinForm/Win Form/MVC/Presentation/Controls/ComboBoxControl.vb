Namespace WinForm.MVC.Presentation.Controls

    Public Class ComboBox
        Inherits DevComponents.DotNetBar.Controls.ComboBoxEx
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

        Public Event ReloadComboBox()
        Public Event SetInactiveValue(Value As Object)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ExtraComboBoxItems As Short
            [Nothing] = 0
            PleaseSelect = -1
            None = -2
            AgencyDefault = -3
            Open = -4
        End Enum

#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _DisableMouseWheel As Boolean = False
        Protected _ExtraComboBoxItem As ExtraComboBoxItems = ExtraComboBoxItems.Nothing
        Protected _IsRequired As Boolean = False
        Protected _BookmarkingEnabled As Boolean = False
        Protected _CurrentBookmark As Object = Nothing
        Protected _DisplayName As String = ""
        Protected _ErrorIconAlignment As System.Windows.Forms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Protected _EntityDataType As System.Type = Nothing
        Protected _AddedItemsToDataSource As Generic.List(Of Object) = Nothing
        Protected _AddInactiveItemsOnSelectedValue As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _IsDataSourceLoading As Boolean = False
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _ReadOnly As Boolean = False
        Protected _Visible As Boolean = True
        Protected _TextBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox = Nothing
        Protected _AutoSelectSingleItemDatasource As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _AutoFindItemInDataSource As Boolean = False
        Private _SecurityEnabled As Boolean = True
        Protected _TabOnEnter As Boolean = True

#End Region

#Region " Properties "

        Public ReadOnly Property UserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.UserEntryChanged
            Get
                UserEntryChanged = _UserEntryChanged
            End Get
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Public Property DisplayName As String
            Get
                DisplayName = _DisplayName
            End Get
            Set(ByVal value As String)
                _DisplayName = value
            End Set
        End Property
        Public Shadows Property DataSource() As Object
            Get
                DataSource = MyBase.DataSource
            End Get
            Set(ByVal value As Object)
                _IsDataSourceLoading = True
                LoadDataSource(value)
                _IsDataSourceLoading = False

                If _AutoSelectSingleItemDatasource Then

                    SelectSingleItemDataSource()

                End If

            End Set
        End Property
        Public Property ExtraComboBoxItem() As ExtraComboBoxItems
            Get
                ExtraComboBoxItem = _ExtraComboBoxItem
            End Get
            Set(ByVal value As ExtraComboBoxItems)
                _ExtraComboBoxItem = value
            End Set
        End Property
        Public Property BookmarkingEnabled() As Boolean
            Get
                BookmarkingEnabled = _BookmarkingEnabled
            End Get
            Set(ByVal value As Boolean)
                _BookmarkingEnabled = value
            End Set
        End Property
        Public Property ErrorIconAlignment() As System.Windows.Forms.ErrorIconAlignment
            Get
                ErrorIconAlignment = _ErrorIconAlignment
            End Get
            Set(ByVal value As System.Windows.Forms.ErrorIconAlignment)
                _ErrorIconAlignment = value
            End Set
        End Property
        Public Shadows Property SelectedValue As Object
            Get
                SelectedValue = MyBase.SelectedValue
            End Get
            Set(ByVal value As Object)

                Dim Failed As Boolean = False

                Try

                    If IsNothing(value) = False Then

                        MyBase.SelectedValue = value

                    Else

                        Failed = True

                    End If

                Catch ex As Exception
                    Failed = True
                End Try

                If Failed OrElse MyBase.SelectedValue Is Nothing Then

                    Try

                        If _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing AndAlso Me.Items.Count > 0 Then

                            Me.SelectedIndex = 0

                        Else

                            Me.SelectedIndex = -1

                        End If

                    Catch ex As Exception

                    End Try

                    Try

                        If (value IsNot Nothing OrElse value <> Nothing) AndAlso Me.HasASelectedValue = False AndAlso _AddInactiveItemsOnSelectedValue Then

                            RaiseEvent SetInactiveValue(value)

                        End If

                    Catch ex As Exception

                    End Try

                End If

            End Set
        End Property
        Public Property DisableMouseWheel() As Boolean
            Get
                DisableMouseWheel = _DisableMouseWheel
            End Get
            Set(ByVal value As Boolean)
                _DisableMouseWheel = value
            End Set
        End Property
        Public Property AddInactiveItemsOnSelectedValue() As Boolean
            Get
                AddInactiveItemsOnSelectedValue = _AddInactiveItemsOnSelectedValue
            End Get
            Set(ByVal value As Boolean)
                _AddInactiveItemsOnSelectedValue = value
            End Set
        End Property
        Public ReadOnly Property IsDataSourceLoading As Boolean
            Get
                IsDataSourceLoading = _IsDataSourceLoading
            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)
                _ByPassUserEntryChanged = value
            End Set
        End Property
        Public Property [ReadOnly] As Boolean
            Get
                [ReadOnly] = _ReadOnly
            End Get
            Set(ByVal value As Boolean)

                If value <> _ReadOnly Then

                    _ReadOnly = value

                    ShowControl()

                End If

            End Set
        End Property
        Public Shadows Property Visible As Boolean
            Get
                Visible = _Visible
            End Get
            Set(ByVal value As Boolean)
                _Visible = value
                ShowControl()
            End Set
        End Property
        Public Property AutoSelectSingleItemDatasource As Boolean
            Get
                AutoSelectSingleItemDatasource = _AutoSelectSingleItemDatasource
            End Get
            Set(ByVal value As Boolean)
                _AutoSelectSingleItemDatasource = value
            End Set
        End Property
        Public Property AutoFindItemInDataSource As Boolean
            Get
                AutoFindItemInDataSource = _AutoFindItemInDataSource
            End Get
            Set(value As Boolean)
                _AutoFindItemInDataSource = value
            End Set
        End Property
        Public Shadows Property Enabled As Boolean
            Get
                Enabled = MyBase.Enabled
            End Get
            Set(ByVal value As Boolean)

                If _SecurityEnabled Then

                    MyBase.Enabled = value

                Else

                    MyBase.Enabled = False

                End If

                If Not MyBase.Enabled Then

                    Me.UseCustomBackColor = False

                Else

                    SetRequired(_IsRequired)

                End If

            End Set
        End Property
        Public Property SecurityEnabled As Boolean
            Get
                SecurityEnabled = _SecurityEnabled
            End Get
            Set(ByVal value As Boolean)
                _SecurityEnabled = value
                Me.Enabled = value
            End Set
        End Property
        Public Property TabOnEnter() As Boolean
            Get
                TabOnEnter = _TabOnEnter
            End Get
            Set(ByVal value As Boolean)
                _TabOnEnter = value
            End Set
        End Property
        Public Overrides Property SelectedIndex() As Integer
            Get
                SelectedIndex = MyBase.SelectedIndex
            End Get
            Set(ByVal value As Integer)

                If value = 0 Then

                    If Me.Items.Count > 0 Then

                        MyBase.SelectedIndex = 0

                    Else

                        MyBase.SelectedIndex = -1

                    End If

                Else

                    MyBase.SelectedIndex = value

                End If

            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDown
            Me.ItemHeight = 14
            Me.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
            Me.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
            Me.FocusHighlightEnabled = True
            Me.WatermarkEnabled = True
            Me.FlatStyle = Windows.Forms.FlatStyle.Flat
            Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
            Me.FocusHighlightColor = System.Drawing.Color.FromArgb(255, 230, 141)

            Me.DoubleBuffered = True

            _AddedItemsToDataSource = New Generic.List(Of Object)
            _TextBox = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox

        End Sub
        Public Sub ClearChanged() Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper)

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor)

        End Sub
        Public Sub SetPropertySettings(Optional ByVal DisplayName As String = Nothing, Optional ByVal EntityDataType As System.Type = Nothing, Optional ByVal IsRequired As Boolean = False)

            If String.IsNullOrEmpty(DisplayName) = False Then

                _DisplayName = DisplayName

            End If

            If EntityDataType IsNot Nothing AndAlso EntityDataType.IsEnum Then

                _EntityDataType = EntityDataType.GetEnumUnderlyingType

            Else

                _EntityDataType = EntityDataType

            End If

            SetRequired(IsRequired)

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If PropertyDescriptor IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                End Try

                If EntityAttribute IsNot Nothing Then

                    SetPropertySettings(AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name), PropertyDescriptor.PropertyType, EntityAttribute.IsRequired)

                Else

                    SetPropertySettings(AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name), PropertyDescriptor.PropertyType)

                End If

            End If

        End Sub
        Public Sub SetPropertySettings(ByVal EnumProperty As [Enum])

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor)

        End Sub
        Public Sub SetRequired(ByVal IsRequired As Boolean)

            _IsRequired = IsRequired

            If _IsRequired Then

                Me.UseCustomBackColor = True
                Me.BackColor = Drawing.Color.Cyan

            Else

                Me.UseCustomBackColor = False
                Me.BackColor = Drawing.Color.White

            End If

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                Me.DisplayMember = "Display"
                Me.ValueMember = "Value"

                If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.MVC.Presentation.Controls.Validation.CustomValidatorControl)

                        DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.ErrorProvider.SetIconAlignment(Me, _ErrorIconAlignment)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub SetControlType()

            Me.DisplayMember = "Display"
            Me.ValueMember = "Value"

        End Sub
        Protected Sub LoadDataSource(ByRef Value As Object)

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If Me.DesignMode = False Then

                Me.BeginUpdate()

                LoadBookmarks()

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = Value

                If Value IsNot Nothing Then

                    If _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                        If Me.DisplayMember = "" Then

                            Me.SetControlType()

                        End If

                        LoadExtraComboItem(_ExtraComboBoxItem, BindingSource)

                    End If

                End If

                MyBase.DataSource = BindingSource

                SetBookmarks()

                If Me.DisplayMember = "" Then

                    Me.SetControlType()

                End If

                Me.ClearChanged()

                Me.EndUpdate()

            End If

        End Sub
        Protected Sub LoadExtraComboItem(ByVal ExtraComboItem As ExtraComboBoxItems, ByRef BindingSource As System.Windows.Forms.BindingSource)

            If ExtraComboBoxItem = ExtraComboBoxItems.AgencyDefault Then

                AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.DisplayMember, Me.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", Nothing, True, True, _AddedItemsToDataSource)

            Else

                AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.DisplayMember, Me.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", AdvantageFramework.EnumUtilities.GetValue(ExtraComboItem.GetType, ExtraComboItem.ToString), True, True, _AddedItemsToDataSource)

            End If

        End Sub
        Public Sub AddComboItemToExistingDataSource(ByVal DisplayValue As String, ByVal Value As String, ByVal InsertInFirstPosition As Boolean, Optional ByVal PostionIndex As Integer = -1)

            AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(Me.DataSource, Me.DisplayMember, Me.ValueMember, DisplayValue, Value, InsertInFirstPosition, False, _AddedItemsToDataSource, PostionIndex)

        End Sub
        Public Sub RemoveAddedItemsFromDataSource()

            RemoveAddedItemsFromDataSource(Me.DataSource)

        End Sub
        Private Sub RemoveAddedItemsFromDataSource(ByVal BindingSource As System.Windows.Forms.BindingSource)

            AdvantageFramework.WinForm.MVC.Presentation.Controls.SuspendBindingOnABindingSource(BindingSource)

            Try

                For Each AddedItem In _AddedItemsToDataSource

                    BindingSource.Remove(AddedItem)

                Next

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.MVC.Presentation.Controls.ResumeBindingOnABindingSource(BindingSource)

        End Sub
        Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                If _IsRequired Then

                    If Me.GetSelectedValue Is Nothing Then

                        If _DisplayName = "" Then

                            ErrorMessage = "Is required."

                        Else

                            ErrorMessage = _DisplayName & " is required."

                        End If

                        IsValid = False

                    End If

                End If

                If Me.Text <> "" AndAlso Me.GetSelectedValue Is Nothing AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.None.ToString) & "]" AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.PleaseSelect.ToString) & "]" AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.AgencyDefault.ToString) & "]" AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.Open.ToString) & "]" Then

                    If _DisplayName = "" Then

                        ErrorMessage = "Please select a valid "

                    Else

                        ErrorMessage = "Please select a valid " & _DisplayName

                    End If

                    IsValid = False

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                Validate = IsValid
            End Try

        End Function
        Protected Sub LoadBookmarks()

            If _BookmarkingEnabled AndAlso
                Me.SelectedItem IsNot Nothing Then

                _CurrentBookmark = Me.SelectedItem

            Else

                _CurrentBookmark = Nothing

            End If

        End Sub
        Protected Sub SetBookmarks()

            If _BookmarkingEnabled AndAlso
                _CurrentBookmark IsNot Nothing Then

                Me.SelectedItem = _CurrentBookmark

            End If

        End Sub
        Public Function HasASelectedValue() As Boolean

            'objects
            Dim DoesHaveASelectedValue As Boolean = False

            If Me.SelectedValue IsNot Nothing Then

                If Me.ExtraComboBoxItem = ExtraComboBoxItems.Nothing Then

                    DoesHaveASelectedValue = True

                Else

                    If Me.ExtraComboBoxItem = ExtraComboBoxItems.PleaseSelect Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.PleaseSelect) Then

                            DoesHaveASelectedValue = True

                        End If

                    ElseIf Me.ExtraComboBoxItem = ExtraComboBoxItems.None Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.None) Then

                            DoesHaveASelectedValue = True

                        End If

                    ElseIf Me.ExtraComboBoxItem = ExtraComboBoxItems.AgencyDefault Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.AgencyDefault) Then

                            DoesHaveASelectedValue = True

                        End If

                    ElseIf Me.ExtraComboBoxItem = ExtraComboBoxItems.Open Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.Open) Then

                            DoesHaveASelectedValue = True

                        End If

                    End If

                End If

            End If

            HasASelectedValue = DoesHaveASelectedValue

        End Function
        Public Function GetSelectedValue() As Object

            'objects
            Dim SelectedValue As Object = Nothing
            Dim SystemType As System.Type = Nothing

            If Me.HasASelectedValue Then

                Try

                    If _EntityDataType IsNot Nothing Then

                        If Nullable.GetUnderlyingType(_EntityDataType) IsNot Nothing Then

                            SystemType = Nullable.GetUnderlyingType(_EntityDataType)

                        Else

                            SystemType = _EntityDataType

                        End If

                        If SystemType = GetType(Short) OrElse SystemType = GetType(Integer) OrElse SystemType = GetType(Long) OrElse
                                SystemType = GetType(Decimal) OrElse SystemType = GetType(Single) OrElse SystemType = GetType(Double) Then

                            If IsNumeric(Me.SelectedValue) Then

                                SelectedValue = Convert.ChangeType(Me.SelectedValue, SystemType)

                            Else

                                SelectedValue = Me.SelectedValue

                            End If

                        Else

                            SelectedValue = Convert.ChangeType(Me.SelectedValue, SystemType)

                        End If

                    Else

                        SelectedValue = Me.SelectedValue

                    End If

                Catch ex As Exception
                    SelectedValue = Me.SelectedValue
                End Try

            End If

            GetSelectedValue = SelectedValue

        End Function
        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)

            MyBase.OnResize(e)

            Me.SelectionLength = 0

        End Sub
        Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)

            Dim HandledMouseEventArgs As System.Windows.Forms.HandledMouseEventArgs = Nothing

            If _DisableMouseWheel Then

                HandledMouseEventArgs = DirectCast(e, System.Windows.Forms.HandledMouseEventArgs)

                HandledMouseEventArgs.Handled = True

            End If

        End Sub
        Private Sub ShowControl()

            If _ReadOnly Then

                _TextBox.Location = Me.Location
                _TextBox.Size = Me.Size
                _TextBox.Visible = _Visible AndAlso Me.Enabled
                MyBase.Visible = _Visible AndAlso Not Me.Enabled
                _TextBox.Text = Me.Text

            Else

                _TextBox.Visible = False
                MyBase.Visible = _Visible

            End If

        End Sub
        Private Sub AddTextbox()

            _TextBox.ReadOnly = True
            _TextBox.Location = Me.Location
            _TextBox.Size = Me.Size
            _TextBox.Dock = Me.Dock
            _TextBox.Anchor = Me.Anchor
            _TextBox.Enabled = Me.Enabled
            _TextBox.Visible = (_ReadOnly AndAlso _Visible AndAlso Me.Enabled)
            _TextBox.RightToLeft = Me.RightToLeft
            _TextBox.Font = Me.Font
            _TextBox.Text = Me.Text
            _TextBox.TabStop = False
            _TextBox.TabIndex = Me.TabIndex
            _TextBox.BackColor = System.Drawing.SystemColors.Control
            _TextBox.ByPassUserEntryChanged = True

        End Sub
        Public Shadows Sub Show()

            Me.Visible = True

        End Sub
        Public Shadows Sub Hide()

            Me.Visible = False

        End Sub
        Protected Overrides Sub OnParentChanged(ByVal e As System.EventArgs)

            MyBase.OnParentChanged(e)

            If Parent IsNot Nothing Then

                AddTextbox()
                _TextBox.Parent = Me.Parent

            End If

        End Sub
        Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)

            MyBase.OnSelectedIndexChanged(e)

            If Me.SelectedIndex = -1 Then

                _TextBox.Clear()

            Else

                _TextBox.Text = Me.Text

            End If

        End Sub
        Protected Overrides Sub OnSelectedValueChanged(ByVal e As System.EventArgs)

            MyBase.OnSelectedValueChanged(e)

            If Me.SelectedValue Is Nothing Then

                _TextBox.Clear()

            Else

                _TextBox.Text = Me.Text

            End If

        End Sub
        Protected Overrides Sub OnDropDownStyleChanged(ByVal e As System.EventArgs)

            MyBase.OnDropDownStyleChanged(e)

            _TextBox.Text = Me.Text

        End Sub
        Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)

            MyBase.OnFontChanged(e)

            _TextBox.Font = Me.Font

        End Sub
        Protected Overrides Sub OnDockChanged(ByVal e As System.EventArgs)

            MyBase.OnDockChanged(e)

            _TextBox.Dock = Me.Dock

        End Sub
        Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)

            MyBase.OnEnabledChanged(e)

            ShowControl()

        End Sub
        Protected Overrides Sub OnRightToLeftChanged(ByVal e As System.EventArgs)

            MyBase.OnRightToLeftChanged(e)

            _TextBox.RightToLeft = Me.RightToLeft

        End Sub
        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)

            MyBase.OnTextChanged(e)

            _TextBox.Text = Me.Text

        End Sub
        Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)

            MyBase.OnLocationChanged(e)

            _TextBox.Location = Me.Location

        End Sub
        Protected Overrides Sub OnTabIndexChanged(ByVal e As System.EventArgs)

            MyBase.OnTabIndexChanged(e)

            _TextBox.TabIndex = Me.TabIndex

        End Sub
        Public Function SelectSingleItemDataSource() As Boolean

            'objects
            Dim Selected As Boolean = False

            Try

                If Me.Items.Count = 2 AndAlso Me.ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                    Me.SelectedIndex = 1
                    Selected = True

                ElseIf Me.Items.Count = 1 AndAlso Me.ExtraComboBoxItem = ExtraComboBoxItems.Nothing Then

                    Me.SelectedIndex = 0
                    Selected = True

                End If

            Catch ex As Exception
                Selected = False
            Finally
                SelectSingleItemDataSource = Selected
            End Try

        End Function
        Protected Sub SetUserEntryChanged()

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.MVC.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        Protected Overrides Sub OnKeyDown(e As Windows.Forms.KeyEventArgs)

            If Me.DroppedDown = False AndAlso _TabOnEnter Then

                If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = False Then

                    Me.FindForm.SelectNextControl(Me, True, True, True, True)

                ElseIf e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

                    Me.FindForm.SelectNextControl(Me, False, True, True, True)

                End If

            End If

            MyBase.OnKeyDown(e)

        End Sub

#Region "  Control Event Handlers "

        Private Sub ComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectionChangeCommitted

            SetUserEntryChanged()

        End Sub
        Private Sub ComboBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

            _TextBox.Size = Me.Size

        End Sub
        Private Sub ComboBox_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.Validating

            Dim ParentForm As System.Windows.Forms.Form = Nothing
            Dim Item As Object = Nothing

            If Me.SelectedItem Is Nothing AndAlso Me.Text <> "" Then

                If Me.ValueMember = "Code" Then

                    For ItemIndex As Integer = 0 To Me.Items.Count - 1

                        If Me.Items(ItemIndex).Code.ToString.ToUpper = Me.Text.ToUpper Then

                            Me.SelectedItem = Me.Items(ItemIndex)

                            SetUserEntryChanged()

                            ParentForm = Me.FindForm

                            If ParentForm IsNot Nothing AndAlso TypeOf ParentForm Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                                DirectCast(ParentForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).ValidateControl(Me)

                            End If

                            Exit For

                        End If

                    Next

                ElseIf _AutoFindItemInDataSource Then

                    Try

                        Item = AdvantageFramework.WinForm.MVC.Presentation.Controls.FindObjectInDataSource(Me.DataSource, Me.ValueMember, Me.Text)

                    Catch ex As Exception
                        Item = Nothing
                    End Try

                    If Item IsNot Nothing Then

                        Me.SelectedItem = Item

                        SetUserEntryChanged()

                        ParentForm = Me.FindForm

                        If ParentForm IsNot Nothing AndAlso TypeOf ParentForm Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                            DirectCast(ParentForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).ValidateControl(Me)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

            Me.DroppedDown = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "


#End Region

#End Region

    End Class

End Namespace
