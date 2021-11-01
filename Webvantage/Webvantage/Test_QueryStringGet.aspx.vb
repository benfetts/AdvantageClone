Public Class Test_QueryStringGet
    Inherits Webvantage.BaseChildPage

    Private _PageVariable As String = ""

    Private Sub Test_QueryStringGet_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Dim LocalClientCodeVariable As String = ""
        Dim LocalDivisionCodeVariable As String = ""
        Dim LocalContractId As Integer = 0

        LocalClientCodeVariable = qs.ClientCode
        LocalDivisionCodeVariable = qs.DivisionCode
        LocalContractId = qs.ContractID

        Me._PageVariable = qs.GetValue("myvar")

        With Response

            .Write(LocalClientCodeVariable)
            .Write("<br />")
            .Write(LocalDivisionCodeVariable)
            .Write("<br />")
            .Write(qs.ContractID) 'call direct
            .Write("<br />")
            .Write(_PageVariable)
            .Write("<br />")

        End With

    End Sub

End Class
