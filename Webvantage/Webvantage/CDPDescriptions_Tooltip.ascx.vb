Imports System.Data
Imports System.Data.SqlClient

Partial Public Class CDPDescriptions_Tooltip
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub getCDPDescriptions(ByVal cl As String, ByVal div As String, ByVal prd As String)
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim cl_desc, div_desc, prd_desc As String

        'Get Client description
        SQL_STRING = "SELECT CL_NAME FROM CLIENT WHERE CL_CODE = '" & cl & "'"

        Try
            dr = oSQL.ExecuteReader(Session("ConnString"), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CDPDescriptions_Tooltip Routine:getCDPDescriptions", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            cl_desc = dr.GetString(0)
            Me.lblClient.Text = cl_desc
        End If

        dr.Close()

        'Get Division description
        SQL_STRING = "SELECT DIV_NAME FROM DIVISION WHERE CL_CODE = '" & cl & "' AND DIV_CODE = '" & div & "'"

        Try
            dr = oSQL.ExecuteReader(Session("ConnString"), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CDPDescriptions_Tooltip Routine:getCDPDescriptions", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            div_desc = dr.GetString(0)
            Me.lblDivision.Text = div_desc
        End If

        dr.Close()

        'Get Product description
        SQL_STRING = "SELECT PRD_DESCRIPTION FROM PRODUCT WHERE CL_CODE = '" & cl & "' AND DIV_CODE = '" & div & "' AND PRD_CODE = '" & prd & "'"

        Try
            dr = oSQL.ExecuteReader(Session("ConnString"), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CDPDescriptions_Tooltip Routine:getCDPDescriptions", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            prd_desc = dr.GetString(0)
            Me.lblProduct.Text = prd_desc
        End If

        dr.Close()

    End Sub

End Class