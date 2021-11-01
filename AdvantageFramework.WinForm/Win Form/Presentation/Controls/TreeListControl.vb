Namespace WinForm.Presentation.Controls

    Public Class TreeListControl
        Inherits DevExpress.XtraTreeList.TreeList
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            NonEditable
            Editable
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As TreeListControl.Type = TreeListControl.Type.Default
        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _BypassChangedOnAddNode As Boolean = False
        Protected _BypassChangedOnDeleteNode As Boolean = False

#End Region

#Region " Properties "

        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
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
        Public Property ControlType() As TreeListControl.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As TreeListControl.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public ReadOnly Property HasASelectedNode As Boolean
            Get
                HasASelectedNode = If(Me.Selection.Count > 0, True, False)
            End Get
        End Property
        Public ReadOnly Property HasOnlyOneSelectedNode As Boolean
            Get
                HasOnlyOneSelectedNode = If(Me.Selection.Count = 1, True, False)
            End Get
        End Property
        Public ReadOnly Property SelectedNodeHasChildNodes As Boolean
            Get

                If Me.HasASelectedNode Then

                    SelectedNodeHasChildNodes = If(Me.GetFirstSelectedNode.Nodes.Count > 0, True, False)

                Else

                    SelectedNodeHasChildNodes = False

                End If

            End Get
        End Property
        Public WriteOnly Property BypassChangedOnAddAndDeleteNode As Boolean
            Set(value As Boolean)
                _BypassChangedOnDeleteNode = value
                _BypassChangedOnAddNode = value
            End Set
        End Property
        Public WriteOnly Property BypassChangedOnAddNode As Boolean
            Set(value As Boolean)
                _BypassChangedOnAddNode = value
            End Set
        End Property
        Public WriteOnly Property BypassChangedOnDeleteNode As Boolean
            Set(value As Boolean)
                _BypassChangedOnDeleteNode = value
            End Set
        End Property


#End Region

#Region " Methods "

        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False

            Me.OptionsNavigation.UseTabKey = True
            Me.OptionsNavigation.AutoMoveRowFocus = True

            Me.DoubleBuffered = True
            ''AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Sub LoadFormSettings(Form As Windows.Forms.Form) Implements Interfaces.IUserControl.LoadFormSettings

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case TreeListControl.Type.Default

                    Me.OptionsBehavior.Editable = False

                Case Type.Editable

                    Me.OptionsBehavior.Editable = True

                Case Type.NonEditable

                    Me.OptionsBehavior.Editable = False

            End Select

        End Sub
        Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try


            Catch ex As Exception
                IsValid = False
            Finally
                Validate = IsValid
            End Try

        End Function
        Protected Sub ModifyColumn(ByVal TreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            If EntityAttribute.PropertyType <> BaseClasses.PropertyTypes.Default Then

                AddRepositoryItemByPropertyTypeEntityAttribute(TreeListColumn, PropertyDescriptor, EntityAttribute)

            ElseIf EntityAttribute.DefaultColumnType <> BaseClasses.DefaultColumnTypes.None Then

                AddRepositoryItemByDefaultColumnTypeEntityAttribute(TreeListColumn, PropertyDescriptor, EntityAttribute)

            Else

                AddDefaultRepositoryItem(TreeListColumn, PropertyDescriptor, EntityAttribute)

            End If

        End Sub
        Protected Sub AddRepositoryItemByPropertyTypeEntityAttribute(ByVal TreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            Select Case EntityAttribute.PropertyType

                Case Else

                    AddDefaultRepositoryItem(TreeListColumn, PropertyDescriptor, EntityAttribute)

            End Select

        End Sub
        Protected Sub AddRepositoryItemByDefaultColumnTypeEntityAttribute(ByVal TreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            Select Case EntityAttribute.DefaultColumnType

                Case Else

                    AddDefaultRepositoryItem(TreeListColumn, PropertyDescriptor, EntityAttribute)

            End Select

        End Sub
        Protected Sub AddDefaultRepositoryItem(ByVal TreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute)

            'Objects
            Dim NonNullableType As System.Type = Nothing

            If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                NonNullableType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

            Else

                NonNullableType = PropertyDescriptor.PropertyType

            End If

            Select Case NonNullableType

                Case GetType(System.String)

                    AddSubItemTextBox(TreeListColumn, PropertyDescriptor)

            End Select

        End Sub
        Protected Sub AddSubItemTextBox(ByRef TreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn, ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            'objects
            Dim SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox = Nothing
            Dim MaxLength As Long = -1
            Dim BaseClass As Object = Nothing

            SubItemTextBox = New AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox

            SubItemTextBox.Session = _Session
            SubItemTextBox.ControlType = Presentation.Controls.SubItemTextBox.Type.Default

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(PropertyDescriptor.ComponentType, TreeListColumn.FieldName))

                    Catch ex As Exception
                        MaxLength = -1
                    End Try

                    If MaxLength <> -1 Then

                        SubItemTextBox.MaxLength = MaxLength

                    End If

                End Using

            End If

            Me.RepositoryItems.Add(SubItemTextBox)

            TreeListColumn.ColumnEdit = SubItemTextBox

        End Sub

#Region "  Public "

        Public Sub SetColumnPropertySettings(ByVal ObjectType As System.Type)

            'objects
            Dim TreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            For Each TreeListColumn In Me.Columns.OfType(Of DevExpress.XtraTreeList.Columns.TreeListColumn)().ToList

                Try

                    PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)().Where(Function(Prop) Prop.Name = TreeListColumn.FieldName).SingleOrDefault

                Catch ex As Exception
                    PropertyDescriptor = Nothing
                End Try

                If PropertyDescriptor IsNot Nothing Then

                    Try

                        EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                    Catch ex As Exception
                        EntityAttribute = Nothing
                    End Try

                    ModifyColumn(TreeListColumn, PropertyDescriptor, EntityAttribute)

                End If

            Next

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Public Function GetFirstSelectedNode() As DevExpress.XtraTreeList.Nodes.TreeListNode

            GetFirstSelectedNode = Me.Selection(0)

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub TreeListControl_CellValueChanging(sender As Object, e As DevExpress.XtraTreeList.CellValueChangedEventArgs) Handles Me.CellValueChanging

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        Private Sub TreeListControl_NodeChanged(sender As Object, e As DevExpress.XtraTreeList.NodeChangedEventArgs) Handles Me.NodeChanged

            'objects
            Dim BypassChanges As Boolean = False

            Select Case e.ChangeType

                Case DevExpress.XtraTreeList.NodeChangeTypeEnum.Add

                    BypassChanges = _BypassChangedOnAddNode

                Case DevExpress.XtraTreeList.NodeChangeTypeEnum.Remove

                    BypassChanges = _BypassChangedOnDeleteNode

                Case Else

                    BypassChanges = True

            End Select

            If BypassChanges = False Then

                If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                    _UserEntryChanged = True

                    AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

                End If

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
