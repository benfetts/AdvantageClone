Namespace Database.Classes

    <Serializable()> _
    Public Class Content

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ContentType

            ProjectManagement = 1

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ContentUserID As Integer = 0
        Public Property ContentItemID As Integer = 0
        Public Property Name As String = ""
        Public Property PageName As String = ""
        Public Property UserControlName As String = ""
        Public Property ViewName As String = ""
        Public Property FormName As String = ""
        Public Property IsVisible As Boolean = False
        Public Property ContentCode As String = ""
        Public Property ModuleCode As String = ""
        Public Property HasContent As Boolean = False

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            Try

                Dim sb As New System.Text.StringBuilder
                With sb

                    .Append(ContentUserID)
                    .Append("|")
                    .Append(ContentItemID)
                    .Append("|")
                    .Append(Name)
                    .Append("|")
                    .Append(PageName)
                    .Append("|")
                    .Append(UserControlName)
                    .Append("|")
                    .Append(ViewName)
                    .Append("|")
                    .Append(FormName)
                    .Append("|")
                    .Append(IsVisible)
                    .Append("|")
                    .Append(ContentCode)
                    .Append("|")
                    .Append(ModuleCode)
                    .Append("|")
                    .Append(HasContent)

                End With

                Return sb.ToString()

            Catch ex As Exception

                Return ""

            End Try

        End Function
        Public Sub FromString(ByVal Value As String)

            Try

                Dim ar() As String
                ar = Value.Split("|")

                Me.ContentUserID = ar(0)
                Me.ContentItemID = ar(1)
                Me.Name = ar(2)
                Me.PageName = ar(3)
                Me.UserControlName = ar(4)
                Me.ViewName = ar(5)
                Me.FormName = ar(6)
                Me.IsVisible = ar(7)
                Me.ContentCode = ar(8)
                Me.ModuleCode = ar(9)
                Me.HasContent = ar(10)

            Catch ex As Exception

            End Try

        End Sub

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
