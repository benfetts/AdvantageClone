Namespace Controller.Billing

    <Serializable()>
    Public Class PaymentCenterDashboardController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub

#End Region

    End Class

End Namespace
