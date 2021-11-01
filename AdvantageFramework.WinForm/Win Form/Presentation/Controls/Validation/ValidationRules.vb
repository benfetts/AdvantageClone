'Namespace WinForm.Presentation.Controls.Validation

'    Public Class ValidationRules
'        Inherits DevExpress.XtraEditors.DXErrorProvider.ValidationRuleBase


'#Region " Constants "



'#End Region

'#Region " Enum "



'#End Region

'#Region " Variables "



'#End Region

'#Region " Properties "



'#End Region

'#Region " Methods "

'        Public Sub New()

'            MyBase.New()

'        End Sub
'        Public Overrides Function Validate(ByVal Control As System.Windows.Forms.Control, ByVal Value As Object) As Boolean

'            'objects
'            Dim IsValid As Boolean = True

'            Me.ErrorText = ""
'            Me.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.None

'            If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

'                IsValid = DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.TextBox).Validate(Me.ErrorText, Me.ErrorType)

'            ElseIf TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.ComboBox Then

'                IsValid = DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.ComboBox).Validate(Me.ErrorText, Me.ErrorType)

'            End If

'            Validate = IsValid

'        End Function
'        Public Overrides Function Clone() As Object

'            Clone = MyBase.MemberwiseClone

'        End Function

'#End Region

'    End Class

'End Namespace

