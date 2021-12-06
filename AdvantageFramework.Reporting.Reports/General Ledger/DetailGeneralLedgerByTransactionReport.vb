Namespace GeneralLedger

    Public Class DetailGeneralLedgerByTransactionReport

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
        Private Sub EmptyGroupFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            e.Cancel = DoPostPeriodRowsExistForCurrentAccount()

        End Sub
        Private Sub EmptyGroupHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            e.Cancel = DoPostPeriodRowsExistForCurrentAccount()

        End Sub

#End Region

#End Region

    End Class

End Namespace
