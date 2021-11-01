Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Web.UI
Imports Webvantage.MiscFN

Partial Public Class DesktopCurrentRatio
    Inherits Webvantage.BaseDesktopObject

    Dim agy_setting As Int16

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.ratioRadGrid.Skin = MiscFN.SetRadGridSkin()
        If Not Page.IsPostBack Then
            'Check Agency Maintenance Setting
            agy_setting = getAgencySetting()
            If agy_setting <> 1 Then
                'Do not display data
                Me.DivObject.Visible = False
                Exit Sub
            Else
                LoadDropDowns()
                GetCurrentPP()
                Me.CurRatioRadGrid.Rebind()
            End If
        End If

    End Sub
    Private Function getAgencySetting() As Int16
        Dim AgySetting As Int16
        Dim oDesktop As New cDesktopObjects(CStr(Session("ConnString")))

        AgySetting = oDesktop.GetAgencySetting("CURRENT_RATIO_ON")
        Return AgySetting
    End Function

    Private Sub LoadDropDowns()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.ddPPBegin
            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()
        End With

        With Me.ddPPEnd
            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()
        End With

        With Me.ddOffice
            .DataSource = oDD.GetOfficesEmp(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With
        Session("OFFICE_CR") = ""

    End Sub

    Private _CurrentRatioGoal As Decimal = CDec(0.0)

    Public Sub GetColor(ByVal Ratio As Decimal, ByRef ColorDiv As HtmlControls.HtmlControl)

        'If Ratio = 0 Then

        '    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ColorDiv, "standard-green")
        '    Exit Sub

        'End If

        If _CurrentRatioGoal = 0 Then

            Dim oSQL As SqlHelper
            Dim SQL_STRING As String
            Dim dr As SqlDataReader

            SQL_STRING = "SELECT CAST(AGY_SETTINGS_VALUE AS DECIMAL(3,1)) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'CUR_RATIO_GOAL'"

            Try
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)

                If dr.HasRows Then

                    dr.Read()
                    _CurrentRatioGoal = dr.GetDecimal(0)

                Else

                    _CurrentRatioGoal = 1.5

                End If

            Catch

                _CurrentRatioGoal = 1.5

            End Try

            dr.Close()

        End If

        If Ratio < _CurrentRatioGoal Then

            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ColorDiv, "standard-red")

        Else

            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ColorDiv, "standard-green")

        End If

    End Sub

    Private Function GetCurrentPP() As String
        Dim currentPeriod, firstPeriod As String
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        firstPeriod = oDO.getStartPeriod()
        currentPeriod = oDO.getEndPeriod()

        Me.ddPPBegin.SelectedValue = firstPeriod
        Me.ddPPEnd.SelectedValue = currentPeriod
        Session("PPBEGIN_CR") = firstPeriod
        Session("PPEND_CR") = currentPeriod

    End Function

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click

        Me.CurRatioRadGrid.Rebind()

    End Sub

    Private Sub CurRatioRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles CurRatioRadGrid.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
            GetColor(e.Item.DataItem("RATIO"), FlagColorDiv)

        End If
    End Sub

    Private Sub CurRatioRadGrid_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles CurRatioRadGrid.NeedDataSource
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim startPP, endPP, Office As String

        startPP = Me.ddPPBegin.SelectedValue
        endPP = Me.ddPPEnd.SelectedValue
        Office = Me.ddOffice.SelectedValue

        If startPP > endPP Then

            Me.ShowMessage("Please enter valid Periods.")
            Me.ddPPBegin.SelectedValue = CStr(Session("PPBEGIN_CR"))
            Me.ddPPEnd.SelectedValue = CStr(Session("PPEND_CR"))
            'Exit Sub

        End If

        Session("PPBEGIN_CR") = startPP
        Session("PPEND_CR") = endPP
        Session("OFFICE_CR") = Office

        If Office = "All" Then

            Office = ""

        End If

        Me.CurRatioRadGrid.DataSource = oDO.GetCurrentRatio(startPP, endPP, Office, Session("UserCode"))

    End Sub
    Private Sub ddOffice_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles ddOffice.SelectedIndexChanged
        CurRatioRadGrid.Rebind()
    End Sub

    Private Sub ddPPBegin_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPBegin.SelectedIndexChanged
        CurRatioRadGrid.Rebind()
    End Sub

    Private Sub ddPPEnd_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPEnd.SelectedIndexChanged
        CurRatioRadGrid.Rebind()
    End Sub

End Class