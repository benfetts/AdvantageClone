Namespace WinForm.MVC.Presentation

	Public Class CRUDDialog

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum [Type]
			DatabaseProfile
		End Enum

#End Region

#Region " Variables "

		Private _FormType As AdvantageFramework.WinForm.MVC.Presentation.CRUDDialog.Type = AdvantageFramework.WinForm.MVC.Presentation.CRUDDialog.Type.DatabaseProfile

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New(ByVal FormType As AdvantageFramework.WinForm.MVC.Presentation.CRUDDialog.Type)

			' This call is required by the Windows Form Designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_FormType = FormType

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(ByVal FormType As AdvantageFramework.WinForm.MVC.Presentation.CRUDDialog.Type) As Windows.Forms.DialogResult

			'objects
			Dim CRUDDialog As AdvantageFramework.WinForm.MVC.Presentation.CRUDDialog = Nothing

			CRUDDialog = New AdvantageFramework.WinForm.MVC.Presentation.CRUDDialog(FormType)

			ShowFormDialog = CRUDDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub CRUDDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			Me.ShowUnsavedChangesOnFormClosing = False

		End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

	End Class

End Namespace
