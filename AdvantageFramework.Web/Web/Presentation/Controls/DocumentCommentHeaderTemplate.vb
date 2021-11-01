Namespace Web.Presentation.Controls

    Public Class DocumentCommentHeaderTemplate
        Implements System.Web.UI.ITemplate

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DocumentCommentID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByVal DocumentCommentID As Integer)

            _DocumentCommentID = DocumentCommentID

        End Sub
        Public Sub InstantiateIn(ByVal Container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn

            Dim ImageButton As System.Web.UI.WebControls.ImageButton = Nothing

            ImageButton = New System.Web.UI.WebControls.ImageButton()

            ImageButton.ImageUrl = "~/Images/delete.png"
            ImageButton.ID = "DocumentCommentDelete" & _DocumentCommentID
            ImageButton.ToolTip = "Click to delete this row"
            ImageButton.CommandName = "DocumentCommentDelete"
            ImageButton.CommandArgument = _DocumentCommentID

            Container.Controls.Add(ImageButton)

        End Sub

#End Region

    End Class

End Namespace