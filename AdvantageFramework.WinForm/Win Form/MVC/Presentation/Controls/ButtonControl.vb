Namespace WinForm.MVC.Presentation.Controls

	Public Class Button
		Inherits DevComponents.DotNetBar.ButtonX

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _SecurityEnabled As Boolean = True

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

#End Region

#Region " Methods "

		Public Sub New()

			Me.Size = New System.Drawing.Size(75, 20)
			Me.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.DoubleBuffered = True

		End Sub
		Public Sub UncheckAllSubItems()

			'objects
			Dim SubItems As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem = Nothing

			For Each SubItem In Me.SubItems

				SubItem.Checked = False

			Next

		End Sub

#Region "  Control Event Handlers "

		Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

			If Me.SubItems.Count > 0 AndAlso Me.AutoExpandOnClick AndAlso Me.Expanded = False Then

				Me.Expanded = True

			End If

		End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace
