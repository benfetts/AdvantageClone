Namespace WinForm.Presentation.Controls

    Public Class TimePicker
        Inherits Telerik.WinControls.UI.RadTimePicker
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As TimePicker.Type = TimePicker.Type.Default
        Protected _IsRequired As Boolean = False
        Protected _DisplayName As String = ""
        Protected _FormSettingsLoaded As Boolean = False
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _ReadOnly As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _TabOnEnter As Boolean = True

#End Region

#Region " Properties "

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
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Controls.Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Public Property ControlType() As TimePicker.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As TimePicker.Type)
                _ControlType = value
                SetControlType()
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
        Public Property TabOnEnter() As Boolean
            Get
                TabOnEnter = _TabOnEnter
            End Get
            Set(ByVal value As Boolean)
                _TabOnEnter = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.AutoSize = False
            Me.Size = New System.Drawing.Size(75, 20)
            Me.ClockPosition = Telerik.WinControls.UI.ClockPosition.HideClock
            Me.TabStop = True
            Me.TimeTables = Telerik.WinControls.UI.TimeTables.HoursAndMinutesInOneTable
            Me.DoubleBuffered = True

            AddHandler Me.TimePickerElement.PopupForm.MouseDown, AddressOf TimePicker_MouseDown

        End Sub
        Protected Overrides Sub Finalize()

            RemoveHandler Me.TimePickerElement.PopupForm.MouseDown, AddressOf TimePicker_MouseDown

            MyBase.Finalize()

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Protected Sub LoadFormSettings(Form As Windows.Forms.Form) Implements Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then



                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum], Optional ByVal CustomDisplayName As String = "")

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper)

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor, CustomDisplayName)

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, Optional ByVal CustomDisplayName As String = "")

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If PropertyDescriptor IsNot Nothing Then

                _DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

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

            If CustomDisplayName <> "" Then

                _DisplayName = CustomDisplayName

            End If

        End Sub
        Public Sub SetPropertySettings(ByVal EnumProperty As [Enum], Optional ByVal CustomDisplayName As String = "")

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor, CustomDisplayName)

        End Sub
        Public Sub SetRequired(ByVal IsRequired As Boolean)

            _IsRequired = IsRequired

            If _IsRequired Then

                Me.BackColor = Drawing.Color.Cyan

            End If

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case TimePicker.Type.Default

                    Me.Value = Now
                    Me.ClockPosition = Telerik.WinControls.UI.ClockPosition.HideClock
                    Me.TimeTables = Telerik.WinControls.UI.TimeTables.HoursAndMinutesInOneTable

            End Select

        End Sub
        Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim Name As String = ""

            Try

                If _IsRequired Then

                    If Me.Text.Trim = "" OrElse Me.Value.HasValue = False Then

                        If _DisplayName <> "" Then

                            ErrorMessage = _DisplayName & " is required."

                        Else

                            Try

                                Name = AdvantageFramework.StringUtilities.GetNameAsWords(Me.Name.Substring(Me.Name.IndexOf("_") + 1))

                            Catch ex As Exception
                                Name = ""
                            End Try

                            ErrorMessage = Name & " is required."

                        End If

                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                Validate = IsValid
            End Try

        End Function
        Public Function GetValue() As Object

            Dim Value As Object = Nothing

            If Me.Value.HasValue Then

                Try

                    Value = Convert.ToDateTime(Me.Value)

                Catch ex As Exception
                    Value = Nothing
                End Try

            End If

            GetValue = Value

        End Function
        Public Shadows Sub Show()

            Me.Visible = True

        End Sub
        Public Shadows Sub Hide()

            Me.Visible = False

        End Sub
        Public Overrides Sub OnKeyDown(sender As Object, e As Windows.Forms.KeyEventArgs)

            If _TabOnEnter Then

                If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = False Then

                    System.Windows.Forms.SendKeys.Send("{TAB}")

                    'below does not work
                    'Me.FindForm.SelectNextControl(Me, True, True, True, True)

                ElseIf e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

                    Me.FindForm.SelectNextControl(Me, False, True, True, True)

                End If

            End If

            MyBase.OnKeyDown(sender, e)

        End Sub
#Region "  Control Event Handlers "

        Private Sub TimePicker_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs)

            Dim TimeTableVisualElement As Telerik.WinControls.UI.TimeTableVisualElement = Nothing

            Try

                TimeTableVisualElement = Me.TimePickerElement.PopupContentElement.ElementTree.GetElementAtPoint(e.Location)

            Catch ex As Exception
                TimeTableVisualElement = Nothing
            End Try

            If TimeTableVisualElement IsNot Nothing Then

                If TimeTableVisualElement.FindAncestor(Of Telerik.WinControls.UI.TimeTableElementHours)() IsNot Nothing Then

                    If Me.TimePickerElement.IsPopupOpen Then

                        Me.TimePickerElement.ClosePopup()

                    End If

                End If

            End If

        End Sub
        Private Sub TimePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ValueChanged

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
