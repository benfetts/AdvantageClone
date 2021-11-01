Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel
Imports Webvantage.cGlobals


Partial Public Class jobVersions
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private JobNum As Integer
    Private JobCompNum As Int16
    Private versionNum As Integer
    Private JobVerHdrID As Integer
    Private IndentSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
    Private TitleSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
    Private RowSpacer As String = "&nbsp;&nbsp;"
    Private OpenSpacerTable As String = "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center""><tr><td width=""550"" align=""left"" valign=""top"">"
    Private MiddleSpacerTable As String = "</td><td width=""10"" align=""center"" valign=""middle"">&nbsp;</td><td align=""left"" valign=""top"">"
    Private CloseSpacerTable As String = "</td></tr></table>"
    Private DivSpacer As String = "<div style="" width: 600px; overflow-x: scroll; text-align: left;""> "
    Private DivEnding As String = "</div>"
    Private SQL_STRING As String
    Private dr As SqlDataReader
    Private oSQL As SqlHelper

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadToolbarJobVersions_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarJobVersions.ButtonClick
        Select Case e.Item.Value

            Case "New"

                Session("NewSaved") = 0
                Dim StrURL As String = "jobVerNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum
                Me.OpenWindow("Select a Template", StrURL)

            Case "Copy"

                Try

                    Session("NewSaved") = 0
                    Dim StrURL As String = "jobVerNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&mode=copy"
                    Me.OpenWindow("Select a Template", StrURL)

                Catch ex As Exception
                End Try

            Case "Refresh"
                Me.RadGridJobVersions.Rebind()

        End Select
    End Sub

    Private Sub RadGridJobVersions_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobVersions.ItemDataBound

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim ImageButtonViewDetails As ImageButton = CType(e.Item.FindControl("ImageButtonViewDetails"), ImageButton)

            If ImageButtonViewDetails IsNot Nothing Then

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "jobVerTmplt.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                qs.JobVersionHeaderID = e.Item.DataItem("JOB_VER_HDR_ID")
                qs.Add("JobVerHdrID", e.Item.DataItem("JOB_VER_HDR_ID"))
                qs.Add("JobVerCPID", e.Item.DataItem("CREATED_BY_CP"))
                qs.Add("NewSaved", "0")

                ImageButtonViewDetails.Attributes.Add("onclick", Me.HookUpOpenWindow("Form", qs.ToString(True)))

            End If

        End If

    End Sub
    Private Sub RadGridJobVersions_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobVersions.NeedDataSource
        Dim job, comp, jobVersHdrID, idx As Integer
        Dim version_nbr As Int16
        Dim code, desc, jvtmpdesc As String

        job = Me.JobNum
        comp = Me.JobCompNum

        Dim SQL_STRING As String = ""

        SQL_STRING = " SELECT JVH.JOB_VER_HDR_ID, JVH.JOB_VER_SEQ_NBR, JVH.JOB_VER_DESC, JOB_VER_TMPLT_HDR.JV_TMPLT_DESC "
        SQL_STRING &= ", RIGHT(REPLICATE('0', 3) +  CAST(JVH.JOB_VER_SEQ_NBR AS VARCHAR), 3) + ' - ' + JOB_VER_TMPLT_HDR.JV_TMPLT_DESC + ISNULL(' - '+  JVH.JOB_VER_DESC,'') AS TEXT_DISPLAY, ISNULL(JVH.CREATED_BY_CP,0) AS CREATED_BY_CP"
        SQL_STRING &= " FROM JOB_VER_HDR JVH INNER JOIN JOB_VER_TMPLT_HDR ON JVH.JV_TMPLT_CODE = JOB_VER_TMPLT_HDR.JV_TMPLT_CODE"
        SQL_STRING &= " WHERE JVH.JOB_NUMBER = " & job
        SQL_STRING &= " AND JVH.JOB_COMPONENT_NBR = " & comp

        Me.RadGridJobVersions.DataSource = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, SQL_STRING, "DtData")

    End Sub

#End Region
#Region " Page "

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        Me.JobNum = Request.QueryString("JobNum")
        Me.JobCompNum = Request.QueryString("JobCompNum")

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        If qs.JobNumber > 0 Then
            Me.JobNum = qs.JobNumber
        End If
        If qs.JobComponentNumber > 0 Then
            Me.JobCompNum = qs.JobComponentNumber
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobVersions)
            Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
            Dim desc As String

            desc = MyJV.GetAgencyDesc()
            If desc <> "" Then
                Me.PageTitle = desc & " for Job/Comp " & Me.JobNum.ToString.PadLeft(6, "0") & "/" & Me.JobCompNum.ToString.PadLeft(2, "0")
            End If

            If Request.QueryString("newFrom") = "jvt" Then
                Session("NewSaved") = 0
                Dim StrURL As String = "jobVerNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum
                Me.OpenWindow("Select a Template", StrURL, 325, 625)
            End If

        Else
            Select Case Me.EventArgument
                Case "Cancel"
                    'Me.CloseThisWindow()
                Case "OpenNewVersion"
                    Dim JobVerHdrID As Integer
                    JobVerHdrID = Session("JobVerHdrID")

                    'Open the Data entry screen
                    Dim strURL As String = "jobVerTmplt.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&JobVerHdrID=" & JobVerHdrID & "&NewSaved=1"
                    Me.OpenWindow("", strURL, , , True)
            End Select
        End If

        If Me.IsClientPortal = True Then
            Me.RadToolbarJobVersions.Items(3).Visible = False
        End If

    End Sub

#End Region

#End Region


End Class
