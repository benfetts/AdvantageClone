Namespace WinForm.Presentation.Controls

    Public Class DateEdit
        Inherits DevExpress.XtraEditors.DateEdit
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

        Protected _ControlType As DateEdit.Type = DateEdit.Type.Default
        Protected _IsRequired As Boolean = False
        Protected _DisplayName As String = ""
        Protected _FormSettingsLoaded As Boolean = False
        Protected _ErrorIconAlignment As System.Windows.Forms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _ReadOnly As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _OriginalInputButtonSettings As Hashtable = Nothing
        Protected _ShowingButtons As Boolean = False
        Protected _TabOnEnter As Boolean = True
        Private _SecurityEnabled As Boolean = True

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
        Public Property ControlType() As DateEdit.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As DateEdit.Type)
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

#End Region

#Region " Methods "

        Public Sub New()

            Me.Size = New System.Drawing.Size(75, 20)
            Me.Properties.MinValue = #1/1/1900#
            Me.Properties.MaxValue = #6/6/2079#

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DoubleBuffered = True

            _OriginalInputButtonSettings = New Hashtable

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.ErrorProvider.SetIconAlignment(Me, _ErrorIconAlignment)

                    End If

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

            Else

                Me.BackColor = Drawing.Color.White

            End If

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case DateEdit.Type.Default

                    Me.Properties.DisplayFormat.FormatString = "d"
                    Me.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                    Me.Properties.EditFormat.FormatString = "d"
                    Me.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                    Me.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret

                    Me.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret

                    Me.EditValue = CDate(Now.ToShortDateString)

            End Select

        End Sub
        Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim Name As String = ""

            Try

                If _IsRequired Then

                    If Me.Text.Trim = "" OrElse Me.EditValue Is Nothing Then

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

            If Me.EditValue <> Nothing Then

                Try

                    Value = Convert.ToDateTime(Me.EditValue)

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

#Region "  Control Event Handlers "

        Private Sub DateEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles Me.EditValueChanging

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        Private Sub DateEdit_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles Me.ParseEditValue

            'objects
            Dim EnteredDate As String = Nothing
            Dim EnteredDateValue As Date = Nothing
            Dim MinDateValue As Date = Nothing
            Dim MaxDateValue As Date = Nothing

            If e.Value IsNot Nothing AndAlso e.Handled = False AndAlso e.Value.GetType IsNot GetType(Date) AndAlso IsDBNull(e.Value) = False Then

                EnteredDate = e.Value

                If String.IsNullOrWhiteSpace(EnteredDate) = False Then

                    Try

                        EnteredDateValue = AdvantageFramework.DateUtilities.ConvertStringToShortDateString(EnteredDate)

                    Catch ex As Exception
                        EnteredDateValue = Nothing
                    End Try

                    If IsNothing(EnteredDateValue) = False Then

                        Try

                            MinDateValue = CDate(Me.Properties.MinValue.ToShortDateString)

                        Catch ex As Exception
                            MinDateValue = CDate(Date.MinValue.ToShortDateString)
                        End Try

                        Try

                            MaxDateValue = CDate(Me.Properties.MaxValue.ToShortDateString)

                        Catch ex As Exception
                            MaxDateValue = CDate(Date.MaxValue.ToShortDateString)
                        End Try

                        If (EnteredDateValue >= MinDateValue OrElse MinDateValue = Nothing) AndAlso (EnteredDateValue <= MaxDateValue OrElse MaxDateValue = Nothing) Then

                            e.Value = CDate(EnteredDateValue)

                            e.Handled = True

                        Else

                            e.Handled = False

                        End If

                    Else

                        e.Handled = False

                    End If

                Else

                    e.Value = Nothing

                End If

            Else

                e.Handled = False

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
