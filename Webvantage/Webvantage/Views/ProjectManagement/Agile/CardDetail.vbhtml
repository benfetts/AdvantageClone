@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.CardDetail
@Code

    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
<table style="">
    <tr>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            @Code

                If Model.Comments IsNot Nothing AndAlso Model.Comments.Count > 0 Then

                    Dim BoardBuilder = Html.EJ().Grid(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardDetail.Comment)("CommentsGrid")
                    BoardBuilder.AllowTextWrap(True)
                    BoardBuilder.Datasource(Model.Comments)
                    BoardBuilder.Columns(Sub(Column)

                                             Column.Field("Comment").HeaderText("Comment").EditType(EditingType.StringEdit).Add()
                                             Column.Field("UserCode").HeaderText("UserCode").EditType(EditingType.StringEdit).Width(150).Add()
                                             Column.Field("CommentDate").HeaderText("Date").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Format("{0:f}").Add()

                                         End Sub)
                    BoardBuilder.Render()


                End If

            End Code   
        </td>
    </tr>
</table>
