Imports System.Drawing.Printing

Namespace Proofing

    Public Class FeedbackSummaryReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private Data As Generic.List(Of FullAssetRow) = Nothing

#End Region

#Region " Properties "
        Public Property SecuritySession As AdvantageFramework.Security.Session = Nothing
        Public Property AlertID As Integer = 0
        Public Property EmployeeTimezoneOffset As Decimal? = 0
        Public Property IsClientPortal As Boolean = False
        Public Property ClientContactID As Integer = 0
        Public Property HideSystemComments As Boolean = False
        Public Property CultureCode As String = "en-US"
        Private Property _FeedbackSummary As AdvantageFramework.Proofing.Classes.FeedbackSummary = Nothing

#End Region

#Region " Methods "

#Region "  Show Form Methods "


#End Region
#Region "  Form Event Handlers "
        Private Sub FeedbackSummaryReport_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint

            LoadData()

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As PrintEventArgs) Handles PageHeader.BeforePrint


        End Sub

#End Region
#Region "  Control Event Handlers "
        Private Sub SubReport_Assets_BeforePrint(sender As Object, e As PrintEventArgs) Handles SubReport_Assets.BeforePrint

            Try

                SubReport_Assets.ReportSource.DataSource = Data

            Catch ex As Exception
                SubReport_Assets.ReportSource.DataSource = Nothing
            End Try

        End Sub

#End Region
        Private Sub LoadData()

            If SecuritySession IsNot Nothing AndAlso AlertID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Dim AlertController As New AdvantageFramework.Controller.Desktop.AlertController(SecuritySession)
                    Dim Alert As AdvantageFramework.DTO.Desktop.Alert = Nothing
                    Dim Offset As Decimal = 0
                    Dim AllComments As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertComment) = Nothing
                    Dim AllAssets As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertAttachment) = Nothing

                    Data = New List(Of FullAssetRow)

                    If EmployeeTimezoneOffset IsNot Nothing AndAlso EmployeeTimezoneOffset > 0 Then

                        Offset = CType(EmployeeTimezoneOffset, Decimal)

                    End If

                    Alert = AlertController.LoadAlert(DbContext, AlertID, ClientContactID, Offset, 0, IsClientPortal)

                    If Alert IsNot Nothing Then

                        'AllComments = AlertController.LoadAlertComments(AlertID, 0, False, IsClientPortal)
                        AllAssets = AlertController.LoadAlertAttachments(SecuritySession, DbContext, AlertID, Offset, IsClientPortal)

                        Me.Label_ProofTitle.Text = Alert.Subject
                        Me.Label_Description.Text = Alert.Body
                        Me.Label_Template.Text = Alert.AlertAssignmentTemplateName
                        Me.Label_CurrentState.Text = Alert.AlertStateName

                        Me.Label_ClientName.Text = Alert.ClientCode & " - " & Alert.ClientName
                        Me.Label_DivisionName.Text = Alert.DivisionCode & " - " & Alert.DivisionName
                        Me.Label_ProductName.Text = Alert.ProductCode & " - " & Alert.ProductName

                        If Alert.JobDescription = Alert.JobComponentDescription Then

                            Me.Label_Job.Text = Alert.JobAndComponentNumbers & " - " & Alert.JobComponentDescription

                        Else

                            Me.Label_Job.Text = Alert.JobAndComponentNumbers & " - " & Alert.JobDescription & "/" & Alert.JobComponentDescription

                        End If

                        Me.Label_Priority.Text = Alert.PriorityDescription

                        If Alert.StartDate IsNot Nothing Then

                            Me.Label_StartDate.Text = CType(Alert.StartDate, Date).ToShortDateString

                        Else

                            Me.Label_StartDate.Text = ""

                        End If
                        If Alert.DueDate IsNot Nothing Then

                            Me.Label_DueDate.Text = CType(Alert.DueDate, Date).ToShortDateString

                        Else

                            Me.Label_DueDate.Text = ""

                        End If
                        If String.IsNullOrWhiteSpace(Alert.TimeDue) = False Then

                            Me.Label_TimeDue.Text = Alert.TimeDue

                        Else

                            Me.Label_TimeDue.Text = ""

                        End If
                        If AllAssets IsNot Nothing And AllAssets.Count > 0 Then

                            Dim Row As FullAssetRow = Nothing

                            For Each Asset As AdvantageFramework.DTO.Desktop.AlertAttachment In AllAssets

                                Row = Nothing
                                Row = New FullAssetRow

                                Row.Asset = Asset

                                Row.Comments = AlertController.LoadAlertComments(Alert.ID, Asset.DocumentID, Me.HideSystemComments, Me.IsClientPortal)
                                'If AllComments IsNot Nothing Then

                                '    Try

                                '        Row.Comments = (From Entity In AllComments
                                '                        Where (Entity.DocumentID Is Nothing OrElse
                                '                                  Entity.DocumentID = Asset.DocumentID)).ToList()

                                '    Catch ex As Exception
                                '    End Try

                                'End If

                                Data.Add(Row)

                            Next

                        End If

                    End If

                End Using

            End If

        End Sub

#End Region

    End Class
    Public Class FullAssetRow

        Public Property Asset As AdvantageFramework.DTO.Desktop.AlertAttachment = Nothing
        Public Comments As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertComment) = Nothing

        Sub New()

            Asset = New DTO.Desktop.AlertAttachment
            Comments = New List(Of DTO.Desktop.AlertComment)

        End Sub

    End Class

End Namespace
