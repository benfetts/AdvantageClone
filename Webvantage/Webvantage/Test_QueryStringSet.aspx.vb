Public Class Test_QueryStringSet
    Inherits Webvantage.BaseChildPage


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim qs As New AdvantageFramework.Web.QueryString()

        With qs

            .Page = "Test_QueryStringGet.aspx"

            .ClientCode = "abc"
            .DivisionCode = "def"

            .ContractID = 1

            .Add("myvar", "somevalue")

            .Go() 'this will re-use the same window and load the new page

        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim qs As New AdvantageFramework.Web.QueryString()

        With qs

            .Page = "Test_QueryStringGet.aspx"

            .ClientCode = "abc"
            .DivisionCode = "def"

            .ContractID = 1

            .Add("myvar", "somevalue")

        End With

        Me.OpenWindow(qs) 'this will open a new window

    End Sub

End Class
