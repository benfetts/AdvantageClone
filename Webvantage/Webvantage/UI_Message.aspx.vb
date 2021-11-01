Imports System.IO
Imports System.Collections.Generic

Public Class UI_Message
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

    Private _Message As AdvantageFramework.Web.CookieMessages.Methods.Message
    Private _MessageCookie As HttpCookie

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    'Page
    Private Sub UI_Message_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs IsNot Nothing Then

            If IsNumeric(qs.GetValue("msgid")) = True Then

                _Message = CType(CType(qs.GetValue("msgid"), Integer), AdvantageFramework.Web.CookieMessages.Methods.Message)

            End If

        End If

        Select Case _Message
            Case AdvantageFramework.Web.CookieMessages.Methods.Message.SetColors
                Me.RadMultiPageMessages.FindPageViewByID("RadPageViewSetColors").Selected = True

        End Select

    End Sub

    'Messages:
#Region " Set Colors "

    Private Sub RadButtonDontBother_Click(sender As Object, e As EventArgs) Handles RadButtonDontBother.Click

        Dim Messages As New AdvantageFramework.Web.CookieMessages.Methods(_Session.ConnectionString, _Session.UserCode)
        Dim Message As New AdvantageFramework.Web.CookieMessages.CookieMessage

        Message.MessageType = _Message
        Message.RemindAgain = False
        Message.LastReminded = Today.Date
        Messages.Update(Message)

        Me.CloseThisWindow()

    End Sub
    Private Sub RadButtonRemindMeLater_Click(sender As Object, e As EventArgs) Handles RadButtonRemindMeLater.Click

        Dim Messages As New AdvantageFramework.Web.CookieMessages.Methods(_Session.ConnectionString, _Session.UserCode)
        Dim Message As New AdvantageFramework.Web.CookieMessages.CookieMessage

        Message.MessageType = _Message
        Message.RemindAgain = True
        Message.LastReminded = Today.Date
        Messages.Update(Message)

        Me.CloseThisWindow()

    End Sub

#End Region

#End Region

End Class

