Imports System.Data.SqlClient
Partial Public Class dtp_agencyGoals_print
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim startPP, endPP, Office As String

        LoadHeader()

        startPP = Session("PPBEGIN_AGLS")
        endPP = Session("PPEND_AGLS")
        Office = Session("OFFICE_AGLS")

        If Office = "All" Then
            Office = ""
        End If

        Me.RadGrid1.DataSource = oDO.GetAgencyGoals(startPP, endPP, Office, Session("UserCode"))
        Me.RadGrid1.DataBind()

    End Sub

    Public Sub GetColor(ByVal Amt As Decimal, ByVal Total_Amt As Decimal, ByVal descr As String, ByRef FlagColorDiv As HtmlControls.HtmlControl)

        If descr = "Operating Expense" Or descr = "Payroll" Or descr = "Overhead" Then

            If Amt < Total_Amt Or Amt = Total_Amt Then
                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Green)
            Else
                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Red)
            End If

        Else

            If Amt > Total_Amt Then
                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Green)
            Else
                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Red)
            End If

        End If

    End Sub

    Private Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")

            If e.Item.DataItem("DESCR") = "Gross Income" Then
                If e.Item.DataItem("AMT") < 0 Then

                    AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Red)

                Else

                    GetColor(e.Item.DataItem("ACTUAL_PCT"), e.Item.DataItem("GOAL_PCT"), e.Item.DataItem("DESCR"), FlagColorDiv)

                End If

            ElseIf e.Item.DataItem("DESCR") = "Billing" Then

                AdvantageFramework.Web.Presentation.Controls.DivHide(FlagColorDiv)

            ElseIf e.Item.DataItem("DESCR") = "Net Profit" Then

                If e.Item.DataItem("AMT") < 0 Then

                    AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Red)

                Else

                    GetColor(e.Item.DataItem("ACTUAL_PCT"), e.Item.DataItem("GOAL_PCT"), e.Item.DataItem("DESCR"), FlagColorDiv)

                End If

            Else '(Operating Expense, Payroll, Overhead)

                If e.Item.DataItem("AMT") < 0 Then

                    AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Green)

                Else

                    GetColor(e.Item.DataItem("ACTUAL_PCT"), e.Item.DataItem("GOAL_PCT"), e.Item.DataItem("DESCR"), FlagColorDiv)

                End If

            End If
        End If
    End Sub

    Private Sub LoadHeader()
        Dim startPP, endPP, Office As String
        Dim header_str As String

        startPP = Session("PPBEGIN_AGLS")
        endPP = Session("PPEND_AGLS")
        Office = Session("OFFICE_AGLS")

        header_str = "Agency Goals &nbsp;&nbsp;&nbsp;&nbsp; Period Range: " & startPP & " to " & endPP
        Me.Label1.Text = header_str

        header_str = "Office: " & Office
        Me.lblType.Text = header_str

    End Sub
End Class