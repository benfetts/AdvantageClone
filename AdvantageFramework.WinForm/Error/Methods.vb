Namespace [Error]

    <HideModuleName()> _
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

		Public Function ShowFormDialog(ByVal Exception As Exception) As Windows.Forms.DialogResult

			'objects
			Dim DialogResult As Windows.Forms.DialogResult = Windows.Forms.DialogResult.Ignore

			DialogResult = AdvantageFramework.Error.Presentation.ErrorDialog.ShowFormDialog(Exception)

			ShowFormDialog = DialogResult

		End Function
		Public Sub ShowFormDialog(Exception As Exception, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

			DialogResult = AdvantageFramework.Error.Presentation.ErrorDialog.ShowFormDialog(Exception)

		End Sub

#End Region

	End Module

End Namespace