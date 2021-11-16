Namespace FinanceAndAccounting

    Public Class PaymentManagerReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Date As String = String.Empty
        Private _BankCode As String = String.Empty
        Private _CheckRunID As String = String.Empty
        Private _AgencyName As String = String.Empty
        Private _Bank As AdvantageFramework.Database.Entities.Bank = Nothing
        Private _CheckRegister As AdvantageFramework.Database.Entities.CheckRegister = Nothing

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
        Public WriteOnly Property BankCode As String
            Set(value As String)
                _BankCode = value
            End Set
        End Property
        Public WriteOnly Property CheckRunID As String
            Set(value As String)
                _CheckRunID = value
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

        Private Sub PaymentManagerReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, _BankCode)

                Try

                    _CheckRegister = AdvantageFramework.Database.Procedures.CheckRegister.Load(DbContext).FirstOrDefault(Function(Entity) Entity.BankCode = _BankCode AndAlso Entity.CheckRunID = _CheckRunID)

                Catch ex As Exception
                    _CheckRegister = Nothing
                End Try

            End Using

        End Sub
        Private Sub PaymentManagerReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            Dim PaymentManagerReports As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.PaymentManagerReport) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    PaymentManagerReports = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.FinanceAndAccounting.PaymentManagerReport)(String.Format(AdvantageFramework.Controller.FinanceAndAccounting.PaymentManagerController.APCheckInfoSQLStatement, _BankCode, _CheckRunID)).ToList

                Catch ex As Exception
                    PaymentManagerReports = Nothing
                End Try

            End Using

            Me.DataSource = PaymentManagerReports

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            XrLabelPageFooter_Date.Text = _Date
            XrLabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            XrLabelPageHeader_Agency.Text = _AgencyName

            XrLabelPageHeader_BankCode.Text = _BankCode
            XrLabelPageHeader_Account.Text = If(_Bank IsNot Nothing, _Bank.AccountNumber, String.Empty)
            XrLabelPageHeader_CheckRunID.Text = _CheckRunID
            XrLabelPageHeader_ChecksDated.Text = If(_CheckRegister IsNot Nothing, _CheckRegister.CheckDate.ToShortDateString, String.Empty)
            XrLabelPageHeader_ExportUserID.Text = If(_Session IsNot Nothing, _Session.UserCode, String.Empty)

            XrLabelPageHeader_GLTransaction.Text = If(_CheckRegister IsNot Nothing, If(_CheckRegister.GLTransaction.HasValue, _CheckRegister.GLTransaction.GetValueOrDefault(0), String.Empty), String.Empty)
            XrLabelPageHeader_PostPeriod.Text = If(_CheckRegister IsNot Nothing, _CheckRegister.PostPeriodCode, String.Empty)

        End Sub

#End Region

#End Region

    End Class

End Namespace
