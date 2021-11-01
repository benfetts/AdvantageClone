Namespace Employee

    Public Class EmployeeRateHistoryReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _Date As String = String.Empty
        Private _SortedBy As String = ""

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
        Public WriteOnly Property SortedBy As String
            Set(value As String)
                _SortedBy = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentEmployee() As AdvantageFramework.Database.Views.Employee

            Try

                LoadCurrentEmployee = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Views.Employee)

            Catch ex As Exception
                LoadCurrentEmployee = Nothing
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub EmployeeRateHistoryReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageFooter_Date.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _SortedBy

        End Sub
        Private Sub DetailReportRateHistory_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportRateHistory.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeRateHistoryList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRateHistory) = Nothing

            Try

                Employee = LoadCurrentEmployee()

                If Employee IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        EmployeeRateHistoryList = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRateHistory)

                        EmployeeRateHistoryList.AddRange(AdvantageFramework.Database.Procedures.EmployeeRateHistory.LoadByEmployeeCode(DbContext, Employee.Code).Include("DepartmentTeam").Include("EmployeeTitle").ToList)

                        BindingSourceRateHistory.DataSource = EmployeeRateHistoryList

                    End Using

                End If

            Catch ex As Exception
                BindingSourceRateHistory.DataSource = Nothing
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
