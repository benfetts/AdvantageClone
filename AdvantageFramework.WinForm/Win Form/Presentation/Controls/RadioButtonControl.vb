Namespace WinForm.Presentation.Controls

    Public Class RadioButtonControl
        Inherits DevComponents.DotNetBar.Controls.CheckBoxX
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Private _SecurityEnabled As Boolean = True
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
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Public Overrides Property Checked As Boolean
            Get
                Checked = MyBase.Checked
            End Get
            Set(ByVal value As Boolean)
                MyBase.Checked = value
                Me.TabStop = value
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

            Me.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.Size = New System.Drawing.Size(Me.Size.Width, 20)
            Me.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.TabStop = Me.Checked
            Me.DoubleBuffered = True
            Me.BackColor = Drawing.Color.White

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Protected Overrides Sub OnKeyDown(e As Windows.Forms.KeyEventArgs)

            If _TabOnEnter Then

                If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = False Then

                    Me.FindForm.SelectNextControl(Me, True, True, True, True)

                ElseIf e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

                    Me.FindForm.SelectNextControl(Me, False, True, True, True)

                End If

            End If

            MyBase.OnKeyDown(e)

        End Sub

#Region "  Control Event Handlers "

        Private Sub RadioButtonControl_CheckedChangedEx(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles Me.CheckedChangedEx

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
