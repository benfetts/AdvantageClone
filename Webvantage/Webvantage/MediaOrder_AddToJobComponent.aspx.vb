Imports Telerik.Web.UI

Public Class MediaOrder_AddToJobComponent
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0
    Private _LoadOnlyAvailable As Boolean = False

    Private _HasInternet As Boolean = False
    Private _HasMagazine As Boolean = False
    Private _HasNewspaper As Boolean = False
    Private _HasOutOfHome As Boolean = False
    Private _HasRadio As Boolean = False
    Private _HasTV As Boolean = False

    Private _MediaLines As New Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)
    Private _MediaLinesInJob As New Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)
    Private _MediaLinesAvailable As New Generic.List(Of AdvantageFramework.Media.Classes.MediaOrderLine)

#End Region

#Region " Properties "


#End Region

#Region " Methods "

#Region " Controls "


#End Region
#Region " Page "

    Private Sub MediaOrder_AddToJobComponent_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me._JobNumber = Me.CurrentQuerystring.JobNumber
        Me._JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber

    End Sub

#End Region

    Private Sub Load()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Me._MediaLines = AdvantageFramework.Media.LoadByJobAndComponent(DbContext, _JobNumber, _JobComponentNumber, True, _Session)

            For Each ml As AdvantageFramework.Media.Classes.MediaOrderLine In Me._MediaLines

                If ml.IsInJob = True Then

                    Me._MediaLinesInJob.Add(ml)

                Else

                    Me._MediaLinesAvailable.Add(ml)

                End If

            Next

            Me.RadListBoxMediaOrdersCurrentlyInJob.DataSource = Me._MediaLinesInJob


            Me.RadListBoxAvailableMediaOrders.DataSource = Me._MediaLinesAvailable

        End Using


    End Sub
    Private Function SetDataKey(ByRef MediaOrderLine As AdvantageFramework.Media.Classes.MediaOrderLine) As String

        Dim DataKeyString As String = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", MediaOrderLine.OrderType,
                                                                                       MediaOrderLine.OrderNumber,
                                                                                       MediaOrderLine.LineNumber,
                                                                                       MediaOrderLine.RevisionNumber,
                                                                                       MediaOrderLine.SequenceNumber,
                                                                                       MediaOrderLine.JobNumber,
                                                                                       MediaOrderLine.JobComponentNumber,
                                                                                       MediaOrderLine.IsInJob)

        Return DataKeyString

    End Function
    Private Function ParseDataKey(ByVal DataKey As String) As AdvantageFramework.Media.Classes.MediaOrderLine

        Try

            Dim mol As New AdvantageFramework.Media.Classes.MediaOrderLine
            Dim ar As String()
            ar = DataKey.Split("|")

            mol.OrderType = ar(0)
            mol.OrderNumber = ar(1)
            mol.LineNumber = ar(2)
            mol.RevisionNumber = ar(3)
            mol.SequenceNumber = ar(4)
            If IsNumeric(ar(5)) Then mol.JobNumber = ar(5)
            If IsNumeric(ar(6)) Then mol.JobComponentNumber = ar(6)
            If ar(7) IsNot Nothing AndAlso ar(7).ToString().ToLower() = "true" Then mol.IsInJob = True

            Return mol

        Catch ex As Exception

            Me.ShowMessage(ex.Message.ToString())
            Return Nothing

        End Try

    End Function

#End Region

End Class