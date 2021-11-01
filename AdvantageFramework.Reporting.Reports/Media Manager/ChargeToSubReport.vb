Namespace MediaManager

    Public Class ChargeToSubReport

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

        Private Sub ChargeToSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '    _PrintCardInfo = DbContext.ExecuteStoreQuery(Of Boolean)("SELECT CAST(AGY_SETTINGS_VALUE as bit) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'VCC_INCLUDE_CARDINFO'").FirstOrDefault

            'End Using

        End Sub
        Private Sub LabelDetail_ChargeTo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_ChargeTo.BeforePrint

            'objects
            Dim EncryptedChargeToParts() As String = Nothing
            Dim CardNumber As String = Nothing

            'If _PrintCardInfo Then

            EncryptedChargeToParts = Split(_ChargeTo, " - ")

            If EncryptedChargeToParts IsNot Nothing AndAlso EncryptedChargeToParts.Count = 3 Then

                CardNumber = AdvantageFramework.Security.Encryption.ASCIIDecoding(EncryptedChargeToParts(0))

                LabelDetail_ChargeTo.Text = "MasterCard " & Mid(CardNumber, 1, 4) & "-" & Mid(CardNumber, 5, 4) & "-" & Mid(CardNumber, 9, 4) & "-" & Mid(CardNumber, 13, 4) & " - " & EncryptedChargeToParts(1) & " - " & AdvantageFramework.Security.Encryption.ASCIIDecoding(EncryptedChargeToParts(2))

            Else

                LabelDetail_ChargeTo.Text = _ChargeTo

            End If

            'End If

        End Sub
        'Private Sub LabelDetail_CardNumberLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_CardNumberLabel.BeforePrint

        '    If Not _PrintCardInfo Then

        '        e.Cancel = True

        '    End If

        'End Sub

#End Region

    End Class

End Namespace