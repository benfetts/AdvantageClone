Imports System.IO
Imports System.Web.UI

Namespace AlertSystem.Classes

    <Serializable()>
    Public Class CommentDocument

        Public Property Filename As String = ""
        Public Property DocumentId As Integer = 0
        Public Property MimeType As String = ""
        Public Property FileExtension As String = ""
        Public Property Title As String = ""

        Public Function ObjectToString(ByVal TheObject As Generic.List(Of CommentDocument)) As String

            Dim formatter As LosFormatter = New LosFormatter
            Dim writer As StringWriter = New StringWriter

            formatter.Serialize(writer, TheObject)

            Return writer.ToString()

        End Function
        Public Function StringToObject(ByVal TheString As String) As Generic.List(Of CommentDocument)

            Dim formatter As LosFormatter = New LosFormatter
            Dim reader As StringReader = New StringReader(TheString)

            Return CType(formatter.Deserialize(reader), Generic.List(Of CommentDocument))

        End Function

        Sub New()

        End Sub

    End Class

End Namespace
