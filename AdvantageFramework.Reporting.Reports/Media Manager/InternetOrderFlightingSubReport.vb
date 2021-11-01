Namespace MediaManager

    Public Class InternetOrderFlightingSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ChargeTo As String = Nothing
        'Private _PrintCardInfo As Boolean = False

#End Region

#Region " Properties "

        'Public WriteOnly Property Session As AdvantageFramework.Security.Session
        '    Set(ByVal value As AdvantageFramework.Security.Session)
        '        _Session = value
        '    End Set
        'End Property
        Public WriteOnly Property ChargeTo As String
            Set(value As String)
                _ChargeTo = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace