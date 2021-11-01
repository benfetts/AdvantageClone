Namespace Web.Presentation.Controls

    Public Class ProgressIndicator

        Public Const Red As String = "#E72F40"
        Public Const Yellow As String = "#FFD600"
        Public Const Green As String = "#47BC1D"

        Public Property Height As Integer = 13
        Public Property Width As Integer = 100

        Public Property Max As Integer = 100
        Public Property Value As Integer = 0
        Public Property Color As String = "#616161" ' hex value
        Public Property ToolTip As String = ""
        Public Property OnClick As String = ""

        Public Property MarginTop As Integer = 0
        Public Property MarginBottom As Integer = 0

        Public Function DrawHTML() As String

            ToolTip = ToolTip.Trim()
            OnClick = OnClick.Trim()

            If Max > 0 AndAlso Width <> Max Then

                Value = (Value / Max) * Width

            End If

            Dim ProgressStringBuilder As New System.Text.StringBuilder

            If MarginTop <> 0 OrElse MarginBottom <> 0 Then
                ProgressStringBuilder.Append("<div ")
                ProgressStringBuilder.Append(" style=""")
                If MarginTop <> 0 Then

                    ProgressStringBuilder.Append("margin-top:")
                    ProgressStringBuilder.Append(MarginTop.ToString())
                    ProgressStringBuilder.Append("px;")

                End If
                If MarginBottom <> 0 Then

                    ProgressStringBuilder.Append("margin-bottom:")
                    ProgressStringBuilder.Append(MarginBottom.ToString())
                    ProgressStringBuilder.Append("px;")

                End If
                ProgressStringBuilder.Append(""">")
            End If

            ProgressStringBuilder.Append("<div ")

            If ToolTip <> "" Then

                ProgressStringBuilder.Append("title=""")
                ProgressStringBuilder.Append(ToolTip)
                ProgressStringBuilder.Append(""" ")

            End If

            If OnClick <> "" Then

                ProgressStringBuilder.Append(" onclick=""")
                ProgressStringBuilder.Append(OnClick)
                ProgressStringBuilder.Append(" return false;""")

            End If

            ProgressStringBuilder.Append("")
            ProgressStringBuilder.Append("style=""width: ")
            ProgressStringBuilder.Append(Width.ToString())
            ProgressStringBuilder.Append("px; border: 1px solid ")
            ProgressStringBuilder.Append(Color)
            ProgressStringBuilder.Append(";padding: 0px;height: ")
            ProgressStringBuilder.Append(Height.ToString())
            ProgressStringBuilder.Append("px;overflow: hidden;""><div style=""width: ")
            ProgressStringBuilder.Append(Value.ToString())
            ProgressStringBuilder.Append("px;background-color: ")
            ProgressStringBuilder.Append(Color)
            ProgressStringBuilder.Append(";height: ")
            ProgressStringBuilder.Append(Height.ToString())
            ProgressStringBuilder.Append("px;")


            If OnClick <> "" Then

                ProgressStringBuilder.Append("cursor: pointer;")

            End If

            ProgressStringBuilder.Append("""></div></div>")
            If MarginTop <> 0 OrElse MarginBottom <> 0 Then
                ProgressStringBuilder.Append("</div>")
            End If
            Return ProgressStringBuilder.ToString()

        End Function

        Sub New()

        End Sub

    End Class

End Namespace


