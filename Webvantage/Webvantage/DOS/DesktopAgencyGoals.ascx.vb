Imports System.Data.SqlClient
Imports Webvantage.MiscFN

Partial Public Class DesktopAgencyGoals
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
                LoadGrid(True)
            End If
        End If
    End Sub

    Private Function getAgencySetting() As Int16
        Dim AgySetting As Int16
        Dim oDesktop As New cDesktopObjects(CStr(Session("ConnString")))

        AgySetting = oDesktop.GetAgencySetting("AGENCY_GOALS_ON")
        Return AgySetting
    End Function

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Dim image As String

        image = butRefresh.ImageUrl
        If image <> "~/Images/lock16.png" Then
            LoadGrid(True)
        End If
    End Sub

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
        Session("OFFICE_AGLS") = ""

    End Sub

    Private Sub GetColor(ByVal Amt As Decimal, ByVal Total_Amt As Decimal, ByVal descr As String, ByRef ColorDiv As HtmlControls.HtmlControl)

        If descr = "Operating Expense" Or descr = "Payroll" Or descr = "Overhead" Then

            If Amt < Total_Amt Or Amt = Total_Amt Then
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ColorDiv, "standard-green")
            Else
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ColorDiv, "standard-red")
            End If

        Else

            If Amt > Total_Amt Then
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ColorDiv, "standard-green")
            Else
                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ColorDiv, "standard-red")
            End If

        End If

    End Sub

    Private Function GetCurrentPP() As String
        Dim currentPeriod, firstPeriod As String
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        firstPeriod = oDO.getStartPeriod()
        currentPeriod = oDO.getEndPeriod()

        Me.ddPPBegin.SelectedValue = firstPeriod
        Me.ddPPEnd.SelectedValue = currentPeriod
        Session("PPBEGIN_AGLS") = firstPeriod
        Session("PPEND_AGLS") = currentPeriod

    End Function

    Private Sub LoadGrid(ByVal ab_bind As Boolean)
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim startPP, endPP, Office As String

        startPP = Me.ddPPBegin.SelectedValue
        endPP = Me.ddPPEnd.SelectedValue
        Office = Me.ddOffice.SelectedValue

        If startPP > endPP Then
            Me.ShowMessage("Please enter valid Periods.")
            Me.ddPPBegin.SelectedValue = CStr(Session("PPBEGIN_AGLS"))
            Me.ddPPEnd.SelectedValue = CStr(Session("PPEND_AGLS"))
            Exit Sub
        End If

        Session("PPBEGIN_AGLS") = startPP
        Session("PPEND_AGLS") = endPP
        Session("OFFICE_AGLS") = Office

        If Office = "All" Then
            Office = ""
        End If

        Me.Radgridratio.DataSource = oDO.GetAgencyGoals(startPP, endPP, Office, Session("UserCode"))
        If ab_bind Then
            Me.Radgridratio.DataBind()
        End If

    End Sub

    Private Sub Radgridratio_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles Radgridratio.ItemDataBound

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")

            If e.Item.DataItem("DESCR") = "Gross Income" Then

                If e.Item.DataItem("AMT") < 0 Then

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FlagColorDiv, "standard-red")

                Else

                    GetColor(e.Item.DataItem("ACTUAL_PCT"), e.Item.DataItem("GOAL_PCT"), e.Item.DataItem("DESCR"), FlagColorDiv)

                End If

            ElseIf e.Item.DataItem("DESCR") = "Billing" Then

                AdvantageFramework.Web.Presentation.Controls.DivHide(FlagColorDiv)

            ElseIf e.Item.DataItem("DESCR") = "Net Profit" Then

                If e.Item.DataItem("AMT") < 0 Then

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FlagColorDiv, "standard-red")
                Else

                    GetColor(e.Item.DataItem("ACTUAL_PCT"), e.Item.DataItem("GOAL_PCT"), e.Item.DataItem("DESCR"), FlagColorDiv)

                End If

            Else '(Operating Expense, Payroll, Overhead)
                If e.Item.DataItem("AMT") < 0 Then

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(FlagColorDiv, "standard-green")

                Else

                    GetColor(e.Item.DataItem("ACTUAL_PCT"), e.Item.DataItem("GOAL_PCT"), e.Item.DataItem("DESCR"), FlagColorDiv)

                End If

            End If
        End If
    End Sub

    Private Sub Radgridratio_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles Radgridratio.SortCommand
        LoadGrid(True)
    End Sub

    Private Sub ddOffice_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddOffice.SelectedIndexChanged
        LoadGrid(True)

    End Sub

    Private Sub ddPPBegin_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPBegin.SelectedIndexChanged
        LoadGrid(True)

    End Sub

    Private Sub ddPPEnd_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPEnd.SelectedIndexChanged
        LoadGrid(True)

    End Sub
End Class