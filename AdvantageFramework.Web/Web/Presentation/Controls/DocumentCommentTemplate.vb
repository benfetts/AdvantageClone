Namespace Web.Presentation.Controls

    Public Class DocumentCommentTemplate
        Implements System.Web.UI.ITemplate

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Comment As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByVal Comment As String)

            _Comment = Comment

        End Sub
        Private Sub InstantiateIn(ByVal Container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn

            'objects
            Dim HtmlGenericControl As System.Web.UI.HtmlControls.HtmlGenericControl = Nothing

            HtmlGenericControl = New System.Web.UI.HtmlControls.HtmlGenericControl()

            HtmlGenericControl.TagName = "div"
            HtmlGenericControl.Style("Font-family") = "Arial"

            HtmlGenericControl.InnerText = _Comment

            Container.Controls.Add(HtmlGenericControl)

        End Sub

#End Region

    End Class

End Namespace