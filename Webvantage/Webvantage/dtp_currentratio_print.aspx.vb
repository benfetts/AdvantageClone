Imports System.Data.SqlClient
Public Class dtp_currentratio_print
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim startPP, endPP, Office As String

        startPP = Session("PPBEGIN_CR")
        endPP = Session("PPEND_CR")
        Office = Session("OFFICE_CR")

        If Office = "All" Then
            Office = ""
        End If

        LoadHeader()

        Me.RadGrid2.DataSource = oDO.GetCurrentRatio(startPP, endPP, Office, Session("UserCode"))
        Me.RadGrid2.DataBind()

    End Sub

    Private _Goal As Decimal = 0
    Public Sub GetColor(ByVal Ratio As Decimal, ByRef FlagDiv As HtmlControls.HtmlControl, ByRef FlagImage As WebControls.Image)

        If Me._Goal = 0 Then

            Dim oSQL As SqlHelper
            Dim SQL_STRING As String
            Dim dr As SqlDataReader

            SQL_STRING = "SELECT CAST(AGY_SETTINGS_VALUE AS DECIMAL(3,1)) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'CUR_RATIO_GOAL'"

            Try
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)

                Do While dr.Read

                    Me._Goal = dr.GetDecimal(0)

                Loop

            Catch

                Err.Raise(Err.Number, "Class:dt_currentratio Routine:GetColor", Err.Description)

            Finally

            End Try

            dr.Close()

        End If

        If Ratio < Me._Goal Then

            AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Red)

        End If

        If Ratio = Me._Goal Or Ratio > Me._Goal Then

            AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.LightGreen)

        End If

    End Sub

    Private Sub LoadHeader()
        Dim startPP, endPP, Office As String
        Dim header_str As String

        startPP = Session("PPBEGIN_CR")
        endPP = Session("PPEND_CR")
        Office = Session("OFFICE_CR")

        header_str = "Current Ratio &nbsp;&nbsp;&nbsp;&nbsp; Period Range: " & startPP & " to " & endPP
        Me.Label1.Text = header_str

        header_str = "Office: " & Office
        Me.lblType.Text = header_str

    End Sub

    Private Sub RadGrid2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
            Dim FlagImage As Web.UI.WebControls.Image = e.Item.FindControl("ImageFlag")

            GetColor(e.Item.DataItem("RATIO"), FlagColorDiv, FlagImage)

        End If
    End Sub

End Class