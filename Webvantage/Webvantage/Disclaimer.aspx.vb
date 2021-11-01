Public Class Disclaimer
    Inherits Webvantage.BaseChildPage

    Public Enum [Type]
        QOTD = 0
        RSS = 1
        WOTD = 2
    End Enum
    Protected Sub Disclaimer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.DivQOTD.Visible = False
        Me.DivRSS.Visible = False
        Me.DivWOTD.Visible = False

        Select Case CType(Me.CurrentQuerystring.Get("disclaimer"), Integer)
            Case 0
                Me.DivQOTD.Visible = True
                Me.PageTitle = "Quote of the Day Disclaimer"
            Case 1
                Me.DivRSS.Visible = True
                Me.PageTitle = "News Reader Disclaimer"
            Case 2
                Me.DivWOTD.Visible = True
                Me.PageTitle = "Word of the Day Disclaimer"
        End Select

    End Sub

End Class