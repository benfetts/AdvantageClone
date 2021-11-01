Public Class MediaOrder_StatusHistory
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _OrderNumber As Integer = 0
    Private _LineNumber As Short = 0
    Private _RevisionNumber As Short = 0
    Private _SequenceNumber As Short = 0
    Private _OrderType As AdvantageFramework.Web.QueryString.MediaOrderType


#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadGridMediaStatus_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridMediaStatus.ItemDataBound
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridMediaStatus_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridMediaStatus.NeedDataSource
        Try
            Dim MediaOrderStatus As AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Me.RadGridMediaStatus.DataSource = AdvantageFramework.MediaManager.LoadMediaManagerOrderStatus(DbContext, _OrderType, _OrderNumber, _LineNumber).OrderByDescending(Function(MediaStatus) MediaStatus.RevisedDate).ThenByDescending(Function(MediaStatus) MediaStatus.ID).ToList

            End Using

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Page "



#End Region

#End Region

    Private Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Me._OrderType = Me.CurrentQuerystring.MediaType
            Me._OrderNumber = Me.CurrentQuerystring.MediaOrderNumber
            Me._LineNumber = Me.CurrentQuerystring.MediaOrderLineNumber
            Me._RevisionNumber = Me.CurrentQuerystring.MediaOrderRevisionNumber
            Me._SequenceNumber = Me.CurrentQuerystring.MediaOrderSequenceNumber

        Catch ex As Exception

        End Try
    End Sub

    
End Class