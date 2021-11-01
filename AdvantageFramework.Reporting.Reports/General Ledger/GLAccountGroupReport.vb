Namespace GeneralLedger

    Public Class GLAccountGroupReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _Date As String = String.Empty

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

#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub GLAccountGroupReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub Label_CodeType_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_CodeType.BeforePrint

            'objects
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing
            Dim LabelText As String = ""

            Try

                AccountGroup = DirectCast(Me.GetCurrentRow(), AdvantageFramework.Database.Entities.AccountGroup)

                If AccountGroup IsNot Nothing Then

                    Select Case AccountGroup.Type.GetValueOrDefault(1)

                        Case 1

                            LabelText = "Full Account Group"

                        Case 2

                            LabelText = "Base Account Group"

                    End Select

                End If

            Catch ex As Exception
                LabelText = ""
            Finally
                Label_CodeType.Text = LabelText
            End Try

        End Sub
        Private Sub SubReport_AccountGroupDetails_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrSubreport1.BeforePrint

            'objects
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing

            Try

                AccountGroup = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.AccountGroup)

            Catch ex As Exception
                AccountGroup = Nothing
            End Try

            If AccountGroup IsNot Nothing Then

                Try

                    DirectCast(XrSubreport1.ReportSource, AdvantageFramework.Reporting.Reports.GeneralLedger.GLAccountGroupFullAccountCodeSubReport).AccountGroupType = AccountGroup.Type

                Catch ex As Exception

                End Try

                DirectCast(XrSubreport1.ReportSource, AdvantageFramework.Reporting.Reports.GeneralLedger.GLAccountGroupFullAccountCodeSubReport).Session = _Session

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    XrSubreport1.ReportSource.DataSource = AdvantageFramework.Database.Procedures.AccountGroupDetail.LoadByAccountGroupCode(DbContext, AccountGroup.Code).ToList

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
