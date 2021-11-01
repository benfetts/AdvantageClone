Imports System.Data
Imports System.Data.SqlClient
Partial Public Class DesktopTrafficStatistics
    Inherits Webvantage.BaseDesktopObject

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Me.IsPostBack Then
                Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfMonth()
                Me.RadDatePickerEndDate.SelectedDate = LoGlo.LastOfMonth()
                LoadData()
            End If
            If Me.DropTrafficFunctions.Items.Count <= 0 Then
                LoadTrafficStatus()
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadTrafficStatus()
        Try
            Me.DropTrafficFunctions.Items.Add(New Telerik.Web.UI.RadComboBoxItem("[Select A Status]", "none"))
            Dim od As Webvantage.cDropDowns = New Webvantage.cDropDowns(Session("ConnString"))
            Dim dr As SqlDataReader
            dr = od.GetTrafficCodes
            If dr.HasRows Then
                Do While dr.Read
                    Me.DropTrafficFunctions.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dr(0).ToString() & " - " & dr(1).ToString(), dr(0).ToString()))
                Loop
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadData()
        Session("ds_DTO_JobStatistics") = ""
        Session("ds_DTO_JobStatistics") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        Try
            Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
            Dim sDate As Date
            Dim eDate As Date

            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                sDate = Me.RadDatePickerStartDate.SelectedDate
            Else
                sDate = LoGlo.FirstOfMonth()
            End If
            If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
                eDate = Me.RadDatePickerEndDate.SelectedDate
            Else
                eDate = LoGlo.LastOfMonth()
            End If
            dt = oDTO.GetJobStatistics(Session("UserID"), sDate, eDate, Me.DropTrafficFunctions.SelectedValue.ToString(), Me.ChkIsClosedStatus.Checked, "", "")

            If dt.Rows.Count > 0 Then
                ds.Tables.Add(dt.Copy())
                Session("ds_DTO_JobStatistics") = ds
            Else
                Session("ds_DTO_JobStatistics") = Nothing
            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

    Public Function WriteXML() As String
        Return cCharting.getFCXMLData_MultiColumn3D_JobStatistics(Session("ds_DTO_JobStatistics"), Me.DropTrafficFunctions.SelectedValue, Me.ChkIsClosedStatus.Checked)
    End Function

End Class