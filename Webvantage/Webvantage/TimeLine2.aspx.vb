Imports System
Imports System.Data.SqlClient

Public Class TimeLine2
    Inherits Webvantage.BaseChildPage

    Public strJobNo As String
    Public strJobCompNo As String
    Public strPeriod As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_TrafficTimeline)

        SetPanelControls()
    End Sub

    Private Sub SetPanelControls()
        Try


            'Me.butPrint = Me.RadPanelBar.Items(0).Items(0).FindControl("butPrint")

            Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=traffictimeline&type=job&client=%&division=%&product=%&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value);return false;")
            Me.hlJobComp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtJobComp.ClientID & "&type=jobcomptimeline&client=%&division=%&product=%&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")

            'Me.butPrint.Attributes.Add("onclick", "window.open('timeline_p.aspx?JobNo=" & strJobNo & "&JobCompNo=" & strJobCompNo & "&Period=" & strPeriod & "', 'PopLookup','screenX=100,left=100,screenY=100,top=100,width=800,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")


        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub butRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefresh.Click
        Dim otimeline As cTraffic = New cTraffic(Session("ConnString"), Session("UserID"))
        Dim ds As DataSet
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))

        'these fields are passed for the print screen.
        strJobNo = Me.txtJob.Text
        strJobCompNo = Me.txtJobComp.Text
        strPeriod = Me.rbPeriod.SelectedValue
        Try
            If Me.txtJob.Text = "" Or Me.txtJobComp.Text = "" Then
                Me.dgTimeline.DataSource = Nothing
                Page.DataBind()
                Me.ShowMessage("You need to enter a Job Number and Job Component Number.")
                Exit Sub
            End If

            If IsNumeric(Me.txtJob.Text.Trim) = False Or IsNumeric(Me.txtJobComp.Text.Trim) = False Then
                Me.ShowMessage("Invalid job/comp number.")
                Exit Sub
            End If
            If myVal.ValidateJobCompNumber(Me.txtJob.Text, Me.txtJobComp.Text) = False Then
                Me.ShowMessage("This is not a valid job/component!")
                Exit Sub
            End If
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.txtJob.Text.Trim, Me.txtJobComp.Text.Trim) = False Then
                Me.ShowMessage("Access to this job/component is denied.")
                Exit Sub
            End If


            Me.dlJobs.DataSource = otimeline.GetJobHeader(CInt(Me.txtJob.Text), CInt(Me.txtJobComp.Text))
            ds = otimeline.GetTimeline(CInt(Me.txtJob.Text), CInt(Me.txtJobComp.Text), Me.rbPeriod.SelectedValue, Session("UserCode"))
            If ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns(8))
                Me.dgTimeline.DataSource = ds.Tables(0).DefaultView
                Page.DataBind()
            Else
                Me.dgTimeline.DataSource = Nothing
                Page.DataBind()
                Me.ShowMessage("No Records Returned")
            End If
            ds.Dispose()
        Catch ex As Exception
            If InStr(ex.Message.ToString(), "DataTable") > 0 Or InStr(ex.Message.ToString(), "Column") > 0 Then
                Me.ShowMessage("Schedules spanning more than a year will not display properly in this view.")
            Else
                Me.ShowMessage(ex.Message.ToString.Replace("/", "_").Replace("'", ""))
            End If
        End Try

    End Sub

    Protected Sub dgTimeLine_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles dgTimeline.ItemDataBound

        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            If Not IsDBNull(e.Item.DataItem(6)) And Not IsDBNull(e.Item.DataItem(7)) Then
                Dim lcStart As String = e.Item.DataItem(6)
                Dim lcEnd As String = e.Item.DataItem(7)
                Dim ldStart As Date = e.Item.DataItem(6)
                Dim ldEnd As Date = e.Item.DataItem(7)
                e.Item.Cells(6).Text = LoGlo.FormatDate(ldStart.ToShortDateString)
                e.Item.Cells(7).Text = LoGlo.FormatDate(ldEnd.ToShortDateString)
                If ldStart > ldEnd Then
                    e.Item.Cells(6).ForeColor = System.Drawing.Color.Red
                    e.Item.Cells(7).ForeColor = System.Drawing.Color.Red
                End If
            End If
        ElseIf e.Item.ItemType = ListItemType.Header Then

        End If

    End Sub

    Private Sub butClear_Click(sender As Object, e As EventArgs) Handles butClear.Click
        Try
            Me.txtJob.Text = ""
            Me.txtJobComp.Text = ""
            Page.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class