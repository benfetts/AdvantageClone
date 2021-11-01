Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Data.Entity

Namespace Models

    Public Class AlertModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertID As Integer
        Public Property AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing

#End Region

#Region " Methods "

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal AlertID As Integer)

            Me.AlertID = AlertID

            If Me.AlertID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Me.AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                End Using

            End If

            If Me.AlertEntity Is Nothing Then Me.AlertEntity = New AdvantageFramework.Database.Entities.Alert

        End Sub

#End Region

    End Class

    Public Class AlertRecipientModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#End Region

    End Class
    Public Class AlertCommentModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#End Region

    End Class
    Public Class AlertAttachmentModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
