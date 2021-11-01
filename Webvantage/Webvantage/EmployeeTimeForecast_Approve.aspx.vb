Public Class EmployeeTimeForecast_Approve
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext)

        'objects
        Dim EmployeeTimeForecastOfficeDetailID As Integer = 0

        If _EmployeeTimeForecastOfficeDetail Is Nothing Then

            If DbContext IsNot Nothing Then

                Try

                    If Request.QueryString("EmployeeTimeForecastOfficeDetailID") IsNot Nothing Then

                        EmployeeTimeForecastOfficeDetailID = CType(Request.QueryString("EmployeeTimeForecastOfficeDetailID"), Integer)

                    End If

                Catch ex As Exception
                    EmployeeTimeForecastOfficeDetailID = 0
                End Try

                Try

                    _EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecast")
                                                         Where Entity.ID = EmployeeTimeForecastOfficeDetailID
                                                         Select Entity).Single

                Catch ex As Exception
                    _EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End If

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_CreateRevision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim ApprovedEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadEmployeeTimeForecastOfficeDetail(DbContext)

                If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    Try

                        ApprovedEmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCode(DbContext, _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode).ToList.Where(Function(ETFOD) ETFOD.EmployeeTimeForecastID = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID AndAlso ETFOD.OfficeCode = _EmployeeTimeForecastOfficeDetail.OfficeCode AndAlso ETFOD.AssignedToEmployeeCode = _EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode).ToList.Where(Function(OfficeDetail) OfficeDetail.IsApproved).Single

                    Catch ex As Exception
                        ApprovedEmployeeTimeForecastOfficeDetail = Nothing
                    Finally

                        If ApprovedEmployeeTimeForecastOfficeDetail IsNot Nothing Then

                            LabelWarningMessage.Text = "Approval of revision (" & AdvantageFramework.StringUtilities.PadWithCharacter(ApprovedEmployeeTimeForecastOfficeDetail.RevisionNumber, 3, "0", True) & ") will be " &
                                                       "removed and this revision (" & AdvantageFramework.StringUtilities.PadWithCharacter(_EmployeeTimeForecastOfficeDetail.RevisionNumber, 3, "0", True) & ") will be approved."

                        End If

                    End Try

                    RadToolBarButtonApprove.Enabled = True

                Else

                    RadToolBarButtonApprove.Enabled = False

                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarEmployeeTimeForecast_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecast.ButtonClick

        'objects
        Dim ApprovedEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

        Select Case e.Item.Value

            Case "Approve"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadEmployeeTimeForecastOfficeDetail(DbContext)

                    If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        Try

                            ApprovedEmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCode(DbContext, _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode).ToList.Where(Function(ETFOD) ETFOD.EmployeeTimeForecastID = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID AndAlso ETFOD.OfficeCode = _EmployeeTimeForecastOfficeDetail.OfficeCode AndAlso ETFOD.AssignedToEmployeeCode = _EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode).ToList.Where(Function(OfficeDetail) OfficeDetail.IsApproved).Single

                        Catch ex As Exception
                            ApprovedEmployeeTimeForecastOfficeDetail = Nothing
                        Finally

                            If ApprovedEmployeeTimeForecastOfficeDetail IsNot Nothing Then

                                ApprovedEmployeeTimeForecastOfficeDetail.IsApproved = False
                                ApprovedEmployeeTimeForecastOfficeDetail.ApprovedByEmployeeCode = Nothing
                                ApprovedEmployeeTimeForecastOfficeDetail.ApprovedDate = Nothing

                                AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, ApprovedEmployeeTimeForecastOfficeDetail)

                            End If

                        End Try

                        _EmployeeTimeForecastOfficeDetail.IsApproved = True
                        _EmployeeTimeForecastOfficeDetail.ApprovedByEmployeeCode = Session("empcode").ToString
                        _EmployeeTimeForecastOfficeDetail.ApprovedDate = Now

                        AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, _EmployeeTimeForecastOfficeDetail)

                    End If

                End Using

        End Select

        Me.CloseThisWindow()

    End Sub

#End Region

#End Region

End Class