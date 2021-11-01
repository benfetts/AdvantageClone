Namespace WinForm.Presentation.Controls

    Public Class PropertyGridControl
        Inherits DevExpress.XtraVerticalGrid.PropertyGridControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

        Public Event QueryPopupNeedDatasource(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)
        Public Event SubItemTextBoxButtonClickEvent(ByVal SelectedObject As Object)

#Region " Constants "


#End Region

#Region " Enum "

        Public Enum ControlTypes
            [Default]
            ImportTemplate
            Editable
            NonEditable
            ExportTemplate
            AutoFill
        End Enum

#End Region

#Region " Variables "

        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _FormSettingsLoaded As Boolean = False
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _ControlType As WinForm.Presentation.Controls.PropertyGridControl.ControlTypes = ControlTypes.Default
        Protected _AutoloadRepositoryDatasource As Boolean = True
        Protected _AutoFilterLookupColumns As Boolean = False
        Protected _ObjectType As System.Type = Nothing
        Protected _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Protected _IsAutoFilling As Boolean = False
        Protected _AllowExtraItemsInGridLookupEdits As Boolean = True

#End Region

#Region " Properties "

        Public Property AllowExtraItemsInGridLookupEdits As Boolean
            Get
                AllowExtraItemsInGridLookupEdits = _AllowExtraItemsInGridLookupEdits
            End Get
            Set(value As Boolean)
                _AllowExtraItemsInGridLookupEdits = value
            End Set
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get
                UserEntryChanged = _UserEntryChanged
            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)
                _ByPassUserEntryChanged = value
            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Friend Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public Shadows Property SelectedObject As Object
            Get
                SelectedObject = MyBase.SelectedObject
            End Get
            Set(ByVal value As Object)
                MyBase.SelectedObject = value
                LoadSelectedObject()
            End Set
        End Property
        Public Shadows Property ControlType As WinForm.Presentation.Controls.PropertyGridControl.ControlTypes
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As WinForm.Presentation.Controls.PropertyGridControl.ControlTypes)
                _ControlType = value
                SetupPropertyGridViewControl()
            End Set
        End Property
        Public Property AutoloadRepositoryDatasource As Boolean
            Get
                AutoloadRepositoryDatasource = _AutoloadRepositoryDatasource
            End Get
            Set(ByVal value As Boolean)
                _AutoloadRepositoryDatasource = value
            End Set
        End Property
        Public Property AutoFilterLookupColumns As Boolean
            Get
                AutoFilterLookupColumns = _AutoFilterLookupColumns
            End Get
            Set(ByVal value As Boolean)
                _AutoFilterLookupColumns = value
            End Set
        End Property
        Public Property ObjectType As System.Type
            Get
                ObjectType = _ObjectType
            End Get
            Set(ByVal value As System.Type)

                _ObjectType = value

                If _ObjectType IsNot Nothing Then

                    _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(_ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                End If

            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8)
            Me.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8)

            Me.OptionsView.ShowRootCategories = False
            Me.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort

            ' Add any initialization after the InitializeComponent() call.
            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub SetupPropertyGridViewControl()

            Me.Rows.Clear()

            ModifyBehaviorOptions()
            ModifyCustomizationOptions()
            ModifyFilterOptions()
            ModifyLayoutOptions()
            ModifyMenuOptions()
            ModifySelectionOptions()
            ModifyViewOptions()
            ModifyNavigationOptions()

        End Sub
        Protected Sub ModifyBehaviorOptions()

            Select Case _ControlType

                Case ControlTypes.Default

                    Me.OptionsBehavior.Editable = False

                Case ControlTypes.Editable

                    Me.OptionsBehavior.Editable = True

                Case ControlTypes.ImportTemplate, ControlTypes.ExportTemplate, ControlTypes.AutoFill

                    Me.OptionsBehavior.Editable = True

                Case ControlTypes.NonEditable

                    Me.OptionsBehavior.Editable = False

            End Select

        End Sub
        Protected Sub ModifyCustomizationOptions()

            Select Case _ControlType

                Case ControlTypes.Default


                Case ControlTypes.Editable


                Case ControlTypes.ImportTemplate, ControlTypes.ExportTemplate, ControlTypes.AutoFill


                Case ControlTypes.NonEditable


            End Select

        End Sub
        Protected Sub ModifyFilterOptions()

            Select Case _ControlType

                Case ControlTypes.Default


                Case ControlTypes.Editable


                Case ControlTypes.ImportTemplate, ControlTypes.ExportTemplate, ControlTypes.AutoFill


                Case ControlTypes.NonEditable


            End Select

        End Sub
        Protected Sub ModifyLayoutOptions()

            Select Case _ControlType

                Case ControlTypes.Default


                Case ControlTypes.Editable


                Case ControlTypes.ImportTemplate, ControlTypes.ExportTemplate, ControlTypes.AutoFill


                Case ControlTypes.NonEditable


            End Select

        End Sub
        Protected Sub ModifyMenuOptions()

            Select Case _ControlType

                Case ControlTypes.Default


                Case ControlTypes.Editable


                Case ControlTypes.ImportTemplate, ControlTypes.ExportTemplate, ControlTypes.AutoFill


                Case ControlTypes.NonEditable


            End Select

        End Sub
        Protected Sub ModifySelectionOptions()

            Select Case _ControlType

                Case ControlTypes.Default


                Case ControlTypes.Editable


                Case ControlTypes.ImportTemplate, ControlTypes.ExportTemplate, ControlTypes.AutoFill


                Case ControlTypes.NonEditable


            End Select

        End Sub
        Protected Sub ModifyViewOptions()

            Select Case _ControlType

                Case ControlTypes.Default


                Case ControlTypes.Editable


                Case ControlTypes.ImportTemplate, ControlTypes.ExportTemplate, ControlTypes.AutoFill


                Case ControlTypes.NonEditable


            End Select

        End Sub
        Protected Sub ModifyNavigationOptions()

            Select Case _ControlType

                Case ControlTypes.Default


                Case ControlTypes.Editable


                Case ControlTypes.ImportTemplate, ControlTypes.ExportTemplate, ControlTypes.AutoFill


                Case ControlTypes.NonEditable


            End Select

        End Sub
        Protected Sub LoadSelectedObject()

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            If Me.SelectedObject IsNot Nothing Then

                If Me.ObjectType Is Nothing Then

                    Me.ObjectType = Me.SelectedObject.GetType

                End If

                For Each PropertyDescriptor In _ObjectTypePropertyDescriptors

                    Try

                        BaseRow = Me.GetRowByFieldName(PropertyDescriptor.Name)

                    Catch ex As Exception
                        BaseRow = Nothing
                    End Try

                    If BaseRow IsNot Nothing Then

                        BaseRow.Appearance.Font = New System.Drawing.Font("Arial", 8)
                        BaseRow.HeaderInfo.Style.Font = New System.Drawing.Font("Arial", 8)

                        BaseRow.Properties.ReadOnly = PropertyDescriptor.IsReadOnly

                        Try

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                        Catch ex As Exception
                            EntityAttribute = Nothing
                        End Try

                        If EntityAttribute IsNot Nothing Then

                            If EntityAttribute.DisplayFormat <> "" Then

                                If EntityAttribute.DisplayFormat.StartsWith("c") OrElse EntityAttribute.DisplayFormat.StartsWith("n") Then

                                    BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric

                                ElseIf EntityAttribute.DisplayFormat.StartsWith("d") Then

                                    BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.DateTime

                                End If

                                BaseRow.Properties.Format.FormatString = EntityAttribute.DisplayFormat

                            End If

                            If PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DisplayNameAttribute).Any = False Then

                                If EntityAttribute.CustomColumnCaption <> "" Then

                                    BaseRow.Properties.Caption = EntityAttribute.CustomColumnCaption

                                Else

                                    BaseRow.Properties.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

                                End If

                            End If

                            If EntityAttribute.PropertyType <> BaseClasses.PropertyTypes.Default Then

                                Select Case EntityAttribute.PropertyType

                                    Case BaseClasses.PropertyTypes.ClientCode, BaseClasses.PropertyTypes.DivisionCode, _
                                         BaseClasses.PropertyTypes.ProductCode, BaseClasses.PropertyTypes.FunctionCode

                                        BaseRow.Properties.Caption = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.BaseClasses.PropertyTypes), CLng(EntityAttribute.PropertyType)).Replace("Code", "")

                                End Select

                            End If

                            BaseRow.Properties.ReadOnly = EntityAttribute.IsReadOnlyColumn
                            BaseRow.Visible = EntityAttribute.ShowColumnInGrid
                            BaseRow.OptionsRow.AllowMoveToCustomizationForm = EntityAttribute.ShowColumnInGrid
                            BaseRow.OptionsRow.ShowInCustomizationForm = EntityAttribute.ShowColumnInGrid

                        Else

                            If PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DisplayNameAttribute).Any = False Then

                                BaseRow.Properties.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

                            End If

                        End If

                        If _ControlType = ControlTypes.Editable OrElse _ControlType = ControlTypes.ImportTemplate OrElse _ControlType = ControlTypes.ExportTemplate OrElse _ControlType = ControlTypes.AutoFill Then

                            If Me.SelectedObject.GetType Is GetType(AdvantageFramework.Exporting.DataFilterClasses.AccountPayable) AndAlso PropertyDescriptor.Name = AdvantageFramework.Exporting.DataFilterClasses.AccountPayable.Properties.SelectByEntryOrInvoiceDate.ToString Then

                                AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl.Type.EnumObject, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Exporting.DataFilterClasses.AccountPayable.EntryDateOrInvoiceDate))

                            ElseIf Me.SelectedObject.GetType Is GetType(AdvantageFramework.Exporting.DataFilterClasses.AccountPayableAnswersOnDemand) AndAlso PropertyDescriptor.Name = AdvantageFramework.Exporting.DataFilterClasses.AccountPayableAnswersOnDemand.Properties.SelectByEntryOrInvoiceDate.ToString Then

                                AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl.Type.EnumObject, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Exporting.DataFilterClasses.AccountPayableAnswersOnDemand.EntryDateOrInvoiceDate))

                            ElseIf Me.SelectedObject.GetType Is GetType(AdvantageFramework.Exporting.DataFilterClasses.AccountPayableCustom1) AndAlso PropertyDescriptor.Name = AdvantageFramework.Exporting.DataFilterClasses.AccountPayableCustom1.Properties.SelectByEntryOrInvoiceOrExportDate.ToString Then

                                AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl.Type.EnumObject, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Exporting.DataFilterClasses.AccountPayableCustom1.EntryInvoiceExportDate))

                            ElseIf Me.SelectedObject.GetType Is GetType(AdvantageFramework.Exporting.DataFilterClasses.PurchaseOrder) AndAlso PropertyDescriptor.Name = AdvantageFramework.Exporting.DataFilterClasses.PurchaseOrder.Properties.SelectByDate.ToString Then

                                AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl.Type.EnumObject, EntityAttribute, PropertyDescriptor, GetType(AdvantageFramework.Exporting.DataFilterClasses.PurchaseOrder.SelectByDates))

                            ElseIf Me.SelectedObject.GetType Is GetType(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) AndAlso PropertyDescriptor.Name = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString Then

                                AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumberAutoFill, EntityAttribute, PropertyDescriptor)

                            ElseIf Me.SelectedObject.GetType Is GetType(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine) AndAlso
                                    (PropertyDescriptor.Name = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartDate.ToString OrElse PropertyDescriptor.Name = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndDate.ToString) Then

                                AddSubItemDateEdit(BaseRow, SubItemDateInput.Type.Broadcast)

                            ElseIf Me.SelectedObject.GetType.BaseType Is GetType(AdvantageFramework.Database.Entities.Market) AndAlso PropertyDescriptor.Name = AdvantageFramework.Database.Entities.Market.Properties.CountryID.ToString Then

                                AddSubItemGridLookupEdit(BaseRow)

                            Else

                                AddSubItem(BaseRow, PropertyDescriptor, EntityAttribute)

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Protected Sub AddSubItem(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            'objects
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = Nothing
            Dim DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes = Nothing

            Try

                PropertyType = EntityAttribute.PropertyType

            Catch ex As Exception
                PropertyType = BaseClasses.PropertyTypes.Default
            End Try

            Try

                DefaultColumnType = EntityAttribute.DefaultColumnType

            Catch ex As Exception
                DefaultColumnType = BaseClasses.DefaultColumnTypes.None
            End Try

            If PropertyType <> BaseClasses.PropertyTypes.Default Then

                AddSubItemByPropertyTypeAttribute(BaseRow, PropertyType, PropertyDescriptor, EntityAttribute)

            ElseIf DefaultColumnType <> BaseClasses.DefaultColumnTypes.None Then

                AddSubItemByDefaultColumnTypeAttribute(BaseRow, DefaultColumnType, PropertyDescriptor, EntityAttribute)

            Else

                AddDefaultSubItem(BaseRow, PropertyDescriptor)

            End If

        End Sub
        Protected Sub AddSubItemByDefaultColumnTypeAttribute(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            Select Case DefaultColumnType

                'Case BaseClasses.DefaultColumnTypes.JobComponentDescription

                '    AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl.Type.JobComponentDescription, EntityAttribute, PropertyDescriptor)

                'Case BaseClasses.DefaultColumnTypes.JobDescription

                '    AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl.Type.JobDescription, EntityAttribute, PropertyDescriptor)

                Case BaseClasses.DefaultColumnTypes.Memo

                    AddSubItemMemoEdit(BaseRow, PropertyDescriptor)

                Case Else

                    AddSubItemByDefaultColumnTypeAttribute(BaseRow, DefaultColumnType, PropertyDescriptor.PropertyType)

            End Select

        End Sub
        Protected Sub AddSubItemByDefaultColumnTypeAttribute(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes, ByVal ValueType As System.Type)

            Select Case DefaultColumnType

                Case BaseClasses.DefaultColumnTypes.ReversedCheckBox

                    AddSubItemCheckBox(BaseRow, True, ValueType)

                Case BaseClasses.DefaultColumnTypes.StandardCheckBox

                    AddSubItemCheckBox(BaseRow, False, ValueType)

                Case BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox

                    AddSubItemImageCheckBox(BaseRow, True, SubItemImageCheckEditControl.Type.ImageWhenChecked)

                Case BaseClasses.DefaultColumnTypes.ColorPicker

                    AddSubItemColorPicker(BaseRow)

                Case BaseClasses.DefaultColumnTypes.HyperLink

                    AddSubItemHyperLink(BaseRow)

                Case Else

                    AddDefaultSubItem(BaseRow, ValueType, Nothing)

            End Select

        End Sub
        Protected Function AddCustomSubItem(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, _
                                            ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, _
                                            ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, _
                                            ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute) As Boolean

            'Objects
            Dim Added As Boolean = False

            Try



            Catch ex As Exception
                Added = True
            Finally
                AddCustomSubItem = False
            End Try

        End Function
        Protected Sub AddSubItemByPropertyTypeAttribute(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, _
                                                        ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, _
                                                        ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, _
                                                        ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim FormatString As String = ""

            If AddCustomSubItem(BaseRow, PropertyType, PropertyDescriptor, EntityAttribute) = False Then

                If BaseRow.Properties.Format.FormatString IsNot Nothing Then

                    FormatString = BaseRow.Properties.Format.FormatString

                End If

                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemByPropertyTypeAttribute(_Session, BaseRow.Properties.FieldName, PropertyType, PropertyDescriptor, EntityAttribute, _ObjectType, FormatString, _AllowExtraItemsInGridLookupEdits)

                If RepositoryItem IsNot Nothing Then

                    AddSubItemToBaseRow(BaseRow, RepositoryItem)

                End If

            End If

        End Sub
        Protected Sub AddSubItemToBaseRow(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem)

            If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                AddSubItemGridLookupEdit(BaseRow, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemComboBox Then

                AddSubItemComboBox(BaseRow, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox Then

                AddSubItemTextBox(BaseRow, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput Then

                AddSubItemDateEdit(BaseRow, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox Then

                AddSubItemImageComboBox(BaseRow, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                AddSubItemNumericInput(BaseRow, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit Then

                AddSubItemMemoEdit(BaseRow, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit Then

                AddSubItemTimeEdit(BaseRow, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemColorEdit Then

                AddSubItemColorPicker(BaseRow, RepositoryItem)

            ElseIf TypeOf RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Then

                AddSubItemCheckBox(BaseRow, RepositoryItem)

            Else

                Me.RepositoryItems.Add(RepositoryItem)
                BaseRow.Properties.RowEdit = RepositoryItem

            End If

        End Sub
        Private Sub AddDefaultSubItem(ByVal BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Try

                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

            Catch ex As Exception
                EntityAttribute = Nothing
            End Try

            AddDefaultSubItem(BaseRow, PropertyDescriptor.PropertyType, EntityAttribute)

        End Sub
        Private Sub AddDefaultSubItem(ByVal BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal PropertyType As System.Type, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            If PropertyType Is GetType(String) Then

                If TypeOf Me.SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail AndAlso BaseRow.Properties.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ClientPO.ToString Then

                    AddSubItemTextBox(BaseRow, Presentation.Controls.SubItemTextBox.Type.ClientPO)

                ElseIf TypeOf Me.SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail AndAlso BaseRow.Properties.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdNumber.ToString Then

                    AddSubItemTextBox(BaseRow, Presentation.Controls.SubItemTextBox.Type.AdNumber)

                ElseIf TypeOf Me.SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail AndAlso BaseRow.Properties.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString Then

                    AddSubItemTextBox(BaseRow, Presentation.Controls.SubItemTextBox.Type.AdSizeCode)

                Else

                    AddSubItemTextBox(BaseRow, Presentation.Controls.SubItemTextBox.Type.Default)

                End If

            ElseIf PropertyType Is GetType(Decimal) Then

                AddSubItemNumericInput(BaseRow, SubItemNumericInput.Type.Decimal, False, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Decimal)) Then

                AddSubItemNumericInput(BaseRow, SubItemNumericInput.Type.Decimal, True, EntityAttribute)

            ElseIf PropertyType Is GetType(Long) Then

                AddSubItemNumericInput(BaseRow, SubItemNumericInput.Type.Long, False, EntityAttribute)

            ElseIf PropertyType Is GetType(Integer) Then

                AddSubItemNumericInput(BaseRow, SubItemNumericInput.Type.Integer, False, EntityAttribute)

            ElseIf PropertyType Is GetType(Short) Then

                AddSubItemNumericInput(BaseRow, SubItemNumericInput.Type.Short, False, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Long)) Then

                AddSubItemNumericInput(BaseRow, SubItemNumericInput.Type.Long, True, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Integer)) Then

                AddSubItemNumericInput(BaseRow, SubItemNumericInput.Type.Integer, True, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Short)) Then

                AddSubItemNumericInput(BaseRow, SubItemNumericInput.Type.Short, True, EntityAttribute)

            ElseIf PropertyType Is GetType(System.Nullable(Of Boolean)) OrElse _
                    PropertyType Is GetType(Boolean) Then

                AddSubItemCheckBox(BaseRow, False, GetType(Boolean))

            ElseIf PropertyType Is GetType(System.Nullable(Of Date)) OrElse _
                PropertyType Is GetType(Date) Then

                AddSubItemDateEdit(BaseRow, SubItemDateInput.Type.Default)

            End If

        End Sub
        Protected Sub AddSubItemMemoEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            Dim SubItemMemoEdit As AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit = Nothing

            SubItemMemoEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemMemoEdit(Session, BaseRow.Properties.FieldName, Me.SelectedObject.GetType)

            If SubItemMemoEdit IsNot Nothing Then

                AddSubItemMemoEdit(BaseRow, SubItemMemoEdit)

            End If

        End Sub
        Protected Sub AddSubItemMemoEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef SubItemMemoEdit As AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit)

            Me.RepositoryItems.Add(SubItemMemoEdit)

            BaseRow.Properties.RowEdit = SubItemMemoEdit

            AddHandler SubItemMemoEdit.Closed, AddressOf SubItemMemoEdit_Closed

        End Sub
        Private Sub SubItemMemoEdit_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs)

            If e.CloseMode = DevExpress.XtraEditors.PopupCloseMode.CloseUpKey Then

                Try

                    Me.FocusedRow = (From Row In Me.Rows.OfType(Of DevExpress.XtraVerticalGrid.Rows.BaseRow)()
                                     Where Row.VisibleIndex > Me.FocusedRow.VisibleIndex _
                                     Order By Row.VisibleIndex Ascending _
                                     Select Row).FirstOrDefault

                Catch ex As Exception

                End Try

            End If

        End Sub
        Protected Sub AddSubItemNumericInput(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal SubItemNumericInputType As Presentation.Controls.SubItemNumericInput.Type, ByVal IsNullable As Boolean, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            'objects
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing
            Dim FormatString As String = ""

            If BaseRow.Properties.Format IsNot Nothing Then

                FormatString = BaseRow.Properties.Format.FormatString

            End If

            SubItemNumericInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemNumericInput(_Session, SubItemNumericInputType, BaseRow.Properties.FieldName, FormatString, IsNullable, Me.SelectedObject.GetType, EntityAttribute)

            If SubItemNumericInput IsNot Nothing Then

                AddSubItemNumericInput(BaseRow, SubItemNumericInput)

            End If

        End Sub
        Protected Sub AddSubItemNumericInput(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput)

            Me.RepositoryItems.Add(SubItemNumericInput)

            BaseRow.Properties.RowEdit = SubItemNumericInput

        End Sub
        Protected Sub AddSubItemTextBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal SubItemTextBoxType As Presentation.Controls.SubItemTextBox.Type)

            'objects
            Dim SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox = Nothing

            SubItemTextBox = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemTextBox(Session, SubItemTextBoxType, BaseRow.Properties.FieldName, Me.SelectedObject.GetType)

            If SubItemTextBox IsNot Nothing Then

                AddSubItemTextBox(BaseRow, SubItemTextBox)

            End If

        End Sub
        Protected Sub AddSubItemTextBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox)

            Me.RepositoryItems.Add(SubItemTextBox)

            BaseRow.Properties.RowEdit = SubItemTextBox

            AddHandler SubItemTextBox.ButtonClick, AddressOf SubItemTextBox_ButtonClick

        End Sub
        Protected Sub AddSubItemGridLookupEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal SubItemComboBoxType As Presentation.Controls.SubItemGridLookUpEditControl.Type, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EnumType As System.Type)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            SubItemGridLookUpEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(_Session, SubItemComboBoxType, BaseRow.Properties.FieldName, EntityAttribute, PropertyDescriptor, EnumType, _AllowExtraItemsInGridLookupEdits)

            If SubItemGridLookUpEditControl IsNot Nothing Then

                AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl)

            End If

        End Sub
        Protected Sub AddSubItemGridLookupEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal SubItemComboBoxType As Presentation.Controls.SubItemGridLookUpEditControl.Type, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            SubItemGridLookUpEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(_Session, SubItemComboBoxType, BaseRow.Properties.FieldName, EntityAttribute, PropertyDescriptor, Nothing, _AllowExtraItemsInGridLookupEdits)

            If SubItemGridLookUpEditControl IsNot Nothing Then

                AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl)

            End If

        End Sub
        Protected Sub AddSubItemGridLookupEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

            If _AutoloadRepositoryDatasource Then

                SubItemGridLookUpEditControl.LoadDefaultDataSourceView()

            End If

            Me.RepositoryItems.Add(SubItemGridLookUpEditControl)

            BaseRow.Properties.RowEdit = SubItemGridLookUpEditControl

            AddHandler SubItemGridLookUpEditControl.EditValueChanged, AddressOf SubItemGridLookUpEditControl_EditValueChanged
            AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControl_QueryPopup

        End Sub
        Protected Sub AddSubItemDateEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ControlType As SubItemDateInput.Type)

            Dim SubItemDateInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput = Nothing

            SubItemDateInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput

            If SubItemDateInput IsNot Nothing Then

                SubItemDateInput.ControlType = ControlType

                If ControlType = SubItemDateInput.Type.Broadcast Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        SubItemDateInput.BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

                    End Using

                End If

                AddSubItemDateEdit(BaseRow, SubItemDateInput)

            End If

        End Sub
        Protected Sub AddSubItemDateEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef SubItemDateInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput)

            Me.RepositoryItems.Add(SubItemDateInput)

            BaseRow.Properties.RowEdit = SubItemDateInput

        End Sub
        Protected Sub AddSubItemCheckBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal IsReversedCheckBox As Boolean, ByVal PropertyType As System.Type)

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            RepositoryItemCheckEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(IsReversedCheckBox, PropertyType)

            If RepositoryItemCheckEdit IsNot Nothing Then

                AddSubItemCheckBox(BaseRow, RepositoryItemCheckEdit)

            End If

            Me.RepositoryItems.Add(RepositoryItemCheckEdit)

            BaseRow.Properties.RowEdit = RepositoryItemCheckEdit

        End Sub
        Protected Sub AddSubItemCheckBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit)

            Me.RepositoryItems.Add(RepositoryItemCheckEdit)

            BaseRow.Properties.RowEdit = RepositoryItemCheckEdit

        End Sub
        Protected Sub AddSubItemHyperLink(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow)

            Dim RepositoryItemHyperLinkEdit As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit = Nothing

            RepositoryItemHyperLinkEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemHyperLinkEdit()

            If RepositoryItemHyperLinkEdit IsNot Nothing Then

                AddSubItemHyperLink(BaseRow, RepositoryItemHyperLinkEdit)

            End If

        End Sub
        Protected Sub AddSubItemHyperLink(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef RepositoryItemHyperLinkEdit As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit)

            Me.RepositoryItems.Add(RepositoryItemHyperLinkEdit)

            BaseRow.Properties.RowEdit = RepositoryItemHyperLinkEdit

        End Sub
        Protected Sub AddSubItemColorPicker(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow)

            Dim RepositoryItemColorEdit As DevExpress.XtraEditors.Repository.RepositoryItemColorEdit = Nothing

            RepositoryItemColorEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemColorPicker()

            If RepositoryItemColorEdit IsNot Nothing Then

                AddSubItemColorPicker(BaseRow, RepositoryItemColorEdit)

            End If

        End Sub
        Protected Sub AddSubItemColorPicker(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef RepositoryItemColorEdit As DevExpress.XtraEditors.Repository.RepositoryItemColorEdit)

            RepositoryItemColorEdit.StoreColorAsInteger = True

            Me.RepositoryItems.Add(RepositoryItemColorEdit)

            BaseRow.Properties.RowEdit = RepositoryItemColorEdit

        End Sub
        Protected Sub AddSubItemImageCheckBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal IsReadOnly As Boolean, ByVal SubItemImageCheckEditControlType As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl.Type)

            Dim SubItemImageCheckEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl = Nothing

            SubItemImageCheckEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemImageCheckBox(IsReadOnly, SubItemImageCheckEditControlType, _ObjectType, BaseRow.Properties.FieldName)

            If SubItemImageCheckEditControl IsNot Nothing Then

                AddSubItemCheckBox(BaseRow, SubItemImageCheckEditControl)

            End If

        End Sub
        Protected Sub AddSubItemImageCheckBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef SubItemImageCheckEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageCheckEditControl)

            Me.RepositoryItems.Add(SubItemImageCheckEditControl)

            BaseRow.Properties.RowEdit = SubItemImageCheckEditControl

        End Sub
        Protected Sub AddSubItemComboBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal SubItemComboBoxType As Presentation.Controls.SubItemComboBox.Type)

            Dim SubItemComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemComboBox = Nothing

            SubItemComboBox = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemComboBox(_Session, SubItemComboBoxType)

            If SubItemComboBox IsNot Nothing Then

                AddSubItemComboBox(BaseRow, SubItemComboBox)

            End If

        End Sub
        Protected Sub AddSubItemComboBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef SubItemComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemComboBox)

            Me.RepositoryItems.Add(SubItemComboBox)

            BaseRow.Properties.RowEdit = SubItemComboBox

        End Sub
        Protected Sub AddSubItemImageComboBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal SubItemImageComboBoxType As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox.Type)

            Dim SubItemImageComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox = Nothing

            SubItemImageComboBox = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemImageComboBox(SubItemImageComboBoxType)

            If True Then

                AddSubItemImageComboBox(BaseRow, SubItemImageComboBox)

            End If

        End Sub
        Protected Sub AddSubItemImageComboBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef SubItemImageComboBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemImageComboBox)

            Me.RepositoryItems.Add(SubItemImageComboBox)

            BaseRow.Properties.RowEdit = SubItemImageComboBox

        End Sub
        Protected Sub AddSubItemTimeEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow)

            Dim SubItemTimeInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemTimeInput = Nothing

            SubItemTimeInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemTimeEdit(SubItemTimeInput.Type.Default)

            If SubItemTimeInput IsNot Nothing Then

                AddSubItemTimeEdit(BaseRow, SubItemTimeInput)

            End If

        End Sub
        Protected Sub AddSubItemTimeEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef SubItemTimeInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemTimeInput)

            Me.RepositoryItems.Add(SubItemTimeInput)

            BaseRow.Properties.RowEdit = SubItemTimeInput

        End Sub
        Private Sub SetSelectedObjectValueByPropertyType(ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes, ByVal Value As Object)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim NonNullableType As System.Type = Nothing

            Try

                PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(Me.SelectedObject).OfType(Of System.ComponentModel.PropertyDescriptor)() _
                                      Where [Property].Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Where(Function(Attribute) Attribute.PropertyType = PropertyType).Any _
                                      Select [Property]).SingleOrDefault

                If PropertyDescriptor IsNot Nothing Then

                    If Me.GetRowByFieldName(PropertyDescriptor.Name) IsNot Nothing AndAlso Me.GetRowByFieldName(PropertyDescriptor.Name).Visible Then

                        If Value IsNot Nothing Then

                            If [Nullable].GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                                NonNullableType = [Nullable].GetUnderlyingType(PropertyDescriptor.PropertyType)

                            Else

                                NonNullableType = PropertyDescriptor.PropertyType

                            End If

                            If Convert.ChangeType(Value, NonNullableType) <> PropertyDescriptor.GetValue(Me.SelectedObject) Then

                                Try

                                    PropertyDescriptor.SetValue(Me.SelectedObject, Convert.ChangeType(Value, NonNullableType))

                                Catch ex As Exception

                                End Try

                            End If

                        Else

                            Try

                                PropertyDescriptor.SetValue(Me.SelectedObject, Nothing)

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SetSelectedObjectValueByDefaultColumnType(ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes, ByVal Value As Object)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim NonNullableType As System.Type = Nothing

            Try

                PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(Me.SelectedObject).OfType(Of System.ComponentModel.PropertyDescriptor)() _
                                      Where [Property].Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Where(Function(Attribute) Attribute.DefaultColumnType = DefaultColumnType).Any _
                                      Select [Property]).SingleOrDefault

                If PropertyDescriptor IsNot Nothing Then

                    If Me.GetRowByFieldName(PropertyDescriptor.Name) IsNot Nothing AndAlso Me.GetRowByFieldName(PropertyDescriptor.Name).Visible Then

                        If Value IsNot Nothing Then

                            If [Nullable].GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                                NonNullableType = [Nullable].GetUnderlyingType(PropertyDescriptor.PropertyType)

                            Else

                                NonNullableType = PropertyDescriptor.PropertyType

                            End If

                            If Convert.ChangeType(Value, NonNullableType) <> PropertyDescriptor.GetValue(Me.SelectedObject) Then

                                Try

                                    PropertyDescriptor.SetValue(Me.SelectedObject, Convert.ChangeType(Value, NonNullableType))

                                Catch ex As Exception

                                End Try

                            End If

                        Else

                            Try

                                PropertyDescriptor.SetValue(Me.SelectedObject, Nothing)

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub FillSelectedObjectValues(ByVal Entity As Object)

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Try

                If TypeOf Entity Is AdvantageFramework.Database.Entities.Job Then

                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode, CType(Entity, AdvantageFramework.Database.Entities.Job).ClientCode)
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode, CType(Entity, AdvantageFramework.Database.Entities.Job).DivisionCode)
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, CType(Entity, AdvantageFramework.Database.Entities.Job).ProductCode)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobDescription, CType(Entity, AdvantageFramework.Database.Entities.Job).Description)

                    If CType(Entity, AdvantageFramework.Database.Entities.Job).JobComponents IsNot Nothing AndAlso CType(Entity, AdvantageFramework.Database.Entities.Job).JobComponents.Count = 1 Then

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponent, CType(Entity, AdvantageFramework.Database.Entities.Job).JobComponents.FirstOrDefault.Number)
                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponentID, CType(Entity, AdvantageFramework.Database.Entities.Job).JobComponents.FirstOrDefault.ID)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobComponentDescription, CType(Entity, AdvantageFramework.Database.Entities.Job).JobComponents.FirstOrDefault.Description)

                    End If

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.JobComponent Then

                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode, CType(Entity, AdvantageFramework.Database.Entities.JobComponent).Job.ClientCode)
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode, CType(Entity, AdvantageFramework.Database.Entities.JobComponent).Job.DivisionCode)
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, CType(Entity, AdvantageFramework.Database.Entities.JobComponent).Job.ProductCode)
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobNumber, CType(Entity, AdvantageFramework.Database.Entities.JobComponent).JobNumber)
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponent, CType(Entity, AdvantageFramework.Database.Entities.JobComponent).Number)
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponentID, CType(Entity, AdvantageFramework.Database.Entities.JobComponent).ID)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobDescription, CType(Entity, AdvantageFramework.Database.Entities.JobComponent).Job.Description)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobComponentDescription, CType(Entity, AdvantageFramework.Database.Entities.JobComponent).Description)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Client Then

                    Client = DirectCast(Entity, AdvantageFramework.Database.Entities.Client)

                    If Client.Divisions IsNot Nothing Then

                        If Client.Divisions.Where(Function(Div) Div.IsActive = 1).Count = 1 Then

                            Division = Client.Divisions.Where(Function(Div) Div.IsActive = 1).SingleOrDefault

                            SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode, Division.Code)

                            If Division.Products IsNot Nothing Then

                                If Division.Products.Where(Function(Prd) Prd.IsActive = 1).Count = 1 Then

                                    Product = Division.Products.Where(Function(Prd) Prd.IsActive = 1).SingleOrDefault

                                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, Product.Code)

                                End If

                            End If

                        End If

                    End If

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Division Then

                    Division = DirectCast(Entity, AdvantageFramework.Database.Entities.Division)

                    If Division.Products IsNot Nothing Then

                        If Division.Products.Where(Function(Prd) Prd.IsActive = 1).Count = 1 Then

                            Product = Division.Products.Where(Function(Prd) Prd.IsActive = 1).SingleOrDefault

                            SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, Product.Code)

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Protected Sub SubItemGridLookUpEditControl_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim ControlType As SubItemGridLookUpEditControl.Type = SubItemGridLookUpEditControl.Type.Default
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim Index As Integer = -1
            Dim Value As Object = Nothing
            Dim Values As Generic.Dictionary(Of BaseClasses.DefaultColumnTypes, Object) = Nothing

            _IsAutoFilling = True

            Try

                Try

                    GridLookUpEdit = sender

                    ControlType = CType(Me.FocusedRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ControlType

                Catch ex As Exception
                    GridLookUpEdit = Nothing
                    ControlType = SubItemGridLookUpEditControl.Type.Default
                End Try

                If GridLookUpEdit IsNot Nothing AndAlso ControlType <> SubItemGridLookUpEditControl.Type.Default Then

                    Values = New Generic.Dictionary(Of BaseClasses.DefaultColumnTypes, Object)

                    Select Case ControlType

                        Case SubItemGridLookUpEditControl.Type.Client

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Client.Properties.Name.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.ClientName, Value)

                        Case SubItemGridLookUpEditControl.Type.Division

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Division.Properties.Name.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.DivisionName, Value)

                        Case SubItemGridLookUpEditControl.Type.Product

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.Name.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.ProductName, Value)

                        Case SubItemGridLookUpEditControl.Type.SalesClass

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.SalesClass.Properties.Description.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.SalesClassDescription, Value)

                        Case SubItemGridLookUpEditControl.Type.Function

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Function.Properties.Description.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.FunctionDescription, Value)

                        Case SubItemGridLookUpEditControl.Type.Employee

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, "Name")

                            Values.Add(BaseClasses.DefaultColumnTypes.EmployeeName, Value)

                        Case SubItemGridLookUpEditControl.Type.Office

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Office.Properties.Name.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.OfficeName, Value)

                        Case SubItemGridLookUpEditControl.Type.Job

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Core.Job.Properties.Description.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.JobDescription, Value)

                        Case SubItemGridLookUpEditControl.Type.JobComponent, SubItemGridLookUpEditControl.Type.JobComponentID

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Core.JobComponent.Properties.Description.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.JobComponentDescription, Value)

                        Case SubItemGridLookUpEditControl.Type.AccountReceivable

                            Values.Add(BaseClasses.DefaultColumnTypes.AccountReceivableSequenceNumber, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.AccountReceivable.Properties.SequenceNumber.ToString))
                            Values.Add(BaseClasses.DefaultColumnTypes.AccountReceivableType, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.AccountReceivable.Properties.Type.ToString))
                            Values.Add(BaseClasses.DefaultColumnTypes.AccountReceivableClientCode, GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.AccountReceivable.Properties.ClientCode.ToString))

                        Case SubItemGridLookUpEditControl.Type.DepartmentTeam

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.DepartmentTeam.Properties.Description.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.DepartmentTeamName, Value)

                        Case SubItemGridLookUpEditControl.Type.Vendor

                            Value = GridLookUpEdit.Properties.View.GetRowCellValue(GridLookUpEdit.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.Vendor.Properties.Name.ToString)

                            Values.Add(BaseClasses.DefaultColumnTypes.VendorName, Value)

                    End Select

                    If IsNothing(GridLookUpEdit.EditValue) OrElse IsDBNull(GridLookUpEdit.EditValue) Then

                        For Each KeyValuePair In Values

                            SetSelectedObjectValueByDefaultColumnType(KeyValuePair.Key, Nothing)

                        Next

                    Else

                        For Each KeyValuePair In Values

                            SetSelectedObjectValueByDefaultColumnType(KeyValuePair.Key, KeyValuePair.Value)

                        Next

                    End If

                End If

            Catch ex As Exception

            End Try

            _IsAutoFilling = False

        End Sub
        Protected Sub SubItemGridLookUpEditControl_QueryPopup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ProductCode As String = ""
            Dim JobComponentID As String = ""
            Dim JobNumber As String = ""
            Dim DataSource As Object = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
            Dim Jobs As Generic.List(Of AdvantageFramework.Database.Entities.Job) = Nothing
            Dim JobNumbers As Integer() = Nothing
            Dim Entity As Object = Nothing
            Dim ProductCodes As String() = Nothing
            Dim OverrideDefaultDatasource As Boolean = False
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = BaseClasses.PropertyTypes.Default
            Dim MediaPlanID As Integer = Nothing

            If (_ControlType = ControlTypes.Editable OrElse _ControlType = ControlTypes.ImportTemplate OrElse _ControlType = ControlTypes.AutoFill) AndAlso TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = Me.ActiveEditor

                Try

                    PropertyDescriptor = _ObjectTypePropertyDescriptors.Where(Function(Prop) Prop.Name = Me.FocusedRow.Properties.FieldName).SingleOrDefault

                Catch ex As Exception
                    PropertyDescriptor = Nothing
                End Try

                If PropertyDescriptor IsNot Nothing Then

                    Try

                        EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                    Catch ex As Exception
                        EntityAttribute = Nothing
                    End Try

                    If EntityAttribute IsNot Nothing Then

                        PropertyType = EntityAttribute.PropertyType

                    End If

                End If

                If _Session IsNot Nothing AndAlso _AutoFilterLookupColumns Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Select Case PropertyType

                                Case BaseClasses.PropertyTypes.ClientCode

                                    RaiseEvent QueryPopupNeedDatasource(Me.FocusedRow.Properties.FieldName, OverrideDefaultDatasource, DataSource)

                                    If OverrideDefaultDatasource = False Then

                                        DataSource = From Client In AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                     Where Client.IsActive = 1
                                                     Select Client

                                    End If

                                Case BaseClasses.PropertyTypes.DivisionCode

                                    ClientCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode)

                                    If ClientCode <> "" Then

                                        RaiseEvent QueryPopupNeedDatasource(Me.FocusedRow.Properties.FieldName, OverrideDefaultDatasource, DataSource)

                                        If OverrideDefaultDatasource = False Then

                                            DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                         Where Division.ClientCode = ClientCode AndAlso
                                                               Division.IsActive = 1
                                                         Select Division

                                        End If

                                    Else

                                        Me.CloseEditor()

                                    End If

                                Case BaseClasses.PropertyTypes.ProductCode

                                    ClientCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode)
                                    DivisionCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode)

                                    If ClientCode <> "" AndAlso DivisionCode <> "" Then

                                        RaiseEvent QueryPopupNeedDatasource(Me.FocusedRow.Properties.FieldName, OverrideDefaultDatasource, DataSource)

                                        If OverrideDefaultDatasource = False Then

                                            Try

                                                ProductCodes = (From UserClientDivisionProductAccess In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, _Session.UserCode)
                                                                Where UserClientDivisionProductAccess.ClientCode = ClientCode AndAlso
                                                                      UserClientDivisionProductAccess.DivisionCode = DivisionCode
                                                                Select [PrdCode] = UserClientDivisionProductAccess.ProductCode).ToList.Select(Function(PrdCode) PrdCode).ToArray

                                                If ProductCodes.Any Then

                                                    DataSource = From Product In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)
                                                                 Where ProductCodes.Contains(Product.Code) AndAlso
                                                                       Product.IsActive = 1
                                                                 Select Product

                                                Else

                                                    DataSource = From Product In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)
                                                                 Where Product.IsActive = 1
                                                                 Select Product

                                                End If

                                            Catch ex As Exception

                                            End Try

                                        End If

                                    Else

                                        Me.CloseEditor()

                                    End If

                                Case BaseClasses.PropertyTypes.JobNumber

                                    RaiseEvent QueryPopupNeedDatasource(Me.FocusedRow.Properties.FieldName, OverrideDefaultDatasource, DataSource)

                                    If OverrideDefaultDatasource = False Then

                                        ClientCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode)
                                        DivisionCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode)
                                        ProductCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode)
                                        JobComponentID = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponentID)

                                        If JobComponentID IsNot Nothing Then

                                            Entity = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, JobComponentID)

                                            DataSource = From Job In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext)
                                                         Where Job.Number = CType(Entity, AdvantageFramework.Database.Entities.JobComponent).JobNumber
                                                         Select Job

                                        ElseIf ClientCode IsNot Nothing AndAlso DivisionCode IsNot Nothing AndAlso ProductCode IsNot Nothing Then

                                            DataSource = From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                         Where Job.ClientCode = ClientCode AndAlso
                                                               Job.DivisionCode = DivisionCode AndAlso
                                                               Job.ProductCode = ProductCode
                                                         Select Job

                                        ElseIf ClientCode IsNot Nothing AndAlso DivisionCode IsNot Nothing Then

                                            DataSource = From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                         Where Job.ClientCode = ClientCode AndAlso
                                                               Job.DivisionCode = DivisionCode
                                                         Select Job

                                        ElseIf ClientCode IsNot Nothing Then

                                            DataSource = From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                         Where Job.ClientCode = ClientCode
                                                         Select Job

                                        Else

                                            DataSource = AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)

                                        End If

                                    End If

                                Case BaseClasses.PropertyTypes.JobComponent, BaseClasses.PropertyTypes.JobComponentID

                                    JobNumber = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobNumber)

                                    RaiseEvent QueryPopupNeedDatasource(Me.FocusedRow.Properties.FieldName, OverrideDefaultDatasource, DataSource)

                                    If OverrideDefaultDatasource = False Then

                                        ClientCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode)
                                        DivisionCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode)
                                        ProductCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode)

                                        If JobNumber IsNot Nothing Then

                                            DataSource = (From JobComponent In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext)
                                                          Where JobComponent.JobNumber = JobNumber
                                                          Select JobComponent).ToList

                                        Else

                                            If ClientCode IsNot Nothing Then

                                                If DivisionCode IsNot Nothing AndAlso ProductCode IsNot Nothing Then

                                                    JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                  Where Job.ClientCode = ClientCode AndAlso
                                                                        Job.DivisionCode = DivisionCode AndAlso
                                                                        Job.ProductCode = ProductCode AndAlso
                                                                        Job.IsOpen = 1
                                                                  Select Job.Number).ToArray

                                                ElseIf DivisionCode IsNot Nothing Then

                                                    JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                  Where Job.ClientCode = ClientCode AndAlso
                                                                        Job.DivisionCode = DivisionCode AndAlso
                                                                        Job.IsOpen = 1
                                                                  Select Job.Number).ToArray

                                                Else

                                                    JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                  Where Job.ClientCode = ClientCode AndAlso
                                                                        Job.IsOpen = 1
                                                                  Select Job.Number).ToArray

                                                End If

                                            Else

                                                JobNumbers = (From Job In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                              Select Job.Number).ToArray

                                            End If

                                            DataSource = (From JobComponent In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext)
                                                          Where JobNumbers.Contains(JobComponent.JobNumber)
                                                          Select JobComponent).ToList

                                        End If

                                    End If

                                    If JobNumber IsNot Nothing Then

                                        If GridLookUpEdit.Properties.View.Columns("JobNumber") IsNot Nothing Then

                                            GridLookUpEdit.Properties.View.Columns("JobNumber").Visible = False

                                        End If

                                    Else

                                        If GridLookUpEdit.Properties.View.Columns("JobNumber") IsNot Nothing Then

                                            GridLookUpEdit.Properties.View.Columns("JobNumber").Visible = True

                                        End If

                                    End If

                                Case BaseClasses.PropertyTypes.MediaPlanDetailID

                                    MediaPlanID = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.MediaPlanID)

                                    RaiseEvent QueryPopupNeedDatasource(Me.FocusedRow.Properties.FieldName, OverrideDefaultDatasource, DataSource)

                                    If OverrideDefaultDatasource = False Then

                                        DataSource = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).Include("SalesClass")

                                    End If

                                Case Else

                                    RaiseEvent QueryPopupNeedDatasource(Me.FocusedRow.Properties.FieldName, OverrideDefaultDatasource, DataSource)

                                    If OverrideDefaultDatasource = False Then

                                        DataSource = Nothing

                                    End If

                            End Select

                            If DataSource IsNot Nothing Then

                                Try

                                    DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

                                Catch ex As Exception
                                    DataSource = Nothing
                                End Try

                            End If

                        End Using

                    End Using

                Else

                    RaiseEvent QueryPopupNeedDatasource(Me.FocusedRow.Properties.FieldName, OverrideDefaultDatasource, DataSource)

                    If OverrideDefaultDatasource = False Then

                        DataSource = Nothing

                    End If

                    If DataSource IsNot Nothing Then

                        Try

                            DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

                        Catch ex As Exception
                            DataSource = Nothing
                        End Try

                    End If

                End If

                If DataSource IsNot Nothing Then

                    BindingSource = New System.Windows.Forms.BindingSource

                    BindingSource.DataSource = DataSource

                    GridLookUpEdit.Properties.DataSource = BindingSource

                    If TypeOf Me.FocusedRow.Properties.RowEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                        SubItemGridLookUpEditControl = DirectCast(Me.FocusedRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                        If _AllowExtraItemsInGridLookupEdits = False Then

                            SubItemGridLookUpEditControl.ExtraComboBoxItem = Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                        End If

                        If SubItemGridLookUpEditControl.AddExtraComboBoxItem Then

                            If SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.NullValue Then

                                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(GridLookUpEdit.Properties.DataSource, SubItemGridLookUpEditControl.DisplayMember, SubItemGridLookUpEditControl.ValueMember,
                                                                                                                  "[None]", -3, True, True, Nothing)

                            Else

                                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(GridLookUpEdit.Properties.DataSource, SubItemGridLookUpEditControl.DisplayMember, SubItemGridLookUpEditControl.ValueMember,
                                                                                                                  "[" & AdvantageFramework.StringUtilities.GetNameAsWords(SubItemGridLookUpEditControl.ExtraComboBoxItem.ToString) & "]",
                                                                                                                  AdvantageFramework.EnumUtilities.GetValue(SubItemGridLookUpEditControl.ExtraComboBoxItem.GetType, SubItemGridLookUpEditControl.ExtraComboBoxItem.ToString),
                                                                                                                  True, True, Nothing)

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub ValidateAllRows()

            For VisibleRow = 0 To Me.VisibleRows.Count - 1

                Me.FocusedRow = Me.VisibleRows.Item(VisibleRow)

                RaiseValidatingEditor(New DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs(Me.VisibleRows.Item(VisibleRow).Properties.Value))

            Next

        End Sub
        Public Sub HideRowsByFieldName(ByVal NotVisibleFieldNames As IEnumerable(Of String))

            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            If NotVisibleFieldNames IsNot Nothing Then

                For Each FieldName In NotVisibleFieldNames

                    HideRowByFieldName(FieldName)

                Next

            End If

        End Sub
        Public Sub HideRowByFieldName(ByVal FieldName As String)

            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                BaseRow = Me.GetRowByFieldName(FieldName)

            Catch ex As Exception
                BaseRow = Nothing
            End Try

            If BaseRow IsNot Nothing Then

                BaseRow.Visible = False

            End If

        End Sub
        Private Sub AddSubItemGridLookupEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl
            SubItemGridLookUpEditControl.Session = Me.Session

            SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default

            SubItemGridLookUpEditControl.NullText = ""
            SubItemGridLookUpEditControl.DisplayMember = "Name"
            SubItemGridLookUpEditControl.ValueMember = "ID"

            SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
            SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

            BindingSource = New System.Windows.Forms.BindingSource

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                BindingSource.DataSource = DbContext.Countries.ToList.Select(Function(Entity) New With {.ID = Entity.ID, .Name = Entity.Name}).ToList

            End Using

            SubItemGridLookUpEditControl.DataSource = BindingSource

            AddSubItemGridLookupEdit(BaseRow, SubItemGridLookUpEditControl)

        End Sub

#Region "  Functions "

        Protected Function GetSelectedObjectValueByPropertyType(ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            'objects
            Dim Value As Object = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Try

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(Me.SelectedObject).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    Try

                        EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                    Catch ex As Exception
                        EntityAttribute = Nothing
                    End Try

                    If EntityAttribute IsNot Nothing Then

                        If EntityAttribute.PropertyType = PropertyType Then

                            Value = PropertyDescriptor.GetValue(Me.SelectedObject)

                            Exit For

                        End If

                    End If

                Next

            Catch ex As Exception
                Value = Nothing
            Finally
                GetSelectedObjectValueByPropertyType = Value
            End Try

        End Function
        Private Sub ClearValuesByPropertyType(ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Try

                Select Case PropertyType

                    Case BaseClasses.PropertyTypes.ClientCode

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode, Nothing)
                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, Nothing)

                    Case BaseClasses.PropertyTypes.DivisionCode

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, Nothing)

                End Select

            Catch ex As Exception

            End Try

            Try

                ClearSelectedObjectValuesByPropertyType(PropertyType)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ClearSelectedObjectValuesByPropertyType(ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Try

                Select Case PropertyType

                    Case BaseClasses.PropertyTypes.JobNumber

                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobDescription, Nothing)
                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponentID, Nothing)
                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponent, Nothing)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobComponentDescription, Nothing)

                    Case BaseClasses.PropertyTypes.JobComponent, BaseClasses.PropertyTypes.JobComponentID

                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobComponentDescription, Nothing)

                    Case BaseClasses.PropertyTypes.ClientCode, BaseClasses.PropertyTypes.DivisionCode, BaseClasses.PropertyTypes.ProductCode

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobNumber, Nothing)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobDescription, Nothing)
                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponentID, Nothing)
                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponent, Nothing)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobComponentDescription, Nothing)

                    Case BaseClasses.PropertyTypes.AccountReceivable

                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.AccountReceivableSequenceNumber, Nothing)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.AccountReceivableType, Nothing)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.AccountReceivableClientCode, Nothing)

                    Case BaseClasses.PropertyTypes.OfficeCode

                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.OfficeName, Nothing)

                    Case BaseClasses.PropertyTypes.DepartmentTeamCode

                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.DepartmentTeamName, Nothing)

                    Case BaseClasses.PropertyTypes.MediaPlanID

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.MediaPlanDetailID, Nothing)

                End Select

            Catch ex As Exception

            End Try

        End Sub
        Private Sub AutoFillPropertyValues(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Entity As Object)

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobCore As AdvantageFramework.Database.Core.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobComponentCore As AdvantageFramework.Database.Core.JobComponent = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim DivisionCore As AdvantageFramework.Database.Core.Division = Nothing
            Dim ProductCore As AdvantageFramework.Database.Core.Product = Nothing
            Dim JobNumber As Nullable(Of Integer) = Nothing
            Dim JobComponentID As Nullable(Of Integer) = Nothing
            Dim JobComponentNumber As Nullable(Of Integer) = Nothing
            Dim JobComponentDescription As String = Nothing
            Dim IsValid As Boolean
            Dim ProductView As AdvantageFramework.Database.Views.ProductView = Nothing

            _IsAutoFilling = True

            Try

                If TypeOf Entity Is AdvantageFramework.Database.Entities.Job Then

                    Job = DirectCast(Entity, AdvantageFramework.Database.Entities.Job)

                    Try

                        ProductView = (From Prod In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext)
                                       Where Prod.ClientCode = Job.ClientCode AndAlso
                                                Prod.DivisionCode = Job.DivisionCode AndAlso
                                                Prod.ProductCode = Job.ProductCode
                                       Select Prod).SingleOrDefault

                    Catch ex As Exception
                        ProductView = Nothing
                    End Try

                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode, Job.ClientCode)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ClientName, If(ProductView IsNot Nothing, ProductView.ClientName, ""))
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode, Job.DivisionCode)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.DivisionName, If(ProductView IsNot Nothing, ProductView.DivisionName, ""))
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, Job.ProductCode)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ProductName, If(ProductView IsNot Nothing, ProductView.ProductDescription, ""))

                    If GetSelectedObjectValueByPropertyType(BaseClasses.Methods.PropertyTypes.JobNumber) = 0 Then

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobNumber, Job.Number)

                    End If

                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobDescription, Job.Description)

                    Try

                        If Job.IsOpen = 1 Then

                            JobComponentCore = (From JobComp In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext))
                                                Where JobComp.JobNumber = Job.Number
                                                Select JobComp).SingleOrDefault

                        Else

                            JobComponentCore = (From JobComp In AdvantageFramework.Database.Procedures.JobComponent.LoadCore(AdvantageFramework.Database.Procedures.JobComponent.LoadAllByJobNumber(DbContext, Job.Number))
                                                Select JobComp).SingleOrDefault

                        End If

                        JobComponentNumber = JobComponentCore.Number
                        JobComponentID = JobComponentCore.ID
                        JobComponentDescription = JobComponentCore.Description

                    Catch ex As Exception
                        JobComponentNumber = Nothing
                        JobComponentID = Nothing
                    End Try

                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponent, JobComponentNumber)
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponentID, JobComponentID)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobComponentDescription, JobComponentDescription)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.JobComponent Then

                    JobComponent = DirectCast(Entity, AdvantageFramework.Database.Entities.JobComponent)

                    'Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobComponent.JobNumber)
                    JobCore = AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext).SingleOrDefault(Function(EntityCore) EntityCore.Number = JobComponent.JobNumber)

                    Try

                        ProductView = (From Prod In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext)
                                       Where Prod.ClientCode = JobCore.ClientCode AndAlso
                                                Prod.DivisionCode = JobCore.DivisionCode AndAlso
                                                Prod.ProductCode = JobCore.ProductCode
                                       Select Prod).SingleOrDefault

                    Catch ex As Exception
                        ProductView = Nothing
                    End Try

                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode, JobCore.ClientCode)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ClientName, If(ProductView IsNot Nothing, ProductView.ClientName, ""))
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode, JobCore.DivisionCode)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.DivisionName, If(ProductView IsNot Nothing, ProductView.DivisionName, ""))
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, JobCore.ProductCode)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ProductName, If(ProductView IsNot Nothing, ProductView.ProductDescription, ""))
                    SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobNumber, JobCore.Number)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobDescription, JobCore.Description)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.JobComponentDescription, JobComponent.Description)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Client Then

                    Client = DirectCast(Entity, AdvantageFramework.Database.Entities.Client)
                    DivisionCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode)
                    ProductCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode)

                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ClientName, Client.Name)

                    If String.IsNullOrEmpty(DivisionCode) = False Then

                        IsValid = True

                        AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.DivisionCode, DivisionCode, IsValid, Client.Code)

                        If IsValid = False Then

                            DivisionCode = Nothing
                            ProductCode = Nothing

                        End If

                    End If

                    If String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                        IsValid = True

                        AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.ProductCode, ProductCode, IsValid, Client.Code, DivisionCode)

                        If IsValid = False Then

                            ProductCode = Nothing

                        End If

                    End If

                    If String.IsNullOrEmpty(DivisionCode) Then

                        Try

                            DivisionCore = (From Div In AdvantageFramework.Database.Procedures.Division.LoadCore(AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext))
                                            Where Div.ClientCode = Client.Code
                                            Select Div).SingleOrDefault

                        Catch ex As Exception
                            DivisionCore = Nothing
                        End Try

                    End If

                    If DivisionCore IsNot Nothing AndAlso String.IsNullOrEmpty(ProductCode) = True Then

                        Try

                            ProductCore = (From Prod In AdvantageFramework.Database.Procedures.Product.LoadCore(AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext))
                                           Where Prod.ClientCode = Client.Code AndAlso
                                                    Prod.DivisionCode = DivisionCore.Code
                                           Select Prod).SingleOrDefault

                        Catch ex As Exception
                            ProductCore = Nothing
                        End Try

                    End If

                    If DivisionCore IsNot Nothing Then

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode, DivisionCore.Code)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.DivisionName, DivisionCore.Name)

                    Else

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode, Nothing)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.DivisionName, Nothing)

                    End If

                    If ProductCore IsNot Nothing Then

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, ProductCore.Code)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ProductName, ProductCore.Name)

                    Else

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, Nothing)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ProductName, Nothing)

                    End If

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Division Then

                    Division = DirectCast(Entity, AdvantageFramework.Database.Entities.Division)
                    ProductCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode)

                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.DivisionName, Division.Name)

                    If String.IsNullOrEmpty(ProductCode) = False Then

                        IsValid = True

                        AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.ProductCode, ProductCode, IsValid, Division.ClientCode, Division.Code)

                        If IsValid = False Then

                            ProductCode = Nothing

                        End If

                    End If

                    If String.IsNullOrEmpty(ProductCode) Then

                        Try

                            ProductCore = (From Prod In AdvantageFramework.Database.Procedures.Product.LoadCore(AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext))
                                           Where Prod.ClientCode = Division.ClientCode AndAlso
                                                    Prod.DivisionCode = Division.Code
                                           Select Prod).SingleOrDefault

                        Catch ex As Exception
                            ProductCore = Nothing
                        End Try

                    End If

                    If ProductCore IsNot Nothing Then

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, ProductCore.Code)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ProductName, ProductCore.Name)

                    Else

                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ProductCode, Nothing)
                        SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ProductName, Nothing)

                    End If

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Core.Product Then

                    ProductCore = DirectCast(Entity, AdvantageFramework.Database.Core.Product)

                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.ProductName, ProductCore.Name)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.AccountReceivable Then

                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.AccountReceivableSequenceNumber, DirectCast(Entity, AdvantageFramework.Database.Entities.AccountReceivable).SequenceNumber)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.AccountReceivableType, DirectCast(Entity, AdvantageFramework.Database.Entities.AccountReceivable).Type)
                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.AccountReceivableClientCode, DirectCast(Entity, AdvantageFramework.Database.Entities.AccountReceivable).ClientCode)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Office Then

                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.OfficeName, DirectCast(Entity, AdvantageFramework.Database.Entities.Office).Code)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.DepartmentTeam Then

                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.DepartmentTeamName, DirectCast(Entity, AdvantageFramework.Database.Entities.DepartmentTeam).Code)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Function Then

                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.FunctionDescription, DirectCast(Entity, AdvantageFramework.Database.Entities.Function).Description)

                ElseIf TypeOf Entity Is AdvantageFramework.Database.Core.Vendor Then

                    SetSelectedObjectValueByDefaultColumnType(BaseClasses.DefaultColumnTypes.VendorName, DirectCast(Entity, AdvantageFramework.Database.Core.Vendor).Name)

                End If

            Catch ex As Exception

            End Try

            _IsAutoFilling = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PropertyGridControl_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles Me.CellValueChanged

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Entity As Object = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim JobNumber As Integer = Nothing
            Dim DoClear As Boolean = True
            Dim SequenceNumber As Short = Nothing
            Dim Type As String = Nothing

            If _IsAutoFilling = False AndAlso Me.AutoFilterLookupColumns AndAlso (_ControlType = PropertyGridControl.ControlTypes.Editable OrElse _ControlType = ControlTypes.ImportTemplate OrElse _ControlType = ControlTypes.AutoFill) Then

                Try

                    PropertyDescriptor = _ObjectTypePropertyDescriptors.Where(Function(Prop) Prop.Name = Me.FocusedRow.Properties.FieldName).SingleOrDefault

                    If PropertyDescriptor IsNot Nothing Then

                        Try

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                            If EntityAttribute IsNot Nothing Then

                                If e.Value IsNot Nothing Then

                                    If EntityAttribute.PropertyType <> BaseClasses.PropertyTypes.Default Then

                                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                                Select Case EntityAttribute.PropertyType

                                                    Case BaseClasses.PropertyTypes.JobNumber

                                                        ClearSelectedObjectValuesByPropertyType(EntityAttribute.PropertyType)

                                                        Entity = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.JobComponent

                                                        ClearSelectedObjectValuesByPropertyType(EntityAttribute.PropertyType)

                                                        JobNumber = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobNumber)

                                                        If JobNumber = 0 Then

                                                            If TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                                                                With DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                                                                    JobNumber = .Properties.View.GetRowCellValue(.Properties.View.FocusedRowHandle, AdvantageFramework.Database.Entities.JobComponent.Properties.JobNumber.ToString)

                                                                End With

                                                            End If

                                                        End If

                                                        If JobNumber > 0 Then

                                                            Entity = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, e.Value)

                                                        End If

                                                    Case BaseClasses.PropertyTypes.JobComponentID

                                                        ClearSelectedObjectValuesByPropertyType(EntityAttribute.PropertyType)

                                                        SetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.JobComponent, DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.GetRowCellValue(DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.FocusedRowHandle, "Number"))

                                                        Entity = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.ClientCode

                                                        ClearSelectedObjectValuesByPropertyType(EntityAttribute.PropertyType)

                                                        Entity = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.DivisionCode

                                                        ClearSelectedObjectValuesByPropertyType(EntityAttribute.PropertyType)

                                                        ClientCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode)

                                                        Entity = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, ClientCode, e.Value)

                                                    Case BaseClasses.PropertyTypes.ProductCode

                                                        ClearSelectedObjectValuesByPropertyType(EntityAttribute.PropertyType)

                                                        ClientCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.ClientCode)
                                                        DivisionCode = GetSelectedObjectValueByPropertyType(BaseClasses.PropertyTypes.DivisionCode)

                                                        Try

                                                            Entity = AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext).SingleOrDefault(Function(ECO) ECO.ClientCode = ClientCode AndAlso ECO.DivisionCode = DivisionCode AndAlso ECO.Code = e.Value)

                                                        Catch ex As Exception
                                                            Entity = Nothing
                                                        End Try

                                                    Case BaseClasses.PropertyTypes.FunctionCode, BaseClasses.PropertyTypes.VendorFunctionCode

                                                        ClearSelectedObjectValuesByPropertyType(BaseClasses.PropertyTypes.FunctionCode)

                                                        Entity = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.DepartmentTeamCode

                                                        ClearSelectedObjectValuesByPropertyType(BaseClasses.PropertyTypes.DepartmentTeamCode)

                                                        Entity = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, e.Value)

                                                    Case BaseClasses.PropertyTypes.VendorCode

                                                        ClearSelectedObjectValuesByPropertyType(BaseClasses.PropertyTypes.VendorCode)

                                                        Entity = AdvantageFramework.Database.Procedures.Vendor.LoadCore(DbContext).SingleOrDefault(Function(ECO) ECO.Code = e.Value)

                                                End Select

                                                If Entity IsNot Nothing Then

                                                    AutoFillPropertyValues(DbContext, DataContext, Entity)

                                                    DoClear = False

                                                End If

                                            End Using

                                        End Using

                                    End If

                                End If

                                If DoClear Then

                                    ClearValuesByPropertyType(EntityAttribute.PropertyType)

                                End If

                            End If

                        Catch ex As Exception
                            EntityAttribute = Nothing
                        End Try

                    End If

                Catch ex As Exception

                End Try

            End If

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        Private Sub PropertyGridControl_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles Me.CellValueChanging

            Try

                Me.ActiveEditor.Tag.Tag = False

            Catch ex As Exception

            End Try

        End Sub
        Private Sub PropertyGridControl_CustomPropertyDescriptors(ByVal sender As Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventArgs) Handles Me.CustomPropertyDescriptors

            'objects
            Dim FilteredProperties As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim AddProperty As Boolean = Nothing

            If e.Context.PropertyDescriptor Is Nothing Then

                FilteredProperties = New System.ComponentModel.PropertyDescriptorCollection(Nothing)

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(Me.SelectedObject).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    AddProperty = True
                    EntityAttribute = Nothing

                    Try

                        If PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Any Then

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).FirstOrDefault

                        End If

                    Catch ex As Exception
                        EntityAttribute = Nothing
                    End Try

                    If EntityAttribute IsNot Nothing Then

                        If _ControlType = ControlTypes.ImportTemplate Then

                            AddProperty = EntityAttribute.IsImportDefaultProperty

                        ElseIf _ControlType = ControlTypes.Editable Then

                            If PropertyDescriptor.PropertyType.Name.Contains("ICollection") OrElse
                                    (PropertyDescriptor.PropertyType.BaseType IsNot Nothing AndAlso PropertyDescriptor.PropertyType.BaseType.Name.Contains("Entity")) OrElse
                                    PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).Any(Function(Attribute) Attribute.Browsable = False) Then

                                AddProperty = False

                            End If

                        ElseIf _ControlType = ControlTypes.ExportTemplate Then

                            AddProperty = Not EntityAttribute.IsReadOnlyColumn

                        ElseIf _ControlType = ControlTypes.AutoFill Then

                            AddProperty = EntityAttribute.IsAutoFillProperty

                        End If

                    Else

                        If PropertyDescriptor.PropertyType.Name.Contains("ICollection") OrElse
                            (PropertyDescriptor.PropertyType.BaseType IsNot Nothing AndAlso PropertyDescriptor.PropertyType.BaseType.Name.Contains("Entity")) OrElse
                             PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).Any(Function(Attribute) Attribute.Browsable = False) Then

                            AddProperty = False

                        Else

                            AddProperty = PropertyDescriptor.IsBrowsable

                        End If

					End If

                    If AddProperty Then

                        FilteredProperties.Add(PropertyDescriptor)

                    End If

                Next

                e.Properties = FilteredProperties

            End If

        End Sub
        Private Sub PropertyGridControl_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles Me.ValidatingEditor

            Dim SelectedObject As Object = Nothing

            SelectedObject = Me.SelectedObject

            If SelectedObject IsNot Nothing Then

                If TypeOf SelectedObject Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                    If TypeOf SelectedObject Is AdvantageFramework.BaseClasses.Entity Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DirectCast(SelectedObject, AdvantageFramework.BaseClasses.Entity).DbContext = DbContext

                            e.ErrorText = DirectCast(SelectedObject, AdvantageFramework.BaseClasses.Entity).ValidateEntityProperty(Me.FocusedRow.Properties.FieldName, e.Valid, e.Value)

                            e.Valid = True

                        End Using

                    ElseIf TypeOf SelectedObject Is AdvantageFramework.BaseClasses.EntityBase Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                DirectCast(SelectedObject, AdvantageFramework.BaseClasses.EntityBase).DbContext = DbContext
                                DirectCast(SelectedObject, AdvantageFramework.BaseClasses.EntityBase).DataContext = DataContext

                                e.ErrorText = DirectCast(SelectedObject, AdvantageFramework.BaseClasses.EntityBase).ValidateEntityProperty(Me.FocusedRow.Properties.FieldName, e.Valid, e.Value)

                                e.Valid = True

                            End Using

                        End Using

                    ElseIf TypeOf SelectedObject Is AdvantageFramework.BaseClasses.BaseClass Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DirectCast(SelectedObject, AdvantageFramework.BaseClasses.BaseClass).DbContext = DbContext

                            e.ErrorText = DirectCast(SelectedObject, AdvantageFramework.BaseClasses.BaseClass).ValidateEntityProperty(Me.FocusedRow.Properties.FieldName, e.Valid, e.Value)

                            e.Valid = True

                        End Using

                    ElseIf TypeOf SelectedObject Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                        e.ErrorText = DirectCast(SelectedObject, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntityProperty(Me.FocusedRow.Properties.FieldName, e.Valid, e.Value)

                        e.Valid = True

                    Else

                        Try

                            e.ErrorText = DirectCast(FocusedRow, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntityProperty(Me.FocusedRow.Properties.FieldName, e.Valid, e.Value)

                            e.Valid = True

                        Catch ex As Exception

                        End Try

                    End If

                End If

            End If

            If TypeOf Me.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                If TypeOf Me.ActiveEditor.Tag Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                    If DirectCast(Me.ActiveEditor.Tag, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).IsNewValue Then

                        e.Valid = False
                        DirectCast(Me.ActiveEditor.Tag, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).IsNewValue = False
                        DirectCast(Me.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).ShowPopup()

                    End If

                End If

            End If

            If String.IsNullOrWhiteSpace(e.ErrorText) = False Then

                Me.SetRowError(Me.FocusedRow.Properties, e.ErrorText)

            Else

                Me.SetRowError(Me.FocusedRow.Properties, Nothing)

            End If
            
        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Protected Sub SubItemTextBox_ButtonClick()

            Dim SelectedObject As Object = Nothing

            If Me.OptionsBehavior.Editable Then

                SelectedObject = MyBase.SelectedObject

                If _ObjectType Is GetType(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail) Then

                    RaiseEvent SubItemTextBoxButtonClickEvent(SelectedObject)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
