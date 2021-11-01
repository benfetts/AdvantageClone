Namespace GeneralLedger

    Public Class OfficeAndDepartmentCrossReferenceReport

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

        Private Sub OfficeAndDepartmentCrossReferenceReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub SubReport_OfficeCrossReference_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles SubReport_OfficeCrossReference.BeforePrint

            Try

                'DirectCast(SubReport_OfficeCrossReference.ReportSource, AdvantageFramework.Reporting.Reports.GeneralLedger.OfficeCrossReferenceSubReport).Session = _Session

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SubReport_OfficeCrossReference.ReportSource.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.Load(DbContext).Include("Office").ToList

                End Using

            Catch ex As Exception
                SubReport_OfficeCrossReference.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub SubReport_DepartmentCrossReference_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles SubReport_DepartmentCrossReference.BeforePrint

            Try

                'DirectCast(SubReport_OfficeCrossReference.ReportSource, AdvantageFramework.Reporting.Reports.GeneralLedger.OfficeCrossReferenceSubReport).Session = _Session

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SubReport_DepartmentCrossReference.ReportSource.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.Load(DbContext).Include("DepartmentTeam").ToList

                End Using

            Catch ex As Exception
                SubReport_DepartmentCrossReference.ReportSource.DataSource = Nothing
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
