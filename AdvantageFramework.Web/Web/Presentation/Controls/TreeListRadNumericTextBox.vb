Namespace Web.Presentation.Controls

    Public Class TreeListRadNumericTextBox
        Inherits Telerik.Web.UI.TreeListColumnEditor

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing

#End Region

#Region " Properties "

        Public Property RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox
            Get
                RadNumericTextBox = _RadNumericTextBox
            End Get
            Set(value As Telerik.Web.UI.RadNumericTextBox)
                _RadNumericTextBox = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Column As Telerik.Web.UI.TreeListEditableColumn)

            MyBase.New(Column)
            InitializeRadNumericTextBox()

        End Sub
        Protected Overridable Sub InitializeRadNumericTextBox()

            _RadNumericTextBox = New Telerik.Web.UI.RadNumericTextBox()
            _RadNumericTextBox.ID = MyBase.GenerateControlID()

        End Sub
        Public Overrides Function GetValues() As IEnumerable

            GetValues = New Double(0) {_RadNumericTextBox.Value.GetValueOrDefault(0)}

        End Function
        Public Overrides Sub Initialize(editItem As Telerik.Web.UI.TreeListEditableItem, container As System.Web.UI.Control)
            container.Controls.Add(_RadNumericTextBox)
        End Sub
        Public Overrides Sub SetValues(values As IEnumerable)

            Dim Value As Object = Nothing

            Value = Telerik.Web.UI.TreeListColumnEditor.GetFirstValueFromEnumerable(values)

            If Value IsNot Nothing AndAlso IsNumeric(Value) Then

                _RadNumericTextBox.Value = CDbl(Value)

            End If

        End Sub

#End Region

    End Class

End Namespace