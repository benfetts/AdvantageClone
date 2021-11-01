Imports Telerik.Web.UI
Imports Telerik.Charting
Imports System.Data.SqlClient


Partial Public Class DesktopCurrentRatioGraph
    Inherits Webvantage.BaseDesktopObject

    Dim agy_setting As Int16

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack And Not Page.IsCallback Then
            'Check Agency Maintenance Setting
            agy_setting = getAgencySetting()

            If agy_setting <> 1 Then

                'Do not display data
                Me.DivObject.Visible = False
                Exit Sub

            Else

                LoadDropDowns()
                GetCurrentPP()

            End If

            LoadChart()

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
        Session("OFFICE_CRG") = ""

    End Sub

    Private Function GetCurrentPP() As String
        Dim currentPeriod, firstPeriod As String
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        firstPeriod = oDO.getStartPeriod()
        currentPeriod = oDO.getEndPeriod()

        Me.ddPPBegin.SelectedValue = firstPeriod
        Me.ddPPEnd.SelectedValue = currentPeriod
        Session("PPBEGIN_CRG") = firstPeriod
        Session("PPEND_CRG") = currentPeriod

    End Function

    Public ratio, assets, liabs As Double

    Private Sub LoadChart()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim dr As SqlDataReader
        Dim startPP, endPP, Office As String

        startPP = Me.ddPPBegin.SelectedValue
        endPP = Me.ddPPEnd.SelectedValue
        Office = Me.ddOffice.SelectedValue

        If startPP > endPP Then

            Me.ShowMessage("Please enter valid Periods.")

            Me.ddPPBegin.SelectedValue = CStr(Session("PPBEGIN_CRG"))
            Me.ddPPEnd.SelectedValue = CStr(Session("PPEND_CRG"))
            startPP = Me.ddPPBegin.SelectedValue
            endPP = Me.ddPPEnd.SelectedValue

        End If

        Session("PPBEGIN_CRG") = startPP
        Session("PPEND_CRG") = endPP
        Session("OFFICE_CRG") = Office

        If Office = "All" Then
            Office = ""
        End If

        Try
            dr = oDO.GetCurrentRatio(startPP, endPP, Office, Session("UserCode"))

            If dr.HasRows Then
                dr.Read()
                assets = dr.GetDouble(2)
                liabs = dr.GetDouble(3)
                ratio = dr.GetDouble(4)
            End If
            'Me.LblRatio.Text = ratio.ToString("#,##0.00")

        Catch
            Err.Raise(Err.Number, "Class:dt_currentratio_graph Routine:LoadChart", Err.Description)
        End Try

        Try

            cCharting.GetPieChart_CurrentRatio(RadHtmlChartCurrentRatio, assets, liabs, "Current Ratio: " & ratio.ToString("N2"))

        Catch ex As Exception

        End Try

        Try
            dr.Close()
        Catch ex As Exception
        End Try

    End Sub

    Public Function WriteXML() As String
        Return cCharting.getFCXMLData_CurrRatioPie(assets, liabs, "")
    End Function

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Dim image As String

        image = butRefresh.ImageUrl
        If image <> "~/Images/lock16.png" Then
            LoadChart()
        End If
    End Sub

    Private Sub ddOffice_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles ddOffice.SelectedIndexChanged
        LoadChart()
    End Sub

    Private Sub ddPPBegin_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPBegin.SelectedIndexChanged
        LoadChart()

    End Sub

    Private Sub ddPPEnd_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPEnd.SelectedIndexChanged
        LoadChart()

    End Sub
End Class

