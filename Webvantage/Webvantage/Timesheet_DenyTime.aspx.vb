Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports Telerik.Web.UI
Imports Webvantage.cGlobals

Partial Public Class Timesheet_DenyTime
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "



#End Region
#Region " Page "

    Private Sub Timesheet_DenyTime_Load(sender As Object, e As EventArgs) Handles Me.Load

        MiscFN.ResponseRedirect("Timesheet_MissingTime.aspx", True)

    End Sub

#End Region

#End Region

End Class