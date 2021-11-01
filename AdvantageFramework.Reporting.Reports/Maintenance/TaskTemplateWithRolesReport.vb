Namespace Maintenance

    Public Class TaskTemplateWithRolesReport

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
        Private Sub SSubReport_TaskTemplateWithRoles_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubReport_TaskTemplateWithRoles.BeforePrint

            'objects
            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing

            Try

                TaskTemplate = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.TaskTemplate)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SubReport_TaskTemplateWithRoles.ReportSource.DataSource = AdvantageFramework.Database.Procedures.TaskTemplateWithRolesComplexType.Load(DbContext, TaskTemplate.Code) _
                                                                              .OrderBy(Function(Entity) Entity.PhaseID) _
                                                                              .ThenBy(Function(Entity) Entity.TaskCode).ToList

                End Using

            Catch ex As Exception
                SubReport_TaskTemplateWithRoles.ReportSource.DataSource = Nothing
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
