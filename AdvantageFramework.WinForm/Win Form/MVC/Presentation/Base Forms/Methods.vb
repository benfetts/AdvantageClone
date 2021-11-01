Namespace WinForm.MVC.Presentation

	<HideModuleName()>
	Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Public Function GetComboBoxControls(ByVal ControlCollection As System.Windows.Forms.Control.ControlCollection) As List(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox)

			'objects
			Dim ComboBoxList As Generic.List(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox) = Nothing

			ComboBoxList = New Generic.List(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox)

			For Each Control In ControlCollection

				If Control.[GetType]().Equals(GetType(AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox)) Then

					ComboBoxList.Add(Control)

				End If

				If Control.Controls.Count > 0 Then

					ComboBoxList.AddRange(GetComboBoxControls(Control.Controls))

				End If

			Next

			GetComboBoxControls = ComboBoxList

		End Function

#End Region

	End Module

End Namespace
