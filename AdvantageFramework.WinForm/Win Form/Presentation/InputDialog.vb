Namespace WinForm.Presentation

    Public Class InputDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EnumProperty As [Enum] = Nothing
        Private _TextBoxControlType As AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type = Presentation.Controls.TextBox.Type.Default

#End Region

#Region " Properties "

        Private WriteOnly Property Message() As String
            Set(ByVal value As String)
                LabelForm_Message.Text = value
                ResetSizeOfText()
            End Set
        End Property
        Private WriteOnly Property DefaultValue() As String
            Set(ByVal value As String)
                TextBoxForm_Input.Text = value
            End Set
        End Property
        Private ReadOnly Property Value() As String
            Get
                Value = TextBoxForm_Input.Text
            End Get
        End Property
        Private WriteOnly Property EnumProperty As [Enum]
            Set(ByVal value As [Enum])
                _EnumProperty = value
            End Set
        End Property
        Private WriteOnly Property TextBoxControlType As AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type
            Set(ByVal value As AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type)
                _TextBoxControlType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub ResetSizeOfText()

            'objects
            Dim LinesArray() As String = Nothing
            Dim Graphic As System.Drawing.Graphics = Nothing
            Dim SizeF As System.Drawing.SizeF = Nothing
            Dim ArrayCounter As Integer = 0
            Dim LargestLine As String = ""
            Dim LargestLineIndex As Integer = 0

            LinesArray = LabelForm_Message.Text.Split(vbCrLf)

            Select Case LinesArray.GetLength(0)

                Case 0, 1, 2, 3

                    Me.Height = 148

                Case Else
                    Me.Height = 148 + (LinesArray.GetLength(0) - 3) * (13)

            End Select

            'loop through array
            Do While ArrayCounter < LinesArray.Length

                If LinesArray(ArrayCounter).Length > LargestLineIndex Then

                    LargestLineIndex = LinesArray(ArrayCounter).Length
                    LargestLine = LinesArray(ArrayCounter)

                End If
                'counter
                ArrayCounter += 1

            Loop

            Graphic = LabelForm_Message.CreateGraphics
            SizeF = Graphic.MeasureString(LargestLine, LabelForm_Message.Font)

            Me.Width = 254

            If Me.Width < SizeF.Width + 24 Then

                Me.Width = SizeF.Width + 24

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Title As String, ByVal Message As String, ByVal DefaultValue As String, ByRef Value As String, Optional ByVal EnumProperty As [Enum] = Nothing, _
                                              Optional ByVal TextBoxControlType As AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type = Presentation.Controls.TextBox.Type.Default) As System.Windows.Forms.DialogResult

            'objects
            Dim InputDialog As InputDialog = Nothing

            InputDialog = New InputDialog

            InputDialog.Text = Title

            InputDialog.Message = Message
            InputDialog.DefaultValue = DefaultValue

            InputDialog.EnumProperty = EnumProperty
            InputDialog.TextBoxControlType = TextBoxControlType

            If InputDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Value = InputDialog.Value
                ShowFormDialog = Windows.Forms.DialogResult.OK

            Else

                Value = ""
                ShowFormDialog = Windows.Forms.DialogResult.Cancel

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub InputDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            If _EnumProperty IsNot Nothing Then

                TextBoxForm_Input.SetPropertySettings(_EnumProperty)

            End If

            TextBoxForm_Input.ControlType = _TextBoxControlType

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                TextBoxForm_Input.Focus()

            End If
            
        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace