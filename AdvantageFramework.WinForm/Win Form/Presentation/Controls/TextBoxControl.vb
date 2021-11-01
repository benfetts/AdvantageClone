Namespace WinForm.Presentation.Controls

    Public Class TextBox
        Inherits DevComponents.DotNetBar.Controls.TextBoxX
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

        Public Event TagObjectChanged()
        Public Event FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            File
            Office
            Employee
            [Function]
            SocialSecurityNumber
            Folder
            PostPeriod
            Email
            Vendor
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As TextBox.Type = TextBox.Type.Default
        Protected _FormSettingsLoaded As Boolean = False
        Protected _FileFilter As AdvantageFramework.FileSystem.FileFilters = AdvantageFramework.FileSystem.FileFilters.Default
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _IsRequired As Boolean = False
        Protected _DisplayName As String = ""
        Protected _TabOnEnter As Boolean = True
        Protected _ErrorIconAlignment As System.Windows.Forms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Protected _CheckSpellingOnValidate As Boolean = False
        Protected _PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = BaseClasses.PropertyTypes.Default
        Protected _AgencyImportPath As String = ""
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _MaxFileSize As Long = Nothing
        Protected _ShowSpellCheckCompleteMessage As Boolean = True
        Protected _StartingFolderName As String = Nothing
        'Protected WithEvents ContextMenuBarTextBox As DevComponents.DotNetBar.ContextMenuBar = Nothing
        'Protected WithEvents ButtonItemTextBox_Menu As DevComponents.DotNetBar.ButtonItem = Nothing
        'Protected WithEvents ButtonItemMenu_SpellCheck As DevComponents.DotNetBar.ButtonItem = Nothing
        'Protected _AddSpellCheckMenu As Boolean = False
        Private _SecurityEnabled As Boolean = True
        Private _CheckingSpelling As Boolean = False

#End Region

#Region " Properties "

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
        'Public Property AddSpellCheckMenu() As Boolean
        '    Get
        '        AddSpellCheckMenu = _AddSpellCheckMenu
        '    End Get
        '    Set(ByVal value As Boolean)
        '        _AddSpellCheckMenu = value

        '        If _AddSpellCheckMenu Then

        '            AddSpellCheckMenuToControl()

        '        End If

        '    End Set
        'End Property
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
        Public Property ControlType() As TextBox.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As TextBox.Type)
                _ControlType = value
                SetControlType()
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
        Public Property FileFilter() As AdvantageFramework.FileSystem.FileFilters
            Get
                FileFilter = _FileFilter
            End Get
            Set(ByVal value As AdvantageFramework.FileSystem.FileFilters)
                _FileFilter = value
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
        Public Property CheckSpellingOnValidate() As Boolean
            Get
                CheckSpellingOnValidate = _CheckSpellingOnValidate
            End Get
            Set(ByVal value As Boolean)
                _CheckSpellingOnValidate = value
            End Set
        End Property
        Public Overrides Property Text As String
            Get

                If _AgencyImportPath = "" Then

                    Text = MyBase.Text

                Else

                    If MyBase.Text <> "" Then

                        Text = AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath, "\") & MyBase.Text

                    Else

                        Text = MyBase.Text

                    End If

                End If

            End Get
            Set(ByVal value As String)

                If _AgencyImportPath = "" Then

                    MyBase.Text = value

                Else

                    MyBase.Text = If(value IsNot Nothing, value.Replace(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath, "\"), ""), value)

                End If

            End Set
        End Property
        Public Property MaxFileSize As Long
            Get
                MaxFileSize = _MaxFileSize
            End Get
            Set(value As Long)
                _MaxFileSize = value
            End Set
        End Property
        Public Property ShowSpellCheckCompleteMessage As Boolean
            Get
                ShowSpellCheckCompleteMessage = _ShowSpellCheckCompleteMessage
            End Get
            Set(value As Boolean)
                _ShowSpellCheckCompleteMessage = value
            End Set
        End Property
        Public Property StartingFolderName As String
            Get
                StartingFolderName = _StartingFolderName
            End Get
            Set(value As String)
                _StartingFolderName = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.Size = New System.Drawing.Size(Me.Size.Width, 20)
            Me.ShortcutsEnabled = True
            Me.FocusHighlightEnabled = True
            Me.Border.Class = "TextBoxBorder"
            Me.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.FocusHighlightColor = System.Drawing.Color.FromArgb(255, 230, 141)

            Me.DoubleBuffered = True

        End Sub
        'Private Sub AddSpellCheckMenuToControl()

        '    ContextMenuBarTextBox = New DevComponents.DotNetBar.ContextMenuBar()
        '    ButtonItemTextBox_Menu = New DevComponents.DotNetBar.ButtonItem()
        '    ButtonItemMenu_SpellCheck = New DevComponents.DotNetBar.ButtonItem()

        '    ContextMenuBarTextBox.SetContextMenuEx(Me, ButtonItemTextBox_Menu)

        '    ContextMenuBarTextBox.AntiAlias = True
        '    ContextMenuBarTextBox.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {ButtonItemTextBox_Menu})
        '    ContextMenuBarTextBox.Location = New System.Drawing.Point(935, 135)
        '    ContextMenuBarTextBox.Name = "ContextMenuBarTextBox"
        '    ContextMenuBarTextBox.Size = New System.Drawing.Size(75, 25)
        '    ContextMenuBarTextBox.Stretch = True
        '    ContextMenuBarTextBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '    ContextMenuBarTextBox.TabIndex = 4
        '    ContextMenuBarTextBox.TabStop = False
        '    ContextMenuBarTextBox.Text = ""

        '    ButtonItemTextBox_Menu.AutoExpandOnClick = True
        '    ButtonItemTextBox_Menu.Name = "ButtonItemTextBox_Menu"
        '    ButtonItemTextBox_Menu.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {ButtonItemMenu_SpellCheck})
        '    ButtonItemTextBox_Menu.Text = "Menu"

        '    ButtonItemMenu_SpellCheck.Image = AdvantageFramework.My.Resources.SpellCheckImage
        '    ButtonItemMenu_SpellCheck.Name = "ButtonItemMenu_SpellCheck"
        '    ButtonItemMenu_SpellCheck.Text = "Spell Check"

        'End Sub
        Public Sub SetDefaultPropertySettings(Optional ByVal MaxLength As Long = 0, Optional ByVal DisplayName As String = "",
                                              Optional ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = BaseClasses.PropertyTypes.Default,
                                              Optional ByVal IsRequired As Boolean = False)

            If MaxLength > 0 Then

                Me.MaxLength = MaxLength

            End If

            If DisplayName <> "" Then

                _DisplayName = DisplayName

            End If

            If PropertyType <> BaseClasses.PropertyTypes.Default Then

                _PropertyType = PropertyType

            End If

            SetRequired(IsRequired)

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByVal OverrideDisplayName As String)

            'objects
            Dim MaxLength As Long = 0
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim MaxLengthAttribute As System.ComponentModel.DataAnnotations.MaxLengthAttribute = Nothing
            Dim DisplayName As String = ""
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = BaseClasses.PropertyTypes.Default
            Dim IsRequired As Boolean = False

            If PropertyDescriptor IsNot Nothing Then

                DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

                If OverrideDisplayName <> "" Then

                    DisplayName = OverrideDisplayName

                End If

                MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

                If String.IsNullOrWhiteSpace(OverrideDisplayName) = False Then

                    DisplayName = OverrideDisplayName

                End If

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        PropertyType = EntityAttribute.PropertyType
                        IsRequired = EntityAttribute.IsRequired

                    End If

                End Try

            End If

            SetDefaultPropertySettings(MaxLength, DisplayName, PropertyType, IsRequired)

        End Sub
        Public Sub SetPropertySettings(ByVal EnumProperty As [Enum])

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor, "")

        End Sub
        Public Sub SetPropertySettings(ByVal EnumProperty As [Enum], ByVal OverrideDisplayName As String)

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor, OverrideDisplayName)

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum], Optional ByVal OverrideDisplayName As String = "")

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper)

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor, OverrideDisplayName)

        End Sub
        Public Sub SetRequired(ByVal IsRequired As Boolean)

            _IsRequired = IsRequired

            If _IsRequired Then

                Me.BackColor = Drawing.Color.Cyan

            End If

        End Sub
        Public Sub SetAgencyImportPath(ByVal Path As String, ByVal Append As Boolean)

            If _AgencyImportPath <> "" Then

                If Append Then

                    _AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath, "\") & Path

                Else

                    _AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Path, "\")

                End If

            End If

        End Sub
        Public Sub SetAgencyImportPathToLogoPath()

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        _AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadLogoPath(DbContext), "\")

                    End If

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.ErrorProvider.SetIconAlignment(Me, _ErrorIconAlignment)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _ControlType = TextBox.Type.File Then

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                    _AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\")

                                End If

                            End Using

                        Catch ex As Exception
                            _AgencyImportPath = ""
                        End Try

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case TextBox.Type.Default

                    Me.ButtonCustom.Visible = False
                    Me.ShortcutsEnabled = True
                    Me.ButtonCustom.DisplayPosition = 0
                    _PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.Default

                Case TextBox.Type.File

                    Me.ButtonCustom.Visible = True
                    Me.ShortcutsEnabled = True
                    Me.ButtonCustom.DisplayPosition = 0
                    _PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.File

                Case TextBox.Type.Office

                    Me.ButtonCustom.Visible = True
                    Me.ShortcutsEnabled = True
                    Me.ButtonCustom.DisplayPosition = 0
                    _PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode

                Case TextBox.Type.Employee

                    Me.ButtonCustom.Visible = True
                    Me.ShortcutsEnabled = True
                    Me.ButtonCustom.DisplayPosition = 0
                    _PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.EmployeeCode

                Case TextBox.Type.[Function]

                    Me.ButtonCustom.Visible = True
                    Me.ShortcutsEnabled = True
                    Me.ButtonCustom.DisplayPosition = 0
                    _PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode

                Case TextBox.Type.Folder

                    Me.ButtonCustom.Visible = True
                    Me.ShortcutsEnabled = True
                    Me.ButtonCustom.DisplayPosition = 0
                    _PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.Folder

                Case TextBox.Type.PostPeriod

                    Me.ButtonCustom.Visible = True
                    Me.ShortcutsEnabled = True
                    Me.ButtonCustom.DisplayPosition = 0
                    _PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodCode

                Case TextBox.Type.Email

                    Me.ButtonCustom.Visible = False
                    Me.ShortcutsEnabled = True
                    Me.ButtonCustom.DisplayPosition = 0
                    _PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.Email

                Case TextBox.Type.Vendor

                    Me.ButtonCustom.Visible = True
                    Me.ShortcutsEnabled = True
                    Me.ButtonCustom.DisplayPosition = 0
                    _PropertyType = AdvantageFramework.BaseClasses.PropertyTypes.VendorCode

            End Select

        End Sub
        Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                If _IsRequired Then

                    If Me.Text.Trim = "" Then

                        ErrorMessage = _DisplayName & " is required."

                        IsValid = False

                    End If

                End If

                If _CheckSpellingOnValidate Then

                    CheckSpelling()

                End If

                If IsValid Then

                    If _PropertyType <> BaseClasses.PropertyTypes.Default AndAlso Me.Text.Trim <> "" Then

                        If _Session IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    ErrorMessage = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, _PropertyType, Me.Text, IsValid)

                                End Using

                            End Using

                        End If

                    End If

                End If

                If IsValid Then

                    Select Case _ControlType

                        Case TextBox.Type.File

                            IsValid = ControlType_File_Validation(ErrorMessage)

                        Case TextBox.Type.Office

                            IsValid = ControlType_Office_Validation(ErrorMessage)

                        Case TextBox.Type.Employee

                            IsValid = ControlType_Employee_Validation(ErrorMessage)

                        Case TextBox.Type.[Function]

                            IsValid = ControlType_Function_Validation(ErrorMessage)

                        Case TextBox.Type.SocialSecurityNumber

                            IsValid = ControlType_SocialSecurityNumber_Validation(ErrorMessage)

                        Case TextBox.Type.Folder

                            IsValid = ControlType_Folder_Validation(ErrorMessage)

                        Case TextBox.Type.PostPeriod

                            IsValid = ControlType_PostPeriod_Validation(ErrorMessage)

                        Case TextBox.Type.Email

                            IsValid = ControlType_Email_Validation(ErrorMessage)

                        Case TextBox.Type.Vendor

                            IsValid = ControlType_Vendor_Validation(ErrorMessage)

                    End Select

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                RaiseEvent FinalizeValidationEvent(IsValid, ErrorMessage)
                Validate = IsValid
            End Try

        End Function
        Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)

            If _TabOnEnter Then

                If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = False Then

                    Me.FindForm.SelectNextControl(Me, True, True, True, True)

                ElseIf e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

                    Me.FindForm.SelectNextControl(Me, False, True, True, True)

                End If

            End If

            MyBase.OnKeyDown(e)

        End Sub
        Public Sub CheckSpelling()

            Dim SpellChecker As AdvantageFramework.WinForm.Presentation.Controls.SpellChecker = Nothing
            Dim OriginalShowSpellCheckCompleteMessage As Boolean = False

            If DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SpellChecker IsNot Nothing AndAlso _CheckingSpelling = False Then

                _CheckingSpelling = True

                Try

                    SpellChecker = DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SpellChecker

                    OriginalShowSpellCheckCompleteMessage = SpellChecker.ShowSpellCheckCompleteMessage

                    SpellChecker.ShowSpellCheckCompleteMessage = _ShowSpellCheckCompleteMessage

                    Me.Text = SpellChecker.Check(Me.Text)

                    SpellChecker.ShowSpellCheckCompleteMessage = OriginalShowSpellCheckCompleteMessage

                Catch ex As Exception
                    Me.Text = Me.Text
                End Try

                _CheckingSpelling = False

            End If

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Public Function GetText() As Object

            'objects
            Dim TheText As String = Nothing

            Try

                If String.IsNullOrWhiteSpace(Me.Text) = False Then

                    TheText = Me.Text

                Else

                    TheText = Nothing

                End If

            Catch ex As Exception
                TheText = Me.Text
            End Try

            GetText = TheText

        End Function
        Public Sub SetUserEntryChanged()

            _UserEntryChanged = True

            AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

        End Sub

#Region "  Control Event Handlers "

        Private Sub TextBox_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ButtonCustomClick

            Select Case _ControlType

                Case TextBox.Type.Default



                Case TextBox.Type.File

                    ControlType_File_ButtonCustomClick(sender, e)

                Case TextBox.Type.Office

                    ControlType_Office_ButtonCustomClick(sender, e)

                Case TextBox.Type.Employee

                    ControlType_Employee_ButtonCustomClick(sender, e)

                Case TextBox.Type.Function

                    ControlType_Function_ButtonCustomClick(sender, e)

                Case TextBox.Type.Folder

                    ControlType_Folder_ButtonCustomClick(sender, e)

                Case TextBox.Type.PostPeriod

                    ControlType_PostPeriod_ButtonCustomClick(sender, e)

                Case TextBox.Type.Vendor

                    ControlType_Vendor_ButtonCustomClick(sender, e)

            End Select

        End Sub
        Private Sub TextBox_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Private Sub TextBox_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

            'RemoveHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Private Sub TextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

            If Not Me.Multiline AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then

                e.SuppressKeyPress = True

            End If

        End Sub
        Private Sub TextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged

            'objects
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = ""
            Dim ParentForm As System.Windows.Forms.Form = Nothing
            Dim CustomValidatorControl As AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl = Nothing

            If Me.Focused = False Then

                IsValid = Validate(ErrorMessage)

                ParentForm = Me.FindForm

                If ParentForm IsNot Nothing AndAlso TypeOf ParentForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    If DirectCast(ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuperValidator IsNot Nothing Then

                        CustomValidatorControl = DirectCast(ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuperValidator.GetValidator1(Me)

                        If CustomValidatorControl IsNot Nothing Then

                            CustomValidatorControl.DisplayError = Not IsValid
                            CustomValidatorControl.ErrorMessage = ErrorMessage

                        End If

                    End If

                End If

            End If

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        'Private Sub ButtonItemMenu_SpellCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMenu_SpellCheck.Click

        '    CheckSpelling()

        'End Sub

#End Region

#Region "  Custom Control Event Handlers "

#Region "   Social Security Number "

        Private Function ControlType_SocialSecurityNumber_Validation(ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                If _IsRequired OrElse Me.Text <> "" Then

                    If AdvantageFramework.StringUtilities.IsValidSocialSecurityNumber(Me.Text, True) = False Then

                        ErrorText = "Please enter a valid Social Security Number"
                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                ControlType_SocialSecurityNumber_Validation = IsValid
                RaiseEvent TagObjectChanged()
            End Try

        End Function

#End Region

#Region "   Function "

        Private Sub ControlType_Function_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim SelectedFunctions As IEnumerable = Nothing
            Dim FunctionCode As String = ""

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Function, True, True, SelectedFunctions) = Windows.Forms.DialogResult.OK Then

                If SelectedFunctions IsNot Nothing Then

                    Try

                        FunctionCode = (From Entity In SelectedFunctions
                                        Select Entity.Code).FirstOrDefault

                    Catch ex As Exception
                        FunctionCode = ""
                    Finally

                        If FunctionCode <> "" Then

                            Me.Text = FunctionCode
                            ControlType_Function_Validation("")

                        End If

                    End Try

                End If

            End If

        End Sub
        Private Function ControlType_Function_Validation(ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            Try

                If _Session Is Nothing Then

                    IsValid = False

                End If

                If IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, Me.Text)

                        If [Function] Is Nothing Then

                            ErrorText = "Please enter a valid function code"
                            IsValid = False

                        End If

                    End Using

                End If

                Me.Tag = [Function]

            Catch ex As Exception
                IsValid = False
            Finally
                ControlType_Function_Validation = IsValid
                RaiseEvent TagObjectChanged()
            End Try

        End Function

#End Region

#Region "   Employee "

        Private Sub ControlType_Employee_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim SelectedEmployees As IEnumerable = Nothing
            Dim EmployeeCode As String = ""

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Employee, True, True, SelectedEmployees) = Windows.Forms.DialogResult.OK Then

                If SelectedEmployees IsNot Nothing Then

                    Try

                        EmployeeCode = (From Entity In SelectedEmployees
                                        Select Entity.Code).FirstOrDefault

                    Catch ex As Exception
                        EmployeeCode = ""
                    Finally

                        If EmployeeCode <> "" Then

                            Me.Text = EmployeeCode
                            ControlType_Employee_Validation("")

                        End If

                    End Try

                End If

            End If

        End Sub
        Private Function ControlType_Employee_Validation(ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                If _Session Is Nothing Then

                    IsValid = False

                End If

                If IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Text)

                        If Employee Is Nothing Then

                            ErrorText = "Please enter a valid employee code"
                            IsValid = False

                        End If

                    End Using

                End If

                Me.Tag = Employee

            Catch ex As Exception
                IsValid = False
            Finally
                ControlType_Employee_Validation = IsValid
                RaiseEvent TagObjectChanged()
            End Try

        End Function

#End Region

#Region "   Office "

        Private Sub ControlType_Office_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim SelectedOffices As IEnumerable = Nothing
            Dim OfficeCode As String = ""

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Office, True, True, SelectedOffices) = Windows.Forms.DialogResult.OK Then

                If SelectedOffices IsNot Nothing Then

                    Try

                        OfficeCode = (From Entity In SelectedOffices
                                      Select Entity.Code).FirstOrDefault

                    Catch ex As Exception
                        OfficeCode = ""
                    Finally

                        If OfficeCode <> "" Then

                            Me.Text = OfficeCode
                            ControlType_Office_Validation("")

                        End If

                    End Try

                End If

            End If

        End Sub
        Private Function ControlType_Office_Validation(ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

            Try

                If _Session Is Nothing Then

                    IsValid = False

                End If

                If IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Me.Text)

                        If Office Is Nothing Then

                            ErrorText = "Please enter a valid office code"
                            IsValid = False

                        End If

                    End Using

                End If

                Me.Tag = Office

            Catch ex As Exception
                IsValid = False
            Finally
                ControlType_Office_Validation = IsValid
                RaiseEvent TagObjectChanged()
            End Try

        End Function

#End Region

#Region "   File "

        Private Sub ControlType_File_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim File As String = ""
            Dim Files() As String = Nothing

            If _AgencyImportPath = "" Then

                File = AdvantageFramework.WinForm.Presentation.SelectFileToOpen(_StartingFolderName, AdvantageFramework.FileSystem.LoadFileFilterString(_FileFilter), "")

                If String.IsNullOrEmpty(File) = False AndAlso System.IO.File.Exists(File) Then

                    Me.Text = File

                End If

            Else

                If AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyImportPath, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({_FileFilter}), False, Files) = System.Windows.Forms.DialogResult.OK Then

                    Try

                        File = Files(0)

                    Catch ex As Exception
                        File = ""
                    End Try

                    Me.Text = File.Replace(AdvantageFramework.StringUtilities.AppendTrailingCharacter(_AgencyImportPath, "\"), "").Trim

                End If

            End If

        End Sub
        Private Function ControlType_File_Validation(ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim FileInfo As System.IO.FileInfo = Nothing

            Try

                If My.Computer.FileSystem.FileExists(Me.Text) = False Then

                    If Not _IsRequired AndAlso Me.Text = "" Then

                        IsValid = True

                    Else

                        ErrorText = "Please select a valid file"
                        IsValid = False

                    End If

                End If

                If IsValid And Me.Text <> "" Then

                    FileInfo = New System.IO.FileInfo(Me.Text)

                    If _FileFilter <> AdvantageFramework.FileSystem.FileFilters.Default Then

                        If FileInfo.Extension.ToUpper <> CStr("." & _FileFilter.ToString.ToUpper) Then

                            ErrorText = "Please enter a valid file with correct extension"
                            IsValid = False

                        End If

                    End If

                    If MaxFileSize > 0 Then

                        If FileInfo.Length > MaxFileSize Then

                            ErrorText = "Max file size is " & AdvantageFramework.FileSystem.GetFileSizeWithNotation(MaxFileSize)
                            IsValid = False

                        End If

                    End If

                End If

                Me.Tag = FileInfo

            Catch ex As Exception
                IsValid = False
            Finally
                ControlType_File_Validation = IsValid
                RaiseEvent TagObjectChanged()
            End Try

        End Function

#End Region

#Region "   Folder "

        Private Sub ControlType_Folder_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs)

            AdvantageFramework.WinForm.Presentation.BrowseForFolder(Me.Text, Me.StartingFolderName)

        End Sub
        Private Function ControlType_Folder_Validation(ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try


                If My.Computer.FileSystem.DirectoryExists(Me.Text) = False Then

                    If _IsRequired OrElse Me.Text <> "" Then

                        ErrorText = "Please select a valid folder"
                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                ControlType_Folder_Validation = IsValid
            End Try

        End Function

#End Region

#Region "   Post Period "

        Private Sub ControlType_PostPeriod_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim SelectedPostPeriods As IEnumerable = Nothing
            Dim PostPeriodCode As String = ""

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.PostPeriod, True, False, SelectedPostPeriods) = Windows.Forms.DialogResult.OK Then

                If SelectedPostPeriods IsNot Nothing Then

                    Try

                        PostPeriodCode = (From Entity In SelectedPostPeriods
                                          Select Entity.Code).FirstOrDefault

                    Catch ex As Exception
                        PostPeriodCode = ""
                    Finally

                        If PostPeriodCode <> "" Then

                            Me.Text = PostPeriodCode
                            ControlType_PostPeriod_Validation("")

                        End If

                    End Try

                End If

            End If

        End Sub
        Private Function ControlType_PostPeriod_Validation(ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                If _Session Is Nothing Then

                    IsValid = False

                End If

                If IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, Me.Text)

                        If PostPeriod Is Nothing Then

                            ErrorText = "Please enter a valid post period code"
                            IsValid = False

                        End If

                    End Using

                End If

                Me.Tag = PostPeriod

            Catch ex As Exception
                IsValid = False
            Finally
                ControlType_PostPeriod_Validation = IsValid
                RaiseEvent TagObjectChanged()
            End Try

        End Function

#End Region

#Region "   Email "

        Private Function ControlType_Email_Validation(ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                If _Session Is Nothing Then

                    IsValid = False

                End If

                If IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If Me.Text <> "" AndAlso Not AdvantageFramework.StringUtilities.IsValidEmailAddress(Me.Text) Then

                            ErrorText = "Please enter a valid email address"
                            IsValid = False

                        End If

                    End Using

                End If

                Me.Tag = Me.Text

            Catch ex As Exception
                IsValid = False
            Finally
                ControlType_Email_Validation = IsValid
                RaiseEvent TagObjectChanged()
            End Try

        End Function

#End Region

#Region "   Vendor "

        Private Sub ControlType_Vendor_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim SelectedVendors As IEnumerable = Nothing
            Dim VendorCode As String = ""

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Vendor, True, True, SelectedVendors, False) = Windows.Forms.DialogResult.OK Then

                If SelectedVendors IsNot Nothing Then

                    Try

                        VendorCode = (From Entity In SelectedVendors
                                      Select Entity.Code).FirstOrDefault

                    Catch ex As Exception
                        VendorCode = ""
                    Finally

                        If VendorCode <> "" Then

                            Me.Text = VendorCode
                            ControlType_Vendor_Validation("")

                        End If

                    End Try

                End If

            End If

        End Sub
        Private Function ControlType_Vendor_Validation(ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                If _Session Is Nothing Then

                    IsValid = False

                End If

                If IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Me.Text)

                        Catch ex As Exception
                            IsValid = False
                            Vendor = Nothing
                        End Try

                        If Vendor Is Nothing Then

                            IsValid = False

                        End If

                    End Using

                End If

                Me.Tag = Vendor

            Catch ex As Exception
                IsValid = False
            Finally

                If IsValid = False Then

                    ErrorText = "Please select a valid vendor."

                End If

                ControlType_Vendor_Validation = IsValid
                RaiseEvent TagObjectChanged()
            End Try

        End Function

#End Region

#End Region

#End Region

    End Class

End Namespace