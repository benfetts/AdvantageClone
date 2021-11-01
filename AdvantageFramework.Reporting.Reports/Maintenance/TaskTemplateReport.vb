Namespace Maintenance

    Public Class TaskTemplateReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""

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

        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub SubReport_TaskTemplateDetails_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubReport_TaskTemplateDetails.BeforePrint


            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    SubReport_TaskTemplateDetails.ReportSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.TaskTemplateDetailView.LoadByTaskTemplateCode(DataContext, DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.TaskTemplate).Code).ToList
                                                                             Select Entity _
                                                                             Order By Entity.ProcessOrderNumber Ascending).ToList

                End Using

            Catch ex As Exception
                SubReport_TaskTemplateDetails.ReportSource.DataSource = Nothing
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
