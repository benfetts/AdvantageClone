Namespace WinForm.Presentation

    Public Class NumericInputDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EnumProperty As [Enum] = Nothing
        Private _NumericInputControlType As AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type = Presentation.Controls.NumericInput.Type.Default
        Private _IsRequired As Nullable(Of Boolean) = Nothing
        Private _MinValue As Nullable(Of Double) = Nothing
        Private _MaxValue As Nullable(Of Double) = Nothing
        Private _DisplayFormat As String = Nothing
        Private _MaxLength As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        Private WriteOnly Property Message() As String
            Set(ByVal value As String)
                LabelForm_Message.Text = value
                ResetSizeOfText()
            End Set
        End Property
        Private WriteOnly Property DefaultValue() As Object
            Set(ByVal value As Object)
                NumericInputForm_Input.Value = value
            End Set
        End Property
        Private ReadOnly Property Value() As Decimal
            Get
                Value = NumericInputForm_Input.Value
            End Get
        End Property
        Private WriteOnly Property EnumProperty As [Enum]
            Set(ByVal value As [Enum])
                _EnumProperty = value
            End Set
        End Property
        Private WriteOnly Property NumericInputControlType As AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type
            Set(ByVal value As AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type)
                _NumericInputControlType = value
            End Set
        End Property
        Private WriteOnly Property IsRequired() As Nullable(Of Boolean)
            Set(value As Nullable(Of Boolean))
                _IsRequired = value
            End Set
        End Property
        Private WriteOnly Property MinValue() As Nullable(Of Double)
            Set(value As Nullable(Of Double))
                _MinValue = value
            End Set
        End Property
        Private WriteOnly Property MaxValue() As Nullable(Of Double)
            Set(value As Nullable(Of Double))
                _MaxValue = value
            End Set
        End Property
        Private WriteOnly Property DisplayFormat() As String
            Set(value As String)
                _DisplayFormat = value
            End Set
        End Property
        Private WriteOnly Property MaxLength() As Nullable(Of Integer)
            Set(value As Nullable(Of Integer))
                _MaxLength = value
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
            Dim BaseHeight As Integer = 0
            Dim BaseWidth As Integer = 0

            BaseWidth = 300
            BaseHeight = 169

            LinesArray = LabelForm_Message.Text.Split(vbCrLf)

            Select Case LinesArray.GetLength(0)

                Case 0, 1, 2, 3

                    Me.Height = BaseHeight

                Case Else

                    Me.Height = BaseHeight + (LinesArray.GetLength(0) - 3) * (13)

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

            Me.Width = BaseWidth

            If Me.Width < SizeF.Width + 24 Then

                Me.Width = SizeF.Width + 24

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Title As String, ByVal Message As String, ByVal DefaultValue As Object, ByRef Value As Object, Optional ByVal EnumProperty As [Enum] = Nothing, _
                                              Optional ByVal NumericControlType As AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type = Presentation.Controls.NumericInput.Type.Default, _
                                              Optional ByVal IsRequired As Nullable(Of Boolean) = Nothing, Optional MinValue As Nullable(Of Double) = Nothing,
                                              Optional MaxValue As Nullable(Of Double) = Nothing, Optional DisplayFormat As String = Nothing, _
                                              Optional MaxLength As Nullable(Of Integer) = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim NumericInputDialog As NumericInputDialog = Nothing

            NumericInputDialog = New NumericInputDialog

            NumericInputDialog.Text = Title
            NumericInputDialog.Message = Message
            NumericInputDialog.DefaultValue = DefaultValue
            NumericInputDialog.EnumProperty = EnumProperty
            NumericInputDialog.NumericInputControlType = NumericControlType
            NumericInputDialog.IsRequired = IsRequired
            NumericInputDialog.MinValue = MinValue
            NumericInputDialog.MaxValue = MaxValue
            NumericInputDialog.DisplayFormat = DisplayFormat
            NumericInputDialog.MaxLength = MaxLength

            If NumericInputDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Value = NumericInputDialog.Value
                ShowFormDialog = Windows.Forms.DialogResult.OK

            Else

                Value = 0
                ShowFormDialog = Windows.Forms.DialogResult.Cancel

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub NumericInputDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            
            NumericInputForm_Input.ControlType = _NumericInputControlType

            If _EnumProperty IsNot Nothing Then

                NumericInputForm_Input.SetPropertySettings(_EnumProperty)

            End If

            If _IsRequired IsNot Nothing Then

                NumericInputForm_Input.SetRequired(_IsRequired.Value)

                If _IsRequired.Value Then

                    NumericInputForm_Input.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                End If

            End If

            If _MinValue IsNot Nothing Then

                NumericInputForm_Input.Properties.MinValue = _MinValue.Value

            End If

            If _MaxValue IsNot Nothing Then

                NumericInputForm_Input.Properties.MaxValue = _MaxValue.Value

            End If

            If _DisplayFormat IsNot Nothing Then

                NumericInputForm_Input.SetFormat(_DisplayFormat)

            End If

            If _MaxLength IsNot Nothing Then

                NumericInputForm_Input.Properties.MaxLength = _MaxLength.Value

            End If

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

                NumericInputForm_Input.Focus()

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