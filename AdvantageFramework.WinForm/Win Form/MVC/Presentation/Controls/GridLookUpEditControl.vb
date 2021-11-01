Namespace WinForm.MVC.Presentation.Controls

    Public Class GridLookUpEdit
        Inherits DevExpress.XtraEditors.GridLookUpEdit
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

        Public Event ReloadComboBox()
        Public Event QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean)
        Public Event DataSourceChangedEvent()
        Public Event SetInactiveValue(Value As Object)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ExtraComboBoxItems As Short
            [Nothing] = 0
            PleaseSelect = -1
            None = -2
            AgencyDefault = -3
            All = -4
        End Enum

        Public Enum [Type]
            [Default]
            Market
            PostPeriod
            EnumObjects
            NielsenStation
            BroadcastType
            RatingsService
            MediaMarketBreak
            NielsenRadioReportType
            NielsenRadioPeriod
            NielsenRadioMarket
            NielsenRadioQualitative
            NielsenRadioDaypart
            NielsenRadioStation
            MediaDemographic
            Client
            Vendor
            CurrencyCode
            NielsenRadioCounty
            MarketBreak
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As GridLookUpEdit.Type = GridLookUpEdit.Type.Default
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
        Protected _BypassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _HasValidDataSource As Boolean = False
        Protected _ShowAllRowsOnInitialSearch As Boolean = False
        Protected _ActiveFilterString As String = ""
        Protected _ActiveFilterEnabled As Boolean = False
        Protected _HideValueMemberColumn As Boolean = False
        Protected _UseAlternateView As Boolean = False
        Protected _SecurityEnabled As Boolean = True
        Protected _AutoFillMode As Boolean = False
        Protected _TabOnEnter As Boolean = True
        Protected _ReadOnly As Boolean = False
        Protected _TextBox As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox = Nothing
        Protected _Visible As Boolean = True

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
        Public Property ControlType() As GridLookUpEdit.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As GridLookUpEdit.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Shadows Property DataSource() As Object
            Get
                DataSource = MyBase.Properties.DataSource
            End Get
            Set(ByVal value As Object)
                _IsDataSourceLoading = True
                LoadDataSource(value)
                _IsDataSourceLoading = False
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
        Public Overloads Property ErrorIconAlignment() As System.Windows.Forms.ErrorIconAlignment
            Get
                ErrorIconAlignment = _ErrorIconAlignment
            End Get
            Set(ByVal value As System.Windows.Forms.ErrorIconAlignment)
                _ErrorIconAlignment = value
            End Set
        End Property
        Public Shadows Property SelectedValue As Object
            Get
                SelectedValue = MyBase.EditValue
            End Get
            Set(ByVal value As Object)

                Try

                    MyBase.EditValue = value

                Catch ex As Exception

                End Try

                If TypeOf Me.DataSource Is System.Windows.Forms.BindingSource AndAlso
                                        CType(Me.DataSource, System.Windows.Forms.BindingSource).DataSource IsNot Nothing AndAlso
                                        CType(Me.DataSource, System.Windows.Forms.BindingSource).Count > 0 AndAlso
                                        Me.Properties.DisplayMember <> "" Then

                    Try

                        If AdvantageFramework.BaseClasses.ApplyWhere(CType(Me.DataSource, System.Windows.Forms.BindingSource).List.AsQueryable, Me.Properties.ValueMember, BaseClasses.OperatorTypes.IsEqualTo, MyBase.EditValue).Cast(Of Object).Any = False Then

                            Me.EditValue = Nothing

                        End If

                    Catch ex As Exception

                    End Try

                ElseIf TypeOf Me.DataSource Is System.Windows.Forms.BindingSource AndAlso
                       CType(Me.DataSource, System.Windows.Forms.BindingSource).DataSource IsNot Nothing AndAlso
                       CType(Me.DataSource, System.Windows.Forms.BindingSource).Count = 0 Then

                    Me.EditValue = Nothing

                End If

                If ((value IsNot Nothing OrElse value <> Nothing) AndAlso Me.HasASelectedValue = False AndAlso _AddInactiveItemsOnSelectedValue) Then

                    RaiseEvent SetInactiveValue(value)

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
                _BypassUserEntryChanged = value
            End Set
        End Property
        Public Property ActiveFilterString As String
            Get
                ActiveFilterString = _ActiveFilterString
            End Get
            Set(ByVal value As String)
                _ActiveFilterString = value
                _ActiveFilterEnabled = True
            End Set
        End Property
        Public WriteOnly Property HideValueMemberColumn As Boolean
            Set(value As Boolean)
                _HideValueMemberColumn = value
            End Set
        End Property
        Public WriteOnly Property UseAlternateView As Boolean
            Set(value As Boolean)
                _UseAlternateView = value
            End Set
        End Property
        Public Shadows Property Enabled As Boolean
            Get
                Enabled = MyBase.Enabled
            End Get
            Set(value As Boolean)

                If _SecurityEnabled Then

                    MyBase.Enabled = value

                Else

                    MyBase.Enabled = False

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
        Public Property AutoFillMode As Boolean
            Get
                AutoFillMode = _AutoFillMode
            End Get
            Set(value As Boolean)
                _AutoFillMode = value
            End Set
        End Property
        Public Overrides Property EnterMoveNextControl As Boolean
            Get
                Return _TabOnEnter
            End Get
            Set(value As Boolean)
                _TabOnEnter = value
            End Set
        End Property
        Public Overloads Property [ReadOnly] As Boolean
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

#End Region

#Region " Methods "

        Public Sub New()

            Me.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.Properties.PopupSizeable = True

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
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
        Public Sub SetPropertySettings(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If PropertyDescriptor IsNot Nothing Then

                _DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)
                _EntityDataType = PropertyDescriptor.PropertyType

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        SetRequired(EntityAttribute.IsRequired)

                    End If

                End Try

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

                Me.Properties.Appearance.BackColor = Drawing.Color.Cyan

            Else

                Me.Properties.Appearance.BackColor = Drawing.Color.White

            End If

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

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

            Me.Properties.View.Columns.Clear()

            Select Case _ControlType

                Case GridLookUpEdit.Type.Default

                    Me.Properties.ValueMember = ""
                    Me.Properties.DisplayMember = ""
                    Me.Properties.NullText = ""

                Case GridLookUpEdit.Type.Market

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Market"

                Case GridLookUpEdit.Type.PostPeriod

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Post Period"

                Case GridLookUpEdit.Type.EnumObjects

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select"

                Case GridLookUpEdit.Type.NielsenStation

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Station"

                Case GridLookUpEdit.Type.BroadcastType

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Media"

                Case GridLookUpEdit.Type.RatingsService

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Service"

                Case GridLookUpEdit.Type.MediaMarketBreak

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Market Break"

                Case GridLookUpEdit.Type.NielsenRadioReportType

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Report Type"

                Case GridLookUpEdit.Type.NielsenRadioPeriod

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Period"

                Case GridLookUpEdit.Type.NielsenRadioMarket

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Number"
                    Me.Properties.NullText = "Select Market"

                Case GridLookUpEdit.Type.NielsenRadioQualitative

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Qualitative"

                Case GridLookUpEdit.Type.NielsenRadioDaypart

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Daypart"

                Case GridLookUpEdit.Type.NielsenRadioStation

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ComboID"
                    Me.Properties.NullText = "Select Station"

                Case GridLookUpEdit.Type.MediaDemographic

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Demographic"

                Case GridLookUpEdit.Type.Client

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Client"

                Case GridLookUpEdit.Type.Vendor

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Vendor"

                Case GridLookUpEdit.Type.CurrencyCode

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Currency"

                Case GridLookUpEdit.Type.NielsenRadioCounty

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "CountyCode"
                    Me.Properties.NullText = "Select County"

                Case GridLookUpEdit.Type.MarketBreak

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Category"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Market Break"

            End Select

        End Sub
        Protected Sub LoadDataSource(ByRef Value As Object)

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If Me.DesignMode = False Then

                LoadBookmarks()

                BindingSource = New System.Windows.Forms.BindingSource

                If _UseAlternateView = True Then

                    BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceAlternateView(Value)

                Else

                    BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Value)

                End If

                If Value IsNot Nothing Then

                    _HasValidDataSource = True

                    If _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                        If Me.Properties.DisplayMember = "" Then

                            Me.SetControlType()

                        End If

                        LoadExtraComboItem(_ExtraComboBoxItem, BindingSource)

                    End If

                Else

                    _HasValidDataSource = False

                End If

                MyBase.Properties.DataSource = BindingSource

                MyBase.Properties.View.BestFitColumns()

                SetBookmarks()

                If Me.Properties.DisplayMember = "" Then

                    Me.SetControlType()

                End If

                Me.ClearChanged()

                RaiseEvent DataSourceChangedEvent()

            End If

        End Sub
        Protected Sub LoadExtraComboItem(ByVal ExtraComboItem As ExtraComboBoxItems, ByRef BindingSource As System.Windows.Forms.BindingSource)

            If ExtraComboBoxItem = ExtraComboBoxItems.AgencyDefault Then

                AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.Properties.DisplayMember, Me.Properties.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", Nothing, True, True, _AddedItemsToDataSource)

            Else

                AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.Properties.DisplayMember, Me.Properties.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", AdvantageFramework.EnumUtilities.GetValue(ExtraComboItem.GetType, ExtraComboItem.ToString), True, True, _AddedItemsToDataSource)

            End If

            Me.Properties.NullText = "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]"

        End Sub
        Public Sub AddComboItemToExistingDataSource(ByVal DisplayValue As String, ByVal Value As String, ByVal InsertInFirstPosition As Boolean)

            AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(Me.DataSource, Me.Properties.DisplayMember, Me.Properties.ValueMember, DisplayValue, Value, InsertInFirstPosition, False, _AddedItemsToDataSource)

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

                            ErrorMessage = AdvantageFramework.StringUtilities.GetNameAsWords(_ControlType.ToString) & " is required."

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
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.All.ToString) & "]" AndAlso
                                Me.Text <> Me.Properties.NullText Then

                    If _DisplayName = "" Then

                        ErrorMessage = "Please select a valid " & AdvantageFramework.StringUtilities.GetNameAsWords(_ControlType.ToString)

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
                Me.EditValue IsNot Nothing Then

                _CurrentBookmark = Me.EditValue

            Else

                _CurrentBookmark = Nothing

            End If

        End Sub
        Protected Sub SetBookmarks()

            If _BookmarkingEnabled AndAlso _CurrentBookmark IsNot Nothing Then

                Me.EditValue = _CurrentBookmark

            End If

        End Sub
        Public Function HasASelectedValue() As Boolean

            'objects
            Dim DoesHaveASelectedValue As Boolean = False

            If Me.EditValue IsNot Nothing Then ' Me.Properties.View.FocusedRowHandle > -1 Then

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

                    ElseIf Me.ExtraComboBoxItem = ExtraComboBoxItems.All Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.All) Then

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
        Public Function GetSelectedRowCellValue(ByVal FieldName As String) As Object

            'objects
            Dim RowCellValue As Object = Nothing

            If Me.HasASelectedValue Then

                For RowHandle = 0 To Me.Properties.View.RowCount - 1

                    Try

                        If Me.Properties.View.GetRowCellValue(RowHandle, Me.Properties.ValueMember.ToString) = Me.GetSelectedValue Then

                            If Me.Properties.View.Columns(FieldName) IsNot Nothing Then

                                RowCellValue = Me.Properties.View.GetRowCellValue(RowHandle, FieldName)
                                Exit For

                            End If

                        End If

                    Catch ex As Exception
                        RowCellValue = Nothing
                    End Try

                Next

            End If

            GetSelectedRowCellValue = RowCellValue

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
        Public Function SelectSingleItemDataSource() As Boolean

            'objects
            Dim Selected As Boolean = False
            Dim RowCount As Integer = Nothing
            Dim DataSource As IEnumerable = Nothing
            Dim SelectedItem As Object = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                If Me.DataSource IsNot Nothing Then

                    If TypeOf Me.DataSource Is System.Windows.Forms.BindingSource Then

                        Try

                            DataSource = DirectCast(DirectCast(Me.DataSource, System.Windows.Forms.BindingSource).DataSource, IEnumerable)

                        Catch ex As Exception
                            DataSource = Nothing
                        End Try

                        If DataSource IsNot Nothing Then

                            RowCount = (From Item In DataSource
                                        Select Item).Count

                            If RowCount = 2 AndAlso Me.ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                                Try

                                    PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties((From Item In DataSource Select Item).FirstOrDefault).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = Me.Properties.ValueMember).SingleOrDefault

                                Catch ex As Exception
                                    PropertyDescriptor = Nothing
                                End Try

                                If PropertyDescriptor IsNot Nothing Then

                                    For Each Item In DataSource

                                        If Not (IsNumeric(PropertyDescriptor.GetValue(Item)) AndAlso PropertyDescriptor.GetValue(Item) = Me.ExtraComboBoxItem) Then

                                            SelectedItem = Item
                                            Exit For

                                        End If

                                    Next

                                End If

                            ElseIf RowCount = 1 AndAlso Me.ExtraComboBoxItem = ExtraComboBoxItems.Nothing Then

                                SelectedItem = (From Item In DataSource
                                                Select Item).SingleOrDefault

                                Try

                                    PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(SelectedItem).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = Me.Properties.ValueMember).SingleOrDefault

                                Catch ex As Exception
                                    PropertyDescriptor = Nothing
                                End Try

                            End If

                            If PropertyDescriptor IsNot Nothing Then

                                Me.Properties.View.ClearSelection()
                                Me.SelectedValue = PropertyDescriptor.GetValue(SelectedItem)
                                Selected = True

                            End If

                        End If

                    End If

                End If

                'If Me.Properties.View.RowCount = 2 AndAlso Me.ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                '    Me.Properties.View.SelectRow(1)
                '    Selected = True

                'ElseIf Me.Properties.View.RowCount = 1 AndAlso Me.ExtraComboBoxItem = ExtraComboBoxItems.Nothing Then

                '    Me.Properties.View.SelectRow(0)
                '    Selected = True

                'End If

            Catch ex As Exception
                Selected = False
            Finally
                SelectSingleItemDataSource = Selected
            End Try

        End Function
        Protected Overrides Sub OnKeyDown(e As Windows.Forms.KeyEventArgs)

            If _TabOnEnter Then

                If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

                    Me.FindForm.SelectNextControl(Me, False, True, True, True)

                End If

            End If

            MyBase.OnKeyDown(e)

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
        Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)

            MyBase.OnEnabledChanged(e)

            ShowControl()

        End Sub
        Protected Overrides Sub OnParentChanged(ByVal e As System.EventArgs)

            MyBase.OnParentChanged(e)

            If Parent IsNot Nothing Then

                AddTextbox()
                _TextBox.Parent = Me.Parent

            End If

        End Sub
        Protected Overrides Sub OnEditValueChanged()

            MyBase.OnEditValueChanged()

            If Me.EditValue Is Nothing Then

                _TextBox.Clear()

            Else

                _TextBox.Text = Me.Text

            End If

        End Sub

#Region "  Control Event Handlers "

        Private Sub ModifyRepositoryItems()

            For Each GridColumn In MyBase.Properties.View.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                If GridColumn.RealColumnEdit IsNot Nothing Then

                    If TypeOf GridColumn.RealColumnEdit Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Then

                        DirectCast(GridColumn.RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).DisplayValueChecked = "Yes"
                        DirectCast(GridColumn.RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).DisplayValueUnchecked = "No"
                        DirectCast(GridColumn.RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).DisplayValueGrayed = "No"

                    End If

                End If

            Next

        End Sub
        Private Sub GridLookUpEdit_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles Me.CloseUp

            If e.Value IsNot Nothing AndAlso
               IsNumeric(e.Value) AndAlso
               CDbl(e.Value) < 0 AndAlso e.Value.ToString.StartsWith("-") = True Then

                e.Value = Nothing

            End If

        End Sub
        Private Sub GridLookUpEdit_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles Me.CustomDisplayText

            If e.Value IsNot Nothing Then

                If _HideValueMemberColumn Then

                    e.DisplayText = e.DisplayText

                Else

                    If Me.Properties.DisplayMember <> Me.Properties.ValueMember Then

                        e.DisplayText = e.Value & " - " & e.DisplayText

                    End If

                End If

            ElseIf e.Value Is Nothing AndAlso _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                Select Case _ExtraComboBoxItem

                    Case ExtraComboBoxItems.Nothing


                    Case ExtraComboBoxItems.None

                        e.DisplayText = ""

                    Case Else

                        e.DisplayText = "[" & AdvantageFramework.StringUtilities.GetNameAsWords(_ExtraComboBoxItem.ToString) & "]"

                End Select

            End If

        End Sub
        Private Sub GridLookUpEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EditValueChanged

            If _BypassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.MVC.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        Private Sub GridLookUpEdit_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

            'If DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow IsNot Nothing AndAlso DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls.Count > 2 Then

            '    'RemoveHandler DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.TextChanged, AddressOf TextBox_TextChanged

            'End If

            RemoveHandler Me.Properties.View.CustomRowFilter, AddressOf GridView_CustomRowFilter
            RemoveHandler Me.Properties.View.RowClick, AddressOf GridView_RowClick
            RemoveHandler Me.Properties.View.RowCountChanged, AddressOf GridView_RowCountChanged
            'RemoveHandler Me.Properties.View.ShowFilterPopupListBox, AddressOf GridView_ShowFilterPopupListBox

            MyBase.Dispose()

        End Sub
        Private Sub GridLookUpEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Popup

            'objects
            Dim TextBoxText As String = Nothing

            If IsNothing(MyBase.EditValue) = False AndAlso MyBase.EditValue.ToString <> "" Then

                If _HideValueMemberColumn = True Then

                    TextBoxText = Me.Properties.View.GetFocusedRowCellValue(Me.Properties.View.VisibleColumns(0)).ToString

                Else

                    TextBoxText = MyBase.EditValue

                End If

                If String.IsNullOrEmpty(_ActiveFilterString) = False Then

                    TextBoxText = ""

                    If _ActiveFilterEnabled Then

                        Me.Properties.View.ApplyColumnsFilter()

                    End If

                End If

                'DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.Text = TextBoxText
                'DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.SelectAll()
                'DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.Focus()

                _ShowAllRowsOnInitialSearch = True

                'AddHandler DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.TextChanged, AddressOf TextBox_TextChanged

            End If

        End Sub
        Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)

            _ShowAllRowsOnInitialSearch = False

        End Sub
        Private Sub GridLookUpEdit_PropertiesChanged(sender As Object, e As EventArgs) Handles Me.PropertiesChanged

            AddHandler Me.Properties.View.CustomRowFilter, AddressOf GridView_CustomRowFilter
            AddHandler Me.Properties.View.RowClick, AddressOf GridView_RowClick
            AddHandler Me.Properties.View.RowCountChanged, AddressOf GridView_RowCountChanged

            If TypeOf Me.Properties.View Is AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView Then

                Try

                    DirectCast(Me.Properties.View, AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView).IsInGridLookupEditControl = True

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub GridLookUpEdit_QueryCloseUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.QueryCloseUp

            _ActiveFilterString = MyBase.Properties.View.ActiveFilterString
            _ActiveFilterEnabled = MyBase.Properties.View.ActiveFilterEnabled

        End Sub
        Private Sub GridLookUpEdit_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.QueryPopUp

            'objects
            Dim ColumnsToHide As String() = Nothing

            If Not Me.Properties.ReadOnly Then

                If ColumnsToHide IsNot Nothing AndAlso ColumnsToHide.Count > 0 Then

                    For Each ColumnToHide In ColumnsToHide

                        If Me.Properties.View.Columns(ColumnToHide) IsNot Nothing Then

                            Me.Properties.View.Columns(ColumnToHide).Visible = False

                        End If

                    Next

                End If

                If Me.Properties.View.Columns(Me.Properties.ValueMember) IsNot Nothing Then

                    Me.Properties.View.Columns(Me.Properties.ValueMember).Visible = Not _HideValueMemberColumn

                End If

                MyBase.Properties.View.BestFitColumns()

                ModifyRepositoryItems()

                If Not _HasValidDataSource Then

                    RaiseEvent QueryPopupNeedDataSource(_HasValidDataSource)

                End If

                MyBase.Properties.View.ActiveFilterString = _ActiveFilterString
                MyBase.Properties.View.ActiveFilterEnabled = _ActiveFilterEnabled

            End If

        End Sub
        Private Sub GridView_CustomRowFilter(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs)

            If _ShowAllRowsOnInitialSearch Then

                e.Visible = True

                If _ActiveFilterEnabled = False OrElse String.IsNullOrEmpty(_ActiveFilterString) Then

                    e.Handled = True

                End If

            End If

        End Sub
        Private Sub GridView_RowClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)

            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

            Try

                If e.Button = Windows.Forms.MouseButtons.Left Then

                    If e.Clicks = 2 Then

                        GridHitInfo = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).CalcHitInfo(e.Location)

                        If GridHitInfo.InRowCell Then

                            If DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).IsRowSelected(GridHitInfo.RowHandle) = False Then

                                DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).ClearSelection()

                                DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).SelectRow(GridHitInfo.RowHandle)

                            End If

                            Me.ClosePopup()

                            e.Handled = True

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub GridView_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            If TypeOf (sender) Is AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView Then

                If DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView).RowCount = 1 AndAlso
                        Me.Properties.View.IsRowVisible(Me.Properties.View.FocusedRowHandle) = DevExpress.XtraGrid.Views.Grid.RowVisibleState.Visible Then

                    DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView).Focus()

                    DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).SelectRow(DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView).FocusedRowHandle)

                    Me.ClosePopup()

                End If

            End If

        End Sub
        Private Sub GridLookUpEdit_Resize(sender As Object, e As EventArgs) Handles Me.Resize

            If _TextBox IsNot Nothing Then

                _TextBox.Width = Me.Width

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
