Namespace FinanceAndAccounting

    Public Class AccountPayableBatchSummaryDataEntryOrderReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Date As String = String.Empty
        Private _ForUser As String = Nothing
        Private _ReportRange As String = Nothing
        Private _AgencyName As String = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property ForUser As String
            Set(value As String)
                _ForUser = value
            End Set
        End Property
        Public WriteOnly Property ReportRange As String
            Set(value As String)
                _ReportRange = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub AccountPayableBatchSummaryDataEntryOrderReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_ReportCriteria.Text = "For User: " & _ForUser & Space(5) & _ReportRange
            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelDetail_CurrencyCode_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_CurrencyCode.BeforePrint

            If String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).CurrencyCode) Then

                e.Cancel = True

            Else

                LabelDetail_CurrencyCode.Text = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).CurrencyCode & ":"

            End If

        End Sub
        Private Sub LabelDetail_ForeignAmount_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_ForeignAmount.BeforePrint

            If String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).CurrencyCode) Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
