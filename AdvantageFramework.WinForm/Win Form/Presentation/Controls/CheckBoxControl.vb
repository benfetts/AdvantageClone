Namespace WinForm.Presentation.Controls

    Public Class CheckBox
        Inherits DevComponents.DotNetBar.Controls.CheckBoxX
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Checked1Unchecked0]
            [Checked0Unchecked1]
        End Enum

        Public Enum CheckValueTypes
            [Integer]
            [Short]
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.[Checked1Unchecked0]
        Protected _CheckValueType As AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.Integer
        Protected _ChildControls As Generic.List(Of Object) = New Generic.List(Of Object)
        Protected _SiblingControls As Generic.List(Of Object) = New Generic.List(Of Object)
        Protected _OldestSibling As Object = Nothing
        Private _SecurityEnabled As Boolean = True
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _TabOnEnter As Boolean = True

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
        Public Property ControlType() As AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type)
                _ControlType = value
                SetupCheckBox()
            End Set
        End Property
        Public Property CheckValueType As AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes
            Get
                CheckValueType = _CheckValueType
            End Get
            Set(ByVal value As AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes)
                _CheckValueType = value
                SetupCheckBox()
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public Property ChildControls() As Generic.List(Of Object)
            Get
                ChildControls = _ChildControls
            End Get
            Set(ByVal value As Generic.List(Of Object))
                _ChildControls = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public Property SiblingControls() As Generic.List(Of Object)
            Get
                SiblingControls = _SiblingControls
            End Get
            Set(ByVal value As Generic.List(Of Object))
                _SiblingControls = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public Property OldestSibling() As Object
            Get
                OldestSibling = _OldestSibling
            End Get
            Set(ByVal value As Object)
                _OldestSibling = value
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

            Me.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox
            Me.Size = New System.Drawing.Size(Me.Size.Width, 20)
            Me.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DoubleBuffered = True

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Protected Overridable Sub SetupCheckBox()

            Select Case _ControlType

                Case Type.Checked1Unchecked0

                    Me.CheckValueChecked = 1
                    Me.CheckValueUnchecked = 0
                    Me.CheckValue = 0

                Case Type.Checked0Unchecked1

                    Me.CheckValueChecked = 0
                    Me.CheckValueUnchecked = 1
                    Me.CheckValue = 1

            End Select

            SetupCheckValueType()

        End Sub
        Protected Overridable Sub SetupCheckValueType()

            Select Case _CheckValueType

                Case CheckValueTypes.Integer

                    Me.CheckValueChecked = CInt(Me.CheckValueChecked)
                    Me.CheckValueUnchecked = CInt(Me.CheckValueUnchecked)
                    Me.CheckValue = CInt(Me.CheckValue)

                Case CheckValueTypes.Short

                    Me.CheckValueChecked = CShort(Me.CheckValueChecked)
                    Me.CheckValueUnchecked = CShort(Me.CheckValueUnchecked)
                    Me.CheckValue = CShort(Me.CheckValue)

            End Select

        End Sub
        Public Sub HandlesControl(ByVal RelatedControl As Object, ByVal RadioButtonStyle As Boolean)

            RelatedControl.Enabled = If(RadioButtonStyle, Not Me.Checked, Me.Checked)

            If TypeOf RelatedControl Is AdvantageFramework.WinForm.Presentation.Controls.CheckBox AndAlso Me.Checked = If(RadioButtonStyle, True, False) Then

                RelatedControl.Checked = False

            End If

        End Sub
        Public Sub HandlesControl(ByVal RelatedControls As Generic.List(Of Object), ByVal RadioButtonStyle As Boolean)

            For Each Control In RelatedControls

                Control.Enabled = If(RadioButtonStyle, Not Me.Checked, Me.Checked)

                If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.CheckBox AndAlso Me.Checked = If(RadioButtonStyle, True, False) Then

                    Control.Checked = False

                End If

            Next

        End Sub
        Public Sub HandleChildControls()

            If ChildControls IsNot Nothing Then

                If ChildControls.Count > 0 Then

                    For Each Control In ChildControls

                        Control.Enabled = Me.Checked

                        If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.CheckBox AndAlso Not Me.Checked Then

                            Control.Checked = False

                        End If

                    Next

                End If

            End If

        End Sub
        Public Sub HandleSiblingControls()

            Dim CheckboxSibling As AdvantageFramework.WinForm.Presentation.Controls.CheckBox = Nothing
            Dim SiblingList As Generic.List(Of Object) = Nothing

            If SiblingControls IsNot Nothing Then

                If SiblingControls.Count > 0 OrElse OldestSibling IsNot Nothing Then

                    If OldestSibling IsNot Nothing AndAlso TypeOf OldestSibling Is AdvantageFramework.WinForm.Presentation.Controls.CheckBox Then

                        SiblingList = New Generic.List(Of Object)

                        CheckboxSibling = OldestSibling

                        SiblingList.Add(CheckboxSibling)

                        For Each Control In CheckboxSibling.SiblingControls.Where(Function(sibControl) sibControl IsNot Me)

                            SiblingList.Add(Control)

                        Next

                    Else

                        SiblingList = SiblingControls

                    End If

                    For Each Control In SiblingList

                        Control.Enabled = Not Me.Checked

                        If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.CheckBox AndAlso Me.Checked Then

                            Control.Checked = False

                        End If

                    Next

                End If

            End If

        End Sub
        Public Sub HandleAllControls()

            HandleChildControls()
            HandleSiblingControls()

        End Sub
        Public Function GetValue() As Object

            'objects
            Dim CheckValue As Object = Nothing

            Try

                Select Case _CheckValueType

                    Case CheckValueTypes.Integer
                        
                        CheckValue = Convert.ToInt32(Me.CheckValue)

                    Case CheckValueTypes.Short

                        CheckValue = Convert.ToInt16(Me.CheckValue)

                End Select

            Catch ex As Exception
                CheckValue = Nothing
            End Try

            GetValue = CheckValue

        End Function
        Protected Overrides Sub OnKeyDown(e As Windows.Forms.KeyEventArgs)

            If _TabOnEnter Then

                If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = False Then

                    Me.FindForm.SelectNextControl(Me, True, True, True, True)
                    e.Handled = True

                ElseIf e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

                    Me.FindForm.SelectNextControl(Me, False, True, True, True)
                    e.Handled = True

                End If

            End If

            If Not e.Handled Then

                MyBase.OnKeyDown(e)

            End If
            
        End Sub

#Region "  Control Event Handlers "

        Private Sub CheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CheckedChanged

            '_UserEntryChanged = True

            'AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

        End Sub
        Private Sub CheckBox_CheckedChangedEx(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles Me.CheckedChangedEx

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        Private Sub CheckBox_CheckValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CheckValueChanged

            '_UserEntryChanged = True

            'AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
