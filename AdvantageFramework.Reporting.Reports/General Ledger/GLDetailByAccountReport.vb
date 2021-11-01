Namespace GeneralLedger

    Public Class GLDetailByAccountReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _Date As String = String.Empty
        Private _FromPostPeriod As String = ""
        Private _ToPostPeriod As String = ""

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public WriteOnly Property FromPostPeriod As String
            Set(value As String)
                _FromPostPeriod = value
            End Set
        End Property
        Public WriteOnly Property ToPostPeriod As String
            Set(value As String)
                _ToPostPeriod = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function DoPostPeriodRowsExistForCurrentAccount() As Boolean

            Dim GeneralLedgerDetailByAccountReport As AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport = Nothing
            Dim RowsExist As Boolean = False

            Try

                GeneralLedgerDetailByAccountReport = GetCurrentRow()

                If GeneralLedgerDetailByAccountReport IsNot Nothing Then

                    RowsExist = (From item In DirectCast(Me.DataSource, IEnumerable(Of AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport))
                                 Where Not String.IsNullOrWhiteSpace(item.PostPeriodCode) AndAlso
                                       item.AccountCode = GeneralLedgerDetailByAccountReport.AccountCode
                                 Select item).Any

                End If

            Catch ex As Exception
                RowsExist = False
            Finally
                DoPostPeriodRowsExistForCurrentAccount = RowsExist
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub GLDetailByAccountReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _FromPostPeriod & " to " & _ToPostPeriod

        End Sub
        Private Sub Detail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            Dim GeneralLedgerDetailByAccountReport As AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport = Nothing

            GeneralLedgerDetailByAccountReport = GetCurrentRow()

            If GeneralLedgerDetailByAccountReport IsNot Nothing Then

                If String.IsNullOrWhiteSpace(GeneralLedgerDetailByAccountReport.PostPeriodCode) Then

                    e.Cancel = DoPostPeriodRowsExistForCurrentAccount()

                End If

            End If

        End Sub
        Private Sub PostPeriodGroupFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PostPeriodGroupFooter.BeforePrint

            Dim GeneralLedgerDetailByAccountReport As AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport = Nothing

            GeneralLedgerDetailByAccountReport = GetCurrentRow()

            If GeneralLedgerDetailByAccountReport IsNot Nothing Then

                If String.IsNullOrWhiteSpace(GeneralLedgerDetailByAccountReport.PostPeriodCode) Then

                    e.Cancel = DoPostPeriodRowsExistForCurrentAccount()

                End If

            End If

        End Sub
        Private Sub LabelAccountEndingBalance_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelAccountEndingBalance.BeforePrint

            'objects
            Dim GeneralLedgerDetailByAccountReport As AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport = Nothing
            Dim EndingBalance As Decimal = Nothing
            Dim BeginningBalance As Decimal = Nothing

            GeneralLedgerDetailByAccountReport = GetCurrentRow()

            If GeneralLedgerDetailByAccountReport IsNot Nothing Then

                Try

                    EndingBalance = (From item In DirectCast(Me.DataSource, IEnumerable(Of AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport))
                                     Where item.AccountCode = GeneralLedgerDetailByAccountReport.AccountCode AndAlso
                                           item.PostPeriodCode <= GeneralLedgerDetailByAccountReport.PostPeriodCode
                                     Select [Balance] = item.DebitAmount - item.CreditAmount).Sum()

                    BeginningBalance = (From item In DirectCast(Me.DataSource, IEnumerable(Of AdvantageFramework.Reporting.Database.Classes.GeneralLedgerDetailByAccountReport))
                                        Where item.AccountCode = GeneralLedgerDetailByAccountReport.AccountCode
                                        Select [Balance] = item.AccountBeginningBalance).Sum()

                    DirectCast(sender, DevExpress.XtraReports.UI.XRLabel).Text = (BeginningBalance + EndingBalance).ToString("c")

                Catch ex As Exception

                End Try

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
