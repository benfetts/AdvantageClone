Namespace Controller.Maintenance.General

    Public Class TimezoneController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub

#End Region

    End Class

End Namespace
