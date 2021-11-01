Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports Webvantage.cGlobals

Partial Public Class Timesheet_MissingTime
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private Property HasMissingTime As Boolean
        Get
            If ViewState("HasMissingTime") Is Nothing Then
                Return False
            Else
                Return CType(ViewState("HasMissingTime"), Boolean)
            End If
        End Get
        Set(value As Boolean)
            ViewState("HasMissingTime") = value
        End Set
    End Property
    Private Property HasDeniedTime As Boolean
        Get
            If ViewState("HasDeniedTime") Is Nothing Then
                Return False
            Else
                Return CType(ViewState("HasDeniedTime"), Boolean)
            End If
        End Get
        Set(value As Boolean)
            ViewState("HasDeniedTime") = value
        End Set
    End Property


#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadGridMissingTime_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridMissingTime.ItemCommand
        Select Case e.CommandName
            Case "OpenTimesheet"
                HttpContext.Current.Session("TimesheetStartDate") = CType(e.CommandArgument, DateTime)
                Dim NavigateUrl As String = "Timesheet.aspx?dto=0&FromWindow=MissingTime&TSdate=" & e.CommandArgument
                Me.OpenWindow("", NavigateUrl)
        End Select
    End Sub
    Private Sub RadGridMissingTime_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridMissingTime.NeedDataSource

        Try

            Dim oSQL As SqlHelper
            Dim arParams(0) As SqlParameter
            Dim dt As New DataTable

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = Session("UserCode").ToString
            arParams(0) = paramUserID

            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_get_missing_time_employee", "DtData", arParams)

            RadGridMissingTime.DataSource = dt

            If dt IsNot Nothing Then

                Me.HasMissingTime = dt.Rows.Count > 0

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RadGridDeniedTime_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDeniedTime.ItemCommand
        Select Case e.CommandName

            Case "OpenTimesheet"

                HttpContext.Current.Session("TimesheetStartDate") = CType(e.CommandArgument, DateTime)
                Dim NavigateUrl As String = "Timesheet.aspx?dto=0&FromWindow=DeniedTime&TSdate=" & e.CommandArgument
                Me.OpenWindow("", NavigateUrl)

        End Select
    End Sub
    Private Sub RadGridDeniedTime_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDeniedTime.NeedDataSource

        Try

            Dim dto As New cDesktopObjects(Session("ConnString"))
            Dim dt As New DataTable

            dt = dto.GetDeniedTimeEmployee(Session("UserCode")).Tables(0)

            Me.RadGridDeniedTime.DataSource = dt

            If dt IsNot Nothing Then

                Me.HasDeniedTime = dt.Rows.Count > 0

            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region
#Region " Page "

    Private Sub Timesheet_MissingTime_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Private Sub Timesheet_MissingTime_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Me.DivMissingTime.Visible = Me.HasMissingTime
        Me.DivDeniedTime.Visible = Me.HasDeniedTime

        Me.MissingTimeHeader.Visible = False
        Me.DeniedTimeHeader.Visible = False

        If Me.HasMissingTime = True AndAlso Me.HasDeniedTime = True Then

            Me.Page.Title = String.Format("Missing/denied time for {0}", Me.GetUserEmpName())

            Me.MissingTimeHeader.Visible = True
            Me.DeniedTimeHeader.Visible = True

        ElseIf Me.HasMissingTime = True AndAlso Me.HasDeniedTime = False Then

            Me.Page.Title = String.Format("Missing time for {0}", Me.GetUserEmpName())

        ElseIf Me.HasMissingTime = False AndAlso Me.HasDeniedTime = True Then

            Me.Page.Title = String.Format("Denied time for {0}", Me.GetUserEmpName())

        Else

            Me.CloseThisWindow()

        End If

    End Sub

#End Region

    Private Function GetUserEmpName() As String

        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim SQLStr As String
        Dim UserEmpName As String = ""

        SQLStr = "SELECT dbo.udf_get_empl_name(EMP_CODE, 'FML') FROM SEC_USER WHERE USER_CODE = '" & Session("UserCode").ToString() & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQLStr)

            If dr.HasRows Then

                dr.Read()
                UserEmpName = dr.GetString(0)

            End If
        Catch ex As Exception
        End Try

        Return UserEmpName

    End Function


#End Region



End Class