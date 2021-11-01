Imports System.Drawing.Printing
Imports DevExpress.XtraRichEdit

Namespace Proofing
    Public Class FeedbackSummaryAssetCommentsSubReport

#Region " Constants "

        Public Const BulletSpacer As String = "  •  "
        Public Const Indent As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

        Public Const ContainerTemplate As String = "<div><span style=""font-family: Arial !important;"">{0}</span></div>"
        Public Const NameAndDateTemplate As String = "<div><span style=""font-family: Arial; font-size: 8px; font-weight: bold;"">{0}</span></div>"
        Public Const SmallTextTemplate As String = "<div><span style=""font-family: Arial; font-size: 8px;"">{0}</span></div>"
        Public Const CommentTemplate As String = "<div><span style=""font-family: Arial; font-size: 10px;"">{0}</span></div>"
        Public Const ReplyTemplate As String = "<div style=""margin-left: 15px;"">{0}</div>"
        Public Const ReplyReplyTemplate As String = "<div style=""margin-left: 30px;"">{0}</div>"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Public Comment As DTO.Desktop.AlertComment = Nothing
        Public DisplayDate As String = String.Empty

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "
        Private Sub FeedbackSummaryAssetCommentsSubReport_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint


        End Sub

#End Region

#Region "  Control Event Handlers "
        Private Sub Label_NameAndDate_BeforePrint(sender As Object, e As PrintEventArgs) Handles Label_NameAndDate.BeforePrint

            Dim ReplyString As String = String.Empty

            Try

                Comment = TryCast(Me.GetCurrentRow, DTO.Desktop.AlertComment)

            Catch ex As Exception
                Comment = Nothing
            End Try
            If Comment IsNot Nothing Then

                Me.Label_NameAndDate.Text = ""

                Dim CommentSB As New Text.StringBuilder

                CommentSB.Append(SetNameAndDate(Comment.EmployeeFullName, Comment.CustodyStartDate, Comment.CustodyEndDate))
                CommentSB.AppendFormat(CommentTemplate, Comment.Comment)

                If Comment.MarkupID IsNot Nothing AndAlso Comment.MarkupID > 0 Then

                    CommentSB.AppendFormat(SmallTextTemplate, "Has Markup?  Yes")

                Else

                    CommentSB.AppendFormat(SmallTextTemplate, "Has Markup?  No")

                End If

                If Comment.Replies IsNot Nothing AndAlso Comment.Replies.Count > 0 Then

                    For Each Reply As AdvantageFramework.DTO.Desktop.AlertComment In Comment.Replies

                        ReplyString = String.Empty

                        ReplyString = SetNameAndDate(Reply.EmployeeFullName, Reply.CustodyStartDate, Reply.CustodyEndDate)
                        ReplyString &= String.Format(CommentTemplate, Reply.Comment)

                        CommentSB.AppendFormat(ReplyTemplate, ReplyString)

                        If Reply.Replies IsNot Nothing AndAlso Reply.Replies.Count > 0 Then

                            For Each ReplyReply As AdvantageFramework.DTO.Desktop.AlertComment In Reply.Replies

                                ReplyString = String.Empty

                                ReplyString = SetNameAndDate(ReplyReply.EmployeeFullName, ReplyReply.CustodyStartDate, ReplyReply.CustodyEndDate)
                                ReplyString &= String.Format(CommentTemplate, ReplyReply.Comment)

                                CommentSB.AppendFormat(ReplyReplyTemplate, ReplyString)

                            Next

                        End If

                    Next

                End If

                Me.RichText_Comment.Html = String.Format(ContainerTemplate, CommentSB.ToString())

            Else

                Me.Label_NameAndDate.Text = ""
                Me.RichText_Comment.Html = ""

            End If

        End Sub


        Private Function SetNameAndDate(ByVal Name As String, ByVal StartDate As Date?, ByVal EndDate As Date?) As String

            Dim NameAndDate As String = String.Empty
            Dim DisplayDate As String = String.Empty

            'If StartDate Is Nothing AndAlso EndDate Is Nothing Then

            '    DisplayDate = String.Empty

            'ElseIf StartDate Is Nothing AndAlso EndDate Is Nothing Then

            '    DisplayDate = StartDate.ToString() & " - " & EndDate.ToString()

            'ElseIf StartDate IsNot Nothing AndAlso EndDate Is Nothing Then

            '    DisplayDate = StartDate.ToString()

            'ElseIf StartDate Is Nothing AndAlso EndDate IsNot Nothing Then

            '    DisplayDate = EndDate.ToString()

            'End If

            ''based on typescript function for date string (module-base.ts)
            If StartDate IsNot Nothing AndAlso EndDate Is Nothing Then

                DisplayDate = StartDate.ToString()

            ElseIf StartDate IsNot Nothing AndAlso EndDate IsNot Nothing Then

                If CType(StartDate, Date).ToShortDateString() = CType(EndDate, Date).ToShortDateString() Then

                    DisplayDate = CType(StartDate, Date).ToString() & " - " & CType(EndDate, Date).ToShortTimeString

                Else

                    DisplayDate = CType(StartDate, Date).ToString() & " - " & CType(EndDate, Date).ToString()

                End If

            End If

            NameAndDate = Name & If(String.IsNullOrWhiteSpace(DisplayDate) = True, "", BulletSpacer & DisplayDate.ToUpper())

            Return String.Format(NameAndDateTemplate, NameAndDate)

        End Function

#End Region

#End Region

    End Class

End Namespace
